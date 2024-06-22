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
    internal class DAOKHMo
    {
        public static DataTable getDataTableKHMo()
        {
            return DatabaseProvider.getInstance().getDataTableKHMo();
        }
        public static DataTable getDataTableKHMoSV()
        {
            return DatabaseProvider.getInstance().getDataTableKHMoSV();
        }
        public static int updateKHMo(KHMo kh, KHMo old)
        {
            return DatabaseProvider.getInstance().updateKHMo(kh, old);
        }
        public static int insertKHMo(KHMo kh)
        {
            return DatabaseProvider.getInstance().insertKHMo(kh);
        }
    }
}
