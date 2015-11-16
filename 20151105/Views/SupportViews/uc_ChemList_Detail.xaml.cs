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

namespace VcsConnect_Client.Views.SupportViews
{
    /// <summary>
    /// Interaction logic for uc_ChemList_Detail.xaml
    /// </summary>
    public partial class uc_ChemList_Detail : UserControl
    {
        // create the viewModel 
        ViewModel.ChemList_ViewModel clVM = new ViewModel.ChemList_ViewModel();

        // routed events
        public RoutedEventHandler OnChemList_ADDEnabel;
        public RoutedEventHandler OnChemList_ADD;
        public RoutedEventHandler OnChemList_CANCEL;
        public RoutedEventHandler OnChemList_DELETE;
        public RoutedEventHandler OnChemList_UPDATE;

        // constructor
        public uc_ChemList_Detail()
        {
            InitializeComponent();

            //
            ResetDisplayFields();
            InitialButtonConfiguration();

            // view model
            clVM.PropertyChanged += viewModel_PropertyChanged;
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
                sender = clVM.AddResult;
                if (OnChemList_ADD != null) OnChemList_ADD(sender, new RoutedEventArgs());
            }

            if (e.PropertyName == "UpdateResult")
            {
                // update Event
                sender = clVM.UpdateResult;
                if (OnChemList_UPDATE != null) OnChemList_UPDATE(sender, new RoutedEventArgs());
            }
        }

        
        // ADD Record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lwdom_chemlist_Model lwdclMod = new lwdom_chemlist_Model();
            lwdom_chemlist_Woker LWDCLWkr = new lwdom_chemlist_Woker();

            // load the model
            lwdclMod = Load_Model();

            // async ADD
            clVM.Add_ChemList_Async(lwdclMod);

            // reset fields
            ResetDisplayFields();

            // use inital button configuration
            InitialButtonConfiguration();
        }


        // UPDATE ChemList Record
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lwdom_chemlist_Model lwdclMod = new lwdom_chemlist_Model();
            lwdom_chemlist_Woker LWDCLWkr = new lwdom_chemlist_Woker();

            // load the model
            lwdclMod = (lwdom_chemlist_Model)this.DataContext;

            // async Update
            clVM.Update_ChemList_Async(lwdclMod);

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
            sender = "";

            // CANCEL Event
            if (OnChemList_CANCEL != null) OnChemList_CANCEL(sender, new RoutedEventArgs());
        }



        // DELETE Record
        private void buttonDELETE_Click(object sender, RoutedEventArgs e)
        {
            lwdom_chemlist_Woker LWDCLWkr = new lwdom_chemlist_Woker();
            MessageBoxResult result;
            Int64 recID = 0;
            bool boolResult = false;

            result = MessageBox.Show("You are about to Delete a record.\nDo you want to continue?", "Delete",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            string strMsg = "";

            if (MessageBoxResult.OK == result)
            {
                boolResult = Int64.TryParse(lblOBJECTID.Content.ToString(), out recID);
                if (recID > 0)
                {
                    strMsg = LWDCLWkr.Delete_ChemList_rec(recID);
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
            if (OnChemList_DELETE != null) OnChemList_DELETE(sender, new RoutedEventArgs());
        }


        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
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
            EnableDisplayFields();
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            lblOBJECTID.Content = "";
            txtChemCode.Text = "";
            txtEPANum.Text = "";
            txtActiveIngr.Text = "";
            txtManufacturer.Text = "";
            txtRetail.Text = "";
            txtcost.Text = "";
            cboComment.Text = "";
            cboUnits.Text = "";
            cboactiveStatus.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            txtChemCode.IsEnabled = false;
            txtEPANum.IsEnabled = false;
            txtActiveIngr.IsEnabled = false;
            txtManufacturer.IsEnabled = false;
            txtRetail.IsEnabled = false;
            txtcost.IsEnabled = false;
            cboComment.IsEnabled = false;
            cboUnits.IsEnabled = false;
            cboactiveStatus.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtChemCode.IsEnabled = true;
            txtEPANum.IsEnabled = true;
            txtActiveIngr.IsEnabled = true;
            txtManufacturer.IsEnabled = true;
            txtRetail.IsEnabled = true;
            txtcost.IsEnabled = true;
            cboComment.IsEnabled = true;
            cboUnits.IsEnabled = true;
            cboactiveStatus.IsEnabled = true;
        }



        // load the Model
        private lwdom_chemlist_Model Load_Model()
        {
            lwdom_chemlist_Model lwdclMod = new lwdom_chemlist_Model();

            bool result = false;
            decimal decNum = 0;

            lwdclMod.ChemCode = txtChemCode.Text;
            lwdclMod.EPANum = txtEPANum.Text;
            lwdclMod.ActiveIngr = txtActiveIngr.Text;
            lwdclMod.Manufacturer = txtManufacturer.Text;
            //
            // Retail
            result = decimal.TryParse(txtRetail.Text.Trim(), out decNum);
            lwdclMod.retail = decNum;
            // Cost
            result = decimal.TryParse(txtcost.Text.Trim(), out decNum);
            lwdclMod.cost = decNum;
            //
            lwdclMod.Comment = cboComment.Text;
            lwdclMod.Units = cboUnits.Text;
            lwdclMod.activeStatus = cboactiveStatus.Text.Trim();

            // returne the model
            return lwdclMod;
        }


        // ADD Enable based on Blank fields, 
        // Set the ADD Button Configuration
        private void buttonADD_Enable_blank_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            ADDButtonConfiguration();
            sender = "ADD Enabled based on blanks.";

            // Add Enable Event
            if (OnChemList_ADDEnabel != null) OnChemList_ADDEnabel(sender, new RoutedEventArgs());
        }


        // ADD Enable based on Copy fields, 
        // Set the ADD Button Configuration
        private void buttonADD_Enable_copy_Click(object sender, RoutedEventArgs e)
        {
            // do not reset display fields
            ADDButtonConfiguration();
            sender = "ADD Enabled based on copy.";

            // Add Enable Event
            if (OnChemList_ADDEnabel != null) OnChemList_ADDEnabel(sender, new RoutedEventArgs());
        }
    }
}
