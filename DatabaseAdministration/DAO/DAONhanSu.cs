﻿using DatabaseAdministration.DataProvider;
using DatabaseAdministration.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DAO
{
    internal class DAONhanSu
    {
        public static List<NhanSu> getNhanSu()
        {
            List<NhanSu> listNhanSu = new List<NhanSu>();

            DataTable data = DatabaseProvider.getInstance().getNhanSu();
            foreach (DataRow row in data.Rows)
            {
                listNhanSu.Add(new NhanSu(row));
            }
            return listNhanSu;
        }

        public static bool updateSDT(string sdt)
        {
            return DatabaseProvider.getInstance().updateSDTNhanSuCaNhan(sdt);
        }

        public static DataTable getDataTableNhanSu()
        {
            return DatabaseProvider.getInstance().getNhanSu();
        }
        public static int updateNhanSu(NhanSu ns)
        {
            return DatabaseProvider.getInstance().updateNhanSu(ns);
        }
        public static bool deleteNhanSu(string id)
        {
            return DatabaseProvider.getInstance().deleteNhanSu(id);
        }
        public static int insertNhanSu(NhanSu ns)
        {
            return DatabaseProvider.getInstance().insertNhanSu(ns);
        }
    }
}
