   M S B A M L   `   `   `  ����  VcsConnect_Client;    5VcsConnect_Client.Views.SupportViews.uc_ChemList_List   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,9q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $��60 �6+   68   �� 5      $��90 �6+   68   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   .+�5      �� -   5        $��	lblStatus��5      $��Status��6-   $��Center=�6>   $��1q�6b   $��Center=�5      $��0��6>   $��0��6N   
����  �$��1q�5      
���   �
�������$
��Bold"�6Z   6n   �� 5      -   5        $��cboChemActiveStatus��5      $��Center=�6:   $��1q�6^   $��Center=�5      $��1��6>   $��0��6N   
����  �$��1q�5       
���   �
�������$
��Bold"�6Z   .@�5!      �� .��6'   active6/   �� 5"      .��6'   
inactive61   5#      �� 5&      -   5        $��LabelBanner��5&      $��Chemical Listing��6/   $��1q�6J   $��Center=�5'      $��Center=�6@   $��2��5(      $��0��6,   
����  �$��1q�6P   
���   �
�������$
��Bold"�5)   F   6Z   5*       J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5.      �� 52      $	��Top=�6   $��	10,2,10,9q�6*   ._�53      � .+�54      &   System.Windows.Controls.DataGrid  -   5        $��ChemList_DataGrid��54         AutoGenerateColumns .   %� IsVirtualizing .  %� VirtualizationMode$ Standard=�56      	   EnableRowVirtualization	 . !
   EnableColumnVirtualization
 .  ��54   8   ��    Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
OBJECTID+   ClipboardContentBinding 6Z   Z�   5:      $ Chemical Code��6N    61   �� *
ChemCode+ 6e   Z�   5;      $ 
EPA Number��6L    61   �� *EPANum+ 6`   Z�   5<      $ Active Ingredients��6P    61   �� *
ActiveIngr+ 6l   Z�   5=      $ Manufacturer��6R    61   �� *Manufacturer+ 6h   Z�   5>      $ Retail Cost��6d    61   �� *retail+ �� StringFormat$ #,#0.00�� 6y   Z�   5?      $
 Cost��6b    61   �� *cost+$ #,#0.00�� 6p   Z�   5@      $ Comments��6M    61   �� *	Comment+ 6_   Z�   5A      $ Units��6K    61   �� *Units+ 6Z   Z�   5B      $ Status��6R    61   �� *activeStatus+ 6b   Z� 5D      5E      5F      5G      5H      5I      