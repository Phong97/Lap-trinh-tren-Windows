/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mypack;

import java.awt.Dimension;
import java.awt.EventQueue;
import java.awt.Image;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import java.awt.image.BufferedImage;
import java.beans.EventHandler;
import java.io.InputStream;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.imageio.ImageIO;
import javax.swing.*;

/**
 *
 * @author NQHUY
 */
public class Main {

    // Tạo các menu và các menuItem 
    JMenu HeThong, XemDM, QLDanhMuc, QLTheoDon, QLTheoNhom, Help, TacGia;
    JMenuItem Pass, Exit, DichVu, KhachHang, LoaiPhong, ChiTietDV, BangGia, ChiTietHD;
    JMenuItem TheoPhong, TheoKhach, TheoHoaDon, TheoPhieuTT;
    JMenuItem KHTheoPhong, TroGiup, ThongTin, HuongDan;
    JMenuItem Huy, Khang, Phong;
    JFrame frmMain;

    public Main() {
        Initialize();
    }

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            public void run() {
                try {
                    Main window = new Main();
                    window.frmMain.setVisible(true);
                } catch (Exception e) {
                    System.out.println("Error :" + e);
                }
            }
        });
    }

    public void Initialize() {
        // Tạo form main
        frmMain = new JFrame("Quản lý phòng trọ");

        JMenuBar mb = new JMenuBar();   //  Tạo ra một menuBar 

        HeThong = new JMenu("Hệ thống");
        Pass = new JMenuItem("Quản lý tài khoản", new ImageIcon("src/Images/Login.png"));
        Exit = new JMenuItem("Thoát", new ImageIcon("src/Images/Exit.png"));
        Exit.setActionCommand("Exit");

        // Thêm MenuItem vào menu Hệ thống
        HeThong.add(Pass);
        HeThong.add(Exit);
        mb.add(HeThong);

        XemDM = new JMenu("Xem danh mục");          // Set tên tiêu đề cho menu
        // Set tiêu đề cho các menuItem và set lệnh để khi click vào menuItem thực hiện sự kiện gọi lớp
        DichVu = new JMenuItem("Danh mục dịch vụ");
        DichVu.setActionCommand("DichVu");          // Set sự kiện cho MenuItem

        KhachHang = new JMenuItem("Danh mục khách hàng");
        KhachHang.setActionCommand("KhachHang");

        LoaiPhong = new JMenuItem("Danh mục loại phòng");
        LoaiPhong.setActionCommand("LoaiPhong");

        ChiTietDV = new JMenuItem("Danh mục chi tiết dịch vụ");
        ChiTietDV.setActionCommand("ChiTietDV");

        ChiTietHD = new JMenuItem("Danh mục chi tiết hợp đồng");
        ChiTietHD.setActionCommand("ChiTietDV");

        BangGia = new JMenuItem("Danh mục bảng giá");
        BangGia.setActionCommand("BangGia");

        // Đưa các menuItem vào menu
        XemDM.add(DichVu);
        XemDM.add(KhachHang);
        XemDM.add(LoaiPhong);
        XemDM.add(BangGia);
        XemDM.add(ChiTietDV);
        XemDM.add(ChiTietHD);
        mb.add(XemDM);

        // Menu Quản lý danh mục theo đơn 
        QLTheoDon = new JMenu("Quản lý danh mục theo đơn");

        // Set các tiêu đề và set lệnh để khi click vào menuItem thực hiện sự kiện gọi lớp
        TheoPhong = new JMenuItem("Danh mục theo phòng");
        TheoPhong.setActionCommand("TheoPhong");

        TheoKhach = new JMenuItem("Danh mục theo khách hàng");
        TheoKhach.setActionCommand("TheoKhach");

        TheoHoaDon = new JMenuItem("Danh mục theo hợp đồng");
        TheoHoaDon.setActionCommand("TheoHoaDon");

        TheoPhieuTT = new JMenuItem("Danh mục theo phiếu thanh toán");
        TheoPhieuTT.setActionCommand("TheoPhieuTT");

        // Thêm các menuItem vào menu quản lý danh mục theo đơn
        QLTheoDon.add(TheoPhong);
        QLTheoDon.add(TheoKhach);
        QLTheoDon.add(TheoHoaDon);
        QLTheoDon.add(TheoPhieuTT);

        // Thêm menu quản lý thoe đơn vào menuBar
        mb.add(QLTheoDon);                  // Add menu  con vào menu chính 

        // Tạo menu quản lý danh mục theo nhóm
        QLTheoNhom = new JMenu("Quản lý danh mục theo nhóm");

        KHTheoPhong = new JMenuItem("Quản lý phòng trọ từng nhà trọ");
        KHTheoPhong.setActionCommand("KHTheoPhong");
        QLTheoNhom.add(KHTheoPhong);
        mb.add(QLTheoNhom);

        // Tạo menu hướng dẫn hướng dẫn sử dụng và tên tác giả .
        TroGiup = new JMenu("Trợ giúp người dùng");

        ThongTin = new JMenuItem("Thông tin sản phẩm");
        ThongTin.setActionCommand("ThongTin");

        HuongDan = new JMenuItem("Hướng dẫn sử dụng");
        HuongDan.setActionCommand("HuongDan");

        TacGia = new JMenu("Tác giả");
        Huy = new JMenuItem("Nguyễn Quang Huy");
        Khang = new JMenuItem("Lê Tấn Khang");
        Phong = new JMenuItem("Hồ Văn Phong");

        TroGiup.add(ThongTin);
        TroGiup.add(HuongDan);

        TacGia.add(Huy);
        TacGia.add(Khang);
        TacGia.add(Phong);
        TroGiup.add(TacGia);

        mb.add(TroGiup);
        JLabel lblImage = new JLabel();
        lblImage.setBounds(2, 2, 796, 496);
        lblImage.setIcon(new ImageIcon("src/Images/Main1.jpg"));
        frmMain.getContentPane().add(lblImage);

        // Tạo ra MenuItemListener để bắt sự kiện 
        MenuItemListener menuItemListener = new MenuItemListener();

        // Tạo các sự kiện cho các menuItem
        TheoKhach.addActionListener(menuItemListener);
        TheoHoaDon.addActionListener(menuItemListener);
        TheoPhong.addActionListener(menuItemListener);
        DichVu.addActionListener(menuItemListener);
        KhachHang.addActionListener(menuItemListener);
        LoaiPhong.addActionListener(menuItemListener);
        Exit.addActionListener(menuItemListener);
        TheoPhieuTT.addActionListener(menuItemListener);
        KHTheoPhong.addActionListener(menuItemListener);
        ChiTietDV.addActionListener(menuItemListener);
        ChiTietHD.addActionListener(menuItemListener);
        BangGia.addActionListener(menuItemListener);
        ThongTin.addActionListener(menuItemListener);
        HuongDan.addActionListener(menuItemListener);

        // Set icon cho form main
        Image icon = Toolkit.getDefaultToolkit().getImage("src/Images/nhatro1.png");
        frmMain.setIconImage(icon);
        
        frmMain.setJMenuBar(mb);
        frmMain.setBounds(320, 80, 800, 500);
        frmMain.setLayout(null);
    }

    // Bắt sự kiện cho  từng  menuItem
    public class MenuItemListener implements ActionListener {

        public void actionPerformed(ActionEvent e) {
            // Kiêm tra khi click vào các menuItem
            if (e.getSource() == TheoKhach) {
                KhachHang kh = new KhachHang();
                kh.frmKhachHang.setVisible(true);
            }
            if (e.getSource() == DichVu) {
                DichVu dv = new DichVu();
                dv.frmDV.setVisible(true);
            }
            if (e.getSource() == KhachHang) {
                ViewKhachHang vkh = new ViewKhachHang();
                vkh.frmKhachHang.setVisible(true);
            }
            if (e.getSource() == Exit) {
                // Thoát chương trình khi nhấn lệnh exit
                frmMain.dispatchEvent(new WindowEvent(frmMain, WindowEvent.WINDOW_CLOSING));
            }
            if (e.getSource() == LoaiPhong) {
                LoaiPhong lp = new LoaiPhong();
                lp.frmLP.setVisible(true);
            }
            if (e.getSource() == TheoPhong) {
                PhongTro pt = new PhongTro();
                pt.frmPT.setVisible(true);
            }
            if (e.getSource() == TheoHoaDon) {
                HopDongThue hdt = new HopDongThue();
                hdt.frmHDT.setVisible(true);
            }
            if (e.getSource() == TheoPhieuTT) {
                PhieuThanhToan ptt = new PhieuThanhToan();
                ptt.frmPhieuTT.setVisible(true);
            }
            if (e.getSource() == KHTheoPhong) {
                AlterPhongTro pt = new AlterPhongTro();
                pt.frmPT.setVisible(true);
            }
            if (e.getSource() == BangGia) {
                BangGia bg = new BangGia();
                bg.frmBG.setVisible(true);
            }
            if (e.getSource() == ChiTietDV) {
                ChiTietDichVu ctdv = new ChiTietDichVu();
                ctdv.frmctdv.setVisible(true);
            }
            if (e.getSource() == ChiTietHD) {
                ChiTietHopDong cthd = new ChiTietHopDong();
                cthd.frmCTHD.setVisible(true);
            }
            if (e.getSource() == ThongTin) {
                JOptionPane.showMessageDialog(frmMain, "Sản phầm được làm bởi tác giả Phong Huy Khang");
            }
            if (e.getSource() == HuongDan) {
                JOptionPane.showMessageDialog(frmMain, "Bạn liên hệ email: nguyenquanghuy605@gmail.com để được hướng dẫn sử dụng");
            }
        }
    }
}
