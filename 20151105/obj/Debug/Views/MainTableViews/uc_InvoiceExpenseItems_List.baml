   M S B A M L   `   `   `  ����  VcsConnect_ClientH    BVcsConnect_Client.Views.MainTableViews.uc_InvoiceExpenseItems_List   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,9q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $��80 �6+   68   �� 5      $	��100 �6+   69   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   .+�5      �� -   5        $��LabelCategory��5      $��Category��61   $��Center=�6D   $��1q�5      $��Center=�6'   $��0��6I   $��0��6Y   
�������$��1q�5   0   
���   �
�������$
��Bold"�5      60   �� 5      -   5        $��cboCategory��5      $��Center=�62   $��	1,0,1,1.4q�6V   $��Center=�5       $��1��6A   $��0��6Q   
�������$��1q�5!   3   
���   �
�������$
��Bold"�5"   6   $��28��6H   $��Bottom=�6T   .@�5$      �� .��6'   	Equipment62   �� 5%      .��6'   Worker6/   5&      �� 5)      -   5        $��LabelBanner��5)      $#��Invoice Expense Items Listing��6/   $��1q�6W   $��Center=�5*      $��Center=�6@   $��2��5+      $��0��6,   
�������$��1q�6M   
���   �
�������$
��Bold"�5,   F   6Z   5-       J� Effect 5.      3  -System.Windows.Media.Effects.DropShadowEffect  5/         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   51      �� 55      $	��Top=�6   $��	10,2,10,9q�6*   ._�56      � .+�57      &   System.Windows.Controls.DataGrid  -   5        $��InvExpItems_DataGrid��57         AutoGenerateColumns .   %� IsVirtualizing .  %� VirtualizationMode$ Standard=�59      	   EnableRowVirtualization	 . !
   EnableColumnVirtualization
 .     
IsReadOnly . ��57   ;   ��    ColumnHeaderStyle 5<      �� 5=       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5>   "   ��  �� Property � �� �� Value �#CAE1FF6Q   �� 5?   "    � ��
 �����6S   �� 5@   "    � ��$ 1q�6D   6P   �� 5A   "    � ��$ 1q�6;   6G   5B         Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+   ClipboardContentBinding 6T   Z�   5F      $
 WOID��6J    61   �� *WOID+ 6X   Z�   5G      $ 
Invoice ID��6O    61   �� *	InvoiceID+ 6c   Z�   5H      $ Category��6N    61   �� *
Category+ 6`   Z�   5I      $ Exp Name��6M    61   �� *	ExpName+ 6_   Z�   5J      $
 Rate��6J    61   �� *Rate+ 6X   Z�   5K      $
 Cost��6J    61   �� *Cost+ 6X   Z�   5L      $ Total Hours��6N    61   �� *
TotHours+ 6c   Z� 5N      5O      5P      5Q      5R      5S      