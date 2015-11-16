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
    class Bids_ViewModel: ViewModelBase
    {
        // Get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();

        // private definitions
        private List<lw_Bids_Model> _bvmMod_List;
        private string _strMsg;
        private string _UpdateResult;
        private string _AddResult;

        // properties
        public List<lw_Bids_Model> bvmMod_List
        {
            get
            {
                return _bvmMod_List;
            }
            set
            {
                if(_bvmMod_List != value)
                {
                    _bvmMod_List = value;
                    OnPropertyChanged("BidsList");
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
        public void Get_Bids_Async()
        {
            // async thread
            Task.Run(() =>
                {
                    // return list of Bids
                    lw_Bids_Worker BWkr = new lw_Bids_Worker();
                    return BWkr.Get_Bids_List(ref _strMsg);
                })
                .ContinueWith(task => bvmMod_List = task.Result, context);
        }



        // Async Get Method
        public void Get_BidsByDate_Async(string strDate)
        {
            // async thread
            Task.Run(() =>
            {
                // return list of Bids
                lw_Bids_Worker BWkr = new lw_Bids_Worker();
                return BWkr.Get_Bids_ByBidSentDate_List(strDate);
            })
                .ContinueWith(task => bvmMod_List = task.Result, context);
        }


        // Async Add Method
        public void Add_Bids_Async(lw_Bids_Model bMod)
        {
            // async thread
            Task.Run(() =>
                {
                    // add bids record
                    lw_Bids_Worker BWkr = new lw_Bids_Worker();
                    return BWkr.Add_Bids_Rec(bMod);
                })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        // Aysnc Update Method
        public void Update_Bids_Async(lw_Bids_Model bMod)
        {
            // aysnc thread
            Task.Run(() =>
                {
                    lw_Bids_Worker BWkr = new lw_Bids_Worker();
                    return BWkr.Update_Bid_rec(bMod);
                })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}
