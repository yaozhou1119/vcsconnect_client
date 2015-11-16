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
    class Client_ViewModel: ViewModelBase
    {
        // get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();


        // private definitions
        private List<lw_Client_Model> _cvmMod_List;
        private string _UpdateResult;
        private string _AddResult;
        private string _strMsg;


        // worker
        lw_Client_Worker CWkr;


        // constructor
        public Client_ViewModel()
        {
            // worker
            CWkr = new lw_Client_Worker();
            _strMsg = "";
        }


        // properties
        public List<lw_Client_Model> cvmMod_List
        {
            get
            {
                return _cvmMod_List;
            }
            set
            {
                if(_cvmMod_List != value)
                {
                    _cvmMod_List = value;
                    OnPropertyChanged("Client_List");
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
        public void Get_Clients_Async(string ActiveStatus)
        {
            // Async thread
            Task.Run(() =>
                {
                    return CWkr.Get_Client_List(ref _strMsg, ActiveStatus);
                })
                .ContinueWith(task => cvmMod_List = task.Result, context);
        }



        // Get Client list by LIKE used with the Client Name
        public void Get_Clients_LIKEName_Async(string _status, string _clName)
        {
            // Async thread
            Task.Run(() =>
            {
                return CWkr.Get_Client_LIKEName_List(_status, _clName);
            })
                .ContinueWith(task => cvmMod_List = task.Result, context);
        }


        public void Add_Client_Async(lw_Client_Model cMod)
        {
            // Aysnc thread
            Task.Run(() =>
                {
                    return CWkr.Add_Client_Rec(cMod);
                })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        public void Update_Client_Async(lw_Client_Model cMod)
        {
            // Async thread
            Task.Run(() =>
                {
                    return CWkr.Update_Client_rec(cMod);
                })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}
