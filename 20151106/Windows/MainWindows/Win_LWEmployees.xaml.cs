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

namespace VcsConnect_Client.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for Win_LWEmployees.xaml
    /// </summary>
    public partial class Win_LWEmployees : Window
    {
        // creating and instance of the ViewModel
        private ViewModel.Employees_ViewModel eVM = new ViewModel.Employees_ViewModel();

        // private string
        private string _activeStatus;

        // constructor
        public Win_LWEmployees(string activeStatus)
        {
            InitializeComponent();
            _activeStatus = activeStatus;
            this.Title = _activeStatus + " Employees";



            // LISTENER: ADD
            uc_EmployeeDetail.OnEmployee_ADD += (o, e) =>
            {
                // turn off busy Indicator
                busy_Indicator.IsBusy = true;

                // list data
                // Telling the ViewModel to retieve data
                eVM.Get_EmployeesList_Async(_activeStatus);
                labelStatus.Content = "Retrieving data...";
            };



            // LISTENER: UPDATE
            uc_EmployeeDetail.OnEmployee_UPDATE += (o, e) =>
            {
                // turn off busy Indicator
                busy_Indicator.IsBusy = true;

                // list data
                // Telling the ViewModel to retieve data
                eVM.Get_EmployeesList_Async(_activeStatus);
                labelStatus.Content = "Retrieving data...";
            };



            // LISTENER: CANCEL
            uc_EmployeeDetail.OnEmployee_CANCEL += (o, e) =>
            {
                // turn off busy Indicator
                busy_Indicator.IsBusy = true;

                // list data
                // Telling the ViewModel to retieve data
                eVM.Get_EmployeesList_Async(_activeStatus);
                labelStatus.Content = "Retrieving data...";
            };



            // LISTENER: DELETE
            uc_EmployeeDetail.OnEmployee_DELETE += (o, e) =>
            {
                // turn off busy Indicator
                busy_Indicator.IsBusy = true;

                // list data
                // Telling the ViewModel to retieve data
                eVM.Get_EmployeesList_Async(_activeStatus);
                labelStatus.Content = "Retrieving data...";
            };



            // LISTENER: Selected data changed
            // Handle on Employee selection changed events
            uc_EmpList.OnEmployee_SELECTED += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_Employees_Model) == false) return;

                lw_Employees_Model selectedContent = (lw_Employees_Model)itm;

                uc_EmployeeDetail.DataContext = selectedContent;

                uc_EmployeeDetail.Execute_UpdateButtonConfiguration();
                labelStatus.Content = "Contact ID: " + selectedContent.ID;
            };


            // LISTENER: CANCEL
            uc_EmployeeDetail.OnEmployee_CANCEL += (o, e) =>
            {
                // clear message
                labelStatus.Content = "";
            };


            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            eVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "Employees_List")
                {
                    uc_EmpList.DataContext = eVM.evmMod_List;
                    labelStatus.Content = "Retrieved " + eVM.evmMod_List.Count + " " + _activeStatus + " Employees.";
                    
                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;
                }
            };


            // Telling the ViewModel to retieve data
            eVM.Get_EmployeesList_Async(_activeStatus);
            labelStatus.Content = "Retrieving data...";
        } // end of constructory

        // menu exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
