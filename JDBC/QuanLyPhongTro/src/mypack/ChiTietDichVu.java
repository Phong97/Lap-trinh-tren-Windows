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
public class ChiTietDichVu {

    // Khai báo form chính và bảng
    JFrame frmctdv;
    JTable table;

    // Chuẩn bị dữ liệu kết nối
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    public static void main(String[] args) {
        // Lắng nghe sự kiện
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    ChiTietDichVu ctdv = new ChiTietDichVu();
                    ctdv.frmctdv.setVisible(true);
                } catch (Exception ex) {
                    System.err.println("Can not create form");
                }
            }
        });
    }

    public ChiTietDichVu() {
        Initialize();       // Gọi lại hàm Initialize 
        try {
            conn = DBConnection.getConnection();    // Gọi kết nối với cơ sở dữ liệu
        } catch (Exception ex) {
            System.out.println("Can not connection ...");
        }
        ShowTable();        // Show table
    }

    public void ShowTable() {
        // Tạo vector 
        Vector cols = new Vector();
        // Thêm các cột
        cols.addElement("MaChiTietDV");
        cols.addElement("NgaySuDung");
        cols.addElement("MaDichVu");
        cols.addElement("MaChiTietHD");
        // tạo vector chứa dữ liệu
        Vector data = new Vector();
        // Tạo câu lệnh truy vấn 
        String sql = "Select * from quanlynhatro.chitietdichvu";
        try {
            // Chuẩn bị câu lệnh truy vấn
            stmt = conn.prepareStatement(sql);
            rs = stmt.executeQuery();       // Thực thi câu lệnh truy vấn
            while (rs.next()) {
                Vector dv = new Vector();
                dv.addElement(rs.getString("MaChiTietDV"));
                dv.addElement(rs.getString("NgaySuDung"));
                dv.addElement(rs.getString("MaDichVu"));
                dv.addElement(rs.getString("MaChiTietHD"));
                
                data.add(dv);   // Thêm dữ liệu vào vector data
            }

        } catch (Exception ex) {
            System.out.println("Can not show table and error:" + ex);
        }
        table.setModel(new DefaultTableModel(data, cols));  // Set dữ liệu lên trên bảng
    }

    public void Initialize() {
        // Tạo form chính 
        frmctdv = new JFrame("Danh mục chi tiết dịch vụ");
        frmctdv.setBounds(450, 150, 500, 250);
        frmctdv.getContentPane().setLayout(null);

        // Tạo label dnah mục dịch vụ
        JLabel lblDV = new JLabel("Danh mục chi tiết dịch vụ");
        lblDV.setFont(new Font("Tohama", Font.BOLD, 30));
        lblDV.setBounds(60, 20, 440, 40);
        frmctdv.getContentPane().add(lblDV);

        // Tạo bảng để show dữ liệu lên
        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setBounds(20, 80, 440, 120);
        frmctdv.getContentPane().add(scrollPane);

        // Tạo bảng
        table = new JTable();
        scrollPane.setViewportView(table);  // show dữ liệu lên trên bảng
    }
}
