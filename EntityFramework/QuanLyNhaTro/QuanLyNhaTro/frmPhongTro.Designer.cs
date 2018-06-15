namespace QuanLyNhaTro
{
    partial class frmPhongTro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhongTro));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPhongTro = new System.Windows.Forms.ComboBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.dvgKH = new System.Windows.Forms.DataGridView();
            this.dvgDV = new System.Windows.Forms.DataGridView();
            this.MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTietDichVus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dvgPhieuThu = new System.Windows.Forms.DataGridView();
            this.MaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThangSuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDongThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPhieuThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ma Phong Tro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(222, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ten Phong Tro";
            // 
            // cbPhongTro
            // 
            this.cbPhongTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPhongTro.FormattingEnabled = true;
            this.cbPhongTro.Location = new System.Drawing.Point(125, 16);
            this.cbPhongTro.Name = "cbPhongTro";
            this.cbPhongTro.Size = new System.Drawing.Size(59, 24);
            this.cbPhongTro.TabIndex = 2;
            this.cbPhongTro.SelectedIndexChanged += new System.EventHandler(this.cbPhongTro_SelectedIndexChanged);
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenPhong.Enabled = false;
            this.txtTenPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenPhong.Location = new System.Drawing.Point(357, 16);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(132, 22);
            this.txtTenPhong.TabIndex = 3;
            // 
            // dvgKH
            // 
            this.dvgKH.AllowUserToAddRows = false;
            this.dvgKH.AllowUserToDeleteRows = false;
            this.dvgKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgKH.Location = new System.Drawing.Point(12, 386);
            this.dvgKH.Name = "dvgKH";
            this.dvgKH.ReadOnly = true;
            this.dvgKH.Size = new System.Drawing.Size(656, 211);
            this.dvgKH.TabIndex = 33;
            // 
            // dvgDV
            // 
            this.dvgDV.AllowUserToAddRows = false;
            this.dvgDV.AllowUserToDeleteRows = false;
            this.dvgDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDV,
            this.TenDV,
            this.GiaDV,
            this.ChiTietDichVus});
            this.dvgDV.Location = new System.Drawing.Point(357, 75);
            this.dvgDV.Name = "dvgDV";
            this.dvgDV.ReadOnly = true;
            this.dvgDV.Size = new System.Drawing.Size(311, 261);
            this.dvgDV.TabIndex = 34;
            // 
            // MaDV
            // 
            this.MaDV.DataPropertyName = "MaDV";
            this.MaDV.HeaderText = "MaDV";
            this.MaDV.Name = "MaDV";
            this.MaDV.ReadOnly = true;
            this.MaDV.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TenDV
            // 
            this.TenDV.DataPropertyName = "TenDV";
            this.TenDV.HeaderText = "TenDV";
            this.TenDV.Name = "TenDV";
            this.TenDV.ReadOnly = true;
            // 
            // GiaDV
            // 
            this.GiaDV.DataPropertyName = "GiaDV";
            this.GiaDV.HeaderText = "GiaDV";
            this.GiaDV.Name = "GiaDV";
            this.GiaDV.ReadOnly = true;
            // 
            // ChiTietDichVus
            // 
            this.ChiTietDichVus.DataPropertyName = "ChiTietDichVus";
            this.ChiTietDichVus.HeaderText = "ChiTietDichVus";
            this.ChiTietDichVus.Name = "ChiTietDichVus";
            this.ChiTietDichVus.ReadOnly = true;
            this.ChiTietDichVus.Visible = false;
            // 
            // dvgPhieuThu
            // 
            this.dvgPhieuThu.AllowUserToAddRows = false;
            this.dvgPhieuThu.AllowUserToDeleteRows = false;
            this.dvgPhieuThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPhieuThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieu,
            this.ThangSuDung,
            this.ThanhTien,
            this.NgayThanhToan,
            this.MaHD,
            this.HopDongThue});
            this.dvgPhieuThu.Location = new System.Drawing.Point(12, 75);
            this.dvgPhieuThu.Name = "dvgPhieuThu";
            this.dvgPhieuThu.ReadOnly = true;
            this.dvgPhieuThu.Size = new System.Drawing.Size(329, 261);
            this.dvgPhieuThu.TabIndex = 37;
            // 
            // MaPhieu
            // 
            this.MaPhieu.DataPropertyName = "MaPhieu";
            this.MaPhieu.HeaderText = "MaPhieu";
            this.MaPhieu.Name = "MaPhieu";
            this.MaPhieu.ReadOnly = true;
            // 
            // ThangSuDung
            // 
            this.ThangSuDung.DataPropertyName = "ThangSuDung";
            this.ThangSuDung.HeaderText = "ThangSuDung";
            this.ThangSuDung.Name = "ThangSuDung";
            this.ThangSuDung.ReadOnly = true;
            // 
            // ThanhTien
            // 
            this.ThanhTien.DataPropertyName = "ThanhTien";
            this.ThanhTien.HeaderText = "ThanhTien";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            // 
            // NgayThanhToan
            // 
            this.NgayThanhToan.DataPropertyName = "NgayThanhToan";
            this.NgayThanhToan.HeaderText = "NgayThanhToan";
            this.NgayThanhToan.Name = "NgayThanhToan";
            this.NgayThanhToan.ReadOnly = true;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            // 
            // HopDongThue
            // 
            this.HopDongThue.DataPropertyName = "HopDongThue";
            this.HopDongThue.HeaderText = "HopDongThue";
            this.HopDongThue.Name = "HopDongThue";
            this.HopDongThue.ReadOnly = true;
            this.HopDongThue.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(290, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Khach Hang";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.SystemColors.Control;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.Color.Black;
            this.btnReload.Location = new System.Drawing.Point(531, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(122, 36);
            this.btnReload.TabIndex = 39;
            this.btnReload.Text = "RELOAD";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // frmPhongTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(680, 610);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dvgPhieuThu);
            this.Controls.Add(this.dvgDV);
            this.Controls.Add(this.dvgKH);
            this.Controls.Add(this.txtTenPhong);
            this.Controls.Add(this.cbPhongTro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhongTro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPhongTro";
            this.Load += new System.EventHandler(this.frmPhongTro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPhieuThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPhongTro;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.DataGridView dvgKH;
        private System.Windows.Forms.DataGridView dvgDV;
        private System.Windows.Forms.DataGridView dvgPhieuThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThangSuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDongThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiTietDichVus;
    }
}