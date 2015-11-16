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
    public class lwdom_RatesID_Worker
    {
        // based on SQL table name: lwdom_RatesID
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // based on SQL table name: lwdom_chemlist
        // constructor
        public lwdom_RatesID_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lwdom_RatesID_Model> Get_RatesID_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, RateName " +
                "FROM lwdom_RatesID " +
                "ORDER BY RateName";

            // create List
            List<lwdom_RatesID_Model> lwridMod_List = new List<lwdom_RatesID_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_RatesID_Model lwridMod = new lwdom_RatesID_Model();
                    lwridMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwridMod.RateName = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    
                    // add Equipment to List
                    lwridMod_List.Add(lwridMod);
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
            return lwridMod_List;
        }


        // Method: get record data based on id
        public lwdom_RatesID_Model Get_SpecificRatesID_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, RateName " +
                "FROM lwdom_RatesID " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on LW Rates Model (lwrMod)
            lwdom_RatesID_Model lwridMod = new lwdom_RatesID_Model();

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
                    lwridMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwridMod.RateName = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
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
            return lwridMod;
        }


        // ADD
        public string Add_RatesID_Rec(lwdom_RatesID_Model lwridMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lwdom_RatesID (RateName) " +
                "VALUES (@RateName)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@RateName", lwridMod.RateName);

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
        public string Update_RatesID_rec(lwdom_RatesID_Model lwridMod)
        {
            // Method: update selected Hours Master recore 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lwdom_RatesID " +
                "SET RateName=@RateName " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@RateName", lwridMod.RateName);
                //
                command.Parameters.AddWithValue("@ID", lwridMod.ID); // must be in the order of the sqlstatement

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

        public string Delete_RatesID_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lwdom_RatesID " +
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
                strMsg = "Delete did not occur, data missing.";
            }

            // return status message
            return strMsg;
        }


        // removes all records from the lwdom_Rates table
        // while leaving all table structures
        public string Truncate_RatesID_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lwdom_RatesID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "SQL lwdom_RatesID table Initialized.";
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
        private lwdom_RatesID_Model Reset_RatesID_Model(lwdom_RatesID_Model lwridMod)
        {
            // reset the model
            lwridMod.ID = 0;
            lwridMod.RateName = "";

            // return the model
            return lwridMod;
        }


        // ADO method: return list of string names
        // using List<string> 
        public List<string> Get_RateName_stringList()
        {
            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string hld = "";

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, RateName " +
               "FROM lwdom_RatesID " +
               "ORDER BY RateName";

            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlStatement, connection);
            SqlDataReader reader = command.ExecuteReader();

            // create a list of Rate names
            List<string> rn_List = new List<string>();

            // populate the list
            while (reader.Read())
            {
                // reader[1] is casting it to string
                hld = (reader[1] != DBNull.Value) ? (string)reader[1] : "";

                // add to the list
                rn_List.Add(hld);
            }

            // close reader and connection
            reader.Close();
            connection.Close();

            // return the list
            return rn_List;
        }
    }
}
