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
        public const int OK = 0;
        public const int INVALID_INFO = 1;
        public const int INVALID_ROLE = 2;
        public const int ERROR = 3;
        public const int PDB = 4;

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


        public int connectionCheck(string hostName, string serviceName, string username, string password, int role)
        {
            this.connectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={hostName})(PORT=1521))(CONNECT_DATA=(SERVICE_NAME={serviceName})));User Id={username};Password={password};";

            if (role == 0)
            {
                this.connectionString += "DBA Privilege=SYSDBA;";
            }

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();

                    if (role == 0) return OK;
                }
                catch (OracleException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        Console.WriteLine("Oracle Error " + ex.Errors[i].Number + ": " + ex.Errors[i].Message);
                        if (ex.Errors[i].Number == 1017) // Lỗi sai mật khẩu/tên đăng nhập
                        {
                            return INVALID_INFO;
                        }
                    }
                    return ERROR;
                }
            }

            if (!serviceName.Equals("xe"))
            {
                return PDB;
            }

            if (role != 0)
            {
                string roleVal = "";
                switch (role)
                {
                    case 1:
                        roleVal = "SV";
                        break;
                    case 2:
                        roleVal = "NVCB";
                        break;
                    case 3:
                        roleVal = "GIAOVU";
                        break;
                    case 4:
                        roleVal = "GV";
                        break;
                    case 5:
                        roleVal = "TRGDV";
                        break;
                    case 6:
                        roleVal = "TRGKHOA";
                        break;
                }

                DataTable data = DatabaseProvider.getInstance().getCurrentUserRole();
                if (data.Rows.Count > 0)
                {
                    object firstCellValue = data.Rows[0][0];
                    if (roleVal.Equals(firstCellValue.ToString()))
                    {
                        return OK;
                    }
                    else
                    {
                        return INVALID_ROLE;
                    }
                }
            }
            return ERROR;
        }
    }
}
