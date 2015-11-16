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
    /// Interaction logic for Win_LWInvExpItems.xaml
    /// </summary>
    public partial class Win_LWInvExpItems : Window
    {
        // creating and instance of the ViewModel
        private ViewModel.InvoiceItemExpense_ViewModel ieiVM = new ViewModel.InvoiceItemExpense_ViewModel();
        private string _category;
        private string _invID;

        // constructor
        public Win_LWInvExpItems()
        {
            InitializeComponent();
            _category = "";
            _invID = "";
            

            // LISTENER: Selected data changed
            // Handle on Inv Exp Items selection changed events
            uc_InvExpItemsList.OnInvExpItems_SELECTED += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_InvoiceExpenseItems_Model) == false) return;

                lw_InvoiceExpenseItems_Model selectedContent = (lw_InvoiceExpenseItems_Model)itm;

                uc_InvExpItemsDetail.DataContext = selectedContent;

                uc_InvExpItemsDetail.Execute_UpdateButtonConfiguration();
                labelStatus.Content = "Contact ID: " + selectedContent.ID;
            };


            // LISTENER: Selected Category changed
            // Handle on Inv Exp Items selection changed events
            uc_InvExpItemsList.OnInvExpItems_CategorySELECTED += (o, e) =>
            {
                _category = o.ToString();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // reset and initial button
                uc_InvExpItemsDetail.Execute_InitialButtonConfiguration();

                // Get List, Async Get
                if (_category.Trim() != "")
                {
                    ieiVM.Get_InvExpItems_byCategory_Async(_category);
                    uc_InvExpItemsList.LabelBanner.Content = "Inventory Expense Items List (" + _category + ")";
                }
                else
                {
                    ieiVM.Get_InvExpItems_Async();
                    uc_InvExpItemsList.LabelBanner.Content = "Inventory Expense Items List";
                }
            };



            // ADD Enable Blank
            uc_InvExpItemsDetail.OnInvExpItems_ADDEnable_Blank += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Invoice Expense Items
                ieiVM.Get_InvExpItems_Async();
                txtInvID.Text = "";
            };



            // ADD
            uc_InvExpItemsDetail.OnInvExpItems_ADD += (o, e) =>
            {
                // display message
                labelStatus.Content = "";
                _invID = txtInvID.Text.Trim();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Invoice Expense Items
                if (_invID.Trim() == "")
                {
                    ieiVM.Get_InvExpItems_Async();
                    txtInvID.Text = "";
                }
                else
                {
                    ieiVM.Get_InvExpItems_byLIKEInvoiceID_Async(_invID);
                }
            };



            // UPDATE
            uc_InvExpItemsDetail.OnInvExpItems_UPDATE += (o, e) =>
            {
                // display message
                labelStatus.Content = "";
                _invID = txtInvID.Text.Trim();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Invoice Expense Items
                if (_invID.Trim() == "")
                {
                    ieiVM.Get_InvExpItems_Async();
                    txtInvID.Text = "";
                }
                else
                {
                    ieiVM.Get_InvExpItems_byLIKEInvoiceID_Async(_invID);
                }
            };



            // CANCEL
            uc_InvExpItemsDetail.OnInvExpItems_CANCEL += (o, e) =>
                {
                    // display message
                    labelStatus.Content = o.ToString();

                    // turn ON busy Indicator
                    busy_Indicator.IsBusy = true;

                    // redisplay data in grid
                    // Get Async Invoice Expense Items
                    ieiVM.Get_InvExpItems_Async();
                    txtInvID.Text = "";
                };



            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            ieiVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "InvExpItems_List")
                {
                    uc_InvExpItemsList.DataContext = ieiVM.ieivmMod_List;
                    labelStatus.Content = "Retrieved " + ieiVM.ieivmMod_List.Count + " Invoice Expense Items.";
                    
                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;

                    // change key board focus
                    Keyboard.Focus(txtInvID);
                }
            };



            // Telling the ViewModel to retieve data
            ieiVM.Get_InvExpItems_Async();
            labelStatus.Content = "Retrieving data...";
        }

        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // Select records by Invoice ID, SQL LIKE
        private void txtInvID_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _invID = "";
            _invID = txtInvID.Text.Trim();
            
            // display message
            labelStatus.Content = "";
            uc_InvExpItemsDetail.Execute_InitialButtonConfiguration();

            // turn ON busy Indicator
            busy_Indicator.IsBusy = true;

            // get data
            ieiVM.Get_InvExpItems_byLIKEInvoiceID_Async(_invID);
        }
    }
}
