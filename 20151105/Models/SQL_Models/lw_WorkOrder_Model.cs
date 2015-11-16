using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    class lw_WorkOrder_Model
    {
        // private strings
        private string _LocationID;
        private string _PurchaseOrder;
        private string _ROWName;
        private string _ROWNum;
        private string _State;
        private string _Description;
        private string _JobType;
        private string _PIC;
        private string _linenum;
        private string _ClientName;

        // date
        private string strDT;
        private string strCompDT = "1/1/1900";
        private DateTime compDT;

        private bool result = false;
        private DateTime tempDT;
        private DateTime? nullDate = null;


        // private dates
        private DateTime? _StartDate;
        private DateTime? _FinishDate;


        // Based on Access table: lw_WorkOrder
        // constructor
        public lw_WorkOrder_Model() { }

        // properties
        public Int64 ID { get; set; }

        public string ClientName
        {
            get
            {
                if (_ClientName == null) _ClientName = "";
                return _ClientName;
            }
            set
            {
                _ClientName = value.Trim();
            }
        }


        public string LocationID
        {
            get
            {
                if (_LocationID == null) _LocationID = "";
                return _LocationID;
            }
            set
            {
                _LocationID = value.Trim();
            }
        }


        public Int64 WOID { get; set; }

        public string PurchaseOrder
        {
            get
            {
                if (_PurchaseOrder == null) _PurchaseOrder = "";
                return _PurchaseOrder;
            }
            set
            {
                _PurchaseOrder = value.Trim();
            }
        }

        // date handling
        public DateTime? StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                compDT = Convert.ToDateTime(strCompDT);
                strDT = value.ToString();
                result = DateTime.TryParse(strDT, out tempDT);

                // checking for dates older than 1/1/1900
                if (tempDT < compDT) result = false;
                _StartDate = (result) ? tempDT : nullDate;
            }
        }


        public DateTime? FinishDate
        {
            get
            {
                return _FinishDate;
            }
            set
            {
                compDT = Convert.ToDateTime(strCompDT);
                strDT = value.ToString();
                result = DateTime.TryParse(strDT, out tempDT);

                // checking for dates older than 1/1/1900
                if (tempDT < compDT) result = false;
                _FinishDate = (result) ? tempDT : nullDate;
            }
        }


        public string ROWName
        {
            get
            {
                if (_ROWName == null) _ROWName = "";
                return _ROWName;
            }
            set
            {
                _ROWName = value.Trim();
            }
        }

        public string ROWNum
        {
            get
            {
                if (_ROWNum == null) _ROWNum = "";
                return _ROWNum;
            }
            set
            {
                _ROWNum = value.Trim();
            }
        }

        public string State
        {
            get
            {
                if (_State == null) _State = "";
                return _State;
            }
            set
            {
                _State = value.Trim();
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


        public string PIC
        {
            get
            {
                if (_PIC == null) _PIC = "";
                return _PIC;
            }
            set
            {
                _PIC = value.Trim();
            }
        }


        public decimal ContractPrice_cost { get; set; }
        public decimal ContractPrice_retail { get; set; }

        public Int64 RateID { get; set; }
        public Int64 LocID { get; set; }
        public double expWorker { get; set; }
        public double expEquip { get; set; }
        public double expChem { get; set; }
        public double InvoicedNoTax { get; set; }
        public double perDiemCost { get; set; }
        public double TankTotal { get; set; }


        public string linenum
        {
            get
            {
                if (_linenum == null) _linenum = "";
                return _linenum;
            }
            set
            {
                _linenum = value.Trim();
            }
        }

        public Int64 AccNum { get; set; }
    }
}