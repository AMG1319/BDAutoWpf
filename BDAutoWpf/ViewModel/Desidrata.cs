using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDAutoWpf.ViewModel;
using System.Windows;
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

namespace BDAutoWpf.ViewModel
{
    public class VM_Desidrata : BasePropriete
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
        private C_TDesidrata _DesidrataSelectionnee;
        public C_TDesidrata DesidrataSelectionnee
        {
            get { return _DesidrataSelectionnee; }
            set { AssignerChamp<C_TDesidrata>(ref _DesidrataSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
        private VM_UnDesidrata _UnDesidrata;
        public VM_UnDesidrata UnDesidrata
        {
            get { return _UnDesidrata; }
            set { AssignerChamp<VM_UnDesidrata>(ref _UnDesidrata, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_TDesidrata> _BcpDesidratas = new ObservableCollection<C_TDesidrata>();
        public ObservableCollection<C_TDesidrata> BcpDesidratas
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
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }
        private ObservableCollection<C_TDesidrata> ChargerDesidratas(string chConn)
        {
            ObservableCollection<C_TDesidrata> rep = new ObservableCollection<C_TDesidrata>();
            List<C_TDesidrata> lTmp = new G_TDesidrata(chConn).Lire("DMarque");
            foreach (C_TDesidrata Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnDesidrata.ID = new G_TDesidrata(chConnexion).Ajouter(UnDesidrata.IDC,UnDesidrata.Marque,UnDesidrata.Model,
                    UnDesidrata.AnneeMin,UnDesidrata.AnneeMax,UnDesidrata.KmMin,UnDesidrata.KmMax,UnDesidrata.Couleur,UnDesidrata.PrixMin,UnDesidrata.PrixMax);
                BcpDesidratas.Add(new C_TDesidrata(UnDesidrata.IDC, UnDesidrata.Marque, UnDesidrata.Model,
                    UnDesidrata.AnneeMin, UnDesidrata.AnneeMax, UnDesidrata.KmMin, UnDesidrata.KmMax, UnDesidrata.Couleur, UnDesidrata.PrixMin, UnDesidrata.PrixMax));
            }
            else
            {
                new G_TDesidrata(chConnexion).Modifier(UnDesidrata.ID, UnDesidrata.IDC, UnDesidrata.Marque, UnDesidrata.Model,
                    UnDesidrata.AnneeMin, UnDesidrata.AnneeMax, UnDesidrata.KmMin, UnDesidrata.KmMax, UnDesidrata.Couleur, UnDesidrata.PrixMin, UnDesidrata.PrixMax);
                BcpDesidratas[nAjout] = new C_TDesidrata(UnDesidrata.IDC, UnDesidrata.Marque, UnDesidrata.Model,
                    UnDesidrata.AnneeMin, UnDesidrata.AnneeMax, UnDesidrata.KmMin, UnDesidrata.KmMax, UnDesidrata.Couleur, UnDesidrata.PrixMin, UnDesidrata.PrixMax);
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
                C_TDesidrata Tmp = new G_TDesidrata(chConnexion).Lire_ID(DesidrataSelectionnee.IDDesidrata);
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
            }
        }
        public void Supprimer()
        {
            if (DesidrataSelectionnee != null)
            {
                new G_TDesidrata(chConnexion).Supprimer(DesidrataSelectionnee.IDDesidrata);
                BcpDesidratas.Remove(DesidrataSelectionnee);
            }
        }
        public void EssaiSelMult(object lListe)
        {
            IList lTmp = (IList)lListe;
            foreach (C_TDesidrata p in lTmp)
            { string s = p.DMarque; }
            int nTmp = lTmp.Count;
        }
        public void DesidrataSelectionnee2UnDesidrata()
        {
            UnDesidrata.ID = DesidrataSelectionnee.IDDesidrata;
            UnDesidrata.IDC = DesidrataSelectionnee.IDClient;
            UnDesidrata.Marque = DesidrataSelectionnee.DMarque;
            UnDesidrata.Model = DesidrataSelectionnee.DModel;
            UnDesidrata.AnneeMin = DesidrataSelectionnee.DAnneeMin;
            UnDesidrata.AnneeMax = DesidrataSelectionnee.DAnneeMax;
            UnDesidrata.KmMin = DesidrataSelectionnee.DKmMin;
            UnDesidrata.KmMax = DesidrataSelectionnee.DKmMax;
            UnDesidrata.Couleur = DesidrataSelectionnee.DCouleur;
            UnDesidrata.PrixMin = DesidrataSelectionnee.DPrixMin;
            UnDesidrata.PrixMax = DesidrataSelectionnee.DPrixMax;
        }
    }
    public class VM_UnDesidrata : BasePropriete
    {
        private int _ID, _IDC;
        private string _Marque, _Model, _Couleur;
        private decimal ? _AnneeMin, _AnneeMax, _KmMin, _KmMax, _PrixMin, _PrixMax;


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
