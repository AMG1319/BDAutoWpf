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
 public class C_TTransaction
 {
  #region Données membres
  private int _IDTransaction;
  private int _IDClient;
  private int _IDVoiture;
  private string _TType;
  private decimal _TPrix;
  private DateTime _TDate;
  #endregion
  #region Constructeurs
  public C_TTransaction()
  { }
  public C_TTransaction(int IDClient_, int IDVoiture_, string TType_, decimal TPrix_, DateTime TDate_)
  {
   IDClient = IDClient_;
   IDVoiture = IDVoiture_;
   TType = TType_;
   TPrix = TPrix_;
   TDate = TDate_;
  }
  public C_TTransaction(int IDTransaction_, int IDClient_, int IDVoiture_, string TType_, decimal TPrix_, DateTime TDate_)
   : this(IDClient_, IDVoiture_, TType_, TPrix_, TDate_)
  {
   IDTransaction = IDTransaction_;
  }
  #endregion
  #region Accesseurs
  public int IDTransaction
  {
   get { return _IDTransaction; }
   set { _IDTransaction = value; }
  }
  public int IDClient
  {
   get { return _IDClient; }
   set { _IDClient = value; }
  }
  public int IDVoiture
  {
   get { return _IDVoiture; }
   set { _IDVoiture = value; }
  }
  public string TType
  {
   get { return _TType; }
   set { _TType = value; }
  }
  public decimal TPrix
  {
   get { return _TPrix; }
   set { _TPrix = value; }
  }
  public DateTime TDate
  {
   get { return _TDate; }
   set { _TDate = value; }
  }
  #endregion
 }
}
