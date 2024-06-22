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
    internal class DAODonVi
    {
        public static DataTable getDataTableDonVi()
        {
            return DatabaseProvider.getInstance().getDatatableDonVi();
        }
        public static int updateDonVi(DonVi dv, string madv)
        {
            return DatabaseProvider.getInstance().updateDonVi(dv, madv);
        }
        public static int insertDonVi(DonVi dv)
        {
            return DatabaseProvider.getInstance().insertDonVi(dv);
        }
    }
}
