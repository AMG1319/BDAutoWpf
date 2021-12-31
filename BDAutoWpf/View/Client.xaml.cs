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
using System.Windows.Shapes;
using BDAutoWpf.Classes;
using System.IO;
namespace BDAutoWpf.View
{
    /// <summary>
    /// Logique d'interaction pour Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        private ViewModel.VM_Client LocalClient;
        public Client()
        {
            InitializeComponent();
            LocalClient = new ViewModel.VM_Client();
            DataContext = LocalClient;
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgClients.SelectedIndex >= 0) LocalClient.ClientSelectionnee2UnClient();
        }
    }
}
