using System.Windows.Controls;
using System.Collections.Generic;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;
using System.ComponentModel;
using Swordfish.NET.Collections;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public UserControl2()
        {
            DataContext = gestionnaire;
            gestionnaire.AjouterListe("Liste Vide", new());

            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gestionnaire.ActiveKey = (string)ListBox.SelectedValue;
        }

        public ConcurrentObservableSortedDictionary<string, UserList> GetLists()
        {
            return gestionnaire.MesListesUtilisateur;
        }
    }

}