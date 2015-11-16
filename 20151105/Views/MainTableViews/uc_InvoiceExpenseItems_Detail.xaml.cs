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
    /// Interaction logic for uc_InvoiceExpenseItems_Detail.xaml
    /// </summary>
    public partial class uc_InvoiceExpenseItems_Detail : UserControl
    {
        // creating and instance of the ViewModel
        private ViewModel.InvoiceItemExpense_ViewModel iieVM = new ViewModel.InvoiceItemExpense_ViewModel();

        // routed event Handlers
        public RoutedEventHandler OnInvExpItems_ADD;
        public RoutedEventHandler OnInvExpItems_ADDEnable_Blank;
        public RoutedEventHandler OnInvExpItems_ADDEnable_Copy;
        public RoutedEventHandler OnInvExpItems_CANCEL;
        public RoutedEventHandler OnInvExpItems_UPDATE;

        // constructor
        public uc_InvoiceExpenseItems_Detail()
        {
            InitializeComponent();

            // reset and initialize buttons
            ResetDisplayFields();
            InitialButtonConfiguration();

            // view model
            iieVM.PropertyChanged += viewModel_PropertyChanged;
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
                sender = iieVM.AddResult;
                if (OnInvExpItems_ADD != null) OnInvExpItems_ADD(sender, new RoutedEventArgs());
            }

            if (e.PropertyName == "UpdateResult")
            {
                // update Event
                sender = iieVM.UpdateResult;
                if (OnInvExpItems_UPDATE != null) OnInvExpItems_UPDATE(sender, new RoutedEventArgs());
            }
        }


        // ADD Enable - COPY 
        private void buttonADD_Enable_Copy_Click(object sender, RoutedEventArgs e)
        {
            // ADD button configuration
            ADDButtonConfiguration();
        }


        // ADD Enable - with all blank fields
        private void buttonADD_Enable_Blank_Click(object sender, RoutedEventArgs e)
        {
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lw_InvoiceExpenseItems_Model();

            // reset and add configuration
            ResetDisplayFields();
            ADDButtonConfiguration();

            // Add enabled event
            if (OnInvExpItems_ADDEnable_Blank != null) OnInvExpItems_ADDEnable_Blank(sender, new RoutedEventArgs());
        }


        // ADD
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lw_InvoiceExpenseItems_Model ieiMod = new lw_InvoiceExpenseItems_Model();

            // load the model
            ieiMod = (lw_InvoiceExpenseItems_Model)this.DataContext;

            // MVVM async ADD
            iieVM.Add_InvExpItems_Async(ieiMod);

            // reset fields
            ResetDisplayFields();

            // use inital button configuration
            InitialButtonConfiguration();
        }


        // UPDATE
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lw_InvoiceExpenseItems_Model ieiMod = new lw_InvoiceExpenseItems_Model();
            
            // load the model
            ieiMod = (lw_InvoiceExpenseItems_Model)this.DataContext;

            // MVVM async Update
            iieVM.Update_InvExpItems_Async(ieiMod);

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

            // cancel event
            if (OnInvExpItems_CANCEL != null) OnInvExpItems_CANCEL(sender, new RoutedEventArgs());
        }


        private void buttonDELETE_Click(object sender, RoutedEventArgs e)
        {

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
            txtWOID.Text = "";
            txtInvoiceID.Text = "";
            cboCategory.Text = "";
            txtExpName.Text = "";
            txtRate.Text = "";
            txtCost.Text = "";
            txtTotHours.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            txtWOID.IsEnabled = false;
            cboCategory.IsEnabled = false;
            txtExpName.IsEnabled = false;
            txtRate.IsEnabled = false;
            txtCost.IsEnabled = false;
            txtTotHours.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtWOID.IsEnabled = true;
            cboCategory.IsEnabled = true;
            txtExpName.IsEnabled = true;
            txtRate.IsEnabled = true;
            txtCost.IsEnabled = true;
            txtTotHours.IsEnabled = true;
        }
    }
}
