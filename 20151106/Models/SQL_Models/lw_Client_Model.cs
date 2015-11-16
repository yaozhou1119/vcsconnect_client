using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lw_Client_Model
    {
        // private strings
        private string _Name;
        private string _ActiveStatus;
        private string _Note;
        private string _Comments;


        // based on SQL Table: lw_Client
        // Constructor
        public lw_Client_Model() { }

        // properties
        public Int64 ID { get; set; }
        public Int64 AccNum { get; set; }

        public string Name
        {
            get
            {
                if (_Name == null) _Name = "";
                return _Name;
            }
            set
            {
                _Name = value.Trim();
            }
        }

        public string ActiveStatus
        {
            get
            {
                if (_ActiveStatus == null) _ActiveStatus = "";
                return _ActiveStatus;
            }
            set
            {
                _ActiveStatus = value.Trim();
            }
        }

        public string Note
        {
            get
            {
                if (_Note == null) _Note = "";
                return _Note;
            }
            set
            {
                _Note = value.Trim();
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
                _Comments = value.Trim();
            }
        }
    }
}