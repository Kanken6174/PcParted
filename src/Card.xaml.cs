using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Windows.Media.Imaging;
using System.Timers;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour les cartes de gpu
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UC_clicked(object sender, MouseButtonEventArgs e)
        {
            nom_carte.Text = "Nice click";
        }

        private void ImgCard_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var Ipath = @"https://media.ldlc.com/r374/ld/products/00/05/80/47/LD0005804743_1.jpg";
            BitmapImage Ipic = new BitmapImage(new Uri(Ipath, UriKind.Absolute));
            ImgCard.Source = Ipic;
            Ipic.DownloadCompleted += new EventHandler(PicDL);
        }

        private void PicDL(object sender, EventArgs e)
        {
            myMediaElement.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
