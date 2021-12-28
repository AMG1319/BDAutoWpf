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
    public class VM_Service : BasePropriete
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
        private C_TService _ServiceSelectionnee;
        public C_TService ServiceSelectionnee
        {
            get { return _ServiceSelectionnee; }
            set { AssignerChamp<C_TService>(ref _ServiceSelectionnee, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        #endregion
        #region Données extérieures
        private VM_UnService _UnService;
        public VM_UnService UnService
        {
            get { return _UnService; }
            set { AssignerChamp<VM_UnService>(ref _UnService, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private ObservableCollection<C_TService> _BcpServices = new ObservableCollection<C_TService>();
        public ObservableCollection<C_TService> BcpServices
        {
            get { return _BcpServices; }
            set { _BcpServices = value; }
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
        public VM_Service()
        {
            UnService = new VM_UnService();
            UnService.ID = 1;
            UnService.Nom = "Service";
            UnService.Prix = 121;



            BcpServices = ChargerServices(chConnexion);
            ActiverUneFiche = false;
            cConfirmer = new BaseCommande(Confirmer);
            cAnnuler = new BaseCommande(Annuler);
            cAjouter = new BaseCommande(Ajouter);
            cModifier = new BaseCommande(Modifier);
            cSupprimer = new BaseCommande(Supprimer);
            cEssaiSelMult = new BaseCommande(EssaiSelMult);
        }
        private ObservableCollection<C_TService> ChargerServices(string chConn)
        {
            ObservableCollection<C_TService> rep = new ObservableCollection<C_TService>();
            List<C_TService> lTmp = new G_TService(chConn).Lire("CNom");
            foreach (C_TService Tmp in lTmp)
                rep.Add(Tmp);
            return rep;
        }
        public void Confirmer()
        {
            if (nAjout == -1)
            {
                UnService.ID = new G_TService(chConnexion).Ajouter(UnService.Nom, UnService.Prix);
                BcpServices.Add(new C_TService(UnService.Nom, UnService.Prix));
            }
            else
            {
                new G_TService(chConnexion).Modifier(UnService.ID,UnService.Nom, UnService.Prix);
                BcpServices[nAjout] = new C_TService(UnService.ID,UnService.Nom, UnService.Prix);
            }
            ActiverUneFiche = false;
        }
        public void Annuler()
        { ActiverUneFiche = false; }
        public void Ajouter()
        {
            UnService = new VM_UnService();
            nAjout = -1;
            ActiverUneFiche = true;
        }
        public void Modifier()
        {
            if (ServiceSelectionnee != null)
            {
                C_TService Tmp = new G_TService(chConnexion).Lire_ID(ServiceSelectionnee.IDService);
                UnService = new VM_UnService();
                UnService.ID = Tmp.IDService;
                UnService.Nom = Tmp.SNom;
                UnService.Prix = Tmp.SPrix;

                ActiverUneFiche = true;
            }
        }
        public void Supprimer()
        {
            if (ServiceSelectionnee != null)
            {
                new G_TService(chConnexion).Supprimer(ServiceSelectionnee.IDService);
                BcpServices.Remove(ServiceSelectionnee);
            }
        }
        public void EssaiSelMult(object lListe)
        {
            IList lTmp = (IList)lListe;
            foreach (C_TService p in lTmp)
            { string s = p.SNom; }
            int nTmp = lTmp.Count;
        }
        public void ClientSelectionnee2UnClient()
        {
            UnService.ID = ServiceSelectionnee.IDService;
            UnService.Nom = ServiceSelectionnee.SNom;
            UnService.Prix = ServiceSelectionnee.SPrix;
        }
    }
    public class VM_UnService : BasePropriete
    {
        private int _ID;
        private string _Nom;
        private double _Prix; 


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
        public double Prix
        {
            get { return _Prix; }
            set { AssignerChamp<double>(ref _Prix, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }

    }
}
