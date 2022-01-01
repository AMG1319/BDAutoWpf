using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDAutoWpf.ViewModel
{
    public class VM_TableauDeBord : BasePropriete
    {
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        public DataTable dtTransaction = new DataTable();

        private C_TService _ServiceSelectionnee;
        public C_TService ServiceSelectionnee
        {
            get { return _ServiceSelectionnee; }
            set { AssignerChamp<C_TService>(ref _ServiceSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private DataRowView _TransactionSelectionnee;
        public DataRowView TransactionSelectionnee
        {
            get { return _TransactionSelectionnee; }
            set { AssignerChamp<DataRowView>(ref _TransactionSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private VM_UnService _UnService;
        public VM_UnService UnService
        {
            get { return _UnService; }
            set { AssignerChamp<VM_UnService>(ref _UnService, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_TService> _BcpServices = new ObservableCollection<C_TService>();
        public ObservableCollection<C_TService> BcpServices
        {
            get { return _BcpServices; }
            set { _BcpServices = value; }
        }
        private VM_UneTransaction _UneTransaction;
        public VM_UneTransaction UneTransaction
        {
            get { return _UneTransaction; }
            set { AssignerChamp<VM_UneTransaction>(ref _UneTransaction, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private BindingSource _BcpTransactions = new BindingSource();
        public BindingSource BcpTransactions
        {
            get { return _BcpTransactions; }
            set { _BcpTransactions = value; }
        }
        public BaseCommande cEncoderPresta { get; set; }
        public VM_TableauDeBord()
        {
            BcpTransactions = ChargerTransactions(chConnexion);
            BcpServices = ChargerServices(chConnexion);
            cEncoderPresta = new BaseCommande(EncoderPresta);
        }
        private BindingSource ChargerTransactions(string chConn)
        {
            BindingSource rep = new BindingSource();

            dtTransaction.Columns.Add(new DataColumn("IDTransaction", Type.GetType("System.Int32")));
            dtTransaction.Columns.Add(new DataColumn("IDClient"));
            dtTransaction.Columns.Add(new DataColumn("IDVoiture"));
            dtTransaction.Columns.Add(new DataColumn("TType"));
            dtTransaction.Columns.Add(new DataColumn("TPrix"));
            dtTransaction.Columns.Add(new DataColumn("TDate"));
            List<C_TTransaction> lTmp3 = new G_TTransaction(chConn).Lire("TType");
            foreach (C_TTransaction t in lTmp3)
            {
                C_TClient Tmp = new G_TClient(chConnexion).Lire_ID(t.IDClient);
                C_TVoiture Tmp1 = new G_TVoiture(chConnexion).Lire_ID(t.IDVoiture);
                dtTransaction.Rows.Add(t.IDTransaction, t.IDClient + "-" + Tmp.CNom + "-" + Tmp.CPrenom, t.IDVoiture + "-" + Tmp1.VMarque + "-" + Tmp1.VModel, t.TType, t.TPrix, t.TDate.Date.ToString("d"));
            }
            rep.DataSource = dtTransaction;
            return rep;
        }
        private ObservableCollection<C_TService> ChargerServices(string chConn)
        {
            ObservableCollection<C_TService> rep = new ObservableCollection<C_TService>();
            List<C_TService> lTmp = new G_TService(chConn).Lire("CNom");
            foreach (C_TService Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        private int _NbHeure;
        public int NbHeure
        {
            get { return _NbHeure; }
            set { AssignerChamp<int>(ref _NbHeure, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public void aff()
        {
            MessageBox.Show("Transac = " + TransactionSelectionnee[1].ToString());
            MessageBox.Show("Service = " + ServiceSelectionnee.SNom);
        }
        public void EncoderPresta()
        {
             new G_TPrestation(chConnexion).Ajouter(int.Parse(TransactionSelectionnee[0].ToString()), ServiceSelectionnee.IDService, 
                NbHeure, NbHeure*ServiceSelectionnee.SPrix);
            MessageBox.Show("La prestation a bien été encodée");
        }
    }
}
