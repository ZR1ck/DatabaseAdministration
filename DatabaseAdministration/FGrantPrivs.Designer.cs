namespace DatabaseAdministration
{
    partial class FGrantPrivs
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
            this.label1 = new System.Windows.Forms.Label();
            this.privsCbBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tablesCbBox = new System.Windows.Forms.ComboBox();
            this.withGrantOptionCheck = new System.Windows.Forms.CheckBox();
            this.OKBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.columnsCbBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.schemaCbBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select privilege";
            // 
            // privsCbBox
            // 
            this.privsCbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.privsCbBox.FormattingEnabled = true;
            this.privsCbBox.Items.AddRange(new object[] {
            "SELECT",
            "INSERT",
            "UPDATE",
            "DELETE"});
            this.privsCbBox.Location = new System.Drawing.Point(180, 35);
            this.privsCbBox.Name = "privsCbBox";
            this.privsCbBox.Size = new System.Drawing.Size(146, 24);
            this.privsCbBox.TabIndex = 1;
            this.privsCbBox.SelectionChangeCommitted += new System.EventHandler(this.privsCbBox_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Table";
            // 
            // tablesCbBox
            // 
            this.tablesCbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tablesCbBox.FormattingEnabled = true;
            this.tablesCbBox.Location = new System.Drawing.Point(180, 69);
            this.tablesCbBox.Name = "tablesCbBox";
            this.tablesCbBox.Size = new System.Drawing.Size(146, 24);
            this.tablesCbBox.TabIndex = 3;
            this.tablesCbBox.SelectionChangeCommitted += new System.EventHandler(this.tablesCbBox_SelectionChangeCommitted);
            // 
            // withGrantOptionCheck
            // 
            this.withGrantOptionCheck.AutoSize = true;
            this.withGrantOptionCheck.Location = new System.Drawing.Point(53, 113);
            this.withGrantOptionCheck.Name = "withGrantOptionCheck";
            this.withGrantOptionCheck.Size = new System.Drawing.Size(132, 20);
            this.withGrantOptionCheck.TabIndex = 4;
            this.withGrantOptionCheck.Text = "With Grant Option";
            this.withGrantOptionCheck.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(383, 157);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(68, 27);
            this.OKBtn.TabIndex = 5;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(468, 157);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(87, 27);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(355, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Columns";
            // 
            // columnsCbBox
            // 
            this.columnsCbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnsCbBox.FormattingEnabled = true;
            this.columnsCbBox.Location = new System.Drawing.Point(427, 69);
            this.columnsCbBox.Name = "columnsCbBox";
            this.columnsCbBox.Size = new System.Drawing.Size(128, 24);
            this.columnsCbBox.TabIndex = 8;
            this.columnsCbBox.SelectionChangeCommitted += new System.EventHandler(this.columnsCbBox_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(355, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Schema";
            // 
            // schemaCbBox
            // 
            this.schemaCbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schemaCbBox.FormattingEnabled = true;
            this.schemaCbBox.Location = new System.Drawing.Point(427, 35);
            this.schemaCbBox.Name = "schemaCbBox";
            this.schemaCbBox.Size = new System.Drawing.Size(128, 24);
            this.schemaCbBox.TabIndex = 10;
            this.schemaCbBox.SelectionChangeCommitted += new System.EventHandler(this.schemaCbBox_SelectionChangeCommitted);
            // 
            // FGrantPrivs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 196);
            this.Controls.Add(this.schemaCbBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.columnsCbBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.withGrantOptionCheck);
            this.Controls.Add(this.tablesCbBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.privsCbBox);
            this.Controls.Add(this.label1);
            this.Name = "FGrantPrivs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grant privilege";
            this.Load += new System.EventHandler(this.FGrantPrivs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox privsCbBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tablesCbBox;
        private System.Windows.Forms.CheckBox withGrantOptionCheck;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox columnsCbBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox schemaCbBox;
    }
}