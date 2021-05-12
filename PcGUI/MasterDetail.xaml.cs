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
        public MainApp parentElement;
        public Card carte;
        public UserControl5()
        {
            carte = new(null, null);
            InitializeComponent();
        }
        
        public void onVisibilityChanged(Card carte)
        {
            this.carte = carte;
            nom_carte.Text = carte.Informations.Model;
            BitmapImage Ipic;
            if (!carte.Informations.PictureURL.Equals("about:blank"))
            {
                Ipic = new BitmapImage(carte.Informations.PictureURL);
            }
            else
            {
                Ipic = new BitmapImage(new System.Uri(@"https://www.techpowerup.com/gpudb/placeholder_nvidia.jpg"));
            }
       
            masterDetailPic.UseLayoutRounding = true;
            masterDetailPic.Source = Ipic;
        }

        private void closeDetailButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentElement.CloseDetail(sender, e);
        }
    }
}