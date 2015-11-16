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
    /// Interaction logic for uc_Invoice_Detail.xaml
    /// </summary>
    public partial class uc_Invoice_Detail : UserControl
    {
        // create the Instance of Invoice View Model
        ViewModel.Invoice_ViewModel invVM = new ViewModel.Invoice_ViewModel();

        // worker
        lw_Invoice_Worker IWkr;

        // Routed Event Handlers
        public RoutedEventHandler OnInvoice_ADDEnabled;
        public RoutedEventHandler OnInvoice_CANCELED;
        public RoutedEventHandler OnInvoice_UPDATE;

        // constructor
        public uc_Invoice_Detail()
        {
            InitializeComponent();

            // worker
            IWkr = new lw_Invoice_Worker();

            // reset display fields and
            // Initialize button settings
            ResetDisplayFields();
            InitialButtonConfiguration();
        }



        // ADD
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {

        }



        // UPDATE
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lw_Invoice_Model iMod = new lw_Invoice_Model();
            string strMsg = "";

            // load model from dataContext
            iMod = (lw_Invoice_Model)DataContext;

            // update Invoice record
            strMsg = IWkr.Update_Invoice_rec(iMod);
            sender = strMsg;

            // reset
            ResetDisplayFields();
            InitialButtonConfiguration();

            // Update Event
            if (OnInvoice_UPDATE != null) OnInvoice_UPDATE(sender, new RoutedEventArgs());
        }


        // CANCEL Event
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            InitialButtonConfiguration();

            // event
            if (OnInvoice_CANCELED != null) OnInvoice_CANCELED(sender, new RoutedEventArgs());
        }


        private void buttonDELETE_Click(object sender, RoutedEventArgs e)
        {

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


        // Execute ADDButtonConfig coming from outside
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
            buttonADD_EnableCopy.IsEnabled = false;
            buttonADD_EnableBlank.IsEnabled = true;
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
            buttonADD_EnableCopy.IsEnabled = false;
            buttonADD_EnableBlank.IsEnabled = false;
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
            buttonADD_EnableCopy.IsEnabled = true;
            buttonADD_EnableBlank.IsEnabled = true;
            //
            EnableDisplayFields();
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            lblID.Content = "";
            txtWorkOrderID.Text = "";
            txtInvoiceID.Text = "";
            txtDescription.Text = "";
            txtContactID.Text = "";
            dtpWorkFrom.Text = "";
            dtpWorkTo.Text = "";
            dtpInvoiceDate.Text = "";
            txtPaid.Text = "";
            txtEquipHour.Text = "";
            txtWorkerHour.Text = "";
            txtChemHour.Text = "";
            txtTaxAmt.Text = "";
            txtBillLocation.Text = "";
            txtLocID.Text = "";
            txtInvID.Text = "";
            txtinvMemo.Text = "";
            txtLocWrkID.Text = "";
            txtshowBillName.Text = "";
            txttotEquip.Text = "";
            txttotWork.Text = "";
            txttotChem.Text = "";
            txttotItem.Text = "";
            txttotBeforeTax.Text = "";
            txttotInvoicedBeforTax.Text = "";
            txtAccNum.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            txtWorkOrderID.IsEnabled = false;
            txtInvoiceID.IsEnabled = false;
            txtDescription.IsEnabled = false;
            txtContactID.IsEnabled = false;
            dtpWorkFrom.IsEnabled = false;
            dtpWorkTo.IsEnabled = false;
            dtpInvoiceDate.IsEnabled = false;
            txtPaid.IsEnabled = false;
            txtEquipHour.IsEnabled = false;;
            txtWorkerHour.IsEnabled = false;
            txtChemHour.IsEnabled = false;
            txtTaxAmt.IsEnabled = false;
            txtBillLocation.IsEnabled = false;
            txtLocID.IsEnabled = false;
            txtInvID.IsEnabled = false;
            txtinvMemo.IsEnabled = false;
            txtLocWrkID.IsEnabled = false;
            txtshowBillName.IsEnabled = false;
            txttotEquip.IsEnabled = false;
            txttotWork.IsEnabled = false;
            txttotChem.IsEnabled = false;
            txttotItem.IsEnabled = false;
            txttotBeforeTax.IsEnabled = false;
            txttotInvoicedBeforTax.IsEnabled = false;
            txtAccNum.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtWorkOrderID.IsEnabled = true;
            txtInvoiceID.IsEnabled = true;
            txtDescription.IsEnabled = true;
            txtContactID.IsEnabled = true;
            dtpWorkFrom.IsEnabled = true;
            dtpWorkTo.IsEnabled = true;
            dtpInvoiceDate.IsEnabled = true;
            txtPaid.IsEnabled = true;
            txtEquipHour.IsEnabled = true;
            txtWorkerHour.IsEnabled = true;
            txtChemHour.IsEnabled = true;
            txtTaxAmt.IsEnabled = true;
            txtBillLocation.IsEnabled = true;
            txtLocID.IsEnabled = true;
            txtInvID.IsEnabled = true;
            txtinvMemo.IsEnabled = true;
            txtLocWrkID.IsEnabled = true;
            txtshowBillName.IsEnabled = true;
            txttotEquip.IsEnabled = true;
            txttotWork.IsEnabled = true;
            txttotChem.IsEnabled = true;
            txttotItem.IsEnabled = true;
            txttotBeforeTax.IsEnabled = true;
            txttotInvoicedBeforTax.IsEnabled = true;
            txtAccNum.IsEnabled = true;
        }


        // ADD Enable copying all display fields
        private void buttonADD_EnableCopy_Click(object sender, RoutedEventArgs e)
        {
            string strINVDdate = DateTime.Now.ToString("MMddyyyy");
            txtInvoiceID.Text = txtWorkOrderID.Text + "-" + strINVDdate;
            ADDButtonConfiguration();
            sender = "ADD Enable with Copy.";

            // Add Enable Event
            if (OnInvoice_ADDEnabled != null) OnInvoice_ADDEnabled(sender, new RoutedEventArgs());
        }


        // ADD Enable using Blank Fields
        private void buttonADD_EnableBlank_Click(object sender, RoutedEventArgs e)
        {
            // set the data context
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lw_Invoice_Model();

            ResetDisplayFields();
            ADDButtonConfiguration();
            sender = "ADD Enable with all fields blank";

            // Add Enable Event
            if (OnInvoice_ADDEnabled != null) OnInvoice_ADDEnabled(sender, new RoutedEventArgs());
        }
    }
}