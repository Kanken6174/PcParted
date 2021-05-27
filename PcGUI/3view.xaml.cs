using System.Windows;
using System.Windows.Controls;
using logicPC.Gestionnaires;
using logicPC.Settings;
using System.Collections.Generic;
using logicPC.FiltersAndSearch;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using logicPC.CardData;
using System.IO;

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
        public Dictionary<string, BitmapImage> miniatures;
        public string cardID = default;
        private int minTick = 0;

        private Card _toShow;
        public Card ToShow
        {
            get { return _toShow; }
            set
            {

                _toShow = value;
                ShouldDetailbeShown = !ShouldDetailbeShown;
                DetailedCard.onVisibilityChanged(ToShow, cardID);
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
            gestionnaire.StreamRoot.CollectionChanged += Gestionnaire_RenderRefreshNeeded;
        }

        private async void Gestionnaire_RenderRefreshNeeded(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            minTick++;
            if (minTick > SettingsLogic.PoolingMax)
            {
                foreach (KeyValuePair<string, Card> card in gestionnaire.ProtectedData)
                {
                    BitmapImage bmp = new();
                    bmp = await makeBmp(card.Key);
                    if (miniatures.ContainsKey(card.Key))
                        miniatures.Remove(card.Key);
                    miniatures.TryAdd(card.Key, bmp);
                }
                minTick = 0;
                RefreshAll();
            }
        }

        private async Task<BitmapImage> makeBmp(string key)
        {
            BitmapImage bmp = new(SettingsLogic.DummyPic);
            if (gestionnaire.StreamRoot.ContainsKey(key))
            {
                using (var memStream = new MemoryStream())
                {
                    gestionnaire.StreamRoot[key].Position = 0;
                    await gestionnaire.StreamRoot[key].CopyToAsync(memStream);
                    {
                        try{
                            bmp = new BitmapImage();
                            memStream.Position = 0;
                            bmp.BeginInit();
                            bmp.StreamSource = memStream;
                            bmp.CacheOption = BitmapCacheOption.OnLoad;
                            bmp.EndInit();
                        }
                        catch (System.NotSupportedException)
                        {
                            bmp = new(SettingsLogic.DummyPic);
                        }
                    }
                }
            }
            else
            {

            }
            return bmp;
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
                DetailedCard.carteID = card.Key;
                cloneCarte.parent3view = this;
                cloneCarte.laCarte = SavePic(cloneCarte.laCarte, card.Key);
                cloneCarte.ImgCard.Source = miniatures[card.Key];

                wrappy.Children.Add(cloneCarte);
            }
        }

        public void RefreshRenderNoFilter()
        {
            wrappy.Children.Clear();
            foreach (KeyValuePair<string, Card> card in gestionnaire.ProtectedData)
            {
                UserControl3 cloneCarte = new();
                cloneCarte.laCarte = card.Value;
                cloneCarte.ID = card.Key;
                DetailedCard.carteID = card.Key;
                cloneCarte.parent3view = this;
                cloneCarte.laCarte = card.Value;
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
                if(miniatures.ContainsKey(card.Key))
                    cloneCarte.ImgCard.Source = miniatures[card.Key];
                wrappy.Children.Add(cloneCarte);
            }
        }
        /// <summary>
        /// Sauvegarde une 
        /// </summary>
        /// <param name="toSave"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Card SavePic(Card toSave, string ID)
        {
            BitmapImage bmp = new(SettingsLogic.DummyPic);
            if (toSave != null)
                if (toSave.Informations.CarteMin != default)
                {
                    bmp = new();
                    bmp.BeginInit();
                    bmp.StreamSource = toSave.Informations.CarteMin;
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