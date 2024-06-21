using DatabaseAdministration.DAO;
using DatabaseAdministration.DataProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class NhanSu
    {
        public string maNV { get; set; }
        public string hoten { get; set; }
        public string phai { get; set; }
        public string ngaySinh { get; set; }
        public string SDT { get; set; }
        public string vaiTro { get; set; }
        public string maDV { get; set; }
        public int phuCap { get; set; }

        public NhanSu(string maNV, string hoTen, string phai, string ngaySinh, string SDT, string vaiTro, string maDV, int phuCap)
        {
            this.maNV = maNV;
            this.hoten = hoTen;
            this.phai = phai;
            this.ngaySinh = ngaySinh;
            this.SDT = SDT;
            this.vaiTro = vaiTro;
            this.maDV = maDV;
            this.phuCap = phuCap;
        }
        
        public NhanSu(DataRow dataRow)
        {
            this.maNV = (string)dataRow["MANV"];
            this.hoten = (string)dataRow["HOTEN"];
            this.phai = (string)dataRow["PHAI"];
            DateTime ngSinh = Convert.ToDateTime(dataRow["NGSINH"]);
            this.ngaySinh = ngSinh.ToString("dd/MM/yyyy");
            this.SDT = (string)dataRow["SDT"];
            this.vaiTro = (string)dataRow["VAITRO"];
            this.maDV = (string)dataRow["MADV"];
            this.phuCap = Convert.ToInt32(dataRow["PHUCAP"]);
        }

        public static List<NhanSu> getNhanSu() {
            return DAONhanSu.getNhanSu();
        }

        public static NhanSu getCurrentNhanSu()
        {
            List<NhanSu> listNhanSu = getNhanSu();
            if (listNhanSu.Count == 1)
            {
                return listNhanSu[0];
            }
            return null;
        }

        public static bool updateSDT(string sdt)
        {
            return DAONhanSu.updateSDT(sdt);
        }

        public static DataTable getDataTableNhanSu()
        {
            return DAONhanSu.getDataTableNhanSu();
        }

        public static int updateNhanSu(NhanSu ns)
        {
            return DAONhanSu.updateNhanSu(ns);
        }
        public static bool deleteNhanSu(string id)
        {
            return DAONhanSu.deleteNhanSu(id);
        }
        public static int insertNhanSu(NhanSu ns)
        {
            return DAONhanSu.insertNhanSu(ns);
        }
    }
}
