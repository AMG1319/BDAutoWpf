using System.Collections.Generic;
using System.Collections.ObjectModel;
using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System.Collections;
using System.Configuration;
using System;
using System.Data;
using System.Windows.Forms;

namespace BDAutoWpf.ViewModel
{
    public class VM_Prestation : BasePropriete
    {
        //DESKTOP-U9ONRQ2\SQLEXPRESS
        #region Données Écran
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        private int nAjout;
        public DataTable dtPrestation = new DataTable();

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
        private DataRowView _PrestationSelectionnee;
        public DataRowView PrestationSelectionnee
        {
            get { return _PrestationSelectionnee; }
            set { AssignerChamp<DataRowView>(ref _PrestationSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
        private VM_UnePrestation _UnePrestation;
        public VM_UnePrestation UnePrestation
        {
            get { return _UnePrestation; }
            set { AssignerChamp<VM_UnePrestation>(ref _UnePrestation, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private BindingSource _BcpPrestations = new BindingSource();
        public BindingSource BcpPrestations
        {
            get { return _BcpPrestations; }
            set { _BcpPrestations = value; }
        }
        #endregion
        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        #endregion
        public VM_Prestation()
        {
            UnePrestation = new VM_UnePrestation();
            UnePrestation.ID = 1;
            UnePrestation.IDT = 1;
            UnePrestation.IDS = 1;
            UnePrestation.NbHeure = 00;
            UnePrestation.Prix = 00;

            BcpPrestations = ChargerPrestations(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
        }
        private BindingSource ChargerPrestations(string chConn)
        {
            BindingSource rep = new BindingSource();
            dtPrestation.Columns.Add(new DataColumn("IDPrestation", Type.GetType("System.Int32")));
            dtPrestation.Columns.Add(new DataColumn("IDTransaction"));
            dtPrestation.Columns.Add(new DataColumn("IDService"));
            dtPrestation.Columns.Add(new DataColumn("PNbHeure"));
            dtPrestation.Columns.Add(new DataColumn("PPrixTot"));
            List<C_TPrestation> lTmp = new G_TPrestation(chConn).Lire("IDPrestation");
            foreach (C_TPrestation p in lTmp)
            {
                C_TService Tmp2 = new G_TService(chConnexion).Lire_ID(p.IDService);
                dtPrestation.Rows.Add(p.IDPrestation, p.IDTransaction, p.IDService + "-" + Tmp2.SNom, p.PNbHeure, p.PPrixTot);
            }
            rep.DataSource = dtPrestation;
            return rep;
        }
        public void Confirmer()
        {
            string[] s1;
            s1 = UnePrestation.Service.Split('-');
            UnePrestation.IDS = Convert.ToInt32(s1[0]);

            if (UnePrestation.Prix == 0)
            {
                C_TService Tmp2 = new G_TService(chConnexion).Lire_ID(UnePrestation.IDS);
                UnePrestation.Prix = UnePrestation.NbHeure * Tmp2.SPrix;
            }
            
            if (nAjout == -1)
            {                     
                UnePrestation.ID = new G_TPrestation(chConnexion).Ajouter(UnePrestation.IDT, UnePrestation.IDS, UnePrestation.NbHeure,UnePrestation.Prix);
                dtPrestation.Rows.Add(UnePrestation.ID,UnePrestation.IDT, UnePrestation.Service, UnePrestation.NbHeure, UnePrestation.Prix);
            }
            else
            {
                new G_TPrestation(chConnexion).Modifier(UnePrestation.ID, UnePrestation.IDT, UnePrestation.IDS, UnePrestation.NbHeure, UnePrestation.Prix);
                
                PrestationSelectionnee[1] = UnePrestation.IDT.ToString();
                PrestationSelectionnee[2] = UnePrestation.Service.ToString();
                PrestationSelectionnee[3] = UnePrestation.NbHeure.ToString();
                PrestationSelectionnee[4] = UnePrestation.Prix.ToString();
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UnePrestation = new VM_UnePrestation();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (PrestationSelectionnee != null)
            {
                C_TPrestation Tmp = new G_TPrestation(chConnexion).Lire_ID(int.Parse(PrestationSelectionnee[0].ToString()));
                UnePrestation = new VM_UnePrestation();
                UnePrestation.ID = Tmp.IDPrestation;
                UnePrestation.IDT = Tmp.IDTransaction;
                UnePrestation.IDS = Tmp.IDService;
                UnePrestation.NbHeure = Tmp.PNbHeure;
                UnePrestation.Prix = Tmp.PPrixTot;
                nAjout = BcpPrestations.IndexOf(PrestationSelectionnee);
                ActiverUneFiche = true;

                C_TService Tmp2 = new G_TService(chConnexion).Lire_ID(Tmp.IDService);
                UnePrestation.Service = Tmp2.IDService + "-" + Tmp2.SNom;
            }
        }
        public void Supprimer()
        {
            if (PrestationSelectionnee != null)
            {
                new G_TPrestation(chConnexion).Supprimer(int.Parse(PrestationSelectionnee[0].ToString()));
                BcpPrestations.Remove(PrestationSelectionnee);
            }
        }
        public void PrestationSelectionnee2UnePrestation()
        {
            UnePrestation.ID = Convert.ToInt32(PrestationSelectionnee[0].ToString());
            UnePrestation.IDT = Convert.ToInt32(PrestationSelectionnee[1].ToString());

            string[] s1;
            s1 = PrestationSelectionnee[2].ToString().Split('-');
            UnePrestation.IDS = Convert.ToInt32(s1[0]);

            UnePrestation.NbHeure = Convert.ToInt32(PrestationSelectionnee[3].ToString());
            UnePrestation.Prix = Convert.ToDouble(PrestationSelectionnee[4].ToString());

            UnePrestation.Service = PrestationSelectionnee[2].ToString();
        }
    }
    public class VM_UnePrestation : BasePropriete
    {
        private int _ID, _IDT, _IDS, _NbHeure;
        private double _Prix;

        private string _Service;
        public string Service
        {
            get { return _Service; }
            set { AssignerChamp<string>(ref _Service, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        public int ID
        {
            get { return _ID; }
            set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int IDT
        {
            get { return _IDT; }
            set { AssignerChamp<int>(ref _IDT, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int IDS
        {
            get { return _IDS; }
            set { AssignerChamp<int>(ref _IDS, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int NbHeure
        {
            get { return _NbHeure; }
            set { AssignerChamp<int>(ref _NbHeure, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public double Prix
        {
            get { return _Prix; }
            set { AssignerChamp<double>(ref _Prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

    }
}