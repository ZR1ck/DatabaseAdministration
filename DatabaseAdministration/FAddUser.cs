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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DatabaseAdministration
{
    public partial class FAddUser : Form
    {
        public EventHandler updateUserTab;
        public FAddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usernameInput = textBox1.Text;
            string passwordInput = textBox2.Text;
            string connectionString = LoginHelper.getInstance().ConnectionString;

            if (usernameInput.Length == 0)
            {
                MessageBox.Show("Username must not be left empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (passwordInput.Length == 0)
            {
                MessageBox.Show("Password must not be left empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    using (OracleConnection connection = new OracleConnection(connectionString))
                    {
                        connection.Open();

                        string sql = "CREATE USER " + usernameInput + " IDENTIFIED BY " + passwordInput;
                        using (OracleCommand command = new OracleCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("User created successfully!");
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

        }

        protected virtual void onUpdated(EventArgs eventArgs)
        {
            updateUserTab?.Invoke(this, eventArgs);
        }
    }
}