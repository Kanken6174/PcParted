using logicPC.Conteneurs;
using System.Collections.Generic;
using System.ComponentModel;
using logicPC.ImportStrategies;

namespace logicPC.Gestionnaires
{
    /// <summary>
    /// Classe dédiée à la gestion des listes d'utilisateur
    /// </summary>
    public class GestionnaireListes : INotifyPropertyChanged
    {
        public Dictionary<string, Card> Data;
        public IReadOnlyDictionary<string, Card> ProtectedData;
        public Dictionary<string, UserList> MesListesUtilisateur { get; private set; }
        public string ActiveKey = default;

        public event PropertyChangedEventHandler PropertyChanged;

        public GestionnaireListes()
        {
            Data = ImporterManager.ImportAll();
            ProtectedData = Data;
            MesListesUtilisateur = new();
        }
        public GestionnaireListes(Dictionary<string, UserList> dico, string Active)
        {
            MesListesUtilisateur = dico;
            ActiveKey = Active;
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
            if (MesListesUtilisateur.ContainsKey(nom))
            {
                while (MesListesUtilisateur.ContainsKey($"{nom}({alreadyExists})"))
                {
                    alreadyExists++;
                }

                nom = $"{nom}({alreadyExists})";
            }
            MesListesUtilisateur.TryAdd(nom, toAdd);
            //PropertyChanged(this, new PropertyChangedEventArgs("ListesUtilisateur"));
            
        }

        /// <summary>
        /// supprime une UserList de MesListes
        /// </summary>
        /// <param name="key">la clé (string) à supprimer du dictionnaire</param>
        /// <returns></returns>
        public bool SupprimeListe(string key)
        {
            //PropertyChanged(this, new PropertyChangedEventArgs("ListesUtilisateur"));
            return MesListesUtilisateur.Remove(key);
        }

        /// <summary>
        /// Duplique une entrée du dictionnaire MesListes
        /// </summary>
        /// <param name="key">Clé de l'entrée à dupliquer</param>
        /// <returns></returns>
        public void DuplicateList(string key)
        {
            if (MesListesUtilisateur.ContainsKey(key))
            {
                UserList clone;
                MesListesUtilisateur.TryGetValue(key, out clone);
                AjouterListe(key, clone);
            }
            //PropertyChanged(this, new PropertyChangedEventArgs("ListesUtilisateur"));
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
                PropertyChanged(this, new PropertyChangedEventArgs("ListesUtilisateur"));
            }
        }

    }
}