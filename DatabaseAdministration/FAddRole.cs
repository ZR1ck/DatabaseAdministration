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

            if (rolenameInput.Length == 0)
            {
                MessageBox.Show("Empty input", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (DatabaseProvider.getInstance().addRole(rolenameInput))
            {
                MessageBox.Show("Role created successfully!");
                onUpdated(EventArgs.Empty);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Cannot create role", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected virtual void onUpdated(EventArgs eventArgs)
        {
            updateRoleTab?.Invoke(this, eventArgs);
        }
    }
}