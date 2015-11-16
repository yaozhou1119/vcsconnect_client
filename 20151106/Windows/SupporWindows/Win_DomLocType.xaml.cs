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
    /// Interaction logic for Win_DomLocType.xaml
    /// </summary>
    public partial class Win_DomLocType : Window
    {
        // Worker
        lwdom_LocType_Worker LTWkr;

        // constructor
        public Win_DomLocType()
        {
            InitializeComponent();

            // worker
            LTWkr = new lwdom_LocType_Worker();

            // reset field and initialize buttons
            ResetDisplayFields();
            InitialButtonConfiguration();

            // list models in data grid
            ListModelsInGrid();
        }


        // Add Enable
        private void menuAddLocType_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            ADDButtonConfiguration();

            // change key board focus
            Keyboard.Focus(txtLocTypeDesc);
        }


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // ADD Record
        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {
            lwdom_LocType_Model ltMod = new lwdom_LocType_Model();
            string strMsg = "";

            // loads model with data from view
            ltMod = LoadData_IntoModel();

            // display message
            labelStatus.Content = strMsg;
            
            // add the record
            if (ltMod.LocTypeDesc.Trim() != "")
            {
                strMsg = LTWkr.Add_LocType_Rec(ltMod);
            }
            else
            {
                strMsg = "ADD Canceled. No data entered.";
                MessageBox.Show(strMsg, "Rate Name", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // display the message
            labelStatus.Content = strMsg;

            // list data
            ListModelsInGrid();

            ResetDisplayFields();
            InitialButtonConfiguration();
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {

        }


        // Cancel
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayFields();
            InitialButtonConfiguration();
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LocType_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        // Display data from grid
        private void DisplayData(lwdom_LocType_Model ltMod)
        {
            lblID.Content = ltMod.ID;
            txtLocTypeDesc.Text = ltMod.LocTypeDesc;
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
            txtLocTypeDesc.Text = "";
        }


        // Disable display fields
        public void DisableDisplayFields()
        {
            txtLocTypeDesc.IsEnabled = false;
        }


        // Enable display fields
        public void EnableDisplayFields()
        {
            txtLocTypeDesc.IsEnabled = true;
        }


        // list models in grid
        private void ListModelsInGrid()
        {
            // List Loc Type Models
            List<lwdom_LocType_Model> ltMod_List = LTWkr.Get_LocType_List();
            LocType_DataGrid.DataContext = ltMod_List;
        }


        // load data into the model
        private lwdom_LocType_Model LoadData_IntoModel()
        {
            lwdom_LocType_Model ltMod = new lwdom_LocType_Model();
            bool result = false;
            Int64 intID = 0;

            // read display fields load data
            result = Int64.TryParse(lblID.Content.ToString(), out intID);
            ltMod.ID = (result) ? intID : 0;
            ltMod.LocTypeDesc = txtLocTypeDesc.Text.Trim();

            // return model
            return ltMod;
        }
    }
}
