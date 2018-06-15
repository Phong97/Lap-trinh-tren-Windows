using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro
{
    /// <summary>
    /// Quản lý Phiếu Thanh toán
    /// thêm xóa sửa
    /// tìm kiếm theo tháng hoặc hợp đồng
    /// đồng thời tính tổng tiền cho mục tìm được
    /// </summary>
    public partial class frmPhieuThanhToan : Form
    {
        private int insert = 0; //cờ insert
        QuanLyNhaTroContainer context;//đối tượng kết nối
        decimal tien;//tổng tiền
        //khởi tạo
        public frmPhieuThanhToan()
        {
            InitializeComponent();
        }

            //reset text
        private void Reset()
        {
            txtMa.ResetText();
            cbMaHD.ResetText();
            dtNgayThanhToan.ResetText();
            txtThangSuDung.ResetText();
            txtThanhTien.ResetText();
            lblKH.ResetText();
        }

        //load data
        private int LoadData()
        {
            try
            {
                context = new QuanLyNhaTroContainer(); //kết nối
                //lấy dữ liệu phiếu thanh toán đổ lên
                dvg.DataSource = (from s in context.PhieuThanhToans
                                  select new
                                  {
                                      s.MaPhieu,
                                      s.ThangSuDung,
                                      s.ThanhTien,
                                      s.NgayThanhToan,
                                      s.MaHD
                                  }).Distinct().ToList();
                cbMaHD.Items.Clear();//remove hết các item trong cbMaHD

                //thêm item cho cbMaHD
                var maHD = context.HopDongThues.Select(s => s.MaHD);//lấy mã hợp đồng
                foreach (var temp in maHD)
                {
                    cbMaHD.Items.Add(temp.ToString());//add
                }

                tien = 0;//gán tiền = 0
                //thao tác với nút lệnh
                dvg.Focus();
                txtMa.Enabled = false;
                btnUpdate.Enabled = false;
                bntTien.Enabled = false;
                btnDelete.Enabled = true;
                dvg.Enabled = true;
                Reset();
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;//lỗi
            };

            return 1;//thành công
        }

        //sự kiện form load
        private void frmPhieuThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //sự kiện Click cho nút Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            if (LoadData() == 1)// nếu loaddata thành công thì thông báo thành công 
                MessageBox.Show("Thanh cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //sự kiện SelectedIndexChanged cho nút cbMaHD
        private void cbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maHD = Int32.Parse(cbMaHD.Text);//lấy mã hợp đồng

            lblKH.Text = "Khach Hang " + context.HopDongThues
                .Where(s => s.MaHD == maHD).First().MaKH.ToString();//tìm mã khách hàng tương ứng

            //tính tiền
            decimal tien = 0;
            try
            {
                int maPhong = context.ChiTietHopDongs
                    .Where(s => s.MaHD == maHD).First().MaPhong;//tìm mã phòng tương ứng mã hợp đồng
                int maLoai = context.PhongTroes
                    .Where(s => s.MaPhong == s.MaPhong).First().MaLoaiPhong;//tìm mã loại phòng tương ứng mã phòng
                decimal tienPhong = Decimal.Parse(context.LoaiPhongs
                    .Where(s => s.MaLoaiPhong == maLoai).First().GiaPhong.ToString()); //tiền phòng tính từ tiền loại phòng
                tien = tien + tienPhong; //cộng vào tổng tiền

                int maChiTietHD = context.ChiTietHopDongs
                    .Where(s => s.MaHD == maHD).First().MaChiTietHD;//tìm mã chi tiết hợp đồng
                var maDV = context.ChiTietDichVus
                    .Where(s => s.MaChiTietHD == maChiTietHD).Select(s => s.MaDV);//danh sách mã dịch vụ tương ứng

                //cộng tiền từng dịch vụ lại
                foreach (var temp in maDV)
                {
                    tienPhong = 0;//=0
                    tienPhong = Decimal.Parse(context.DichVus
                        .Where(s => s.MaDV == temp).First().GiaDV.ToString());//tiền dịch vụ
                    if (tienPhong != 0)//nếu dùng dịch vụ thì cộng vào tổng tiền
                        tien += tienPhong;
                }
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //hiện tổng tiền lên
            txtThanhTien.Text = tien.ToString();
        }

        //sự kiện Click cho nút Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int maPhieu = Int32.Parse(txtMa.Text);//lấy mã phiếu thu

                var phieuThu = context.PhieuThanhToans
                    .Where(s => s.MaPhieu == maPhieu).First();//tìm phiếu thu tương ứng
                context.PhieuThanhToans.Remove(phieuThu);//remove phiếu thu
                context.SaveChanges();//lưu
                //thông báo thành công
                MessageBox.Show("Thanh cong!", "Thong bao",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        //sự kiện Click cho nút Insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //thao tac nút lệnh
            dvg.Enabled = false;
            txtMa.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
            insert = 1;//bật cờ insert

            Reset();
        }

        //sự kiện click cho nút update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tien = 0;//tiền = 0

                //thao tác với nút lệnh
                dvg.Enabled = true;
                txtMa.Enabled = false;
                btnDelete.Enabled = true;

                //lấy dữ liệu
                int maPhieu = Int32.Parse(txtMa.Text.ToString());
                DateTime ngayThanhToan = dtNgayThanhToan.Value;
                int thangSuDung = Int32.Parse(txtThangSuDung.Text.ToString());
                int maHD = Int32.Parse(cbMaHD.Text.ToString());
                tien = Decimal.Parse(txtThanhTien.Text.ToString());

                if (insert == 0)//update
                {
                    try
                    {
                        var phieuThu = context.PhieuThanhToans
                            .Where(s => s.MaPhieu == maPhieu).First();//tìm phiếu thanh toán
                        //cập nhập giá trị
                        phieuThu.NgayThanhToan = ngayThanhToan;
                        phieuThu.ThangSuDung = thangSuDung;
                        phieuThu.ThanhTien = tien;
                        phieuThu.MaHD = maHD;
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;
                    }//end cathch
                }//end if
                else//insert
                {
                    try
                    {
                        PhieuThanhToan phieuThu = new PhieuThanhToan();//tạo
                        //gán trị
                        phieuThu.MaPhieu = maPhieu;
                        phieuThu.NgayThanhToan = dtNgayThanhToan.Value;
                        phieuThu.ThangSuDung = Int32.Parse(txtThangSuDung.Text);
                        phieuThu.ThanhTien = tien;
                        phieuThu.MaHD = Int32.Parse(cbMaHD.Text);
                        context.PhieuThanhToans.Add(phieuThu);//thêm
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;
                    }//end catch
                    insert = 0;//tắt cờ insert
                }


                context.SaveChanges();//lưu
                //thông báo thành công
                MessageBox.Show("Thanh cong!", "Thong bao",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        //sự kiện cellClick cho datagridView
        private void dvg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;//bật nút Update

            try
            {
                int r = dvg.CurrentCell.RowIndex; //dòng đang chọn

                //truyền dữ liệu
                txtMa.Text = dvg.Rows[r].Cells[0].Value.ToString();
                txtThangSuDung.Text = dvg.Rows[r].Cells[1].Value.ToString();
                txtThanhTien.Text = dvg.Rows[r].Cells[2].Value.ToString();
                dtNgayThanhToan.Text = dvg.Rows[r].Cells[3].Value.ToString();
                cbMaHD.Text = dvg.Rows[r].Cells[4].Value.ToString();
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        //search
        private void Search()
        {
            LoadData();
            bntTien.Enabled = true;//bật nút Tiền
            string var = cbSearch.Text;//lấy item đã chọn
            int ma;//mã
            try
            {
                ma = Int32.Parse(txtSearch.Text.ToString());//lấy mã
            }//end try
            catch(Exception)
            {
                dvg.DataSource = null;//mã không hợp lệ không tìm thấy
                return;
            }

            if (var.Equals("MaHD"))//item MaHD
            {
                //tìm dữ liệu phiếu thanh toán
                var dsPhieuThanhToan = (from s in context.PhieuThanhToans
                                  select new
                                  {
                                      s.MaPhieu,
                                      s.ThangSuDung,
                                      s.ThanhTien,
                                      s.NgayThanhToan,
                                      s.MaHD
                                  }).Distinct()
                                    .ToList().FindAll(k => k.MaHD == ma);

                tien += Decimal.Parse(dsPhieuThanhToan
                    .Sum(s => s.ThanhTien).ToString());//tính tổng tiền
                dvg.DataSource = dsPhieuThanhToan;//đổ dữ liệu lên
            }//end if
            else if (var.Equals("Thang"))//item Thang
            {
                //tìm dữ liệu phiếu thanh toán
                var dsPhieuThanhToan = (from s in context.PhieuThanhToans
                                  select new
                                  {
                                      s.MaPhieu,
                                      s.ThangSuDung,
                                      s.ThanhTien,
                                      s.NgayThanhToan,
                                      s.MaHD
                                  }).Distinct()
                                     .ToList().FindAll(k => k.ThangSuDung == ma);

                tien += Decimal.Parse(dsPhieuThanhToan
                    .Sum(s => s.ThanhTien).ToString());//tính tổng tiền
                dvg.DataSource = dsPhieuThanhToan;//đổ dữ liệu lên
            }//end else
            else//ngược lại
            {
                LoadData();
            }
        }

        //sự kiện cbSearch_SelectedIndexChanged
        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
            txtSearch.Focus();
        }

        //sự kiện txtSearch_TextChanged
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
            txtSearch.Focus();
        }

        //sự kiện click cho nút Tien
        /*đưa ra thông báo*/
        private void bntTien_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tong so tien: " + tien.ToString() + " $", "Tong tien",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
