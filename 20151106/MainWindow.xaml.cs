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
// windows
using VcsConnect_Client.Windows.SupporWindows;
using VcsConnect_Client.Windows.MainWindows;
using VcsConnect_Client.Windows.ApplicationValuesWindows;
// workers
using VcsConnect_Client.Workers.SQL_Workers;

namespace VcsConnect_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // constructor
            InitializeComponent();
            Title = BuildTitle();
        }


        // build title line
        private string BuildTitle()
        {
            string strTitle = "";
            string strYear = DateTime.Today.Year.ToString();
            strTitle = "VCS Connect, Client, © " + strYear + " Vegetation Control Services";
            return strTitle;
        }


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // test sql connection
        private void menuTestSQLConnection_Click(object sender, RoutedEventArgs e)
        {
            SqlDBConnectionTester SDBCTWkr = new SqlDBConnectionTester();
            string strMsg = "";
            strMsg = SDBCTWkr.TestSqlConnection();

            // diplay message
            labelStatus.Content = strMsg;
        }


        // display Chemlist Window
        private void menuChemList_Click(object sender, RoutedEventArgs e)
        {
            Win_LWChemList WinLWCL = new Win_LWChemList();
            WinLWCL.ShowDialog();
        }


        // display RatesID Window
        private void menuRatesID_Click(object sender, RoutedEventArgs e)
        {
            Win_DomRatesID WinDRID = new Win_DomRatesID();
            WinDRID.ShowDialog();
        }


        // display Rate Window
        private void menuRates_Click(object sender, RoutedEventArgs e)
        {
            Win_LWRates WinLWR = new Win_LWRates();
            WinLWR.ShowDialog();
        }


        // Display window for ALL BIDS
        private void menuBids_Click(object sender, RoutedEventArgs e)
        {
            Win_LWBids WinLWB = new Win_LWBids();
            WinLWB.ShowDialog();
        }


        // Display window for All WorkOrders
        private void menuWorkOrders_Click(object sender, RoutedEventArgs e)
        {
            Win_LWWorkOrders WinWO = new Win_LWWorkOrders();
            WinWO.ShowDialog();
        }


        // Display window for all Invoices
        private void menuInvoices_Click(object sender, RoutedEventArgs e)
        {
            Win_LWInvoices WinINV = new Win_LWInvoices();
            WinINV.ShowDialog();
        }


        // Display Client Window for Active Clients
        private void menuClient_Active_Click(object sender, RoutedEventArgs e)
        {
            string status = "active";
            Win_LWClient WinLWC = new Win_LWClient(status);
            WinLWC.ShowDialog();      
        }

        // Display Client Window for InActive Clients
        private void menuClient_Inactive_Click(object sender, RoutedEventArgs e)
        {
            string status = "inactive";
            Win_LWClient WinLWC = new Win_LWClient(status);
            WinLWC.ShowDialog();      
        }


        private void menuContacts_Active_Click(object sender, RoutedEventArgs e)
        {
            string status = "active";
            Win_LWContacts WinContact = new Win_LWContacts(status);
            WinContact.ShowDialog();
        }

        private void menuContacts_Inactive_Click(object sender, RoutedEventArgs e)
        {
            string status = "inactive";
            Win_LWContacts WinContact = new Win_LWContacts(status);
            WinContact.ShowDialog();
        }


        // Inactive Employees
        private void menuEmployees_Inactive_Click(object sender, RoutedEventArgs e)
        {
            string status = "inactive";
            Win_LWEmployees WinEmp = new Win_LWEmployees(status);
            WinEmp.ShowDialog();
        }


        // Active Employees
        private void menuEmployees_Active_Click(object sender, RoutedEventArgs e)
        {
            string status = "active";
            Win_LWEmployees WinEmp = new Win_LWEmployees(status);
            WinEmp.ShowDialog();
        }


        // display State Name Window
        private void menuStateName_Click(object sender, RoutedEventArgs e)
        {
            Win_DomStateName Win_DSN = new Win_DomStateName();
            Win_DSN.ShowDialog();
        }


        // display All Invoice Expense Items
        private void menuAllInvExpItems_List_Click(object sender, RoutedEventArgs e)
        {
            Win_LWInvExpItems Win_IEI = new Win_LWInvExpItems();
            Win_IEI.ShowDialog();
        }


        // Display the window for Application Values
        private void menuApplicationValues_Click(object sender, RoutedEventArgs e)
        {
            Win_ApplicationValues Win_AV = new Win_ApplicationValues();
            Win_AV.ShowDialog();
        }


        // Display Client Locations
        private void menuClientLocations_Click(object sender, RoutedEventArgs e)
        {
            Win_LWClientLocation WinCL = new Win_LWClientLocation();
            WinCL.ShowDialog();
        }


        // display Job Types
        private void menuJobTypes_Click(object sender, RoutedEventArgs e)
        {
            Win_DomJobType WinJT = new Win_DomJobType();
            WinJT.ShowDialog();
        }


        // Display the Loc Cat Window
        private void menuLocCat_Click(object sender, RoutedEventArgs e)
        {
            Win_DomLocCat WinLC = new Win_DomLocCat();
            WinLC.ShowDialog();
        }


        // Display the Location Type Window
        private void menuLocType_Click(object sender, RoutedEventArgs e)
        {
            Win_DomLocType WinLT = new Win_DomLocType();
            WinLT.ShowDialog();
        }
    }
}
