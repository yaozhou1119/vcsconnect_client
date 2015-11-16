using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// models
using VcsConnect_Client.Models.SQL_Models;
// worker
using VcsConnect_Client.Workers.SQL_Workers;


namespace VcsConnect_Client.ViewModel
{
    class InvoiceItemExpense_ViewModel : ViewModelBase
    {
        // Get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();

        // worker
        lw_InvoiceExpenseItems_Worker IEIWkr;

        // private definitions
        private List<lw_InvoiceExpenseItems_Model> _ieivmMod_List;
        private string _strMsg;
        private string _UpdateResult;
        private string _AddResult;

        // constructor
        public InvoiceItemExpense_ViewModel()
        {
            // worker
            IEIWkr = new lw_InvoiceExpenseItems_Worker();

            _strMsg = "";
        }

        // properties
        public List<lw_InvoiceExpenseItems_Model> ieivmMod_List
        {
            get
            {
                return _ieivmMod_List;
            }
            set
            {
                if (_ieivmMod_List != value)
                {
                    _ieivmMod_List = value;
                    OnPropertyChanged("InvExpItems_List");
                }
            }
        }

        public string UpdateResult
        {
            get
            {
                return _UpdateResult;
            }
            set
            {
                _UpdateResult = value;
                OnPropertyChanged("UpdateResult");
            }
        }

        public string AddResult
        {
            get
            {
                return _AddResult;
            }
            set
            {
                _AddResult = value;
                OnPropertyChanged("AddResult");
            }
        }


        // Async Get Method
        public void Get_InvExpItems_Async()
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Inv Expense Items
                return IEIWkr.Get_InvExpensItems_List(ref _strMsg);
            })
                .ContinueWith(task => ieivmMod_List = task.Result, context);
        }



        // Async Get Method by date
        public void Get_InvExpItems_byInvoiceID_Async(string _InvoiceID)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Inv Exp Items by Invoice ID
                return IEIWkr.Get_InvExpensItems_byInvoiceID_List(_InvoiceID);
            })
                .ContinueWith(task => ieivmMod_List = task.Result, context);
        }



        // Async Get Method by Category
        public void Get_InvExpItems_byCategory_Async(string _Category)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Inv Exp Items by Category
                return IEIWkr.Get_InvExpensItems_byCategory_List(_Category);
            })
                .ContinueWith(task => ieivmMod_List = task.Result, context);
        }



        // Async Get Method by SQL LIKE Invoice ID
        public void Get_InvExpItems_byLIKEInvoiceID_Async(string _invID)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Inv Exp Items by wild card LIKE and InvoiceID
                return IEIWkr.Get_InvExpensItems_LIKEInvoiceID_List(_invID);
            })
                .ContinueWith(task => ieivmMod_List = task.Result, context);
        }



        // Async Add Method
        public void Add_InvExpItems_Async(lw_InvoiceExpenseItems_Model ieiMod)
        {
            // async thread
            Task.Run(() =>
            {
                // add Invoice Item record
                return IEIWkr.Add_InvExpensItems_Rec(ieiMod);
            })
                .ContinueWith(task => AddResult = task.Result, context);
        }



        // Aysnc Update Method
        public void Update_InvExpItems_Async(lw_InvoiceExpenseItems_Model ieiMod)
        {
            // aysnc thread
            Task.Run(() =>
            {
                // update Invoice Item record
                return IEIWkr.Update_InvExpensItems_rec(ieiMod);
            })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}
