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
 public class A_TDesidrata : ADBase
 {
  #region Constructeurs
  public A_TDesidrata(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int IDClient, string DMarque, string DModel, decimal? DAnneeMin, decimal? DAnneeMax, decimal? DKmMin, decimal? DKmMax, string DCouleur, decimal? DPrixMin, decimal? DPrixMax)
  {
   CreerCommande("AjouterTDesidrata");
   int res = 0;
   Commande.Parameters.Add("IDDesidrata", SqlDbType.Int);
   Direction("IDDesidrata", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@IDClient", IDClient);
   if(DMarque == null) Commande.Parameters.AddWithValue("@DMarque", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DMarque", DMarque);
   if(DModel == null) Commande.Parameters.AddWithValue("@DModel", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DModel", DModel);
   if(DAnneeMin == null) Commande.Parameters.AddWithValue("@DAnneeMin", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DAnneeMin", DAnneeMin);
   if(DAnneeMax == null) Commande.Parameters.AddWithValue("@DAnneeMax", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DAnneeMax", DAnneeMax);
   if(DKmMin == null) Commande.Parameters.AddWithValue("@DKmMin", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DKmMin", DKmMin);
   if(DKmMax == null) Commande.Parameters.AddWithValue("@DKmMax", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DKmMax", DKmMax);
   if(DCouleur == null) Commande.Parameters.AddWithValue("@DCouleur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DCouleur", DCouleur);
   if(DPrixMin == null) Commande.Parameters.AddWithValue("@DPrixMin", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DPrixMin", DPrixMin);
   if(DPrixMax == null) Commande.Parameters.AddWithValue("@DPrixMax", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DPrixMax", DPrixMax);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IDDesidrata"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IDDesidrata, int IDClient, string DMarque, string DModel, decimal? DAnneeMin, decimal? DAnneeMax, decimal? DKmMin, decimal? DKmMax, string DCouleur, decimal? DPrixMin, decimal? DPrixMax)
  {
   CreerCommande("ModifierTDesidrata");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDDesidrata", IDDesidrata);
   Commande.Parameters.AddWithValue("@IDClient", IDClient);
   if(DMarque == null) Commande.Parameters.AddWithValue("@DMarque", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DMarque", DMarque);
   if(DModel == null) Commande.Parameters.AddWithValue("@DModel", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DModel", DModel);
   if(DAnneeMin == null) Commande.Parameters.AddWithValue("@DAnneeMin", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DAnneeMin", DAnneeMin);
   if(DAnneeMax == null) Commande.Parameters.AddWithValue("@DAnneeMax", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DAnneeMax", DAnneeMax);
   if(DKmMin == null) Commande.Parameters.AddWithValue("@DKmMin", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DKmMin", DKmMin);
   if(DKmMax == null) Commande.Parameters.AddWithValue("@DKmMax", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DKmMax", DKmMax);
   if(DCouleur == null) Commande.Parameters.AddWithValue("@DCouleur", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DCouleur", DCouleur);
   if(DPrixMin == null) Commande.Parameters.AddWithValue("@DPrixMin", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DPrixMin", DPrixMin);
   if(DPrixMax == null) Commande.Parameters.AddWithValue("@DPrixMax", Convert.DBNull);
   else Commande.Parameters.AddWithValue("@DPrixMax", DPrixMax);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_TDesidrata> Lire(string Index)
  {
   CreerCommande("SelectionnerTDesidrata");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_TDesidrata> res = new List<C_TDesidrata>();
   while (dr.Read())
   {
    C_TDesidrata tmp = new C_TDesidrata();
    tmp.IDDesidrata = int.Parse(dr["IDDesidrata"].ToString());
    tmp.IDClient = int.Parse(dr["IDClient"].ToString());
    tmp.DMarque = dr["DMarque"].ToString();
    tmp.DModel = dr["DModel"].ToString();
   if(dr["DAnneeMin"] != DBNull.Value) tmp.DAnneeMin = decimal.Parse(dr["DAnneeMin"].ToString());
   if(dr["DAnneeMax"] != DBNull.Value) tmp.DAnneeMax = decimal.Parse(dr["DAnneeMax"].ToString());
   if(dr["DKmMin"] != DBNull.Value) tmp.DKmMin = decimal.Parse(dr["DKmMin"].ToString());
   if(dr["DKmMax"] != DBNull.Value) tmp.DKmMax = decimal.Parse(dr["DKmMax"].ToString());
    tmp.DCouleur = dr["DCouleur"].ToString();
   if(dr["DPrixMin"] != DBNull.Value) tmp.DPrixMin = decimal.Parse(dr["DPrixMin"].ToString());
   if(dr["DPrixMax"] != DBNull.Value) tmp.DPrixMax = decimal.Parse(dr["DPrixMax"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_TDesidrata Lire_ID(int IDDesidrata)
  {
   CreerCommande("SelectionnerTDesidrata_ID");
   Commande.Parameters.AddWithValue("@IDDesidrata", IDDesidrata);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_TDesidrata res = new C_TDesidrata();
   while (dr.Read())
   {
    res.IDDesidrata = int.Parse(dr["IDDesidrata"].ToString());
    res.IDClient = int.Parse(dr["IDClient"].ToString());
    res.DMarque = dr["DMarque"].ToString();
    res.DModel = dr["DModel"].ToString();
   if(dr["DAnneeMin"] != DBNull.Value) res.DAnneeMin = decimal.Parse(dr["DAnneeMin"].ToString());
   if(dr["DAnneeMax"] != DBNull.Value) res.DAnneeMax = decimal.Parse(dr["DAnneeMax"].ToString());
   if(dr["DKmMin"] != DBNull.Value) res.DKmMin = decimal.Parse(dr["DKmMin"].ToString());
   if(dr["DKmMax"] != DBNull.Value) res.DKmMax = decimal.Parse(dr["DKmMax"].ToString());
    res.DCouleur = dr["DCouleur"].ToString();
   if(dr["DPrixMin"] != DBNull.Value) res.DPrixMin = decimal.Parse(dr["DPrixMin"].ToString());
   if(dr["DPrixMax"] != DBNull.Value) res.DPrixMax = decimal.Parse(dr["DPrixMax"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IDDesidrata)
  {
   CreerCommande("SupprimerTDesidrata");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDDesidrata", IDDesidrata);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
