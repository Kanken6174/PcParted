using System.Windows.Controls;
using System.Collections.Generic;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;

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
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        public Dictionary<string, UserList> GetLists()
        {
            return gestionnaire.MesListesUtilisateur;
        }
    }
}