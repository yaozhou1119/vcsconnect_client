   M S B A M L   `   `   `  ����  VcsConnect_Client;    5VcsConnect_Client.Views.MainTableViews.uc_Bids_Detail   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        ���#F5F5F5.��5	      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,5q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $��* �6+   67   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   66   .+�5      �� -   5        $��buttonADD_Enable_Copy��5      $��Bid (Add Record) - Copy��6:   $��2q�6\   
��� ���$��2q�5   2   $��Stretch=�6F   $��0��5      $��0��6-   
����  �
�������$
��Bold"�6c   5   C   �� 5      -   5        $��buttonADD_Enable_Blank��5      $��Bid (Add Record) - Blank��6;   $��2q�6^   
��� ���$��2q�5   2   $��Stretch=�6F   $��1��5      $��0��6-   
����  �
�������$
��Bold"�6c   5    D   5!       J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5%      �� 5)      $��Bottom=�6   $��2q�6-   ._�5-      �� $��1��6   $��	10,1,10,9q�6&   ._�5.      �   5/      �� 50      $��* �6/   6;   �� 51      $��* �6/   6;   �� 52      $��* �6/   6;   �� 53      $��* �6/   6;    55      �� 56      $��30 �6,   .+�59      �� -   5        $��	buttonADD��59   !   $	��ADD��62   $��2q�6@   
��� ���$��2q�6`   $��0��5:   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5;   4   6F   �� 5=      -   5        $��buttonUpdate��5=   !   $��Update��65   $��2q�6F   
��� ���$��2q�6f   $��1��5>   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5?   4   6F   �� 5A      -   5        $��buttonCancel��5A   !   $��Cancel��66   $��2q�6G   
��� ���$��2q�6g   $��2��5B   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5C   4   6F   �� 5E      -   5        $��buttonDELETE��5E   !   $��DELETE��66   $��2q�6G   
��� ���$��2q�6g   $��3��5F   !   $��0��61   $��Stretch=�6>   
����  �
��� ���$
��Bold"�5G   5   6G   5H       5K        5L      $ .5Q�6+   $ 5Q�68   $ 3Q�6G   6Y   5N      5O      �� 5S      $	��Top=�6   $��4,4,4,1q�6*   ._�5T      � -   5        $��
Equip_Grid��5T        5U      �� 5V      $
��auto �6+   6:   �� 5W      $��* �6+   67   �� 5X      $��10 �6+   68   �� 5Y      $
��auto �6+   6:   �� 5Z      $��* �6+   67    5\      �� 5]      $��30 �6(   �� 5^      $��30 �6(   �� 5_      $��30 �6(   �� 5`      $��30 �6(   �� 5a      $��30 �6(   �� 5b      $��30 �6(   �� 5c      $��30 �6(   �� 5d      $��30 �6(   �� 5e      $��* �6(   �� 5f      $��* �6(   �� 5g      $��* �6(   .+�5k      �� $��ID��6   $��Center=�6)   $��Center=�6M   
����  �$��1q�5l       $��2q�64   ���#F0F8FF$��0��6T   $��0��6d   6s   �� 5m      -	   5        $��lblID��5m      $��Center=�6M   $��Center=�5n   "   
����  �$��1q�6W   ���#F0F8FF$��1��5o   "   $��0��62   $��2q�6?   ��5m   )   �� *ID+ �� Mode$ TwoWay=�5o   ?   �� 5r      $��BidID��6   $��Center=�6,   $��Center=�6P   
����  �$��1q�5s       $��2q�64   ���#F0F8FF$��3��6T   $��0��6d   6s   �� 5t      -
   5        $��lblBidID��5t      $��Center=�6S   $��Center=�5u   "   
����  �$��1q�6W   ���#F0F8FF$��4��5v   "   $��0��62   $��2q�6?   ��5t   ,   �� *BidID+$ TwoWay=�5v   ?   �� 5z      $��Client Name��6   $��Center=�62   $��Center=�6V   
����  �$��1q�5{       $��2q�64   ���#F0F8FF$��0��6T   $��1��6d   6s   �� 5|      -   5        $��txtClientName��5|      $��Center=�6]   $��Center=�5}   "   
����  �$��1q�6W   
�������$��1��5~   "   $��1��62   $��2q�6?   ��5|   3   �� *
ClientName+$ Default=�5~   L   �� 5�      $��Client Loc ID��6   $��Center=�64   $��Center=�6X   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��1��6d   6s   �� 5�      -   5        $��txtClientLocID��5�      $��Center=�6_   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��1��62   $��2q�6?   ��5�   4   �� *ClientLocID+$ Default=�5�   L   �� 5�      $��Bid Amt Retail��6   $��Center=�65   $��Center=�6Y   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��2��6d   6s   �� 5�      -   5        $��txtBidAmtRetail��5�      $��Center=�6a   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��2��62   $��2q�6?   ��5�   5   �� *BidAmtRetail+$ Default=�5�   L   �� 5�      $��Bid Amt Cost��6   $��Center=�63   $��Center=�6W   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��2��6d   6s   �� 5�      -   5        $��txtBidAmtCost��5�      $��Center=�6]   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��2��62   $��2q�6?   ��5�   3   �� *
BidAmtCost+$ Default=�.��5�   J   5�      �� 5�      $
��Area��6   $��Center=�6+   $��Center=�6O   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��3��6d   6s   �� 5�      -   5        $��txtArea��5�      $��Center=�6Q   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��3��62   $��2q�6?   ��5�   -   �� *Area+$ Default=�5�   ?   �� 5�      $��BidSent��6   $��Center=�6.   $��Center=�6R   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��3��6d   6s   (  "System.Windows.Controls.DatePicker  5�      -   5        $��
dtpBidSent��5�   !   $��Center=�6b   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��3��62   $��2q�6?      SelectedDate 5�   3   �� *	BidSent+$ Default=�5�   ?   �� 5�      $��Description��6   $��Center=�62   $��Center=�6V   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��4��6d   6s   �� 5�      -   5        $��txtDescription��5�      $��Center=�6_   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��4��62   $��2q�6?   ��5�   4   �� *Description+$ Default=�5�   L   �� 5�      $��Bid Won��6   $��Center=�6.   $��Center=�6R   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��4��6d   6s   �� 5�      -   5        $��	cboBidWon��5�      $��Center=�6V   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��4��62   $��2q�6?    �� Text 5�   0   �� *BidWon+$ Default=�.@�5�      �� $	��Yes��6'   67   �� 5�      $��No��6'   66   5�      �� 5�      $��	Attn Name��6   $��Center=�60   $��Center=�6T   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��5��6d   6s   �� 5�      -   5        $��txtAttnName��5�      $��Center=�6]   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��5��62   $��2q�6?   ��5�   1   �� *activeStatus+$ Default=�5�   L   �� 5�      $��Desc Bid Amt Retail��6   $��Center=�6:   $��Center=�6^   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��5��6d   6s   �� 5�      -   5        $��txtdescBidAmtRetail��5�      $��Center=�6i   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��5��62   $��2q�6?   ��5�   9   �� *descBidAmtRetail+$ Default=�5�   L   �� 5�      $��Desc Bid Amt Cost��6   $��Center=�68   $��Center=�6\   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��6��6d   6s   �� 5�      -   5        $��txtdescBidAmtCost��5�      $��Center=�6e   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��6��62   $��2q�6?   ��5�   7   �� *descBidAmtCost+$ Default=�5�   L   �� 5�      $��Acc Num��6   $��Center=�6.   $��Center=�6R   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��6��6d   6s   �� 5�      -   5        $��	txtAccNum��5�      $��Center=�6U   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��6��62   $��2q�6?   ��5�   /   �� *AccNum+$ Default=�5�   L   �� 5�      $��	Narrative��6   $��Center=�60   $��Center=�6T   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��5��6T   $��7��6h   6w   �� 5�      -   5        $��rtbNarrative��5�   "   $
��Left=�66   $��Center=�5�   "   
����  �$��1q�6W   
�������$��5��5�   "   $��8��66   $��3��6C   $��2q�6T   $
��Auto=�5�   "   $
��Auto=�5�   "   . �5�      /� 6)   5�      5�      5�      5�      5�      5�      