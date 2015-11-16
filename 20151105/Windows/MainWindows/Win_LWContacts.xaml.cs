using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Win_LWContacts.xaml
    /// </summary>
    public partial class Win_LWContacts : Window
    {
        // creating and instance of the ViewModel
        private ViewModel.Contact_ViewModel ccVM = new ViewModel.Contact_ViewModel();
        
        // private Active Status
        private string _ActiveStatus;


        // constructor
        public Win_LWContacts(string ActiveStatus)
        {
            InitializeComponent();
            _ActiveStatus = ActiveStatus;
            Title = _ActiveStatus + " Contacts";
           

            // LISTENER: Selected data changed
            // Handle on WorkOrder selection changed events
            uc_ContactList.OnContact_SELECTED += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_ClientContacts_Model) == false) return;

                lw_ClientContacts_Model selectedContent = (lw_ClientContacts_Model)itm;

                uc_ContactDetail.DataContext = selectedContent;

                uc_ContactDetail.Execute_UpdateButtonConfiguration();
                labelStatus.Content = "Contact ID: " + selectedContent.ID;
            };




            // LISTENER: Cancel
            uc_ContactDetail.OnContact_CANCEL += (o, e) =>
            {
                labelStatus.Content = o.ToString();
            };



            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            ccVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "Contact_List")
                {
                    uc_ContactList.DataContext = ccVM.ccvmMod_List;
                    labelStatus.Content = "Retrieved " + ccVM.ccvmMod_List.Count + " " + _ActiveStatus + " Contacts.";
                    
                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;
                }
            };

            // Telling the ViewModel to retieve data
            ccVM.Get_ContactList_Async(_ActiveStatus);
            labelStatus.Content = "Retrieving data...";
        }

        // menu Exit Point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        // Method to copy List<T>
        private List<lw_ClientContacts_Model> CopyList(List<lw_ClientContacts_Model> ccml)
        {
            List<lw_ClientContacts_Model> ccl2 = new List<lw_ClientContacts_Model>();

            // adding to new List<T>
            foreach(lw_ClientContacts_Model ccMod in ccml)
            {
                ccl2.Add(ccMod);
            }

            // return List<T>
            return ccl2;
        }


        // Search Client Contacts by Last Name
        private void txtSearchLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string strLN = txtSearchLastName.Text.Trim();

            // display message
            labelStatus.Content = "";

            // turn ON busy Indicator
            busy_Indicator.IsBusy = true;

            // reset and initial button
            uc_ContactDetail.Execute_InitialButtonConfiguration();

            // search by last name
            ccVM.Get_ContactList_byLIKELastName_Async(_ActiveStatus, strLN);
        }
    }
}