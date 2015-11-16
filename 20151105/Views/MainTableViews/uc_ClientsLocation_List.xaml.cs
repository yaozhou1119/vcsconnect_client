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
    /// Interaction logic for uc_ClientsLocation_List.xaml
    /// </summary>
    public partial class uc_ClientsLocation_List : UserControl
    {
        // routed event handler
        public RoutedEventHandler OnClientLocation_SELECTED;

        // constructor
        public uc_ClientsLocation_List()
        {
            InitializeComponent();
        }


        // Selection Event
        private void ClientLocation_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnClientLocation_SELECTED != null) OnClientLocation_SELECTED(sender, new RoutedEventArgs());
        }
    }
}
