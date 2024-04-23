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

        public DataTable getSchema()
        {
            string query = "SELECT username  FROM dba_users u WHERE EXISTS (SELECT 1 FROM dba_objects o  WHERE o.owner = u.username )";
            return ExecuteQuery(query);
        }
        public DataTable getColsPrivs(string grantee)
        {
            string query = $"SELECT *FROM DBA_COL_PRIVS WHERE GRANTEE = '{grantee}'";
            return ExecuteQuery(query);
        }

        public DataTable getTableNames(string schema)
        {
            string query = $"SELECT table_name FROM all_tables WHERE owner = '{schema}'";
            return ExecuteQuery(query);
        }

        public DataTable getColumnNames(string schema, string table)
        {
            string query = $"SELECT column_name FROM all_tab_columns WHERE table_name = '{table}' AND owner = '{schema}'";
            return ExecuteQuery(query);
        }

        public bool grantPriv(string priv, string schema, string table, string grantee, bool grantWithOptionChecked)
        {
            string sqlstr = $"GRANT {priv} ON {schema}.{table} TO {grantee}";
            if (grantWithOptionChecked)
            {
                sqlstr += " WITH GRANT OPTION";
            }
            return ExecuteNonQuery(sqlstr);
        }

        public bool grantPriv(string priv, string schema, string table, string col, string grantee, bool grantWithOptionChecked)
        {
            string sqlstr = $"GRANT {priv} ({col}) ON {schema}.{table} TO {grantee}";
            if(grantWithOptionChecked)
            {
                sqlstr += " WITH GRANT OPTION";
            }
            return ExecuteNonQuery(sqlstr);
        }

        public bool grantRole(string role, string user)
        {
            string sqlstr = $"GRANT {role} TO {user}";
            return ExecuteNonQuery(sqlstr);
        }

        public bool grantSelect(string schema, string table, string cols, string grantee, bool grantWithOptionChecked)
        {
            string view =
                $"CREATE OR REPLACE VIEW V_{schema}_{table}_{grantee} AS " +
                $"SELECT {cols} FROM {schema}.{table}";
            if (!ExecuteNonQuery(view)) { return false; }

            string sqlstr = $"GRANT SELECT ON V_{schema}_{table}_{grantee} TO {grantee}";
            if (grantWithOptionChecked)
            {
                sqlstr += " WITH GRANT OPTION";
            }
            return ExecuteNonQuery(sqlstr);
        }

        public bool revokePrivs(string grantee, string revokeType, string owner = null, string tableName = null, string type = null)
        {
            string query;
            // Drop view
            if (type != null && type.ToUpper() == "VIEW")
            {
                query = $"DROP VIEW {tableName}";
                return ExecuteNonQuery (query);
            }
            // revoke if not view
            if (owner != null && tableName != null)
            {
                query = $"REVOKE {revokeType} ON {owner}.{tableName} FROM {grantee}";
            }
            else
            {
                query = $"REVOKE {revokeType} FROM {grantee}";
            }
            return ExecuteNonQuery(query);
        }

        public bool UpdateUsername(string oldUsername, string newUsername)
        {
            using (OracleConnection connection = new OracleConnection(LoginHelper.getInstance().ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh SQL để cập nhật tên người dùng trong bảng người dùng của bạn
                    string sql = $"UPDATE DBA_USERS SET USERNAME = '{newUsername}' WHERE USERNAME = '{oldUsername}'";

                    // Tạo đối tượng Command
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        // Thêm tham số cho câu lệnh SQL
                        //command.Parameters.Add(new OracleParameter("newUsername", newUsername));
                        //command.Parameters.Add(new OracleParameter("oldUsername", oldUsername));

                        // Thực hiện câu lệnh SQL
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra xem có dòng nào bị ảnh hưởng không
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý các ngoại lệ nếu cần
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false;
                }
            }
            return false;
        }

        public bool UpdateRolename(string oldName, string newName)
        {
            using (OracleConnection connection = new OracleConnection(LoginHelper.getInstance().ConnectionString))
            {
                try
                {
                    connection.Open();
                    string sql = $"UPDATE DBA_ROLES SET ROLE = '{newName}' WHERE ROLE = '{oldName}'";
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false;
                }
            }
            return false;
        }
    }
}
