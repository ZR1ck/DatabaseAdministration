using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAdministration.DTO
{
    internal class DonVi
    {
        private string maDV, tenDV, trgDV;

        public DonVi(string maDV, string tenDV, string trgDV)
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.trgDV = trgDV;
        }
    }
}
