using System.Windows.Controls;
using System.Collections.Generic;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;
using System.ComponentModel;
using Swordfish.NET.Collections;
using logicPC.CardData;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        //public string PrixTotal {get => gestionnaire.UserListsStorage[(string)ListBox.SelectedValue??""].PrixTotalStr??"0.00"; set {} }
        //public string HashrateTot { get => gestionnaire.UserListsStorage[(string)ListBox.SelectedValue].HashrateTotaleStr??"0"; set { } }
        //public string Conso { get => gestionnaire.UserListsStorage[(string)ListBox.SelectedValue].ConsommationTotStr??"000"; set { } }
        public UserControl2()
        {
            DataContext = gestionnaire;
            gestionnaire.AjouterListe("Liste Vide", new());

            InitializeComponent();
            gestionnaire.DataNotifier += DatagridRefresh_needed;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshMe();
        }

        public ConcurrentObservableDictionary<string, UserList> GetLists()
        {
            return gestionnaire.UserListsStorage;
        }

        private void DatagridRefresh_needed<E>(object sender, E e)
        {
            gestionnaire.UserListsStorage[(string)ListBox.SelectedValue].ProcessTot();
            string selected = new("");
            if (ListBox.SelectedValue is not null)
                selected = ListBox.SelectedValue.ToString();

            GrdBkmarks.ItemsSource = null;
            GrdBkmarks.ItemsSource = gestionnaire.CardDataToDisplay;
            watt.Text = gestionnaire.UserListsStorage[(string)ListBox.SelectedValue].ConsommationTotStr;
            euro.Text = gestionnaire.UserListsStorage[(string)ListBox.SelectedValue].PrixTotalStr;
            hash.Text = gestionnaire.UserListsStorage[(string)ListBox.SelectedValue].HashrateTotaleStr;
        }

        private void RefreshMe()
        {
            if (gestionnaire is not null && ListBox.SelectedValue is not null)
            {
                gestionnaire.ActiveKey = (string)ListBox.SelectedValue;
                gestionnaire.RefreshDataToDisplay((string)ListBox.SelectedValue);
                DatagridRefresh_needed(this, new string((string)ListBox.SelectedValue));
            }
        
         }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            RefreshMe();
        }
    }

}