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
    /// Interaction logic for uc_WorkOrders_List.xaml
    /// </summary>
    public partial class uc_WorkOrders_List : UserControl
    {
        // routed Event Handler
        public RoutedEventHandler OnWorkOrder_SELECTED;
        public RoutedEventHandler OnSelectedDate_SELECTED;

        // constructor
        public uc_WorkOrders_List()
        {
            InitializeComponent();
        }


        // Selection Event
        private void WorkOrders_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnWorkOrder_SELECTED != null) OnWorkOrder_SELECTED(sender, new RoutedEventArgs());
        }


        // Select a new start date
        private void dtpDateSelection_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dt = (DateTime)dtpDateSelection.SelectedDate;
            sender = dt.ToShortDateString();

            // Selected date event
            if (OnSelectedDate_SELECTED != null) OnSelectedDate_SELECTED(sender, new RoutedEventArgs());
        }
    }
}
