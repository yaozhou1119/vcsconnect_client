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
    public class lw_ClientContact_Worker
    {
        // based on SQL table: lw_ClientContacts
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_ClientContact_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_ClientContacts_Model> Get_ClientContacts_List(ref string strMsg, string strStatus)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, AccNum, LocationID, ContactTitle, ContactFN, ContactLN, " +
                "OffPhone, OffPhoneExt, CellPhone, FaxNum, OthPhone, Email, Comments, LocID, ActiveStatus " +
                "FROM lw_ClientContacts " +
                "WHERE ActiveStatus=@ActiveStatus " +
                "ORDER BY LocationID, ContactLN";

            // create List
            List<lw_ClientContacts_Model> ccMod_List = new List<lw_ClientContacts_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command
                command.Parameters.AddWithValue("@ActiveStatus", strStatus);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_ClientContacts_Model ccMod = new lw_ClientContacts_Model();

                    ccMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    ccMod.AccNum = (reader[1] != DBNull.Value) ? Convert.ToInt64(reader[1]) : 0;
                    ccMod.LocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ccMod.ContactTitle = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ccMod.ContactFN = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ccMod.ContactLN = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    ccMod.OffPhone = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    ccMod.OffPhoneExt = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    ccMod.CellPhone = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    ccMod.FaxNum = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    ccMod.OthPhone = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    ccMod.Email = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    ccMod.Comments = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    ccMod.LocID = (reader[13] != DBNull.Value) ? Convert.ToInt64(reader[13]) : 0;
                    ccMod.ActiveStatus = (reader[14] != DBNull.Value) ? (string)reader[14] : "";

                    // add Equipment to List
                    ccMod_List.Add(ccMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get Contact List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return ccMod_List;
        }



        // Method: Get List by ContactID
        public List<lw_ClientContacts_Model> Get_ClientContactsByAccNum_List(Int64 numID)
        {
            // building the connection string
            // get the provider, database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, AccNum, LocationID, ContactTitle, ContactFN, ContactLN, " +
               "OffPhone, OffPhoneExt, CellPhone, FaxNum, OthPhone, Email, Comments, LocID, ActiveStatus " +
               "FROM lw_ClientContacts " +
                "WHERE AccNum=@AccNum " +
                "ORDER BY LocationID, ContactLN";

            // create List
            List<lw_ClientContacts_Model> ccMod_List = new List<lw_ClientContacts_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@AccNum", numID);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_ClientContacts_Model ccMod = new lw_ClientContacts_Model();

                    ccMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    ccMod.AccNum = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    ccMod.LocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ccMod.ContactTitle = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ccMod.ContactFN = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ccMod.ContactLN = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    ccMod.OffPhone = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    ccMod.OffPhoneExt = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    ccMod.CellPhone = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    ccMod.FaxNum = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    ccMod.OthPhone = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    ccMod.Email = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    ccMod.Comments = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    ccMod.LocID = (reader[13] != DBNull.Value) ? (Int64)reader[13] : 0;
                    ccMod.ActiveStatus = (reader[14] != DBNull.Value) ? (string)reader[14] : "";

                    // add Equipment to List
                    ccMod_List.Add(ccMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Get Contact by AccNum List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return ccMod_List;
        }



        // Method: get record data based on id
        public lw_ClientContacts_Model Get_SpecificClientContact_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, AccNum, LocationID, ContactTitle, ContactFN, ContactLN, " +
                "OffPhone, OffPhoneExt, CellPhone, FaxNum, OthPhone, Email, Comments, LocID, ActiveStatus " +
                "FROM lw_ClientContacts " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on Equip Model (eMod)
            lw_ClientContacts_Model ccMod = new lw_ClientContacts_Model();

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
                    ccMod.ID = (reader[0] != DBNull.Value) ? (int)reader[0] : 0;
                    ccMod.AccNum = (reader[1] != DBNull.Value) ? (int)reader[1] : 0;
                    ccMod.LocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ccMod.ContactTitle = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ccMod.ContactFN = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ccMod.ContactLN = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    ccMod.OffPhone = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    ccMod.OffPhoneExt = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    ccMod.CellPhone = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    ccMod.FaxNum = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    ccMod.OthPhone = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    ccMod.Email = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    ccMod.Comments = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    ccMod.LocID = (reader[13] != DBNull.Value) ? (int)reader[13] : 0;
                    ccMod.ActiveStatus = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
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
            return ccMod;
        }


        // ADD
        public string Add_ClientContact_Rec(lw_ClientContacts_Model ccMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lw_ClientContacts (AccNum, LocationID, ContactTitle, ContactFN, ContactLN, " +
                "OffPhone, OffPhoneExt, CellPhone, FaxNum, OthPhone, Email, Comments, LocID, ActiveStatus) " +
                "VALUES (@AccNum, @LocationID, @ContactTitle, @ContactFN, @ContactLN, " +
                "@OffPhone, @OffPhoneExt, @CellPhone, @FaxNum, @OthPhone, @Email, @Comments, @LocID, @ActiveStatus)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@AccNum", ccMod.AccNum);
                command.Parameters.AddWithValue("@LocationID", ccMod.LocationID);
                command.Parameters.AddWithValue("@ContactTitle", ccMod.ContactTitle);
                command.Parameters.AddWithValue("@ContactFN", ccMod.ContactFN);
                command.Parameters.AddWithValue("@ContactLN", ccMod.ContactLN);
                command.Parameters.AddWithValue("@OffPhone", ccMod.OffPhone);
                command.Parameters.AddWithValue("@OffPhoneExt", ccMod.OffPhoneExt);
                command.Parameters.AddWithValue("@CellPhone", ccMod.CellPhone);
                command.Parameters.AddWithValue("@FaxNum", ccMod.FaxNum);
                command.Parameters.AddWithValue("@OthPhone", ccMod.OthPhone);
                command.Parameters.AddWithValue("@Email", ccMod.Email);
                command.Parameters.AddWithValue("@Comments", ccMod.Comments);
                command.Parameters.AddWithValue("@LocID", ccMod.LocID);
                command.Parameters.AddWithValue("@ActiveStatus", ccMod.ActiveStatus);

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
        public string Update_ClientContact_rec(lw_ClientContacts_Model ccMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_ClientContacts " +
                "SET AccNum=@AccNum, " +
                "LocationID=@LocationID, " +
                "ContactTitle=@ContactTitle, " +
                "ContactFN=@ContactFN, " +
                "ContactLN=@ContactLN, " +
                "OffPhone=@OffPhone, " +
                "OffPhoneExt=@OffPhoneExt, " +
                "CellPhone=@CellPhone, " +
                "FaxNum=@FaxNum, " +
                "OthPhone=@OthPhone, " +
                "Email=@Email, " +
                "Comments=@Comments, " +
                "LocID=@LocID, " +
                "ActiveStatus=@ActiveStatus " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@AccNum", ccMod.AccNum);
                command.Parameters.AddWithValue("@LocationID", ccMod.LocationID);
                command.Parameters.AddWithValue("@ContactTitle", ccMod.ContactTitle);
                command.Parameters.AddWithValue("@ContactFN", ccMod.ContactFN);
                command.Parameters.AddWithValue("@ContactLN", ccMod.ContactLN);
                command.Parameters.AddWithValue("@OffPhone", ccMod.OffPhone);
                command.Parameters.AddWithValue("@OffPhoneExt", ccMod.OffPhoneExt);
                command.Parameters.AddWithValue("@CellPhone", ccMod.CellPhone);
                command.Parameters.AddWithValue("@FaxNum", ccMod.FaxNum);
                command.Parameters.AddWithValue("@OthPhone", ccMod.OthPhone);
                command.Parameters.AddWithValue("@Email", ccMod.Email);
                command.Parameters.AddWithValue("@Comments", ccMod.Comments);
                command.Parameters.AddWithValue("@LocID", ccMod.LocID);
                command.Parameters.AddWithValue("@ActiveStatus", ccMod.ActiveStatus);
                //
                command.Parameters.AddWithValue("@ID", ccMod.ID); // must be in the order of the sqlstatement

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
        public string Delete_ClientContacts_rec(Int32 recID)
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
                string sqlStatement = "DELETE FROM lw_ClientContacts " +
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


        // removes all records from the ClientContact table
        // while leaving all table structures
        public string Truncate_ClientContact_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_ClientContacts";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Client Contact table Initialized.";
            }
            catch (Exception err)
            {
                connection.Close();
                strMsg = err.Message.ToString();
            }

            // return status message
            return strMsg;
        }



        // Reset ClientContact Model
        private lw_ClientContacts_Model Reset_ClientContact_Mod(lw_ClientContacts_Model ccMod)
        {
            // reset the model
            ccMod.ID = 0;
            ccMod.AccNum = 0;
            ccMod.LocationID = "";
            ccMod.ContactTitle = "";
            ccMod.ContactFN = "";
            ccMod.ContactLN = "";
            ccMod.OffPhone = "";
            ccMod.OffPhoneExt = "";
            ccMod.CellPhone = "";
            ccMod.FaxNum = "";
            ccMod.OthPhone = "";
            ccMod.Email = "";
            ccMod.Comments = "";
            ccMod.LocID = 0;
            ccMod.ActiveStatus = "";

            // return the model
            return ccMod;
        }



        // Method: Get Client Contact List by LocationID
        public List<lw_ClientContacts_Model> Get_ClientContacts_ByLocationId_List(string _strLocID)
        {
            // building the connection string
            // get the provider, database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, AccNum, LocationID, ContactTitle, ContactFN, ContactLN, " +
               "OffPhone, OffPhoneExt, CellPhone, FaxNum, OthPhone, Email, Comments, LocID, ActiveStatus " +
               "FROM lw_ClientContacts " +
                "WHERE LocationID=@LocationID " +
                "ORDER BY LocationID, ContactLN";

            // create List
            List<lw_ClientContacts_Model> ccMod_List = new List<lw_ClientContacts_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@LocationID", _strLocID);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_ClientContacts_Model ccMod = new lw_ClientContacts_Model();

                    ccMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    ccMod.AccNum = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    ccMod.LocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ccMod.ContactTitle = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ccMod.ContactFN = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ccMod.ContactLN = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    ccMod.OffPhone = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    ccMod.OffPhoneExt = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    ccMod.CellPhone = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    ccMod.FaxNum = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    ccMod.OthPhone = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    ccMod.Email = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    ccMod.Comments = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    ccMod.LocID = (reader[13] != DBNull.Value) ? (Int64)reader[13] : 0;
                    ccMod.ActiveStatus = (reader[14] != DBNull.Value) ? (string)reader[14] : "";

                    // add Equipment to List
                    ccMod_List.Add(ccMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Get Client Contact by LocationID List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return ccMod_List;
        }




        // Method: Get List
        public List<lw_ClientContacts_Model> Get_ClientContacts_byLIKELastName_List(string strStatus, string strLN)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, ContactID is the Key
            string sqlStatement = "SELECT ID, AccNum, LocationID, ContactTitle, ContactFN, ContactLN, " +
                "OffPhone, OffPhoneExt, CellPhone, FaxNum, OthPhone, Email, Comments, LocID, ActiveStatus " +
                "FROM lw_ClientContacts " +
                // "WHERE ActiveStatus=@ActiveStatus AND ContactLN LIKE @ContactLN  " +
                "WHERE ContactLN LIKE @ContactLN  " +
                "ORDER BY ContactLN, ContactFN";

            // create List
            List<lw_ClientContacts_Model> ccMod_List = new List<lw_ClientContacts_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command
                // command.Parameters.AddWithValue("@ActiveStatus", strStatus);
                command.Parameters.AddWithValue("@ContactLN", strLN + '%');

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_ClientContacts_Model ccMod = new lw_ClientContacts_Model();

                    ccMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    ccMod.AccNum = (reader[1] != DBNull.Value) ? Convert.ToInt64(reader[1]) : 0;
                    ccMod.LocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ccMod.ContactTitle = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ccMod.ContactFN = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ccMod.ContactLN = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    ccMod.OffPhone = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    ccMod.OffPhoneExt = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    ccMod.CellPhone = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    ccMod.FaxNum = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    ccMod.OthPhone = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    ccMod.Email = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    ccMod.Comments = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    ccMod.LocID = (reader[13] != DBNull.Value) ? Convert.ToInt64(reader[13]) : 0;
                    ccMod.ActiveStatus = (reader[14] != DBNull.Value) ? (string)reader[14] : "";

                    // add Equipment to List
                    ccMod_List.Add(ccMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_ClientContacts_byLIKELastName_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return ccMod_List;
        }
    }
}