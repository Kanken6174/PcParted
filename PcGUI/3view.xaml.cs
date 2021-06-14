using logicPC.CardData;
using logicPC.FiltersAndSearch;
using logicPC.Gestionnaires;
using logicPC.Settings;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using PcGUI.PicturePersistance;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Imaging;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class MainApp : UserControl
    {
        public GestionnaireListes Gestionnaire => (App.Current as App).monGestionnaire;
        public Dictionary<string, BitmapImage> miniatures;
        public Dictionary<string, UserControl3> cartesDisp;
        public bool ShouldDetailbeShown = false;
        public string searchTerms = default;
        public string cardID = default;
        private int availablePackets = 0;
        private int PacketsDoneIndex = 0;

        private Card _toShow;

        public Card ToShow
        {
            get { return _toShow; }
            set
            {
                _toShow = value;
                ShouldDetailbeShown = !ShouldDetailbeShown;
                DetailedCard.onVisibilityChanged(ToShow, cardID);
                ShowChanged();
            }
        }

        /// <summary>
        /// Le constructeur princpal de l'userControl 3view (cet UC sert un peu de HUB à l'application).
        /// </summary>
        public MainApp()
        {
            miniatures = new();
            InitializeComponent();
            InitRefresh();
            DetailedCard.parentElement = this;
            Filters.MyParent = this;
            Gestionnaire.StreamStorage.CollectionChanged += Gestionnaire_RenderRefreshNeeded;
            Filters.applyInit();

        }

        /// <summary>
        /// évènement répmondant à la condition: une bitmapimage a fini d'être téléchargée. Fonctionne par pool d'un certain nombre d'images avant de refresh.
        /// Si l'évènement est appellé moins de fois que le paramètre requis, il ne se lancera pas pour économiser des ressources. (3 par 3 par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Gestionnaire_RenderRefreshNeeded(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            availablePackets++;
            if (availablePackets > SettingsLogic.PoolingMax)
            {
                int i = 0;
                List<string> group = new();
                foreach (KeyValuePair<string, Card> card in Gestionnaire.ProtectedData)
                {
                    if (i < (SettingsLogic.PoolingMax + PacketsDoneIndex) && i >= PacketsDoneIndex)
                    {
                        BitmapImage bmp = new();
                        bmp = await MakeBmp(card.Key);
                        bmp.CacheOption = BitmapCacheOption.OnDemand;
                        bmp.Freeze();
                        if (miniatures.ContainsKey(card.Key))
                            miniatures.Remove(card.Key);
                        miniatures.TryAdd(card.Key, bmp);
                        group.Add(card.Key);
                    }
                    i++;
                }
                PacketsDoneIndex += SettingsLogic.PoolingMax;
                availablePackets = 0;
                RefreshGroup(group);
            }
        }

        private void Gestionnaire_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RefreshAll();
        }

        /// <summary>
        /// Cette méthode est le refresh inital appellé à l'initalisation de l'application.
        /// Il va notamment créer tous les UserControl3 (cartes) qui vont dans le wrappannel "wrappy".
        /// </summary>
        public void InitRefresh()
        {
            wrappy.Children.Clear();
            foreach (KeyValuePair<string, Card> card in Gestionnaire.ProtectedData)
            {
                UserControl3 cloneCarte = new();
                cloneCarte.laCarte = card.Value;
                cloneCarte.ID = card.Key;
                DetailedCard.carteID = card.Key;
                cloneCarte.parent3view = this;
                PopulateDefaultMiniatures(card.Key, card.Value);
                cloneCarte.ImgCard.Source = miniatures[card.Key];
                cloneCarte.Name = card.Key;
                wrappy.RegisterName(cloneCarte.Name, cloneCarte);
                wrappy.Children.Add(cloneCarte);
            }
        }

        public void RefreshRenderNoFilter()
        {
            foreach (KeyValuePair<string, Card> card in Gestionnaire.ProtectedData)
            {
                UserControl3 clone = (UserControl3)wrappy.FindName(card.Key);
                if (clone.ImgCard.Source != miniatures[card.Key] && clone != null)
                    clone.ImgCard.Source = miniatures[card.Key];
            }
        }

        /// <summary>
        /// Va refresh les miniatures des carted dont l'ID (key) est dans la liste de strings group
        /// </summary>
        /// <param name="group">La liste de keys à refresh</param>
        public void RefreshGroup(List<string> group)
        {
            foreach (string name in group)
            {
                if (wrappy.FindName(name) != null)
                {
                    UserControl3 clone = (UserControl3)wrappy.FindName(name);
                    clone.Visibility = Visibility.Collapsed;
                    if (miniatures.ContainsKey(name))
                    {
                        clone.ImgCard.Source = miniatures[name];
                        
                       using (MemoryStream outStream = new())
                        {
                            BitmapEncoder enc = new BmpBitmapEncoder();
                            enc.Frames.Add(BitmapFrame.Create(miniatures[name]));
                            enc.Save(outStream);
                            Bitmap bitmap = new(outStream);
                            if(!File.Exists($@"{SettingsLogic.CachePATH}{name}.png"))
                            bitmap.Save($@"{SettingsLogic.CachePATH}{name}.png", ImageFormat.Png);
                        }
                    }

                    if (clone != null && Gestionnaire.Data.ContainsKey(name))
                    {
                        clone.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        public void RefreshAll()
        {
            foreach (KeyValuePair<string, Card> card in Gestionnaire.ProtectedData)
            {
                if (wrappy.FindName(card.Key) != null)
                {
                    UserControl3 clone = (UserControl3)wrappy.FindName(card.Key);
                    clone.Visibility = Visibility.Collapsed;
                }
            }
            foreach (KeyValuePair<string, Card> card in Gestionnaire.Data)
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
        public bool PopulateDefaultMiniatures(string ID, Card card)
        {
            BitmapImage bmp = new();
            bmp = new(SettingsLogic.DummyPic);
            miniatures.Add(ID, bmp);
            return true;
        }

        /// <summary>
        /// Cette tâche renvoie la bitmapimage correspondante à "key", ou celle par défaut si elle n'existe pas
        /// </summary>
        /// <param name="key">La clé de dictionnaire correspondant à la carte</param>
        /// <returns></returns>
        private async Task<BitmapImage> MakeBmp(string key)
        {
            BitmapImage bmp = new(SettingsLogic.DummyPic);
            if (Gestionnaire.StreamStorage.ContainsKey(key) && Gestionnaire.StreamStorage[key] != null)
            {
                using (var memStream = new MemoryStream())
                {
                    Gestionnaire.StreamStorage[key].Position = 0;
                    await Gestionnaire.StreamStorage[key].CopyToAsync(memStream);
                    {
                        try
                        {
                            bmp = new BitmapImage();
                            memStream.Position = 0;
                            bmp.BeginInit();
                            bmp.CacheOption = BitmapCacheOption.OnLoad;
                            bmp.StreamSource = memStream;
                            bmp.DecodePixelWidth = 75;
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

        private void ShowChanged()
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
            UserControl3 clone = new();
            wrappy.Children.Add(clone);
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

        private void Search(object sender, RoutedEventArgs e)
        {
            Gestionnaire.Data = Gestionnaire.ProtectedData.SearchModel(searchTerms);
            RefreshAll();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await Gestionnaire.GetAllPics();
        }
    }
}