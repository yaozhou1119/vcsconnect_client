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
    /// Interaction logic for uc_Clients_Detail.xaml
    /// </summary>
    public partial class uc_Clients_Detail : UserControl
    {
        // instance of Client View Model
        ViewModel.Client_ViewModel cVM = new ViewModel.Client_ViewModel();

        // worker
        lw_Client_Worker LWCWkr;

        // routed Event handlers
        public RoutedEventHandler OnClient_ADD;
        public RoutedEventHandler OnClient_ADDEnable_Copy;
        public RoutedEventHandler OnClient_ADDEnable_Blank;
        public RoutedEventHandler OnClient_CANCEL;
        public RoutedEventHandler OnClient_DELETE;
        public RoutedEventHandler OnClient_UPDATE;


        // constructor
        public uc_Clients_Detail()
        {
            InitializeComponent();

            // worker
            LWCWkr = new lw_Client_Worker();

            // reset and initialize
            ResetDisplayFields();
            InitialButtonConfiguration();

            // Client View Model (cVM)
            cVM.PropertyChanged += viewModel_PropertyChanged;
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
                sender = cVM.AddResult;
                if (OnClient_ADD != null) OnClient_ADD(sender, new RoutedEventArgs());
            }

            if (e.PropertyName == "UpdateResult")
            {
                // update Event
                sender = cVM.UpdateResult;
                if (OnClient_UPDATE != null) OnClient_UPDATE(sender, new RoutedEventArgs());
            }
        }

        

        // ADD
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lw_Client_Model lwclMod = new lw_Client_Model();
            string strMsg = "";
            string strNum = "";
            bool result = false;
            Int64 intAccNum = 0;

            // get the data from the context and
            // add data to the model
            lw_Client_Model cMod = (lw_Client_Model)DataContext;

            // Instert record
            strMsg = LWCWkr.Add_Client_Rec(cMod); // add new rec
            strNum = LWCWkr.Get_LastIDKey_Used(); // get rec number to be used as AccNum
                        
            // convert string to Int64
            result = Int64.TryParse(strNum, out intAccNum);
            if (intAccNum > 0)
            {
                // load model
                cMod.ID = intAccNum;
                cMod.AccNum = intAccNum;

                // update the accnum in the client
                cVM.Update_Client_Async(cMod);

                // reset and reconfigur
                ResetDisplayFields();
                InitialButtonConfiguration();
            }
            else
            {
                strMsg = "AccNum NOT UPDATED.";
            }
        }



        // update
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lw_Client_Model cMod = new lw_Client_Model();
            
            // load model
            cMod = (lw_Client_Model)this.DataContext;

            // async Update
            cVM.Update_Client_Async(cMod);

            // reset and reconfigure
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // CANCEL
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            InitialButtonConfiguration();

            // Cancel Event
            if (OnClient_CANCEL != null) OnClient_CANCEL(sender, new RoutedEventArgs());
        }


        // DELETE
        private void buttonDELETE_Click(object sender, RoutedEventArgs e)
        {
            lw_Client_Worker LWCWkr = new lw_Client_Worker();
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
                    strMsg = LWCWkr.Delete_Client_rec(recID);
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
            if (OnClient_DELETE != null) OnClient_DELETE(sender, new RoutedEventArgs());
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



        // Execute Reset and Initial Configuration
        public void Execute_InitialConfiguration()
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
            lblAccNum.Content = "";
            txtName.Text = "";
            cboActiveStatus.Text = "";
            txtNote.Text = "";
            txtComments.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            lblAccNum.IsEnabled = false;
            txtName.IsEnabled = false;
            cboActiveStatus.IsEnabled = false;
            txtNote.IsEnabled = false;
            txtComments.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            lblAccNum.IsEnabled = true;
            txtName.IsEnabled = true;
            cboActiveStatus.IsEnabled = true;
            txtNote.IsEnabled = true;
            txtComments.IsEnabled = true;
        }



        // load the Model
        // load model is used on an ADD
        private lw_Client_Model Load_Model()
        {
            lw_Client_Model lwcMod = new lw_Client_Model();
            bool result = false;
            Int64 intNum = 0;

            lwcMod.ID = 0;
            //
            result = Int64.TryParse(lblAccNum.Content.ToString(), out intNum);
            lwcMod.AccNum = (result) ? intNum : 0;
            lwcMod.Name = txtName.Text.Trim();
            lwcMod.ActiveStatus = cboActiveStatus.Text.Trim();
            lwcMod.Note = txtNote.Text.Trim();

            // returne the model
            return lwcMod;
        }


        // ADD Enable - Copy, use fields previously loaded
        private void buttonADD_Enable_Copy_Click(object sender, RoutedEventArgs e)
        {
            // No ResetDisplayFields for a Add Copy
            ADDButtonConfiguration();

            // Add Enable Event
            if (OnClient_ADDEnable_Copy != null) OnClient_ADDEnable_Copy(sender, new RoutedEventArgs());
        }


        // ADD Enable - Blank, all fields start as blank
        private void buttonADD_Enable_Blank_Click(object sender, RoutedEventArgs e)
        {
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lw_Client_Model();

            ResetDisplayFields();
            ADDButtonConfiguration();

            // Add Enable Event
            if (OnClient_ADDEnable_Blank != null) OnClient_ADDEnable_Blank(sender, new RoutedEventArgs());
        }
    }
}
