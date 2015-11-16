using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// model
using VcsConnect_Client.Models.SQL_Models;
// worker
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Workers.SQL_Workers
{
    class lw_Invoice_Worker
    {
        // based on SQL table: lw_Invoice
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_Invoice_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_Invoice_Model> Get_Invoice_List(ref string strMsg)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            // building sql command, WOID is the Key
            string sqlStatement = "SELECT ID, WorkOrderID, InvoiceID, Description, ContactID, WorkFrom, " +
                "WorkTo, InvoiceDate, Paid, EquipHour, WorkerHour, ChemHour, TaxAmt, BillLocation, " +
                "LocID, InvID, invMemo, LocWrkID, showBillName, totEquip, totWork, totChem, totItem, " +
                "totBeforeTax, totInvoicedBeforTax, AccNum " +
                "FROM lw_Invoice " +
                "ORDER BY InvoiceID";

            // create List
            List<lw_Invoice_Model> invMod_List = new List<lw_Invoice_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Invoice_Model invMod = new lw_Invoice_Model();

                    invMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;

                    //
                    invMod.WorkOrderID = (reader[1] != DBNull.Value) ? Convert.ToInt64(reader[1]) : 0;
                    invMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    invMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    invMod.ContactID = (reader[4] != DBNull.Value) ? Convert.ToInt64(reader[4]) : 0;

                    // WorkFrom, WorkTo, and InvoiceDate
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    invMod.WorkFrom = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    invMod.WorkTo = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[7].ToString(), out DT);
                    invMod.InvoiceDate = (result) ? DT : nullDate;

                    //
                    invMod.Paid = (reader[8] != DBNull.Value) ? (string)reader[8] : "No";
                    invMod.EquipHour = (reader[9] != DBNull.Value) ? (string)reader[9] : "No";
                    invMod.WorkerHour = (reader[10] != DBNull.Value) ? (string)reader[10] : "No";
                    invMod.ChemHour = (reader[11] != DBNull.Value) ? (string)reader[11] : "No";
                    invMod.TaxAmt = (reader[12] != DBNull.Value) ? Convert.ToDecimal(reader[12]) : 0;
                    invMod.BillLocation = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    invMod.LocID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    invMod.InvID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    invMod.invMemo = (reader[16] != DBNull.Value) ? (string)reader[16] : "";
                    invMod.LocWrkID = (reader[17] != DBNull.Value) ? Convert.ToInt64(reader[17]) : 0;
                    invMod.showBillName = (reader[18] != DBNull.Value) ? (string)reader[18] : "No";
                    invMod.totEquip = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    invMod.totWork = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    invMod.totChem = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;
                    invMod.totItem = (reader[22] != DBNull.Value) ? Convert.ToDouble(reader[22]) : 0;
                    invMod.totBeforeTax = (reader[23] != DBNull.Value) ? Convert.ToDouble(reader[23]) : 0;
                    invMod.totInvoicedBeforTax = (reader[24] != DBNull.Value) ? Convert.ToDouble(reader[24]) : 0;
                    invMod.AccNum = (reader[25] != DBNull.Value) ? Convert.ToInt64(reader[25]) : 0;

                    // add to List
                    invMod_List.Add(invMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Get_Invoice_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return invMod_List;
        }



        // Method: Get List
        public List<lw_Invoice_Model> Get_Invoice_ByAccNum_List(Int64 _AccNum)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            // building sql command, WOID is the Key
            string sqlStatement = "SELECT ID, WorkOrderID, InvoiceID, Description, ContactID, WorkFrom, " +
                "WorkTo, InvoiceDate, Paid, EquipHour, WorkerHour, ChemHour, TaxAmt, BillLocation, " +
                "LocID, InvID, invMemo, LocWrkID, showBillName, totEquip, totWork, totChem, totItem, " +
                "totBeforeTax, totInvoicedBeforTax, AccNum " +
                "FROM lw_Invoice " +
                "WHERE AccNum=@AccNum " +
                "ORDER BY InvoiceID";

            // create List
            List<lw_Invoice_Model> invMod_List = new List<lw_Invoice_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command
                command.Parameters.AddWithValue("@AccNum", _AccNum);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Invoice_Model invMod = new lw_Invoice_Model();

                    invMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;

                    //
                    invMod.WorkOrderID = (reader[1] != DBNull.Value) ? Convert.ToInt64(reader[1]) : 0;
                    invMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    invMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    invMod.ContactID = (reader[4] != DBNull.Value) ? Convert.ToInt64(reader[4]) : 0;

                    // WorkFrom, WorkTo, and InvoiceDate
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    invMod.WorkFrom = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    invMod.WorkTo = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[7].ToString(), out DT);
                    invMod.InvoiceDate = (result) ? DT : nullDate;

                    //
                    invMod.Paid = (reader[8] != DBNull.Value) ? (string)reader[8] : "No";
                    invMod.EquipHour = (reader[9] != DBNull.Value) ? (string)reader[9] : "No";
                    invMod.WorkerHour = (reader[10] != DBNull.Value) ? (string)reader[10] : "No";
                    invMod.ChemHour = (reader[11] != DBNull.Value) ? (string)reader[11] : "No";
                    invMod.TaxAmt = (reader[12] != DBNull.Value) ? Convert.ToDecimal(reader[12]) : 0;
                    invMod.BillLocation = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    invMod.LocID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    invMod.InvID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    invMod.invMemo = (reader[16] != DBNull.Value) ? (string)reader[16] : "";
                    invMod.LocWrkID = (reader[17] != DBNull.Value) ? Convert.ToInt64(reader[17]) : 0;
                    invMod.showBillName = (reader[18] != DBNull.Value) ? (string)reader[18] : "No";
                    invMod.totEquip = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    invMod.totWork = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    invMod.totChem = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;
                    invMod.totItem = (reader[22] != DBNull.Value) ? Convert.ToDouble(reader[22]) : 0;
                    invMod.totBeforeTax = (reader[23] != DBNull.Value) ? Convert.ToDouble(reader[23]) : 0;
                    invMod.totInvoicedBeforTax = (reader[24] != DBNull.Value) ? Convert.ToDouble(reader[24]) : 0;
                    invMod.AccNum = (reader[25] != DBNull.Value) ? Convert.ToInt64(reader[25]) : 0;

                    // add to List
                    invMod_List.Add(invMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Get_Invoice_ByAccNum_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return invMod_List;
        }


        // Method: get record data based on id
        public lw_Invoice_Model Get_Specific_Invoice_Record(int recID)
        {
            string strMsg = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, WorkOrderID, InvoiceID, Description, ContactID, WorkFrom, " +
                "WorkTo, InvoiceDate, Paid, EquipHour, WorkerHour, ChemHour, TaxAmt, BillLocation, " +
                "LocID, InvID, invMemo, LocWrkID, showBillName, totEquip, totWork, totChem, totItem, " +
                "totBeforeTax, totInvoicedBeforTax, AccNum " +
                "FROM lw_Invoice " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on WorkOrder Model (woMod)
            lw_Invoice_Model invMod = new lw_Invoice_Model();

            try
            {
                // open the connection           
                connection.Open();

                command.Parameters.AddWithValue("@WOID", recID);

                // execute the reader
                SqlDataReader reader = command.ExecuteReader();

                // populate the invoice list
                if (reader.Read())
                {
                    invMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;

                    //
                    invMod.WorkOrderID = (reader[1] != DBNull.Value) ? Convert.ToInt64(reader[1]) : 0;
                    invMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    invMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    invMod.ContactID = (reader[4] != DBNull.Value) ? Convert.ToInt64(reader[4]) : 0;

                    // WorkFrom, WorkTo, and InvoiceDate
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    invMod.WorkFrom = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    invMod.WorkTo = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[7].ToString(), out DT);
                    invMod.InvoiceDate = (result) ? DT : nullDate;

                    //
                    invMod.Paid = (reader[8] != DBNull.Value) ? (string)reader[8] : "No";
                    invMod.EquipHour = (reader[9] != DBNull.Value) ? (string)reader[9] : "No";
                    invMod.WorkerHour = (reader[10] != DBNull.Value) ? (string)reader[10] : "No";
                    invMod.ChemHour = (reader[11] != DBNull.Value) ? (string)reader[11] : "No";
                    invMod.TaxAmt = (reader[12] != DBNull.Value) ? Convert.ToDecimal(reader[12]) : 0;
                    invMod.BillLocation = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    invMod.LocID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    invMod.InvID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    invMod.invMemo = (reader[16] != DBNull.Value) ? (string)reader[16] : "";
                    invMod.LocWrkID = (reader[17] != DBNull.Value) ? Convert.ToInt64(reader[17]) : 0;
                    invMod.showBillName = (reader[18] != DBNull.Value) ? (string)reader[18] : "No";
                    invMod.totEquip = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    invMod.totWork = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    invMod.totChem = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;
                    invMod.totItem = (reader[22] != DBNull.Value) ? Convert.ToDouble(reader[22]) : 0;
                    invMod.totBeforeTax = (reader[23] != DBNull.Value) ? Convert.ToDouble(reader[23]) : 0;
                    invMod.totInvoicedBeforTax = (reader[24] != DBNull.Value) ? Convert.ToDouble(reader[24]) : 0;
                    invMod.AccNum = (reader[25] != DBNull.Value) ? Convert.ToInt64(reader[25]) : 0;
                }

                // the close
                reader.Close();
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Get_Specific_Invoice_Record", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // the close
            connection.Close();

            // return the Model
            return invMod;
        }


        // ADD
        public string Add_Invoice_Rec(lw_Invoice_Model invMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";
            DBNull dbNll = DBNull.Value;

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lw_Invoice (WorkOrderID, InvoiceID, Description, ContactID, WorkFrom, " +
                "WorkTo, InvoiceDate, Paid, EquipHour, WorkerHour, ChemHour, TaxAmt, BillLocation, " +
                "LocID, InvID, invMemo, LocWrkID, showBillName, totEquip, totWork, totChem, totItem, " +
                "totBeforeTax, totInvoicedBeforTax, AccNum) " +
                "VALUES (@WorkOrderID, @InvoiceID, @Description, @ContactID, @WorkFrom, " +
                "@WorkTo, @InvoiceDate, @Paid, @EquipHour, @WorkerHour, @ChemHour, @TaxAmt, @BillLocation, " +
                "@LocID, @InvID, @invMemo, @LocWrkID, @showBillName, @totEquip, @totWork, @totChem, @totItem, " +
                "@totBeforeTax, @totInvoicedBeforTax, @AccNum)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@WorkOrderID", invMod.WorkOrderID);
                command.Parameters.AddWithValue("@InvoiceID", invMod.InvoiceID);
                command.Parameters.AddWithValue("@Description", invMod.Description);
                command.Parameters.AddWithValue("@ContactID", invMod.ContactID);
                // work from date
                if (invMod.WorkFrom != null)
                {
                    command.Parameters.AddWithValue("@WorkFrom", invMod.WorkFrom);
                }
                else
                {
                    command.Parameters.AddWithValue("@WorkFrom", DBNull.Value);
                }
                // work to
                if (invMod.WorkTo != null)
                {
                    command.Parameters.AddWithValue("@WorkTo", invMod.WorkTo);
                }
                else
                {
                    command.Parameters.AddWithValue("@WorkTo", DBNull.Value);
                }
                // Invoice Date
                if (invMod.InvoiceDate != null)
                {
                    command.Parameters.AddWithValue("@InvoiceDate", invMod.InvoiceDate);
                }
                else
                {
                    command.Parameters.AddWithValue("@InvoiceDate", DBNull.Value);
                }

                command.Parameters.AddWithValue("@Paid", invMod.Paid);
                command.Parameters.AddWithValue("@EquipHour", invMod.EquipHour);
                command.Parameters.AddWithValue("@WorkerHour", invMod.WorkerHour);
                command.Parameters.AddWithValue("@ChemHour", invMod.ChemHour);
                command.Parameters.AddWithValue("@TaxAmt", invMod.TaxAmt);
                command.Parameters.AddWithValue("@BillLocation", invMod.BillLocation);
                command.Parameters.AddWithValue("@LocID", invMod.LocID);
                command.Parameters.AddWithValue("@InvID", invMod.InvID);
                command.Parameters.AddWithValue("@invMemo", invMod.invMemo);
                command.Parameters.AddWithValue("@LocWrkID", invMod.LocWrkID);
                command.Parameters.AddWithValue("@showBillName", invMod.showBillName);
                command.Parameters.AddWithValue("@totEquip", invMod.totEquip);
                command.Parameters.AddWithValue("@totWork", invMod.totWork);
                command.Parameters.AddWithValue("@totChem", invMod.totChem);
                command.Parameters.AddWithValue("@totItem", invMod.totItem);
                command.Parameters.AddWithValue("@totBeforeTax", invMod.totBeforeTax);
                command.Parameters.AddWithValue("@totInvoicedBeforTax", invMod.totInvoicedBeforTax);
                command.Parameters.AddWithValue("@AccNum", invMod.AccNum);

                command.ExecuteNonQuery();
                strMsg = "Record was added.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Record Add Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_Invoice_rec(lw_Invoice_Model invMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_Invoice " +
                "SET WorkOrderID=@WorkOrderID, " +
                "InvoiceID=@InvoiceID, " +
                "Description=@Description, " +
                "ContactID=@ContactID, " +
                "WorkFrom=@WorkFrom, " +
                "WorkTo=@WorkTo, " +
                "InvoiceDate=@InvoiceDate, " +
                "Paid=@Paid, " +
                "EquipHour=@EquipHour, " +
                "WorkerHour=@WorkerHour, " +
                "ChemHour=@ChemHour, " +
                "TaxAmt=@TaxAmt, " +
                "BillLocation=@BillLocation, " +
                "LocID=@LocID, " +
                "InvID=@InvID, " +
                "invMemo=@invMemo, " +
                "LocWrkID=@LocWrkID, " +
                "showBillName=@showBillName, " +
                "totEquip=@totEquip, " +
                "totWork=@totWork, " +
                "totChem=@totChem, " +
                "totItem=@totItem, " +
                "totBeforeTax=@totBeforeTax, " +
                "totInvoicedBeforTax=@totInvoicedBeforTax, " +
                "AccNum=@AccNum " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@WorkOrderID", invMod.WorkOrderID);
                command.Parameters.AddWithValue("@InvoiceID", invMod.InvoiceID);
                command.Parameters.AddWithValue("@Description", invMod.Description);
                command.Parameters.AddWithValue("@ContactID", invMod.ContactID);
                // work from date
                if (invMod.WorkFrom != null)
                {
                    command.Parameters.AddWithValue("@WorkFrom", invMod.WorkFrom);
                }
                else
                {
                    command.Parameters.AddWithValue("@WorkFrom", DBNull.Value);
                }
                // work to
                if (invMod.WorkTo != null)
                {
                    command.Parameters.AddWithValue("@WorkTo", invMod.WorkTo);
                }
                else
                {
                    command.Parameters.AddWithValue("@WorkTo", DBNull.Value);
                }
                // Invoice Date
                if (invMod.InvoiceDate != null)
                {
                    command.Parameters.AddWithValue("@InvoiceDate", invMod.InvoiceDate);
                }
                else
                {
                    command.Parameters.AddWithValue("@InvoiceDate", DBNull.Value);
                }

                command.Parameters.AddWithValue("@Paid", invMod.Paid);
                command.Parameters.AddWithValue("@EquipHour", invMod.EquipHour);
                command.Parameters.AddWithValue("@WorkerHour", invMod.WorkerHour);
                command.Parameters.AddWithValue("@ChemHour", invMod.ChemHour);
                command.Parameters.AddWithValue("@TaxAmt", invMod.TaxAmt);
                command.Parameters.AddWithValue("@BillLocation", invMod.BillLocation);
                command.Parameters.AddWithValue("@LocID", invMod.LocID);
                command.Parameters.AddWithValue("@InvID", invMod.InvID);
                command.Parameters.AddWithValue("@invMemo", invMod.invMemo);
                command.Parameters.AddWithValue("@LocWrkID", invMod.LocWrkID);
                command.Parameters.AddWithValue("@showBillName", invMod.showBillName);
                command.Parameters.AddWithValue("@totEquip", invMod.totEquip);
                command.Parameters.AddWithValue("@totWork", invMod.totWork);
                command.Parameters.AddWithValue("@totChem", invMod.totChem);
                command.Parameters.AddWithValue("@totItem", invMod.totItem);
                command.Parameters.AddWithValue("@totBeforeTax", invMod.totBeforeTax);
                command.Parameters.AddWithValue("@totInvoicedBeforTax", invMod.totInvoicedBeforTax);
                command.Parameters.AddWithValue("@AccNum", invMod.AccNum);
                //
                command.Parameters.AddWithValue("@ID", invMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Update_Invoice_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }



        // DELETE
        public string Delete_Invoice_rec(Int32 recID)
        {
            // the delete is based on record ID
            string strMsg = "";

            if (recID > 0)
            {
                // get the connection string
                connectionString = PSWkr.G_SQLDatabaseConnectionString;

                // create connection object
                SqlConnection connection = new SqlConnection(connectionString);

                // building sql command
                string sqlStatement = "DELETE FROM lw_Invoice " +
                    "WHERE ID=@ID";

                // SqlCommand
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    // open the connection           
                    connection.Open();

                    // Adding parameters for WHERE = ID
                    command.Parameters.AddWithValue("@ID", recID);

                    // execute the reader
                    SqlDataReader reader = command.ExecuteReader();

                    // the close
                    reader.Close();

                    strMsg = "Record Deleted.";
                }
                catch (Exception e)
                {
                    strMsg = e.Message.ToString();
                    System.Windows.MessageBox.Show(strMsg, "SQL: Delete_Invoice_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

                // the close
                connection.Close();
            }
            else
            {
                strMsg = "Delete did not occur, ID did not contain data.";
                System.Windows.MessageBox.Show(strMsg, "SQL: Delete_Invoice_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }


        // removes all records from the Invoice table
        // while leaving all table structures
        public string Truncate_Invoice_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_Invoice";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Invoice table Initialized.";
            }
            catch (Exception err)
            {
                connection.Close();
                strMsg = err.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Truncate_Invoice_table", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }



        // Reset Bid Model
        public lw_Invoice_Model Reset_Invoice_Mod(lw_Invoice_Model invMod)
        {
            DateTime? nullDate = null;

            // reset the model
            invMod.ID = 0;
            invMod.WorkOrderID = 0;
            invMod.InvoiceID = "";
            invMod.Description = "";
            invMod.ContactID = 0;

            // WorkFrom, WorkTo, and InvoiceDate
            invMod.WorkFrom = nullDate;
            invMod.WorkTo = nullDate;
            invMod.InvoiceDate = nullDate;

            //
            invMod.Paid = "";
            invMod.EquipHour = "";
            invMod.WorkerHour = "";
            invMod.ChemHour = "";
            invMod.TaxAmt = 0;
            invMod.BillLocation = "";
            invMod.LocID = 0;
            invMod.InvID = 0;
            invMod.invMemo = "";
            invMod.LocWrkID = 0;
            invMod.showBillName = "";
            invMod.totEquip = 0;
            invMod.totWork = 0;
            invMod.totChem = 0;
            invMod.totItem = 0;
            invMod.totBeforeTax = 0;
            invMod.totInvoicedBeforTax = 0;
            invMod.AccNum = 0;

            // return the model
            return invMod;
        }




        // Method: Get List
        public List<lw_Invoice_Model> Get_Invoice_ByBillLocation_List(string _BillLoc)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            // building sql command, WOID is the Key
            string sqlStatement = "SELECT ID, WorkOrderID, InvoiceID, Description, ContactID, WorkFrom, " +
                "WorkTo, InvoiceDate, Paid, EquipHour, WorkerHour, ChemHour, TaxAmt, BillLocation, " +
                "LocID, InvID, invMemo, LocWrkID, showBillName, totEquip, totWork, totChem, totItem, " +
                "totBeforeTax, totInvoicedBeforTax, AccNum " +
                "FROM lw_Invoice " +
                "WHERE BillLocation=@BillLocation " +
                "ORDER BY InvoiceID";

            // create List
            List<lw_Invoice_Model> invMod_List = new List<lw_Invoice_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command
                command.Parameters.AddWithValue("@BillLocation", _BillLoc);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Invoice_Model invMod = new lw_Invoice_Model();

                    invMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;

                    //
                    invMod.WorkOrderID = (reader[1] != DBNull.Value) ? Convert.ToInt64(reader[1]) : 0;
                    invMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    invMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    invMod.ContactID = (reader[4] != DBNull.Value) ? Convert.ToInt64(reader[4]) : 0;

                    // WorkFrom, WorkTo, and InvoiceDate
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    invMod.WorkFrom = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    invMod.WorkTo = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[7].ToString(), out DT);
                    invMod.InvoiceDate = (result) ? DT : nullDate;

                    //
                    invMod.Paid = (reader[8] != DBNull.Value) ? (string)reader[8] : "No";
                    invMod.EquipHour = (reader[9] != DBNull.Value) ? (string)reader[9] : "No";
                    invMod.WorkerHour = (reader[10] != DBNull.Value) ? (string)reader[10] : "No";
                    invMod.ChemHour = (reader[11] != DBNull.Value) ? (string)reader[11] : "No";
                    invMod.TaxAmt = (reader[12] != DBNull.Value) ? Convert.ToDecimal(reader[12]) : 0;
                    invMod.BillLocation = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    invMod.LocID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    invMod.InvID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    invMod.invMemo = (reader[16] != DBNull.Value) ? (string)reader[16] : "";
                    invMod.LocWrkID = (reader[17] != DBNull.Value) ? Convert.ToInt64(reader[17]) : 0;
                    invMod.showBillName = (reader[18] != DBNull.Value) ? (string)reader[18] : "No";
                    invMod.totEquip = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    invMod.totWork = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    invMod.totChem = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;
                    invMod.totItem = (reader[22] != DBNull.Value) ? Convert.ToDouble(reader[22]) : 0;
                    invMod.totBeforeTax = (reader[23] != DBNull.Value) ? Convert.ToDouble(reader[23]) : 0;
                    invMod.totInvoicedBeforTax = (reader[24] != DBNull.Value) ? Convert.ToDouble(reader[24]) : 0;
                    invMod.AccNum = (reader[25] != DBNull.Value) ? Convert.ToInt64(reader[25]) : 0;

                    // add to List
                    invMod_List.Add(invMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Get_Invoice_ByBillLocation_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return invMod_List;
        }




        // Method: Get List
        public List<lw_Invoice_Model> Get_Invoice_InvoiceDate_List(string strDate)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;
            string strMsg = "";

            // convert compare date
            result = DateTime.TryParse(strDate, out DT);

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            // building sql command, WOID is the Key
            string sqlStatement = "SELECT ID, WorkOrderID, InvoiceID, Description, ContactID, WorkFrom, " +
                "WorkTo, InvoiceDate, Paid, EquipHour, WorkerHour, ChemHour, TaxAmt, BillLocation, " +
                "LocID, InvID, invMemo, LocWrkID, showBillName, totEquip, totWork, totChem, totItem, " +
                "totBeforeTax, totInvoicedBeforTax, AccNum " +
                "FROM lw_Invoice " +
                "WHERE InvoiceDate>=@InvoiceDate " +
                "ORDER BY InvoiceDate";

            // create List
            List<lw_Invoice_Model> invMod_List = new List<lw_Invoice_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command
                command.Parameters.AddWithValue("@InvoiceDate", DT);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Invoice_Model invMod = new lw_Invoice_Model();

                    invMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;

                    //
                    invMod.WorkOrderID = (reader[1] != DBNull.Value) ? Convert.ToInt64(reader[1]) : 0;
                    invMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    invMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    invMod.ContactID = (reader[4] != DBNull.Value) ? Convert.ToInt64(reader[4]) : 0;

                    // WorkFrom, WorkTo, and InvoiceDate
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    invMod.WorkFrom = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    invMod.WorkTo = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[7].ToString(), out DT);
                    invMod.InvoiceDate = (result) ? DT : nullDate;

                    //
                    invMod.Paid = (reader[8] != DBNull.Value) ? (string)reader[8] : "No";
                    invMod.EquipHour = (reader[9] != DBNull.Value) ? (string)reader[9] : "No";
                    invMod.WorkerHour = (reader[10] != DBNull.Value) ? (string)reader[10] : "No";
                    invMod.ChemHour = (reader[11] != DBNull.Value) ? (string)reader[11] : "No";
                    invMod.TaxAmt = (reader[12] != DBNull.Value) ? Convert.ToDecimal(reader[12]) : 0;
                    invMod.BillLocation = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    invMod.LocID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    invMod.InvID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    invMod.invMemo = (reader[16] != DBNull.Value) ? (string)reader[16] : "";
                    invMod.LocWrkID = (reader[17] != DBNull.Value) ? Convert.ToInt64(reader[17]) : 0;
                    invMod.showBillName = (reader[18] != DBNull.Value) ? (string)reader[18] : "No";
                    invMod.totEquip = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    invMod.totWork = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    invMod.totChem = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;
                    invMod.totItem = (reader[22] != DBNull.Value) ? Convert.ToDouble(reader[22]) : 0;
                    invMod.totBeforeTax = (reader[23] != DBNull.Value) ? Convert.ToDouble(reader[23]) : 0;
                    invMod.totInvoicedBeforTax = (reader[24] != DBNull.Value) ? Convert.ToDouble(reader[24]) : 0;
                    invMod.AccNum = (reader[25] != DBNull.Value) ? Convert.ToInt64(reader[25]) : 0;

                    // add to List
                    invMod_List.Add(invMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Get_Invoice_ByInvoiceDate_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return invMod_List;
        }



        // Method: Get Invoice List based on SQL LIKE Invoice ID
        public List<lw_Invoice_Model> Get_Invoice_LIKEInvoiceID_List(string _strInvID)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;
            string strMsg = "";
            
            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            // building sql command, WOID is the Key
            string sqlStatement = "SELECT ID, WorkOrderID, InvoiceID, Description, ContactID, WorkFrom, " +
                "WorkTo, InvoiceDate, Paid, EquipHour, WorkerHour, ChemHour, TaxAmt, BillLocation, " +
                "LocID, InvID, invMemo, LocWrkID, showBillName, totEquip, totWork, totChem, totItem, " +
                "totBeforeTax, totInvoicedBeforTax, AccNum " +
                "FROM lw_Invoice " +
                "WHERE InvoiceID LIKE @InvoiceID " +
                "ORDER BY InvoiceID, InvoiceDate";

            // create List
            List<lw_Invoice_Model> invMod_List = new List<lw_Invoice_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command
                command.Parameters.AddWithValue("@InvoiceID", _strInvID + '%');

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Invoice_Model invMod = new lw_Invoice_Model();

                    invMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;

                    //
                    invMod.WorkOrderID = (reader[1] != DBNull.Value) ? Convert.ToInt64(reader[1]) : 0;
                    invMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    invMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    invMod.ContactID = (reader[4] != DBNull.Value) ? Convert.ToInt64(reader[4]) : 0;

                    // WorkFrom, WorkTo, and InvoiceDate
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    invMod.WorkFrom = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    invMod.WorkTo = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[7].ToString(), out DT);
                    invMod.InvoiceDate = (result) ? DT : nullDate;

                    //
                    invMod.Paid = (reader[8] != DBNull.Value) ? (string)reader[8] : "No";
                    invMod.EquipHour = (reader[9] != DBNull.Value) ? (string)reader[9] : "No";
                    invMod.WorkerHour = (reader[10] != DBNull.Value) ? (string)reader[10] : "No";
                    invMod.ChemHour = (reader[11] != DBNull.Value) ? (string)reader[11] : "No";
                    invMod.TaxAmt = (reader[12] != DBNull.Value) ? Convert.ToDecimal(reader[12]) : 0;
                    invMod.BillLocation = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    invMod.LocID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    invMod.InvID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    invMod.invMemo = (reader[16] != DBNull.Value) ? (string)reader[16] : "";
                    invMod.LocWrkID = (reader[17] != DBNull.Value) ? Convert.ToInt64(reader[17]) : 0;
                    invMod.showBillName = (reader[18] != DBNull.Value) ? (string)reader[18] : "No";
                    invMod.totEquip = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    invMod.totWork = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    invMod.totChem = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;
                    invMod.totItem = (reader[22] != DBNull.Value) ? Convert.ToDouble(reader[22]) : 0;
                    invMod.totBeforeTax = (reader[23] != DBNull.Value) ? Convert.ToDouble(reader[23]) : 0;
                    invMod.totInvoicedBeforTax = (reader[24] != DBNull.Value) ? Convert.ToDouble(reader[24]) : 0;
                    invMod.AccNum = (reader[25] != DBNull.Value) ? Convert.ToInt64(reader[25]) : 0;

                    // add to List
                    invMod_List.Add(invMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL: Get_Invoice_LIKEInvoiceID_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return invMod_List;
        }
    }
}