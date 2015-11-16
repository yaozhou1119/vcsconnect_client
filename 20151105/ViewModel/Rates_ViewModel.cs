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
    class Rates_ViewModel : ViewModelBase
    {
        // get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();

        // private definitions
        private List<lwdom_Rates_Model> _rvmMod_List;
        private string _UpdateResult;
        private string _AddResult;


        // worker
        lwdom_Rates_Worker RWkr;


        // constructor
        public Rates_ViewModel()
        {
            // worker
            RWkr = new lwdom_Rates_Worker();
        }


        // properties
        public List<lwdom_Rates_Model> rvmMod_List
        {
            get
            {
                return _rvmMod_List;
            }
            set
            {
                if(_rvmMod_List != value)
                {
                    _rvmMod_List = value;
                    OnPropertyChanged("Rates_List");
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


        // Async Methods
        public void Get_Rates_Async()
        {
            // Async thread
            Task.Run(() =>
                {
                    return RWkr.Get_Rates_List();
                })
                .ContinueWith(task => rvmMod_List = task.Result, context);
        }


        // Get Rates by Rate Year
        public void Get_Rates_byRateYear_Async(int intRY)
        {
            // Async thread
            Task.Run(() =>
            {
                return RWkr.Get_Rates_ByRateYear_List(intRY);
            })
                .ContinueWith(task => rvmMod_List = task.Result, context);
        }


        // Get Rates by Rate ID
        public void Get_Rates_byRateID_Async(string rID)
        {
            // Async thread
            Task.Run(() =>
            {
                return RWkr.Get_Rates_ByRateID_List(rID);
            })
                .ContinueWith(task => rvmMod_List = task.Result, context);
        }


        public void Add_Rate_Async(lwdom_Rates_Model rMod)
        {
            // Aysnc thread
            Task.Run(() =>
                {
                    return RWkr.Add_Rates_Rec(rMod);
                })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        public void Update_Rates_Async(lwdom_Rates_Model rMod)
        {
            // Async thread
            Task.Run(() =>
                {
                    return RWkr.Update_Rates_rec(rMod);
                })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}