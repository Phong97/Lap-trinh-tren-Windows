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
    /// Xem thông tin
    /// dịch vụ, thiết bị, loại phòng, phòng, nhà trọ, khách hàng
    /// nhận tham số tương ứng từ frmQuanLyNhaTro
    /// </summary>
    public partial class frmThongTin : Form
    {
        private int ma;//mã
        //khởi tạo
        public frmThongTin(int ma)
        {
            this.ma = ma;//tham số nhận vào
            InitializeComponent();
        }

        //sự kiện form load
        private void frmThongTin_Load(object sender, EventArgs e)
        {
            try
            {
                    QuanLyNhaTroContainer context = new QuanLyNhaTroContainer();//kết nối
                switch(ma)//kiểm tra mã
                {
                    case 1://dịch vụ
                        lblTen.Text = "Danh Mục Dịch Vụ";//đổi tên lable
                        dvg.DataSource = context.DichVus.Distinct().ToList();//đổ dữ liệu
                        break;
                    case 2://thiết bị
                        lblTen.Text = "Danh Mục Thiết Bị";
                        dvg.DataSource = context.ThietBis.Distinct().ToList();
                        break;
                    case 3://loại phòng
                        lblTen.Text = "Danh Mục Loại Phòng";
                        dvg.DataSource = context.LoaiPhongs.Distinct().ToList();
                        break;
                    case 4://phòng trọ
                        lblTen.Text = "Danh Mục Phòng Trọ";
                        dvg.DataSource = context.PhongTroes.Distinct().ToList();
                        break;
                    case 5://nhà trọ
                        lblTen.Text = "Danh Mục Nhà Trọ";
                        dvg.DataSource = context.NhaTroes.Distinct().ToList();
                        break;
                    case 6://khách hàng
                        lblTen.Text = "Danh Mục Khách Hàng";
                        dvg.DataSource = context.KhachHangs.Distinct().ToList();
                        break;
                    default:
                        break;
                }
            }// end try
            catch (Exception) //thông báo lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}
