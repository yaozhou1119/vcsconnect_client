   M S B A M L   `   `   `  ����  VcsConnect_Client9    3VcsConnect_Client.Views.MainTableViews.uc_Bids_List   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,9q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $	��175 �6+   69   �� 5      $��5 �6+   67   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��dtpBidSelectSentDate��5   !   $��Center=�6=   $��Center=�5   !   $��0��6C   $��0��6S   
�������$��1q�5   5   
���   �
�������$
��Bold"�5   8   5   b   �� 5       -   5        $��LabelBanner��5       $��Bid Listing��6/   $��Center=�6E   $��Center=�5!      $��2��6>   $��0��6N   
�������$��1q�5"      
���   �
�������$
��Bold"�6Z   6n   5#       J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5'      �� 5+      $	��Top=�6   $��	10,2,10,9q�6*   ._�5,      � .+�5-      &   System.Windows.Controls.DataGrid  -   5        $��Bid_DataGrid��5-         AutoGenerateColumns .   %� IsVirtualizing .  %� VirtualizationMode$ Standard=�5/      	   EnableRowVirtualization	 . !
   EnableColumnVirtualization
 .  "   VerticalScrollBarVisibility$
 Auto=�51      $   HorizontalScrollBarVisibility$
 Auto=�52         
IsReadOnly . ��5-   3   ��    Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+   ClipboardContentBinding 6T   Z�   56      $ Bid ID��6K    61   �� *BidID+ 6[   Z�   57      $ Client Name��6P    61   �� *
ClientName+ 6e   Z�   58      $ Client Loc ID��6Q    61   �� *ClientLocID+ 6h   Z�   59      $ Retail Bid Amount��6R    61   �� *BidAmtRetail+ 6m   Z�   5:      $ Cost Bid Amount��6P    61   �� *
BidAmtCost+ 6i   Z�   5;      $
 Area��6J    61   �� *Area+ 6X   Z�   5>      $ Bid Sent��6]    61   �� *	BidSent+ �� StringFormat$ d�� 6o   Z�    ElementStyle 5?   "   �� 5@   &    �� 
TargetType" ��6,   .�5A   *   ��  �� Property � �� �� Value$ Center=�6P   6a   5B   '   5D        5F      $ Description��6Q    61   �� *Description+ 6f   Z�   5G      $ Bid Won��6L    61   �� *BidWon+ 6]   Z�   5H      $ 	Attn Name��6N    61   �� *
AttnName+ 6a   Z�   5I      $ Two Columns��6P    61   �� *
TwoColumns+ 6e   Z�   5J      $ Desc Bid Amt Retail��6V    61   �� *descBidAmtRetail+ 6s   Z�   5K      $ Desc Bid Amt Cost��6T    61   �� *descBidAmtCost+ 6o   Z�   5L      $ Show Loc Name��6Q    61   �� *showLocName+ 6h   Z�   5M      $ Acc Num��6L    61   �� *AccNum+ 6]   Z� 5O      5P      5Q      5R      5S      5T      