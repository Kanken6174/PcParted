using System.Windows;
using System.Windows.Controls;
using logicPC.Gestionnaires;
using logicPC;
using System.Collections.Generic;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class MainApp : UserControl
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public bool ShouldDetailbeShown = false;

        private Card _toShow;
        public Card ToShow { get { return _toShow; }
                             set {

                _toShow = value;
                ShouldDetailbeShown = true;
                DetailedCard.onVisibilityChanged(ToShow);
                showChanged();
            }
                              }
        
        public MainApp()
        {
            InitializeComponent();


            wrappy.Children.Clear();
            UserControl3 cloneCarte = new();
            foreach (KeyValuePair<string, Card> card in gestionnaire.Data)
            {
                cloneCarte = new();    
                cloneCarte.laCarte = card.Value;
                cloneCarte.ID = card.Key;
                cloneCarte.parent3view = this;
                wrappy.Children.Add(cloneCarte);
            }
            ToShow = cloneCarte.laCarte;
        }

        private void showChanged()
        {
            if (ShouldDetailbeShown)
            {
                DetailedCard.Visibility = Visibility.Visible;
                closeDetailButton.Visibility = Visibility.Visible;
            }
            else
            {
                DetailedCard.Visibility = Visibility.Hidden;
                closeDetailButton.Visibility = Visibility.Hidden;
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
        }

        private void UserControl5_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CloseDetail(object sender, RoutedEventArgs e)
        {
            DetailedCard.Visibility = Visibility.Hidden;
            closeDetailButton.Visibility = Visibility.Hidden;
            ShouldDetailbeShown = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShouldDetailbeShown = true;
            DetailedCard.Visibility = Visibility.Visible;
            closeDetailButton.Visibility = Visibility.Visible;
        }
    }
}