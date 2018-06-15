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
    /// Đăng nhập
    /// đăng nhập và thoát
    /// </summary>
    public partial class frmDangNhap : Form
    {
        // khởi tạo
        public frmDangNhap()
        {
            InitializeComponent();
        }

        //sự kiện Click cho nút btnThoat
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;//result
            //gọi MessageBox
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)//nếu result là ok thì exit
                Application.Exit(); 
        }

        //sự kiện Click cho nút btnDangNhap
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLyNhaTroContainer context = new QuanLyNhaTroContainer(); //kết nối
                var tk = context.TaiKhoans.ToList()
                    .Find(s=>s.TenTK.Equals(txtTaiKhoan.Text)); //tìm tài khoản tương ứng
                tk.MatKhau = tk.MatKhau.Trim(); //chuẩn hóa cách mật khẩu
                if (tk.MatKhau.Equals(txtMatKhau.Text))//nếu đúng mật khẩu thì đăng nhập
                {
                    //thông báo thành công
                    MessageBox.Show("Dang Nhap Thanh Cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //gọi form quản lý nhà trọ
                    var main = new frmQuanLyNhaTro(tk);//tạo 
                    main.ShowDialog();//show
                }//end if
                else//sai mật khẩu thông báo sai
                {
                    MessageBox.Show("Ten Tai Khoan Hoac Mat Khau Khong Dung!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }//end try
            catch(Exception)
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
