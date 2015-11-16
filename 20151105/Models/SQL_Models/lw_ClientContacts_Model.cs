using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// worker
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lw_ClientContacts_Model
    {
        // private strings
        private string _LocationID;
        private string _ContactTitle;
        private string _ContactFN;
        private string _ContactLN;
        private string _OffPhone;
        private string _OffPhoneExt;
        private string _CellPhone;
        private string _FaxNum;
        private string _OthPhone;
        private string _Email;
        private string _Comments;
        private string _ActiveStatus;


        // based on SQL table: lw_ClientContacts
        // constructor
        public lw_ClientContacts_Model() { }

        // properties
        public Int64 ID { get; set; }
        public Int64 AccNum { get; set; }

        public string LocationID
        {
            get
            {
                if (_LocationID == null) _LocationID = "";
                return _LocationID;
            }
            set
            {
                _LocationID = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string ContactTitle
        {
            get
            {
                if (_ContactTitle == null) _ContactTitle = "";
                return _ContactTitle;
            }
            set
            {
                _ContactTitle = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string ContactFN
        {
            get
            {
                if (_ContactFN == null) _ContactFN = "";
                return _ContactFN;
            }
            set
            {
                _ContactFN = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string ContactLN
        {
            get
            {
                if (_ContactLN == null) _ContactLN = "";
                return _ContactLN;
            }
            set
            {
                _ContactLN = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string OffPhone
        {
            get
            {
                if (_OffPhone == null) _OffPhone = "";
                return _OffPhone;
            }
            set
            {
                _OffPhone = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string OffPhoneExt
        {
            get
            {
                if (_OffPhoneExt == null) _OffPhoneExt = "";
                return _OffPhoneExt;
            }
            set
            {
                _OffPhoneExt = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string CellPhone
        {
            get
            {
                if (_CellPhone == null) _CellPhone = "";
                return _CellPhone;
            }
            set
            {
                _CellPhone = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string FaxNum
        {
            get
            {
                if (_FaxNum == null) _FaxNum = "";
                return _FaxNum;
            }
            set
            {
                _FaxNum = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string OthPhone
        {
            get
            {
                if (_OthPhone == null) _OthPhone = "";
                return _OthPhone;
            }
            set
            {
                _OthPhone = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string Email
        {
            get
            {
                if (_Email == null) _Email = "";
                return _Email;
            }
            set
            {
                _Email = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string Comments
        {
            get
            {
                if (_Comments == null) _Comments = "";
                return _Comments;
            }
            set
            {
                _Comments = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public Int64 LocID { get; set; }


        public string ActiveStatus
        {
            get
            {
                if (_ActiveStatus == null) _ActiveStatus = "";
                return _ActiveStatus;
            }
            set
            {
                _ActiveStatus = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }
    }
}