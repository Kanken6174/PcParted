using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Windows.Media.Imaging;

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
            //var Ipath = @"https://pcper.com/wp-content/uploads/2020/10/nvidia-geforce-rtx-3070-fe-9.jpg";
            nom_carte.Text = "Nice click";
            //ImgCard.Source = new BitmapImage(new Uri(Ipath, UriKind.Absolute));
        }
    }
}
