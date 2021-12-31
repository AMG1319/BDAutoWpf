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
    /// Logique d'interaction pour Service.xaml
    /// </summary>
    public partial class Service : Window
    {

        private ViewModel.VM_Service LocalService;
        public Service()
        {
            InitializeComponent();
            LocalService = new ViewModel.VM_Service();
            DataContext = LocalService;
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgServices.SelectedIndex >= 0) LocalService.ClientSelectionnee2UnClient();
        }
        
    }
}
