   M S B A M L   `   `   `  ����  VcsConnect_ClientF    @VcsConnect_Client.Views.MainTableViews.uc_ClientsLocation_Detail   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5        ���#F5F5F5.��5      � .+�5   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,5q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $��* �6+   67   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   66   .+�5      �� -   5        $��buttonADD_Enable_Copy��5      $"��Location (add record) - Copy��6:   $��2q�6a   
��� ���$��2q�5      $��Stretch=�61   $��0��6O   $��0��6_   
����  �
�������$
��Bold"�5   F   5   C   �� 5      -   5        $��buttonADD_Enable_Blank��5      $#��Location (add record) - Blank��6;   $��2q�6c   
��� ���$��2q�5       $��Stretch=�61   $��1��6O   $��0��6_   
����  �
�������$
��Bold"�5!   F   5"   D   5#       J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5'      �� 5+      $��Bottom=�6   $��2q�6-   ._�5/      �� $��1��6   $��	10,1,10,9q�6&   ._�50      �   51      �� 52      $��* �6/   6;   �� 53      $��* �6/   6;   �� 54      $��* �6/   6;   �� 55      $��* �6/   6;    57      �� 58      $��30 �6,   .+�5;      �� -   5        $��	buttonADD��5;   !   $	��ADD��62   $��2q�6@   
��� ���$��2q�6`   $��0��5<   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5=   4   6F   �� 5?      -   5        $��buttonUpdate��5?   !   $��Update��65   $��2q�6F   
��� ���$��2q�6f   $��1��5@   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5A   4   6F   �� 5C      -   5        $��buttonCancel��5C   !   $��Cancel��66   $��2q�6G   
��� ���$��2q�6g   $��2��5D   !   $��0��61   $��Stretch=�6>   
����  �
�������$
��Bold"�5E   4   6F   �� 5G      -   5        $��buttonDELETE��5G   !   $��DELETE��66   $��2q�6G   
��� ���$��2q�6g   $��3��5H   !   $��0��61   $��Stretch=�6>   
����  �
��� ���$
��Bold"�5I   5   6G   5J       5M        5N      $ .5Q�6+   $ 5Q�68   $ 3Q�6G   6Y   5P      5Q      �� 5U      $	��Top=�6   $��4,4,4,1q�6*   ._�5V      � -   5        $��Contact_Grid��5V        5W      �� 5X      $
��auto �6+   6:   �� 5Y      $��* �6+   67   �� 5Z      $��10 �6+   68   �� 5[      $
��auto �6+   6:   �� 5\      $��* �6+   67    5_      �� 5`      $��37 �6(   �� 5a      $��37 �6(   �� 5b      $��37 �6(   �� 5c      $��37 �6(   �� 5d      $��37 �6(   �� 5e      $��37 �6(   �� 5f      $��* �6(   .+�5j      �� $��ID��6   $��Center=�6)   $��Center=�6M   
����  �$��1q�5k       $��2q�64   ���#F0F8FF$��0��6T   $��0��6d   6s   �� 5l      -	   5        $��lblID��5l      $��Center=�6M   $��Center=�5m   "   
����  �$��1q�6W   ���#F0F8FF$��1��5n   "   $��0��62   $��2q�6?   ��5l   )   �� *ID+ �� Mode$ TwoWay=�5n   ?   �� 5q      $��Acc Num��6   $��Center=�6.   $��Center=�6R   
����  �$��1q�5r       $��2q�64   ���#F0F8FF$��3��6T   $��0��6d   6s   �� 5s      -
   5        $��	txtAccNum��5s      $��Center=�6T   $��Center=�5t   "   
����  �$��1q�6W   
�������$��4��5u   "   $��0��62   $��2q�6?   ��5s   /   �� *AccNum+$ TwoWay=�5u   ?   �� 5y      $��Client Name��6   $��Center=�62   $��Center=�6V   
����  �$��1q�5z       $��2q�64   ���#F0F8FF$��0��6T   $��1��6d   6s   �� 5{      -   5        $��txtClientName��5{      $��Center=�6]   $��Center=�5|   "   
����  �$��1q�6W   
�������$��1��5}   "   $��1��62   $��2q�6?   ��5{   3   �� *
ClientName+$ Default=�5}   ?   �� 5�      $��Location ID��6   $��Center=�62   $��Center=�6V   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��1��6d   6s   �� 5�      -   5        $��txtClientLocationID��5�      $��Center=�6i   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��1��62   $��2q�6?   ��5�   9   �� *ClientLocationID+$ Default=�5�   L   �� 5�      $
��Name��6   $��Center=�6+   $��Center=�6O   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��2��6d   6s   �� 5�      -   5        $��txtName��5�      $��Center=�6Q   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��2��62   $��2q�6?   ��5�   -   �� *Name+$ Default=�5�   ?   �� 5�      $
��Type��6   $��Center=�6+   $��Center=�6O   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��2��6d   6s   �� 5�      -   5        $��txtType��5�      $��Center=�6Q   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��2��62   $��2q�6?   ��5�   -   �� *Type+$ Default=�5�   L   �� 5�      $��	Address 1��6   $��Center=�60   $��Center=�6T   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��3��6d   6s   �� 5�      -   5        $��
txtLocAdd1��5�      $��Center=�6W   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��3��62   $��2q�6?   ��5�   0   �� *	LocAdd1+$ Default=�5�   L   �� 5�      $��	Address 2��6   $��Center=�60   $��Center=�6T   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��3��6d   6s   �� 5�      -   5        $��
txtLocAdd2��5�      $��Center=�6W   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��3��62   $��2q�6?   
���   ���5�   0   �� *	LocAdd2+$ Default=�5�   _   �� 5�      $
��Town��6   $��Center=�6+   $��Center=�6O   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��4��6d   6s   �� 5�      -   5        $��
txtLocTown��5�      $��Center=�6W   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��4��62   $��2q�6?   ��5�   0   �� *	LocTown+$ Default=�5�   L   �� 5�      $��State��6   $��Center=�6,   $��Center=�6P   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��4��6d   6s   �� 5�      -   5        $��txtLocState��5�      $��Center=�6Y   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��4��62   $��2q�6?   ��5�   1   �� *
LocState+$ Default=�5�   L   �� 5�      $	��Zip��6   $��Center=�6*   $��Center=�6N   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��5��6d   6s   �� 5�      -   5        $��	txtLocZip��5�      $��Center=�6U   $��Center=�5�   "   
����  �$��1q�6W   
�������$��1��5�   "   $��5��62   $��2q�6?   ��5�   /   �� *LocZip+$ Default=�5�   L   �� 5�      $��LocCat��6   $��Center=�6-   $��Center=�6Q   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��3��6T   $��5��6d   6s   �� 5�      -   5        $��	txtLocCat��5�      $��Center=�6U   $��Center=�5�   "   
����  �$��1q�6W   
�������$��4��5�   "   $��5��62   $��2q�6?   ��5�   /   �� *LocCat+$ Default=�5�   L   �� 5�      $��Comment��6   $��Center=�6.   $��Center=�6R   
����  �$��1q�5�       $��2q�64   ���#F0F8FF$��0��6T   $��6��6d   6s   �� 5�      -   5        $��
txtComment��5�      $��Center=�6I   $��Center=�5�      
����  �$��1q�6S   
�������$��1��5�      $��6��6.   $��7��6;   $��2q�6O    �� TextWrapping$
 Wrap=�6Z   $
��Auto=�5�      $
��Auto=�5�      ��5�   0   �� *	Comment+5�   P   5�      5�      5�      %  Xceed.Wpf.Toolkit.BusyIndicator  5�   
   -   5          Name$ busyIndicator��5�      $��Center=�64   $��Center=�6O   5�      5�      