using BDAutoWpf.Classes;
using BDAutoWpf.Gestion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDAutoWpf.ViewModel
{
    public class VM_StockHtml : BasePropriete
    {
        private string sConnexion = ConfigurationManager.ConnectionStrings["BDAutoWpf.Properties.Settings.BDConnexion"].ConnectionString;
        private DataTable dtVoiture;
        private BindingSource bsVoiture;
        public VM_StockHtml()
        {            
                        
        }
        public void GenererHTML()
        {
            RemplirDT();
            StringBuilder strHTMLBuilder = new StringBuilder();
            strHTMLBuilder.Append("<html>");
            strHTMLBuilder.Append("<head>");
            strHTMLBuilder.Append("</head>");
            strHTMLBuilder.Append("<body>");
            strHTMLBuilder.Append("<h2 style='text-align:center ; background - color:Black;color: pink;font-family:arial; '>Voiture Disponible en stock</h1>");
            //strHTMLBuilder.Append("<h1 style='text-align:center ; style='color: blue';font-family:arial; '>voiture </h1>");
            strHTMLBuilder.Append("<table align='center' border='3px' cellpadding='5' cellspacing='1' bgcolor='black'style='color:white; border: 1px solid #ccc;font-size: 12pt;font-family:arial'>");
            strHTMLBuilder.Append("<tr>");
            foreach (DataColumn myColumn in dtVoiture.Columns)
            {
                strHTMLBuilder.Append("<td >");
                strHTMLBuilder.Append(myColumn.ColumnName);
                strHTMLBuilder.Append("</td>");
            }
            strHTMLBuilder.Append("</tr>");
            foreach (DataRow myRow in dtVoiture.Rows)
            {
                strHTMLBuilder.Append("<tr >");
                foreach (DataColumn myColumn in dtVoiture.Columns)
                {
                    strHTMLBuilder.Append("<td >");
                    strHTMLBuilder.Append(myRow[myColumn.ColumnName].ToString());
                    strHTMLBuilder.Append("</td>");

                }
                strHTMLBuilder.Append("</tr>");
            }
            strHTMLBuilder.Append("</table>");
            strHTMLBuilder.Append("</body>");
            strHTMLBuilder.Append("</html>");
            string Htmltext = strHTMLBuilder.ToString();
            File.WriteAllText(@"D:\WPF-Winforms\BDAutoStock.HTML", Htmltext);
        }
        public void RemplirDT()
        {
            int Vente, Achat;
            dtVoiture = new DataTable();
            dtVoiture.Columns.Add(new DataColumn("IDVoiture", System.Type.GetType("System.Int32")));
            dtVoiture.Columns.Add(new DataColumn("Marque"));
            dtVoiture.Columns.Add(new DataColumn("Model"));
            dtVoiture.Columns.Add(new DataColumn("Annee"));
            dtVoiture.Columns.Add(new DataColumn("Kilometrage"));
            dtVoiture.Columns.Add(new DataColumn("Couleur"));
            dtVoiture.Columns.Add(new DataColumn("Prix"));
            List<C_TVoiture> lTmp = new G_TVoiture(sConnexion).Lire("IDVoiture");
            List<C_TTransaction> lTmp1 = new G_TTransaction(sConnexion).Lire("IDVoiture");
            foreach (C_TVoiture v in lTmp)
            {
                Vente = Achat = 0;
                foreach (C_TTransaction t in lTmp1)
                {
                    if (v.IDVoiture == t.IDVoiture)
                    {
                        if (t.TType == "Achat")
                            Achat++;
                        else if (t.TType == "Vente")
                            Vente++;
                    }
                }
                if (Achat > Vente)
                {
                    dtVoiture.Rows.Add(v.IDVoiture, v.VMarque, v.VModel, v.VAnnee, v.VKilometrage, v.VCouleur, v.VPrix);
                }
            }
            bsVoiture = new BindingSource();
            bsVoiture.DataSource = dtVoiture;
        }
    }
}
