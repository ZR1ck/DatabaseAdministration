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
    internal class DAOHocPhan
    {
        public static DataTable getDataTableHocPhan()
        {
            return DatabaseProvider.getInstance().getDataTableHocPhan();
        }
        public static DataTable getDataTableHocPhanSV()
        {
            return DatabaseProvider.getInstance().getDataTableHocPhanSV();
        }
        public static int updateHocPhan(HocPhan hp, string mahp)
        {
            return DatabaseProvider.getInstance().updateHocPhan(hp, mahp);
        }
        public static int insertHocPhan(HocPhan hp)
        {
            return DatabaseProvider.getInstance().insertHocPhan(hp);
        }
    }
}
