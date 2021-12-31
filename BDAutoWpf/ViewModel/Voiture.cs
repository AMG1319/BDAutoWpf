using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System.Collections;
using System.Configuration;

namespace BDAutoWpf.ViewModel
{
    public class VM_Voiture : BasePropriete
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
        private C_TVoiture _VoitureSelectionnee;
        public C_TVoiture VoitureSelectionnee
        {
            get { return _VoitureSelectionnee; }
            set { AssignerChamp<C_TVoiture>(ref _VoitureSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
        private VM_UneVoiture _UneVoiture;
        public VM_UneVoiture UneVoiture
        {
            get { return _UneVoiture; }
            set { AssignerChamp<VM_UneVoiture>(ref _UneVoiture, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_TVoiture> _BcpVoitures = new ObservableCollection<C_TVoiture>();
        public ObservableCollection<C_TVoiture> BcpVoitures
        {
            get { return _BcpVoitures; }
            set { _BcpVoitures = value; }
        }
        #endregion
        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        #endregion
        public VM_Voiture()
        {
            UneVoiture = new VM_UneVoiture();
            UneVoiture.ID = 24;
            UneVoiture.Marque = "Toyota";
            UneVoiture.Model = "YarisGP";
            UneVoiture.Annee = 2020;
            UneVoiture.Km = 1000;
            UneVoiture.Couleur = "Blanc";
            UneVoiture.Prix = 32000;

            BcpVoitures = ChargerVoitures(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
        }
        private ObservableCollection<C_TVoiture> ChargerVoitures(string chConn)
        {
            ObservableCollection<C_TVoiture> rep = new ObservableCollection<C_TVoiture>();
            List<C_TVoiture> lTmp = new G_TVoiture(chConn).Lire("VMarque");
            foreach (C_TVoiture Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UneVoiture.ID = new G_TVoiture(chConnexion).Ajouter(UneVoiture.Marque, UneVoiture.Model, UneVoiture.Annee, UneVoiture.Km, UneVoiture.Couleur, UneVoiture.Prix);
                BcpVoitures.Add(new C_TVoiture(UneVoiture.ID, UneVoiture.Marque, UneVoiture.Model, UneVoiture.Annee, UneVoiture.Km, UneVoiture.Couleur, UneVoiture.Prix));
            }
            else
            {
                new G_TVoiture(chConnexion).Modifier(UneVoiture.ID, UneVoiture.Marque, UneVoiture.Model, UneVoiture.Annee, UneVoiture.Km, UneVoiture.Couleur, UneVoiture.Prix);
                BcpVoitures[nAjout] = new C_TVoiture(UneVoiture.ID, UneVoiture.Marque, UneVoiture.Model, UneVoiture.Annee, UneVoiture.Km, UneVoiture.Couleur, UneVoiture.Prix);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UneVoiture = new VM_UneVoiture();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (VoitureSelectionnee != null)
            {
                C_TVoiture Tmp = new G_TVoiture(chConnexion).Lire_ID(VoitureSelectionnee.IDVoiture);
                UneVoiture = new VM_UneVoiture();
                UneVoiture.ID = Tmp.IDVoiture;
                UneVoiture.Marque = Tmp.VMarque;
                UneVoiture.Model = Tmp.VModel;
                UneVoiture.Annee = Tmp.VAnnee;
                UneVoiture.Km = Tmp.VKilometrage;
                UneVoiture.Couleur = Tmp.VCouleur;
                UneVoiture.Prix = Tmp.VPrix;
                nAjout = BcpVoitures.IndexOf(VoitureSelectionnee);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (VoitureSelectionnee != null)
            {
                new G_TVoiture(chConnexion).Supprimer(VoitureSelectionnee.IDVoiture);
                BcpVoitures.Remove(VoitureSelectionnee);
            }
        }

        public void VoitureSelectionnee2UneVoiture()
        {
            UneVoiture.ID = VoitureSelectionnee.IDVoiture;
            UneVoiture.Marque = VoitureSelectionnee.VMarque;
            UneVoiture.Model = VoitureSelectionnee.VModel;
            UneVoiture.Annee = VoitureSelectionnee.VAnnee;
            UneVoiture.Km = VoitureSelectionnee.VKilometrage;
            UneVoiture.Couleur = VoitureSelectionnee.VCouleur;
            UneVoiture.Prix = VoitureSelectionnee.VPrix;
        }
    }
    public class VM_UneVoiture : BasePropriete
    {
        private int _ID;
        private string _Marque, _Model, _Couleur;
        private decimal _Annee, _Km, _Prix;

        public int ID
        {
            get { return _ID; }
            set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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
        public decimal Annee
        {
            get { return _Annee; }
            set { AssignerChamp<decimal>(ref _Annee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public decimal Km
        {
            get { return _Km; }
            set { AssignerChamp<decimal>(ref _Km, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Couleur
        {
            get { return _Couleur; }
            set { AssignerChamp<string>(ref _Couleur, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public decimal Prix
        {
            get { return _Prix; }
            set { AssignerChamp<decimal>(ref _Prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

    }
}