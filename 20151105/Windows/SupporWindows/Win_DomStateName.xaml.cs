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
    /// Interaction logic for Win_DomStateName.xaml
    /// </summary>
    public partial class Win_DomStateName : Window
    {
        // worker
        lwdom_StateName_Worker DSNWkr;

        // constructor
        public Win_DomStateName()
        {
            InitializeComponent();

            // worker
            DSNWkr = new lwdom_StateName_Worker();

            // display list of models in grid
            ListModels_InGrid();

            // reset and initialize
            ResetDisplayFields();
            InitialButtonConfiguration();
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
            txtStateName.Text = "";
        }



        // Disable display fields
        public void DisableDisplayFields()
        {
            txtStateName.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtStateName.IsEnabled = true;
        }

        // Add State Name configuration
        private void menuAddStateName_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            ADDButtonConfiguration();
            //
            labelStatus.Content = "Press ADD to save entry.";
        }


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // ADD Record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            string strMsg = "";
            lwdom_StateName_Model dsnMod = new lwdom_StateName_Model();

            // loads model with data from view
            dsnMod = Load_StateName_Model();

            // add the record
            if (dsnMod.StateName.Trim() != null)
            {
                strMsg = DSNWkr.Add_StateName_Rec(dsnMod);
            }
            else
            {
                strMsg = "ADD Canceled. No data entered.";
                MessageBox.Show(strMsg, "Rate Name", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // display the message
            labelStatus.Content = strMsg;

            // list data
            ListModels_InGrid();

            ResetDisplayFields();
            InitialButtonConfiguration();
        }


        // UPDATE Record
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            string strMsg = "";
            lwdom_StateName_Model dsnMod = new lwdom_StateName_Model();

            // loads model with data from view
            dsnMod = Load_StateName_Model();

            // add the record
            strMsg = DSNWkr.Update_StateName_rec(dsnMod);

            // display the message
            labelStatus.Content = strMsg;

            // list data
            ListModels_InGrid();

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


        // DELETE Record
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
                    strMsg = DSNWkr.Delete_StateName_rec(num);
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
            ListModels_InGrid();

            // message
            labelStatus.Content = strMsg;
        }




        // display the data
        private void DisplayData(lwdom_StateName_Model dsnMod)
        {
            lblID.Content = dsnMod.ID.ToString();
            txtStateName.Text = dsnMod.StateName;
        }



        // Select State Name from Data Grid
        private void StateName_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var datagrid = (DataGrid)StateName_DataGrid;
            var itm = datagrid.SelectedItem;
            if ((itm is lwdom_StateName_Model) == false) return;

            lwdom_StateName_Model dsnMod = (lwdom_StateName_Model)itm;

            // display data
            DisplayData(dsnMod);

            // display message
            labelStatus.Content = "ID: " + dsnMod.ID.ToString();
            UpdateButtonConfiguration();
        }

         // list models in grid
        private void ListModels_InGrid()
        {
            // List State Name - Models
            List<lwdom_StateName_Model> dsnMod_List = DSNWkr.Get_StateNames_List();
            StateName_DataGrid.DataContext = dsnMod_List;
        }



        // load data model with data from window
        private lwdom_StateName_Model Load_StateName_Model()
        {
            int _id = 0;
            bool result = false;

            lwdom_StateName_Model dsnMod = new lwdom_StateName_Model();

            result = int.TryParse(lblID.Content.ToString(), out _id);
            dsnMod.ID = (result == true) ? _id : 0;
            dsnMod.StateName = txtStateName.Text.Trim();

            // return model
            return dsnMod;
        }
    }
}
