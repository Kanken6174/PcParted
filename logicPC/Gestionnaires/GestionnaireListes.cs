using logicPC.CardData;
using logicPC.Conteneurs;
using logicPC.Downloaders;
using logicPC.Importers;
using logicPC.Settings;
using Swordfish.NET.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

        public void LoadUL(string PATH=@".\UserLists\")
        {
            var data = Persistance.Load();
            foreach(var j in data)
            {
                AjouterListe(j.Key, j.Value);
            }
        }

        public void SaveUL(string PATH = @".\UserLists\")
        {
            Persistance.Save(UserListsStorage);
        }

        /// <summary>
        /// Données du manager / gestionnaire de UserListes
        /// </summary>
        public Dictionary<string, Card> Data;
        public IReadOnlyDictionary<string, Card> ProtectedData;
        public ConcurrentObservableDictionary<string, Stream> StreamStorage;
        public ConcurrentObservableSortedDictionary<string, UserList> UserListsStorage { get; set; }


        public ConcurrentObservableDictionary<int, Card> CardDataToDisplay { get; set; }

        public string ActiveKey { get; set; }

        public int ActiveList { get; set; }

        public event PropertyChangedEventHandler DataNotifier;  //Les classes abonnées à cet évènement recevront toutes les notifications envoyées par NotifyAction()

        public event PropertyChangedEventHandler PropertyChanged;   //PropertyChanged de GestionnaireListes... peu fonctionnel et remplacé par DataNotifier.

        public event PropertyChangedEventHandler RenderRefreshNeeded;   //Téléchargement d'une bitmapImage terminé.

        public GestionnaireListes(IPersistanceManager persistance)
        {
            Persistance = persistance;
            ActiveKey = new string("");
            ActiveList = 0;
            CardDataToDisplay = new();
            Data = ImporterManager.ImportAll();
            ProtectedData = Data;
            UserListsStorage = new();
            StreamStorage = new();
            StreamStorage.PropertyChanged += RenderRefreshNeeded;
            DataNotifier += Ignore;
        }

        private void Ignore(object sender, PropertyChangedEventArgs e)
        {
            //Simplement pour éviter un crash en cas de non-utilisation
        }

        /// <summary>
        /// Appellée une fois au démarrage. Va remplir StreamStorage de streams pointant sur les différentes Uri correspondant à chaque image.
        /// </summary>
        /// <returns></returns>
        public async Task GetAllPics()
        {
            foreach (KeyValuePair<string, Card> carte in ProtectedData)
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
                }
                else
                    carte.Value.Informations.CarteMin = null;
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <param name="toast">Le type d'action demandée/param>
        public void NotifyAction(object sender, string toast)
        {
            DataNotifier.Invoke(sender, new(toast));
            if (toast == "refreshDatagrids")
                CardDataToDisplay = new();
        }
    }
}