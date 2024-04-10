using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAdministration.DataProvider
{
    internal class DatabaseProvider
    {
        private static DatabaseProvider instance = null;
        private DatabaseProvider() { }

        public static DatabaseProvider getInstance()
        {
            if (instance == null) 
            { 
                instance = new DatabaseProvider(); 
            }
            return instance;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (OracleConnection connection = new OracleConnection(LoginHelper.getInstance().ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                            connection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return dataTable;
        }



        public DataTable getUsers()
        {
            string query = "SELECT USERNAME FROM DBA_USERS";
            return ExecuteQuery(query);
        }

        public DataTable getRole()
        {
            string query = "SELECT ROLE FROM DBA_ROLES";
            return ExecuteQuery(query);
        }

        public DataTable getTabPrivs(string grantee)
        {
            string query = $"SELECT *FROM DBA_TAB_PRIVS WHERE GRANTEE = '{grantee}'";
            return ExecuteQuery(query);
        }

        public DataTable getSysPrivs(string grantee)
        {
            string query = $"SELECT *FROM DBA_SYS_PRIVS WHERE GRANTEE = '{grantee}'";
            return ExecuteQuery(query);
        }

        public DataTable getRolePrivs(string grantee)
        {
            string query = $"SELECT *FROM DBA_ROLE_PRIVS WHERE GRANTEE = '{grantee}'";
            return ExecuteQuery(query);
        }
    }
}
