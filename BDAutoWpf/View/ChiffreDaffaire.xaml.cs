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

namespace BDAutoWpf.View
{
    /// <summary>
    /// Logique d'interaction pour ChiffreDaffaire.xaml
    /// </summary>
    public partial class ChiffreDaffaire : Window
    {
        private ViewModel.VM_ChiffreDaffaire Local;
        public ChiffreDaffaire()
        {
            InitializeComponent();
            Local = new ViewModel.VM_ChiffreDaffaire();
            DataContext = Local;
            dtpSemaine.SelectedDate= DateTime.Today.AddDays(-7);
        }
    }
}
