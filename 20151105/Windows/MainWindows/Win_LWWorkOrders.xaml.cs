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
    /// Interaction logic for Win_LWWorkOrders.xaml
    /// </summary>
    public partial class Win_LWWorkOrders : Window
    {
        // worker
        private lw_WorkOrders_Worker WOWkr;

        // creating and instance of the ViewModel
        private ViewModel.WorkOrders_ViewModel woVM = new ViewModel.WorkOrders_ViewModel();

        // private ClientName string
        private string _clientName;
        
        // constructor
        public Win_LWWorkOrders()
        {
            InitializeComponent();
            _clientName = "";

            // Workers
            WOWkr = new lw_WorkOrders_Worker();

            // LISTENER: Selected data changed
            // Handle on WorkOrder selection changed events
            uc_WOList.OnWorkOrder_SELECTED += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_WorkOrder_Model) == false) return;

                lw_WorkOrder_Model selectedContent = (lw_WorkOrder_Model)itm;

                uc_WODetail.DataContext = selectedContent;

                uc_WODetail.Execute_UpdateButtonConfiguration();
                labelStatus.Content = "WorkOrder ID: " + selectedContent.ID;
            };



            // LISTENER: Selected Date Change
            // Handle on WorkOrder OnSelectedDate_SELECTED event
            uc_WOList.OnSelectedDate_SELECTED += (o, e) =>
            {
                // turn off busy Indicator
                busy_Indicator.IsBusy = true;

                string strDate = o.ToString();
                woVM.Get_WorkOrdersByDate_Async(strDate);

                labelStatus.Content = "Retrieving data...";
            };



            // LISTENER: ADD Enabled
            // Used for both Blank and Copy
            uc_WODetail.OnWorkOrder_ADDEnabel += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();
            };



            // LISTENER: ADD
            uc_WODetail.OnWorkOrder_ADD += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                _clientName = "";
                if (txtCLName.Text != null) _clientName = txtCLName.Text.Trim();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Work Order List
                if (_clientName.Trim() != "")
                {
                    woVM.Get_WorkOrders_LIKEClientName_Async(_clientName);
                }
                else
                {
                    woVM.Get_WorkOrders_Async();
                    txtCLName.Text = "";
                }
            };



            // LISTENER: UPDATE
            uc_WODetail.OnWorkOrder_UPDATE += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                _clientName = "";
                if (txtCLName.Text != null) _clientName = txtCLName.Text.Trim();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Work Order List
                if (_clientName.Trim() != "")
                {
                    woVM.Get_WorkOrders_LIKEClientName_Async(_clientName);
                }
                else
                {
                    woVM.Get_WorkOrders_Async();
                    txtCLName.Text = "";
                }
            };




            // LISTENER: UPDATE
            uc_WODetail.OnWorkOrder_DELETE += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                _clientName = "";
                if (txtCLName.Text != null) _clientName = txtCLName.Text.Trim();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Work Order List
                if (_clientName.Trim() != "")
                {
                    woVM.Get_WorkOrders_LIKEClientName_Async(_clientName);
                }
                else
                {
                    woVM.Get_WorkOrders_Async();
                    txtCLName.Text = "";
                }
            };



            // LISTENER: CANCELED
            uc_WODetail.OnWorkOrder_CANCEL += (o, e) =>
            {
                // display message
                labelStatus.Content = "";

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Chem List
                woVM.Get_WorkOrders_Async();
                txtCLName.Text = "";
            };




            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            woVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "WOList")
                {
                    uc_WOList.DataContext = woVM.wovmMod_List;
                    labelStatus.Content = "Retrieved " + woVM.wovmMod_List.Count + " Work Orders.";

                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;

                    // change key board focus
                    Keyboard.Focus(txtCLName);
                }
            };

            // Telling the ViewModel to retieve data
            woVM.Get_WorkOrders_Async();
            labelStatus.Content = "Retrieving data...";
        } // end of constructor


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        // Select Work Orders by LIKE Client Name
        private void txtCLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string clName = txtCLName.Text.Trim();

            // display message
            labelStatus.Content = "";

            // turn ON busy Indicator
            busy_Indicator.IsBusy = true;

            // reset detail fields
            uc_WODetail.Execute_InitialButtonConfiguration();

            // get data
            woVM.Get_WorkOrders_LIKEClientName_Async(clName);
        }
    }
}
