/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mypack;

/**
 *
 * @author NQHUY
 */
import com.toedter.calendar.JDateChooser;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.*;
import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.Vector;
import java.util.Date;
import javax.accessibility.AccessibleRole;
import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;

public class PhieuThanhToan {

    // Khai báo biến cho việc truy vấn
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    JFrame frmPhieuTT;
    JTable table;
    // Tạo các textfield toàn cục
    private JTextField txtMaPhieu;
    private JTextField txtThangSD;
    private JTextField txtThanhTien, txtTinhTien;
    private JDateChooser txtDate;
    private JTextField txtTenKHTT, txtGiaDV, txtGP;

    java.util.Date date;
    String dateInput;

    // Khai báo các vector dữ liệu cho combobox
    Vector DatacbHD = new Vector();
    Vector DatacbDV = new Vector();
    Vector DatacbPT = new Vector();

    public static void main(String[] agrs) {
        // Lắng nghe sự kiện
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    PhieuThanhToan ptt = new PhieuThanhToan();
                    ptt.frmPhieuTT.setVisible(true);
                } catch (Exception ex) {
                    System.err.println("Can't create form ..." + ex);
                }
            }
        });
    }

    public PhieuThanhToan() {
        Initialize();
        try {
            conn = DBConnection.getConnection();        // Thực hiện kết nối với cơ sở dữ liệu
        } catch (Exception ex) {
            System.err.println("Can not get connection ..." + ex);
        }
        ShowTable();
        ShowCombobox();
    }

    public void ShowTable() {
        // Tạo vector để tạo table 
        Vector cols = new Vector();
        cols.addElement("Mã phiếu");
        cols.addElement("Thời hạn hợp đồng");
        cols.addElement("Thành tiền");
        cols.addElement("Ngày thanh toán");
        cols.addElement("Mã hợp đồng");

        Vector data = new Vector();
        // Tạo câu lệnh truy vấn
        String sql = "select * from quanlynhatro.phieuthanhtoan";
        try {
            // Chuẩn bị câu lệnh truy vấn
            stmt = conn.prepareStatement(sql);
            // Thực hiện câu lệnh truy vấn
            rs = stmt.executeQuery();
            while (rs.next()) {
                //Dua du lieu len bang
                Vector ptt = new Vector();
                ptt.addElement(rs.getInt("MaPhieu"));
                ptt.addElement(rs.getInt("ThangSuDung"));
                ptt.addElement(rs.getInt("ThanhTien"));
                ptt.addElement(rs.getDate("NgayThanhToan"));
                ptt.addElement(rs.getInt("MaHopDong"));

                data.add(ptt);      // Đưa dữ liệu vào vector data
            }
        } catch (Exception ex) {
            System.err.println("Can not show data in table ..." + ex);
        }
        // Đưa dữ liệu lên table 
        table.setModel(new DefaultTableModel(data, cols));

    }
    // Đưa dữ liệu lên combobox 
    public void ShowCombobox() {
        DatacbHD.clear();       // Xoa dữ liệu củ
        DatacbPT.clear();
        DatacbDV.clear();
        try {
            String sql = "select * from quanlynhatro.hopdongthue";
            stmt = conn.prepareStatement(sql);
            rs = stmt.executeQuery();
            while (rs.next()) {
                DatacbHD.add(rs.getString("MaHopDong"));    // Lay du lieu de dua vao combobox
            }
        } catch (Exception ex) {
            System.err.println("Can not show data in combobox:" + ex);
        }
        // Lấy mã phòng đổ vào combobox mã phòng trọ
        try {
            String sql = "select * from quanlynhatro.phongtro";
            stmt = conn.prepareStatement(sql);
            rs = stmt.executeQuery();
            while (rs.next()) {
                DatacbPT.add(rs.getString("MaPhongTro"));
            }
        } catch (Exception ex) {
            System.out.println("Error show combobox phong tro" + ex);
        }
        // Lấy mã dịch vụ đổ vào combobox mã dịch vụ
        try {
            String sql = "select * from quanlynhatro.DichVu";
            stmt = conn.prepareStatement(sql);
            rs = stmt.executeQuery();
            while (rs.next()) {
                DatacbDV.add(rs.getString("MaDichVu"));
            }
        } catch (Exception ex) {
            System.out.println("Error show combobox mã dịch vụ :" + ex);
        }
    }

    // Set tạo form và thực hiện các tính năng 
    private void Initialize() {
        // Tạo form chính
        frmPhieuTT = new JFrame("Quản lý phiếu thanh toán");
        frmPhieuTT.setBounds(320, 80, 750, 490);
        frmPhieuTT.getContentPane().setLayout(null);

        // Panel
        JPanel Panel = new JPanel();
        Panel.setBorder(new TitledBorder(null, "Thông tin về phiếu thanh toán",
                TitledBorder.CENTER, TitledBorder.TOP, null, null));       // Set tiêu đề  và vị trí tiêu đề
        Panel.setBounds(17, 15, 700, 420);          // Set vị trí và size Panel
        frmPhieuTT.getContentPane().add(Panel);     // Thêm  panel vào form chính
        Panel.setLayout(null);                      // Set layout cho panel

        // Tạo label mã phiếu thanh toán 
        JLabel lblMP = new JLabel("Mã phiếu thanh toán :");
        lblMP.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblMP.setBounds(20, 30, 170, 27);
        Panel.add(lblMP);

        // Tạp textfield cho mã phiếu thanh toán
        txtMaPhieu = new JTextField();
        txtMaPhieu.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtMaPhieu.setBounds(180, 30, 60, 27);
        Panel.add(txtMaPhieu);

        // Tạo label cho số tháng sử dụng
        JLabel lblThangSD = new JLabel("Thời hạn hợp đồng :");
        lblThangSD.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblThangSD.setBounds(280, 30, 170, 27);
        Panel.add(lblThangSD);

        // Tạo textfield cho số tháng sử dụng
        txtThangSD = new JTextField();
        txtThangSD.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtThangSD.setBounds(420, 30, 60, 27);
        Panel.add(txtThangSD);

        // Tạo Label cho mã hợp đồng
        JLabel lblMaHD = new JLabel("Mã hợp đồng :");
        lblMaHD.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblMaHD.setBounds(510, 30, 100, 30);
        Panel.add(lblMaHD);

        // Tạo combobox cho mã hợp đồng
        JComboBox cbMaHD = new JComboBox(DatacbHD);
        cbMaHD.setBounds(620, 30, 60, 27);
        Panel.add(cbMaHD);

        // Băt sự kiện combobox show ra tên khách hàng thanh toán
        cbMaHD.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                try {
                    int id = Integer.parseInt(cbMaHD.getSelectedItem().toString()) - 1;

                    HopDongThue hd = new HopDongThue();
                    KhachHang kh = new KhachHang();
                    int MaKH = Integer.parseInt(hd.table.getValueAt(id, 1).toString()) - 1;
                    txtTenKHTT.setText(kh.table.getValueAt(MaKH, 1).toString());
                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(frmPhieuTT, "Không thể xem thông tin khách hàng");
                    System.err.println("Error" + ex);
                }
            }
        });

        // Tạo label Tính tiền
        JLabel lblThanhTien = new JLabel("Thành tiền :");
        lblThanhTien.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblThanhTien.setBounds(440, 110, 120, 27);
        Panel.add(lblThanhTien);

        // Tạo textfield tính tiền
        txtThanhTien = new JTextField();
        txtThanhTien.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtThanhTien.setBounds(530, 110, 110, 27);
        txtThanhTien.enable(false);         // Khóa lại không cho nhập hay chỉnh sữa
        Panel.add(txtThanhTien);

        // Tạp label VND
        JLabel lblTien = new JLabel("VND");
        lblTien.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblTien.setBounds(650, 110, 50, 27);
        Panel.add(lblTien);

        // Ngay thanh toán 
        JLabel lblNgay = new JLabel("Ngày thanh toán :");
        lblNgay.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblNgay.setBounds(20, 70, 170, 27);
        Panel.add(lblNgay);

        // Tạo textfield ngày
        txtDate = new JDateChooser();
        txtDate.setBounds(180, 70, 120, 27);
        Panel.add(txtDate);

        // Tạo label tên khách hàng thanh toán tiền
        JLabel lblTenKH = new JLabel("Tên khách hàng thanh toán:");
        lblTenKH.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblTenKH.setBounds(330, 70, 190, 30);
        Panel.add(lblTenKH);

        // Tạo textfield tên khách hàng
        txtTenKHTT = new JTextField();
        txtTenKHTT.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtTenKHTT.setBounds(530, 70, 150, 27);
        Panel.add(txtTenKHTT);

        // Tao label ma phong tro
        JLabel lblMaPT = new JLabel("Mã phòng trọ:");
        lblMaPT.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblMaPT.setBounds(20, 110, 100, 27);
        Panel.add(lblMaPT);

        // Tạo combobox cho mã phòng trọ
        JComboBox cbMaPT = new JComboBox(DatacbPT);
        cbMaPT.setBounds(120, 110, 60, 27);
        Panel.add(cbMaPT);

        // Tạo Label giá phòng trọ
        JLabel lblGP = new JLabel("Giá phòng trọ :");
        lblGP.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblGP.setBounds(210, 110, 120, 30);
        Panel.add(lblGP);

        // Tạo textfield cho giá phòng trọ
        txtGP = new JTextField();
        txtGP.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtGP.setBounds(320, 110, 100, 27);
        Panel.add(txtGP);

        // Tạo textfield mã dịch vụ
        JComboBox cbMaDV = new JComboBox(DatacbDV);
        cbMaDV.setBounds(120, 150, 60, 27);
        Panel.add(cbMaDV);

        // Lắng nghe sự kiện khi click chuột vào combobox
        cbMaDV.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    // Lấy địa chỉ id từ combobox mã dịch vụ 
                    int id = Integer.parseInt(cbMaDV.getSelectedItem().toString());
                    // Gọi lại lớp dịch vụ
                    DichVu dv = new DichVu();
                    // Truyền giá phòng từ trong bảng giá ra gán vào text giá phòng
                    txtGiaDV.setText(dv.table.getValueAt(id-1, 2).toString());
                } catch (Exception ex) {
                    System.err.println("Error" + ex);
                }
            }
        });

        // Tạo bảng 
        table = new JTable();
        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setBounds(15, 220, 670, 180);
        Panel.add(scrollPane);

        // Sự kiện show thông tin ra text
        table.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent arg0) {
                // Lấy dòng trong bảng phiếu thanh toán ra đưa vào biên row
                int row = table.getSelectedRow();
                txtMaPhieu.setText(table.getValueAt(row, 0).toString());
                txtThangSD.setText(table.getValueAt(row, 1).toString());
                txtThanhTien.setText(table.getValueAt(row, 2).toString());
                txtDate.setDate((Date) table.getValueAt(row, 3));
                cbMaHD.setSelectedItem(table.getValueAt(row, 4).toString());

                try {
                    // Lấy giá trị trong combobox đưa vào Id
                    int id = Integer.parseInt(cbMaHD.getSelectedItem().toString());

                    // Gọi lại các lớp Hợp đồng thuê và khách hàng
                    HopDongThue hd = new HopDongThue();
                    KhachHang kh = new KhachHang();

                    // Lấy mã khách hàng trong bảng hợp đồng ra 
                    int MaKH = Integer.parseInt(hd.table.getValueAt(id - 1, 1).toString());
                   
                    // Đưa tên khách hàng vào text thông qua mã khách hàng
                    txtTenKHTT.setText(kh.table.getValueAt(MaKH - 1, 1).toString());

                    // Gọi lại lớp bảng giá
                    BangGia bg = new BangGia();
                    ChiTietHopDong cthd = new ChiTietHopDong();
                    // Lấy mã hợp đồng từ lớp chi tiết hợp đồng
                    int mahd = Integer.parseInt(cthd.table.getValueAt(id - 1, 3).toString());
                    // Lấy mã phòng trọ từ lớp chi tiết hợp đồng
                    int mapt = Integer.parseInt(cthd.table.getValueAt(mahd - 1, 4).toString());
                    // Set giá trị cho combobox cho mã phòng trọ
                    cbMaPT.setSelectedItem(cthd.table.getValueAt(mahd - 1, 4).toString());

                    // Truyền giá phòng từ trong bảng giá ra gán vào text giá phòng
                    txtGP.setText(bg.table.getValueAt(mapt - 1, 1).toString());

                } catch (Exception ex) {
                    JOptionPane.showMessageDialog(frmPhieuTT, "Không thể xem thông tin khách hàng");
                    System.err.println("Error" + ex);
                }
                try {
                    // Lấy mã hợp đồng từ combobox truyền vào id
                    int id = Integer.parseInt(cbMaHD.getSelectedItem().toString());
                    // Goi lại lớp Chi Tiết hợp đồng
                    ChiTietHopDong cthd = new ChiTietHopDong();
                    // Lấy mã chi tiết hợp đồng từ bảng chi tiết hợp đồng 
                    int macthd = Integer.parseInt(cthd.table.getValueAt(id - 1, 0).toString());

                    // GỌi laij lớp chi tiết dịch vụ
                    ChiTietDichVu ctdv = new ChiTietDichVu();
                    
                    // Lấy dịch vụ từ bảng chi tiết dịch vụ
                    int madv = Integer.parseInt(ctdv.table.getValueAt(macthd - 1, 2).toString());

                    // Gọi lại lớp dịch vụ
                    DichVu dv = new DichVu();
                    // Set text giá dịch vụ từ bảng dịch vụ khi truyền vào số dòng và số cột
                    txtGiaDV.setText(dv.table.getValueAt(madv - 1, 2).toString());
                    cbMaDV.setSelectedItem(dv.table.getValueAt(madv - 1, 0).toString());

                } catch (Exception ex) {
                    System.out.println("Không thể show thông tin dịch vụ " + ex);
                }
            }
        });
        scrollPane.setViewportView(table);

        // Tạo button thêm phiếu thanh toán
        JButton btnThem = new JButton("Thêm");
        btnThem.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnThem.setBounds(380, 185, 100, 27);
        Panel.add(btnThem);

        // Lắng nghe sự kiện khi nhấn nút thêm
        btnThem.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Tạo câu lệnh truy vấn thêm phiếu thanh toán
                String sql = "Insert into quanlynhatro.phieuthanhtoan"
                        + "(MaPhieu,ThangSuDung,ThanhTien,NgayThanhToan,MaHopDong)"
                        + "Values(?,?,?,?,?)";
                // Date
                date = txtDate.getDate();
                dateInput = new SimpleDateFormat("yyyy-MM-dd").format(date);
                try {
                    // Chuẩn bị câu lệnh truy vấn
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, Integer.parseInt(txtMaPhieu.getText()));
                    stmt.setInt(2, Integer.parseInt(txtThangSD.getText()));
                    stmt.setInt(3, Integer.parseInt(txtThanhTien.getText()));
                    stmt.setString(4, dateInput);
                    stmt.setInt(5, Integer.parseInt(cbMaHD.getSelectedItem().toString()));

                    stmt.executeUpdate();   // Thực hiện câu lệnh truy vấn
                    JOptionPane.showMessageDialog(frmPhieuTT, "Thêm dữ liệu thành công");
                } catch (Exception ex) {
                    System.err.println("Can not insert :" + ex);
                    JOptionPane.showMessageDialog(frmPhieuTT, "Thêm dữ liệu thất bại");
                }
                ShowTable();
            }
        });

        // Tạo button xóa dữ liệu
        JButton btnXoa = new JButton("Xóa");
        btnXoa.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnXoa.setBounds(480, 185, 100, 27);
        Panel.add(btnXoa);

        // Lắng nghe sự kiện xóa dữ liệu
        btnXoa.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                int id = Integer.parseInt(txtMaPhieu.getText());
                // Tạo câu lệnh xóa 
                String sql = "delete from quanlynhatro.phieuthanhtoan where MaPhieu=?";
                try {
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, id);
                    int huy = JOptionPane.showConfirmDialog(frmPhieuTT, "Bạn có muốn xóa",
                            "Xóa phiếu thanh toán", JOptionPane.YES_NO_OPTION);
                    switch (huy) {
                        case JOptionPane.YES_OPTION:
                            stmt.executeUpdate();
                            break;
                        case JOptionPane.NO_OPTION:
                            break;
                        case JOptionPane.CANCEL_OPTION:
                            break;
                    }
                } catch (Exception ex) {
                    System.out.println("Khong the xoa" + ex);
                    JOptionPane.showMessageDialog(frmPhieuTT, "Xóa dữ liệu thất bại");
                }
                ShowTable();
            }
        });

        cbMaPT.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    int id = Integer.parseInt(cbMaPT.getSelectedItem().toString()) - 1;

                    BangGia bg = new BangGia();
                    // Truyền giá phòng từ trong bảng giá ra gán vào text giá phòng
                    txtGP.setText(bg.table.getValueAt(id, 1).toString());
                } catch (Exception ex) {
                    System.err.println("Error" + ex);
                }
            }
        });

        // Tạo label tên khách hàng thanh toán tiền
        JLabel lblGiaDichVu = new JLabel("Tên giá dịch vụ:");
        lblGiaDichVu.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblGiaDichVu.setBounds(210, 150, 130, 30);
        Panel.add(lblGiaDichVu);

        // Tạo textfield giá dịch vụ
        txtGiaDV = new JTextField();
        txtGiaDV.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtGiaDV.setBounds(320, 150, 100, 27);
        Panel.add(txtGiaDV);

        // Tạo label mã dịch vụ
        JLabel lblMaDV = new JLabel("Mã dịch vụ :");
        lblMaDV.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblMaDV.setBounds(20, 150, 120, 30);
        Panel.add(lblMaDV);
        
        // TextField tính tiền 
        txtTinhTien = new JTextField();
        txtTinhTien.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtTinhTien.setBounds(160, 185, 110, 27);
        txtTinhTien.enable(false);         // Khóa lại không cho nhập hay chỉnh sữa
        Panel.add(txtTinhTien);

        // Tạp label VND
        JLabel lblTien1 = new JLabel("VND");
        lblTien1.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblTien1.setBounds(280, 185, 50, 27);
        Panel.add(lblTien1);

        // Tạo button tính tiền
        JButton btnTinh = new JButton("Tính tiền");
        btnTinh.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnTinh.setBounds(20, 185, 120, 27);
        Panel.add(btnTinh);

        // Chua xong chổ tính tiền còn tiền dịch vụ
        btnTinh.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                try {
                    int thoihanpt = Integer.parseInt(txtThangSD.getText());
                    int giaDV = Integer.parseInt(txtGiaDV.getText());
                    int tien = Integer.parseInt(txtGP.getText()) * thoihanpt + giaDV * thoihanpt;
                    txtTinhTien.setText(String.valueOf(tien));
                    txtThanhTien.setText(String.valueOf(tien));
                } catch (Exception ex) {
                    System.out.println("Không tính được tiền" + ex);
                }
            }
        });

        // Tạo button reset
        JButton btnReset = new JButton("Reset");
        btnReset.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnReset.setBounds(580, 185, 100, 27);
        Panel.add(btnReset);

        // Lắng nghe sự kiện reset
        btnReset.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                txtGP.setText("");
                txtDate.setDate(date);
                txtGiaDV.setText("");
                txtMaPhieu.setText("");
                txtTenKHTT.setText("");
                txtThangSD.setText("");
                txtThanhTien.setText("");
                txtTinhTien.setText("");
            }
        });
    }
}
