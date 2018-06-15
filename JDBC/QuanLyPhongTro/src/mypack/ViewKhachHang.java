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
public class ViewKhachHang {

    // Tạo form chính 
    JFrame frmKhachHang;
    JTable table;

    // Tạo biến truy vấn
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            public void run() {
                try {
                    ViewKhachHang KH = new ViewKhachHang();
                    KH.frmKhachHang.setVisible(true);
                } catch (Exception e) {

                }
            }
        });
    }

    // Show table 
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
        table.setModel(new DefaultTableModel(data, cols));
    }

    public ViewKhachHang() {
        Initialize();
        try {
            conn = DBConnection.getConnection();
        } catch (Exception e) {
            // TODO: handle exception
        }
        showTable();        // Show data lên bảng 
    }

    private void Initialize() {
        // Tạo form chính 
        frmKhachHang = new JFrame("Danh mục khách hàng");
        frmKhachHang.setBounds(320, 80, 800, 420);
        frmKhachHang.getContentPane().setLayout(null);

        // Tạo label danh mục khách hàng
        JLabel lblDV = new JLabel("Danh mục khách hàng");
        lblDV.setFont(new Font("Tohama", Font.BOLD, 30));
        lblDV.setBounds(260,20,350,40);
        frmKhachHang.getContentPane().add(lblDV);
        
        // Tạo bảng
        table = new JTable();
        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setBounds(17, 80, 750, 290);
        frmKhachHang.getContentPane().add(scrollPane);

        scrollPane.setViewportView(table);
    }
}
