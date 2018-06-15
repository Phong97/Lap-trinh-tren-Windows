/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mypack;

import java.awt.EventQueue;
import java.awt.Font;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.Vector;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.table.DefaultTableModel;

/**
 *
 * @author NQHUY
 */
public class ChiTietHopDong {

    // Khai báo form chính và table chi tiết hợp đồng
    JFrame frmCTHD;
    JTable table;

    // Khai báo biến kết nối
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    public static void main(String[] args) {
        // Lắng nghe sự kiện
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    ChiTietHopDong dv = new ChiTietHopDong();
                    dv.frmCTHD.setVisible(true);
                } catch (Exception ex) {
                    System.err.println("Can not create form");
                }
            }
        });
    }

    public ChiTietHopDong() {
        Initialize();   // Gọi lại hàm Initialize
        try {
            conn = DBConnection.getConnection();        // Thực hiện kết nối dữ  liệu
        } catch (Exception ex) {
            System.out.println("Can not connection ...");
        }
        ShowTable();    // Show thông tin bảng lên 
    }

    public void ShowTable() {
        // Tạo  một vector 
        Vector cols = new Vector();
        // Thêm các cột 
        cols.addElement("MaChiTietHD");
        cols.addElement("NgayThue");
        cols.addElement("NgayHetHan");
        cols.addElement("MaHopDong");
        cols.addElement("MaPhongTro");

        // Tạo vector data để chứa dữ liệu
        Vector data = new Vector();
        // Chuẩn bị câu lệnh truy vấn
        String sql = "Select * from quanlynhatro.chitiethopdong";
        try {
            // Chuẩn bị câu lệnh truy vấn
            stmt = conn.prepareStatement(sql);
            // Thực hiện câu lệnh truy vấn
            rs = stmt.executeQuery();
            // Đưa dữ liệu lên bảng
            while (rs.next()) {
                Vector dv = new Vector();
                dv.addElement(rs.getString("MaChiTietHD"));
                dv.addElement(rs.getString("NgayThue"));
                dv.addElement(rs.getString("NgayHetHan"));
                dv.addElement(rs.getString("MaHopDong"));
                dv.addElement(rs.getString("MaPhongTro"));
                data.add(dv);   // Đưa dữ liệu vào vector data
            }

        } catch (Exception ex) {
            System.out.println("Can not show table and error:" + ex);
        }
        table.setModel(new DefaultTableModel(data, cols));  // Set dữ liệu lên bảng
    }

    public void Initialize() {
        // Tạo form chính 
        frmCTHD = new JFrame("Danh mục chi tiết hợp đồng");
        frmCTHD.setBounds(450, 150, 500, 250);
        frmCTHD.getContentPane().setLayout(null);

        // Tạo label danh mục chi tiết hợp đồng
        JLabel lblct = new JLabel("Danh mục chi tiết hợp đồng");
        lblct.setFont(new Font("Tohama", Font.BOLD, 30));
        lblct.setBounds(40, 20, 420, 40);
        frmCTHD.getContentPane().add(lblct);

        // Tạo bảng để show dữ liệu lên
        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setBounds(20, 80, 440, 120);
        frmCTHD.getContentPane().add(scrollPane);

        // Tạo bảng
        table = new JTable();
        scrollPane.setViewportView(table);  // show dữ liệu lên trên bảng
    }
}
