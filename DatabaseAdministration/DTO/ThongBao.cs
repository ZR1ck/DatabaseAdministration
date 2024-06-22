using DatabaseAdministration.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class ThongBao
    {
        public static DataTable getThongBao()
        {
            return DAOThongBao.getThongBao();
        }
    }
}
