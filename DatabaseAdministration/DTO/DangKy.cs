using DatabaseAdministration.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class DangKy
    {
        public string maSV {  get; set; }
        public string maGV {  get; set; }
        public string maHP {  get; set; }
        public string HK {  get; set; }
        public string maCT { get; set; }
        public int nam {  get; set; }
        public double diemTH { get; set; }
        public double diemQT { get; set; }
        public double diemCK { get; set; }
        public double diemTK { get; set; }

        public DangKy(string maSV, string maGV, string maHP, string hK, string maCT, int nam, double diemTH, double diemQT, double diemCK, double diemTK)
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

        public static DataTable getDataTableDangKi()
        {
            return DAODangKy.getDataTableDangKi();
        }

        public static int updateDangKy(DangKy dk)
        {
            return DAODangKy.updateDangKy(dk);
        }

        public static int deleteDangKy(DangKy dk)
        {
            return DAODangKy.deleteDangKy(dk);
        }

        public static int insertDangKy(DangKy dk)
        {
            return DAODangKy.insertDangKy(dk);
        }
    }
}
