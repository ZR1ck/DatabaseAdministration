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

            if (usernameInput.Length == 0)
            {
                MessageBox.Show("Username must not be left empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (passwordInput.Length == 0)
            {
                MessageBox.Show("Password must not be left empty", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int i = DatabaseProvider.getInstance().addUser(usernameInput, passwordInput);
            switch (i)
            {
                case 0:
                    MessageBox.Show("User created successfully!");
                    onUpdated(EventArgs.Empty);
                    this.DialogResult = DialogResult.OK;
                    break;
                case 1:
                    MessageBox.Show("Username only contains valid characters (a - z, A - Z) and numbers (0 - 9)", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 2:
                    MessageBox.Show("Password only contains valid characters (a - z, A - Z) and numbers (0 - 9)", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case 3:
                    MessageBox.Show("Cannot create user", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }

        protected virtual void onUpdated(EventArgs eventArgs)
        {
            updateUserTab?.Invoke(this, eventArgs);
        }
    }
}