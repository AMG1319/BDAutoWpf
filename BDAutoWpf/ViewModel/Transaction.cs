using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Windows.Documents;

namespace BDAutoWpf.ViewModel
{
    public class VM_Transaction : BasePropriete
    {
        //DESKTOP-U9ONRQ2\SQLEXPRESS
        #region Données Écran
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        private int nAjout;
        public DataTable dtTransaction = new DataTable();

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
        private DataRowView _TransactionSelectionnee;
        public DataRowView TransactionSelectionnee
        {
            get { return _TransactionSelectionnee; }
            set { AssignerChamp<DataRowView>(ref _TransactionSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
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
        #endregion
        #region Commandes
        public BaseCommande cConfirmer { get; set; }
        public BaseCommande cAnnuler { get; set; }
        public BaseCommande cAjouter { get; set; }
        public BaseCommande cModifier { get; set; }
        public BaseCommande cSupprimer { get; set; }
        public BaseCommande cFacture { get; set; }
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
            cFacture = new BaseCommande(Facture);
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
                dtTransaction.Rows.Add(t.IDTransaction, t.IDClient + "-" + Tmp.CNom + "-" + Tmp.CPrenom, t.IDVoiture+"-"+Tmp1.VMarque+"-"+Tmp1.VModel, t.TType, t.TPrix, t.TDate.Date.ToString("d"));
            }
            rep.DataSource = dtTransaction;
            return rep;
        }
        public void Confirmer()
        {
            string[] s1;
            s1 = UneTransaction.Client.Split('-');
            UneTransaction.IDC = Convert.ToInt32(s1[0]);
            string[] s2;
            s2 = UneTransaction.Voiture.Split('-');
            UneTransaction.IDV = Convert.ToInt32(s2[0]);

            if (nAjout == -1)
            {
                UneTransaction.ID = new G_TTransaction(chConnexion).Ajouter(UneTransaction.IDC, UneTransaction.IDV, UneTransaction.Type, UneTransaction.Prix, UneTransaction.Dt);
                dtTransaction.Rows.Add(UneTransaction.ID,UneTransaction.Client, UneTransaction.Voiture, UneTransaction.Type, UneTransaction.Prix, UneTransaction.Dt.ToString("d"));
            }
            else
            {
                new G_TTransaction(chConnexion).Modifier(UneTransaction.ID, UneTransaction.IDC, UneTransaction.IDV, UneTransaction.Type, UneTransaction.Prix, UneTransaction.Dt);

                TransactionSelectionnee[1] = UneTransaction.Client.ToString();
                TransactionSelectionnee[2] = UneTransaction.Voiture.ToString();
                TransactionSelectionnee[3] = UneTransaction.Type.ToString();
                TransactionSelectionnee[4] = UneTransaction.Prix.ToString();
                TransactionSelectionnee[5] = UneTransaction.Dt.ToString();
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
                C_TTransaction Tmp = new G_TTransaction(chConnexion).Lire_ID(int.Parse(TransactionSelectionnee[0].ToString()));
                UneTransaction = new VM_UneTransaction();
                UneTransaction.ID = Tmp.IDTransaction;
                UneTransaction.IDC = Tmp.IDClient;
                UneTransaction.IDV = Tmp.IDVoiture;
                UneTransaction.Type = Tmp.TType;
                UneTransaction.Prix = Tmp.TPrix;
                UneTransaction.Dt = Tmp.TDate;
                nAjout = BcpTransactions.IndexOf(TransactionSelectionnee);
                ActiverUneFiche = true;
                C_TClient Tmp2 = new G_TClient(chConnexion).Lire_ID(Tmp.IDClient);
                UneTransaction.Client = Tmp2.IDClient + "-" + Tmp2.CNom + "-" + Tmp2.CPrenom;

                C_TVoiture Tmp3 = new G_TVoiture(chConnexion).Lire_ID(Tmp.IDVoiture);
                UneTransaction.Voiture = Tmp3.IDVoiture + "-" + Tmp3.VMarque+ "-" + Tmp3.VModel;
            }
        }
        public void Supprimer()
        {
            if (TransactionSelectionnee != null)
            {
                new G_TTransaction(chConnexion).Supprimer(int.Parse(TransactionSelectionnee[0].ToString()));
                BcpTransactions.Remove(TransactionSelectionnee);
            }
        }
        public void Facture()
        {
            if (TransactionSelectionnee != null)
            {
                FlowDocument fd = new FlowDocument();
                Paragraph p = new Paragraph();
                int id = UneTransaction.ID;
                C_TTransaction pTmp = new G_TTransaction(chConnexion).Lire_ID(id);
                C_TClient client = new G_TClient(chConnexion).Lire_ID(pTmp.IDClient);
                C_TVoiture voiture = new G_TVoiture(chConnexion).Lire_ID(pTmp.IDVoiture);

                p.Inlines.Add(new Bold(new Run("-------------------FACTURE-------------------")));
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Numéro de facture   :    " + id);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Type de transaction :    " + pTmp.TType);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Date de transaction :    " + pTmp.TDate.Date.ToString("d"));
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Identifiant Client  :    " + pTmp.IDClient.ToString());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Nom                 :    " + client.CNom);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Prénom              :    " + client.CPrenom);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Numéro de Tel.      :    " + client.CNumTel);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Email               :    " + client.CMail);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Identifiant Voiture :    " + pTmp.IDVoiture.ToString());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Marque              :    " + voiture.VMarque);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Modèle              :    " + voiture.VModel);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Année               :    " + voiture.VAnnee);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Kilométrage         :    " + voiture.VKilometrage);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Couleur             :    " + voiture.VCouleur);
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Prix de transaction :    " + pTmp.TPrix.ToString() + " €");
                List<C_TPrestation> prest = new G_TPrestation(chConnexion).Lire("IDPrestation");
                double Fprix = (double)pTmp.TPrix;
                bool ifprest = false;
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add("Frais effectué(s) sur le véhicule :");
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                p.Inlines.Add(new LineBreak());
                foreach (C_TPrestation a in prest)
                {                    
                    if(a.IDTransaction == UneTransaction.ID)
                    {
                        ifprest = true;
                        C_TService sv = new G_TService(chConnexion).Lire_ID(a.IDService);
                        p.Inlines.Add("Frais de :    " + sv.SNom);
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add("Prix de la prestation :    " + a.PPrixTot + " €");
                        p.Inlines.Add(new LineBreak());
                        p.Inlines.Add(new LineBreak());
                        Fprix += a.PPrixTot;                        
                    }
                }
                if(ifprest==false)
                {
                    p.Inlines.Add(" Aucun frais n'a été effectué sur cette transaction");
                }
                else
                {
                    p.Inlines.Add(new LineBreak());
                    p.Inlines.Add("Prix Total de la facture :    " + Fprix + " €");
                }                


                fd.Blocks.Add(p);

                FileStream fs = new FileStream(@"D:\WPF-Winforms\Facture-" + id + ".rtf", FileMode.Create);
                TextRange tr = new TextRange(fd.ContentStart, fd.ContentEnd);
                tr.Save(fs, System.Windows.DataFormats.Rtf);
                Process.Start(@"D:\WPF-Winforms\Facture-" + id + ".rtf");
            }
            else
                MessageBox.Show("Sélectionner une transaction svp");
        
        }
        public void TransactionSelectionnee2UneTransaction()
        {
            UneTransaction.ID = Convert.ToInt32(TransactionSelectionnee[0].ToString());
            string[] s1;
            s1 = TransactionSelectionnee[1].ToString().Split('-');
            UneTransaction.IDC = Convert.ToInt32(s1[0]);

            string[] s2;
            s2 = TransactionSelectionnee[2].ToString().Split('-');
            UneTransaction.IDV = Convert.ToInt32(s2[0]);

            UneTransaction.Type = TransactionSelectionnee[3].ToString();
            UneTransaction.Prix = Convert.ToDecimal(TransactionSelectionnee[4].ToString());
            UneTransaction.Dt = Convert.ToDateTime(TransactionSelectionnee[5].ToString());

            UneTransaction.Client = TransactionSelectionnee[1].ToString();
            UneTransaction.Voiture = TransactionSelectionnee[2].ToString();
        }
    }
    public class VM_UneTransaction : BasePropriete
    {
        private int _ID, _IDC, _IDV;
        private string _Type;
        private decimal _Prix;
        private DateTime _Dt;

        private string _Client;

        public string Client
        {
            get { return _Client; }
            set { AssignerChamp<string>(ref _Client, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

        private string _Voiture;

        public string Voiture
        {
            get { return _Voiture; }
            set { AssignerChamp<string>(ref _Voiture, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
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