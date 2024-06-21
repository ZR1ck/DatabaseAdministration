using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class HocPhan
    {
        private string maHP, tenHP, maDV;
        private int soTC, soTLT, soTTH, soSVTD;

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
    }
}
