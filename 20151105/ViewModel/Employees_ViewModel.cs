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
    class Employees_ViewModel : ViewModelBase
    {
        // get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();


        // private definitions
        private List<lw_Employees_Model> _evmMod_List;

        
        private string _AddResult;
        private string _DeleteResult;
        private string _UpdateResult;

        private string _strMsg;


        // worker
        lw_Employees_Worker EWkr;


        // constructor
        public Employees_ViewModel()
        {
            // worker
            EWkr = new lw_Employees_Worker();
            _strMsg = "";
        }


        // properties
        public List<lw_Employees_Model> evmMod_List
        {
            get
            {
                return _evmMod_List;
            }
            set
            {
                if(_evmMod_List != value)
                {
                    _evmMod_List = value;
                    OnPropertyChanged("Employees_List");
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


        public string DeleteResult
        {
            get
            {
                return _DeleteResult;
            }
            set
            {
                _DeleteResult = value;
                OnPropertyChanged("DeleteResult");
            }
        }


        // Async Method: Get List
        public void Get_EmployeesList_Async(string strStatus)
        {
            // Async thread
            Task.Run(() =>
                {
                    return EWkr.Get_Employees_List(ref _strMsg, strStatus);
                })
                .ContinueWith(task => evmMod_List = task.Result, context);
        }


        // Async Method: Add Record
        public void Add_Employees_Async(lw_Employees_Model eMod)
        {
            // Aysnc thread
            Task.Run(() =>
                {
                    return EWkr.Add_Employee_Rec(eMod);
                })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        // Async Method: Update Record
        public void Update_Employees_Async(lw_Employees_Model eMod)
        {
            // Async thread
            Task.Run(() =>
                {
                    return EWkr.Update_Employee_rec(eMod);
                })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }


        // Async Method: DELETE Record
        public void Delete_Employees_Async(lw_Employees_Model eMod)
        {
            // Async thread
            Task.Run(() =>
            {
                return EWkr.Delete_Employee_rec(eMod.ID);
            })
                .ContinueWith(task => DeleteResult = task.Result, context);
        }
    }
}