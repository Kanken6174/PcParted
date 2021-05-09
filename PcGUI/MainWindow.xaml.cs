using System.Windows;
using logicPC.Gestionnaires;
using System.Collections.Generic;
namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}