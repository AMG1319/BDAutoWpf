   M S B A M L   `   `   `  ����D  @BDAutoWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BDAutoWpf.ViewBDAutoWpf.View  5   	       BDAutoWpf.View.Prestation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BDAutoWpf.View     5   	   -   5          � Title$  
Prestation��5   	   $	��450��6   $	��600��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5        $��UneFiche��5      $��0,0,0,0.333q�5      {�5      ��  �� Path$ ActiverUneFiche� �� Mode$ OneWay=� 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     5      �� 5      $
��Auto �6#   �� 5      $	��58* �6#   .+�5       �� -   5        $	��tID��5       $��Identifiant��6#   $��Center=�66   $	��0,4q�6Q   �� 5!      -   5        $
��tbID��5!      $��1��6"   $��
3,3,45.8,3q�62   {�.  ��5"      �� $ UnePrestation.ID�$ TwoWay=�6A   �� 5$      -   5        $
��tNom��5$      $��Identifiant Transaction��6$   $��1��6C   $��Center=�6P   $	��0,4q�6k   �� 5%      -   5        $��cbIDT��5%      $��
3,3,45.8,3q�6$   $��1��68   $��1��6E    �� SelectedValue 6U   �� $ UnePrestation.IDT�$ TwoWay=��� 5'      -   5        $	��tPr��5'      $��Identifiant Service��6#   $��2��6>   $��Center=�6K   $	��0,4q�6f   �� 5(      -   5        $��cbIDS��5(      $��
3,3,45.8,3q�6$   $��2��68   $��1��6E    6U   �� $ UnePrestation.Service�$ TwoWay=��� 5+      -	   5        $	��tNo��5+      $��Nombre D'heures��6#   $��3��6:   $��Center=�6G   $	��0,4q�6b   �� 5,      -
   5        $��	tbNbHeure��5,      $��3��6'   $��1��64   $��
3,3,45.8,3q�6D   ��5-      �� $ UnePrestation.NbHeure�$ TwoWay=��� 5/      -   5        $��tN��5/      $
��Prix��6"   $��4��6.   $��Center=�6;   $	��0,4q�6V   �� 50      -   5        $��tbPrix��50      $��4��6$   $��1��61   $��
3,3,45.8,3q�6A   ��51      �� $ UnePrestation.Prix�$ TwoWay=�53      �� 54   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��89,2.667,89,3q�6X   .+�55      �� -   5        $��
bConfirmer��55      $��	Confirmer��6'   $��3q�6;   {�6F   �� $ ActiverUneFiche�$ OneWay=���56      �� *
cConfirmer+�� 57      -   5        $��bAnnuler��57      $��Annuler��6%   $��3q�67   {�6B   �� $ ActiverUneFiche�$ OneWay=���58      �� *
cAnnuler+59      &   System.Windows.Controls.DataGrid  5:   
   -   5        $��dgPrestations��5:      $��2��6T   "   VerticalScrollBarVisibility$ Visible=�6a      
IsReadOnly . 	   AutoGenerateColumns	 .  $��0,0,0,0.333q�5<   |   ��5:   (   �� $ BcpPrestations�{�5;   ;   �� $ ActiverBcpFiche�$ OneWay=�
 �� SelectedItem
 5<      �� *PrestationSelectionnee+$ TwoWay=�   Columns 5=      0  *System.Windows.Controls.DataGridTextColumn  5>      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ IDPrestation�  5?         Header$ Identifiant Transaction��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6m    6F   �� $ IDTransaction�6m     5@      $ Identifiant Service��6%   $ * 6e    6B   �� $ 	IDService�6e     5A      $ Nombre d'heure��6%   $ * 6_    6=   �� $ PNbHeure�6_     5B      $
 Prix��6%   $ * 6U    63   �� $ PPrixTot�6U   5D      �� 5E   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��32,2.667,32,3q�6X   .+�5F      �� -   5        $��bAjouter��5F      $��Ajouter��6%   $��3q�67   {�6B   �� $ ActiverBcpFiche�$ OneWay=���5G      �� *
cAjouter+�� 5H      -   5        $��	bModifier��5H      $��Modifier��6&   $��3q�69   {�6D   �� $ ActiverBcpFiche�$ OneWay=���5I      �� *	cModifier+�� 5J      -   5        $��
bSupprimer��5J      $��	Supprimer��6'   $��3q�6;   {�6F   �� $ ActiverBcpFiche�$ OneWay=���5K      �� *
cSupprimer+5L      5M      5N      