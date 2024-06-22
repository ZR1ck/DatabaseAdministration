using DatabaseAdministration.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class HocPhan
    {
        public string maHP { get; set; }
        public string tenHP { get; set; }
        public string maDV { get; set; }
        public int soTC { get; set; }
        public int soTLT { get; set; }
        public int soTTH { get; set; }
        public int soSVTD { get; set; }

        public HocPhan(string maHP, string tenHP, string maDV, int soTC, int soTLT, int soTTH, int soSVTD)
        {
            this.maHP = maHP;
            this.tenHP = tenHP;
            this.maDV = maDV;
            this.soTC = soTC;
            this.soTLT = soTLT;
            this.soTTH = soTTH;
            this.soSVTD = soSVTD;
        }

        public static DataTable getDataTableHocPhan()
        {
            return DAOHocPhan.getDataTableHocPhan();
        }
        public static DataTable getDataTableHocPhanSV()
        {
            return DAOHocPhan.getDataTableHocPhanSV();
        }
        public static int updateHocPhan(HocPhan hp, string mahp)
        {
            return DAOHocPhan.updateHocPhan(hp, mahp);
        }
        public static int insertHocPhan(HocPhan hp)
        {
            return DAOHocPhan.insertHocPhan(hp);
        }
    }
}
