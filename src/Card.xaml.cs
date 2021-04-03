using System.Windows.Controls;
using System.Windows.Input;

namespace PcParted
{
    /// <summary>
    /// Logique d'interaction pour les cartes de gpu
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void UC_clicked(object sender, MouseButtonEventArgs e)
        {
            nom_carte.Text = "Incroyable! cliqué!!";
        }
    }
}
