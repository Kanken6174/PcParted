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
            string selected = "";
            if (ListesComboBox.SelectedValue is not null)
               selected  = ListesComboBox.SelectedValue.ToString();

            DGrid.ItemsSource = null;
            DGrid.ItemsSource = gestionnaire.CardDataToDisplay;
        }

        private void Button_ClickRename(object sender, RoutedEventArgs e)
        {
            if (ListesComboBox.SelectedValue == null)
                ListesComboBox.SelectedIndex = 0;
            
            if(ListesComboBox.SelectedValue == null)
                return;
            
            string selected = ListesComboBox.SelectedValue.ToString();

            if (selected != null && gestionnaire.UserListsStorage.ContainsKey(selected))
            {
                gestionnaire.RenommeListe(selected, NameBox.Text);
            }
        }

        private void ListesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshMe();
        }

        private void refreshMe()
        {
            if (gestionnaire is not null && (string)ListesComboBox.SelectedValue is not null)
            {
                gestionnaire.ActiveKey = (string)ListesComboBox.SelectedValue;
                gestionnaire.RefreshDataToDisplay((string)ListesComboBox.SelectedValue);
                DatagridRefresh_needed(this, new string((string)ListesComboBox.SelectedValue));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            refreshMe();
        }
    }
}
