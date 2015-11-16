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
    /// Interaction logic for uc_Invoice_List.xaml
    /// </summary>
    public partial class uc_Invoice_List : UserControl
    {
        // routed Event Handler
        public RoutedEventHandler OnInvoice_SELECTED;
        public RoutedEventHandler OnInvoiceDate_SELECTED;

        // constructor
        public uc_Invoice_List()
        {
            InitializeComponent();
        }


        // Selection Event
        private void Invoice_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnInvoice_SELECTED != null) OnInvoice_SELECTED(sender, new RoutedEventArgs());
        }

        
        // Select Invoices by Invoice Date
        private void dtpSelectInvoiceDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = (DateTime)dtpSelectInvoiceDate.SelectedDate;
            sender = dt.ToShortDateString();

            // selection date event
            if (OnInvoiceDate_SELECTED != null) OnInvoiceDate_SELECTED(sender, new RoutedEventArgs());
        }
    }
}
