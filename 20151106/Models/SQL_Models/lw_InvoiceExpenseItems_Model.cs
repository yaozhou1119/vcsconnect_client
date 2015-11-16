using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lw_InvoiceExpenseItems_Model
    {
        // private strings
        private string _WOID;
        private string _InvoiceID;
        private string _Category;
        private string _ExpName;

        // based on SQL table: lw_InvoiceExpenseItems
        // constructor
        public lw_InvoiceExpenseItems_Model() { }

        // properties
        public Int64 ID { get; set; }

        public string WOID
        {
            get
            {
                if (_WOID == null) _WOID = "";
                return _WOID;
            }
            set
            {
                _WOID = value.Trim();
            }
        }

        public string InvoiceID
        {
            get
            {
                if (_InvoiceID == null) _InvoiceID = "";
                return _InvoiceID;
            }
            set
            {
                _InvoiceID = value.Trim();
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
                _Category = value.Trim();
            }
        }

        public string ExpName
        {
            get
            {
                if (_ExpName == null) _ExpName = "";
                return _ExpName;
            }
            set
            {
                _ExpName = value.Trim();
            }
        }

        public decimal Rate { get; set; }
        public decimal Cost { get; set; }
        public decimal TotHours { get; set; }
    }
}