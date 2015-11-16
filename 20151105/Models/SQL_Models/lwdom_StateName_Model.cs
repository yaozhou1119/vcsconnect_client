using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lwdom_StateName_Model
    {
        // private string
        private string _StateName;

        // constructor
        public lwdom_StateName_Model() { }

        // properties
        public Int64 ID { get; set; }

        public string StateName
        {
            get
            {
                if (_StateName == null) _StateName = "";
                return _StateName;
            }
            set
            {
                _StateName = value.ToUpper().Trim();
            }
        }
    }
}
