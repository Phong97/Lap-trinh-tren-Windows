using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.IO;

namespace QuanLyNhaTro
{
    /// <summary>
    /// Quản lý khách hàng
    /// thêm xóa sửa
    /// tìm kiếm theo tên hoặc giới tính
    /// </summary>
    public partial class frmKhachHang : Form
    {
        private byte[] img = null; //image
        private int insert = 0; //cờ insert
        QuanLyNhaTroContainer context;//đối tượng kết nối

        //khởi tạo
        public frmKhachHang()
        {
            InitializeComponent();
        }

        //loaddata
        private int LoadData()
        {
            try
            {
                context = new QuanLyNhaTroContainer(); //kết nối
                //đổ dữ liệu lên datagridView Khách hàng
                dvg.DataSource = (from s in context.KhachHangs
                                 select new { s.MaKhach, 
                                     s.TenKhach, 
                                     s.CMND, 
                                     s.GioiTinh,
                                     s.DiaChiKhach, 
                                     s.NgheNghiep, 
                                     s.SdtKhach,
                                     s.HinhAnhKH }).Distinct().ToList();

                //thao tác các nút lệnh
                dvg.Focus();
                txtMaKH.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = true;
                dvg.Enabled = true;
                Reset();
            }
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;//lỗi
            };
            return 1;//thành công
        }

        //form load
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //sự kiện click nút ChangeAvatar
        private void btnChangeAvatar_Click(object sender, EventArgs e)
        {
            try
            {
                //mở hộp thoại
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "All Picture Files (*.jpg,*.bmp,*.gif)|*.jpg;*.bmp;*.gif";
                dlg.Title = "Select SinhVien Picture";

                //nếu chọn ảnh
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string imgLoc = dlg.FileName.ToString(); //lấy địa chỉ
                    FileStream fs = new FileStream(imgLoc, FileMode.Open,
                          FileAccess.Read); //đọc ảnh
                    BinaryReader br = new BinaryReader(fs); //đọc nhị phân
                    img = br.ReadBytes((int)fs.Length); //đọc ra mảng nhị phân

                    var image = Image.FromFile(imgLoc); //lấy ảnh
                    var temp = new Bitmap(image, new Size(150, 130)); //tạo ảnh bitmap từ image
                    picHinhAnh.Image = temp;//thêm ảnh vào pictureBox
                }
            }//end try
            catch (Exception) //lỗi
            {
                MessageBox.Show("Lỗi!", "Lỗi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sự kiện CellClick cho datagridView
        private void dvg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;//bật btnUpdate

            try
            {
                int r = dvg.CurrentCell.RowIndex; //dòng đang chọn

                //truyền dữ liệu
                txtMaKH.Text = dvg.Rows[r].Cells[0].Value.ToString();
                txtTenKH.Text = dvg.Rows[r].Cells[1].Value.ToString();
                txtCMND.Text = dvg.Rows[r].Cells[2].Value.ToString();
                txtGioiTinh.Text = dvg.Rows[r].Cells[3].Value.ToString().ToUpper();
                txtDiaChi.Text = dvg.Rows[r].Cells[4].Value.ToString();
                txtNgheNghiep.Text = dvg.Rows[r].Cells[5].Value.ToString();
                txtSDT.Text = dvg.Rows[r].Cells[6].Value.ToString();

                try
                {
                    img = (byte[])(dvg.Rows[r].Cells[7].Value); //đọc ra mảng nhị phân

                    //kiểm tra đọc có hay không
                    if (img == null)
                        picHinhAnh.Image = null;
                    else
                    {
                        MemoryStream ms = new MemoryStream(img); //chuyển lại thành hình ảnh nhớ
                        picHinhAnh.Image = new Bitmap(Image.FromStream(ms),
                            new Size(150, 130)); //show ảnh lên
                    }
                }//end try
                catch(Exception)
                {
                    //
                }
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        //sự kiện TextChanged txtSearch
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search(); 
            txtSearch.Focus();
        }

        //sự kiện SelectedIndexChanged cho cbxSearch
        private void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
            txtSearch.Focus();
        }

        //Search 
        private void Search()
        {
            LoadData();
            string var = cbxSearch.Text; // lấy item đã chọn trong cbxSearch

            if (var.Equals("TenKH")) //chọn item TenKH
            {
                /*lấy tên khách hàng từ txtSearch tìm trong khách hàng
                 * đổ lên datagridView*/
                dvg.DataSource = (from s in context.KhachHangs
                                  select new
                                  {
                                      s.MaKhach,
                                      s.TenKhach,
                                      s.CMND,
                                      s.GioiTinh,
                                      s.DiaChiKhach,
                                      s.NgheNghiep,
                                      s.SdtKhach,
                                      s.HinhAnhKH
                                  }).Distinct()
                                    .ToList()
                                    .FindAll(k => k.TenKhach.Equals(txtSearch.Text.ToString()));
            }//
            else if (var.Equals("GioiTinh"))//chọn item GioiTinh
            {
                /*lấy giới tính khách hàng từ txtSearch tìm trong khách hàng
                 * đổ lên datagridView*/
                dvg.DataSource = (from s in context.KhachHangs
                                 select new { 
                                     s.MaKhach,
                                     s.TenKhach, 
                                     s.CMND, 
                                     s.GioiTinh,
                                     s.DiaChiKhach, 
                                     s.NgheNghiep, 
                                     s.SdtKhach, 
                                     s.HinhAnhKH }).Distinct()
                                     .ToList()
                                     .FindAll(k => k.GioiTinh.Equals(txtSearch.Text.ToString().ToUpper()));
            }//
            else//load Data
            {
                LoadData();
            }
        }

        //sự kiện Click cho nút Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            if (LoadData() == 1)// nếu loaddata thành công thì thông báo thành công 
                MessageBox.Show("Thanh cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //reset text
        private void Reset()
        {
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtCMND.ResetText();
            txtGioiTinh.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
            txtNgheNghiep.ResetText();
            picHinhAnh.Image = null;
        }

        //sự kiện Click cho nút Insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //thao tác với nút lệnh
            dvg.Enabled = false;
            txtMaKH.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
            insert = 1;//bật cờ insert

            Reset();
        }

        //sự kiện Click cho nút Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //thao tac su kien
                dvg.Enabled = true;
                txtMaKH.Enabled = false;
                btnDelete.Enabled = true;

                //lay du lieu
                int maKH = Int32.Parse(txtMaKH.Text.ToString());
                string tenKH = txtTenKH.Text.ToString();
                int soCMND = Int32.Parse(txtCMND.Text.ToString());
                string gioiTinh = txtGioiTinh.Text.ToString().ToUpper();
                string diaChi = txtDiaChi.Text.ToString();
                string ngheNghiep = txtNgheNghiep.Text.ToString();
                decimal sdt = Decimal.Parse(txtSDT.Text.ToString());


                if (insert == 0)//insert
                {
                    try
                    {
                        var kh = context.KhachHangs
                            .Where(s => s.MaKhach == maKH).First(); //tìm khách hàng tương ứng
                        //gán lại giá trị
                        kh.TenKhach = tenKH;
                        kh.CMND = soCMND;
                        kh.GioiTinh = gioiTinh;
                        kh.DiaChiKhach = diaChi;
                        kh.NgheNghiep = ngheNghiep;
                        kh.SdtKhach = sdt;
                        kh.HinhAnhKH = img;
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;
                    }//end catch
                }//end if
                else//update
                {
                    try
                    {
                        KhachHang kh = new KhachHang(); //tạo
                        //gán giá trị
                        kh.MaKhach = maKH;
                        kh.TenKhach = tenKH;
                        kh.GioiTinh = gioiTinh;
                        kh.HinhAnhKH = img;
                        kh.NgheNghiep = ngheNghiep;
                        kh.SdtKhach = sdt;
                        kh.CMND = soCMND;
                        kh.DiaChiKhach = diaChi;
                        context.KhachHangs.Add(kh);//thêm khách hàng vừa tạo
                        context.SaveChanges();//lưu

                        //thêm hợp đồng không
                        DialogResult traLoi = MessageBox.Show("Ban co muon them Hop dong thue khong?", "Hoi",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (traLoi == DialogResult.Yes)
                        {
                            var hd = new frmHopDongThue();
                            hd.ShowDialog();
                        }
                    }//end try
                    catch (Exception)
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;
                    }//end catch
                    insert = 0;//tắt cờ 
                }//end else

                context.SaveChanges();//lưu
                //thông báo thành công
                MessageBox.Show("Thanh cong!", "Thong bao",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end if
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        //sự kiện Click cho nút Delete
        /*trước khi xóa khách hàng phải xóa chi tiết dịch vụ, 
         * chi tiết hợp đồng, phiếu thanh toán và hợp đồng thuê*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int maKH = Int32.Parse(txtMaKH.Text.ToString());//lấy mã khách hàng
                //tìm hợp đồng
                var hd = context.HopDongThues.Where(s => s.MaKH == maKH);
                foreach(var temp in hd)
                {
                    //tìm phiếu thanh toán
                    var phieuThanhToan = context.PhieuThanhToans.Where(s => s.MaHD == temp.MaHD);
                    foreach(var temp1 in phieuThanhToan)
                    {
                        context.PhieuThanhToans.Remove(temp1); //remove phiếu thanh toán tìm được
                    }

                    //tìm chi tiết hợp đồng
                    var chiTietHD = context.ChiTietHopDongs.Where(s => s.MaHD == temp.MaHD);
                    foreach(var temp2 in chiTietHD)
                    {
                        //tìm chi tiết dịch vụ
                        var chiTietDV = context.ChiTietDichVus.Where(s => s.MaChiTietHD == temp2.MaChiTietHD);
                        foreach(var temp3 in chiTietDV)
                        {
                            context.ChiTietDichVus.Remove(temp3);//remove chi tiết dịch vụ
                        }

                        //remove chi tiết hợp đồng
                        context.ChiTietHopDongs.Remove(temp2);
                    }

                    //remove hợp đồng thuê
                    context.HopDongThues.Remove(temp);
                }

                //tìm khách hàng
                var kh = context.KhachHangs.Where(s => s.MaKhach == maKH).First();
                context.KhachHangs.Remove(kh);//remove khách hàng 
                context.SaveChanges();//lưu
                //thông báo thành công
                MessageBox.Show("Thanh cong!", "Thong bao",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end if
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadData();
        }
    }
}
