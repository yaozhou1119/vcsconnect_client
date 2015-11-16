using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.ApplicationValues
{
    public class ApplicationValue_Model
    {
        // based on SQL table: Application_Values
        // constructor
        public ApplicationValue_Model() { }

        // properties
        public Int64 ID { get; set; }
        public Int64 NextWorkOrderID { get; set; } // next WO ID to be used
        public Int64 NextBidID { get; set; } // next Bids ID to be used
    }
}
