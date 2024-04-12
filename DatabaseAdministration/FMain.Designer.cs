using System.Windows.Forms;

namespace DatabaseAdministration
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageUser = new System.Windows.Forms.TabPage();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.tabPageRole = new System.Windows.Forms.TabPage();
            this.dataGridViewRole = new System.Windows.Forms.DataGridView();
            this.tabControlPrivs = new System.Windows.Forms.TabControl();
            this.tabPageTabPrivs = new System.Windows.Forms.TabPage();
            this.dataGridViewTabPrivs = new System.Windows.Forms.DataGridView();
            this.tabPageSysPrivs = new System.Windows.Forms.TabPage();
            this.dataGridViewSysPrivs = new System.Windows.Forms.DataGridView();
            this.tabPageRolePrivs = new System.Windows.Forms.TabPage();
            this.dataGridViewRolePrivs = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteCurrent = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.tabPageUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.tabPageRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRole)).BeginInit();
            this.tabControlPrivs.SuspendLayout();
            this.tabPageTabPrivs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabPrivs)).BeginInit();
            this.tabPageSysPrivs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSysPrivs)).BeginInit();
            this.tabPageRolePrivs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRolePrivs)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.tabPageUser);
            this.tabControl.Controls.Add(this.tabPageRole);
            this.tabControl.Location = new System.Drawing.Point(13, 17);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(282, 470);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageUser
            // 
            this.tabPageUser.Controls.Add(this.dataGridViewUser);
            this.tabPageUser.Location = new System.Drawing.Point(4, 25);
            this.tabPageUser.Name = "tabPageUser";
            this.tabPageUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUser.Size = new System.Drawing.Size(274, 441);
            this.tabPageUser.TabIndex = 0;
            this.tabPageUser.Text = "User";
            this.tabPageUser.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.AllowUserToAddRows = false;
            this.dataGridViewUser.AllowUserToDeleteRows = false;
            this.dataGridViewUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUser.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewUser.MultiSelect = false;
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.ReadOnly = true;
            this.dataGridViewUser.RowHeadersWidth = 51;
            this.dataGridViewUser.RowTemplate.Height = 24;
            this.dataGridViewUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUser.Size = new System.Drawing.Size(268, 435);
            this.dataGridViewUser.TabIndex = 0;
            this.dataGridViewUser.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewUser_CellMouseClick);
            // 
            // tabPageRole
            // 
            this.tabPageRole.Controls.Add(this.dataGridViewRole);
            this.tabPageRole.Location = new System.Drawing.Point(4, 25);
            this.tabPageRole.Name = "tabPageRole";
            this.tabPageRole.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRole.Size = new System.Drawing.Size(274, 441);
            this.tabPageRole.TabIndex = 1;
            this.tabPageRole.Text = "Role";
            this.tabPageRole.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRole
            // 
            this.dataGridViewRole.AllowUserToAddRows = false;
            this.dataGridViewRole.AllowUserToDeleteRows = false;
            this.dataGridViewRole.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRole.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRole.MultiSelect = false;
            this.dataGridViewRole.Name = "dataGridViewRole";
            this.dataGridViewRole.ReadOnly = true;
            this.dataGridViewRole.RowHeadersWidth = 51;
            this.dataGridViewRole.RowTemplate.Height = 24;
            this.dataGridViewRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRole.Size = new System.Drawing.Size(268, 435);
            this.dataGridViewRole.TabIndex = 1;
            this.dataGridViewRole.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewRole_CellMouseClick);
            // 
            // tabControlPrivs
            // 
            this.tabControlPrivs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPrivs.Controls.Add(this.tabPageTabPrivs);
            this.tabControlPrivs.Controls.Add(this.tabPageSysPrivs);
            this.tabControlPrivs.Controls.Add(this.tabPageRolePrivs);
            this.tabControlPrivs.Location = new System.Drawing.Point(297, 17);
            this.tabControlPrivs.Name = "tabControlPrivs";
            this.tabControlPrivs.SelectedIndex = 0;
            this.tabControlPrivs.Size = new System.Drawing.Size(482, 470);
            this.tabControlPrivs.TabIndex = 1;
            // 
            // tabPageTabPrivs
            // 
            this.tabPageTabPrivs.Controls.Add(this.dataGridViewTabPrivs);
            this.tabPageTabPrivs.Location = new System.Drawing.Point(4, 25);
            this.tabPageTabPrivs.Name = "tabPageTabPrivs";
            this.tabPageTabPrivs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTabPrivs.Size = new System.Drawing.Size(474, 441);
            this.tabPageTabPrivs.TabIndex = 0;
            this.tabPageTabPrivs.Text = "DBA_TAB_PRIVS";
            this.tabPageTabPrivs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTabPrivs
            // 
            this.dataGridViewTabPrivs.AllowUserToAddRows = false;
            this.dataGridViewTabPrivs.AllowUserToDeleteRows = false;
            this.dataGridViewTabPrivs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTabPrivs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTabPrivs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTabPrivs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTabPrivs.MultiSelect = false;
            this.dataGridViewTabPrivs.Name = "dataGridViewTabPrivs";
            this.dataGridViewTabPrivs.ReadOnly = true;
            this.dataGridViewTabPrivs.RowHeadersWidth = 51;
            this.dataGridViewTabPrivs.RowTemplate.Height = 24;
            this.dataGridViewTabPrivs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTabPrivs.Size = new System.Drawing.Size(468, 435);
            this.dataGridViewTabPrivs.TabIndex = 1;
            // 
            // tabPageSysPrivs
            // 
            this.tabPageSysPrivs.Controls.Add(this.dataGridViewSysPrivs);
            this.tabPageSysPrivs.Location = new System.Drawing.Point(4, 25);
            this.tabPageSysPrivs.Name = "tabPageSysPrivs";
            this.tabPageSysPrivs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSysPrivs.Size = new System.Drawing.Size(474, 441);
            this.tabPageSysPrivs.TabIndex = 1;
            this.tabPageSysPrivs.Text = "DBA_SYS_PRIVS";
            this.tabPageSysPrivs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewSysPrivs
            // 
            this.dataGridViewSysPrivs.AllowUserToAddRows = false;
            this.dataGridViewSysPrivs.AllowUserToDeleteRows = false;
            this.dataGridViewSysPrivs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSysPrivs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSysPrivs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSysPrivs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSysPrivs.MultiSelect = false;
            this.dataGridViewSysPrivs.Name = "dataGridViewSysPrivs";
            this.dataGridViewSysPrivs.ReadOnly = true;
            this.dataGridViewSysPrivs.RowHeadersWidth = 51;
            this.dataGridViewSysPrivs.RowTemplate.Height = 24;
            this.dataGridViewSysPrivs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSysPrivs.Size = new System.Drawing.Size(468, 435);
            this.dataGridViewSysPrivs.TabIndex = 1;
            // 
            // tabPageRolePrivs
            // 
            this.tabPageRolePrivs.Controls.Add(this.dataGridViewRolePrivs);
            this.tabPageRolePrivs.Location = new System.Drawing.Point(4, 25);
            this.tabPageRolePrivs.Name = "tabPageRolePrivs";
            this.tabPageRolePrivs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRolePrivs.Size = new System.Drawing.Size(474, 441);
            this.tabPageRolePrivs.TabIndex = 2;
            this.tabPageRolePrivs.Text = "DBA_ROLE_PRIVS";
            this.tabPageRolePrivs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRolePrivs
            // 
            this.dataGridViewRolePrivs.AllowUserToAddRows = false;
            this.dataGridViewRolePrivs.AllowUserToDeleteRows = false;
            this.dataGridViewRolePrivs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRolePrivs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRolePrivs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRolePrivs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRolePrivs.MultiSelect = false;
            this.dataGridViewRolePrivs.Name = "dataGridViewRolePrivs";
            this.dataGridViewRolePrivs.ReadOnly = true;
            this.dataGridViewRolePrivs.RowHeadersWidth = 51;
            this.dataGridViewRolePrivs.RowTemplate.Height = 24;
            this.dataGridViewRolePrivs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRolePrivs.Size = new System.Drawing.Size(468, 435);
            this.dataGridViewRolePrivs.TabIndex = 1;
            this.dataGridViewRolePrivs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewRolePrivs_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnDeleteCurrent);
            this.panel2.Controls.Add(this.btnHistory);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnAddRole);
            this.panel2.Controls.Add(this.btnAddUser);
            this.panel2.Location = new System.Drawing.Point(800, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 490);
            this.panel2.TabIndex = 3;
            // 
            // btnDeleteCurrent
            // 
            this.btnDeleteCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCurrent.Location = new System.Drawing.Point(3, 250);
            this.btnDeleteCurrent.Name = "btnDeleteCurrent";
            this.btnDeleteCurrent.Size = new System.Drawing.Size(184, 46);
            this.btnDeleteCurrent.TabIndex = 4;
            this.btnDeleteCurrent.Text = "Delete Current User/Role";
            this.btnDeleteCurrent.UseVisualStyleBackColor = true;
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Location = new System.Drawing.Point(3, 146);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(184, 46);
            this.btnHistory.TabIndex = 3;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(3, 198);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(184, 46);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update Current User/Role";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAddRole
            // 
            this.btnAddRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRole.Location = new System.Drawing.Point(3, 94);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(187, 46);
            this.btnAddRole.TabIndex = 1;
            this.btnAddRole.Text = "Add Role";
            this.btnAddRole.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.Location = new System.Drawing.Point(3, 42);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(187, 46);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Controls.Add(this.tabControlPrivs);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 490);
            this.panel1.TabIndex = 4;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.tabControl.ResumeLayout(false);
            this.tabPageUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.tabPageRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRole)).EndInit();
            this.tabControlPrivs.ResumeLayout(false);
            this.tabPageTabPrivs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTabPrivs)).EndInit();
            this.tabPageSysPrivs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSysPrivs)).EndInit();
            this.tabPageRolePrivs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRolePrivs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageUser;
        private System.Windows.Forms.TabPage tabPageRole;
        private TabControl tabControlPrivs;
        private TabPage tabPageTabPrivs;
        private TabPage tabPageSysPrivs;
        private TabPage tabPageRolePrivs;
        private Panel panel2;
        private Button btnDeleteCurrent;
        private Button btnHistory;
        private Button btnUpdate;
        private Button btnAddRole;
        private Button btnAddUser;
        private Panel panel1;
        private DataGridView dataGridViewUser;
        private DataGridView dataGridViewRole;
        private DataGridView dataGridViewTabPrivs;
        private DataGridView dataGridViewSysPrivs;
        private DataGridView dataGridViewRolePrivs;
    }

    public class TabButton : UserControl
    {
        private Button button;

        public TabButton()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            button = new Button();
            button.Dock = DockStyle.Fill;
            button.Text = "New Button";
            Controls.Add(button);
        }
    }
}