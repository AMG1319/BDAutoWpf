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
 public class C_TClient
 {
  #region Données membres
  private int _IDClient;
  private string _CNom;
  private string _CPrenom;
  private string _CNumTel;
  private string _CMail;
  private int _CCodePostal;
  #endregion
  #region Constructeurs
  public C_TClient()
  { }
  public C_TClient(string CNom_, string CPrenom_, string CNumTel_, string CMail_, int CCodePostal_)
  {
   CNom = CNom_;
   CPrenom = CPrenom_;
   CNumTel = CNumTel_;
   CMail = CMail_;
   CCodePostal = CCodePostal_;
  }
  public C_TClient(int IDClient_, string CNom_, string CPrenom_, string CNumTel_, string CMail_, int CCodePostal_)
   : this(CNom_, CPrenom_, CNumTel_, CMail_, CCodePostal_)
  {
   IDClient = IDClient_;
  }
  #endregion
  #region Accesseurs
  public int IDClient
  {
   get { return _IDClient; }
   set { _IDClient = value; }
  }
  public string CNom
  {
   get { return _CNom; }
   set { _CNom = value; }
  }
  public string CPrenom
  {
   get { return _CPrenom; }
   set { _CPrenom = value; }
  }
  public string CNumTel
  {
   get { return _CNumTel; }
   set { _CNumTel = value; }
  }
  public string CMail
  {
   get { return _CMail; }
   set { _CMail = value; }
  }
  public int CCodePostal
  {
   get { return _CCodePostal; }
   set { _CCodePostal = value; }
  }
  #endregion
 }
}
