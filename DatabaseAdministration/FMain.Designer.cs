﻿using System.Windows.Forms;

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
            this.tabPageColPrivs = new System.Windows.Forms.TabPage();
            this.dataGridViewColPrivs = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteCurrentRole = new System.Windows.Forms.Button();
            this.btnDeleteCurrentUser = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAudit = new System.Windows.Forms.Button();
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
            this.tabPageColPrivs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColPrivs)).BeginInit();
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
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
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
            this.dataGridViewRole.TabIndex = 0;
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
            this.tabControlPrivs.Controls.Add(this.tabPageColPrivs);
            this.tabControlPrivs.Location = new System.Drawing.Point(297, 17);
            this.tabControlPrivs.Name = "tabControlPrivs";
            this.tabControlPrivs.SelectedIndex = 0;
            this.tabControlPrivs.Size = new System.Drawing.Size(482, 470);
            this.tabControlPrivs.TabIndex = 0;
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
            this.dataGridViewTabPrivs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewTabPrivs_MouseDown);
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
            this.dataGridViewSysPrivs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewSysPrivs_MouseDown);
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
            this.dataGridViewRolePrivs.TabIndex = 0;
            this.dataGridViewRolePrivs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewRolePrivs_MouseDown);
            // 
            // tabPageColPrivs
            // 
            this.tabPageColPrivs.Controls.Add(this.dataGridViewColPrivs);
            this.tabPageColPrivs.Location = new System.Drawing.Point(4, 25);
            this.tabPageColPrivs.Name = "tabPageColPrivs";
            this.tabPageColPrivs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColPrivs.Size = new System.Drawing.Size(474, 441);
            this.tabPageColPrivs.TabIndex = 3;
            this.tabPageColPrivs.Text = "DBA_COL_PRIVS";
            this.tabPageColPrivs.UseVisualStyleBackColor = true;
            // 
            // dataGridViewColPrivs
            // 
            this.dataGridViewColPrivs.AllowUserToAddRows = false;
            this.dataGridViewColPrivs.AllowUserToDeleteRows = false;
            this.dataGridViewColPrivs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewColPrivs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewColPrivs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewColPrivs.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewColPrivs.MultiSelect = false;
            this.dataGridViewColPrivs.Name = "dataGridViewColPrivs";
            this.dataGridViewColPrivs.ReadOnly = true;
            this.dataGridViewColPrivs.RowHeadersWidth = 51;
            this.dataGridViewColPrivs.RowTemplate.Height = 24;
            this.dataGridViewColPrivs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewColPrivs.Size = new System.Drawing.Size(468, 435);
            this.dataGridViewColPrivs.TabIndex = 2;
            this.dataGridViewColPrivs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewColPrivs_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnAudit);
            this.panel2.Controls.Add(this.btnDeleteCurrentRole);
            this.panel2.Controls.Add(this.btnDeleteCurrentUser);
            this.panel2.Controls.Add(this.btnModify);
            this.panel2.Controls.Add(this.btnAddRole);
            this.panel2.Controls.Add(this.btnAddUser);
            this.panel2.Location = new System.Drawing.Point(800, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 490);
            this.panel2.TabIndex = 3;
            // 
            // btnDeleteCurrentRole
            // 
            this.btnDeleteCurrentRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCurrentRole.Location = new System.Drawing.Point(3, 250);
            this.btnDeleteCurrentRole.Name = "btnDeleteCurrentRole";
            this.btnDeleteCurrentRole.Size = new System.Drawing.Size(184, 46);
            this.btnDeleteCurrentRole.TabIndex = 5;
            this.btnDeleteCurrentRole.Text = "Delete Current Role";
            this.btnDeleteCurrentRole.UseVisualStyleBackColor = true;
            this.btnDeleteCurrentRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnDeleteCurrentUser
            // 
            this.btnDeleteCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteCurrentUser.Location = new System.Drawing.Point(3, 198);
            this.btnDeleteCurrentUser.Name = "btnDeleteCurrentUser";
            this.btnDeleteCurrentUser.Size = new System.Drawing.Size(184, 46);
            this.btnDeleteCurrentUser.TabIndex = 4;
            this.btnDeleteCurrentUser.Text = "Delete Current User";
            this.btnDeleteCurrentUser.UseVisualStyleBackColor = true;
            this.btnDeleteCurrentUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.Location = new System.Drawing.Point(3, 146);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(184, 46);
            this.btnModify.TabIndex = 3;
            this.btnModify.Text = "Modify Current";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
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
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
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
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
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
            // btnAudit
            // 
            this.btnAudit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAudit.Location = new System.Drawing.Point(3, 302);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(184, 46);
            this.btnAudit.TabIndex = 6;
            this.btnAudit.Text = "Audit";
            this.btnAudit.UseVisualStyleBackColor = true;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
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
            this.Text = "Database Administration";
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
            this.tabPageColPrivs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColPrivs)).EndInit();
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
        private Button btnDeleteCurrentUser;
        private Button btnModify;
        private Button btnAddRole;
        private Button btnAddUser;
        private Panel panel1;
        private DataGridView dataGridViewUser;
        private DataGridView dataGridViewRole;
        private DataGridView dataGridViewTabPrivs;
        private DataGridView dataGridViewSysPrivs;
        private DataGridView dataGridViewRolePrivs;
        private TabPage tabPageColPrivs;
        private DataGridView dataGridViewColPrivs;
        private Button btnDeleteCurrentRole;
        private Button btnAudit;
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