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
        bool cpt = true;
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        public DataTable dtTransaction = new DataTable();
        public ObservableCollection<C_TService> rep1 = new ObservableCollection<C_TService>();
        public ObservableCollection<C_TClient> rep2 = new ObservableCollection<C_TClient>();
        public ObservableCollection<C_TVoiture> rep3 = new ObservableCollection<C_TVoiture>();
        public BindingSource rep4 = new BindingSource();

        #region Accesseur
        private int _NbHeure;
        public int NbHeure
        {
            get { return _NbHeure; }
            set { AssignerChamp<int>(ref _NbHeure, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        public BaseCommande cEncoderPresta { get; set; }
        public VM_TableauDeBord()
        {
            BcpTransactions = ChargerTransactions(chConnexion);
            BcpServices = ChargerServices(chConnexion);
            BcpClients = ChargerClients(chConnexion);
            BcpVoitures = ChargerVoitures(chConnexion);
            cEncoderPresta = new BaseCommande(EncoderPresta);
        }

        #region Selectionnee
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
        private C_TClient _ClientSelectionnee;
        public C_TClient ClientSelectionnee
        {
            get { return _ClientSelectionnee; }
            set { AssignerChamp<C_TClient>(ref _ClientSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_TVoiture _VoitureSelectionnee;
        public C_TVoiture VoitureSelectionnee
        {
            get { return _VoitureSelectionnee; }
            set { AssignerChamp<C_TVoiture>(ref _VoitureSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region VM
        private VM_UnService _UnService;
        public VM_UnService UnService
        {
            get { return _UnService; }
            set { AssignerChamp<VM_UnService>(ref _UnService, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UneTransaction _UneTransaction;
        public VM_UneTransaction UneTransaction
        {
            get { return _UneTransaction; }
            set { AssignerChamp<VM_UneTransaction>(ref _UneTransaction, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UnClient _UnClient;
        public VM_UnClient UnClient
        {
            get { return _UnClient; }
            set { AssignerChamp<VM_UnClient>(ref _UnClient, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private VM_UneVoiture _UneVoiture;
        public VM_UneVoiture UneVoiture
        {
            get { return _UneVoiture; }
            set { AssignerChamp<VM_UneVoiture>(ref _UneVoiture, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region DataSource
        private ObservableCollection<C_TService> _BcpServices = new ObservableCollection<C_TService>();
        public ObservableCollection<C_TService> BcpServices
        {
            get { return _BcpServices; }
            set { _BcpServices = value; }
        }

        private BindingSource _BcpTransactions = new BindingSource();
        public BindingSource BcpTransactions
        {
            get { return _BcpTransactions; }
            set { _BcpTransactions = value; }
        }

        private ObservableCollection<C_TClient> _BcpClients = new ObservableCollection<C_TClient>();
        public ObservableCollection<C_TClient> BcpClients
        {
            get { return _BcpClients; }
            set { _BcpClients = value; }
        }

        private ObservableCollection<C_TVoiture> _BcpVoitures = new ObservableCollection<C_TVoiture>();
        public ObservableCollection<C_TVoiture> BcpVoitures
        {
            get { return _BcpVoitures; }
            set { _BcpVoitures = value; }
        }
        #endregion
        #region ChargerDGV
        private BindingSource ChargerTransactions(string chConn)
        {
            //rep4.Clear();
            dtTransaction.Clear();
            if(cpt == true)
            {
                dtTransaction.Columns.Add(new DataColumn("IDTransaction", Type.GetType("System.Int32")));
                dtTransaction.Columns.Add(new DataColumn("IDClient"));
                dtTransaction.Columns.Add(new DataColumn("IDVoiture"));
                dtTransaction.Columns.Add(new DataColumn("TType"));
                dtTransaction.Columns.Add(new DataColumn("TPrix"));
                dtTransaction.Columns.Add(new DataColumn("TDate"));
                cpt = false;
            }
            
            List<C_TTransaction> lTmp3 = new G_TTransaction(chConn).Lire("TType");
            foreach (C_TTransaction t in lTmp3)
            {
                C_TClient Tmp = new G_TClient(chConnexion).Lire_ID(t.IDClient);
                C_TVoiture Tmp1 = new G_TVoiture(chConnexion).Lire_ID(t.IDVoiture);
                dtTransaction.Rows.Add(t.IDTransaction, t.IDClient + "-" + Tmp.CNom + "-" + Tmp.CPrenom, t.IDVoiture + "-" + Tmp1.VMarque + "-" + Tmp1.VModel, t.TType, t.TPrix, t.TDate.Date.ToString("d"));
            }
            rep4.DataSource = dtTransaction;
            return rep4;
        }
        private ObservableCollection<C_TService> ChargerServices(string chConn)
        {
            rep1.Clear();
            List<C_TService> lTmp = new G_TService(chConn).Lire("CNom");
            foreach (C_TService Tmp in lTmp)
                rep1.Add(Tmp);
            return rep1;
        }
        private ObservableCollection<C_TClient> ChargerClients(string chConn)
        {
            rep2.Clear();
            List<C_TClient> lTmp = new G_TClient(chConn).Lire("CNom");
            foreach (C_TClient Tmp in lTmp)
                rep2.Add(Tmp);
            return rep2;
        }
        private ObservableCollection<C_TVoiture> ChargerVoitures(string chConn)
        {
            rep3.Clear();
            List<C_TVoiture> lTmp = new G_TVoiture(chConn).Lire("VMarque");
            foreach (C_TVoiture Tmp in lTmp)
                rep3.Add(Tmp);
            return rep3;
        }
        #endregion
        public void EncoderPresta()
        {
             new G_TPrestation(chConnexion).Ajouter(int.Parse(TransactionSelectionnee[0].ToString()), ServiceSelectionnee.IDService, 
                NbHeure, NbHeure*ServiceSelectionnee.SPrix);
            MessageBox.Show("La prestation a bien été encodée");
        }
        public void Refresh()
        {
            BcpTransactions = ChargerTransactions(chConnexion);
            BcpServices = ChargerServices(chConnexion);
            BcpClients = ChargerClients(chConnexion);
            BcpVoitures = ChargerVoitures(chConnexion);
        }
        
    }
}
