namespace sa
{
    partial class frmDangkyPhongban
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
            this.dgvDSN = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSN)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDSN
            // 
            this.dgvDSN.AllowUserToAddRows = false;
            this.dgvDSN.AllowUserToDeleteRows = false;
            this.dgvDSN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSN.Location = new System.Drawing.Point(0, 0);
            this.dgvDSN.MultiSelect = false;
            this.dgvDSN.Name = "dgvDSN";
            this.dgvDSN.ReadOnly = true;
            this.dgvDSN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSN.Size = new System.Drawing.Size(800, 450);
            this.dgvDSN.TabIndex = 0;
            this.dgvDSN.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSN_CellDoubleClick);
            // 
            // frmDangkyPhongban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDSN);
            this.Name = "frmDangkyPhongban";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách phòng ban";
            this.Load += new System.EventHandler(this.frmDangkyPhongban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSN;
    }
}