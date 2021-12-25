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
 public class C_TService
 {
  #region Données membres
  private int _IDService;
  private string _SNom;
  private string _SPrix;
  #endregion
  #region Constructeurs
  public C_TService()
  { }
  public C_TService(string SNom_, string SPrix_)
  {
   SNom = SNom_;
   SPrix = SPrix_;
  }
  public C_TService(int IDService_, string SNom_, string SPrix_)
   : this(SNom_, SPrix_)
  {
   IDService = IDService_;
  }
  #endregion
  #region Accesseurs
  public int IDService
  {
   get { return _IDService; }
   set { _IDService = value; }
  }
  public string SNom
  {
   get { return _SNom; }
   set { _SNom = value; }
  }
  public string SPrix
  {
   get { return _SPrix; }
   set { _SPrix = value; }
  }
  #endregion
 }
}
