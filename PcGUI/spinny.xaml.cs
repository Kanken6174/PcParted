using System.Windows;
using System.Windows.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class spinner : UserControl
    {
        public double i;
        private DoubleCollection tik = new();
        public DoubleCollection tok { get
            {
                tok = new DoubleCollection() { i };
                return tik;
            }
            set { tik = value; }
            }
        public spinner()
        {
            InitializeComponent();

        }

        private void mySpinner_Loaded(object sender, RoutedEventArgs e)
        {
             Task.Run(() => {
                 i = 1;
                 while (true)
                 {
                     i++;
                     if (i >= 360)
                         i = 1;
                     Thread.Sleep(50);
                     _ = tok;
                 }
            });
        }

    }
}