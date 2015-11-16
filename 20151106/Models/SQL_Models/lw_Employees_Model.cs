using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Models.SQL_Models
{
    public class lw_Employees_Model
    {
        // private strings
        private string _EmpID;
        private string _EmpFN;
        private string _EmpLN;
        private string _EmpAdd1;
        private string _EmpAdd2;
        private string _EmpTown;
        private string _EmpState;
        private string _EmpZip;
        private string _EmpHomePhone;
        private string _EmpCellPhone;
        private string _EmpEmail;
        private string _Comment;
        private string _Active;
        private string _EmpWorkCell;
        private string _EmpNotes;

        // constructor
        public lw_Employees_Model() { }

        // properties
        public Int64 ID { get; set; }

        public string EmpID
        {
            get
            {
                if (_EmpID == null) _EmpID = "";
                return _EmpID;
            }
            set
            {
                _EmpID = value.Trim();
            }
        }

        public string EmpFN
        {
            get
            {
                if (_EmpFN == null) _EmpFN = "";
                return _EmpFN;
            }
            set
            {
                _EmpFN = value.Trim();
            }
        }

        public string EmpLN
        {
            get
            {
                if (_EmpLN == null) _EmpLN = "";
                return _EmpLN;
            }
            set
            {
                _EmpLN = value.Trim();
            }
        }

        public string EmpAdd1
        {
            get
            {
                if (_EmpAdd1 == null) _EmpAdd1 = "";
                return _EmpAdd1;
            }
            set
            {
                _EmpAdd1 = value.Trim();
            }
        }

        public string EmpAdd2
        {
            get
            {
                if (_EmpAdd2 == null) _EmpAdd2 = "";
                return _EmpAdd2;
            }
            set
            {
                _EmpAdd2 = value.Trim();
            }
        }

        public string EmpTown
        {
            get
            {
                if (_EmpTown == null) _EmpTown = "";
                return _EmpTown;
            }
            set
            {
                _EmpTown = value.Trim();
            }
        }

        public string EmpState
        {
            get
            {
                if (_EmpState == null) _EmpState = "";
                return _EmpState;
            }
            set
            {
                _EmpState = value.ToUpper().Trim();
            }
        }

        public string EmpZip
        {
            get
            {
                if (_EmpZip == null) _EmpZip = "";
                return _EmpZip;
            }
            set
            {
                _EmpZip = value.Trim();
            }
        }

        public string EmpHomePhone
        {
            get
            {
                if (_EmpHomePhone == null) _EmpHomePhone = "";
                return _EmpHomePhone;
            }
            set
            {
                _EmpHomePhone = value.Trim();
            }
        }

        public string EmpCellPhone
        {
            get
            {
                if (_EmpCellPhone == null) _EmpCellPhone = "";
                return _EmpCellPhone;
            }
            set
            {
                _EmpCellPhone = value.Trim();
            }
        }

        public string EmpEmail
        {
            get
            {
                if (_EmpEmail == null) _EmpEmail = "";
                return _EmpEmail;
            }
            set
            {
                _EmpEmail = value.Trim();
            }
        }

        public string Comment
        {
            get
            {
                if (_Comment == null) _Comment = "";
                return _EmpEmail;
            }
            set
            {
                _Comment = value.Trim();
            }
        }

        public string Active
        {
            get
            {
                if (_Active == null) _Active = "";
                return _Active;
            }
            set
            {
                _Active = value.Trim();
            }
        }

        public string EmpWorkCell
        {
            get
            {
                if (_EmpWorkCell == null) _EmpWorkCell = "";
                return _EmpWorkCell;
            }
            set
            {
                _EmpWorkCell = value.Trim();
            }
        }

        public string EmpNotes
        {
            get
            {
                if (_EmpNotes == null) _EmpNotes = "";
                return _EmpNotes;
            }
            set
            {
                _EmpNotes = value.Trim();
            }
        }
    }
}