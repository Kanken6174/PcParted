using System.Windows.Controls;
using logicPC;
using System.Windows.Media.Imaging;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl5.xaml
    /// </summary>
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
        }
        
        public void onVisibilityChanged(Card carte)
        {
            nom_carte.Text = carte.Model;

            if (!carte.PictureURL.Equals("about:blank"))
            {
                BitmapImage Ipic = new BitmapImage(carte.PictureURL);
                masterDetailPic.Source = Ipic;
            }
        }
    }
}