   M S B A M L   `   `   `  ����D  @BDAutoWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BDAutoWpf.ViewBDAutoWpf.View  5   	        BDAutoWpf.View.Transaction   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BDAutoWpf.View     5   	   -   5          � Title$  Transaction��5   	   $	��450��6   $	��600��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��373* �6   �� 5      $
��221* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5        $��UneFiche��5      $��0,0,-0.4,0.2q�5      $��2��6%   {�5      ��  �� Path$ ActiverUneFiche� �� Mode$ OneWay=� 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     5      �� 5      $
��Auto �6#   �� 5       $	��58* �6#   .+�5"      �� -   5        $	��tID��5"      $��Identifiant��6#   $��Center=�66   $	��0,4q�6Q   �� 5#      -   5        $
��tbID��5#      $��1��6"   $��
3,3,45.8,3q�62   {�.  ��5$      �� $ UneTransaction.ID�$ TwoWay=�6B   �� 5&      -   5        $
��tPre��5&      $��Identifiant Client��6$   $��1��6>   $��Center=�6K   $	��0,4q�6f   �� 5'      -   5        $��cbIDC��5'      $��
3,3,45.8,3q�6$   $��1��68   $��1��6E    �� SelectedValue 6U   �� $ UneTransaction.Client�$ TwoWay=��� 5)      -   5        $
��tNom��5)      $��Identifiant Voiture��6$   $��2��6?   $��Center=�6L   $	��0,4q�6g   �� 5*      -   5        $��cbIDV��5*      $��
3,3,45.8,3q�6$   $��2��68   $��1��6E    6U   �� $ UneTransaction.Voiture�$ TwoWay=��� 5,      -	   5        $	��tNo��5,      $��Type de transaction��6#   $��3��6>   $��Center=�6K   $	��0,4q�6f   �� 5-      -
   5        $��cbType��5-      $��
3,3,45.8,3q�6%   $��3��69   $��1��6F    6V   �� $ UneTransaction.Type�$ TwoWay=��� 50      -   5        $��tN��50      $
��Prix��6"   $��4��6.   $��Center=�6;   $	��0,4q�6V   �� 51      -   5        $��tbPrix��51      $��4��6$   $��1��61   $��
3,3,45.8,3q�6A   ��52      �� $ UneTransaction.Prix�$ TwoWay=��� 54      -   5        $��t��54      $
��Date��6!   $��5��6-   $��Center=�6:   $	��0,4q�6U   (  "System.Windows.Controls.DatePicker  55      -   5        $��dpNai��55      $��5��6&   $��1��63   $��
3,3,45.8,3q�6C      SelectedDate 56      �� $ UneTransaction.Dt�$ TwoWay=� �� StringFormat$ 
dd/mm/yyyy��58      �� 59   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��240,2.8,19,3.4q�6X   .+�5:      �� -   5        $��
bConfirmer��5:      $��	Confirmer��6'   $��3q�6;   {�6F   �� $ ActiverUneFiche�$ OneWay=���5;      �� *
cConfirmer+�� 5<      -   5        $��bAnnuler��5<      $��Annuler��6%   $��3q�67   {�6B   �� $ ActiverUneFiche�$ OneWay=���5=      �� *
cAnnuler+5>      &   System.Windows.Controls.DataGrid  5?   
   -   5        $��dgTransactions��5?      $��1��6V   "	   VerticalScrollBarVisibility$	 Visible=�6c   
   
IsReadOnly
 .    AutoGenerateColumns .  $��0,30.8,-0.4,0.8q�5A   ~   $��2��6�   $��2��6�   ��5?   )   �� $ BcpTransactions�{�5@   ;   �� $ ActiverBcpFiche�$ OneWay=� �� SelectedItem 5A      �� *TransactionSelectionnee+$ TwoWay=�   Columns 5B      0  *System.Windows.Controls.DataGridTextColumn  5C      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ IDTransaction�  5D         Header$ Identifiant Client��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6c    6A   �� $ IDClient�6c     5E      $ Identifiant Voiture��6%   $
 Auto 6e    6B   �� $ 	IDVoiture�6e     5F      $
 Type��6%   $
 Auto 6R    63   �� $ TType�6R     5G      $
 Prix��6%   $
 Auto 6R    63   �� $ TPrix�6R     5H      $
 Date��6%   $
 Auto 6R    63   �� $ TDate�6R   5J      �� 5K   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��206,2.4,124.6,3q�6X   $��2��6q   $	��263��6�   .+�5L      �� -   5        $��bAjouter��5L      $��Ajouter��6%   $��3q�67   {�6B   �� $ ActiverBcpFiche�$ OneWay=���5M      �� *
cAjouter+�� 5N      -   5        $��	bModifier��5N      $��Modifier��6&   $��3q�69   {�6D   �� $ ActiverBcpFiche�$ OneWay=���5O      �� *	cModifier+�� 5P      -   5        $��
bSupprimer��5P      $��	Supprimer��6'   $��3q�6;   {�6F   �� $ ActiverBcpFiche�$ OneWay=���5Q      �� *
cSupprimer+�� 5R      -   5        $��bFacture��5R      $��Facture��6%   $��	3,3,3,2.6q�67   $��60��5S   )   {�5R   J   �� $ ActiverBcpFiche�$ OneWay=���5S      �� *
cFacture+6)   5T      5U      5V      