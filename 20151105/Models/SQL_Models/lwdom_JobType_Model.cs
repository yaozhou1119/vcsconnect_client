using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lwdom_JobType_Model
    {
        // private string
        private string _JobType;

        // constructor
        public lwdom_JobType_Model() { }

        // properties
        public Int64 ID { get; set; }

        public string JobType
        {
            get
            {
                if (_JobType == null) _JobType = "";
                return _JobType;
            }
            set
            {
                _JobType = value.Trim();
            }
        }
    }
}
