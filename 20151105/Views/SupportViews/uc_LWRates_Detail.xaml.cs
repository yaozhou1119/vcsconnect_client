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

namespace VcsConnect_Client.Views.SupportViews
{
    /// <summary>
    /// Interaction logic for uc_LWRates_Detail.xaml
    /// </summary>
    public partial class uc_LWRates_Detail : UserControl
    {
        // create the viewModel 
        ViewModel.Rates_ViewModel viewModel = new ViewModel.Rates_ViewModel();


        // routed event handlers
        public RoutedEventHandler OnRates_ADDEnable;
        public RoutedEventHandler OnRates_ADD;
        public RoutedEventHandler OnRates_CANCEL;
        public RoutedEventHandler OnRates_DELETE;
        public RoutedEventHandler OnRates_UPDATE;

        // worker
        lwdom_Rates_Worker LWRWkr;

        // constructor
        public uc_LWRates_Detail()
        {
            InitializeComponent();

            // worker
            LWRWkr = new lwdom_Rates_Worker();

            // load combo box
            LoadRateID_Combobox();

            // reset and initialize
            ResetDisplayFields();
            InitialButtonConfiguration();

            // view model
            viewModel.PropertyChanged += viewModel_PropertyChanged;
        }


        // Delegate was build by Visual Studio on TAB click prompt.
        void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // this is the view model property listener. This is called whenever a property
            // in the view model changes. To know what property changed we can use e.PropertyName
            busyIndicator.IsBusy = false;
            IsEnabled = true;

            // reset fields
            ResetDisplayFields();
            InitialButtonConfiguration();

            if (e.PropertyName == "AddResult")
            {
                // ADD Event
                sender = viewModel.AddResult;
                if (OnRates_ADD != null) OnRates_ADD(sender, new RoutedEventArgs());
            }

            if (e.PropertyName == "UpdateResult")
            {
                // update Event
                sender = viewModel.UpdateResult;
                if (OnRates_UPDATE != null) OnRates_UPDATE(sender, new RoutedEventArgs());
            }
        }

        

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }



        // ADD Record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lwdom_Rates_Model rMod = new lwdom_Rates_Model();

            // load the model
            rMod = (lwdom_Rates_Model)this.DataContext;

            // async ADD
            viewModel.Add_Rate_Async(rMod);

            // reset fields
            ResetDisplayFields();

            // use inital button configuration
            InitialButtonConfiguration();
        }


        // UPDATE Record
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lwdom_Rates_Model lwrMod = new lwdom_Rates_Model();

            // load the model
            lwrMod = (lwdom_Rates_Model)this.DataContext;

            // async Update
            viewModel.Update_Rates_Async(lwrMod);

            // reset fields
            ResetDisplayFields();

            // use inital button configuration
            InitialButtonConfiguration();
        }



        // CANCEL
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            InitialButtonConfiguration();

            // Cancel Event
            if (OnRates_CANCEL != null) OnRates_CANCEL(sender, new RoutedEventArgs());
        }



        // DELETE record
        private void buttonDELETE_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            Int64 recID = 0;
            bool boolResult = false;

            result = MessageBox.Show("You are about to Delete a record.\nDo you want to continue?", "Delete",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            string strMsg = "";

            if (MessageBoxResult.OK == result)
            {
                boolResult = Int64.TryParse(lblID.Content.ToString(), out recID);
                if (recID > 0)
                {
                    strMsg = LWRWkr.Delete_Rates_rec(recID);
                }
                else
                {
                    strMsg = "Record ID problem";
                }
            }
            else
            {
                strMsg = "Delete Cancelled.";
            }

            // put message in sender
            sender = strMsg;

            // reset
            ResetDisplayFields();

            // initial button config
            InitialButtonConfiguration();

            // Delete Event
            if (OnRates_DELETE != null) OnRates_DELETE(sender, new RoutedEventArgs());
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



        // Execute InitialButtonConfig coming from outside
        public void Execute_InitialButtonConfiguration()
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
            buttonADD_EnableBlank.IsEnabled = true;
            buttonADD_EnableCopy.IsEnabled = false;
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
            buttonADD_EnableBlank.IsEnabled = false;
            buttonADD_EnableCopy.IsEnabled = false;
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
            buttonADD_EnableBlank.IsEnabled = true;
            buttonADD_EnableCopy.IsEnabled = true;
            //
            EnableDisplayFields();
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            lblID.Content = "";
            cboRateID.Text = "";
            cboCategory.Text = "";
            txtCode.Text = "";
            txtRateYear.Text = "";
            txtDescription.Text = "";
            txtRetailRate.Text = "";
            txtCostRate.Text = "";
            cboActiveStatus.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            cboRateID.IsEnabled = false;
            cboCategory.IsEnabled = false;
            txtCode.IsEnabled = false;
            txtRateYear.IsEnabled = false;
            txtDescription.IsEnabled = false;
            txtRetailRate.IsEnabled = false;
            txtCostRate.IsEnabled = false;
            cboActiveStatus.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            cboRateID.IsEnabled = true;
            cboCategory.IsEnabled = true;
            txtCode.IsEnabled = true;
            txtRateYear.IsEnabled = true;
            txtDescription.IsEnabled = true;
            txtRetailRate.IsEnabled = true;
            txtCostRate.IsEnabled = true;
            cboActiveStatus.IsEnabled = true;
        }

        
        // load the lwdom_RateID into string list
        private void LoadRateID_Combobox()
        {
            List<string> rn_List = new List<string>();
            lwdom_RatesID_Worker LWRIDWkr = new lwdom_RatesID_Worker();

            rn_List = LWRIDWkr.Get_RateName_stringList();
            cboRateID.ItemsSource = rn_List;
        }



        // ADD Enable - using copied Display Fields
        private void buttonADD_EnableCopy_Click(object sender, RoutedEventArgs e)
        {
            // just change to ADD button configuration
            ADDButtonConfiguration();
        }


        // ADD Enable - Blank display fields
        private void buttonADD_EnableBlank_Click(object sender, RoutedEventArgs e)
        {
            // set the data context
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lwdom_Rates_Model();

            ResetDisplayFields();
            ADDButtonConfiguration();
        }
    }
}
