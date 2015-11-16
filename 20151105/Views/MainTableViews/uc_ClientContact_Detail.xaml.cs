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
// models
using VcsConnect_Client.Models.SQL_Models;
// workers
using VcsConnect_Client.Workers.SQL_Workers;

namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_ClientContact_Detail.xaml
    /// </summary>
    public partial class uc_ClientContact_Detail : UserControl
    {
        // instantial Client Contact View Model
        ViewModel.Contact_ViewModel ccVM = new ViewModel.Contact_ViewModel();

        // Routed Events
        public RoutedEventHandler OnContact_ADD;
        public RoutedEventHandler OnContact_CANCEL;
        public RoutedEventHandler OnContact_UPDATE;

        // worker
        lw_ClientContact_Worker CCWkr;

        // constructor
        public uc_ClientContact_Detail()
        {
            InitializeComponent();

            // worker
            CCWkr = new lw_ClientContact_Worker();

            // initial button condition and reset fields
            ResetDisplayFields();
            InitialButtonConfiguration();

            // view model
            ccVM.PropertyChanged += viewModel_PropertyChanged;
        }


        // Delegate was build by Visual Studio on TAB click prompt.
        private void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
                sender = ccVM.AddResult;
                if (OnContact_ADD != null) OnContact_ADD(sender, new RoutedEventArgs());
            }

            if (e.PropertyName == "UpdateResult")
            {
                // update Event
                sender = ccVM.UpdateResult;
                if (OnContact_UPDATE != null) OnContact_UPDATE(sender, new RoutedEventArgs());
            }
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        

        // ADD Client Contact record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lw_ClientContacts_Model ccMod = new lw_ClientContacts_Model();

            // populate model
            ccMod = (lw_ClientContacts_Model)DataContext;

            // async ADD
            ccVM.Add_Contact_Async(ccMod);

            // reset and initialize button configuration
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // UPDATE Client Contact record
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lw_ClientContacts_Model ccMod = new lw_ClientContacts_Model();

            // populate model
            ccMod = (lw_ClientContacts_Model)DataContext;

            // async Update
            ccVM.Update_Contact_Async(ccMod);

            // reset and initialize button configuration
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // CANCEL
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            // redisplay and initialize
            ResetDisplayFields();
            InitialButtonConfiguration();

            // event
            sender = "Canceled.";
            if (OnContact_CANCEL != null) OnContact_CANCEL(sender, new RoutedEventArgs());
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

        // Execute InitialButtonConfiguration coming from outside
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
            txtAccNum.Text = "";
            txtLocationID.Text = "";
            txtContactTitle.Text = "";
            txtContactFN.Text = "";
            txtContactLN.Text = "";
            txtOffPhone.Text = "";
            txtOffPhoneExt.Text = "";
            txtCellPhone.Text = "";
            txtFaxNum.Text = "";
            txtOthPhone.Text = "";
            txtEmail.Text = "";
            //
            cboActiveStatus.Text = "";
            txtComments.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            lblID.IsEnabled = false;
            txtAccNum.IsEnabled = false;
            txtLocationID.IsEnabled = false;
            txtContactTitle.IsEnabled = false;
            txtContactFN.IsEnabled = false;
            txtContactLN.IsEnabled = false;
            txtOffPhone.IsEnabled = false;
            txtOffPhoneExt.IsEnabled = false;
            txtCellPhone.IsEnabled = false;
            txtFaxNum.IsEnabled = false;
            txtOthPhone.IsEnabled = false;
            txtEmail.IsEnabled = false;
            //
            cboActiveStatus.IsEnabled = false;
            txtComments.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            lblID.IsEnabled = true;
            txtAccNum.IsEnabled = true;
            txtLocationID.IsEnabled = true;
            txtContactTitle.IsEnabled = true;
            txtContactFN.IsEnabled = true;
            txtContactLN.IsEnabled = true;
            txtOffPhone.IsEnabled = true;
            txtOffPhoneExt.IsEnabled = true;
            txtCellPhone.IsEnabled = true;
            txtFaxNum.IsEnabled = true;
            txtOthPhone.IsEnabled = true;
            txtEmail.IsEnabled = true;
            //
            cboActiveStatus.IsEnabled = true;
            txtComments.IsEnabled = true;
        }


        // Enable Add and copy
        private void buttonADD_Enable_Copy_Click(object sender, RoutedEventArgs e)
        {
            // set the UI
            ADDButtonConfiguration();
        }


        // Enable Add no copy
        private void buttonADD_Enable_Blank_Click(object sender, RoutedEventArgs e)
        {
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lw_ClientContacts_Model();

            // set the UI
            ResetDisplayFields();
            ADDButtonConfiguration();
        }
    }
}
