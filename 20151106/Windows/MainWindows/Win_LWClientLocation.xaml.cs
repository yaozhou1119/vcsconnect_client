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

namespace VcsConnect_Client.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for Win_LWClientLocation.xaml
    /// </summary>
    public partial class Win_LWClientLocation : Window
    {
        // instantiate View Model
        ViewModel.ClientLocation_ViewModel clVM = new ViewModel.ClientLocation_ViewModel();

        // constructor
        public Win_LWClientLocation()
        {
            InitializeComponent();


            // LISTENER: Selected data changed
            // Handle on Client Locations selection 
            // changed events
            uc_ClientLocationList.OnClientLocation_SELECTED += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_ClientLocations_Model) == false) return;

                lw_ClientLocations_Model selectedContent = (lw_ClientLocations_Model)itm;

                uc_ClientLocationDetail.DataContext = selectedContent;

                uc_ClientLocationDetail.Execute_UpdateButtonConfiguration();
                labelStatus.Content = "Client Location ID: " + selectedContent.ID;
            };


            // LISTENER: ADD Enable
            uc_ClientLocationDetail.OnClientLocation_ADDEnable += (o, e) =>
                {
                    labelStatus.Content = o.ToString();
                };


            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            clVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "ClientLocations_List")
                {
                    uc_ClientLocationList.DataContext = clVM.clMod_List;
                    labelStatus.Content = "Retrieved " + clVM.clMod_List.Count + " Client Locations.";

                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;

                    // change key board focus
                    Keyboard.Focus(txtNameSrch);
                }
            };


            // Telling the ViewModel to retieve data
            clVM.Get_ClientLocations_Async();
            labelStatus.Content = "Retrieving data...";
        } // end of constructor


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // select by Client Name change
        private void txtNameSrch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // client name
            string clName = txtNameSrch.Text.Trim();

            // display message
            labelStatus.Content = "";

            // turn ON busy Indicator
            busy_Indicator.IsBusy = true;

            // reset and initial button
            //uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientDetail.Execute_InitialConfiguration();
            //uc_ClientAssocTblDisplay.uc_ClientsLocationList.DataContext = null;
            //uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_InvList.DataContext = null;
            //uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_BidsList.DataContext = null;
            //uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_WOList.DataContext = null;
            //uc_ClientAssocTblDisplay.uc_ClientTabControlRef.uc_ClientContactList.DataContext = null;

            // get data based on search
            clVM.Get_ClientLocations_LIKEName_Async(clName);
        }
    }
}
