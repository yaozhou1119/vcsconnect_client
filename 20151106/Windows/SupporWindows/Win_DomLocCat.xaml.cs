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
    /// Interaction logic for Win_DomLocCat.xaml
    /// </summary>
    public partial class Win_DomLocCat : Window
    {
        // Worker
        lwdom_LocCat_Worker LCWkr;

        // constructor
        public Win_DomLocCat()
        {
            InitializeComponent();

            // Worker
            LCWkr = new lwdom_LocCat_Worker();

            // load grid
            ListModelsInGrid();

            // reset and initialize buttons
            ResetDisplayFields();
            InitialButtonConfiguration();
        }

        // place application in ADD configuration
        private void menuAddLocCat_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            ADDButtonConfiguration();

            // clear message
            labelStatus.Content = "";
        }


        // menu Exit Point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // ADD Record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lwdom_LocCat_Model lcMod = new lwdom_LocCat_Model();
            string strMsg = "";

            // load data
            lcMod = LoadDataForUpdate();

            // add the record
            strMsg = LCWkr.Add_LocCat_Rec(lcMod);

            // display message
            labelStatus.Content = strMsg;
            ListModelsInGrid();
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // UPDATE Record
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            lwdom_LocCat_Model lcMod = new lwdom_LocCat_Model();
            string strMsg = "";

            // load data
            lcMod = LoadDataForUpdate();

            // Update the record
            strMsg = LCWkr.Update_LocCat_rec(lcMod);

            // display message
            labelStatus.Content = strMsg;
            ListModelsInGrid();
            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // cancel - reset and initialize button configura
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            InitialButtonConfiguration();

            // clear message
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
                    strMsg = LCWkr.Delete_LocCat_rec(num);
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


        // Select Record from Data Grid
        private void LocCat_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datagrid = (DataGrid)LocCat_DataGrid;
            var itm = datagrid.SelectedItem;
            if ((itm is lwdom_LocCat_Model) == false) return;

            lwdom_LocCat_Model lcMod = (lwdom_LocCat_Model)itm;

            // display data
            DisplayData(lcMod);

            // display message
            labelStatus.Content = "ID: " + lcMod.ID.ToString();
            UpdateButtonConfiguration();
        }


        // load data for update
        private lwdom_LocCat_Model LoadDataForUpdate()
        {
            lwdom_LocCat_Model lcMod = new lwdom_LocCat_Model();
            bool result = false;
            Int64 iNum = 0;

            // try Parse
            result = Int64.TryParse(lblID.Content.ToString(), out iNum);
            lcMod.ID = (result) ? iNum : 0;

            lcMod.LocCatDesc = txtLocCatDesc.Text.Trim();

            // return model
            return lcMod;
        }


        // Display data from grid
        private void DisplayData(lwdom_LocCat_Model lcMod)
        {
            lblID.Content = lcMod.ID;
            txtLocCatDesc.Text = lcMod.LocCatDesc;
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
            txtLocCatDesc.Text = "";
        }


        // Disable display fields
        public void DisableDisplayFields()
        {
            txtLocCatDesc.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtLocCatDesc.IsEnabled = true;
        }


        // list models in grid
        private void ListModelsInGrid()
        {
            // List Loc Cat Models
            List<lwdom_LocCat_Model> lcMod_List = LCWkr.Get_LocCat_List();
            LocCat_DataGrid.DataContext = lcMod_List;
        }
    }
}
