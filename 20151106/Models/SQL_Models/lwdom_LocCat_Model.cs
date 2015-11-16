using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lwdom_LocCat_Model
    {
        // private strine
        public string _LocCatDesc;

        // constructor
        public lwdom_LocCat_Model() { }

        // properties
        public Int64 ID { get; set; }

        public string LocCatDesc
        {
            get
            {
                if (_LocCatDesc == null) _LocCatDesc = "";
                return _LocCatDesc;
            }
            set
            {
                _LocCatDesc = value.Trim();
            }
        }
    }
}
