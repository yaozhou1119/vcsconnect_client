   M S B A M L   `   `   `  ����  VcsConnect_Client?    9VcsConnect_Client.Views.MainTableViews.uc_WorkOrders_List   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,9q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $	��175 �6+   69   �� 5      $��5 �6+   67   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��dtpDateSelection��5   !   $��Center=�69   $��Center=�5   !   $��0��6C   $��0��6S   
�������$��1q�5   5   
���   �
�������$
��Bold"�5   8      SelectedDateFormat$ Short=�5   !   6>   �� 5!      -   5        $��LabelBanner��5!      $��Work Orders Listing��6/   $��Center=�6M   $��Center=�5"      $��2��6>   $��0��6N   
�������$��1q�5#      
���   �
�������$
��Bold"�6Z   6n   5$       J� Effect 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5(      �� 5,      $	��Top=�6   $��	10,2,10,9q�6*   ._�5-      � .+�5.      &   System.Windows.Controls.DataGrid  -   5        $��WorkOrders_DataGrid��5.         AutoGenerateColumns .   %� IsVirtualizing . 	 %� VirtualizationMode$	 Standard=�50      
   EnableRowVirtualization
 . !   EnableColumnVirtualization .  "   VerticalScrollBarVisibility$
 Auto=�52      $   HorizontalScrollBarVisibility$
 Auto=�53         
IsReadOnly . ��5.   :   ��    Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+   ClipboardContentBinding 6T   Z�   57      $ Client Name��6P    61   �� *
ClientName+ 6e   Z�   58      $ Location ID��6P    61   �� *
LocationID+ 6e   Z�   59      $
 WOID��6J    61   �� *WOID+ 6X   Z�   5:      $ Purchase Order��6S    61   �� *PurchaseOrder+ 6k   Z�   5=      $ 
Start Date��6_    61   �� *	StartDate+ �� StringFormat$ d�� 6s   Z�    ElementStyle 5>   "   �� 5?   &    �� 
TargetType" ��6,   .�5@   *   ��  �� Property � �� �� Value$ Center=�6P   6a   5A   '   5C        5D      $ Finish Date��6`    61   �� *
FinishDate+$ d�� 6u   Z�  5E   "   �� 5F   &   " ��6,   .�5G   *   ��  � ��$ Center=�6P   6a   5H   '   5J        5L      $ ROW Name��6M    61   �� *	ROWName+ 6_   Z�   5M      $ ROW Num��6L    61   �� *ROWNum+ 6]   Z�   5N      $ State��6K    61   �� *State+ 6Z   Z�   5O      $ Description��6Q    61   �� *Description+ 6f   Z�   5P      $ Job Type��6M    61   �� *	JobType+ 6_   Z�   5Q      $	 PIC��6I    61   �� *PIC+ 6V   Z�   5R      $ Contract Price Cost��6X    61   �� *ContractPrice_cost+ 6u   Z�   5S      $ Contract Price Retail��6Z    61   �� *ContractPrice_retail+ 6y   Z�   5T      $ Rate ID��6L    61   �� *RateID+ 6]   Z�   5U      $ Loc ID��6K    61   �� *LocID+ 6[   Z�   5V      $ 
exp Worker��6O    61   �� *	expWorker+ 6c   Z�   5W      $ 	exp Equip��6N    61   �� *
expEquip+ 6a   Z�   5X      $ exp Chem��6M    61   �� *	expChem+ 6_   Z�   5Y      $ Invoiced No Tax��6S    61   �� *InvoicedNoTax+ 6l   Z�   5Z      $ perDiem Cost��6Q    61   �� *perDiemCost+ 6g   Z�   5[      $ 
Tank Total��6O    61   �� *	TankTotal+ 6c   Z�   5\      $ line num��6M    61   �� *	linenum+ 6_   Z�   5]      $ Acc Num��6L    61   �� *AccNum+ 6]   Z� 5_      5`      5a      5b      5c      5d      