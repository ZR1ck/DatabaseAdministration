using DatabaseAdministration.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class SinhVien
    {
        public string maSV, hoTen, phai, ngaySinh, diaChi, DT, maCT, maNganh;
        public int soTCTL, diemTBTL;

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

        public SinhVien(DataRow row)
        {
            this.maSV = (string)row["MASV"];
            this.hoTen = (string)row["HOTEN"];
            this.phai = (string)row["PHAI"];
            DateTime ngSinh = Convert.ToDateTime(row["NGSINH"]);
            this.ngaySinh = ngSinh.ToString("dd/MM/yyyy");
            this.diaChi = (string)row["DCHI"];
            this.DT = (string)row["SDT"];
            this.maCT = (string)row["MACT"];
            this.maNganh = (string)row["MANGANH"];
            this.soTCTL = Convert.ToInt32(row["SOTCTL"]);
            this.diemTBTL = Convert.ToInt32(row["DTBTL"]);
        }

        public static List<SinhVien> getListSinhVien()
        {
            return DAOSinhVien.getListSinhVien();
        }

        public static DataTable getDataTableSinhVien()
        {
            return DAOSinhVien.getDataTableSinhVien();
        }

        public static SinhVien getCurrentSV()
        {
            List<SinhVien> listSV = DAOSinhVien.getListSinhVien();
            if (listSV.Count == 1)
            {
                return listSV[0];
            }
            return null;
        }
        public static bool svUpdateTTCN(string sdt, string diachi)
        {
            return DAOSinhVien.svUpdateTTCN(sdt, diachi);
        }
    }
}
