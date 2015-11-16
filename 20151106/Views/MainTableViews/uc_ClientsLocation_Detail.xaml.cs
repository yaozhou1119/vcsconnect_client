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
    /// Interaction logic for uc_ClientsLocation_Detail.xaml
    /// </summary>
    public partial class uc_ClientsLocation_Detail : UserControl
    {
        // routed event handlers
        public RoutedEventHandler OnClientLocation_ADDEnable;


        // constructor
        public uc_ClientsLocation_Detail()
        {
            InitializeComponent();

            // load combo boxes
            load_LocCat_CombBox();
            load_JobType_CombBox();
            load_LocType_CombBox();

            // reset and initialize buttons
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // ADD Enable: configure for ADD
        private void buttonADD_Enable_Copy_Click(object sender, RoutedEventArgs e)
        {
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lw_ClientLocations_Model();

            // Add Enable Event copying data
            ADDButtonConfiguration();
            sender = "Configured for ADD Enable copying data.";
            if (OnClientLocation_ADDEnable != null) OnClientLocation_ADDEnable(sender, new RoutedEventArgs());
        }

        private void buttonADD_Enable_Blank_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

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



        // Execute Reset Configuration
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
            buttonADD_Enable_Copy.IsEnabled = false;
            buttonADD_Enable_Blank.IsEnabled = true;
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
            buttonADD_Enable_Copy.IsEnabled = false;
            buttonADD_Enable_Blank.IsEnabled = false;
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
            buttonADD_Enable_Copy.IsEnabled = true;
            buttonADD_Enable_Blank.IsEnabled = true;
            //
            EnableDisplayFields();
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            lblID.Content = "";
            txtAccNum.Text = "";
            txtClientName.Text = "";
            txtClientLocationID.Text = "";
            txtName.Text = "";
            cboType.Text = "";
            txtLocAdd1.Text = "";
            txtLocAdd2.Text = "";
            txtLocTown.Text = "";
            txtLocState.Text = "";
            txtLocZip.Text = "";
            txtComment.Text = "";
            //
            cboLocType.Text = "";
            cboLocCat.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            lblID.IsEnabled = false;
            txtAccNum.IsEnabled = false;
            txtClientName.IsEnabled = false;
            txtClientLocationID.IsEnabled = false;
            txtName.IsEnabled = false;
            cboType.IsEnabled = false;
            txtLocAdd1.IsEnabled = false;
            txtLocAdd2.IsEnabled = false;
            txtLocTown.IsEnabled = false;
            txtLocState.IsEnabled = false;
            txtLocZip.IsEnabled = false;
            txtComment.IsEnabled = false;
            //
            cboLocType.IsEnabled = false;
            cboLocCat.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            lblID.IsEnabled = true;
            txtAccNum.IsEnabled = true;
            txtClientName.IsEnabled = true;
            txtClientLocationID.IsEnabled = true;
            txtName.IsEnabled = true;
            cboType.IsEnabled = true;
            txtLocAdd1.IsEnabled = true;
            txtLocAdd2.IsEnabled = true;
            txtLocTown.IsEnabled = true;
            txtLocState.IsEnabled = true;
            txtLocZip.IsEnabled = true;
            txtComment.IsEnabled = true;
            //
            cboLocType.IsEnabled = true;
            cboLocCat.IsEnabled = true;
        }


        // load the Location Category comb box
        private void load_LocCat_CombBox()
        {
            lwdom_LocCat_Worker LCWkr = new lwdom_LocCat_Worker();
            List<string> lcStr_List = LCWkr.Get_LocCatDesc_stringList();
            
            // load combo box items source
            cboLocCat.ItemsSource = lcStr_List;
        }


        // load the Job Type comb box
        private void load_JobType_CombBox()
        {
            // Job Type
            lwdom_JobType_Worker JTWkr = new lwdom_JobType_Worker();
            List<string> jtStr_List = JTWkr.Get_JobType_stringList();

            // load combo box items source
            cboType.ItemsSource = jtStr_List;
        }



        // load the lwdom_LocType comb box
        private void load_LocType_CombBox()
        {
            // Location Type
            lwdom_LocType_Worker LTWkr = new lwdom_LocType_Worker();
            List<string> ltStr_List = LTWkr.Get_LocType_StringList();

            // load combo box items source
            cboLocType.ItemsSource = ltStr_List;
        }
    }
}
