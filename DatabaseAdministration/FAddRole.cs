using DatabaseAdministration.DataProvider;
using Oracle.ManagedDataAccess.Client;
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
    public partial class FAddRole : Form
    {
        public EventHandler updateRoleTab;
        public FAddRole()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rolenameInput = textBox1.Text;
            string connectionString = LoginHelper.getInstance().ConnectionString;
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string sql = "CREATE ROLE " + rolenameInput;
                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Role created successfully!");
                        onUpdated(EventArgs.Empty);
                    }

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        protected virtual void onUpdated(EventArgs eventArgs)
        {
            updateRoleTab?.Invoke(this, eventArgs);
        }
    }
}