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
import java.sql.*;
import java.util.Vector;
import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;

public class DichVu {
    
    // Khai báo form dịch vụ và bảng dịch vụ
    JFrame frmDV;
    JTable table;
    
    // Khai báo biến truy vấn 
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;
    
    public static void main(String[] args ){
        // Lắng nghe sự kiện
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try{
                    DichVu dv= new DichVu();
                    dv.frmDV.setVisible(true);
                }catch(Exception ex){
                    System.err.println("Can not create form");
                }
            }
        });
    }
    
    public DichVu(){
        Initialize();
        try{
            conn=DBConnection.getConnection();          // Thực hiện kết nối với cơ sở dữ liệu
        }catch(Exception ex){
            System.out.println("Can not connection ...");
        }
        ShowTable();
    }
    
    public void ShowTable(){
        // Tạo vector để tạo ra bảng
        Vector cols= new Vector();
        // Thêm vào các cột cho bảng
        cols.addElement("MaDichVu");
        cols.addElement("TenDichVu");
        cols.addElement("GiaDichVu");
        // Tạo vector data chứa dữ liệu
        Vector data= new Vector();
        // Tạo câu lệnh truy vấn
        String sql= "Select * from quanlynhatro.dichvu";
        try{
            // Chuẩn bị câu lệnh truy vấn
            stmt =conn.prepareStatement(sql);
            // Thực hiện câu lệnh truy vấn
            rs= stmt.executeQuery();
            while(rs.next()){
                Vector dv= new Vector();
                dv.addElement(rs.getString("MaDichVu"));
                dv.addElement(rs.getString("TenDichVu"));
                dv.addElement(rs.getString("GiaDichVu"));
                
                data.add(dv);       // Đưa dữ liệu vào vector data 
            }
            
        }catch(Exception ex){
            System.out.println("Can not show table and error:"+ex);
        }
        // Set dữ liệu lên bảng 
        table.setModel(new DefaultTableModel(data,cols));
    }
    
    public void Initialize(){
        // Tạo form chính 
        frmDV= new JFrame("Danh mục dịch vụ");
        frmDV.setBounds(450,150,500,250);
        frmDV.getContentPane().setLayout(null);
        
        // Tạo label dnah mục dịch vụ
        JLabel lblDV = new JLabel("Danh mục dịch vụ");
        lblDV.setFont(new Font("Tohama", Font.BOLD, 30));
        lblDV.setBounds(120,20,340,40);
        frmDV.getContentPane().add(lblDV);
        
        // Tạo bảng để show dữ liệu lên
        JScrollPane scrollPane= new JScrollPane();
        scrollPane.setBounds(20,80,440,120);
        frmDV.getContentPane().add(scrollPane);
        
        // Tạo bảng
        table= new JTable();
        scrollPane.setViewportView(table);  // show dữ liệu lên trên bảng
    }
}
