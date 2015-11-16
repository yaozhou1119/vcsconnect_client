using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// worker
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lwdom_Rates_Model
    {
        // private strings
        private string _RateID;
        private string _Category;
        private string _Code;
        private string _Description;
        private string _ActiveStatus;

        // constructor
        public lwdom_Rates_Model() { }

        // properties
        public Int64 ID { get; set; }

        public string RateID
        {
            get
            {
                if (_RateID == null) _RateID = "";
                return _RateID;
            }
            set
            {
                _RateID = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string Category
        {
            get
            {
                if (_Category == null) _Category = "";
                return _Category;
            }
            set
            {
                _Category = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string Code
        {
            get
            {
                if (_Code == null) _Code = "";
                return _Code;
            }
            set
            {
                _Code = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public int RateYear { get; set; }

        public string Description
        {
            get
            {
                if (_Description == null) _Description = "";
                return _Description;
            }
            set
            {
                _Description = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public decimal RetailRate { get; set; }
        public decimal CostRate { get; set; }

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


        /// <summary>
        /// Create a copy of this instance
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public lwdom_Rates_Model Copy()
        {
            // create the model copy
            lwdom_Rates_Model modelCopy = new lwdom_Rates_Model();

            // copy the data
            modelCopy.ID = ID;
            modelCopy.RateID = RateID;
            modelCopy.Category = Category;
            modelCopy.Code = Code;
            modelCopy.RateYear = RateYear;
            modelCopy.Description = Description;
            modelCopy.RetailRate = RetailRate;
            modelCopy.CostRate = CostRate;
            modelCopy.ActiveStatus = ActiveStatus;

            // return the copy
            return modelCopy;
        }
    }
}
