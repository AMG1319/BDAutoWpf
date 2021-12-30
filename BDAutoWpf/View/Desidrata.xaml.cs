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
           /* FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des personnes encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach (C_TDesidrata cp in LocalDesidrata.BcpDesidratas)
            {
                Paragraph pl = new Paragraph(new Run(cp.IDClient+ " " + cp.DMarque));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\WPF-Winforms\essai.rtf", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, DataFormats.Rtf);*/
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
