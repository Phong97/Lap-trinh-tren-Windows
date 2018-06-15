namespace QuanLyNhaTro
{
    partial class frmNhaTro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhaTro));
            this.dvgNhaTro = new System.Windows.Forms.DataGridView();
            this.MaTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReload = new System.Windows.Forms.Button();
            this.lblNhaTro = new System.Windows.Forms.Label();
            this.lblPhongTro = new System.Windows.Forms.Label();
            this.dvgPhongTro = new System.Windows.Forms.DataGridView();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongNguoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienTich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dvgThietBi = new System.Windows.Forms.DataGridView();
            this.MaThietBi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenThietBi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvgNhaTro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPhongTro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgThietBi)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgNhaTro
            // 
            this.dvgNhaTro.AllowUserToAddRows = false;
            this.dvgNhaTro.AllowUserToDeleteRows = false;
            this.dvgNhaTro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgNhaTro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTro,
            this.DiaChi,
            this.DoanhThu});
            this.dvgNhaTro.Location = new System.Drawing.Point(16, 44);
            this.dvgNhaTro.Name = "dvgNhaTro";
            this.dvgNhaTro.ReadOnly = true;
            this.dvgNhaTro.Size = new System.Drawing.Size(344, 124);
            this.dvgNhaTro.TabIndex = 0;
            this.dvgNhaTro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgNhaTro_CellClick);
            // 
            // MaTro
            // 
            this.MaTro.DataPropertyName = "MaNhaTro";
            this.MaTro.HeaderText = "MaNhaTro";
            this.MaTro.Name = "MaTro";
            this.MaTro.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "DiaChi";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // DoanhThu
            // 
            this.DoanhThu.DataPropertyName = "DoanhThu";
            this.DoanhThu.HeaderText = "DoanhThu";
            this.DoanhThu.Name = "DoanhThu";
            this.DoanhThu.ReadOnly = true;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(405, 75);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(122, 57);
            this.btnReload.TabIndex = 19;
            this.btnReload.Text = "RELOAD";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblNhaTro
            // 
            this.lblNhaTro.AutoSize = true;
            this.lblNhaTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaTro.Location = new System.Drawing.Point(15, 15);
            this.lblNhaTro.Name = "lblNhaTro";
            this.lblNhaTro.Size = new System.Drawing.Size(77, 20);
            this.lblNhaTro.TabIndex = 20;
            this.lblNhaTro.Text = "Nha Tro:";
            // 
            // lblPhongTro
            // 
            this.lblPhongTro.AutoSize = true;
            this.lblPhongTro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhongTro.Location = new System.Drawing.Point(15, 173);
            this.lblPhongTro.Name = "lblPhongTro";
            this.lblPhongTro.Size = new System.Drawing.Size(96, 20);
            this.lblPhongTro.TabIndex = 21;
            this.lblPhongTro.Text = "Phong Tro:";
            // 
            // dvgPhongTro
            // 
            this.dvgPhongTro.AllowUserToAddRows = false;
            this.dvgPhongTro.AllowUserToDeleteRows = false;
            this.dvgPhongTro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPhongTro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhong,
            this.TenPhong,
            this.SoLuongNguoi,
            this.MaLoaiPhong,
            this.TenLoaiPhong,
            this.DienTich,
            this.GiaPhong});
            this.dvgPhongTro.Location = new System.Drawing.Point(11, 198);
            this.dvgPhongTro.Name = "dvgPhongTro";
            this.dvgPhongTro.ReadOnly = true;
            this.dvgPhongTro.Size = new System.Drawing.Size(545, 150);
            this.dvgPhongTro.TabIndex = 22;
            this.dvgPhongTro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgPhongTro_CellClick);
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "MaPhong";
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.ReadOnly = true;
            // 
            // TenPhong
            // 
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.HeaderText = "TenPhong";
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.ReadOnly = true;
            // 
            // SoLuongNguoi
            // 
            this.SoLuongNguoi.DataPropertyName = "SoLuongNguoi";
            this.SoLuongNguoi.HeaderText = "SoLuongNguoi";
            this.SoLuongNguoi.Name = "SoLuongNguoi";
            this.SoLuongNguoi.ReadOnly = true;
            // 
            // MaLoaiPhong
            // 
            this.MaLoaiPhong.DataPropertyName = "MaLoaiPhong";
            this.MaLoaiPhong.HeaderText = "MaLoaiPhong";
            this.MaLoaiPhong.Name = "MaLoaiPhong";
            this.MaLoaiPhong.ReadOnly = true;
            // 
            // TenLoaiPhong
            // 
            this.TenLoaiPhong.DataPropertyName = "TenLoaiPhong";
            this.TenLoaiPhong.HeaderText = "TenLoaiPhong";
            this.TenLoaiPhong.Name = "TenLoaiPhong";
            this.TenLoaiPhong.ReadOnly = true;
            // 
            // DienTich
            // 
            this.DienTich.DataPropertyName = "DienTich";
            this.DienTich.HeaderText = "DienTich";
            this.DienTich.Name = "DienTich";
            this.DienTich.ReadOnly = true;
            // 
            // GiaPhong
            // 
            this.GiaPhong.DataPropertyName = "GiaPhong";
            this.GiaPhong.HeaderText = "GiaPhong";
            this.GiaPhong.Name = "GiaPhong";
            this.GiaPhong.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Thiet Bi:";
            // 
            // dvgThietBi
            // 
            this.dvgThietBi.AllowUserToAddRows = false;
            this.dvgThietBi.AllowUserToDeleteRows = false;
            this.dvgThietBi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgThietBi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaThietBi,
            this.TenThietBi,
            this.ThoiDiem});
            this.dvgThietBi.Location = new System.Drawing.Point(114, 384);
            this.dvgThietBi.Name = "dvgThietBi";
            this.dvgThietBi.ReadOnly = true;
            this.dvgThietBi.Size = new System.Drawing.Size(343, 132);
            this.dvgThietBi.TabIndex = 24;
            // 
            // MaThietBi
            // 
            this.MaThietBi.DataPropertyName = "MaThietBi";
            this.MaThietBi.HeaderText = "MaThietBi";
            this.MaThietBi.Name = "MaThietBi";
            this.MaThietBi.ReadOnly = true;
            // 
            // TenThietBi
            // 
            this.TenThietBi.DataPropertyName = "TenThietBi";
            this.TenThietBi.HeaderText = "TenThietBi";
            this.TenThietBi.Name = "TenThietBi";
            this.TenThietBi.ReadOnly = true;
            // 
            // ThoiDiem
            // 
            this.ThoiDiem.DataPropertyName = "ThoiDiem";
            this.ThoiDiem.HeaderText = "ThoiDiem";
            this.ThoiDiem.Name = "ThoiDiem";
            this.ThoiDiem.ReadOnly = true;
            // 
            // frmNhaTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 526);
            this.Controls.Add(this.dvgThietBi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dvgPhongTro);
            this.Controls.Add(this.lblPhongTro);
            this.Controls.Add(this.lblNhaTro);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.dvgNhaTro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNhaTro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNhaTro";
            this.Load += new System.EventHandler(this.frmNhaTro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgNhaTro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPhongTro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgThietBi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgNhaTro;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lblNhaTro;
        private System.Windows.Forms.Label lblPhongTro;
        private System.Windows.Forms.DataGridView dvgPhongTro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dvgThietBi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongNguoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienTich;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaThietBi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenThietBi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiDiem;
    }
}