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
    class Contact_ViewModel : ViewModelBase
    {
        // get the UI thread's context
        private TaskScheduler context = TaskScheduler.FromCurrentSynchronizationContext();


        // private definitions
        private List<lw_ClientContacts_Model> _ccvmMod_List;

        private string _UpdateResult;
        private string _AddResult;
        private string _strMsg;


        // worker
        lw_ClientContact_Worker CCWkr;


        // constructor
        public Contact_ViewModel()
        {
            // worker
            CCWkr = new lw_ClientContact_Worker();
            _strMsg = "";
        }


        // properties
        public List<lw_ClientContacts_Model> ccvmMod_List
        {
            get
            {
                return _ccvmMod_List;
            }
            set
            {
                if(_ccvmMod_List != value)
                {
                    _ccvmMod_List = value;
                    OnPropertyChanged("Contact_List");
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
        public void Get_ContactList_Async(string strStatus)
        {
            // Async thread
            Task.Run(() =>
                {
                    return CCWkr.Get_ClientContacts_List(ref _strMsg, strStatus);
                })
                .ContinueWith(task => ccvmMod_List = task.Result, context);
        }


        // Async Methods search Client Contact by Like last name
        public void Get_ContactList_byLIKELastName_Async(string strStatus, string strLN)
        {
            // Async thread
            Task.Run(() =>
            {
                return CCWkr.Get_ClientContacts_byLIKELastName_List(strStatus, strLN);
            })
                .ContinueWith(task => ccvmMod_List = task.Result, context);
        }


        public void Add_Contact_Async(lw_ClientContacts_Model ccMod)
        {
            // Aysnc thread
            Task.Run(() =>
                {
                    return CCWkr.Add_ClientContact_Rec(ccMod);
                })
                .ContinueWith(task => AddResult = task.Result, context);
        }


        public void Update_Contact_Async(lw_ClientContacts_Model ccMod)
        {
            // Async thread
            Task.Run(() =>
                {
                    return CCWkr.Update_ClientContact_rec(ccMod);
                })
                .ContinueWith(task => UpdateResult = task.Result, context);
        }
    }
}

