using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// model
using VcsConnect_Client.Models.SQL_Models;
using VcsConnect_Client.Models.ApplicationValues;
// worker
using VcsConnect_Client.Workers.General_Workers;
using VcsConnect_Client.Workers.ApplicationValue_Workers;

namespace VcsConnect_Client.Workers.SQL_Workers
{
    class lw_WorkOrders_Worker
    {
        // based on SQL table: lw_WorkOrder
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_WorkOrders_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_WorkOrder_Model> Get_WorkOrder_List(ref string strMsg)
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
            string sqlStatement = "SELECT ID, LocationID, WOID, PurchaseOrder, StartDate, FinishDate, " +
                "ROWName, ROWNum, State, Description, JobType, PIC, ContractPrice_cost, " +
                "ContractPrice_retail, RateID, LocID, expWorker, expEquip, expChem, InvoicedNoTax, " +
                "perDiemCost, TankTotal, linenum, AccNum, ClientName " +
                "FROM lw_WorkOrder " +
                "ORDER BY WOID";

            // create List
            List<lw_WorkOrder_Model> woMod_List = new List<lw_WorkOrder_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();

                    woMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    woMod.LocationID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    woMod.WOID = (reader[2] != DBNull.Value) ? Convert.ToInt64(reader[2]) : 0;
                    woMod.PurchaseOrder = (reader[3] != DBNull.Value) ? (string)reader[3] : "";

                    // StartDate and FinishDate
                    result = DateTime.TryParse(reader[4].ToString(), out DT);
                    woMod.StartDate = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    woMod.FinishDate = (result) ? DT : nullDate;

                    //
                    woMod.ROWName = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    woMod.ROWNum = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    woMod.State = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    woMod.Description = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    woMod.JobType = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    woMod.PIC = (reader[11] != DBNull.Value) ? (string)reader[11] : "";

                    woMod.ContractPrice_cost = (reader[12] != DBNull.Value) ? (decimal)reader[12] : 0;
                    woMod.ContractPrice_retail = (reader[13] != DBNull.Value) ? (decimal)reader[13] : 0;

                    woMod.RateID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    woMod.LocID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    woMod.expWorker = (reader[16] != DBNull.Value) ? Convert.ToDouble(reader[16]) : 0;
                    woMod.expEquip = (reader[17] != DBNull.Value) ? Convert.ToDouble(reader[17]) : 0;
                    woMod.expChem = (reader[18] != DBNull.Value) ? Convert.ToDouble(reader[18]) : 0;
                    woMod.InvoicedNoTax = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    woMod.perDiemCost = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    woMod.TankTotal = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;

                    woMod.linenum = (reader[22] != DBNull.Value) ? (string)reader[22] : "";
                    woMod.AccNum = (reader[23] != DBNull.Value) ? Convert.ToInt64(reader[23]) : 0;
                    woMod.ClientName = (reader[24] != DBNull.Value) ? (string)reader[24] : "";
                    
                    // add to List
                    woMod_List.Add(woMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Generate List of Work Orders", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return woMod_List;
        }


        // Method: get record data based on id
        public lw_WorkOrder_Model Get_Specific_WorkOrder_Record(int recID)
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
            string sqlStatement = "SELECT ID, LocationID, WOID, PurchaseOrder, StartDate, FinishDate, " +
                "ROWName, ROWNum, State, Description, JobType, PIC, ContractPrice_cost, " +
                "ContractPrice_retail, RateID, LocID, expWorker, expEquip, expChem, InvoicedNoTax, " +
                "perDiemCost, TankTotal, linenum, AccNum, ClientName " +
                "FROM lw_WorkOrder " +
                "WHERE WOID=@WOID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on WorkOrder Model (woMod)
            lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();

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
                    woMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    woMod.LocationID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    woMod.WOID = (reader[2] != DBNull.Value) ? Convert.ToInt64(reader[2]) : 0;
                    woMod.PurchaseOrder = (reader[3] != DBNull.Value) ? (string)reader[3] : "";

                    // StartDate and FinishDate
                    result = DateTime.TryParse(reader[4].ToString(), out DT);
                    woMod.StartDate = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    woMod.FinishDate = (result) ? DT : nullDate;

                    //
                    woMod.ROWName = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    woMod.ROWNum = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    woMod.State = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    woMod.Description = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    woMod.JobType = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    woMod.PIC = (reader[11] != DBNull.Value) ? (string)reader[11] : "";

                    woMod.ContractPrice_cost = (reader[12] != DBNull.Value) ? (decimal)reader[12] : 0;
                    woMod.ContractPrice_retail = (reader[13] != DBNull.Value) ? (decimal)reader[13] : 0;

                    woMod.RateID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    woMod.LocID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    woMod.expWorker = (reader[16] != DBNull.Value) ? Convert.ToDouble(reader[16]) : 0;
                    woMod.expEquip = (reader[17] != DBNull.Value) ? Convert.ToDouble(reader[17]) : 0;
                    woMod.expChem = (reader[18] != DBNull.Value) ? Convert.ToDouble(reader[18]) : 0;
                    woMod.InvoicedNoTax = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    woMod.perDiemCost = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    woMod.TankTotal = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;

                    woMod.linenum = (reader[22] != DBNull.Value) ? (string)reader[22] : "";
                    woMod.AccNum = (reader[23] != DBNull.Value) ? Convert.ToInt64(reader[23]) : 0;
                    woMod.ClientName = (reader[24] != DBNull.Value) ? (string)reader[24] : "";
                }

                // the close
                reader.Close();
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
            }

            // the close
            connection.Close();

            // return the Model
            return woMod;
        }


        // ADD
        public string Add_WorkOrder_Rec(lw_WorkOrder_Model woMod)
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
            string sqlStatement = "INSERT INTO lw_WorkOrder (LocationID, WOID, PurchaseOrder, StartDate, FinishDate, " +
               "ROWName, ROWNum, State, Description, JobType, PIC, ContractPrice_cost, ContractPrice_retail, RateID, LocID, " +
               "expWorker, expEquip, expChem, InvoicedNoTax, perDiemCost, TankTotal, linenum, AccNum, ClientName) " +
                "VALUES (@LocationID, @WOID, @PurchaseOrder, @StartDate, @FinishDate, " +
               "@ROWName, @ROWNum, @State, @Description, @JobType, @PIC, @ContractPrice_cost, @ContractPrice_retail, @RateID, @LocID, " +
               "@expWorker, @expEquip, @expChem, @InvoicedNoTax, @perDiemCost, @TankTotal, @linenum, @AccNum, @ClientName)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@LocationID", woMod.LocationID);
                command.Parameters.AddWithValue("@WOID", woMod.WOID);
                command.Parameters.AddWithValue("@PurchaseOrder", woMod.PurchaseOrder);

                // date handling
                if (woMod.StartDate != null)
                {
                    command.Parameters.AddWithValue("@StartDate", woMod.StartDate);
                }
                else
                {
                    command.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }
                if (woMod.FinishDate != null)
                {
                    command.Parameters.AddWithValue("@FinishDate", woMod.FinishDate);
                }
                else
                {
                    command.Parameters.AddWithValue("@FinishDate", DBNull.Value);
                }

                command.Parameters.AddWithValue("@ROWName", woMod.ROWName);
                command.Parameters.AddWithValue("@ROWNum", woMod.ROWNum);
                command.Parameters.AddWithValue("@State", woMod.State);
                command.Parameters.AddWithValue("@Description", woMod.Description);
                command.Parameters.AddWithValue("@JobType", woMod.JobType);
                command.Parameters.AddWithValue("@PIC", woMod.PIC);
                command.Parameters.AddWithValue("@ContractPrice_cost", woMod.ContractPrice_cost);
                command.Parameters.AddWithValue("@ContractPrice_retail", woMod.ContractPrice_retail);
                command.Parameters.AddWithValue("@RateID", woMod.RateID);
                command.Parameters.AddWithValue("@LocID", woMod.LocID);
                command.Parameters.AddWithValue("@expWorker", woMod.expWorker);
                command.Parameters.AddWithValue("@expEquip", woMod.expEquip);
                command.Parameters.AddWithValue("@expChem", woMod.expChem);
                command.Parameters.AddWithValue("@InvoicedNoTax", woMod.InvoicedNoTax);
                command.Parameters.AddWithValue("@perDiemCost", woMod.perDiemCost);
                command.Parameters.AddWithValue("@TankTotal", woMod.TankTotal);
                command.Parameters.AddWithValue("@linenum", woMod.linenum);
                command.Parameters.AddWithValue("@AccNum", woMod.AccNum);
                command.Parameters.AddWithValue("@ClientName", woMod.ClientName);
                
                command.ExecuteNonQuery();
                strMsg = "Record was added.";
                // update the next available Work Order Number by 1
                UpdateNext_WONum();
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL:Record Add Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_WorkOrder_rec(lw_WorkOrder_Model woMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_WorkOrder " +
                "SET LocationID=@LocationID, " +
                "WOID=@WOID, " +
                "PurchaseOrder=@PurchaseOrder, " +
                "StartDate=@StartDate, " +
                "FinishDate=@FinishDate, " +
                "ROWName=@ROWName, " +
                "ROWNum=@ROWNum, " +
                "State=@State, " +
                "Description=@Description, " +
                "JobType=@JobType, " +
                "PIC=@PIC, " +
                "ContractPrice_cost=@ContractPrice_cost, " +
                "ContractPrice_retail=@ContractPrice_retail, " +
                "RateID=@RateID, " +
                "LocID=@LocID, " +
                "expWorker=@expWorker, " +
                "expEquip=@expEquip, " +
                "expChem=@expChem, " +
                "InvoicedNoTax=@InvoicedNoTax, " +
                "perDiemCost=@perDiemCost, " +
                "TankTotal=@TankTotal, " +
                "linenum=@linenum, " +
                "AccNum=@AccNum, " +
                "ClientName=@ClientName " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@LocationID", woMod.LocationID);
                command.Parameters.AddWithValue("@WOID", woMod.WOID);
                command.Parameters.AddWithValue("@PurchaseOrder", woMod.PurchaseOrder);


                // date handling
                if (woMod.StartDate != null)
                {
                    command.Parameters.AddWithValue("@StartDate", woMod.StartDate);
                }
                else
                {
                    command.Parameters.AddWithValue("@StartDate", DBNull.Value);
                }
                if (woMod.FinishDate != null)
                {
                    command.Parameters.AddWithValue("@FinishDate", woMod.FinishDate);
                }
                else
                {
                    command.Parameters.AddWithValue("@FinishDate", DBNull.Value);
                }

                command.Parameters.AddWithValue("@ROWName", woMod.ROWName);
                command.Parameters.AddWithValue("@ROWNum", woMod.ROWNum);
                command.Parameters.AddWithValue("@State", woMod.State);
                command.Parameters.AddWithValue("@Description", woMod.Description);
                command.Parameters.AddWithValue("@JobType", woMod.JobType);
                command.Parameters.AddWithValue("@PIC", woMod.PIC);
                command.Parameters.AddWithValue("@ContractPrice_cost", woMod.ContractPrice_cost);
                command.Parameters.AddWithValue("@ContractPrice_retail", woMod.ContractPrice_retail);
                command.Parameters.AddWithValue("@RateID", woMod.RateID);
                command.Parameters.AddWithValue("@LocID", woMod.LocID);
                command.Parameters.AddWithValue("@expWorker", woMod.expWorker);
                command.Parameters.AddWithValue("@expEquip", woMod.expEquip);
                command.Parameters.AddWithValue("@expChem", woMod.expChem);
                command.Parameters.AddWithValue("@InvoicedNoTax", woMod.InvoicedNoTax);
                command.Parameters.AddWithValue("@perDiemCost", woMod.perDiemCost);
                command.Parameters.AddWithValue("@TankTotal", woMod.TankTotal);
                command.Parameters.AddWithValue("@linenum", woMod.linenum);
                command.Parameters.AddWithValue("@AccNum", woMod.AccNum);
                command.Parameters.AddWithValue("@ClientName", woMod.ClientName);

                //                // ID is key
                command.Parameters.AddWithValue("@ID", woMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Update_WorkOrder_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }



        // DELETE
        public string Delete_WorkOrder_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lw_WorkOrder " +
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
                }

                // the close
                connection.Close();
            }
            else
            {
                strMsg = "Delete did not occur, ID did not contain data.";
            }

            // return status message
            return strMsg;
        }


        // removes all records from the WO table
        // while leaving all table structures
        public string Truncate_WorkOrder_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_WorkOrder";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Work Order table Initialized.";
            }
            catch (Exception err)
            {
                connection.Close();
                strMsg = err.Message.ToString();
            }
                        
            // return status message
            return strMsg;
        }



        // Reset Bid Model
        public lw_WorkOrder_Model Reset_Bids_Mod(lw_WorkOrder_Model woMod)
        {
            DateTime? nullDate = null;

            // reset the model
            woMod.ID = 0;
            woMod.LocationID = "";
            woMod.WOID = 0;
            woMod.PurchaseOrder = "";
            woMod.StartDate = nullDate;
            woMod.FinishDate = nullDate;
            woMod.ROWName = "";
            woMod.ROWNum = "";
            woMod.State = "";
            woMod.Description = "";
            woMod.JobType = "";
            woMod.PIC = "";
            woMod.ContractPrice_cost = 0;
            woMod.ContractPrice_retail = 0;
            woMod.RateID = 0;
            woMod.LocID = 0;
            woMod.expWorker = 0;
            woMod.expEquip = 0;
            woMod.expChem = 0;
            woMod.InvoicedNoTax = 0;
            woMod.perDiemCost = 0;
            woMod.TankTotal = 0;
            woMod.linenum = "";
            woMod.AccNum = 0;
            woMod.ClientName = "";

            // return the model
            return woMod;
        }




        // Method: Get List by Location ID
        public List<lw_WorkOrder_Model> Get_WorkerOrders_ByLocationID_List(string strLocID)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            string strMsg = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, LocationID, WOID, PurchaseOrder, StartDate, FinishDate, " +
               "ROWName, ROWNum, State, Description, JobType, PIC, ContractPrice_cost, " +
               "ContractPrice_retail, RateID, LocID, expWorker, expEquip, expChem, InvoicedNoTax, " +
               "perDiemCost, TankTotal, linenum, AccNum, ClientName " +
               "FROM lw_WorkOrder " +
               "WHERE LocationID=@LocationID " +
               "ORDER BY LocationID";

            // create List
            List<lw_WorkOrder_Model> woMod_List = new List<lw_WorkOrder_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@LocationID", strLocID);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();

                    woMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    woMod.LocationID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    woMod.WOID = (reader[2] != DBNull.Value) ? Convert.ToInt64(reader[2]) : 0;
                    woMod.PurchaseOrder = (reader[3] != DBNull.Value) ? (string)reader[3] : "";

                    // StartDate and FinishDate
                    result = DateTime.TryParse(reader[4].ToString(), out DT);
                    woMod.StartDate = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    woMod.FinishDate = (result) ? DT : nullDate;

                    //
                    woMod.ROWName = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    woMod.ROWNum = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    woMod.State = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    woMod.Description = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    woMod.JobType = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    woMod.PIC = (reader[11] != DBNull.Value) ? (string)reader[11] : "";

                    woMod.ContractPrice_cost = (reader[12] != DBNull.Value) ? (decimal)reader[12] : 0;
                    woMod.ContractPrice_retail = (reader[13] != DBNull.Value) ? (decimal)reader[13] : 0;

                    woMod.RateID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    woMod.LocID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    woMod.expWorker = (reader[16] != DBNull.Value) ? Convert.ToDouble(reader[16]) : 0;
                    woMod.expEquip = (reader[17] != DBNull.Value) ? Convert.ToDouble(reader[17]) : 0;
                    woMod.expChem = (reader[18] != DBNull.Value) ? Convert.ToDouble(reader[18]) : 0;
                    woMod.InvoicedNoTax = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    woMod.perDiemCost = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    woMod.TankTotal = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;

                    woMod.linenum = (reader[22] != DBNull.Value) ? (string)reader[22] : "";
                    woMod.AccNum = (reader[23] != DBNull.Value) ? Convert.ToInt64(reader[23]) : 0;
                    woMod.ClientName = (reader[24] != DBNull.Value) ? (string)reader[24] : "";

                    // add to List
                    woMod_List.Add(woMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
            }

            // return List
            return woMod_List;
        }




        // Method: Get List by Location ID
        public List<lw_WorkOrder_Model> Get_WorkerOrders_AccNum_List(Int64 _AccNum)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            string strMsg = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, LocationID, WOID, PurchaseOrder, StartDate, FinishDate, " +
               "ROWName, ROWNum, State, Description, JobType, PIC, ContractPrice_cost, " +
               "ContractPrice_retail, RateID, LocID, expWorker, expEquip, expChem, InvoicedNoTax, " +
               "perDiemCost, TankTotal, linenum, AccNum, ClientName " +
               "FROM lw_WorkOrder " +
               "WHERE AccNum=@AccNum " +
               "ORDER BY LocationID";

            // create List
            List<lw_WorkOrder_Model> woMod_List = new List<lw_WorkOrder_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@AccNum", _AccNum);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();

                    woMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    woMod.LocationID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    woMod.WOID = (reader[2] != DBNull.Value) ? Convert.ToInt64(reader[2]) : 0;
                    woMod.PurchaseOrder = (reader[3] != DBNull.Value) ? (string)reader[3] : "";

                    // StartDate and FinishDate
                    result = DateTime.TryParse(reader[4].ToString(), out DT);
                    woMod.StartDate = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    woMod.FinishDate = (result) ? DT : nullDate;

                    //
                    woMod.ROWName = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    woMod.ROWNum = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    woMod.State = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    woMod.Description = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    woMod.JobType = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    woMod.PIC = (reader[11] != DBNull.Value) ? (string)reader[11] : "";

                    woMod.ContractPrice_cost = (reader[12] != DBNull.Value) ? (decimal)reader[12] : 0;
                    woMod.ContractPrice_retail = (reader[13] != DBNull.Value) ? (decimal)reader[13] : 0;

                    woMod.RateID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    woMod.LocID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    woMod.expWorker = (reader[16] != DBNull.Value) ? Convert.ToDouble(reader[16]) : 0;
                    woMod.expEquip = (reader[17] != DBNull.Value) ? Convert.ToDouble(reader[17]) : 0;
                    woMod.expChem = (reader[18] != DBNull.Value) ? Convert.ToDouble(reader[18]) : 0;
                    woMod.InvoicedNoTax = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    woMod.perDiemCost = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    woMod.TankTotal = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;

                    woMod.linenum = (reader[22] != DBNull.Value) ? (string)reader[22] : "";
                    woMod.AccNum = (reader[23] != DBNull.Value) ? Convert.ToInt64(reader[23]) : 0;
                    woMod.ClientName = (reader[24] != DBNull.Value) ? (string)reader[24] : "";

                    // add to List
                    woMod_List.Add(woMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
            }

            // return List
            return woMod_List;
        }




        // Method: Get List by Location ID
        public List<lw_WorkOrder_Model> Get_WorkerOrders_bySelectedDate_List(string strDate)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            string strMsg = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // convert selected string date
            result = DateTime.TryParse(strDate, out DT);

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, LocationID, WOID, PurchaseOrder, StartDate, FinishDate, " +
               "ROWName, ROWNum, State, Description, JobType, PIC, ContractPrice_cost, " +
               "ContractPrice_retail, RateID, LocID, expWorker, expEquip, expChem, InvoicedNoTax, " +
               "perDiemCost, TankTotal, linenum, AccNum, ClientName " +
               "FROM lw_WorkOrder " +
               "WHERE StartDate>=@StartDate " +
               "ORDER BY StartDate";

            // create List
            List<lw_WorkOrder_Model> woMod_List = new List<lw_WorkOrder_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@StartDate", DT);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();

                    woMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    woMod.LocationID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    woMod.WOID = (reader[2] != DBNull.Value) ? Convert.ToInt64(reader[2]) : 0;
                    woMod.PurchaseOrder = (reader[3] != DBNull.Value) ? (string)reader[3] : "";

                    // StartDate and FinishDate
                    result = DateTime.TryParse(reader[4].ToString(), out DT);
                    woMod.StartDate = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    woMod.FinishDate = (result) ? DT : nullDate;

                    //
                    woMod.ROWName = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    woMod.ROWNum = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    woMod.State = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    woMod.Description = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    woMod.JobType = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    woMod.PIC = (reader[11] != DBNull.Value) ? (string)reader[11] : "";

                    woMod.ContractPrice_cost = (reader[12] != DBNull.Value) ? (decimal)reader[12] : 0;
                    woMod.ContractPrice_retail = (reader[13] != DBNull.Value) ? (decimal)reader[13] : 0;

                    woMod.RateID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    woMod.LocID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    woMod.expWorker = (reader[16] != DBNull.Value) ? Convert.ToDouble(reader[16]) : 0;
                    woMod.expEquip = (reader[17] != DBNull.Value) ? Convert.ToDouble(reader[17]) : 0;
                    woMod.expChem = (reader[18] != DBNull.Value) ? Convert.ToDouble(reader[18]) : 0;
                    woMod.InvoicedNoTax = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    woMod.perDiemCost = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    woMod.TankTotal = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;

                    woMod.linenum = (reader[22] != DBNull.Value) ? (string)reader[22] : "";
                    woMod.AccNum = (reader[23] != DBNull.Value) ? Convert.ToInt64(reader[23]) : 0;
                    woMod.ClientName = (reader[24] != DBNull.Value) ? (string)reader[24] : "";

                    // add to List
                    woMod_List.Add(woMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_WorkerOrders_bySelectedDate_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return woMod_List;
        }



        // Method: Select Client List by LIKE Client Name
        public List<lw_WorkOrder_Model> Get_WorkerOrders_byLIKEClientName_List(string _clName)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            string strMsg = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;
            
            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, LocationID, WOID, PurchaseOrder, StartDate, FinishDate, " +
               "ROWName, ROWNum, State, Description, JobType, PIC, ContractPrice_cost, " +
               "ContractPrice_retail, RateID, LocID, expWorker, expEquip, expChem, InvoicedNoTax, " +
               "perDiemCost, TankTotal, linenum, AccNum, ClientName " +
               "FROM lw_WorkOrder " +
               "WHERE ClientName LIKE @ClientName " +
               "ORDER BY ClientName";

            // create List
            List<lw_WorkOrder_Model> woMod_List = new List<lw_WorkOrder_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert command
                command.Parameters.AddWithValue("@ClientName", _clName + '%');

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_WorkOrder_Model woMod = new lw_WorkOrder_Model();

                    woMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    woMod.LocationID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    woMod.WOID = (reader[2] != DBNull.Value) ? Convert.ToInt64(reader[2]) : 0;
                    woMod.PurchaseOrder = (reader[3] != DBNull.Value) ? (string)reader[3] : "";

                    // StartDate and FinishDate
                    result = DateTime.TryParse(reader[4].ToString(), out DT);
                    woMod.StartDate = (result) ? DT : nullDate;
                    result = DateTime.TryParse(reader[5].ToString(), out DT);
                    woMod.FinishDate = (result) ? DT : nullDate;

                    //
                    woMod.ROWName = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    woMod.ROWNum = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    woMod.State = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    woMod.Description = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    woMod.JobType = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    woMod.PIC = (reader[11] != DBNull.Value) ? (string)reader[11] : "";

                    woMod.ContractPrice_cost = (reader[12] != DBNull.Value) ? (decimal)reader[12] : 0;
                    woMod.ContractPrice_retail = (reader[13] != DBNull.Value) ? (decimal)reader[13] : 0;

                    woMod.RateID = (reader[14] != DBNull.Value) ? Convert.ToInt64(reader[14]) : 0;
                    woMod.LocID = (reader[15] != DBNull.Value) ? Convert.ToInt64(reader[15]) : 0;
                    woMod.expWorker = (reader[16] != DBNull.Value) ? Convert.ToDouble(reader[16]) : 0;
                    woMod.expEquip = (reader[17] != DBNull.Value) ? Convert.ToDouble(reader[17]) : 0;
                    woMod.expChem = (reader[18] != DBNull.Value) ? Convert.ToDouble(reader[18]) : 0;
                    woMod.InvoicedNoTax = (reader[19] != DBNull.Value) ? Convert.ToDouble(reader[19]) : 0;
                    woMod.perDiemCost = (reader[20] != DBNull.Value) ? Convert.ToDouble(reader[20]) : 0;
                    woMod.TankTotal = (reader[21] != DBNull.Value) ? Convert.ToDouble(reader[21]) : 0;

                    woMod.linenum = (reader[22] != DBNull.Value) ? (string)reader[22] : "";
                    woMod.AccNum = (reader[23] != DBNull.Value) ? Convert.ToInt64(reader[23]) : 0;
                    woMod.ClientName = (reader[24] != DBNull.Value) ? (string)reader[24] : "";

                    // add to List
                    woMod_List.Add(woMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_WorkerOrders_byLIKEClientName_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return woMod_List;
        }

        
        // Update the Next WorkOrder Number by 1
        private void UpdateNext_WONum()
        {
            ApplicationValue_Model avMod = new ApplicationValue_Model();
            Application_Values_Worker AVWkr = new Application_Values_Worker();
            string strMsg = "";

            // get application Value model
            avMod = AVWkr.Get_SpecificAppValue_Record(ref strMsg);

            // Update, Increment Next Work Order ID by 1
            avMod.ID = 1;
            avMod.NextWorkOrderID = avMod.NextWorkOrderID + 1;
            AVWkr.Update_ApplicationValues_rec(avMod);
        }
    }
}