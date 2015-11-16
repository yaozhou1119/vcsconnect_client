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

namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_Employees_List.xaml
    /// </summary>
    public partial class uc_Employees_List : UserControl
    {
        // routed event handler
        public RoutedEventHandler OnEmployee_SELECTED;

        // constructor
        public uc_Employees_List()
        {
            InitializeComponent();
        }


        // Selection Event
        private void Employee_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnEmployee_SELECTED != null) OnEmployee_SELECTED(sender, new RoutedEventArgs());
        }
    }
}
