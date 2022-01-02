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
        public ObservableCollection<C_TVoiture> rep5 = new ObservableCollection<C_TVoiture>();
        public ObservableCollection<C_TClient> rep6 = new ObservableCollection<C_TClient>();
        List<C_TVoiture> Stock = new List<C_TVoiture>();
        List<C_TVoiture> VtrInterest = new List<C_TVoiture>();
        public BaseCommande cEncoderPresta { get; set; }
        public BaseCommande cEncoderTransac { get; set; }
        public VM_TableauDeBord()
        {
            BcpTransactions = ChargerTransactions(chConnexion);
            BcpServices = ChargerServices(chConnexion);
            BcpClients = ChargerClients(chConnexion);
            BcpVoitures = ChargerVoitures(chConnexion);
            BcpVtr = ChargerVtr(chConnexion);
            BcpCl = ChargerCl(chConnexion);
            cEncoderPresta = new BaseCommande(EncoderPresta);
            cEncoderTransac = new BaseCommande(EncoderTransac);
        }

        #region Accesseur
        private int _NbHeure;
        private decimal _Prix;
        private DateTime _Dt;
        private string _Type;
        public int NbHeure
        {
            get { return _NbHeure; }
            set { AssignerChamp<int>(ref _NbHeure, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string TypeT
        {
            get { return _Type; }
            set { AssignerChamp<string>(ref _Type, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        public decimal Prix
        {
            get { return _Prix; }
            set { AssignerChamp<decimal>(ref _Prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public DateTime Dt
        {
            get { return _Dt; }
            set { AssignerChamp<DateTime>(ref _Dt, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion      
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
        private C_TVoiture _VtrSelectionnee;
        public C_TVoiture VtrSelectionnee
        {
            get { return _VtrSelectionnee; }
            set { AssignerChamp<C_TVoiture>(ref _VtrSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private C_TClient _ClSelectionnee;
        public C_TClient ClSelectionnee
        {
            get { return _ClSelectionnee; }
            set { AssignerChamp<C_TClient>(ref _ClSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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

        private ObservableCollection<C_TVoiture> _BcpVtr = new ObservableCollection<C_TVoiture>();
        public ObservableCollection<C_TVoiture> BcpVtr
        {
            get { return _BcpVtr; }
            set { _BcpVtr = value; }
        }

        private ObservableCollection<C_TClient> _BcpCl = new ObservableCollection<C_TClient>();
        public ObservableCollection<C_TClient> BcpCl
        {
            get { return _BcpCl; }
            set { _BcpCl = value; }
        }
        #endregion
        #region ChargerDGV
        private BindingSource ChargerTransactions(string chConn)
        {
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
        private ObservableCollection<C_TVoiture> ChargerVtr(string chConn)
        {
            int cptA, cptV;
            rep5.Clear();
            List<C_TVoiture> lTmp = new G_TVoiture(chConn).Lire("VMarque");
            List<C_TTransaction> lTmp1 = new G_TTransaction(chConn).Lire("IDTransaction");
            foreach (C_TVoiture v in lTmp)
            {
                cptA = cptV = 0;
                foreach (C_TTransaction t in lTmp1)
                {
                    if (v.IDVoiture == t.IDVoiture)
                    {
                        if (t.TType == "Achat")
                            cptA++;
                        else if (t.TType == "Vente")
                            cptV++;
                    }
                }
                if (cptA > cptV)
                {
                    Stock.Add(v);
                    rep5.Add(v);
                }
            }            
            return rep5;
        }
        private ObservableCollection<C_TClient> ChargerCl(string chConn)
        {
            int cptc;
            rep6.Clear();
            List<C_TDesidrata> lTmp = new G_TDesidrata(chConn).Lire("IDDesidrata");
            List<C_TClient> lTmp1 = new G_TClient(chConn).Lire("IDClient");
            foreach(C_TClient c in lTmp1)
            {
                cptc = 0;
                foreach (C_TDesidrata d in lTmp)
                {
                    if (c.IDClient == d.IDClient)
                        cptc++;
                }
                if (cptc > 0)
                {
                    rep6.Add(c);
                }
            }
            return rep6;
        }
        #endregion
        #region Methode
        public void EncoderPresta()
        {
             new G_TPrestation(chConnexion).Ajouter(int.Parse(TransactionSelectionnee[0].ToString()), ServiceSelectionnee.IDService, 
                NbHeure, NbHeure*ServiceSelectionnee.SPrix);
            MessageBox.Show("La prestation a bien été encodée");
            Refresh();
        }
        public void EncoderTransac()
        {
            new G_TTransaction(chConnexion).Ajouter(ClientSelectionnee.IDClient, VoitureSelectionnee.IDVoiture, TypeT, Prix, Dt);
            MessageBox.Show("La transaction a bien été encodée");
            Refresh();
        }
        public void Refresh()
        {
            BcpTransactions = ChargerTransactions(chConnexion);
            BcpServices = ChargerServices(chConnexion);
            BcpClients = ChargerClients(chConnexion);
            BcpVoitures = ChargerVoitures(chConnexion);
            BcpVtr = ChargerVtr(chConnexion);
            BcpCl = ChargerCl(chConnexion);
        }
        public List<C_TVoiture> CheckInterest()
        {
            VtrInterest.Clear();
            List<C_TDesidrata> lTmp1 = new G_TDesidrata(chConnexion).Lire("IDDesidrata");
            foreach (C_TDesidrata Tmp in lTmp1)
            {
                if(Tmp.IDClient == ClSelectionnee.IDClient)
                {
                    foreach (C_TVoiture v in Stock)
                    {
                        if ((Tmp.DMarque == v.VMarque || Tmp.DMarque == "") && (Tmp.DModel == v.VModel || Tmp.DModel == "")
                            && (Tmp.DAnneeMin <= v.VAnnee || Tmp.DAnneeMin == null) && (Tmp.DAnneeMax >= v.VAnnee || Tmp.DAnneeMax == null)
                            && (Tmp.DKmMin <= v.VKilometrage || Tmp.DKmMin == null) && (Tmp.DKmMax >= v.VKilometrage || Tmp.DKmMax == null)
                            && (Tmp.DCouleur == v.VCouleur || Tmp.DCouleur == "") && (Tmp.DPrixMin <= v.VPrix || Tmp.DPrixMin == null) && (Tmp.DPrixMax >= v.VPrix || Tmp.DPrixMax == null))
                        {
                            VtrInterest.Add(v);
                        }
                    }
                }                
            }
            return VtrInterest;
        }
        #endregion

    }
}
