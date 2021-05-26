using logicPC.Conteneurs;
using System.Collections.Generic;
using System.ComponentModel;
using logicPC.ImportStrategies;
using logicPC.Downloaders;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Drawing;
using logicPC.CardData;
using logicPC.Importers;
using logicPC.Settings;
using Swordfish.NET.Collections;

namespace logicPC.Gestionnaires
{
    /// <summary>
    /// Classe dédiée à la gestion des listes d'utilisateur
    /// </summary>
    public class GestionnaireListes : INotifyPropertyChanged
    {
        public Dictionary<string, Card> Data;
        public IReadOnlyDictionary<string, Card> ProtectedData;
        public ConcurrentObservableSortedDictionary<string, UserList> MesListesUtilisateur { get; set; }
        public string ActiveKey = default;
        private int _activelist;
        public int ActiveList
        {
            get { return _activelist; }
            set { _activelist = value; PropertyChanged?.Invoke(nameof(_activelist), new PropertyChangedEventArgs("e")); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public GestionnaireListes()
        {
            Data = ImporterManager.ImportAll();
            ProtectedData = Data;
            MesListesUtilisateur = new();
            GetAllPics();
        }

        public async void GetAllPics()
        {
            foreach(KeyValuePair<string,Card> carte in Data)
            {
                if (carte.Value.Informations.PictureURL != new System.Uri("about:blank"))
                {
                    Stream getPicsTask = await PictureDownloader.GetPicture(carte.Value.Informations.PictureURL);
                    carte.Value.Informations.miniature = getPicsTask;
                }
                else
                    carte.Value.Informations.miniature = null;
            }
            
        }

        /// <summary>
        /// Renvoie la liste utilisateur active
        /// </summary>
        /// <returns>Une liste utilisateur UserList qui contient des cards graphiques</returns>
        public UserList GetActive() => MesListesUtilisateur[ActiveKey];
        /// <summary>
        /// Ajoute une liste vide au dictionnaire de listes d'utilisateur
        /// </summary>
        /// <param name="nom">Le nom de la liste à ajouter</param>
        /// <returns></returns>
        public void AjouterListe(string nom, UserList toAdd)
        {
            int alreadyExists = 1;
            if (nom != null && MesListesUtilisateur.ContainsKey(nom))
            {
                while (MesListesUtilisateur.ContainsKey($"{nom}({alreadyExists})"))
                {
                    alreadyExists++;
                }

                nom = $"{nom}({alreadyExists})";
            }
            MesListesUtilisateur.Add(nom, toAdd);
            
        }

        /// <summary>
        /// supprime une UserList de MesListes
        /// </summary>
        /// <param name="key">la clé (string) à supprimer du dictionnaire</param>
        /// <returns></returns>
        public bool SupprimeListe(string key)
        {
            if (key != null && MesListesUtilisateur.ContainsKey(key))
            {
                bool reussi = MesListesUtilisateur.Remove(key);
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
            if (key != null && MesListesUtilisateur.ContainsKey(key))
            {
                UserList clone;
                MesListesUtilisateur.TryGetValue(key, out clone);
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
            UserList temp = new();
            bool isIn = MesListesUtilisateur.TryGetValue(oldKey, out temp);
            if (isIn)
            {
                MesListesUtilisateur.Remove(oldKey);
                AjouterListe(newKey, temp);
                //PropertyChanged(this, new PropertyChangedEventArgs("ListesUtilisateur"));
            }
        }

    }
}