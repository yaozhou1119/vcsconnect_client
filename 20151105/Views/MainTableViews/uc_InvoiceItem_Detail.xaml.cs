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
// model
using VcsConnect_Client.Models.SQL_Models;

namespace VcsConnect_Client.Views.MainTableViews
{
    /// <summary>
    /// Interaction logic for uc_InvoiceItem_Detail.xaml
    /// </summary>
    public partial class uc_InvoiceItem_Detail : UserControl
    {
        // routed event handler
        public RoutedEventHandler OnInvItem_CANCEL;

        // constructor
        public uc_InvoiceItem_Detail()
        {
            InitializeComponent();
        }

        private void buttonADD_Enable_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonADD_Enable_Blank_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonADD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {

        }


        // Cancel
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            // event
            if (OnInvItem_CANCEL != null) OnInvItem_CANCEL(sender, new RoutedEventArgs());
        }


        private void buttonDELETE_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
