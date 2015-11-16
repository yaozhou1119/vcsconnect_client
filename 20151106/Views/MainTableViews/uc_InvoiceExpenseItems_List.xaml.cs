using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_InvoiceExpenseItems_List.xaml
    /// </summary>
    public partial class uc_InvoiceExpenseItems_List : UserControl
    {
        // Routed Event Handler
        public RoutedEventHandler OnInvExpItems_SELECTED;
        public RoutedEventHandler OnInvExpItems_CategorySELECTED;


        // constructor
        public uc_InvoiceExpenseItems_List()
        {
            InitializeComponent();
        }


        // Selection Event
        private void InvExpItems_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnInvExpItems_SELECTED != null) OnInvExpItems_SELECTED(sender, new RoutedEventArgs());
        }



        // Category Selection
        private void cboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strSelect = "";

            // read selected value from combo box,
            // this way is used because comboBoxItem
            // is used to define values in the XAML
            ComboBoxItem cbi = (ComboBoxItem)cboCategory.SelectedItem;
            if (cbi != null)
            {
                strSelect = cbi.Content.ToString();
                cboCategory.Text = strSelect;
            }
            else
            {
                strSelect = "";
                cboCategory.Text = "";
            }

            sender = strSelect;

            // Chem Status Selection Event
            if (OnInvExpItems_CategorySELECTED != null) OnInvExpItems_CategorySELECTED(sender, new RoutedEventArgs());
        }
    }
}
