using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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


        public bool ExecuteNonQuery(string query)
        {
            using (OracleConnection connection = new OracleConnection(LoginHelper.getInstance().ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
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
        public DataTable getColsPrivs(string grantee)
        {
            string query = $"SELECT *FROM DBA_COL_PRIVS WHERE GRANTEE = '{grantee}'";
            return ExecuteQuery(query);
        }

        public DataTable getAllTableName()
        {
            string query = $"SELECT OWNER || '.' || TABLE_NAME AS TABLE_NAME FROM ALL_TABLES";
            return ExecuteQuery(query);
        }

        public bool grantPrivs(string priv, string tbName, string grantee, bool grntOpt, List<string> cols = null)
        {
            string onCols = "";
            if (cols != null && cols.Count > 0)
            {
                string s = string.Join(", ", cols);
                onCols = "(" + s + ")";
            }
            string query = $"GRANT {priv} {onCols} ON {tbName} TO {grantee}";
            if (grntOpt)
            {
                query += " WITH GRANT OPTION";
            }
            return ExecuteNonQuery(query);
        }

        public DataTable getTableColsName(string tableName)
        {
            string[] tb = tableName.Split('.');
            string tbName = "";
            if (tb.Length > 1)
            {
                tbName = tb[1];
            }
            string query = $"SELECT COLUMN_NAME FROM ALL_TAB_COLUMNS WHERE TABLE_NAME = '{tbName}'";
            return ExecuteQuery(query);
        }
    }
}
