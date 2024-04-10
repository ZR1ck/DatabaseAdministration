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

        private bool grantPrivs(string grantee)
        {

            if (comboBoxPrivs.SelectedIndex != -1 && comboBoxTable.SelectedIndex != -1)
            {
                string priv = comboBoxPrivs.Text;
                string tableName = comboBoxTable.Text;
                bool grantOpt = checkBoxGrantOpt.Checked;
                List<string> selectedCols = null;
                // Selete, Update
                if (comboBoxPrivs.SelectedIndex == 0 || comboBoxPrivs.SelectedIndex == 1)
                {
                    using (FTableCols tableCols = new FTableCols(tableName))
                    {
                        DialogResult dialogResult = tableCols.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            selectedCols = tableCols.SelectedItems;
                            if (selectedCols.Count <= 0 || selectedCols == null) { return false; }
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            return false;
                        }
                    }
                }
                // Insert, Delete
                return provider.grantPrivs(priv, tableName, grantee, grantOpt, selectedCols);
            }
            return false;
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
            if (grantPrivs(this.grantee))
            {
                MessageBox.Show("Grant Succeeded");
                onPrivsUpdated(EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
