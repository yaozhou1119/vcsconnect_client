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
// worker
using VcsConnect_Client.Workers.SQL_Workers;

namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_Employees_Detail.xaml
    /// </summary>
    public partial class uc_Employees_Detail : UserControl
    {
        // ViewModel
        ViewModel.Employees_ViewModel viewModel = new ViewModel.Employees_ViewModel();

        // routed Event Handlers
        public RoutedEventHandler OnEmployee_ADD;
        public RoutedEventHandler OnEmployee_CANCEL;
        public RoutedEventHandler OnEmployee_DELETE;
        public RoutedEventHandler OnEmployee_UPDATE;

        // worker
        private lw_Employees_Worker EWkr;

        // constructor
        public uc_Employees_Detail()
        {
            InitializeComponent();

            // worker
            EWkr = new lw_Employees_Worker();

            // load combo box
            loadComboBox_StateNames();

            // property changed event handler (delegate)
            viewModel.PropertyChanged += viewModel_PropertyChanged;
        }


        // LISTENER: ViewModel Property Change 
        void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // this is the view model property listener. This is called whenever a property
            // in the view model changes. To know what property changed we can use e.PropertyName
            busyIndicator.IsBusy = false;
            IsEnabled = true;

            // reset fields and Buttons
            ResetDisplayFields();
            InitialButtonConfiguration();

            // Async ADD
            if (e.PropertyName == "AddResult")
            {
                // update event
                sender = viewModel.AddResult;
                if (OnEmployee_ADD != null) OnEmployee_ADD(sender, new RoutedEventArgs());
            }

            // Async Update
            if (e.PropertyName == "UpdateResult")
            {
                // update event
                sender = viewModel.UpdateResult;
                if (OnEmployee_UPDATE != null) OnEmployee_UPDATE(sender, new RoutedEventArgs());
            }

            // Async Delete: DeleteResult
            if (e.PropertyName == "DeleteResult")
            {
                // update event
                sender = viewModel.DeleteResult;
                if (OnEmployee_UPDATE != null) OnEmployee_UPDATE(sender, new RoutedEventArgs());
            }
        }

       


        // Add with copy
        private void buttonADD_Enable_Copy_Click(object sender, RoutedEventArgs e)
        {
            // leave data context in tact
            ADDButtonConfiguration();
        }


        // Add with Blank
        private void buttonADD_Enable_Blank_Click(object sender, RoutedEventArgs e)
        {
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lw_Employees_Model();

            // set the UI
            ResetDisplayFields();
            ADDButtonConfiguration();
        }


        // ADD Record Event
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            // get the data from the dataContext 
            // and load into model
            lw_Employees_Model eMod = (lw_Employees_Model)DataContext;

            // Async ADD record using viewModel
            viewModel.Add_Employees_Async(eMod);

            // disable this control while we are updating. 
            IsEnabled = false;

            // Busy Indicator
            busyIndicator.BusyContent = "Adding Employee Record...";
            busyIndicator.IsBusy = true;
        }



        // UPDATE Record Event
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            // get the data from the dataContext 
            // and load into model
            lw_Employees_Model eMod = (lw_Employees_Model)DataContext;

            // Async Update record using viewModel
            viewModel.Update_Employees_Async(eMod);

            // disable this control while we are updating. 
            IsEnabled = false;

            // Busy Indicator
            busyIndicator.BusyContent = "Updating Employee Record...";
            busyIndicator.IsBusy = true;
        }



        // CANCEL Event
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            // reset fields and initial button configuration
            ResetDisplayFields();
            InitialButtonConfiguration();

            // CANCEL Event
            if (OnEmployee_CANCEL != null) OnEmployee_CANCEL(sender, new RoutedEventArgs());
        }



        // DELETE
        private void buttonDELETE_Click(object sender, RoutedEventArgs e)
        {
            // processing the delete reques
            lw_Employees_Worker EWkr = new lw_Employees_Worker();
            MessageBoxResult result;

            result = MessageBox.Show("You are about to Delete a record.\nDo you want to continue?", "Delete",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (MessageBoxResult.OK == result)
            {
                // get the data from the dataContext 
                // and load into model
                lw_Employees_Model eMod = (lw_Employees_Model)DataContext;

                if (eMod.ID > 0)
                {
                    // Async DELETE record using viewModel
                    viewModel.Delete_Employees_Async(eMod);
                    // reset
                    ResetDisplayFields();

                    // initial button config
                    InitialButtonConfiguration();

                    // disable this control while we are updating. 
                    IsEnabled = false;

                    // Busy Indicator
                    busyIndicator.BusyContent = "Deleting Employee Record...";
                    busyIndicator.IsBusy = true;
                }
            }
        }



        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }


        // Get List of State Names
        private void loadComboBox_StateNames()
        {
            lwdom_StateName_Worker DSNWkr = new lwdom_StateName_Worker();
            List<string> sn_List = new List<string>();

            // build list
            sn_List = DSNWkr.Get_StateName_stringList();
            
            // return list of state names
            cboEmpState.ItemsSource = sn_List;
        }


        // Execute UpdateButtonConfig coming from outside
        public void Execute_UpdateButtonConfiguration()
        {
            UpdateButtonConfiguration();
        }



        // Execute ADDButtonConfig coming from outside
        public void Execute_ADDButtonConfiguration()
        {
            ResetDisplayFields();
            ADDButtonConfiguration();
        }



        // Execute Reset Configuration
        public void Execute_ResetConfiguration()
        {
            ResetDisplayFields();
            InitialButtonConfiguration();
        }



        // initial button configuration
        private void InitialButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDELETE.Visibility = Visibility.Hidden;
            //
            buttonADD_Enable_Copy.IsEnabled = false;
            buttonADD_Enable_Blank.IsEnabled = true;
            //
            DisableDisplayFields();
        }


        // ADD button configuration
        private void ADDButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Visible;
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDELETE.Visibility = Visibility.Hidden;
            //
            buttonADD_Enable_Copy.IsEnabled = false;
            buttonADD_Enable_Blank.IsEnabled = false;
            //
            EnableDisplayFields();
        }



        // Update button configuration
        private void UpdateButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Visible;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDELETE.Visibility = Visibility.Visible;
            //
            buttonADD_Enable_Copy.IsEnabled = true;
            buttonADD_Enable_Blank.IsEnabled = true;
            //
            EnableDisplayFields();
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            lblID.Content = "";
            lblEmpID.Content = "";
            txtEmpLN.Text = "";
            txtEmpFN.Text = "";
            txtEmpAdd1.Text = "";
            txtEmpAdd2.Text = "";
            txtEmpTown.Text = "";
            cboEmpState.Text = "";
            txtEmpZip.Text = "";
            txtEmpHomePhone.Text = "";
            txtEmpCellPhone.Text = "";
            txtEmpEmail.Text = "";
            txtComment.Text = "";
            cboActive.Text = "";
            txtEmpWorkCell.Text = "";
            // rich text
            txtEmpNotes.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            txtEmpLN.IsEnabled = false;
            txtEmpFN.IsEnabled = false;
            txtEmpAdd1.IsEnabled = false;
            txtEmpAdd2.IsEnabled = false;
            txtEmpTown.IsEnabled = false;
            cboEmpState.IsEnabled = false;
            txtEmpZip.IsEnabled = false;
            txtEmpHomePhone.IsEnabled = false;
            txtEmpCellPhone.IsEnabled = false;
            txtEmpEmail.IsEnabled = false;
            txtComment.IsEnabled = false;
            cboActive.IsEnabled = false;
            txtEmpWorkCell.IsEnabled = false;
            txtEmpNotes.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtEmpLN.IsEnabled = true;
            txtEmpFN.IsEnabled = true;
            txtEmpAdd1.IsEnabled = true;
            txtEmpAdd2.IsEnabled = true;
            txtEmpTown.IsEnabled = true;
            cboEmpState.IsEnabled = true;
            txtEmpZip.IsEnabled = true;
            txtEmpHomePhone.IsEnabled = true;
            txtEmpCellPhone.IsEnabled = true;
            txtEmpEmail.IsEnabled = true;
            txtComment.IsEnabled = true;
            cboActive.IsEnabled = true;
            txtEmpWorkCell.IsEnabled = true;
            txtEmpNotes.IsEnabled = true;
        }
    }
}
