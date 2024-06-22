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
    internal class DAOPhanCong
    {
        public static DataTable getDataTablePhanCong()
        {
            return DatabaseProvider.getInstance().getDataTablePhanCong();
        }
        public static int updatePhanCong(PhanCong pc, PhanCong oldPc)
        {
            return DatabaseProvider.getInstance().updatePhanCong(pc, oldPc);
        }
        public static int insertPhanCong(PhanCong pc)
        {
            return DatabaseProvider.getInstance().insertPhanCong(pc);
        }
        public static int deletePhanCong(PhanCong pc)
        {
            return DatabaseProvider.getInstance().deletePhanCong(pc);
        }
    }
}
