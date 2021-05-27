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
        public Dictionary<string, BitmapImage> miniatures;
        public Dictionary<string, UserControl3> cartesDisp;
        public bool ShouldDetailbeShown = false;
        public string searchTerms = default;
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

        /// <summary>
        /// évènement répmondant à la condition: une bitmapimage a fini d'être téléchargée. Fonctionne par pool d'un certain nombre d'images avant de refresh.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Gestionnaire_RenderRefreshNeeded(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            minTick++;
            if (minTick > SettingsLogic.PoolingMax)
            {
                List<string> group = new();
                foreach (KeyValuePair<string, Card> card in gestionnaire.ProtectedData)
                {
                    BitmapImage bmp = new();
                    bmp = await makeBmp(card.Key);
                    if (miniatures.ContainsKey(card.Key))
                        miniatures.Remove(card.Key);
                    miniatures.TryAdd(card.Key, bmp);
                    group.Add(card.Key);
                }
                minTick = 0;
                RefreshGroup(group);
            }
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
                PopulateDefaultMiniatures(card.Key);
                cloneCarte.ImgCard.Source = miniatures[card.Key];
                cloneCarte.Name = card.Key;
                wrappy.RegisterName(cloneCarte.Name, cloneCarte);
                wrappy.Children.Add(cloneCarte);
            }
        }

        public void RefreshRenderNoFilter()
        {
            foreach (KeyValuePair<string, Card> card in gestionnaire.ProtectedData)
            {
                UserControl3 clone = (UserControl3)wrappy.FindName(card.Key);
                if (clone.ImgCard.Source != miniatures[card.Key] && clone != null)
                    clone.ImgCard.Source = miniatures[card.Key];
            }
        }

        public void RefreshGroup(List<string> group)
        {
            foreach(string name in group)
            {
                if (wrappy.FindName(name) != null)
                {
                    UserControl3 clone = (UserControl3)wrappy.FindName(name);
                    clone.Visibility = Visibility.Collapsed;
                    if (miniatures.ContainsKey(name))
                        clone.ImgCard.Source = miniatures[name];

                    if (clone != null && gestionnaire.Data.ContainsKey(name))
                        clone.Visibility = Visibility.Visible;

                }

            }
        }

        public void RefreshAll()
        {
            foreach (KeyValuePair<string, Card> card in gestionnaire.ProtectedData) 
            {
                if (wrappy.FindName(card.Key) != null)
                {
                    UserControl3 clone = (UserControl3)wrappy.FindName(card.Key);
                    clone.Visibility = Visibility.Collapsed;
                }
            }
            foreach (KeyValuePair<string, Card> card in gestionnaire.Data)
            {
                UserControl3 cloneCarte = (UserControl3)wrappy.FindName(card.Key);
                if (cloneCarte != null)
                {
                    cloneCarte.Visibility = Visibility.Visible;
                    if (miniatures.ContainsKey(card.Key))
                        cloneCarte.ImgCard.Source = miniatures[card.Key];
                }
            }
        }
        /// <summary>
        /// Sauvegarde une 
        /// </summary>
        /// <param name="toSave"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public void PopulateDefaultMiniatures(string ID)
        {
            BitmapImage bmp = new(SettingsLogic.DummyPic);
            miniatures.Add(ID, bmp);
        }

        /// <summary>
        /// Cette tâche renvoie la bitmapimage correspondante à "key", ou celle par défaut si elle n'existe pas 
        /// </summary>
        /// <param name="key">La clé de dictionnaire correspondant à la carte</param>
        /// <returns></returns>
        private async Task<BitmapImage> makeBmp(string key)
        {
            BitmapImage bmp = new(SettingsLogic.DummyPic);
            if (gestionnaire.StreamRoot.ContainsKey(key) && gestionnaire.StreamRoot[key] != null)
            {
                using (var memStream = new MemoryStream())
                {
                    gestionnaire.StreamRoot[key].Position = 0;
                    await gestionnaire.StreamRoot[key].CopyToAsync(memStream);
                    {
                        try
                        {
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
            gestionnaire.Data = gestionnaire.ProtectedData.SearchModel(searchTerms);
            RefreshAll();
        }
    }
}