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
        private void btnAjouterClient_Click(object sender, RoutedEventArgs e)
        {
            View.Client f = new View.Client();
            f.ShowDialog();
        }
        private void btnAjouterService_Click(object sender, RoutedEventArgs e)
        {
            View.Service f = new View.Service();
            f.ShowDialog();
        }
        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAjouterDesidrata_Click(object sender, RoutedEventArgs e)
        {
            View.Desidrata f = new View.Desidrata();
            f.ShowDialog();
        }

        private void btnAjouterPrestation_Click(object sender, RoutedEventArgs e)
        {
            View.Prestation f = new View.Prestation();
            f.ShowDialog();
        }

        private void btnAjouterTransaction_Click(object sender, RoutedEventArgs e)
        {
            View.Transaction f = new View.Transaction();
            f.ShowDialog();
        }
    }
}
