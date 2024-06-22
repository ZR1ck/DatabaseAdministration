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
            comboBoxRole.SelectedIndex = 0;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string hostName = TxtHostName.Text;
            string serviceName = TxtServiceName.Text;
            string password = TxtPassword.Text;
            string username = TxtUsername.Text;
            int role = comboBoxRole.SelectedIndex;

            if (string.IsNullOrEmpty(hostName) || string.IsNullOrEmpty(serviceName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Empty field.");
                return;
            }

            LoginHelper helper = LoginHelper.getInstance();
            int connStatus = helper.connectionCheck(hostName, serviceName, username, password, role);
            if (connStatus == LoginHelper.OK)
            {
                this.Hide();
                if (role == 0)
                {
                    FMain fMain = new FMain();
                    fMain.ShowDialog();
                }
                else
                {
                    FUsersMain fUsersMain = new FUsersMain(role);
                    fUsersMain.ShowDialog();
                }
                this.Show();
            }
            else if (connStatus == LoginHelper.PDB)
            {
                this.Hide();
                FPDBOLS fMain = new FPDBOLS();
                fMain.ShowDialog();
                this.Show();
            }
            else if (connStatus == LoginHelper.INVALID_INFO)
            {
                MessageBox.Show("Invalid username or password.");
            }
            else if (connStatus == LoginHelper.INVALID_ROLE)
            {
                MessageBox.Show("Invalid role.");
            }
            else if (connStatus == LoginHelper.ERROR)
            {
                MessageBox.Show("Something went wrong :(.");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtServiceName_Leave(object sender, EventArgs e)
        {
            if (!TxtServiceName.Text.Equals("xe"))
            {
                comboBoxRole.SelectedIndex = -1;
                comboBoxRole.Enabled = false;
            }
            else
            {
                comboBoxRole.SelectedIndex = 0;
                comboBoxRole.Enabled = true;
            }
        }
    }
}
