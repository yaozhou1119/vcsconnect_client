using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lwdom_RatesID_Model
    {
        // private string
        private string _RateName;

        // based on SQL table: lwdom_RatesID
        // constructor
        public lwdom_RatesID_Model() { }

        public Int64 ID { get; set; }

        public string RateName
        {
            get
            {
                if (_RateName == null) _RateName = "";
                return _RateName;
            }
            set
            {
                _RateName = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }
    }
}
