   M S B A M L   `   `   `  ����  VcsConnect_ClientB    <VcsConnect_Client.Views.MainTableViews.uc_InvoiceItem_Detail   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ���	#FFE5E5E5.��5	      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,5q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $��* �6+   67   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   66   .+�5      �� -   5        $��buttonADD_Enable_Copy��5      $&�� Invoice Item (add record) - Copy��6:   $��2q�6e   
��� ���$��2q�5      $��Stretch=�61   $��0��6O   $��0��6_   
����  �
�������$
��Bold"�5   F   5   C   �� 5      -   5        $��buttonADD_Enable_Blank��5      $'��!Invoice Item (add record) - Blank��6;   $��2q�6g   
��� ���$��2q�5      $��Stretch=�61   $��1��6O   $��0��6_   
����  �
�������$
��Bold"�5   F   5    D   5!       J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5%      �� 5)      $��Bottom=�6   $��2q�6-   ._�5-      �� $��1��6   $��	10,1,10,9q�6&   ._�5.      �   5/      �� 50      $��* �6/   6;   �� 51      $��* �6/   6;   �� 52      $��* �6/   6;   �� 53      $��* �6/   6;    55      �� 56      $��30 �6,   .+�59      �� -   5        $��	buttonADD��59   !   $	��ADD��62   $��2q�6@   
��� ���$��2q�6`   $��0��5:   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5;   4   6F   �� 5=      -   5        $��buttonUpdate��5=   !   $��Update��65   $��2q�6F   
��� ���$��2q�6f   $��1��5>   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5?   4   6F   �� 5A      -   5        $��buttonCancel��5A   !   $��Cancel��66   $��2q�6G   
��� ���$��2q�6g   $��2��5B   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5C   4   6F   �� 5E      -   5        $��buttonDELETE��5E   !   $��DELETE��66   $��2q�6G   
��� ���$��2q�6g   $��3��5F   !   $��0��61   $��Stretch=�6>   
����  �
��� ���$
��Bold"�5G   5   6G   5H       5K        5L      $ .5Q�6+   $ 5Q�68   $ 3Q�6G   6Y   5N      5O      �� 5S      $	��Top=�6   $��4,4,4,1q�6*   ._�5T      � -   5        $��
Equip_Grid��5T        5U      �� 5V      $
��auto �6+   6:   �� 5W      $��* �6+   67    5Y      �� 5Z      $��* �6(   �� 5[      $��* �6(   �� 5\      $��* �6(   �� 5]      $��* �6(   �� 5^      $��* �6(   �� 5_      $��* �6(   �� 5`      $��* �6(   .+�5d      �� $��ID��6   $��Center=�6)   $��Center=�6M   
����  �$��1q�5e       $��2q�64   ���#F0F8FF$��0��6T   $��0��6d   6s   �� 5f      -   5        $��lblID��5f      $��Center=�6M   $��Center=�5g   "   
����  �$��1q�6W   ���#F0F8FF$��1��5h   "   $��0��62   $��2q�6?   ��5f   )   �� *ID+ �� Mode$ TwoWay=�5h   ?   �� 5k      $��Inv Item Id��6   $��Center=�62   $��Center=�6V   
����  �$��1q�5l       $��2q�64   ���#F0F8FF$��0��6T   $��1��6d   6s   �� 5m      -	   5        $��lblInvItemId��5m      $��Center=�6[   $��Center=�5n   "   
����  �$��1q�6W   ���#F0F8FF$��1��5o   "   $��1��62   $��2q�6?   ��5m   0   �� *	InvItemId+$ TwoWay=�5o   ?   �� 5r      $��
Invoice ID��6   $��Center=�61   $��Center=�6U   
����  �$��1q�5s       $��2q�64   ���#F0F8FF$��0��6T   $��2��6d   6s   �� 5t      -
   5        $��txtInvoiceID��5t      $��Center=�6[   $��Center=�5u   "   
����  �$��1q�6W   
�������$��1��5v   "   $��2��62   $��2q�6?   ��5t   2   �� *	InvoiceID+$ Default=�5v   ?   �� 5y      $��Description��6   $��Center=�62   $��Center=�6V   
����  �$��1q�5z       $��2q�64   ���#F0F8FF$��0��6T   $��3��6d   6s   �� 5{      -   5        $��txtDescription��5{      $��Center=�6_   $��Center=�5|   "   
����  �$��1q�6W   
�������$��1��5}   "   $��3��62   $��2q�6?   ��5{   4   �� *Description+$ Default=�5}   ?   �� 5�      $
��Cost��6   $��Center=�6+   $��Center=�6O   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��4��6d   6s   �� 5�      -   5        $��txtCost��5�      $��Center=�6C   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��4��62   $��2q�6?   ��5�   -   �� *Cost+5�   L   �� 5�      $��InvID��6   $��Center=�6,   $��Center=�6P   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��5��6d   6s   �� 5�      -   5        $��txtInvID��5�      $��Center=�6S   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��5��62   $��2q�6?   ��5�   .   �� *InvID+$ Default=�5�   ?   �� 5�      $��Is tax��6   $��Center=�6-   $��Center=�6Q   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��6��6d   6s   �� 5�      -   5        $��txtistax��5�      $��Center=�6T   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��6��62   $��2q�6?    �� Text 5�   /   �� *istax+$ Default=�.@�5�      �� .��6'   Yes6,   �� 5�      .��6'   No6+   5�      5�      5�      5�      5�      5�      