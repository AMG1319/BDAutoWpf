using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BDAutoWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class TableauDeBord : Window
    {
        public TableauDeBord()
        {
            InitializeComponent();
        }
        private void btnAjouterVoiture_Click(object sender, RoutedEventArgs e)
        {
            View.Voiture f = new View.Voiture();
            f.ShowDialog();
        }
        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
