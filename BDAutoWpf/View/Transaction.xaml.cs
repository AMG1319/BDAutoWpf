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
    /// Logique d'interaction pour Transaction.xaml
    /// </summary>
    public partial class Transaction : Window
    {
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        private ViewModel.VM_Transaction LocalTransaction;
        public Transaction()
        {
            InitializeComponent();
            LocalTransaction = new ViewModel.VM_Transaction();
            DataContext = LocalTransaction;            
        }

        private void dgTransactions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTransactions.SelectedIndex >= 0) LocalTransaction.TransactionSelectionnee2UneTransaction();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<C_TClient> lTmp = new G_TClient(chConnexion).Lire("CNom");
            foreach (C_TClient Tmp in lTmp)
            {
                cbIDC.Items.Add(Tmp.IDClient + "-" + Tmp.CNom + "-" + Tmp.CPrenom);
            }

            List<C_TVoiture> lTmp1 = new G_TVoiture(chConnexion).Lire("CNom");
            foreach (C_TVoiture Tmp1 in lTmp1)
            {
                cbIDV.Items.Add(Tmp1.IDVoiture + "-" + Tmp1.VMarque + "-" + Tmp1.VModel);
            }

            cbType.Items.Add("Achat");
            cbType.Items.Add("Vente");
        }
    }
}
