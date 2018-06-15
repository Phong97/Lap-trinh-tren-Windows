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
import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.event.*;
import java.sql.*;
import java.util.Vector;
import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;

public class PhongTro {

    // Tạo form phòng trọ
    JFrame frmPT;

    // Khai báo biến thực hiện câu lệnh
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    // Khai báo table
    JTable table;
    JTable table2;
    JTable table3;

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    PhongTro pt = new PhongTro();
                    //pt.frmPT.setMaximumSize(new Dimension(800, 570));
                    pt.frmPT.setVisible(true);
                } catch (Exception ex) {
                    System.out.println("Can't create form ...");
                }
            }
        });
    }

    public PhongTro() {
        Initialize();
        try {
            conn = DBConnection.getConnection();
        } catch (Exception ex) {
            System.out.println("Can't connection ...");
        }
        ShowTable1();
        ShowTable2();
        ShowTable3();
    }

    // Show thong tin ve phong tro
    public void ShowTable1() {
        // Name Column table
        Vector cols = new Vector();
        cols.addElement("PhongTro");
        cols.addElement("TenPhong");
        cols.addElement("SoLuongNguoi");
        cols.addElement("MaLoaiPhong");
        cols.addElement("MaNhaTro");

        // Data table
        Vector data = new Vector();
        // Tạo câu lệnh truy vấn
        String sql = "Select * From quanlynhatro.phongtro";
        try {
            // Chuẩn bị câu lệnh truy vấn
            stmt = conn.prepareStatement(sql);
            // Thực hiện câu lệnh truy vấn
            rs = stmt.executeQuery();
            int row = 0;
            while (rs.next()) {
                //  Đưa dữ liệu lên bảng
                Vector pt = new Vector();
                pt.addElement(rs.getString("MaPhongTro"));
                pt.addElement(rs.getString("TenPhongTro"));
                pt.addElement(rs.getInt("SoLuongNguoi"));
                pt.addElement(rs.getString("MaLoaiPhong"));
                pt.addElement(rs.getString("MaNhaTro"));

                data.add(pt);       // Đưa dữ liệu lên vector data
            }

        } catch (Exception e) {
            // TODO: handle exception
            System.out.println("Show dữ liệu phòng trọ bị lỗi" + e);
        }
        // Set dữ liệu lên table
        table.setModel(new DefaultTableModel(data, cols));
    }

    // Show thong tin ve Hop dong
    public void ShowTable2() {
        // Name Column table
        Vector cols = new Vector();
        cols.addElement("MaHopDong");
        cols.addElement("MaKH");
        cols.addElement("NgayLapHD");
        cols.addElement("ThoiHanHD");

        // Data table
        Vector data = new Vector();
        String sql = "Select * From quanlynhatro.hopdongthue";
        try {
            stmt = conn.prepareStatement(sql);
            rs = stmt.executeQuery();
            int row = 0;
            while (rs.next()) {
                //  Đưa dữ liệu lên bảng
                Vector hd = new Vector();
                hd.addElement(rs.getString("MaHopDong"));
                hd.addElement(rs.getString("MaKH"));
                hd.addElement(rs.getString("NgayLapHD"));
                hd.addElement(rs.getString("ThoiHanHD"));

                data.add(hd);
            }

        } catch (Exception e) {
            // TODO: handle exception
        }
        table2.setModel(new DefaultTableModel(data, cols));
    }

    // Show thong tin ve khach hang 
    public void ShowTable3() {

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
        String sql = "Select * From quanlynhatro.khachhang";
        try {
            stmt = conn.prepareStatement(sql);
            rs = stmt.executeQuery();
            int row = 0;
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

                data.add(khachhang);

            }

        } catch (Exception e) {
            // TODO: handle exception
        }
        table3.setModel(new DefaultTableModel(data, cols));
    }

    // Show thông tin hợp đồng khi click chuột vào phòng trọ
    public void ShowHD() {
        // Lấy giá trị dòng khi click chuột 
        int row1 = table.getSelectedRow();
        // Name Column table
        Vector cols = new Vector();
        cols.addElement("MaHopDong");
        cols.addElement("MaKH");
        cols.addElement("NgayLapHD");
        cols.addElement("ThoiHanHD");
        // Tạo vector data để lưu dữ liệu
        Vector data = new Vector();

        try {
            // Tạo câu lệnh truy vấn select mã hợp đồng
            String sqlName = "Select * From quanlynhatro.hopdongthue Where MaHopDong LIKE ?";
            // Lấy mã phòng trọ trong bảng phòng trọ
            int id = Integer.parseInt(table.getValueAt(row1, 0).toString());
            // Khởi tạo lớp Chi tiết hợp đồng
            ChiTietHopDong cthd = new ChiTietHopDong();
            // Lấy mã hợp đồng trong bảng chi tiết hợp đồng
            int mahd = Integer.parseInt(cthd.table.getValueAt(id, 3).toString());
            stmt = conn.prepareStatement(sqlName);  // Thực hiện lệnh
            //
            stmt.setInt(1, Integer.parseInt(table.getValueAt(mahd - 1, 0).toString()));
            rs = stmt.executeQuery();

            while (rs.next()) {
                //  Đưa dữ liệu lên bảng
                Vector hd = new Vector();
                hd.addElement(rs.getString("MaHopDong"));
                hd.addElement(rs.getString("MaKH"));
                hd.addElement(rs.getString("NgayLapHD"));
                hd.addElement(rs.getString("ThoiHanHD"));

                data.add(hd);
            }
        } catch (Exception ex) {
            System.out.println("Error1 : " + ex);
        }
        table2.setModel(new DefaultTableModel(data, cols));
    }

    // Show thông tin khách hàng khi click chuột vào phòng trọ
    public void ShowKH() {

        int row1 = table.getSelectedRow();

        // Set show lai bang khach hang
        Vector cols1 = new Vector();
        cols1.addElement("MaKH");
        cols1.addElement("TenKH");
        cols1.addElement("SoCMND");
        cols1.addElement("GioiTinh");
        cols1.addElement("DiaChi");
        cols1.addElement("NgheNghiep");
        cols1.addElement("SoDienThoaiKH");
        cols1.addElement("Images");
        Vector data1 = new Vector();
        try {
            // Tạo câu lệnh truy vấn select mã hợp đồng
            String sqlName = "Select * From quanlynhatro.khachhang Where MaKH LIKE ?";
            // Lấy mã phòng trọ trong bảng phòng trọ
            int id = Integer.parseInt(table.getValueAt(row1, 0).toString());
            // Khởi tạo lớp Chi tiết hợp đồng
            ChiTietHopDong cthd = new ChiTietHopDong();
            // Lấy mã hợp đồng trong bảng chi tiết hợp đồng
            int mahd = Integer.parseInt(cthd.table.getValueAt(id - 1, 3).toString());
            // Lấy mã khách hàng từ bảng Hợp đồng thuê
            int makh = Integer.parseInt(table2.getValueAt(mahd, 1).toString());

            stmt = conn.prepareStatement(sqlName);  // Thực hiện lệnh
            stmt.setInt(1, Integer.parseInt(table2.getValueAt(makh, 1).toString()));
            rs = stmt.executeQuery();
            while (rs.next()) {
                // Đưa dữ liệu lên bảng
                Vector kh = new Vector();

                kh.addElement(rs.getString("MaKH"));
                kh.addElement(rs.getString("TenKH"));
                kh.addElement(rs.getInt("SoCMND"));
                kh.addElement(rs.getString("GioiTinh"));
                kh.addElement(rs.getString("DiaChi"));
                kh.addElement(rs.getString("NgheNghiep"));
                kh.addElement(rs.getInt("SoDienThoaiKH"));
                kh.addElement(rs.getBytes("HinhAnhKH"));

                data1.addElement(kh);
            }
        } catch (Exception ex) {
            System.out.println("Error show table khach hang" + ex);
        }
        table3.setModel(new DefaultTableModel(data1, cols1));
    }

    public void Initialize() {
        // Tạo form chính
        frmPT = new JFrame("Phòng trọ");
        frmPT.setBounds(320, 80, 800, 570);
        frmPT.getContentPane().setLayout(null);

        // Panel thong tin chung
        JPanel Panel = new JPanel();
        Panel.setBorder(new TitledBorder(null, "Thông tin chi tiết về phòng trọ và hợp đồng của khách hàng",
                TitledBorder.CENTER, TitledBorder.TOP, null, null));
        Panel.setBounds(10, 10, 765, 510);
        frmPT.getContentPane().add(Panel);
        Panel.setLayout(null);

        // Button Show All
        JButton btnShowAll = new JButton("Show All");
        btnShowAll.setFont(new Font("Tohama", Font.BOLD, 13));
        btnShowAll.setBounds(337, 33, 100, 30);
        Panel.add(btnShowAll);

        // Lắng nghe sự kiện button show 
        btnShowAll.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                ShowTable1();
                ShowTable2();
                ShowTable3();
            }
        });

        // Tạo bảng
        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setBounds(20, 80, 360, 180);
        Panel.add(scrollPane);

        table = new JTable();
        // Sự kiện mouseclick cho bảng table của Bảng Phòng trọ
        table.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent arg0) {
//                ShowTable1();
//                ShowTable2();
//                ShowTable3();
                ShowHD();
                //ShowKH();
            }
        });
        scrollPane.setViewportView(table);

        // Tạo bảng hợp đồng thuê
        table2 = new JTable();
        // Tạo bảng
        JScrollPane scrollPane2 = new JScrollPane();
        scrollPane2.setBounds(400, 80, 350, 180);
        Panel.add(scrollPane2);

        scrollPane2.setViewportView(table2);

        // Tạo sự kiện mouseclick cho bảng Hợp đồng thuê
        table2.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent arg0) {
                // Lấy dòng trên table
                int row1 = table2.getSelectedRow();
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

                try {

                    String sqlName = "Select * From quanlynhatro.khachhang Where MaKH LIKE ?";
                    int row = Integer.parseInt(table2.getValueAt(row1, 1).toString());
                    stmt = conn.prepareStatement(sqlName);  // Thực hiện lệnh
                    stmt.setInt(1, Integer.parseInt(table3.getValueAt(row - 1, 0).toString()));
//                    System.out.println("table3.getValueAt(row, 0).toString():"+table3.getValueAt(row-1, 0).toString());
                    rs = stmt.executeQuery();

                    while (rs.next()) {
                        // Đưa dữ liệu lên bảng
                        Vector kh = new Vector();

                        kh.addElement(rs.getString("MaKH"));
                        kh.addElement(rs.getString("TenKH"));
                        kh.addElement(rs.getInt("SoCMND"));
                        kh.addElement(rs.getString("GioiTinh"));
                        kh.addElement(rs.getString("DiaChi"));
                        kh.addElement(rs.getString("NgheNghiep"));
                        kh.addElement(rs.getInt("SoDienThoaiKH"));
                        kh.addElement(rs.getBytes("HinhAnhKH"));

                        data.addElement(kh);

                        System.out.println("huy");
                    }
                } catch (Exception ex) {
                    System.out.println("Error: " + ex);
                }
                table3.setModel(new DefaultTableModel(data, cols));
            }
        });

        // Tạo bảng
        table3 = new JTable();

        JScrollPane scrollPane3 = new JScrollPane();
        scrollPane3.setBounds(20, 290, 730, 200);
        Panel.add(scrollPane3);

        scrollPane3.setViewportView(table3);
    }
}
