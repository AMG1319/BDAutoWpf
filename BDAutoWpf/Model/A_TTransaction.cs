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
 public class A_TTransaction : ADBase
 {
  #region Constructeurs
  public A_TTransaction(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int IDClient, int IDVoiture, string TType, decimal TPrix, DateTime TDate)
  {
   CreerCommande("AjouterTTransaction");
   int res = 0;
   Commande.Parameters.Add("IDTransaction", SqlDbType.Int);
   Direction("IDTransaction", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@IDClient", IDClient);
   Commande.Parameters.AddWithValue("@IDVoiture", IDVoiture);
   Commande.Parameters.AddWithValue("@TType", TType);
   Commande.Parameters.AddWithValue("@TPrix", TPrix);
   Commande.Parameters.AddWithValue("@TDate", TDate);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IDTransaction"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IDTransaction, int IDClient, int IDVoiture, string TType, decimal TPrix, DateTime TDate)
  {
   CreerCommande("ModifierTTransaction");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDTransaction", IDTransaction);
   Commande.Parameters.AddWithValue("@IDClient", IDClient);
   Commande.Parameters.AddWithValue("@IDVoiture", IDVoiture);
   Commande.Parameters.AddWithValue("@TType", TType);
   Commande.Parameters.AddWithValue("@TPrix", TPrix);
   Commande.Parameters.AddWithValue("@TDate", TDate);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_TTransaction> Lire(string Index)
  {
   CreerCommande("SelectionnerTTransaction");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_TTransaction> res = new List<C_TTransaction>();
   while (dr.Read())
   {
    C_TTransaction tmp = new C_TTransaction();
    tmp.IDTransaction = int.Parse(dr["IDTransaction"].ToString());
    tmp.IDClient = int.Parse(dr["IDClient"].ToString());
    tmp.IDVoiture = int.Parse(dr["IDVoiture"].ToString());
    tmp.TType = dr["TType"].ToString();
    tmp.TPrix = decimal.Parse(dr["TPrix"].ToString());
    tmp.TDate = DateTime.Parse(dr["TDate"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_TTransaction Lire_ID(int IDTransaction)
  {
   CreerCommande("SelectionnerTTransaction_ID");
   Commande.Parameters.AddWithValue("@IDTransaction", IDTransaction);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_TTransaction res = new C_TTransaction();
   while (dr.Read())
   {
    res.IDTransaction = int.Parse(dr["IDTransaction"].ToString());
    res.IDClient = int.Parse(dr["IDClient"].ToString());
    res.IDVoiture = int.Parse(dr["IDVoiture"].ToString());
    res.TType = dr["TType"].ToString();
    res.TPrix = decimal.Parse(dr["TPrix"].ToString());
    res.TDate = DateTime.Parse(dr["TDate"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IDTransaction)
  {
   CreerCommande("SupprimerTTransaction");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDTransaction", IDTransaction);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
