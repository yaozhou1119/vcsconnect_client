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

namespace VcsConnect_Client.Views.SupportViews
{
    /// <summary>
    /// Interaction logic for uc_ChemList_List.xaml
    /// </summary>
    public partial class uc_ChemList_List : UserControl
    {
        // routed event handle
        public RoutedEventHandler OnChemList_SELECTED;
        public RoutedEventHandler OnChemList_StatusSELECTED;


        // constructor
        public uc_ChemList_List()
        {
            InitializeComponent();
        }


        // selecting a record
        private void ChemList_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnChemList_SELECTED != null) OnChemList_SELECTED(sender, new RoutedEventArgs());
        }


        // Selecting Chem Records by Active Status
        private void cboChemActiveStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string strSelect = "";

            // read selected value from combo box,
            // this way is used because comboBoxItem
            // is used to define values in the XAML
            ComboBoxItem cbi = (ComboBoxItem)cboChemActiveStatus.SelectedItem;
            if (cbi != null)
            {
                strSelect = cbi.Content.ToString();
                cboChemActiveStatus.Text = strSelect;
            }
            else
            {
                strSelect = "";
                cboChemActiveStatus.Text = "";
            }

            sender = strSelect;

            // Chem Status Selection Event
            if (OnChemList_StatusSELECTED!= null) OnChemList_StatusSELECTED(sender, new RoutedEventArgs());
        }
    }
}
