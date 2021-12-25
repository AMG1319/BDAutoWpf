#region Ressources extérieures
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace BDAutoWpf.Classes
{
 /// <summary>
 /// Classe de définition des données
 /// </summary>
 public class C_TPrestation
 {
  #region Données membres
  private int _IDPrestation;
  private int _IDTransaction;
  private int _IDService;
  private int _PNbHeure;
  private double _PPrixTot;
  #endregion
  #region Constructeurs
  public C_TPrestation()
  { }
  public C_TPrestation(int IDTransaction_, int IDService_, int PNbHeure_, double PPrixTot_)
  {
   IDTransaction = IDTransaction_;
   IDService = IDService_;
   PNbHeure = PNbHeure_;
   PPrixTot = PPrixTot_;
  }
  public C_TPrestation(int IDPrestation_, int IDTransaction_, int IDService_, int PNbHeure_, double PPrixTot_)
   : this(IDTransaction_, IDService_, PNbHeure_, PPrixTot_)
  {
   IDPrestation = IDPrestation_;
  }
  #endregion
  #region Accesseurs
  public int IDPrestation
  {
   get { return _IDPrestation; }
   set { _IDPrestation = value; }
  }
  public int IDTransaction
  {
   get { return _IDTransaction; }
   set { _IDTransaction = value; }
  }
  public int IDService
  {
   get { return _IDService; }
   set { _IDService = value; }
  }
  public int PNbHeure
  {
   get { return _PNbHeure; }
   set { _PNbHeure = value; }
  }
  public double PPrixTot
  {
   get { return _PPrixTot; }
   set { _PPrixTot = value; }
  }
  #endregion
 }
}
