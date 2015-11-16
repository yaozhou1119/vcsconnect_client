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
    class lwdom_LocCat_Worker
    {
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // based on SQL table name: lwdom_LocCat
        // constructor
        public lwdom_LocCat_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lwdom_LocCat_Model> Get_LocCat_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, LocCatDesc " +
                "FROM lwdom_LocCat " +
                "ORDER BY LocCatDesc";

            // create List
            List<lwdom_LocCat_Model> lcMod_List = new List<lwdom_LocCat_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_LocCat_Model lcMod = new lwdom_LocCat_Model();

                    lcMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lcMod.LocCatDesc = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    
                    // add Equipment to List
                    lcMod_List.Add(lcMod);
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
            return lcMod_List;
        }


        // Method: get record data based on id
        public lwdom_LocCat_Model Get_SpecificLocCat_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, LocCatDesc " +
                "FROM lwdom_LocCat " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on LW LocCat Model (lcMod)
            lwdom_LocCat_Model lcMod = new lwdom_LocCat_Model();

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
                    lcMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lcMod.LocCatDesc = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
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
            return lcMod;
        }


        // ADD
        public string Add_LocCat_Rec(lwdom_LocCat_Model lcMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lwdom_LocCat (LocCatDesc) " +
                "VALUES (@LocCatDesc)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@LocCatDesc", lcMod.LocCatDesc);

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
        public string Update_LocCat_rec(lwdom_LocCat_Model lcMod)
        {
            // Method: update selected Hours Master recore 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lwdom_LocCat " +
                "SET LocCatDesc=@LocCatDesc " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@LocCatDesc", lcMod.LocCatDesc);
                //
                command.Parameters.AddWithValue("@ID", lcMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // DELETE
        public string Delete_LocCat_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lwdom_LocCat " +
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


        // removes all records from the Job Type table
        // while leaving all table structures
        public string Truncate_LocCatDesc_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lwdom_LocCat";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "SQL lwdom_LocCat table Initialized.";
            }
            catch (Exception err)
            {
                connection.Close();
                strMsg = err.Message.ToString();
            }

            // return status message
            return strMsg;
        }




        // ADO method: return list of string names
        // using List<string> 
        public List<string> Get_LocCatDesc_stringList()
        {
            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string hld = "";

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, LocCatDesc " +
                "FROM lwdom_LocCat " +
                "ORDER BY LocCatDesc";

            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlStatement, connection);
            SqlDataReader reader = command.ExecuteReader();

            // create a list of Rate names
            List<string> lc_List = new List<string>();

            // populate the list
            while (reader.Read())
            {
                // reader[1] is casting it to string
                hld = (reader[1] != DBNull.Value) ? (string)reader[1] : "";

                // add to the list
                lc_List.Add(hld);
            }

            // close reader and connection
            reader.Close();
            connection.Close();

            // return the list
            return lc_List;
        }
    }
}