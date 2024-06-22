using DatabaseAdministration.DTO;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DatabaseAdministration.DataProvider
{
    internal class DatabaseProvider
    {
        private static DatabaseProvider instance = null;
        private DatabaseProvider() { }
        public const int UNIQUE_CONSTRAINT_VIOLATED = 1;
        public const int INTEGRITY_CONSTRAINT_VIOLATED = 2291;
        public const int SUCCESS = 0;
        public const int UNIDENTIFIED_ERROR = -1;
        public const int NO_ROWSAFFECTED = -2;
        public const int POLICY_WITH_CHECK_OPTION_VIOLATION = 28115;

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
        public int ExecuteQueryUpdated(string query)
        {
            using (OracleConnection connection = new OracleConnection(LoginHelper.getInstance().ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();
                        if (rowsAffected == 0) return NO_ROWSAFFECTED;
                        return 0;
                    }
                }
                catch (OracleException ex)
                {
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        Console.WriteLine("Oracle Error " + ex.Errors[i].Number + ": " + ex.Errors[i].Message);
                        if (ex.Errors[i].Number == UNIQUE_CONSTRAINT_VIOLATED)
                        {
                            return UNIQUE_CONSTRAINT_VIOLATED;
                        }
                        else if (ex.Errors[i].Number == INTEGRITY_CONSTRAINT_VIOLATED)
                        {
                            return INTEGRITY_CONSTRAINT_VIOLATED;
                        }
                        else if (ex.Errors[i].Number == POLICY_WITH_CHECK_OPTION_VIOLATION)
                        {
                            return POLICY_WITH_CHECK_OPTION_VIOLATION;
                        }
                    }
                    return UNIDENTIFIED_ERROR;
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
            if (!verify(newUsername)) { return false; }
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
            if (!verify(newName)) return false;
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

        public int addUser(string username, string password)
        {
            if (!verify(username)) return 1; // invalid username
            if (!verify(password)) return 2; // invalid password

            string sql = "CREATE USER " + username + " IDENTIFIED BY " + password;

            if (ExecuteNonQuery(sql))
            {
                return 0;
            }
            else return 3; // exec error
        }

        public bool addRole(string rolenameInput)
        {
            if (!verify(rolenameInput)) return false;

            string sql = "CREATE ROLE " + rolenameInput;

            return ExecuteNonQuery(sql);
        }

        private bool verify(string input)
        {
            Regex regex = new Regex("^[a-zA-Z0-9]+$");
            return regex.IsMatch(input);
        }

        public DataTable getCurrentUserRole()
        {
            string query = "SELECT * FROM SESSION_ROLES";
            return ExecuteQuery(query);
        }

        public DataTable getNhanSu()
        {
            string query = "SELECT * FROM QLDL.NHANSU";
            return ExecuteQuery(query);
        }

        public bool updateSDTNhanSuCaNhan(string sdt)
        {
            string query = $"UPDATE QLDL.NHANSU SET SDT = '{sdt}'";
            return ExecuteNonQuery(query);
        }

        public DataTable getSinhVien()
        {
            string query = "SELECT * FROM QLDL.SINHVIEN";
            return ExecuteQuery(query);
        }

        public bool svUpdateTTCN(string sdt, string diachi)
        {
            string query = $"UPDATE QLDL.SINHVIEN SET SDT = '{sdt}', DCHI = '{diachi}'";
            return ExecuteNonQuery(query);
        }

        public int updateSV(SinhVien sv)
        {
            string query = $"UPDATE QLDL.SINHVIEN SET " +
                $"MASV = '{sv.maSV}', HOTEN = '{sv.hoTen}', PHAI = '{sv.phai}', " +
                $"NGSINH = TO_DATE('{sv.ngaySinh}','dd-MM-yyyy'), " +
                $"DCHI = '{sv.diaChi}', SDT = '{sv.DT}', MACT = '{sv.maCT}', " +
                $"MANGANH = '{sv.maNganh}', SOTCTL = '{sv.soTCTL}', DTBTL = '{sv.diemTBTL}'" +
                $"WHERE MASV = '{sv.maSV}'";
            
            return ExecuteQueryUpdated(query);
        }

        public int insertSV(SinhVien sv)
        {
            string query = $"INSERT INTO QLDL.SINHVIEN VALUES ('{sv.maSV}', '{sv.hoTen}', '{sv.phai}', TO_DATE('{sv.ngaySinh}', 'dd-MM-yyyy'), " +
                $"'{sv.diaChi}', '{sv.DT}', '{sv.maCT}', '{sv.maNganh}', {sv.soTCTL}, {sv.diemTBTL})";

            return ExecuteQueryUpdated(query);
        }

        public int updateNhanSu(NhanSu ns)
        {
            string query = $"UPDATE QLDL.NHANSU SET " +
                $"MANV = '{ns.maNV}', HOTEN = '{ns.hoten}', PHAI = '{ns.phai}', " +
                $"NGSINH = TO_DATE('{ns.ngaySinh}','dd-MM-yyyy'), " +
                $"PHUCAP = '{ns.phuCap}', SDT = '{ns.SDT}', VAITRO = '{ns.vaiTro}', " +
                $"MADV = '{ns.maDV}' " +
                $"WHERE MANV = '{ns.maNV}'";
            return ExecuteQueryUpdated(query);
        }

        public bool deleteNhanSu(string id)
        {
            string query = $"DELETE QLDL.NHANSU WHERE MANV = '{id}'";
            return ExecuteNonQuery(query);
        }

        public int insertNhanSu(NhanSu ns)
        {
            string query = $"INSERT INTO QLDL.NHANSU VALUES (" +
                $"'{ns.maNV}', '{ns.hoten}', '{ns.phai}', TO_DATE('{ns.ngaySinh}', 'dd-MM-yyyy'), {ns.phuCap}, " +
                $"'{ns.SDT}', '{ns.vaiTro}', '{ns.maDV}'" +
                $")";
            return ExecuteQueryUpdated(query);
        }

        public DataTable getDataTablePhanCong()
        {
            string query = "SELECT * FROM QLDL.PHANCONG";
            return ExecuteQuery(query);
        }

        public int updatePhanCong(PhanCong pc, PhanCong oldPc)
        {
            string query = $"UPDATE QLDL.PHANCONG " +
                $"SET MAGV = '{pc.maGV}', MAHP = '{pc.maHP}', HK = '{pc.HK}', NAM = {pc.nam}, MACT = '{pc.maCT}' " +
                $"WHERE MAGV = '{oldPc.maGV}' AND MAHP = '{oldPc.maHP}' AND HK = '{oldPc.HK}' AND NAM = {oldPc.nam} AND MACT = '{oldPc.maCT}'";
            return ExecuteQueryUpdated(query);
        }

        public int deletePhanCong(PhanCong pc)
        {
            string query = $"DELETE QLDL.PHANCONG " +
                $"WHERE MAGV = '{pc.maGV}' AND MAHP = '{pc.maHP}' AND HK = '{pc.HK}'AND NAM = {pc.nam} AND MACT = '{pc.maCT}' ";
            return ExecuteQueryUpdated(query);
        }

        public int insertPhanCong(PhanCong pc)
        {
            string query = $"INSERT INTO QLDL.PHANCONG VALUES (" +
                $"'{pc.maGV}', '{pc.maHP}', '{pc.HK}', {pc.nam}, '{pc.maCT}')";
            return ExecuteQueryUpdated(query);
        }

        public DataTable getDatatableDonVi()
        {
            string query = "SELECT * FROM QLDL.DONVI";
            return ExecuteQuery(query);
        }

        public int updateDonVi(DonVi dv, string madv)
        {
            string query = $"UPDATE QLDL.DONVI " +
                $"SET MADV = '{dv.maDV}', TENDV = '{dv.tenDV}', TRGDV = '{dv.trgDV}' " +
                $"WHERE MADV = '{madv}'";
            return ExecuteQueryUpdated(query);
        }

        public int insertDonVi(DonVi dv)
        {
            string query = $"INSERT INTO QLDL.DONVI VALUES ('{dv.maDV}', '{dv.tenDV}', '{dv.trgDV}')";
            return ExecuteQueryUpdated(query);
        }

        public DataTable getDataTableKHMo()
        {
            string query = "SELECT * FROM QLDL.KHMO";
            return ExecuteQuery(query);
        }

        public DataTable getDataTableKHMoSV()
        {
            string query = "SELECT * FROM QLDL.V_SV_KHMO";
            return ExecuteQuery(query);
        }

        public int updateKHMo(KHMo kh, KHMo old)
        {
            string query = $"UPDATE QLDL.KHMO SET " +
                $"MAHP = '{kh.maHP}', HK = '{kh.HK}', NAM = {kh.nam}, MACT = '{kh.maCT}' " +
                $"WHERE MAHP = '{old.maHP}' AND HK = '{old.HK}' AND NAM = {old.nam} AND MACT = '{old.maCT}' ";
            return ExecuteQueryUpdated(query);
        }

        public int insertKHMo(KHMo kh)
        {
            string query = $"INSERT INTO QLDL.KHMO VALUES ('{kh.maHP}','{kh.HK}', {kh.nam}, '{kh.maCT}') ";
            return ExecuteQueryUpdated(query);
        }

        public DataTable getDataTableDangki()
        {
            string query = $"SELECT * FROM QLDL.DANGKY";
            return ExecuteQuery(query);
        }

        public int updateDangKy(DangKy dk)
        {
            string query = $"UPDATE QLDL.DANGKY " +
                $"SET DIEMTH = {dk.diemTH}, DIEMQT = {dk.diemQT}, DIEMCK = {dk.diemCK}, DIEMTK = {dk.diemTK} " +
                $"WHERE MASV = '{dk.maSV}' AND MAGV = '{dk.maGV}' AND MAHP = '{dk.maHP}' AND HK = '{dk.HK}' " +
                $"AND NAM = '{dk.nam}' AND MACT = '{dk.maCT}' ";
            return ExecuteQueryUpdated(query);
        }

        public int deleteDangKy(DangKy dk)
        {
            string query = $"DELETE QLDL.DANGKY " +
                $"WHERE MASV = '{dk.maSV}' AND MAGV = '{dk.maGV}' AND MAHP = '{dk.maHP}' AND HK = '{dk.HK}' " +
                $"AND NAM = '{dk.nam}' AND MACT = '{dk.maCT}' ";
            return ExecuteQueryUpdated(query);
        }

        public int insertDangKy(DangKy dk)
        {
            string diemTH, diemQT, diemCK, diemTK;
            diemTH = dk.diemTH != 0 ? dk.diemTH.ToString() : "NULL";
            diemQT = dk.diemQT != 0 ? dk.diemQT.ToString() : "NULL";
            diemCK = dk.diemCK != 0 ? dk.diemCK.ToString() : "NULL";
            diemTK = dk.diemTK != 0 ? dk.diemTK.ToString() : "NULL";

            string query = $"INSERT INTO QLDL.DANGKY VALUES (" +
                $"'{dk.maSV}', '{dk.maGV}', '{dk.maHP}', '{dk.HK}', {dk.nam}, '{dk.maCT}'," +
                $" {diemTH}, {diemQT}, {diemCK}, {diemTK}" +
                $")";

            return ExecuteQueryUpdated(query);
        }
    }
}
