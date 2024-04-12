using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseAdministration.DataProvider;

namespace DatabaseAdministration
{
    public partial class FGrantPrivs : Form
    {
        DatabaseProvider databaseProvider = DatabaseProvider.getInstance();
        string grantee;
        string priv;
        string schema;
        string table;
        string column;
        public FGrantPrivs()
        {
            InitializeComponent();
        }

        public void setGrantee(string grantee)
        {
            this.grantee = grantee;
        }

        private void loadColumns()
        {
            if (table != null)
            {
                DataTable columnsData = databaseProvider.getColumnNames(schema, table);
                List<string> columnList = new List<string>();
                columnList = (from DataRow dr in columnsData.Rows select dr[0].ToString()).ToList();
                columnsCbBox.DataSource = columnList;
            }
        }

        private void FGrantPrivs_Load(object sender, EventArgs e)
        {
            DataTable schemaData = databaseProvider.getSchema();
            List<string> schemaList = new List<string>();
            schemaList = (from DataRow dr in schemaData.Rows select dr[0].ToString()).ToList();
            schemaCbBox.DataSource = schemaList;
            columnsCbBox.Enabled = false;
        }

        private void privsCbBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            priv = privsCbBox.SelectedItem.ToString();
            if(priv.Equals("SELECT") || priv.Equals("UPDATE"))
            {
                columnsCbBox.Enabled = true;
                loadColumns();
            } else
            {
                columnsCbBox.Enabled = false;
                column = null;
                columnsCbBox.DataSource = null;
            }
        }

        private void schemaCbBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            schema = schemaCbBox.SelectedItem.ToString();
            DataTable tablesData = databaseProvider.getTableNames(schema);
            List<string> tableList = new List<string>();
            tableList = (from DataRow dr in tablesData.Rows select dr[0].ToString()).ToList() ;
            tablesCbBox.DataSource = tableList;
        }

        private void tablesCbBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            table = tablesCbBox.SelectedItem.ToString();
            if(columnsCbBox.Enabled)
            {
                loadColumns();
            }
        }

        private void columnsCbBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            column = columnsCbBox.SelectedItem.ToString();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if(priv == "SELECT" || priv == "UPDATE")
            {
                if(priv == null || schema == null || table == null || column == null)
                {
                    MessageBox.Show("There is unselected field");
                }
                else if(databaseProvider.grantPriv(priv, schema, table, column, grantee, withGrantOptionCheck.Checked))
                {
                    MessageBox.Show("Grant success");
                } else
                {
                    MessageBox.Show("Grant failed");
                }
            } else
            {
                if (priv == null || schema == null || table == null)
                {
                    MessageBox.Show("There is unselected field");
                }
                else if (databaseProvider.grantPriv(priv, schema, table, grantee, withGrantOptionCheck.Checked))
                {
                    MessageBox.Show("Grant success");
                }
                else
                {
                    MessageBox.Show("Grant failed");
                }
            }
        }
    }
}
