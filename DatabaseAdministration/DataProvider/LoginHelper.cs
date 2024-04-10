using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DataProvider
{
    internal class LoginHelper
    {
        private string connectionString = "";
        private static LoginHelper instance = null;

        private LoginHelper() { }

        public string ConnectionString { get { return connectionString; } }

        public static LoginHelper getInstance()
        {
            if (instance == null)
            {
                instance = new LoginHelper();
            }
            return instance;
        }


        public bool connectionCheck(string hostName, string serviceName, string username, string password)
        {
            this.connectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={hostName})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME={serviceName})));User Id={username};Password={password};DBA Privilege=SYSDBA;";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Login error: " + e.Message);
                    return false;
                }
            }
        }
    }
}
