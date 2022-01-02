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
    /// Logique d'interaction pour StockHtml.xaml
    /// </summary>
    public partial class StockHtml : Window
    {
        private ViewModel.VM_StockHtml LocalStock;
        public StockHtml()
        {
            InitializeComponent();
            LocalStock = new ViewModel.VM_StockHtml();
            LocalStock.GenererHTML();
            wbStock.Navigate(@"D:\WPF-Winforms\BDAutoStock.HTML");
        }
        //this.wbStock.Navigate(@"D:\WPF-Winforms\BDAutoStock.HTML");
    }
}
