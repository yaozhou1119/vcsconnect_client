using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lw_Invoice_Model
    {
        // private strings
        private string _InvoiceID;
        private string _Description;
        private string _BillLocation;
        private string _invMemo;


        // based on SQL table name: lw_Invoice
        // constructor
        public lw_Invoice_Model() { }


        // properties
        public Int64 ID { get; set; }
        public Int64 WorkOrderID { get; set; }


        // InvoiceID is a key
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

        public Int64 ContactID { get; set; }
        public DateTime? WorkFrom { get; set; }
        public DateTime? WorkTo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Paid { get; set; } // Paid?
        public string EquipHour { get; set; } // EquipHour?
        public string WorkerHour { get; set; } // WorkerHour?
        public string ChemHour { get; set; } // ChemHour?
        public decimal TaxAmt { get; set; }

        public string BillLocation
        {
            get
            {
                if (_BillLocation == null) _BillLocation = "";
                return _BillLocation;
            }
            set
            {
                _BillLocation = value.Trim();
            }
        }

        public Int64 LocID { get; set; }
        public Int64 InvID { get; set; }

        // memo field in textBox
        public string invMemo
        {
            get
            {
                if (_invMemo == null) _invMemo = "";
                return _invMemo;
            }
            set
            {
                _invMemo = value.Trim();
            }
        }

        public Int64 LocWrkID { get; set; }
        public string showBillName { get; set; }
        public double totEquip { get; set; }
        public double totWork { get; set; }
        public double totChem { get; set; }
        public double totItem { get; set; }
        public double totBeforeTax { get; set; }
        public double totInvoicedBeforTax { get; set; }
        public Int64 AccNum { get; set; }
    }
}