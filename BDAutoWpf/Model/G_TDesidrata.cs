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
 public class G_TDesidrata : G_Base
 {
  #region Constructeurs
  public G_TDesidrata()
   : base()
  { }
  public G_TDesidrata(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int IDClient, string DMarque, string DModel, decimal? DAnneeMin, decimal? DAnneeMax, decimal? DKmMin, decimal? DKmMax, string DCouleur, decimal? DPrixMin, decimal? DPrixMax)
  { return new A_TDesidrata(ChaineConnexion).Ajouter(IDClient, DMarque, DModel, DAnneeMin, DAnneeMax, DKmMin, DKmMax, DCouleur, DPrixMin, DPrixMax); }
  public int Modifier(int IDDesidrata, int IDClient, string DMarque, string DModel, decimal? DAnneeMin, decimal? DAnneeMax, decimal? DKmMin, decimal? DKmMax, string DCouleur, decimal? DPrixMin, decimal? DPrixMax)
  { return new A_TDesidrata(ChaineConnexion).Modifier(IDDesidrata, IDClient, DMarque, DModel, DAnneeMin, DAnneeMax, DKmMin, DKmMax, DCouleur, DPrixMin, DPrixMax); }
  public List<C_TDesidrata> Lire(string Index)
  { return new A_TDesidrata(ChaineConnexion).Lire(Index); }
  public C_TDesidrata Lire_ID(int IDDesidrata)
  { return new A_TDesidrata(ChaineConnexion).Lire_ID(IDDesidrata); }
  public int Supprimer(int IDDesidrata)
  { return new A_TDesidrata(ChaineConnexion).Supprimer(IDDesidrata); }
 }
}
