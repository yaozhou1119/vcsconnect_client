   M S B A M L   `   `   `  ����  VcsConnect_Client<    6VcsConnect_Client.Views.MainTableViews.uc_Invoice_List   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � .+�5
   
   ]� ��. .+�5      �� $	��Top=�6   $��	10,2,10,9q�6*   ._�5      �   � ColumnDefinitions  5      �� 5      $	��175 �6+   69   �� 5      $��5 �6+   67   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      $��30 �6(   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��dtpSelectInvoiceDate��5   !   $��Center=�6=   $��Center=�5   !   $��0��6C   $��0��6S   
�������$��1q�5   5   
���   �
�������$
��Bold"�5   8   5   b   �� 5       -   5        $��LabelBanner��5       $��Invoice Listing��6/   $��Center=�6I   $��Center=�5!      $��2��6>   $��0��6N   
�������$��1q�5"      
���   �
�������$
��Bold"�6Z   6n   5#       J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         Opacity$ .5Q�6'      
BlurRadius$ 5Q�64      ShadowDepth$ 3Q�6C   6U   5'      �� 5+      $	��Top=�6   $��	10,2,10,9q�6*   ._�5,      � .+�5-      &   System.Windows.Controls.DataGrid  -   5        $��Invoice_DataGrid��5-         AutoGenerateColumns .   %� IsVirtualizing .  %� VirtualizationMode$ Standard=�5/      	   EnableRowVirtualization	 . !
   EnableColumnVirtualization
 .  "   VerticalScrollBarVisibility$
 Auto=�51      $   HorizontalScrollBarVisibility$
 Auto=�52         
IsReadOnly . ��5-   7   ��    Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+   ClipboardContentBinding 6T   Z�   56      $ WorkOrder ID��6Q    61   �� *WorkOrderID+ 6g   Z�   57      $ 
Invoice ID��6O    61   �� *	InvoiceID+ 6c   Z�   58      $ Description��6Q    61   �� *Description+ 6f   Z�   59      $ 
Contact ID��6O    61   �� *	ContactID+ 6c   Z�   5<      $ 	Work From��6^    61   �� *
WorkFrom+ �� StringFormat$ d�� 6q   Z�    ElementStyle 5=   "   �� 5>   &    �� 
TargetType" ��6,   .�5?   *   ��  �� Property � �� �� Value$ Center=�6P   6a   5@   '   5B        5D      $ Work To��6\    61   �� *WorkTo+$ d�� 6m   Z�  5E   "   �� 5F   &   " ��6,   .�5G   *   ��  � ��$ Center=�6P   6a   5H   '   5J        5L      $ Invoice Date��6a    61   �� *InvoiceDate+$ d�� 6w   Z�  5M   "   �� 5N   &   " ��6,   .�5O   *   ��  � ��$ Center=�6P   6a   5P   '   5R        5T      $
 Paid��6J    61   �� *Paid+ 6X   Z�   5U      $ 
Equip Hour��6O    61   �� *	EquipHour+ 6c   Z�   5V      $ Worker Hour��6P    61   �� *
WorkerHour+ 6e   Z�   5W      $ 	Chem Hour��6N    61   �� *
ChemHour+ 6a   Z�   5X      $ Tax Amt��6L    61   �� *TaxAmt+ 6]   Z�   5Y      $ Bill Location��6R    61   �� *BillLocation+ 6i   Z�   5Z      $ LocID��6K    61   �� *LocID+ 6Z   Z�   5[      $ InvID��6K    61   �� *InvID+ 6Z   Z�   5\      $ inv Memo��6M    61   �� *	invMemo+ 6_   Z�   5]      $ 	LocWrk ID��6N    61   �� *
LocWrkID+ 6a   Z�   5^      $ show Bill Name��6R    61   �� *showBillName+ 6j   Z�   5_      $ 	Tot Equip��6f    61   �� *
totEquip+$ {0:c}�� 6y   Z�   5`      $ Tot Work��6e    61   �� *	totWork+$ {0:c}�� 6w   Z�   5a      $ Tot Chem��6e    61   �� *	totChem+$ {0:c}�� 6w   Z�   5b      $ Tot Item��6e    61   �� *	totItem+$ {0:c}�� 6w   Z�   5c      $ Tot Before Tax��6j    61   �� *totBeforeTax+$ {0:c}�� 6�   Z�   5d      $ Tot Invoiced Befor Tax��6q    61   �� *totInvoicedBeforTax+$ {0:c}�� 6�   Z�   5e      $ Acc Num��6L    61   �� *AccNum+ 6]   Z� 5g      5h      5i      5j      5k      5l      