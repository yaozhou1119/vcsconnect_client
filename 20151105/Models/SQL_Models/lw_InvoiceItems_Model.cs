using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lw_InvoiceItems_Model
    {
        // private strings
        private string _InvoiceID;
        private string _Description;
        private string _istax;

        // constructor
        public lw_InvoiceItems_Model() { }

        // public properties
        public Int64 ID { get; set; }
        public Int64 InvItemId { get; set; }

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

        public string Description
        {
            get
            {
                if (_Description == null) _Description = "";
                return _Description;
            }
            set
            {
                _Description = value.Trim();
            }
        }

        public decimal Cost { get; set; }
        public Int64 InvID { get; set; }

        public string istax
        {
            get
            {
                if (_istax == null) _istax = "";
                return _istax;
            }
            set
            {
                _istax = value.Trim();
            }
        }
    }
}