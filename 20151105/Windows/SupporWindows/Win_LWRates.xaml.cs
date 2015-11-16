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
using System.Windows.Shapes;
// model
using VcsConnect_Client.Models.SQL_Models;
// worker
using VcsConnect_Client.Workers.SQL_Workers;

namespace VcsConnect_Client.Windows.SupporWindows
{
    /// <summary>
    /// Interaction logic for Win_LWRates.xaml
    /// </summary>
    public partial class Win_LWRates : Window
    {
        // creating and instance of the ViewModel
        private ViewModel.Rates_ViewModel rVM = new ViewModel.Rates_ViewModel();

        // worker
        lwdom_Rates_Worker LWRWkr;

        // private RateYear string, Rate ID string
        private string strRY;
        private string strRId;

        // constructor
        public Win_LWRates()
        {
            InitializeComponent();

            // worker
            LWRWkr = new lwdom_Rates_Worker();
            strRY = "";
            strRId = "";

            // load comboBox
            LoadRateID_Combobox();


            // LISTENER: Selected data changed
            // Handle on ChemList selection changed events
            ucRate_List.OnRates_SELECTION += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lwdom_Rates_Model) == false) return;

                lwdom_Rates_Model selectedContent = (lwdom_Rates_Model)itm;

                ucRates_Detail.DataContext = selectedContent;

                labelStatus.Content = "ID: " + selectedContent.ID;
                ucRates_Detail.Execute_UpdateButtonConfiguration();
            };



            // LISTENER: ADD
            ucRates_Detail.OnRates_ADD += (o, e) =>
            {
                string strMsg = o.ToString();
                bool result = false;
                int intRy = 0;

                // get the select Rate Year and convert to int Year
                result = int.TryParse(strRY, out intRy);

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // reset and initial button
                ucRates_Detail.Execute_InitialButtonConfiguration();

                // Get List, Async Get
                if (intRy > 0)
                {
                    rVM.Get_Rates_byRateYear_Async(intRy);
                    ucRate_List.LabelBanner.Content = "Rates List for Year " + intRy.ToString();
                }
                else
                {
                    rVM.Get_Rates_Async();
                    ucRate_List.LabelBanner.Content = "Rates List";
                }
            };



            // LISTENER: UPDATE
            ucRates_Detail.OnRates_UPDATE += (o, e) =>
            {
                string strMsg = o.ToString();
                bool result = false;
                int intRy = 0;

                // get the select Rate Year and convert to int Year
                result = int.TryParse(strRY, out intRy);

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // reset and initial button
                ucRates_Detail.Execute_InitialButtonConfiguration();

                // Get List, Async Get
                if (intRy > 0)
                {
                    rVM.Get_Rates_byRateYear_Async(intRy);
                    ucRate_List.LabelBanner.Content = "Rates List for Year " + intRy.ToString();
                }
                else
                {
                    rVM.Get_Rates_Async();
                    ucRate_List.LabelBanner.Content = "Rates List";
                }
            };



            // LISTENER: Cancel
            ucRates_Detail.OnRates_CANCEL += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Rates List
                rVM.Get_Rates_Async();
                ucRate_List.cboRateYear.Text = "";
                cboRateID.Text = "";
            };



            // LISTENER: DELETE
            ucRates_Detail.OnRates_DELETE += (o, e) =>
            {
                string strMsg = o.ToString();
                bool result = false;
                int intRy = 0;

                // get the select Rate Year and convert to int Year
                result = int.TryParse(strRY, out intRy);

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // reset and initial button
                ucRates_Detail.Execute_InitialButtonConfiguration();

                // Get List, Async Get
                if (intRy > 0)
                {
                    rVM.Get_Rates_byRateYear_Async(intRy);
                    ucRate_List.LabelBanner.Content = "Rates List for Year " + intRy.ToString();
                }
                else
                {
                    rVM.Get_Rates_Async();
                    ucRate_List.LabelBanner.Content = "Rates List";
                }
            };




            // LISTENER: Async Get Ratest base on Rate Year
            // status selection
            ucRate_List.OnRates_byRateYearSELECTED += (o, e) =>
            {
                strRY = o.ToString();
                bool result = false;
                int intRy = 0;

                // get the select Rate Year and convert to int Year
                result = int.TryParse(strRY, out intRy);

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // reset and initial button
                ucRates_Detail.Execute_InitialButtonConfiguration();

                // Get List, Async Get
                if (intRy > 0)
                {
                    rVM.Get_Rates_byRateYear_Async(intRy);
                    ucRate_List.LabelBanner.Content = "Rates List for Year " + intRy.ToString();
                }
                else
                {
                    rVM.Get_Rates_Async();
                    ucRate_List.LabelBanner.Content = "Rates List";
                }
            };



            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            rVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "Rates_List")
                {
                    ucRate_List.DataContext = rVM.rvmMod_List;
                    labelStatus.Content = "Retrieved " + rVM.rvmMod_List.Count + " Rates.";

                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;
                }
            };


            // Telling the ViewModel to retieve data
            rVM.Get_Rates_Async();
            labelStatus.Content = "Retrieving data...";
        }


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // Select by Rates by RateID
        private void cboRateID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboRateID.SelectedValue != null)
            {
                strRId = cboRateID.SelectedValue.ToString();
            }
            else
            {
                strRId = "";
            }
                         
            // turn ON busy Indicator
            busy_Indicator.IsBusy = true;

            // reset and initial button
            ucRates_Detail.Execute_InitialButtonConfiguration();

            // Get List, Async Get
            if (strRId == null) strRId = "";
            if (strRId.Trim() != "")
            {
                rVM.Get_Rates_byRateID_Async(strRId);
                ucRate_List.LabelBanner.Content = "Rates List for " + strRId;
            }
            else
            {
                rVM.Get_Rates_Async();
                ucRate_List.LabelBanner.Content = "Rates List";
            }
        }


        // load the lwdom_RateID into string list
        private void LoadRateID_Combobox()
        {
            List<string> rID_List = new List<string>();
            lwdom_Rates_Worker RWkr = new lwdom_Rates_Worker();

            rID_List = RWkr.Get_RateIDString_List();
            cboRateID.ItemsSource = rID_List;
        }
    }
}
