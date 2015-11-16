using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// workers
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lwdom_chemlist_Model
    {
        // private variables
        private string _ChemCode;
        private string _EPANum;
        private string _ActiveIngr; // active ingrediant
        private string _Manufacturer;
        private string _Comment;
        private string _Units;
        private string _activeStatus; 

        // constructor
        public lwdom_chemlist_Model() { }

        // properties
        public Int64 OBJECTID { get; set; }

        public string ChemCode
        {
            get
            {
                if (_ChemCode == null) _ChemCode = "";
                return _ChemCode;
            }
            set
            {
                _ChemCode = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string EPANum
        {
            get
            {
                if (_EPANum == null) _EPANum = " ";
                return _EPANum;
            }
            set
            {
                _EPANum = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
                if (_EPANum.Trim() == "") _EPANum = " ";
            }
        }

        public string ActiveIngr
        {
            get
            {
                if (_ActiveIngr == null) _ActiveIngr = "";
                return _ActiveIngr;
            }
            set
            {
                _ActiveIngr = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string Manufacturer
        {
            get
            {
                if (_Manufacturer == null) _Manufacturer = "";
                return _Manufacturer;
            }
            set
            {
                _Manufacturer = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        // retail was cost in access mdb
        public decimal retail { get; set; }
        public decimal cost { get; set; } // new field

        public string Comment
        {
            get
            {
                if (_Comment == null) _Comment = "";
                return _Comment;
            }
            set
            {
                _Comment = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string Units
        {
            get
            {
                if (_Units == null) _Units = "";
                return _Units;
            }
            set
            {
                _Units = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        // Active Status
        // was yes/no field in access db
        public string activeStatus
        {
            get
            {
                if (_activeStatus == null) _activeStatus = "";
                return _activeStatus;
            }
            set
            {
                _activeStatus = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }
    }
}