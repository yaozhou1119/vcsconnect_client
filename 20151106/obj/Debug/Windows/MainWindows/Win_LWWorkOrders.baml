   M S B A M L   `   `   `  ����L  HVcsConnect_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:VcsConnect_Client.Views.MainTableViews&VcsConnect_Client.Views.MainTableViews  5   	   <    6VcsConnect_Client.Windows.MainWindows.Win_LWWorkOrders   5   	   =View4clr-namespace:VcsConnect_Client.Views.MainTableViews  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Work Orders��5   	   $	��500��6   $	��600��6-   $
��1000��6:   $
��1250��6J   ���#E8E8E8.��5      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��3,5,3,3q�6*   $��23��6;   ._�5      o� -   5        $��MainMenu��5      $��27��6'   .@�5      m� -   5        $��menuFile��5      $
��File��6/   $��12(�6=   $
��Bold"�6K   .@�5      m� -   5        $��menuExit��5   #   $
��Exit��63   $��12(�6A   $��Regular"�6O   5   <   5      5      5      �� 5       $��Bottom=�6   $��
10,5,12,12q�6-   ._�5!      �  � ColumnDefinitions 5"      �� 5#      $��90 �6+   68   �� 5$      $	��150 �6+   69   �� 5%      $��* �6+   67    � RowDefinitions 5'      �� 5(      $��35 �6(   66   .+�5,      �� -   5        $��labelCLName��5,      $��Client Name��6/   $��Center=�6E   $��Center=�5-      $��0��6>   $��0��6N   $��1q�6[   
�������
�������$��1q�5/      $
��Bold"�60   6D   �� 52      -   5        $��	txtCLName��52      $��Center=�6/   $��Center=�53      $��1��6@   $��0��6P   $��1q�6]   
�������
�������$��1q�54   I   $
��Bold"�55      6V   �� 58      -   5        $��labelStatus��58      $��Center=�6/   $��Center=�59      $��2��5:      $��0��6,   $��2q�69   
�������
�������$��1q�5;   0   $
��Bold"�6D   6X   5<       J� Effect 5=      3  -System.Windows.Media.Effects.DropShadowEffect  5>         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5@      �� 5C      $	��Top=�6   $��3,5,9,3q�6*   ._�5D      �  5E      �� 5F      $��* �6+   67   �� 5G      $��* �6+   67    5I      �� 5J      $��* �6(   65   .+�5N      �� $��2q�6   $��0��6(   $��0��68   ._�5O      ?   9VcsConnect_Client.Views.MainTableViews.uc_WorkOrders_List  -   5          Name$ 	uc_WOList��5O   2   5P      �� 5S      $��Stretch=�6#   $��5��6?   $��0��6I   $��0��6Y   $��Right=�5T   #   
�������$��1q�6S   $��2q�5U   #   ���#0000EE6.   �� 5X      $��2q�6   $��1��6(   $��0��68   ._�5Y      A   ;VcsConnect_Client.Views.MainTableViews.uc_WorkOrders_Detail  -   5          Name$ uc_WODetail��5Y   4   5Z      5[      5\      5]      �� 5`   
   ._�5a      %  Xceed.Wpf.Toolkit.BusyIndicator  -	   5        	  Name$	 busy_Indicator��5a   !   
   IsBusy
 . $��Center=�6G   $��Center=�5b   !   6>    5c        5d      $ .5Q�6#   $ 5Q�60   $ 5Q�6?   6Q   5f      5g      5h      