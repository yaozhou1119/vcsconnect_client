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
    public class lw_Client_Worker
    {
        // based on SQL table: lw_Client
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_Client_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_Client_Model> Get_Client_List(ref string strMsg, string _status)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            
            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, AccNum, Name, ActiveStatus, Note, Comments " +
                "FROM lw_Client " +
                "WHERE ActiveStatus=@ActiveStatus " +
                "ORDER BY AccNum";

            // create List
            List<lw_Client_Model> cMod_List = new List<lw_Client_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command parameter
                command.Parameters.AddWithValue("@ActiveStatus", _status); 

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Client_Model cMod = new lw_Client_Model();

                    cMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    cMod.AccNum = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    cMod.Name = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    cMod.ActiveStatus = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    cMod.Note = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    cMod.Comments = (reader[5] != DBNull.Value) ? (string)reader[5] : "";

                    // add Equipment to List
                    cMod_List.Add(cMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return cMod_List;
        }


        // Method: get record data based on id
        public lw_Client_Model Get_SpecificClient_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, AccNum, Name, ActiveStatus, Note, Comments " +
                "FROM lw_Client " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on Equip Model (eMod)
            lw_Client_Model cMod = new lw_Client_Model();

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
                    cMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    cMod.AccNum = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    cMod.Name = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    cMod.ActiveStatus = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    cMod.Note = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    cMod.Comments = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
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
            return cMod;
        }



        // Select last Identity ID used
        public string Get_LastIDKey_Used()
        {
            string strMsg = "";
            string strID = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT IDENT_CURRENT('lw_Client')";
            
            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);
            
            try
            {
                // open the connection           
                connection.Open();
                
                // execute the reader
                SqlDataReader reader = command.ExecuteReader();

                // populate the invoice list
                if (reader.Read())
                {
                    strID = (reader[0] != DBNull.Value) ? Convert.ToString(reader[0]) : "";
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
            return strID;
        }



        // ADD
        public string Add_Client_Rec(lw_Client_Model cMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lw_Client (AccNum, Name, ActiveStatus, Note, Comments) " +
                "VALUES (@AccNum, @Name, @ActiveStatus, @Note, @Comments)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@AccNum", cMod.AccNum);
                command.Parameters.AddWithValue("@Name", cMod.Name);
                command.Parameters.AddWithValue("@ActiveStatus", cMod.ActiveStatus);
                command.Parameters.AddWithValue("@Note", cMod.Note);
                command.Parameters.AddWithValue("@Comments", cMod.Comments);

                command.ExecuteNonQuery();
                strMsg = "Record was added.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Add_Client_Rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_Client_rec(lw_Client_Model cMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_Client " +
                "SET AccNum=@AccNum, " +
                "Name=@Name, " +
                "ActiveStatus=@ActiveStatus, " +
                "Note=@Note, " +
                "Comments=@Comments " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@AccNum", cMod.AccNum);
                command.Parameters.AddWithValue("@Name", cMod.Name);
                command.Parameters.AddWithValue("@ActiveStatus", cMod.ActiveStatus);
                command.Parameters.AddWithValue("@Note", cMod.Note);
                command.Parameters.AddWithValue("@Comments", cMod.Comments);
                //
                command.Parameters.AddWithValue("@ID", cMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Update_Client_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }





        // Method: update Client AccNum
        // To be used in conjunction with ADD Client
        public string Update_Client_AccNum_rec(Int64 intAccNum)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_Client " +
                "SET AccNum=@AccNum " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@AccNum", intAccNum);
                //
                command.Parameters.AddWithValue("@ID", intAccNum); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "AccNum was updated.";
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
            }

            connection.Close();
            return strMsg;
        }



        // Delete record
        public string Delete_Client_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lw_Client " +
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


        // removes all records from the Client table
        // while leaving all table structures
        public string Truncate_Client_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_Client";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Client table Initialized.";
            }
            catch (Exception err)
            {
                connection.Close();
                strMsg = err.Message.ToString();
            }

            // return status message
            return strMsg;
        }



        // Reset Equipment Model
        private lw_Client_Model Reset_Client_Mod(lw_Client_Model cMod)
        {
            // reset the model
            cMod.ID = 0;
            cMod.AccNum = 0;
            cMod.Name = "";
            cMod.ActiveStatus = "";
            cMod.Note = "";

            // return the model
            return cMod;
        }




        // Method: Get List WHERE is based on Status and LIKE and Name
        public List<lw_Client_Model> Get_Client_LIKEName_List(string _status, string _clName)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, AccNum, Name, ActiveStatus, Note, Comments " +
                "FROM lw_Client " +
                "WHERE ActiveStatus=@ActiveStatus AND Name LIKE @Name " + 
                "ORDER BY AccNum";

            // create List
            List<lw_Client_Model> cMod_List = new List<lw_Client_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command parameter
                command.Parameters.AddWithValue("@ActiveStatus", _status);
                command.Parameters.AddWithValue("@Name", _clName + '%');

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Client_Model cMod = new lw_Client_Model();

                    cMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    cMod.AccNum = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    cMod.Name = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    cMod.ActiveStatus = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    cMod.Note = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    cMod.Comments = (reader[5] != DBNull.Value) ? (string)reader[5] : "";

                    // add Equipment to List
                    cMod_List.Add(cMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "SQL Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return cMod_List;
        }
    }
}
