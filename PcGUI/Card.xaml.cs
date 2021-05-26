using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using logicPC;
using System.Windows.Threading;
using logicPC.Gestionnaires;
using System.Runtime.InteropServices;
using logicPC.CardData;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour les cartes de gpu
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public MainApp parent3view;
        public Card laCarte;
        public string ID;
        BitmapImage miniPic;
        public UserControl3()
        {
            InitializeComponent();
            miniPic = new();
        }


        private void UC_clicked(object sender, MouseButtonEventArgs e)
        {
            parent3view.cardID = ID;
            parent3view.ToShow = laCarte;
        }

        private void ImgCard_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            nom_carte.Text = laCarte.Informations.Model as string;
            

            /*
            if (!laCarte.PictureURL.Equals("about:blank"))
            {
            BitmapImage Ipic = new BitmapImage(laCarte.PictureURL);
            ImgCard.Source = Ipic;
            Ipic.DownloadCompleted += new EventHandler(PicDL);
            }
            */
        }

        private void PicDL(object sender, EventArgs e)
        {
            
        }
    }
}