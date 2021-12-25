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
    /// Logique d'interaction pour Voiture.xaml
    /// </summary>
    public partial class Voiture : Window
    {
        private ViewModel.VM_Voiture LocalVoiture;
        public Voiture()
        {
            InitializeComponent();
            LocalVoiture = new ViewModel.VM_Voiture();
            DataContext = LocalVoiture;
            FlowDocument fd = new FlowDocument();
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Bold(new Run("Titre de document")));
            p.Inlines.Add(new LineBreak());
            p.Inlines.Add(new Run("Liste des personnes encodées"));
            fd.Blocks.Add(p);
            List l = new List();
            foreach (C_TVoiture cp in LocalVoiture.BcpVoitures)
            {
                Paragraph pl = new Paragraph(new Run(cp.VMarque + " " + cp.VModel));
                l.ListItems.Add(new ListItem(pl));
            }
            fd.Blocks.Add(l);
            rtbDoc.Document = fd;
            FileStream fs = new FileStream(@"D:\WPF-Winforms\essai.rtf", FileMode.Create);
            TextRange tr = new TextRange(rtbDoc.Document.ContentStart, rtbDoc.Document.ContentEnd);
            tr.Save(fs, DataFormats.Rtf);
        }

        private void dgVoitures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgVoitures.SelectedIndex >= 0) LocalVoiture.VoitureSelectionnee2UneVoiture();
        }
    }
}
