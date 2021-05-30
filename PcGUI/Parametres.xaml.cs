using System.Windows.Controls;
using logicPC.Gestionnaires;
using logicPC.Settings;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour UserControl6.xaml
    /// </summary>
    public partial class UserControl6 : UserControl
    {
        public GestionnaireListes gestionnaire => (App.Current as App).monGestionnaire;
        public UserControl6()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
             int.TryParse(maxPool.Text, out SettingsLogic.PoolingMax);
        }
    }
}