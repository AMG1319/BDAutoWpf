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
 public class C_TDesidrata
 {
  #region Données membres
  private int _IDDesidrata;
  private int _IDClient;
  private string _DMarque;
  private string _DModel;
  private decimal? _DAnneeMin;
  private decimal? _DAnneeMax;
  private decimal? _DKmMin;
  private decimal? _DKmMax;
  private string _DCouleur;
  private decimal? _DPrixMin;
  private decimal? _DPrixMax;
  #endregion
  #region Constructeurs
  public C_TDesidrata()
  { }
  public C_TDesidrata(int IDClient_, string DMarque_, string DModel_, decimal? DAnneeMin_, decimal? DAnneeMax_, decimal? DKmMin_, decimal? DKmMax_, string DCouleur_, decimal? DPrixMin_, decimal? DPrixMax_)
  {
   IDClient = IDClient_;
   DMarque = DMarque_;
   DModel = DModel_;
   DAnneeMin = DAnneeMin_;
   DAnneeMax = DAnneeMax_;
   DKmMin = DKmMin_;
   DKmMax = DKmMax_;
   DCouleur = DCouleur_;
   DPrixMin = DPrixMin_;
   DPrixMax = DPrixMax_;
  }
  public C_TDesidrata(int IDDesidrata_, int IDClient_, string DMarque_, string DModel_, decimal? DAnneeMin_, decimal? DAnneeMax_, decimal? DKmMin_, decimal? DKmMax_, string DCouleur_, decimal? DPrixMin_, decimal? DPrixMax_)
   : this(IDClient_, DMarque_, DModel_, DAnneeMin_, DAnneeMax_, DKmMin_, DKmMax_, DCouleur_, DPrixMin_, DPrixMax_)
  {
   IDDesidrata = IDDesidrata_;
  }
  #endregion
  #region Accesseurs
  public int IDDesidrata
  {
   get { return _IDDesidrata; }
   set { _IDDesidrata = value; }
  }
  public int IDClient
  {
   get { return _IDClient; }
   set { _IDClient = value; }
  }
  public string DMarque
  {
   get { return _DMarque; }
   set { _DMarque = value; }
  }
  public string DModel
  {
   get { return _DModel; }
   set { _DModel = value; }
  }
  public decimal? DAnneeMin
  {
   get { return _DAnneeMin; }
   set { _DAnneeMin = value; }
  }
  public decimal? DAnneeMax
  {
   get { return _DAnneeMax; }
   set { _DAnneeMax = value; }
  }
  public decimal? DKmMin
  {
   get { return _DKmMin; }
   set { _DKmMin = value; }
  }
  public decimal? DKmMax
  {
   get { return _DKmMax; }
   set { _DKmMax = value; }
  }
  public string DCouleur
  {
   get { return _DCouleur; }
   set { _DCouleur = value; }
  }
  public decimal? DPrixMin
  {
   get { return _DPrixMin; }
   set { _DPrixMin = value; }
  }
  public decimal? DPrixMax
  {
   get { return _DPrixMax; }
   set { _DPrixMax = value; }
  }
  #endregion
 }
}
