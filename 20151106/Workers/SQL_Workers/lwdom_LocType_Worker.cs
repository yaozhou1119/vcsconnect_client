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
    class lwdom_LocType_Worker
    {
        // based on SQL Table: lwdom_LocType
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // based on SQL table name: lwdom_LocCat
        // constructor
        public lwdom_LocType_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lwdom_LocType_Model> Get_LocType_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, LocTypeDesc " +
                "FROM lwdom_LocType " +
                "ORDER BY LocTypeDesc";

            // create List
            List<lwdom_LocType_Model> ltMod_List = new List<lwdom_LocType_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_LocType_Model ltMod = new lwdom_LocType_Model();

                    ltMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    ltMod.LocTypeDesc = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    
                    // add Equipment to List
                    ltMod_List.Add(ltMod);
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
            return ltMod_List;
        }


        // Method: get record data based on id
        public lwdom_LocType_Model Get_SpecificLocType_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, LocTypeDesc " +
                "FROM lwdom_LocType " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on LW LocType Model (ltMod)
            lwdom_LocType_Model ltMod = new lwdom_LocType_Model();

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
                    ltMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    ltMod.LocTypeDesc = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
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
            return ltMod;
        }


        // ADD
        public string Add_LocType_Rec(lwdom_LocType_Model ltMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lwdom_LocType (LocTypeDesc) " +
                "VALUES (@LocTypeDesc)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@LocTypeDesc", ltMod.LocTypeDesc);

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
        public string Update_LocType_rec(lwdom_LocType_Model ltMod)
        {
            // Method: update selected Hours Master recore 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lwdom_LocType " +
                "SET LocTypeDesc=@LocTypeDesc " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@LocTypeDesc", ltMod.LocTypeDesc);
                //
                command.Parameters.AddWithValue("@ID", ltMod.ID); // must be in the order of the sqlstatement

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
        public string Delete_LocType_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lwdom_LocType " +
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
        public string Truncate_LocType_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lwdom_LocType";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "SQL lwdom_LocType table Initialized.";
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



        // Method: Get List
        public List<string> Get_LocType_StringList()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, LocTypeDesc " +
                "FROM lwdom_LocType " +
                "ORDER BY LocTypeDesc";

            // create List
            List<string> ltMod_StringList = new List<string>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    string strHld = "";

                    strHld = (reader[1] != DBNull.Value) ? (string)reader[1] : "";

                    // add Equipment to List
                    ltMod_StringList.Add(strHld);
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
            return ltMod_StringList;
        }
    }
}