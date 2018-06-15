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
    /// Quản lí chi tiết dịch vụ
    /// thêm xóa sửa 
    /// tìm kiếm theo mã chi tiết hợp đồng
    /// </summary>
    public partial class frmChiTietDichVu : Form
    {
        private int insert = 0; //cờ insert
        QuanLyNhaTroContainer context;//đối tượng kết nối

        //khởi tạo
        public frmChiTietDichVu()
        {
            InitializeComponent();
        }

        //reset text ở txtMa, cbChiTietHD, cbMaDV, dtNgaySuDung, lblHD
        private void Reset()
        {
            txtMa.ResetText();
            cbChiTietHD.ResetText();
            cbMaDV.ResetText();
            dtNgaySuDung.ResetText();
            lblHD.ResetText();
            lblDV.ResetText();
        }

        //load lại dữ liệu và refresh như ban đầu
        private int LoadData()
        {
            try
            {
                context = new QuanLyNhaTroContainer(); //ket noi

                //đổ dữ liệu lên datagridView
                dvg.DataSource = (from s in context.ChiTietDichVus
                                  select new
                                  {
                                      s.MaChiTietDV,
                                      s.NgaySuDung,
                                      s.MaDV,
                                      s.MaChiTietHD
                                  }).Distinct().ToList();

                //remove cái item trong combox MaDV, ChiTietHD, Search
                cbMaDV.Items.Clear();
                cbChiTietHD.Items.Clear();
                cbSearch.Items.Clear();

                //thêm item chjo cbMaDV && cbSearch
                var maDV = context.DichVus.Select(s => s.MaDV); //lấy mã Dịch Vụ
                foreach (var temp in maDV)
                {
                    cbMaDV.Items.Add(temp.ToString()); // add item CbMaDV
                    cbSearch.Items.Add(temp.ToString()); // add item CbSearch
                }
                cbSearch.Items.Add("All Search"); //add item "All Search" cho cbSearch

                //thêm item cho cbChiTietHD
                var chiTietHD = context.ChiTietHopDongs
                    .Select(s => s.MaChiTietHD);//lấy mã chi tiết hợp đồng 
                foreach (var temp in chiTietHD)
                {
                    cbChiTietHD.Items.Add(temp.ToString()); // add item CbChiTietHD
                }

                //đưa cái nút lệnh trở về như ban đầu
                dvg.Focus(); //focus đến datagridView
                txtMa.Enabled = false; //ẩn txtMa
                btnUpdate.Enabled = false; // ẩn btnUpdate
                btnDelete.Enabled = true; //mở btnDelete
                dvg.Enabled = true; //mở datadridView
                Reset(); //reset
            }// end try
            catch (Exception) //thông báo lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;//load thất bại
            };

            return 1; //load thành công
        }

        //form load
        private void frmChiTietDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //nút reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            //thông báo thành công nếu thành công
            if (LoadData() == 1)
                MessageBox.Show("Thanh cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //sự kiện cellClick cho dataGridView
        private void dvg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true; //mở button update

            try
            {
                int r = dvg.CurrentCell.RowIndex; //dòng đang chọn

                //hiện dữ liệu lên textbox và combox phù hợp
                txtMa.Text = dvg.Rows[r].Cells[0].Value.ToString();
                dtNgaySuDung.Value = DateTime.Parse(dvg.Rows[r].Cells[1].Value.ToString());
                cbMaDV.Text = dvg.Rows[r].Cells[2].Value.ToString();
                cbChiTietHD.Text = dvg.Rows[r].Cells[3].Value.ToString();
            }//end try
            catch (Exception) //thông báo lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        //nút delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int maChiTietDV = Int32.Parse(txtMa.Text); //mã chi tiết dịch vụ đang chọn

                var chiTietDV = context.ChiTietDichVus
                    .Where(s => s.MaChiTietDV == maChiTietDV).First(); //tìm chi tiết dịch vụ
                context.ChiTietDichVus.Remove(chiTietDV);//xóa chi tiết dịch vụ đã tìm được
                context.SaveChanges();//lưu
                //thông báo thành công
                MessageBox.Show("Thanh cong!", "Thong bao",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end try
            catch(Exception)  //lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        //nút Insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //thao tác lại cái nút lệnh
            dvg.Enabled = false;
            txtMa.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
            insert = 1;

            Reset(); //reset lại
        }

        //nút update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //thao tác nút lệnh
                dvg.Enabled = true;
                txtMa.Enabled = false;
                btnDelete.Enabled = true;

                //lấy dữ liệu
                int ma = Int32.Parse(txtMa.Text.ToString());
                DateTime ngayBatDau = dtNgaySuDung.Value;
                int maDV = Int32.Parse(cbMaDV.Text.ToString());
                int maChiTietHD = Int32.Parse(cbChiTietHD.Text.ToString());

                if (insert == 0) //sửa
                {
                    try
                    {
                        var chiTietDV = context.ChiTietDichVus
                            .Where(s => s.MaChiTietDV == ma).First();//tìm chi tiết dịch vụ đang chọn

                        //gán lại dữ liệu
                        chiTietDV.NgaySuDung = ngayBatDau;
                        chiTietDV.MaDV = maDV;
                        chiTietDV.MaChiTietHD = maChiTietHD;
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;
                    }
                }//end if
                else //thêm
                {
                    try
                    {
                        ChiTietDichVu chiTietDV = new ChiTietDichVu();//khởi tạo một đối tượng chi tiết dịch vụ

                        //gán giá trị
                        chiTietDV.MaChiTietDV = ma;
                        chiTietDV.NgaySuDung = ngayBatDau;
                        chiTietDV.MaDV = maDV;
                        chiTietDV.MaChiTietHD = maChiTietHD;

                        context.ChiTietDichVus.Add(chiTietDV);//thêm
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
                       MessageBoxButtons.OK, MessageBoxIcon.Information);//thông báo thành công
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();//load lại dữ liệu
        }

        //combox search theo mã chi tiết hợp đồng
        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string var = cbSearch.Text; //đối tượng tìm kiếm

                if (var.Equals("All Search"))//load data
                {
                    LoadData();
                }
                else //tìm kiếm mã chi tiết hợp đồng
                {
                    int maChiTietDV = Int32.Parse(var.ToString());//mã chi tiết hợp đồng

                    //tìm danh sách chi tiết dịch vụ cùng mã chi tiết hợp đồng đổ vào datagridView
                    dvg.DataSource = (from s in context.ChiTietDichVus
                                      where s.MaChiTietDV== maChiTietDV
                                      select new
                                      {
                                          s.MaChiTietDV,
                                          s.NgaySuDung,
                                          s.MaDV,
                                          s.MaChiTietHD
                                      }).Distinct().ToList();
                }
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        //combobox chi tiết hợp đồng thay đổi thì label bên cạnh hiện mã hợp đồng tương ứng
        private void cbChiTietHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maChiTietHD = Int32.Parse(cbChiTietHD.Text);//lấy mã

            lblHD.Text = "MaHD " +  context.ChiTietHopDongs
                .Where(s => s.MaChiTietHD == maChiTietHD).First().MaHD.ToString();//tìm kiếm
        }

        private void cbMaDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maDV = Int32.Parse(cbMaDV.Text);//lấy mã

            lblDV.Text = context.DichVus
                .Where(s => s.MaDV == maDV).First().TenDV.ToString();//tìm kiếm
        }
    }
}
