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
    /// Quản lý Nhà Trọ
    /// Form chức năng giao diện của chương trình
    /// gồm các menu chức năng
    /// </summary>
    public partial class frmQuanLyNhaTro : Form
    {
        private TaiKhoan taiKhoan;//tài khoản
        //khởi tạo
        public frmQuanLyNhaTro(TaiKhoan tk)
        {
            taiKhoan = tk;//tài khoản đang đăng nhập
            InitializeComponent();
        }

        //cập nhập số lượng người phòng trọ và doanh thu nhà trọ
        private void CapNhapDuLieu()
        {
            try
            {
                QuanLyNhaTroContainer context = new QuanLyNhaTroContainer();
                //doanh thu
                var dsNhaTro = context.NhaTroes.ToList();
                foreach (var nhaTro in dsNhaTro)//đi qua từng nhà trọ
                {
                    decimal doanhthu = 0;//doanh thu = 0
                    var dsPhongTro = context.PhongTroes
                        .Where(s => s.MaNhaTro == nhaTro.MaNhaTro);//danh sách phòng trọ tương ứng nhà trọ
                    foreach (var phongTro in dsPhongTro)//đi từng phòng trọ
                    {
                        var dsCTHD = context.ChiTietHopDongs
                            .Where(s => s.MaPhong == phongTro.MaPhong);//danh sách chi tiết hợp đồng

                        foreach (var hd in dsCTHD)
                        {
                            try
                            {
                                //tính tổng tiền từng các phiếu thanh toán
                                doanhthu += Decimal.Parse(context.PhieuThanhToans
                                    .Where(s => s.MaHD == hd.MaHD).Sum(s => s.ThanhTien).ToString());
                            }
                            catch (Exception)
                            {
                                //hợp đồng đó không có phiếu thanh toán
                            }
                        }
                    }

                    nhaTro.DoanhThu = doanhthu;//cập nhập doanh thu
                }
                //số lượng người
                var dsPhongTroes = context.PhongTroes.ToList();
                foreach (var temp in dsPhongTroes)//đi từng phòng trọ
                {
                    temp.SoLuongNguoi = 0;//khởi tạo bằng 0

                    try
                    {
                        temp.SoLuongNguoi = context.ChiTietHopDongs
                            .Where(s => s.MaPhong == temp.MaPhong).Count();//tìm số lượng người
                    }
                    catch (Exception)
                    {
                        //phòng không có chi tiết hợp đồng nào
                    }
                }
                context.SaveChanges();
            }
            catch(Exception)
            {
                MessageBox.Show("Loi! Cap nhap du lieu khong thanh cong", "Loi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sự kiện form load
        private void frmQuanLyNhaTro_Load(object sender, EventArgs e)
        {
            pbxLogo.Load(@"Resources\PHKlogo.gif");//picturebox động góc màn hình
            this.BackgroundImage = Image.FromFile(@"Resources\background.jpg");//ảnh nền
        }

        //sự kiện đăngXuấtToolStripMenuItem_Click
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//thoát form
        }

        //sự kiện cho TaiKhoan
        private void thôngTinNhàTrọToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //gọi form
            var frmtaiKhoan = new frmTaiKhoan(ref taiKhoan);
            frmtaiKhoan.ShowDialog();
        }

        //sự kiện cho Quản lý Khách Hàng
        private void nhàTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gọi form
            var frmKH = new frmKhachHang();
            frmKH.ShowDialog();
            CapNhapDuLieu();
        }

        //sự kiện cho Quản lý Hợp Đồng 
        private void hợpĐồngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frmHD = new frmHopDongThue();
            frmHD.ShowDialog();
            CapNhapDuLieu();
        }

        //sự kiện cho Quản lý Chi Tiết Hợp Đồng
        private void chiTiếtHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gọi form
            var frmCTHD = new frmChiTietHopDong();
            frmCTHD.ShowDialog();
            CapNhapDuLieu();
        }

        //sự kiện cho Quản lý Chi Tiết Dịch Vụ
        private void chiTiếtDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gọi form
            var frmCTDV = new frmChiTietDichVu();
            frmCTDV.ShowDialog();
            CapNhapDuLieu();
        }

        //sự kiện cho Quản lý Phiếu Thanh Toán
        private void phiếuThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gọi form
            var frmPTT = new frmPhieuThanhToan();
            frmPTT.ShowDialog();
            CapNhapDuLieu();
        }

        //sự kiện cho Quản lý Dịch Vụ
        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gọi form
            var frmDV = new frmDichVu();
            frmDV.ShowDialog();
        }

        //sự kiện cho Tổng quan Nhà Trọ
        private void nhàTrọToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //gọi form
            var frmNT = new frmNhaTro();
            frmNT.ShowDialog();
        }

        //sự kiện cho Tổng quan Phòng trọ
        private void phòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //gọi form
            var frmPT = new frmPhongTro();
            frmPT.ShowDialog();
        }

        //sự kiện Click cho ?
        /*Thông tin sản phẩm*/
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StringBuilder output = new StringBuilder();//lưu thông tin
            output.Append("       ĐỒ ÁN CUỐI KÌ LẬP TRÌNH WINDOWN APPLICATION");
            output.Append("\r\n                                           Lớp sáng thứ 5");
            output.Append("\r\n                          Giáo viên: Nguyễn Minh Đạo");
            output.Append("\n\r\n                                        QUẢN LÝ NHÀ TRỌ\n");
            output.Append("\r\n Thành viên:    Nguyễn Quang Huy                      15110215");
            output.Append("\r\n                          Hồ Văn Phong                                15110277");
            output.Append("\r\n                          Lê Tấn Khang                                 15110229");
            MessageBox.Show(output.ToString(), "Tác giả",
                MessageBoxButtons.OK);//show 
        }

        //gọi form frmThongTin
        private void XemDanhMuc(int ma)
        {
            frmThongTin frm = new frmThongTin(ma);
            frm.ShowDialog();
        }

        //sự kiện cho Thoát
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Xem danh mục Dịch Vụ
        private void danhMụcDịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(1);
        }

        //Xem danh mục Thiết bị
        private void danhMụcThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(2);
        }

        //Xem danh mục Loại Phòng
        private void danhMụcLoạiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(3);
        }

        //Xem danh mục Phòng Trọ
        private void danhMụcPhòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(4);
        }

        //Xem danh mục Nhà Trọ
        private void danhMụcNhàTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(5);
        }

        //Xem danh mục Khách Hàng
        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemDanhMuc(6);
        }
    }
}
