using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Menu_open(object sender, RoutedEventArgs e)
        {
            ((App.Current as App).MainWindow as MainWindow).Content = new MainApp();       //Je sais pas si c'est la meilleure façon de le faire, mais on remplace le content du contentControl de la page mère avec un userControl2
        }
    }
}
