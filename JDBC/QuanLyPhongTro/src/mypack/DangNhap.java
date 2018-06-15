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
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import java.sql.*;
import javax.swing.*;
import javax.swing.border.TitledBorder;
import javax.swing.event.*;

public class DangNhap {

    // Khai báo biến toàn cục 
    public JTextField txtUser;
    public JPasswordField txtPass;
    public JFrame frmLogin;

    //Khai báo biến cho thực hiện truy vấn
    private Connection conn;
    private PreparedStatement stmt;
    private ResultSet rs;

    public static void main(String[] args) {
        // Lắng nghe sự kiện
        EventQueue.invokeLater(new Runnable() {
            public void run() {
                try {
                    DangNhap Login = new DangNhap();
                    Login.frmLogin.setVisible(true);
                } catch (Exception e) {
                    System.out.println("Can not create :"+e);
                }
            }
        });
    }

    public DangNhap() {
        Initialize();
        try {
            conn = DBConnection.getConnection();
        } catch (Exception e) {
            // TODO: handle exception
            System.err.println("Can not connect :"+e);
        }
    }

    private void Initialize() {
        // Tạo form chính
        frmLogin = new JFrame("Đăng nhập");
        frmLogin.setBounds(360, 154, 400, 220);
        frmLogin.getContentPane().setLayout(null);

        // Panel
        JPanel Login= new JPanel();
        Login.setBorder(new TitledBorder(null,"Đăng nhập",TitledBorder.LEADING,TitledBorder.TOP,null,null));
        //Login.setFont(new Font("Tahoma",Font.BOLD,16));
        Login.setBounds(10,10,362,160);
        frmLogin.getContentPane().add(Login);
        Login.setLayout(null);
        
        // Tạo label tên đăng nhập
        JLabel lblUser= new JLabel("Tên đăng nhập :");
        lblUser.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblUser.setBounds(25,25,150,27);
        Login.add(lblUser);
        
        // Tạo label mật khẩu
        JLabel lblPass= new JLabel("Mật khẩu :");
        lblPass.setFont(new Font("Tahoma", Font.BOLD, 13));
        lblPass.setBounds(25,60,150,27);
        Login.add(lblPass);
        
        // Tạo textfiled cho tên đăng nhập
        txtUser= new JTextField();
        txtUser.setBounds(160,25,180,27);
        txtUser.setFont(new Font("Tahoma", Font.BOLD, 13));
        Login.add(txtUser);
        txtUser.setColumns(10); 
        
        // Tạo textfield cho mật khẩu
        txtPass= new JPasswordField();
        txtPass.setBounds(160,60,180,27);
        txtPass.setFont(new Font("Tahoma", Font.BOLD, 13));
        Login.add(txtPass);
        txtPass.setColumns(10); 
        
        // Tạo button đăng nhập
        JButton btnLogin= new JButton(" Đăng nhập");
        btnLogin.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnLogin.setBounds(25,110,140,30);
        btnLogin.setIcon(new ImageIcon("src/Images/Login.png"));
        Login.add(btnLogin);
        
        // Lắng nghe sự kiện button đăng nhập
        btnLogin.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Kiểm tra tên đăng nhập và mật khẩu khi đăng nhập
                if((txtUser.getText().equals("admin")) && (txtPass.getText().equals("123")))
               {
                   Main main=new Main();        // Gọi lại lớp main
                   main.frmMain.setVisible(true);// Show form
                   // Thực hiện đóng form login khi form main hiện ra
                   frmLogin.dispatchEvent(new WindowEvent(frmLogin, WindowEvent.WINDOW_CLOSING));        
               }
            }
        });
        
        // Tạo butotn exit
        JButton btnExit= new JButton(" Thoát");
        btnExit.setFont(new Font("Tahoma", Font.BOLD, 13));
        btnExit.setBounds(200,110,140,30);
        btnExit.setIcon(new ImageIcon("src/Images/Exit.png"));
        Login.add(btnExit);
        
        // Lắng nghe sự kiện exit
        btnExit.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Thoát chương trình khi nhấn nút exit 
               frmLogin.dispatchEvent(new WindowEvent(frmLogin, WindowEvent.WINDOW_CLOSING));
            }
        });
    }
}
