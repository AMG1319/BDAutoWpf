#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
using BDAutoWpf.Classes;
using BDAutoWpf.Acces;
#endregion

namespace BDAutoWpf.Gestion
{
 /// <summary>
 /// Couche intermédiaire de gestion (Business Layer)
 /// </summary>
 public class G_TClient : G_Base
 {
  #region Constructeurs
  public G_TClient()
   : base()
  { }
  public G_TClient(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string CNom, string CPrenom, string CNumTel, string CMail, int CCodePostal)
  { return new A_TClient(ChaineConnexion).Ajouter(CNom, CPrenom, CNumTel, CMail, CCodePostal); }
  public int Modifier(int IDClient, string CNom, string CPrenom, string CNumTel, string CMail, int CCodePostal)
  { return new A_TClient(ChaineConnexion).Modifier(IDClient, CNom, CPrenom, CNumTel, CMail, CCodePostal); }
  public List<C_TClient> Lire(string Index)
  { return new A_TClient(ChaineConnexion).Lire(Index); }
  public C_TClient Lire_ID(int IDClient)
  { return new A_TClient(ChaineConnexion).Lire_ID(IDClient); }
  public int Supprimer(int IDClient)
  { return new A_TClient(ChaineConnexion).Supprimer(IDClient); }
 }
}
