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
    class ChemList_ViewModel : ViewModelBase
    {
        // get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();

        // private definitions
        private List<lwdom_chemlist_Model> _clvmMod_List;
        private string _UpdateResult;
        private string _AddResult;


        // worker
        lwdom_chemlist_Woker CLWkr;


        // constructor
        public ChemList_ViewModel()
        {
            // worker
            CLWkr = new lwdom_chemlist_Woker();
        }


        // properties
        public List<lwdom_chemlist_Model> clvmMod_List
        {
            get
            {
                return _clvmMod_List;
            }
            set
            {
                if(_clvmMod_List != value)
                {
                    _clvmMod_List = value;
                    OnPropertyChanged("Chemical_List");
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
        public void Get_ChemList_Async()
        {
            // Async thread
            Task.Run(() =>
                {
                    return CLWkr.Get_ChemList_List();
                })
                .ContinueWith(task => clvmMod_List = task.Result, context);
        }


        // Get ChemList by Active Status
        public void Get_ChemList_byActiveStatus_Async(string activeStatus)
        {
            // Async thread
            Task.Run(() =>
            {
                return CLWkr.Get_ChemList_byStatus_List(activeStatus);
            })
                .ContinueWith(task => clvmMod_List = task.Result, context);
        }



        // Get Chem list by LIKE used with the ChemCode column
        public void Get_List_byLIKEChemCode_Async(string _chemCode)
        {
            // Async thread
            Task.Run(() =>
            {
                return CLWkr.Get_ChemList_LIKEChemCode_List(_chemCode);
            })
                .ContinueWith(task => clvmMod_List = task.Result, context);
        }


        public void Add_ChemList_Async(lwdom_chemlist_Model clMod)
        {
            // Aysnc thread
            Task.Run(() =>
                {
                    return CLWkr.Add_ChemList_Rec(clMod);
                })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        public void Update_ChemList_Async(lwdom_chemlist_Model clMod)
        {
            // Async thread
            Task.Run(() =>
                {
                    return CLWkr.Update_ChemList_rec(clMod);
                })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}