namespace DatabaseAdministration
{
    partial class FLogin
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
            this.lHostName = new System.Windows.Forms.Label();
            this.lServiceName = new System.Windows.Forms.Label();
            this.lUsername = new System.Windows.Forms.Label();
            this.lPassword = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.TxtServiceName = new System.Windows.Forms.TextBox();
            this.TxtHostName = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lHostName
            // 
            this.lHostName.AutoSize = true;
            this.lHostName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHostName.Location = new System.Drawing.Point(71, 28);
            this.lHostName.Name = "lHostName";
            this.lHostName.Size = new System.Drawing.Size(89, 18);
            this.lHostName.TabIndex = 0;
            this.lHostName.Text = "Host Name:";
            // 
            // lServiceName
            // 
            this.lServiceName.AutoSize = true;
            this.lServiceName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lServiceName.Location = new System.Drawing.Point(71, 72);
            this.lServiceName.Name = "lServiceName";
            this.lServiceName.Size = new System.Drawing.Size(111, 18);
            this.lServiceName.TabIndex = 0;
            this.lServiceName.Text = "Service Name:";
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUsername.Location = new System.Drawing.Point(71, 116);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(84, 18);
            this.lUsername.TabIndex = 0;
            this.lUsername.Text = "Username:";
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPassword.Location = new System.Drawing.Point(71, 160);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(81, 18);
            this.lPassword.TabIndex = 0;
            this.lPassword.Text = "Password:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBoxRole);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TxtPassword);
            this.panel1.Controls.Add(this.TxtUsername);
            this.panel1.Controls.Add(this.TxtServiceName);
            this.panel1.Controls.Add(this.TxtHostName);
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Controls.Add(this.BtnOK);
            this.panel1.Controls.Add(this.lHostName);
            this.panel1.Controls.Add(this.lPassword);
            this.panel1.Controls.Add(this.lServiceName);
            this.panel1.Controls.Add(this.lUsername);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 310);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Items.AddRange(new object[] {
            "Admin",
            "Sinh viên",
            "Nhân viên",
            "Giáo vụ",
            "Giảng viên",
            "Trưởng đơn vị",
            "Trưởng khoa"});
            this.comboBoxRole.Location = new System.Drawing.Point(214, 200);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(121, 24);
            this.comboBoxRole.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role:";
            // 
            // TxtPassword
            // 
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TxtPassword.Location = new System.Drawing.Point(214, 158);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(213, 25);
            this.TxtPassword.TabIndex = 4;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // TxtUsername
            // 
            this.TxtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsername.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TxtUsername.Location = new System.Drawing.Point(214, 114);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(213, 25);
            this.TxtUsername.TabIndex = 3;
            this.TxtUsername.Text = "sys";
            // 
            // TxtServiceName
            // 
            this.TxtServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtServiceName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TxtServiceName.Location = new System.Drawing.Point(214, 70);
            this.TxtServiceName.Name = "TxtServiceName";
            this.TxtServiceName.Size = new System.Drawing.Size(213, 25);
            this.TxtServiceName.TabIndex = 2;
            this.TxtServiceName.Text = "xe";
            // 
            // TxtHostName
            // 
            this.TxtHostName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtHostName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TxtHostName.Location = new System.Drawing.Point(214, 26);
            this.TxtHostName.Name = "TxtHostName";
            this.TxtHostName.Size = new System.Drawing.Size(213, 25);
            this.TxtHostName.TabIndex = 1;
            this.TxtHostName.Text = "localhost";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.BtnCancel.Location = new System.Drawing.Point(280, 263);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(116, 27);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.BtnOK.Location = new System.Drawing.Point(100, 263);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(116, 27);
            this.BtnOK.TabIndex = 6;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 334);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection Infomation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lHostName;
        private System.Windows.Forms.Label lServiceName;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.TextBox TxtServiceName;
        private System.Windows.Forms.TextBox TxtHostName;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label label1;
    }
}

