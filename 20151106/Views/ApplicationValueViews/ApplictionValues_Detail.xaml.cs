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
using VcsConnect_Client.Models.ApplicationValues;
// worker
using VcsConnect_Client.Workers.ApplicationValue_Workers;

namespace VcsConnect_Client.Views.ApplicationValueViews
{
    /// <summary>
    /// Interaction logic for ApplictionValues_Detail.xaml
    /// </summary>
    public partial class ApplictionValues_Detail : UserControl
    {
        // routed event handle
        public RoutedEventHandler OnAV_ADD;
        public RoutedEventHandler OnAV_CANCEL;
        public RoutedEventHandler OnAV_UPDATE;

        // Worker
        Application_Values_Worker AVWkr;

        // constructor
        public ApplictionValues_Detail()
        {
            InitializeComponent();

            // Worker
            AVWkr = new Application_Values_Worker();
            
            // set dataContext
            SetDataContext();

            // get application value record
            Get_ApplicationValue_Rec();

            // update config
            UpdateButtonConfiguration();
        }


        // Add Enable
        private void buttonADD_Enable_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            ADDButtonConfiguration();
        }


        // ADD Record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            string strMsg = "";
            ApplicationValue_Model avMod = new ApplicationValue_Model();
            avMod = (ApplicationValue_Model)DataContext;

            strMsg = AVWkr.ADD_ApplicationValues_Record(avMod);
            sender = strMsg;

            // add evet
            if (OnAV_ADD != null) OnAV_ADD(sender, new RoutedEventArgs());
        }



        // UPDATE
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            string strMsg = "";
            ApplicationValue_Model avMod = new ApplicationValue_Model();
            avMod = (ApplicationValue_Model)DataContext;

            strMsg = AVWkr.Update_ApplicationValues_rec(avMod);
            sender = strMsg;

            // add evet
            if (OnAV_UPDATE != null) OnAV_UPDATE(sender, new RoutedEventArgs());
        }


        // CANCEL
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            InitialButtonConfiguration();

            // cancel event
            if (OnAV_CANCEL != null) OnAV_CANCEL(sender, new RoutedEventArgs());
        }

        private void buttonDELETE_Click(object sender, RoutedEventArgs e)
        {

        }


        // Update config
        public void Execute_UpdateButtonConfig()
        {
            UpdateButtonConfiguration();
        }


        // initial button configuration
        private void InitialButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDELETE.Visibility = Visibility.Hidden;
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
            EnableDisplayFields();
        }



        // Update button configuration
        private void UpdateButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Visible;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDELETE.Visibility = Visibility.Hidden;
            //
            EnableDisplayFields();
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            FlowDocument fldoc = new FlowDocument();

            lblID.Content = "";
            txtNextWorkOrderID.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            txtNextWorkOrderID.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtNextWorkOrderID.IsEnabled = true;
        }

        
        // Get Application Value Record
        private void Get_ApplicationValue_Rec()
        {
            string strMsg = "";
            ApplicationValue_Model avMod = new ApplicationValue_Model();

            // get specific Application Value will always 
            // get the first record.  Hard wired.
            avMod = AVWkr.Get_SpecificAppValue_Record(ref strMsg);

            if (avMod != null)
            {
                // load data
                DataContext = (ApplicationValue_Model)avMod;

                // on recID = 1, turn off Add
                if (avMod.ID == 1)
                {
                    buttonADD_Enable.IsEnabled = false;
                }
            }
        }


        // create the data context
        private void SetDataContext()
        {
            DataContext = null;
            DataContext = new ApplicationValue_Model();
        }
    }
}
