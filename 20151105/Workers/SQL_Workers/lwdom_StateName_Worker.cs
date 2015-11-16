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
    public class lwdom_StateName_Worker
    {
        // based on SQL table name: lwdom_RatesID
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // based on SQL table name: lwdom_chemlist
        // constructor
        public lwdom_StateName_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lwdom_StateName_Model> Get_StateNames_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, StateName " +
                "FROM lwdom_StateName " +
                "ORDER BY StateName";

            // create List
            List<lwdom_StateName_Model> dsnMod_List = new List<lwdom_StateName_Model>();

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_StateName_Model dsnMod = new lwdom_StateName_Model();

                    dsnMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    dsnMod.StateName = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    
                    // add Equipment to List
                    dsnMod_List.Add(dsnMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                connection.Close();
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_StateNames_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return dsnMod_List;
        }


        // Method: get record data based on id
        public lwdom_StateName_Model Get_SpecificStateName_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, StateName " +
                "FROM lwdom_StateName " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on LW Rates Model (lwrMod)
            lwdom_StateName_Model dsnMod = new lwdom_StateName_Model();

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
                    dsnMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    dsnMod.StateName = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                }

                // the close
                reader.Close();
            }
            catch (Exception errMsg)
            {
                connection.Close();
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_SpecificStateName_Record", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // the close
            connection.Close();

            // return the Model
            return dsnMod;
        }


        // ADD
        public string Add_StateName_Rec(lwdom_StateName_Model dsnMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lwdom_StateName (StateName) " +
                "VALUES (@StateName)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@StateName", dsnMod.StateName);

                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Record was added.";
            }
            catch (Exception err)
            {
                strMsg = err.Message.ToString();
                connection.Close();
                System.Windows.MessageBox.Show(strMsg, "Method: Add_StateName_Rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            return strMsg;
        }


        // Method: update record
        public string Update_StateName_rec( lwdom_StateName_Model dsnMod)
        {
            // Method: update selected Hours Master recore 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lwdom_StateName " +
                "SET StateName=@StateName " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@StateName", dsnMod.StateName);
                //
                command.Parameters.AddWithValue("@ID", dsnMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Record was updated.";
            }
            catch (Exception err)
            {
                strMsg = err.Message.ToString();
                connection.Close();
                System.Windows.MessageBox.Show(strMsg, "Method: Update_StateName_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            return strMsg;
        }


        // DELETE
        public string Delete_StateName_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lwdom_StateName " +
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
                    connection.Close();
                    strMsg = "Record Deleted.";
                }
                catch (Exception err)
                {
                    strMsg = err.Message.ToString();
                    connection.Close();
                    System.Windows.MessageBox.Show(strMsg, "Delete_StateName_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

                // the close
                connection.Close();
            }
            else
            {
                strMsg = "Delete did not occur, data missing.";
                System.Windows.MessageBox.Show(strMsg, "Delete_StateName_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }


        // removes all records from the table
        // while leaving all table structures
        public string Truncate_StateName_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lwdom_StateName";

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
                System.Windows.MessageBox.Show(strMsg, "Method: Truncate_StateName_table", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }



        // Reset state name Model
        private lwdom_StateName_Model Reset_StateName_Model()
        {
            lwdom_StateName_Model dsnMod = new lwdom_StateName_Model();

            // reset the model
            dsnMod.ID = 0;
            dsnMod.StateName = "";

            // return the model
            return dsnMod;
        }


        // ADO method: return list of string names
        // using List<string> 
        public List<string> Get_StateName_stringList()
        {
            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string hld = "";

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, StateName " +
                "FROM lwdom_StateName " +
                "ORDER BY StateName";

            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlStatement, connection);
            SqlDataReader reader = command.ExecuteReader();

            // create a list of State Names
            List<string> dsn_List = new List<string>();

            // populate the list
            while (reader.Read())
            {
                // reader[1] is casting it to string
                hld = (reader[1] != DBNull.Value) ? (string)reader[1] : "";

                // add to the list
                dsn_List.Add(hld);
            }

            // close reader and connection
            reader.Close();
            connection.Close();

            // return the list
            return dsn_List;
        }
    }
}
