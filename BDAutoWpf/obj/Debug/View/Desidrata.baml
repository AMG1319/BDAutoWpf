   M S B A M L   `   `   `  ����D  @BDAutoWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BDAutoWpf.ViewBDAutoWpf.View  5   	       BDAutoWpf.View.Desidrata   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BDAutoWpf.View     5   	   -   5          � Title$  	Desidrata��5   	   $	��700��6   $	��600��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � -   5        $��UneFiche��5      $��0,0,6.6,0.6q�5      {�5      ��  �� Path$ ActiverUneFiche� �� Mode$ OneWay=� 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $
��Auto �6     5"      �� 5#      $
��Auto �6#   �� 5$      $	��58* �6#   .+�5&      �� -   5        $	��tID��5&      $��Identifiant��6#   $��Center=�66   $	��0,4q�6Q   �� 5'      -   5        $
��tbID��5'      $��1��6"   $��
3,3,45.8,3q�62   {�.  ��5(      �� $ UnDesidrata.ID�$ TwoWay=�6?   �� 5*      -   5        $
��tIDC��5*      $��Identifiant Client��6$   $��1��6>   $��Center=�6K   $	��0,4q�6f   �� 5+      -   5        $��cbIDC��5+      $��
3,3,45.8,3q�6$   $��1��68   $��1��6E    �� SelectedValue 6U   �� $ UnDesidrata.Client�$ TwoWay=��� 5.      -   5        $��tM��5.      $��Marque��6"   $��2��60   $��Center=�6=   $	��0,4q�6X   �� 5/      -   5        $��tbMarque��5/      $��2��6&   $��1��63   $��
3,3,45.8,3q�6C   ��50      �� $ UnDesidrata.Marque�$ TwoWay=��� 52      -	   5        $	��tMo��52      $��Model��6#   $��3��60   $��Center=�6=   $	��0,4q�6X   �� 53      -
   5        $��tbModel��53      $��3��6%   $��1��62   $��
3,3,45.8,3q�6B   ��54      �� $ UnDesidrata.Model�$ TwoWay=��� 56      -   5        $��tN��56      $��
Annee Min.��6"   $��4��64   $��Center=�6A   $	��0,4q�6\   �� 57      -   5        $��
tbAnneeMin��57      $��4��6(   $��1��65   $��
3,3,45.8,3q�6E   ��58      �� $ UnDesidrata.AnneeMin�$ TwoWay=��� 5:      -   5        $��t��5:      $��
Annee Max.��6!   $��5��63   $��Center=�6@   $	��0,4q�6[   �� 5;      -   5        $��
tbAnneeMax��5;      $��5��6(   $��1��65   $��
3,3,45.8,3q�6E   ��5<      �� $ UnDesidrata.AnneeMax�$ TwoWay=��� 5>      -   5        $��tk��5>      $��Kilomètrage Min.��6"   $��6��6:   $��Center=�6G   $	��0,4q�6b   �� 5?      -   5        $��tbKmMin��5?      $��6��6%   $��1��62   $��
3,3,45.8,3q�6B   ��5@      �� $ UnDesidrata.KmMin�$ TwoWay=��� 5B      -   5        $	��tkm��5B      $��Kilomètrage Max.��6#   $��7��6;   $��Center=�6H   $	��0,4q�6c   �� 5C      -   5        $��tbKmMax��5C      $��7��6%   $��1��62   $��
3,3,45.8,3q�6B   ��5D      �� $ UnDesidrata.KmMax�$ TwoWay=��� 5F      -   5        $��tc��5F      $��Couleur��6"   $��8��61   $��Center=�6>   $	��0,4q�6Y   �� 5G      -   5        $��	tbCouleur��5G      $��8��6'   $��1��64   $��
3,3,45.8,3q�6D   ��5H      �� $ UnDesidrata.Couleur�$ TwoWay=��� 5J      -   5        $��tprix��5J      $��	Prix Min.��6%   $��9��66   $��Center=�6C   $	��0,4q�6^   �� 5K      -   5        $��	tbPrixMin��5K      $��9��6'   $��1��64   $��
3,3,45.8,3q�6D   ��5L      �� $ UnDesidrata.PrixMin�$ TwoWay=��� 5N      -   5        $��tprixM��5N      $��	Prix Max.��6&   $��10��67   $��Center=�6E   $	��0,4q�6`   �� 5O      -   5        $��	tbPrixMax��5O      $��10��6'   $��1��65   $��
3,3,45.8,3q�6E   ��5P      �� $ UnDesidrata.PrixMax�$ TwoWay=�5S      �� 5T   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��238,2.4,241.6,2.8q�6X   $	��114��6s   .+�5U      �� -   5        $��
bConfirmer��5U      $��	Confirmer��6'   $��3q�6;   {�6F   �� $ ActiverUneFiche�$ OneWay=���5V      �� *
cConfirmer+�� 5W      -   5        $��bAnnuler��5W      $��Annuler��6%   $��3q�67   {�6B   �� $ ActiverUneFiche�$ OneWay=���5X      �� *
cAnnuler+5Y      &   System.Windows.Controls.DataGrid  5Z   
   -   5        $��dgDesidratas��5Z      $��2��6R   "   VerticalScrollBarVisibility$ Visible=�6_      
IsReadOnly . 	   AutoGenerateColumns	 .  $��0,0.2,6.6,0.4q�5\   z   ��5Z   '   �� $ BcpDesidratas�{�5[   ;   �� $ ActiverBcpFiche�$ OneWay=�
 �� SelectedItem
 5\      �� *DesidrataSelectionnee+$ TwoWay=�   Columns 5]      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ IDDesidrata�  5_         Header$ IDClient��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6Y    67   �� $ IDClient�6Y     5`      $ Marque��6%   $
 Auto 6V    65   �� $ DMarque�6V     5a      $ Model��6%   $
 Auto 6T    64   �� $ DModel�6T     5b      $ 
Annne Min.��6%   $ * 6\    69   �� $ 	DAnneeMin�6\     5c      $ 
Annne Max.��6%   $ * 6\    69   �� $ 	DAnneeMax�6\     5d      $ Km Min.��6%   $ * 6V    66   �� $ DKmMin�6V     5e      $ Km Max.��6%   $ * 6V    66   �� $ DKmMax�6V     5f      $ Couleur��6%   $ * 6X    66   �� $ DCouleur�6X     5g      $ 	Prix Min.��6%   $ * 6Z    68   �� $ DPrixMin�6Z     5h      $ 	Prix Max.��6%   $ * 6Z    68   �� $ DPrixMax�6Z   5j      �� 5k   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��208,2.6,215.6,3.4q�6X   $	��170��6s   .+�5l      �� -   5        $��bAjouter��5l      $��Ajouter��6%   $��3q�67   {�6B   �� $ ActiverBcpFiche�$ OneWay=���5m      �� *
cAjouter+�� 5n      -   5        $��	bModifier��5n      $��Modifier��6&   $��3q�69   {�6D   �� $ ActiverBcpFiche�$ OneWay=���5o      �� *	cModifier+�� 5p      -   5        $��
bSupprimer��5p      $��	Supprimer��6'   $��3q�6;   {�6F   �� $ ActiverBcpFiche�$ OneWay=���5q      �� *
cSupprimer+5s      5u      5v      