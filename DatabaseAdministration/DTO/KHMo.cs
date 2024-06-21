using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class KHMo
    {
        private string maHP, HK, maCT;
        private int nam;

        public KHMo(string maHp, string HK, string maCT, int nam)
        {
            this.maHP = maHp;
            this.HK = HK;
            this.maCT = maCT;
            this.nam = nam;
        }
    }
}
