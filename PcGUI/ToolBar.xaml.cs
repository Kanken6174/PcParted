using System.Windows.Controls;
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using logicPC.Gestionnaires;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl7.xaml
    /// </summary>
    public partial class UserControl7 : UserControl
    {
        public GestionnaireListes Gestionnaire => (App.Current as App).monGestionnaire;
        public UserControl7()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Dataset files (*.pnm)|*.pnm|All files (*.*)|*.*",
                InitialDirectory = @"Y:\cs\datacrawler"
            };
            if (openFileDialog.ShowDialog() == true)
                //_ = File.ReadAllText(openFileDialog.FileName);
                Gestionnaire.LoadUL();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();

        }

        private void NewList(object sender, RoutedEventArgs e)
        {
            Gestionnaire.AjouterListe("NewList", new logicPC.Conteneurs.UserList());
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Gestionnaire.SaveUL();
        }
    }
}