   M S B A M L   `   `   `  ����D  @BDAutoWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BDAutoWpf.ViewBDAutoWpf.View  5   	       BDAutoWpf.View.Voiture   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BDAutoWpf.View     5   	     � Title$  Voiture��5   
   $	��450��6   $	��600��6'   .��5	      �  � ColumnDefinitions 5
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
��Auto �6    �� 5      $
��Auto �6     5      �� 5      $
��Auto �6#   �� 5       $	��58* �6#   .+�5"      �� -   5        $	��tID��5"      $��Identifiant��6#   $��Center=�66   $	��0,4q�6Q   �� 5#      -   5        $
��tbID��5#      $��1��6"   $��
3,3,45.8,3q�62   {�.  ��5$      �� $ UneVoiture.ID�$ TwoWay=�6>   �� 5&      -   5        $
��tPre��5&      $��Marque��6$   $��1��62   $��Center=�6?   $	��0,4q�6Z   �� 5'      -   5        $��tbMarque��5'      $��1��6&   $��1��63   $��
3,3,45.8,3q�6C   ��5(      �� $ UneVoiture.Marque�$ TwoWay=��� 5*      -   5        $
��tNom��5*      $��Model��6$   $��2��61   $��Center=�6>   $	��0,4q�6Y   �� 5+      -   5        $��tbModel��5+      $��2��6%   $��1��62   $��
3,3,45.8,3q�6B   ��5,      �� $ UneVoiture.Model�$ TwoWay=��� 5.      -   5        $	��tNo��5.      $��Annee��6#   $��3��60   $��Center=�6=   $	��0,4q�6X   �� 5/      -	   5        $��tbAnnee��5/      $��3��6%   $��1��62   $��
3,3,45.8,3q�6B   ��50      �� $ UneVoiture.Annee�$ TwoWay=��� 52      -
   5        $��tN��52      $��Kilometrage��6"   $��4��65   $��Center=�6B   $	��0,4q�6]   �� 53      -   5        $
��tbKm��53      $��4��6"   $��1��6/   $��
3,3,45.8,3q�6?   ��54      �� $ UneVoiture.Km�$ TwoWay=��� 56      -   5        $��t��56      $��Couleur��6!   $��5��60   $��Center=�6=   $	��0,4q�6X   �� 57      -   5        $��	tbCouleur��57      $��5��6'   $��1��64   $��
3,3,45.8,3q�6D   ��58      �� $ UneVoiture.Couleur�$ TwoWay=��� 5:      -   5        $��to��5:      $
��Prix��6"   $��6��6.   $��Center=�6;   $	��0,4q�6V   �� 5;      -   5        $��tbPrix��5;      $��6��6$   $��1��61   $��
3,3,45.8,3q�6A   ��5<      �� $ UneVoiture.Prix�$ TwoWay=�5>      �� 5?   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��89,2.667,89,3q�6X   .+�5@      �� -   5        $��
bConfirmer��5@      $��	Confirmer��6'   $��3q�6;   {�6F   �� $ ActiverUneFiche�$ OneWay=���5A      �� *
cConfirmer+�� 5B      -   5        $��bAnnuler��5B      $��Annuler��6%   $��3q�67   {�6B   �� $ ActiverUneFiche�$ OneWay=���5C      �� *
cAnnuler+5D      &   System.Windows.Controls.DataGrid  5E   
   -   5        $��
dgVoitures��5E      $��2��6N   "   VerticalScrollBarVisibility$ Visible=�6[      
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,0.333q�5G   v   ��5E   %   �� $ BcpVoitures�{�5F   ;   �� $ ActiverBcpFiche�$ OneWay=�	 �� SelectedItem	 5G      �� *VoitureSelectionnee+$ TwoWay=�
   Columns
 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ 	IDVoiture�  5J         Header$ Marque��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V    65   �� $ VMarque�6V     5K      $ Model��6%   $ * 6T    64   �� $ VModel�6T     5L      $ Annee��6%   $ * 6T    64   �� $ VAnnee�6T     5M      $ Km��6%   $ * 6W    61   �� $ VKilometrage�6W     5N      $ Couleur��6%   $ * 6X    66   �� $ VCouleur�6X     5O      $
 Prix��6%   $ * 6R    63   �� $ VPrix�6R   5Q      �� 5R   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��32,2.667,32,3q�6X   .+�5S      �� -   5        $��bAjouter��5S      $��Ajouter��6%   $��3q�67   {�6B   �� $ ActiverBcpFiche�$ OneWay=���5T      �� *
cAjouter+�� 5U      -   5        $��	bModifier��5U      $��Modifier��6&   $��3q�69   {�6D   �� $ ActiverBcpFiche�$ OneWay=���5V      �� *	cModifier+�� 5W      -   5        $��
bSupprimer��5W      $��	Supprimer��6'   $��3q�6;   {�6F   �� $ ActiverBcpFiche�$ OneWay=���5X      �� *
cSupprimer+5Z      5\      5]      