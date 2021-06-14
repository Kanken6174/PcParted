using logicPC.CardData;
using logicPC.Conteneurs;
using logicPC.Downloaders;
using logicPC.Importers;
using logicPC.Settings;
using Microsoft.Win32.SafeHandles;
using Swordfish.NET.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace logicPC.Gestionnaires
{
    /// <summary>
    /// Classe dédiée à la gestion des listes d'utilisateur
    /// </summary>
    public class GestionnaireListes : INotifyPropertyChanged
    {
        /// <summary>
        /// Gestionnaire de persistance
        /// </summary>
        public IPersistanceManager Persistance { get; set; }

        public void LoadUL()
        {
            var data = Persistance.Load();
            if (data != null)
                foreach (var j in data)
                    AjouterListe(j.Key, j.Value);
        }

        public void SaveUL()
        {
            Persistance.Save(UserListsStorage);
        }

        /// <summary>
        /// Données du manager / gestionnaire de UserListes
        /// </summary>
        public Dictionary<string, Card> Data;
        public readonly Dictionary<string, Card> ProtectedData;
        public ConcurrentObservableDictionary<string, Stream> StreamStorage;
        public ConcurrentObservableDictionary<string, UserList> UserListsStorage { get; set; }
        public ConcurrentObservableDictionary<Card, int> CardDataToDisplay { get; set; }

        public string ActiveKey { get; set; }
        public int ActiveList { get; set; }

        /// <summary>
        /// Evènements
        /// </summary>
        public event PropertyChangedEventHandler DataNotifier;  //Les classes abonnées à cet évènement recevront toutes les notifications envoyées par NotifyAction()
        public event PropertyChangedEventHandler PropertyChanged;   //PropertyChanged de GestionnaireListes... peu fonctionnel et remplacé par DataNotifier.
        public event PropertyChangedEventHandler RenderRefreshNeeded;   //Téléchargement d'une bitmapImage terminé.


        /// <summary>
        /// Données utilisées pour les filtres
        /// </summary>
        public List<string> ArchitecturedList { get; private set; } = new();
        public List<string> ManufacturersList { get; private set; } = new();
        public double MaxPrice { get; private set; } = new();
        public double MinPrice { get; private set; } = new();
        public double MinHashrate { get; private set; } = new();
        public double MaxHashrate { get; private set; } = new();
        public int MaxPowerDraw { get; private set; } = new();

        /// <summary>
        /// Constructeur de la classe GestionnaireListes
        /// </summary>
        /// <param name="persistance">Optionnel, définit le type de persistance à la déclaration d'objet</param>
        public GestionnaireListes(IPersistanceManager persistance = null)
        {
            CardDataToDisplay = new();
            if (!Directory.Exists(SettingsLogic.CachePATH))
            {
                Directory.CreateDirectory(SettingsLogic.CachePATH);
            }
            if (persistance != null)
                Persistance = persistance;
            ActiveKey = new string("");
            ActiveList = 0;
            CardDataToDisplay = new();
            ProtectedData = ImporterManager.ImportAll().Result;
            Data = ProtectedData;
            getMaxes();
            UserListsStorage = new();
            StreamStorage = new();
            StreamStorage.PropertyChanged += RenderRefreshNeeded;
            DataNotifier += Ignore;
        }


        /// <summary>
        /// Comme son nom l'indique, récupère tous les extrêmes du dataset (min/max)
        /// </summary>
        private void getMaxes()
        {
            ManufacturersList.Add("Tous");
            ArchitecturedList.Add("Toutes");
            foreach (KeyValuePair<string, Card> card in ProtectedData)
            {
                if (!ManufacturersList.Contains(card.Value.Informations.Manufacturer))
                    ManufacturersList.Add(card.Value.Informations.Manufacturer);

                if (!ArchitecturedList.Contains(card.Value.Informations.Architecture))
                    ArchitecturedList.Add(card.Value.Informations.Architecture);

                if (card.Value.Theorics.Price > MaxPrice)
                    MaxPrice = card.Value.Theorics.Price;

                if (card.Value.Theorics.Price < MinPrice)
                    MinPrice = card.Value.Theorics.Price;

                if (card.Value.Theorics.EnergyConsumption > MaxPowerDraw)
                    MaxPowerDraw = card.Value.Theorics.EnergyConsumption;

                if (card.Value.Theorics.Hashrate < MinHashrate)
                    MinHashrate = card.Value.Theorics.Hashrate;

                if (card.Value.Theorics.Hashrate > MaxHashrate)
                    MaxHashrate = card.Value.Theorics.Hashrate;
            }        
        }

        /// <summary>
        /// Appellée une fois au démarrage (par les vues pour optimiser la performance). Va remplir StreamStorage de streams pointant sur les différentes Uri correspondant à chaque image.
        /// </summary>
        /// <returns></returns>
        public async Task GetAllPics()
        {
            foreach (KeyValuePair<string, Card> carte in ProtectedData)
            {
                if (!File.Exists($@"{SettingsLogic.CachePATH}{carte.Key}.png"))
                {
                    if (carte.Value.Informations.PictureURL != new System.Uri("about:blank") && carte.Key != null)
                    {
                        try
                        {
                            StreamStorage.TryAdd(carte.Key, await PictureDownloader.GetPicture(carte.Value.Informations.PictureURL));
                            carte.Value.Informations.CarteMin = StreamStorage[carte.Key];
                        }
                        catch (TaskCanceledException)
                        {
                            carte.Value.Informations.CarteMin = null;
                        }
                        catch (System.Net.Http.HttpRequestException)
                        {
                            carte.Value.Informations.CarteMin = null;
                        }
                        catch (System.Security.Authentication.AuthenticationException
)
                        {
                            carte.Value.Informations.CarteMin = null;
                        }
                        catch (System.AccessViolationException)
                        {
                            carte.Value.Informations.CarteMin = null;
                        }
                    }
                    else
                        carte.Value.Informations.CarteMin = null;
                }
                else
                {
                    FileStream FS = File.OpenRead($@"{SettingsLogic.CachePATH}{carte.Key}.png");
                    MemoryStream MS = new();
                    FS.Position = 0;
                    await FS.CopyToAsync(MS);
                    StreamStorage.TryAdd(carte.Key, MS);
                    carte.Value.Informations.CarteMin = StreamStorage[carte.Key];
                }
            }
        }

        /// <summary>
        /// Renvoie la liste utilisateur active
        /// </summary>
        /// <returns>Une liste utilisateur UserList qui contient des cards graphiques</returns>
        public UserList GetActive() => UserListsStorage[ActiveKey];

        /// <summary>
        /// Ajoute une liste vide au dictionnaire de listes d'utilisateur
        /// </summary>
        /// <param name="nom">Le nom de la liste à ajouter</param>
        /// <returns>le nom valide qui ajouté</returns>
        public string AjouterListe(string nom, UserList toAdd)
        {
            int alreadyExists = 1;
            if (nom != null && UserListsStorage.ContainsKey(nom))
            {
                while (UserListsStorage.ContainsKey($"{nom}({alreadyExists})"))
                {
                    alreadyExists++;
                }

                nom = $"{nom}({alreadyExists})";
            }
            UserListsStorage.Add(nom, toAdd);
            return nom;
        }

        /// <summary>
        /// supprime une UserList de MesListes
        /// </summary>
        /// <param name="key">la clé (string) à supprimer du dictionnaire</param>
        /// <returns>état de réussite</returns>
        public bool SupprimeListe(string key)
        {
            if (key != null && UserListsStorage.ContainsKey(key))
            {
                bool reussi = UserListsStorage.Remove(key);
                return reussi;
            }
            return false;
        }

        /// <summary>
        /// Duplique une entrée du dictionnaire MesListes
        /// </summary>
        /// <param name="key">Clé de l'entrée à dupliquer</param>
        public void DuplicateList(string key)
        {
            if (key != null && UserListsStorage.ContainsKey(key))
            {
                UserListsStorage.TryGetValue(key, out UserList clone);
                AjouterListe(key, clone);
            }
        }

        /// <summary>
        /// Permet de renommer une UserListe dans le dictionnaire en changeant sa clé (sauvegarde,suppression et ajout)
        /// </summary>
        /// <param name="oldKey">clé d'origine dans le dictionnaire</param>
        /// <param name="newKey">nouvelle clé voulue. Cela équivaut également au nom de la liste affiché dans l'application</param>
        /// <returns>bool : succès de l'opération</returns>
        public void RenommeListe(string oldKey, string newKey)
        {
            bool isIn = UserListsStorage.TryGetValue(oldKey, out UserList temp);
            if (isIn)
            {
                UserListsStorage.Remove(oldKey);
                AjouterListe(newKey, temp ?? new());
            }
        }

        /// <summary>
        /// Un système de notification baséesur des évènements pour simplifier la communication entre certains évènements de la vue et du code-behind.
        /// Surtout utilisé pour les datagrids où le binding de données venant de plusieurs sources de type dictionnaire est compliquée...
        /// </summary>
        /// <param name="sender">L'objet envoyant la notification</param>
        /// <param name="toast">Un message string qui passe en argument/param>
        /// <param name="mode">Le type d'action demandée, optionnel/param>
        public void NotifyAction(object sender, string toast, int mode = 0)
        {
            CardDataToDisplay = new();
            if (mode == 0)
            {
                if (toast == "")
                    toast = ActiveKey;
                if(UserListsStorage.ContainsKey(toast))
                    RefreshDataToDisplay(toast);
            }
            DataNotifier.Invoke(sender, new(toast));
        }

        /// <summary>
        /// Met à jour les données que doivent afficher les datagrids clientes.
        /// </summary>
        /// <param name="key">La clé de la UserList à afficher</param>
        public void RefreshDataToDisplay(string key)
        {
            CardDataToDisplay.Clear();
            foreach (KeyValuePair<string, Card> card in UserListsStorage[key].Cards)
            {
                CardDataToDisplay.TryAdd(card.Value, UserListsStorage[key].QuantityCards[card.Key]);
            }
        }

        private void Ignore(object sender, PropertyChangedEventArgs e)
        {
            //Simplement pour éviter une exception en cas de non-utilisation
        }
    }
}