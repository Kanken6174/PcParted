using System.Windows;
using logicPC.Gestionnaires;
using System.Collections.Generic;
namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public GestionnaireListes monGestionnaire { get; private set; } = new GestionnaireListes();
        public App()
        {

        }

    }
}