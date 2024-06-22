using DatabaseAdministration.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DAO
{
    internal class DAOThongBao
    {
        public static DataTable getThongBao()
        {
            return DatabaseProvider.getInstance().getThongBao();
        }
    }
}
