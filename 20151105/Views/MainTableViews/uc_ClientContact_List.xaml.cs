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
    /// Interaction logic for uc_ClientContact_List.xaml
    /// </summary>
    public partial class uc_ClientContact_List : UserControl
    {
        // routed events
        public RoutedEventHandler OnContact_SELECTED;

        // constructor
        public uc_ClientContact_List()
        {
            InitializeComponent();
        }


        // Contact Selection Event
        private void ClientContact_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OnContact_SELECTED != null) OnContact_SELECTED(sender, new RoutedEventArgs());
        }
    }
}
