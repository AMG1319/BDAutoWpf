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
 public class C_TVoiture
 {
  #region Données membres
  private int _IDVoiture;
  private string _VMarque;
  private string _VModel;
  private decimal _VAnnee;
  private decimal _VKilometrage;
  private string _VCouleur;
  private decimal _VPrix;
  #endregion
  #region Constructeurs
  public C_TVoiture()
  { }
  public C_TVoiture(string VMarque_, string VModel_, decimal VAnnee_, decimal VKilometrage_, string VCouleur_, decimal VPrix_)
  {
   VMarque = VMarque_;
   VModel = VModel_;
   VAnnee = VAnnee_;
   VKilometrage = VKilometrage_;
   VCouleur = VCouleur_;
   VPrix = VPrix_;
  }
  public C_TVoiture(int IDVoiture_, string VMarque_, string VModel_, decimal VAnnee_, decimal VKilometrage_, string VCouleur_, decimal VPrix_)
   : this(VMarque_, VModel_, VAnnee_, VKilometrage_, VCouleur_, VPrix_)
  {
   IDVoiture = IDVoiture_;
  }
  #endregion
  #region Accesseurs
  public int IDVoiture
  {
   get { return _IDVoiture; }
   set { _IDVoiture = value; }
  }
  public string VMarque
  {
   get { return _VMarque; }
   set { _VMarque = value; }
  }
  public string VModel
  {
   get { return _VModel; }
   set { _VModel = value; }
  }
  public decimal VAnnee
  {
   get { return _VAnnee; }
   set { _VAnnee = value; }
  }
  public decimal VKilometrage
  {
   get { return _VKilometrage; }
   set { _VKilometrage = value; }
  }
  public string VCouleur
  {
   get { return _VCouleur; }
   set { _VCouleur = value; }
  }
  public decimal VPrix
  {
   get { return _VPrix; }
   set { _VPrix = value; }
  }
  #endregion
 }
}
