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
using System.Windows.Shapes;
using System.Net;
// models
using VcsConnect_Client.Models.SQL_Models;
// worker
using VcsConnect_Client.Workers.SQL_Workers;
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for Win_LWBids.xaml
    /// </summary>
    public partial class Win_LWBids : Window
    {
        // worker
        private lw_Bids_Worker LWBWkr;

        // creating and instance of the ViewModel
        private ViewModel.Bids_ViewModel bidsVM = new ViewModel.Bids_ViewModel();
                
        // constructor
        public Win_LWBids()
        {
            InitializeComponent();

            // worker
            LWBWkr = new lw_Bids_Worker();
            
            // LISTENER: Selected data changed
            // Handle on ChemList selection changed events
            uc_BidsList.OnBid_SELECTED += (o, e) =>
            {
                FlowDocument flwDoc = new FlowDocument();

                var p = new Paragraph();
                var run = new Run();

                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lw_Bids_Model) == false) return;

                lw_Bids_Model selectedContent = (lw_Bids_Model)itm;

                uc_BidsDetail.DataContext = selectedContent;

                // rtf (RichText Formatting) for RichTextBox
                // MemoryStream uses System.IO
                if (selectedContent.Narrative.Trim() == "")
                {
                    uc_BidsDetail.rtbNarrative.Document = flwDoc;
                }
                else
                {
                    MemoryStream ms = new MemoryStream(ASCIIEncoding.Default.GetBytes(selectedContent.Narrative));
                    uc_BidsDetail.rtbNarrative.Selection.Load(ms, DataFormats.Rtf);
                }
                //

                uc_BidsDetail.Execute_UpdateButtonConfiguration();
                labelStatus.Content = "Bid ID: " + selectedContent.BidID;
                
                flwDoc = null;
            };




            // LISTENER: Selection by Sent Date
            uc_BidsList.OnBidSentDate_SELECTED += (o, e) =>
            {

                // turn off busy Indicator
                busy_Indicator.IsBusy = true;

                string strDate = o.ToString();
                bidsVM.Get_BidsByDate_Async(strDate);

                labelStatus.Content = "Retrieving data...";
            };



            // LISTENER: CANCEL
            uc_BidsDetail.OnBid_CANCEL += (o, e) =>
            {
                // Re - Display Bid List 
                // this is an example of reusing 
                // Get_Bids_Async, actually this will
                // not be used on a CANCEL. No need to 
                // redisplay list because the list Grids
                // have the parameter IsReadOnly="True";
                busy_Indicator.IsBusy = false;
                labelStatus.Content = "Cancel";
            };



            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            bidsVM.PropertyChanged += (o, e) =>
                {
                    // the View Model is notifying us that a property was updated
                    // checking for a specific property returned by the View Model
                    if (e.PropertyName == "BidsList")
                    {
                        uc_BidsList.DataContext = bidsVM.bvmMod_List;
                        labelStatus.Content = "Retrieved " + bidsVM.bvmMod_List.Count + " Bids.";
                        
                        // turn off busy Indicator
                        busy_Indicator.IsBusy = false;
                    }
                };



            // Telling the ViewModel to retieve data
            bidsVM.Get_Bids_Async();
            labelStatus.Content = "Retrieving data...";
        }


        // menu exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
