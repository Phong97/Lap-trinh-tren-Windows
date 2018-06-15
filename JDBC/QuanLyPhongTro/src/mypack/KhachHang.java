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
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.FileInputStream;
import javax.swing.*;
import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.Vector;
import javax.imageio.ImageIO;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;
import javax.swing.JScrollPane;
import javax.swing.filechooser.FileNameExtensionFilter;

public class KhachHang {

    // Khai báo form khách hàng
    JFrame frmKhachHang;

    // Khai báo biến truy vấn
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    // Khai báo biến chung
    public JTextField txtID;
    public JTextField txtName;
    public JTextField txtCMND;
    public JTextField txtGT;
    public JTextField txtDiaChi;
    public JTextField txtNgheNghiep;
    public JTextField txtDT;
    public JTextField txtSearch;
    public JTable table;
    public JLabel lblImages;

    // Biến để Browse Images
    String filename = null;
    BufferedImage bi;

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            public void run() {
                try {
                    KhachHang KH = new KhachHang();
                    KH.frmKhachHang.setVisible(true);
                } catch (Exception e) {

                }
            }
        });
    }

    public KhachHang() {
        Initialize();
        try {
            conn = DBConnection.getConnection();    // Thực hiện kết nối với cơ sở dữ liệu
        } catch (Exception e) {
            // TODO: handle exception
        }
        showTable();        // Show data lên bảng 
    }

    // Hiển thị bảng giống như datagridview
    public void showTable() {

        // Name Column table
        Vector cols = new Vector();
        cols.addElement("Ma_KH");
        cols.addElement("TenKH");
        cols.addElement("SoCMND");
        cols.addElement("GioiTinh");
        cols.addElement("DiaChi");
        cols.addElement("NgheNghiep");
        cols.addElement("SDT_KH");
        cols.addElement("Images");

        // Data table
        Vector data = new Vector();
        // Tạo câu lệnh truy vấn
        String sql = "Select * From quanlynhatro.khachhang";
        try {
            // Chuẩn bị câu lệnh truy vấn
            stmt = conn.prepareStatement(sql);
            // Thực hiện câu lệnh truy vấn
            rs = stmt.executeQuery();
            while (rs.next()) {
                //  Đưa dữ liệu lên bảng
                Vector khachhang = new Vector();
                khachhang.addElement(rs.getInt("MaKH"));
                khachhang.addElement(rs.getString("TenKH"));
                khachhang.addElement(rs.getInt("SoCMND"));
                khachhang.addElement(rs.getString("GioiTinh"));
                khachhang.addElement(rs.getString("DiaChi"));
                khachhang.addElement(rs.getString("NgheNghiep"));
                khachhang.addElement(rs.getInt("SoDienThoaiKH"));
                khachhang.addElement(rs.getBytes("HinhAnhKH"));

                data.add(khachhang);    // Đưa dữ liệu vào data
            }

        } catch (Exception e) {
            System.err.println("Không thể show dữ liệu lên bảng" + e);
        }
        table.setModel(new DefaultTableModel(data, cols));
    }

    private void Initialize() {
        // Tạo form chính 
        frmKhachHang = new JFrame("Quản lý khách hàng");        // Set tiêu đề cho form
        frmKhachHang.setBounds(320, 80, 800, 570);              // Set vị trí và size cho form
        frmKhachHang.getContentPane().setLayout(null);          // Set layout cho form

        // Panel chung Thông tin 
        JPanel Panel = new JPanel();
        Panel.setBorder(new TitledBorder(null, "Thông tin khách hàng", TitledBorder.LEADING, TitledBorder.TOP, null, null));
        Panel.setBounds(10, 10, 765, 510);
        frmKhachHang.getContentPane().add(Panel);
        Panel.setLayout(null);

        // Tạo bảng
        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setBounds(20, 325, 730, 170);
        Panel.add(scrollPane);

        // Tạo panel avartar
        JPanel Panel_2 = new JPanel();
        Panel_2.setBorder(new TitledBorder(null, "Avatar", TitledBorder.LEADING, TitledBorder.TOP, null, null));
        Panel_2.setBounds(510, 20, 240, 220);
        Panel.add(Panel_2);
        Panel_2.setLayout(null);

        // Tạo label chứa hình ảnh
        lblImages = new JLabel("");
        lblImages.setIcon(new ImageIcon(""));
        lblImages.setBounds(12, 18, 215, 195);
        //lblImages.setLocation(513, 29);
        Panel_2.add(lblImages);

        // Label mã khách hàng
        JLabel lblID = new JLabel("Mã khách hàng :");
        lblID.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblID.setBounds(50, 30, 170, 27);
        Panel.add(lblID);

        // Tạo textfield cho mã khách hàng
        txtID = new JTextField();
        txtID.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtID.setBounds(230, 30, 250, 27);
        Panel.add(txtID);

        // Tạo label cho tên  khách hàng
        JLabel lblName = new JLabel("Tên khách hàng :");
        lblName.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblName.setBounds(50, 60, 170, 27);
        Panel.add(lblName);

        // Tạo textfield cho  tên khách hàng
        txtName = new JTextField();
        txtName.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtName.setBounds(230, 60, 250, 27);
        Panel.add(txtName);

        // Tạo label số chứng minh nhân dân
        JLabel lblCMND = new JLabel("Số CMND :");
        lblCMND.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblCMND.setBounds(50, 90, 170, 27);
        Panel.add(lblCMND);

        // Tạo textfield cho số chứng minh nhân dân
        txtCMND = new JTextField();
        txtCMND.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtCMND.setBounds(230, 90, 250, 27);
        Panel.add(txtCMND);

        // Tạo label cho giới tính
        JLabel lblGT = new JLabel("Giới tính :");
        lblGT.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblGT.setBounds(50, 120, 170, 27);
        Panel.add(lblGT);

        // Tạo textfield cho giới tính
        txtGT = new JTextField();
        txtGT.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtGT.setBounds(230, 120, 250, 27);
        Panel.add(txtGT);

        // Tạo label cho địa chỉ
        JLabel lblDiaChi = new JLabel("Địa chỉ :");
        lblDiaChi.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblDiaChi.setBounds(50, 150, 250, 27);
        Panel.add(lblDiaChi);

        // Tạo textfield cho địa chỉ
        txtDiaChi = new JTextField();
        txtDiaChi.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtDiaChi.setBounds(230, 150, 250, 27);
        Panel.add(txtDiaChi);

        // Tạo label cho nghề nghiệp
        JLabel lblNgheNghiep = new JLabel("Nghề nghiệp :");
        lblNgheNghiep.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblNgheNghiep.setBounds(50, 180, 170, 27);
        Panel.add(lblNgheNghiep);

        // Tạo textfield cho nghề nghiệp
        txtNgheNghiep = new JTextField();
        txtNgheNghiep.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtNgheNghiep.setBounds(230, 180, 250, 27);
        Panel.add(txtNgheNghiep);

        // Tạo label cho số điện thoại
        JLabel lblSDT = new JLabel("Số điện thoại :");
        lblSDT.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblSDT.setBounds(50, 210, 170, 27);
        Panel.add(lblSDT);

        // Tọa textfield cho số điện thoại
        txtDT = new JTextField();
        txtDT.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtDT.setBounds(230, 210, 250, 27);
        Panel.add(txtDT);

        // Button Insert 
        JButton btnInsert = new JButton(" Insert");
        btnInsert.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent arg0) {
                // Tạo câu lệnh truy vấn đê insert dữ liệu
                String sql = "INSERT INTO quanlynhatro.khachhang "
                        + "(MaKH, TenKH, SoCMND, GioiTinh, DiaChi, NgheNghiep, SoDienThoaiKH,HinhAnhKH)"
                        + " VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                // Images
//                FileInputStream fis;
                try {
                    // DATE
                    // Kiểm tra khách hàng có dữ liệu hình ảnh hay ko
                    if (filename != null) {
                        File imgfile = new File(filename);
                        FileInputStream fin = new FileInputStream(imgfile);
                        stmt = conn.prepareStatement(sql);
                        stmt.setInt(1, Integer.parseInt(txtID.getText()));
                        stmt.setString(2, txtName.getText());
                        stmt.setInt(3, Integer.parseInt(txtCMND.getText()));
                        stmt.setString(4, txtGT.getText());
                        stmt.setString(5, txtDiaChi.getText());
                        stmt.setString(6, txtNgheNghiep.getText());
                        stmt.setInt(7, Integer.parseInt(txtDT.getText()));
                        stmt.setBinaryStream(8, fin, (int) imgfile.length());
                        stmt.executeUpdate();
                        JOptionPane.showMessageDialog(frmKhachHang, "Thêm dữ liệu thành công");
                    }
                    // Kiểm tra khách hàng không có dữ liệu hình ảnh thì không insert hình ảnh
                    if (filename == null) {
                        sql = "INSERT INTO quanlynhatro.khachhang "
                                + "(MaKH, TenKH, SoCMND, GioiTinh, DiaChi, NgheNghiep, SoDienThoaiKH)"
                                + " VALUES (?, ?, ?, ?, ?, ?, ?)";
                        stmt = conn.prepareStatement(sql);
                        stmt.setInt(1, Integer.parseInt(txtID.getText()));
                        stmt.setString(2, txtName.getText());
                        stmt.setInt(3, Integer.parseInt(txtCMND.getText()));
                        stmt.setString(4, txtGT.getText());
                        stmt.setString(5, txtDiaChi.getText());
                        stmt.setString(6, txtNgheNghiep.getText());
                        stmt.setInt(7, Integer.parseInt(txtDT.getText()));
                        stmt.executeUpdate();
                        JOptionPane.showMessageDialog(frmKhachHang, "Thêm dữ liệu thành công");// Show thông báo khi insert thành công
                    }

                } catch (Exception e) {
                    // TODO: handle exception
                    System.out.println("Loi Insert: " + e);
                    JOptionPane.showMessageDialog(txtCMND, "Thêm dữ liệu thất bại");
                }
                // Hiện ra thông báo có muốn làm hợp đồng hay không
                int reponse = JOptionPane.showConfirmDialog(frmKhachHang, "Bạn có muốn thêm hợp đồng?",
                        "Thông báo", JOptionPane.YES_NO_OPTION);
                String message = "?";
                switch (reponse) {
                    case JOptionPane.YES_OPTION:
                        message = "Yes_Option";
                        HopDongThue hdt = new HopDongThue();
                        hdt.frmHDT.setVisible(true);
                        break;
                    case JOptionPane.NO_OPTION:
                        message = "No_Option";
                        break;
                    case JOptionPane.CLOSED_OPTION:
                        message = "Close_Option";
                        break;
                    default:
                        message = "autre";
                }
            }
        });
        btnInsert.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnInsert.setBounds(20, 280, 110, 30);
        btnInsert.setIcon(new ImageIcon("src/Images/insert2.png"));
        Panel.add(btnInsert);

        // Button Delete
        JButton btnDelete = new JButton(" Delete");
        btnDelete.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnDelete.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent arg0) {
                int id = Integer.parseInt(txtID.getText());
                String sql = "Delete From quanlynhatro.khachhang Where MaKH =?";
                try {
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, id);
                    int reponse = JOptionPane.showConfirmDialog(frmKhachHang, "Do you want delete?", "Delete person",
                            JOptionPane.YES_NO_OPTION);
                    String message = "?";
                    switch (reponse) {
                        case JOptionPane.YES_OPTION:
                            message = "YES_OPTION";
                            stmt.executeUpdate();
                            break;
                        case JOptionPane.NO_OPTION:
                            message = "NO_OPTION";
                            break;
                        case JOptionPane.CLOSED_OPTION:
                            message = "CLOSED_OPTION";
                            break;
                        default:
                            message = "autre";

                    }
//                    JOptionPane.showMessageDialog(frmKhachHang, "response: " + message);

                } catch (Exception e) {
                    JOptionPane.showMessageDialog(null, "Xóa dữ liệu không thành công");
                }
                showTable();
            }
        });

        btnDelete.setBounds(140, 280, 110, 30);
        btnDelete.setIcon(new ImageIcon("src/Images/Delete.png"));  // Set icon cho button delete
        Panel.add(btnDelete);

        // Button Update  
        JButton btnUpdate = new JButton(" Update");
        btnUpdate.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnUpdate.setBounds(260, 280, 120, 30);
        btnUpdate.setIcon(new ImageIcon("src/Images/Save.png"));
        Panel.add(btnUpdate);

        btnUpdate.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent arg0) {
                int id = Integer.parseInt(txtID.getText());
                // Tạo câu  lệnh update cho truy vấn
                String sql = "UPDATE quanlynhatro.khachhang SET TenKH=?, SoCMND=?, GioiTinh=?, DiaChi=?, NgheNghiep=?, SoDienThoaiKH=?, HinhAnhKH=? WHERE MaKH=?";

                // Images
                FileInputStream fis;
                try {
                    //thêm có hình ảnh
                    if (filename != null) {
                        File imgfile = new File(filename);
                        FileInputStream fin = new FileInputStream(imgfile);

                        stmt = conn.prepareStatement(sql);
                        stmt.setString(1, txtName.getText());
                        stmt.setInt(2, Integer.parseInt(txtCMND.getText()));
                        stmt.setString(3, txtGT.getText());
                        stmt.setString(4, txtDiaChi.getText());
                        stmt.setString(5, txtNgheNghiep.getText());
                        stmt.setInt(6, Integer.parseInt(txtDT.getText()));
                        stmt.setBinaryStream(7, fin, (int) imgfile.length());
                        stmt.setInt(8, id);
                        stmt.executeUpdate();
                        JOptionPane.showMessageDialog(frmKhachHang, "Cập nhật thành công");
                    }
                    //thêm không hình ảnh
                    if (filename == null) {
                        sql = "UPDATE quanlynhatro.khachhang SET TenKH=?, SoCMND=?, GioiTinh=?, DiaChi=?, NgheNghiep=?, SoDienThoaiKH=? WHERE MaKH=?";
                        stmt = conn.prepareStatement(sql);

                        stmt.setString(1, txtName.getText());
                        stmt.setInt(2, Integer.parseInt(txtCMND.getText()));
                        stmt.setString(3, txtGT.getText());
                        stmt.setString(4, txtDiaChi.getText());
                        stmt.setString(5, txtNgheNghiep.getText());
                        stmt.setInt(6, Integer.parseInt(txtDT.getText()));
                        stmt.setInt(7, id);
                        stmt.executeUpdate();
                        JOptionPane.showMessageDialog(frmKhachHang, "Cập nhật thành công");
                        System.out.println("Update ok");
                    }

                } catch (Exception e) {
                    // TODO: handle exception
                    System.out.println("Loi Update: " + e);
                    JOptionPane.showMessageDialog(frmKhachHang, "Cập nhật dữ liệu thất bại");
                }
                showTable();        // Show lại dữ liệu lên bảng khi cập nhật
            }
        });

        // Button Reload
        JButton btnReload = new JButton(" Reload");
        btnReload.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnReload.setBounds(390, 280, 120, 30);
        btnReload.setIcon(new ImageIcon("src/Images/update.png"));
        Panel.add(btnReload);

        btnReload.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                showTable();
            }
        });

        // Button Browse
        JButton btnBrowse = new JButton("Browse");
        btnBrowse.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnBrowse.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                // Thực hiện lấy images đưa vào label images
                JFileChooser fileChooser = new JFileChooser();
                FileNameExtensionFilter filter = new FileNameExtensionFilter("images", "jpg", "png");
                fileChooser.setFileFilter(filter);
                
                int i = fileChooser.showOpenDialog(null);
                if (i == JFileChooser.APPROVE_OPTION) {
                    File file = fileChooser.getSelectedFile();
                    filename = file.getAbsolutePath();
                    try {
                        bi = ImageIO.read(file);
                        ImageIcon icon = new ImageIcon(bi);
                        lblImages.setIcon(icon);
                    } catch (Exception e2) {
                        System.err.println("Browse images err" + e2);
                    }
                }

            }
        });
        btnBrowse.setBounds(512, 240, 90, 30);
        Panel.add(btnBrowse);

        // Tạo combobox để search
        JComboBox comboBox = new JComboBox();
        comboBox.setModel(new DefaultComboBoxModel(new String[]{"All Search", "MaKH", "TenKH"}));
        comboBox.setBounds(520, 280, 110, 30);
        Panel.add(comboBox);

        // Button Search
        JButton btnSearch = new JButton("Search");
        btnSearch.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnSearch.setBounds(660, 240, 90, 30);
        Panel.add(btnSearch);

        // Tạo textfield search
        txtSearch = new JTextField();
        txtSearch.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtSearch.setBounds(640, 280, 110, 30);
        Panel.add(txtSearch);

        // Lắng nghe sự kiện search
        btnSearch.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {

                // Name Column table
                Vector cols = new Vector();

                cols.addElement("MaKH");
                cols.addElement("TenKH");
                cols.addElement("SoCMND");
                cols.addElement("GioiTinh");
                cols.addElement("DiaChi");
                cols.addElement("NgheNghiep");
                cols.addElement("SoDienThoaiKH");
                cols.addElement("Images");

                Vector data = new Vector();
                String Search = txtSearch.getText().trim();
                String Select = comboBox.getSelectedItem().toString();

                switch (Select) {
                    case "All Search":
                        String sql = "Select * From quanlynhatro.khachhang";

                        try {
                            stmt = conn.prepareStatement(sql);
                            rs = stmt.executeQuery();
                            //int row = 0;
                            while (rs.next()) {
                                //  Đưa dữ liệu lên bảng
                                Vector khachhang = new Vector();
                                khachhang.addElement(rs.getString("MaKH"));
                                khachhang.addElement(rs.getString("TenKH"));
                                khachhang.addElement(rs.getInt("SoCMND"));
                                khachhang.addElement(rs.getString("GioiTinh"));
                                khachhang.addElement(rs.getString("DiaChi"));
                                khachhang.addElement(rs.getString("NgheNghiep"));
                                khachhang.addElement(rs.getInt("SoDienThoaiKH"));
                                khachhang.addElement(rs.getBytes("HinhAnhKH"));

                                if (khachhang.toString().contains(Search)) {

                                    data.addElement(khachhang);
                                }

                            }
                        } catch (Exception ex) {

                        }
                        break;
                    case "MaKH":
                        try {
                            String sqlPhong = "select * from quanlynhatro.khachhang where MaKH LIKE ?";
                            stmt = conn.prepareStatement(sqlPhong);
                            stmt.setInt(1, Integer.parseInt(txtSearch.getText()));
                            rs = stmt.executeQuery();
                            while (rs.next()) {
                                // Đưa dữ liệu lên bảng
                                Vector khachhang = new Vector();
                                khachhang.addElement(rs.getString("MaKH"));
                                khachhang.addElement(rs.getString("TenKH"));
                                khachhang.addElement(rs.getInt("SoCMND"));
                                khachhang.addElement(rs.getString("GioiTinh"));
                                khachhang.addElement(rs.getString("DiaChi"));
                                khachhang.addElement(rs.getString("NgheNghiep"));
                                khachhang.addElement(rs.getInt("SoDienThoaiKH"));
                                khachhang.addElement(rs.getBytes("HinhAnhKH"));

                                data.addElement(khachhang);
                                //
                            }
                        } catch (Exception ex) {
                            System.err.println("Search dữ liệu bị lỗi" + ex);
                        }
                    case "TenKH":
                        try {
                            String sqlName = "Select * From quanlynhatro.khachhang Where TenKH LIKE ?";
                            stmt = conn.prepareStatement(sqlName);  // Thực hiện lệnh
                            stmt.setString(1, txtSearch.getText() + "%");   // Lấy TenKH trong txtSearch
                            rs = stmt.executeQuery();
                            //int row = 0;
                            while (rs.next()) {
                                // Đưa dữ liệu lên bảng
                                Vector khachhang = new Vector();
                                khachhang.addElement(rs.getString("MaKH"));
                                khachhang.addElement(rs.getString("TenKH"));
                                khachhang.addElement(rs.getInt("SoCMND"));
                                khachhang.addElement(rs.getString("GioiTinh"));
                                khachhang.addElement(rs.getString("DiaChi"));
                                khachhang.addElement(rs.getString("NgheNghiep"));
                                khachhang.addElement(rs.getInt("SoDienThoaiKH"));
                                khachhang.addElement(rs.getBytes("HinhAnhKH"));

                                data.addElement(khachhang);
                                //
                            }
                        } catch (Exception ex) {

                        }
                        break;
                }
                table.setModel(new DefaultTableModel(data, cols));
            }
        });

        // Tạo table 
        table = new JTable();
        // Bắt dự  kiện mouseclicked
        table.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent arg0) {
                int row = table.getSelectedRow();

                txtID.setText(table.getValueAt(row, 0).toString());
                txtName.setText(table.getValueAt(row, 1).toString());
                txtCMND.setText(table.getValueAt(row, 2).toString());
                txtGT.setText(table.getValueAt(row, 3).toString());
                txtDiaChi.setText(table.getValueAt(row, 4).toString());
                txtNgheNghiep.setText(table.getValueAt(row, 5).toString());
                txtDT.setText(table.getValueAt(row, 6).toString());
                
            //lấy hình ảnh của khách hàng
                int id = Integer.parseInt(txtID.getText());
                // Tạo câu lệnh truy vấn
                String sql = "Select * From quanlynhatro.khachhang where MaKH =?";

                try {
                    // Chuẩn bị câu lệnh truy vấn
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, id);
                    rs = stmt.executeQuery();
                    while (rs.next()) {

                        byte[] imagedata = rs.getBytes("HinhAnhKH");
                        ImageIcon format = new ImageIcon(imagedata);
                        lblImages.setIcon(format);
                    }

                } catch (Exception e) {
                    // TODO: handle exception
                    System.out.println("Sự kiện mouse click bị lỗi"+e);
                    
                }
            }
        });
        scrollPane.setViewportView(table);  // Show dữ liệu lên table
    }
}
