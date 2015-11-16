using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// model
using VcsConnect_Client.Models.ApplicationValues;
// worker
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Workers.ApplicationValue_Workers
{
    public class Application_Values_Worker
    {
        // based on SQL table: lw_Client
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public Application_Values_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: get record data based on id
        // ID will always be = 1
        public ApplicationValue_Model Get_SpecificAppValue_Record(ref string strMsg)
        {
            strMsg = "";
            Int64 recID = 1; // Force Sql to always return record ID = 1.

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, NextWorkOrderID, NextBidID " +
                "FROM Application_Values " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on Equip Model (eMod)
            ApplicationValue_Model avMod = new ApplicationValue_Model();

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
                    avMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    avMod.NextWorkOrderID = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    avMod.NextBidID = (reader[2] != DBNull.Value) ? (Int64)reader[2] : 0;
                }

                // the close
                reader.Close();
                strMsg = "ID = " + avMod.ID.ToString();
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_SpecificAppValue_Record", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // the close
            connection.Close();

            // return the Model
            return avMod;
        }



        // ADD
        public string ADD_ApplicationValues_Record(ApplicationValue_Model avMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO Application_Values (NextWorkOrderID, NextBidID) " +
                "VALUES (@NextWorkOrderID, @NextBidID)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@NextWorkOrderID", avMod.NextWorkOrderID);
                command.Parameters.AddWithValue("@NextBidID", avMod.NextBidID);

                command.ExecuteNonQuery();
                strMsg = "Record was added.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: ADD_ApplicationValues_Record", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_ApplicationValues_rec(ApplicationValue_Model avMod)
        {
            // Method: update selected Application Values record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE Application_Values " +
                "SET NextWorkOrderID=@NextWorkOrderID, " +
                "NextBidID=@NextBidID " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@NextWorkOrderID", avMod.NextWorkOrderID);
                command.Parameters.AddWithValue("@NextBidID", avMod.NextBidID);
                //
                command.Parameters.AddWithValue("@ID", avMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Update_ApplicationValues_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }



        // Delete record
        public string Delete_ApplicationValues_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM Application_Values " +
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
    }
}