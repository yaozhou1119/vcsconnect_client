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
// models
using VcsConnect_Client.Models.SQL_Models;
// workers
using VcsConnect_Client.Workers.SQL_Workers;

namespace VcsConnect_Client.Windows.SupporWindows
{
    /// <summary>
    /// Interaction logic for Win_LWChemList.xaml
    /// </summary>
    public partial class Win_LWChemList : Window
    {
        // creating and instance of the ViewModel
        private ViewModel.ChemList_ViewModel clVM = new ViewModel.ChemList_ViewModel();

        // workers 
        lwdom_chemlist_Woker LWCWkr;

        // private status
        private string _ActStatus;
        private string _SearchChemCode;

        // constructor
        public Win_LWChemList()
        {
            InitializeComponent();
            LWCWkr = new lwdom_chemlist_Woker();
            _ActStatus = "";


            // LISTENER: Selected data changed
            // Handle on ChemList selection changed events
            uc_ChemicalList_List.OnChemList_SELECTED += (o, e) =>
            {
                var datagrid = (DataGrid)o;
                var itm = datagrid.SelectedItem;
                if ((itm is lwdom_chemlist_Model) == false) return;

                lwdom_chemlist_Model selectedContent = (lwdom_chemlist_Model)itm;

                uc_ChemicalList_Detail.DataContext = selectedContent;

                labelStatus.Content = "ChemCode ID: " + selectedContent.ChemCode;
                uc_ChemicalList_Detail.Execute_UpdateButtonConfiguration();
            };

            

            // ADD ENABLED - used for both blank
            // and copy base ADD
            uc_ChemicalList_Detail.OnChemList_ADDEnabel += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();
            };



            // ADD Record
            uc_ChemicalList_Detail.OnChemList_ADD += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Chem List
                clVM.Get_ChemList_byActiveStatus_Async(_ActStatus);
            };

             

            // UPDATE Record
            uc_ChemicalList_Detail.OnChemList_UPDATE += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                _SearchChemCode = "";
                if (txtSearchChemCode != null) _SearchChemCode = txtSearchChemCode.Text.Trim();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Work Order List
                // SearchChemCode has value
                if (_SearchChemCode.Trim() != "")
                {
                    clVM.Get_List_byLIKEChemCode_Async(_SearchChemCode);
                }
                else
                {
                    // redisplay data in grid
                    // Get Async Chem List
                    // SearchChemCode does not have value
                    clVM.Get_ChemList_byActiveStatus_Async(_ActStatus);
                    txtSearchChemCode.Text.Trim();
                }
            };


            // DELETE Record
            uc_ChemicalList_Detail.OnChemList_DELETE += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Chem List
                clVM.Get_ChemList_byActiveStatus_Async(_ActStatus);
            };



            // CANCEL
            uc_ChemicalList_Detail.OnChemList_CANCEL += (o, e) =>
            {
                // display message
                labelStatus.Content = o.ToString();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // redisplay data in grid
                // Get Async Chem List
                clVM.Get_ChemList_Async();
                uc_ChemicalList_List.cboChemActiveStatus.Text = "";
            };



            // LISTENER: Async Get Chem List base on active
            // status selection
            uc_ChemicalList_List.OnChemList_StatusSELECTED += (o, e) =>
            {
                _ActStatus = o.ToString();

                // turn ON busy Indicator
                busy_Indicator.IsBusy = true;

                // reset and initial button
                uc_ChemicalList_Detail.Execute_InitialButtonConfiguration();

                // Get List, Async Get
                if (_ActStatus.Trim() != "")
                {
                    clVM.Get_ChemList_byActiveStatus_Async(_ActStatus);
                    uc_ChemicalList_List.LabelBanner.Content = "Chemical List (" + _ActStatus + ")";
                }
                else
                {
                    clVM.Get_ChemList_Async();
                    uc_ChemicalList_List.LabelBanner.Content = "Chemical List";
                }
            };



            // Listening for ViewModel Property Change
            // --------------------------------
            // Loading the data grid MVVM style
            // --------------------------------
            clVM.PropertyChanged += (o, e) =>
            {
                // the View Model is notifying us that a property was updated
                // checking for a specific property returned by the View Model
                if (e.PropertyName == "Chemical_List")
                {
                    uc_ChemicalList_List.DataContext = clVM.clvmMod_List;
                    labelStatus.Content = "Retrieved " + clVM.clvmMod_List.Count + " Chemicals.";

                    // turn off busy Indicator
                    busy_Indicator.IsBusy = false;

                    // change key board focus
                    Keyboard.Focus(txtSearchChemCode);
                }
            };


            // Telling the ViewModel to retieve data
            clVM.Get_ChemList_Async();
            labelStatus.Content = "Retrieving data...";
        }


        // menu Exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        // SQL LIKE based on chemCode
        private void txtSearchChemCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string chCode = txtSearchChemCode.Text.Trim();

            // display message
            labelStatus.Content = "";

            // turn ON busy Indicator
            busy_Indicator.IsBusy = true;

            // reset and initial button
            uc_ChemicalList_Detail.Execute_InitialButtonConfiguration();

            clVM.Get_List_byLIKEChemCode_Async(chCode);
        }
    }
}
