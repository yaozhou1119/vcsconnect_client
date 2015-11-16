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
    class ClientLocation_ViewModel : ViewModelBase
    {
        // get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();


        // private definitions
        private List<lw_ClientLocations_Model> _clMod_List;
        private string _UpdateResult;
        private string _AddResult;


        // worker
        lw_ClientLocations_Worker CLWkr;


        // constructor
        public ClientLocation_ViewModel()
        {
            // worker
            CLWkr = new lw_ClientLocations_Worker();
        }


        // properties
        public List<lw_ClientLocations_Model> clMod_List
        {
            get
            {
                return _clMod_List;
            }
            set
            {
                if(_clMod_List != value)
                {
                    _clMod_List = value;
                    OnPropertyChanged("ClientLocations_List");
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
        public void Get_ClientLocations_Async()
        {
            // Async thread
            Task.Run(() =>
                {
                    return CLWkr.Get_ClientLocation_List();
                })
                .ContinueWith(task => clMod_List = task.Result, context);
        }



        // Get Client list by LIKE used with the Name
        public void Get_ClientLocations_LIKEName_Async(string _Name)
        {
            // Async thread
            Task.Run(() =>
            {
                return CLWkr.Get_ClientLocation_ByLIKEName_List(_Name);
            })
                .ContinueWith(task => clMod_List = task.Result, context);
        }


        public void Add_ClientLocations_Async(lw_ClientLocations_Model clMod)
        {
            // Aysnc thread
            Task.Run(() =>
                {
                    return CLWkr.Add_ClientLocation_Rec(clMod);
                })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        public void Update_ClientLocations_Async(lw_ClientLocations_Model clMod)
        {
            // Async thread
            Task.Run(() =>
                {
                    return CLWkr.Update_ClientLocation_rec(clMod);
                })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}
