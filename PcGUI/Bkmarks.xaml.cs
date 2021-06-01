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
        public UserControl2()
        {
            DataContext = gestionnaire;
            gestionnaire.AjouterListe("Liste Vide", new());

            InitializeComponent();
            gestionnaire.DataNotifier += DatagridRefresh_needed;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gestionnaire.ActiveKey = (string)ListBox.SelectedValue;
        }

        public ConcurrentObservableSortedDictionary<string, UserList> GetLists()
        {
            return gestionnaire.UserListsStorage;
        }

        private void DatagridRefresh_needed<E>(object sender, E e)
        {
            string selected = new("");
            if (ListBox.SelectedValue is not null)
                selected = ListBox.SelectedValue.ToString();

            if (selected != null)
                if (gestionnaire.UserListsStorage.ContainsKey(selected))
                {
                    foreach (KeyValuePair<string, Card> card in gestionnaire.UserListsStorage[selected].Cards)
                    {
                        gestionnaire.CardDataToDisplay.TryAdd(gestionnaire.UserListsStorage[selected].QuantityCards[card.Key], card.Value);
                    }
                    GrdBkmarks.ItemsSource = null;
                    GrdBkmarks.ItemsSource = gestionnaire.CardDataToDisplay;
                }

        }
    }

}