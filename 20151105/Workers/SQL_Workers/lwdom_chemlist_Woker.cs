using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// models
using VcsConnect_Client.Models.SQL_Models;
// workers
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Workers.SQL_Workers
{
    public class lwdom_chemlist_Woker
    {
        // based on SQL table name: lwdom_chemlist
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lwdom_chemlist_Woker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lwdom_chemlist_Model> Get_ChemList_List()
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT OBJECTID, chemcode, epanum, activeingr, manufacturer, retail, cost, comment, units, activeStatus " +
                "FROM lwdom_chemlist " +
                "ORDER BY chemcode";

            // create List
            List<lwdom_chemlist_Model> lwdcMod_List = new List<lwdom_chemlist_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_chemlist_Model lwdcMod = new lwdom_chemlist_Model();

                    lwdcMod.OBJECTID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwdcMod.ChemCode = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    lwdcMod.EPANum = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    lwdcMod.ActiveIngr = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    lwdcMod.Manufacturer = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    //
                    lwdcMod.retail = (reader[5] != DBNull.Value) ? (decimal)reader[5] : 0;
                    lwdcMod.cost = (reader[6] != DBNull.Value) ? (decimal)reader[6] : 0;
                    //
                    lwdcMod.Comment = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    lwdcMod.Units = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    lwdcMod.activeStatus = (reader[9] != DBNull.Value) ? (string)reader[9] : "";

                    // add Equipment to List
                    lwdcMod_List.Add(lwdcMod);
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
            return lwdcMod_List;
        }


        // Method: get record data based on id
        public lwdom_chemlist_Model Get_SpecificChemList_Record(int recID)
        {
            string strMsg = "";
            
            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT OBJECTID, chemcode, epanum, activeingr, manufacturer, retail, cost, comment, units, activeStatus " +
                "FROM lwdom_chemlist " +
                "WHERE chemcode=@chemcode";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on Equip Model (eMod)
            lwdom_chemlist_Model lwdcMod = new lwdom_chemlist_Model();

            try
            {
                // open the connection           
                connection.Open();

                command.Parameters.AddWithValue("@OBJECTID", recID);

                // execute the reader
                SqlDataReader reader = command.ExecuteReader();

                // populate the invoice list
                if (reader.Read())
                {
                    lwdcMod.OBJECTID = (reader[0] != DBNull.Value) ? (Int32)reader[0] : 0;
                    lwdcMod.ChemCode = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    lwdcMod.EPANum = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    lwdcMod.ActiveIngr = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    lwdcMod.Manufacturer = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    //
                    lwdcMod.retail = (reader[5] != DBNull.Value) ? (decimal)reader[5] : 0;
                    lwdcMod.cost = (reader[6] != DBNull.Value) ? (decimal)reader[6] : 0;
                    //
                    lwdcMod.Comment = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    lwdcMod.Units = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    lwdcMod.activeStatus = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
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
            return lwdcMod;
        }


        // ADD
        public string Add_ChemList_Rec(lwdom_chemlist_Model lwdcMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lwdom_chemlist (chemcode, epanum, activeingr, manufacturer, retail, cost, comment, units, activeStatus) " +
                "VALUES (@chemcode, @epanum, @activeingr, @manufacturer, @retail, @cost, @comment, @units, @activeStatus)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@chemcode", lwdcMod.ChemCode);
                command.Parameters.AddWithValue("@epanum", lwdcMod.EPANum);
                command.Parameters.AddWithValue("@activeingr", lwdcMod.ActiveIngr);
                command.Parameters.AddWithValue("@manufacturer", lwdcMod.Manufacturer);
                command.Parameters.AddWithValue("@retail", lwdcMod.retail);
                command.Parameters.AddWithValue("@cost", lwdcMod.cost);
                command.Parameters.AddWithValue("@comment", lwdcMod.Comment);
                command.Parameters.AddWithValue("@units", lwdcMod.Units);
                command.Parameters.AddWithValue("@activeStatus", lwdcMod.activeStatus);
                //lwdcMod.activeStatus = true;
                //command.Parameters.AddWithValue("@activeStatus", lwdcMod.activeStatus);

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
        public string Update_ChemList_rec(lwdom_chemlist_Model lwdcMod)
        {
            // Method: update selected Hours Master recore 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lwdom_chemlist " +
                "SET chemcode=@chemcode, " + 
                "epanum=@epanum, " +
                "activeingr=@activeingr, " +
                "manufacturer=@manufacturer, " +
                "retail=@retail, " +
                "cost=@cost, " +
                "comment=@comment, " +
                "units=@units, " +
                "activeStatus=@activeStatus " +
                "WHERE OBJECTID=@OBJECTID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@chemcode", lwdcMod.ChemCode);
                command.Parameters.AddWithValue("@epanum", lwdcMod.EPANum);
                command.Parameters.AddWithValue("@activeingr", lwdcMod.ActiveIngr);
                command.Parameters.AddWithValue("@manufacturer", lwdcMod.Manufacturer);
                command.Parameters.AddWithValue("@retail", lwdcMod.retail);
                command.Parameters.AddWithValue("@cost", lwdcMod.cost);
                command.Parameters.AddWithValue("@comment", lwdcMod.Comment);
                command.Parameters.AddWithValue("@units", lwdcMod.Units);
                command.Parameters.AddWithValue("@activeStatus", lwdcMod.activeStatus);
                //
                command.Parameters.AddWithValue("@OBJECTID", lwdcMod.OBJECTID); // must be in the order of the sqlstatement

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

        public string Delete_ChemList_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lwdom_chemlist " +
                    "WHERE OBJECTID=@OBJECTID";

                // SqlCommand
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    // open the connection           
                    connection.Open();

                    // Adding parameters for WHERE = ID
                    command.Parameters.AddWithValue("@OBJECTID", recID);

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


        // removes all records from the Chemlist table
        // while leaving all table structures
        public string Truncate_ChemList_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lwdom_chemlist";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "ChemList table Initialized.";
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
        private lwdom_chemlist_Model Reset_ChemList_Mod(lwdom_chemlist_Model lwdcMod)
        {
            // reset the model
            lwdcMod.ChemCode = "";
            lwdcMod.EPANum = "";
            lwdcMod.ActiveIngr = "";
            lwdcMod.Manufacturer = "";
            lwdcMod.retail = 0;
            lwdcMod.cost = 0;
            lwdcMod.Comment = "";
            lwdcMod.Units = "";
            lwdcMod.activeStatus = "";

            // return the model
            return lwdcMod;
        }


        // Method: Get List
        public List<lwdom_chemlist_Model> Get_ChemList_byStatus_List(string _status)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT OBJECTID, chemcode, epanum, activeingr, manufacturer, retail, cost, comment, units, activeStatus " +
                "FROM lwdom_chemlist " +
                "WHERE activeStatus=@activeStatus " +
                "ORDER BY chemcode";

            // create List
            List<lwdom_chemlist_Model> lwdcMod_List = new List<lwdom_chemlist_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert command
                command.Parameters.AddWithValue("@activeStatus", _status);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_chemlist_Model lwdcMod = new lwdom_chemlist_Model();

                    lwdcMod.OBJECTID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwdcMod.ChemCode = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    lwdcMod.EPANum = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    lwdcMod.ActiveIngr = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    lwdcMod.Manufacturer = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    //
                    lwdcMod.retail = (reader[5] != DBNull.Value) ? (decimal)reader[5] : 0;
                    lwdcMod.cost = (reader[6] != DBNull.Value) ? (decimal)reader[6] : 0;
                    //
                    lwdcMod.Comment = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    lwdcMod.Units = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    lwdcMod.activeStatus = (reader[9] != DBNull.Value) ? (string)reader[9] : "";

                    // add Equipment to List
                    lwdcMod_List.Add(lwdcMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_ChemList_byStatus_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return lwdcMod_List;
        }




        // Method: Get List using SQL LIKE
        public List<lwdom_chemlist_Model> Get_ChemList_LIKEChemCode_List(string _chemCode)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command, chemcode is the Key
            string sqlStatement = "SELECT OBJECTID, chemcode, epanum, activeingr, manufacturer, retail, cost, comment, units, activeStatus " +
                "FROM lwdom_chemlist " +
                "WHERE chemcode LIKE @chemcode " +
                "ORDER BY chemcode";

            // create List
            List<lwdom_chemlist_Model> lwdcMod_List = new List<lwdom_chemlist_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert command
                command.Parameters.AddWithValue("@chemcode", _chemCode+'%');

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lwdom_chemlist_Model lwdcMod = new lwdom_chemlist_Model();

                    lwdcMod.OBJECTID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    lwdcMod.ChemCode = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    lwdcMod.EPANum = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    lwdcMod.ActiveIngr = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    lwdcMod.Manufacturer = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    //
                    lwdcMod.retail = (reader[5] != DBNull.Value) ? (decimal)reader[5] : 0;
                    lwdcMod.cost = (reader[6] != DBNull.Value) ? (decimal)reader[6] : 0;
                    //
                    lwdcMod.Comment = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    lwdcMod.Units = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    lwdcMod.activeStatus = (reader[9] != DBNull.Value) ? (string)reader[9] : "";

                    // add Equipment to List
                    lwdcMod_List.Add(lwdcMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_ChemList_usingLike_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return lwdcMod_List;
        }
    }
}