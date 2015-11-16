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
    public class lw_Bids_Worker
    {
        // based on SQL table: lw_ClientContacts
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_Bids_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_Bids_Model> Get_Bids_List(ref string strMsg)
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
            string sqlStatement = "SELECT ID, BidID, ClientLocID, BidAmtRetail, BidAmtCost, Area, BidSent, " +
                "Description, BidWon, Narrative, AttnName, Narrative2, TwoColumns, descBidAmtRetail, " +
                "descBidAmtCost, showLocName, AccNum, ClientName " +
                "FROM lw_Bids " +
                "ORDER BY AccNum";

            // create List
            List<lw_Bids_Model> bMod_List = new List<lw_Bids_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Bids_Model bMod = new lw_Bids_Model();

                    bMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    bMod.BidID = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    bMod.ClientLocID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    bMod.BidAmtRetail = (reader[3] != DBNull.Value) ? (decimal)reader[3] : 0;
                    bMod.BidAmtCost = (reader[4] != DBNull.Value) ? (decimal)reader[4] : 0;
                    bMod.Area = (reader[5] != DBNull.Value) ? (Int64)reader[5] : 0;
                    //
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    bMod.BidSent = (result) ? DT : nullDate;
                    //
                    bMod.Description = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    bMod.BidWon = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    bMod.Narrative = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    bMod.AttnName = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    bMod.Narrative2 = (reader[11] != DBNull.Value) ? Convert.ToString(reader[11]) : "";
                    bMod.TwoColumns = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    bMod.descBidAmtRetail = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    bMod.descBidAmtCost = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
                    bMod.showLocName = (reader[15] != DBNull.Value) ? (string)reader[15] : "";
                    bMod.AccNum = (reader[16] != DBNull.Value) ? (Int64)reader[16] : 0;
                    bMod.ClientName = (reader[17] != DBNull.Value) ? (string)reader[17] : "";

                    // add Equipment to List
                    bMod_List.Add(bMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL Error: Get_Bids_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return bMod_List;
        }


        // Method: get record data based on id
        public lw_Bids_Model Get_Specific_Bids_Record(int recID)
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
            string sqlStatement = "SELECT ID, BidID, ClientLocID, BidAmtRetail, BidAmtCost, Area, BidSent, " +
                "Description, BidWon, Narrative, AttnName, Narrative2, TwoColumns, descBidAmtRetail, " +
                "descBidAmtCost, showLocName, AccNum, ClientName " +
                "FROM lw_Bids " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on Bids Model (bMod)
            lw_Bids_Model bMod = new lw_Bids_Model();

            try
            {
                // open the connection           
                connection.Open();

                command.Parameters.AddWithValue("@ID", recID);

                // execute the reader
                SqlDataReader reader = command.ExecuteReader();

                // populate the invoice list
                if (reader.Read())
                {
                    bMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    bMod.BidID = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    bMod.ClientLocID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    bMod.BidAmtRetail = (reader[3] != DBNull.Value) ? (decimal)reader[3] : 0;
                    bMod.BidAmtCost = (reader[4] != DBNull.Value) ? (decimal)reader[4] : 0;
                    bMod.Area = (reader[5] != DBNull.Value) ? (Int64)reader[5] : 0;
                    //
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    bMod.BidSent = (result) ? DT : nullDate;
                    //
                    bMod.Description = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    bMod.BidWon = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    bMod.Narrative = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    bMod.AttnName = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    bMod.Narrative2 = (reader[11] != DBNull.Value) ? Convert.ToString(reader[11]) : "";
                    bMod.TwoColumns = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    bMod.descBidAmtRetail = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    bMod.descBidAmtCost = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
                    bMod.showLocName = (reader[15] != DBNull.Value) ? (string)reader[15] : "";
                    bMod.AccNum = (reader[16] != DBNull.Value) ? (Int64)reader[16] : 0;
                    bMod.ClientName = (reader[17] != DBNull.Value) ? (string)reader[17] : "";
                }

                // the close
                reader.Close();
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Get_Specific_Bids_Record", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // the close
            connection.Close();

            // return the Model
            return bMod;
        }


        // ADD
        public string Add_Bids_Rec(lw_Bids_Model bMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lw_Bids (BidID, ClientLocID, BidAmtRetail, BidAmtCost, Area, BidSent, Description, " +
                "BidWon, Narrative, AttnName, Narrative2, TwoColumns, descBidAmtRetail, descBidAmtCost, " +
                "showLocName, AccNum, ClientName) " +
                "VALUES (@BidID, @ClientLocID, @BidAmtRetail, @BidAmtCost, @Area, @BidSent, @Description, " +
                "@BidWon, @Narrative, @AttnName, @Narrative2, @TwoColumns, @descBidAmtRetail, @descBidAmtCost, " +
                "@showLocName, @AccNum, @ClientName)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@BidID", bMod.BidID);
                command.Parameters.AddWithValue("@ClientLocID", bMod.ClientLocID);
                command.Parameters.AddWithValue("@BidAmtRetail", bMod.BidAmtRetail);
                command.Parameters.AddWithValue("@BidAmtCost", bMod.BidAmtCost);
                command.Parameters.AddWithValue("@Area", bMod.Area);
                command.Parameters.AddWithValue("@BidSent", bMod.BidSent);
                command.Parameters.AddWithValue("@Description", bMod.Description);
                command.Parameters.AddWithValue("@BidWon", bMod.BidWon);
                command.Parameters.AddWithValue("@Narrative", bMod.Narrative);
                command.Parameters.AddWithValue("@AttnName", bMod.AttnName);
                command.Parameters.AddWithValue("@Narrative2", bMod.Narrative2);
                command.Parameters.AddWithValue("@TwoColumns", bMod.TwoColumns);
                command.Parameters.AddWithValue("@descBidAmtRetail", bMod.descBidAmtRetail);
                command.Parameters.AddWithValue("@descBidAmtCost", bMod.descBidAmtCost);
                command.Parameters.AddWithValue("@showLocName", bMod.showLocName);
                command.Parameters.AddWithValue("@AccNum", bMod.AccNum);
                command.Parameters.AddWithValue("@ClientName", bMod.ClientName);

                command.ExecuteNonQuery();
                strMsg = "Record was added.";
                // update Application Value: BidsID by 1
                UpdateNext_BidsID();
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Add_Bids_Rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_Bid_rec(lw_Bids_Model bMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_Bids " +
                "SET BidID=@BidID, " +
                "ClientLocID=@ClientLocID, " +
                "BidAmtRetail=@BidAmtRetail, " +
                "BidAmtCost=@BidAmtCost, " +
                "Area=@Area, " +
                "BidSent=@BidSent, " +
                "Description=@Description, " +
                "BidWon=@BidWon, " +
                "Narrative=@Narrative, " +
                "AttnName=@AttnName, " +
                "Narrative2=@Narrative2, " +
                "TwoColumns=@TwoColumns, " +
                "descBidAmtRetail=@descBidAmtRetail, " +
                "descBidAmtCost=@descBidAmtCost " +
                "showLocName=@showLocName, " +
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
                command.Parameters.AddWithValue("@BidID", bMod.BidID);
                command.Parameters.AddWithValue("@ClientLocID", bMod.ClientLocID);
                command.Parameters.AddWithValue("@BidAmtRetail", bMod.BidAmtRetail);
                command.Parameters.AddWithValue("@BidAmtCost", bMod.BidAmtCost);
                command.Parameters.AddWithValue("@Area", bMod.Area);
                command.Parameters.AddWithValue("@BidSent", bMod.BidSent);
                command.Parameters.AddWithValue("@Description", bMod.Description);
                command.Parameters.AddWithValue("@BidWon", bMod.BidWon);
                command.Parameters.AddWithValue("@Narrative", bMod.Narrative);
                command.Parameters.AddWithValue("@AttnName", bMod.AttnName);
                command.Parameters.AddWithValue("@Narrative2", bMod.Narrative2);
                command.Parameters.AddWithValue("@TwoColumns", bMod.TwoColumns);
                command.Parameters.AddWithValue("@descBidAmtRetail", bMod.descBidAmtRetail);
                command.Parameters.AddWithValue("@descBidAmtCost", bMod.descBidAmtCost);
                command.Parameters.AddWithValue("@showLocName", bMod.showLocName);
                command.Parameters.AddWithValue("@AccNum", bMod.AccNum);
                command.Parameters.AddWithValue("@ClientName", bMod.ClientName);
                //
                command.Parameters.AddWithValue("@ID", bMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
            }

            connection.Close();
            return strMsg;
        }



        // DELETE
        public string Delete_Bids_rec(Int32 recID)
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
                string sqlStatement = "DELETE FROM lw_Bids " +
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


        // removes all records from the Bids table
        // while leaving all table structures
        public string Truncate_Bids_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_Bids";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Bids table Initialized.";
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
        private lw_Bids_Model Reset_ClientContact_Mod(lw_Bids_Model bMod)
        {
            DateTime? nullDate = null;

            // reset the model
            bMod.ID = 0;
            bMod.BidID = 0;
            bMod.ClientLocID = "";
            bMod.BidAmtRetail = 0;
            bMod.BidAmtCost = 0;
            bMod.Area = 0;
            bMod.BidSent = nullDate;
            bMod.Description = "";
            bMod.BidWon = "";
            bMod.Narrative = "";
            bMod.AttnName = "";
            bMod.Narrative2 = "";
            bMod.TwoColumns = "";
            bMod.descBidAmtRetail = "";
            bMod.descBidAmtCost = "";
            bMod.showLocName = "";
            bMod.AccNum = 0;
            bMod.ClientName = "";

            // return the model
            return bMod;
        }



        // Method: Get List by AccNum
        public List<lw_Bids_Model> Get_Bids_ByAccNum_List(Int64 intAccNum)
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
            string sqlStatement = "SELECT ID, BidID, ClientLocID, BidAmtRetail, BidAmtCost, Area, BidSent, " +
                "Description, BidWon, Narrative, AttnName, Narrative2, TwoColumns, descBidAmtRetail, " +
                "descBidAmtCost, showLocName, AccNum, ClientName " +
                "FROM lw_Bids " +
                "WHERE AccNum=@AccNum " +
                "ORDER BY ClientLocID";

            // create List
            List<lw_Bids_Model> bMod_List = new List<lw_Bids_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@AccNum", intAccNum);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Bids_Model bMod = new lw_Bids_Model();

                    bMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    bMod.BidID = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    bMod.ClientLocID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    bMod.BidAmtRetail = (reader[3] != DBNull.Value) ? (decimal)reader[3] : 0;
                    bMod.BidAmtCost = (reader[4] != DBNull.Value) ? (decimal)reader[4] : 0;
                    bMod.Area = (reader[5] != DBNull.Value) ? (Int64)reader[5] : 0;
                    //
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    bMod.BidSent = (result) ? DT : nullDate;
                    //
                    bMod.Description = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    bMod.BidWon = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    bMod.Narrative = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    bMod.AttnName = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    bMod.Narrative2 = (reader[11] != DBNull.Value) ? Convert.ToString(reader[11]) : "";
                    bMod.TwoColumns = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    bMod.descBidAmtRetail = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    bMod.descBidAmtCost = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
                    bMod.showLocName = (reader[15] != DBNull.Value) ? (string)reader[15] : "";
                    bMod.AccNum = (reader[16] != DBNull.Value) ? (Int64)reader[16] : 0;
                    bMod.ClientName = (reader[17] != DBNull.Value) ? (string)reader[17] : "";

                    // add Equipment to List
                    bMod_List.Add(bMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Get_Bids_ByAccNum_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return bMod_List;
        }



        // Method: Get List by AccNum
        public List<lw_Bids_Model> Get_Bids_ByClientLocation_List(string strClLocID)
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
            string sqlStatement = "SELECT ID, BidID, ClientLocID, BidAmtRetail, BidAmtCost, Area, BidSent, " +
                "Description, BidWon, Narrative, AttnName, Narrative2, TwoColumns, descBidAmtRetail, " +
                "descBidAmtCost, showLocName, AccNum, ClientName " +
                "FROM lw_Bids " +
                "WHERE ClientLocID=@ClientLocID " +
                "ORDER BY ClientLocID";

            // create List
            List<lw_Bids_Model> bMod_List = new List<lw_Bids_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@ClientLocID", strClLocID);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Bids_Model bMod = new lw_Bids_Model();

                    bMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    bMod.BidID = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    bMod.ClientLocID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    bMod.BidAmtRetail = (reader[3] != DBNull.Value) ? (decimal)reader[3] : 0;
                    bMod.BidAmtCost = (reader[4] != DBNull.Value) ? (decimal)reader[4] : 0;
                    bMod.Area = (reader[5] != DBNull.Value) ? (Int64)reader[5] : 0;
                    //
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    bMod.BidSent = (result) ? DT : nullDate;
                    //
                    bMod.Description = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    bMod.BidWon = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    bMod.Narrative = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    bMod.AttnName = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    bMod.Narrative2 = (reader[11] != DBNull.Value) ? Convert.ToString(reader[11]) : "";
                    bMod.TwoColumns = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    bMod.descBidAmtRetail = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    bMod.descBidAmtCost = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
                    bMod.showLocName = (reader[15] != DBNull.Value) ? (string)reader[15] : "";
                    bMod.AccNum = (reader[16] != DBNull.Value) ? (Int64)reader[16] : 0;
                    bMod.ClientName = (reader[17] != DBNull.Value) ? (string)reader[17] : "";

                    // add to List
                    bMod_List.Add(bMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Get_Bids_ByClientLocation_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return bMod_List;
        }




        // Method: Get List by Bid Sent Date
        public List<lw_Bids_Model> Get_Bids_ByBidSentDate_List(string strDate)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            string strMsg = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // get the compare date
            result = DateTime.TryParse(strDate, out DT);

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, BidID, ClientLocID, BidAmtRetail, BidAmtCost, Area, BidSent, " +
                "Description, BidWon, Narrative, AttnName, Narrative2, TwoColumns, descBidAmtRetail, " +
                "descBidAmtCost, showLocName, AccNum, ClientName " +
                "FROM lw_Bids " +
                "WHERE BidSent>=@BidSent " +
                "ORDER BY BidSent";

            // create List
            List<lw_Bids_Model> bMod_List = new List<lw_Bids_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@BidSent", DT);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Bids_Model bMod = new lw_Bids_Model();

                    bMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    bMod.BidID = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    bMod.ClientLocID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    bMod.BidAmtRetail = (reader[3] != DBNull.Value) ? (decimal)reader[3] : 0;
                    bMod.BidAmtCost = (reader[4] != DBNull.Value) ? (decimal)reader[4] : 0;
                    bMod.Area = (reader[5] != DBNull.Value) ? (Int64)reader[5] : 0;
                    //
                    result = DateTime.TryParse(reader[6].ToString(), out DT);
                    bMod.BidSent = (result) ? DT : nullDate;
                    //
                    bMod.Description = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    bMod.BidWon = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    bMod.Narrative = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    bMod.AttnName = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    bMod.Narrative2 = (reader[11] != DBNull.Value) ? Convert.ToString(reader[11]) : "";
                    bMod.TwoColumns = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    bMod.descBidAmtRetail = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    bMod.descBidAmtCost = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
                    bMod.showLocName = (reader[15] != DBNull.Value) ? (string)reader[15] : "";
                    bMod.AccNum = (reader[16] != DBNull.Value) ? (Int64)reader[16] : 0;
                    bMod.ClientName = (reader[17] != DBNull.Value) ? (string)reader[17] : "";

                    // add to List
                    bMod_List.Add(bMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "BidsList";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Get_Bids_ByBidSentDate_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return bMod_List;
        }


        // Update the Next Bid ID Number by 1
        private void UpdateNext_BidsID()
        {
            ApplicationValue_Model avMod = new ApplicationValue_Model();
            Application_Values_Worker AVWkr = new Application_Values_Worker();
            string strMsg = "";

            // get the Application Values Model
            avMod = AVWkr.Get_SpecificAppValue_Record(ref strMsg);

            // increment next Bids ID number by 1
            avMod.ID = 1;
            avMod.NextBidID = avMod.NextBidID + 1;
            AVWkr.Update_ApplicationValues_rec(avMod);
        }
    }
}
