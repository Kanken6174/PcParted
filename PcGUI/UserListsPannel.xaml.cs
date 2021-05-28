using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using logicPC.Gestionnaires;

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
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            ListesComboBox.SelectedItem = gestionnaire.AjouterListe("Nouvelle liste", new());
        }

        private void Button_Click_rem(object sender, RoutedEventArgs e)
        {   
            if(ListesComboBox.SelectedValue == null)
            gestionnaire.SupprimeListe((string)ListesComboBox.SelectedValue);
            else
            gestionnaire.SupprimeListe((string)ListesComboBox.SelectedValue);
        }

        private void Button_Click_dupe(object sender, RoutedEventArgs e)
        {
            if (ListesComboBox.SelectedValue == null)
                gestionnaire.DuplicateList((string)ListesComboBox.SelectedValue);
            else
                gestionnaire.DuplicateList((string)ListesComboBox.SelectedValue);

        }

        private void ListesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGrid.DataContext = ListesComboBox.SelectedItem;
        }
    }
}
