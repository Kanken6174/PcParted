using System.Windows.Controls;
using logicPC.Gestionnaires;
using logicPC.FiltersAndSearch;
using System.IO;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl4.xaml
    /// </summary>
    public partial class UserControl4 : UserControl
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public MainApp MyParent;
        public UserControl4()
        {
            DataContext = gestionnaire;
            InitializeComponent();
            prix.Value = gestionnaire.MaxPrice;
            Consommation.Value = gestionnaire.MaxPowerDraw;
        }

        private void Hashrate_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            hashMin.Text = Hashrate.Value.ToString("#0MH/S");
        }

        private void Consommation_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            ConsoBox.Text = Consommation.Value.ToString("#0W");
        }

        private void prix_Copy_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            PriceMinBox.Text = prix_Copy.Value.ToString("#0.00€");
        }

        private void prix_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            PriceMaxBox.Text = prix.Value.ToString("#0.00€");
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gestionnaire.Data = gestionnaire.ProtectedData;
            if(Constructeur.SelectedItem != null && Constructeur.SelectedItem.ToString() != "Tous")
               gestionnaire.Data = Filters.ConstructorFilter(Constructeur.SelectedItem.ToString(), gestionnaire.Data);

            if (Architectures.SelectedItem != null && Architectures.SelectedItem.ToString() != "Toutes")
                gestionnaire.Data = Filters.ArchitectureFilter(Architectures.SelectedItem.ToString(), gestionnaire.Data);

            if (showCorrupted.IsChecked == false)
            {
                gestionnaire.Data = Filters.PriceSlider(prix_Copy.Value, prix.Value, gestionnaire.Data);
                gestionnaire.Data = Filters.GflopsSlider(Hashrate.Value, gestionnaire.Data);
                gestionnaire.Data = Filters.PowerSlider(Consommation.Value, gestionnaire.Data);
            }

            MyParent.RefreshAll();
        }

        public void applyInit()
        {
            Button_Click(new(), new());
        }

        private void showCorrupted_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            prix_Copy.IsEnabled = false;
            prix.IsEnabled = false;
            Hashrate.IsEnabled = false;
            Consommation.IsEnabled = false;
        }

        private void showCorrupted_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            prix_Copy.IsEnabled = true;
            prix.IsEnabled = true;
            Hashrate.IsEnabled = true;
            Consommation.IsEnabled = true;
        }
    }
}