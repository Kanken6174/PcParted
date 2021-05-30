﻿using System.Windows.Controls;
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
            spinny.Visibility = System.Windows.Visibility.Visible;
            this.carte = carte;
            this.carteID = ID;
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
       
            masterDetailPic.UseLayoutRounding = true;
            masterDetailPic.Source = Ipic;
        }

        private void Ipic_DownloadCompleted(object sender, System.EventArgs e)
        {
            spinny.Visibility = System.Windows.Visibility.Hidden;
        }

        private void closeDetailButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            parentElement.CloseDetail(sender, e);
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.ContainsKey(carteID))
            {
                gestionnaire.UserListsStorage[gestionnaire.ActiveKey].Cards.Add(carteID, carte);
                gestionnaire.UserListsStorage[gestionnaire.ActiveKey].QuantityCards.Add(carteID, 1);
            }
            else
                gestionnaire.UserListsStorage[gestionnaire.ActiveKey].QuantityCards[carteID]++;

            gestionnaire.NotifyAction(sender, "refreshDatagrids");
        }
    }
}