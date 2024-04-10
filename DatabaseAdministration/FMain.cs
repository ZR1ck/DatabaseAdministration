using DatabaseAdministration.DataProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAdministration
{
    public partial class FMain : Form
    {
        DatabaseProvider databaseProvider = DatabaseProvider.getInstance();
        public FMain()
        {
            InitializeComponent();
            LoadUsersAndRoles();
        }

        private void LoadUsersAndRoles()
        {
            dataGridViewUser.DataSource = databaseProvider.getUsers();
            dataGridViewRole.DataSource = databaseProvider.getRole();
        }

        private void LoadPrivs(string grantee)
        {
            dataGridViewTabPrivs.DataSource = databaseProvider.getTabPrivs(grantee);
            dataGridViewSysPrivs.DataSource = databaseProvider.getSysPrivs(grantee);
            dataGridViewRolePrivs.DataSource = databaseProvider.getRolePrivs(grantee);
        }

        private void dataGridViewUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Right click
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get cell location
                Point cellLocation = dataGridViewUser.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                cellLocation.X += cellLocation.X / 2;

                // Get cell data
                string cellValue = dataGridViewUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // ContextMenuStrip
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                ToolStripMenuItem privs = new ToolStripMenuItem("Grant privilege");
                privs.Click += (s, args) =>
                {
                    // Handle grant privs click
                    MessageBox.Show("Grant privilege");
                };

                ToolStripMenuItem role = new ToolStripMenuItem("Grant role");
                role.Click += (s, args) =>
                {
                    // Handle grant role click
                    MessageBox.Show("Grant role");
                };

                contextMenu.Items.Add(privs);
                contextMenu.Items.Add(role);

                contextMenu.Show(dataGridViewUser, cellLocation);
            }
            // Left click
            else if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string cellValue = dataGridViewUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                LoadPrivs(cellValue);
            }
        }

        private void dataGridViewRole_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Right click
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get cell location
                Point cellLocation = dataGridViewRole.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                cellLocation.X += cellLocation.X / 2;

                // Get cell data
                string cellValue = dataGridViewRole.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // ContextMenuStrip
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                ToolStripMenuItem privs = new ToolStripMenuItem("Grant privilege");
                privs.Click += (s, args) =>
                {
                    // Handle grant privs click
                    MessageBox.Show("Grant privilege");
                };

                ToolStripMenuItem role = new ToolStripMenuItem("Grant role");
                role.Click += (s, args) =>
                {
                    // Handle grant role click
                    MessageBox.Show("Grant role");
                };

                contextMenu.Items.Add(privs);
                contextMenu.Items.Add(role);

                contextMenu.Show(dataGridViewRole, cellLocation);
            }
            // Left click
            else if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string cellValue = dataGridViewRole.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                LoadPrivs(cellValue);
            }
        }

        private void dataGridViewRolePrivs_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGridViewRolePrivs.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dataGridViewRolePrivs.ClearSelection();
                    dataGridViewRolePrivs.Rows[currentMouseOverRow].Selected = true;

                    string grantee = dataGridViewRolePrivs.Rows[currentMouseOverRow].Cells["GRANTEE"].Value.ToString();
                    string grantedRole = dataGridViewRolePrivs.Rows[currentMouseOverRow].Cells["GRANTED_ROLE"].Value.ToString();

                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    ToolStripMenuItem privs = new ToolStripMenuItem("Revoke privilege");
                    privs.Click += (s, args) =>
                    {
                        // Handle revoke privs click
                        MessageBox.Show("revoke privilege" + grantee + " " + grantedRole);
                    };
                    contextMenu.Items.Add(privs);
                    contextMenu.Show(dataGridViewRolePrivs, new Point(e.X, e.Y));
                }
            }
        }
    }
}
