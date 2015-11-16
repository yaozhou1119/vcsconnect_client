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

namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_Bids_List.xaml
    /// </summary>
    public partial class uc_Bids_List : UserControl
    {
        // routed event
        public RoutedEventHandler OnBid_SELECTED;
        public RoutedEventHandler OnBidSentDate_SELECTED;

        // constructor
        public uc_Bids_List()
        {
            InitializeComponent();
        }


        // select Bid record
        private void Bid_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnBid_SELECTED != null) OnBid_SELECTED(sender, new RoutedEventArgs());
        }

        
        // Select Bids by BidSent date Selection
        private void dtpBidSelectSentDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = (DateTime)dtpBidSelectSentDate.SelectedDate;
            sender = dt.ToShortDateString();

            // Selected date event
            if (OnBidSentDate_SELECTED != null) OnBidSentDate_SELECTED(sender, new RoutedEventArgs());
        }
    }
}
