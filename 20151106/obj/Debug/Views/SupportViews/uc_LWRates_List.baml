   M S B A M L   `   `   `  ����  VcsConnect_Client:    4VcsConnect_Client.Views.SupportViews.uc_LWRates_List   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,9q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $��70 �6+   68   �� 5      $��90 �6+   68   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   .+�5      �� -   5        $��LabelRateYear��5      $��	Rate Year��61   $��Center=�6E   $��1q�5      $��Center=�6'   $��0��6I   $��0��6Y   
����  �$��1q�5   3   
���   �
�������$
��Bold"�5   3   6G   �� 5      -   5        $��cboRateYear��5      $��Center=�62   $��1q�6V   $��Center=�5       $��1��6A   $��0��6Q   
����  �$��1q�5!   6   
���   �
�������$
��Bold"�5"   6   5#   Q   �� 5&      -   5        $��LabelBanner��5&      $��Rates��6/   $��Center=�6?   $��1q�5'      $��Center=�6'   $��2��6I   $��0��6Y   
����  �$��1q�5(   3   
���   �
�������$
��Bold"�5)   3   6G   5*       J� Effect 5+      3  -System.Windows.Media.Effects.DropShadowEffect  5,         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5.      �� 52      $	��Top=�6   $��	10,2,10,9q�6*   ._�53      � .+�54      &   System.Windows.Controls.DataGrid  -   5        $��Rates_DataGrid��54         AutoGenerateColumns .   %� IsVirtualizing .  %� VirtualizationMode$ Standard=�56      	   EnableRowVirtualization	 . !
   EnableColumnVirtualization
 .  ��54   5   ��    Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+   ClipboardContentBinding 6T   Z�   5:      $ Rate ID��6L    61   �� *RateID+ 6]   Z�   5;      $ Category��6N    61   �� *
Category+ 6`   Z�   5<      $
 Code��6J    61   �� *Code+ 6X   Z�   5=      $ RateYear��6N    61   �� *
RateYear+ 6`   Z�   5>      $ Description��6Q    61   �� *Description+ 6f   Z�   5?      $ Retail Rate��6h    61   �� *
RetailRate+ �� StringFormat$ #,#0.00�� 6}   Z�   5@      $
 Cost��6f    61   �� *
CostRate+$ #,#0.00�� 6t   Z�   5A      $ ActiveStatus��6R    61   �� *ActiveStatus+ 6h   Z� 5C      5D      5E      5F      5G      5H      