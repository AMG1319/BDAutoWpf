using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDAutoWpf.ViewModel;
//using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System.Collections;
using System.Configuration;
using System.Windows.Forms;
using System.Data;


namespace BDAutoWpf.ViewModel
{
    public class VM_Desidrata : BasePropriete
    {
        #region Données Écran
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        private int nAjout;
        public DataTable dtDesidrata = new DataTable();

        private bool _ActiverUneFiche;
        public bool ActiverUneFiche
        {
            get { return _ActiverUneFiche; }
            set
            {
                AssignerChamp<bool>(ref _ActiverUneFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ActiverBcpFiche = !ActiverUneFiche;
            }
        }
        private bool _ActiverBcpFiche;
        public bool ActiverBcpFiche
        {
            get { return _ActiverBcpFiche; }
            set { AssignerChamp<bool>(ref _ActiverBcpFiche, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private DataRowView _DesidrataSelectionnee;
        public DataRowView DesidrataSelectionnee
        {
            get { return _DesidrataSelectionnee; }
            set { AssignerChamp<DataRowView>(ref _DesidrataSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures

        private VM_UnDesidrata _UnDesidrata;
        public VM_UnDesidrata UnDesidrata
        {
            get { return _UnDesidrata; }
            set { AssignerChamp<VM_UnDesidrata>(ref _UnDesidrata, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private BindingSource _BcpDesidratas = new BindingSource();
        public BindingSource BcpDesidratas
        {
            get { return _BcpDesidratas; }
            set { _BcpDesidratas = value; }
        }
        #endregion
        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        public BaseCommande cEssaiSelMult { get; set; }
        #endregion
        public VM_Desidrata()
        {
            UnDesidrata = new VM_UnDesidrata();
            UnDesidrata.ID = 1;
            UnDesidrata.IDC = 1;
            UnDesidrata.Marque = "Toyota";
            UnDesidrata.Model = "YarisGP";
            UnDesidrata.AnneeMin = 0000;
            UnDesidrata.AnneeMax = 0000;
            UnDesidrata.KmMin = 000000;
            UnDesidrata.KmMax = 000000;
            UnDesidrata.Couleur = "Noir";
            UnDesidrata.PrixMin = 000000;
            UnDesidrata.PrixMax = 000000;


            BcpDesidratas = ChargerDesidratas(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
        }

        private BindingSource ChargerDesidratas(string chConn)
        {            
            BindingSource rep = new BindingSource();
            dtDesidrata.Columns.Add(new DataColumn("IDDesidrata", Type.GetType("System.Int32")));
            dtDesidrata.Columns.Add(new DataColumn("IDClient"));
            dtDesidrata.Columns.Add(new DataColumn("DMarque"));
            dtDesidrata.Columns.Add(new DataColumn("DModel"));
            dtDesidrata.Columns.Add(new DataColumn("DAnneeMin"));
            dtDesidrata.Columns.Add(new DataColumn("DAnneeMax"));
            dtDesidrata.Columns.Add(new DataColumn("DKmMin"));
            dtDesidrata.Columns.Add(new DataColumn("DKmMax"));
            dtDesidrata.Columns.Add(new DataColumn("DCouleur"));
            dtDesidrata.Columns.Add(new DataColumn("DPrixMin"));
            dtDesidrata.Columns.Add(new DataColumn("DPrixMax"));

            List<C_TDesidrata> lTmp = new G_TDesidrata(chConn).Lire("DMarque");
            foreach (C_TDesidrata d in lTmp)
            {
                C_TClient Tmp = new G_TClient(chConnexion).Lire_ID(d.IDClient);
                dtDesidrata.Rows.Add(d.IDDesidrata, d.IDClient+ "-" + Tmp.CNom + "-" + Tmp.CPrenom , d.DMarque, d.DModel, d.DAnneeMin, d.DAnneeMax, d.DKmMin, d.DKmMax, d.DCouleur, d.DPrixMin, d.DPrixMax);
            }
            
            rep.DataSource = dtDesidrata;
            return rep;
        }
        public void Confirmer()
        {
            string[] s;
            s = UnDesidrata.Client.Split('-');
            UnDesidrata.IDC = Convert.ToInt32(s[0]);
            if (nAjout == -1)
            {                
                UnDesidrata.ID = new G_TDesidrata(chConnexion).Ajouter(UnDesidrata.IDC,UnDesidrata.Marque,UnDesidrata.Model,
                    UnDesidrata.AnneeMin,UnDesidrata.AnneeMax,UnDesidrata.KmMin,UnDesidrata.KmMax,UnDesidrata.Couleur,UnDesidrata.PrixMin,UnDesidrata.PrixMax);
                C_TClient Tmp = new G_TClient(chConnexion).Lire_ID(UnDesidrata.IDC);
                dtDesidrata.Rows.Add(UnDesidrata.ID, Tmp.IDClient + "-" + Tmp.CNom + "-" + Tmp.CPrenom, UnDesidrata.Marque, UnDesidrata.Model,
                    UnDesidrata.AnneeMin, UnDesidrata.AnneeMax, UnDesidrata.KmMin, UnDesidrata.KmMax, UnDesidrata.Couleur, UnDesidrata.PrixMin, UnDesidrata.PrixMax);               
            }
            else
            {
                new G_TDesidrata(chConnexion).Modifier(UnDesidrata.ID, UnDesidrata.IDC, UnDesidrata.Marque, UnDesidrata.Model,
                    UnDesidrata.AnneeMin, UnDesidrata.AnneeMax, UnDesidrata.KmMin, UnDesidrata.KmMax, UnDesidrata.Couleur, UnDesidrata.PrixMin, UnDesidrata.PrixMax);


                DesidrataSelectionnee[1] = UnDesidrata.Client.ToString();
                DesidrataSelectionnee[2] = UnDesidrata.Marque.ToString();
                DesidrataSelectionnee[3] = UnDesidrata.Model.ToString();
                DesidrataSelectionnee[4] = UnDesidrata.AnneeMin.ToString();
                DesidrataSelectionnee[5] = UnDesidrata.AnneeMax.ToString();
                DesidrataSelectionnee[6] = UnDesidrata.KmMin.ToString();
                DesidrataSelectionnee[7] = UnDesidrata.KmMax.ToString();
                DesidrataSelectionnee[8] = UnDesidrata.Couleur.ToString();
                DesidrataSelectionnee[9] = UnDesidrata.PrixMin.ToString();
                DesidrataSelectionnee[10] = UnDesidrata.PrixMax.ToString();
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UnDesidrata = new VM_UnDesidrata();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (DesidrataSelectionnee != null)
            {
                C_TDesidrata Tmp = new G_TDesidrata(chConnexion).Lire_ID(int.Parse(DesidrataSelectionnee[0].ToString()));
                UnDesidrata = new VM_UnDesidrata();
                UnDesidrata.ID = Tmp.IDDesidrata;
                UnDesidrata.IDC = Tmp.IDClient;
                UnDesidrata.Marque = Tmp.DMarque;
                UnDesidrata.Model = Tmp.DModel;
                UnDesidrata.AnneeMin = Tmp.DAnneeMin;
                UnDesidrata.AnneeMax = Tmp.DAnneeMax;
                UnDesidrata.KmMin = Tmp.DKmMin;
                UnDesidrata.KmMax = Tmp.DKmMax;
                UnDesidrata.Couleur = Tmp.DCouleur;
                UnDesidrata.PrixMin = Tmp.DPrixMin;
                UnDesidrata.PrixMax = Tmp.DPrixMax;
                nAjout = BcpDesidratas.IndexOf(DesidrataSelectionnee);
                ActiverUneFiche = true;
                C_TClient Tmp2 = new G_TClient(chConnexion).Lire_ID(Tmp.IDClient);
                UnDesidrata.Client = Tmp2.IDClient + "-" + Tmp2.CNom + "-" + Tmp2.CPrenom;
            }
        }
        public void Supprimer()
        {
            if (DesidrataSelectionnee != null)
            {
                new G_TDesidrata(chConnexion).Supprimer(int.Parse(DesidrataSelectionnee[0].ToString()));
                BcpDesidratas.Remove(DesidrataSelectionnee);
            }
        }
        public void DesidrataSelectionnee2UnDesidrata()
        {
            UnDesidrata.ID =Convert.ToInt32(DesidrataSelectionnee[0].ToString());
            decimal test ;
            string[] s;
            s = DesidrataSelectionnee[1].ToString().Split('-');

            UnDesidrata.IDC = Convert.ToInt32(s[0]);
            UnDesidrata.Marque = DesidrataSelectionnee[2].ToString();
            UnDesidrata.Model = DesidrataSelectionnee[3].ToString();

            if (decimal.TryParse(DesidrataSelectionnee[4].ToString(), out test))
                UnDesidrata.AnneeMin = test;
            else
                UnDesidrata.AnneeMin = null;

            if (decimal.TryParse(DesidrataSelectionnee[5].ToString(), out test))
                UnDesidrata.AnneeMax = test;
            else
                UnDesidrata.AnneeMax = null;

            if (decimal.TryParse(DesidrataSelectionnee[6].ToString(), out test))
                UnDesidrata.KmMin = test;
            else
                UnDesidrata.KmMin = null;

            if (decimal.TryParse(DesidrataSelectionnee[7].ToString(), out test))
                UnDesidrata.KmMax = test;
            else
                UnDesidrata.KmMax = null;

            UnDesidrata.Couleur = DesidrataSelectionnee[8].ToString();

            if (decimal.TryParse(DesidrataSelectionnee[9].ToString(), out test))
                UnDesidrata.PrixMin = test;
            else
                UnDesidrata.PrixMin = null;

            if (decimal.TryParse(DesidrataSelectionnee[10].ToString(), out test))
                UnDesidrata.PrixMax = test;
            else
                UnDesidrata.PrixMax = null;

            UnDesidrata.Client = DesidrataSelectionnee[1].ToString();
        }
    }
    public class VM_UnDesidrata : BasePropriete
    {
        private int _ID, _IDC;
        private string _Marque, _Model, _Couleur;
        private decimal ? _AnneeMin, _AnneeMax, _KmMin, _KmMax, _PrixMin, _PrixMax;
        private string _Client;

        public string Client
        {
            get { return _Client; }
            set { AssignerChamp<string>(ref _Client, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        public int ID
        {
            get { return _ID; }
            set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int IDC
        {
            get { return _IDC; }
            set { AssignerChamp<int>(ref _IDC, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Marque
        {
            get { return _Marque; }
            set { AssignerChamp<string>(ref _Marque, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Model
        {
            get { return _Model; }
            set { AssignerChamp<string>(ref _Model, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Couleur
        {
            get { return _Couleur; }
            set { AssignerChamp<string>(ref _Couleur, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public decimal ? AnneeMin
        {
            get { return _AnneeMin; }
            set { AssignerChamp<decimal?>(ref _AnneeMin, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public decimal ? AnneeMax
        {
            get { return _AnneeMax; }
            set { AssignerChamp<decimal?>(ref _AnneeMax, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public decimal ? KmMin
        {
            get { return _KmMin; }
            set { AssignerChamp<decimal?>(ref _KmMin, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public decimal? KmMax
        {
            get { return _KmMax; }
            set { AssignerChamp<decimal?>(ref _KmMax, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public decimal? PrixMin
        {
            get { return _PrixMin; }
            set { AssignerChamp<decimal?>(ref _PrixMin, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public decimal? PrixMax
        {
            get { return _PrixMax; }
            set { AssignerChamp<decimal?>(ref _PrixMax, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

    }
}
