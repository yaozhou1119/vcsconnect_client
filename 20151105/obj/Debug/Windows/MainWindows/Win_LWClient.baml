   M S B A M L   `   `   `  ����L  HVcsConnect_Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:VcsConnect_Client.Views.MainTableViews&VcsConnect_Client.Views.MainTableViews  5   	   8    2VcsConnect_Client.Windows.MainWindows.Win_LWClient   5   	   =View4clr-namespace:VcsConnect_Client.Views.MainTableViews  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Win_LWClient��5   	   $	��500��6   $	��600��6.   $
��1000��6;   $
��1250��6K   ���#E8E8E8.��5      � .+�5	   
   ]� ��. .+�5      �� $	��Top=�6   $��3,5,3,3q�6*   $��23��6;   ._�5      o� -   5        $��MainMenu��5      $��27��6'   .@�5      m� -   5        $��menuFile��5      $
��File��6/   $��12(�6=   $
��Bold"�6K   .@�5      m� -   5        $��menuExit��5   #   $
��Exit��63   $��12(�6A   $��Regular"�6O   5   <   5      5      5      �� 5      $��Bottom=�6   $��
10,5,12,12q�6-   ._�5       �  � ColumnDefinitions 5!      �� 5"      $	��100 �6+   69   �� 5#      $	��150 �6+   69   �� 5$      $��* �6+   67    � RowDefinitions 5&      �� 5'      $��35 �6(   66   .+�5+      �� -   5        $��labelClientName��5+      $��Client Name��63   $��Center=�6I   $��Center=�5,      $��0��6>   $��0��6N   $��1q�6[   
�������
�������$��1q�5-   H   $
��Bold"�5.      60   �� 51      -   5        $��txtSearchClientName��51      $��Center=�69   $��Center=�52      $��1��6@   $��0��6P   $��1q�6]   
�������
�������$��1q�53   I   $
��Bold"�54      6`   �� 57      -   5        $��labelStatus��57      $��Center=�6/   $��Center=�58      $��2��6>   $��0��6N   $��1q�6[   
�������
�������$��1q�5:      $
��Bold"�60   6D   5;       J� Effect 5<      3  -System.Windows.Media.Effects.DropShadowEffect  5=         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5?      �� 5B      $	��Top=�6   $��3,5,9,3q�6*   ._�5C      �  5D      �� 5E      $��* �6+   67   �� 5F      $��* �6+   67    5H      �� 5I      $��* �6(   65   .+�5M      �� $��2q�6   $��0��6(   $��0��68   ._�5N      <   6VcsConnect_Client.Views.MainTableViews.uc_Clients_List  -   5          Name$ uc_ClientsList��5N   /   5O      �� 5R      $��Stretch=�6#   $��5��6?   $��0��6I   $��0��6Y   $��Right=�5S   #   
�������$��1q�6S   $��2q�5T   #   ���#0000EE � ToolTip$ Slide - Left, Right��6C   �� 5W      $��2q�6   $��1��6(   $��0��68   ._�5X      M   GVcsConnect_Client.Views.MainTableViews.uc_ClientAssociatedTable_Display  -   5        	  Name$	 uc_ClientAssocTblDisplay��5X   @   5Y      5Z      5[      5\      �� 5_   
   ._�5`      %  Xceed.Wpf.Toolkit.BusyIndicator  -	   5        
  Name$
 busy_Indicator��5`   !      IsBusy . $��Center=�6G   $��Center=�5a   !   6>    5b        5c      $ .5Q�6#   $ 5Q�60   $ 5Q�6?   6Q   5e      5f      5g      