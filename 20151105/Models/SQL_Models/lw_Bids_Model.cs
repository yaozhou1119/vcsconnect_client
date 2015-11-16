using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// workers
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lw_Bids_Model
    {
        // private strings
        private string _ClientLocID;
        private string _Description;
        private string _Narrative;
        private string _AttnName;
        private string _Narrative2;
        private string _BidWon; // Yes,No
        private string _TwoColumns; // Yes,No
        private string _descBidAmtRetail; // new
        private string _descBidAmtCost; // new
        private string _showLocName; // Yes,No
        private string _ClientName;

        // based on the SQL table name: lw_Bids
        // constructor
        public lw_Bids_Model() { }


        // properties
        public Int64 ID { get; set; }
        public Int64 BidID { get; set; }

        public string ClientLocID
        {
            get
            {
                if (_ClientLocID == null) _ClientLocID = "";
                return _ClientLocID;
            }
            set
            {
                _ClientLocID = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public decimal BidAmtRetail { get; set; }
        public decimal BidAmtCost { get; set; }
        public Int64 Area { get; set; }
        public DateTime? BidSent { get; set; }

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

        public string BidWon
        {
            get
            {
                if (_BidWon == null) _BidWon = "";
                return _BidWon;
            }
            set
            {
                _BidWon = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        // set for rtf
        public string Narrative
        {
            get
            {
                if (_Narrative == null) _Narrative = "";
                return @_Narrative;
            }
            set
            {
                _Narrative = @value;
            }
        }


        public string AttnName
        {
            get
            {
                if (_AttnName == null) _AttnName = "";
                return _AttnName;
            }
            set
            {
                _AttnName = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        // set for rtf
        public string Narrative2
        {
            get
            {
                if (_Narrative2 == null) _Narrative2 = "";
                return @_Narrative2;
            }
            set
            {
                _Narrative2 = @value;
            }
        }

        public string TwoColumns
        {
            get
            {
                if (_TwoColumns == null) _TwoColumns = "";
                return _TwoColumns;
            }
            set
            {
                _TwoColumns = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }


        public string descBidAmtRetail
        {
            get
            {
                if (_descBidAmtRetail == null) _descBidAmtRetail = "";
                return _descBidAmtRetail;
            }
            set
            {
                _descBidAmtRetail = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string descBidAmtCost
        {
            get
            {
                if (_descBidAmtCost == null) _descBidAmtCost = "";
                return _descBidAmtCost;
            }
            set
            {
                _descBidAmtCost = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public string showLocName
        {
            get
            {
                if (_showLocName == null) _showLocName = "";
                return _showLocName;
            }
            set
            {
                _showLocName = Tools.RemoveSpecialCharacters(Tools.NullToString(value)).Trim();
            }
        }

        public Int64 AccNum { get; set; }

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
    }
}