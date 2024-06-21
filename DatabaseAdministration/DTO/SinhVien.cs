using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class SinhVien
    {
        private string maSV, hoTen, phai, ngaySinh, diaChi, DT, maCT, maNganh;
        private int soTCTL, diemTBTL;

        public SinhVien(string maSV, string hoTen, string phai, string ngaySinh, string diaChi, string dT, string maCT, string maNganh, int soTCTL, int diemTBTL)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.phai = phai;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.DT = dT;
            this.maCT = maCT;
            this.maNganh = maNganh;
            this.soTCTL = soTCTL;
            this.diemTBTL = diemTBTL;
        }


    }
}
