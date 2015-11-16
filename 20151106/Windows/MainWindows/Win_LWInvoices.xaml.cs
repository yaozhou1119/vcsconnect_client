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
using System.Windows.Shapes;
// models
using VcsConnect_Client.Models.SQL_Models;
// worker
using VcsConnect_Client.Workers.SQL_Workers;
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for Win_LWInvoices.xaml
    /// </summary>
    public partial class Win_LWInvoices : Window
    {
        // creating and instance of the ViewModel
        private ViewModel.Invoice_ViewModel invVM = new ViewModel.Invoice_ViewModel();

        // worker
        lw_InvoiceItems_Worker IIWkr;
        lw_InvoiceExpenseItems_Worker IEIWkr;

        // on Date Selection:
        // clear the Invoice Item, and Inv Expense Item lists
        List<lw_InvoiceItems_Model> clrIIMod_list;
        List<lw_InvoiceExpenseItems_Model> clrIEIMod_list;

        // constructor
        public Win_LWInvoices()
        {
            InitializeComponent();

            // clear the Invoice Item, and Inv Expense Item lists
            clrIIMod_list = new List<lw_InvoiceItems_Model>();
            clrIEIMod_list = new List<lw_InvoiceExpenseItems_Model>();

            // worker
            IIWkr = new lw_InvoiceItems_Worker();
            IEIWkr = new lw_InvoiceExpenseItems_Worker();


            // LISTENER: Selected data changed
            // Handle on WorkOrder selection changed events
            uc_InvListing.OnInvoice_SELECTED += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_Invoice_Model) == false) return;

                lw_Invoice_Model selectedContent = (lw_Invoice_Model)itm;

                // display Invoice detail
                uc_AssociatedInvoiceData.uc_InvDetail.DataContext = selectedContent;


                // display Invoice Items based on selected Invoice
                List<lw_InvoiceItems_Model> iiMod_InvoiceID_List = IIWkr.Get_InvoiceItem_byInvoiceID_List(selectedContent.InvoiceID);
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvItemList.DataContext = iiMod_InvoiceID_List;


                // display Invoice Expense Items based on selected Invoice
                List<lw_InvoiceExpenseItems_Model> ieiMod_InvoiceID_List = IEIWkr.Get_InvExpensItems_byInvoiceID_List(selectedContent.InvoiceID);
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvExpItemList.DataContext = ieiMod_InvoiceID_List;

                // set the Invoice UPDATE button configuration
                uc_AssociatedInvoiceData.uc_InvDetail.Execute_UpdateButtonConfiguration();
                labelStatus.Content = "Invoice ID: " + selectedContent.ID;
            };


            // LISTENER: Selected Date Change
            // Handle on Invoice OnSelectedDate_SELECTED event
            uc_InvListing.OnInvoiceDate_SELECTED += (o, e) =>
            {
                // turn on busy Indicator
                busy_Indicator.IsBusy = true;

                string strDate = o.ToString();
                invVM.Get_InvoiceByDate_Async(strDate);

                // on Date Selection, clear the Invoice
                // Item data grid list
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvItemList.DataContext = clrIIMod_list;
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvExpItemList.DataContext = clrIEIMod_list;

                labelStatus.Content = "Retrieving data...";
            };



            // LISTENER: ADD Enabled
            uc_AssociatedInvoiceData.uc_InvDetail.OnInvoice_ADDEnabled += (o, e) =>
            {
                string strInvID = "";
                if (txtInvIDSearch.Text != null) strInvID = txtInvIDSearch.Text.Trim();

                // turn on busy Indicator
                busy_Indicator.IsBusy = true;

                // get list of invoices
                invVM.Get_Invoice_Async();

                // on Date Selection, clear the Invoice
                // Item data grid list
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvItemList.DataContext = clrIIMod_list;
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvExpItemList.DataContext = clrIEIMod_list;

                labelStatus.Content = "Retrieving data...";
            };




            // LISTENER: UPDATE
            uc_AssociatedInvoiceData.uc_InvDetail.OnInvoice_UPDATE += (o, e) =>
            {
                labelStatus.Content = o.ToString();

                // get strInvId
                string strInvId = "";
                if (txtInvIDSearch.Text != null) strInvId = txtInvIDSearch.Text.Trim();

                if (strInvId.Trim() != "")
                {
                    invVM.Get_Invoice_ByLIKEInvoiceID_Async(strInvId);
                }
                else
                {
                    invVM.Get_Invoice_Async();
                }

                // on Date Selection, clear the Invoice
                // Item data grid list
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvItemList.DataContext = clrIIMod_list;
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvExpItemList.DataContext = clrIEIMod_list;

                labelStatus.Content = "Retrieving data...";
            };



            // LISTENER: CANCELED
            uc_AssociatedInvoiceData.uc_InvDetail.OnInvoice_CANCELED += (o, e) =>
            {
                // display message
                labelStatus.Content = "";

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // on Date Selection, clear the Invoice
                // Item data grid list
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvItemList.DataContext = clrIIMod_list;
                uc_AssociatedInvoiceData.uc_InvTabControls.uc_InvExpItemList.DataContext = clrIEIMod_list;

                // redisplay data in grid
                // Get Async Invoice List
                invVM.Get_Invoice_Async();
                txtInvIDSearch.Text = "";
            };


            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            invVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "INVList")
                {
                    uc_InvListing.DataContext = invVM.invvmMod_List;
                    labelStatus.Content = "Retrieved " + invVM.invvmMod_List.Count + " Invoices.";

                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;

                    // change key board focus
                    Keyboard.Focus(txtInvIDSearch);
                }
            };

            // Telling the ViewModel to retieve data
            invVM.Get_Invoice_Async();
            labelStatus.Content = "Retrieving data...";
        }


        // menu exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // Selecting Invoices based on text changed on InvoiceID (SQL LIKE)
        private void txtInvIDSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string strInvID = "";
            if (txtInvIDSearch.Text != null) strInvID = txtInvIDSearch.Text.Trim();

            // display message
            labelStatus.Content = "";

            // turn ON busy Indicator
            busy_Indicator.IsBusy = true;

            // reset detail fields
            uc_AssociatedInvoiceData.uc_InvDetail.Execute_InitialButtonConfiguration();

            // get data
            invVM.Get_Invoice_ByLIKEInvoiceID_Async(strInvID);
        }
    }
}
