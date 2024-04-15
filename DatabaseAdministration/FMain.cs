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
        string currentChecked = null;
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
            dataGridViewColPrivs.DataSource = databaseProvider.getColsPrivs(grantee);
        }

        private void dataGridViewUser_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clickUserAndRoleEvent(dataGridViewUser, e);
        }

        private void dataGridViewRole_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clickUserAndRoleEvent(dataGridViewRole, e);
        }

        private void dataGridViewTabPrivs_MouseDown(object sender, MouseEventArgs e)
        {
            privsClickEvent(dataGridViewTabPrivs, e);
        }

        private void dataGridViewSysPrivs_MouseDown(object sender, MouseEventArgs e)
        {
            privsClickEvent(dataGridViewSysPrivs, e);
        }

        private void dataGridViewRolePrivs_MouseDown(object sender, MouseEventArgs e)
        {
            privsClickEvent(dataGridViewRolePrivs, e);
        }

        private void dataGridViewColPrivs_MouseDown(object sender, MouseEventArgs e)
        {
            privsClickEvent(dataGridViewColPrivs, e);
        }



        // Callback after grant new priv
        private void mainGridDataUpdated(object sender, EventArgs e)
        {
            LoadPrivs(currentChecked);
        }




        // Handle users role click (grant privileges, grant roles, show current privileges)
        private void clickUserAndRoleEvent(DataGridView dataGrid, DataGridViewCellMouseEventArgs e)
        {
            // Right click
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get cell location
                Point cellLocation = dataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                cellLocation.X += cellLocation.X / 2;

                // Get cell data (user)
                string cellValue = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                currentChecked = cellValue;

                // ContextMenuStrip
                ContextMenuStrip contextMenu = new ContextMenuStrip();

                ToolStripMenuItem privs = new ToolStripMenuItem("Grant privilege");
                privs.Click += (s, args) =>
                {
                    // Handle grant privs click
                    FGrantPrivs fUserGrantPrivs = new FGrantPrivs();
                    fUserGrantPrivs.setGrantee(cellValue);
                    fUserGrantPrivs.dataUpdated += mainGridDataUpdated;
                    fUserGrantPrivs.ShowDialog();
                };

                ToolStripMenuItem role = new ToolStripMenuItem("Grant role");
                role.Click += (s, args) =>
                {
                    // Handle grant role click
                    FGrantRole fGrantRole = new FGrantRole();
                    fGrantRole.setUser(cellValue);
                    fGrantRole.dataUpdated += mainGridDataUpdated;
                    fGrantRole.ShowDialog();

                };

                contextMenu.Items.Add(privs);
                contextMenu.Items.Add(role);

                contextMenu.Show(dataGrid, cellLocation);
            }
            // Left click
            else if (e.Button == MouseButtons.Left && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string cellValue = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                LoadPrivs(cellValue);
            }
        }

        // Handle privs click (revoke privileges)
        private void privsClickEvent(DataGridView dataGrid, MouseEventArgs e)
        {
            // Right click
            if (e.Button == MouseButtons.Right)
            {
                int currentMouseOverRow = dataGrid.HitTest(e.X, e.Y).RowIndex;
                if (currentMouseOverRow >= 0)
                {
                    dataGrid.ClearSelection();
                    dataGrid.Rows[currentMouseOverRow].Selected = true;

                    string grantee = dataGrid.Rows[currentMouseOverRow].Cells["GRANTEE"].Value.ToString();

                    string revokeType = null;
                    if (dataGrid.Equals(dataGridViewTabPrivs))
                    {
                        revokeType = "PRIVILEGE";
                    }
                    else if (dataGrid.Equals(dataGridViewSysPrivs))
                    {
                        revokeType = "PRIVILEGE";
                    }
                    else if (dataGrid.Equals(dataGridViewRolePrivs))
                    {
                        revokeType = "GRANTED_ROLE";
                    }
                    else if (dataGrid.Equals(dataGridViewColPrivs))
                    {
                        revokeType = "PRIVILEGE";
                    }
                    // (select, insert, update, delete)
                    string revoke = dataGrid.Rows[currentMouseOverRow].Cells[revokeType].Value.ToString();
                    string owner = null;

                    // table name (nullable)
                    string tableName = null;
                    try
                    {
                        tableName = dataGrid.Rows[currentMouseOverRow].Cells["TABLE_NAME"].Value.ToString();
                        owner = dataGrid.Rows[currentMouseOverRow].Cells["OWNER"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                    ContextMenuStrip contextMenu = new ContextMenuStrip();
                    ToolStripMenuItem privs = new ToolStripMenuItem("Revoke privilege");
                    privs.Click += (s, args) =>
                    {
                        // Handle revoke privs click
                        if (databaseProvider.revokePrivs(grantee, revoke, owner, tableName))
                        {
                            MessageBox.Show("Revoked");
                            LoadPrivs(this.currentChecked);
                        }
                        else
                        {
                            MessageBox.Show("Revoke Failed");
                        }
                    };
                    contextMenu.Items.Add(privs);
                    contextMenu.Show(dataGrid, new Point(e.X, e.Y));
                }
            }
        }


    }
}
