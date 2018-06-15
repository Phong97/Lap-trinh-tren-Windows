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
    /// Quản lí Dịch Vụ
    /// thêm xóa sửa
    /// </summary>
    public partial class frmDichVu : Form
    {
        QuanLyNhaTroContainer context;//đối tượng kết nối
        int insert = 0;//cờ insert

        //khởi tạo
        public frmDichVu()
        {
            InitializeComponent();
        }

        //load data
        private int LoadData()
        {
            try
            {
                context = new QuanLyNhaTroContainer();//kết nối

                dvg.DataSource = context.DichVus.ToList();//đổ dữ liệu lên datagridView

                //khởi tạo nút lệnh như ban đầu
                dvg.Focus();
                txtMa.Enabled = false;
                btnUpdate.Enabled = false;
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

        //sự kiện Click cho nút Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            if (LoadData() == 1) //thông báo thành công nếu loaddata thành công
                MessageBox.Show("Thanh cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //sự kiện load form
        private void frmDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //sự kiện cellClick cho datadridView
        private void dvg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;//bật btnUpdate

            try
            {
                int row = e.RowIndex; //hàng đang chọn
                //đổ dữ lên text
                txtMa.Text = dvg.Rows[row].Cells[0].Value.ToString();
                txtTen.Text = dvg.Rows[row].Cells[1].Value.ToString();
                txtGia.Text = dvg.Rows[row].Cells[2].Value.ToString();
            }
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        //sự kiện Click cho nút Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int maDV = Int32.Parse(txtMa.Text.ToString());//lấy mã Dịch Vụ tương ứng

                var dsChiTietDichVu = context.ChiTietDichVus
                    .Where(s=>s.MaDV == maDV).ToList();//lấy danh sách Chi Tiet Dich Vu tương ứng

                //remove các chi tiet dich vụ tìm được
                foreach(var temp in dsChiTietDichVu)
                {
                    context.ChiTietDichVus.Remove(temp);
                }

                var dv = context.DichVus
                    .Where(s => s.MaDV == maDV).First();//lấy dịch vụ tương ứng
                context.DichVus.Remove(dv);//remove dịch vụ tìm được
                context.SaveChanges();//lưu
                MessageBox.Show("Thanh cong!", "Thong bao",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadData();
        }

        //reset text
        private void Reset()
        {
           
            txtMa.ResetText();
            txtTen.ResetText();
            txtGia.ResetText();
        }

        //sự kiện Click cho nút Insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            dvg.Enabled = false;
            txtMa.Enabled = true;
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
                dvg.Enabled = true;
                txtMa.Enabled = false;
                btnDelete.Enabled = true;

               //lấy dữ liệu
                int maDV = Int32.Parse(txtMa.Text.ToString());
                string tenDV = txtTen.Text.ToString();
                decimal gia = Decimal.Parse(txtGia.Text.ToString());

                //nếu giá nhỏ hơn 0 thì báo lỗi và loaddata 
                if (gia < 0)
                {
                    MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadData();
                    return;
                }

                if (insert == 0)//update
                {
                    try
                    {
                        var dv = context.DichVus
                            .Where(s => s.MaDV == maDV).First();//tìm dịch vụ tương ứng
                        //gán lại giá trị
                        dv.MaDV = maDV;
                        dv.TenDV = tenDV;
                        dv.GiaDV = gia;
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
                        DichVu dv = new DichVu(); //tạo
                        //gán giá trị
                        dv.GiaDV = gia;
                        dv.TenDV = tenDV;
                        dv.MaDV = maDV;
                        context.DichVus.Add(dv);//thêm dịch vụ
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;
                    }
                    insert = 0;//tắt cờ insert
                }

                context.SaveChanges();//lưu

                MessageBox.Show("Thanh cong!", "Thong bao",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }
    }
}
