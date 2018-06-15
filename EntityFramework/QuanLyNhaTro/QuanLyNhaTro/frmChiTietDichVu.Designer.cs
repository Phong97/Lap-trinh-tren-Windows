namespace QuanLyNhaTro
{
    partial class frmChiTietDichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChiTietDichVu));
            this.pnThongTin = new System.Windows.Forms.Panel();
            this.lblHD = new System.Windows.Forms.Label();
            this.cbChiTietHD = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtNgaySuDung = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbMaDV = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dvg = new System.Windows.Forms.DataGridView();
            this.MaChiTietDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaChiTietHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDV = new System.Windows.Forms.Label();
            this.pnThongTin.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvg)).BeginInit();
            this.SuspendLayout();
            // 
            // pnThongTin
            // 
            this.pnThongTin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnThongTin.Controls.Add(this.lblDV);
            this.pnThongTin.Controls.Add(this.lblHD);
            this.pnThongTin.Controls.Add(this.cbChiTietHD);
            this.pnThongTin.Controls.Add(this.label1);
            this.pnThongTin.Controls.Add(this.dtNgaySuDung);
            this.pnThongTin.Controls.Add(this.btnUpdate);
            this.pnThongTin.Controls.Add(this.cbMaDV);
            this.pnThongTin.Controls.Add(this.label5);
            this.pnThongTin.Controls.Add(this.label6);
            this.pnThongTin.Controls.Add(this.txtMa);
            this.pnThongTin.Controls.Add(this.label7);
            this.pnThongTin.Location = new System.Drawing.Point(12, 12);
            this.pnThongTin.Name = "pnThongTin";
            this.pnThongTin.Size = new System.Drawing.Size(464, 145);
            this.pnThongTin.TabIndex = 3;
            // 
            // lblHD
            // 
            this.lblHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHD.Location = new System.Drawing.Point(272, 113);
            this.lblHD.Name = "lblHD";
            this.lblHD.Size = new System.Drawing.Size(78, 23);
            this.lblHD.TabIndex = 37;
            // 
            // cbChiTietHD
            // 
            this.cbChiTietHD.FormattingEnabled = true;
            this.cbChiTietHD.Location = new System.Drawing.Point(148, 114);
            this.cbChiTietHD.Name = "cbChiTietHD";
            this.cbChiTietHD.Size = new System.Drawing.Size(106, 21);
            this.cbChiTietHD.TabIndex = 36;
            this.cbChiTietHD.SelectedIndexChanged += new System.EventHandler(this.cbChiTietHD_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Ma Chi Tiet HD";
            // 
            // dtNgaySuDung
            // 
            this.dtNgaySuDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgaySuDung.Location = new System.Drawing.Point(148, 46);
            this.dtNgaySuDung.Name = "dtNgaySuDung";
            this.dtNgaySuDung.Size = new System.Drawing.Size(235, 22);
            this.dtNgaySuDung.TabIndex = 34;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(370, 87);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 38);
            this.btnUpdate.TabIndex = 33;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbMaDV
            // 
            this.cbMaDV.FormattingEnabled = true;
            this.cbMaDV.Location = new System.Drawing.Point(148, 80);
            this.cbMaDV.Name = "cbMaDV";
            this.cbMaDV.Size = new System.Drawing.Size(106, 21);
            this.cbMaDV.TabIndex = 5;
            this.cbMaDV.SelectedIndexChanged += new System.EventHandler(this.cbMaDV_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ma DV";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ngay Su Dung";
            // 
            // txtMa
            // 
            this.txtMa.Enabled = false;
            this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(148, 14);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(57, 22);
            this.txtMa.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ma Chi Tiet DV";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbSearch);
            this.panel1.Controls.Add(this.btnReload);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnInsert);
            this.panel1.Location = new System.Drawing.Point(12, 172);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 48);
            this.panel1.TabIndex = 34;
            // 
            // cbSearch
            // 
            this.cbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(326, 9);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(106, 24);
            this.cbSearch.TabIndex = 37;
            this.cbSearch.Text = "All Search";
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(207, 7);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(90, 30);
            this.btnReload.TabIndex = 18;
            this.btnReload.Text = "RELOAD";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(107, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(6, 7);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(90, 30);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "INSERT";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dvg
            // 
            this.dvg.AllowUserToAddRows = false;
            this.dvg.AllowUserToDeleteRows = false;
            this.dvg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChiTietDV,
            this.NgaySuDung,
            this.MaDV,
            this.MaChiTietHD});
            this.dvg.Location = new System.Drawing.Point(17, 226);
            this.dvg.Name = "dvg";
            this.dvg.ReadOnly = true;
            this.dvg.Size = new System.Drawing.Size(454, 249);
            this.dvg.TabIndex = 35;
            this.dvg.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvg_CellClick);
            // 
            // MaChiTietDV
            // 
            this.MaChiTietDV.DataPropertyName = "MaChiTietDV";
            this.MaChiTietDV.HeaderText = "MaChiTietDV";
            this.MaChiTietDV.Name = "MaChiTietDV";
            this.MaChiTietDV.ReadOnly = true;
            // 
            // NgaySuDung
            // 
            this.NgaySuDung.DataPropertyName = "NgaySuDung";
            this.NgaySuDung.HeaderText = "NgaySuDung";
            this.NgaySuDung.Name = "NgaySuDung";
            this.NgaySuDung.ReadOnly = true;
            this.NgaySuDung.Width = 130;
            // 
            // MaDV
            // 
            this.MaDV.DataPropertyName = "MaDV";
            this.MaDV.HeaderText = "MaDV";
            this.MaDV.Name = "MaDV";
            this.MaDV.ReadOnly = true;
            // 
            // MaChiTietHD
            // 
            this.MaChiTietHD.DataPropertyName = "MaChiTietHD";
            this.MaChiTietHD.HeaderText = "MaChiTietHD";
            this.MaChiTietHD.Name = "MaChiTietHD";
            this.MaChiTietHD.ReadOnly = true;
            // 
            // lblDV
            // 
            this.lblDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDV.Location = new System.Drawing.Point(272, 80);
            this.lblDV.Name = "lblDV";
            this.lblDV.Size = new System.Drawing.Size(92, 23);
            this.lblDV.TabIndex = 38;
            // 
            // frmChiTietDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 487);
            this.Controls.Add(this.dvg);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnThongTin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChiTietDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmChiTietDichVu";
            this.Load += new System.EventHandler(this.frmChiTietDichVu_Load);
            this.pnThongTin.ResumeLayout(false);
            this.pnThongTin.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnThongTin;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbMaDV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbChiTietHD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtNgaySuDung;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dvg;
        private System.Windows.Forms.Label lblHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTietDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTietHD;
        private System.Windows.Forms.Label lblDV;
    }
}