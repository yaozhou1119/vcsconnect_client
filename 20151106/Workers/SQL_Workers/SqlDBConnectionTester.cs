using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VcsConnect_Client.Workers.General_Workers;

namespace VcsConnect_Client.Workers.SQL_Workers
{
    public class SqlDBConnectionTester
    {
        // constructor
        public SqlDBConnectionTester() { }

        // Test the stored connection string
        public string TestSqlConnection()
        {
            PropertiesSettingsWorker PSWkr = new PropertiesSettingsWorker();
            string strMsg = "";

            // load sql connection string 
            string connectionstring = PSWkr.G_SQLDatabaseConnectionString;

            try
            {
                // Attempt a connection 
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                strMsg = "SQL Connection: " + connection.State;
                connection.Close();
            }
            catch (Exception err)
            {
                strMsg = err.Message.ToString();
            }

            return strMsg;
        }
    }
}