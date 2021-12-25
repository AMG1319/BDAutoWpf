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
 public class A_TVoiture : ADBase
 {
  #region Constructeurs
  public A_TVoiture(string sChaineConnexion)
  	: base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string VMarque, string VModel, decimal VAnnee, decimal VKilometrage, string VCouleur, decimal VPrix)
  {
   CreerCommande("AjouterTVoiture");
   int res = 0;
   Commande.Parameters.Add("IDVoiture", SqlDbType.Int);
   Direction("IDVoiture", ParameterDirection.Output);
   Commande.Parameters.AddWithValue("@VMarque", VMarque);
   Commande.Parameters.AddWithValue("@VModel", VModel);
   Commande.Parameters.AddWithValue("@VAnnee", VAnnee);
   Commande.Parameters.AddWithValue("@VKilometrage", VKilometrage);
   Commande.Parameters.AddWithValue("@VCouleur", VCouleur);
   Commande.Parameters.AddWithValue("@VPrix", VPrix);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   res = int.Parse(LireParametre("IDVoiture"));
   Commande.Connection.Close();
   return res;
  }
  public int Modifier(int IDVoiture, string VMarque, string VModel, decimal VAnnee, decimal VKilometrage, string VCouleur, decimal VPrix)
  {
   CreerCommande("ModifierTVoiture");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDVoiture", IDVoiture);
   Commande.Parameters.AddWithValue("@VMarque", VMarque);
   Commande.Parameters.AddWithValue("@VModel", VModel);
   Commande.Parameters.AddWithValue("@VAnnee", VAnnee);
   Commande.Parameters.AddWithValue("@VKilometrage", VKilometrage);
   Commande.Parameters.AddWithValue("@VCouleur", VCouleur);
   Commande.Parameters.AddWithValue("@VPrix", VPrix);
   Commande.Connection.Open();
   Commande.ExecuteNonQuery();
   Commande.Connection.Close();
   return res;
  }
  public List<C_TVoiture> Lire(string Index)
  {
   CreerCommande("SelectionnerTVoiture");
   Commande.Parameters.AddWithValue("@Index", Index);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   List<C_TVoiture> res = new List<C_TVoiture>();
   while (dr.Read())
   {
    C_TVoiture tmp = new C_TVoiture();
    tmp.IDVoiture = int.Parse(dr["IDVoiture"].ToString());
    tmp.VMarque = dr["VMarque"].ToString();
    tmp.VModel = dr["VModel"].ToString();
    tmp.VAnnee = decimal.Parse(dr["VAnnee"].ToString());
    tmp.VKilometrage = decimal.Parse(dr["VKilometrage"].ToString());
    tmp.VCouleur = dr["VCouleur"].ToString();
    tmp.VPrix = decimal.Parse(dr["VPrix"].ToString());
    res.Add(tmp);
			}
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public C_TVoiture Lire_ID(int IDVoiture)
  {
   CreerCommande("SelectionnerTVoiture_ID");
   Commande.Parameters.AddWithValue("@IDVoiture", IDVoiture);
   Commande.Connection.Open();
   SqlDataReader dr = Commande.ExecuteReader();
   C_TVoiture res = new C_TVoiture();
   while (dr.Read())
   {
    res.IDVoiture = int.Parse(dr["IDVoiture"].ToString());
    res.VMarque = dr["VMarque"].ToString();
    res.VModel = dr["VModel"].ToString();
    res.VAnnee = decimal.Parse(dr["VAnnee"].ToString());
    res.VKilometrage = decimal.Parse(dr["VKilometrage"].ToString());
    res.VCouleur = dr["VCouleur"].ToString();
    res.VPrix = decimal.Parse(dr["VPrix"].ToString());
   }
			dr.Close();
			Commande.Connection.Close();
			return res;
		}
  public int Supprimer(int IDVoiture)
  {
   CreerCommande("SupprimerTVoiture");
   int res = 0;
   Commande.Parameters.AddWithValue("@IDVoiture", IDVoiture);
   Commande.Connection.Open();
   res = Commande.ExecuteNonQuery();
			Commande.Connection.Close();
			return res;
		}
 }
}
