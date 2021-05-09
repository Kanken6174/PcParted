using System.Windows;
using System.Windows.Controls;

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