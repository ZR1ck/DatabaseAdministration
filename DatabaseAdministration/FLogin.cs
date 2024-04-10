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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string hostName = TxtHostName.Text;
            string serviceName = TxtServiceName.Text;
            string password = TxtPassword.Text;
            string username = TxtUsername.Text;

            if (string.IsNullOrEmpty(hostName) || string.IsNullOrEmpty(serviceName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Empty field.");
                return;
            }

            LoginHelper helper = LoginHelper.getInstance();
            if (helper.connectionCheck(hostName, serviceName, username, password))
            {
                this.Hide();
                FMain fMain = new FMain();
                fMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
