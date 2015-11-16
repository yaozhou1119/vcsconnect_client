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
    public class lwdom_JobType_Worker
    {
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // based on SQL table name: lwdom_JobType
        // constructor
        public lwdom_JobType_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lwdom_JobType_Model> Get_JobType_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT ID, JobType " +
                "FROM lwdom_JobType " +
                "ORDER BY JobType";

            // create List
            List<lwdom_JobType_Model> jtMod_List = new List<lwdom_JobType_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_JobType_Model jtMod = new lwdom_JobType_Model();

                    jtMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    jtMod.JobType = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    
                    // add Equipment to List
                    jtMod_List.Add(jtMod);
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
            return jtMod_List;
        }


        // Method: get record data based on id
        public lwdom_JobType_Model Get_SpecificJobType_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, JobType " +
                "FROM lwdom_JobType " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on LW Jobtype Model (jtMod)
            lwdom_JobType_Model jtMod = new lwdom_JobType_Model();

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
                    jtMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    jtMod.JobType = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
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
            return jtMod;
        }


        // ADD
        public string Add_JobType_Rec(lwdom_JobType_Model jtMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lwdom_JobType (JobType) " +
                "VALUES (@JobType)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@JobType", jtMod.JobType);

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
        public string Update_JobType_rec(lwdom_JobType_Model jtMod)
        {
            // Method: update selected Hours Master recore 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lwdom_JobType " +
                "SET JobType=@JobType " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@JobType", jtMod.JobType);
                //
                command.Parameters.AddWithValue("@ID", jtMod.ID); // must be in the order of the sqlstatement

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
        public string Delete_JobType_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lwdom_JobType " +
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
        public string Truncate_JobType_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lwdom_JobType";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "SQL lwdom_JobType table Initialized.";
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
        public List<string> Get_JobType_stringList()
        {
            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string hld = "";

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, JobType " +
                "FROM lwdom_JobType " +
                "ORDER BY JobType";

            connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand(sqlStatement, connection);
            SqlDataReader reader = command.ExecuteReader();

            // create a list of Rate names
            List<string> jt_List = new List<string>();

            // populate the list
            while (reader.Read())
            {
                // reader[1] is casting it to string
                hld = (reader[1] != DBNull.Value) ? (string)reader[1] : "";

                // add to the list
                jt_List.Add(hld);
            }

            // close reader and connection
            reader.Close();
            connection.Close();

            // return the list
            return jt_List;
        }
    }
}