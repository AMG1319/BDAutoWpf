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
 public class G_TPrestation : G_Base
 {
  #region Constructeurs
  public G_TPrestation()
   : base()
  { }
  public G_TPrestation(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int IDTransaction, int IDService, int PNbHeure, double PPrixTot)
  { return new A_TPrestation(ChaineConnexion).Ajouter(IDTransaction, IDService, PNbHeure, PPrixTot); }
  public int Modifier(int IDPrestation, int IDTransaction, int IDService, int PNbHeure, double PPrixTot)
  { return new A_TPrestation(ChaineConnexion).Modifier(IDPrestation, IDTransaction, IDService, PNbHeure, PPrixTot); }
  public List<C_TPrestation> Lire(string Index)
  { return new A_TPrestation(ChaineConnexion).Lire(Index); }
  public C_TPrestation Lire_ID(int IDPrestation)
  { return new A_TPrestation(ChaineConnexion).Lire_ID(IDPrestation); }
  public int Supprimer(int IDPrestation)
  { return new A_TPrestation(ChaineConnexion).Supprimer(IDPrestation); }
 }
}
