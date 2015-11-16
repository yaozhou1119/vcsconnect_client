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
using System.Windows.Navigation;
using System.Windows.Shapes;
// models
using VcsConnect_Client.Models.SQL_Models;
using VcsConnect_Client.Models.ApplicationValues;
// worker
using VcsConnect_Client.Workers.ApplicationValue_Workers;


namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_Bids_Detail.xaml
    /// </summary>
    public partial class uc_Bids_Detail : UserControl
    {
        // routed event handler
        public RoutedEventHandler OnBid_AddENABLE;
        public RoutedEventHandler OnBid_CANCEL;

        // constructor
        public uc_Bids_Detail()
        {
            InitializeComponent();

            // reset and initial button condition
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // ADD Record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            // get the data from the dataContext 
            // and load into model
            lw_Bids_Model bMod = (lw_Bids_Model)DataContext;
        }


        // UPDATE Record
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            // get the data from the dataContext 
            // and load into model
            lw_Bids_Model bMod = (lw_Bids_Model)DataContext;
        }


        // CANCEL
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            // because datagrid display is set to read only
            // there is no need to reload data grid
            ResetDisplayFields();
            InitialButtonConfiguration();

            // Cancel Event
            if (OnBid_CANCEL != null) OnBid_CANCEL(sender, new RoutedEventArgs());
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
            lblBidID.Background = (Brush)bc.ConvertFrom("#F0F8FF");
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
            lblBidID.Background = (Brush)bc.ConvertFrom("#EEDFCC");
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
            lblBidID.Background = (Brush)bc.ConvertFrom("#F0F8FF");
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            FlowDocument fldoc = new FlowDocument();

            lblID.Content = "";
            lblBidID.Content = "";
            txtClientName.Text = "";
            txtClientLocID.Text = "";
            txtBidAmtRetail.Text = "";
            txtBidAmtCost.Text = "";
            txtArea.Text = "";
            dtpBidSent.Text = "";
            txtDescription.Text = "";
            cboBidWon.Text = "";
            txtAttnName.Text = "";
            txtdescBidAmtRetail.Text = "";
            txtdescBidAmtCost.Text = "";
            rtbNarrative.Document = fldoc;
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            lblID.IsEnabled = false;
            lblBidID.IsEnabled = false;
            txtClientName.IsEnabled = false;
            txtClientLocID.IsEnabled = false;
            txtBidAmtRetail.IsEnabled = false;
            txtBidAmtCost.IsEnabled = false;
            txtArea.IsEnabled = false;
            dtpBidSent.IsEnabled = false;
            txtDescription.IsEnabled = false;
            cboBidWon.IsEnabled = false;
            txtAttnName.IsEnabled = false;
            txtdescBidAmtRetail.IsEnabled = false;
            txtdescBidAmtCost.IsEnabled = false;
            rtbNarrative.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            lblID.IsEnabled = true;
            lblBidID.IsEnabled = true;
            txtClientName.IsEnabled = true;
            txtClientLocID.IsEnabled = true;
            txtBidAmtRetail.IsEnabled = true;
            txtBidAmtCost.IsEnabled = true;
            txtArea.IsEnabled = true;
            dtpBidSent.IsEnabled = true;
            txtDescription.IsEnabled = true;
            cboBidWon.IsEnabled = true;
            txtAttnName.IsEnabled = true;
            txtdescBidAmtRetail.IsEnabled = true;
            txtdescBidAmtCost.IsEnabled = true;
            rtbNarrative.IsEnabled = true;
        }



        // load the Model
        // load model is used on an ADD
        private lw_Bids_Model Load_Model()
        {
            lw_Bids_Model bMod = new lw_Bids_Model();
            bool result = false;
            Int64 intNum = 0;
            decimal decNum = 0;
            DateTime DT;
            DateTime? nullDate = null;

            // formatting for Richtext
            TextRange tr = new TextRange(rtbNarrative.Document.ContentStart, rtbNarrative.Document.ContentEnd);
            
            bMod.ID = 0;
            //
            result = Int64.TryParse(lblBidID.Content.ToString(), out intNum);
            bMod.BidID = (result) ? intNum : 0;
            //
            bMod.ClientLocID = txtClientLocID.Text;
            //
            result = decimal.TryParse(txtBidAmtRetail.Text, out decNum);
            bMod.BidAmtRetail = (result) ? decNum : 0;
            //
            result = decimal.TryParse(txtBidAmtCost.Text, out decNum);
            bMod.BidAmtCost = (result) ? decNum : 0;
            //
            result = Int64.TryParse(txtArea.Text, out intNum);
            bMod.Area = (result) ? intNum : 0;
            //
            result = DateTime.TryParse(dtpBidSent.Text, out DT);
            bMod.BidSent = (result) ? DT : nullDate;
            //
            bMod.Description = txtDescription.Text;
            bMod.BidWon = cboBidWon.Text;
            bMod.AttnName = txtAttnName.Text;
            bMod.descBidAmtRetail = txtdescBidAmtRetail.Text;
            bMod.descBidAmtCost = txtdescBidAmtCost.Text;

            // richtext formatting save to db
            // tr contains reference to rtbNarrative
            // saved as string in bMod.Narrative
            using (MemoryStream ms = new MemoryStream())
            {
                tr.Save(ms, DataFormats.Rtf);
                bMod.Narrative = Encoding.ASCII.GetString(ms.ToArray());
            }

            // returne the model
            return bMod;
        }


        // ADD Enable - Copy
        private void buttonADD_Enable_Copy_Click(object sender, RoutedEventArgs e)
        {
            Int64 iNBidsNum = 0;

            // set the UI
            ADDButtonConfiguration();

            // get next WO number
            iNBidsNum = GetNext_BidsID_Number();
            lblBidID.Content = iNBidsNum.ToString();
        }


        // ADD Enable - Blank
        private void buttonADD_Enable_Blank_Click(object sender, RoutedEventArgs e)
        {
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lw_Bids_Model();

            // set the UI
            ResetDisplayFields();
            ADDButtonConfiguration();
        }


        // Get the next Work Order Number to use on an ADD
        private Int64 GetNext_BidsID_Number()
        {
            Application_Values_Worker AVWkr = new Application_Values_Worker();
            ApplicationValue_Model avMod = new ApplicationValue_Model();
            string strMsg = "";

            // get the application Value model
            // Hard wired to always get record 1
            avMod = AVWkr.Get_SpecificAppValue_Record(ref strMsg);

            // return Next Work Order Number
            return avMod.NextBidID;
        }
    }
}
