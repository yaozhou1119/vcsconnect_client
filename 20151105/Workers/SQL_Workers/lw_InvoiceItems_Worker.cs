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
using VcsConnect_Client.Workers.SQL_Workers;

namespace VcsConnect_Client.Workers.SQL_Workers
{
    public class lw_InvoiceItems_Worker
    {
        // based on SQL table: lw_Client
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_InvoiceItems_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_InvoiceItems_Model> Get_InvoiceItem_List(ref string strMsg)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, InvItemId, InvoiceID, Description, Cost, " +
                "InvID, istax " +
                "FROM lw_InvoiceItems " +
                "ORDER BY InvoiceID";

            // create List
            List<lw_InvoiceItems_Model> iiMod_List = new List<lw_InvoiceItems_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_InvoiceItems_Model iiMod = new lw_InvoiceItems_Model();

                    iiMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    iiMod.InvItemId = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    iiMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    iiMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    iiMod.Cost = (reader[4] != DBNull.Value) ? Convert.ToDecimal(reader[4]) : 0;
                    iiMod.InvID = (reader[5] != DBNull.Value) ? Convert.ToInt64(reader[5]) : 0;
                    iiMod.istax = (reader[6] != DBNull.Value) ? (string)reader[6] : "";

                    // add to list
                    iiMod_List.Add(iiMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_InvoiceItem_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return iiMod_List;
        }




        // Method: Get List
        public List<lw_InvoiceItems_Model> Get_InvoiceItem_byInvoiceID_List(string strInvID)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, InvItemId, InvoiceID, Description, Cost, " +
                "InvID, istax " +
                "FROM lw_InvoiceItems " +
                "WHERE InvoiceID=@InvoiceID " +
                "ORDER BY Description";

            // create List
            List<lw_InvoiceItems_Model> iiMod_List = new List<lw_InvoiceItems_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command
                command.Parameters.AddWithValue("@InvoiceID", strInvID);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_InvoiceItems_Model iiMod = new lw_InvoiceItems_Model();

                    iiMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    iiMod.InvItemId = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    iiMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    iiMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    iiMod.Cost = (reader[4] != DBNull.Value) ? Convert.ToDecimal(reader[4]) : 0;
                    iiMod.InvID = (reader[5] != DBNull.Value) ? Convert.ToInt64(reader[5]) : 0;
                    iiMod.istax = (reader[6] != DBNull.Value) ? (string)reader[6] : "";

                    // add to list
                    iiMod_List.Add(iiMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_InvoiceItem_byInvoiceID_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return iiMod_List;
        }


        // Method: get record data based on id
        public lw_InvoiceItems_Model Get_Specific_InvoiceItem_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, InvItemId, InvoiceID, Description, Cost, " +
                "InvID, istax " +
                "FROM lw_InvoiceItems " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on Equip Model (eMod)
            lw_InvoiceItems_Model iiMod = new lw_InvoiceItems_Model();

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
                    iiMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    iiMod.InvItemId = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    iiMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    iiMod.Description = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    iiMod.Cost = (reader[4] != DBNull.Value) ? Convert.ToDecimal(reader[4]) : 0;
                    iiMod.InvID = (reader[5] != DBNull.Value) ? Convert.ToInt64(reader[5]) : 0;
                    iiMod.istax = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                }

                // the close
                reader.Close();
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_Specific_InvoiceItem_Record", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // the close
            connection.Close();

            // return the Model
            return iiMod;
        }


        // ADD
        public string Add_InvoiceItem_Rec(lw_InvoiceItems_Model iiMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lw_InvoiceItems (InvItemId, InvoiceID, Description, " +
                "Cost, InvID, istax) " +
                "VALUES (@InvItemId, @InvoiceID, @Description, @Cost, @InvID, @istax)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@InvItemId", iiMod.InvItemId);
                command.Parameters.AddWithValue("@InvoiceID", iiMod.InvoiceID);
                command.Parameters.AddWithValue("@Description", iiMod.Description);
                command.Parameters.AddWithValue("@Cost", iiMod.Cost);
                command.Parameters.AddWithValue("@InvID", iiMod.InvID);
                command.Parameters.AddWithValue("@istax", iiMod.istax);

                command.ExecuteNonQuery();
                strMsg = "Record was added.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Add_InvoiceItem_Rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_InvoiceItem_rec(lw_InvoiceItems_Model iiMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_InvoiceItems " +
                "SET InvItemId=@InvItemId, " +
                "InvoiceID=@InvoiceID, " +
                "Description=@Description, " +
                "Cost=@Cost, " +
                "InvID=@InvID, " +
                "istax=@istax " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@InvItemId", iiMod.InvItemId);
                command.Parameters.AddWithValue("@InvoiceID", iiMod.InvoiceID);
                command.Parameters.AddWithValue("@Description", iiMod.Description);
                command.Parameters.AddWithValue("@Cost", iiMod.Cost);
                command.Parameters.AddWithValue("@InvID", iiMod.InvID);
                command.Parameters.AddWithValue("@istax", iiMod.istax);
                //
                command.Parameters.AddWithValue("@ID", iiMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Update_InvoiceItem_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // DELETE
        public string Delete_InvoiceItem_rec(Int32 recID)
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
                string sqlStatement = "DELETE FROM lw_InvoiceItems " +
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
                    System.Windows.MessageBox.Show(strMsg, "Method: Delete_InvoiceItem_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

                // the close
                connection.Close();
            }
            else
            {
                strMsg = "Delete did not occur, chemcode did not contain data.";
                System.Windows.MessageBox.Show(strMsg, "Method: Delete_InvoiceItem_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }




        // removes all records from the Invoice Item table
        // while leaving all table structures
        public string Truncate_InvoiceItem_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_InvoiceItems";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Invoice Item table Initialized.";
            }
            catch (Exception err)
            {
                connection.Close();
                strMsg = err.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Truncate_InvoiceItem_table", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }


        // Reset Invoice Item Model
        private lw_InvoiceItems_Model Reset_InvoiceItem_Mod()
        {
            lw_InvoiceItems_Model iiMod = new lw_InvoiceItems_Model();

            // reset the model
            iiMod.ID = 0;
            iiMod.InvItemId = 0;
            iiMod.InvoiceID = "";
            iiMod.Description = "";
            iiMod.Cost = 0;
            iiMod.InvID = 0;
            iiMod.istax = "";

            // return the model
            return iiMod;
        }
    }
}