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
    public class lw_ClientLocations_Worker
    {
        // based on SQL table: lw_ClientLocations
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_ClientLocations_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_ClientLocations_Model> Get_ClientLocation_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";
            string strDT = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, AccNum, ClientLocationID, Name, Type, LocAdd1, LocAdd2, " +
                "LocTown, LocState, LocZip, UpdateDate, Comment, LocType, LocCat, ClientName " +
                "FROM lw_ClientLocations " +
                "ORDER BY Name";

            // create List
            List<lw_ClientLocations_Model> cMod_List = new List<lw_ClientLocations_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_ClientLocations_Model clMod = new lw_ClientLocations_Model();

                    clMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    clMod.AccNum = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    clMod.ClientLocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    clMod.Name = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    clMod.Type = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    clMod.LocAdd1 = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    clMod.LocAdd2 = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    clMod.LocTown = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    clMod.LocState = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    clMod.LocZip = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    //
                    strDT = (reader[10] != DBNull.Value) ? Convert.ToString(reader[10]) : "";
                    result = DateTime.TryParse(strDT, out DT);
                    clMod.UpdateDate = (result == true) ? DT : nullDate;
                    //
                    clMod.Comment = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    clMod.LocType = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    clMod.LocCat = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    clMod.ClientName = (reader[14] != DBNull.Value) ? (string)reader[14] : "";

                    // add Equipment to List
                    cMod_List.Add(clMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_ClientLocation_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return cMod_List;
        }



        public List<lw_ClientLocations_Model> Get_ClientLocation_ByAccNum_List(Int64 intNum)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";
            string strDT = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, AccNum, ClientLocationID, Name, Type, LocAdd1, LocAdd2, " +
                "LocTown, LocState, LocZip, UpdateDate, Comment, LocType, LocCat, ClientName " +
                "FROM lw_ClientLocations " +
                "WHERE AccNum=@AccNum " +
                "ORDER BY Name";

            // create List
            List<lw_ClientLocations_Model> cMod_List = new List<lw_ClientLocations_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@AccNum", intNum);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_ClientLocations_Model clMod = new lw_ClientLocations_Model();

                    clMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    clMod.AccNum = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    clMod.ClientLocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    clMod.Name = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    clMod.Type = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    clMod.LocAdd1 = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    clMod.LocAdd2 = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    clMod.LocTown = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    clMod.LocState = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    clMod.LocZip = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    //
                    strDT = (reader[10] != DBNull.Value) ? Convert.ToString(reader[10]) : "";
                    result = DateTime.TryParse(strDT, out DT);
                    clMod.UpdateDate = (result == true) ? DT : nullDate;
                    //
                    clMod.Comment = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    clMod.LocType = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    clMod.LocCat = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    clMod.ClientName = (reader[14] != DBNull.Value) ? (string)reader[14] : "";

                    // add Equipment to List
                    cMod_List.Add(clMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_ClientLocation_ByAccNum_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
            }

            // return List
            return cMod_List;
        }


        // Method: get record data based on id
        public lw_ClientLocations_Model Get_SpecificClientLocation_Record(int recID)
        {
            string strMsg = "";
            string strDT = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, AccNum, ClientLocationID, Name, Type, LocAdd1, LocAdd2, " +
                 "LocTown, LocState, LocZip, UpdateDate, Comment, LocType, LocCat, ClientName " +
                 "FROM lw_ClientLocations " +
                 "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on Equip Model (eMod)
            lw_ClientLocations_Model clMod = new lw_ClientLocations_Model();

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
                    clMod.ID = (reader[0] != DBNull.Value) ? (int)reader[0] : 0;
                    clMod.AccNum = (reader[1] != DBNull.Value) ? (int)reader[1] : 0;
                    clMod.ClientLocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    clMod.Name = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    clMod.Type = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    clMod.LocAdd1 = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    clMod.LocAdd2 = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    clMod.LocTown = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    clMod.LocState = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    clMod.LocZip = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    //
                    strDT = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    result = DateTime.TryParse(strDT, out DT);
                    clMod.UpdateDate = (result == true) ? DT : nullDate;
                    //
                    clMod.Comment = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    clMod.LocType = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    clMod.LocCat = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    clMod.ClientName = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
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
            return clMod;
        }


        // ADD
        public string Add_ClientLocation_Rec(lw_ClientLocations_Model clMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lw_ClientLocations (AccNum, ClientLocationID, Name, Type, " +
                    "LocAdd1, LocAdd2, LocTown, LocState, LocZip, UpdateDate, Comment, LocType, LocCat, " +
                    "ClientName) " +
                "VALUES (@AccNum, @ClientLocationID, @Name, @Type, @LocAdd1, @LocAdd2, @LocTown, @LocState, " +
                    "@LocZip, @UpdateDate, @Comment, @LocType, @LocCat, @ClientName)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@AccNum", clMod.AccNum);
                command.Parameters.AddWithValue("@ClientLocationID", clMod.ClientLocationID);
                command.Parameters.AddWithValue("@Name", clMod.Name);
                command.Parameters.AddWithValue("@Type", clMod.Type);
                command.Parameters.AddWithValue("@LocAdd1", clMod.LocAdd1);
                command.Parameters.AddWithValue("@LocAdd2", clMod.LocAdd2);
                command.Parameters.AddWithValue("@LocTown", clMod.LocTown);
                command.Parameters.AddWithValue("@LocState", clMod.LocState);
                command.Parameters.AddWithValue("@LocZip", clMod.LocZip);
                command.Parameters.AddWithValue("@UpdateDate", clMod.UpdateDate);
                command.Parameters.AddWithValue("@Comment", clMod.Comment);
                command.Parameters.AddWithValue("@LocType", clMod.LocType);
                command.Parameters.AddWithValue("@LocCat", clMod.LocCat);
                command.Parameters.AddWithValue("@ClientName", clMod.ClientName);

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
        public string Update_ClientLocation_rec(lw_ClientLocations_Model clMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_ClientLocations " +
                "SET AccNum=@AccNum, " +
                "ClientLocationID=@ClientLocationID, " +
                "Name=@Name, " +
                "Type=@Type, " +
                "LocAdd1=@LocAdd1, " +
                "LocAdd2=@LocAdd2, " +
                "LocTown=@LocTown, " +
                "LocState=@LocState, " +
                "LocZip=@LocZip, " +
                "UpdateDate=@UpdateDate, " +
                "Comment=@Comment, " +
                "LocType=@LocType, " +
                "LocCat=@LocCat, " +
                "ClientName=@ClientName " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@AccNum", clMod.AccNum);
                command.Parameters.AddWithValue("@ClientLocationID", clMod.ClientLocationID);
                command.Parameters.AddWithValue("@Name", clMod.Name);
                command.Parameters.AddWithValue("@Type", clMod.Type);
                command.Parameters.AddWithValue("@LocAdd1", clMod.LocAdd1);
                command.Parameters.AddWithValue("@LocAdd2", clMod.LocAdd2);
                command.Parameters.AddWithValue("@LocTown", clMod.LocTown);
                command.Parameters.AddWithValue("@LocState", clMod.LocState);
                command.Parameters.AddWithValue("@LocZip", clMod.LocZip);
                command.Parameters.AddWithValue("@UpdateDate", clMod.UpdateDate);
                command.Parameters.AddWithValue("@Comment", clMod.Comment);
                command.Parameters.AddWithValue("@LocType", clMod.LocType);
                command.Parameters.AddWithValue("@LocCat", clMod.LocCat);
                command.Parameters.AddWithValue("@ClientName", clMod.ClientName);
                //
                command.Parameters.AddWithValue("@ID", clMod.ID); // must be in the order of the sqlstatement

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

        public string Delete_ClientLocation_rec(Int32 recID)
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
                string sqlStatement = "DELETE FROM lw_ClientLocations " +
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


        // removes all records from the ClientLocation table
        // while leaving all table structures
        public string Truncate_ClientLocation_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_ClientLocations";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Client LOCATION table Initialized.";
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
        private lw_ClientLocations_Model Reset_Client_Mod(lw_ClientLocations_Model clMod)
        {
            DateTime? nullDate = null;

            // reset the model
            clMod.ID = 0;
            clMod.AccNum = 0;
            //
            clMod.ClientLocationID = "";
            clMod.Name = "";
            clMod.Type = "";
            clMod.LocAdd1 = "";
            clMod.LocAdd2 = "";
            clMod.LocTown = "";
            clMod.LocState = "";
            clMod.LocZip = "";
            //
            clMod.UpdateDate = nullDate;
            //
            clMod.Comment = "";
            clMod.LocType = "";
            clMod.LocCat = "";
            clMod.ClientName = "";

            // return the model
            return clMod;
        }


        // Get Client Location by LIKE on Name
        public List<lw_ClientLocations_Model> Get_ClientLocation_ByLIKEName_List(string strName)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";
            string strDT = "";
            bool result = false;
            DateTime DT;
            DateTime? nullDate = null;

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, AccNum, ClientLocationID, Name, Type, LocAdd1, LocAdd2, " +
                "LocTown, LocState, LocZip, UpdateDate, Comment, LocType, LocCat, ClientName " +
                "FROM lw_ClientLocations " +
                "WHERE Name LIKE @Name " + 
                "ORDER BY Name";

            // create List
            List<lw_ClientLocations_Model> clMod_List = new List<lw_ClientLocations_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert Command
                command.Parameters.AddWithValue("@Name", strName + '%');

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_ClientLocations_Model clMod = new lw_ClientLocations_Model();

                    clMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    clMod.AccNum = (reader[1] != DBNull.Value) ? (Int64)reader[1] : 0;
                    clMod.ClientLocationID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    clMod.Name = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    clMod.Type = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    clMod.LocAdd1 = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    clMod.LocAdd2 = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    clMod.LocTown = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    clMod.LocState = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    clMod.LocZip = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    //
                    strDT = (reader[10] != DBNull.Value) ? Convert.ToString(reader[10]) : "";
                    result = DateTime.TryParse(strDT, out DT);
                    clMod.UpdateDate = (result == true) ? DT : nullDate;
                    //
                    clMod.Comment = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    clMod.LocType = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    clMod.LocCat = (reader[13] != DBNull.Value) ? (string)reader[13] : "";
                    clMod.ClientName = (reader[14] != DBNull.Value) ? (string)reader[14] : "";

                    // add Client Location record to List
                    clMod_List.Add(clMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "done";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_ClientLocation_ByLIKEName_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Exclamation);
            }

            // return List
            return clMod_List;
        }
    }
}
