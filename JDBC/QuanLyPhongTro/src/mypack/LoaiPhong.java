/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mypack;

import java.awt.EventQueue;
import java.awt.Font;
import java.sql.*;
import java.util.Vector;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;


/**
 *
 * @author NQHUY
 */
public class LoaiPhong {
    // Khai báo biến truy vấn
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;
    // Khai báo form chính và bảng
    JFrame frmLP;
    JTable table;
    public static void main(String[] args ){
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try{
                    LoaiPhong lp= new LoaiPhong();
                    lp.frmLP.setVisible(true);
                }catch(Exception ex){
                    System.err.println("Can not create form");
                }
            }
        });
    }
    
    public LoaiPhong(){
        Initialize();
        try{
            conn=DBConnection.getConnection(); 
        }catch(Exception ex){
            System.out.println("Can not connection ...");
        }
        ShowTable();
    }
    
    public void ShowTable(){
        // Tạo vector để tạo bảng 
        Vector cols= new Vector();
        cols.addElement("MaLoaiPhong");
        cols.addElement("TenLoaiPhong");
        cols.addElement("DienTich");
        // Tạo vector data để chứa dữ liệu
        Vector data= new Vector();
        // Tạo câu lệnh truy vấn 
        String sql= "Select * from quanlynhatro.loaiphong";
        try{
            // Chuẩn bị truy vấn 
            stmt =conn.prepareStatement(sql);
            // Thực hiện truy vấn
            rs= stmt.executeQuery();
            while(rs.next()){
                
                Vector dv= new Vector();
                dv.addElement(rs.getString("MaLoaiPhong"));
                dv.addElement(rs.getString("TenLoaiPhong"));
                dv.addElement(rs.getString("DienTich"));
                
                data.add(dv);
            }
            
        }catch(Exception ex){
            System.out.println("Can not show table and error:"+ex);
        }
        table.setModel(new DefaultTableModel(data,cols));           // Đưa dữ liệu vào table
    }
    
    public void Initialize(){
        // Tạo form chính
        frmLP= new JFrame("Danh mục loại phòng");
        frmLP.setBounds(450,150,500,250);
        frmLP.getContentPane().setLayout(null);
        
        // Tạo label dnah mục loại phòng
        JLabel lblDV = new JLabel("Danh mục loại phòng");
        lblDV.setFont(new Font("Tohama", Font.BOLD, 30));
        lblDV.setBounds(100,20,340,40);
        frmLP.getContentPane().add(lblDV);
        
        // Tạo scrollPane để đưa dữ liệu lên bảng
        JScrollPane scrollPane= new JScrollPane();
        scrollPane.setBounds(20,80,440,120);
        frmLP.getContentPane().add(scrollPane);
        
        table= new JTable();
        scrollPane.setViewportView(table);// Show dữ liệu lên bảng

    }
}
