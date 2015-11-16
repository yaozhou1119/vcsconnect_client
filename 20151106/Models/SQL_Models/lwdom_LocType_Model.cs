using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lwdom_LocType_Model
    {
        // private string
        private string _LocTypeDesc;

        // based on SQL Table: lwdom_LocType
        // constructor
        public lwdom_LocType_Model() { }

        // property
        public Int64 ID { get; set; }

        public string LocTypeDesc
        {
            get
            {
                if (_LocTypeDesc == null) _LocTypeDesc = "";
                return _LocTypeDesc;
            }
            set
            {
                _LocTypeDesc = value.Trim();
            }
        }
    }
}
