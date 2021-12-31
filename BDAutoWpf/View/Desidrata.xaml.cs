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
using System.Data;

namespace BDAutoWpf.View
{
    /// <summary>
    /// Logique d'interaction pour Desidrata.xaml
    /// </summary>
    public partial class Desidrata : Window
    {
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        private ViewModel.VM_Desidrata LocalDesidrata;
        public Desidrata()
        {
            InitializeComponent();
            LocalDesidrata = new ViewModel.VM_Desidrata();
            DataContext = LocalDesidrata;
        }

        private void dgDesidratas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDesidratas.SelectedIndex >= 0) LocalDesidrata.DesidrataSelectionnee2UnDesidrata();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<C_TClient> lTmp = new G_TClient(chConnexion).Lire("CNom");
            foreach (C_TClient Tmp in lTmp)
            {
                cbIDC.Items.Add(Tmp.IDClient + "-" + Tmp.CNom + "-" + Tmp.CPrenom);
            }
        }
    }
}
