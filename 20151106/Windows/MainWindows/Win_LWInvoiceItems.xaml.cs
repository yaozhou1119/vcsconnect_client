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

namespace VcsConnect_Client.Windows.MainWindows
{
    /// <summary>
    /// Interaction logic for Win_LWInvoiceItems.xaml
    /// </summary>
    public partial class Win_LWInvoiceItems : Window
    {
        // model
        private lw_InvoiceItems_Model _iiMod;

        // constructor
        public Win_LWInvoiceItems(lw_InvoiceItems_Model iiMod)
        {
            InitializeComponent();
            _iiMod = new lw_InvoiceItems_Model();
            _iiMod = iiMod;

            // display data
            busy_Indicator.IsBusy = false;
            uc_InvItemDetail.DataContext = _iiMod;

            // LISTENER: CANCEL
            uc_InvItemDetail.OnInvItem_CANCEL += (o, e) =>
            {
                // on a cancle close the window
                this.Close();
            };
        }

        // menu Exit Point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
