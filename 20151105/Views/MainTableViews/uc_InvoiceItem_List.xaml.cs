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
// model
using VcsConnect_Client.Models.SQL_Models;
// Views
using VcsConnect_Client.Views.MainTableViews;
// Windows
using VcsConnect_Client.Windows.MainWindows;

namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_InvoiceItem_List.xaml
    /// </summary>
    public partial class uc_InvoiceItem_List : UserControl
    {
        public uc_InvoiceItem_List()
        {
            InitializeComponent();
        }

        private void InvoiceItem_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Display Invoice Item Detail Window
        private void InvoiceItem_DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var datagrid = (DataGrid)sender;
            var itm = datagrid.SelectedItem;
            if ((itm is lw_InvoiceItems_Model) == false) return;

            // get selected contet
            lw_InvoiceItems_Model selectedContent = (lw_InvoiceItems_Model)itm;

            // display Invoice Item detail
            Win_LWInvoiceItems Win_II = new Win_LWInvoiceItems(selectedContent);
            Win_II.ShowDialog();
        }
    }
}
