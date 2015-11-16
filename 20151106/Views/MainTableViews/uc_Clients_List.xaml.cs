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
    /// Interaction logic for uc_Clients_List.xaml
    /// </summary>
    public partial class uc_Clients_List : UserControl
    {
        public RoutedEventHandler OnClient_SelectedChanged;

        // constructor
        public uc_Clients_List()
        {
            InitializeComponent();
        }


        // Selected Record Event
        private void Client_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnClient_SelectedChanged != null) OnClient_SelectedChanged(sender, new RoutedEventArgs());
        }
    }
}
