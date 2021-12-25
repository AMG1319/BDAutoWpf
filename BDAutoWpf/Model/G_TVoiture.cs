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
 public class G_TVoiture : G_Base
 {
  #region Constructeurs
  public G_TVoiture()
   : base()
  { }
  public G_TVoiture(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(string VMarque, string VModel, decimal VAnnee, decimal VKilometrage, string VCouleur, decimal VPrix)
  { return new A_TVoiture(ChaineConnexion).Ajouter(VMarque, VModel, VAnnee, VKilometrage, VCouleur, VPrix); }
  public int Modifier(int IDVoiture, string VMarque, string VModel, decimal VAnnee, decimal VKilometrage, string VCouleur, decimal VPrix)
  { return new A_TVoiture(ChaineConnexion).Modifier(IDVoiture, VMarque, VModel, VAnnee, VKilometrage, VCouleur, VPrix); }
  public List<C_TVoiture> Lire(string Index)
  { return new A_TVoiture(ChaineConnexion).Lire(Index); }
  public C_TVoiture Lire_ID(int IDVoiture)
  { return new A_TVoiture(ChaineConnexion).Lire_ID(IDVoiture); }
  public int Supprimer(int IDVoiture)
  { return new A_TVoiture(ChaineConnexion).Supprimer(IDVoiture); }
 }
}
