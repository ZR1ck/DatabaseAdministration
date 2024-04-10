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
    public partial class FTableCols : Form
    {
        public List<string> SelectedItems { get; private set; }

        private string tableName;
        public FTableCols(string tableName)
        {
            InitializeComponent();
            SelectedItems = new List<string>();
            this.tableName = tableName;
            loadList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewCols.CheckedItems)
            {
                if (item.Checked)
                {
                    SelectedItems.Add(item.Text);
                }
            }
            if (SelectedItems == null || SelectedItems.Count <= 0)
            {
                MessageBox.Show("Select at least one option");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void loadList()
        {
            listViewCols.Clear();
            DataTable dataTable = DatabaseProvider.getInstance().getTableColsName(this.tableName);

            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                listViewCols.Items.Add(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
