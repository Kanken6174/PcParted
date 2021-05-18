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
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public UserControl7()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Dataset files (*.pnm)|*.pnm|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"Y:\cs\datacrawler";
            if (openFileDialog.ShowDialog() == true)
                _ = File.ReadAllText(openFileDialog.FileName);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.MainWindow.Close();

        }

        private void newList(object sender, RoutedEventArgs e)
        {
            gestionnaire.AjouterListe("NewList", new logicPC.Conteneurs.UserList());
        }
    }
}