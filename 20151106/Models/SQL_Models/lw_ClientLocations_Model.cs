using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// model
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lw_ClientLocations_Model
    {
        // private strings
        private string _ClientLocationID;
        private string _ClientName;
        private string _Name;
        private string _Type;
        private string _LocAdd1;
        private string _LocAdd2;
        private string _LocTown;
        private string _LocState;
        private string _LocZip;
        private string _Comment;
        private string _LocType;
        private string _loccat;

        // based on table: lw_ClientLocations
        // constructor
        public lw_ClientLocations_Model() { }

        // property
        public Int64 ID { get; set; }
        public Int64 AccNum { get; set; }

        public string ClientLocationID
        {
            get
            {
                if (_ClientLocationID == null) _ClientLocationID = "";
                return _ClientLocationID;
            }
            set
            {
                _ClientLocationID = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string ClientName
        {
            get
            {
                if (_ClientName == null) _ClientName = "";
                return _ClientName;
            }
            set
            {
                _ClientName = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string Name
        {
            get
            {
                if (_Name == null) _Name = "";
                return _Name;
            }
            set
            {
                _Name = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string Type
        {
            get
            {
                if (_Type == null) _Type = "";
                return _Type;
            }
            set
            {
                _Type = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string LocAdd1
        {
            get
            {
                if (_LocAdd1 == null) _LocAdd1 = "";
                return _LocAdd1;
            }
            set
            {
                _LocAdd1 = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string LocAdd2
        {
            get
            {
                if (_LocAdd2 == null) _LocAdd2 = "";
                return _LocAdd2;
            }
            set
            {
                _LocAdd2 = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string LocTown
        {
            get
            {
                if (_LocTown == null) _LocTown = "";
                return _LocTown;
            }
            set
            {
                _LocTown = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string LocState
        {
            get
            {
                if (_LocState == null) _LocState = "";
                return _LocState;
            }
            set
            {
                _LocState = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string LocZip
        {
            get
            {
                if (_LocZip == null) _LocZip = "";
                return _LocZip;
            }
            set
            {
                _LocZip = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public DateTime? UpdateDate { get; set; }

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

        public string LocType
        {
            get
            {
                if (_LocType == null) _LocType = "";
                return _LocType;
            }
            set
            {
                _LocType = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string LocCat
        {
            get
            {
                if (_loccat == null) _loccat = "";
                return _loccat;
            }
            set
            {
                _loccat = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }
    }
}