   M S B A M L   `   `   `  ����D  @BDAutoWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BDAutoWpf	BDAutoWpf  5   	       BDAutoWpf.TableauDeBord   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BDAutoWpf     5   	   -   5          � Title$  Tableau de bord��5   
   $	��500��6"   $	��800��6/   
���   �.��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��150 �6   �� 5      .+�5   
   � $��0��6   .+�5      �� $��Center=�6   .+�5      �� -   5        $��btnChiffreDaffaire��5      $��Chiffre d'affaire��63   $��5q�6O   6Z   �� 5      -   5        $��btnAfficherStock��5      $��Stock de voiture��61   $��5q�6L   6W   �� 5      -   5        $��btnAjouterPrestation��5      $��Nouvelle Prestation��65   $��5q�6S   6^   �� 5      -   5        $��btnAjouterTransaction��5      $��Nouvelle Transaction��66   $��5q�6U   6`   �� 5      -   5        $��btnAjouterVoiture��5      $��Nouvelle Auto��62   $��5q�6J   6U   �� 5      -   5        $��btnAjouterService��5      $��Nouveau Service��62   $��5q�6L   6W   �� 5      -   5        $��btnAjouterClient��5      $��Nouveau Client��61   $��5q�6J   6U   �� 5      -	   5        $��btnAjouterDesidrata��5      $��Nouveau Desidrata��64   $��5q�6P   6[   �� 5      -
   5        $��
btnQuitter��5      $��Quitter��6+   $��5q�6=   6H   5      5      � 5   
   $��1��6   .+�5      �� .@�5      �� $��Encoder Prestation��6   .��5      �  � RowDefinitions 5      �� 5       �� 5!      $��80 �6,   .+�5#      � $��0��6    5$      �� 5%   "   �� 5&   "   $	��200 �63   .+�5(      � $��0��6#   .+�5)   "   &   System.Windows.Controls.DataGrid  -   5        $��dgTransactions��5)   +   $��1��6n   "   VerticalScrollBarVisibility$ Visible=�6{      
IsReadOnly .    AutoGenerateColumns .  ��6A   ��  �� Path$ BcpTransactions�{�5*   S   �� $ ActiverBcpFiche� �� Mode$ OneWay=� �� SelectedItem 5+   %   �� *TransactionSelectionnee+$ TwoWay=�	   Columns	 5,   &   0  *System.Windows.Controls.DataGridTextColumn  5-   *   ,  &System.Windows.Controls.DataGridColumn
   
Visibility$
 Hidden=�6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� $ IDTransaction�  5.   *      Header$ Identifiant Client��6=      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6{    6Y   �� $ IDClient�6{     5/   *   $ Identifiant Voiture��6=   $
 Auto 6}    6Z   �� $ 	IDVoiture�6}     50   *   $
 Type��6=   $
 Auto 6j    6K   �� $ TType�6j     51   *   $
 Prix��6=   $
 Auto 6j    6K   �� $ TPrix�6j     52   *   $
 Date��6=   $
 Auto 6j    6K   �� $ TDate�6j    � 	Resources 54   &    �� Color��%�   (��       55   :   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(��      56   :   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)�� 55   *   $
 Blue��6}   �� 56   *   $ White��6�   57   '   58   #   59      � 5:      $��1��6#   .+�5;   "     -   5        $��
dgServices��5;   +   $ Visible=�6g    .  .  ��6=   �� $ BcpServices�{�5<   S   �� $ ActiverBcpFiche�$ OneWay=� 5=   &   �� *ServiceSelectionnee+$ TwoWay=�	 5>   &     5?   *   $
 Hidden=�6=    6Q   �� $ 	IDService�  5@   *   $	 Nom��6=   $ * 6h    6J   �� $
 SNom�6h     5A   *   $
 Prix��6=   $ * 6j    6K   �� $ SPrix�6j    5C   &   ��%�   (��       5D   :   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(��      5E   :   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)�� 5D   *   $
 Blue��6}   �� 5E   *   $ White��6�   5F   '   5G   #   5H      5I      � 5J      $��1��6    5K      �� 5L   "   �� 5M   "   .+�5O      � $��0��6#   .+�5P   "   �� -   5        $
��tNbH��5P   ,   $��Nombre d'heures prestées��68   $��Center=�6X   �� 5Q   "   -   5        $��	tbNbHeure��5Q   *   $��20��6;   $��154,10,343.667,10q�5R   L   ��6!   �� $ NbHeure�$ TwoWay=�6L   5S      � 5T      $��1��6#   .+�5U   "   �� -   5        $��bEncoderPresta��5U   )   $��Encoder une prestation��6?   $��3q�6`   ��5V   !   �� *cEncoderPresta+5W      5X      5Y      5Z      �� 5[      $��Encoder Transaction��6   .��5\      �  5]      �� 5^      �� 5_      $��80 �6,   .+�5a      � $��0��6    5b      �� 5c   "   �� 5d   "   .+�5f      � $��0��6#   .+�5g   "     -   5        $��	dgClients��5g   +   $��2��6d   $ Visible=�6q    .  .  $��0,0,0,0.333q�5i   �   ��5g   <   �� $ 
BcpClients�{�5h   W   �� $ ActiverBcpFiche�$ OneWay=� 5i   *   �� *ClientSelectionnee+$ TwoWay=�	 5j   &     5k   *   $
 Hidden=�6=    6Q   �� $ IDClient�  5l   *   $	 Nom��6=   $ * 6h    6J   �� $
 CNom�6h     5m   *   $ Prénom��6=   $ * 6n    6M   �� $ CPrenom�6n     5n   *   $ Num.Tél��6=   $ * 6o    6N   �� $ CNumTel�6o     5o   *   $ Email��6=   $ * 6k    6L   �� $ CMail�6k     5p   *   $ Code Postal��6=   $ * 6w    6R   �� $ CCodePostal�6w    5r   &   ��%�   (��       5s   :   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(��      5t   :   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)�� 5s   *   $
 Blue��6}   �� 5t   *   $ White��6�   5u   '   5v   #   5w      � 5x      $��1��6#   .+�5y   "     -   5        $��
dgVoitures��5y   +   $��2��6f   $ Visible=�6s    .  .  $��0,0,0,0.333q�5{   �   ��5y   =   �� $ BcpVoitures�{�5z   S   �� $ ActiverBcpFiche�$ OneWay=� 5{   %   �� *VoitureSelectionnee+$ TwoWay=�	 5|   &     5}   *   $
 Hidden=�6=    6Q   �� $ 	IDVoiture�  5~   *   $ Marque��6=   $ * 6n    6M   �� $ VMarque�6n     5   *   $ Model��6=   $ * 6l    6L   �� $ VModel�6l     5�   *   $ Annee��6=   $ * 6l    6L   �� $ VAnnee�6l     5�   *   $ Km��6=   $ * 6o    6I   �� $ VKilometrage�6o     5�   *   $ Couleur��6=   $ * 6p    6N   �� $ VCouleur�6p     5�   *   $
 Prix��6=   $ * 6j    6K   �� $ VPrix�6j    5�   &   ��%�   (��       5�   :   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(��      5�   :   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)�� 5�   *   $
 Blue��6}   �� 5�   *   $ White��6�   5�   '   5�   #   5�      5�      � 5�      $��1��6    5�      �� 5�   "   �� 5�   "   .+�5�      � $��0��6#   .+�5�   "   �� -   5        $	��tNo��5�   ,   $��Type de transaction��67   $��Center=�6S   $��18��6n   $��0,12,527.667,10q�6z   �� 5�   "   -   5        $��cbType��5�   +   $��109,12,436.667,10q�6l    �� SelectedValue 6:   �� $ TypeT�$ TwoWay=�6l   �� 5�   "   -   5        $��tN��5�   ,   $
��Prix��66   $��Center=�6B   $��16��6]   $��247,14,354.667,10q�6i   �� 5�   "   -   5        $��tbPrix��5�   *   $��282,14,250.667,10q�6`   ��68   �� $
 Prix�$ TwoWay=�6`   �� 5�   "   -   5        $��t��5�   ,   $
��Date��65   $��Center=�6A   $��16��6\   $��434,14,151.667,10q�6h   (  "System.Windows.Controls.DatePicker  5�   "   -   5        $��dpNai��5�   -   $��485,11,48.667,6q�6�      SelectedDate 6;   �� $ Dt�$ TwoWay=� �� StringFormat$ 
dd/mm/yyyy��6�   5�      � 5�      $��1��6#   .+�5�   "   �� -   5        $��bEncoderTransac��5�   )   $��Encoder une Transaction��6@   $��3q�6b   ��5�   !   �� *cEncoderTransac+5�      5�      5�      5�      �� 5�      $0��*Client intéréssé par un véhicule dispo��6   .��5�      �  5�      �� 5�      �� 5�      $��40 �6,   .+�5�      � $��0��6    5�      �� 5�   "   �� 5�   "   .+�5�      � $��1��6#   .+�5�   "     -   5        $��dgVtr��5�   +   $ Visible=�6\    .  .     SelectionMode$ Extended=�5�   O   ��5�   8   �� $ BcpVtr�	 5�   &     5�   *   $
 Hidden=�6=    6Q   �� $ 	IDVoiture�  5�   *   $ Marque��6=   $ * 6n    6M   �� $ VMarque�6n     5�   *   $ Model��6=   $ * 6l    6L   �� $ VModel�6l     5�   *   $ Annee��6=   $ * 6l    6L   �� $ VAnnee�6l     5�   *   $ Km��6=   $ * 6o    6I   �� $ VKilometrage�6o     5�   *   $ Couleur��6=   $ * 6p    6N   �� $ VCouleur�6p     5�   *   $
 Prix��6=   $ * 6j    6K   �� $ VPrix�6j    5�   &   ��%�   (��       5�   :   *1/SystemColors.InactiveSelectionHighlightBrushKey+)(��      5�   :   *53SystemColors.InactiveSelectionHighlightTextBrushKey+)�� 5�   *   $
 Blue��6}   �� 5�   *   $ White��6�   5�   '   5�   #   5�      � 5�      $��0��6#   .+�5�   "     -   5        $
��dgCl��5�   +   $ Visible=�6[    .  .  ��67   �� $ BcpCl� 5�   S   �� *ClSelectionnee+$ TwoWay=�	 5�   &     5�   *   $
 Hidden=�6=    6Q   �� $ IDClient�  5�   *   $	 Nom��6=   $ * 6h    6J   �� $
 CNom�6h     5�   *   $ Prénom��6=   $ * 6n    6M   �� $ CPrenom�6n     5�   *   $ Num.Tél��6=   $ * 6o    6N   �� $ CNumTel�6o     5�   *   $ Email��6=   $ * 6k    6L   �� $ CMail�6k     5�   *   $ Code Postal��6=   $ * 6w    6R   �� $ CCodePostal�6w   5�   #   5�      5�      � 5�      $��1��6   .+�5�      �� -   5        $��bEnvoyerMail��5�   %   $,��&Envoyer un mail au client selectionné��69   $��3q�6i   ��5�   !   �� *cEnvoyerMail+5�      5�      5�      5�      5�      5�      5�      