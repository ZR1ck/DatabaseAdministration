using DatabaseAdministration.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class PhanCong
    {
        public string maGV { get; set; }
        public string maHP { get; set; }
        public string HK { get; set; }
        public string maCT { get; set; }
        public int nam {  get; set; }

        public PhanCong(string maGV, string maHP, string hK, string maCT, int nam)
        {
            this.maGV = maGV;
            this.maHP = maHP;
            this.HK = hK;
            this.maCT = maCT;
            this.nam = nam;
        }

        public static DataTable getDataTablePhanCong()
        {
            return DAOPhanCong.getDataTablePhanCong();
        }

        public static int updatePhanCong(PhanCong pc, PhanCong oldPc)
        {
            return DAOPhanCong.updatePhanCong(pc, oldPc);
        }

        public static int insertPhanCong(PhanCong pc)
        {
            return DAOPhanCong.insertPhanCong(pc);
        }
        public static int deletePhanCong(PhanCong pc)
        {
            return DAOPhanCong.deletePhanCong(pc);
        }
    }
}
