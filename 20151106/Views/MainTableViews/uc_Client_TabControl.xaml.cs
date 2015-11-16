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
    /// Interaction logic for uc_Client_TabControl.xaml
    /// </summary>
    public partial class uc_Client_TabControl : UserControl
    {
        // constructor
        public uc_Client_TabControl()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
