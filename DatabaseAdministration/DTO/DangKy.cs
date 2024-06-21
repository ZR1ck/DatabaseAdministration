using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class DangKy
    {
        private string maSV, maGV, maHP, HK, maCT;
        private int nam;
        private float diemTH, diemQT, diemCK, diemTK;

        public DangKy(string maSV, string maGV, string maHP, string hK, string maCT, int nam, float diemTH, float diemQT, float diemCK, float diemTK)
        {
            this.maSV = maSV;
            this.maGV = maGV;
            this.maHP = maHP;
            this.HK = hK;
            this.maCT = maCT;
            this.nam = nam;
            this.diemTH = diemTH;
            this.diemQT = diemQT;
            this.diemCK = diemCK;
            this.diemTK = diemTK;
        }
    }
}
