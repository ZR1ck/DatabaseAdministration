using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseAdministration.DataProvider;

namespace DatabaseAdministration
{
    public partial class FGrantRole : Form
    {
        DatabaseProvider databaseProvider = DatabaseProvider.getInstance();
        string user;
        string role;
        public FGrantRole()
        {
            InitializeComponent();
        }

        public void setUser(string user)
        {
            this.user = user;
        }
        private void FGrantRole_Load(object sender, EventArgs e)
        {
            DataTable roleTable = databaseProvider.getRole();
            List<string> roleList = new List<string>();
            roleList = (from DataRow dr in roleTable.Rows select dr[0].ToString()).ToList();
            rolesCbBox.DataSource = roleList;
        }

        private void rolesCbBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            role = rolesCbBox.SelectedItem.ToString();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if(role == null)
            {
                MessageBox.Show("Role is unselected");
            } else
            {
                if(databaseProvider.grantRole(role, user))
                {
                    MessageBox.Show("Grant sucess");
                } else
                {
                    MessageBox.Show("Grant failed");
                }
            }
        }
    }
}
