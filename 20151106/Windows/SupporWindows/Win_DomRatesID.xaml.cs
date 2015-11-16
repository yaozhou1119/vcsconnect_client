using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Win_DomRatesID.xaml
    /// </summary>
    public partial class Win_DomRatesID : Window
    {
        // worker
        lwdom_RatesID_Worker LWRIDWkr;

        // constructor
        public Win_DomRatesID()
        {
            InitializeComponent();

            // worker
            LWRIDWkr = new lwdom_RatesID_Worker();

            // display list of models in grid
            ListModelInGrid();

            // reset and initialize
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // ADD Enabled
        private void menuAddRateID_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            ADDButtonConfiguration();
        }


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // ADD record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            string strMsg = "";
            lwdom_RatesID_Model lwridMod = new lwdom_RatesID_Model();

            // loads model with data from view
            lwridMod = LoadRatesID_Model();

            // add the record
            if (lwridMod.RateName.Trim() != "")
            {
                strMsg = LWRIDWkr.Add_RatesID_Rec(lwridMod);
            }
            else
            {
                strMsg = "ADD Canceled. No data entered.";
                MessageBox.Show(strMsg, "Rate Name", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // display the message
            labelStatus.Content = strMsg;

            // list data
            ListModelInGrid();

            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // UPDATE
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            string strMsg = "";
            lwdom_RatesID_Model lwridMod = new lwdom_RatesID_Model();

            // loads model with data from view
            lwridMod = LoadRatesID_Model();

            // add the record
            strMsg = LWRIDWkr.Update_RatesID_rec(lwridMod);

            // display the message
            labelStatus.Content = strMsg;

            // list data
            ListModelInGrid();

            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // CANCEL
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
                    strMsg = LWRIDWkr.Delete_RatesID_rec(num);
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
            ListModelInGrid();

            // message
            labelStatus.Content = strMsg;
        }

        

        // Select Record
        private void RatesID_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datagrid = (DataGrid)RatesID_DataGrid;
            var itm = datagrid.SelectedItem;
            if ((itm is lwdom_RatesID_Model) == false) return;

            lwdom_RatesID_Model lwridMod = (lwdom_RatesID_Model)itm;

            // display data
            DisplayData(lwridMod);

            // display message
            labelStatus.Content = "ID: " + lwridMod.ID.ToString();
            UpdateButtonConfiguration();
        }


        // display the data
        private void DisplayData(lwdom_RatesID_Model lwridMod)
        {
            lblID.Content = lwridMod.ID.ToString();
            txtRateName.Text = lwridMod.RateName;
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
            txtRateName.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            txtRateName.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtRateName.IsEnabled = true;
        }


        // list models in grid
        private void ListModelInGrid()
        {
            // List RateID - Rate Name Models
            List<lwdom_RatesID_Model> lwridMod_List =  LWRIDWkr.Get_RatesID_List();
            RatesID_DataGrid.DataContext = lwridMod_List;
        }



        // load data model with data from window
        private lwdom_RatesID_Model LoadRatesID_Model()
        {
            int _id = 0;
            bool result = false;

            lwdom_RatesID_Model lwridMod = new lwdom_RatesID_Model();
            result = int.TryParse(lblID.Content.ToString(), out _id);
            lwridMod.ID = (result == true) ? _id : 0;
            lwridMod.RateName = txtRateName.Text.Trim();

            // return model
            return lwridMod;
        }
    }
}
