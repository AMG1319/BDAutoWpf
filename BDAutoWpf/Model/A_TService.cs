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
 public class A_TService : ADBase
 {
  #region Constructeurs
  public A_TService(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string SNom, double SPrix)
  {
   CreerCommande("AjouterTService");
   int res = 0;
   Commande.Parameters.Add("IDService", SqlDbType.Int);
   Direction("IDService", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@SNom", SNom);
   Commande.Parameters.AddWithValue("@SPrix", SPrix);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IDService"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IDService, string SNom, double SPrix)
  {
   CreerCommande("ModifierTService");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDService", IDService);
   Commande.Parameters.AddWithValue("@SNom", SNom);
   Commande.Parameters.AddWithValue("@SPrix", SPrix);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_TService> Lire(string Index)
  {
   CreerCommande("SelectionnerTService");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_TService> res = new List<C_TService>();
   while (dr.Read())
   {
    C_TService tmp = new C_TService();
    tmp.IDService = int.Parse(dr["IDService"].ToString());
    tmp.SNom = dr["SNom"].ToString();
    tmp.SPrix = double.Parse(dr["SPrix"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_TService Lire_ID(int IDService)
  {
   CreerCommande("SelectionnerTService_ID");
   Commande.Parameters.AddWithValue("@IDService", IDService);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_TService res = new C_TService();
   while (dr.Read())
   {
    res.IDService = int.Parse(dr["IDService"].ToString());
    res.SNom = dr["SNom"].ToString();
    res.SPrix = double.Parse(dr["SPrix"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IDService)
  {
   CreerCommande("SupprimerTService");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDService", IDService);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
