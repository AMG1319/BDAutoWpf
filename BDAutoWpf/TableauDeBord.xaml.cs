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
        private ViewModel.VM_TableauDeBord LocalTableauDeBord;
        public TableauDeBord()
        {
            InitializeComponent();
            LocalTableauDeBord = new ViewModel.VM_TableauDeBord();
            DataContext = LocalTableauDeBord;
            bEncoderPresta.IsEnabled = false;
            bEncoderTransac.IsEnabled = false;
        }
        private void btnAjouterVoiture_Click(object sender, RoutedEventArgs e)
        {
            View.Voiture f = new View.Voiture();
            Hide();
            f.ShowDialog();
            Show();
            LocalTableauDeBord.Refresh();
        }
        private void btnAjouterClient_Click(object sender, RoutedEventArgs e)
        {
            View.Client f = new View.Client();
            Hide();
            f.ShowDialog();
            Show();
            LocalTableauDeBord.Refresh();
        }
        private void btnAjouterService_Click(object sender, RoutedEventArgs e)
        {
            View.Service f = new View.Service();
            Hide();
            f.ShowDialog();
            Show();
            LocalTableauDeBord.Refresh();
        }
        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAjouterDesidrata_Click(object sender, RoutedEventArgs e)
        {
            View.Desidrata f = new View.Desidrata();
            Hide();
            f.ShowDialog();
            Show();
            LocalTableauDeBord.Refresh();
        }

        private void btnAjouterPrestation_Click(object sender, RoutedEventArgs e)
        {
            View.Prestation f = new View.Prestation();
            Hide();
            f.ShowDialog();
            Show();
            LocalTableauDeBord.Refresh();
        }

        private void btnAjouterTransaction_Click(object sender, RoutedEventArgs e)
        {
            View.Transaction f = new View.Transaction();
            Hide();
            f.ShowDialog();
            Show();
            LocalTableauDeBord.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbType.Items.Add("Achat");
            cbType.Items.Add("Vente");
        }

        private void dgTransactions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (dgServices.SelectedIndex >= 0 && dgTransactions.SelectedIndex >=0)
            {
                bEncoderPresta.IsEnabled = true;
            }
            else
                bEncoderPresta.IsEnabled = false;

        }

        private void dgServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgServices.SelectedIndex >= 0 && dgTransactions.SelectedIndex >= 0)
            {
                bEncoderPresta.IsEnabled = true;
            }
            else
                bEncoderPresta.IsEnabled = false;
        }

        private void dgVoitures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgVoitures.SelectedIndex >= 0 && dgClients.SelectedIndex >= 0)
            {
                bEncoderTransac.IsEnabled = true;
            }
            else
                bEncoderTransac.IsEnabled = false;
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgVoitures.SelectedIndex >= 0 && dgClients.SelectedIndex >= 0)
            {
                bEncoderTransac.IsEnabled = true;
            }
            else
                bEncoderTransac.IsEnabled = false;
        }
    }
}
