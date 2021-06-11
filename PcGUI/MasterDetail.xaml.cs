using System.Windows.Controls;
using System.Windows.Media.Imaging;
using logicPC.CardData;
using logicPC.Gestionnaires;
using logicPC.Settings;
using logicPC.Conteneurs;
using System.Windows;
using System.ComponentModel;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl5.xaml
    /// </summary>
    public partial class UserControl5 : UserControl, INotifyPropertyChanged
    {
        public MainApp parentElement;
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public Card carte { get; set; }
        public string carteID;

        public event PropertyChangedEventHandler PropertyChanged;

        public UserControl5()
        {
            carte = new(null, null);
            InitializeComponent();
        }
        
        public void onVisibilityChanged(Card carte, string ID)
        {
            spinny.Visibility = System.Windows.Visibility.Visible;
            this.carte = carte;
            this.carteID = ID;
            carte.Theorics = new(carte.Specifications, carte.Informations);
            nom_carte.Text = carte.Informations.Model;
            BitmapImage Ipic;
            if (!carte.Informations.PictureURL.Equals("about:blank"))
            {
                Ipic = new BitmapImage(carte.Informations.PictureURL);
                Ipic.DownloadCompleted += Ipic_DownloadCompleted;
            }
            else
            {
                Ipic = new BitmapImage(SettingsLogic.DummyPic);
                spinny.Visibility = System.Windows.Visibility.Hidden;
            }

            RemButton.IsEnabled = gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.ContainsKey(carteID);

            masterDetailPic.UseLayoutRounding = true;
            masterDetailPic.Source = Ipic;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }

        private void Ipic_DownloadCompleted(object sender, System.EventArgs e)
        {
            spinny.Visibility = System.Windows.Visibility.Hidden;
        }

        private void closeDetailButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentElement.CloseDetail(sender, e);
        }

        /// <summary>
        /// Bouton d'ajout à la liste active
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.ContainsKey(carteID))
            {
                gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.Add(carteID, carte);
                gestionnaire.UserListsStorage[gestionnaire.ActiveKey].QuantityCards.Add(carteID, 1);
            }
            else
                gestionnaire.UserListsStorage[gestionnaire.ActiveKey].QuantityCards[carteID]++;

            gestionnaire.NotifyAction(sender, "");
            RemButton.IsEnabled = gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.ContainsKey(carteID);
        }

        /// <summary>
        /// Bouton de retrait de carte à la liste active
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.ContainsKey(carteID))
            {
                gestionnaire.UserListsStorage[gestionnaire.ActiveKey].QuantityCards[carteID]--;
                if (gestionnaire.UserListsStorage[gestionnaire.ActiveKey].QuantityCards[carteID] == 0)
                {
                    gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.Remove(carteID);
                    gestionnaire.UserListsStorage[gestionnaire.ActiveKey].QuantityCards.Remove(carteID);
                }
            }


            gestionnaire.NotifyAction(sender, "");
            RemButton.IsEnabled = gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.ContainsKey(carteID);
        }
    }
}