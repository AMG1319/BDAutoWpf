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
 public class A_TClient : ADBase
 {
  #region Constructeurs
  public A_TClient(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string CNom, string CPrenom, string CNumTel, string CMail, int CCodePostal)
  {
   CreerCommande("AjouterTClient");
   int res = 0;
   Commande.Parameters.Add("IDClient", SqlDbType.Int);
   Direction("IDClient", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@CNom", CNom);
   Commande.Parameters.AddWithValue("@CPrenom", CPrenom);
   Commande.Parameters.AddWithValue("@CNumTel", CNumTel);
   Commande.Parameters.AddWithValue("@CMail", CMail);
   Commande.Parameters.AddWithValue("@CCodePostal", CCodePostal);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IDClient"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IDClient, string CNom, string CPrenom, string CNumTel, string CMail, int CCodePostal)
  {
   CreerCommande("ModifierTClient");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDClient", IDClient);
   Commande.Parameters.AddWithValue("@CNom", CNom);
   Commande.Parameters.AddWithValue("@CPrenom", CPrenom);
   Commande.Parameters.AddWithValue("@CNumTel", CNumTel);
   Commande.Parameters.AddWithValue("@CMail", CMail);
   Commande.Parameters.AddWithValue("@CCodePostal", CCodePostal);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_TClient> Lire(string Index)
  {
   CreerCommande("SelectionnerTClient");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_TClient> res = new List<C_TClient>();
   while (dr.Read())
   {
    C_TClient tmp = new C_TClient();
    tmp.IDClient = int.Parse(dr["IDClient"].ToString());
    tmp.CNom = dr["CNom"].ToString();
    tmp.CPrenom = dr["CPrenom"].ToString();
    tmp.CNumTel = dr["CNumTel"].ToString();
    tmp.CMail = dr["CMail"].ToString();
    tmp.CCodePostal = int.Parse(dr["CCodePostal"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_TClient Lire_ID(int IDClient)
  {
   CreerCommande("SelectionnerTClient_ID");
   Commande.Parameters.AddWithValue("@IDClient", IDClient);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_TClient res = new C_TClient();
   while (dr.Read())
   {
    res.IDClient = int.Parse(dr["IDClient"].ToString());
    res.CNom = dr["CNom"].ToString();
    res.CPrenom = dr["CPrenom"].ToString();
    res.CNumTel = dr["CNumTel"].ToString();
    res.CMail = dr["CMail"].ToString();
    res.CCodePostal = int.Parse(dr["CCodePostal"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IDClient)
  {
   CreerCommande("SupprimerTClient");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDClient", IDClient);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
