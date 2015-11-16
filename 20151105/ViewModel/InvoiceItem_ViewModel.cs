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
    class InvoiceItem_ViewModel : ViewModelBase
    {
        // Get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();

        // worker
        lw_InvoiceItems_Worker IIWkr;

        // private definitions
        private List<lw_InvoiceItems_Model> _iivmMod_List;
        private string _strMsg;
        private string _UpdateResult;
        private string _AddResult;

        // constructor
        public InvoiceItem_ViewModel()
        {
            // worker
            IIWkr = new lw_InvoiceItems_Worker();

            _strMsg = "";
        }

        // properties
        public List<lw_InvoiceItems_Model> iivmMod_List
        {
            get
            {
                return _iivmMod_List;
            }
            set
            {
                if (_iivmMod_List != value)
                {
                    _iivmMod_List = value;
                    OnPropertyChanged("InvItm_List");
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
        public void Get_InvoiceItem_Async()
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Invoices
                return IIWkr.Get_InvoiceItem_List(ref _strMsg);
            })
                .ContinueWith(task => iivmMod_List = task.Result, context);
        }



        // Async Get Method by date
        public void Get_InvoiceItemByInvoiceID_Async(string _InvoiceID)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Invoices by Invoice ID
                return IIWkr.Get_InvoiceItem_byInvoiceID_List(_InvoiceID);
            })
                .ContinueWith(task => iivmMod_List = task.Result, context);
        }



        // Async Add Method
        public void Add_InvoiceItem_Async(lw_InvoiceItems_Model iiMod)
        {
            // async thread
            Task.Run(() =>
            {
                // add Invoice Item record
                return IIWkr.Add_InvoiceItem_Rec(iiMod);
            })
                .ContinueWith(task => AddResult = task.Result, context);
        }



        // Aysnc Update Method
        public void Update_InvoiceItem_Async(lw_InvoiceItems_Model iiMod)
        {
            // aysnc thread
            Task.Run(() =>
            {
                // update Invoice Item record
                return IIWkr.Update_InvoiceItem_rec(iiMod);
            })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}
