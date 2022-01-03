using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDAutoWpf.ViewModel
{
    public class VM_ChiffreDaffaire : BasePropriete
    {
        private string chConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        public BaseCommande cCalculer { get; set; }

        public VM_ChiffreDaffaire()
        {
            cCalculer = new BaseCommande(Calculer);
        }
        private string _LChiffre;
        public string LChiffre
        {
            get { return _LChiffre; }
            set { AssignerChamp<string>(ref _LChiffre, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        private DateTime _Dt;
        public DateTime Dt
        {
            get { return _Dt; }
            set { AssignerChamp<DateTime>(ref _Dt, value, System.Reflection.MethodBase.GetCurrentMethod().Name); }
        }
        public void Calculer()
        {
            DateTime cmp = Dt;
            decimal chiffre = 0;
            List<C_TTransaction> lTmp1 = new G_TTransaction(chConnexion).Lire("IDClient");
            foreach (C_TTransaction t in lTmp1)
            {
                if (t.TType == "Vente")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (t.TDate.Date == cmp.AddDays(i).Date)
                        {
                            chiffre = chiffre + t.TPrix;
                        }
                    }
                }
            }
            LChiffre = chiffre.ToString() + "€";
        }
    }
}
