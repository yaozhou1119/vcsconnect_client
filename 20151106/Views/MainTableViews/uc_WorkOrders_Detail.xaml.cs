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
using VcsConnect_Client.Models.ApplicationValues;
// worker
using VcsConnect_Client.Workers.SQL_Workers;
using VcsConnect_Client.Workers.ApplicationValue_Workers;

namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_WorkOrders_Detail.xaml
    /// </summary>
    public partial class uc_WorkOrders_Detail : UserControl
    {
        // creating and instance of the ViewModel
        private ViewModel.WorkOrders_ViewModel woVM = new ViewModel.WorkOrders_ViewModel();

        // routed event handlers
        public RoutedEventHandler OnWorkOrder_ADD;
        public RoutedEventHandler OnWorkOrder_ADDEnabel;
        public RoutedEventHandler OnWorkOrder_CANCEL;
        public RoutedEventHandler OnWorkOrder_DELETE;
        public RoutedEventHandler OnWorkOrder_UPDATE;

        // worker
        lw_WorkOrders_Worker WOWkr;

        // constructor
        public uc_WorkOrders_Detail()
        {
            InitializeComponent();

            // worker
            WOWkr = new lw_WorkOrders_Worker();

            // reset and initial button condition
            ResetDisplayFields();
            InitialButtonConfiguration();

            // load combobox
            Load_JobType_ComboBox();
            Load_State_ComboBox();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        
        // ADD
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();
            string strMsg = "";

            // load the model
            woMod = (lw_WorkOrder_Model)DataContext;

            // regular add (non-async)
            strMsg = WOWkr.Add_WorkOrder_Rec(woMod);
            sender = strMsg;

            // reset display fields 
            // and initialize buttons
            ResetDisplayFields();
            InitialButtonConfiguration();

            // update event
            if (OnWorkOrder_ADD != null) OnWorkOrder_ADD(sender, new RoutedEventArgs());
        }



        // UPDATE
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();
            string strMsg = "";

            // load the model
            woMod = (lw_WorkOrder_Model)DataContext;

            // update work order
            strMsg = WOWkr.Update_WorkOrder_rec(woMod);
            sender = strMsg;

            // update event
            if (OnWorkOrder_UPDATE != null) OnWorkOrder_UPDATE(sender, new RoutedEventArgs());
        }



        // CANCEL Event
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            // reset fields, InitialButton configuration
            ResetDisplayFields();
            InitialButtonConfiguration();

            // event
            if (OnWorkOrder_CANCEL != null) OnWorkOrder_CANCEL(sender, new RoutedEventArgs());
        }



        // DELETE
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
                    woVM.DELETE_WorkOrders_Async(recID);
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
            if (OnWorkOrder_DELETE != null) OnWorkOrder_DELETE(sender, new RoutedEventArgs());
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



        // Execute Reset and Initial Button config,
        // coming from outside
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
            buttonADD_Enable_Blank.IsEnabled = true;
            buttonADD_Enable_Copy.IsEnabled = false;
            //
            DisableDisplayFields();

            // change display colors for WO ID background
            // #EEDFCC
            var bc = new BrushConverter();
            txtWOID.Background = (Brush)bc.ConvertFrom("#F0F8FF");
        }


        // ADD button configuration
        private void ADDButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Visible;
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDELETE.Visibility = Visibility.Hidden;
            //
            buttonADD_Enable_Blank.IsEnabled = false;
            buttonADD_Enable_Copy.IsEnabled = false;
            //
            EnableDisplayFields();

            // change display colors for WO ID background
            // #EEDFCC
            var bc = new BrushConverter();
            txtWOID.Background = (Brush)bc.ConvertFrom("#EEDFCC");
        }



        // Update button configuration
        private void UpdateButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Visible;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDELETE.Visibility = Visibility.Visible;
            //
            buttonADD_Enable_Blank.IsEnabled = true;
            buttonADD_Enable_Copy.IsEnabled = true;
            //
            EnableDisplayFields();

            // change display colors for WO ID background
            // #EEDFCC
            var bc = new BrushConverter();
            txtWOID.Background = (Brush)bc.ConvertFrom("#F0F8FF");
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            lblID.Content = "";
            txtLocationID.Text = "";
            txtWOID.Text = "";
            txtPurchaseOrder.Text = "";
            dtpStartDate.Text = "";
            dtpFinishDate.Text = "";
            txtROWName.Text = "";
            txtROWNum.Text = "";
            cboState.Text = "";
            txtDescription.Text = "";
            cboJobType.Text = "";
            txtPIC.Text = "";
            txtContractPrice_cost.Text = "";
            txtContractPrice_retail.Text = "";
            txtRateID.Text = "";
            txtLocID.Text = "";
            txtexpWorker.Text = "";
            txtexpEquip.Text = "";
            txtexpChem.Text = "";
            txtInvoicedNoTax.Text = "";
            txtperDiemCost.Text = "";
            txtTankTotal.Text = "";
            txtlinenum.Text = "";
            txtAccNum.Text = "";
            txtClientName.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            txtLocationID.IsEnabled = false;
            txtPurchaseOrder.IsEnabled = false;
            dtpStartDate.IsEnabled = false;
            dtpFinishDate.IsEnabled = false;
            txtROWName.IsEnabled = false;
            txtROWNum.IsEnabled = false;
            cboState.IsEnabled = false;
            txtDescription.IsEnabled = false;
            cboJobType.IsEnabled = false;
            txtPIC.IsEnabled = false;
            txtContractPrice_cost.IsEnabled = false;
            txtContractPrice_retail.IsEnabled = false;
            txtRateID.IsEnabled = false;
            txtLocID.IsEnabled = false;
            txtexpWorker.IsEnabled = false;
            txtexpEquip.IsEnabled = false;
            txtexpChem.IsEnabled = false;
            txtInvoicedNoTax.IsEnabled = false;
            txtperDiemCost.IsEnabled = false;
            txtTankTotal.IsEnabled = false;
            txtlinenum.IsEnabled = false;
            txtAccNum.IsEnabled = false;
            txtClientName.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtLocationID.IsEnabled = true;
            txtPurchaseOrder.IsEnabled = true;
            dtpStartDate.IsEnabled = true;
            dtpFinishDate.IsEnabled = true;
            txtROWName.IsEnabled = true;
            txtROWNum.IsEnabled = true;
            cboState.IsEnabled = true;
            txtDescription.IsEnabled = true;
            cboJobType.IsEnabled = true;
            txtPIC.IsEnabled = true;
            txtContractPrice_cost.IsEnabled = true;
            txtContractPrice_retail.IsEnabled = true;
            txtRateID.IsEnabled = true;
            txtLocID.IsEnabled = true;
            txtexpWorker.IsEnabled = true;
            txtexpEquip.IsEnabled = true;
            txtexpChem.IsEnabled = true;
            txtInvoicedNoTax.IsEnabled = true;
            txtperDiemCost.IsEnabled = true;
            txtTankTotal.IsEnabled = true;
            txtlinenum.IsEnabled = true;
            txtAccNum.IsEnabled = true;
            txtClientName.IsEnabled = true;
        }

        
        // ADD Enable with copy
        private void buttonADD_Enable_Copy_Click(object sender, RoutedEventArgs e)
        {
            lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();
            Int64 iNWoNum = 0;
            // change to ADD configuration
            ADDButtonConfiguration();
            sender = "ADD Enabled based on copying display fields.";
            lblID.Content = "";

            // get next WO number
            woMod = (lw_WorkOrder_Model)DataContext;
            iNWoNum = GetNext_WorkOrder_Number();

            // insert new WO number
            woMod.WOID = iNWoNum;
            txtWOID.Text = iNWoNum.ToString();

            // move everything back to dataContext
            DataContext = (lw_WorkOrder_Model)woMod;

            // Add Enable Event
            if (OnWorkOrder_ADDEnabel != null) OnWorkOrder_ADDEnabel(sender, new RoutedEventArgs());
        }


        // ADD Enable using Blank
        private void buttonADD_Enable_Blank_Click(object sender, RoutedEventArgs e)
        {
            Int64 iNWoNum = 0;

            // set the data context
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lw_WorkOrder_Model();
                        
            // reset display fields and change
            // buttons to Add configuration
            ResetDisplayFields();
            ADDButtonConfiguration();
            sender = "ADD Enabled based on blank display fields.";

            // get next WO number
            iNWoNum = GetNext_WorkOrder_Number();
            txtWOID.Text = iNWoNum.ToString();

            // Add Enable Event
            if (OnWorkOrder_ADDEnabel != null) OnWorkOrder_ADDEnabel(sender, new RoutedEventArgs());
        }


        // Get the next Work Order Number to use on an ADD
        private Int64 GetNext_WorkOrder_Number()
        {
            Application_Values_Worker AVWkr = new Application_Values_Worker();
            ApplicationValue_Model avMod = new ApplicationValue_Model();
            string strMsg = "";

            // get the application Value model
            // Hard wired to always get record 1
            avMod = AVWkr.Get_SpecificAppValue_Record(ref strMsg);
            
            // return Next Work Order Number
            return avMod.NextWorkOrderID;
        }

        
        // load JobType Combox
        private void Load_JobType_ComboBox()
        {
            lwdom_JobType_Worker JTWkr = new lwdom_JobType_Worker();
            List<string> jt_List = JTWkr.Get_JobType_stringList();
            cboJobType.ItemsSource = jt_List;
        }


        // load state names into comboBox
        private void Load_State_ComboBox()
        {
            lwdom_StateName_Worker SNWkr = new lwdom_StateName_Worker();
            List<string> sn_List = SNWkr.Get_StateName_stringList();
            cboState.ItemsSource = sn_List;
        }
    }
}
