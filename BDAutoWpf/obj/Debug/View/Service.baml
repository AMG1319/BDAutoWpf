   M S B A M L   `   `   `  ����D  @BDAutoWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:BDAutoWpf.ViewBDAutoWpf.View  5   	       BDAutoWpf.View.Service   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:BDAutoWpf.View     5   	     � Title$  Service��5   
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
��Auto �6     5      �� 5      $
��Auto �6#   �� 5      $	��58* �6#   .+�5      �� -   5        $	��tID��5      $��Identifiant��6#   $��Center=�66   $	��0,4q�6Q   �� 5      -   5        $
��tbID��5      $��1��6"   $��
3,3,45.8,3q�62   {�.  ��5       �� $ UnService.ID�$ TwoWay=�6=   �� 5"      -   5        $
��tNom��5"      $	��Nom��6$   $��1��6/   $��Center=�6<   $	��0,4q�6W   �� 5#      -   5        $��tbNom��5#      $��1��6#   $��1��60   $��
3,3,45.8,3q�6@   ��5$      �� $ UnService.Nom�$ TwoWay=��� 5&      -   5        $	��tPr��5&      $
��Prix��6#   $��2��6/   $��Center=�6<   $	��0,4q�6W   �� 5'      -   5        $��tbPrix��5'      $��2��6$   $��1��61   $��
3,3,45.8,3q�6A   ��5(      �� $ UnService.Prix�$ TwoWay=�5*      �� 5+   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Center=�6;   $��89,2.667,89,3q�6X   .+�5,      �� -   5        $��
bConfirmer��5,      $��	Confirmer��6'   $��3q�6;   {�6F   �� $ ActiverUneFiche�$ OneWay=���5-      �� *
cConfirmer+�� 5.      -	   5        $��bAnnuler��5.      $��Annuler��6%   $��3q�67   {�6B   �� $ ActiverUneFiche�$ OneWay=���5/      �� *
cAnnuler+50      &   System.Windows.Controls.DataGrid  51   
   -
   5        $��
dgServices��51      $��2��6N   "   VerticalScrollBarVisibility$ Visible=�6[      
IsReadOnly .    AutoGenerateColumns .  $��0,0,0,0.333q�53   u   ��51   %   �� $ BcpServices�{�52   ;   �� $ ActiverBcpFiche�$ OneWay=�	 �� SelectedItem	 53      �� *ServiceSelectionnee+$ TwoWay=�
   Columns
 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $ 	IDService�  56         Header$	 Nom��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6P    62   �� $
 SNom�6P     57      $
 Prix��6%   $ * 6R    63   �� $ SPrix�6R   59      �� 5:   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   $��32,2.667,32,3q�6X   .+�5;      �� -   5        $��bAjouter��5;      $��Ajouter��6%   $��3q�67   {�6B   �� $ ActiverBcpFiche�$ OneWay=���5<      �� *
cAjouter+�� 5=      -   5        $��	bModifier��5=      $��Modifier��6&   $��3q�69   {�6D   �� $ ActiverBcpFiche�$ OneWay=���5>      �� *	cModifier+�� 5?      -   5        $��
bSupprimer��5?      $��	Supprimer��6'   $��3q�6;   {�6F   �� $ ActiverBcpFiche�$ OneWay=���5@      �� *
cSupprimer+5A      5B      5C      