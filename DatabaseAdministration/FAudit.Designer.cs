namespace DatabaseAdministration
{
    partial class FAudit
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
            this.tabControlAudit = new System.Windows.Forms.TabControl();
            this.tabPageFgaAuditTrail = new System.Windows.Forms.TabPage();
            this.tabPageAuditTrail = new System.Windows.Forms.TabPage();
            this.dataGridViewFgaAuditTrail = new System.Windows.Forms.DataGridView();
            this.dataGridViewAuditTrail = new System.Windows.Forms.DataGridView();
            this.tabControlAudit.SuspendLayout();
            this.tabPageFgaAuditTrail.SuspendLayout();
            this.tabPageAuditTrail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFgaAuditTrail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditTrail)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAudit
            // 
            this.tabControlAudit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAudit.Controls.Add(this.tabPageFgaAuditTrail);
            this.tabControlAudit.Controls.Add(this.tabPageAuditTrail);
            this.tabControlAudit.Location = new System.Drawing.Point(12, 12);
            this.tabControlAudit.Name = "tabControlAudit";
            this.tabControlAudit.SelectedIndex = 0;
            this.tabControlAudit.Size = new System.Drawing.Size(905, 461);
            this.tabControlAudit.TabIndex = 0;
            // 
            // tabPageFgaAuditTrail
            // 
            this.tabPageFgaAuditTrail.Controls.Add(this.dataGridViewFgaAuditTrail);
            this.tabPageFgaAuditTrail.Location = new System.Drawing.Point(4, 25);
            this.tabPageFgaAuditTrail.Name = "tabPageFgaAuditTrail";
            this.tabPageFgaAuditTrail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFgaAuditTrail.Size = new System.Drawing.Size(897, 432);
            this.tabPageFgaAuditTrail.TabIndex = 0;
            this.tabPageFgaAuditTrail.Text = "FgaAuditTrail";
            this.tabPageFgaAuditTrail.UseVisualStyleBackColor = true;
            // 
            // tabPageAuditTrail
            // 
            this.tabPageAuditTrail.Controls.Add(this.dataGridViewAuditTrail);
            this.tabPageAuditTrail.Location = new System.Drawing.Point(4, 25);
            this.tabPageAuditTrail.Name = "tabPageAuditTrail";
            this.tabPageAuditTrail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuditTrail.Size = new System.Drawing.Size(897, 432);
            this.tabPageAuditTrail.TabIndex = 1;
            this.tabPageAuditTrail.Text = "AuditTrail";
            this.tabPageAuditTrail.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFgaAuditTrail
            // 
            this.dataGridViewFgaAuditTrail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFgaAuditTrail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFgaAuditTrail.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewFgaAuditTrail.Name = "dataGridViewFgaAuditTrail";
            this.dataGridViewFgaAuditTrail.RowHeadersWidth = 51;
            this.dataGridViewFgaAuditTrail.RowTemplate.Height = 24;
            this.dataGridViewFgaAuditTrail.Size = new System.Drawing.Size(885, 420);
            this.dataGridViewFgaAuditTrail.TabIndex = 0;
            // 
            // dataGridViewAuditTrail
            // 
            this.dataGridViewAuditTrail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAuditTrail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAuditTrail.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewAuditTrail.Name = "dataGridViewAuditTrail";
            this.dataGridViewAuditTrail.RowHeadersWidth = 51;
            this.dataGridViewAuditTrail.RowTemplate.Height = 24;
            this.dataGridViewAuditTrail.Size = new System.Drawing.Size(885, 420);
            this.dataGridViewAuditTrail.TabIndex = 0;
            // 
            // FAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 485);
            this.Controls.Add(this.tabControlAudit);
            this.Name = "FAudit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FAudit";
            this.tabControlAudit.ResumeLayout(false);
            this.tabPageFgaAuditTrail.ResumeLayout(false);
            this.tabPageAuditTrail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFgaAuditTrail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditTrail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAudit;
        private System.Windows.Forms.TabPage tabPageFgaAuditTrail;
        private System.Windows.Forms.DataGridView dataGridViewFgaAuditTrail;
        private System.Windows.Forms.TabPage tabPageAuditTrail;
        private System.Windows.Forms.DataGridView dataGridViewAuditTrail;
    }
}