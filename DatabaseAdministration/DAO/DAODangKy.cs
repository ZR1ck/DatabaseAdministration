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
    internal class DAODangKy
    {
        public static DataTable getDataTableDangKi()
        {
            return DatabaseProvider.getInstance().getDataTableDangki();
        }
        public static int updateDangKy(DangKy dk)
        {
            return DatabaseProvider.getInstance().updateDangKy(dk);
        }
        public static int deleteDangKy(DangKy dk)
        {
            return DatabaseProvider.getInstance().deleteDangKy(dk);
        }
        public static int insertDangKy(DangKy dk)
        {
            return DatabaseProvider.getInstance().insertDangKy(dk);
        }
    }
}
