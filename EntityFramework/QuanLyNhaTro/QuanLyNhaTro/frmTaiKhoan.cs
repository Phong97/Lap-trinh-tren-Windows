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
    /// Quan Lý tài khoản
    /// thêm xóa sửa
    /// nhận tài khoản từ frmQuanLyKhachHang
    /// </summary>
    public partial class frmTaiKhoan : Form
    {
        private TaiKhoan taiKhoan;//tài khoản
        private int insert = 0;//cờ insert
        //khởi tạo
        public frmTaiKhoan(ref TaiKhoan tk)
        {
            taiKhoan = tk;//nhận tài khoản
            InitializeComponent();
        }

        //sự kiện click cho nút reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            //gán lại text
            txtTaiKhoan.Text = taiKhoan.TenTK;
            txtMatKhau.Text = taiKhoan.MatKhau;
        }

        //sự kiện form load
        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            //gán lại text
            txtTaiKhoan.Text = taiKhoan.TenTK;
            txtMatKhau.Text = taiKhoan.MatKhau;
        }

        //sự kiện click cho nút insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //thao tác nút lệnh
            btnDelete.Enabled = false;
            txtTaiKhoan.Enabled = true;
            txtMatKhau.ResetText();
            txtTaiKhoan.ResetText();
            insert = 1;//bật cờ insert
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = true;
                txtTaiKhoan.Enabled = false;

                QuanLyNhaTroContainer context = new QuanLyNhaTroContainer();

                if (insert == 0) //sửa
                {
                    try
                    {
                        //cập nhập mật khẩu
                        context.TaiKhoans.Where(s => s.TenTK.Equals(taiKhoan.TenTK))
                            .First().MatKhau = txtMatKhau.Text;//cơ sở dữ liệu
                        taiKhoan.MatKhau = txtMatKhau.Text;//form
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }//end if
                else //thêm
                {
                    try
                    {
                        TaiKhoan tk = new TaiKhoan();//tạo
                        //gán giá trị
                        tk.TenTK = txtTaiKhoan.Text;
                        tk.MatKhau = txtMatKhau.Text;
                        context.TaiKhoans.Add(tk);//thêm
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    insert = 0;//tắt cờ insert
                }


                context.SaveChanges();//lưu

                MessageBox.Show("Thanh cong!", "Thong bao",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);//thông báo thành công
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //sự kiện click cho nút delte
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //dialog hỏi có xáo không nhận result về biến traLoi
                DialogResult traLoi = MessageBox.Show("Ban co muon xoa?(Application exit)", "XOA", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traLoi == DialogResult.Yes)//trả lời ok
                {
                    QuanLyNhaTroContainer context = new QuanLyNhaTroContainer();//đối tượng kết nối

                    context.TaiKhoans.Remove(context.TaiKhoans
                        .Where(s=>s.TenTK.Equals(taiKhoan.TenTK)).First());//xóa tài khoản
                    context.SaveChanges();//lưu
                    //thông báo thành công
                    MessageBox.Show("Thanh cong!", "Thong bao",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Application.Exit();//thoát khởi chương trình
                }
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
