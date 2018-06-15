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
import java.sql.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.util.Vector;
import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.TitledBorder;
import javax.swing.table.DefaultTableModel;

public class AlterPhongTro {

    // 
    Connection conn;
    PreparedStatement stmt;
    ResultSet rs;
    // 
    JFrame frmPT;
    JTable tableNT, tableLP, tablePT1;
    JTextField txtMaNT, txtDiaChi;          // Nha Tro
    JTextField txtMaLP, txtTenLP, txtDTLP;    // Loai Phong
    JTextField txtMaPT, txtTenPT, txtSL;        // Phong Tro

    // Tạo vector mã nhân viên và vector mã loại phòng để đưa vào combobox
    Vector mant = new Vector();
    Vector malp = new Vector();

    public static void main(String[] args) {
        EventQueue.invokeLater(new Runnable() {
            @Override
            public void run() {
                try {
                    AlterPhongTro pt = new AlterPhongTro(); 
                    pt.frmPT.setVisible(true);
                } catch (Exception ex) {
                    System.err.println("Can not create form");
                }
            }
        });
    }

    public AlterPhongTro() {
        Initialize();
        try {
            conn = DBConnection.getConnection();
        } catch (Exception ex) {
            System.err.println("Error get connection :" + ex);
        }
        ShowTableNT();  // Show table nhà trọ
        ShowTableLP();  // Show table loại phòng
        ShowTablePT1(); // Show table phòng trọ
    }

    // Show len bang Nha tro
    public void ShowTableNT() {
        Vector cols = new Vector();
        // Dùng phương thức add để tạo các cột
        cols.addElement("Mã nhà trọ");
        cols.addElement("Địa chỉ");
        // Tạo ra một vector data để chứa dữ liệu 
        Vector data = new Vector();
        String sql = "Select MaNhaTro,DiaChi from quanlynhatro.nhatro";
        mant.clear();       // Xóa dữ liệu trong combobox
        try {
            // Chuẩn bị câu lệnh truy vấn
            stmt = conn.prepareStatement(sql);
            // Thực hiện truy vấn 
            rs = stmt.executeQuery();
            while (rs.next()) {
                //  Đưa dữ liệu lên bảng
                Vector nt = new Vector();
                mant.addElement(rs.getString("MaNhaTro"));     // Đưa dữ liệu vào combobox
                // Lấy dữ liệu vào các cột nt
                nt.addElement(rs.getString("MaNhaTro"));
                nt.addElement(rs.getString("DiaChi"));
                data.add(nt);   // Đưa dữ liệu vào data
            }
        } catch (Exception ex) {
            System.err.println("Can not show table nha tro :" + ex);
            JOptionPane.showMessageDialog(frmPT, "Show bảng nhà trọ bị lỗi");
        }
        tableNT.setModel(new DefaultTableModel(data, cols));
        txtDiaChi.setText("");  // Set lại text địa chỉ rỗng
        txtMaNT.setText("");    // Set lại text mã nhà trọ rỗng
    }

    // Show lên bảng loại phòng
    public void ShowTableLP() {
        // Tạo ra một vector chứa các cột
        Vector cols = new Vector();
        // Thêm cac cột vào các vector
        cols.addElement("MaLoaiPhong");
        cols.addElement("TenLoaiPhong");
        cols.addElement("DienTich");

        Vector data = new Vector();
        // Tạo câu lệnh truy vấn
        String sql = "Select * from quanlynhatro.loaiphong";
        malp.clear();           // Xóa dữ liệu củ trong combobox
        try {
            stmt = conn.prepareStatement(sql);  
            rs = stmt.executeQuery();           // Thực hiện câu lệnh truy vấn
            while (rs.next()) {

                Vector dv = new Vector();
                malp.addElement(rs.getString("MaLoaiPhong"));       // Đưa dữ liệu vào combobox
                // Lấy dữ liệu đưa vào các cột dv
                dv.addElement(rs.getString("MaLoaiPhong"));
                dv.addElement(rs.getString("TenLoaiPhong"));
                dv.addElement(rs.getString("DienTich"));

                data.add(dv);
            }

        } catch (Exception ex) {
            System.out.println("Can not show table and error:" + ex);
        }
        tableLP.setModel(new DefaultTableModel(data, cols));
        // Set lại các text về rỗng
        txtMaLP.setText("");
        txtDTLP.setText("");
        txtTenLP.setText("");
    }

    // Show lên bảng phòng trọ
    public void ShowTablePT1() {
        // Tạo vector để tạo bảng
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
            // Thực thi câu lệnh truy vấn
            rs = stmt.executeQuery();
            while (rs.next()) {
                //  Đưa dữ liệu lên bảng
                Vector pt = new Vector();
                // Thêm dữ liệu vào các cột 
                pt.addElement(rs.getString("MaPhongTro"));
                pt.addElement(rs.getString("TenPhongTro"));
                pt.addElement(rs.getInt("SoLuongNguoi"));
                pt.addElement(rs.getString("MaLoaiPhong"));
                pt.addElement(rs.getString("MaNhaTro"));

                data.add(pt);   // Đưa dữ liệu vào vector data
            }
        } catch (Exception e) {
            System.err.println("Show table phong tro loi :" + e);
        }
        // Đưa dữ liệu lên bảng phòng trọ
        tablePT1.setModel(new DefaultTableModel(data, cols));
    }

    public void Initialize() {
        // Tạo form chính
        frmPT = new JFrame("Phòng trọ");
        frmPT.setBounds(320, 80, 860, 510);
        frmPT.getContentPane().setLayout(null);

        // Tạo Panel cho nhà trọ
        JPanel PanelNT = new JPanel();
        PanelNT.setBorder(new TitledBorder(null, "Nhà trọ",
                TitledBorder.LEADING, TitledBorder.TOP,
                new Font("times new roman", Font.PLAIN, 20), Color.red));
        PanelNT.setBounds(10, 10, 350, 240);
        frmPT.getContentPane().add(PanelNT);
        PanelNT.setLayout(null);

        // Tọa label mã nhà trọ
        JLabel lblMaNT = new JLabel("Mã nhà trọ");
        lblMaNT.setFont(new Font("Tohama", Font.BOLD, 13));     // Xét font cho label
        lblMaNT.setBounds(20, 140, 100, 30);                    // Xét tọa độ cho label
        PanelNT.add(lblMaNT);                                   // Thêm label vào panel

        // Tạo text mã nhà trọ
        txtMaNT = new JTextField();                             
        txtMaNT.setFont(new Font("Tohama", Font.BOLD, 13));     // Xét font cho TextField
        txtMaNT.setBounds(20, 170, 70, 23);                     // Xét tọa độ cho TextField
        PanelNT.add(txtMaNT);                                   // Thêm label vào TextField

        // Tọa Label Địa chỉ
        JLabel lblDiaChi = new JLabel("Địa chỉ");
        lblDiaChi.setFont(new Font("Tohama", Font.BOLD, 13));
        lblDiaChi.setBounds(120, 140, 100, 30);
        PanelNT.add(lblDiaChi);

        // Tọa textfield địa chỉ
        txtDiaChi = new JTextField();
        txtDiaChi.setFont(new Font("Tohama", Font.BOLD, 13));
        txtDiaChi.setBounds(120, 170, 210, 23);
        PanelNT.add(txtDiaChi);

        // Tạo button thêm
        JButton btnThemNT = new JButton("Thêm");
        btnThemNT.setFont(new Font("Tohama", Font.BOLD, 13));
        btnThemNT.setBounds(20, 200, 70, 23);
        PanelNT.add(btnThemNT);

        // Thêm dữ liệu
        btnThemNT.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String sql = "Insert into quanlynhatro.nhatro"
                        + "(MaNhaTro,DiaChi)"
                        + "Values(?,?)";
                try {
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, Integer.parseInt(txtMaNT.getText()));
                    stmt.setString(2, txtDiaChi.getText());
                    stmt.executeUpdate();
                    JOptionPane.showMessageDialog(frmPT, "Thêm dữ liệu thành công");
                } catch (Exception ex) {
                    System.err.println("Can not insert data");
                }
                ShowTableNT();
            }
        });

        // Tạo Button cập nhật
        JButton btnCapNhatNT = new JButton("Cập nhật");
        btnCapNhatNT.setFont(new Font("Tohama", Font.BOLD, 13));
        btnCapNhatNT.setBounds(90, 200, 91, 23);
        PanelNT.add(btnCapNhatNT);

        // Cập nhật dữ liệu
        btnCapNhatNT.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent arg0) {
                // Lấy ra truyền mã nhà trọ vào biến id
                int id = Integer.parseInt(txtMaNT.getText());
                // Tạo câu lệnh truy vấn 
                String sql = "UPDATE quanlynhatro.nhatro SET DiaChi=? WHERE MaNhaTro=?";
                try {
                    stmt = conn.prepareStatement(sql);
                    stmt.setString(1, txtDiaChi.getText());
                    stmt.setInt(2, id);
                    stmt.executeUpdate();                   // Thực thi câu lệnh truy vấn
                    // Thông báo khi cập nhật thành công
                    JOptionPane.showMessageDialog(frmPT, "Cập nhật dữ liệu thành công");
                } catch (Exception ex) {
                    System.err.println("Can not update data" + ex);
                    JOptionPane.showMessageDialog(frmPT, "Cập nhật dữ liệu thất bại");
                }
                ShowTableNT();          // Show lại bảng
            }
        });

        // Tạo button Xóa 
        JButton btnXoaNT = new JButton("Xóa");
        btnXoaNT.setFont(new Font("Tohama", Font.BOLD, 13));
        btnXoaNT.setBounds(181, 200, 70, 23);
        PanelNT.add(btnXoaNT);

        // Xóa dữ liệu 
        btnXoaNT.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                int id = Integer.parseInt(txtMaNT.getText());
                String sql = "delete from quanlynhatro.nhatro where MaNhaTro=?";
                try {
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, id);
                    int reponse = JOptionPane.showConfirmDialog(frmPT, "Bạn có muốn xóa?",
                            "Xóa nhà trọ", JOptionPane.YES_NO_OPTION);
                    // Bắt các trường hợp cho thông báo
                    switch (reponse) {
                        case JOptionPane.YES_OPTION:
                            stmt.executeUpdate();
                            break;
                        case JOptionPane.NO_OPTION:
                            break;
                        case JOptionPane.CLOSED_OPTION:
                            break;
                        default:
                            break;
                    }
                    //JOptionPane.showConfirmDialog(frmPT, "Câu trả:" + message);
                } catch (Exception ex) {
                    System.err.println("Can't delete " + ex);
                    JOptionPane.showConfirmDialog(frmPT, "Xóa dữ liệu bị lỗi");
                }
                ShowTableNT();
            }
        });

        // Tạo button Reload 
        JButton btnReset = new JButton("Reload");
        btnReset.setFont(new Font("Tohama", Font.BOLD, 13));
        btnReset.setBounds(251, 200, 80, 23);
        PanelNT.add(btnReset);

        // Reset dữ liệu
        btnReset.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                ShowTableNT();
            }
        });

        // Tao table nhà trọ
        tableNT = new JTable();
        JScrollPane scrollNT = new JScrollPane();
        scrollNT.setBounds(20, 30, 310, 100);
        PanelNT.add(scrollNT);
        // Bắt sự kiện click chuột vào bảng
        tableNT.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent arg0) {
                int row = tableNT.getSelectedRow();
                // Truyền các giá trị vào TextField
                txtMaNT.setText(tableNT.getValueAt(row, 0).toString());
                txtDiaChi.setText(tableNT.getValueAt(row, 1).toString());
            }
        });

        // Set show dữ liệu lên bảng nhà trọ 
        scrollNT.setViewportView(tableNT);

        // Tạo Panel cho Loại phòng
        JPanel PanelLP = new JPanel();
        PanelLP.setBorder(new TitledBorder(null, "Loại Phòng",
                TitledBorder.LEADING, TitledBorder.TOP,
                new Font("times new roman", Font.PLAIN, 20), Color.red));
        PanelLP.setBounds(10, 250, 350, 210);
        frmPT.getContentPane().add(PanelLP);
        PanelLP.setLayout(null);

        // Tạo danh sách bảng  
        tableLP = new JTable();
        JScrollPane scrollLP = new JScrollPane();
        scrollLP.setBounds(20, 30, 310, 70);
        PanelLP.add(scrollLP);

        // Lắng nghe sự kiện mouseClick 
        tableLP.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent arg0) {
                // Lấy dòng mà khi click chuột vào 
                int row = tableLP.getSelectedRow();
                // Show dữ liệu lên các textField
                txtMaLP.setText(tableLP.getValueAt(row, 0).toString());
                txtTenLP.setText(tableLP.getValueAt(row, 1).toString());
                txtDTLP.setText(tableLP.getValueAt(row, 2).toString());
            }
        });
        // Show dữ liệu lên bảng loại phòng
        scrollLP.setViewportView(tableLP);

        // Tạo label mã loại phòng
        JLabel lblMaLP = new JLabel("Mã loại phòng");
        lblMaLP.setFont(new Font("Tohama", Font.BOLD, 13));
        lblMaLP.setBounds(20, 110, 100, 27);
        PanelLP.add(lblMaLP);

        // Tạo textfield mã loại phòng
        txtMaLP = new JTextField();
        txtMaLP.setFont(new Font("Tohama", Font.BOLD, 13));
        txtMaLP.setBounds(130, 110, 100, 23);
        PanelLP.add(txtMaLP);

        // Tạo label tên loại phòng
        JLabel lblTen = new JLabel("Tên loại phòng");
        lblTen.setFont(new Font("Tohama", Font.BOLD, 13));
        lblTen.setBounds(20, 140, 100, 27);
        PanelLP.add(lblTen);

        // Tạo textfield tên loại phòng
        txtTenLP = new JTextField();
        txtTenLP.setFont(new Font("Tohama", Font.BOLD, 13));
        txtTenLP.setBounds(130, 140, 100, 23);
        PanelLP.add(txtTenLP);

        // Tạo label diện tích
        JLabel lblDT = new JLabel("Diện tích");
        lblDT.setFont(new Font("Tohama", Font.BOLD, 13));
        lblDT.setBounds(20, 170, 100, 27);
        PanelLP.add(lblDT);

        // Tạo textfiled diện tích loại phòng
        txtDTLP = new JTextField();
        txtDTLP.setFont(new Font("Tohama", Font.BOLD, 13));
        txtDTLP.setBounds(130, 170, 100, 23);
        PanelLP.add(txtDTLP);

        // Tạo button thêm
        JButton btnThemLP = new JButton("Thêm");
        btnThemLP.setFont(new Font("Tohama", Font.BOLD, 13));
        btnThemLP.setBounds(240, 110, 90, 23);
        PanelLP.add(btnThemLP);

        // Lắng nghe sự kiện của button thêm 
        btnThemLP.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Tạo câu lệnh truy thêm loại phòng
                String sql = "Insert into quanlynhatro.loaiphong"
                        + "(MaLoaiPhong,TenLoaiPhong,DienTich)"
                        + "Values(?,?,?)";
                try {
                    // Chuẩn bị câu lệnh truy vấn
                    stmt = conn.prepareStatement(sql);
                    // Lấy dữ liệu từ các textfield đưa xuống cơ sở dữ liệu
                    stmt.setInt(1, Integer.parseInt(txtMaLP.getText()));
                    stmt.setString(2, txtTenLP.getText());
                    stmt.setInt(3, Integer.parseInt(txtDTLP.getText()));
                    stmt.executeUpdate();   // Thực hiện truy vấn 
                    JOptionPane.showMessageDialog(frmPT, "Thêm dữ liệu thành công");
                } catch (Exception ex) {
                    System.err.println("Can not insert data");
                    JOptionPane.showMessageDialog(frmPT, "Thêm dữ liệu thất bại");
                }
                ShowTableLP();      // Show lại dữ liệu 
            }
        });

        // Button cập nhật 
        JButton btnCapNhatLP = new JButton("Cập nhật");
        btnCapNhatLP.setFont(new Font("Tohama", Font.BOLD, 13));
        btnCapNhatLP.setBounds(239, 140, 91, 23);
        PanelLP.add(btnCapNhatLP);

        // Button cập nhật loại phòng
        btnCapNhatLP.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Lấy từ textfield mã loại phòng truyền vào biến id
                int id = Integer.parseInt(txtMaLP.getText());
                // Tạo câu lệnh truy vấn cập nhật dữ liệu
                String sql = "UPDATE quanlynhatro.loaiphong SET TenLoaiPhong=?,DienTich=? WHERE MaLoaiPhong=?";
                try {
                    // Chuẩn bị câu lệnh truy vấn 
                    stmt = conn.prepareStatement(sql);
                    stmt.setString(1, txtTenLP.getText());
                    stmt.setInt(2, Integer.parseInt(txtDTLP.getText()));
                    stmt.setInt(3, id);
                    stmt.executeUpdate();       // Thực hiện câu lệnh truy vấn
                    JOptionPane.showMessageDialog(frmPT, "Cập nhật dữ liệu thành công");
                } catch (Exception ex) {
                    System.err.println("Can not update data" + ex);
                    JOptionPane.showMessageDialog(frmPT, "Cập nhật dữ liệu thất bại");
                }
                ShowTableLP();      // Show lại bảng loại phòng khi cập nhật
            }
        });

        // Button cóa loại phòng
        JButton btnXoaLP = new JButton("Xóa");
        btnXoaLP.setFont(new Font("Tohama", Font.BOLD, 13));
        btnXoaLP.setBounds(240, 170, 90, 23);
        PanelLP.add(btnXoaLP);

        // Lắng nghe sự kiện xóa loại phòng 
        btnXoaLP.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Lấy id từ textfield từ mã loại phòng
                int id = Integer.parseInt(txtMaLP.getText());
                // Tạo câu lệnh truy vấn xóa loại phòng
                String sql = "delete from quanlynhatro.loaiphong where MaLoaiPhong=?";
                try {
                    // Chuẩn bị câu lệnh truy vấn
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, id);
                    int reponse = JOptionPane.showConfirmDialog(frmPT, "Bạn có muốn xóa?",
                            "Xóa loại phòng", JOptionPane.YES_NO_OPTION);
                    // Bắt các trường hợp khi người dùng chọn
                    switch (reponse) {
                        case JOptionPane.YES_OPTION:
                            stmt.executeUpdate();       // Thực thi câu lệnh 
                            break;
                        case JOptionPane.NO_OPTION:
                            break;
                        case JOptionPane.CLOSED_OPTION:
                            break;
                        default:
                            break;
                    }
//                    JOptionPane.showConfirmDialog(frmPT, "Câu trả:" + message);
                } catch (Exception ex) {
                    System.err.println("Can't delete " + ex);
                    JOptionPane.showMessageDialog(frmPT, "Xóa dữ liệu loại phòng thất bại");
                }
                ShowTableLP();      // Show lại bảng loại phòng khi thực hiện xóa
            }
        });

        // Tạo Panel cho Phòng  trọ
        JPanel PanelPT = new JPanel();
        PanelPT.setBorder(new TitledBorder(null, "Phòng trọ",
                TitledBorder.LEADING, TitledBorder.TOP,
                new Font("times new roman", Font.PLAIN, 20), Color.red));
        PanelPT.setBounds(370, 10, 460, 450);
        frmPT.getContentPane().add(PanelPT);
        PanelPT.setLayout(null);

        // Tạo table Phong tro
        tablePT1 = new JTable();

        // Tạo scroll để lưu bảng
        JScrollPane scrollPT1 = new JScrollPane();
        scrollPT1.setBounds(20, 200, 420, 230);
        PanelPT.add(scrollPT1);

        // Tạo label mã phòng trọ
        JLabel lblMaPT = new JLabel("Mã phòng trọ");
        lblMaPT.setFont(new Font("Tohama", Font.BOLD, 13));
        lblMaPT.setBounds(20, 30, 120, 30);
        PanelPT.add(lblMaPT);

        // Tạo textfield mã phòng trọ
        txtMaPT = new JTextField();
        txtMaPT.setFont(new Font("Tohama", Font.BOLD, 13));
        txtMaPT.setBounds(130, 34, 140, 23);
        PanelPT.add(txtMaPT);

        // Tạo label tên phòng trọ
        JLabel lblTenPhong = new JLabel("Tên phòng trọ");
        lblTenPhong.setFont(new Font("Tohama", Font.BOLD, 13));
        lblTenPhong.setBounds(20, 60, 120, 30);
        PanelPT.add(lblTenPhong);

        // Tạo textfield  tên phòng trọ
        txtTenPT = new JTextField();
        txtTenPT.setFont(new Font("Tohama", Font.BOLD, 13));
        txtTenPT.setBounds(130, 64, 140, 23);
        PanelPT.add(txtTenPT);

        // Tạo label tên mã nhà trọ
        JLabel lblPT1 = new JLabel("Mã nhà trọ");
        lblPT1.setFont(new Font("Tohama", Font.BOLD, 13));
        lblPT1.setBounds(20, 90, 120, 30);
        PanelPT.add(lblPT1);

        // Combobox nhà trọ
        JComboBox cbNT = new JComboBox(mant);
        cbNT.setBounds(130, 94, 140, 23);
        PanelPT.add(cbNT);

        // Tạo label loại phòng
        JLabel lblLP1 = new JLabel("Loại phòng");
        lblLP1.setFont(new Font("Tohama", Font.BOLD, 13));
        lblLP1.setBounds(20, 120, 120, 30);
        PanelPT.add(lblLP1);

        // Combox loai phong
        JComboBox cbLP = new JComboBox(malp);
        cbLP.setBounds(130, 124, 140, 23);
        PanelPT.add(cbLP);

        // Tạo label số lượng
        JLabel lblSL = new JLabel("Số lượng");
        lblSL.setFont(new Font("Tohama", Font.BOLD, 13));
        lblSL.setBounds(20, 150, 120, 30);
        PanelPT.add(lblSL);

        // Tạo textfield số lượng
        txtSL = new JTextField();
        txtSL.setFont(new Font("Tohama", Font.BOLD, 13));
        txtSL.setBounds(130, 154, 140, 23);
        PanelPT.add(txtSL);

        // Thêm phòng trọ  Chưa xong
        JButton btnAdd = new JButton("  Thêm");                         // Set tiêu đề cho button
        btnAdd.setFont(new Font("Tohama", Font.BOLD, 13));              // Set font cho button
        btnAdd.setIcon(new ImageIcon("src/Images/insert1.png"));        // Set icon cho button thêm
        btnAdd.setBounds(290, 70, 140, 30);                             // Set tọa độ và size cho button
        PanelPT.add(btnAdd);                                            // Thêm btnAdd vào panel

        // Lắng nghe sự kiện mouseclick của table phòng trọ
        tablePT1.addMouseListener(new MouseAdapter() {
            public void mouseClicked(MouseEvent arg0) {
                // Lấy ra dòng table phòng trọ 
                int row = tablePT1.getSelectedRow();
                // Show dữ liệu lên các text field
                txtMaPT.setText(tablePT1.getValueAt(row, 0).toString());
                txtTenPT.setText(tablePT1.getValueAt(row, 1).toString());
                txtSL.setText(tablePT1.getValueAt(row, 2).toString());
                cbLP.setSelectedItem(tablePT1.getValueAt(row, 3).toString());
                cbNT.setSelectedItem(tablePT1.getValueAt(row, 4).toString());
            }
        });
        scrollPT1.setViewportView(tablePT1);    // Show table

        // Lắng nghe sự kiện của button Thêm 
        btnAdd.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Tạo câu lệnh truy vấn
                String sql = "Insert into quanlynhatro.phongtro"
                        + "(MaPhongTro,TenPhongTro,SoLuongNguoi,MaLoaiPhong,MaNhaTro)"
                        + "Values(?,?,?,?,?)";
                try {
                    // Chuẩn bị câu lệnh truy vấn
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, Integer.parseInt(txtMaPT.getText()));
                    stmt.setString(2, txtTenPT.getText());
                    stmt.setInt(3, Integer.parseInt(txtSL.getText()));
                    stmt.setInt(4, Integer.parseInt(cbLP.getSelectedItem().toString()));
                    stmt.setInt(5, Integer.parseInt(cbLP.getSelectedItem().toString()));
                    stmt.executeUpdate();       // Thực hiện truy vấn
                    JOptionPane.showMessageDialog(frmPT, "Thêm dữ liệu thành công"); // show thông báo khi thêm thành công
                } catch (Exception ex) {
                    System.err.println("Can not insert Phong tro :" + ex);
                    JOptionPane.showMessageDialog(frmPT, "Thêm dữ liệu thất bại");
                }
                ShowTablePT1();     // Show lại bảng khi thêm dữ liệu
            }
        });
        
        // Button cập nhật  du lieu
        JButton btnUpdate = new JButton("Cập nhật");
        btnUpdate.setFont(new Font("Tohama", Font.BOLD, 13));
        btnUpdate.setBounds(290, 150, 140, 30);
        btnUpdate.setIcon(new ImageIcon("src/Images/update3.png"));     // Set icon cho button
        PanelPT.add(btnUpdate);
        
        // Lắng nghe sự kiện của button cập nhật 
        btnUpdate.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Lấy mã phòng trọ từ textfield truyền vào biến id
                int id = Integer.parseInt(txtMaPT.getText());
                // Tạo câu lệnh truy vấn cập nhật dữ liệu phòng trọ
                String sql = "Update quanlynhatro.phongtro "
                        + "SET TenPhongTro=?, SoLuongNguoi=?,MaLoaiPhong=?,MaNhaTro=?"
                        + "Where MaPhongTro=?";
                try {
                    // Chuẩn bị câu lệnh truy vấn
                    stmt = conn.prepareStatement(sql);
                    stmt.setString(1, txtTenPT.getText());
                    stmt.setInt(2, Integer.parseInt(txtSL.getText()));
                    stmt.setString(3, String.valueOf(cbLP.getSelectedItem()));
                    stmt.setString(4, String.valueOf(cbNT.getSelectedItem()));
                    stmt.setInt(5, id);
                    stmt.executeUpdate();       // Thực hiện câu lệnh truy vấn
                    JOptionPane.showMessageDialog(frmPT, "Cập nhật phòng trọ thành công");
                    
                } catch (Exception ex) {
                    System.err.println("Can not update phong tro :" + ex);
                    JOptionPane.showMessageDialog(frmPT, "Cập nhật phòng trọ thất bại");
                }
                ShowTablePT1();     // Show lại dữ liệu phòng trọ
            }
        });
        
        // Button xóa phòng trọ
        JButton btnDelete= new JButton(" Xóa");
        btnDelete.setFont(new Font("Tohama", Font.BOLD, 13));
        btnDelete.setBounds(290, 34, 140, 30);
        btnDelete.setIcon(new ImageIcon("src/Images/delete3.png"));
        PanelPT.add(btnDelete);
        
        // Lắng nghe sự kiện của button xóa
        btnDelete.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Lấy mã phòng trọ từ textfield truyền vào biến id
               int id = Integer.parseInt(txtMaPT.getText());
               // Tạo câu lệnh truy vấn xóa mã phòng trọ
                String sql = "delete from quanlynhatro.phongtro where MaPhongTro=?";
                try {
                    // Chuẩn bị câu lệnh truy vấn
                    stmt = conn.prepareStatement(sql);
                    stmt.setInt(1, id);
                    int reponse = JOptionPane.showConfirmDialog(frmPT, "Bạn có muốn xóa?",
                            "Xóa phòng trọ", JOptionPane.YES_NO_OPTION);
                    switch (reponse) {
                        case JOptionPane.YES_OPTION:
                                    stmt.executeUpdate();   // thực hiện câu lệnh truy vấn
                                    break;
                        case JOptionPane.NO_OPTION:
                            break;
                        case JOptionPane.CLOSED_OPTION:
                            break;
                        default:
                            break;
                    }
                    //JOptionPane.showConfirmDialog(frmPT, "Câu trả:" + message);
                } catch (Exception ex) {
                    System.err.println("Can't delete " + ex);
                    JOptionPane.showMessageDialog(frmPT, "Xóa dữ liệu thất bị");
                }
                ShowTablePT1();     // Show lại bảng khi xóa dữ liệu thành công
            }
        });
        
        // Button reload phòng trọ
        JButton btnReload= new JButton("  Reload");
        btnReload.setFont(new Font("Tohama", Font.BOLD, 13));
        btnReload.setBounds(290, 110, 140, 30);
        btnReload.setIcon(new ImageIcon("src/Images/reload.jpg"));
        PanelPT.add(btnReload);
        
        // Lắng nghe sự kiện reload
        btnReload.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                ShowTablePT1();     // Show lại table 
            }
        });
    }
}
