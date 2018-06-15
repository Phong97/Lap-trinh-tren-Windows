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
    /// Quản lý Hợp Đồng Thuê
    /// thêm xóa sửa
    /// tìm kiếm theo mã khách hàng
    /// </summary>
    public partial class frmHopDongThue : Form
    {
        private int insert = 0; //cờ insert
        QuanLyNhaTroContainer context; //đối tượng kết nối

        //khởi tạo
        public frmHopDongThue()
        {
            InitializeComponent();
        }

        //reset text
        private void Reset()
        {
            
            txtMaHD.ResetText();
            cbMaKH.ResetText();
            dtBD.ResetText();
            txtTH.ResetText();

        }

        //load data
        private int LoadData()
        {
            try
            {
                context = new QuanLyNhaTroContainer(); //kết nối
                //đổ dữ liệu lên datagridView
                dvg.DataSource = (from s in context.HopDongThues
                                  select new
                                  {
                                      s.MaHD,
                                      s.MaKH,
                                      s.NgayBatDauHD,
                                      s.ThoiHanHD
                                  }).Distinct().ToList();

                var makh = context.KhachHangs.Select(s => s.MaKhach);//lấy danh sách mã khách hàng
                
                //remove item của cbMaKH và cbSearch
                cbMaKH.Items.Clear();
                cbSearch.Items.Clear();

                //thêm item cho cbMaKH và cbSearch
                foreach (var temp in makh)
                {
                    cbMaKH.Items.Add(temp.ToString());
                    cbSearch.Items.Add(temp.ToString());
                }
                cbSearch.Items.Add("All Search"); //thêm item "All Search" cho cbSearch

                dvg.Focus();
                txtMaHD.Enabled = false;
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

        //sự kiện click cho nút Insert
        private void btnInsert_Click(object sender, EventArgs e)
        {
            dvg.Enabled = false;
            txtMaHD.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
            insert = 1;//bật cờ insert

            Reset();
        }

        //sự kiện form load
        private void frmHopDongThue_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //sự kiện click cho nút reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            if (LoadData() == 1) // nếu loaddata thành công thì thông báo thành công 
                MessageBox.Show("Thanh cong!", "Thong bao",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //sự kiện cellClick cho datagridView
        private void dvg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;//bật btnUpdtae

            try
            {
                int r = dvg.CurrentCell.RowIndex; //hàng đang chọn

                //truyền dữ liệu
                txtMaHD.Text = dvg.Rows[r].Cells[0].Value.ToString();
                cbMaKH.Text = dvg.Rows[r].Cells[1].Value.ToString();
                dtBD.Value = DateTime.Parse(dvg.Rows[r].Cells[2].Value.ToString());
                txtTH.Text = dvg.Rows[r].Cells[3].Value.ToString() + " thang";
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        //sự kiện click cho nút update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //bật datagridView và btnDelete, tắt txtMaHD 
                dvg.Enabled = true;
                txtMaHD.Enabled = false;
                btnDelete.Enabled = true;

                //lấy dữ liệu
                int maKH = Int32.Parse(cbMaKH.Text.ToString());
                int maHD = Int32.Parse(txtMaHD.Text.ToString());
                DateTime ngayBatDau = dtBD.Value;
                int thoiHan = Int32.Parse(txtTH.Text.ToString());


                if (insert == 0)//update
                {
                    try
                    {
                        var hd = context.HopDongThues
                            .Where(s => s.MaHD == maHD).First(); //tìm hợp đồng tương ứng
                        //gán lại giá trị
                        hd.MaKH = maHD;
                        hd.NgayBatDauHD = ngayBatDau;
                        hd.ThoiHanHD = thoiHan;
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;
                    }//end catch
                }
                else//insert
                {
                    try
                    {
                        HopDongThue hd = new HopDongThue(); //tạo
                        //gán giá trị
                        hd.MaHD = maHD;
                        hd.MaKH = maKH;
                        hd.NgayBatDauHD = ngayBatDau;
                        hd.ThoiHanHD = thoiHan;
                        context.HopDongThues.Add(hd);//thêm hợp đồng vừa tạo
                        context.SaveChanges();//lưu

                        //thêm chi tiết hợp đồng không
                        DialogResult traLoi = MessageBox.Show("Ban co muon them Chi Tiet Hop dong thue khong?", "Hoi",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (traLoi == DialogResult.Yes)
                        {
                            //gọi form ChiTietHopDong
                            var chiTietHD = new frmChiTietHopDong();
                            chiTietHD.ShowDialog();
                        }
                    }//end try
                    catch (Exception)//lỗi
                    {
                        MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadData();
                        return;
                    }//end catch
                    insert = 0;//tat co insert
                }

                context.SaveChanges(); //lưu

                MessageBox.Show("Thanh cong!", "Thong bao",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi! Vui long kiem tra lai thong tin", "Loi",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
        }

        //sự kiện click nút Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int maHD = Int32.Parse(txtMaHD.Text.ToString());//lấy mã Hợp đồng tương ứng
                
                var phieuThanhToan = context.PhieuThanhToans
                    .Where(s => s.MaHD == maHD);//danh sách phiếu thanh toán tương ứng
                //remove phiếu thanh toán tìm được
                foreach (var temp1 in phieuThanhToan)
                {
                    context.PhieuThanhToans.Remove(temp1);
                }

                var chiTietHD = context.ChiTietHopDongs
                    .Where(s => s.MaHD == maHD);//danh sách hợp đồng tương ứng
                //
                foreach (var temp2 in chiTietHD)
                {
                    //danh sách chi tiết dịch vụ tưowng ứng với mỗi chi tiết hợp đồng tìm được
                    var chiTietDV = context.ChiTietDichVus
                        .Where(s => s.MaChiTietHD == temp2.MaChiTietHD);
                    //remove chi tiết dịch vụ tìm được
                    foreach (var temp3 in chiTietDV)
                    {
                        context.ChiTietDichVus.Remove(temp3);
                    }

                    //remove chi tiết hợp đồng
                    context.ChiTietHopDongs.Remove(temp2);
                }

                //tìm hợp đồng thuê tương ứng
                var hd = context.HopDongThues.Where(s => s.MaHD == maHD).First();
                context.HopDongThues.Remove(hd);//remove hợp đồng tìm được
                context.SaveChanges();//lưu
                //thông báo thành công
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

        //sự kiện SelectedIndexChanged cho cbSearch
        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string var = cbSearch.Text;//lấy item 

                if (var.Equals("All Search"))//item All Search
                {
                    LoadData();
                }
                else
                {
                    int maKh = Int32.Parse(var.ToString());//lấy mã khách hàng tương ứng
                    //đổ dữ liệu lên datagridView hợp đồng thuê tương ứng
                    dvg.DataSource = (from s in context.HopDongThues
                                      where s.MaKH == maKh
                                      select new
                                      {
                                          s.MaHD,
                                          s.MaKH,
                                          s.NgayBatDauHD,
                                          s.ThoiHanHD
                                      }).Distinct().ToList();
                }
            }//end try
            catch (Exception)//lỗi
            {
                MessageBox.Show("Loi load du lieu!", "Loi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }
    }
}
