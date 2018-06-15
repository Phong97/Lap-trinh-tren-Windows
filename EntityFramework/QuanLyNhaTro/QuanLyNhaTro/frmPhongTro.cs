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
    /// Tổng quan Phòng trọ
    /// chọn phòng trọ từ comboBox 
    /// trả về danh sách phiếu thanh toán, khách hàng, dịch vụ phòng đang dùng
    /// </summary>
    public partial class frmPhongTro : Form
    {
        QuanLyNhaTroContainer context;//đối tượng kết nối
        //khởi tạo
        public frmPhongTro()
        {
            InitializeComponent();
        }

        //load data
        private int LoadData()
        {
            try
            {
                context = new QuanLyNhaTroContainer(); //kết nối

                //cbPhongTro
                cbPhongTro.Items.Clear();//remove item
                var maPT = context.PhongTroes.Select(s => s.MaPhong);//danh sách mã phòng
                foreach (var temp in maPT)
                {
                    cbPhongTro.Items.Add(temp.ToString());//thêm item cho cbPhongTro
                }

                //dvg PhieuThanhToan
                dvgPhieuThu.DataSource = (from s in context.PhieuThanhToans
                                  select new
                                  {
                                      s.MaPhieu,
                                      s.ThangSuDung,
                                      s.ThanhTien,
                                      s.NgayThanhToan,
                                      s.MaHD
                                  }).Distinct().ToList();
                
                //dvg DV
                dvgDV.DataSource = context.DichVus.ToList();


                //dvg KH
                dvgKH.DataSource = (from s in context.KhachHangs
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
                                  }).Distinct().ToList();

                cbPhongTro.Focus();
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
        private void frmPhongTro_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //sự kiện cbPhongTro_SelectedIndexChanged
        private void cbPhongTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int maPhong = Int32.Parse(cbPhongTro.Text);//lấy mã phòng
                txtTenPhong.Text = context.PhongTroes
                    .Where(s => s.MaPhong == maPhong).First().TenPhong;//hiện tên phòng

                var dsmaHD = context.ChiTietHopDongs
                    .Where(s => s.MaPhong == maPhong).Select(s=>s.MaHD);//danh sách mã hợp đồng

                //PhieuThanhToan
                List<PhieuThanhToan> dsPhieuThu = new List<PhieuThanhToan>();//tạo
                foreach (var maHD in dsmaHD)//đi từng hợp đồng
                {       
                    //tìm Phiếu thanh toán
                     var phieuThu = (from s in context.PhieuThanhToans
                                              where s.MaHD == maHD
                                              select new
                                              {
                                                  s.MaPhieu,
                                                  s.NgayThanhToan,
                                                  s.ThangSuDung,
                                                  s.ThanhTien,
                                                  s.MaHD
                                              }).Distinct().ToList();
                    foreach(var temp  in phieuThu)//đi từng phiếu
                    {
                        PhieuThanhToan phieuThanhToan = new PhieuThanhToan();//tạo
                        //gán giá trị
                        phieuThanhToan.MaPhieu = temp.MaPhieu;
                        phieuThanhToan.NgayThanhToan = temp.NgayThanhToan;
                        phieuThanhToan.ThangSuDung = temp.ThangSuDung;
                        phieuThanhToan.ThanhTien = temp.ThanhTien;
                        phieuThanhToan.MaHD = temp.MaHD;
                        dsPhieuThu.Add(phieuThanhToan);//thêm vào list
                    }
                }
                dvgPhieuThu.DataSource = dsPhieuThu;//đổ dữ liệu lên dvgPhieuThu


                //Dịch Vụ
                var dsMaChiTietHD = context.ChiTietHopDongs
                    .Where(s => s.MaPhong == maPhong).Select(s => s.MaChiTietHD)
                    .Distinct().ToList();//danh sách mã Chi Tiết hợp đồng

                var dsDV = new List<DichVu>();//tạo
                foreach(var temp in dsMaChiTietHD)//đi từng chi tiết hợp đồng
                {
                    var temp1 = context.ChiTietDichVus
                        .Where(s => s.MaChiTietHD == temp).Select(s=>s.MaDV)
                        .Distinct().ToList();//danh sách mã chi tiết dịch vụ
                    foreach(var temp2 in temp1)//đi từng mã chi tiết dịch vụ
                    {
                        if (dsDV.Any(s => s.MaDV == temp2) == false)//đã có dịch vụ đó
                        {
                            DichVu dv = context.DichVus
                                .Where(s => s.MaDV == temp2).First();//tìm dịch vụ
                            DichVu temp3 = new DichVu();//tạo
                            //gán giá trị
                            temp3.GiaDV = dv.GiaDV;
                            temp3.MaDV = dv.MaDV;
                            temp3.TenDV = dv.TenDV;
                            dsDV.Add(temp3);//thêm vào list
                        }
                    }
                }
                dvgDV.DataSource = dsDV;//đổ dữ liệu lên dvgDV

                //Khách Hàng
                List<KhachHang> dsKH = new List<KhachHang>();//tạo
                foreach (var maHD in dsmaHD)//đi từng mã hợp đồng
                {
                    var kh = context.HopDongThues
                        .Where(s => s.MaHD == maHD).Select(s => s.KhachHang)
                        .Distinct().ToList();//danh sách khách hàng
                    foreach (var temp in kh)//đi từng khách hàng
                    {
                        KhachHang temp1 = new KhachHang();//tạo
                        //gán giá trị
                        temp1.MaKhach = temp.MaKhach;
                        temp1.TenKhach = temp.TenKhach;
                        temp1.CMND = temp.CMND;
                        temp1.GioiTinh = temp.GioiTinh;
                        temp1.DiaChiKhach = temp.DiaChiKhach;
                        temp1.NgheNghiep = temp.NgheNghiep;
                        temp1.SdtKhach = temp.SdtKhach;
                        temp1.HinhAnhKH = temp.HinhAnhKH;
                        dsKH.Add(temp1);//thêm vào list
                    }//
                }//
                dvgKH.DataSource = dsKH;//đỏ dữ liệu lên dvgKH
            }//end try
            catch(Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sự kiện click Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            if (LoadData() == 1)// nếu loaddata thành công thì thông báo thành công 
                MessageBox.Show("Thanh cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
