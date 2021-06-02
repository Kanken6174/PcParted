using System.Windows.Controls;
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using logicPC.Gestionnaires;
using logicPC.Settings;
using System.Text.RegularExpressions;
namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl7.xaml
    /// </summary>
    public partial class UserControl7 : UserControl
    {
        public GestionnaireListes Gestionnaire => (App.Current as App).monGestionnaire;
        public OpenFileDialog openFileDialog = new()
        {
            Filter = "XML save files (*.XML)|*.XML|All files (*.*)|*.*",
            InitialDirectory = @"C:\"
        };
        public UserControl7()
        {
            InitializeComponent();
            var parentFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var xmlPath = Path.Combine(parentFolder, "XML");
            openFileDialog.InitialDirectory = xmlPath;
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Directory.Exists(openFileDialog.InitialDirectory))
                Directory.CreateDirectory(openFileDialog.InitialDirectory);
            if (openFileDialog.ShowDialog() == true)
                Gestionnaire.Persistance.PATH = openFileDialog.FileName;

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