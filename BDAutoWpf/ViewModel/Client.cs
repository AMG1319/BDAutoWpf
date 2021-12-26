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
    public class VM_Client : BasePropriete
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
        private C_TClient _ClientSelectionnee;
        public C_TClient ClientSelectionnee
        {
            get { return _ClientSelectionnee ;}
            set { AssignerChamp<C_TClient>(ref _ClientSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
        private VM_UnClient _UnClient;
        public VM_UnClient UnClient
        {
            get { return _UnClient; }
            set { AssignerChamp<VM_UnClient>(ref _UnClient, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_TClient> _BcpClients = new ObservableCollection<C_TClient>();
        public ObservableCollection<C_TClient> BcpClients
        {
            get { return _BcpClients; }
            set { _BcpClients = value; }
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
        public VM_Client()
        {
            UnClient = new VM_UnClient();
            UnClient.ID = 1;
            UnClient.Nom = "Nom";
            UnClient.Prenom = "YarisGP";
            UnClient.NumTel = "+32";
            UnClient.Mail = "xyz@hotmail.be";
            UnClient.CodePostal = 0000;


            BcpClients = ChargerClients(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }
        private ObservableCollection<C_TClient> ChargerClients(string chConn)
        {
            ObservableCollection<C_TClient> rep = new ObservableCollection<C_TClient>();
            List<C_TClient> lTmp = new G_TClient(chConn).Lire("CNom");
            foreach (C_TClient Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnClient.ID = new G_TClient(chConnexion).Ajouter(UnClient.Nom,UnClient.Prenom,UnClient.NumTel,UnClient.Mail,UnClient.CodePostal);
                BcpClients.Add(new C_TClient(UnClient.ID, UnClient.Nom, UnClient.Prenom, UnClient.NumTel, UnClient.Mail, UnClient.CodePostal));
            }
            else
            {
                new G_TClient(chConnexion).Modifier(UnClient.ID, UnClient.Nom, UnClient.Prenom, UnClient.NumTel, UnClient.Mail, UnClient.CodePostal);
                BcpClients[nAjout] = new C_TClient(UnClient.ID, UnClient.Nom, UnClient.Prenom, UnClient.NumTel, UnClient.Mail, UnClient.CodePostal);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UnClient = new VM_UnClient();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (ClientSelectionnee != null)
            {
                C_TClient Tmp = new G_TClient(chConnexion).Lire_ID(ClientSelectionnee.IDClient);
                UnClient = new VM_UnClient();
                UnClient.ID = Tmp.IDClient;
                UnClient.Nom = Tmp.CNom;
                UnClient.Prenom = Tmp.CPrenom;
                UnClient.NumTel = Tmp.CNumTel;
                UnClient.Mail = Tmp.CMail;
                UnClient.CodePostal = Tmp.CCodePostal;
                nAjout = BcpClients.IndexOf(ClientSelectionnee);
                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (ClientSelectionnee != null)
            {
                new G_TClient(chConnexion).Supprimer(ClientSelectionnee.IDClient);
                BcpClients.Remove(ClientSelectionnee);
            }
        }
        public void EssaiSelMult(object lListe)
        {
            IList lTmp = (IList)lListe;
            foreach (C_TClient p in lTmp)
            { string s = p.CNom; }
            int nTmp = lTmp.Count;
        }
        public void ClientSelectionnee2UnClient()
        {
            UnClient.ID = ClientSelectionnee.IDClient;
            UnClient.Nom = ClientSelectionnee.CNom;
            UnClient.Prenom = ClientSelectionnee.CPrenom;
            UnClient.NumTel = ClientSelectionnee.CNumTel;
            UnClient.Mail = ClientSelectionnee.CMail;
            UnClient.CodePostal = ClientSelectionnee.CCodePostal;
        }
    }
    public class VM_UnClient : BasePropriete
    {
        private int _ID, _CodePostal;
        private string _Nom, _Prenom, _NumTel, _Mail;


        public int ID
        {
            get { return _ID; }
            set { AssignerChamp<int>(ref _ID, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Nom
        {
            get { return _Nom; }
            set { AssignerChamp<string>(ref _Nom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Prenom
        {
            get { return _Prenom; }
            set { AssignerChamp<string>(ref _Prenom, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string NumTel
        {
            get { return _NumTel; }
            set { AssignerChamp<string>(ref _NumTel, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public string Mail
        {
            get { return _Mail; }
            set { AssignerChamp<string>(ref _Mail, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public int CodePostal
        {
            get { return _CodePostal; }
            set { AssignerChamp<int>(ref _CodePostal, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }


    }
}
