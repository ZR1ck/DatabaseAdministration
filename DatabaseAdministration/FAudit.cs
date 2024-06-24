using DatabaseAdministration.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAdministration
{
    public partial class FAudit : Form
    {
        public FAudit()
        {
            InitializeComponent();
            dataGridViewFgaAuditTrail.DataSource = DatabaseProvider.getInstance().getFGAAuditTrail();
            dataGridViewAuditTrail.DataSource = DatabaseProvider.getInstance().getAuditTrail();
        }
    }
}
