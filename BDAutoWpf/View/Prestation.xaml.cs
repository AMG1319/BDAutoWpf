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
    /// Logique d'interaction pour Prestation.xaml
    /// </summary>
    public partial class Prestation : Window
    {
        private ViewModel.VM_Prestation LocalPrestation;
        public Prestation()
        {
            InitializeComponent();
            LocalPrestation = new ViewModel.VM_Prestation();
            DataContext = LocalPrestation;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des personnes encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach (C_TPrestation cp in LocalPrestation.BcpPrestations)
            {
                Paragraph pl = new Paragraph(new Run(cp.IDTransaction + " " + cp.IDService));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\WPF-Winforms\essai.rtf", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, DataFormats.Rtf);
        }

        private void dgPrestations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPrestations.SelectedIndex >= 0) LocalPrestation.PrestationSelectionnee2UnePrestation();
        }
    }
}

