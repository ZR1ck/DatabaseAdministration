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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DatabaseAdministration
{
    public partial class FGrantPrivs : Form
    {
        public EventHandler dataUpdated;

        private DatabaseProvider provider = DatabaseProvider.getInstance();
        private string grantee;

        public FGrantPrivs(string grantee)
        {
            this.grantee = grantee;
            InitializeComponent();
            LoadTableName();
        }

        private void LoadTableName()
        {
            comboBoxTable.DataSource = provider.getAllTableName();
            comboBoxTable.DisplayMember = "TABLE_NAME";
            comboBoxPrivs.SelectedIndex = 0;
        }

        protected virtual void onPrivsUpdated(EventArgs eventArgs)
        {
            dataUpdated?.Invoke(this, eventArgs);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}
