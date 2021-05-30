using System.Windows;
using System.Windows.Controls;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;
using logicPC.CardData;
using System.Collections.Generic;
using Swordfish.NET.Collections;

namespace PcParted
{
    /// <summary>
    /// Interaction logic for UserListsPannel.xaml
    /// </summary>
    public partial class UserListsPannel : UserControl
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        
        public UserListsPannel()
        {
            DataContext = gestionnaire;
            InitializeComponent();
            gestionnaire.DataNotifier += DatagridRefresh_needed;
        }


        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            ListesComboBox.SelectedItem = gestionnaire.AjouterListe("Nouvelle liste", new());
        }

        private void Button_Click_rem(object sender, RoutedEventArgs e)
        {   
            if(ListesComboBox.SelectedValue is null)
            gestionnaire.SupprimeListe((string)ListesComboBox.SelectedValue);
            else
            gestionnaire.SupprimeListe((string)ListesComboBox.SelectedValue);
        }

        private void Button_Click_dupe(object sender, RoutedEventArgs e)
        {
            if (ListesComboBox.SelectedValue is null)
                gestionnaire.DuplicateList((string)ListesComboBox.SelectedValue);
            else
                gestionnaire.DuplicateList((string)ListesComboBox.SelectedValue);

        }

        private void DatagridRefresh_needed<E>(object sender, E e)
        {
            string selected = new("");
            if (ListesComboBox.SelectedValue is not null)
               selected  = ListesComboBox.SelectedValue.ToString();

            if(selected != null)
                if (gestionnaire.UserListsStorage.ContainsKey(selected))
                {
                    foreach (KeyValuePair<string, Card> card in gestionnaire.UserListsStorage[selected].Cards)
                    {
                        gestionnaire.Datagridcards.TryAdd(gestionnaire.UserListsStorage[selected].QuantityCards[card.Key], card.Value);
                    }
                    DGrid.ItemsSource = null;
                    DGrid.ItemsSource = gestionnaire.Datagridcards;
                }
           
        }
    }
}
