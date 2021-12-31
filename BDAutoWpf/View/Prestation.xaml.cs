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
using BDAutoWpf.Gestion;
using System.Configuration;

namespace BDAutoWpf.View
{
    /// <summary>
    /// Logique d'interaction pour Prestation.xaml
    /// </summary>
    public partial class Prestation : Window
    {
        private ViewModel.VM_Prestation LocalPrestation;
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        public Prestation()
        {
            InitializeComponent();
            LocalPrestation = new ViewModel.VM_Prestation();
            DataContext = LocalPrestation;
        }

        private void dgPrestations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPrestations.SelectedIndex >= 0) LocalPrestation.PrestationSelectionnee2UnePrestation();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<C_TService> lTmp = new G_TService(chConnexion).Lire("SNom");
            foreach (C_TService Tmp in lTmp)
            {
                cbIDS.Items.Add(Tmp.IDService + "-" + Tmp.SNom);
            }
            List<C_TTransaction> lTmp2 = new G_TTransaction(chConnexion).Lire("IDTransaction");
            foreach (C_TTransaction Tmp2 in lTmp2)
            {
                cbIDT.Items.Add(Tmp2.IDTransaction);
            }
        }
    }
}

