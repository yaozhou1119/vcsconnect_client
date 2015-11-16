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
    /// Interaction logic for Win_DomJobType.xaml
    /// </summary>
    public partial class Win_DomJobType : Window
    {
        // worker 
        lwdom_JobType_Worker JTWkr;

        // constructor
        public Win_DomJobType()
        {
            InitializeComponent();

            // worker
            JTWkr = new lwdom_JobType_Worker();

            // display list of models in grid
            ListModelsInGrid();

            // reset and initialize buttons
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // Configure Window to Allow ADD
        private void menuAddJobType_Click(object sender, RoutedEventArgs e)
        {
            // set the data context
            // Enable Add Button has been clicked, so release any data 
            // context reference
            DataContext = null;

            // Create a new model object and bind 
            // it to the dataContext
            DataContext = new lwdom_JobType_Model();

            ResetDisplayFields();
            ADDButtonConfiguration();
            labelStatus.Content = "";
        }


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // ADD Job Type record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lwdom_JobType_Model jtMod = new lwdom_JobType_Model();
            string strMsg = "";
            
            // load data
            jtMod.JobType = txtJobType.Text.Trim();

            // add the record
            strMsg = JTWkr.Add_JobType_Rec(jtMod);

            // display message
            labelStatus.Content = strMsg;
            ListModelsInGrid();
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // UPDATE
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lwdom_JobType_Model jtMod = new lwdom_JobType_Model();
            string strMsg = "";

            jtMod = LoadDataForUpdate();
            strMsg = JTWkr.Update_JobType_rec(jtMod);

            // message
            labelStatus.Content = strMsg;
            ListModelsInGrid();
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // Clear display fields and LabelStatus on Cancel
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            InitialButtonConfiguration();
            labelStatus.Content = "";
        }


        // DELETE
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;

            result = MessageBox.Show("You are about to Delete a record.\nDo you want to continue?", "Delete",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            string strMsg = "";

            if (MessageBoxResult.OK == result)
            {
                bool TFValue = false;
                Int32 num = 0;

                TFValue = Int32.TryParse(lblID.Content.ToString(), out num);

                if (TFValue)
                {
                    strMsg = JTWkr.Delete_JobType_rec(num);
                }
                else
                {
                    strMsg = "Record ID problem";
                }
            }
            else
            {
                strMsg = "Delete Cancelled.";
            }

            // reset and configure
            ResetDisplayFields();
            InitialButtonConfiguration();

            // list data
            ListModelsInGrid();

            // message
            labelStatus.Content = strMsg;
        }


        // Select Job Type Record
        private void JobType_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datagrid = (DataGrid)JobType_DataGrid;
            var itm = datagrid.SelectedItem;
            if ((itm is lwdom_JobType_Model) == false) return;

            lwdom_JobType_Model jtMod = (lwdom_JobType_Model)itm;

            // display data
            DisplayData(jtMod);

            // display message
            labelStatus.Content = "ID: " + jtMod.ID.ToString();
            UpdateButtonConfiguration();
        }



        // load data for update
        private lwdom_JobType_Model LoadDataForUpdate()
        {
            lwdom_JobType_Model jtMod = new lwdom_JobType_Model();

            jtMod.ID = Convert.ToInt64(lblID.Content.ToString());
            jtMod.JobType = txtJobType.Text.Trim();

            // return model
            return jtMod;
        }


        // Display data from grid
        private void DisplayData(lwdom_JobType_Model jtMod)
        {
            lblID.Content = jtMod.ID;
            txtJobType.Text = jtMod.JobType;
        }


        // initial button configuration
        private void InitialButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDelete.Visibility = Visibility.Hidden;
            //
            DisableDisplayFields();
        }


        // ADD button configuration
        private void ADDButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Visible;
            buttonUpdate.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDelete.Visibility = Visibility.Hidden;
            //
            EnableDisplayFields();
        }



        // Update button configuration
        private void UpdateButtonConfiguration()
        {
            buttonADD.Visibility = Visibility.Hidden;
            buttonUpdate.Visibility = Visibility.Visible;
            buttonCancel.Visibility = Visibility.Visible;
            buttonDelete.Visibility = Visibility.Visible;
            //
            EnableDisplayFields();
        }



        // reset display fields
        public void ResetDisplayFields()
        {
            lblID.Content = "";
            txtJobType.Text = "";
        }


        // Disable display fields
        public void DisableDisplayFields()
        {
            txtJobType.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtJobType.IsEnabled = true;
        }


        // list models in grid
        private void ListModelsInGrid()
        {
            // List RateID - Job Type Models
            List<lwdom_JobType_Model> jtMod_List = JTWkr.Get_JobType_List();
            JobType_DataGrid.DataContext = jtMod_List;
        }
    }
}
