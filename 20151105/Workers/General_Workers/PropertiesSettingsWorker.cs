using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VcsConnect_Client.Workers.General_Workers
{
    public class PropertiesSettingsWorker
    {
        // constructor
        public PropertiesSettingsWorker() { }
        

        // Winhost connection string to connect to the
        // VCSConnect database: DB_93184_vcsconnect
        public string G_SQLDatabaseConnectionString
        {
            get
            {
                // Example used by treeWorksWeb secruity app.
                // return  @"Data Source=tcp:s10.winhost.com;Initial Catalog=DB_76273_twlite;User ID=DB_76273_twlite_user;Password=Trees2495;Integrated Security=False;";
                return @"Data Source=tcp:s11.winhost.com;Initial Catalog=DB_93184_vcsconnect;User ID=DB_93184_vcsconnect_user;Password=footballbat;Integrated Security=False;";
            }
        }
    }
}
