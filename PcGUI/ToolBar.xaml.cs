using System.Windows.Controls;
using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl7.xaml
    /// </summary>
    public partial class UserControl7 : UserControl
    {
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
    }
}