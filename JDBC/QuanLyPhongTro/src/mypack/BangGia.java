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
public class BangGia {

    // Khai báo form chính và table bảng giá
    JFrame frmBG;
    JTable table;

    // Khai báo biến cho câu lệnh truy vấn
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    BangGia bg = new BangGia();
                    bg.frmBG.setVisible(true);
                } catch (Exception ex) {
                    System.err.println("Can not create form");
                }
            }
        });
    }

    public BangGia() {
        Initialize();
        try {
            conn = DBConnection.getConnection();        // Kết nối cơ sở dữ liệu
        } catch (Exception ex) {
            System.out.println("Can not connection ...");
        }
        ShowTable();
    }

    public void ShowTable() {
        // Tạo vector để tạo table
        Vector cols = new Vector();
        // Thêm các cột vào trong vector 
        cols.addElement("MaBangGia");
        cols.addElement("DonGia");
        cols.addElement("MaPhongTro");
        // Tạo vector data để chưa dữ liệu
        Vector data = new Vector();
        // Tạo câu lệnh truy vấn
        String sql = "Select * from quanlynhatro.banggia";
        try {
            // Chuẩn bị câu lệnh truy vấn 
            stmt = conn.prepareStatement(sql);
            // Thực hiện câu lệnh truy vấn
            rs = stmt.executeQuery();
            while (rs.next()) {

                Vector dv = new Vector();
                dv.addElement(rs.getString("MaBG"));
                dv.addElement(rs.getString("DonGia"));
                dv.addElement(rs.getString("MaPhongTro"));

                data.add(dv);       // Đưa dữ liệu vào vector data
            }

        } catch (Exception ex) {
            System.out.println("Can not show table and error:" + ex);
        }
        // Đưa dữ liệu vào table
        table.setModel(new DefaultTableModel(data, cols));  
    }

    public void Initialize() {
        // Tạo form chính 
        frmBG = new JFrame("Danh mục bảng giá");
        frmBG.setBounds(450, 150, 500, 250);
        frmBG.getContentPane().setLayout(null);

        // Tạo label dnah mục bảng giá
        JLabel lblBG = new JLabel("Danh mục bảng giá");
        lblBG.setFont(new Font("Tohama", Font.BOLD, 30));
        lblBG.setBounds(120, 20, 340, 40);
        frmBG.getContentPane().add(lblBG);

        // Tạo bảng để show dữ liệu lên
        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setBounds(20, 80, 440, 120);
        frmBG.getContentPane().add(scrollPane);

        // Tạo bảng
        table = new JTable();
        scrollPane.setViewportView(table);  // show dữ liệu lên trên bảng
    }
}
