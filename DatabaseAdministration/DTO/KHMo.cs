using DatabaseAdministration.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class KHMo
    {
        public string maHP {  get; set; }
        public string HK { get; set; }
        public string maCT { get; set; }
        public int nam {  get; set; }

        public KHMo(string maHp, string HK, string maCT, int nam)
        {
            this.maHP = maHp;
            this.HK = HK;
            this.maCT = maCT;
            this.nam = nam;
        }

        public static DataTable getDataTableKHMo()
        {
            return DAOKHMo.getDataTableKHMo();
        }

        public static DataTable getDataTableKHMoSV()
        {
            return DAOKHMo.getDataTableKHMoSV();
        }

        public static int updateKHMo(KHMo kh, KHMo old)
        {
            return DAOKHMo.updateKHMo(kh, old);
        }

        public static int insertKHMo(KHMo kh)
        {
            return DAOKHMo.insertKHMo(kh);
        }
    }
}
