using System.Windows;
using System.Windows.Controls;
using logicPC.Gestionnaires;
using logicPC;
using System.Collections.Generic;
using logicPC.FiltersAndSearch;
using logicPC.Downloaders;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class MainApp : UserControl
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public bool ShouldDetailbeShown = false;
        public string searchTerms = default;
        public Dictionary<string,BitmapImage> miniatures;

        private Card _toShow;
        public Card ToShow
        {
            get { return _toShow; }
            set
            {

                _toShow = value;
                ShouldDetailbeShown = !ShouldDetailbeShown;
                DetailedCard.onVisibilityChanged(ToShow);
                showChanged();
            }
        }

        public MainApp()
        {
            miniatures = new();
            InitializeComponent();
            InitRefresh();
            DetailedCard.parentElement = this;
            gestionnaire.PropertyChanged += Gestionnaire_PropertyChanged;
        }

        private void Gestionnaire_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RefreshAll();
        }

        public void InitRefresh()
        {
            wrappy.Children.Clear();
            foreach (KeyValuePair<string, Card> card in gestionnaire.ProtectedData)
            {
                UserControl3 cloneCarte = new();
                cloneCarte.laCarte = card.Value;
                cloneCarte.ID = card.Key;
                cloneCarte.parent3view = this;
                cloneCarte.laCarte = SavePic(cloneCarte.laCarte, card.Key);
                cloneCarte.ImgCard.Source = miniatures[card.Key];
                wrappy.Children.Add(cloneCarte);
            }
        }

        public void RefreshAll()
        {
            wrappy.Children.Clear();
            foreach (KeyValuePair<string, Card> card in gestionnaire.Data)
            {
                UserControl3 cloneCarte = new();
                cloneCarte.laCarte = card.Value;
                cloneCarte.ID = card.Key;
                cloneCarte.parent3view = this;
                cloneCarte.ImgCard.Source = miniatures[card.Key];
                wrappy.Children.Add(cloneCarte);
            }
        }

        public Card SavePic(Card toSave, string ID)
        {
            BitmapImage bmp = new(new System.Uri("https://www.techpowerup.com/gpudb/placeholder_nvidia.jpg"));
                if (toSave != null)
                    if (toSave.Informations.miniature != default)
                    {
                    bmp = new();
                    bmp.BeginInit();
                    bmp.StreamSource = toSave.Informations.miniature;
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.EndInit();
                    bmp.Freeze();
                    }
            miniatures.Add(ID, bmp);
            return toSave;
        }

        private void showChanged()
        {
            if (ShouldDetailbeShown)
            {
                DetailedCard.Visibility = Visibility.Visible;
            }
            else
            {
                DetailedCard.Visibility = Visibility.Hidden;
            }
        }

        private void AddCard(object sender, RoutedEventArgs e)
        {
            UserControl3 clone = new UserControl3();
            wrappy.Children.Add(clone);
        }

        private void wrappy_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchTerms = (sender as TextBox).Text;
        }

        private void UserControl5_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void CloseDetail(object sender, RoutedEventArgs e)
        {
            DetailedCard.Visibility = Visibility.Hidden;
            ShouldDetailbeShown = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShouldDetailbeShown = true;
            DetailedCard.Visibility = Visibility.Visible;
        }

        private void DetailedCard_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void search(object sender, RoutedEventArgs e)
        {
            gestionnaire.Data = gestionnaire.Data.SearchModel(searchTerms);
            RefreshAll();
            gestionnaire.Data = (Dictionary<string, Card>)gestionnaire.ProtectedData;
        }
    }
}