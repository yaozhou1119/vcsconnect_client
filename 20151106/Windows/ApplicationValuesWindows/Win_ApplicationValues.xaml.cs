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
using VcsConnect_Client.Models.ApplicationValues;
// worker
using VcsConnect_Client.Workers.ApplicationValue_Workers;

namespace VcsConnect_Client.Windows.ApplicationValuesWindows
{
    /// <summary>
    /// Interaction logic for Win_ApplicationValues.xaml
    /// </summary>
    public partial class Win_ApplicationValues : Window
    {
        // constructor
        public Win_ApplicationValues()
        {
            InitializeComponent();

            // busyIndication
            busy_Indicator.IsBusy = false;


            // LISTENER: ADD
            ucAppValues.OnAV_ADD += (o, e) =>
            {
                // turn off busy Indicator
                busy_Indicator.IsBusy = false;
                labelStatus.Content = o.ToString();
                ucAppValues.Execute_UpdateButtonConfig();
            };


            // LISTENER: CANCEL
            ucAppValues.OnAV_CANCEL += (o, e) =>
            {
                // exit window
                this.Close();
            };


            // LISTENER: UPDATE
            ucAppValues.OnAV_UPDATE += (o, e) =>
            {
                // turn off busy Indicator
                busy_Indicator.IsBusy = false;
                labelStatus.Content = o.ToString();
            };
        }


        // menu exit point
        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
