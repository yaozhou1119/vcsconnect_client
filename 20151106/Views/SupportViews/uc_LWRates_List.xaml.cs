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
// worker
using VcsConnect_Client.Workers.SQL_Workers;

namespace VcsConnect_Client.Views.SupportViews
{
    /// <summary>
    /// Interaction logic for uc_LWRates_List.xaml
    /// </summary>
    public partial class uc_LWRates_List : UserControl
    {
        // routed event handler
        public RoutedEventHandler OnRates_SELECTION;
        public RoutedEventHandler OnRates_byRateYearSELECTED;


        // constructor
        public uc_LWRates_List()
        {
            InitializeComponent();

            // load combo box
            Load_RateYear_ComboBox();
        }


        // Selected record Event
        private void Rates_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnRates_SELECTION != null) OnRates_SELECTION(sender, new RoutedEventArgs());
        }


        // Load RateYear comboBox with Distinct RateYears Values
        private void Load_RateYear_ComboBox()
        {
            lwdom_Rates_Worker RWkr = new lwdom_Rates_Worker();
            List<string> strRY_List = new List<string>();

            strRY_List = RWkr.Get_RateYear_List();
            
            // load combo box
            cboRateYear.ItemsSource = strRY_List;
        }


        // Select Rates based on RateYear
        private void cboRateYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strSelect = "";

            // read selected value from combo box
            strSelect = Convert.ToString(cboRateYear.SelectedValue);
            if (strSelect.Trim() != "")
            {
                cboRateYear.Text = strSelect;
            }
            else
            {
                strSelect = "";
                cboRateYear.Text = "";
            }

            sender = strSelect;

            // Chem Status Selection Event
            if (OnRates_byRateYearSELECTED != null) OnRates_byRateYearSELECTED(sender, new RoutedEventArgs());
        }
    }
}
