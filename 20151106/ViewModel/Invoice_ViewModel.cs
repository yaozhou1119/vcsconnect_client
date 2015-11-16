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
    class Invoice_ViewModel : ViewModelBase
    {
        // Get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();

        // worker
        lw_Invoice_Worker INVWkr;

        // private definitions
        private List<lw_Invoice_Model> _invvmMod_List;
        private string _strMsg;
        private string _UpdateResult;
        private string _AddResult;

        // constructor
        public Invoice_ViewModel()
        {
            // worker
            INVWkr = new lw_Invoice_Worker();

            _strMsg = "";
        }

        // properties
        public List<lw_Invoice_Model> invvmMod_List
        {
            get
            {
                return _invvmMod_List;
            }
            set
            {
                if (_invvmMod_List != value)
                {
                    _invvmMod_List = value;
                    OnPropertyChanged("INVList");
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
        public void Get_Invoice_Async()
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Invoices
                return INVWkr.Get_Invoice_List(ref _strMsg);
            })
                .ContinueWith(task => invvmMod_List = task.Result, context);
        }



        // Async Get Method by date
        public void Get_InvoiceByDate_Async(string strDate)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Invoices by date
                return INVWkr.Get_Invoice_InvoiceDate_List(strDate);
            })
                .ContinueWith(task => invvmMod_List = task.Result, context);
        }



        // Async Get Method by LIKE InvoiceID
        public void Get_Invoice_ByLIKEInvoiceID_Async(string strInvID)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Invoices by date
                return INVWkr.Get_Invoice_LIKEInvoiceID_List(strInvID);
            })
                .ContinueWith(task => invvmMod_List = task.Result, context);
        }


        // Async Add Method
        public void Add_Invoice_Async(lw_Invoice_Model invMod)
        {
            // async thread
            Task.Run(() =>
            {
                // add Invoice record
                return INVWkr.Add_Invoice_Rec(invMod);
            })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        // Aysnc Update Method
        public void Update_Invoice_Async(lw_Invoice_Model invMod)
        {
            // aysnc thread
            Task.Run(() =>
            {
                // update work order record
                return INVWkr.Update_Invoice_rec(invMod);
            })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}
