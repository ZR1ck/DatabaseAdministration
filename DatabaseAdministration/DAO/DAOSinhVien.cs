using DatabaseAdministration.DataProvider;
using DatabaseAdministration.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DAO
{
    internal class DAOSinhVien
    {
        public static List<SinhVien> getListSinhVien()
        {
            List<SinhVien> listSV = new List<SinhVien>();

            DataTable data = DatabaseProvider.getInstance().getSinhVien();
            foreach (DataRow row in data.Rows)
            {
                listSV.Add(new SinhVien(row));
            }
            return listSV;
        }

        public static DataTable getDataTableSinhVien()
        {
            return DatabaseProvider.getInstance().getSinhVien();
        }
        
        public static bool svUpdateTTCN(string sdt, string diachi)
        {
            return DatabaseProvider.getInstance().svUpdateTTCN(sdt, diachi);
        }
        public static int updateSV(SinhVien sv)
        {
            return DatabaseProvider.getInstance().updateSV(sv);
        }

        public static int insertSV(SinhVien sv)
        {
            return DatabaseProvider.getInstance().insertSV(sv);
        }
    }
}
