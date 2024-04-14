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
    public partial class FTableCols : Form
    {
        private string schema, table;
        public List<string> Result { get; private set; }
        public FTableCols(string schema, string table)
        {
            InitializeComponent();
            this.schema = schema;
            this.table = table;
            loadCols();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Result = getCols();
            if (Result != null )
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Select at least one");
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private List<string> getCols()
        {
            List<string> selectedValues = new List<string>();

            foreach (string item in checkedListBoxTableCols.CheckedItems)
            {
                selectedValues.Add(item);
            }
            return selectedValues;
        }

        private void loadCols()
        {
            DataTable columnsData = DatabaseProvider.getInstance().getColumnNames(this.schema, this.table);
            List<string> columnList = new List<string>();
            columnList = (from DataRow dr in columnsData.Rows select dr[0].ToString()).ToList();

            foreach (string s in columnList)
            {
                checkedListBoxTableCols.Items.Add(s);
            }
        }
    }
}
