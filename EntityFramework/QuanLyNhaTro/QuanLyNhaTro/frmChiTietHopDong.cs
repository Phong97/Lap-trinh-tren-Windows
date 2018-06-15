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
    /// Quản lí chi tiết hợp đồng 
    /// thêm sửa xóa
    /// tìm kiếm theo mã phòng
    /// </summary>
    public partial class frmChiTietHopDong : Form
    {
        private int insert = 0; //cờ insert
        QuanLyNhaTroContainer context; // đối tượng kết nối

        //khởi tạo
        public frmChiTietHopDong()
        {
            InitializeComponent();
        }

        //reset text
        private void Reset()
        {
            txtMa.ResetText();
            cbMaHD.ResetText();
            cbPhongTro.ResetText();
            lblTenPhong.ResetText();

        }

        //load data
        private int LoadData()
        {
            try
            {
                context = new QuanLyNhaTroContainer(); //kết nối

                //đổ dữ liệu của bảng ChiTietHopDong lên datagridView
                dvg.DataSource = (from s in context.ChiTietHopDongs
                                  select new
                                  {
                                      s.MaChiTietHD,
                                      s.MaHD,
                                      s.MaPhong
                                  }).Distinct().ToList();

                //remove item của cbMa, cbPhongTro, cbSearch
                cbMaHD.Items.Clear();
                cbPhongTro.Items.Clear();
                cbSearch.Items.Clear();

                //thêm item cho cbPhongTro && cbSearch
                var maPT = context.PhongTroes.Select(s=>s.MaPhong); //lấy mã danh sách phòng Trọ
                foreach (var temp in maPT)
                {
                    cbPhongTro.Items.Add(temp.ToString()); //add item cbPhongTro
                    cbSearch.Items.Add(temp.ToString());//add item cbSearch
                }
                cbSearch.Items.Add("All Search"); //add item "All Search" cho cbSearch

                //thêm item cho cbMaHD
                var maHD = context.HopDongThues
                    .Select(s => s.MaHD).ToList(); //lấy danh sách tất cả mã hợp đồng
                var maHDDung = context.ChiTietHopDongs
                    .Select(s => s.MaHD).ToList() ;//lấy danh sách mã hợp đồng đã thêm Chi tiết HD
                //lọc ra danh sách mã hợp đồng chưa có Chi Tiết HD
                foreach(var temp in maHDDung)
                {
                    maHD.Remove(temp);
                }

                //thêm item cho cbMaHD
                foreach (var temp in maHD)
                {
                    cbMaHD.Items.Add(temp.ToString());
                }

                //đưa cái nút lệnh trở về như ban đầu
                dvg.Focus();
                txtMa.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = true;
                dvg.Enabled = true;
                Reset();
            }//end try
            catch (Exception) //lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;//lỗi
            };

            return 1;//thành công
        }

        //sự kiện form load
        private void frmChiTietHopDong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //sự kiện click cho nút Reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            //thông báo thành công nếu loaddata thành công
            if (LoadData() == 1)
                MessageBox.Show("Thanh cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //sự kiện cellClick cho datagridView
        private void dvg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;//bật btnUpdate

            try
            {
                int r = dvg.CurrentCell.RowIndex; //hàng đang chọn

                //hiện dữ liệu lên text
                txtMa.Text = dvg.Rows[r].Cells[0].Value.ToString();
                cbMaHD.Text = dvg.Rows[r].Cells[1].Value.ToString();
                cbPhongTro.Text = dvg.Rows[r].Cells[2].Value.ToString();
            }//end try
            catch (Exception) //lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string var = cbSearch.Text;//item combobox đã chọn

                if (var.Equals("All Search")) //nếu chọn All Search
                {
                    LoadData(); //load lại data
                }//end if
                else //nếu chọn mã phòng
                {
                    int maPT = Int32.Parse(var.ToString()); //lấy mã phòng
                    //lấy danh sách chi tiết hợp đồng theo mã phòng đã chọn đổ lên datagridView
                    dvg.DataSource = (from s in context.ChiTietHopDongs
                                      where s.MaPhong == maPT
                                      select new
                                  {
                                      s.MaChiTietHD,
                                      s.MaHD,
                                      s.MaPhong
                                  }).Distinct().ToList();
                }//end else
            }//end try
            catch (Exception)
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        //sự kiện Click btnInsert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            dvg.Enabled = false;
            txtMa.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
            insert = 1;//bật cờ insert

            Reset();
        }

        //sự kiện Click cho nút btnUpdate
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //thao tac su kien
                dvg.Enabled = true;
                txtMa.Enabled = false;
                btnDelete.Enabled = true;

                //lay du lieu
                int ma = Int32.Parse(txtMa.Text.ToString());
                int maHD = Int32.Parse(cbMaHD.Text.ToString());
                int maPT = Int32.Parse(cbPhongTro.Text.ToString());


                if (insert == 0) //nếu update
                {
                    try
                    {
                        var chiTietHD = context.ChiTietHopDongs
                            .Where(s => s.MaChiTietHD == ma).First();//lấy chiTietHD tương ứng
                        //gán lại dữ liệu
                        chiTietHD.MaHD = maHD;
                        chiTietHD.MaPhong = maPT;
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;//thoát
                    }//end catch
                }//end if
                else//nếu insert
                {
                    try
                    {
                        ChiTietHopDong chiTietHD = new ChiTietHopDong();//tạo
                        //thêm dữ liệu cho ChiTietHopDong vừa tạo
                        chiTietHD.MaChiTietHD = ma;
                        chiTietHD.MaHD = maHD;
                        chiTietHD.MaPhong = maPT;
                        context.ChiTietHopDongs.Add(chiTietHD);//thêm vào bảng ChiTietHopDong
                        context.SaveChanges();//lưu

                         //thêm chi tiết hợp đồng không
                        DialogResult traLoi = MessageBox.Show("Ban co muon them Chi Tiet Dich Vu khong?", "Hoi",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (traLoi == DialogResult.Yes)
                        {
                            /*thêm chi tiết hợp đồng kết hợp thêm chi tiết dịch vụ*/
                            var chitietDV = new frmChiTietDichVu(); //tạo
                            chitietDV.ShowDialog();//hiện formChiTietDichVu
                        }
                    }//end if
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;//thoát
                    }//end catch

                    insert = 0;//tắt cờ insert
                }//end else


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

        //sự kiện CLick cho nút btnDelete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int maChiTietHD = Int32.Parse(txtMa.Text.ToString());//lấy mã chi tiết hợp đồng

                var chiTietDV = context.ChiTietDichVus
                    .Where(s => s.MaChiTietHD == maChiTietHD); //lấy danh sách chi tiết dịch vụ tương ứng
                //remove chi tiết dịch vụ đã tìm được
                foreach (var temp in chiTietDV)
                {
                    context.ChiTietDichVus.Remove(temp);
                }

                //tìm chi tiết hợp đồng tương ứng
                var chiTietHD = context.ChiTietHopDongs
                    .Where(s => s.MaChiTietHD == maChiTietHD).First();
                context.ChiTietHopDongs.Remove(chiTietHD); // remove chi tiết hợp đồng tìm được
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

        //sự kiện SelectedIndexChanged cho cbPhongTro
        private void cbPhongTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int maPhong = Int32.Parse(cbPhongTro.Text);//mã phòng tương ứng

                /*tìm tên phòng trọ tương ứng hiện lên lable */
                lblTenPhong.Text = context.PhongTroes
                    .Where(s => s.MaPhong == maPhong).Select(s => s.TenPhong).First().ToString();
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cbPhongTro.Focus();
        }
    }
}
