#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BDAutoWpf.Classes;
#endregion

namespace BDAutoWpf.Acces
{
 /// <summary>
 /// Couche d'accès aux données (Data Access Layer)
 /// </summary>
 public class A_TPrestation : ADBase
 {
  #region Constructeurs
  public A_TPrestation(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int IDTransaction, int IDService, int PNbHeure, double PPrixTot)
  {
   CreerCommande("AjouterTPrestation");
   int res = 0;
   Commande.Parameters.Add("IDPrestation", SqlDbType.Int);
   Direction("IDPrestation", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@IDTransaction", IDTransaction);
   Commande.Parameters.AddWithValue("@IDService", IDService);
   Commande.Parameters.AddWithValue("@PNbHeure", PNbHeure);
   Commande.Parameters.AddWithValue("@PPrixTot", PPrixTot);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IDPrestation"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IDPrestation, int IDTransaction, int IDService, int PNbHeure, double PPrixTot)
  {
   CreerCommande("ModifierTPrestation");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDPrestation", IDPrestation);
   Commande.Parameters.AddWithValue("@IDTransaction", IDTransaction);
   Commande.Parameters.AddWithValue("@IDService", IDService);
   Commande.Parameters.AddWithValue("@PNbHeure", PNbHeure);
   Commande.Parameters.AddWithValue("@PPrixTot", PPrixTot);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_TPrestation> Lire(string Index)
  {
   CreerCommande("SelectionnerTPrestation");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_TPrestation> res = new List<C_TPrestation>();
   while (dr.Read())
   {
    C_TPrestation tmp = new C_TPrestation();
    tmp.IDPrestation = int.Parse(dr["IDPrestation"].ToString());
    tmp.IDTransaction = int.Parse(dr["IDTransaction"].ToString());
    tmp.IDService = int.Parse(dr["IDService"].ToString());
    tmp.PNbHeure = int.Parse(dr["PNbHeure"].ToString());
    tmp.PPrixTot = double.Parse(dr["PPrixTot"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_TPrestation Lire_ID(int IDPrestation)
  {
   CreerCommande("SelectionnerTPrestation_ID");
   Commande.Parameters.AddWithValue("@IDPrestation", IDPrestation);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_TPrestation res = new C_TPrestation();
   while (dr.Read())
   {
    res.IDPrestation = int.Parse(dr["IDPrestation"].ToString());
    res.IDTransaction = int.Parse(dr["IDTransaction"].ToString());
    res.IDService = int.Parse(dr["IDService"].ToString());
    res.PNbHeure = int.Parse(dr["PNbHeure"].ToString());
    res.PPrixTot = double.Parse(dr["PPrixTot"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IDPrestation)
  {
   CreerCommande("SupprimerTPrestation");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDPrestation", IDPrestation);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
