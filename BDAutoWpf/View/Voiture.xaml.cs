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

        }

        private void dgVoitures_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgVoitures.SelectedIndex >= 0) LocalVoiture.VoitureSelectionnee2UneVoiture();
        }
    }
}
