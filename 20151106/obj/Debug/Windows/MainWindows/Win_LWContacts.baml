   M S B A M L   `   `   `  ����L  HVcsConnect_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:VcsConnect_Client.Views.MainTableViews&VcsConnect_Client.Views.MainTableViews  5   	   :    4VcsConnect_Client.Windows.MainWindows.Win_LWContacts   5   	   =View4clr-namespace:VcsConnect_Client.Views.MainTableViews  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  All Client Contacts��5   	   $	��500��6%   $	��600��65   $
��1000��6B   $
��1250��6R   ���#E8E8E8.��5      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��3,5,3,3q�6*   $��23��6;   ._�5      o� -   5        $��MainMenu��5      $��27��6'   .@�5      m� -   5        $��menuFile��5      $
��File��6/   $��12(�6=   $
��Bold"�6K   .@�5      m� -   5        $��menuExit��5   #   $
��Exit��63   $��12(�6A   $��Regular"�6O   5   <   5      5      5      �� 5       $��Bottom=�6   $��
10,5,12,12q�6-   ._�5!      �  � ColumnDefinitions 5"      �� 5#      $��80 �6+   68   �� 5$      $	��150 �6+   69   �� 5%      $��* �6+   67    � RowDefinitions 5'      �� 5(      $��35 �6(   66   .+�5,      �� -   5        $��labelLastName��5,      $��	Last Name��61   $��Center=�6E   $��Center=�5-      $��0��6>   $��0��6N   $��2q�5.      
�������
�������$��1q�5/      $
��Bold"�60   6D   �� 52      -   5        $��txtSearchLastName��52      $��Center=�67   $��Center=�53      $��1��6@   $��0��6P   $��2q�54      
�������
�������$��1q�55      $
��Bold"�62   56   L   �� 59      -   5        $��labelStatus��59      $��Center=�6/   $��Center=�5:      $��2��6>   $��0��6N   $��2q�5;      
�������
�������$��1q�5<      $
��Bold"�60   6D   5=       J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5A      �� 5D      $	��Top=�6   $��3,5,9,3q�6*   ._�5E      �  5F      �� 5G      $��* �6+   67   �� 5H      $��* �6+   67    5J      �� 5K      $��* �6(   65   .+�5O      �� $��2q�6   $��0��6(   $��0��68   ._�5P      B   <VcsConnect_Client.Views.MainTableViews.uc_ClientContact_List  -   5          Name$ uc_ContactList��5P   5   5Q      �� 5T      $��Stretch=�6#   $��5��6?   $��0��6I   $��0��6Y   $��Right=�5U   #   
�������$��1q�6S   $��2q�5V   #   ���#0000EE6.   �� 5Y      $��2q�6   $��1��6(   $��0��68   ._�5Z      D   >VcsConnect_Client.Views.MainTableViews.uc_ClientContact_Detail  -   5          Name$ uc_ContactDetail��5Z   :   5[      5\      5]      5^      �� 5a   
   ._�5b      %  Xceed.Wpf.Toolkit.BusyIndicator  -	   5        	  Name$	 busy_Indicator��5b   !   
   IsBusy
 . $��Center=�6H   $��Center=�5c      6:    5d        5e      $ .5Q�6#   $ 5Q�60   $ 5Q�6?   6Q   5g      5h      5i      