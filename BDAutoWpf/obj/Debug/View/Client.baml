   M S B A M L   `   `   `  ����D  @BDAutoWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BDAutoWpf.ViewBDAutoWpf.View  5   	       BDAutoWpf.View.Client   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BDAutoWpf.View     5   	     � Title$  Client��5   	   $	��450��6   $	��600��6%   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5        $��UneFiche��5      $��0,0,0,0.333q�5      {�5      ��  �� Path$ ActiverUneFiche� �� Mode$ OneWay=� 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     5      �� 5      $
��Auto �6#   �� 5      $	��58* �6#   .+�5!      �� -   5        $	��tID��5!      $��Identifiant��6#   $��Center=�66   $	��0,4q�6Q   �� 5"      -   5        $
��tbID��5"      $��1��6"   $��
3,3,45.8,3q�62   {�.  ��5#      �� $ UnClient.ID�$ TwoWay=�6<   �� 5%      -   5        $
��tNom��5%      $	��Nom��6$   $��1��6/   $��Center=�6<   $	��0,4q�6W   �� 5&      -   5        $��tbNom��5&      $��1��6#   $��1��60   $��
3,3,45.8,3q�6@   ��5'      �� $ UnClient.Nom�$ TwoWay=��� 5)      -   5        $	��tPr��5)      $��Prénom��6#   $��2��61   $��Center=�6>   $	��0,4q�6Y   �� 5*      -   5        $��tbPrenom��5*      $��2��6&   $��1��63   $��
3,3,45.8,3q�6C   ��5+      �� $ UnClient.Prenom�$ TwoWay=��� 5-      -   5        $	��tNo��5-      $��Num.Téléphone��6#   $��3��68   $��Center=�6E   $	��0,4q�6`   �� 5.      -	   5        $��tbNumTel��5.      $��3��6&   $��1��63   $��
3,3,45.8,3q�6C   ��5/      �� $ UnClient.NumTel�$ TwoWay=��� 51      -
   5        $��tN��51      $��Email��6"   $��4��6/   $��Center=�6<   $	��0,4q�6W   �� 52      -   5        $��tbMail��52      $��4��6$   $��1��61   $��
3,3,45.8,3q�6A   ��53      �� $ UnClient.Mail�$ TwoWay=��� 55      -   5        $��t��55      $��Code Postal��6!   $��5��64   $��Center=�6A   $	��0,4q�6\   �� 56      -   5        $��tbCodePostal��56      $��5��6*   $��1��67   $��
3,3,45.8,3q�6G   ��57      �� $ UnClient.CodePostal�$ TwoWay=�59      �� 5:   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��89,2.667,89,3q�6X   .+�5;      �� -   5        $��
bConfirmer��5;      $��	Confirmer��6'   $��3q�6;   {�6F   �� $ ActiverUneFiche�$ OneWay=���5<      �� *
cConfirmer+�� 5=      -   5        $��bAnnuler��5=      $��Annuler��6%   $��3q�67   {�6B   �� $ ActiverUneFiche�$ OneWay=���5>      �� *
cAnnuler+5?      &   System.Windows.Controls.DataGrid  5@   
   -   5        $��	dgClients��5@      $��2��6L   "   VerticalScrollBarVisibility$ Visible=�6Y      
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,0.333q�5B   t   ��5@   $   �� $ 
BcpClients�{�5A   ;   �� $ ActiverBcpFiche�$ OneWay=�	 �� SelectedItem	 5B      �� *ClientSelectionnee+$ TwoWay=�
   Columns
 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ IDClient�  5E         Header$	 Nom��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P    62   �� $
 CNom�6P     5F      $ Prénom��6%   $ * 6V    65   �� $ CPrenom�6V     5G      $ Num.Tél��6%   $ * 6W    66   �� $ CNumTel�6W     5H      $ Email��6%   $ * 6S    64   �� $ CMail�6S     5I      $ Code Postal��6%   $ * 6_    6:   �� $ CCodePostal�6_   5K      �� 5L   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��32,2.667,32,3q�6X   .+�5M      �� -   5        $��bAjouter��5M      $��Ajouter��6%   $��3q�67   {�6B   �� $ ActiverBcpFiche�$ OneWay=���5N      �� *
cAjouter+�� 5O      -   5        $��	bModifier��5O      $��Modifier��6&   $��3q�69   {�6D   �� $ ActiverBcpFiche�$ OneWay=���5P      �� *	cModifier+�� 5Q      -   5        $��
bSupprimer��5Q      $��	Supprimer��6'   $��3q�6;   {�6F   �� $ ActiverBcpFiche�$ OneWay=���5R      �� *
cSupprimer+5S      5T      5U      