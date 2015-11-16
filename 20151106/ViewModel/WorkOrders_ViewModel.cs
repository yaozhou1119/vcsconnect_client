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
    class WorkOrders_ViewModel : ViewModelBase
    {
        // Get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();

        // worker
        lw_WorkOrders_Worker WOWkr;

        // private definitions
        private List<lw_WorkOrder_Model> _wovmMod_List;
        private string _strMsg;
        private string _UpdateResult;
        private string _AddResult;

        // constructor
        public WorkOrders_ViewModel()
        {
            // worker
            WOWkr = new lw_WorkOrders_Worker();

            _strMsg = "";
        }

        // properties
        public List<lw_WorkOrder_Model> wovmMod_List
        {
            get
            {
                return _wovmMod_List;
            }
            set
            {
                if (_wovmMod_List != value)
                {
                    _wovmMod_List = value;
                    OnPropertyChanged("WOList");
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
        public void Get_WorkOrders_Async()
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Bids
                return WOWkr.Get_WorkOrder_List(ref _strMsg);
            })
                .ContinueWith(task => wovmMod_List = task.Result, context);
        }



        // Async Get Method by date
        public void Get_WorkOrdersByDate_Async(string strDate)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Work Orders
                return WOWkr.Get_WorkerOrders_bySelectedDate_List(strDate);
            })
                .ContinueWith(task => wovmMod_List = task.Result, context);
        }


        // Async Get Method by LIKE Client Name
        public void Get_WorkOrders_LIKEClientName_Async(string clName)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Work Orders by LIKE Client Name
                return WOWkr.Get_WorkerOrders_byLIKEClientName_List(clName);
            })
                .ContinueWith(task => wovmMod_List = task.Result, context);
        }



        // Async Add Method
        public void Add_WorkOrders_Async(lw_WorkOrder_Model woMod)
        {
            // async thread
            Task.Run(() =>
            {
                // add WorkOrders record
                return WOWkr.Add_WorkOrder_Rec(woMod);
            })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        // Aysnc Update Method
        public void Update_WorkOrders_Async(lw_WorkOrder_Model woMod)
        {
            // aysnc thread
            Task.Run(() =>
            {
                // update work order record
                return WOWkr.Update_WorkOrder_rec(woMod);
            })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }


        // Aysnc DELETE Method
        public void DELETE_WorkOrders_Async(Int64 recID)
        {
            // aysnc thread
            Task.Run(() =>
            {
                // DELETE work order record based on ID
                return WOWkr.Delete_WorkOrder_rec(recID);
            })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}
