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
 public class G_TService : G_Base
 {
  #region Constructeurs
  public G_TService()
   : base()
  { }
  public G_TService(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string SNom, double SPrix)
  { return new A_TService(ChaineConnexion).Ajouter(SNom, SPrix); }
  public int Modifier(int IDService, string SNom, double SPrix)
  { return new A_TService(ChaineConnexion).Modifier(IDService, SNom, SPrix); }
  public List<C_TService> Lire(string Index)
  { return new A_TService(ChaineConnexion).Lire(Index); }
  public C_TService Lire_ID(int IDService)
  { return new A_TService(ChaineConnexion).Lire_ID(IDService); }
  public int Supprimer(int IDService)
  { return new A_TService(ChaineConnexion).Supprimer(IDService); }
 }
}
