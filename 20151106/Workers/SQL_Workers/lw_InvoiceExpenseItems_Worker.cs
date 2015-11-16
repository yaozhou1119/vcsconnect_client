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
    public class lw_InvoiceExpenseItems_Worker
    {
        // based on SQL table: lw_Client
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_InvoiceExpenseItems_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_InvoiceExpenseItems_Model> Get_InvExpensItems_List(ref string strMsg)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, WOID, InvoiceID, Category, ExpName, " +
                "Rate, Cost, TotHours " +
                "FROM lw_InvoiceExpenseItems " +
                "ORDER BY InvoiceID, Category";

            // create List
            List<lw_InvoiceExpenseItems_Model> ieiMod_List = new List<lw_InvoiceExpenseItems_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);
                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_InvoiceExpenseItems_Model ieiMod = new lw_InvoiceExpenseItems_Model();

                    ieiMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    ieiMod.WOID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    ieiMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ieiMod.Category = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ieiMod.ExpName = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ieiMod.Rate = (reader[5] != DBNull.Value) ? Convert.ToDecimal(reader[5]) : 0;
                    ieiMod.Cost = (reader[6] != DBNull.Value) ? Convert.ToDecimal(reader[6]) : 0;
                    ieiMod.TotHours = (reader[7] != DBNull.Value) ? Convert.ToInt16(reader[7]) : 0;

                    // add Equipment to List
                    ieiMod_List.Add(ieiMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_InvExpensItems_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return ieiMod_List;
        }


        // Method: get record data based on id
        public lw_InvoiceExpenseItems_Model Get_SpecificInvExpensItem_Record(int recID)
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, WOID, InvoiceID, Category, ExpName, " +
                "Rate, Cost, TotHours " +
                "FROM lw_InvoiceExpenseItems " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on model
            lw_InvoiceExpenseItems_Model ieiMod = new lw_InvoiceExpenseItems_Model();

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
                    ieiMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    ieiMod.WOID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    ieiMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ieiMod.Category = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ieiMod.ExpName = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ieiMod.Rate = (reader[5] != DBNull.Value) ? Convert.ToDecimal(reader[5]) : 0;
                    ieiMod.Cost = (reader[6] != DBNull.Value) ? Convert.ToDecimal(reader[6]) : 0;
                    ieiMod.TotHours = (reader[7] != DBNull.Value) ? Convert.ToInt16(reader[7]) : 0;
                }

                // the close
                reader.Close();
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_SpecificInvExpensItem_Record", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // the close
            connection.Close();

            // return the Model
            return ieiMod;
        }


        // ADD
        public string Add_InvExpensItems_Rec(lw_InvoiceExpenseItems_Model ieiMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lw_InvoiceExpenseItems (WOID, InvoiceID, " +
                "Category, ExpName, Rate, Cost, TotHours) " +
                "VALUES (@WOID, @InvoiceID, @Category, @ExpName, @Rate, @Cost, @TotHours)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@WOID", ieiMod.WOID);
                command.Parameters.AddWithValue("@InvoiceID", ieiMod.InvoiceID);
                command.Parameters.AddWithValue("@Category", ieiMod.Category);
                command.Parameters.AddWithValue("@ExpName", ieiMod.ExpName);
                command.Parameters.AddWithValue("@Rate", ieiMod.Rate);
                command.Parameters.AddWithValue("@Cost", ieiMod.Cost);
                command.Parameters.AddWithValue("@TotHours", ieiMod.TotHours);

                command.ExecuteNonQuery();
                strMsg = "Record was added.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Add_InvExpensItems_Rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_InvExpensItems_rec(lw_InvoiceExpenseItems_Model ieiMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_InvoiceExpenseItems " +
                "SET WOID=@WOID, " +
                "InvoiceID=@InvoiceID, " +
                "Category=@Category, " +
                "ExpName=@ExpName, " +
                "Rate=@Rate, " +
                "Cost=@Cost, " +
                "TotHours=@TotHours " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@WOID", ieiMod.WOID);
                command.Parameters.AddWithValue("@InvoiceID", ieiMod.InvoiceID);
                command.Parameters.AddWithValue("@Category", ieiMod.Category);
                command.Parameters.AddWithValue("@ExpName", ieiMod.ExpName);
                command.Parameters.AddWithValue("@Rate", ieiMod.Rate);
                command.Parameters.AddWithValue("@Cost", ieiMod.Cost);
                command.Parameters.AddWithValue("@TotHours", ieiMod.TotHours);
                //
                command.Parameters.AddWithValue("@ID", ieiMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Update_InvExpensItems_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }

        public string Delete_InvExpensItems_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lw_InvoiceExpenseItems " +
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
                catch (Exception errMsg)
                {
                    strMsg = errMsg.Message.ToString();
                    System.Windows.MessageBox.Show(strMsg, "Method: Delete_InvExpensItems_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

                // the close
                connection.Close();
            }
            else
            {
                strMsg = "Delete did not occur, chemcode did not contain data.";
                System.Windows.MessageBox.Show(strMsg, "Method: Delete_InvExpensItems_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }


        // removes all records from the Client table
        // while leaving all table structures
        public string Truncate_InvExpItems_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_InvoiceExpenseItems";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Invoice Item Expenses table Initialized.";
            }
            catch (Exception errMsg)
            {
                connection.Close();
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Truncate_InvExpItems_table", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }



        // Method: Get List
        public List<lw_InvoiceExpenseItems_Model> Get_InvExpensItems_byInvoiceID_List(string strInvID)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, WOID, InvoiceID, Category, ExpName, " +
                "Rate, Cost, TotHours " +
                "FROM lw_InvoiceExpenseItems " +
                "WHERE InvoiceID=@InvoiceID " +
                "ORDER BY Category";

            // create List
            List<lw_InvoiceExpenseItems_Model> ieiMod_List = new List<lw_InvoiceExpenseItems_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert command
                command.Parameters.AddWithValue("@InvoiceID", strInvID);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_InvoiceExpenseItems_Model ieiMod = new lw_InvoiceExpenseItems_Model();

                    ieiMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    ieiMod.WOID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    ieiMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ieiMod.Category = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ieiMod.ExpName = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ieiMod.Rate = (reader[5] != DBNull.Value) ? Convert.ToDecimal(reader[5]) : 0;
                    ieiMod.Cost = (reader[6] != DBNull.Value) ? Convert.ToDecimal(reader[6]) : 0;
                    ieiMod.TotHours = (reader[7] != DBNull.Value) ? Convert.ToInt16(reader[7]) : 0;

                    // add Equipment to List
                    ieiMod_List.Add(ieiMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_InvExpensItems_byInvoiceID_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return ieiMod_List;
        }




        // Method: Get List by Category
        public List<lw_InvoiceExpenseItems_Model> Get_InvExpensItems_byCategory_List(string strCAT)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, WOID, InvoiceID, Category, ExpName, " +
                "Rate, Cost, TotHours " +
                "FROM lw_InvoiceExpenseItems " +
                "WHERE Category=@Category " +
                "ORDER BY InvoiceID";

            // create List
            List<lw_InvoiceExpenseItems_Model> ieiMod_List = new List<lw_InvoiceExpenseItems_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert command
                command.Parameters.AddWithValue("@Category", strCAT);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_InvoiceExpenseItems_Model ieiMod = new lw_InvoiceExpenseItems_Model();

                    ieiMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    ieiMod.WOID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    ieiMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ieiMod.Category = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ieiMod.ExpName = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ieiMod.Rate = (reader[5] != DBNull.Value) ? Convert.ToDecimal(reader[5]) : 0;
                    ieiMod.Cost = (reader[6] != DBNull.Value) ? Convert.ToDecimal(reader[6]) : 0;
                    ieiMod.TotHours = (reader[7] != DBNull.Value) ? Convert.ToInt16(reader[7]) : 0;

                    // add Equipment to List
                    ieiMod_List.Add(ieiMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_InvExpensItems_byCategory_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return ieiMod_List;
        }



        // Method: Get List by SQL LIKE with InvoiceID
        public List<lw_InvoiceExpenseItems_Model> Get_InvExpensItems_LIKEInvoiceID_List(string strInvID)
        {
            // building the connection string
            // get the provider, activeStatus database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;
            string strMsg = "";

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, WOID, InvoiceID, Category, ExpName, " +
                "Rate, Cost, TotHours " +
                "FROM lw_InvoiceExpenseItems " +
                "WHERE InvoiceID LIKE @InvoiceID " +
                "ORDER BY InvoiceID";

            // create List
            List<lw_InvoiceExpenseItems_Model> ieiMod_List = new List<lw_InvoiceExpenseItems_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // insert command
                command.Parameters.AddWithValue("@InvoiceID", strInvID + '%');

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_InvoiceExpenseItems_Model ieiMod = new lw_InvoiceExpenseItems_Model();

                    ieiMod.ID = (reader[0] != DBNull.Value) ? Convert.ToInt64(reader[0]) : 0;
                    ieiMod.WOID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    ieiMod.InvoiceID = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    ieiMod.Category = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    ieiMod.ExpName = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    ieiMod.Rate = (reader[5] != DBNull.Value) ? Convert.ToDecimal(reader[5]) : 0;
                    ieiMod.Cost = (reader[6] != DBNull.Value) ? Convert.ToDecimal(reader[6]) : 0;
                    ieiMod.TotHours = (reader[7] != DBNull.Value) ? Convert.ToInt16(reader[7]) : 0;

                    // add Equipment to List
                    ieiMod_List.Add(ieiMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_InvExpensItems_LIKEInvoiceID_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return ieiMod_List;
        }
    }
}