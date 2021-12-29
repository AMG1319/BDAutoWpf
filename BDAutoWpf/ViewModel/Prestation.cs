using System.Collections.Generic;
using System.Collections.ObjectModel;
using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System.Collections;
using System.Configuration;
using System;

namespace BDAutoWpf.ViewModel
{
    public class VM_Prestation : BasePropriete
    {
        //DESKTOP-U9ONRQ2\SQLEXPRESS
        #region Données Écran
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        private int nAjout;
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
        private C_TPrestation _PrestationSelectionnee;
        public C_TPrestation PrestationSelectionnee
        {
            get { return _PrestationSelectionnee; }
            set { AssignerChamp<C_TPrestation>(ref _PrestationSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
        private VM_UnePrestation _UnePrestation;
        public VM_UnePrestation UnePrestation
        {
            get { return _UnePrestation; }
            set { AssignerChamp<VM_UnePrestation>(ref _UnePrestation, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_TPrestation> _BcpPrestations = new ObservableCollection<C_TPrestation>();
        public ObservableCollection<C_TPrestation> BcpPrestations
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
        public BaseCommande cEssaiSelMult { get; set; }
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
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }
        private ObservableCollection<C_TPrestation> ChargerPrestations(string chConn)
        {
            ObservableCollection<C_TPrestation> rep = new ObservableCollection<C_TPrestation>();
            List<C_TPrestation> lTmp = new G_TPrestation(chConn).Lire("IDPrestation");
            foreach (C_TPrestation Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnePrestation.ID = new G_TPrestation(chConnexion).Ajouter(UnePrestation.IDT, UnePrestation.IDS, UnePrestation.NbHeure,UnePrestation.Prix);
                BcpPrestations.Add(new C_TPrestation(UnePrestation.ID, UnePrestation.IDT, UnePrestation.IDS, UnePrestation.NbHeure, UnePrestation.Prix));
            }
            else
            {
                new G_TPrestation(chConnexion).Modifier(UnePrestation.ID, UnePrestation.IDT, UnePrestation.IDS, UnePrestation.NbHeure, UnePrestation.Prix);
                BcpPrestations[nAjout] = new C_TPrestation(UnePrestation.ID, UnePrestation.IDT, UnePrestation.IDS, UnePrestation.NbHeure, UnePrestation.Prix);
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
                C_TPrestation Tmp = new G_TPrestation(chConnexion).Lire_ID(PrestationSelectionnee.IDPrestation);
                UnePrestation = new VM_UnePrestation();
                UnePrestation.ID = Tmp.IDPrestation;
                UnePrestation.IDT = Tmp.IDTransaction;
                UnePrestation.IDS = Tmp.IDService;
                UnePrestation.NbHeure = Tmp.PNbHeure;
                UnePrestation.Prix = Tmp.PPrixTot;

                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (PrestationSelectionnee != null)
            {
                new G_TPrestation(chConnexion).Supprimer(PrestationSelectionnee.IDPrestation);
                BcpPrestations.Remove(PrestationSelectionnee);
            }
        }
        public void EssaiSelMult(object lListe)
        {
            IList lTmp = (IList)lListe;
            foreach (C_TPrestation p in lTmp)
            { string s = Convert.ToString(p.IDPrestation); }
            int nTmp = lTmp.Count;
        }
        public void PrestationSelectionnee2UnePrestation()
        {
            UnePrestation.ID = PrestationSelectionnee.IDPrestation;
            UnePrestation.IDT = PrestationSelectionnee.IDTransaction;
            UnePrestation.IDS = PrestationSelectionnee.IDService;
            UnePrestation.NbHeure = PrestationSelectionnee.PNbHeure;
            UnePrestation.Prix = PrestationSelectionnee.PPrixTot;
        }
    }
    public class VM_UnePrestation : BasePropriete
    {
        private int _ID, _IDT, _IDS, _NbHeure;
        private double _Prix;


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