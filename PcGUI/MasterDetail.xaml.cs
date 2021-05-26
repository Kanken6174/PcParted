using System.Windows.Controls;
using System.Windows.Media.Imaging;
using logicPC.CardData;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl5.xaml
    /// </summary>
    public partial class UserControl5 : UserControl
    {
        public MainApp parentElement;
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public Card carte;
        public string carteID;
        public UserControl5()
        {
            carte = new(null, null);
            InitializeComponent();
        }
        
        public void onVisibilityChanged(Card carte, string ID)
        {
            this.carte = carte;
            this.carteID = ID;
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

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!gestionnaire.MesListesUtilisateur[gestionnaire.ActiveKey].Cards.ContainsKey(carteID))
            {
                gestionnaire.MesListesUtilisateur[gestionnaire.ActiveKey].Cards.Add(carteID, carte);
                gestionnaire.MesListesUtilisateur[gestionnaire.ActiveKey].QuantityCards.Add(carteID, 1);
            }
            else
                gestionnaire.MesListesUtilisateur[gestionnaire.ActiveKey].QuantityCards[carteID]++;
        }
    }
}