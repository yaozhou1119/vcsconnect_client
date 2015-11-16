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
// model
using VcsConnect_Client.Models.SQL_Models;
// worker
using VcsConnect_Client.Workers.SQL_Workers;

namespace VcsConnect_Client.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for Win_LWClient.xaml
    /// </summary>
    public partial class Win_LWClient : Window
    {
        // worker
        private lw_Bids_Worker BWkr;
        private lw_Client_Worker LWCWkr;
        private lw_ClientContact_Worker LWCCWkr;
        private lw_ClientLocations_Worker LWCLWkr;
        private lw_Invoice_Worker INVWkr;
        private lw_WorkOrders_Worker WOWkr;

        // creating and instance of the ViewModel
        private ViewModel.Client_ViewModel clVM = new ViewModel.Client_ViewModel();

        private string strMsg;
        private string _ActiveStatus;

        // constructor
        public Win_LWClient(string ActiveStatus)
        {
            InitializeComponent();
            strMsg = "";
            _ActiveStatus = ActiveStatus;
            Title = _ActiveStatus + " Clients";

            // worker
            BWkr = new lw_Bids_Worker();
            LWCWkr = new lw_Client_Worker();
            LWCCWkr = new lw_ClientContact_Worker();
            LWCLWkr = new lw_ClientLocations_Worker();
            INVWkr = new lw_Invoice_Worker();
            WOWkr = new lw_WorkOrders_Worker();
            

            // LISTENER: Selected data changed
            // Handle on Client selection changed events
            uc_ClientsList.OnClient_SelectedChanged += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_Client_Model) == false) return;
                strMsg = "";

                lw_Client_Model selectedContent = (lw_Client_Model)itm;

                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientDetail.DataContext = selectedContent;

                labelStatus.Content = "Client Account Number: " + selectedContent.AccNum;
                Int64 numID = selectedContent.AccNum;

                // display ClientContact list 
                List<lw_ClientContacts_Model> ccMod_List = LWCCWkr.Get_ClientContactsByAccNum_List(numID);
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientContactList.DataContext = ccMod_List;

                // display clientlocation list 
                List<lw_ClientLocations_Model> lwclMod_List = LWCLWkr.Get_ClientLocation_ByAccNum_List(numID);
                uc_ClientAssocTblDisplay.uc_ClientsLocationList.DataContext = lwclMod_List;

                // display Bids based on AccNum, list 
                List<lw_Bids_Model> lwbMod_List = BWkr.Get_Bids_ByAccNum_List(numID);
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_BidsList.DataContext = lwbMod_List;

                // display WorkOrders based on AccNum, list 
                List<lw_WorkOrder_Model> woMod_List_accnNum = WOWkr.Get_WorkerOrders_AccNum_List(numID);
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_WOList.DataContext = woMod_List_accnNum;

                // display Invoices based on AccNum, list 
                List<lw_Invoice_Model> iMod_List_accnNum = INVWkr.Get_Invoice_ByAccNum_List(numID);
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_InvList.DataContext = iMod_List_accnNum;

                // change to an Update configuration
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientDetail.Execute_UpdateButtonConfiguration();
            };



            // LISTENER: OnClientLocation_SELECTED 
            // Handle on selection changed events
            uc_ClientAssocTblDisplay.uc_ClientsLocationList.OnClientLocation_SELECTED += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_ClientLocations_Model) == false) return;
                strMsg = "";

                lw_ClientLocations_Model selectedContent = (lw_ClientLocations_Model)itm;

                string strClLocID = selectedContent.ClientLocationID;
                
                // display Contacts based on ClientLocationID, list 
                List<lw_ClientContacts_Model> ccMod_List_contact = LWCCWkr.Get_ClientContacts_ByLocationId_List(strClLocID);
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientContactList.DataContext = ccMod_List_contact;

                // display Bids based on ClientLocationID, list 
                List<lw_Bids_Model> lwbMod_List_clLocID = BWkr.Get_Bids_ByClientLocation_List(strClLocID);
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_BidsList.DataContext = lwbMod_List_clLocID;

                // display WorkOrders based on LocationID, list 
                List<lw_WorkOrder_Model> woMod_List_LocID = WOWkr.Get_WorkerOrders_ByLocationID_List(strClLocID);
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_WOList.DataContext = woMod_List_LocID;

                // display Invoices based on BillLocation, list 
                List<lw_Invoice_Model> iMod_List_LocID = INVWkr.Get_Invoice_ByBillLocation_List(strClLocID);
                uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_InvList.DataContext = iMod_List_LocID;
            };



            // LISTENER: ADD Enabled
            uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientDetail.OnClient_CANCEL += (o, e) =>
            {
                labelStatus.Content = "ADD is Enabled.";
                // Display Client List
                List<lw_Client_Model> cMod_List_ae = LWCWkr.Get_Client_List(ref strMsg, _ActiveStatus);
                uc_ClientsList.DataContext = cMod_List_ae;
            };



            // LISTENER: CANCEL
            uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientDetail.OnClient_CANCEL += (o, e) =>
            {
                // Not necessary to redisplay data to grid.
                // Grid paramater has been set: IsReadOnly="True";
                labelStatus.Content = "Canceled.";
            };



            // LISTENER: DELETE
            uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientDetail.OnClient_DELETE += (o, e) =>
            {
                labelStatus.Content = o.ToString();
                // Display Client List
                List<lw_Client_Model> cMod_List_del = LWCWkr.Get_Client_List(ref strMsg, _ActiveStatus);
                uc_ClientsList.DataContext = cMod_List_del;

                // 
            };



            // LISTENER: ADD
            uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientDetail.OnClient_ADD += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();
                // Display Client List
                List<lw_Client_Model> cMod_List_add = LWCWkr.Get_Client_List(ref strMsg, _ActiveStatus);
                uc_ClientsList.DataContext = cMod_List_add;
            };



            // LISTENER: UPDATE
            uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientDetail.OnClient_UPDATE += (o, e) =>
            {
                labelStatus.Content = o.ToString();
                // Display Client List
                List<lw_Client_Model> cMod_List_upd = LWCWkr.Get_Client_List(ref strMsg, _ActiveStatus);
                uc_ClientsList.DataContext = cMod_List_upd;
            };



            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            clVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "Client_List")
                {
                    uc_ClientsList.DataContext = clVM.cvmMod_List;
                    labelStatus.Content = "Retrieved " + clVM.cvmMod_List.Count + " Clients.";

                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;

                    // change key board focus
                    Keyboard.Focus(txtSearchClientName);
                }
            };

            // Telling the ViewModel to retieve data
            clVM.Get_Clients_Async(_ActiveStatus);
            labelStatus.Content = "Retrieving data...";
        }  // end of constructor        
            

        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        // Select Clients by Name search
        private void txtSearchClientName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string clName = txtSearchClientName.Text.Trim();

            // display message
            labelStatus.Content = "";

            // turn ON busy Indicator
            busy_Indicator.IsBusy = true;

            clVM.Get_Clients_LIKEName_Async(_ActiveStatus, clName);
        }
    }
}
