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
 public class G_TTransaction : G_Base
 {
  #region Constructeurs
  public G_TTransaction()
   : base()
  { }
  public G_TTransaction(string sChaineConnexion)
   : base(sChaineConnexion)
  { }
  #endregion
  public int Ajouter(int IDClient, int IDVoiture, string TType, decimal TPrix, DateTime TDate)
  { return new A_TTransaction(ChaineConnexion).Ajouter(IDClient, IDVoiture, TType, TPrix, TDate); }
  public int Modifier(int IDTransaction, int IDClient, int IDVoiture, string TType, decimal TPrix, DateTime TDate)
  { return new A_TTransaction(ChaineConnexion).Modifier(IDTransaction, IDClient, IDVoiture, TType, TPrix, TDate); }
  public List<C_TTransaction> Lire(string Index)
  { return new A_TTransaction(ChaineConnexion).Lire(Index); }
  public C_TTransaction Lire_ID(int IDTransaction)
  { return new A_TTransaction(ChaineConnexion).Lire_ID(IDTransaction); }
  public int Supprimer(int IDTransaction)
  { return new A_TTransaction(ChaineConnexion).Supprimer(IDTransaction); }
 }
}
