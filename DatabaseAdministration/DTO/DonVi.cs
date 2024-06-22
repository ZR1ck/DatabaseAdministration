using DatabaseAdministration.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class DonVi
    {
        public string maDV {  get; set; }
        public string tenDV { get; set; }
        public string trgDV { get; set; }

        public DonVi(string maDV, string tenDV, string trgDV)
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.trgDV = trgDV;
        }

        public static DataTable getDataTableDonVi()
        {
            return DAODonVi.getDataTableDonVi();
        }
        public static int updateDonVi(DonVi dv, string madv)
        {
            return DAODonVi.updateDonVi(dv, madv);
        }
        public static int insertDonVi(DonVi dv)
        {
            return DAODonVi.insertDonVi(dv);
        }
    }
}
