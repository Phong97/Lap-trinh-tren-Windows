
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2017 09:46:59
-- Generated from EDMX file: C:\Users\Phonghv\OneDrive\QuanLyNhaTro\QuanLyNhaTro\QuanLyNhaTro.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QuanLyPhongTro];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__ChiTietDi__MaChi__2A4B4B5E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietDichVus] DROP CONSTRAINT [FK__ChiTietDi__MaChi__2A4B4B5E];
GO
IF OBJECT_ID(N'[dbo].[FK__ChiTietDic__MaDV__2B3F6F97]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietDichVus] DROP CONSTRAINT [FK__ChiTietDic__MaDV__2B3F6F97];
GO
IF OBJECT_ID(N'[dbo].[FK__ChiTietHo__MaPho__2C3393D0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietHopDongs] DROP CONSTRAINT [FK__ChiTietHo__MaPho__2C3393D0];
GO
IF OBJECT_ID(N'[dbo].[FK__ChiTietHop__MaHD__2D27B809]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChiTietHopDongs] DROP CONSTRAINT [FK__ChiTietHop__MaHD__2D27B809];
GO
IF OBJECT_ID(N'[dbo].[FK__HopDongThu__MaKH__2E1BDC42]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HopDongThues] DROP CONSTRAINT [FK__HopDongThu__MaKH__2E1BDC42];
GO
IF OBJECT_ID(N'[dbo].[FK__PhieuThanh__MaHD__2F10007B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhieuThanhToans] DROP CONSTRAINT [FK__PhieuThanh__MaHD__2F10007B];
GO
IF OBJECT_ID(N'[dbo].[FK__PhongTro__MaLoai__300424B4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhongTroes] DROP CONSTRAINT [FK__PhongTro__MaLoai__300424B4];
GO
IF OBJECT_ID(N'[dbo].[FK__PhongTro__MaNhaT__30F848ED]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhongTroes] DROP CONSTRAINT [FK__PhongTro__MaNhaT__30F848ED];
GO
IF OBJECT_ID(N'[dbo].[FK__TrangBi__MaPhong__31EC6D26]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrangBis] DROP CONSTRAINT [FK__TrangBi__MaPhong__31EC6D26];
GO
IF OBJECT_ID(N'[dbo].[FK__TrangBi__MaThiet__32E0915F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrangBis] DROP CONSTRAINT [FK__TrangBi__MaThiet__32E0915F];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ChiTietDichVus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTietDichVus];
GO
IF OBJECT_ID(N'[dbo].[ChiTietHopDongs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChiTietHopDongs];
GO
IF OBJECT_ID(N'[dbo].[DichVus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DichVus];
GO
IF OBJECT_ID(N'[dbo].[HopDongThues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HopDongThues];
GO
IF OBJECT_ID(N'[dbo].[KhachHangs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KhachHangs];
GO
IF OBJECT_ID(N'[dbo].[LoaiPhongs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoaiPhongs];
GO
IF OBJECT_ID(N'[dbo].[NhaTroes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NhaTroes];
GO
IF OBJECT_ID(N'[dbo].[PhieuThanhToans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhieuThanhToans];
GO
IF OBJECT_ID(N'[dbo].[PhongTroes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhongTroes];
GO
IF OBJECT_ID(N'[dbo].[TaiKhoans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaiKhoans];
GO
IF OBJECT_ID(N'[dbo].[ThietBis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ThietBis];
GO
IF OBJECT_ID(N'[dbo].[TrangBis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrangBis];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ChiTietDichVus'
CREATE TABLE [dbo].[ChiTietDichVus] (
    [MaChiTietDV] int  NOT NULL,
    [NgaySuDung] datetime  NULL,
    [MaDV] int  NOT NULL,
    [MaChiTietHD] int  NOT NULL
);
GO

-- Creating table 'ChiTietHopDongs'
CREATE TABLE [dbo].[ChiTietHopDongs] (
    [MaChiTietHD] int  NOT NULL,
    [MaHD] int  NOT NULL,
    [MaPhong] int  NOT NULL
);
GO

-- Creating table 'DichVus'
CREATE TABLE [dbo].[DichVus] (
    [MaDV] int  NOT NULL,
    [TenDV] nvarchar(100)  NOT NULL,
    [GiaDV] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'HopDongThues'
CREATE TABLE [dbo].[HopDongThues] (
    [MaHD] int  NOT NULL,
    [MaKH] int  NOT NULL,
    [NgayBatDauHD] datetime  NOT NULL,
    [ThoiHanHD] int  NULL
);
GO

-- Creating table 'KhachHangs'
CREATE TABLE [dbo].[KhachHangs] (
    [MaKhach] int  NOT NULL,
    [TenKhach] nvarchar(100)  NULL,
    [CMND] int  NULL,
    [GioiTinh] nvarchar(max)  NULL,
    [DiaChiKhach] nvarchar(100)  NULL,
    [NgheNghiep] nvarchar(100)  NULL,
    [SdtKhach] decimal(18,0)  NULL,
    [HinhAnhKH] varbinary(max)  NULL
);
GO

-- Creating table 'LoaiPhongs'
CREATE TABLE [dbo].[LoaiPhongs] (
    [MaLoaiPhong] int IDENTITY(1,1) NOT NULL,
    [DienTich] float  NULL,
    [TenLoaiPhong] nvarchar(100)  NOT NULL,
    [GiaPhong] decimal(18,0)  NULL
);
GO

-- Creating table 'NhaTroes'
CREATE TABLE [dbo].[NhaTroes] (
    [MaNhaTro] int IDENTITY(1,1) NOT NULL,
    [DiaChi] nvarchar(100)  NOT NULL,
    [DoanhThu] decimal(18,0)  NULL
);
GO

-- Creating table 'PhieuThanhToans'
CREATE TABLE [dbo].[PhieuThanhToans] (
    [MaPhieu] int  NOT NULL,
    [ThangSuDung] int  NOT NULL,
    [ThanhTien] decimal(18,0)  NULL,
    [NgayThanhToan] datetime  NULL,
    [MaHD] int  NOT NULL
);
GO

-- Creating table 'PhongTroes'
CREATE TABLE [dbo].[PhongTroes] (
    [MaPhong] int IDENTITY(1,1) NOT NULL,
    [TenPhong] nvarchar(100)  NULL,
    [SoLuongNguoi] int  NULL,
    [MaLoaiPhong] int  NOT NULL,
    [MaNhaTro] int  NOT NULL
);
GO

-- Creating table 'TaiKhoans'
CREATE TABLE [dbo].[TaiKhoans] (
    [TenTK] nvarchar(100)  NOT NULL,
    [MatKhau] nchar(100)  NOT NULL
);
GO

-- Creating table 'ThietBis'
CREATE TABLE [dbo].[ThietBis] (
    [MaThietBi] int IDENTITY(1,1) NOT NULL,
    [TenThietBi] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'TrangBis'
CREATE TABLE [dbo].[TrangBis] (
    [MaPhong] int  NOT NULL,
    [MaThietBi] int  NOT NULL,
    [ThoiDiem] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MaChiTietDV] in table 'ChiTietDichVus'
ALTER TABLE [dbo].[ChiTietDichVus]
ADD CONSTRAINT [PK_ChiTietDichVus]
    PRIMARY KEY CLUSTERED ([MaChiTietDV] ASC);
GO

-- Creating primary key on [MaChiTietHD] in table 'ChiTietHopDongs'
ALTER TABLE [dbo].[ChiTietHopDongs]
ADD CONSTRAINT [PK_ChiTietHopDongs]
    PRIMARY KEY CLUSTERED ([MaChiTietHD] ASC);
GO

-- Creating primary key on [MaDV] in table 'DichVus'
ALTER TABLE [dbo].[DichVus]
ADD CONSTRAINT [PK_DichVus]
    PRIMARY KEY CLUSTERED ([MaDV] ASC);
GO

-- Creating primary key on [MaHD] in table 'HopDongThues'
ALTER TABLE [dbo].[HopDongThues]
ADD CONSTRAINT [PK_HopDongThues]
    PRIMARY KEY CLUSTERED ([MaHD] ASC);
GO

-- Creating primary key on [MaKhach] in table 'KhachHangs'
ALTER TABLE [dbo].[KhachHangs]
ADD CONSTRAINT [PK_KhachHangs]
    PRIMARY KEY CLUSTERED ([MaKhach] ASC);
GO

-- Creating primary key on [MaLoaiPhong] in table 'LoaiPhongs'
ALTER TABLE [dbo].[LoaiPhongs]
ADD CONSTRAINT [PK_LoaiPhongs]
    PRIMARY KEY CLUSTERED ([MaLoaiPhong] ASC);
GO

-- Creating primary key on [MaNhaTro] in table 'NhaTroes'
ALTER TABLE [dbo].[NhaTroes]
ADD CONSTRAINT [PK_NhaTroes]
    PRIMARY KEY CLUSTERED ([MaNhaTro] ASC);
GO

-- Creating primary key on [MaPhieu] in table 'PhieuThanhToans'
ALTER TABLE [dbo].[PhieuThanhToans]
ADD CONSTRAINT [PK_PhieuThanhToans]
    PRIMARY KEY CLUSTERED ([MaPhieu] ASC);
GO

-- Creating primary key on [MaPhong] in table 'PhongTroes'
ALTER TABLE [dbo].[PhongTroes]
ADD CONSTRAINT [PK_PhongTroes]
    PRIMARY KEY CLUSTERED ([MaPhong] ASC);
GO

-- Creating primary key on [TenTK] in table 'TaiKhoans'
ALTER TABLE [dbo].[TaiKhoans]
ADD CONSTRAINT [PK_TaiKhoans]
    PRIMARY KEY CLUSTERED ([TenTK] ASC);
GO

-- Creating primary key on [MaThietBi] in table 'ThietBis'
ALTER TABLE [dbo].[ThietBis]
ADD CONSTRAINT [PK_ThietBis]
    PRIMARY KEY CLUSTERED ([MaThietBi] ASC);
GO

-- Creating primary key on [MaPhong], [MaThietBi] in table 'TrangBis'
ALTER TABLE [dbo].[TrangBis]
ADD CONSTRAINT [PK_TrangBis]
    PRIMARY KEY CLUSTERED ([MaPhong], [MaThietBi] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MaChiTietHD] in table 'ChiTietDichVus'
ALTER TABLE [dbo].[ChiTietDichVus]
ADD CONSTRAINT [FK__ChiTietDi__MaChi__2A4B4B5E]
    FOREIGN KEY ([MaChiTietHD])
    REFERENCES [dbo].[ChiTietHopDongs]
        ([MaChiTietHD])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ChiTietDi__MaChi__2A4B4B5E'
CREATE INDEX [IX_FK__ChiTietDi__MaChi__2A4B4B5E]
ON [dbo].[ChiTietDichVus]
    ([MaChiTietHD]);
GO

-- Creating foreign key on [MaDV] in table 'ChiTietDichVus'
ALTER TABLE [dbo].[ChiTietDichVus]
ADD CONSTRAINT [FK__ChiTietDic__MaDV__2B3F6F97]
    FOREIGN KEY ([MaDV])
    REFERENCES [dbo].[DichVus]
        ([MaDV])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ChiTietDic__MaDV__2B3F6F97'
CREATE INDEX [IX_FK__ChiTietDic__MaDV__2B3F6F97]
ON [dbo].[ChiTietDichVus]
    ([MaDV]);
GO

-- Creating foreign key on [MaPhong] in table 'ChiTietHopDongs'
ALTER TABLE [dbo].[ChiTietHopDongs]
ADD CONSTRAINT [FK__ChiTietHo__MaPho__2C3393D0]
    FOREIGN KEY ([MaPhong])
    REFERENCES [dbo].[PhongTroes]
        ([MaPhong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ChiTietHo__MaPho__2C3393D0'
CREATE INDEX [IX_FK__ChiTietHo__MaPho__2C3393D0]
ON [dbo].[ChiTietHopDongs]
    ([MaPhong]);
GO

-- Creating foreign key on [MaHD] in table 'ChiTietHopDongs'
ALTER TABLE [dbo].[ChiTietHopDongs]
ADD CONSTRAINT [FK__ChiTietHop__MaHD__2D27B809]
    FOREIGN KEY ([MaHD])
    REFERENCES [dbo].[HopDongThues]
        ([MaHD])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ChiTietHop__MaHD__2D27B809'
CREATE INDEX [IX_FK__ChiTietHop__MaHD__2D27B809]
ON [dbo].[ChiTietHopDongs]
    ([MaHD]);
GO

-- Creating foreign key on [MaKH] in table 'HopDongThues'
ALTER TABLE [dbo].[HopDongThues]
ADD CONSTRAINT [FK__HopDongThu__MaKH__2E1BDC42]
    FOREIGN KEY ([MaKH])
    REFERENCES [dbo].[KhachHangs]
        ([MaKhach])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__HopDongThu__MaKH__2E1BDC42'
CREATE INDEX [IX_FK__HopDongThu__MaKH__2E1BDC42]
ON [dbo].[HopDongThues]
    ([MaKH]);
GO

-- Creating foreign key on [MaHD] in table 'PhieuThanhToans'
ALTER TABLE [dbo].[PhieuThanhToans]
ADD CONSTRAINT [FK__PhieuThanh__MaHD__2F10007B]
    FOREIGN KEY ([MaHD])
    REFERENCES [dbo].[HopDongThues]
        ([MaHD])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PhieuThanh__MaHD__2F10007B'
CREATE INDEX [IX_FK__PhieuThanh__MaHD__2F10007B]
ON [dbo].[PhieuThanhToans]
    ([MaHD]);
GO

-- Creating foreign key on [MaLoaiPhong] in table 'PhongTroes'
ALTER TABLE [dbo].[PhongTroes]
ADD CONSTRAINT [FK__PhongTro__MaLoai__300424B4]
    FOREIGN KEY ([MaLoaiPhong])
    REFERENCES [dbo].[LoaiPhongs]
        ([MaLoaiPhong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PhongTro__MaLoai__300424B4'
CREATE INDEX [IX_FK__PhongTro__MaLoai__300424B4]
ON [dbo].[PhongTroes]
    ([MaLoaiPhong]);
GO

-- Creating foreign key on [MaNhaTro] in table 'PhongTroes'
ALTER TABLE [dbo].[PhongTroes]
ADD CONSTRAINT [FK__PhongTro__MaNhaT__30F848ED]
    FOREIGN KEY ([MaNhaTro])
    REFERENCES [dbo].[NhaTroes]
        ([MaNhaTro])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__PhongTro__MaNhaT__30F848ED'
CREATE INDEX [IX_FK__PhongTro__MaNhaT__30F848ED]
ON [dbo].[PhongTroes]
    ([MaNhaTro]);
GO

-- Creating foreign key on [MaPhong] in table 'TrangBis'
ALTER TABLE [dbo].[TrangBis]
ADD CONSTRAINT [FK__TrangBi__MaPhong__31EC6D26]
    FOREIGN KEY ([MaPhong])
    REFERENCES [dbo].[PhongTroes]
        ([MaPhong])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MaThietBi] in table 'TrangBis'
ALTER TABLE [dbo].[TrangBis]
ADD CONSTRAINT [FK__TrangBi__MaThiet__32E0915F]
    FOREIGN KEY ([MaThietBi])
    REFERENCES [dbo].[ThietBis]
        ([MaThietBi])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__TrangBi__MaThiet__32E0915F'
CREATE INDEX [IX_FK__TrangBi__MaThiet__32E0915F]
ON [dbo].[TrangBis]
    ([MaThietBi]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------