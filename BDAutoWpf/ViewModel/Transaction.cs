using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System.Collections;
using System.Configuration;

namespace BDAutoWpf.ViewModel
{
    public class VM_Transaction : BasePropriete
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
        private C_TTransaction _TransactionSelectionnee;
        public C_TTransaction TransactionSelectionnee
        {
            get { return _TransactionSelectionnee; }
            set { AssignerChamp<C_TTransaction>(ref _TransactionSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
        private VM_UneTransaction _UneTransaction;
        public VM_UneTransaction UneTransaction
        {
            get { return _UneTransaction; }
            set { AssignerChamp<VM_UneTransaction>(ref _UneTransaction, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_TTransaction> _BcpTransactions = new ObservableCollection<C_TTransaction>();
        public ObservableCollection<C_TTransaction> BcpTransactions
        {
            get { return _BcpTransactions; }
            set { _BcpTransactions = value; }
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
        public VM_Transaction()
        {
            UneTransaction = new VM_UneTransaction();
            UneTransaction.ID = 0;
            UneTransaction.IDC = 0;
            UneTransaction.IDV = 0;
            UneTransaction.Type = "Achat ou Vente";
            UneTransaction.Prix = 00;
            UneTransaction.Dt = DateTime.Today;
            UneTransaction.Prix = 00;

            BcpTransactions = ChargerTransactions(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }
        private ObservableCollection<C_TTransaction> ChargerTransactions(string chConn)
        {
            ObservableCollection<C_TTransaction> rep = new ObservableCollection<C_TTransaction>();
            List<C_TTransaction> lTmp = new G_TTransaction(chConn).Lire("VMarque");
            foreach (C_TTransaction Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UneTransaction.ID = new G_TTransaction(chConnexion).Ajouter(UneTransaction.IDC, UneTransaction.IDV, UneTransaction.Type, UneTransaction.Prix, UneTransaction.Dt);
                BcpTransactions.Add(new C_TTransaction(UneTransaction.ID, UneTransaction.IDC, UneTransaction.IDV, UneTransaction.Type, UneTransaction.Prix, UneTransaction.Dt));
            }
            else
            {
                new G_TTransaction(chConnexion).Modifier(UneTransaction.ID, UneTransaction.IDC, UneTransaction.IDV, UneTransaction.Type, UneTransaction.Prix, UneTransaction.Dt);
                BcpTransactions[nAjout] = new C_TTransaction(UneTransaction.ID, UneTransaction.IDC, UneTransaction.IDV, UneTransaction.Type, UneTransaction.Prix, UneTransaction.Dt);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UneTransaction = new VM_UneTransaction();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (TransactionSelectionnee != null)
            {
                C_TTransaction Tmp = new G_TTransaction(chConnexion).Lire_ID(TransactionSelectionnee.IDTransaction);
                UneTransaction = new VM_UneTransaction();
                UneTransaction.ID = Tmp.IDTransaction;
                UneTransaction.IDC = Tmp.IDClient;
                UneTransaction.IDV = Tmp.IDVoiture;
                UneTransaction.Type = Tmp.TType;
                UneTransaction.Prix = Tmp.TPrix;
                UneTransaction.Dt = Tmp.TDate;
                nAjout = BcpTransactions.IndexOf(TransactionSelectionnee);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (TransactionSelectionnee != null)
            {
                new G_TTransaction(chConnexion).Supprimer(TransactionSelectionnee.IDTransaction);
                BcpTransactions.Remove(TransactionSelectionnee);
            }
        }
        public void EssaiSelMult(object lListe)
        {
            IList lTmp = (IList)lListe;
            foreach (C_TTransaction p in lTmp)
            { string s = p.TType; }
            int nTmp = lTmp.Count;
        }
        public void TransactionSelectionnee2UneTransaction()
        {
            UneTransaction.ID = TransactionSelectionnee.IDTransaction;
            UneTransaction.IDC = TransactionSelectionnee.IDClient;
            UneTransaction.IDV = TransactionSelectionnee.IDVoiture;
            UneTransaction.Type = TransactionSelectionnee.TType;
            UneTransaction.Prix = TransactionSelectionnee.TPrix;
            UneTransaction.Dt = TransactionSelectionnee.TDate;
        }
    }
    public class VM_UneTransaction : BasePropriete
    {
        private int _ID, _IDC, _IDV;
        private string _Type;
        private decimal _Prix;
        private DateTime _Dt;

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
        public int IDV
        {
            get { return _IDV; }
            set { AssignerChamp<int>(ref _IDV, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Type
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

    }
}