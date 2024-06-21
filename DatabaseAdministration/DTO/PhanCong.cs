using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class PhanCong
    {
        private string maGV, maHP, HK, maCT;
        private int nam;

        public PhanCong(string maGV, string maHP, string hK, string maCT, int nam)
        {
            this.maGV = maGV;
            this.maHP = maHP;
            this.HK = hK;
            this.maCT = maCT;
            this.nam = nam;
        }
    }
}
