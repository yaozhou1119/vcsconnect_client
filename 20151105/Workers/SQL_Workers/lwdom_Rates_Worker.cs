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
    public class lwdom_Rates_Worker
    {
        // based on SQL table name: lwdom_chemlist
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lwdom_Rates_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lwdom_Rates_Model> Get_Rates_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, RateID, Category, Code, RateYear, Description, " +
                "RetailRate, CostRate, ActiveStatus " +
                "FROM lwdom_Rates " +
                "ORDER BY RateYear, Category";

            // create List
            List<lwdom_Rates_Model> lwrMod_List = new List<lwdom_Rates_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_Rates_Model lwrMod = new lwdom_Rates_Model();

                    lwrMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwrMod.RateID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    lwrMod.Category = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    lwrMod.Code = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    lwrMod.RateYear = (reader[4] != DBNull.Value) ? (int)reader[4] : 0;
                    lwrMod.Description = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    lwrMod.RetailRate = (reader[6] != DBNull.Value) ? (decimal)reader[6] : 0;
                    lwrMod.CostRate = (reader[7] != DBNull.Value) ? (decimal)reader[7] : 0;
                    lwrMod.ActiveStatus = (reader[8] != DBNull.Value) ? (string)reader[8] : "";

                    // add Equipment to List
                    lwrMod_List.Add(lwrMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
            }

            // return List
            return lwrMod_List;
        }


        // Method: get record data based on id
        public lwdom_Rates_Model Get_SpecificRates_Record(int recID)
        {
            string strMsg = "";
            
            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, RateID, Category, Code, RateYear, Description, " +
                "RetailRate, CostRate, ActiveStatus " +
                "FROM lwdom_Rates " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on LW Rates Model (lwrMod)
            lwdom_Rates_Model lwrMod = new lwdom_Rates_Model();

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
                    lwrMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwrMod.RateID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    lwrMod.Category = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    lwrMod.Code = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    lwrMod.RateYear = (reader[4] != DBNull.Value) ? (int)reader[4] : 0;
                    lwrMod.Description = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    lwrMod.RetailRate = (reader[6] != DBNull.Value) ? (decimal)reader[6] : 0;
                    lwrMod.CostRate = (reader[7] != DBNull.Value) ? (decimal)reader[7] : 0;
                    lwrMod.ActiveStatus = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
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
            return lwrMod;
        }


        // ADD
        public string Add_Rates_Rec(lwdom_Rates_Model lwrMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lwdom_Rates (RateID, Category, Code, RateYear, " +
                "Description, RetailRate, CostRate, ActiveStatus) " +
                "VALUES (@RateID, @Category, @Code, @RateYear, " +
                "@Description, @RetailRate, @CostRate, @ActiveStatus)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@RateID", lwrMod.RateID);
                command.Parameters.AddWithValue("@Category", lwrMod.Category);
                command.Parameters.AddWithValue("@Code", lwrMod.Code);
                command.Parameters.AddWithValue("@RateYear", lwrMod.RateYear);
                command.Parameters.AddWithValue("@Description", lwrMod.Description);
                command.Parameters.AddWithValue("@RetailRate", lwrMod.RetailRate);
                command.Parameters.AddWithValue("@CostRate", lwrMod.CostRate);
                command.Parameters.AddWithValue("@ActiveStatus", lwrMod.ActiveStatus);
                //lwdcMod.activeStatus = true;
                //command.Parameters.AddWithValue("@activeStatus", lwdcMod.activeStatus);

                command.ExecuteNonQuery();
                strMsg = "Record was added.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_Rates_rec(lwdom_Rates_Model lwrMod)
        {
            // Method: update selected Hours Master recore 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lwdom_Rates " +
                "SET RateID=@RateID, " +
                "Category=@Category, " +
                "Code=@Code, " +
                "RateYear=@RateYear, " +
                "Description=@Description, " +
                "RetailRate=@RetailRate, " +
                "CostRate=@CostRate, " +
                "ActiveStatus=@ActiveStatus " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@RateID", lwrMod.RateID);
                command.Parameters.AddWithValue("@Category", lwrMod.Category);
                command.Parameters.AddWithValue("@Code", lwrMod.Code);
                command.Parameters.AddWithValue("@RateYear", lwrMod.RateYear);
                command.Parameters.AddWithValue("@Description", lwrMod.Description);
                command.Parameters.AddWithValue("@RetailRate", lwrMod.RetailRate);
                command.Parameters.AddWithValue("@CostRate", lwrMod.CostRate);
                command.Parameters.AddWithValue("@ActiveStatus", lwrMod.ActiveStatus);
                //
                command.Parameters.AddWithValue("@ID", lwrMod.ID); // must be in the order of the sqlstatement

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

        public string Delete_Rates_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lwdom_Rates " +
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
                strMsg = "Delete did not occur, chemcode did not contain data.";
            }

            // return status message
            return strMsg;
        }


        // removes all records from the lwdom_Rates table
        // while leaving all table structures
        public string Truncate_Rates_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lwdom_Rates";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "ChemList table Initialized.";
            }
            catch (Exception err)
            {
                connection.Close();
                strMsg = err.Message.ToString();
            }
                        
            // return status message
            return strMsg;
        }



        // Reset lwdom_Rates Model
        private lwdom_Rates_Model Reset_Rates_Model(lwdom_Rates_Model lwrMod)
        {
            // reset the model
            lwrMod.ID = 0;
            lwrMod.RateID = "";
            lwrMod.Category = "";
            lwrMod.Code = "";
            lwrMod.RateYear = 0;
            lwrMod.Description = "";
            lwrMod.RetailRate = 0;
            lwrMod.CostRate = 0;
            lwrMod.ActiveStatus = "";

            // return the model
            return lwrMod;
        }



        // Method: Get List RateYear strings
        public List<string> Get_RateYear_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";


            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT DISTINCT RateYear " +
                "FROM lwdom_Rates " +
                "ORDER BY RateYear";

            // create List
            List<string> ry_List = new List<string>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    string strRateYear = "";

                    strRateYear = (reader[0] != DBNull.Value) ? Convert.ToString(reader[0]) : "";
                    
                    // add Rate Year to list of strings
                    ry_List.Add(strRateYear);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_RateYear_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List of strings
            return ry_List;
        }



        // Method: Get List
        public List<lwdom_Rates_Model> Get_Rates_ByRateYear_List(int intRY)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, RateID, Category, Code, RateYear, Description, " +
                "RetailRate, CostRate, ActiveStatus " +
                "FROM lwdom_Rates " +
                "WHERE RateYear=@RateYear " +
                "ORDER BY Category";

            // create List
            List<lwdom_Rates_Model> lwrMod_List = new List<lwdom_Rates_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert command
                command.Parameters.AddWithValue("@RateYear", intRY);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_Rates_Model lwrMod = new lwdom_Rates_Model();

                    lwrMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwrMod.RateID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    lwrMod.Category = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    lwrMod.Code = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    lwrMod.RateYear = (reader[4] != DBNull.Value) ? (int)reader[4] : 0;
                    lwrMod.Description = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    lwrMod.RetailRate = (reader[6] != DBNull.Value) ? (decimal)reader[6] : 0;
                    lwrMod.CostRate = (reader[7] != DBNull.Value) ? (decimal)reader[7] : 0;
                    lwrMod.ActiveStatus = (reader[8] != DBNull.Value) ? (string)reader[8] : "";

                    // add Equipment to List
                    lwrMod_List.Add(lwrMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
            }

            // return List
            return lwrMod_List;
        }



        // Method: Get List
        public List<lwdom_Rates_Model> Get_Rates_ByRateID_List(string _rID)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, RateID, Category, Code, RateYear, Description, " +
                "RetailRate, CostRate, ActiveStatus " +
                "FROM lwdom_Rates " +
                "WHERE RateID=@RateID " +
                "ORDER BY Category, Code";

            // create List
            List<lwdom_Rates_Model> lwrMod_List = new List<lwdom_Rates_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert command
                command.Parameters.AddWithValue("@RateID", _rID);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_Rates_Model lwrMod = new lwdom_Rates_Model();

                    lwrMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwrMod.RateID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    lwrMod.Category = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    lwrMod.Code = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    lwrMod.RateYear = (reader[4] != DBNull.Value) ? (int)reader[4] : 0;
                    lwrMod.Description = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    lwrMod.RetailRate = (reader[6] != DBNull.Value) ? (decimal)reader[6] : 0;
                    lwrMod.CostRate = (reader[7] != DBNull.Value) ? (decimal)reader[7] : 0;
                    lwrMod.ActiveStatus = (reader[8] != DBNull.Value) ? (string)reader[8] : "";

                    // add Equipment to List
                    lwrMod_List.Add(lwrMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
            }

            // return List
            return lwrMod_List;
        }




        // Method: Get List RateYear strings
        public List<string> Get_RateIDString_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";


            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT DISTINCT RateID " +
                "FROM lwdom_Rates " +
                "ORDER BY RateID";

            // create List
            List<string> rID_List = new List<string>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    string _RId = "";

                    _RId = (reader[0] != DBNull.Value) ? Convert.ToString(reader[0]) : "";

                    // add Rate Year to list of strings
                    rID_List.Add(_RId);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_RateID_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List of strings
            return rID_List;
        }
    }
}
