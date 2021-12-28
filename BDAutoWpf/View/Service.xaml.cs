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
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des services encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach (C_TService cp in LocalService.BcpServices)
            {
                Paragraph pl = new Paragraph(new Run(cp.SNom + " " + cp.SPrix));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\WPF-Winforms\essai.rtf", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, DataFormats.Rtf);
        }

        private void dgClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgServices.SelectedIndex >= 0) LocalService.ClientSelectionnee2UnClient();
        }
        
    }
}
