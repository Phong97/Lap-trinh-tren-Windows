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
import javax.naming.spi.DirStateFactory;
import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;
import javax.xml.transform.Result;
import com.toedter.calendar.JDateChooser;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.io.File;
import java.io.FileInputStream;
import java.text.SimpleDateFormat;

/**
 *
 * @author NQHUY
 */
public class HopDongThue {

    // Khai báo biến cho thực hiện truy vấn
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    // Khai báo form chính và table hợp đồng thuê phòng
    JFrame frmHDT;
    JTable table;
    private JTextField txtMaHD,txtThoiHanHD;
    private JDateChooser txtDate;
    // Khai báo biến để thêm ngày 
    java.util.Date date;
    String dateInput;
    
    // Tạo một vector data để lưu trữ dữ liệu của combobox
    Vector cbMaKH = new Vector();

    public static void main(String[] agrs) {
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    HopDongThue hdt = new HopDongThue();
                    hdt.frmHDT.setVisible(true);
                } catch (Exception ex) {
                    System.err.println("Can not create form:" + ex);
                }
            }
        });
    }

    public HopDongThue() {
        Initalize();
        try {
            conn = DBConnection.getConnection();        // Thực hiện kết nối với cơ sở dữ liệu
        } catch (Exception ex) {
            System.err.println("Can not connect :" + ex);
        }
        ShowTable();        // Show lai table
        ShowCombobox();     // Show lại dữ liệu combobox
    }

    public void ShowTable() {
        // Tạo một vector để tạo các cột 
        Vector cols = new Vector();
        cols.addElement("MaHopDong");
        cols.addElement("MaKH");
        cols.addElement("NgayLapHD");
        cols.addElement("ThoiHanHD");

        // Tạo vector để chứa dữ liệu 
        Vector data = new Vector();
        String sql = "Select * From quanlynhatro.hopdongthue";
        try {
            // Chuẩn bị câu lệnh truy vấn
            stmt = conn.prepareStatement(sql);
            // Thực hiện câu lệnh truy vấn
            rs = stmt.executeQuery();
            while (rs.next()) {
                //  Đưa dữ liệu lên bảng
                Vector khachhang = new Vector();
                khachhang.addElement(rs.getInt("MaHopDong"));
                khachhang.addElement(rs.getInt("MaKH"));
                khachhang.addElement(rs.getDate("NgayLapHD"));
                khachhang.addElement(rs.getInt("ThoiHanHD"));

                data.add(khachhang);    // Đưa dữ liệu vào data
            }

        } catch (Exception ex) {
            System.err.println("Can not mapping data " + ex);
        }
        table.setModel(new DefaultTableModel(data, cols));  // set dữ liệu vào bảng
    }

    public void ShowCombobox() {
        cbMaKH.clear();         // Reset combobox mã khách hàng
        // Tạo câu lệnh truy vấn
        String sql = "select * from quanlynhatro.khachhang";
        try {
            // Chuẩn bị câu lệnh truy vấn
            stmt = conn.prepareStatement(sql);
            // Thực hiện câu lệnh truy vấn
            rs = stmt.executeQuery();
            while (rs.next()) {
                cbMaKH.addElement(rs.getString("MaKH"));
            }
        } catch (Exception ex) {
            System.out.println("Can not show data in combobox" + ex);
        }
    }

    private void Initalize() {
        // Tạo form chính 
        frmHDT = new JFrame("Quản lý hợp đồng thuê");
        frmHDT.setBounds(320, 80, 600, 440);
        frmHDT.getContentPane().setLayout(null);

        // Panel chung Thông tin 
        JPanel Panel = new JPanel();
        Panel.setBorder(new TitledBorder(null, "Hợp đồng thuê phòng", TitledBorder.LEADING, TitledBorder.TOP, null, null));
        Panel.setBounds(10, 10, 565, 380);
        frmHDT.getContentPane().add(Panel);
        Panel.setLayout(null);

        // Tọa label mã hợp đồng
        JLabel lblMaHD = new JLabel("Mã hợp đồng :");
        lblMaHD.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblMaHD.setBounds(20, 30, 170, 27);
        Panel.add(lblMaHD);

        // Tạo textfield mã hợp đồng
        txtMaHD = new JTextField();
        txtMaHD = new JTextField();
        txtMaHD.setFont(new Font("Tahoma", Font.BOLD, 13));
        txtMaHD.setBounds(150, 30, 110, 30);
        Panel.add(txtMaHD);

        // Tạo label mã khách hàng
        JLabel lblMaKH = new JLabel("Mã khách hàng :");
        lblMaKH.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblMaKH.setBounds(300, 30, 170, 27);
        Panel.add(lblMaKH);

        // Tạo combobox để lấy dữ liệu mã khách hàng
        JComboBox comboBox = new JComboBox(cbMaKH);
        comboBox.setBounds(430, 30, 110, 30);
        Panel.add(comboBox);

        // Ngay thue
        JLabel lblNgay = new JLabel("Ngày bắt đầu hợp đồng :");
        lblNgay.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblNgay.setBounds(20, 80, 170, 27);
        Panel.add(lblNgay);

        // Tạo textfield ngày
        txtDate = new JDateChooser();
        txtDate.setBounds(200, 80, 120, 27);
        Panel.add(txtDate);

        // Button Insert 
        JButton btnInsert = new JButton(" Insert");
        btnInsert.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnInsert.setBounds(20, 135, 110, 30);
        btnInsert.setIcon(new ImageIcon("src/Images/insert2.png"));
        Panel.add(btnInsert);

        // Button Update  
        JButton btnUpdate = new JButton(" Update");
        btnUpdate.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnUpdate.setBounds(425, 135, 120, 30);
        btnUpdate.setIcon(new ImageIcon("src/Images/Save.png"));
        Panel.add(btnUpdate);

        // Button cập nhật chỉnh sữa dữ liệu
        btnUpdate.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent arg0) {
                // Lấy mã hợp đồng trên textfield mã hợp đồng
                int id = Integer.parseInt(txtMaHD.getText());
                // Tạo câu truy vấn 
                String sql = "Update quanlynhatro.hopdongthue set MaKH=?,NgayLapHD=?"
                        + "where MaHopDong=?";
                // Date
                date = txtDate.getDate();
                dateInput = new SimpleDateFormat("yyyy-MM-dd").format(date);
                try {
                    // Chuẩn bị câu lệnh truy vấn
                    stmt = conn.prepareStatement(sql);
                    stmt.setString(1, String.valueOf(comboBox.getSelectedItem()));
                    stmt.setString(2, dateInput);
                    stmt.setInt(3, id);
                    stmt.executeUpdate();       // Thực hiện câu lệnh truy vấn
                    JOptionPane.showMessageDialog(frmHDT, "Cập nhật dữ liệu thành công");
                } catch (Exception e) {
                    // TODO: handle exception
                    System.out.println("Loi Update: " + e);
                    JOptionPane.showMessageDialog(frmHDT, "Cập nhật dữ liệu thất bại");
                }
                ShowTable();    // Show lại table khi cập nhật dữ liệu thành công
            }
        });

        // Button Delete
        JButton btnDelete = new JButton(" Delete");
        btnDelete.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnDelete.setBounds(155, 135, 110, 30);
        btnDelete.setIcon(new ImageIcon("src/Images/Delete.png"));
        Panel.add(btnDelete);

        // Button Reload
        JButton btnReload = new JButton("Reload");
        btnReload.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnReload.setBounds(290, 135, 110, 30);
        btnReload.setIcon(new ImageIcon("src/Images/update.png"));
        Panel.add(btnReload);

        // Lắng nghe sự kiện 
        btnReload.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                ShowTable();
            }
        });
        // Tạo bảng
        table = new JTable();

        // Tạo scrollPane để đưa dữ liệu lên bảng
        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setBounds(10, 190, 546, 180);
        Panel.add(scrollPane);

        // Lắng nghe sự kiện của click chuột
        table.addMouseListener(new MouseAdapter() {
            @Override
            public void mouseClicked(MouseEvent arg0) {
                // Lấy số dòng khi click vào table
                int row = table.getSelectedRow();
                // Show dữ liệu từ bảng lên textfield và combobox
                txtMaHD.setText(table.getValueAt(row, 0).toString());
                comboBox.setSelectedItem(table.getValueAt(row, 1).toString());
                txtDate.setDate((Date) table.getValueAt(row, 2));
                txtThoiHanHD.setText(table.getValueAt(row, 3).toString());
            }
        });

        scrollPane.setViewportView(table);
        
        // Lắng nghe sự kiện button thêm
        btnInsert.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Tạo câu  lệnh truy vấn
                String sql = "Insert into quanlynhatro.hopdongthue"
                        + "(MaHopDong,MaKH,NgayLapHD)"
                        + "Values(?,?,?)";
                // Lấy ngày từ textfield
                date = txtDate.getDate();
                dateInput = new SimpleDateFormat("yyyy-MM-dd").format(date);
                try {
                    // Thực thi câu lệnh
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, Integer.parseInt(txtMaHD.getText()));
                    stmt.setInt(2, Integer.parseInt(comboBox.getSelectedItem().toString()));
                    stmt.setString(3, dateInput);
                    stmt.executeUpdate();
                    JOptionPane.showMessageDialog(frmHDT, "Thêm dữ liệu thành công");
                } catch (Exception ex) {
                    System.err.println("Can not insert :" + ex);
                    JOptionPane.showMessageDialog(frmHDT, "Thêm dữ liệu thất bại");
                }
                ShowTable();        // Show lại dữ liệu lên bảng khi thêm dữ liệu
            }
        });
        
        // Lắng nghe sự kiện button xóa
        btnDelete.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Lấy mã hợp đồng đưa vào biến id
               int id = Integer.parseInt(txtMaHD.getText());
               // Chuẩn bị câu lệnh
                String sql = "delete from quanlynhatro.hopdongthue where MaHopDong=?";
                try {
                    // Thực thi câu lệnh
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, id);
                    int reponse = JOptionPane.showConfirmDialog(frmHDT, "Bạn có muốn xóa?",
                            "Xóa phòng trọ", JOptionPane.YES_NO_OPTION);
                    switch (reponse) {
                        case JOptionPane.YES_OPTION:
                            stmt.executeUpdate();       // Thực hiện câu lệnh truy vấn
                            break;
                        case JOptionPane.NO_OPTION:
                            break;                      // Thoát khi chọn NO
                        case JOptionPane.CLOSED_OPTION:
                            break;                      // Thoát khi close
                        default:
                            break;
                    }
                } catch (Exception ex) {
                    System.err.println("Can't delete " + ex);
                    JOptionPane.showMessageDialog(frmHDT, "Xóa dữ liệu thất bại");
                }
                ShowTable();        // Show lại table khi xóa dữ liệu 
            }
        });
        
        // Tạo label thời hạn hợp đồng
        JLabel lblThoiHanHD= new JLabel("Thời hạn hợp đồng :");
        lblThoiHanHD.setFont(new Font("Tohama", Font.BOLD, 13));
        lblThoiHanHD.setBounds(340, 80, 170, 27);
        Panel.add(lblThoiHanHD);
        
        // Tạo textfield thời hạn hợp đồng
        txtThoiHanHD= new JTextField();
        txtThoiHanHD.setFont(new Font("Tohama", Font.BOLD, 13));
        txtThoiHanHD.setBounds(480, 80, 60, 27);
        Panel.add(txtThoiHanHD);
        
    }
}
