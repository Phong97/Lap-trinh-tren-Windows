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
    /// Tổng quan về nhà trọ
    /// chọn nhà trọ thấy phòng trọ ở đó
    /// chọn phòng trọ thấy thiết bị đang sử dụng
    /// </summary>
    public partial class frmNhaTro : Form
    {
        QuanLyNhaTroContainer context;//đối tượng kết nối
        //khởi tạo
        public frmNhaTro()
        {
            InitializeComponent();
        }

        //loaddata
        private int LoadData()
        {
            try
            {
                context = new QuanLyNhaTroContainer();//kết nối

                //đổ dữ liệu nhà trọ lên
                dvgNhaTro.DataSource = (from s in context.NhaTroes
                                        select new
                                        {
                                            s.MaNhaTro,
                                            s.DiaChi,
                                            s.DoanhThu
                                        }).Distinct().ToList();
                dvgNhaTro.Focus();

                //đổ dữ liệu phòng trọ lên
                dvgPhongTro.DataSource = (from s in context.PhongTroes
                                         join k in context.LoaiPhongs
                                         on s.MaLoaiPhong equals k.MaLoaiPhong
                                         select new {
                                                s.MaPhong,
                                                s.TenPhong,
                                                s.SoLuongNguoi,
                                                k.MaLoaiPhong,
                                                k.TenLoaiPhong,
                                                k.DienTich,
                                                k.GiaPhong
                                            }).Distinct().ToList();
                
                //đổ dữ liệu thiết bị lên
                dvgThietBi.DataSource = (from s in context.TrangBis
                                         join k in context.ThietBis
                                             on s.MaThietBi equals k.MaThietBi
                                         select new
                                         {
                                             s.MaThietBi,
                                             k.TenThietBi,
                                             s.ThoiDiem
                                         }).Distinct().ToList();
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;//lỗi
            };

            return 1;//thành công
        }

        //sự kiện click cho nút Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            if (LoadData() == 1)// nếu loaddata thành công thì thông báo thành công 
                MessageBox.Show("Thanh cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //sự kiện form load
        private void frmNhaTro_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //sự kiện cellClick cho datagridView nhà trọ
        private void dvgNhaTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //lấy mã nhà trọ
                int maNhaTro = Int32.Parse(dvgNhaTro.Rows[e.RowIndex].Cells[0].Value.ToString());
                //đổ dữ liệu phòng trọ tương ứng với nhà trọ
                //đã chọn lên datagridView phòng trọ
                dvgPhongTro.DataSource = (from s in context.PhongTroes
                                          join k in context.LoaiPhongs
                                          on s.MaLoaiPhong equals k.MaLoaiPhong
                                          where s.MaNhaTro == maNhaTro
                                          select new
                                          {
                                              s.MaPhong,
                                              s.TenPhong,
                                              s.SoLuongNguoi,
                                              k.MaLoaiPhong,
                                              k.TenLoaiPhong,
                                              k.DienTich,
                                              k.GiaPhong
                                          }).Distinct().ToList();
                dvgPhongTro.Focus();

                //lấy mã phòng trọ của phòng trọ đầu tiên
                int maPhongTro = Int32.Parse(dvgPhongTro.Rows[0].Cells[0].Value.ToString());
                //đổ dữ liệu thiết bị tương ứng với phòng trọ đã 
                //chọn lên datagridView thiết bị
                dvgThietBi.DataSource = (from s in context.TrangBis
                                         join k in context.ThietBis
                                             on s.MaThietBi equals k.MaThietBi
                                         where s.MaPhong == maPhongTro
                                         select new
                                         {
                                             s.MaThietBi,
                                             k.TenThietBi,
                                             s.ThoiDiem
                                         }).Distinct().ToList();
            }//end try
            catch (Exception) //lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sự kiện cellClick cho datagridView phòng trọ
        private void dvgPhongTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //lấy mã phòng trọ đã chọn
                int maPhongTro = Int32.Parse(dvgPhongTro.Rows[e.RowIndex].Cells[0].Value.ToString());
                //đổ dữ liệu thiết bị tương ứng với phòng trọ đã 
                //chọn lên datagridView thiết bị
                dvgThietBi.DataSource = (from s in context.TrangBis
                                         join k in context.ThietBis
                                             on s.MaThietBi equals k.MaThietBi
                                         where s.MaPhong == maPhongTro
                                         select new
                                         {
                                             s.MaThietBi,
                                             k.TenThietBi,
                                             s.ThoiDiem
                                         }).Distinct().ToList();
                dvgThietBi.Focus();
            }//end try
            catch (Exception) //lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
