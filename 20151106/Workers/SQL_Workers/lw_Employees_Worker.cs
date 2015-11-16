using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// models
using VcsConnect_Client.Models.SQL_Models;
// worker
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Workers.SQL_Workers
{
    public class lw_Employees_Worker
    {
        // based on SQL table: lw_Employees
        // workers
        PropertiesSettingsWorker PSWkr;

        string connectionString;

        // constructor
        public lw_Employees_Worker()
        {
            PSWkr = new PropertiesSettingsWorker();
            connectionString = "";
        }


        // Method: Get List
        public List<lw_Employees_Model> Get_Employees_List(ref string strMsg, string activeStatus)
        {
            // building the connection string
            // get the provider, database name, and path
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create needed objects
            SqlConnection connection;

            // building sql command
            string sqlStatement = "SELECT ID, EmpID, EmpFN, EmpLN, EmpAdd1, EmpAdd2, EmpTown, " +
                "EmpState, EmpZip, EmpHomePhone, EmpCellPhone, EmpEmail, Comment, Active, " +
                "EmpWorkCell, EmpNotes " +
                "FROM lw_Employees " +
                "WHERE Active=@Active " +
                "ORDER BY EmpLN";

            // create List
            List<lw_Employees_Model> eMod_List = new List<lw_Employees_Model>();

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(sqlStatement, connection);

                // add command
                command.Parameters.AddWithValue("@Active", activeStatus);

                SqlDataReader reader = command.ExecuteReader();

                // read table, populate model
                while (reader.Read())
                {
                    lw_Employees_Model eMod = new lw_Employees_Model();

                    eMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    eMod.EmpID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    eMod.EmpFN = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    eMod.EmpLN = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    eMod.EmpAdd1 = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    eMod.EmpAdd2 = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    eMod.EmpTown = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    eMod.EmpState = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    eMod.EmpZip = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    eMod.EmpHomePhone = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    eMod.EmpCellPhone = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    eMod.EmpEmail = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    eMod.Comment = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    eMod.Active = (reader[13] != DBNull.Value) ? (string)reader[13] : "No";
                    eMod.EmpWorkCell = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
                    eMod.EmpNotes = (reader[15] != DBNull.Value) ? (string)reader[15] : "";
                    
                    // add Employee to List
                    eMod_List.Add(eMod);
                }

                // close reader, close connection
                reader.Close();
                connection.Close();
                strMsg = "List Complete.";
            }
            catch (Exception errMsg)
            {
                strMsg = errMsg.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_Employees_List", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return List
            return eMod_List;
        }


        // Method: get record data based on id
        public lw_Employees_Model Get_SpecificEmployee_Record(int recID)
        {
            string strMsg = "";
            
            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "SELECT ID, EmpID, EmpFN, EmpLN, EmpAdd1, EmpAdd2, EmpTown, " +
                "EmpState, EmpZip, EmpHomePhone, EmpCellPhone, EmpEmail, Comment, Active, " +
                "EmpWorkCell, EmpNotes " +
                "FROM lw_Employees " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // Create object base on Employee Model (eMod)
            lw_Employees_Model eMod = new lw_Employees_Model();

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
                    eMod.ID = (reader[0] != DBNull.Value) ? (Int64)reader[0] : 0;
                    eMod.EmpID = (reader[1] != DBNull.Value) ? (string)reader[1] : "";
                    eMod.EmpFN = (reader[2] != DBNull.Value) ? (string)reader[2] : "";
                    eMod.EmpLN = (reader[3] != DBNull.Value) ? (string)reader[3] : "";
                    eMod.EmpAdd1 = (reader[4] != DBNull.Value) ? (string)reader[4] : "";
                    eMod.EmpAdd2 = (reader[5] != DBNull.Value) ? (string)reader[5] : "";
                    eMod.EmpTown = (reader[6] != DBNull.Value) ? (string)reader[6] : "";
                    eMod.EmpState = (reader[7] != DBNull.Value) ? (string)reader[7] : "";
                    eMod.EmpZip = (reader[8] != DBNull.Value) ? (string)reader[8] : "";
                    eMod.EmpHomePhone = (reader[9] != DBNull.Value) ? (string)reader[9] : "";
                    eMod.EmpCellPhone = (reader[10] != DBNull.Value) ? (string)reader[10] : "";
                    eMod.EmpEmail = (reader[11] != DBNull.Value) ? (string)reader[11] : "";
                    eMod.Comment = (reader[12] != DBNull.Value) ? (string)reader[12] : "";
                    eMod.Active = (reader[13] != DBNull.Value) ? (string)reader[13] : "No";
                    eMod.EmpWorkCell = (reader[14] != DBNull.Value) ? (string)reader[14] : "";
                    eMod.EmpNotes = (reader[15] != DBNull.Value) ? (string)reader[15] : "";
                }

                // the close
                reader.Close();
            }
            catch (Exception e)
            {
                strMsg = e.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Get_SpecificEmployee_Record", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // the close
            connection.Close();

            // return the Model
            return eMod;
        }


        // ADD
        public string Add_Employee_Rec(lw_Employees_Model eMod)
        {
            // Method: Create new record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "INSERT INTO lw_Employees (EmpID, EmpFN, EmpLN, EmpAdd1, EmpAdd2, " +
                "EmpTown, EmpState, EmpZip, EmpHomePhone, EmpCellPhone, EmpEmail, Comment, Active, " +
                "EmpWorkCell, EmpNotes) " +
                "VALUES (@EmpID, @EmpFN, @EmpLN, @EmpAdd1, @EmpAdd2, @EmpTown, @EmpState, @EmpZip, " +
                "@EmpHomePhone, @EmpCellPhone, @EmpEmail, @Comment, @Active, @EmpWorkCell, @EmpNotes)";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                connection.Open();
                // Adding parameters for the Insert Command
                command.Parameters.AddWithValue("@EmpID", eMod.EmpID);
                command.Parameters.AddWithValue("@EmpFN", eMod.EmpFN);
                command.Parameters.AddWithValue("@EmpLN", eMod.EmpLN);
                command.Parameters.AddWithValue("@EmpAdd1", eMod.EmpAdd1);
                command.Parameters.AddWithValue("@EmpAdd2", eMod.EmpAdd2);
                command.Parameters.AddWithValue("@EmpTown", eMod.EmpTown);
                command.Parameters.AddWithValue("@EmpState", eMod.EmpState);
                command.Parameters.AddWithValue("@EmpZip", eMod.EmpZip);
                command.Parameters.AddWithValue("@EmpHomePhone", eMod.EmpHomePhone);
                command.Parameters.AddWithValue("@EmpCellPhone", eMod.EmpCellPhone);
                command.Parameters.AddWithValue("@EmpEmail", eMod.EmpEmail);
                command.Parameters.AddWithValue("@Comment", eMod.Comment);
                command.Parameters.AddWithValue("@Active", eMod.Active);
                command.Parameters.AddWithValue("@EmpWorkCell", eMod.EmpCellPhone);
                command.Parameters.AddWithValue("@EmpNotes", eMod.EmpNotes);
                
                command.ExecuteNonQuery();
                strMsg = "Record was added.";
            }
            catch (Exception err)
            {
                strMsg = err.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Add_Employee_Rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // Method: update record
        public string Update_Employee_rec(lw_Employees_Model eMod)
        {
            // Method: update selected Client record 
            // update the database
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "UPDATE lw_Employees " +
                "SET @EmpID=@EmpID, " +
                "EmpFN=@EmpFN, " +
                "EmpLN=@EmpLN, " +
                "EmpAdd1=@EmpAdd1, " +
                "EmpAdd2=@EmpAdd2, " +
                "EmpTown=@EmpTown, " +
                "EmpState=@EmpState, " +
                "EmpZip=@EmpZip, " +
                "EmpHomePhone=@EmpHomePhone, " +
                "EmpCellPhone=@EmpCellPhone, " +
                "EmpEmail=@EmpEmail, " +
                "Comment=@Comment, " +
                "Active=@Active, " +
                "EmpWorkCell=@EmpWorkCell, " +
                "EmpNotes=@EmpNotes " +
                "WHERE ID=@ID";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            try
            {
                // update the database
                connection.Open();

                // use of command.parameters... prevents sql injection
                command.Parameters.AddWithValue("@EmpID", eMod.EmpID);
                command.Parameters.AddWithValue("@EmpFN", eMod.EmpFN);
                command.Parameters.AddWithValue("@EmpLN", eMod.EmpLN);
                command.Parameters.AddWithValue("@EmpAdd1", eMod.EmpAdd1);
                command.Parameters.AddWithValue("@EmpAdd2", eMod.EmpAdd2);
                command.Parameters.AddWithValue("@EmpTown", eMod.EmpTown);
                command.Parameters.AddWithValue("@EmpState", eMod.EmpState);
                command.Parameters.AddWithValue("@EmpZip", eMod.EmpZip);
                command.Parameters.AddWithValue("@EmpHomePhone", eMod.EmpHomePhone);
                command.Parameters.AddWithValue("@EmpCellPhone", eMod.EmpCellPhone);
                command.Parameters.AddWithValue("@EmpEmail", eMod.EmpEmail);
                command.Parameters.AddWithValue("@Comment", eMod.Comment);
                command.Parameters.AddWithValue("@Active", eMod.Active);
                command.Parameters.AddWithValue("@EmpWorkCell", eMod.EmpCellPhone);
                command.Parameters.AddWithValue("@EmpNotes", eMod.EmpNotes);
                //
                command.Parameters.AddWithValue("@ID", eMod.ID); // must be in the order of the sqlstatement

                command.ExecuteNonQuery();
                strMsg = "Record was updated.";
            }
            catch (Exception err)
            {
                strMsg = err.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Update_Employee_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            connection.Close();
            return strMsg;
        }


        // DELETE
        public string Delete_Employee_rec(Int64 recID)
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
                string sqlStatement = "DELETE FROM lw_Employees " +
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
                catch (Exception err)
                {
                    strMsg = err.Message.ToString();
                    System.Windows.MessageBox.Show(strMsg, "Method: Delete_Employee_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                }

                // the close
                connection.Close();
            }
            else
            {
                strMsg = "Delete did not occur, ID did not contain data.";
                System.Windows.MessageBox.Show(strMsg, "Method: Delete_Employee_rec", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }

            // return status message
            return strMsg;
        }


        // removes all records from the Employees table
        // while leaving all table structures
        public string Truncate_Employees_table()
        {
            string strMsg = "";

            // get the connection string
            connectionString = PSWkr.G_SQLDatabaseConnectionString;

            // create connection object
            SqlConnection connection = new SqlConnection(connectionString);

            // building sql command
            string sqlStatement = "TRUNCATE TABLE lw_Employees";

            // SqlCommand
            SqlCommand command = new SqlCommand(sqlStatement, connection);

            // open the connection and Truncate Table 
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                strMsg = "Employee table Initialized.";
            }
            catch (Exception err)
            {
                connection.Close();
                strMsg = err.Message.ToString();
                System.Windows.MessageBox.Show(strMsg, "Method: Truncate_Employees_table", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
                        
            // return status message
            return strMsg;
        }



        // Reset Equipment Model
        private lw_Employees_Model Reset_Employees_Mod()
        {
            lw_Employees_Model eMod = new lw_Employees_Model();

            // reset the model
            eMod.ID = 0;
            eMod.EmpID = "";
            eMod.EmpFN = "";
            eMod.EmpLN = "";
            eMod.EmpAdd1 = "";
            eMod.EmpAdd2 = "";
            eMod.EmpTown = "";
            eMod.EmpState = "";
            eMod.EmpZip = "";
            eMod.EmpHomePhone = "";
            eMod.EmpCellPhone = "";
            eMod.EmpEmail = "";
            eMod.Comment = "";
            eMod.Active = "No";
            eMod.EmpWorkCell = "";
            eMod.EmpNotes = "";

            // return the model
            return eMod;
        }
    }
}