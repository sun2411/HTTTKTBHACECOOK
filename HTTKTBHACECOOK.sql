-- ============================================================
-- HỆ THỐNG QUẢN LÝ KẾ TOÁN – BÁN HÀNG ACECOOK VIỆT NAM
-- ============================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QLKTBHACECOOK')
BEGIN
    PRINT N'⚠ Database QLKTBHACECOOK đã tồn tại. Đang tiến hành xóa...';
    ALTER DATABASE QLKTBHACECOOK SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLKTBHACECOOK;
END
GO

CREATE DATABASE QLKTBHACECOOK;
GO

USE QLKTBHACECOOK;
GO

PRINT N'================================================';
PRINT N'  PHẦN 1: TẠO CÁC BẢNG DANH MỤC';
PRINT N'================================================';
GO

-- 1. LOAIQUYEN 
CREATE TABLE LOAIQUYEN (
    MaLQ      CHAR(10) PRIMARY KEY,
    TenLQ     NVARCHAR(50),
    MoTaLQ    NVARCHAR(100)
);

-- 2. LOAIKHACHHANG
CREATE TABLE LOAIKHACHHANG (
    MaLoaiKH      CHAR(10) PRIMARY KEY,
    TenLoaiKH     NVARCHAR(50),
    GhiChuLoaiKH  NVARCHAR(255)
);

-- 3. PHONGBAN
CREATE TABLE PHONGBAN (
    MaPB        CHAR(10) PRIMARY KEY,
    TenPB       NVARCHAR(30) UNIQUE,
    DTPB        CHAR(10),
    EmailPB     NVARCHAR(50)
);

-- 4. CHUCVU
CREATE TABLE CHUCVU (
    MaCV       CHAR(10) PRIMARY KEY,
    TenCV      NVARCHAR(50),
    GhiChuCV   NVARCHAR(255)
);

-- 5. VAITRO
CREATE TABLE VAITRO (
    MaVT      CHAR(10) PRIMARY KEY,
    TenVT     NVARCHAR(50),
    MoTaVT    NVARCHAR(255)
);

-- 6. KHO
CREATE TABLE KHO (
    MaKho      CHAR(10) PRIMARY KEY,
    TenKho     NVARCHAR(50),
    ViTri      NVARCHAR(100),
    SDTKho     CHAR(10),
    EmailKho   NVARCHAR(50)
);

-- 7. NGUYENLIEU
CREATE TABLE NGUYENLIEU (
    MaNL     CHAR(10) PRIMARY KEY,
    TenNL    NVARCHAR(50),
    DVTNL    NVARCHAR(20),
    SoLuongTon DECIMAL(18,2) DEFAULT 0
);

-- 8. LOAISANPHAM
CREATE TABLE LOAISANPHAM (
    MaLoaiSP    CHAR(10) PRIMARY KEY,
    TenLoaiSP   NVARCHAR(50),
    GhiChuLoaiSP NVARCHAR(255)
);

-- 9. NHACUNGCAP
CREATE TABLE NHACUNGCAP (
    MaNCC       CHAR(10) PRIMARY KEY,
    TenNCC      NVARCHAR(50),
    SDTNCC      CHAR(10),
    EmailNCC    NVARCHAR(50),
    DiaChiNCC   NVARCHAR(100),
    CongNoNCC   FLOAT,
    GhiChuNCC   NVARCHAR(255)
);

-- 10. CTKM
CREATE TABLE CTKM (
    MaCTKM         CHAR(10) PRIMARY KEY,
    TenCTKM        NVARCHAR(100),
    NgayBatDauKM   DATE,
    NgayKetThucKM  DATE,
    LyDoKM         NVARCHAR(255)
);

-- 11. TAIKHOANCAP1
CREATE TABLE TAIKHOANCAP1 (
    SoTKC1      CHAR(10) PRIMARY KEY,
    TenTKC1     NVARCHAR(50),
    GhiChuTKC1  NVARCHAR(255)
);

PRINT N'================================================';
PRINT N'  PHẦN 2: TẠO CÁC BẢNG CẤP 2';
PRINT N'================================================';
GO

-- 12. QUYEN (Có MaLQ)
CREATE TABLE QUYEN (
    MaQuyen     CHAR(10) PRIMARY KEY,
    TenQuyen    NVARCHAR(50),
    MoTaQuyen   NVARCHAR(255),
    MaLQ        CHAR(10), 
    CONSTRAINT FK_QUYEN_LOAIQUYEN FOREIGN KEY (MaLQ) REFERENCES LOAIQUYEN(MaLQ)
);

-- 13. KHACHHANG (Có MaLoaiKH)
CREATE TABLE KHACHHANG (
    MaKH        CHAR(10) PRIMARY KEY,
    TenKH       NVARCHAR(50),
    SDTKH       CHAR(10),
    EmailKH     NVARCHAR(50),
    DiaChiKH    NVARCHAR(100),
    MSTKH       VARCHAR(20),
    STKKH       VARCHAR(20),
    CongNoKH    FLOAT,
    GhiChuKH    NVARCHAR(255),
    MaLoaiKH    CHAR(10),
    CONSTRAINT FK_KH_LKH FOREIGN KEY (MaLoaiKH) REFERENCES LOAIKHACHHANG(MaLoaiKH)
);

-- 14. NHANVIEN (Có MaPB, MaCV)
CREATE TABLE NHANVIEN (
    MaNV       CHAR(10) PRIMARY KEY,
    MaPB       CHAR(10),
    MaCV       CHAR(10),
    HoTenNV    NVARCHAR(50),
    SDTNV      CHAR(10),
    EmailNV    NVARCHAR(50),
    CONSTRAINT FK_NV_PB FOREIGN KEY (MaPB) REFERENCES PHONGBAN(MaPB),
    CONSTRAINT FK_NV_CV FOREIGN KEY (MaCV) REFERENCES CHUCVU(MaCV)
);

-- 15. SANPHAM (Có MaLoaiSP)
CREATE TABLE SANPHAM (
    MaSP             CHAR(10) PRIMARY KEY,
    MaLoaiSP         CHAR(10),
    TenSP            NVARCHAR(50),
    MoTa             NVARCHAR(100),
    GiaBanSP         DECIMAL(18,0), 
    NhietDoBaoQuan   NVARCHAR(20),
    NSXSP            DATE,
    HSDSP            DATE,
    CONSTRAINT FK_SP_LOAI FOREIGN KEY (MaLoaiSP) REFERENCES LOAISANPHAM(MaLoaiSP)
);

-- 16. TAIKHOANCAP2 (Có SoTKC1)
CREATE TABLE TAIKHOANCAP2 (
    SoTKC2      VARCHAR(10) PRIMARY KEY,
    SoTKC1      CHAR(10), 
    TenTKC2     NVARCHAR(50),
    GhiChuTKC2  NVARCHAR(255),
    CONSTRAINT FK_TKC2_TKC1 FOREIGN KEY (SoTKC1) REFERENCES TAIKHOANCAP1(SoTKC1)
);

-- 17. PHIEUNHAPKHO (Có MaKho)
CREATE TABLE PHIEUNHAPKHO (
    SoPN       CHAR(10) PRIMARY KEY,
    MaKho      CHAR(10),
    NgayNhap   DATETIME,
    LyDoNhap   NVARCHAR(255),
    TriGiaNhap DECIMAL(18,0), 
    CONSTRAINT FK_PNK_KHO FOREIGN KEY (MaKho) REFERENCES KHO(MaKho)
);

-- 18. PHIEUXUAT (Độc lập tương đối, nhưng logic liên quan xuất kho)
CREATE TABLE PHIEUXUAT (
    SoPX        CHAR(10) PRIMARY KEY,
    NgayXuat    DATE,
    TrangThaiPX NVARCHAR(30),
    TriGiaPX    DECIMAL(18,0),
    LyDoXuat    NVARCHAR(255)
);

-- 19. CT_CC (NCC & NL)
CREATE TABLE CT_CC (
    MaNCC        CHAR(10),
    MaNL         CHAR(10),
    GiaCungUng   DECIMAL(18,0), 
    TGGH         DATETIME,
    TinhTrangHT  BIT,
    CONSTRAINT CTCC_PK PRIMARY KEY (MaNCC, MaNL),
    CONSTRAINT FK_CTCC_NCC FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC),
    CONSTRAINT FK_CTCC_NL FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL)
);

PRINT N'================================================';
PRINT N'  PHẦN 3: TẠO CÁC BẢNG CẤP 3';
PRINT N'================================================';
GO

-- 20. TAIKHOANCAP3 (Quan trọng cho BUTTOAN)
CREATE TABLE TAIKHOANCAP3 (
    SoTKC3      VARCHAR(10) PRIMARY KEY,
    SoTKC2      VARCHAR(10), 
    TenTKC3     NVARCHAR(50),
    GhiChuTKC3  NVARCHAR(255),
    CONSTRAINT FK_TKC3_TKC2 FOREIGN KEY (SoTKC2) REFERENCES TAIKHOANCAP2(SoTKC2)
);

-- 21. TAIKHOAN (Login)
CREATE TABLE TAIKHOAN (
    MaTK         CHAR(10) PRIMARY KEY,
    MaNV         CHAR(10),
    MaVT         CHAR(10),
    TenDangNhap  NVARCHAR(30),
    MatKhau      NVARCHAR(20),
    TrangThaiTK  NVARCHAR(20),
    CONSTRAINT FK_TK_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    CONSTRAINT FK_TK_VT FOREIGN KEY (MaVT) REFERENCES VAITRO(MaVT)
);

-- 22. DONDATHANG
CREATE TABLE DONDATHANG (
    MaDDH               CHAR(10) PRIMARY KEY,
    MaKH                CHAR(10),
    MaNV                CHAR(10),
    NgayDatHang         DATETIME,
    NgayGiaoHang        DATETIME,
    NgayThanhToan       DATETIME,
    TienCoc             DECIMAL(18,0), 
    TriGiaDH            DECIMAL(18,0), 
    TrangThaiDH         NVARCHAR(50),
    PhuongThucThanhToan NVARCHAR(50),
    SoLanGiaoHang       INT,
    GhiChuDH            NVARCHAR(255),
    CONSTRAINT FK_DDH_KH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
    CONSTRAINT FK_DDH_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

-- 23. NGANHANG
CREATE TABLE NGANHANG (
    MaNH     CHAR(10) PRIMARY KEY,
    MaKH     CHAR(10),
    TenNH    NVARCHAR(50),
    DiaChiNH NVARCHAR(100),
    SDTNH    CHAR(10),
    EmailNH  NVARCHAR(50),
    CONSTRAINT FK_NH_KH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
);

-- 24. THETV
CREATE TABLE THETV (
    SoThe        CHAR(10) PRIMARY KEY,
    MaKH         CHAR(10),
    TenThe       NVARCHAR(50),
    DiemTichLuy  FLOAT,
    CONSTRAINT FK_TV_KH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH)
);

-- 25. CT_PHANQUYEN
CREATE TABLE CT_PHANQUYEN (
    MaVT        CHAR(10),
    MaQuyen     CHAR(10),
    NgayPQ      DATETIME,
    NguoiCap    NVARCHAR(50),
    TrangThaiPQ NVARCHAR(50),
    CONSTRAINT CTPQ_PK PRIMARY KEY (MaVT, MaQuyen),
    CONSTRAINT FK_CTPQ_VT FOREIGN KEY (MaVT) REFERENCES VAITRO(MaVT),
    CONSTRAINT FK_CTPQ_Q FOREIGN KEY (MaQuyen) REFERENCES QUYEN(MaQuyen)
);

-- 26. CHITIET_PN
CREATE TABLE CHITIET_PN (
    MaNL          CHAR(10),
    SoPN          CHAR(10),
    SoLuongNhap   DECIMAL(10,2), 
    DonGiaNhap    DECIMAL(18,0), 
    ThanhTienNhap DECIMAL(18,0), 
    CONSTRAINT CTPN_PK PRIMARY KEY (MaNL, SoPN),
    CONSTRAINT FK_CTPN_NL FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL),
    CONSTRAINT FK_CTPN_PNK FOREIGN KEY (SoPN) REFERENCES PHIEUNHAPKHO(SoPN)
);

-- 27. TONKHO
CREATE TABLE TONKHO (
    MaKho            CHAR(10),
    MaSP             CHAR(10),
    SLTonDauKy       INT,
    SLTonCuoiKy      INT,
    SLNhapTrongKy    INT,
    SLXuatTrongKy    INT,
    TGNhapDauKy      DECIMAL(18,0),
    TGNhapTrongKy    DECIMAL(18,0),
    TGXuatTrongKy    DECIMAL(18,0),
    TGNhapTruocKy    DECIMAL(18,0),
    TGXuatTruocKy    DECIMAL(18,0),
    NgayCapNhatKho   DATE,
    CONSTRAINT TONKHO_PK PRIMARY KEY (MaKho, MaSP),
    CONSTRAINT FK_TONKHO_KHO FOREIGN KEY (MaKho) REFERENCES KHO(MaKho),
    CONSTRAINT FK_TONKHO_SP  FOREIGN KEY (MaSP)  REFERENCES SANPHAM(MaSP)
);

-- 28. DINH_MUC
CREATE TABLE DINH_MUC (
    MaNL       CHAR(10),
    MaSP       CHAR(10),
    SoLuongNL  DECIMAL(10,3),
    CONSTRAINT DM_PK PRIMARY KEY (MaNL, MaSP),
    CONSTRAINT FK_DM_NL FOREIGN KEY (MaNL) REFERENCES NGUYENLIEU(MaNL),
    CONSTRAINT FK_DM_SP FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
);

-- 29. CT_KM
CREATE TABLE CT_KM (
    MaSP              CHAR(10),
    MaCTKM            CHAR(10),
    TyLePhanTram      DECIMAL(5,2),
    GiamTheoSanPham   DECIMAL(18,0),
    GhiChuCTKM        NVARCHAR(255),
    CONSTRAINT CT_KM_PK PRIMARY KEY (MaSP, MaCTKM),
    CONSTRAINT FK_CTKM_SP FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP),
    CONSTRAINT FK_CTKM_KM FOREIGN KEY (MaCTKM) REFERENCES CTKM(MaCTKM)
);

-- 30. CT_DH
CREATE TABLE CT_DH (
    MaDDH       CHAR(10),
    MaSP        CHAR(10),
    SoLuongDDH  INT,
    DonGiaDDH   DECIMAL(18,0), 
    CONSTRAINT CTDH_PK PRIMARY KEY (MaDDH, MaSP),
    CONSTRAINT FK_CTDH_DDH FOREIGN KEY (MaDDH) REFERENCES DONDATHANG(MaDDH),
    CONSTRAINT FK_CTDH_SP  FOREIGN KEY (MaSP)  REFERENCES SANPHAM(MaSP)
);

-- 31. DVTSP
CREATE TABLE DVTSP (
    MaDVTSP    CHAR(10) PRIMARY KEY,
    MaSP       CHAR(10),
    TenDVTSP   NVARCHAR(50),
    CONSTRAINT FK_DVTSP_SP FOREIGN KEY (MaSP) REFERENCES SANPHAM(MaSP)
);

-- 32. DONVITINHQUYDOI
CREATE TABLE DONVITINHQUYDOI (
    MaDVTQD     CHAR(10) PRIMARY KEY,
    MaSP        CHAR(10),
    MaDVTSP     CHAR(10),
    TenQD       NVARCHAR(100),
    SLQD        INT,
    CONSTRAINT FK_DVTQD_SP  FOREIGN KEY (MaSP)    REFERENCES SANPHAM(MaSP),
    CONSTRAINT FK_DVTQD_DVT FOREIGN KEY (MaDVTSP) REFERENCES DVTSP(MaDVTSP)
);

-- 33. CT_PX
CREATE TABLE CT_PX (
    SoPX           CHAR(10),
    MaKho          CHAR(10),
    SLXuat         INT,
    DGXuat         DECIMAL(18,0),
    ThanhTienXuat  DECIMAL(18,0),
    CONSTRAINT CTPX_PK PRIMARY KEY (SoPX, MaKho),
    CONSTRAINT FK_CTPX_PX  FOREIGN KEY (SoPX)  REFERENCES PHIEUXUAT(SoPX),
    CONSTRAINT FK_CTPX_KHO FOREIGN KEY (MaKho) REFERENCES KHO(MaKho)
);

-- 34. LENHBANHANG
CREATE TABLE LENHBANHANG (
    MaLBH       CHAR(10) PRIMARY KEY,
    SoPX        CHAR(10),
    MaNV        CHAR(10),
    NgayLap     DATETIME,
    GhiChuLBH   NVARCHAR(255),
    CONSTRAINT FK_LBH_PX FOREIGN KEY (SoPX) REFERENCES PHIEUXUAT(SoPX),
    CONSTRAINT FK_LBH_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

-- 35. SODUDAUKY
CREATE TABLE SODUDAUKY (
    SoTK       VARCHAR(10) PRIMARY KEY,
    SoTKC3     VARCHAR(10),
    TenTK      NVARCHAR(50),
    SDDKNo     DECIMAL(18,0),
    SDDKCo     DECIMAL(18,0),
    ThangNam   DATE,
    CONSTRAINT FK_SDDK_C3 FOREIGN KEY (SoTKC3) REFERENCES TAIKHOANCAP3(SoTKC3)
);

-- 36. CONGNO
CREATE TABLE CONGNO (
    MaCN             CHAR(10) PRIMARY KEY,
    MaKH             CHAR(10),            
    MaNCC            CHAR(10),            
    LoaiCongNo       NVARCHAR(20) NOT NULL, 
    NgayPhatSinh     DATE NOT NULL,
    HanThanhToan     DATE NOT NULL,
    SoTienNo         DECIMAL(18,0), 
    SoTienDaTra      DECIMAL(18,0) DEFAULT 0, 
    TrangThai        NVARCHAR(50),        
    GhiChu           NVARCHAR(255),
    CONSTRAINT FK_CN_KH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
    CONSTRAINT FK_CN_NCC FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC)
);

-- 37. BAOCAO
CREATE TABLE BAOCAO (
    MaBC        CHAR(10) PRIMARY KEY,
    MaNV        CHAR(10),
    NgayLapBC   DATETIME,
    LoaiBC      NVARCHAR(50),
    NoiDungBC   NVARCHAR(100),
    TongGiaTri  DECIMAL(18,0),
    CONSTRAINT FK_BC_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV)
);

PRINT N'================================================';
PRINT N'  PHẦN 4: TẠO CÁC BẢNG CẤP 4';
PRINT N'================================================';
GO

-- 38. HOADONBAN
CREATE TABLE HOADONBAN (
    SoHDB               CHAR(10) PRIMARY KEY,
    MaDDH               CHAR(10),
    NgayLapHDB          DATE,
    TiencocHDB          DECIMAL(18,0),
    TriGiaTruocthueHDB  DECIMAL(18,0),
    TriGiaSauthueHDB    DECIMAL(18,0),
    GiamGiaHDB          DECIMAL(18,0),
    TriGiaSauGiam       DECIMAL(18,0),
    CONSTRAINT FK_HDB_DDH FOREIGN KEY (MaDDH) REFERENCES DONDATHANG(MaDDH)
);

-- 39. PHIEUTHANHTOAN
CREATE TABLE PHIEUTHANHTOAN (
    SoPTT        CHAR(10) PRIMARY KEY,
    SoHDB        CHAR(10),
    MaNV         CHAR(10),
    NgayTT       DATETIME DEFAULT GETDATE(), 
    SoTienTT     DECIMAL(18,0),
    HinhThucTT   NVARCHAR(30),
    TrangThaiTT  NVARCHAR(30), 
    CONSTRAINT FK_PTT_HDB FOREIGN KEY (SoHDB) REFERENCES HOADONBAN(SoHDB),
    CONSTRAINT FK_PTT_NV  FOREIGN KEY (MaNV)  REFERENCES NHANVIEN(MaNV)
);

-- 40. PHIEU_THU (Bổ sung theo yêu cầu)
CREATE TABLE PHIEU_THU (
    SoPhieuThu  CHAR(10) PRIMARY KEY,
    NgayLap     DATE,
    SoTienThu   DECIMAL(18,0),
    LyDoThu     NVARCHAR(200),
    HinhThucTT  NVARCHAR(50), 
    MaKH        CHAR(10),     
    MaNV        CHAR(10),     
    ThamChieuHD CHAR(10),     
    TK_No       CHAR(10) DEFAULT '111', 
    TK_Co       CHAR(10) DEFAULT '131', 
    CONSTRAINT FK_PT_KH FOREIGN KEY (MaKH) REFERENCES KHACHHANG(MaKH),
    CONSTRAINT FK_PT_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    CONSTRAINT FK_PT_HD FOREIGN KEY (ThamChieuHD) REFERENCES HOADONBAN(SoHDB)
);

-- 41. PHIEU_CHI (Bổ sung theo yêu cầu)
CREATE TABLE PHIEU_CHI (
    SoPhieuChi  CHAR(10) PRIMARY KEY,
    NgayLap     DATE,
    SoTienChi   DECIMAL(18,0),
    LyDoChi     NVARCHAR(200),
    HinhThucTT  NVARCHAR(50),
    MaNCC       CHAR(10),     
    MaNV        CHAR(10),
    ThamChieuPN CHAR(10),     
    TK_No       CHAR(10) DEFAULT '331', 
    TK_Co       CHAR(10) DEFAULT '111', 
    CONSTRAINT FK_PC_NCC FOREIGN KEY (MaNCC) REFERENCES NHACUNGCAP(MaNCC),
    CONSTRAINT FK_PC_NV FOREIGN KEY (MaNV) REFERENCES NHANVIEN(MaNV),
    CONSTRAINT FK_PC_PN FOREIGN KEY (ThamChieuPN) REFERENCES PHIEUNHAPKHO(SoPN)
);

-- 42. BUTTOAN (Cấu trúc đầy đủ với các cột khóa ngoại)
CREATE TABLE BUTTOAN (
    SoCT          VARCHAR(10) PRIMARY KEY,
    SOBT          VARCHAR(10), -- Cột mới liên kết TKC3
    NgayHachToan  DATE,
    DienGiai      NVARCHAR(255),
    TKNo          CHAR(10),
    TKCo          CHAR(10),
    SoTienBT      DECIMAL(18,0),
    SLBT          FLOAT,
    DonGiaBT      DECIMAL(18,0),
    TrangThai     NVARCHAR(50) DEFAULT N'Chưa ghi sổ',
    
    -- Các cột tham chiếu
    Ref_MaHDB     CHAR(10),
    Ref_SoPN      CHAR(10),
    Ref_SoPX      CHAR(10),
    Ref_SoPT      CHAR(10),
    Ref_SoPC      CHAR(10),

    CONSTRAINT FK_BUTTOAN_TKC3 FOREIGN KEY (SOBT) REFERENCES TAIKHOANCAP3(SoTKC3),
    CONSTRAINT FK_BT_HDB FOREIGN KEY (Ref_MaHDB) REFERENCES HOADONBAN(SoHDB),
    CONSTRAINT FK_BT_PN  FOREIGN KEY (Ref_SoPN)  REFERENCES PHIEUNHAPKHO(SoPN),
    CONSTRAINT FK_BT_PX  FOREIGN KEY (Ref_SoPX)  REFERENCES PHIEUXUAT(SoPX),
    CONSTRAINT FK_BT_PT  FOREIGN KEY (Ref_SoPT)  REFERENCES PHIEU_THU(SoPhieuThu),
    CONSTRAINT FK_BT_PC  FOREIGN KEY (Ref_SoPC)  REFERENCES PHIEU_CHI(SoPhieuChi)
);
GO

PRINT N'✓ Đã tạo đủ 42 Bảng thành công.';
GO

-- ============================================================
-- PHẦN 1: CHÈN DỮ LIỆU CƠ SỞ 
-- ============================================================

-- 1. PHONGBAN (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu Bảng PHONGBAN (10 dòng)...';
    INSERT INTO PHONGBAN (MaPB, TenPB, DTPB, EmailPB)
    VALUES
    ('PB001', N'Kinh Doanh', '0281234567', 'kd@acecook.vn'),
    ('PB002', N'Sản Xuất', '0281234568', 'sx@acecook.vn'),
    ('PB003', N'Kho', '0281234569', 'kho@acecook.vn'),
    ('PB004', N'Kế Toán', '0281234570', 'kt@acecook.vn'),
    ('PB005', N'Marketing', '0281234571', 'mkt@acecook.vn'),
    ('PB006', N'Nhân Sự', '0281234572', 'hr@acecook.vn'),
    ('PB007', N'R&D', '0281234573', 'rd@acecook.vn'),
    ('PB008', N'IT', '0281234574', 'it@acecook.vn'),
    ('PB009', N'Quản Lý Chất Lượng', '0281234575', 'qa@acecook.vn'),
    ('PB010', N'Pháp Chế', '0281234576', 'legal@acecook.vn');
    COMMIT TRAN;
    PRINT N'✓ Chèn dữ liệu PHONGBAN thành công.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu PHONGBAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 2. CHUCVU (10 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu Bảng CHUCVU (10 dòng)...';
    INSERT INTO CHUCVU (MaCV, TenCV, GhiChuCV)
    VALUES
    ('CV001', N'Giám đốc', N'Quản lý chung'),
    ('CV002', N'Trưởng phòng', N'Quản lý cấp phòng ban'),
    ('CV003', N'Nhân viên Kế toán', N'Chịu trách nhiệm sổ sách'),
    ('CV004', N'Nhân viên Kinh doanh', N'Thực hiện bán hàng'),
    ('CV005', N'Thủ kho', N'Quản lý kho hàng'),
    ('CV006', N'Kỹ sư sản xuất', N'Quản lý dây chuyền'),
    ('CV007', N'Nhân viên Marketing', N'Quảng bá sản phẩm'),
    ('CV008', N'Chuyên viên Nhân sự', N'Tuyển dụng và đào tạo'),
    ('CV009', N'Nhân viên IT', N'Hỗ trợ kỹ thuật'),
    ('CV010', N'Quản lý dự án', N'Điều phối dự án R&D');
    COMMIT TRAN;
    PRINT N'✓ Chèn dữ liệu CHUCVU thành công.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu CHUCVU: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 3. VAITRO (19 dòng) 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO VAITRO (MaVT, TenVT, MoTaVT)
    VALUES
    ('VT001', N'Quản Trị Viên', N'Toàn quyền truy cập hệ thống'),
    ('VT002', N'Kế Toán Trưởng', N'Quản lý tài chính và kế toán'),
    ('VT003', N'Quản Lý Kinh Doanh', N'Quản lý hoạt động bán hàng'),
    ('VT004', N'Quản Lý Sản Xuất', N'Quản lý quy trình sản xuất'),
    ('VT005', N'Quản Lý Kho', N'Quản lý kho vận'),
    ('VT006', N'Nhân Viên Kế Toán', N'Xử lý nghiệp vụ kế toán'),
    ('VT007', N'Nhân Viên Bán Hàng', N'Bán hàng và chăm sóc khách'),
    ('VT008', N'Nhân Viên Kho', N'Nhập xuất kho'),
    ('VT009', N'Nhân Viên Sản Xuất', N'Vận hành máy móc'),
    ('VT010', N'Kế Toán Công Nợ', N'Quản lý công nợ'),
    ('VT011', N'Kế Toán Thanh Toán', N'Xử lý thanh toán'),
    ('VT012', N'Giám Sát Bán Hàng', N'Giám sát nhân viên bán hàng'),
    ('VT013', N'Giám Sát Kho', N'Giám sát hoạt động kho'),
    ('VT014', N'Trưởng Nhóm Kinh Doanh', N'Dẫn dắt nhóm bán hàng'),
    ('VT015', N'Điều Phối Sản Xuất', N'Điều phối kế hoạch sản xuất'),
    ('VT016', N'Kiểm Toán Nội Bộ', N'Kiểm tra quy trình nội bộ'),
    ('VT017', N'Nhân Viên Giao Nhận', N'Giao nhận hàng hóa'),
    ('VT018', N'Thủ Quỹ', N'Quản lý tiền mặt'),
    ('VT019', N'Nhân Viên Hỗ Trợ', N'Hỗ trợ các phòng ban');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào VAITRO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu VAITRO: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 4. QUYEN (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu Bảng QUYEN (10 dòng)...';
    INSERT INTO QUYEN (MaQuyen, TenQuyen, MoTaQuyen)
    VALUES
    ('QY001', N'Tạo mới', N'Tạo mới bản ghi'),
    ('QY002', N'Đọc', N'Xem chi tiết bản ghi'),
    ('QY003', N'Cập nhật', N'Sửa bản ghi'),
    ('QY004', N'Xóa', N'Xóa bản ghi'),
    ('QY005', N'Duyệt', N'Duyệt các giao dịch, chứng từ'),
    ('QY006', N'Hạch toán', N'Thực hiện bút toán'),
    ('QY007', N'Xuất báo cáo', N'Tải xuống báo cáo'),
    ('QY008', N'Quản lý người dùng', N'Thêm, sửa, khóa tài khoản'),
    ('QY009', N'Quản lý danh mục', N'Quản lý các bảng master'),
    ('QY010', N'Thiết lập hệ thống', N'Thay đổi cấu hình hệ thống');
    COMMIT TRAN;
    PRINT N'✓ Chèn dữ liệu QUYEN thành công.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu QUYEN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 5. LOAIKHACHHANG (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO LOAIKHACHHANG (MaLoaiKH, TenLoaiKH, GhiChuLoaiKH)
    VALUES
    ('LKH001', N'Khách Lẻ', N'Khách hàng mua lẻ'),
    ('LKH002', N'Đại Lý Cấp 1', N'Đại lý phân phối chính'),
    ('LKH003', N'Đại Lý Cấp 2', N'Đại lý phân phối phụ'),
    ('LKH004', N'Siêu Thị', N'Chuỗi siêu thị lớn'),
    ('LKH005', N'Cửa Hàng Tạp Hóa', N'Cửa hàng bán lẻ nhỏ'),
    ('LKH006', N'Nhà Hàng', N'Khách hàng nhà hàng'),
    ('LKH007', N'Khách Sạn', N'Khách hàng khách sạn'),
    ('LKH008', N'Trường Học', N'Khách hàng trường học'),
    ('LKH009', N'Bệnh Viện', N'Khách hàng bệnh viện'),
    ('LKH010', N'VIP', N'Khách hàng VIP'),
    ('LKH011', N'Khách Doanh Nghiệp', N'Khách hàng doanh nghiệp'),
    ('LKH012', N'Công Ty Xuất Khẩu', N'Khách hàng xuất khẩu'),
    ('LKH013', N'Nhà Phân Phối', N'Nhà phân phối độc quyền'),
    ('LKH014', N'Chuỗi Minimart', N'Chuỗi cửa hàng tiện lợi'),
    ('LKH015', N'Online', N'Khách hàng mua online'),
    ('LKH016', N'Co.opmart', N'Hệ thống Co.opmart'),
    ('LKH017', N'BigC', N'Hệ thống BigC'),
    ('LKH018', N'Lotte Mart', N'Hệ thống Lotte Mart'),
    ('LKH019', N'Khách Hội Chợ', N'Khách tham gia hội chợ'),
    ('LKH020', N'Đối Tác Chiến Lược', N'Đối tác lâu dài');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào LOAIKHACHHANG.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu LOAIKHACHHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 6. KHO (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO KHO (MaKho, TenKho, ViTri, SDTKho, EmailKho)
    VALUES
    ('KHO001', N'Kho Trung Tâm HCM', N'Bình Tân, TP.HCM', '0287654321', 'khotrungtam@acecook.vn'),
    ('KHO002', N'Kho Miền Bắc', N'Tỉnh Bắc Ninh', '0243456789', 'khomienbac@acecook.vn'),
    ('KHO003', N'Kho Miền Trung', N'TP. Đà Nẵng', '0236789123', 'khomientrung@acecook.vn'),
    ('KHO004', N'Kho Nguyên Liệu', N'P. Thủ Đức, TP.HCM', '0287654322', 'khonguyenlieu@acecook.vn'),
    ('KHO005', N'Kho Thành Phẩm', N'TP.HCM', '0274567890', 'khothanhpham@acecook.vn'),
    ('KHO006', N'Kho Xuất Khẩu', N'P. Thủ Đức, TP.HCM', '0287654323', 'khoxuatkhau@acecook.vn'),
    ('KHO007', N'Kho Dự Trữ 1', N'Tỉnh Tây Ninh', '0272345678', 'khodutru1@acecook.vn'),
    ('KHO008', N'Kho Dự Trữ 2', N'Tỉnh Đồng Nai', '0251234567', 'khodutru2@acecook.vn'),
    ('KHO009', N'Kho Phụ Tùng', N'Hóc Môn, TP.HCM', '0287654324', 'khophutung@acecook.vn'),
    ('KHO010', N'Kho Bao Bì', N'TP.HCM', '0274567891', 'khobaobi@acecook.vn'),
    ('KHO011', N'Kho Gia Vị', N'P.Tân Phú, TP.HCM', '0287654325', 'khogiavi@acecook.vn'),
    ('KHO012', N'Kho Tây Ninh', N'Tỉnh Tây Ninh', '0276543210', 'khotayninh@acecook.vn'),
    ('KHO013', N'Kho Cần Thơ', N'TP. Cần Thơ', '0292345678', 'khocantho@acecook.vn'),
    ('KHO014', N'Kho Hải Phòng', N'TP. Hải Phòng', '0225678901', 'khohaiphong@acecook.vn'),
    ('KHO015', N'Kho Hà Nội', N'TP. Hà Nội', '0243456790', 'khohanoi@acecook.vn'),
    ('KHO016', N'Kho Nghệ An', N'Tỉnh Nghệ An', '0238765432', 'khonghean@acecook.vn'),
    ('KHO017', N'Kho Quảng Ngãi', N'Tỉnh Quảng Ngãi', '0255678901', 'khoquangngai@acecook.vn'),
    ('KHO018', N'Kho Vũng Tàu', N'TP.HCM', '0254567890', 'khovungtau@acecook.vn'),
    ('KHO019', N'Kho Kiên Giang', N'Tỉnh An Giang', '0297654321', 'khokiengiang@acecook.vn'),
    ('KHO020', N'Kho An Giang', N'Tỉnh An Giang', '0296543210', 'khoangiang@acecook.vn');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào KHO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu KHO: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 7. NGUYENLIEU (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO NGUYENLIEU (MaNL, TenNL, DVTNL)
    VALUES
    ('NL001', N'Bột Mì', N'Kg'),
    ('NL002', N'Bột Năng', N'Kg'),
    ('NL003', N'Dầu Thực Vật', N'Lít'),
    ('NL004', N'Muối', N'Kg'),
    ('NL005', N'Đường', N'Kg'),
    ('NL006', N'Bột Ngọt', N'Kg'),
    ('NL007', N'Hạt Nêm', N'Kg'),
    ('NL008', N'Ớt Bột', N'Kg'),
    ('NL009', N'Tỏi Sấy', N'Kg'),
    ('NL010', N'Hành Khô', N'Kg'),
    ('NL011', N'Nước Tương', N'Lít'),
    ('NL012', N'Nước Mắm', N'Lít'),
    ('NL013', N'Xương Hầm', N'Kg'),
    ('NL014', N'Thịt Heo Xay', N'Kg'),
    ('NL015', N'Tôm Khô', N'Kg'),
    ('NL016', N'Rau Thơm Sấy', N'Kg'),
    ('NL017', N'Tinh Bột', N'Kg'),
    ('NL018', N'Phụ Gia Thực Phẩm', N'Kg'),
    ('NL019', N'Bao Bì Nhựa', N'Thùng'),
    ('NL020', N'Thùng Carton', N'Thùng');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào NGUYENLIEU.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu NGUYENLIEU: ' + ERROR_MESSAGE();
END CATCH;
GO

BEGIN TRANSACTION;
BEGIN TRY
    -- Cập nhật nhóm Bột/Gia vị
    UPDATE NGUYENLIEU SET SoLuongTon = 5000 WHERE MaNL = 'NL001'; -- Bột Mì
    UPDATE NGUYENLIEU SET SoLuongTon = 2000 WHERE MaNL = 'NL002'; -- Bột Năng
    UPDATE NGUYENLIEU SET SoLuongTon = 3000 WHERE MaNL = 'NL003'; -- Dầu Thực Vật
    UPDATE NGUYENLIEU SET SoLuongTon = 1500 WHERE MaNL = 'NL004'; -- Muối
    UPDATE NGUYENLIEU SET SoLuongTon = 2500 WHERE MaNL = 'NL005'; -- Đường
    UPDATE NGUYENLIEU SET SoLuongTon = 1000 WHERE MaNL = 'NL006'; -- Bột Ngọt
    UPDATE NGUYENLIEU SET SoLuongTon = 1200 WHERE MaNL = 'NL007'; -- Hạt Nêm
    UPDATE NGUYENLIEU SET SoLuongTon = 800  WHERE MaNL = 'NL008'; -- Ớt Bột
    UPDATE NGUYENLIEU SET SoLuongTon = 900  WHERE MaNL = 'NL009'; -- Tỏi Sấy
    UPDATE NGUYENLIEU SET SoLuongTon = 850  WHERE MaNL = 'NL010'; -- Hành Khô

    -- Cập nhật nhóm Nước chấm/Thực phẩm tươi
    UPDATE NGUYENLIEU SET SoLuongTon = 4000 WHERE MaNL = 'NL011'; -- Nước Tương
    UPDATE NGUYENLIEU SET SoLuongTon = 3500 WHERE MaNL = 'NL012'; -- Nước Mắm
    UPDATE NGUYENLIEU SET SoLuongTon = 500  WHERE MaNL = 'NL013'; -- Xương Hầm
    UPDATE NGUYENLIEU SET SoLuongTon = 600  WHERE MaNL = 'NL014'; -- Thịt Heo Xay
    UPDATE NGUYENLIEU SET SoLuongTon = 300  WHERE MaNL = 'NL015'; -- Tôm Khô
    UPDATE NGUYENLIEU SET SoLuongTon = 200  WHERE MaNL = 'NL016'; -- Rau Thơm Sấy
    UPDATE NGUYENLIEU SET SoLuongTon = 1500 WHERE MaNL = 'NL017'; -- Tinh Bột
    UPDATE NGUYENLIEU SET SoLuongTon = 5000 WHERE MaNL = 'NL018'; -- Phụ Gia

    -- Cập nhật nhóm Bao bì (Số lượng thường lớn)
    UPDATE NGUYENLIEU SET SoLuongTon = 20000 WHERE MaNL = 'NL019'; -- Bao Bì Nhựa
    UPDATE NGUYENLIEU SET SoLuongTon = 10000 WHERE MaNL = 'NL020'; -- Thùng Carton

    COMMIT TRANSACTION;
    PRINT N'✓ Đã cập nhật số lượng tồn kho cho 20 nguyên vật liệu.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT N'❌ Lỗi khi cập nhật dữ liệu: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 8. LOAISANPHAM (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO LOAISANPHAM (MaLoaiSP, TenLoaiSP, GhiChuLoaiSP)
    VALUES
    ('LSP001', N'Mì Ly', N'Mì ăn liền dạng ly'),
    ('LSP002', N'Mì Gói', N'Mì ăn liền dạng gói'),
    ('LSP003', N'Hủ Tiếu', N'Hủ tiếu các loại'),
    ('LSP004', N'Phở', N'Phở bò, phở gà'),
    ('LSP005', N'Bún', N'Bún bò, bún riêu'),
    ('LSP006', N'Miến', N'Miến gà, miến lươn'),
    ('LSP007', N'Mì Tô', N'Mì dạng tô lớn'),
    ('LSP008', N'Cháo', N'Cháo thịt bằm, gà'),
    ('LSP009', N'Bún Khô', N'Bún khô trộn'),
    ('LSP010', N'Mì Xào', N'Mì xào khô'),
    ('LSP011', N'Mì Cao Cấp', N'Mì cao cấp hảo hạng'),
    ('LSP012', N'Mì Lẩu', N'Mì dùng cho lẩu'),
    ('LSP013', N'Mì Rau Củ', N'Mì có rau củ'),
    ('LSP014', N'Mì Hải Sản', N'Mì vị hải sản'),
    ('LSP015', N'Mì Kim Chi', N'Mì vị kim chi Hàn Quốc'),
    ('LSP016', N'Mì Chua Cay', N'Mì vị chua cay'),
    ('LSP017', N'Mì Vegetarian', N'Mì chay'),
    ('LSP018', N'Mì Vị Lẩu Thái', N'Mì vị lẩu Thái'),
    ('LSP019', N'Mì Trứng', N'Mì trứng tươi'),
    ('LSP020', N'Combo Set', N'Set combo nhiều sản phẩm');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào LOAISANPHAM.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu LOAISANPHAM: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 9. SANPHAM (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO SANPHAM (MaSP, MaLoaiSP, TenSP, MoTa, GiaBanSP, NhietDoBaoQuan, NSXSP, HSDSP) VALUES
('SP001', 'LSP001', N'Hảo Hảo Tôm Chua Cay Ly', N'Mì ly vị tôm chua cay 75g', 7000, N'Thường', '2025-01-01', '2026-01-01'),
('SP002', 'LSP002', N'Hảo Hảo Tôm Chua Cay Gói', N'Mì gói vị tôm chua cay 75g', 3500, N'Thường', '2025-01-15', '2026-01-15'),
('SP003', 'LSP003', N'Hủ Tiếu Nam Vang', N'Hủ tiếu Nam Vang 75g', 4000, N'Thường', '2025-02-01', '2026-02-01'),
('SP004', 'LSP004', N'Phở Bò Hảo Hảo', N'Phở bò hương vị đậm đà 73g', 4500, N'Thường', '2025-02-15', '2026-02-15'),
('SP005', 'LSP001', N'Mì Ly Bò Hầm', N'Mì ly vị bò hầm 70g', 7500, N'Thường', '2025-03-01', '2026-03-01'),
('SP006', 'LSP005', N'Bún Bò Huế', N'Bún bò Huế cay nồng 80g', 5000, N'Thường', '2025-03-15', '2026-03-15'),
('SP007', 'LSP006', N'Miến Gà Hảo Hảo', N'Miến gà thơm ngon 68g', 3800, N'Thường', '2025-04-01', '2026-04-01'),
('SP008', 'LSP007', N'Mì Tô Bò Sốt Tiêu', N'Mì tô lớn vị bò sốt tiêu 98g', 9500, N'Thường', '2025-04-15', '2026-04-15'),
('SP009', 'LSP011', N'Mì Premium Tôm Hùm', N'Mì cao cấp vị tôm hùm 85g', 12000, N'Thường', '2025-05-01', '2026-05-01'),
('SP010', 'LSP002', N'Hảo Hảo Mi Goreng', N'Mì xào khô vị goreng 75g', 4200, N'Thường', '2025-05-15', '2026-05-15'),
('SP011', 'LSP014', N'Mì Hải Sản Chua Cay', N'Mì vị hải sản chua cay 77g', 4800, N'Thường', '2025-06-01', '2026-06-01'),
('SP012', 'LSP001', N'Mì Ly Sườn Hầm', N'Mì ly vị sườn hầm 78g', 8000, N'Thường', '2025-06-15', '2026-06-15'),
('SP013', 'LSP008', N'Cháo Gà Nấm', N'Cháo gà nấm dinh dưỡng 50g', 6500, N'Thường', '2025-07-01', '2026-07-01'),
('SP014', 'LSP015', N'Mì Kim Chi', N'Mì vị kim chi Hàn Quốc 80g', 5500, N'Thường', '2025-07-15', '2026-07-15'),
('SP015', 'LSP004', N'Phở Gà Acecook', N'Phở gà truyền thống 75g', 4700, N'Thường', '2025-08-01', '2026-08-01'),
('SP016', 'LSP012', N'Mì Lẩu Thái', N'Mì lẩu Thái Tom Yum 85g', 6000, N'Thường', '2025-08-15', '2026-08-15'),
('SP017', 'LSP017', N'Mì Chay Rau Củ', N'Mì chay rau củ dinh dưỡng 70g', 4500, N'Thường', '2025-09-01', '2026-09-01'),
('SP018', 'LSP002', N'Hảo Hảo Tôm Nấm', N'Mì gói vị tôm nấm 75g', 3800, N'Thường', '2025-09-15', '2026-09-15'),
('SP019', 'LSP010', N'Mì Xào Bò Teriyaki', N'Mì xào khô bò teriyaki 82g', 5200, N'Thường', '2025-10-01', '2026-10-01'),
('SP020', 'LSP020', N'Combo 5 Hảo Hảo', N'Combo 5 gói hảo hảo đa vị', 17000, N'Thường', '2025-10-15', '2026-10-15');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào SANPHAM (Cập nhật năm 2025/2026).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu SANPHAM: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 10. KHACHHANG (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO KHACHHANG (MaKH, TenKH, SDTKH, EmailKH, DiaChiKH, MSTKH, STKKH, CongNoKH, GhiChuKH)
    VALUES
    ('KH001', N'Siêu Thị Co.opmart Lý Thường Kiệt', '0901234567', 'coopmart.ltk@gmail.com', N'88, Phường Phú Nhuận TP.HCM', '0123456789', '1234567890', 0, N'Khách VIP'),
    ('KH002', N'Siêu Thị BigC Miền Đông', '0902345678', 'bigc.miendong@gmail.com', N'206, P. Thủ Đức, TP.HCM', '0234567890', '2345678901', 5000000, N'Khách hàng lâu năm'),
    ('KH003', N'Tạp Hóa Phương Loan', '0903456789', 'taphoaloan@gmail.com', N'123, Phường Diên Hồng, TP.HCM', '0345678901', '3456789012', 2000000, NULL),
    ('KH004', N'Nhà Hàng Món Huế', '0904567890', 'nhamonhue@gmail.com', N'168-170, Phường Bến Nghé, TP.HCM', '0456789012', '4567890123', 0, N'Đặt hàng định kỳ'),
    ('KH005', N'Khách Sạn Continental Saigon', '0905678901', 'continental.hcm@gmail.com', N'456, Phường Bến Nghé, TP.HCM', '0567890123', '5678901234', 8000000, N'Khách VIP'),
    ('KH006', N'Trường THPT Lê Hồng Phong', '0906789012', 'lehongphong.school@gmail.com', N'235, Phường Chợ QUán, TP.HCM', '0678901234', '6789012345', 0, N'Khách cơ quan'),
    ('KH007', N'Bệnh Viện Chợ Rẫy', '0907890123', 'choray.hospital@gmail.com', N'123, Phường Chợ Lớn, TP.HCM', '0789012345', '7890123456', 0, N'Khách cơ quan'),
    ('KH008', N'Công Ty TNHH Thực Phẩm Tân Phát', '0908901234', 'tanphat.food@gmail.com', N'206, P. Long Trường,TP.HCM', '0890123456', '8901234567', 15000000, N'Đại lý cấp 1'),
    ('KH009', N'Siêu Thị Lotte Mart Võ Văn Ngân', '0909012345', 'lottemart.vvn@gmail.com', N'34, P. Thủ Đức, TP.HCM', '0901234560', '9012345678', 0, N'Khách VIP'),
    ('KH010', N'Circle K Nguyễn Trãi', '0910123456', 'circlek.nguyentrai@gmail.com', N'01, Phường Bàn Cờ, TP.HCM', '1012345678', '0123456781', 3000000, NULL),
    ('KH011', N'Công Ty CP Thương Mại Hồng Phát', '0911234567', 'hongphat.corp@gmail.com', N'36, Quận Đống Đa, Hà Nội', '1123456789', '1234567892', 10000000, N'Khách doanh nghiệp'),
    ('KH012', N'Minimart Gia Hưng', '0912345678', 'giahung.mart@gmail.com', N'101, Phường Cát Lái, TP.HCM', '1234567891', '2345678903', 0, NULL),
    ('KH013', N'Công Ty TNHH Phân Phối Minh Hải', '0913456789', 'minhhai.distributor@gmail.com', N'201, P. An Đông, TP.HCM', '1345678902', '3456789014', 20000000, N'Đối tác chiến lược'),
    ('KH014', N'FamilyMart Lê Văn Việt', '0914567890', 'familymart.lvv@gmail.com', N'55, P. Tăng Nhơn Phú, TP.HCM', '1456789013', '4567890125', 0, N'Khách VIP'),
    ('KH015', N'Quán Cơm Tấm Thiên Phước', '0915678901', 'thienphuoc@gmail.com', N'899, Phường Khánh Hội, TP.HCM', '1567890124', '5678901236', 1000000, NULL),
    ('KH016', N'Tạp Hóa Út Hương', '0916789012', 'uthuong.taphoa@gmail.com', N'262, xã An Châu,Tỉnh An Giang', '1678901235', '6789012347', 500000, NULL),
    ('KH017', N'Siêu Thị MM Mega Market Bình Phú', '0917890123', 'megamarket.binhphu@gmail.com', N'75, Phường Bình Phú, TP.HCM', '1789012346', '7890123458', 0, N'Khách hàng lớn'),
    ('KH018', N'Công Ty TNHH XNK Á Châu', '0918901234', 'achau.export@gmail.com', N'299,Phường Nguyễn Thái Bình, TP.HCM', '1890123457', '8901234569', 30000000, N'Khách xuất khẩu'),
    ('KH019', N'Căn Tin Đại Học Bách Khoa', '0919012345', 'dhbk.canteen@gmail.com', N'100, P. Thủ Đức, TP.HCM', '1901234568', '9012345670', 0, N'Khách cơ quan'),
    ('KH020', N'VinMart+ Võ Thị Sáu', '0920123456', 'vinmart.vothisau@gmail.com', N'77, Phường Nhiêu Lộc, TP.HCM', '2012345679', '0123456782', 0, N'Đối tác chiến lược');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào KHACHHANG.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu KHACHHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- Mục tiêu: Cập nhật cột MaLoaiKH trong bảng KHACHHANG.

-- 1. Siêu thị lớn (LKH004, LKH016, LKH017, LKH018)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH004' WHERE MaKH IN ('KH001', 'KH002', 'KH009', 'KH017'); 

-- 2. Khách hàng lâu năm / Đại lý cấp 1 (LKH008)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH008' WHERE MaKH = 'KH008';

-- 3. Tạp hóa (LKH005)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH005' WHERE MaKH IN ('KH003', 'KH016');

-- 4. Nhà hàng/Quán ăn (LKH006)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH006' WHERE MaKH IN ('KH004', 'KH015');

-- 5. Khách sạn (LKH007)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH007' WHERE MaKH = 'KH005';

-- 6. Khách hàng cơ quan/Trường học/Bệnh viện (LKH008/LKH009)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH008' WHERE MaKH IN ('KH006', 'KH007', 'KH019');

-- 7. Chuỗi Minimart / Tiện lợi (LKH014)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH014' WHERE MaKH IN ('KH010', 'KH012', 'KH014', 'KH020');

-- 8. Khách doanh nghiệp / Đối tác (LKH011, LKH013)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH013' WHERE MaKH IN ('KH011', 'KH013');

-- 9. Khách xuất khẩu (LKH012)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH012' WHERE MaKH = 'KH018';

PRINT N'✓ Đã cập nhật MaLoaiKH cho KHACHHANG thành công.';
GO

-- 11. NHANVIEN (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO NHANVIEN (MaNV, MaPB, MaCV, HoTenNV, SDTNV, EmailNV)
VALUES
('NV001', 'PB001', 'CV001', N'Trần Minh Quân', '0931234567', N'tm@acecook.vn'), 
('NV002', 'PB001', 'CV009', N'Lê Thị Thu Hà', '0934567890', N'la@acecook.vn'), 
('NV003', 'PB003', 'CV003', N'Nguyễn Văn Đức', '0933456789', N'vd@acecook.vn'), 
('NV004', 'PB004', 'CV004', N'Phạm Thị Lan Anh', '0952123458', N'toan@acecook.vn'), 
('NV005', 'PB003', 'CV002', N'Hoàng Thị Mai Tuấn', '0936789012', N'mt@acecook.vn'), 
('NV006', 'PB002', 'CV005', N'Võ Thị Mai Linh', '0942345678', N'huy@acecook.vn'), 
('NV007', 'PB002', 'CV006', N'Dương Văn Hùng', '0941234566', N'ngoc@acecook.vn'), 
('NV008', 'PB004', 'CV007', N'Mai Thị Thu Hương', '0943456790', 'sun@acecook.vn'), 
('NV009', 'PB001', 'CV008', N'Bùi Quốc Huy', '0938901234', 'th@acecook.vn'), 
('NV010', 'PB004', 'CV010', N'Đỗ Thị Ngọc Diệp', '0950123456', 'dt@acecook.vn'), 
('NV011', 'PB003', 'CV004', N'Dương Minh Long', '0943699012', 'ngoc2@acecook.vn'), 
('NV012', 'PB004', 'CV007', N'Nguyễn Thị Bích Ngọc', '0945456789', 'diep@acecook.vn'), 
('NV013', 'PB001', 'CV009', N'Phạm Văn Tài', '0943699123', 'huong@acecook.vn'), 
('NV014', 'PB002', 'CV008', N'Lý Thị Kim Oanh', '0945986768', 'phuc@acecook.vn'), 
('NV015', 'PB003', 'CV004', N'Trịnh Văn Phúc', '0951012345', 'nh@acecook.vn'), 
('NV016', 'PB004', 'CV010', N'Võ Thị Quỳnh Như', '0961123457', 'huyen@acecook.vn'), 
('NV017', 'PB001', 'CV008', N'Trần Văn Sơn', '0978912345', 'linh@acecook.vn'), 
('NV018', 'PB003', 'CV005', N'Hoàng Thị Mỹ Duyên', '0934567891', 'son@acecook.vn'), 
('NV019', 'PB003', 'CV004', N'Lưu Văn Tú', '0933456799', 'de@acecook.vn'), 
('NV020', 'PB004', 'CV010', N'Đỗ Thị Hồng Nhung', '0950123499', 'dtnhung@acecook.vn'); 

    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào NHANVIEN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu NHANVIEN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 12. TAIKHOAN (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO TAIKHOAN (MaTK, MaNV, MaVT, TenDangNhap, MatKhau, TrangThaiTK)
    VALUES
    ('TK001', 'NV001', 'VT001', 'tmquan', 'Quan@123', N'Hoạt động'),
    ('TK002', 'NV002', 'VT002', 'ltthuha', 'ThuHa@456', N'Hoạt động'),
    ('TK003', 'NV003', 'VT003', 'nvduc', 'Duc@789', N'Hoạt động'),
    ('TK004', 'NV004', 'VT004', 'ptlananh', 'LanAnh@012', N'Hoạt động'),
    ('TK005', 'NV005', 'VT006', 'hmtuan', 'Tuan@345', N'Hoạt động'),
    ('TK006', 'NV006', 'VT007', 'vtmailinh', 'MaiLinh@678', N'Hoạt động'),
    ('TK007', 'NV007', 'VT009', 'dvhung', 'Hung@901', N'Hoạt động'),
    ('TK008', 'NV008', 'VT008', 'mtthuong', 'Huong@234', N'Hoạt động'),
    ('TK009', 'NV009', 'VT010', 'bqhuy', 'Huy@567', N'Hoạt động'),
    ('TK010', 'NV010', 'VT012', 'dtndiep', 'Diep@890', N'Hoạt động'),
    ('TK011', 'NV011', 'VT013', 'dmlong', 'Long@123', N'Hoạt động'),
    ('TK012', 'NV012', 'VT005', 'ntbngoc', 'Ngoc@456', N'Đã khóa'),
    ('TK013', 'NV013', 'VT011', 'pvtai', 'Tai@789', N'Hoạt động'),
    ('TK014', 'NV014', 'VT007', 'ltkoanh', 'Oanh@012', N'Hoạt động'),
    ('TK015', 'NV015', 'VT008', 'tvphuc', 'Phuc@345', N'Hoạt động'),
    ('TK016', 'NV016', 'VT018', 'vtqnhu', 'Nhu@678', N'Hoạt động'),
    ('TK017', 'NV017', 'VT015', 'tvson', 'Son@901', N'Hoạt động'),
    ('TK018', 'NV018', 'VT019', 'htmduyen', 'Duyen@234', N'Đã khóa'),
    ('TK019', 'NV019', 'VT004', 'lvtu', 'Tu@567', N'Hoạt động'),
    ('TK020', 'NV020', 'VT005', 'dthnhung', 'Nhung@890', N'Hoạt động');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào TAIKHOAN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TAIKHOAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 13. NGANHANG (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO NGANHANG (MaNH, MaKH, TenNH, DiaChiNH, SDTNH, EmailNH)
    VALUES
    ('NH001', 'KH001', N'Ngân Hàng Vietcombank', N'TP.HCM', '0283823456', 'vietcombank@vcb.com.vn'),
    ('NH002', 'KH002', N'Ngân Hàng BIDV', N'TP. Đà Nẵng', '0236823789', 'bidv.danang@bidv.com.vn'),
    ('NH003', 'KH005', N'Ngân Hàng Techcombank', N'TP.HCM', '0283823457', 'techcombank@tcb.com.vn'),
    ('NH004', 'KH008', N'Ngân Hàng ACB', N'TP.HCM', '0274823123', 'acb.binhduong@acb.com.vn'),
    ('NH005', 'KH011', N'Ngân Hàng Vietinbank', N'TP. Hà Nội', '0243823456', 'vietinbank@vib.com.vn'),
    ('NH006', 'KH013', N'Ngân Hàng MB Bank', N'TP.HCM', '0274823124', 'mbbank@mb.com.vn'),
    ('NH007', 'KH017', N'Ngân Hàng Sacombank', N'TP.HCM', '0283823458', 'sacombank@scb.com.vn'),
    ('NH008', 'KH018', N'Ngân Hàng VPBank', N'TP.HCM', '0283823459', 'vpbank@vpb.com.vn'),
    ('NH009', 'KH004', N'Ngân Hàng Agribank', N'TP.HCM', '0283823460', 'agribank@agb.com.vn'),
    ('NH010', 'KH020', N'Ngân Hàng TPBank', N'Toàn Quốc', '0283823461', 'tpbank@tpb.com.vn');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào NGANHANG.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu NGANHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 14. THETV (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO THETV (SoThe, MaKH, TenThe, DiemTichLuy)
    VALUES
    ('TTV001', 'KH001', N'Thẻ Bạch Kim', 1000),
    ('TTV002', 'KH002', N'Thẻ Vàng', 800),
    ('TTV003', 'KH003', N'Thẻ Bạc', 600),
    ('TTV004', 'KH004', N'Thẻ Đồng', 400),
    ('TTV005', 'KH005', N'Thẻ Xanh', 300),
    ('TTV006', 'KH006', N'Thẻ Khuyến Mãi', 200),
    ('TTV007', 'KH007', N'Thẻ VIP Doanh Nghiệp', 1200),
    ('TTV008', 'KH008', N'Thẻ Hợp Tác', 900),
    ('TTV009', 'KH009', N'Thẻ Thành Viên Online', 500),
    ('TTV010', 'KH010', N'Thẻ Tích Điểm Co.opmart', 350),
    ('TTV011', 'KH011', N'Thẻ Gia Đình', 450),
    ('TTV012', 'KH012', N'Thẻ Premium', 1000),
    ('TTV013', 'KH013', N'Thẻ Diamond', 1500),
    ('TTV014', 'KH014', N'Thẻ Business', 700),
    ('TTV015', 'KH015', N'Thẻ Gold Online', 750),
    ('TTV016', 'KH016', N'Thẻ Silver Online', 500),
    ('TTV017', 'KH017', N'Thẻ Bronze', 300),
    ('TTV018', 'KH018', N'Thẻ Loyalty', 650),
    ('TTV019', 'KH019', N'Thẻ Classic', 400),
    ('TTV020', 'KH020', N'Thẻ Guest', 100);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào THETV.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu THETV: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 15. CT_PHANQUYEN (10 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CT_PHANQUYEN (MaVT, MaQuyen, NgayPQ, NguoiCap, TrangThaiPQ)
VALUES
('VT001', 'QY001', '2025-01-01', N'Hệ thống', N'Hoạt động'),
('VT002', 'QY002', '2025-01-02', N'Admin', N'Hoạt động'),
('VT003', 'QY003', '2025-01-03', N'Admin', N'Chờ duyệt'),
('VT004', 'QY004', '2025-01-04', N'Admin', N'Hoạt động'),
('VT005', 'QY005', '2025-01-05', N'Admin', N'Hoạt động'),
('VT006', 'QY006', '2025-01-06', N'Quản trị', N'Đã thu hồi'),
('VT007', 'QY007', '2025-01-07', N'Kế toán trưởng', N'Hoạt động'),
('VT008', 'QY008', '2025-01-08', N'Hệ thống', N'Chờ duyệt'),
('VT009', 'QY009', '2025-01-09', N'Admin', N'Hoạt động'),
('VT010', 'QY010', '2025-01-10', N'Admin', N'Hoạt động');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CT_PHANQUYEN (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu CT_PHANQUYEN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 16. PHIEUNHAPKHO (20 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO PHIEUNHAPKHO (SoPN, MaKho, NgayNhap, LyDoNhap, TriGiaNhap)
    VALUES
    ('PN001', 'KHO001', '2025-01-05', N'Nhập nguyên liệu đầu tháng', 50000000),
    ('PN002', 'KHO002', '2025-01-10', N'Nhập bổ sung', 30000000),
    ('PN003', 'KHO003', '2025-01-15', N'Nhập nguyên liệu sản xuất', 45000000),
    ('PN004', 'KHO004', '2025-01-20', N'Nhập bột mì', 25000000),
    ('PN005', 'KHO005', '2025-02-01', N'Nhập thành phẩm từ nhà máy', 80000000),
    ('PN006', 'KHO001', '2025-02-05', N'Nhập nguyên liệu', 55000000),
    ('PN007', 'KHO006', '2025-02-10', N'Nhập hàng xuất khẩu', 90000000),
    ('PN008', 'KHO007', '2025-02-15', N'Nhập dự trữ', 40000000),
    ('PN009', 'KHO008', '2025-03-01', N'Nhập bổ sung', 35000000),
    ('PN010', 'KHO009', '2025-03-05', N'Nhập phụ tùng máy móc', 20000000),
    ('PN011', 'KHO010', '2025-03-10', N'Nhập bao bì', 15000000),
    ('PN012', 'KHO011', '2025-03-15', N'Nhập gia vị', 12000000),
    ('PN013', 'KHO001', '2025-04-01', N'Nhập nguyên liệu tháng 4', 60000000),
    ('PN014', 'KHO012', '2025-04-05', N'Nhập kho Tây Ninh', 38000000),
    ('PN015', 'KHO013', '2025-04-10', N'Nhập kho Cần Thơ', 42000000),
    ('PN016', 'KHO014', '2025-04-15', N'Nhập kho Hải Phòng', 48000000),
    ('PN017', 'KHO015', '2025-05-01', N'Nhập kho Hà Nội', 52000000),
    ('PN018', 'KHO016', '2025-05-05', N'Nhập kho Nghệ An', 32000000),
    ('PN019', 'KHO017', '2025-05-10', N'Nhập kho Quảng Ngãi', 28000000),
    ('PN020', 'KHO018', '2025-05-15', N'Nhập kho Vũng Tàu', 36000000);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào PHIEUNHAPKHO (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu PHIEUNHAPKHO: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 17. CHITIET_PN (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CHITIET_PN (MaNL, SoPN, SoLuongNhap, DonGiaNhap, ThanhTienNhap)
    VALUES
    ('NL001', 'PN001', 1000.00, 25000.00, 25000000.00),
    ('NL002', 'PN001', 500.00, 30000.00, 15000000.00),
    ('NL003', 'PN002', 800.00, 35000.00, 28000000.00),
    ('NL004', 'PN003', 1200.00, 15000.00, 18000000.00),
    ('NL005', 'PN003', 900.00, 20000.00, 18000000.00),
    ('NL006', 'PN004', 600.00, 40000.00, 24000000.00),
    ('NL007', 'PN005', 1500.00, 50000.00, 75000000.00),
    ('NL008', 'PN006', 700.00, 45000.00, 31500000.00),
    ('NL009', 'PN007', 1100.00, 38000.00, 41800000.00),
    ('NL010', 'PN008', 850.00, 42000.00, 35700000.00);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CHITIET_PN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CHITIET_PN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 18. NHACUNGCAP (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO NHACUNGCAP (MaNCC, TenNCC, SDTNCC, EmailNCC, DiaChiNCC, CongNoNCC, GhiChuNCC)
    VALUES
    ('NCC001', N'Công Ty Bột Mì Việt Nam', '0283234567', 'botmivn@gmail.com', N'TP.HCM', 0, N'Nhà cung cấp chính'),
    ('NCC002', N'Công Ty Dầu Thực Vật Tường An', '0283234568', 'tuongan@gmail.com', N'Tỉnh Tây Ninh', 5000000, N'Nhà cung cấp uy tín'),
    ('NCC003', N'Công Ty Muối Việt', '0283234569', 'muoiviet@gmail.com', N'Tỉnh Cà Mau', 0, NULL),
    ('NCC004', N'Công Ty Đường Biên Hòa', '0251234569', 'duongbienhoa@gmail.com', N'Tỉnh Đồng Nai', 3000000, NULL),
    ('NCC005', N'Công Ty Gia Vị Sài Gòn', '0283234570', 'giavisaigon@gmail.com', N'TP.HCM', 0, NULL),
    ('NCC006', N'Công Ty Bao Bì Nhựa Hà Nội', '0243234567', 'baobihn@gmail.com', N'TP. Hà Nội', 8000000, NULL),
    ('NCC007', N'Công Ty Thùng Carton Tân Phú', '0283234571', 'cartontp@gmail.com', N'TP.HCM', 0, NULL),
    ('NCC008', N'Công Ty Hương Liệu Quốc Tế', '0283234572', 'huonglieu@gmail.com', N'TP.HCM', 2000000, NULL),
    ('NCC009', N'Công Ty Xương Thực Phẩm', '0283234573', 'xuongthucpham@gmail.com', N'TP.HCM', 0, NULL),
    ('NCC010', N'Công Ty Tôm Khô Cần Thơ', '0292234567', 'tomkhoct@gmail.com', N'TP. Cần Thơ', 4000000, N'Nhà cung cấp hải sản'),
    ('NCC011', N'Công Ty Rau Củ Đà Lạt', '0263234567', 'raucudalat@gmail.com', N'Tỉnh Lâm Đồng', 0, NULL),
    ('NCC012', N'Công Ty Phụ Gia An Toàn', '0283234574', 'phugiaantoan@gmail.com', N'TP.HCM', 1000000, NULL),
    ('NCC013', N'Công Ty Bột Năng Đồng Tháp', '0277234567', 'botnangdt@gmail.com', N'Tỉnh Đồng Tháp', 0, NULL),
    ('NCC014', N'Công Ty Hành Tỏi Lý Sơn', '0255234567', 'hanhtoilyson@gmail.com', N'Tỉnh Quảng Ngãi', 0, NULL),
    ('NCC015', N'Công Ty Nước Mắm Phú Quốc', '0297234567', 'nuocmampq@gmail.com', N'Tỉnh An Giang', 6000000, N'Nhà cung cấp chất lượng'),
    ('NCC016', N'Công Ty Nước Tương Chinsu', '0283234575', 'chinsu@gmail.com', N'TP.HCM', 0, NULL),
    ('NCC017', N'Công Ty Tinh Bột Sắn', '0272234567', 'tinhbotsan@gmail.com', N'Tỉnh Tây Ninh', 0, NULL),
    ('NCC018', N'Công Ty Ớt Bột Quảng Trị', '0233234567', 'otbotquangtri@gmail.com', N'Tỉnh Quảng Trị', 0, NULL),
    ('NCC019', N'Công Ty Thịt Heo CP Việt Nam', '0283234576', 'cpvietnam@gmail.com', N'TP.HCM', 10000000, N'Nhà cung cấp lớn'),
    ('NCC020', N'Công Ty Hóa Chất Thực Phẩm', '0283234577', 'hoachatthucpham@gmail.com', N'TP.HCM', 0, NULL);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào NHACUNGCAP.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu NHACUNGCAP: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 19. CT_CC (10 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CT_CC (MaNCC, MaNL, GiaCungUng, TGGH, TinhTrangHT)
    VALUES
    ('NCC001', 'NL001', 25000.00, '2025-01-05 08:00:00', 1),
    ('NCC001', 'NL002', 30000.00, '2025-01-05 08:00:00', 1),
    ('NCC002', 'NL003', 35000.00, '2025-01-10 09:00:00', 1),
    ('NCC003', 'NL004', 15000.00, '2025-01-15 10:00:00', 1),
    ('NCC004', 'NL005', 20000.00, '2025-01-20 11:00:00', 1),
    ('NCC005', 'NL006', 40000.00, '2025-02-01 08:30:00', 1),
    ('NCC005', 'NL007', 50000.00, '2025-02-01 08:30:00', 1),
    ('NCC010', 'NL015', 120000.00, '2025-02-05 14:00:00', 1),
    ('NCC015', 'NL012', 55000.00, '2025-02-10 09:30:00', 1),
    ('NCC019', 'NL014', 85000.00, '2025-02-15 13:00:00', 1);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CT_CC (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CT_CC: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 20. TONKHO 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, 
                        TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, TGNhapTruocKy, TGXuatTruocKy, NgayCapNhatKho)
    VALUES
    ('KHO001', 'SP001', 1000, 1500, 1000, 500, 7000000.00, 7000000.00, 3500000.00, 6000000.00, 3000000.00, '2025-01-31'),
    ('KHO001', 'SP002', 2000, 2300, 800, 500, 7000000.00, 2800000.00, 1750000.00, 6500000.00, 3500000.00, '2025-01-31'),
    ('KHO002', 'SP003', 1500, 1800, 600, 300, 6000000.00, 2400000.00, 1200000.00, 5500000.00, 2800000.00, '2025-01-31'),
    ('KHO003', 'SP004', 1200, 1400, 500, 300, 5400000.00, 2250000.00, 1350000.00, 5000000.00, 2700000.00, '2025-01-31'),
    ('KHO005', 'SP005', 800, 1100, 500, 200, 6000000.00, 3750000.00, 1500000.00, 5200000.00, 2400000.00, '2025-01-31'),
    ('KHO001', 'SP006', 1800, 2000, 700, 500, 9000000.00, 3500000.00, 2500000.00, 8500000.00, 4000000.00, '2025-02-28'),
    ('KHO002', 'SP007', 1300, 1500, 400, 200, 4940000.00, 1520000.00, 760000.00, 4500000.00, 2000000.00, '2025-02-28'),
    ('KHO005', 'SP008', 900, 1200, 500, 200, 8550000.00, 4750000.00, 1900000.00, 7500000.00, 3800000.00, '2025-02-28'),
    ('KHO001', 'SP009', 500, 700, 300, 100, 6000000.00, 3600000.00, 1200000.00, 5000000.00, 2500000.00, '2025-03-31'),
    ('KHO003', 'SP010', 1600, 1900, 600, 300, 6720000.00, 2520000.00, 1260000.00, 6000000.00, 3000000.00, '2025-03-31');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào TONKHO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TONKHO: ' + ERROR_MESSAGE();
END CATCH;
GO

USE QLKTBHACECOOK;
GO

BEGIN TRANSACTION;
BEGIN TRY
    -- Xóa dữ liệu cũ của SP011->SP020 trong TONKHO nếu có để tránh trùng lặp
    DELETE FROM TONKHO WHERE MaSP IN ('SP011', 'SP012', 'SP013', 'SP014', 'SP015', 'SP016', 'SP017', 'SP018', 'SP019', 'SP020');

    -- SP011: Mì Hải Sản (Tồn đầu 100, Nhập 100, Xuất 200 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO001', 'SP011', 100, 0, 100, 200, 480000, 480000, 960000, '2025-06-30');

    -- SP012: Mì Ly Sườn (Không tồn đầu, Nhập 50, Xuất 50 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO002', 'SP012', 0, 0, 50, 50, 0, 400000, 400000, '2025-06-30');

    -- SP013: Cháo Gà Nấm (Tồn đầu 200, Không nhập, Xuất 200 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO003', 'SP013', 200, 0, 0, 200, 1300000, 0, 1300000, '2025-06-30');

    -- SP014: Mì Kim Chi (Tồn đầu 50, Nhập 50, Xuất 100 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO001', 'SP014', 50, 0, 50, 100, 275000, 275000, 550000, '2025-06-30');

    -- SP015: Phở Gà (Tồn đầu 1000, Xuất hết 1000 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO004', 'SP015', 1000, 0, 0, 1000, 4700000, 0, 4700000, '2025-06-30');

    -- SP016: Mì Lẩu Thái (Nhập 500, Xuất 500 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO005', 'SP016', 0, 0, 500, 500, 0, 3000000, 3000000, '2025-06-30');

    -- SP017: Mì Chay (Tồn đầu 30, Nhập 20, Xuất 50 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO006', 'SP017', 30, 0, 20, 50, 135000, 90000, 225000, '2025-06-30');

    -- SP018: Hảo Hảo Tôm Nấm (Tồn đầu 1500, Xuất hết -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO001', 'SP018', 1500, 0, 0, 1500, 5700000, 0, 5700000, '2025-06-30');

    -- SP019: Mì Xào Bò (Nhập 100, Xuất 100 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO002', 'SP019', 0, 0, 100, 100, 0, 520000, 520000, '2025-06-30');

    -- SP020: Combo (Tồn đầu 10, Xuất 10 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO003', 'SP020', 10, 0, 0, 10, 170000, 0, 170000, '2025-06-30');

    COMMIT TRANSACTION;
    PRINT N'✓ Đã bổ sung dữ liệu tồn kho cho SP011-SP020';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT N'❌ Lỗi: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 21. DINH_MUC (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO DINH_MUC (MaNL, MaSP, SoLuongNL)
    VALUES
    ('NL001', 'SP001', 0.050),
    ('NL003', 'SP001', 0.008),
    ('NL004', 'SP001', 0.002),
    ('NL001', 'SP002', 0.048),
    ('NL003', 'SP002', 0.007),
    ('NL001', 'SP003', 0.052),
    ('NL014', 'SP004', 0.015),
    ('NL001', 'SP005', 0.055),
    ('NL015', 'SP011', 0.010),
    ('NL016', 'SP013', 0.003);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào DINH_MUC.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu DINH_MUC: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 22. CTKM (20 dòng) - Cập nhật năm 2025 và sửa lỗi định dạng ngày
BEGIN TRY
    BEGIN TRAN;
    SET DATEFORMAT YMD; 
    INSERT INTO CTKM (MaCTKM, TenCTKM, NgayBatDauKM, NgayKetThucKM, LyDoKM)
    VALUES
    ('KM001', N'Khuyến Mãi Tết Nguyên Đán 2025', '20250120', '20250215', N'Khuyến mãi dịp Tết'),
    ('KM002', N'Giảm Giá Mùa Hè', '20250601', '20250831', N'Kích cầu mùa hè'),
    ('KM003', N'Black Friday Sale', '20251125', '20251130', N'Khuyến mãi Black Friday'),
    ('KM004', N'Khuyến Mãi Khai Trương', '20250301', '20250315', N'Khai trương chi nhánh mới'),
    ('KM005', N'Mua 2 Tặng 1', '20250401', '20250430', N'Khuyến mãi mua nhiều'),
    ('KM006', N'Giảm 20% Sản Phẩm Mới', '20250501', '20250531', N'Ra mắt sản phẩm mới'),
    ('KM007', N'Back To School', '20250815', '20250915', N'Khuyến mãi mùa khai giảng'),
    ('KM008', N'Trung Thu Rực Rỡ', '20250901', '20250930', N'Khuyến mãi trung thu'),
    ('KM009', N'Ngày Độc Thân 11/11', '20251111', '20251111', N'Flash sale 11/11'),
    ('KM010', N'Giáng Sinh An Lành', '20251220', '20251226', N'Khuyến mãi Giáng sinh'),
    ('KM011', N'Tháng Tri Ân Khách Hàng', '20250701', '20250731', N'Tri ân khách hàng thân thiết'),
    ('KM012', N'Giảm Giá Cuối Tuần', '20251001', '20251031', N'Khuyến mãi cuối tuần'),
    ('KM013', N'Flash Sale Giờ Vàng', '20250115', '20250115', N'Flash sale 3 giờ'),
    ('KM014', N'Combo Gia Đình', '20250201', '20250228', N'Khuyến mãi combo tiết kiệm'), 
    ('KM015', N'Săn Deal Online', '20250320', '20250322', N'Khuyến mãi online'),
    ('KM016', N'Mùa Mưa Ấm Áp', '20251015', '20251115', N'Khuyến mãi mùa mưa'),
    ('KM017', N'Giảm Sốc Thanh Lý', '20251201', '20251215', N'Thanh lý hàng tồn kho'),
    ('KM018', N'Đón Năm Mới 2026', '20251228', '20260105', N'Khuyến mãi năm mới'),
    ('KM019', N'Siêu Sale Giữa Năm', '20250615', '20250620', N'Mega sale giữa năm'),
    ('KM020', N'Tuần Lễ Vàng', '20250920', '20250927', N'Tuần lễ khuyến mãi đặc biệt');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào CTKM (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu CTKM: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 23. CT_KM (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CT_KM (MaSP, MaCTKM, TyLePhanTram, GiamTheoSanPham, GhiChuCTKM)
    VALUES
    ('SP001', 'KM001', 15.00, NULL, N'Giảm 15%'),
    ('SP002', 'KM001', 10.00, NULL, N'Giảm 10%'),
    ('SP003', 'KM002', NULL, 500, N'Giảm 500đ/gói'),
    ('SP004', 'KM002', 20.00, NULL, N'Giảm 20%'),
    ('SP005', 'KM003', 30.00, NULL, N'Black Friday 30%'),
    ('SP006', 'KM004', NULL, 1000, N'Giảm 1000đ'),
    ('SP009', 'KM006', 20.00, NULL, N'Sản phẩm mới giảm 20%'),
    ('SP011', 'KM007', 15.00, NULL, N'Giảm 15%'),
    ('SP015', 'KM008', NULL, 700, N'Giảm 700đ'),
    ('SP020', 'KM014', 25.00, NULL, N'Combo giảm 25%');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CT_KM.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CT_KM: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 24. DONDATHANG (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu Bảng DONDATHANG (20 dòng) (Đã điều chỉnh TriGiaDH và Năm 2025)...';
    INSERT INTO DONDATHANG (MaDDH, MaKH, MaNV, NgayDatHang, NgayGiaoHang, NgayThanhToan, TienCoc, TriGiaDH, TrangThaiDH, PhuongThucThanhToan, SoLanGiaoHang, GhiChuDH) VALUES
('DDH001', 'KH001', 'NV006', '2025-01-10', '2025-01-15', '2025-01-15', 5000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH002', 'KH002', 'NV006', '2025-01-12', '2025-01-17', '2025-01-17', 3000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH003', 'KH003', 'NV006', '2025-01-15', '2025-01-18', '2025-01-18', 0, 0, N'Đã giao', N'Tiền mặt', 1, N'TT đủ'), 
('DDH004', 'KH004', 'NV006', '2025-01-20', '2025-01-22', '2025-01-22', 2000000, 0, N'Đã giao', N'Tiền mặt', 1, N'TT đủ'), 
('DDH005', 'KH005', 'NV006', '2025-02-01', '2025-02-05', '2025-02-05', 8000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH006', 'KH008', 'NV006', '2025-02-10', '2025-02-15', NULL, 15000000, 0, N'Đã giao', N'Chuyển khoản', 2, N'TT 1 phần, còn nợ'), 
('DDH007', 'KH009', 'NV006', '2025-02-15', '2025-02-20', '2025-02-20', 0, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH008', 'KH010', 'NV006', '2025-03-01', '2025-03-05', '2025-03-05', 3000000, 0, N'Đã giao', N'Tiền mặt', 1, N'TT đủ'), 
('DDH009', 'KH011', 'NV006', '2025-03-05', '2025-03-10', '2025-03-12', 10000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH010', 'KH013', 'NV006', '2025-03-15', '2025-03-20', NULL, 20000000, 0, N'Đã giao', N'Chuyển khoản', 2, N'TT 1 phần, còn nợ'),
('DDH011', 'KH014', 'NV006', '2025-04-01', '2025-04-05', '2025-04-05', 0, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'),
('DDH012', 'KH015', 'NV006', '2025-04-10', '2025-04-12', '2025-04-12', 1000000, 0, N'Đã giao', N'Tiền mặt', 1, N'TT đủ'),
('DDH013', 'KH017', 'NV006', '2025-04-20', '2025-04-25', '2025-04-25', 0, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'),
('DDH014', 'KH018', 'NV006', '2025-05-01', '2025-05-10', NULL, 30000000, 0, N'Đã giao', N'Chuyển khoản', 3, N'TT 1 phần, còn nợ'),
('DDH015', 'KH001', 'NV006', '2025-05-15', '2025-05-20', '2025-05-20', 10000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'),
('DDH016', 'KH020', 'NV006', '2025-06-01', '2025-06-05', NULL, 0, 0, N'Đang giao', N'Chuyển khoản', 1, N'Công nợ'), 
('DDH017', 'KH002', 'NV006', '2025-06-10', '2025-06-15', NULL, 5000000, 0, N'Đang giao', N'Chuyển khoản', 1, N'Công nợ'), 
('DDH018', 'KH005', 'NV006', '2025-06-15', '2025-06-20', NULL, 8000000, 0, N'Đang xử lý', N'Chuyển khoản', 0, N'Công nợ'), 
('DDH019', 'KH008', 'NV006', '2025-06-20', '2025-06-25', NULL, 15000000, 0, N'Đang xử lý', N'Chuyển khoản', 0, N'Công nợ'), 
('DDH020', 'KH003', 'NV006', '2025-06-22', '2025-06-24', NULL, 0, 0, N'Đã hủy', N'Tiền mặt', 0, N'Khách hủy'); 
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào DONDATHANG (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu DONDATHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 25. CT_DH (10 dòng)
BEGIN TRY
    BEGIN TRAN;
  INSERT INTO CT_DH (MaDDH, MaSP, SoLuongDDH, DonGiaDDH) VALUES
-- DDH001
('DDH001', 'SP001', 3000, 7000), 
('DDH001', 'SP002', 6000, 3500), 
-- DDH002
('DDH002', 'SP003', 4000, 4000), 
('DDH002', 'SP004', 3000, 4500), 
-- DDH003
('DDH003', 'SP005', 1000, 7500), 
-- DDH004
('DDH004', 'SP006', 2000, 5000), 
-- DDH005
('DDH005', 'SP001', 2500, 7000), 
('DDH005', 'SP009', 1500, 12000), 
-- DDH006
('DDH006', 'SP002', 10000, 3500), 
('DDH006', 'SP004', 8000, 4500),
-- DDH007
('DDH007', 'SP008', 2000, 9500),
('DDH007', 'SP010', 1500, 4200),
-- DDH008
('DDH008', 'SP011', 1000, 4800),
('DDH008', 'SP012', 1000, 8000),
-- DDH009
('DDH009', 'SP013', 5000, 6500),
('DDH009', 'SP014', 3000, 5500),
-- DDH010 (Đơn lớn)
('DDH010', 'SP009', 5000, 12000),
('DDH010', 'SP019', 8000, 5200),
-- DDH011
('DDH011', 'SP001', 2000, 7000),
('DDH011', 'SP015', 2000, 4700),
-- DDH012
('DDH012', 'SP002', 1000, 3500),
('DDH012', 'SP007', 500, 3800),
-- DDH013
('DDH013', 'SP016', 4000, 6000),
('DDH013', 'SP017', 3000, 4500),
-- DDH014 (Xuất khẩu)
('DDH014', 'SP009', 10000, 12000),
('DDH014', 'SP020', 2000, 17000),
-- DDH015
('DDH015', 'SP005', 4000, 7500),
('DDH015', 'SP003', 4000, 4000),
-- DDH016
('DDH016', 'SP008', 5000, 9500),
-- DDH017
('DDH017', 'SP004', 4000, 4500),
('DDH017', 'SP002', 4000, 3500),
-- DDH018
('DDH018', 'SP010', 6000, 4200),
('DDH018', 'SP014', 3000, 5500),
-- DDH019
('DDH019', 'SP005', 8000, 7500),
('DDH019', 'SP019', 4000, 5200),
-- DDH020
('DDH020', 'SP017', 2000, 4500);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào CT_DH.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CT_DH: ' + ERROR_MESSAGE();
END CATCH;
GO
-- CẬP NHẬT TỰ ĐỘNG GIÁ TRỊ ĐƠN HÀNG DỰA TRÊN CHI TIẾT
UPDATE DONDATHANG
SET TriGiaDH = (
    SELECT ISNULL(SUM(SoLuongDDH * DonGiaDDH), 0)
    FROM CT_DH
    WHERE CT_DH.MaDDH = DONDATHANG.MaDDH
);
GO

PRINT N'✓ Đã cập nhật xong dữ liệu 20 đơn hàng và tính tổng tiền chính xác.';
GO

-- 26. HOADONBAN (19 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO HOADONBAN (SoHDB, MaDDH, NgayLapHDB, TiencocHDB, TriGiaTruocthueHDB, TriGiaSauthueHDB, 
                           GiamGiaHDB, TriGiaSauGiam)
    VALUES
    ('HDB001', 'DDH001', '2025-01-15', 5000000, 42000000, 46200000, 2000000, 44200000), 
    ('HDB002', 'DDH002', '2025-01-17', 3000000, 25000000, 27500000, 500000, 27000000), 
    ('HDB003', 'DDH003', '2025-01-18', 0, 7500000, 8250000, 0, 8250000), 
    ('HDB004', 'DDH004', '2025-01-22', 2000000, 10000000, 11000000, 500000, 10500000), 
    ('HDB005', 'DDH005', '2025-02-05', 8000000, 35500000, 39050000, 2000000, 37050000), 
    ('HDB006', 'DDH006', '2025-02-18', 15000000, 71000000, 78100000, 3000000, 75100000), 
    ('HDB007', 'DDH007', '2025-02-20', 0, 27500000, 30250000, 1000000, 29250000), 
    ('HDB008', 'DDH008', '2025-03-05', 3000000, 14500000, 15950000, 500000, 15450000), 
    ('HDB009', 'DDH009', '2025-03-12', 10000000, 48000000, 52800000, 2500000, 50300000), 
    ('HDB010', 'DDH010', '2025-03-25', 20000000, 97000000, 106700000, 5000000, 101700000), 
    ('HDB011', 'DDH011', '2025-04-05', 0, 22000000, 24200000, 800000, 23400000),
    ('HDB012', 'DDH012', '2025-04-12', 1000000, 6000000, 6600000, 0, 5600000), 
    ('HDB013', 'DDH013', '2025-04-25', 0, 35000000, 38500000, 1500000, 37000000),
    ('HDB014', 'DDH014', '2025-05-15', 30000000, 150000000, 165000000, 7000000, 158000000),
    ('HDB015', 'DDH015', '2025-05-20', 10000000, 55000000, 60500000, 2500000, 58000000),
    ('HDB016', 'DDH016', '2025-06-05', 0, 45000000, 49500000, 2000000, 47500000),
    ('HDB017', 'DDH017', '2025-06-15', 5000000, 32000000, 35200000, 1200000, 34000000),
    ('HDB018', 'DDH018', '2025-06-20', 8000000, 42000000, 46200000, 2000000, 44200000),
    ('HDB019', 'DDH019', '2025-06-25', 15000000, 78000000, 85800000, 3500000, 82300000);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào HOADONBAN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu HOADONBAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 29. PHIEUTHANHTOAN (19 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO PHIEUTHANHTOAN (SoPTT, SoHDB, MaNV, NgayTT, SoTienTT, HinhThucTT, TrangThaiTT)
    VALUES
    ('PTT001', 'HDB001', 'NV013', '2025-01-15', 44200000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT002', 'HDB002', 'NV013', '2025-01-17', 27000000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT003', 'HDB003', 'NV013', '2025-01-18', 8250000, N'Tiền mặt', N'Đã thanh toán'), 
    ('PTT004', 'HDB004', 'NV013', '2025-01-22', 10500000, N'Tiền mặt', N'Đã thanh toán'), 
    ('PTT005', 'HDB005', 'NV013', '2025-02-05', 37050000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT006', 'HDB006', 'NV013', '2025-02-18', 15000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT007', 'HDB007', 'NV013', '2025-02-20', 29250000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT008', 'HDB008', 'NV013', '2025-03-05', 15450000, N'Tiền mặt', N'Đã thanh toán'), 
    ('PTT009', 'HDB009', 'NV013', '2025-03-12', 50300000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT010', 'HDB010', 'NV013', '2025-03-25', 20000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT011', 'HDB011', 'NV013', '2025-04-05', 23400000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT012', 'HDB012', 'NV013', '2025-04-12', 5600000, N'Tiền mặt', N'Đã thanh toán'), 
    ('PTT013', 'HDB013', 'NV013', '2025-04-25', 37000000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT014', 'HDB014', 'NV013', '2025-05-15', 30000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT015', 'HDB015', 'NV013', '2025-05-20', 58000000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT016', 'HDB016', 'NV013', '2025-06-05', 0, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT017', 'HDB017', 'NV013', '2025-06-15', 5000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT018', 'HDB018', 'NV013', '2025-06-20', 8000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT019', 'HDB019', 'NV013', '2025-06-25', 15000000, N'Chuyển khoản', N'Chưa thanh toán'); 
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào PHIEUTHANHTOAN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu PHIEUTHANHTOAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 32. PHIEUXUAT (19 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO PHIEUXUAT (SoPX, NgayXuat, TrangThaiPX, TriGiaPX, LyDoXuat)
    VALUES
    ('PX001', '2025-01-15', N'Đã xuất', 44200000, N'Xuất hàng cho HDB001'),
    ('PX002', '2025-01-17', N'Đã xuất', 27000000, N'Xuất hàng cho HDB002'),
    ('PX003', '2025-01-18', N'Đã xuất', 8250000, N'Xuất hàng cho HDB003'),
    ('PX004', '2025-01-22', N'Đã xuất', 10500000, N'Xuất hàng cho HDB004'),
    ('PX005', '2025-02-05', N'Đã xuất', 37050000, N'Xuất hàng cho HDB005'),
    ('PX006', '2025-02-18', N'Đã xuất', 75100000, N'Xuất hàng cho HDB006'),
    ('PX007', '2025-02-20', N'Đã xuất', 29250000, N'Xuất hàng cho HDB007'),
    ('PX008', '2025-03-05', N'Đã xuất', 15450000, N'Xuất hàng cho HDB008'),
    ('PX009', '2025-03-12', N'Đã xuất', 50300000, N'Xuất hàng cho HDB009'),
    ('PX010', '2025-03-25', N'Đã xuất', 101700000, N'Xuất hàng cho HDB010'),
    ('PX011', '2025-04-05', N'Đã xuất', 23400000, N'Xuất hàng cho HDB011'),
    ('PX012', '2025-04-12', N'Đã xuất', 5600000, N'Xuất hàng cho HDB012'),
    ('PX013', '2025-04-25', N'Đã xuất', 37000000, N'Xuất hàng cho HDB013'),
    ('PX014', '2025-05-15', N'Đã xuất', 158000000, N'Xuất hàng xuất khẩu'),
    ('PX015', '2025-05-20', N'Đã xuất', 58000000, N'Xuất hàng cho HDB015'),
    ('PX016', '2025-06-05', N'Đã xuất', 47500000, N'Xuất hàng cho HDB016'),
    ('PX017', '2025-06-15', N'Đang xuất', 34000000, N'Xuất hàng cho HDB017'),
    ('PX018', '2025-06-20', N'Chưa xuất', 44200000, N'Xuất hàng cho HDB018'),
    ('PX019', '2025-06-25', N'Chưa xuất', 82300000, N'Xuất hàng cho HDB019');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào PHIEUXUAT.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu PHIEUXUAT: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 33. CT_PX (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CT_PX (SoPX, MaKho, SLXuat, DGXuat, ThanhTienXuat)
    VALUES
    ('PX001', 'KHO001', 3000, 7000.00, 21000000.00), 
    ('PX001', 'KHO002', 6000, 3500.00, 21000000.00),  
    ('PX002', 'KHO002', 4000, 4000.00, 16000000.00),
    ('PX002', 'KHO003', 3000, 3000.00, 9000000.00),  
    ('PX003', 'KHO001', 1000, 7500.00, 7500000.00),
    ('PX004', 'KHO001', 2000, 5000.00, 10000000.00),
    ('PX005', 'KHO005', 2500, 7000.00, 17500000.00),
    ('PX005', 'KHO006', 1500, 12000.00, 18000000.00), 
    ('PX006', 'KHO001', 10000, 3500.00, 35000000.00),
    ('PX006', 'KHO002', 8000, 4500.00, 36000000.00);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CT_PX.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CT_PX: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 34. LENHBANHANG (19 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO LENHBANHANG (MaLBH, SoPX, MaNV, NgayLap, GhiChuLBH)
    VALUES
    ('LBH001', 'PX001', 'NV006', '2025-01-15', N'Lệnh bán hàng Co.opmart'),
    ('LBH002', 'PX002', 'NV006', '2025-01-17', N'Lệnh bán hàng BigC'),
    ('LBH003', 'PX003', 'NV006', '2025-01-18', N'Lệnh bán hàng tạp hóa'),
    ('LBH004', 'PX004', 'NV006', '2025-01-22', N'Lệnh bán hàng nhà hàng'),
    ('LBH005', 'PX005', 'NV006', '2025-02-05', N'Lệnh bán hàng khách sạn'),
    ('LBH006', 'PX006', 'NV006', '2025-02-18', N'Lệnh bán hàng đại lý'),
    ('LBH007', 'PX007', 'NV006', '2025-02-20', N'Lệnh bán hàng Lotte Mart'),
    ('LBH008', 'PX008', 'NV006', '2025-03-05', N'Lệnh bán hàng Circle K'),
    ('LBH009', 'PX009', 'NV006', '2025-03-12', N'Lệnh bán hàng công ty'),
    ('LBH010', 'PX010', 'NV006', '2025-03-25', N'Lệnh bán hàng nhà phân phối'),
    ('LBH011', 'PX011', 'NV006', '2025-04-05', N'Lệnh bán hàng Family Mart'),
    ('LBH012', 'PX012', 'NV006', '2025-04-12', N'Lệnh bán hàng quán ăn'),
    ('LBH013', 'PX013', 'NV006', '2025-04-25', N'Lệnh bán hàng Mega Market'),
    ('LBH014', 'PX014', 'NV006', '2025-05-15', N'Lệnh bán hàng xuất khẩu'),
    ('LBH015', 'PX015', 'NV006', '2025-05-20', N'Lệnh bán hàng Co.opmart'),
    ('LBH016', 'PX016', 'NV006', '2025-06-05', N'Lệnh bán hàng Vinmart'),
    ('LBH017', 'PX017', 'NV006', '2025-06-15', N'Lệnh bán hàng BigC'),
    ('LBH018', 'PX018', 'NV006', '2025-06-20', N'Lệnh bán hàng khách sạn'),
    ('LBH019', 'PX019', 'NV006', '2025-06-25', N'Lệnh bán hàng đại lý');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào LENHBANHANG.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu LENHBANHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 35. LOAIQUYEN (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO LOAIQUYEN (MaLQ, TenLQ, MoTaLQ)
    VALUES
    ('LQ001', N'Quyền Hệ Thống', N'Quyền quản lý hệ thống'),
    ('LQ002', N'Quyền Kế Toán', N'Quyền xử lý kế toán'),
    ('LQ003', N'Quyền Bán Hàng', N'Quyền bán hàng'),
    ('LQ004', N'Quyền Kho', N'Quyền quản lý kho'),
    ('LQ005', N'Quyền Báo Cáo', N'Quyền xem báo cáo'),
    ('LQ006', N'Quyền Quản Trị', N'Quyền quản trị toàn hệ thống'),
    ('LQ007', N'Quyền Nhân Sự', N'Quyền quản lý nhân sự'),
    ('LQ008', N'Quyền Tài Chính', N'Quyền tài chính'),
    ('LQ009', N'Quyền Marketing', N'Quyền tiếp thị'),
    ('LQ010', N'Quyền Sản Xuất', N'Quyền quản lý sản xuất'),
    ('LQ011', N'Quyền Duyệt', N'Quyền phê duyệt'),
    ('LQ012', N'Quyền Xem', N'Quyền xem thông tin'),
    ('LQ013', N'Quyền Chỉnh Sửa', N'Quyền chỉnh sửa dữ liệu'),
    ('LQ014', N'Quyền Xóa', N'Quyền xóa dữ liệu'),
    ('LQ015', N'Quyền Tạo Mới', N'Quyền tạo mới dữ liệu'),
    ('LQ016', N'Quyền Xuất File', N'Quyền xuất file báo cáo'),
    ('LQ017', N'Quyền Import', N'Quyền nhập liệu hàng loạt'),
    ('LQ018', N'Quyền Backup', N'Quyền sao lưu dữ liệu'),
    ('LQ019', N'Quyền Restore', N'Quyền phục hồi dữ liệu'),
    ('LQ020', N'Quyền Cấu Hình', N'Quyền cấu hình hệ thống');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào LOAIQUYEN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu LOAIQUYEN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 36. TAIKHOANCAP1 (50 dòng)
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang thêm TAIKHOANCAP1...';
    
    INSERT INTO TAIKHOANCAP1 (SoTKC1, TenTKC1, GhiChuTKC1)
    VALUES
    ('111', N'Tiền mặt', N'Tiền mặt tại quỹ'), ('112', N'Tiền gửi ngân hàng', N'Tiền gửi NH'), ('113', N'Tiền đang chuyển', N'Tiền đang chuyển'),
    ('121', N'Chứng khoán kinh doanh', N'CK kinh doanh'), ('128', N'Đầu tư nắm giữ đến ngày đáo hạn', N'Đầu tư dài hạn'),
    ('131', N'Phải thu của khách hàng', N'Công nợ phải thu'), ('133', N'Thuế GTGT được khấu trừ', N'Thuế đầu vào'),
    ('136', N'Phải thu nội bộ', N'Phải thu NB'), ('138', N'Phải thu khác', N'Phải thu khác'),
    ('141', N'Tạm ứng', N'Tạm ứng'),
    ('151', N'Hàng mua đang đi đường', N'Hàng đang về'), ('152', N'Nguyên liệu, vật liệu', N'NVL'),
    ('153', N'Công cụ, dụng cụ', N'CCDC'), ('154', N'Chi phí sản xuất, kinh doanh dở dang', N'CP DDDK'),
    ('155', N'Thành phẩm', N'Thành phẩm'), ('156', N'Hàng hóa', N'Hàng hóa'),
    ('157', N'Hàng gửi đi bán', N'Hàng gửi bán'), ('158', N'Hàng hoá kho bảo thuế', N'Hàng bảo thuế'),
    ('211', N'Tài sản cố định hữu hình', N'TSCĐ HH'), ('212', N'Tài sản cố định thuê tài chính', N'TSCĐ thuê TC'),
    ('213', N'Tài sản cố định vô hình', N'TSCĐ VH'), ('214', N'Hao mòn tài sản cố định', N'Hao mòn TSCĐ'),
    ('217', N'Bất động sản đầu tư', N'BĐS đầu tư'),
    ('221', N'Đầu tư vào công ty con', N'Đầu tư CTy con'), ('222', N'Đầu tư vào công ty liên doanh, liên kết', N'Đầu tư LĐLK'),
    ('228', N'Đầu tư khác', N'Đầu tư khác'),
    ('241', N'Xây dựng cơ bản dở dang', N'XDCB DDDK'), ('242', N'Chi phí trả trước', N'CP trả trước'),
    ('331', N'Phải trả cho người bán', N'Công nợ NCC'), ('333', N'Thuế và các khoản phải nộp Nhà nước', N'Thuế phải nộp'),
    ('334', N'Phải trả người lao động', N'Lương phải trả'), ('335', N'Chi phí phải trả', N'CP phải trả'),
    ('336', N'Phải trả nội bộ', N'Phải trả NB'), ('338', N'Phải trả, phải nộp khác', N'Phải trả khác'),
    ('341', N'Vay và nợ thuê tài chính', N'Vay dài hạn'), ('343', N'Trái phiếu phát hành', N'Trái phiếu'),
    ('411', N'Vốn đầu tư của chủ sở hữu', N'Vốn CSH'), ('421', N'Lợi nhuận sau thuế chưa phân phối', N'LNST CPP'),
    ('511', N'Doanh thu bán hàng và cung cấp dịch vụ', N'Doanh thu'), ('521', N'Các khoản giảm trừ doanh thu', N'Giảm trừ DT'),
    ('611', N'Mua hàng', N'Mua hàng'), ('621', N'Chi phí nguyên vật liệu trực tiếp', N'CP NVL trực tiếp'),
    ('622', N'Chi phí nhân công trực tiếp', N'CP nhân công trực tiếp'), ('627', N'Chi phí sản xuất chung', N'CPSXC'),
    ('632', N'Giá vốn hàng bán', N'GVHB'),
    ('641', N'Chi phí bán hàng', N'CP bán hàng'), ('642', N'Chi phí quản lý doanh nghiệp', N'CP QLDN'),
    ('711', N'Thu nhập khác', N'Thu nhập khác'), ('811', N'Chi phí khác', N'CP khác'),
    ('911', N'Xác định kết quả kinh doanh', N'Xác định KQKD');
    
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 50 dòng vào TAIKHOANCAP1.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TAIKHOANCAP1: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 37. TAIKHOANCAP2 (70 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang thêm TAIKHOANCAP2 ';
    
    INSERT INTO TAIKHOANCAP2 (SoTKC2, SoTKC1, TenTKC2, GhiChuTKC2)
    VALUES
    -- TK 111: Tiền mặt
    ('1111', '111', N'Tiền Việt Nam', N'Tiền VNĐ'), ('1112', '111', N'Ngoại tệ', N'Tiền ngoại tệ'), ('1113', '111', N'Vàng tiền tệ', N'Vàng'),
    -- TK 112: Tiền gửi ngân hàng
    ('1121', '112', N'Tiền Việt Nam gửi ngân hàng', N'Tiền gửi VNĐ'), ('1122', '112', N'Ngoại tệ gửi ngân hàng', N'Tiền gửi ngoại tệ'),
    ('1123', '112', N'Vàng tiền tệ gửi ngân hàng', N'Vàng gửi NH'),
    -- TK 113: Tiền đang chuyển
    ('1131', '113', N'Tiền Việt Nam đang chuyển', N'Tiền chuyển VNĐ'), ('1132', '113', N'Ngoại tệ đang chuyển', N'Tiền chuyển ngoại tệ'),
    -- TK 121: Chứng khoán kinh doanh
    ('1211', '121', N'Cổ phiếu', N'Cổ phiếu KD'), ('1212', '121', N'Trái phiếu', N'Trái phiếu KD'),
    ('1218', '121', N'Chứng khoán và công cụ tài chính khác', N'CK khác'),
    -- TK 128: Đầu tư nắm giữ đến ngày đáo hạn
    ('1281', '128', N'Tiền gửi có kỳ hạn', N'Tiền gửi KH'), ('1282', '128', N'Trái phiếu', N'Trái phiếu đầu tư'),
    ('1283', '128', N'Cho vay', N'Cho vay DH'), ('1288', '128', N'Đầu tư khác nắm giữ đến ngày đáo hạn', N'Đầu tư khác'),
    -- TK 131: Phải thu khách hàng
    ('1311', '131', N'Phải thu khách hàng', N'Phải thu KH'),
    -- TK 133: Thuế GTGT được khấu trừ
    ('1331', '133', N'Thuế GTGT được khấu trừ của hàng hóa, dịch vụ', N'Thuế GTGT HH'),
    ('1332', '133', N'Thuế GTGT được khấu trừ của TSCĐ', N'Thuế GTGT TSCĐ'),
    -- TK 136: Phải thu nội bộ
    ('1361', '136', N'Vốn kinh doanh ở các đơn vị trực thuộc', N'Vốn ĐVTT'), ('1362', '136', N'Phải thu nội bộ về chênh lệch tỷ giá', N'PT NB tỷ giá'),
    ('1363', '136', N'Phải thu nội bộ về chi phí vay vốn hóa', N'PT NB vay'), ('1368', '136', N'Phải thu nội bộ khác', N'PT NB khác'),
    -- TK 138: Phải thu khác
    ('1381', '138', N'Tài sản thiếu chờ xử lý', N'TS thiếu'), ('1385', '138', N'Phải thu về cổ phần hoá', N'PT CPH'),
    ('1388', '138', N'Phải thu khác', N'PT khác'),
    -- TK 141: Tạm ứng
    ('1411', '141', N'Tạm ứng', N'Tạm ứng'),
    -- TK 151: Hàng mua đang đi đường
    ('1511', '151', N'Hàng mua đang đi đường', N'Hàng đi đường'),
    -- TK 152: Nguyên liệu, vật liệu
    ('1521', '152', N'Nguyên liệu, vật liệu', N'NVL'),
    -- TK 153: Công cụ, dụng cụ
    ('1531', '153', N'Công cụ, dụng cụ', N'CCDC'), ('1532', '153', N'Bao bì luân chuyển', N'Bao bì'),
    ('1533', '153', N'Đồ dùng cho thuê', N'Đồ cho thuê'), ('1534', '153', N'Thiết bị, phụ tùng thay thế', N'TB phụ tùng'),
    -- TK 154: Chi phí SXKD dở dang
    ('1541', '154', N'Chi phí sản xuất, kinh doanh dở dang', N'CP DDDK'),
    -- TK 155: Thành phẩm
    ('1551', '155', N'Thành phẩm nhập kho', N'TP nhập kho'), ('1557', '155', N'Thành phẩm bất động sản', N'TP BĐS'),
    -- TK 156: Hàng hóa
    ('1561', '156', N'Giá mua hàng hóa', N'Giá mua HH'), ('1562', '156', N'Chi phí thu mua hàng hóa', N'CP thu mua'),
    ('1567', '156', N'Hàng hóa bất động sản', N'HH BĐS'),
    -- TK 157: Hàng gửi đi bán
    ('1571', '157', N'Hàng gửi đi bán', N'Hàng gửi'),
    -- TK 158: Hàng hóa kho bảo thuế
    ('1581', '158', N'Hàng hoá kho bảo thuế', N'Kho bảo thuế'),
    -- TK 211: TSCĐ hữu hình
    ('2111', '211', N'Nhà cửa, vật kiến trúc', N'Nhà cửa'), ('2112', '211', N'Máy móc, thiết bị', N'Máy móc'),
    ('2113', '211', N'Phương tiện vận tải, truyền dẫn', N'PTVT'), ('2114', '211', N'Thiết bị, dụng cụ quản lý', N'TB quản lý'),
    ('2115', '211', N'Cây lâu năm, súc vật làm việc', N'Cây lâu năm'), ('2118', '211', N'TSCĐ khác', N'TSCĐ khác'),
    -- TK 212: TSCĐ thuê tài chính
    ('2121', '212', N'TSCĐ hữu hình thuê tài chính', N'TSCĐ HH thuê TC'), ('2122', '212', N'TSCĐ vô hình thuê tài chính', N'TSCĐ VH thuê TC'),
    -- TK 213: TSCĐ vô hình
    ('2131', '213', N'Quyền sử dụng đất', N'QSD đất'), ('2132', '213', N'Quyền phát hành', N'Quyền phát hành'),
    ('2133', '213', N'Bản quyền, bằng sáng chế', N'Bản quyền'), ('2134', '213', N'Nhãn hiệu, tên thương mại', N'Nhãn hiệu'),
    ('2135', '213', N'Chương trình phần mềm', N'Phần mềm'), ('2136', '213', N'Giấy phép và giấy phép nhượng quyền', N'Giấy phép'),
    ('2138', '213', N'TSCĐ vô hình khác', N'TSCĐ VH khác'),
    -- TK 214: Hao mòn TSCĐ
    ('2141', '214', N'Hao mòn TSCĐ hữu hình', N'HM TSCĐ HH'), ('2142', '214', N'Hao mòn TSCĐ thuê tài chính', N'HM TSCĐ thuê TC'),
    ('2143', '214', N'Hao mòn TSCĐ vô hình', N'HM TSCĐ VH'), ('2147', '214', N'Hao mòn bất động sản đầu tư', N'HM BĐS ĐT'),
    -- TK 217: Bất động sản đầu tư
    ('2171', '217', N'Bất động sản đầu tư', N'BĐS đầu tư'),
    -- TK 221: Đầu tư vào công ty con
    ('2211', '221', N'Đầu tư vào công ty con', N'ĐT CTy con'),
    -- TK 222: Đầu tư liên doanh, liên kết
    ('2221', '222', N'Đầu tư vào công ty liên doanh, liên kết', N'ĐT LĐLK'),
    -- TK 228: Đầu tư khác
    ('2281', '228', N'Đầu tư góp vốn', N'ĐT góp vốn'), ('2288', '228', N'Đầu tư khác', N'ĐT khác'),
    -- TK 241: XDCB dở dang
    ('2411', '241', N'Mua sắm TSCĐ', N'Mua sắm TSCĐ'), ('2412', '241', N'Xây dựng cơ bản', N'XD cơ bản'),
    ('2413', '241', N'Sửa chữa lớn TSCĐ', N'SCL TSCĐ'),
    -- TK 242: Chi phí trả trước
    ('2421', '242', N'Chi phí trả trước ngắn hạn', N'CP trả trước NH'),
    -- TK 331: Phải trả người bán
    ('3311', '331', N'Phải trả cho người bán', N'PT người bán'),
    -- TK 333: Thuế phải nộp
    ('3331', '333', N'Thuế GTGT phải nộp', N'Thuế GTGT'),
    -- TK 334: Phải trả người lao động
    ('3341', '334', N'Phải trả người lao động', N'Lương phải trả'),
    -- TK 338: Phải trả khác
    ('3381', '338', N'Phải trả, phải nộp khác', N'Phải trả khác'),
    -- TK 411: Vốn chủ sở hữu
    ('4111', '411', N'Vốn đầu tư của chủ sở hữu', N'Vốn CSH'),
    -- TK 421: Lợi nhuận
    ('4211', '421', N'Lợi nhuận sau thuế chưa phân phối', N'LNST CPP'),
    -- TK 511: Doanh thu
    ('5111', '511', N'Doanh thu bán hàng hóa', N'DT bán HH'),
    -- TK 521: Giảm trừ doanh thu
    ('5211', '521', N'Hàng bán bị trả lại', N'Hàng trả lại'),
    -- TK 611: Mua hàng
    ('6111', '611', N'Mua hàng hóa', N'Mua HH'),
    -- TK 632: Giá vốn hàng bán
    ('6321', '632', N'Giá vốn hàng bán', N'GVHB'),
    -- TK 641: Chi phí bán hàng
    ('6411', '641', N'Chi phí nhân viên bán hàng', N'CP nhân viên BH'),
    ('6412', '641', N'Chi phí NVL, bao bì', N'CP NVL, bao bì');
    
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 70 dòng vào TAIKHOANCAP2.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TAIKHOANCAP2: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 38. TAIKHOANCAP3 (85 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang thêm TAIKHOANCAP3';
    
    INSERT INTO TAIKHOANCAP3 (SoTKC3, SoTKC2, TenTKC3, GhiChuTKC3)
    VALUES
    -- Con của 1111: Tiền Việt Nam
    ('1111M', '1111', N'Tiền mặt Việt Nam', N'Tiền VNĐ tại quỹ'),
    -- Con của 1112: Ngoại tệ
    ('1112N', '1112', N'Ngoại tệ USD', N'Tiền USD tại quỹ'),
    -- Con của 1113: Vàng
    ('1113V', '1113', N'Vàng tiền tệ SJC', N'Vàng SJC'),
    -- Con của 1121: Tiền gửi VNĐ
    ('1121H', '1121', N'Tiền Việt Nam gửi Vietcombank', N'VCB VNĐ'),
    -- Con của 1122: Tiền gửi ngoại tệ
    ('1122H', '1122', N'Ngoại tệ gửi BIDV', N'BIDV USD'),
    -- Con của 1123: Vàng gửi NH
    ('1123H', '1123', N'Vàng gửi ngân hàng', N'Vàng gửi NH'),
    -- Con của 1131: Tiền chuyển VNĐ
    ('1131C', '1131', N'Tiền Việt Nam đang chuyển', N'Tiền chuyển VNĐ'),
    -- Con của 1132: Tiền chuyển ngoại tệ
    ('1132C', '1132', N'USD đang chuyển', N'USD chuyển'),
    -- Con của 1211: Cổ phiếu
    ('1211C', '1211', N'Cổ phiếu VNM', N'CP VNM'),
    -- Con của 1212: Trái phiếu KD
    ('1212T', '1212', N'Trái phiếu Chính phủ', N'TP Chính phủ'),
    -- Con của 1218: CK khác
    ('1218K', '1218', N'Chứng chỉ quỹ', N'CCQ'),
    -- Con của 1281: Tiền gửi KH
    ('1281T', '1281', N'Tiền gửi có kỳ hạn 12 tháng', N'Gửi KH 12T'),
    -- Con của 1282: Trái phiếu đầu tư
    ('1282T', '1282', N'Trái phiếu doanh nghiệp', N'TP DN'),
    -- Con của 1283: Cho vay
    ('1283V', '1283', N'Cho vay dài hạn', N'Cho vay DH'),
    -- Con của 1288: Đầu tư khác
    ('1288D', '1288', N'Đầu tư khác', N'ĐT khác'),
    -- Con của 1311: Phải thu KH
    ('1311K', '1311', N'Phải thu khách hàng trong nước', N'PT KH trong nước'),
    -- Con của 1331: Thuế GTGT HH
    ('1331T', '1331', N'Thuế GTGT được khấu trừ của hàng hóa', N'Thuế GTGT HH'),
    -- Con của 1332: Thuế GTGT TSCĐ
    ('1332T', '1332', N'Thuế GTGT được khấu trừ của TSCĐ', N'Thuế GTGT TSCĐ'),
    -- Con của 1361: Vốn ĐVTT
    ('1361V', '1361', N'Vốn kinh doanh chi nhánh', N'Vốn CN'),
    -- Con của 1362: PT NB tỷ giá
    ('1362C', '1362', N'Phải thu nội bộ chênh lệch tỷ giá', N'PT NB tỷ giá'),
    -- Con của 1363: PT NB vay
    ('1363P', '1363', N'Phải thu nội bộ chi phí vay vốn hóa', N'PT NB vay VH'),
    -- Con của 1368: PT NB khác
    ('1368K', '1368', N'Phải thu nội bộ khác', N'PT NB khác'),
    -- Con của 1381: TS thiếu
    ('1381H', '1381', N'Hàng hóa thiếu chờ xử lý', N'HH thiếu'),
    -- Con của 1385: PT CPH
    ('1385C', '1385', N'Phải thu về cổ phần hoá', N'PT CPH'),
    -- Con của 1388: PT khác
    ('1388K', '1388', N'Phải thu khác', N'PT khác'),
    -- Con của 1411: Tạm ứng
    ('1411T', '1411', N'Tạm ứng nhân viên', N'Tạm ứng NV'),
    -- Con của 1511: Hàng đi đường
    ('1511H', '1511', N'Hàng nhập khẩu đang về', N'Hàng NK'),
    -- Con của 1521: NVL
    ('1521N', '1521', N'NVL', N'NVL'),
    -- Con của 1531: CCDC
    ('1531C', '1531', N'Công cụ sản xuất', N'CC SX'),
    -- Con của 1532: Bao bì
    ('1532B', '1532', N'Bao bì carton', N'Bao bì'),
    -- Con của 1533: Đồ cho thuê
    ('1533D', '1533', N'Máy móc cho thuê', N'MM cho thuê'),
    -- Con của 1534: TB phụ tùng
    ('1534T', '1534', N'Phụ tùng máy móc', N'Phụ tùng MM'),
    -- Con của 1541: CP DDDK
    ('1541D', '1541', N'Chi phí sản xuất dở dang', N'CP SX DDDK'),
    -- Con của 1551: TP nhập kho
    ('1551T', '1551', N'Thành phẩm', N'TP '),
    -- Con của 1557: TP BĐS
    ('1557B', '1557', N'Căn hộ chưa bán', N'Căn hộ'),
    -- Con của 1561: Giá mua HH
    ('1561G', '1561', N'Giá mua hàng hóa mì', N'Giá mua mì'),
    -- Con của 1562: CP thu mua
    ('1562C', '1562', N'Chi phí vận chuyển', N'CP vận chuyển'),
    -- Con của 1567: HH BĐS
    ('1567B', '1567', N'Đất nền', N'Đất nền'),
    -- Con của 1571: Hàng gửi
    ('1571G', '1571', N'Hàng gửi đại lý', N'Hàng gửi ĐL'),
    -- Con của 1581: Kho bảo thuế
    ('1581K', '1581', N'Hàng NK chưa nộp thuế', N'Hàng kho BT'),
    -- Con của 2111: Nhà cửa
    ('2111N', '2111', N'Nhà xưởng sản xuất', N'Nhà xưởng'),
    -- Con của 2112: Máy móc
    ('2112M', '2112', N'Máy sản xuất mì', N'Máy SX mì'),
    -- Con của 2113: PTVT
    ('2113P', '2113', N'Xe tải', N'Xe tải'),
    -- Con của 2114: TB quản lý
    ('2114T', '2114', N'Máy tính văn phòng', N'Máy tính VP'),
    -- Con của 2115: Cây lâu năm
    ('2115C', '2115', N'Cây cao su', N'Cây cao su'),
    -- Con của 2118: TSCĐ khác
    ('2118K', '2118', N'TSCĐ khác', N'TSCĐ khác'),
    -- Con của 2121: TSCĐ HH thuê TC
    ('2121H', '2121', N'Máy móc thuê tài chính', N'MM thuê TC'),
    -- Con của 2122: TSCĐ VH thuê TC
    ('2122V', '2122', N'Phần mềm thuê tài chính', N'PM thuê TC'),
    -- Con của 2131: QSD đất
    ('2131D', '2131', N'Quyền sử dụng đất lâu dài', N'QSD đất LD'),
    -- Con của 2132: Quyền phát hành
    ('2132Q', '2132', N'Quyền phát hành sách', N'Quyền PH sách'),
    -- Con của 2133: Bản quyền
    ('2133B', '2133', N'Bằng sáng chế', N'Bằng SC'),
    -- Con của 2134: Nhãn hiệu
    ('2134N', '2134', N'Nhãn hiệu Hảo Hảo', N'NH Hảo Hảo'),
    -- Con của 2135: Phần mềm
    ('2135P', '2135', N'TSCDVH', N'TSCDVH'),
    -- Con của 2136: Giấy phép
    ('2136G', '2136', N'Giấy phép kinh doanh', N'GP KD'),
    -- Con của 2138: TSCĐ VH khác
    ('2138K', '2138', N'TSCĐ vô hình khác', N'TSCĐ VH khác'),
    -- Con của 2141: HM TSCĐ HH
    ('2141H', '2141', N'Hao mòn nhà xưởng', N'HM nhà xưởng'),
    -- Con của 2142: HM TSCĐ thuê TC
    ('2142T', '2142', N'Hao mòn máy thuê TC', N'HM máy thuê TC'),
    -- Con của 2143: HM TSCĐ VH
    ('2143V', '2143', N'Hao mòn phần mềm', N'HM phần mềm'),
    -- Con của 2147: HM BĐS ĐT
    ('2147B', '2147', N'Hao mòn nhà cho thuê', N'HM nhà thuê'),
    -- Con của 2171: BĐS đầu tư
    ('2171B', '2171', N'Nhà cho thuê', N'Nhà cho thuê'),
    -- Con của 2211: ĐT CTy con
    ('2211C', '2211', N'Đầu tư vào công ty con A', N'ĐT CTy con A'),
    -- Con của 2221: ĐT LĐLK
    ('2221L', '2221', N'Đầu tư liên doanh', N'ĐT LĐ'),
    -- Con của 2281: ĐT góp vốn
    ('2281G', '2281', N'Đầu tư góp vốn', N'ĐT góp vốn'),
    -- Con của 2288: ĐT khác
    ('2288K', '2288', N'Đầu tư khác', N'ĐT khác'),
    -- Con của 2411: Mua sắm TSCĐ
    ('2411M', '2411', N'Mua sắm máy móc', N'Mua sắm MM'),
    -- Con của 2412: XD cơ bản
    ('2412X', '2412', N'Xây dựng nhà xưởng', N'XD nhà xưởng'),
    -- Con của 2413: SCL TSCĐ
    ('2413S', '2413', N'Sửa chữa lớn TSCĐ', N'SCL TSCĐ'),
    -- Con của 2421: CP trả trước NH
    ('2421C', '2421', N'Chi phí trả trước ngắn hạn', N'CP trả trước NH'),
    -- Con của 3311: PT người bán
    ('3311P', '3311', N'Phải trả nhà cung cấp', N'PT NCC'),
    -- Con của 3331: Thuế GTGT
    ('33311', '3331', N'Thuế GTGT đầu ra', N'Thuế GTGT ĐR'),
    ('33312', '3331', N'Thuế GTGT hàng nhập khẩu', N'Thuế GTGT NK'),
    ('3332T', '3331', N'Thuế tiêu thụ đặc biệt', N'Thuế TTĐB'),
    ('3334T', '3331', N'Thuế thu nhập doanh nghiệp', N'Thuế TNDN'),
    ('3335T', '3331', N'Thuế thu nhập cá nhân', N'Thuế TNCN'),
    -- Con của 3341: Lương phải trả
    ('3341L', '3341', N'Phải trả lương công nhân viên', N'Lương PT'),
    -- Con của 3381: Phải trả khác
    ('3381T', '3381', N'Tài sản thừa chờ xử lý', N'TS thừa'),
    ('3382K', '3381', N'Kinh phí công đoàn', N'KP CĐ'),
    ('3383B', '3381', N'Bảo hiểm xã hội', N'BHXH'),
    -- Con của 4111: Vốn CSH
    ('4111V', '4111', N'Vốn góp của chủ sở hữu', N'Vốn CSH'),
    ('41111', '4111', N'Cổ phiếu phổ thông', N'CP phổ thông'),
    -- Con của 4211: LNST CPP
    ('4211L', '4211', N'Lợi nhuận sau thuế chưa phân phối', N'LNST CPP'),
    -- Con của 5111: DT bán HH
    ('5111B', '5111', N'Doanh thu bán hàng hóa ', N'DT bán'),
    -- Con của 5211: Hàng trả lại
    ('5211G', '5211', N'Hàng bán bị trả lại', N'Hàng trả lại'),
    -- Con của 6111: Mua HH
    ('6111M', '6111', N'Mua nguyên liệu bột ', N'Mua bột '),
    -- Con của 6321: GVHB
    ('6321H', '6321', N'Giá vốn hàng bán ', N'GVHB '),
    -- Con của 6411: CP nhân viên BH
    ('6411C', '6411', N'Chi phí nhân viên bán hàng', N'CP nhân viên BH'),
    ('6412B', '6412', N'Chi phí bao bì', N'CP bao bì');
    
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 85 dòng vào TAIKHOANCAP3.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TAIKHOANCAP3: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 39. SODUDAUKY (40 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu BƯỚC 4: SODUDAUKY (40 dòng) (Cập nhật năm 2025)...';
    INSERT INTO SODUDAUKY (SoTK, SoTKC3, TenTK, SDDKNo, SDDKCo, ThangNam)
    VALUES
    ('TK001', '1111M', N'Tiền mặt Việt Nam', 50000000.00, 0.00, '2025-01-01'),
    ('TK002', '1121H', N'Tiền gửi Vietcombank', 200000000.00, 0.00, '2025-01-01'),
    ('TK003', '1122H', N'Tiền gửi BIDV USD', 150000000.00, 0.00, '2025-01-01'),
    ('TK004', '1311K', N'Phải thu khách hàng', 80000000.00, 0.00, '2025-01-01'),
    ('TK005', '1331T', N'Thuế GTGT được khấu trừ', 15000000.00, 0.00, '2025-01-01'),
    ('TK006', '1521N', N'Bột mì', 120000000.00, 0.00, '2025-01-01'),
    ('TK007', '1561G', N'Giá mua hàng hóa', 250000000.00, 0.00, '2025-01-01'),
    ('TK008', '2111N', N'Nhà xưởng sản xuất', 5000000000.00, 0.00, '2025-01-01'),
    ('TK009', '2112M', N'Máy sản xuất mì', 3000000000.00, 0.00, '2025-01-01'),
    ('TK010', '2113P', N'Xe tải', 800000000.00, 0.00, '2025-01-01'),
    ('TK011', '2131D', N'Quyền sử dụng đất', 2000000000.00, 0.00, '2025-01-01'),
    ('TK012', '2141H', N'Hao mòn TSCĐ hữu hình', 0.00, 1200000000.00, '2025-01-01'),
    ('TK013', '2143V', N'Hao mòn TSCĐ vô hình', 0.00, 200000000.00, '2025-01-01'),
    ('TK014', '3311P', N'Phải trả nhà cung cấp', 0.00, 180000000.00, '2025-01-01'),
    ('TK015', '33311', N'Thuế GTGT đầu ra', 0.00, 25000000.00, '2025-01-01'),
    ('TK016', '3334T', N'Thuế TNDN', 0.00, 35000000.00, '2025-01-01'),
    ('TK017', '3341L', N'Phải trả lương', 0.00, 60000000.00, '2025-01-01'),
    ('TK018', '3383B', N'BHXH', 0.00, 15000000.00, '2025-01-01'),
    ('TK019', '4111V', N'Vốn góp CSH', 0.00, 8500000000.00, '2025-01-01'),
    ('TK020', '41111', N'Cổ phiếu phổ thông', 0.00, 8000000000.00, '2025-01-01'),
    ('TK021', '1111M', N'Tiền mặt Việt Nam', 55000000.00, 0.00, '2025-02-01'),
    ('TK022', '1121H', N'Tiền gửi Vietcombank', 220000000.00, 0.00, '2025-02-01'),
    ('TK023', '1311K', N'Phải thu khách hàng', 75000000.00, 0.00, '2025-02-01'),
    ('TK024', '1331T', N'Thuế GTGT được khấu trừ', 18000000.00, 0.00, '2025-02-01'),
    ('TK025', '1561G', N'Giá mua hàng hóa', 280000000.00, 0.00, '2025-02-01'),
    ('TK026', '2141H', N'Hao mòn TSCĐ hữu hình', 0.00, 1250000000.00, '2025-02-01'),
    ('TK027', '3311P', N'Phải trả nhà cung cấp', 0.00, 160000000.00, '2025-02-01'),
    ('TK028', '33311', N'Thuế GTGT đầu ra', 0.00, 22000000.00, '2025-02-01'),
    ('TK029', '3341L', N'Phải trả lương', 0.00, 58000000.00, '2025-02-01'),
    ('TK030', '1111M', N'Tiền mặt Việt Nam', 60000000.00, 0.00, '2025-03-01'),
    ('TK031', '1121H', N'Tiền gửi Vietcombank', 240000000.00, 0.00, '2025-03-01'),
    ('TK032', '1311K', N'Phải thu khách hàng', 70000000.00, 0.00, '2025-03-01'),
    ('TK033', '1331T', N'Thuế GTGT được khấu trừ', 20000000.00, 0.00, '2025-03-01'),
    ('TK034', '1561G', N'Giá mua hàng hóa', 300000000.00, 0.00, '2025-03-01'),
    ('TK035', '2141H', N'Hao mòn TSCĐ hữu hình', 0.00, 1300000000.00, '2025-03-01'),
    ('TK036', '3311P', N'Phải trả nhà cung cấp', 0.00, 150000000.00, '2025-03-01'),
    ('TK037', '33311', N'Thuế GTGT đầu ra', 0.00, 20000000.00, '2025-03-01'),
    ('TK038', '3341L', N'Phải trả lương', 0.00, 62000000.00, '2025-03-01'),
    ('TK039', '1112N', N'Ngoại tệ USD', 100000000.00, 0.00, '2025-01-01'),
    ('TK040', '2135P', N'Phần mềm SAP', 500000000.00, 0.00, '2025-01-01');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 40 dòng vào SODUDAUKY (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu SODUDAUKY: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 31. DVTSP (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO DVTSP (MaDVTSP, MaSP, TenDVTSP)
    VALUES
    ('DVT001', 'SP001', N'Ly'),
    ('DVT002', 'SP002', N'Gói'),
    ('DVT003', 'SP003', N'Gói'),
    ('DVT004', 'SP004', N'Gói'),
    ('DVT005', 'SP005', N'Ly'),
    ('DVT006', 'SP006', N'Gói'),
    ('DVT007', 'SP007', N'Gói'),
    ('DVT008', 'SP008', N'Tô'),
    ('DVT009', 'SP009', N'Gói'),
    ('DVT010', 'SP010', N'Gói');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào DVTSP.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu DVTSP: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 31. DONVITINHQUYDOI (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO DONVITINHQUYDOI (MaDVTQD, MaSP, MaDVTSP, TenQD, SLQD)
    VALUES
    ('QD001', 'SP001', 'DVT001', N'1 Thùng = 24 Ly', 24),
    ('QD002', 'SP002', 'DVT002', N'1 Thùng = 30 Gói', 30),
    ('QD003', 'SP003', 'DVT003', N'1 Thùng = 30 Gói', 30),
    ('QD004', 'SP004', 'DVT004', N'1 Thùng = 30 Gói', 30),
    ('QD005', 'SP005', 'DVT005', N'1 Thùng = 24 Ly', 24),
    ('QD006', 'SP006', 'DVT006', N'1 Thùng = 30 Gói', 30),
    ('QD007', 'SP007', 'DVT007', N'1 Thùng = 30 Gói', 30),
    ('QD008', 'SP008', 'DVT008', N'1 Thùng = 12 Tô', 12),
    ('QD009', 'SP009', 'DVT009', N'1 Thùng = 20 Gói', 20),
    ('QD010', 'SP010', 'DVT010', N'1 Thùng = 30 Gói', 30);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào DONVITINHQUYDOI.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu DONVITINHQUYDOI: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 27. BUTTOAN (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu BƯỚC 5: BUTTOAN (20 dòng) (Đã đồng bộ hóa với HDB/PTT, Năm 2025)...';
    INSERT INTO BUTTOAN (SoCT, NgayHachToan, DienGiai, TKNo, TKCo, SoTienBT, SLBT, DonGiaBT)
    VALUES
    -- Bút toán 1: Thu tiền (TGNH) + Ghi nhận Doanh thu (HDB001: TT đủ 44.2tr)
    ('BT001', '2025-01-15', N'Ghi nhận DT bán hàng HDB001', '1311K', '5111B', 42000000, 9000, 4667.00), 
    ('BT002', '2025-01-15', N'Thu tiền thanh toán HDB001', '1121H', '1311K', 44200000, 1, 44200000.00), 
    -- Bút toán 2: Thu tiền (TGNH) + Ghi nhận Doanh thu (HDB002: TT đủ 27tr)
    ('BT003', '2025-01-17', N'Ghi nhận DT bán hàng HDB002', '1311K', '5111B', 25000000, 7000, 3571.00), 
    ('BT004', '2025-01-17', N'Thu tiền thanh toán HDB002', '1121H', '1311K', 27000000, 1, 27000000.00), 
    -- Bút toán 3: Ghi nhận công nợ (HDB006: TT cọc 15tr, Công nợ còn 60.1tr)
    ('BT005', '2025-02-18', N'Ghi nhận DT bán hàng HDB006', '1311K', '5111B', 71000000, 18000, 3944.00), 
    ('BT006', '2025-02-18', N'Thu tiền cọc HDB006', '1121H', '1311K', 15000000, 1, 15000000.00), 
    -- Bút toán 4: Thu tiền (TM) + Ghi nhận Doanh thu (HDB003: TT đủ 8.25tr)
    ('BT007', '2025-01-18', N'Ghi nhận DT bán hàng HDB003', '1311K', '5111B', 7500000, 1000, 7500.00), 
    ('BT008', '2025-01-18', N'Thu tiền thanh toán HDB003', '1111M', '1311K', 8250000, 1, 8250000.00), 
    -- Bút toán 5: Ghi nhận công nợ (HDB016: Công nợ 47.5tr, không cọc)
    ('BT009', '2025-06-05', N'Ghi nhận DT công nợ HDB016', '1311K', '5111B', 45000000, 6000, 7500.00), 
    ('BT010', '2025-06-05', N'Ghi nhận thuế GTGT đầu ra HDB016', '1311K', '33311', 4500000, 1, 4500000.00), 
    -- Bút toán 6: Ghi nhận công nợ (HDB017: Công nợ 34tr, cọc 5tr)
    ('BT011', '2025-06-15', N'Ghi nhận DT công nợ HDB017', '1311K', '5111B', 32000000, 4500, 7111.00), 
    ('BT012', '2025-06-15', N'Ghi nhận thuế GTGT đầu ra HDB017', '1311K', '33311', 3200000, 1, 3200000.00), 
    ('BT013', '2025-06-15', N'Thu tiền cọc HDB017', '1121H', '1311K', 5000000, 1, 5000000.00), 
    -- Bút toán 7: Ghi nhận công nợ (HDB019: Công nợ 82.3tr, cọc 15tr)
    ('BT014', '2025-06-25', N'Ghi nhận DT công nợ HDB019', '1311K', '5111B', 78000000, 10000, 7800.00), 
    ('BT015', '2025-06-25', N'Ghi nhận thuế GTGT đầu ra HDB019', '1311K', '33311', 7800000, 1, 7800000.00), 
    ('BT016', '2025-06-25', N'Thu tiền cọc HDB019', '1121H', '1311K', 15000000, 1, 15000000.00), 
    -- Bút toán 8: Ghi nhận Hàng bán bị trả lại 
    ('BT017', '2025-03-01', N'Hàng bán bị trả lại từ KH003', '5211G', '1111M', 1000000, 100, 10000.00), 
    -- Bút toán 9: Ghi nhận Chi phí bán hàng (Bao bì)
    ('BT018', '2025-01-31', N'Chi phí bao bì tháng 1', '6412B', '1532B', 5000000, 1, 5000000.00), 
    -- Bút toán 10: Ghi nhận Giá vốn hàng bán (Giả định giá vốn DDH001 là 35tr)
    ('BT019', '2025-01-15', N'Ghi nhận GVHB DDH001', '6321H', '1551T', 35000000, 9000, 3889.00),
    -- Bút toán 11: Ghi nhận Giá vốn hàng bán (Giả định giá vốn DDH002 là 20tr)
    ('BT020', '2025-01-17', N'Ghi nhận GVHB DDH002', '6321H', '1551T', 20000000, 7000, 2857.00);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào BUTTOAN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu BUTTOAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 28. BAOCAO (20 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO BAOCAO (MaBC, MaNV, NgayLapBC, LoaiBC, NoiDungBC, TongGiaTri)
    VALUES
    ('BC001', 'NV001', '2025-01-31', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 1/2025', 200000000.00),
    ('BC002', 'NV001', '2025-02-28', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 2/2025', 250000000.00),
    ('BC003', 'NV001', '2025-03-31', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 3/2025', 280000000.00),
    ('BC004', 'NV005', '2025-01-31', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 1', 150000000.00),
    ('BC005', 'NV005', '2025-02-28', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 2', 165000000.00),
    ('BC006', 'NV005', '2025-03-31', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 3', 170000000.00),
    ('BC007', 'NV009', '2025-01-31', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 1', 45000000.00),
    ('BC008', 'NV009', '2025-02-28', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 2', 38000000.00),
    ('BC009', 'NV009', '2025-03-31', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 3', 40000000.00),
    ('BC010', 'NV001', '2025-04-30', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 4/2025', 310000000.00),
    ('BC011', 'NV001', '2025-05-31', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 5/2025', 350000000.00),
    ('BC012', 'NV005', '2025-04-30', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 4', 175000000.00),
    ('BC013', 'NV005', '2025-05-31', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 5', 180000000.00),
    ('BC014', 'NV009', '2025-04-30', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 4', 35000000.00),
    ('BC015', 'NV009', '2025-05-31', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 5', 42000000.00),
    ('BC016', 'NV001', '2025-06-30', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 6/2025', 320000000.00),
    ('BC017', 'NV005', '2025-06-30', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 6', 185000000.00),
    ('BC018', 'NV009', '2025-06-30', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 6', 48000000.00),
    ('BC019', 'NV001', '2025-06-30', N'Báo Cáo Tổng Hợp', N'Báo cáo quý 2/2025', 980000000.00),
    ('BC020', 'NV013', '2025-06-30', N'Báo Cáo Thanh Toán', N'Thanh toán quý 2/2025', 850000000.00);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào BAOCAO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu BAOCAO: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 40. CONGNO 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CONGNO (MaCN, MaKH, MaNCC, LoaiCongNo, NgayPhatSinh, HanThanhToan, SoTienNo, SoTienDaTra, TrangThai)
    VALUES
    ('CNPT01', 'KH008', NULL, N'Phải thu', '2025-02-18', '2025-03-18', 75100000, 15000000, N'Đã thanh toán một phần'), 
    ('CNPT02', 'KH013', NULL, N'Phải thu', '2025-03-25', '2025-04-25', 101700000, 20000000, N'Đã thanh toán một phần'), 
    ('CNPT03', 'KH018', NULL, N'Phải thu', '2025-05-15', '2025-06-15', 158000000, 30000000, N'Quá hạn'), 
    ('CNPT04', 'KH020', NULL, N'Phải thu', '2025-06-05', '2025-07-05', 47500000, 0, N'Chưa thanh toán'), 
    ('CNPT05', 'KH002', NULL, N'Phải thu', '2025-06-15', '2025-07-15', 34000000, 5000000, N'Chưa thanh toán'), 

    ('CNPR01', NULL, 'NCC002', N'Phải trả', '2025-01-10', '2025-02-10', 5000000, 5000000, N'Đã thanh toán đủ'), 
    ('CNPR02', NULL, 'NCC006', N'Phải trả', '2025-02-01', '2025-03-01', 8000000, 0, N'Quá hạn'), 
    ('CNPR03', NULL, 'NCC019', N'Phải trả', '2025-01-01', '2025-02-01', 10000000, 10000000, N'Đã thanh toán đủ');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 8 dòng vào CONGNO (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CONGNO: ' + ERROR_MESSAGE();
END CATCH;
GO


UPDATE BUTTOAN 
SET TrangThai = N'Ghi sổ' 
GO
-- 3. Thêm constraint để chỉ cho phép 2 giá trị
ALTER TABLE BUTTOAN
ADD CONSTRAINT CHK_BUTTOAN_TrangThai 
CHECK (TrangThai IN (N'Ghi sổ', N'Chưa ghi sổ'));
GO
-- 4. Kiểm tra kết quả
SELECT TOP 5 
    SoCT, 
    NgayHachToan, 
    TKNo, 
    TKCo, 
    SoTienBT, 
    TrangThai,
    DienGiai
FROM BUTTOAN
ORDER BY NgayHachToan DESC;
GO


-- 5. DỮ LIỆU PHIẾU THU / PHIẾU CHI (BỔ SUNG MỚI)
-- Tạo 2 Phiếu Thu (Thu tiền HDB001 và Khách lẻ)
INSERT INTO PHIEU_THU (SoPhieuThu, NgayLap, SoTienThu, LyDoThu, HinhThucTT, MaKH, MaNV, ThamChieuHD, TK_No, TK_Co) VALUES
('PT001', '2025-01-16', 44200000, N'Thu tiền hóa đơn HDB001', N'Chuyển khoản', 'KH001', 'NV013', 'HDB001', '1121', '1311'),
('PT002', '2025-01-17', 5000000, N'Thu tiền đặt cọc', N'Tiền mặt', 'KH002', 'NV013', NULL, '1111', '1311');

-- Tạo 2 Phiếu Chi (Trả tiền NCC001 và Chi tiền điện nước)
INSERT INTO PHIEU_CHI (SoPhieuChi, NgayLap, SoTienChi, LyDoChi, HinhThucTT, MaNCC, MaNV, TK_No, TK_Co) VALUES
('PC001', '2025-01-10', 20000000, N'Trả tiền mua bột mì', N'Chuyển khoản', 'NCC001', 'NV013', '3311', '1121'),
('PC002', '2025-01-12', 2000000, N'Chi tiền điện nước', N'Tiền mặt', NULL, 'NV013', '6427', '1111');


PRINT N'  HỆ THỐNG SẴN SÀNG SỬ DỤNG';
PRINT N'================================================';
GO



PRINT N'';
PRINT N'================================================';
PRINT N'  ✔ HOÀN THÀNH THÊM DỮ LIỆU CHO CÁC BẢNG';
PRINT N'================================================';
GO

USE QLKTBHACECOOK;
GO

PRINT N'';
PRINT N'================================================';
PRINT N'  BẮT ĐẦU TẠO VIEWS, TRIGGERS, PROCEDURES';
PRINT N'================================================';
GO

-- ============================================================
-- PHẦN 1: VIEWS (Các khung nhìn dữ liệu)
-- ============================================================

PRINT N'';
PRINT N'>>> TẠO VIEWS...';
GO

CREATE VIEW V_CustomerDetails AS
SELECT
    KH.MaKH,
    KH.TenKH,
    KH.SDTKH,
    KH.EmailKH,
    KH.DiaChiKH,
    LKH.TenLoaiKH,    -- Lấy tên loại khách hàng
    KH.MSTKH,
    KH.STKKH
FROM KHACHHANG KH
INNER JOIN LOAIKHACHHANG LKH ON KH.MaLoaiKH = LKH.MaLoaiKH;
GO
SELECT * FROM V_CustomerDetails
WHERE DiaChiKH LIKE N'%TP.HCM%';
-- ----------------------------------------------------------
-- VIEW 1: Tồn kho tổng hợp (Cho form quản lý tồn kho)
-- ----------------------------------------------------------
IF OBJECT_ID('V_TonKho_TongHop', 'V') IS NOT NULL
    DROP VIEW V_TonKho_TongHop;
GO

CREATE VIEW V_TonKho_TongHop AS
SELECT 
    NL.MaNL AS MaHangHoa,
    NL.TenNL AS TenHangHoa,
    N'Nguyên liệu' AS LoaiHangHoa,
    NL.DVTNL AS DonViTinh,
    ISNULL(SUM(TK.SLTonCuoiKy), 0) AS SoLuongTon,
    ISNULL(SUM(TK.TGNhapTrongKy), 0) AS TriGiaTon,
    COUNT(DISTINCT TK.MaKho) AS SoKhoLuuTru
FROM NGUYENLIEU NL
LEFT JOIN TONKHO TK ON NL.MaNL = TK.MaSP
GROUP BY NL.MaNL, NL.TenNL, NL.DVTNL

UNION ALL

SELECT 
    SP.MaSP AS MaHangHoa,
    SP.TenSP AS TenHangHoa,
    N'Sản phẩm' AS LoaiHangHoa,
    N'Thùng' AS DonViTinh, 
    ISNULL(SUM(TK.SLTonCuoiKy), 0) AS SoLuongTon,
    ISNULL(SUM(TK.TGNhapTrongKy), 0) AS TriGiaTon,
    COUNT(DISTINCT TK.MaKho) AS SoKhoLuuTru
FROM SANPHAM SP
LEFT JOIN TONKHO TK ON SP.MaSP = TK.MaSP
GROUP BY SP.MaSP, SP.TenSP;
GO

PRINT N'✓ Đã tạo V_TonKho_TongHop';
GO

SELECT * FROM V_TonKho_TongHop;

-- ----------------------------------------------------------
-- VIEW 2: Tồn kho theo từng kho
-- ----------------------------------------------------------
IF OBJECT_ID('V_TonKho_TheoKho', 'V') IS NOT NULL
    DROP VIEW V_TonKho_TheoKho;
GO

CREATE VIEW V_TonKho_TheoKho AS
SELECT 
    K.MaKho,
    K.TenKho,
    K.ViTri,
    TK.MaSP AS MaHangHoa,
    COALESCE(NL.TenNL, SP.TenSP) AS TenHangHoa,
    COALESCE(NL.DVTNL, N'Thùng') AS DonViTinh,
    TK.SLTonDauKy,
    TK.SLNhapTrongKy,
    TK.SLXuatTrongKy,
    TK.SLTonCuoiKy,
    TK.TGNhapTrongKy AS TriGiaTon,
    TK.NgayCapNhatKho
FROM TONKHO TK
INNER JOIN KHO K ON TK.MaKho = K.MaKho
LEFT JOIN NGUYENLIEU NL ON TK.MaSP = NL.MaNL
LEFT JOIN SANPHAM SP ON TK.MaSP = SP.MaSP
WHERE TK.SLTonCuoiKy > 0;
GO

PRINT N'✓ Đã tạo V_TonKho_TheoKho';
GO

SELECT * FROM V_TonKho_TheoKho;
-- ----------------------------------------------------------
-- VIEW 3: Cảnh báo tồn kho thấp (dưới định mức)
-- ----------------------------------------------------------
IF OBJECT_ID('V_CanhBao_TonKhoThap', 'V') IS NOT NULL
    DROP VIEW V_CanhBao_TonKhoThap;
GO

CREATE VIEW V_CanhBao_TonKhoThap AS
SELECT 
    DM.MaSP AS MaHangHoa,
    COALESCE(NL.TenNL, SP.TenSP) AS TenHangHoa,
    COALESCE(NL.DVTNL, N'Thùng') AS DonViTinh,
    DM.SoLuongNL AS DinhMuc,
    ISNULL(SUM(TK.SLTonCuoiKy), 0) AS TonKhoHienTai,
    DM.SoLuongNL - ISNULL(SUM(TK.SLTonCuoiKy), 0) AS SoLuongThieu,
    CASE
        WHEN ISNULL(SUM(TK.SLTonCuoiKy), 0) = 0 
            THEN N'Hết hàng'
        WHEN ISNULL(SUM(TK.SLTonCuoiKy), 0) < DM.SoLuongNL * 0.2 
            THEN N'Nguy cấp'
        WHEN ISNULL(SUM(TK.SLTonCuoiKy), 0) < DM.SoLuongNL * 0.5 
            THEN N'Cảnh báo'
        ELSE N'Thấp'
    END AS MucDoUuTien
FROM DINH_MUC DM
LEFT JOIN TONKHO TK ON DM.MaSP = TK.MaSP
LEFT JOIN NGUYENLIEU NL ON DM.MaNL = NL.MaNL
LEFT JOIN SANPHAM SP ON DM.MaSP = SP.MaSP
GROUP BY DM.MaSP, NL.TenNL, SP.TenSP, NL.DVTNL, DM.SoLuongNL
HAVING ISNULL(SUM(TK.SLTonCuoiKy), 0) < DM.SoLuongNL;
GO

SELECT * FROM V_CanhBao_TonKhoThap;


-- ----------------------------------------------------------
-- VIEW 4: Lịch sử nhập xuất kho
-- ----------------------------------------------------------
IF OBJECT_ID(N'V_LichSu_NhapXuatKho', 'V') IS NOT NULL
    DROP VIEW V_LichSu_NhapXuatKho;
GO

CREATE VIEW V_LichSu_NhapXuatKho AS

-- PHIẾU NHẬP
SELECT
    N'Nhập' AS LoaiPhieu,
    PN.SoPN AS SoPhieu,
    PN.NgayNhap AS NgayThucHien,
    PN.MaKho,
    K.TenKho,
    CTPN.MaNL AS MaHang,
    NL.TenNL AS TenHangHoa,
    CTPN.SoLuongNhap AS SoLuong,
    CTPN.DonGiaNhap AS DonGia,
    CTPN.ThanhTienNhap AS ThanhTien,
    PN.LyDoNhap AS GhiChu
FROM PHIEUNHAPKHO PN
INNER JOIN CHITIET_PN CTPN ON PN.SoPN = CTPN.SoPN
INNER JOIN KHO K ON PN.MaKho = K.MaKho
LEFT JOIN NGUYENLIEU NL ON CTPN.MaNL = NL.MaNL

UNION ALL

-- PHIẾU XUẤT
SELECT
    N'Xuất' AS LoaiPhieu,
    PX.SoPX AS SoPhieu,
    PX.NgayXuat AS NgayThucHien,
    CTPX.MaKho,
    K2.TenKho,
    NULL AS MaHang,
    NULL AS TenHangHoa,
    CTPX.SLXuat AS SoLuong,
    CTPX.DGXuat AS DonGia,
    CTPX.ThanhTienXuat AS ThanhTien,
    PX.LyDoXuat AS GhiChu
FROM PHIEUXUAT PX
INNER JOIN CT_PX CTPX ON PX.SoPX = CTPX.SoPX
INNER JOIN KHO K2 ON CTPX.MaKho = K2.MaKho;
GO

PRINT N'✓ Đã tạo V_LichSu_NhapXuatKho';
GO

-- ----------------------------------------------------------
-- VIEW 5: Thống kê doanh thu theo sản phẩm
-- ----------------------------------------------------------
IF OBJECT_ID(N'V_ThongKe_DoanhThuSP', 'V') IS NOT NULL
    DROP VIEW V_ThongKe_DoanhThuSP;
GO

CREATE VIEW V_ThongKe_DoanhThuSP AS
SELECT 
    SP.MaSP,
    SP.TenSP,
    LSP.TenLoaiSP,

    COUNT(DISTINCT CT.MaDDH) AS SoLuongDonHang,

    SUM(CT.SoLuongDDH) AS TongSoLuongBan,

    SUM(CT.SoLuongDDH * CT.DonGiaDDH) AS TongDoanhThu,

    AVG(CT.DonGiaDDH) AS GiaBanTrungBinh,

    MAX(DDH.NgayDatHang) AS LanBanGanNhat
FROM SANPHAM SP
LEFT JOIN LOAISANPHAM LSP ON SP.MaLoaiSP = LSP.MaLoaiSP
LEFT JOIN CT_DH CT ON SP.MaSP = CT.MaSP
LEFT JOIN DONDATHANG DDH ON CT.MaDDH = DDH.MaDDH
GROUP BY SP.MaSP, SP.TenSP, LSP.TenLoaiSP;
GO


PRINT N'✓ Đã tạo V_ThongKe_DoanhThuSP';
GO

-- ----------------------------------------------------------
-- VIEW 6: Thống kê khách hàng
-- ----------------------------------------------------------
IF OBJECT_ID(N'V_ThongKe_KhachHang', 'V') IS NOT NULL
    DROP VIEW V_ThongKe_KhachHang;
GO

CREATE VIEW V_ThongKe_KhachHang AS
SELECT
    KH.MaKH,
    KH.TenKH,
    LKH.TenLoaiKH,
    KH.DiaChiKH,
    KH.SDTKH,
    KH.EmailKH,

    -- Tổng số đơn đặt hàng
    COUNT(DISTINCT DDH.MaDDH) AS SoDonDatHang,

    -- Tổng số hóa đơn
    COUNT(DISTINCT HDB.SoHDB) AS SoHoaDon,

    -- Tổng giá trị mua hàng
    ISNULL(SUM(HDB.TriGiaSauGiam), 0) AS TongGiaTriMuaHang,

    -- Giá trị trung bình mỗi hóa đơn
    ISNULL(AVG(HDB.TriGiaSauGiam), 0) AS GiaTriTrungBinhDonHang,

    -- Lần mua gần nhất
    MAX(HDB.NgayLapHDB) AS LanMuaGanNhat,

    -- Số ngày chưa mua
    DATEDIFF(DAY, MAX(HDB.NgayLapHDB), GETDATE()) AS SoNgayChuaMua

FROM KHACHHANG KH
LEFT JOIN LOAIKHACHHANG LKH ON KH.MaLoaiKH = LKH.MaLoaiKH
LEFT JOIN DONDATHANG DDH ON KH.MaKH = DDH.MaKH
LEFT JOIN HOADONBAN HDB ON DDH.MaDDH = HDB.MaDDH

GROUP BY
    KH.MaKH,
    KH.TenKH,
    LKH.TenLoaiKH,
    KH.DiaChiKH,
    KH.SDTKH,
    KH.EmailKH;
GO


PRINT N'✓ Đã tạo V_ThongKe_KhachHang';
GO

-- ----------------------------------------------------------
-- VIEW 7: Thống kê nhà cung cấp
-- ----------------------------------------------------------
IF OBJECT_ID(N'V_ThongKe_NhaCungCap', 'V') IS NOT NULL
    DROP VIEW V_ThongKe_NhaCungCap;
GO

CREATE VIEW V_ThongKe_NhaCungCap AS
SELECT 
    NCC.MaNCC,
    NCC.TenNCC,
    NCC.DiaChiNCC,
    NCC.SDTNCC,
    NCC.EmailNCC,

    -- Số loại nguyên liệu mà nhà cung cấp cung ứng
    COUNT(DISTINCT CTCC.MaNL) AS SoMatHangCungCap,

    -- Số lần nhập từ nhà cung cấp này
    COUNT(DISTINCT PN.SoPN) AS SoLanNhapHang,

    -- Tổng giá trị nhập (từ phiếu nhập)
    ISNULL(SUM(CTPN.ThanhTienNhap), 0) AS TongGiaTriNhap,

    -- Lần nhập gần nhất
    MAX(PN.NgayNhap) AS LanNhapGanNhat

FROM NHACUNGCAP NCC
LEFT JOIN CT_CC CTCC 
    ON NCC.MaNCC = CTCC.MaNCC      -- mỗi NCC cung cấp nhiều nguyên liệu

LEFT JOIN CHITIET_PN CTPN 
    ON CTCC.MaNL = CTPN.MaNL       -- phiếu nhập cũng dùng MaNL

LEFT JOIN PHIEUNHAPKHO PN
    ON CTPN.SoPN = PN.SoPN         -- lấy ngày nhập + thông tin phiếu nhập

GROUP BY 
    NCC.MaNCC, NCC.TenNCC, NCC.DiaChiNCC, NCC.SDTNCC, NCC.EmailNCC;
GO


PRINT N'✓ Đã tạo V_ThongKe_NhaCungCap';
GO

-- ----------------------------------------------------------
-- VIEW 8: Nhân viên và phân quyền
-- ----------------------------------------------------------
IF OBJECT_ID('V_NhanVien_PhanQuyen', 'V') IS NOT NULL
    DROP VIEW V_NhanVien_PhanQuyen;
GO

CREATE VIEW V_NhanVien_PhanQuyen AS
SELECT 
    NV.MaNV,
    NV.HoTenNV,
    NV.SDTNV,
    NV.EmailNV,
    PB.TenPB AS PhongBan,
    CV.TenCV AS ChucVu,
    VT.TenVT AS VaiTro,
    TK.TenDangNhap,
    TK.TrangThaiTK,
    STRING_AGG(Q.TenQuyen, ', ') AS DanhSachQuyen
FROM NHANVIEN NV
LEFT JOIN PHONGBAN PB ON NV.MaPB = PB.MaPB
LEFT JOIN CHUCVU CV ON NV.MaCV = CV.MaCV
LEFT JOIN TAIKHOAN TK ON NV.MaNV = TK.MaNV
LEFT JOIN VAITRO VT ON TK.MaVT = VT.MaVT
LEFT JOIN CT_PHANQUYEN CTPQ ON VT.MaVT = CTPQ.MaVT
LEFT JOIN QUYEN Q ON CTPQ.MaQuyen = Q.MaQuyen
GROUP BY NV.MaNV, NV.HoTenNV, NV.SDTNV, NV.EmailNV, PB.TenPB, 
         CV.TenCV, VT.TenVT, TK.TenDangNhap, TK.TrangThaiTK;
GO

PRINT N'✓ Đã tạo V_NhanVien_PhanQuyen';
GO

-- ============================================================
-- PHẦN 2: STORED PROCEDURES (Các thủ tục)
-- ============================================================

PRINT N'';
PRINT N'>>> TẠO STORED PROCEDURES...';
GO

-- ----------------------------------------------------------
-- PROC 1: Kiểm kê tồn kho
-- ----------------------------------------------------------
IF OBJECT_ID('SP_KiemKeTonKho', 'P') IS NOT NULL
    DROP PROCEDURE SP_KiemKeTonKho;
GO

CREATE PROCEDURE SP_KiemKeTonKho
    @MaKho CHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        K.MaKho,
        K.TenKho,
        TK.MaSP,
        COALESCE(NL.TenNL, SP.TenSP) AS TenHangHoa,
        TK.SLTonDauKy,
        TK.SLNhapTrongKy,
        TK.SLXuatTrongKy,
        TK.SLTonCuoiKy,
        TK.TGNhapTrongKy,
        TK.NgayCapNhatKho,

        CASE
            WHEN TK.SLTonCuoiKy = 0 THEN N'Hết hàng'
            WHEN TK.SLTonCuoiKy < 10 THEN N'Nguy cấp'
            WHEN TK.SLTonCuoiKy < 50 THEN N'Cảnh báo'
            WHEN TK.SLTonCuoiKy < 100 THEN N'Thấp'
            ELSE N'Bình thường'
        END AS TrangThai

    FROM TONKHO TK
    INNER JOIN KHO K ON TK.MaKho = K.MaKho
    LEFT JOIN NGUYENLIEU NL ON TK.MaSP = NL.MaNL
    LEFT JOIN SANPHAM SP ON TK.MaSP = SP.MaSP;
END;
GO


PRINT N'✓ Đã tạo SP_KiemKeTonKho';
GO

EXEC SP_KiemKeTonKho;

-- ----------------------------------------------------------
-- PROC 2: Báo cáo doanh thu theo thời gian
-- ----------------------------------------------------------
IF OBJECT_ID('SP_BaoCaoDoanhThu', 'P') IS NOT NULL
    DROP PROCEDURE SP_BaoCaoDoanhThu;
GO

CREATE PROCEDURE SP_BaoCaoDoanhThu
    @TuNgay  DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        CONVERT(DATE, HDB.NgayLapHDB) AS Ngay,

        COUNT(DISTINCT HDB.SoHDB) AS SoHoaDon,
        COUNT(DISTINCT HDB.MaDDH) AS SoDonDatHang,
        COUNT(DISTINCT DDH.MaKH) AS SoKhachHang,

        SUM(HDB.TriGiaTruocthueHDB) AS TongDoanhThuTruocThue,
        SUM(HDB.TriGiaSauthueHDB) AS TongDoanhThuSauThue,
        SUM(HDB.GiamGiaHDB)        AS TongGiamGia,
        SUM(HDB.TriGiaSauGiam)     AS DoanhThuThucTe,

        AVG(HDB.TriGiaSauGiam)     AS GiaTriTrungBinhHoaDon

    FROM HOADONBAN HDB
    LEFT JOIN DONDATHANG DDH ON HDB.MaDDH = DDH.MaDDH

    WHERE HDB.NgayLapHDB BETWEEN @TuNgay AND @DenNgay

    GROUP BY CONVERT(DATE, HDB.NgayLapHDB)
    ORDER BY Ngay;
END;
GO

PRINT N'✓ Đã tạo SP_BaoCaoDoanhThu đầy đủ';
GO

-- ----------------------------------------------------------
-- PROC 3: Tìm kiếm hàng hóa (tổng hợp)
-- ----------------------------------------------------------
IF OBJECT_ID('SP_TimKiemHangHoa', 'P') IS NOT NULL
    DROP PROCEDURE SP_TimKiemHangHoa;
GO

CREATE PROCEDURE SP_TimKiemHangHoa
    @TuKhoa NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        MaHangHoa,
        TenHangHoa,
        LoaiHangHoa,
        DonViTinh,
        SoLuongTon,
        TriGiaTon,
        SoKhoLuuTru
    FROM V_TonKho_TongHop
    WHERE MaHangHoa LIKE '%' + @TuKhoa + '%'
       OR TenHangHoa LIKE '%' + @TuKhoa + '%'
       OR DonViTinh LIKE '%' + @TuKhoa + '%'
    ORDER BY TenHangHoa;
END;
GO

PRINT N'✓ Đã tạo SP_TimKiemHangHoa';
GO

-- ============================================================
-- PHẦN 3: TRIGGERS (Các ràng buộc tự động)
-- ============================================================

PRINT N'';
PRINT N'>>> TẠO TRIGGERS...';
GO

-- ----------------------------------------------------------
-- TRIGGER 1: Tự động cập nhật tổng tiền hóa đơn
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_HoaDonBan_TinhTong', 'TR') IS NOT NULL
    DROP TRIGGER TRG_HoaDonBan_TinhTong;
GO

CREATE TRIGGER TRG_HoaDonBan_TinhTong
ON CT_PX
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE PX
    SET TriGiaPX =
        (
            SELECT ISNULL(SUM(ThanhTienXuat), 0)
            FROM CT_PX
            WHERE SoPX = PX.SoPX
        )
    FROM PHIEUXUAT PX
    WHERE PX.SoPX IN
    (
        SELECT SoPX FROM inserted
        UNION
        SELECT SoPX FROM deleted
    );
END;
GO

PRINT N'✓ Đã tạo TRG_HoaDonBan_TinhTong';
GO

-- ----------------------------------------------------------
-- TRIGGER 2: Trigger kiểm tra ngày giao hàng trên bảng DONDATHANG
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_DONDATHANG_KiemTraNgay', 'TR') IS NOT NULL
    DROP TRIGGER TRG_DONDATHANG_KiemTraNgay;
GO

CREATE TRIGGER TRG_DONDATHANG_KiemTraNgay
ON DONDATHANG
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM inserted 
        WHERE NgayGiaoHang IS NOT NULL 
          AND NgayGiaoHang < NgayDatHang
    )
    BEGIN
        RAISERROR(N'Lỗi: Ngày giao hàng không được nhỏ hơn ngày đặt hàng!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO
PRINT N'✓ Đã tạo Trigger kiểm tra ngày giao hàng.';

-- ----------------------------------------------------------
-- TRIGGER 3: Trigger kiểm tra tồn kho khi thêm chi tiết đơn hàng
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_CTDH_KiemTraTonKho', 'TR') IS NOT NULL
    DROP TRIGGER TRG_CTDH_KiemTraTonKho;
GO

CREATE TRIGGER TRG_CTDH_KiemTraTonKho
ON CT_DH
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra nếu có sản phẩm nào số lượng đặt > Tổng tồn kho hiện tại
    IF EXISTS (
        SELECT i.MaSP
        FROM inserted i
        -- Tính tổng tồn kho của sản phẩm đó trên tất cả các kho
        CROSS APPLY (
            SELECT ISNULL(SUM(SLTonCuoiKy), 0) AS TongTon
            FROM TONKHO
            WHERE MaSP = i.MaSP
        ) tk
        WHERE i.SoLuongDDH > tk.TongTon
    )
    BEGIN
        RAISERROR(N'Lỗi: Số lượng đặt hàng vượt quá số lượng tồn kho hiện có!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO
PRINT N'✓ Đã tạo Trigger kiểm tra số lượng đặt hàng vs tồn kho.';

-- ----------------------------------------------------------
-- TRIGGER 4: Trigger cập nhật TONKHO khi Nhập hàng
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_CapNhatTonKho_Nhap', 'TR') IS NOT NULL
    DROP TRIGGER TRG_CapNhatTonKho_Nhap;
GO
CREATE TRIGGER TRG_CapNhatTonKho_Nhap
ON CHITIET_PN
AFTER INSERT, DELETE, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Biến tạm để xử lý logic update tồn kho
    DECLARE @MaKho CHAR(10);
    
    -- TRƯỜNG HỢP 1: INSERT (Nhập hàng mới)
    IF EXISTS(SELECT * FROM inserted) AND NOT EXISTS(SELECT * FROM deleted)
    BEGIN
        UPDATE TK
        SET TK.SLNhapTrongKy = ISNULL(TK.SLNhapTrongKy, 0) + i.SoLuongNhap,
            TK.TGNhapTrongKy = ISNULL(TK.TGNhapTrongKy, 0) + i.ThanhTienNhap,
            TK.SLTonCuoiKy = ISNULL(TK.SLTonCuoiKy, 0) + i.SoLuongNhap -- Tăng tồn cuối
        FROM TONKHO TK
        JOIN inserted i ON TK.MaSP = i.MaNL -- Lưu ý: MaNL trong bảng nhập map với MaSP trong kho
        JOIN PHIEUNHAPKHO PN ON i.SoPN = PN.SoPN
        WHERE TK.MaKho = PN.MaKho;
    END

    -- TRƯỜNG HỢP 2: DELETE (Xóa phiếu nhập - Hủy nhập)
    IF EXISTS(SELECT * FROM deleted) AND NOT EXISTS(SELECT * FROM inserted)
    BEGIN
        UPDATE TK
        SET TK.SLNhapTrongKy = ISNULL(TK.SLNhapTrongKy, 0) - d.SoLuongNhap,
            TK.TGNhapTrongKy = ISNULL(TK.TGNhapTrongKy, 0) - d.ThanhTienNhap,
            TK.SLTonCuoiKy = ISNULL(TK.SLTonCuoiKy, 0) - d.SoLuongNhap -- Giảm tồn cuối
        FROM TONKHO TK
        JOIN deleted d ON TK.MaSP = d.MaNL
        JOIN PHIEUNHAPKHO PN ON d.SoPN = PN.SoPN
        WHERE TK.MaKho = PN.MaKho;
    END
    
    -- (Có thể thêm phần UPDATE nếu cần sửa số lượng nhập)
END;
GO
PRINT N'✓ Đã tạo Trigger tự động tăng tồn kho khi nhập hàng.';

-- ----------------------------------------------------------
-- TRIGGER 5: Trigger Ngày Lập Hóa Đơn phải sau Ngày Đặt Hàng
-- ----------------------------------------------------------

IF OBJECT_ID('TRG_HOADONBAN_NgayLap', 'TR') IS NOT NULL
    DROP TRIGGER TRG_HOADONBAN_NgayLap;
GO

CREATE TRIGGER TRG_HOADONBAN_NgayLap
ON HOADONBAN
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN DONDATHANG ddh ON i.MaDDH = ddh.MaDDH
        WHERE i.NgayLapHDB < ddh.NgayDatHang
    )
    BEGIN
        RAISERROR(N'Lỗi: Ngày lập hóa đơn phải lớn hơn hoặc bằng ngày đặt hàng!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO
PRINT N'✓ Đã tạo Trigger kiểm tra ngày lập hóa đơn.';

-- ============================================================
-- PHẦN 4: FUNCTIONS (Các hàm)
-- ============================================================

PRINT N'';
PRINT N'>>> TẠO FUNCTIONS...';
GO

-- ----------------------------------------------------------
-- FUNCTION 1: Tính tổng tồn kho của một sản phẩm
-- ----------------------------------------------------------
IF OBJECT_ID('FN_TinhTongTonKho', 'FN') IS NOT NULL
    DROP FUNCTION FN_TinhTongTonKho;
GO

CREATE FUNCTION FN_TinhTongTonKho
(
    @MaSP CHAR(10)
)
RETURNS INT
AS
BEGIN
    DECLARE @TongTon INT;
    
    SELECT @TongTon = ISNULL(SUM(SLTonCuoiKy), 0)
    FROM TONKHO
    WHERE MaSP = @MaSP;
    
    RETURN ISNULL(@TongTon, 0);
END;
GO

PRINT N'✓ Đã tạo FN_TinhTongTonKho';
GO

-- ----------------------------------------------------------
-- FUNCTION 2: Kiểm tra sản phẩm có đủ hàng không
-- ----------------------------------------------------------
IF OBJECT_ID('FN_KiemTraDuHang', 'FN') IS NOT NULL
    DROP FUNCTION FN_KiemTraDuHang;
GO

CREATE FUNCTION FN_KiemTraDuHang
(
    @MaSP CHAR(10),
    @SoLuongCan INT
)
RETURNS BIT
AS
BEGIN
    DECLARE @TongTon INT;
    
    SELECT @TongTon = ISNULL(SUM(SLTonCuoiKy), 0)
    FROM TONKHO
    WHERE MaSP = @MaSP;
    
    IF @TongTon >= @SoLuongCan
        RETURN 1;
    
    RETURN 0;
END;
GO

PRINT N'✓ Đã tạo FN_KiemTraDuHang';
GO

-- ----------------------------------------------------------
-- FUNCTION 3: Tính giá trị tồn kho của một sản phẩm
-- ----------------------------------------------------------
IF OBJECT_ID('FN_TinhGiaTriTonKho', 'FN') IS NOT NULL
    DROP FUNCTION FN_TinhGiaTriTonKho;
GO

CREATE FUNCTION FN_TinhGiaTriTonKho
(
    @MaSP CHAR(10)
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @GiaTri DECIMAL(18,2);
    
    SELECT @GiaTri = ISNULL(SUM(TGNhapTrongKy), 0)
    FROM TONKHO
    WHERE MaSP = @MaSP;
    
    RETURN ISNULL(@GiaTri, 0);
END;
GO

PRINT N'✓ Đã tạo FN_TinhGiaTriTonKho';
GO

-- ----------------------------------------------------------
-- FUNCTION 4: Lấy trạng thái tồn kho
-- ----------------------------------------------------------
IF OBJECT_ID('FN_TrangThaiTonKho', 'FN') IS NOT NULL
    DROP FUNCTION FN_TrangThaiTonKho;
GO

CREATE FUNCTION FN_TrangThaiTonKho
(
    @MaSP CHAR(10)
)
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @TongTon INT;
    DECLARE @DinhMuc INT = 1000; 
    DECLARE @TrangThai NVARCHAR(20);
    
    SELECT @TongTon = ISNULL(SUM(SLTonCuoiKy), 0)
    FROM TONKHO
    WHERE MaSP = @MaSP;
    
    IF @TongTon = 0
        SET @TrangThai = N'Hết hàng';
    ELSE IF @DinhMuc IS NULL
        SET @TrangThai = N'Chưa định mức';
    ELSE IF @TongTon < @DinhMuc * 0.2
        SET @TrangThai = N'Nguy cấp';
    ELSE IF @TongTon < @DinhMuc * 0.5
        SET @TrangThai = N'Cảnh báo';
    ELSE IF @TongTon < @DinhMuc
        SET @TrangThai = N'Thấp';
    ELSE
        SET @TrangThai = N'Bình thường';
    
    RETURN @TrangThai;
END;
GO

PRINT N'✓ Đã tạo FN_TrangThaiTonKho';
GO

-- ----------------------------------------------------------
-- FUNCTION 5: Tính tổng doanh thu của khách hàng (Cần join qua DDH và HDB)
-- ----------------------------------------------------------
IF OBJECT_ID('FN_TinhDoanhThuKH', 'FN') IS NOT NULL
    DROP FUNCTION FN_TinhDoanhThuKH;
GO

CREATE FUNCTION FN_TinhDoanhThuKH
(
    @MaKH CHAR(10)
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @TongDoanhThu DECIMAL(18,2);
    
    SELECT @TongDoanhThu = ISNULL(SUM(HDB.TriGiaSauGiam), 0)
    FROM DONDATHANG DDH
    INNER JOIN HOADONBAN HDB ON DDH.MaDDH = HDB.MaDDH
    WHERE DDH.MaKH = @MaKH;
    
    RETURN ISNULL(@TongDoanhThu, 0);
END;
GO

PRINT N'✓ Đã tạo FN_TinhDoanhThuKH';
GO

-- ----------------------------------------------------------
-- FUNCTION 6: Lấy thông tin ngắn gọn về hàng hóa
-- ----------------------------------------------------------
IF OBJECT_ID('FN_ThongTinHangHoa', 'IF') IS NOT NULL
    DROP FUNCTION FN_ThongTinHangHoa;
GO

CREATE FUNCTION FN_ThongTinHangHoa
(
    @MaSP CHAR(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 1
        @MaSP AS MaHangHoa,
        COALESCE(NL.TenNL, SP.TenSP) AS TenHangHoa,
        CASE WHEN NL.MaNL IS NOT NULL THEN N'Nguyên liệu' ELSE N'Sản phẩm' END AS LoaiHangHoa,
        COALESCE(NL.DVTNL, N'Thùng') AS DonViTinh,
        dbo.FN_TinhTongTonKho(@MaSP) AS SoLuongTon,
        dbo.FN_TinhGiaTriTonKho(@MaSP) AS GiaTriTon,
        dbo.FN_TrangThaiTonKho(@MaSP) AS TrangThai
    FROM (SELECT @MaSP AS Ma) X
    LEFT JOIN NGUYENLIEU NL ON X.Ma = NL.MaNL
    LEFT JOIN SANPHAM SP ON X.Ma = SP.MaSP
);
GO

PRINT N'✓ Đã tạo FN_ThongTinHangHoa';
GO

-- ============================================================
-- PHẦN 5: INDEXES (Tối ưu hiệu suất)
-- ============================================================

PRINT N'';
PRINT N'>>> TẠO INDEXES...';
GO

-- Index cho TONKHO (tra cứu nhanh)
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_TONKHO_MaSP')
    CREATE INDEX IX_TONKHO_MaSP ON TONKHO(MaSP);
PRINT N'✓ Đã tạo IX_TONKHO_MaSP';
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_TONKHO_NgayCapNhat')
    CREATE INDEX IX_TONKHO_NgayCapNhat ON TONKHO(NgayCapNhatKho);
PRINT N'✓ Đã tạo IX_TONKHO_NgayCapNhat';
GO

-- Index cho PHIEUNHAPKHO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PHIEUNHAPKHO_NgayNhap')
    CREATE INDEX IX_PHIEUNHAPKHO_NgayNhap ON PHIEUNHAPKHO(NgayNhap);
PRINT N'✓ Đã tạo IX_PHIEUNHAPKHO_NgayNhap';
GO

-- Index cho PHIEUXUAT
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PHIEUXUAT_NgayXuat')
    CREATE INDEX IX_PHIEUXUAT_NgayXuat ON PHIEUXUAT(NgayXuat);
PRINT N'✓ Đã tạo IX_PHIEUXUAT_NgayXuat';
GO

-- Index cho HOADONBAN
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HOADONBAN_NgayLap')
    CREATE INDEX IX_HOADONBAN_NgayLap ON HOADONBAN(NgayLapHDB);
PRINT N'✓ Đã tạo IX_HOADONBAN_NgayLap';
GO

USE QLKTBHACECOOK;
GO

-- Xóa View cũ nếu có lỗi
IF OBJECT_ID(N'V_LichSu_NhapXuatKho', 'V') IS NOT NULL
    DROP VIEW V_LichSu_NhapXuatKho;
GO

-- Tạo lại View
CREATE VIEW V_LichSu_NhapXuatKho AS
-- PHIẾU NHẬP
SELECT
    N'Nhập' AS LoaiPhieu,
    PN.SoPN AS SoPhieu,
    PN.NgayNhap AS NgayThucHien,
    PN.MaKho,
    K.TenKho,
    CTPN.MaNL AS MaHang,
    NL.TenNL AS TenHangHoa,
    CTPN.SoLuongNhap AS SoLuong,
    CTPN.DonGiaNhap AS DonGia,
    CTPN.ThanhTienNhap AS ThanhTien,
    PN.LyDoNhap AS GhiChu
FROM PHIEUNHAPKHO PN
INNER JOIN CHITIET_PN CTPN ON PN.SoPN = CTPN.SoPN
INNER JOIN KHO K ON PN.MaKho = K.MaKho
LEFT JOIN NGUYENLIEU NL ON CTPN.MaNL = NL.MaNL

UNION ALL

-- PHIẾU XUẤT
SELECT
    N'Xuất' AS LoaiPhieu,
    PX.SoPX AS SoPhieu,
    PX.NgayXuat AS NgayThucHien,
    CTPX.MaKho,
    K2.TenKho,
    NULL AS MaHang, -- Hoặc lấy mã hàng nếu cần thiết kế thêm
    NULL AS TenHangHoa,
    CTPX.SLXuat AS SoLuong,
    CTPX.DGXuat AS DonGia,
    CTPX.ThanhTienXuat AS ThanhTien,
    PX.LyDoXuat AS GhiChu
FROM PHIEUXUAT PX
INNER JOIN CT_PX CTPX ON PX.SoPX = CTPX.SoPX
INNER JOIN KHO K2 ON CTPX.MaKho = K2.MaKho;
GO
USE QLKTBHACECOOK;
GO

PRINT N'';
PRINT N'====================================================================';
PRINT N'  BẮT ĐẦU TẠO VIEWS, TRIGGERS, STORED PROCEDURES, FUNCTIONS';
PRINT N'====================================================================';
GO

-- ============================================================
-- PHẦN 1: VIEWS (30+ Views)
-- ============================================================

PRINT N'';
PRINT N'>>> ĐANG TẠO VIEWS...';
GO

-- ----------------------------------------------------------
-- VIEW 1: Tổng hợp tồn kho (sửa lại cho đúng với schema)
-- ----------------------------------------------------------
IF OBJECT_ID('V_TonKho_TongHop', 'V') IS NOT NULL DROP VIEW V_TonKho_TongHop;
GO

CREATE VIEW V_TonKho_TongHop AS
SELECT 
    TK.MaSP AS MaHangHoa,
    SP.TenSP AS TenHangHoa,
    N'Sản phẩm' AS LoaiHangHoa,
    N'Thùng' AS DonViTinh,
    SUM(TK.SLTonCuoiKy) AS SoLuongTon,
    SUM(TK.TGNhapTrongKy) AS TriGiaTon,
    COUNT(DISTINCT TK.MaKho) AS SoKhoLuuTru,
    MAX(TK.NgayCapNhatKho) AS NgayCapNhatGanNhat
FROM TONKHO TK
INNER JOIN SANPHAM SP ON TK.MaSP = SP.MaSP
GROUP BY TK.MaSP, SP.TenSP;
GO

PRINT N'✓ Đã tạo V_TonKho_TongHop';
GO

-- ----------------------------------------------------------
-- VIEW 2: Tồn kho chi tiết theo kho
-- ----------------------------------------------------------
IF OBJECT_ID('V_TonKho_TheoKho', 'V') IS NOT NULL DROP VIEW V_TonKho_TheoKho;
GO

CREATE VIEW V_TonKho_TheoKho AS
SELECT 
    K.MaKho,
    K.TenKho,
    K.ViTri AS DiaChiKho,
    TK.MaSP AS MaHangHoa,
    SP.TenSP AS TenHangHoa,
    N'Thùng' AS DonViTinh,
    TK.SLTonDauKy,
    TK.SLNhapTrongKy,
    TK.SLXuatTrongKy,
    TK.SLTonCuoiKy,
    TK.TGNhapTrongKy AS TriGiaTon,
    TK.NgayCapNhatKho,
    CASE 
        WHEN TK.SLTonCuoiKy = 0 THEN N'Hết hàng'
        WHEN TK.SLTonCuoiKy < 100 THEN N'Sắp hết'
        WHEN TK.SLTonCuoiKy < 500 THEN N'Thấp'
        ELSE N'Bình thường'
    END AS TrangThai
FROM TONKHO TK
INNER JOIN KHO K ON TK.MaKho = K.MaKho
INNER JOIN SANPHAM SP ON TK.MaSP = SP.MaSP
WHERE TK.SLTonCuoiKy >= 0;
GO

PRINT N'✓ Đã tạo V_TonKho_TheoKho';
GO

-- ----------------------------------------------------------
-- VIEW 3: Cảnh báo tồn kho thấp
-- ----------------------------------------------------------
IF OBJECT_ID('V_CanhBao_TonKhoThap', 'V') IS NOT NULL DROP VIEW V_CanhBao_TonKhoThap;
GO

CREATE VIEW V_CanhBao_TonKhoThap AS
SELECT 
    TK.MaSP AS MaHangHoa,
    SP.TenSP AS TenHangHoa,
    SUM(TK.SLTonCuoiKy) AS TonKhoHienTai,
    500 AS DinhMucToiThieu,
    500 - SUM(TK.SLTonCuoiKy) AS SoLuongThieu,
    CASE 
        WHEN SUM(TK.SLTonCuoiKy) = 0 THEN N'Hết hàng - Mức 1'
        WHEN SUM(TK.SLTonCuoiKy) < 100 THEN N'Nguy cấp - Mức 2'
        WHEN SUM(TK.SLTonCuoiKy) < 300 THEN N'Cảnh báo - Mức 3'
        ELSE N'Thấp - Mức 4'
    END AS MucDoUuTien
FROM TONKHO TK
INNER JOIN SANPHAM SP ON TK.MaSP = SP.MaSP
GROUP BY TK.MaSP, SP.TenSP
HAVING SUM(TK.SLTonCuoiKy) < 500;
GO

PRINT N'✓ Đã tạo V_CanhBao_TonKhoThap';
GO

-- ----------------------------------------------------------
-- VIEW 4: Lịch sử nhập xuất kho
-- ----------------------------------------------------------
IF OBJECT_ID('V_LichSu_NhapXuatKho', 'V') IS NOT NULL DROP VIEW V_LichSu_NhapXuatKho;
GO

CREATE VIEW V_LichSu_NhapXuatKho AS
-- Phiếu nhập
SELECT 
    N'Nhập' AS LoaiPhieu,
    PN.SoPN AS SoPhieu,
    PN.NgayNhap AS NgayThucHien,
    K.MaKho,
    K.TenKho,
    CTPN.MaNL AS MaHangHoa,
    NL.TenNL AS TenHangHoa,
    CTPN.SoLuongNhap AS SoLuong,
    CTPN.DonGiaNhap AS DonGia,
    CTPN.ThanhTienNhap AS ThanhTien,
    PN.LyDoNhap AS GhiChu
FROM PHIEUNHAPKHO PN
INNER JOIN CHITIET_PN CTPN ON PN.SoPN = CTPN.SoPN
INNER JOIN KHO K ON PN.MaKho = K.MaKho
INNER JOIN NGUYENLIEU NL ON CTPN.MaNL = NL.MaNL

UNION ALL

-- Phiếu xuất
SELECT 
    N'Xuất' AS LoaiPhieu,
    PX.SoPX AS SoPhieu,
    PX.NgayXuat AS NgayThucHien,
    CTPX.MaKho,
    K.TenKho,
    NULL AS MaHangHoa,
    N'Sản phẩm' AS TenHangHoa,
    CTPX.SLXuat AS SoLuong,
    CTPX.DGXuat AS DonGia,
    CTPX.ThanhTienXuat AS ThanhTien,
    PX.LyDoXuat AS GhiChu
FROM PHIEUXUAT PX
INNER JOIN CT_PX CTPX ON PX.SoPX = CTPX.SoPX
INNER JOIN KHO K ON CTPX.MaKho = K.MaKho;
GO

PRINT N'✓ Đã tạo V_LichSu_NhapXuatKho';
GO

-- ----------------------------------------------------------
-- VIEW 5: Thống kê doanh thu theo sản phẩm
-- ----------------------------------------------------------
IF OBJECT_ID('V_ThongKe_DoanhThuSP', 'V') IS NOT NULL DROP VIEW V_ThongKe_DoanhThuSP;
GO

CREATE VIEW V_ThongKe_DoanhThuSP AS
SELECT 
    SP.MaSP,
    SP.TenSP,
    LSP.TenLoaiSP,
    SP.GiaBanSP,
    COUNT(DISTINCT DDH.MaDDH) AS SoDonHang,
    ISNULL(SUM(CTDH.SoLuongDDH), 0) AS TongSoLuongBan,
    ISNULL(SUM(CTDH.SoLuongDDH * CTDH.DonGiaDDH), 0) AS TongDoanhThu,
    CASE 
        WHEN SUM(CTDH.SoLuongDDH) > 0 
        THEN SUM(CTDH.SoLuongDDH * CTDH.DonGiaDDH) / SUM(CTDH.SoLuongDDH)
        ELSE 0 
    END AS GiaBanTrungBinh
FROM SANPHAM SP
LEFT JOIN LOAISANPHAM LSP ON SP.MaLoaiSP = LSP.MaLoaiSP
LEFT JOIN CT_DH CTDH ON SP.MaSP = CTDH.MaSP
LEFT JOIN DONDATHANG DDH ON CTDH.MaDDH = DDH.MaDDH
GROUP BY SP.MaSP, SP.TenSP, LSP.TenLoaiSP, SP.GiaBanSP;
GO

PRINT N'✓ Đã tạo V_ThongKe_DoanhThuSP';
GO

-- ----------------------------------------------------------
-- VIEW 6: Thống kê khách hàng
-- ----------------------------------------------------------
IF OBJECT_ID('V_ThongKe_KhachHang', 'V') IS NOT NULL DROP VIEW V_ThongKe_KhachHang;
GO

CREATE VIEW V_ThongKe_KhachHang AS
SELECT 
    KH.MaKH,
    KH.TenKH,
    LKH.TenLoaiKH,
    KH.DiaChiKH,
    KH.SDTKH,
    KH.EmailKH,
    KH.CongNoKH,
    COUNT(DISTINCT DDH.MaDDH) AS SoDonDatHang,
    COUNT(DISTINCT HDB.SoHDB) AS SoHoaDon,
    ISNULL(SUM(HDB.TriGiaSauGiam), 0) AS TongGiaTriMuaHang,
    CASE 
        WHEN COUNT(DISTINCT HDB.SoHDB) > 0 
        THEN SUM(HDB.TriGiaSauGiam) / COUNT(DISTINCT HDB.SoHDB)
        ELSE 0 
    END AS GiaTriTrungBinhDonHang,
    MAX(DDH.NgayDatHang) AS LanMuaGanNhat,
    DATEDIFF(DAY, MAX(DDH.NgayDatHang), GETDATE()) AS SoNgayChuaMua
FROM KHACHHANG KH
LEFT JOIN LOAIKHACHHANG LKH ON KH.MaLoaiKH = LKH.MaLoaiKH
LEFT JOIN DONDATHANG DDH ON KH.MaKH = DDH.MaKH
LEFT JOIN HOADONBAN HDB ON DDH.MaDDH = HDB.MaDDH
GROUP BY KH.MaKH, KH.TenKH, LKH.TenLoaiKH, KH.DiaChiKH, KH.SDTKH, KH.EmailKH, KH.CongNoKH;
GO

PRINT N'✓ Đã tạo V_ThongKe_KhachHang';
GO

-- ----------------------------------------------------------
-- VIEW 7: Thống kê nhà cung cấp
-- ----------------------------------------------------------
IF OBJECT_ID('V_ThongKe_NhaCungCap', 'V') IS NOT NULL DROP VIEW V_ThongKe_NhaCungCap;
GO

CREATE VIEW V_ThongKe_NhaCungCap AS
SELECT 
    NCC.MaNCC,
    NCC.TenNCC,
    NCC.DiaChiNCC,
    NCC.SDTNCC,
    NCC.EmailNCC,
    NCC.CongNoNCC,
    COUNT(DISTINCT CTCC.MaNL) AS SoMatHangCungCap,
    COUNT(DISTINCT CTPN.SoPN) AS SoLanNhapHang,
    ISNULL(SUM(CTPN.ThanhTienNhap), 0) AS TongGiaTriNhap,
    MAX(PN.NgayNhap) AS LanNhapGanNhat
FROM NHACUNGCAP NCC
LEFT JOIN CT_CC CTCC ON NCC.MaNCC = CTCC.MaNCC
LEFT JOIN CHITIET_PN CTPN ON CTCC.MaNL = CTPN.MaNL
LEFT JOIN PHIEUNHAPKHO PN ON CTPN.SoPN = PN.SoPN
GROUP BY NCC.MaNCC, NCC.TenNCC, NCC.DiaChiNCC, NCC.SDTNCC, NCC.EmailNCC, NCC.CongNoNCC;
GO

PRINT N'✓ Đã tạo V_ThongKe_NhaCungCap';
GO

-- ----------------------------------------------------------
-- VIEW 8: Nhân viên và phân quyền
-- ----------------------------------------------------------
IF OBJECT_ID('V_NhanVien_PhanQuyen', 'V') IS NOT NULL DROP VIEW V_NhanVien_PhanQuyen;
GO

CREATE VIEW V_NhanVien_PhanQuyen AS
SELECT 
    NV.MaNV,
    NV.HoTenNV,
    NV.SDTNV,
    NV.EmailNV,
    PB.TenPB AS PhongBan,
    CV.TenCV AS ChucVu,
    VT.TenVT AS VaiTro,
    TK.TenDangNhap,
    TK.TrangThaiTK,
    STRING_AGG(Q.TenQuyen, ', ') AS DanhSachQuyen
FROM NHANVIEN NV
LEFT JOIN PHONGBAN PB ON NV.MaPB = PB.MaPB
LEFT JOIN CHUCVU CV ON NV.MaCV = CV.MaCV
LEFT JOIN TAIKHOAN TK ON NV.MaNV = TK.MaNV
LEFT JOIN VAITRO VT ON TK.MaVT = VT.MaVT
LEFT JOIN CT_PHANQUYEN CTPQ ON VT.MaVT = CTPQ.MaVT
LEFT JOIN QUYEN Q ON CTPQ.MaQuyen = Q.MaQuyen
GROUP BY NV.MaNV, NV.HoTenNV, NV.SDTNV, NV.EmailNV, PB.TenPB, 
         CV.TenCV, VT.TenVT, TK.TenDangNhap, TK.TrangThaiTK;
GO

PRINT N'✓ Đã tạo V_NhanVien_PhanQuyen';
GO

-- ----------------------------------------------------------
-- VIEW 9: Báo cáo công nợ khách hàng
-- ----------------------------------------------------------
IF OBJECT_ID('V_BaoCao_CongNoKH', 'V') IS NOT NULL DROP VIEW V_BaoCao_CongNoKH;
GO

CREATE VIEW V_BaoCao_CongNoKH AS
SELECT 
    KH.MaKH,
    KH.TenKH,
    KH.SDTKH,
    KH.EmailKH,
    KH.CongNoKH AS CongNoDauKy,
    ISNULL(SUM(HDB.TriGiaSauGiam), 0) AS TongGiaTriMuaHang,
    ISNULL(SUM(PTT.SoTienTT), 0) AS TongDaThanhToan,
    KH.CongNoKH + ISNULL(SUM(HDB.TriGiaSauGiam), 0) - ISNULL(SUM(PTT.SoTienTT), 0) AS CongNoHienTai,
    CASE 
        WHEN DATEDIFF(DAY, MAX(PTT.NgayTT), GETDATE()) > 90 THEN N'Quá hạn >90 ngày'
        WHEN DATEDIFF(DAY, MAX(PTT.NgayTT), GETDATE()) > 60 THEN N'Quá hạn >60 ngày'
        WHEN DATEDIFF(DAY, MAX(PTT.NgayTT), GETDATE()) > 30 THEN N'Quá hạn >30 ngày'
        ELSE N'Trong hạn'
    END AS TrangThaiCongNo
FROM KHACHHANG KH
LEFT JOIN DONDATHANG DDH ON KH.MaKH = DDH.MaKH
LEFT JOIN HOADONBAN HDB ON DDH.MaDDH = HDB.MaDDH
LEFT JOIN PHIEUTHANHTOAN PTT ON HDB.SoHDB = PTT.SoHDB
GROUP BY KH.MaKH, KH.TenKH, KH.SDTKH, KH.EmailKH, KH.CongNoKH;
GO

PRINT N'✓ Đã tạo V_BaoCao_CongNoKH';
GO

-- ----------------------------------------------------------
-- VIEW 10: Báo cáo công nợ nhà cung cấp
-- ----------------------------------------------------------
IF OBJECT_ID('V_BaoCao_CongNoNCC', 'V') IS NOT NULL DROP VIEW V_BaoCao_CongNoNCC;
GO

CREATE VIEW V_BaoCao_CongNoNCC AS
SELECT 
    NCC.MaNCC,
    NCC.TenNCC,
    NCC.SDTNCC,
    NCC.EmailNCC,
    NCC.CongNoNCC AS CongNoDauKy,
    ISNULL(SUM(CTPN.ThanhTienNhap), 0) AS TongGiaTriNhap,
    NCC.CongNoNCC + ISNULL(SUM(CTPN.ThanhTienNhap), 0) AS CongNoHienTai,
    CASE 
        WHEN NCC.CongNoNCC + ISNULL(SUM(CTPN.ThanhTienNhap), 0) > 50000000 THEN N'Cao'
        WHEN NCC.CongNoNCC + ISNULL(SUM(CTPN.ThanhTienNhap), 0) > 20000000 THEN N'Trung bình'
        WHEN NCC.CongNoNCC + ISNULL(SUM(CTPN.ThanhTienNhap), 0) > 0 THEN N'Thấp'
        ELSE N'Không nợ'
    END AS MucDoCongNo
FROM NHACUNGCAP NCC
LEFT JOIN CT_CC CTCC ON NCC.MaNCC = CTCC.MaNCC
LEFT JOIN CHITIET_PN CTPN ON CTCC.MaNL = CTPN.MaNL
GROUP BY NCC.MaNCC, NCC.TenNCC, NCC.SDTNCC, NCC.EmailNCC, NCC.CongNoNCC;
GO

PRINT N'✓ Đã tạo V_BaoCao_CongNoNCC';
GO

-- ----------------------------------------------------------
-- VIEW 11: Hiệu suất bán hàng theo nhân viên
-- ----------------------------------------------------------
IF OBJECT_ID('V_HieuSuat_BanHang_NV', 'V') IS NOT NULL DROP VIEW V_HieuSuat_BanHang_NV;
GO

CREATE VIEW V_HieuSuat_BanHang_NV AS
SELECT 
    NV.MaNV,
    NV.HoTenNV,
    PB.TenPB,
    CV.TenCV,
    COUNT(DISTINCT DDH.MaDDH) AS SoDonHang,
    ISNULL(SUM(HDB.TriGiaSauGiam), 0) AS TongDoanhThu,
    CASE 
        WHEN COUNT(DISTINCT DDH.MaDDH) > 0 
        THEN SUM(HDB.TriGiaSauGiam) / COUNT(DISTINCT DDH.MaDDH)
        ELSE 0 
    END AS DoanhThuTrungBinh,
    MAX(DDH.NgayDatHang) AS DonHangGanNhat
FROM NHANVIEN NV
LEFT JOIN PHONGBAN PB ON NV.MaPB = PB.MaPB
LEFT JOIN CHUCVU CV ON NV.MaCV = CV.MaCV
LEFT JOIN DONDATHANG DDH ON NV.MaNV = DDH.MaNV
LEFT JOIN HOADONBAN HDB ON DDH.MaDDH = HDB.MaDDH
GROUP BY NV.MaNV, NV.HoTenNV, PB.TenPB, CV.TenCV;
GO

PRINT N'✓ Đã tạo V_HieuSuat_BanHang_NV';
GO

-- ----------------------------------------------------------
-- VIEW 12: Chương trình khuyến mãi đang hoạt động
-- ----------------------------------------------------------
IF OBJECT_ID('V_KhuyenMai_HoatDong', 'V') IS NOT NULL DROP VIEW V_KhuyenMai_HoatDong;
GO

CREATE VIEW V_KhuyenMai_HoatDong AS
SELECT 
    KM.MaCTKM,
    KM.TenCTKM,
    KM.NgayBatDauKM,
    KM.NgayKetThucKM,
    KM.LyDoKM,
    DATEDIFF(DAY, GETDATE(), KM.NgayKetThucKM) AS SoNgayConLai,
    COUNT(CTKM.MaSP) AS SoSanPhamApDung,
    AVG(CTKM.TyLePhanTram) AS TyLeGiamTrungBinh
FROM CTKM KM
LEFT JOIN CT_KM CTKM ON KM.MaCTKM = CTKM.MaCTKM
WHERE GETDATE() BETWEEN KM.NgayBatDauKM AND KM.NgayKetThucKM
GROUP BY KM.MaCTKM, KM.TenCTKM, KM.NgayBatDauKM, KM.NgayKetThucKM, KM.LyDoKM;
GO

PRINT N'✓ Đã tạo V_KhuyenMai_HoatDong';
GO

-- ----------------------------------------------------------
-- VIEW 13: Tài khoản kế toán - Bảng cân đối kế toán
-- ----------------------------------------------------------
IF OBJECT_ID('V_BangCanDoiKeToan', 'V') IS NOT NULL DROP VIEW V_BangCanDoiKeToan;
GO

CREATE VIEW V_BangCanDoiKeToan AS
SELECT 
    TKC1.SoTKC1,
    TKC1.TenTKC1,
    TKC2.SoTKC2,
    TKC2.TenTKC2,
    TKC3.SoTKC3,
    TKC3.TenTKC3,
    SUM(SDDK.SDDKNo) AS TongNo,
    SUM(SDDK.SDDKCo) AS TongCo,
    SUM(SDDK.SDDKNo) - SUM(SDDK.SDDKCo) AS SoDu
FROM TAIKHOANCAP1 TKC1
LEFT JOIN TAIKHOANCAP2 TKC2 ON TKC1.SoTKC1 = TKC2.SoTKC1
LEFT JOIN TAIKHOANCAP3 TKC3 ON TKC2.SoTKC2 = TKC3.SoTKC2
LEFT JOIN SODUDAUKY SDDK ON TKC3.SoTKC3 = SDDK.SoTKC3
GROUP BY TKC1.SoTKC1, TKC1.TenTKC1, TKC2.SoTKC2, TKC2.TenTKC2, TKC3.SoTKC3, TKC3.TenTKC3;
GO

PRINT N'✓ Đã tạo V_BangCanDoiKeToan';
GO

-- ----------------------------------------------------------
-- VIEW 14: Báo cáo kết quả kinh doanh
-- ----------------------------------------------------------
IF OBJECT_ID('V_BaoCao_KQKD', 'V') IS NOT NULL DROP VIEW V_BaoCao_KQKD;
GO

CREATE VIEW V_BaoCao_KQKD AS
SELECT 
    YEAR(HDB.NgayLapHDB) AS Nam,
    MONTH(HDB.NgayLapHDB) AS Thang,
    SUM(HDB.TriGiaTruocthueHDB) AS DoanhThuTruocThue,
    SUM(HDB.GiamGiaHDB) AS ChietKhau,
    SUM(HDB.TriGiaSauGiam) AS DoanhThuThuan,
    SUM(HDB.TriGiaSauthueHDB - HDB.TriGiaTruocthueHDB) AS Thue,
    SUM(HDB.TriGiaSauGiam) * 0.7 AS GiaVonUocTinh,
    SUM(HDB.TriGiaSauGiam) * 0.3 AS LoiNhuanGopUocTinh
FROM HOADONBAN HDB
GROUP BY YEAR(HDB.NgayLapHDB), MONTH(HDB.NgayLapHDB);
GO

PRINT N'✓ Đã tạo V_BaoCao_KQKD';
GO

-- ----------------------------------------------------------
-- VIEW 15: Đơn hàng theo trạng thái
-- ----------------------------------------------------------
IF OBJECT_ID('V_DonHang_TheoTrangThai', 'V') IS NOT NULL DROP VIEW V_DonHang_TheoTrangThai;
GO

CREATE VIEW V_DonHang_TheoTrangThai AS
SELECT 
    DDH.MaDDH,
    DDH.NgayDatHang,
    KH.TenKH,
    NV.HoTenNV AS NhanVienPhuTrach,
    DDH.TriGiaDH,
    DDH.TienCoc,
    DDH.TrangThaiDH,
    DDH.PhuongThucThanhToan,
    DATEDIFF(DAY, DDH.NgayDatHang, DDH.NgayGiaoHang) AS SoNgayGiao,
    CASE 
        WHEN DDH.TrangThaiDH = N'Đã hủy' THEN N'Đơn hủy'
        WHEN DDH.TrangThaiDH = N'Đã giao' THEN N'Hoàn thành'
        WHEN DATEDIFF(DAY, DDH.NgayDatHang, GETDATE()) > 7 THEN N'Chậm tiến độ'
        ELSE N'Bình thường'
    END AS TinhTrangXuLy
FROM DONDATHANG DDH
INNER JOIN KHACHHANG KH ON DDH.MaKH = KH.MaKH
INNER JOIN NHANVIEN NV ON DDH.MaNV = NV.MaNV;
GO

PRINT N'✓ Đã tạo V_DonHang_TheoTrangThai';
GO

PRINT N'';
PRINT N'=== HOÀN THÀNH TẠO 15 VIEWS ===';
GO

-- ============================================================
-- PHẦN 2: STORED PROCEDURES (25+ Procedures)
-- ============================================================

PRINT N'';
PRINT N'>>> ĐANG TẠO STORED PROCEDURES...';
GO

-- ----------------------------------------------------------
-- PROC 1: Nhập kho (Tự động cập nhật TONKHO)
-- ----------------------------------------------------------
IF OBJECT_ID('SP_NhapKho_SanPham', 'P') IS NOT NULL DROP PROCEDURE SP_NhapKho_SanPham;
GO

CREATE PROCEDURE SP_NhapKho_SanPham
    @MaKho CHAR(10),
    @MaSP CHAR(10),
    @SoLuong INT,
    @DonGia DECIMAL(18,2),
    @LyDoNhap NVARCHAR(255),
    @SoPN CHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Tạo số phiếu nhập tự động
        DECLARE @MaxPN INT;
        SELECT @MaxPN = ISNULL(MAX(CAST(SUBSTRING(SoPN, 3, 8) AS INT)), 0) + 1
        FROM PHIEUNHAPKHO;
        SET @SoPN = 'PN' + RIGHT('00000000' + CAST(@MaxPN AS VARCHAR), 8);
        
        -- Thêm phiếu nhập kho
        INSERT INTO PHIEUNHAPKHO (SoPN, MaKho, NgayNhap, LyDoNhap, TriGiaNhap)
        VALUES (@SoPN, @MaKho, GETDATE(), @LyDoNhap, @SoLuong * @DonGia);
        
        -- Cập nhật hoặc thêm mới TONKHO
        IF EXISTS (SELECT 1 FROM TONKHO WHERE MaKho = @MaKho AND MaSP = @MaSP)
        BEGIN
            UPDATE TONKHO
            SET SLNhapTrongKy = SLNhapTrongKy + @SoLuong,
                SLTonCuoiKy = SLTonCuoiKy + @SoLuong,
                TGNhapTrongKy = TGNhapTrongKy + (@SoLuong * @DonGia),
                NgayCapNhatKho = CAST(GETDATE() AS DATE)
            WHERE MaKho = @MaKho AND MaSP = @MaSP;
        END
        ELSE
        BEGIN
            INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, 
                               SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy,
                               TGNhapTruocKy, TGXuatTruocKy, NgayCapNhatKho)
            VALUES (@MaKho, @MaSP, 0, @SoLuong, @SoLuong, 0, 0, 
                   @SoLuong * @DonGia, 0, 0, 0, CAST(GETDATE() AS DATE));
        END
        
        COMMIT TRANSACTION;
        PRINT N'✓ Nhập kho thành công. Số phiếu: ' + @SoPN;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END;
GO

PRINT N'✓ Đã tạo SP_NhapKho_SanPham';
GO

-- ----------------------------------------------------------
-- PROC 2: Xuất kho (Tự động cập nhật TONKHO)
-- ----------------------------------------------------------
IF OBJECT_ID('SP_XuatKho_SanPham', 'P') IS NOT NULL DROP PROCEDURE SP_XuatKho_SanPham;
GO

CREATE PROCEDURE SP_XuatKho_SanPham
    @MaKho CHAR(10),
    @MaSP CHAR(10),
    @SoLuong INT,
    @DonGia DECIMAL(18,2),
    @LyDoXuat NVARCHAR(255),
    @SoPX CHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Kiểm tra tồn kho
        DECLARE @TonKhoHienTai INT;
        SELECT @TonKhoHienTai = SLTonCuoiKy 
        FROM TONKHO 
        WHERE MaKho = @MaKho AND MaSP = @MaSP;
        
        IF @TonKhoHienTai IS NULL OR @TonKhoHienTai < @SoLuong
        BEGIN
            DECLARE @TenSP NVARCHAR(50);
            SELECT @TenSP = TenSP FROM SANPHAM WHERE MaSP = @MaSP;
            RAISERROR(N'Không đủ hàng "%s" trong kho %s! Tồn: %d, Cần xuất: %d', 
                     16, 1, @TenSP, @MaKho, @TonKhoHienTai, @SoLuong);
            RETURN;
        END
        
        -- Tạo số phiếu xuất tự động
        DECLARE @MaxPX INT;
        SELECT @MaxPX = ISNULL(MAX(CAST(SUBSTRING(SoPX, 3, 8) AS INT)), 0) + 1
        FROM PHIEUXUAT;
        SET @SoPX = 'PX' + RIGHT('00000000' + CAST(@MaxPX AS VARCHAR), 8);
        
        -- Thêm phiếu xuất kho
        INSERT INTO PHIEUXUAT (SoPX, NgayXuat, TrangThaiPX, TriGiaPX, LyDoXuat)
        VALUES (@SoPX, CAST(GETDATE() AS DATE), N'Đã xuất', @SoLuong * @DonGia, @LyDoXuat);
        
        -- Thêm chi tiết phiếu xuất
        INSERT INTO CT_PX (SoPX, MaKho, SLXuat, DGXuat, ThanhTienXuat)
        VALUES (@SoPX, @MaKho, @SoLuong, @DonGia, @SoLuong * @DonGia);
        
        -- Cập nhật TONKHO
        UPDATE TONKHO
        SET SLXuatTrongKy = SLXuatTrongKy + @SoLuong,
            SLTonCuoiKy = SLTonCuoiKy - @SoLuong,
            TGXuatTrongKy = TGXuatTrongKy + (@SoLuong * @DonGia),
            NgayCapNhatKho = CAST(GETDATE() AS DATE)
        WHERE MaKho = @MaKho AND MaSP = @MaSP;
        
        COMMIT TRANSACTION;
        PRINT N'✓ Xuất kho thành công. Số phiếu: ' + @SoPX;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END;
GO

PRINT N'✓ Đã tạo SP_XuatKho_SanPham';
GO

-- ----------------------------------------------------------
-- PROC 3: Tạo đơn đặt hàng
-- ----------------------------------------------------------
IF OBJECT_ID('SP_TaoDonDatHang', 'P') IS NOT NULL DROP PROCEDURE SP_TaoDonDatHang;
GO

CREATE PROCEDURE SP_TaoDonDatHang
    @MaKH CHAR(10),
    @MaNV CHAR(10),
    @NgayGiaoHang DATETIME,
    @TienCoc DECIMAL(18,2),
    @PhuongThucThanhToan NVARCHAR(50),
    @GhiChu NVARCHAR(255),
    @MaDDH CHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Tạo mã đơn đặt hàng tự động
        DECLARE @MaxDDH INT;
        SELECT @MaxDDH = ISNULL(MAX(CAST(SUBSTRING(MaDDH, 4, 7) AS INT)), 0) + 1
        FROM DONDATHANG;
        SET @MaDDH = 'DDH' + RIGHT('0000000' + CAST(@MaxDDH AS VARCHAR), 7);
        
        -- Kiểm tra khách hàng và nhân viên tồn tại
        IF NOT EXISTS (SELECT 1 FROM KHACHHANG WHERE MaKH = @MaKH)
        BEGIN
            RAISERROR(N'Mã khách hàng không tồn tại!', 16, 1);
            RETURN;
        END
        
        IF NOT EXISTS (SELECT 1 FROM NHANVIEN WHERE MaNV = @MaNV)
        BEGIN
            RAISERROR(N'Mã nhân viên không tồn tại!', 16, 1);
            RETURN;
        END
        
        -- Thêm đơn đặt hàng
        INSERT INTO DONDATHANG (
            MaDDH, MaKH, MaNV, NgayDatHang, NgayGiaoHang, NgayThanhToan,
            TienCoc, TriGiaDH, TrangThaiDH, PhuongThucThanhToan, SoLanGiaoHang, GhiChuDH
        )
        VALUES (
            @MaDDH, @MaKH, @MaNV, GETDATE(), @NgayGiaoHang, NULL,
            @TienCoc, 0, N'Đang xử lý', @PhuongThucThanhToan, 0, @GhiChu
        );
        
        COMMIT TRANSACTION;
        PRINT N'✓ Tạo đơn đặt hàng thành công. Mã đơn: ' + @MaDDH;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END;
GO

PRINT N'✓ Đã tạo SP_TaoDonDatHang';
GO

-- ----------------------------------------------------------
-- PROC 4: Thêm sản phẩm vào đơn hàng
-- ----------------------------------------------------------
IF OBJECT_ID('SP_ThemSanPhamVaoDonHang', 'P') IS NOT NULL DROP PROCEDURE SP_ThemSanPhamVaoDonHang;
GO

CREATE PROCEDURE SP_ThemSanPhamVaoDonHang
    @MaDDH CHAR(10),
    @MaSP CHAR(10),
    @SoLuong INT,
    @DonGia DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Kiểm tra đơn hàng tồn tại
        IF NOT EXISTS (SELECT 1 FROM DONDATHANG WHERE MaDDH = @MaDDH)
        BEGIN
            RAISERROR(N'Mã đơn đặt hàng không tồn tại!', 16, 1);
            RETURN;
        END
        
        -- Kiểm tra sản phẩm tồn tại
        IF NOT EXISTS (SELECT 1 FROM SANPHAM WHERE MaSP = @MaSP)
        BEGIN
            RAISERROR(N'Mã sản phẩm không tồn tại!', 16, 1);
            RETURN;
        END
        
        -- Thêm chi tiết đơn hàng
        IF EXISTS (SELECT 1 FROM CT_DH WHERE MaDDH = @MaDDH AND MaSP = @MaSP)
        BEGIN
            -- Cập nhật số lượng nếu đã có
            UPDATE CT_DH
            SET SoLuongDDH = SoLuongDDH + @SoLuong
            WHERE MaDDH = @MaDDH AND MaSP = @MaSP;
        END
        ELSE
        BEGIN
            -- Thêm mới
            INSERT INTO CT_DH (MaDDH, MaSP, SoLuongDDH, DonGiaDDH)
            VALUES (@MaDDH, @MaSP, @SoLuong, @DonGia);
        END
        
        -- Cập nhật tổng giá trị đơn hàng
        UPDATE DONDATHANG
        SET TriGiaDH = (
            SELECT SUM(SoLuongDDH * DonGiaDDH)
            FROM CT_DH
            WHERE MaDDH = @MaDDH
        )
        WHERE MaDDH = @MaDDH;
        
        COMMIT TRANSACTION;
        PRINT N'✓ Thêm sản phẩm vào đơn hàng thành công!';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END;
GO

PRINT N'✓ Đã tạo SP_ThemSanPhamVaoDonHang';
GO

-- ----------------------------------------------------------
-- PROC 5: Tạo hóa đơn từ đơn đặt hàng
-- ----------------------------------------------------------
IF OBJECT_ID('SP_TaoHoaDonBan', 'P') IS NOT NULL DROP PROCEDURE SP_TaoHoaDonBan;
GO

CREATE PROCEDURE SP_TaoHoaDonBan
    @MaDDH CHAR(10),
    @GiamGia DECIMAL(18,2) = 0,
    @SoHDB CHAR(10) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Kiểm tra đơn hàng tồn tại
        IF NOT EXISTS (SELECT 1 FROM DONDATHANG WHERE MaDDH = @MaDDH)
        BEGIN
            RAISERROR(N'Mã đơn đặt hàng không tồn tại!', 16, 1);
            RETURN;
        END
        
        -- Lấy thông tin đơn hàng
        DECLARE @TriGiaDH DECIMAL(18,2), @TienCoc DECIMAL(18,2);
        SELECT @TriGiaDH = TriGiaDH, @TienCoc = TienCoc
        FROM DONDATHANG
        WHERE MaDDH = @MaDDH;
        
        -- Tính toán
        DECLARE @TriGiaTruocThue DECIMAL(18,2) = @TriGiaDH;
        DECLARE @Thue DECIMAL(18,2) = @TriGiaTruocThue * 0.1; -- VAT 10%
        DECLARE @TriGiaSauThue DECIMAL(18,2) = @TriGiaTruocThue + @Thue;
        DECLARE @TriGiaSauGiam DECIMAL(18,2) = @TriGiaSauThue - @GiamGia;
        
        -- Tạo số hóa đơn tự động
        DECLARE @MaxHDB INT;
        SELECT @MaxHDB = ISNULL(MAX(CAST(SUBSTRING(SoHDB, 4, 7) AS INT)), 0) + 1
        FROM HOADONBAN;
        SET @SoHDB = 'HDB' + RIGHT('0000000' + CAST(@MaxHDB AS VARCHAR), 7);
        
        -- Thêm hóa đơn
        INSERT INTO HOADONBAN (
            SoHDB, MaDDH, NgayLapHDB, TiencocHDB, TriGiaTruocthueHDB,
            TriGiaSauthueHDB, GiamGiaHDB, TriGiaSauGiam
        )
        VALUES (
            @SoHDB, @MaDDH, CAST(GETDATE() AS DATE), @TienCoc, @TriGiaTruocThue,
            @TriGiaSauThue, @GiamGia, @TriGiaSauGiam
        );
        
        -- Cập nhật trạng thái đơn hàng
        UPDATE DONDATHANG
        SET TrangThaiDH = N'Đã giao',
            NgayThanhToan = GETDATE()
        WHERE MaDDH = @MaDDH;
        
        COMMIT TRANSACTION;
        PRINT N'✓ Tạo hóa đơn thành công. Số HĐ: ' + @SoHDB;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END;
GO

PRINT N'✓ Đã tạo SP_TaoHoaDonBan';
GO

-- ----------------------------------------------------------
-- PROC 6: Báo cáo doanh thu
-- ----------------------------------------------------------
IF OBJECT_ID('SP_BaoCaoDoanhThu', 'P') IS NOT NULL DROP PROCEDURE SP_BaoCaoDoanhThu;
GO

CREATE PROCEDURE SP_BaoCaoDoanhThu
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        CONVERT(DATE, HDB.NgayLapHDB) AS Ngay,
        COUNT(DISTINCT HDB.SoHDB) AS SoHoaDon,
        COUNT(DISTINCT HDB.MaDDH) AS SoDonHang,
        SUM(HDB.TriGiaTruocthueHDB) AS TongDoanhThu,
        SUM(HDB.GiamGiaHDB) AS TongChietKhau,
        SUM(HDB.TriGiaSauGiam) AS DoanhThuThucTe,
        AVG(HDB.TriGiaSauGiam) AS GiaTriTrungBinh
    FROM HOADONBAN HDB
    WHERE HDB.NgayLapHDB BETWEEN @TuNgay AND @DenNgay
    GROUP BY CONVERT(DATE, HDB.NgayLapHDB)
    ORDER BY Ngay DESC;
END;
GO

PRINT N'✓ Đã tạo SP_BaoCaoDoanhThu';
GO

-- ----------------------------------------------------------
-- PROC 7: Kiểm kê tồn kho
-- ----------------------------------------------------------
IF OBJECT_ID('SP_KiemKeTonKho', 'P') IS NOT NULL DROP PROCEDURE SP_KiemKeTonKho;
GO

CREATE PROCEDURE SP_KiemKeTonKho
    @MaKho CHAR(10) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        K.MaKho,
        K.TenKho,
        TK.MaSP,
        SP.TenSP,
        TK.SLTonDauKy AS TonDauKy,
        TK.SLNhapTrongKy AS SoLuongNhap,
        TK.SLXuatTrongKy AS SoLuongXuat,
        TK.SLTonCuoiKy AS TonHienTai,
        TK.TGNhapTrongKy AS TriGiaTon,
        TK.NgayCapNhatKho AS NgayCapNhat,
        CASE 
            WHEN TK.SLTonCuoiKy = 0 THEN N'Hết hàng'
            WHEN TK.SLTonCuoiKy < 100 THEN N'Nguy cấp'
            WHEN TK.SLTonCuoiKy < 300 THEN N'Cảnh báo'
            WHEN TK.SLTonCuoiKy < 500 THEN N'Thấp'
            ELSE N'Bình thường'
        END AS TrangThai
    FROM TONKHO TK
    INNER JOIN KHO K ON TK.MaKho = K.MaKho
    INNER JOIN SANPHAM SP ON TK.MaSP = SP.MaSP
    WHERE (@MaKho IS NULL OR K.MaKho = @MaKho)
    ORDER BY K.MaKho, TK.MaSP;
END;
GO

PRINT N'✓ Đã tạo SP_KiemKeTonKho';
GO

-- ----------------------------------------------------------
-- PROC 8: Cập nhật giá sản phẩm hàng loạt
-- ----------------------------------------------------------
IF OBJECT_ID('SP_CapNhatGiaSanPham', 'P') IS NOT NULL DROP PROCEDURE SP_CapNhatGiaSanPham;
GO

CREATE PROCEDURE SP_CapNhatGiaSanPham
    @MaLoaiSP CHAR(10),
    @TyLeThayDoi DECIMAL(5,2) -- VD: 10 = tăng 10%, -5 = giảm 5%
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        
        UPDATE SANPHAM
        SET GiaBanSP = GiaBanSP * (1 + @TyLeThayDoi / 100)
        WHERE MaLoaiSP = @MaLoaiSP;
        
        DECLARE @SoSP INT = @@ROWCOUNT;
        
        COMMIT TRANSACTION;
        PRINT N'✓ Đã cập nhật giá cho ' + CAST(@SoSP AS NVARCHAR) + N' sản phẩm';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMsg NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMsg, 16, 1);
    END CATCH
END;
GO

PRINT N'✓ Đã tạo SP_CapNhatGiaSanPham';
GO

PRINT N'';
PRINT N'=== HOÀN THÀNH TẠO 8 STORED PROCEDURES ===';
GO

-- ============================================================
-- PHẦN 3: TRIGGERS (15+ Triggers)
-- ============================================================

PRINT N'';
PRINT N'>>> ĐANG TẠO TRIGGERS...';
GO

-- ----------------------------------------------------------
-- TRIGGER 1: Tự động tính tổng tiền phiếu xuất
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_PhieuXuat_TinhTong', 'TR') IS NOT NULL DROP TRIGGER TRG_PhieuXuat_TinhTong;
GO

CREATE TRIGGER TRG_PhieuXuat_TinhTong
ON CT_PX
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Cập nhật tổng tiền cho phiếu xuất liên quan
    UPDATE PX
    SET TriGiaPX = (
        SELECT ISNULL(SUM(ThanhTienXuat), 0)
        FROM CT_PX
        WHERE SoPX = PX.SoPX
    )
    FROM PHIEUXUAT PX
    WHERE PX.SoPX IN (
        SELECT SoPX FROM inserted
        UNION
        SELECT SoPX FROM deleted
    );
END;
GO

PRINT N'✓ Đã tạo TRG_PhieuXuat_TinhTong';
GO

-- ----------------------------------------------------------
-- TRIGGER 2: Tự động tính thành tiền chi tiết phiếu nhập
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_ChiTietPN_TinhThanhTien', 'TR') IS NOT NULL DROP TRIGGER TRG_ChiTietPN_TinhThanhTien;
GO

CREATE TRIGGER TRG_ChiTietPN_TinhThanhTien
ON CHITIET_PN
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE CTPN
    SET ThanhTienNhap = i.SoLuongNhap * i.DonGiaNhap
    FROM CHITIET_PN CTPN
    INNER JOIN inserted i ON CTPN.MaNL = i.MaNL AND CTPN.SoPN = i.SoPN;
END;
GO

PRINT N'✓ Đã tạo TRG_ChiTietPN_TinhThanhTien';
GO

-- ----------------------------------------------------------
-- TRIGGER 3: Tự động tính thành tiền chi tiết phiếu xuất
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_ChiTietPX_TinhThanhTien', 'TR') IS NOT NULL DROP TRIGGER TRG_ChiTietPX_TinhThanhTien;
GO

CREATE TRIGGER TRG_ChiTietPX_TinhThanhTien
ON CT_PX
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE CTPX
    SET ThanhTienXuat = i.SLXuat * i.DGXuat
    FROM CT_PX CTPX
    INNER JOIN inserted i ON CTPX.SoPX = i.SoPX AND CTPX.MaKho = i.MaKho;
END;
GO

PRINT N'✓ Đã tạo TRG_ChiTietPX_TinhThanhTien';
GO

-- ----------------------------------------------------------
-- TRIGGER 4: Audit log cho bảng SANPHAM
-- ----------------------------------------------------------
-- Tạo bảng log trước
IF OBJECT_ID('LOG_SanPham', 'U') IS NULL
BEGIN
    CREATE TABLE LOG_SanPham (
        LogID INT IDENTITY(1,1) PRIMARY KEY,
        MaSP CHAR(10),
        ThaoTac NVARCHAR(20), -- INSERT, UPDATE, DELETE
        GiaCu DECIMAL(18,2),
        GiaMoi DECIMAL(18,2),
        NguoiThucHien NVARCHAR(50),
        ThoiGian DATETIME DEFAULT GETDATE()
    );
    PRINT N'✓ Đã tạo bảng LOG_SanPham';
END
GO

IF OBJECT_ID('TRG_SanPham_AuditLog', 'TR') IS NOT NULL DROP TRIGGER TRG_SanPham_AuditLog;
GO

CREATE TRIGGER TRG_SanPham_AuditLog
ON SANPHAM
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Log INSERT
    IF EXISTS (SELECT * FROM inserted) AND NOT EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO LOG_SanPham (MaSP, ThaoTac, GiaCu, GiaMoi, NguoiThucHien)
        SELECT MaSP, N'INSERT', NULL, GiaBanSP, SYSTEM_USER
        FROM inserted;
    END
    
    -- Log UPDATE
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO LOG_SanPham (MaSP, ThaoTac, GiaCu, GiaMoi, NguoiThucHien)
        SELECT i.MaSP, N'UPDATE', d.GiaBanSP, i.GiaBanSP, SYSTEM_USER
        FROM inserted i
        INNER JOIN deleted d ON i.MaSP = d.MaSP
        WHERE i.GiaBanSP != d.GiaBanSP;
    END
    
    -- Log DELETE
    IF NOT EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
    BEGIN
        INSERT INTO LOG_SanPham (MaSP, ThaoTac, GiaCu, GiaMoi, NguoiThucHien)
        SELECT MaSP, N'DELETE', GiaBanSP, NULL, SYSTEM_USER
        FROM deleted;
    END
END;
GO

PRINT N'✓ Đã tạo TRG_SanPham_AuditLog';
GO

-- ----------------------------------------------------------
-- TRIGGER 5: Kiểm tra công nợ khách hàng
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_KiemTraCongNoKH', 'TR') IS NOT NULL DROP TRIGGER TRG_KiemTraCongNoKH;
GO

CREATE TRIGGER TRG_KiemTraCongNoKH
ON DONDATHANG
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @MaKH CHAR(10), @CongNo FLOAT, @TriGiaDH DECIMAL(18,2);
    DECLARE @HanMucCongNo FLOAT = 100000000; -- 100 triệu
    
    SELECT @MaKH = MaKH, @TriGiaDH = TriGiaDH FROM inserted;
    SELECT @CongNo = CongNoKH FROM KHACHHANG WHERE MaKH = @MaKH;
    
    IF @CongNo + @TriGiaDH > @HanMucCongNo
    BEGIN
        RAISERROR(N'Cảnh báo: Công nợ khách hàng vượt hạn mức cho phép!', 10, 1);
    END
END;
GO

PRINT N'✓ Đã tạo TRG_KiemTraCongNoKH';
GO

-- ----------------------------------------------------------
-- TRIGGER 6: Tự động cập nhật trạng thái đơn hàng
-- ----------------------------------------------------------
IF OBJECT_ID('TRG_CapNhatTrangThaiDH', 'TR') IS NOT NULL DROP TRIGGER TRG_CapNhatTrangThaiDH;
GO

CREATE TRIGGER TRG_CapNhatTrangThaiDH
ON HOADONBAN
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE DDH
    SET TrangThaiDH = N'Đã giao',
        NgayThanhToan = GETDATE()
    FROM DONDATHANG DDH
    INNER JOIN inserted i ON DDH.MaDDH = i.MaDDH;
END;
GO

PRINT N'✓ Đã tạo TRG_CapNhatTrangThaiDH';
GO

PRINT N'';
PRINT N'=== HOÀN THÀNH TẠO 6 TRIGGERS ===';
GO

-- ============================================================
-- PHẦN 4: FUNCTIONS (12+ Functions)
-- ============================================================

PRINT N'';
PRINT N'>>> ĐANG TẠO FUNCTIONS...';
GO

-- ----------------------------------------------------------
-- FUNCTION 1: Tính tổng tồn kho của một sản phẩm
-- ----------------------------------------------------------
IF OBJECT_ID('FN_TinhTongTonKho', 'FN') IS NOT NULL DROP FUNCTION FN_TinhTongTonKho;
GO

CREATE FUNCTION FN_TinhTongTonKho
(
    @MaSP CHAR(10)
)
RETURNS INT
AS
BEGIN
    DECLARE @TongTon INT;
    
    SELECT @TongTon = ISNULL(SUM(SLTonCuoiKy), 0)
    FROM TONKHO
    WHERE MaSP = @MaSP;
    
    RETURN ISNULL(@TongTon, 0);
END;
GO

PRINT N'✓ Đã tạo FN_TinhTongTonKho';
GO

-- ----------------------------------------------------------
-- FUNCTION 2: Kiểm tra sản phẩm có đủ hàng không
-- ----------------------------------------------------------
IF OBJECT_ID('FN_KiemTraDuHang', 'FN') IS NOT NULL DROP FUNCTION FN_KiemTraDuHang;
GO

CREATE FUNCTION FN_KiemTraDuHang
(
    @MaSP CHAR(10),
    @SoLuongCan INT
)
RETURNS BIT
AS
BEGIN
    DECLARE @TongTon INT;
    
    SELECT @TongTon = ISNULL(SUM(SLTonCuoiKy), 0)
    FROM TONKHO
    WHERE MaSP = @MaSP;
    
    IF @TongTon >= @SoLuongCan
        RETURN 1;
    
    RETURN 0;
END;
GO

PRINT N'✓ Đã tạo FN_KiemTraDuHang';
GO

-- ----------------------------------------------------------
-- FUNCTION 3: Tính giá trị tồn kho
-- ----------------------------------------------------------
IF OBJECT_ID('FN_TinhGiaTriTonKho', 'FN') IS NOT NULL DROP FUNCTION FN_TinhGiaTriTonKho;
GO

CREATE FUNCTION FN_TinhGiaTriTonKho
(
    @MaSP CHAR(10)
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @GiaTri DECIMAL(18,2);
    
    SELECT @GiaTri = ISNULL(SUM(TGNhapTrongKy), 0)
    FROM TONKHO
    WHERE MaSP = @MaSP;
    
    RETURN ISNULL(@GiaTri, 0);
END;
GO

PRINT N'✓ Đã tạo FN_TinhGiaTriTonKho';
GO

-- ----------------------------------------------------------
-- FUNCTION 4: Tính tổng doanh thu khách hàng
-- ----------------------------------------------------------
IF OBJECT_ID('FN_TinhDoanhThuKH', 'FN') IS NOT NULL DROP FUNCTION FN_TinhDoanhThuKH;
GO

CREATE FUNCTION FN_TinhDoanhThuKH
(
    @MaKH CHAR(10)
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @TongDoanhThu DECIMAL(18,2);
    
    SELECT @TongDoanhThu = ISNULL(SUM(HDB.TriGiaSauGiam), 0)
    FROM HOADONBAN HDB
    INNER JOIN DONDATHANG DDH ON HDB.MaDDH = DDH.MaDDH
    WHERE DDH.MaKH = @MaKH;
    
    RETURN ISNULL(@TongDoanhThu, 0);
END;
GO

PRINT N'✓ Đã tạo FN_TinhDoanhThuKH';
GO

-- ----------------------------------------------------------
-- FUNCTION 5: Lấy tên sản phẩm
-- ----------------------------------------------------------
IF OBJECT_ID('FN_LayTenSanPham', 'FN') IS NOT NULL DROP FUNCTION FN_LayTenSanPham;
GO

CREATE FUNCTION FN_LayTenSanPham
(
    @MaSP CHAR(10)
)
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @TenSP NVARCHAR(50);
    
    SELECT @TenSP = TenSP
    FROM SANPHAM
    WHERE MaSP = @MaSP;
    
    RETURN @TenSP;
END;
GO

PRINT N'✓ Đã tạo FN_LayTenSanPham';
GO

-- ----------------------------------------------------------
-- FUNCTION 6: Tính thuế VAT
-- ----------------------------------------------------------
IF OBJECT_ID('FN_TinhThueVAT', 'FN') IS NOT NULL DROP FUNCTION FN_TinhThueVAT;
GO

CREATE FUNCTION FN_TinhThueVAT
(
    @GiaTruocThue DECIMAL(18,2),
    @TyLeThue DECIMAL(5,2) = 10
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    RETURN @GiaTruocThue * (@TyLeThue / 100);
END;
GO

PRINT N'✓ Đã tạo FN_TinhThueVAT';
GO

-- ----------------------------------------------------------
-- FUNCTION 7: Lấy thông tin chi tiết sản phẩm (Table Function)
-- ----------------------------------------------------------
IF OBJECT_ID('FN_ThongTinSanPham', 'IF') IS NOT NULL DROP FUNCTION FN_ThongTinSanPham;
GO

CREATE FUNCTION FN_ThongTinSanPham
(
    @MaSP CHAR(10)
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        SP.MaSP,
        SP.TenSP,
        LSP.TenLoaiSP,
        SP.GiaBanSP,
        SP.MoTa,
        dbo.FN_TinhTongTonKho(SP.MaSP) AS SoLuongTon,
        dbo.FN_TinhGiaTriTonKho(SP.MaSP) AS GiaTriTon
    FROM SANPHAM SP
    LEFT JOIN LOAISANPHAM LSP ON SP.MaLoaiSP = LSP.MaLoaiSP
    WHERE SP.MaSP = @MaSP
);
GO

PRINT N'✓ Đã tạo FN_ThongTinSanPham';
GO

PRINT N'';
PRINT N'=== HOÀN THÀNH TẠO 7 FUNCTIONS ===';
GO

-- ============================================================
-- PHẦN 5: INDEXES (Tối ưu hiệu suất)
-- ============================================================

PRINT N'';
PRINT N'>>> ĐANG TẠO INDEXES...';
GO

-- Indexes cho TONKHO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_TONKHO_MaSP')
    CREATE INDEX IX_TONKHO_MaSP ON TONKHO(MaSP);
PRINT N'✓ Đã tạo IX_TONKHO_MaSP';
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_TONKHO_NgayCapNhat')
    CREATE INDEX IX_TONKHO_NgayCapNhat ON TONKHO(NgayCapNhatKho);
PRINT N'✓ Đã tạo IX_TONKHO_NgayCapNhat';
GO

-- Indexes cho DONDATHANG
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DDH_MaKH')
    CREATE INDEX IX_DDH_MaKH ON DONDATHANG(MaKH);
PRINT N'✓ Đã tạo IX_DDH_MaKH';
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DDH_NgayDat')
    CREATE INDEX IX_DDH_NgayDat ON DONDATHANG(NgayDatHang);
PRINT N'✓ Đã tạo IX_DDH_NgayDat';
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_DDH_TrangThai')
    CREATE INDEX IX_DDH_TrangThai ON DONDATHANG(TrangThaiDH);
PRINT N'✓ Đã tạo IX_DDH_TrangThai';
GO

-- Indexes cho HOADONBAN
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HDB_NgayLap')
    CREATE INDEX IX_HDB_NgayLap ON HOADONBAN(NgayLapHDB);
PRINT N'✓ Đã tạo IX_HDB_NgayLap';
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HDB_MaDDH')
    CREATE INDEX IX_HDB_MaDDH ON HOADONBAN(MaDDH);
PRINT N'✓ Đã tạo IX_HDB_MaDDH';
GO

-- Indexes cho PHIEUNHAPKHO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PNK_NgayNhap')
    CREATE INDEX IX_PNK_NgayNhap ON PHIEUNHAPKHO(NgayNhap);
PRINT N'✓ Đã tạo IX_PNK_NgayNhap';
GO

-- Indexes cho PHIEUXUAT
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PX_NgayXuat')
    CREATE INDEX IX_PX_NgayXuat ON PHIEUXUAT(NgayXuat);
PRINT N'✓ Đã tạo IX_PX_NgayXuat';
GO

-- Indexes cho KHACHHANG
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_KH_TenKH')
    CREATE INDEX IX_KH_TenKH ON KHACHHANG(TenKH);
PRINT N'✓ Đã tạo IX_KH_TenKH';
GO

-- Indexes cho SANPHAM
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SP_TenSP')
    CREATE INDEX IX_SP_TenSP ON SANPHAM(TenSP);
PRINT N'✓ Đã tạo IX_SP_TenSP';
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_SP_MaLoaiSP')
    CREATE INDEX IX_SP_MaLoaiSP ON SANPHAM(MaLoaiSP);
PRINT N'✓ Đã tạo IX_SP_MaLoaiSP';
GO

-- Indexes cho BUTTOAN
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_BT_NgayHachToan')
    CREATE INDEX IX_BT_NgayHachToan ON BUTTOAN(NgayHachToan);
PRINT N'✓ Đã tạo IX_BT_NgayHachToan';
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_BT_TKNo')
    CREATE INDEX IX_BT_TKNo ON BUTTOAN(TKNo);
PRINT N'✓ Đã tạo IX_BT_TKNo';
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_BT_TKCo')
    CREATE INDEX IX_BT_TKCo ON BUTTOAN(TKCo);
PRINT N'✓ Đã tạo IX_BT_TKCo';
GO

PRINT N'';
PRINT N'=== HOÀN THÀNH TẠO 15 INDEXES ===';
GO

-- ============================================================
-- KẾT THÚC
-- ============================================================
















































-- ============================================================
-- PHẦN 1: CHÈN DỮ LIỆU CƠ SỞ (ĐÃ SẮP XẾP MÃ LIỀN MẠCH & NĂM 2025)
-- ============================================================

-- 1. PHONGBAN (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu Bảng PHONGBAN (10 dòng)...';
    INSERT INTO PHONGBAN (MaPB, TenPB, DTPB, EmailPB)
    VALUES
    ('PB001', N'Kinh Doanh', '0281234567', 'kd@acecook.vn'),
    ('PB002', N'Sản Xuất', '0281234568', 'sx@acecook.vn'),
    ('PB003', N'Kho', '0281234569', 'kho@acecook.vn'),
    ('PB004', N'Kế Toán', '0281234570', 'kt@acecook.vn'),
    ('PB005', N'Marketing', '0281234571', 'mkt@acecook.vn'),
    ('PB006', N'Nhân Sự', '0281234572', 'hr@acecook.vn'),
    ('PB007', N'R&D', '0281234573', 'rd@acecook.vn'),
    ('PB008', N'IT', '0281234574', 'it@acecook.vn'),
    ('PB009', N'Quản Lý Chất Lượng', '0281234575', 'qa@acecook.vn'),
    ('PB010', N'Pháp Chế', '0281234576', 'legal@acecook.vn');
    COMMIT TRAN;
    PRINT N'✓ Chèn dữ liệu PHONGBAN thành công.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu PHONGBAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 2. CHUCVU (10 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu Bảng CHUCVU (10 dòng)...';
    INSERT INTO CHUCVU (MaCV, TenCV, GhiChuCV)
    VALUES
    ('CV001', N'Giám đốc', N'Quản lý chung'),
    ('CV002', N'Trưởng phòng', N'Quản lý cấp phòng ban'),
    ('CV003', N'Nhân viên Kế toán', N'Chịu trách nhiệm sổ sách'),
    ('CV004', N'Nhân viên Kinh doanh', N'Thực hiện bán hàng'),
    ('CV005', N'Thủ kho', N'Quản lý kho hàng'),
    ('CV006', N'Kỹ sư sản xuất', N'Quản lý dây chuyền'),
    ('CV007', N'Nhân viên Marketing', N'Quảng bá sản phẩm'),
    ('CV008', N'Chuyên viên Nhân sự', N'Tuyển dụng và đào tạo'),
    ('CV009', N'Nhân viên IT', N'Hỗ trợ kỹ thuật'),
    ('CV010', N'Quản lý dự án', N'Điều phối dự án R&D');
    COMMIT TRAN;
    PRINT N'✓ Chèn dữ liệu CHUCVU thành công.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu CHUCVU: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 3. VAITRO (19 dòng) 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO VAITRO (MaVT, TenVT, MoTaVT)
    VALUES
    ('VT001', N'Quản Trị Viên', N'Toàn quyền truy cập hệ thống'),
    ('VT002', N'Kế Toán Trưởng', N'Quản lý tài chính và kế toán'),
    ('VT003', N'Quản Lý Kinh Doanh', N'Quản lý hoạt động bán hàng'),
    ('VT004', N'Quản Lý Sản Xuất', N'Quản lý quy trình sản xuất'),
    ('VT005', N'Quản Lý Kho', N'Quản lý kho vận'),
    ('VT006', N'Nhân Viên Kế Toán', N'Xử lý nghiệp vụ kế toán'),
    ('VT007', N'Nhân Viên Bán Hàng', N'Bán hàng và chăm sóc khách'),
    ('VT008', N'Nhân Viên Kho', N'Nhập xuất kho'),
    ('VT009', N'Nhân Viên Sản Xuất', N'Vận hành máy móc'),
    ('VT010', N'Kế Toán Công Nợ', N'Quản lý công nợ'),
    ('VT011', N'Kế Toán Thanh Toán', N'Xử lý thanh toán'),
    ('VT012', N'Giám Sát Bán Hàng', N'Giám sát nhân viên bán hàng'),
    ('VT013', N'Giám Sát Kho', N'Giám sát hoạt động kho'),
    ('VT014', N'Trưởng Nhóm Kinh Doanh', N'Dẫn dắt nhóm bán hàng'),
    ('VT015', N'Điều Phối Sản Xuất', N'Điều phối kế hoạch sản xuất'),
    ('VT016', N'Kiểm Toán Nội Bộ', N'Kiểm tra quy trình nội bộ'),
    ('VT017', N'Nhân Viên Giao Nhận', N'Giao nhận hàng hóa'),
    ('VT018', N'Thủ Quỹ', N'Quản lý tiền mặt'),
    ('VT019', N'Nhân Viên Hỗ Trợ', N'Hỗ trợ các phòng ban');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào VAITRO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu VAITRO: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 4. QUYEN (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu Bảng QUYEN (10 dòng)...';
    INSERT INTO QUYEN (MaQuyen, TenQuyen, MoTaQuyen)
    VALUES
    ('QY001', N'Tạo mới', N'Tạo mới bản ghi'),
    ('QY002', N'Đọc', N'Xem chi tiết bản ghi'),
    ('QY003', N'Cập nhật', N'Sửa bản ghi'),
    ('QY004', N'Xóa', N'Xóa bản ghi'),
    ('QY005', N'Duyệt', N'Duyệt các giao dịch, chứng từ'),
    ('QY006', N'Hạch toán', N'Thực hiện bút toán'),
    ('QY007', N'Xuất báo cáo', N'Tải xuống báo cáo'),
    ('QY008', N'Quản lý người dùng', N'Thêm, sửa, khóa tài khoản'),
    ('QY009', N'Quản lý danh mục', N'Quản lý các bảng master'),
    ('QY010', N'Thiết lập hệ thống', N'Thay đổi cấu hình hệ thống');
    COMMIT TRAN;
    PRINT N'✓ Chèn dữ liệu QUYEN thành công.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu QUYEN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 5. LOAIKHACHHANG (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO LOAIKHACHHANG (MaLoaiKH, TenLoaiKH, GhiChuLoaiKH)
    VALUES
    ('LKH001', N'Khách Lẻ', N'Khách hàng mua lẻ'),
    ('LKH002', N'Đại Lý Cấp 1', N'Đại lý phân phối chính'),
    ('LKH003', N'Đại Lý Cấp 2', N'Đại lý phân phối phụ'),
    ('LKH004', N'Siêu Thị', N'Chuỗi siêu thị lớn'),
    ('LKH005', N'Cửa Hàng Tạp Hóa', N'Cửa hàng bán lẻ nhỏ'),
    ('LKH006', N'Nhà Hàng', N'Khách hàng nhà hàng'),
    ('LKH007', N'Khách Sạn', N'Khách hàng khách sạn'),
    ('LKH008', N'Trường Học', N'Khách hàng trường học'),
    ('LKH009', N'Bệnh Viện', N'Khách hàng bệnh viện'),
    ('LKH010', N'VIP', N'Khách hàng VIP'),
    ('LKH011', N'Khách Doanh Nghiệp', N'Khách hàng doanh nghiệp'),
    ('LKH012', N'Công Ty Xuất Khẩu', N'Khách hàng xuất khẩu'),
    ('LKH013', N'Nhà Phân Phối', N'Nhà phân phối độc quyền'),
    ('LKH014', N'Chuỗi Minimart', N'Chuỗi cửa hàng tiện lợi'),
    ('LKH015', N'Online', N'Khách hàng mua online'),
    ('LKH016', N'Co.opmart', N'Hệ thống Co.opmart'),
    ('LKH017', N'BigC', N'Hệ thống BigC'),
    ('LKH018', N'Lotte Mart', N'Hệ thống Lotte Mart'),
    ('LKH019', N'Khách Hội Chợ', N'Khách tham gia hội chợ'),
    ('LKH020', N'Đối Tác Chiến Lược', N'Đối tác lâu dài');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào LOAIKHACHHANG.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu LOAIKHACHHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 6. KHO (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO KHO (MaKho, TenKho, ViTri, SDTKho, EmailKho)
    VALUES
    ('KHO001', N'Kho Trung Tâm HCM', N'Bình Tân, TP.HCM', '0287654321', 'khotrungtam@acecook.vn'),
    ('KHO002', N'Kho Miền Bắc', N'Tỉnh Bắc Ninh', '0243456789', 'khomienbac@acecook.vn'),
    ('KHO003', N'Kho Miền Trung', N'TP. Đà Nẵng', '0236789123', 'khomientrung@acecook.vn'),
    ('KHO004', N'Kho Nguyên Liệu', N'P. Thủ Đức, TP.HCM', '0287654322', 'khonguyenlieu@acecook.vn'),
    ('KHO005', N'Kho Thành Phẩm', N'TP.HCM', '0274567890', 'khothanhpham@acecook.vn'),
    ('KHO006', N'Kho Xuất Khẩu', N'P. Thủ Đức, TP.HCM', '0287654323', 'khoxuatkhau@acecook.vn'),
    ('KHO007', N'Kho Dự Trữ 1', N'Tỉnh Tây Ninh', '0272345678', 'khodutru1@acecook.vn'),
    ('KHO008', N'Kho Dự Trữ 2', N'Tỉnh Đồng Nai', '0251234567', 'khodutru2@acecook.vn'),
    ('KHO009', N'Kho Phụ Tùng', N'Hóc Môn, TP.HCM', '0287654324', 'khophutung@acecook.vn'),
    ('KHO010', N'Kho Bao Bì', N'TP.HCM', '0274567891', 'khobaobi@acecook.vn'),
    ('KHO011', N'Kho Gia Vị', N'P.Tân Phú, TP.HCM', '0287654325', 'khogiavi@acecook.vn'),
    ('KHO012', N'Kho Tây Ninh', N'Tỉnh Tây Ninh', '0276543210', 'khotayninh@acecook.vn'),
    ('KHO013', N'Kho Cần Thơ', N'TP. Cần Thơ', '0292345678', 'khocantho@acecook.vn'),
    ('KHO014', N'Kho Hải Phòng', N'TP. Hải Phòng', '0225678901', 'khohaiphong@acecook.vn'),
    ('KHO015', N'Kho Hà Nội', N'TP. Hà Nội', '0243456790', 'khohanoi@acecook.vn'),
    ('KHO016', N'Kho Nghệ An', N'Tỉnh Nghệ An', '0238765432', 'khonghean@acecook.vn'),
    ('KHO017', N'Kho Quảng Ngãi', N'Tỉnh Quảng Ngãi', '0255678901', 'khoquangngai@acecook.vn'),
    ('KHO018', N'Kho Vũng Tàu', N'TP.HCM', '0254567890', 'khovungtau@acecook.vn'),
    ('KHO019', N'Kho Kiên Giang', N'Tỉnh An Giang', '0297654321', 'khokiengiang@acecook.vn'),
    ('KHO020', N'Kho An Giang', N'Tỉnh An Giang', '0296543210', 'khoangiang@acecook.vn');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào KHO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu KHO: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 7. NGUYENLIEU (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO NGUYENLIEU (MaNL, TenNL, DVTNL)
    VALUES
    ('NL001', N'Bột Mì', N'Kg'),
    ('NL002', N'Bột Năng', N'Kg'),
    ('NL003', N'Dầu Thực Vật', N'Lít'),
    ('NL004', N'Muối', N'Kg'),
    ('NL005', N'Đường', N'Kg'),
    ('NL006', N'Bột Ngọt', N'Kg'),
    ('NL007', N'Hạt Nêm', N'Kg'),
    ('NL008', N'Ớt Bột', N'Kg'),
    ('NL009', N'Tỏi Sấy', N'Kg'),
    ('NL010', N'Hành Khô', N'Kg'),
    ('NL011', N'Nước Tương', N'Lít'),
    ('NL012', N'Nước Mắm', N'Lít'),
    ('NL013', N'Xương Hầm', N'Kg'),
    ('NL014', N'Thịt Heo Xay', N'Kg'),
    ('NL015', N'Tôm Khô', N'Kg'),
    ('NL016', N'Rau Thơm Sấy', N'Kg'),
    ('NL017', N'Tinh Bột', N'Kg'),
    ('NL018', N'Phụ Gia Thực Phẩm', N'Kg'),
    ('NL019', N'Bao Bì Nhựa', N'Thùng'),
    ('NL020', N'Thùng Carton', N'Thùng');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào NGUYENLIEU.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu NGUYENLIEU: ' + ERROR_MESSAGE();
END CATCH;
GO

BEGIN TRANSACTION;
BEGIN TRY
    -- Cập nhật nhóm Bột/Gia vị
    UPDATE NGUYENLIEU SET SoLuongTon = 5000 WHERE MaNL = 'NL001'; -- Bột Mì
    UPDATE NGUYENLIEU SET SoLuongTon = 2000 WHERE MaNL = 'NL002'; -- Bột Năng
    UPDATE NGUYENLIEU SET SoLuongTon = 3000 WHERE MaNL = 'NL003'; -- Dầu Thực Vật
    UPDATE NGUYENLIEU SET SoLuongTon = 1500 WHERE MaNL = 'NL004'; -- Muối
    UPDATE NGUYENLIEU SET SoLuongTon = 2500 WHERE MaNL = 'NL005'; -- Đường
    UPDATE NGUYENLIEU SET SoLuongTon = 1000 WHERE MaNL = 'NL006'; -- Bột Ngọt
    UPDATE NGUYENLIEU SET SoLuongTon = 1200 WHERE MaNL = 'NL007'; -- Hạt Nêm
    UPDATE NGUYENLIEU SET SoLuongTon = 800  WHERE MaNL = 'NL008'; -- Ớt Bột
    UPDATE NGUYENLIEU SET SoLuongTon = 900  WHERE MaNL = 'NL009'; -- Tỏi Sấy
    UPDATE NGUYENLIEU SET SoLuongTon = 850  WHERE MaNL = 'NL010'; -- Hành Khô

    -- Cập nhật nhóm Nước chấm/Thực phẩm tươi
    UPDATE NGUYENLIEU SET SoLuongTon = 4000 WHERE MaNL = 'NL011'; -- Nước Tương
    UPDATE NGUYENLIEU SET SoLuongTon = 3500 WHERE MaNL = 'NL012'; -- Nước Mắm
    UPDATE NGUYENLIEU SET SoLuongTon = 500  WHERE MaNL = 'NL013'; -- Xương Hầm
    UPDATE NGUYENLIEU SET SoLuongTon = 600  WHERE MaNL = 'NL014'; -- Thịt Heo Xay
    UPDATE NGUYENLIEU SET SoLuongTon = 300  WHERE MaNL = 'NL015'; -- Tôm Khô
    UPDATE NGUYENLIEU SET SoLuongTon = 200  WHERE MaNL = 'NL016'; -- Rau Thơm Sấy
    UPDATE NGUYENLIEU SET SoLuongTon = 1500 WHERE MaNL = 'NL017'; -- Tinh Bột
    UPDATE NGUYENLIEU SET SoLuongTon = 5000 WHERE MaNL = 'NL018'; -- Phụ Gia

    -- Cập nhật nhóm Bao bì (Số lượng thường lớn)
    UPDATE NGUYENLIEU SET SoLuongTon = 20000 WHERE MaNL = 'NL019'; -- Bao Bì Nhựa
    UPDATE NGUYENLIEU SET SoLuongTon = 10000 WHERE MaNL = 'NL020'; -- Thùng Carton

    COMMIT TRANSACTION;
    PRINT N'✓ Đã cập nhật số lượng tồn kho cho 20 nguyên vật liệu.';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT N'❌ Lỗi khi cập nhật dữ liệu: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 8. LOAISANPHAM (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO LOAISANPHAM (MaLoaiSP, TenLoaiSP, GhiChuLoaiSP)
    VALUES
    ('LSP001', N'Mì Ly', N'Mì ăn liền dạng ly'),
    ('LSP002', N'Mì Gói', N'Mì ăn liền dạng gói'),
    ('LSP003', N'Hủ Tiếu', N'Hủ tiếu các loại'),
    ('LSP004', N'Phở', N'Phở bò, phở gà'),
    ('LSP005', N'Bún', N'Bún bò, bún riêu'),
    ('LSP006', N'Miến', N'Miến gà, miến lươn'),
    ('LSP007', N'Mì Tô', N'Mì dạng tô lớn'),
    ('LSP008', N'Cháo', N'Cháo thịt bằm, gà'),
    ('LSP009', N'Bún Khô', N'Bún khô trộn'),
    ('LSP010', N'Mì Xào', N'Mì xào khô'),
    ('LSP011', N'Mì Cao Cấp', N'Mì cao cấp hảo hạng'),
    ('LSP012', N'Mì Lẩu', N'Mì dùng cho lẩu'),
    ('LSP013', N'Mì Rau Củ', N'Mì có rau củ'),
    ('LSP014', N'Mì Hải Sản', N'Mì vị hải sản'),
    ('LSP015', N'Mì Kim Chi', N'Mì vị kim chi Hàn Quốc'),
    ('LSP016', N'Mì Chua Cay', N'Mì vị chua cay'),
    ('LSP017', N'Mì Vegetarian', N'Mì chay'),
    ('LSP018', N'Mì Vị Lẩu Thái', N'Mì vị lẩu Thái'),
    ('LSP019', N'Mì Trứng', N'Mì trứng tươi'),
    ('LSP020', N'Combo Set', N'Set combo nhiều sản phẩm');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào LOAISANPHAM.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu LOAISANPHAM: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 9. SANPHAM (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO SANPHAM (MaSP, MaLoaiSP, TenSP, MoTa, GiaBanSP, NhietDoBaoQuan, NSXSP, HSDSP) VALUES
('SP001', 'LSP001', N'Hảo Hảo Tôm Chua Cay Ly', N'Mì ly vị tôm chua cay 75g', 7000, N'Thường', '2025-01-01', '2026-01-01'),
('SP002', 'LSP002', N'Hảo Hảo Tôm Chua Cay Gói', N'Mì gói vị tôm chua cay 75g', 3500, N'Thường', '2025-01-15', '2026-01-15'),
('SP003', 'LSP003', N'Hủ Tiếu Nam Vang', N'Hủ tiếu Nam Vang 75g', 4000, N'Thường', '2025-02-01', '2026-02-01'),
('SP004', 'LSP004', N'Phở Bò Hảo Hảo', N'Phở bò hương vị đậm đà 73g', 4500, N'Thường', '2025-02-15', '2026-02-15'),
('SP005', 'LSP001', N'Mì Ly Bò Hầm', N'Mì ly vị bò hầm 70g', 7500, N'Thường', '2025-03-01', '2026-03-01'),
('SP006', 'LSP005', N'Bún Bò Huế', N'Bún bò Huế cay nồng 80g', 5000, N'Thường', '2025-03-15', '2026-03-15'),
('SP007', 'LSP006', N'Miến Gà Hảo Hảo', N'Miến gà thơm ngon 68g', 3800, N'Thường', '2025-04-01', '2026-04-01'),
('SP008', 'LSP007', N'Mì Tô Bò Sốt Tiêu', N'Mì tô lớn vị bò sốt tiêu 98g', 9500, N'Thường', '2025-04-15', '2026-04-15'),
('SP009', 'LSP011', N'Mì Premium Tôm Hùm', N'Mì cao cấp vị tôm hùm 85g', 12000, N'Thường', '2025-05-01', '2026-05-01'),
('SP010', 'LSP002', N'Hảo Hảo Mi Goreng', N'Mì xào khô vị goreng 75g', 4200, N'Thường', '2025-05-15', '2026-05-15'),
('SP011', 'LSP014', N'Mì Hải Sản Chua Cay', N'Mì vị hải sản chua cay 77g', 4800, N'Thường', '2025-06-01', '2026-06-01'),
('SP012', 'LSP001', N'Mì Ly Sườn Hầm', N'Mì ly vị sườn hầm 78g', 8000, N'Thường', '2025-06-15', '2026-06-15'),
('SP013', 'LSP008', N'Cháo Gà Nấm', N'Cháo gà nấm dinh dưỡng 50g', 6500, N'Thường', '2025-07-01', '2026-07-01'),
('SP014', 'LSP015', N'Mì Kim Chi', N'Mì vị kim chi Hàn Quốc 80g', 5500, N'Thường', '2025-07-15', '2026-07-15'),
('SP015', 'LSP004', N'Phở Gà Acecook', N'Phở gà truyền thống 75g', 4700, N'Thường', '2025-08-01', '2026-08-01'),
('SP016', 'LSP012', N'Mì Lẩu Thái', N'Mì lẩu Thái Tom Yum 85g', 6000, N'Thường', '2025-08-15', '2026-08-15'),
('SP017', 'LSP017', N'Mì Chay Rau Củ', N'Mì chay rau củ dinh dưỡng 70g', 4500, N'Thường', '2025-09-01', '2026-09-01'),
('SP018', 'LSP002', N'Hảo Hảo Tôm Nấm', N'Mì gói vị tôm nấm 75g', 3800, N'Thường', '2025-09-15', '2026-09-15'),
('SP019', 'LSP010', N'Mì Xào Bò Teriyaki', N'Mì xào khô bò teriyaki 82g', 5200, N'Thường', '2025-10-01', '2026-10-01'),
('SP020', 'LSP020', N'Combo 5 Hảo Hảo', N'Combo 5 gói hảo hảo đa vị', 17000, N'Thường', '2025-10-15', '2026-10-15');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào SANPHAM (Cập nhật năm 2025/2026).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu SANPHAM: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 10. KHACHHANG (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO KHACHHANG (MaKH, TenKH, SDTKH, EmailKH, DiaChiKH, MSTKH, STKKH, CongNoKH, GhiChuKH)
    VALUES
    ('KH001', N'Siêu Thị Co.opmart Lý Thường Kiệt', '0901234567', 'coopmart.ltk@gmail.com', N'88, Phường Phú Nhuận TP.HCM', '0123456789', '1234567890', 0, N'Khách VIP'),
    ('KH002', N'Siêu Thị BigC Miền Đông', '0902345678', 'bigc.miendong@gmail.com', N'206, P. Thủ Đức, TP.HCM', '0234567890', '2345678901', 5000000, N'Khách hàng lâu năm'),
    ('KH003', N'Tạp Hóa Phương Loan', '0903456789', 'taphoaloan@gmail.com', N'123, Phường Diên Hồng, TP.HCM', '0345678901', '3456789012', 2000000, NULL),
    ('KH004', N'Nhà Hàng Món Huế', '0904567890', 'nhamonhue@gmail.com', N'168-170, Phường Bến Nghé, TP.HCM', '0456789012', '4567890123', 0, N'Đặt hàng định kỳ'),
    ('KH005', N'Khách Sạn Continental Saigon', '0905678901', 'continental.hcm@gmail.com', N'456, Phường Bến Nghé, TP.HCM', '0567890123', '5678901234', 8000000, N'Khách VIP'),
    ('KH006', N'Trường THPT Lê Hồng Phong', '0906789012', 'lehongphong.school@gmail.com', N'235, Phường Chợ QUán, TP.HCM', '0678901234', '6789012345', 0, N'Khách cơ quan'),
    ('KH007', N'Bệnh Viện Chợ Rẫy', '0907890123', 'choray.hospital@gmail.com', N'123, Phường Chợ Lớn, TP.HCM', '0789012345', '7890123456', 0, N'Khách cơ quan'),
    ('KH008', N'Công Ty TNHH Thực Phẩm Tân Phát', '0908901234', 'tanphat.food@gmail.com', N'206, P. Long Trường,TP.HCM', '0890123456', '8901234567', 15000000, N'Đại lý cấp 1'),
    ('KH009', N'Siêu Thị Lotte Mart Võ Văn Ngân', '0909012345', 'lottemart.vvn@gmail.com', N'34, P. Thủ Đức, TP.HCM', '0901234560', '9012345678', 0, N'Khách VIP'),
    ('KH010', N'Circle K Nguyễn Trãi', '0910123456', 'circlek.nguyentrai@gmail.com', N'01, Phường Bàn Cờ, TP.HCM', '1012345678', '0123456781', 3000000, NULL),
    ('KH011', N'Công Ty CP Thương Mại Hồng Phát', '0911234567', 'hongphat.corp@gmail.com', N'36, Quận Đống Đa, Hà Nội', '1123456789', '1234567892', 10000000, N'Khách doanh nghiệp'),
    ('KH012', N'Minimart Gia Hưng', '0912345678', 'giahung.mart@gmail.com', N'101, Phường Cát Lái, TP.HCM', '1234567891', '2345678903', 0, NULL),
    ('KH013', N'Công Ty TNHH Phân Phối Minh Hải', '0913456789', 'minhhai.distributor@gmail.com', N'201, P. An Đông, TP.HCM', '1345678902', '3456789014', 20000000, N'Đối tác chiến lược'),
    ('KH014', N'FamilyMart Lê Văn Việt', '0914567890', 'familymart.lvv@gmail.com', N'55, P. Tăng Nhơn Phú, TP.HCM', '1456789013', '4567890125', 0, N'Khách VIP'),
    ('KH015', N'Quán Cơm Tấm Thiên Phước', '0915678901', 'thienphuoc@gmail.com', N'899, Phường Khánh Hội, TP.HCM', '1567890124', '5678901236', 1000000, NULL),
    ('KH016', N'Tạp Hóa Út Hương', '0916789012', 'uthuong.taphoa@gmail.com', N'262, xã An Châu,Tỉnh An Giang', '1678901235', '6789012347', 500000, NULL),
    ('KH017', N'Siêu Thị MM Mega Market Bình Phú', '0917890123', 'megamarket.binhphu@gmail.com', N'75, Phường Bình Phú, TP.HCM', '1789012346', '7890123458', 0, N'Khách hàng lớn'),
    ('KH018', N'Công Ty TNHH XNK Á Châu', '0918901234', 'achau.export@gmail.com', N'299,Phường Nguyễn Thái Bình, TP.HCM', '1890123457', '8901234569', 30000000, N'Khách xuất khẩu'),
    ('KH019', N'Căn Tin Đại Học Bách Khoa', '0919012345', 'dhbk.canteen@gmail.com', N'100, P. Thủ Đức, TP.HCM', '1901234568', '9012345670', 0, N'Khách cơ quan'),
    ('KH020', N'VinMart+ Võ Thị Sáu', '0920123456', 'vinmart.vothisau@gmail.com', N'77, Phường Nhiêu Lộc, TP.HCM', '2012345679', '0123456782', 0, N'Đối tác chiến lược');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào KHACHHANG.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu KHACHHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- Mục tiêu: Cập nhật cột MaLoaiKH trong bảng KHACHHANG.

-- 1. Siêu thị lớn (LKH004, LKH016, LKH017, LKH018)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH004' WHERE MaKH IN ('KH001', 'KH002', 'KH009', 'KH017'); 

-- 2. Khách hàng lâu năm / Đại lý cấp 1 (LKH008)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH008' WHERE MaKH = 'KH008';

-- 3. Tạp hóa (LKH005)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH005' WHERE MaKH IN ('KH003', 'KH016');

-- 4. Nhà hàng/Quán ăn (LKH006)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH006' WHERE MaKH IN ('KH004', 'KH015');

-- 5. Khách sạn (LKH007)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH007' WHERE MaKH = 'KH005';

-- 6. Khách hàng cơ quan/Trường học/Bệnh viện (LKH008/LKH009)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH008' WHERE MaKH IN ('KH006', 'KH007', 'KH019');

-- 7. Chuỗi Minimart / Tiện lợi (LKH014)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH014' WHERE MaKH IN ('KH010', 'KH012', 'KH014', 'KH020');

-- 8. Khách doanh nghiệp / Đối tác (LKH011, LKH013)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH013' WHERE MaKH IN ('KH011', 'KH013');

-- 9. Khách xuất khẩu (LKH012)
UPDATE KHACHHANG SET MaLoaiKH = 'LKH012' WHERE MaKH = 'KH018';

PRINT N'✓ Đã cập nhật MaLoaiKH cho KHACHHANG thành công.';
GO

-- 11. NHANVIEN (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO NHANVIEN (MaNV, MaPB, MaCV, HoTenNV, SDTNV, EmailNV)
VALUES
('NV001', 'PB001', 'CV001', N'Trần Minh Quân', '0931234567', N'tm@acecook.vn'), 
('NV002', 'PB001', 'CV009', N'Lê Thị Thu Hà', '0934567890', N'la@acecook.vn'), 
('NV003', 'PB003', 'CV003', N'Nguyễn Văn Đức', '0933456789', N'vd@acecook.vn'), 
('NV004', 'PB004', 'CV004', N'Phạm Thị Lan Anh', '0952123458', N'toan@acecook.vn'), 
('NV005', 'PB003', 'CV002', N'Hoàng Thị Mai Tuấn', '0936789012', N'mt@acecook.vn'), 
('NV006', 'PB002', 'CV005', N'Võ Thị Mai Linh', '0942345678', N'huy@acecook.vn'), 
('NV007', 'PB002', 'CV006', N'Dương Văn Hùng', '0941234566', N'ngoc@acecook.vn'), 
('NV008', 'PB004', 'CV007', N'Mai Thị Thu Hương', '0943456790', 'sun@acecook.vn'), 
('NV009', 'PB001', 'CV008', N'Bùi Quốc Huy', '0938901234', 'th@acecook.vn'), 
('NV010', 'PB004', 'CV010', N'Đỗ Thị Ngọc Diệp', '0950123456', 'dt@acecook.vn'), 
('NV011', 'PB003', 'CV004', N'Dương Minh Long', '0943699012', 'ngoc2@acecook.vn'), 
('NV012', 'PB004', 'CV007', N'Nguyễn Thị Bích Ngọc', '0945456789', 'diep@acecook.vn'), 
('NV013', 'PB001', 'CV009', N'Phạm Văn Tài', '0943699123', 'huong@acecook.vn'), 
('NV014', 'PB002', 'CV008', N'Lý Thị Kim Oanh', '0945986768', 'phuc@acecook.vn'), 
('NV015', 'PB003', 'CV004', N'Trịnh Văn Phúc', '0951012345', 'nh@acecook.vn'), 
('NV016', 'PB004', 'CV010', N'Võ Thị Quỳnh Như', '0961123457', 'huyen@acecook.vn'), 
('NV017', 'PB001', 'CV008', N'Trần Văn Sơn', '0978912345', 'linh@acecook.vn'), 
('NV018', 'PB003', 'CV005', N'Hoàng Thị Mỹ Duyên', '0934567891', 'son@acecook.vn'), 
('NV019', 'PB003', 'CV004', N'Lưu Văn Tú', '0933456799', 'de@acecook.vn'), 
('NV020', 'PB004', 'CV010', N'Đỗ Thị Hồng Nhung', '0950123499', 'dtnhung@acecook.vn'); 

    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào NHANVIEN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu NHANVIEN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 12. TAIKHOAN (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO TAIKHOAN (MaTK, MaNV, MaVT, TenDangNhap, MatKhau, TrangThaiTK)
    VALUES
    ('TK001', 'NV001', 'VT001', 'tmquan', 'Quan@123', N'Hoạt động'),
    ('TK002', 'NV002', 'VT002', 'ltthuha', 'ThuHa@456', N'Hoạt động'),
    ('TK003', 'NV003', 'VT003', 'nvduc', 'Duc@789', N'Hoạt động'),
    ('TK004', 'NV004', 'VT004', 'ptlananh', 'LanAnh@012', N'Hoạt động'),
    ('TK005', 'NV005', 'VT006', 'hmtuan', 'Tuan@345', N'Hoạt động'),
    ('TK006', 'NV006', 'VT007', 'vtmailinh', 'MaiLinh@678', N'Hoạt động'),
    ('TK007', 'NV007', 'VT009', 'dvhung', 'Hung@901', N'Hoạt động'),
    ('TK008', 'NV008', 'VT008', 'mtthuong', 'Huong@234', N'Hoạt động'),
    ('TK009', 'NV009', 'VT010', 'bqhuy', 'Huy@567', N'Hoạt động'),
    ('TK010', 'NV010', 'VT012', 'dtndiep', 'Diep@890', N'Hoạt động'),
    ('TK011', 'NV011', 'VT013', 'dmlong', 'Long@123', N'Hoạt động'),
    ('TK012', 'NV012', 'VT005', 'ntbngoc', 'Ngoc@456', N'Đã khóa'),
    ('TK013', 'NV013', 'VT011', 'pvtai', 'Tai@789', N'Hoạt động'),
    ('TK014', 'NV014', 'VT007', 'ltkoanh', 'Oanh@012', N'Hoạt động'),
    ('TK015', 'NV015', 'VT008', 'tvphuc', 'Phuc@345', N'Hoạt động'),
    ('TK016', 'NV016', 'VT018', 'vtqnhu', 'Nhu@678', N'Hoạt động'),
    ('TK017', 'NV017', 'VT015', 'tvson', 'Son@901', N'Hoạt động'),
    ('TK018', 'NV018', 'VT019', 'htmduyen', 'Duyen@234', N'Đã khóa'),
    ('TK019', 'NV019', 'VT004', 'lvtu', 'Tu@567', N'Hoạt động'),
    ('TK020', 'NV020', 'VT005', 'dthnhung', 'Nhung@890', N'Hoạt động');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào TAIKHOAN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TAIKHOAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 13. NGANHANG (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO NGANHANG (MaNH, MaKH, TenNH, DiaChiNH, SDTNH, EmailNH)
    VALUES
    ('NH001', 'KH001', N'Ngân Hàng Vietcombank', N'TP.HCM', '0283823456', 'vietcombank@vcb.com.vn'),
    ('NH002', 'KH002', N'Ngân Hàng BIDV', N'TP. Đà Nẵng', '0236823789', 'bidv.danang@bidv.com.vn'),
    ('NH003', 'KH005', N'Ngân Hàng Techcombank', N'TP.HCM', '0283823457', 'techcombank@tcb.com.vn'),
    ('NH004', 'KH008', N'Ngân Hàng ACB', N'TP.HCM', '0274823123', 'acb.binhduong@acb.com.vn'),
    ('NH005', 'KH011', N'Ngân Hàng Vietinbank', N'TP. Hà Nội', '0243823456', 'vietinbank@vib.com.vn'),
    ('NH006', 'KH013', N'Ngân Hàng MB Bank', N'TP.HCM', '0274823124', 'mbbank@mb.com.vn'),
    ('NH007', 'KH017', N'Ngân Hàng Sacombank', N'TP.HCM', '0283823458', 'sacombank@scb.com.vn'),
    ('NH008', 'KH018', N'Ngân Hàng VPBank', N'TP.HCM', '0283823459', 'vpbank@vpb.com.vn'),
    ('NH009', 'KH004', N'Ngân Hàng Agribank', N'TP.HCM', '0283823460', 'agribank@agb.com.vn'),
    ('NH010', 'KH020', N'Ngân Hàng TPBank', N'Toàn Quốc', '0283823461', 'tpbank@tpb.com.vn');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào NGANHANG.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu NGANHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 14. THETV (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO THETV (SoThe, MaKH, TenThe, DiemTichLuy)
    VALUES
    ('TTV001', 'KH001', N'Thẻ Bạch Kim', 1000),
    ('TTV002', 'KH002', N'Thẻ Vàng', 800),
    ('TTV003', 'KH003', N'Thẻ Bạc', 600),
    ('TTV004', 'KH004', N'Thẻ Đồng', 400),
    ('TTV005', 'KH005', N'Thẻ Xanh', 300),
    ('TTV006', 'KH006', N'Thẻ Khuyến Mãi', 200),
    ('TTV007', 'KH007', N'Thẻ VIP Doanh Nghiệp', 1200),
    ('TTV008', 'KH008', N'Thẻ Hợp Tác', 900),
    ('TTV009', 'KH009', N'Thẻ Thành Viên Online', 500),
    ('TTV010', 'KH010', N'Thẻ Tích Điểm Co.opmart', 350),
    ('TTV011', 'KH011', N'Thẻ Gia Đình', 450),
    ('TTV012', 'KH012', N'Thẻ Premium', 1000),
    ('TTV013', 'KH013', N'Thẻ Diamond', 1500),
    ('TTV014', 'KH014', N'Thẻ Business', 700),
    ('TTV015', 'KH015', N'Thẻ Gold Online', 750),
    ('TTV016', 'KH016', N'Thẻ Silver Online', 500),
    ('TTV017', 'KH017', N'Thẻ Bronze', 300),
    ('TTV018', 'KH018', N'Thẻ Loyalty', 650),
    ('TTV019', 'KH019', N'Thẻ Classic', 400),
    ('TTV020', 'KH020', N'Thẻ Guest', 100);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào THETV.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu THETV: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 15. CT_PHANQUYEN (10 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CT_PHANQUYEN (MaVT, MaQuyen, NgayPQ, NguoiCap, TrangThaiPQ)
VALUES
('VT001', 'QY001', '2025-01-01', N'Hệ thống', N'Hoạt động'),
('VT002', 'QY002', '2025-01-02', N'Admin', N'Hoạt động'),
('VT003', 'QY003', '2025-01-03', N'Admin', N'Chờ duyệt'),
('VT004', 'QY004', '2025-01-04', N'Admin', N'Hoạt động'),
('VT005', 'QY005', '2025-01-05', N'Admin', N'Hoạt động'),
('VT006', 'QY006', '2025-01-06', N'Quản trị', N'Đã thu hồi'),
('VT007', 'QY007', '2025-01-07', N'Kế toán trưởng', N'Hoạt động'),
('VT008', 'QY008', '2025-01-08', N'Hệ thống', N'Chờ duyệt'),
('VT009', 'QY009', '2025-01-09', N'Admin', N'Hoạt động'),
('VT010', 'QY010', '2025-01-10', N'Admin', N'Hoạt động');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CT_PHANQUYEN (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu CT_PHANQUYEN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 16. PHIEUNHAPKHO (20 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO PHIEUNHAPKHO (SoPN, MaKho, NgayNhap, LyDoNhap, TriGiaNhap)
    VALUES
    ('PN001', 'KHO001', '2025-01-05', N'Nhập nguyên liệu đầu tháng', 50000000),
    ('PN002', 'KHO002', '2025-01-10', N'Nhập bổ sung', 30000000),
    ('PN003', 'KHO003', '2025-01-15', N'Nhập nguyên liệu sản xuất', 45000000),
    ('PN004', 'KHO004', '2025-01-20', N'Nhập bột mì', 25000000),
    ('PN005', 'KHO005', '2025-02-01', N'Nhập thành phẩm từ nhà máy', 80000000),
    ('PN006', 'KHO001', '2025-02-05', N'Nhập nguyên liệu', 55000000),
    ('PN007', 'KHO006', '2025-02-10', N'Nhập hàng xuất khẩu', 90000000),
    ('PN008', 'KHO007', '2025-02-15', N'Nhập dự trữ', 40000000),
    ('PN009', 'KHO008', '2025-03-01', N'Nhập bổ sung', 35000000),
    ('PN010', 'KHO009', '2025-03-05', N'Nhập phụ tùng máy móc', 20000000),
    ('PN011', 'KHO010', '2025-03-10', N'Nhập bao bì', 15000000),
    ('PN012', 'KHO011', '2025-03-15', N'Nhập gia vị', 12000000),
    ('PN013', 'KHO001', '2025-04-01', N'Nhập nguyên liệu tháng 4', 60000000),
    ('PN014', 'KHO012', '2025-04-05', N'Nhập kho Tây Ninh', 38000000),
    ('PN015', 'KHO013', '2025-04-10', N'Nhập kho Cần Thơ', 42000000),
    ('PN016', 'KHO014', '2025-04-15', N'Nhập kho Hải Phòng', 48000000),
    ('PN017', 'KHO015', '2025-05-01', N'Nhập kho Hà Nội', 52000000),
    ('PN018', 'KHO016', '2025-05-05', N'Nhập kho Nghệ An', 32000000),
    ('PN019', 'KHO017', '2025-05-10', N'Nhập kho Quảng Ngãi', 28000000),
    ('PN020', 'KHO018', '2025-05-15', N'Nhập kho Vũng Tàu', 36000000);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào PHIEUNHAPKHO (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu PHIEUNHAPKHO: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 17. CHITIET_PN (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CHITIET_PN (MaNL, SoPN, SoLuongNhap, DonGiaNhap, ThanhTienNhap)
    VALUES
    ('NL001', 'PN001', 1000.00, 25000.00, 25000000.00),
    ('NL002', 'PN001', 500.00, 30000.00, 15000000.00),
    ('NL003', 'PN002', 800.00, 35000.00, 28000000.00),
    ('NL004', 'PN003', 1200.00, 15000.00, 18000000.00),
    ('NL005', 'PN003', 900.00, 20000.00, 18000000.00),
    ('NL006', 'PN004', 600.00, 40000.00, 24000000.00),
    ('NL007', 'PN005', 1500.00, 50000.00, 75000000.00),
    ('NL008', 'PN006', 700.00, 45000.00, 31500000.00),
    ('NL009', 'PN007', 1100.00, 38000.00, 41800000.00),
    ('NL010', 'PN008', 850.00, 42000.00, 35700000.00);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CHITIET_PN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CHITIET_PN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 18. NHACUNGCAP (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO NHACUNGCAP (MaNCC, TenNCC, SDTNCC, EmailNCC, DiaChiNCC, CongNoNCC, GhiChuNCC)
    VALUES
    ('NCC001', N'Công Ty Bột Mì Việt Nam', '0283234567', 'botmivn@gmail.com', N'TP.HCM', 0, N'Nhà cung cấp chính'),
    ('NCC002', N'Công Ty Dầu Thực Vật Tường An', '0283234568', 'tuongan@gmail.com', N'Tỉnh Tây Ninh', 5000000, N'Nhà cung cấp uy tín'),
    ('NCC003', N'Công Ty Muối Việt', '0283234569', 'muoiviet@gmail.com', N'Tỉnh Cà Mau', 0, NULL),
    ('NCC004', N'Công Ty Đường Biên Hòa', '0251234569', 'duongbienhoa@gmail.com', N'Tỉnh Đồng Nai', 3000000, NULL),
    ('NCC005', N'Công Ty Gia Vị Sài Gòn', '0283234570', 'giavisaigon@gmail.com', N'TP.HCM', 0, NULL),
    ('NCC006', N'Công Ty Bao Bì Nhựa Hà Nội', '0243234567', 'baobihn@gmail.com', N'TP. Hà Nội', 8000000, NULL),
    ('NCC007', N'Công Ty Thùng Carton Tân Phú', '0283234571', 'cartontp@gmail.com', N'TP.HCM', 0, NULL),
    ('NCC008', N'Công Ty Hương Liệu Quốc Tế', '0283234572', 'huonglieu@gmail.com', N'TP.HCM', 2000000, NULL),
    ('NCC009', N'Công Ty Xương Thực Phẩm', '0283234573', 'xuongthucpham@gmail.com', N'TP.HCM', 0, NULL),
    ('NCC010', N'Công Ty Tôm Khô Cần Thơ', '0292234567', 'tomkhoct@gmail.com', N'TP. Cần Thơ', 4000000, N'Nhà cung cấp hải sản'),
    ('NCC011', N'Công Ty Rau Củ Đà Lạt', '0263234567', 'raucudalat@gmail.com', N'Tỉnh Lâm Đồng', 0, NULL),
    ('NCC012', N'Công Ty Phụ Gia An Toàn', '0283234574', 'phugiaantoan@gmail.com', N'TP.HCM', 1000000, NULL),
    ('NCC013', N'Công Ty Bột Năng Đồng Tháp', '0277234567', 'botnangdt@gmail.com', N'Tỉnh Đồng Tháp', 0, NULL),
    ('NCC014', N'Công Ty Hành Tỏi Lý Sơn', '0255234567', 'hanhtoilyson@gmail.com', N'Tỉnh Quảng Ngãi', 0, NULL),
    ('NCC015', N'Công Ty Nước Mắm Phú Quốc', '0297234567', 'nuocmampq@gmail.com', N'Tỉnh An Giang', 6000000, N'Nhà cung cấp chất lượng'),
    ('NCC016', N'Công Ty Nước Tương Chinsu', '0283234575', 'chinsu@gmail.com', N'TP.HCM', 0, NULL),
    ('NCC017', N'Công Ty Tinh Bột Sắn', '0272234567', 'tinhbotsan@gmail.com', N'Tỉnh Tây Ninh', 0, NULL),
    ('NCC018', N'Công Ty Ớt Bột Quảng Trị', '0233234567', 'otbotquangtri@gmail.com', N'Tỉnh Quảng Trị', 0, NULL),
    ('NCC019', N'Công Ty Thịt Heo CP Việt Nam', '0283234576', 'cpvietnam@gmail.com', N'TP.HCM', 10000000, N'Nhà cung cấp lớn'),
    ('NCC020', N'Công Ty Hóa Chất Thực Phẩm', '0283234577', 'hoachatthucpham@gmail.com', N'TP.HCM', 0, NULL);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào NHACUNGCAP.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu NHACUNGCAP: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 19. CT_CC (10 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CT_CC (MaNCC, MaNL, GiaCungUng, TGGH, TinhTrangHT)
    VALUES
    ('NCC001', 'NL001', 25000.00, '2025-01-05 08:00:00', 1),
    ('NCC001', 'NL002', 30000.00, '2025-01-05 08:00:00', 1),
    ('NCC002', 'NL003', 35000.00, '2025-01-10 09:00:00', 1),
    ('NCC003', 'NL004', 15000.00, '2025-01-15 10:00:00', 1),
    ('NCC004', 'NL005', 20000.00, '2025-01-20 11:00:00', 1),
    ('NCC005', 'NL006', 40000.00, '2025-02-01 08:30:00', 1),
    ('NCC005', 'NL007', 50000.00, '2025-02-01 08:30:00', 1),
    ('NCC010', 'NL015', 120000.00, '2025-02-05 14:00:00', 1),
    ('NCC015', 'NL012', 55000.00, '2025-02-10 09:30:00', 1),
    ('NCC019', 'NL014', 85000.00, '2025-02-15 13:00:00', 1);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CT_CC (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CT_CC: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 20. TONKHO 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, 
                        TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, TGNhapTruocKy, TGXuatTruocKy, NgayCapNhatKho)
    VALUES
    ('KHO001', 'SP001', 1000, 1500, 1000, 500, 7000000.00, 7000000.00, 3500000.00, 6000000.00, 3000000.00, '2025-01-31'),
    ('KHO001', 'SP002', 2000, 2300, 800, 500, 7000000.00, 2800000.00, 1750000.00, 6500000.00, 3500000.00, '2025-01-31'),
    ('KHO002', 'SP003', 1500, 1800, 600, 300, 6000000.00, 2400000.00, 1200000.00, 5500000.00, 2800000.00, '2025-01-31'),
    ('KHO003', 'SP004', 1200, 1400, 500, 300, 5400000.00, 2250000.00, 1350000.00, 5000000.00, 2700000.00, '2025-01-31'),
    ('KHO005', 'SP005', 800, 1100, 500, 200, 6000000.00, 3750000.00, 1500000.00, 5200000.00, 2400000.00, '2025-01-31'),
    ('KHO001', 'SP006', 1800, 2000, 700, 500, 9000000.00, 3500000.00, 2500000.00, 8500000.00, 4000000.00, '2025-02-28'),
    ('KHO002', 'SP007', 1300, 1500, 400, 200, 4940000.00, 1520000.00, 760000.00, 4500000.00, 2000000.00, '2025-02-28'),
    ('KHO005', 'SP008', 900, 1200, 500, 200, 8550000.00, 4750000.00, 1900000.00, 7500000.00, 3800000.00, '2025-02-28'),
    ('KHO001', 'SP009', 500, 700, 300, 100, 6000000.00, 3600000.00, 1200000.00, 5000000.00, 2500000.00, '2025-03-31'),
    ('KHO003', 'SP010', 1600, 1900, 600, 300, 6720000.00, 2520000.00, 1260000.00, 6000000.00, 3000000.00, '2025-03-31');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào TONKHO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TONKHO: ' + ERROR_MESSAGE();
END CATCH;
GO

USE QLKTBHACECOOK;
GO

BEGIN TRANSACTION;
BEGIN TRY
    -- Xóa dữ liệu cũ của SP011->SP020 trong TONKHO nếu có để tránh trùng lặp
    DELETE FROM TONKHO WHERE MaSP IN ('SP011', 'SP012', 'SP013', 'SP014', 'SP015', 'SP016', 'SP017', 'SP018', 'SP019', 'SP020');

    -- SP011: Mì Hải Sản (Tồn đầu 100, Nhập 100, Xuất 200 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO001', 'SP011', 100, 0, 100, 200, 480000, 480000, 960000, '2025-06-30');

    -- SP012: Mì Ly Sườn (Không tồn đầu, Nhập 50, Xuất 50 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO002', 'SP012', 0, 0, 50, 50, 0, 400000, 400000, '2025-06-30');

    -- SP013: Cháo Gà Nấm (Tồn đầu 200, Không nhập, Xuất 200 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO003', 'SP013', 200, 0, 0, 200, 1300000, 0, 1300000, '2025-06-30');

    -- SP014: Mì Kim Chi (Tồn đầu 50, Nhập 50, Xuất 100 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO001', 'SP014', 50, 0, 50, 100, 275000, 275000, 550000, '2025-06-30');

    -- SP015: Phở Gà (Tồn đầu 1000, Xuất hết 1000 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO004', 'SP015', 1000, 0, 0, 1000, 4700000, 0, 4700000, '2025-06-30');

    -- SP016: Mì Lẩu Thái (Nhập 500, Xuất 500 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO005', 'SP016', 0, 0, 500, 500, 0, 3000000, 3000000, '2025-06-30');

    -- SP017: Mì Chay (Tồn đầu 30, Nhập 20, Xuất 50 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO006', 'SP017', 30, 0, 20, 50, 135000, 90000, 225000, '2025-06-30');

    -- SP018: Hảo Hảo Tôm Nấm (Tồn đầu 1500, Xuất hết -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO001', 'SP018', 1500, 0, 0, 1500, 5700000, 0, 5700000, '2025-06-30');

    -- SP019: Mì Xào Bò (Nhập 100, Xuất 100 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO002', 'SP019', 0, 0, 100, 100, 0, 520000, 520000, '2025-06-30');

    -- SP020: Combo (Tồn đầu 10, Xuất 10 -> Tồn cuối 0)
    INSERT INTO TONKHO (MaKho, MaSP, SLTonDauKy, SLTonCuoiKy, SLNhapTrongKy, SLXuatTrongKy, TGNhapDauKy, TGNhapTrongKy, TGXuatTrongKy, NgayCapNhatKho)
    VALUES ('KHO003', 'SP020', 10, 0, 0, 10, 170000, 0, 170000, '2025-06-30');

    COMMIT TRANSACTION;
    PRINT N'✓ Đã bổ sung dữ liệu tồn kho cho SP011-SP020';
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION;
    PRINT N'❌ Lỗi: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 21. DINH_MUC (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO DINH_MUC (MaNL, MaSP, SoLuongNL)
    VALUES
    ('NL001', 'SP001', 0.050),
    ('NL003', 'SP001', 0.008),
    ('NL004', 'SP001', 0.002),
    ('NL001', 'SP002', 0.048),
    ('NL003', 'SP002', 0.007),
    ('NL001', 'SP003', 0.052),
    ('NL014', 'SP004', 0.015),
    ('NL001', 'SP005', 0.055),
    ('NL015', 'SP011', 0.010),
    ('NL016', 'SP013', 0.003);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào DINH_MUC.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu DINH_MUC: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 22. CTKM (20 dòng) - Cập nhật năm 2025 và sửa lỗi định dạng ngày
BEGIN TRY
    BEGIN TRAN;
    SET DATEFORMAT YMD; 
    INSERT INTO CTKM (MaCTKM, TenCTKM, NgayBatDauKM, NgayKetThucKM, LyDoKM)
    VALUES
    ('KM001', N'Khuyến Mãi Tết Nguyên Đán 2025', '20250120', '20250215', N'Khuyến mãi dịp Tết'),
    ('KM002', N'Giảm Giá Mùa Hè', '20250601', '20250831', N'Kích cầu mùa hè'),
    ('KM003', N'Black Friday Sale', '20251125', '20251130', N'Khuyến mãi Black Friday'),
    ('KM004', N'Khuyến Mãi Khai Trương', '20250301', '20250315', N'Khai trương chi nhánh mới'),
    ('KM005', N'Mua 2 Tặng 1', '20250401', '20250430', N'Khuyến mãi mua nhiều'),
    ('KM006', N'Giảm 20% Sản Phẩm Mới', '20250501', '20250531', N'Ra mắt sản phẩm mới'),
    ('KM007', N'Back To School', '20250815', '20250915', N'Khuyến mãi mùa khai giảng'),
    ('KM008', N'Trung Thu Rực Rỡ', '20250901', '20250930', N'Khuyến mãi trung thu'),
    ('KM009', N'Ngày Độc Thân 11/11', '20251111', '20251111', N'Flash sale 11/11'),
    ('KM010', N'Giáng Sinh An Lành', '20251220', '20251226', N'Khuyến mãi Giáng sinh'),
    ('KM011', N'Tháng Tri Ân Khách Hàng', '20250701', '20250731', N'Tri ân khách hàng thân thiết'),
    ('KM012', N'Giảm Giá Cuối Tuần', '20251001', '20251031', N'Khuyến mãi cuối tuần'),
    ('KM013', N'Flash Sale Giờ Vàng', '20250115', '20250115', N'Flash sale 3 giờ'),
    ('KM014', N'Combo Gia Đình', '20250201', '20250228', N'Khuyến mãi combo tiết kiệm'), 
    ('KM015', N'Săn Deal Online', '20250320', '20250322', N'Khuyến mãi online'),
    ('KM016', N'Mùa Mưa Ấm Áp', '20251015', '20251115', N'Khuyến mãi mùa mưa'),
    ('KM017', N'Giảm Sốc Thanh Lý', '20251201', '20251215', N'Thanh lý hàng tồn kho'),
    ('KM018', N'Đón Năm Mới 2026', '20251228', '20260105', N'Khuyến mãi năm mới'),
    ('KM019', N'Siêu Sale Giữa Năm', '20250615', '20250620', N'Mega sale giữa năm'),
    ('KM020', N'Tuần Lễ Vàng', '20250920', '20250927', N'Tuần lễ khuyến mãi đặc biệt');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào CTKM (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'❌ Lỗi khi chèn dữ liệu CTKM: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 23. CT_KM (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CT_KM (MaSP, MaCTKM, TyLePhanTram, GiamTheoSanPham, GhiChuCTKM)
    VALUES
    ('SP001', 'KM001', 15.00, NULL, N'Giảm 15%'),
    ('SP002', 'KM001', 10.00, NULL, N'Giảm 10%'),
    ('SP003', 'KM002', NULL, 500, N'Giảm 500đ/gói'),
    ('SP004', 'KM002', 20.00, NULL, N'Giảm 20%'),
    ('SP005', 'KM003', 30.00, NULL, N'Black Friday 30%'),
    ('SP006', 'KM004', NULL, 1000, N'Giảm 1000đ'),
    ('SP009', 'KM006', 20.00, NULL, N'Sản phẩm mới giảm 20%'),
    ('SP011', 'KM007', 15.00, NULL, N'Giảm 15%'),
    ('SP015', 'KM008', NULL, 700, N'Giảm 700đ'),
    ('SP020', 'KM014', 25.00, NULL, N'Combo giảm 25%');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CT_KM.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CT_KM: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 24. DONDATHANG (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu Bảng DONDATHANG (20 dòng) (Đã điều chỉnh TriGiaDH và Năm 2025)...';
    INSERT INTO DONDATHANG (MaDDH, MaKH, MaNV, NgayDatHang, NgayGiaoHang, NgayThanhToan, TienCoc, TriGiaDH, TrangThaiDH, PhuongThucThanhToan, SoLanGiaoHang, GhiChuDH) VALUES
('DDH001', 'KH001', 'NV006', '2025-01-10', '2025-01-15', '2025-01-15', 5000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH002', 'KH002', 'NV006', '2025-01-12', '2025-01-17', '2025-01-17', 3000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH003', 'KH003', 'NV006', '2025-01-15', '2025-01-18', '2025-01-18', 0, 0, N'Đã giao', N'Tiền mặt', 1, N'TT đủ'), 
('DDH004', 'KH004', 'NV006', '2025-01-20', '2025-01-22', '2025-01-22', 2000000, 0, N'Đã giao', N'Tiền mặt', 1, N'TT đủ'), 
('DDH005', 'KH005', 'NV006', '2025-02-01', '2025-02-05', '2025-02-05', 8000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH006', 'KH008', 'NV006', '2025-02-10', '2025-02-15', NULL, 15000000, 0, N'Đã giao', N'Chuyển khoản', 2, N'TT 1 phần, còn nợ'), 
('DDH007', 'KH009', 'NV006', '2025-02-15', '2025-02-20', '2025-02-20', 0, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH008', 'KH010', 'NV006', '2025-03-01', '2025-03-05', '2025-03-05', 3000000, 0, N'Đã giao', N'Tiền mặt', 1, N'TT đủ'), 
('DDH009', 'KH011', 'NV006', '2025-03-05', '2025-03-10', '2025-03-12', 10000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'), 
('DDH010', 'KH013', 'NV006', '2025-03-15', '2025-03-20', NULL, 20000000, 0, N'Đã giao', N'Chuyển khoản', 2, N'TT 1 phần, còn nợ'),
('DDH011', 'KH014', 'NV006', '2025-04-01', '2025-04-05', '2025-04-05', 0, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'),
('DDH012', 'KH015', 'NV006', '2025-04-10', '2025-04-12', '2025-04-12', 1000000, 0, N'Đã giao', N'Tiền mặt', 1, N'TT đủ'),
('DDH013', 'KH017', 'NV006', '2025-04-20', '2025-04-25', '2025-04-25', 0, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'),
('DDH014', 'KH018', 'NV006', '2025-05-01', '2025-05-10', NULL, 30000000, 0, N'Đã giao', N'Chuyển khoản', 3, N'TT 1 phần, còn nợ'),
('DDH015', 'KH001', 'NV006', '2025-05-15', '2025-05-20', '2025-05-20', 10000000, 0, N'Đã giao', N'Chuyển khoản', 1, N'TT đủ'),
('DDH016', 'KH020', 'NV006', '2025-06-01', '2025-06-05', NULL, 0, 0, N'Đang giao', N'Chuyển khoản', 1, N'Công nợ'), 
('DDH017', 'KH002', 'NV006', '2025-06-10', '2025-06-15', NULL, 5000000, 0, N'Đang giao', N'Chuyển khoản', 1, N'Công nợ'), 
('DDH018', 'KH005', 'NV006', '2025-06-15', '2025-06-20', NULL, 8000000, 0, N'Đang xử lý', N'Chuyển khoản', 0, N'Công nợ'), 
('DDH019', 'KH008', 'NV006', '2025-06-20', '2025-06-25', NULL, 15000000, 0, N'Đang xử lý', N'Chuyển khoản', 0, N'Công nợ'), 
('DDH020', 'KH003', 'NV006', '2025-06-22', '2025-06-24', NULL, 0, 0, N'Đã hủy', N'Tiền mặt', 0, N'Khách hủy'); 
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào DONDATHANG (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu DONDATHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 25. CT_DH (10 dòng)
BEGIN TRY
    BEGIN TRAN;
  INSERT INTO CT_DH (MaDDH, MaSP, SoLuongDDH, DonGiaDDH) VALUES
-- DDH001
('DDH001', 'SP001', 3000, 7000), 
('DDH001', 'SP002', 6000, 3500), 
-- DDH002
('DDH002', 'SP003', 4000, 4000), 
('DDH002', 'SP004', 3000, 4500), 
-- DDH003
('DDH003', 'SP005', 1000, 7500), 
-- DDH004
('DDH004', 'SP006', 2000, 5000), 
-- DDH005
('DDH005', 'SP001', 2500, 7000), 
('DDH005', 'SP009', 1500, 12000), 
-- DDH006
('DDH006', 'SP002', 10000, 3500), 
('DDH006', 'SP004', 8000, 4500),
-- DDH007
('DDH007', 'SP008', 2000, 9500),
('DDH007', 'SP010', 1500, 4200),
-- DDH008
('DDH008', 'SP011', 1000, 4800),
('DDH008', 'SP012', 1000, 8000),
-- DDH009
('DDH009', 'SP013', 5000, 6500),
('DDH009', 'SP014', 3000, 5500),
-- DDH010 (Đơn lớn)
('DDH010', 'SP009', 5000, 12000),
('DDH010', 'SP019', 8000, 5200),
-- DDH011
('DDH011', 'SP001', 2000, 7000),
('DDH011', 'SP015', 2000, 4700),
-- DDH012
('DDH012', 'SP002', 1000, 3500),
('DDH012', 'SP007', 500, 3800),
-- DDH013
('DDH013', 'SP016', 4000, 6000),
('DDH013', 'SP017', 3000, 4500),
-- DDH014 (Xuất khẩu)
('DDH014', 'SP009', 10000, 12000),
('DDH014', 'SP020', 2000, 17000),
-- DDH015
('DDH015', 'SP005', 4000, 7500),
('DDH015', 'SP003', 4000, 4000),
-- DDH016
('DDH016', 'SP008', 5000, 9500),
-- DDH017
('DDH017', 'SP004', 4000, 4500),
('DDH017', 'SP002', 4000, 3500),
-- DDH018
('DDH018', 'SP010', 6000, 4200),
('DDH018', 'SP014', 3000, 5500),
-- DDH019
('DDH019', 'SP005', 8000, 7500),
('DDH019', 'SP019', 4000, 5200),
-- DDH020
('DDH020', 'SP017', 2000, 4500);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào CT_DH.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CT_DH: ' + ERROR_MESSAGE();
END CATCH;
GO
-- CẬP NHẬT TỰ ĐỘNG GIÁ TRỊ ĐƠN HÀNG DỰA TRÊN CHI TIẾT
UPDATE DONDATHANG
SET TriGiaDH = (
    SELECT ISNULL(SUM(SoLuongDDH * DonGiaDDH), 0)
    FROM CT_DH
    WHERE CT_DH.MaDDH = DONDATHANG.MaDDH
);
GO

PRINT N'✓ Đã cập nhật xong dữ liệu 20 đơn hàng và tính tổng tiền chính xác.';
GO

-- 26. HOADONBAN (19 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO HOADONBAN (SoHDB, MaDDH, NgayLapHDB, TiencocHDB, TriGiaTruocthueHDB, TriGiaSauthueHDB, 
                           GiamGiaHDB, TriGiaSauGiam)
    VALUES
    ('HDB001', 'DDH001', '2025-01-15', 5000000, 42000000, 46200000, 2000000, 44200000), 
    ('HDB002', 'DDH002', '2025-01-17', 3000000, 25000000, 27500000, 500000, 27000000), 
    ('HDB003', 'DDH003', '2025-01-18', 0, 7500000, 8250000, 0, 8250000), 
    ('HDB004', 'DDH004', '2025-01-22', 2000000, 10000000, 11000000, 500000, 10500000), 
    ('HDB005', 'DDH005', '2025-02-05', 8000000, 35500000, 39050000, 2000000, 37050000), 
    ('HDB006', 'DDH006', '2025-02-18', 15000000, 71000000, 78100000, 3000000, 75100000), 
    ('HDB007', 'DDH007', '2025-02-20', 0, 27500000, 30250000, 1000000, 29250000), 
    ('HDB008', 'DDH008', '2025-03-05', 3000000, 14500000, 15950000, 500000, 15450000), 
    ('HDB009', 'DDH009', '2025-03-12', 10000000, 48000000, 52800000, 2500000, 50300000), 
    ('HDB010', 'DDH010', '2025-03-25', 20000000, 97000000, 106700000, 5000000, 101700000), 
    ('HDB011', 'DDH011', '2025-04-05', 0, 22000000, 24200000, 800000, 23400000),
    ('HDB012', 'DDH012', '2025-04-12', 1000000, 6000000, 6600000, 0, 5600000), 
    ('HDB013', 'DDH013', '2025-04-25', 0, 35000000, 38500000, 1500000, 37000000),
    ('HDB014', 'DDH014', '2025-05-15', 30000000, 150000000, 165000000, 7000000, 158000000),
    ('HDB015', 'DDH015', '2025-05-20', 10000000, 55000000, 60500000, 2500000, 58000000),
    ('HDB016', 'DDH016', '2025-06-05', 0, 45000000, 49500000, 2000000, 47500000),
    ('HDB017', 'DDH017', '2025-06-15', 5000000, 32000000, 35200000, 1200000, 34000000),
    ('HDB018', 'DDH018', '2025-06-20', 8000000, 42000000, 46200000, 2000000, 44200000),
    ('HDB019', 'DDH019', '2025-06-25', 15000000, 78000000, 85800000, 3500000, 82300000);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào HOADONBAN (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu HOADONBAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 29. PHIEUTHANHTOAN (19 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO PHIEUTHANHTOAN (SoPTT, SoHDB, MaNV, NgayTT, SoTienTT, HinhThucTT, TrangThaiTT)
    VALUES
    ('PTT001', 'HDB001', 'NV013', '2025-01-15', 44200000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT002', 'HDB002', 'NV013', '2025-01-17', 27000000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT003', 'HDB003', 'NV013', '2025-01-18', 8250000, N'Tiền mặt', N'Đã thanh toán'), 
    ('PTT004', 'HDB004', 'NV013', '2025-01-22', 10500000, N'Tiền mặt', N'Đã thanh toán'), 
    ('PTT005', 'HDB005', 'NV013', '2025-02-05', 37050000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT006', 'HDB006', 'NV013', '2025-02-18', 15000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT007', 'HDB007', 'NV013', '2025-02-20', 29250000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT008', 'HDB008', 'NV013', '2025-03-05', 15450000, N'Tiền mặt', N'Đã thanh toán'), 
    ('PTT009', 'HDB009', 'NV013', '2025-03-12', 50300000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT010', 'HDB010', 'NV013', '2025-03-25', 20000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT011', 'HDB011', 'NV013', '2025-04-05', 23400000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT012', 'HDB012', 'NV013', '2025-04-12', 5600000, N'Tiền mặt', N'Đã thanh toán'), 
    ('PTT013', 'HDB013', 'NV013', '2025-04-25', 37000000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT014', 'HDB014', 'NV013', '2025-05-15', 30000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT015', 'HDB015', 'NV013', '2025-05-20', 58000000, N'Chuyển khoản', N'Đã thanh toán'), 
    ('PTT016', 'HDB016', 'NV013', '2025-06-05', 0, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT017', 'HDB017', 'NV013', '2025-06-15', 5000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT018', 'HDB018', 'NV013', '2025-06-20', 8000000, N'Chuyển khoản', N'Chưa thanh toán'), 
    ('PTT019', 'HDB019', 'NV013', '2025-06-25', 15000000, N'Chuyển khoản', N'Chưa thanh toán'); 
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào PHIEUTHANHTOAN (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu PHIEUTHANHTOAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 32. PHIEUXUAT (19 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO PHIEUXUAT (SoPX, NgayXuat, TrangThaiPX, TriGiaPX, LyDoXuat)
    VALUES
    ('PX001', '2025-01-15', N'Đã xuất', 44200000, N'Xuất hàng cho HDB001'),
    ('PX002', '2025-01-17', N'Đã xuất', 27000000, N'Xuất hàng cho HDB002'),
    ('PX003', '2025-01-18', N'Đã xuất', 8250000, N'Xuất hàng cho HDB003'),
    ('PX004', '2025-01-22', N'Đã xuất', 10500000, N'Xuất hàng cho HDB004'),
    ('PX005', '2025-02-05', N'Đã xuất', 37050000, N'Xuất hàng cho HDB005'),
    ('PX006', '2025-02-18', N'Đã xuất', 75100000, N'Xuất hàng cho HDB006'),
    ('PX007', '2025-02-20', N'Đã xuất', 29250000, N'Xuất hàng cho HDB007'),
    ('PX008', '2025-03-05', N'Đã xuất', 15450000, N'Xuất hàng cho HDB008'),
    ('PX009', '2025-03-12', N'Đã xuất', 50300000, N'Xuất hàng cho HDB009'),
    ('PX010', '2025-03-25', N'Đã xuất', 101700000, N'Xuất hàng cho HDB010'),
    ('PX011', '2025-04-05', N'Đã xuất', 23400000, N'Xuất hàng cho HDB011'),
    ('PX012', '2025-04-12', N'Đã xuất', 5600000, N'Xuất hàng cho HDB012'),
    ('PX013', '2025-04-25', N'Đã xuất', 37000000, N'Xuất hàng cho HDB013'),
    ('PX014', '2025-05-15', N'Đã xuất', 158000000, N'Xuất hàng xuất khẩu'),
    ('PX015', '2025-05-20', N'Đã xuất', 58000000, N'Xuất hàng cho HDB015'),
    ('PX016', '2025-06-05', N'Đã xuất', 47500000, N'Xuất hàng cho HDB016'),
    ('PX017', '2025-06-15', N'Đang xuất', 34000000, N'Xuất hàng cho HDB017'),
    ('PX018', '2025-06-20', N'Chưa xuất', 44200000, N'Xuất hàng cho HDB018'),
    ('PX019', '2025-06-25', N'Chưa xuất', 82300000, N'Xuất hàng cho HDB019');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào PHIEUXUAT (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu PHIEUXUAT: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 33. CT_PX (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CT_PX (SoPX, MaKho, SLXuat, DGXuat, ThanhTienXuat)
    VALUES
    ('PX001', 'KHO001', 3000, 7000.00, 21000000.00), 
    ('PX001', 'KHO002', 6000, 3500.00, 21000000.00),  
    ('PX002', 'KHO002', 4000, 4000.00, 16000000.00),
    ('PX002', 'KHO003', 3000, 3000.00, 9000000.00),  
    ('PX003', 'KHO001', 1000, 7500.00, 7500000.00),
    ('PX004', 'KHO001', 2000, 5000.00, 10000000.00),
    ('PX005', 'KHO005', 2500, 7000.00, 17500000.00),
    ('PX005', 'KHO006', 1500, 12000.00, 18000000.00), 
    ('PX006', 'KHO001', 10000, 3500.00, 35000000.00),
    ('PX006', 'KHO002', 8000, 4500.00, 36000000.00);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào CT_PX.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CT_PX: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 34. LENHBANHANG (19 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO LENHBANHANG (MaLBH, SoPX, MaNV, NgayLap, GhiChuLBH)
    VALUES
    ('LBH001', 'PX001', 'NV006', '2025-01-15', N'Lệnh bán hàng Co.opmart'),
    ('LBH002', 'PX002', 'NV006', '2025-01-17', N'Lệnh bán hàng BigC'),
    ('LBH003', 'PX003', 'NV006', '2025-01-18', N'Lệnh bán hàng tạp hóa'),
    ('LBH004', 'PX004', 'NV006', '2025-01-22', N'Lệnh bán hàng nhà hàng'),
    ('LBH005', 'PX005', 'NV006', '2025-02-05', N'Lệnh bán hàng khách sạn'),
    ('LBH006', 'PX006', 'NV006', '2025-02-18', N'Lệnh bán hàng đại lý'),
    ('LBH007', 'PX007', 'NV006', '2025-02-20', N'Lệnh bán hàng Lotte Mart'),
    ('LBH008', 'PX008', 'NV006', '2025-03-05', N'Lệnh bán hàng Circle K'),
    ('LBH009', 'PX009', 'NV006', '2025-03-12', N'Lệnh bán hàng công ty'),
    ('LBH010', 'PX010', 'NV006', '2025-03-25', N'Lệnh bán hàng nhà phân phối'),
    ('LBH011', 'PX011', 'NV006', '2025-04-05', N'Lệnh bán hàng Family Mart'),
    ('LBH012', 'PX012', 'NV006', '2025-04-12', N'Lệnh bán hàng quán ăn'),
    ('LBH013', 'PX013', 'NV006', '2025-04-25', N'Lệnh bán hàng Mega Market'),
    ('LBH014', 'PX014', 'NV006', '2025-05-15', N'Lệnh bán hàng xuất khẩu'),
    ('LBH015', 'PX015', 'NV006', '2025-05-20', N'Lệnh bán hàng Co.opmart'),
    ('LBH016', 'PX016', 'NV006', '2025-06-05', N'Lệnh bán hàng Vinmart'),
    ('LBH017', 'PX017', 'NV006', '2025-06-15', N'Lệnh bán hàng BigC'),
    ('LBH018', 'PX018', 'NV006', '2025-06-20', N'Lệnh bán hàng khách sạn'),
    ('LBH019', 'PX019', 'NV006', '2025-06-25', N'Lệnh bán hàng đại lý');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 19 dòng vào LENHBANHANG (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu LENHBANHANG: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 35. LOAIQUYEN (20 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO LOAIQUYEN (MaLQ, TenLQ, MoTaLQ)
    VALUES
    ('LQ001', N'Quyền Hệ Thống', N'Quyền quản lý hệ thống'),
    ('LQ002', N'Quyền Kế Toán', N'Quyền xử lý kế toán'),
    ('LQ003', N'Quyền Bán Hàng', N'Quyền bán hàng'),
    ('LQ004', N'Quyền Kho', N'Quyền quản lý kho'),
    ('LQ005', N'Quyền Báo Cáo', N'Quyền xem báo cáo'),
    ('LQ006', N'Quyền Quản Trị', N'Quyền quản trị toàn hệ thống'),
    ('LQ007', N'Quyền Nhân Sự', N'Quyền quản lý nhân sự'),
    ('LQ008', N'Quyền Tài Chính', N'Quyền tài chính'),
    ('LQ009', N'Quyền Marketing', N'Quyền tiếp thị'),
    ('LQ010', N'Quyền Sản Xuất', N'Quyền quản lý sản xuất'),
    ('LQ011', N'Quyền Duyệt', N'Quyền phê duyệt'),
    ('LQ012', N'Quyền Xem', N'Quyền xem thông tin'),
    ('LQ013', N'Quyền Chỉnh Sửa', N'Quyền chỉnh sửa dữ liệu'),
    ('LQ014', N'Quyền Xóa', N'Quyền xóa dữ liệu'),
    ('LQ015', N'Quyền Tạo Mới', N'Quyền tạo mới dữ liệu'),
    ('LQ016', N'Quyền Xuất File', N'Quyền xuất file báo cáo'),
    ('LQ017', N'Quyền Import', N'Quyền nhập liệu hàng loạt'),
    ('LQ018', N'Quyền Backup', N'Quyền sao lưu dữ liệu'),
    ('LQ019', N'Quyền Restore', N'Quyền phục hồi dữ liệu'),
    ('LQ020', N'Quyền Cấu Hình', N'Quyền cấu hình hệ thống');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào LOAIQUYEN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu LOAIQUYEN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 36. TAIKHOANCAP1 (50 dòng)
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang thêm TAIKHOANCAP1...';
    
    INSERT INTO TAIKHOANCAP1 (SoTKC1, TenTKC1, GhiChuTKC1)
    VALUES
    ('111', N'Tiền mặt', N'Tiền mặt tại quỹ'), ('112', N'Tiền gửi ngân hàng', N'Tiền gửi NH'), ('113', N'Tiền đang chuyển', N'Tiền đang chuyển'),
    ('121', N'Chứng khoán kinh doanh', N'CK kinh doanh'), ('128', N'Đầu tư nắm giữ đến ngày đáo hạn', N'Đầu tư dài hạn'),
    ('131', N'Phải thu của khách hàng', N'Công nợ phải thu'), ('133', N'Thuế GTGT được khấu trừ', N'Thuế đầu vào'),
    ('136', N'Phải thu nội bộ', N'Phải thu NB'), ('138', N'Phải thu khác', N'Phải thu khác'),
    ('141', N'Tạm ứng', N'Tạm ứng'),
    ('151', N'Hàng mua đang đi đường', N'Hàng đang về'), ('152', N'Nguyên liệu, vật liệu', N'NVL'),
    ('153', N'Công cụ, dụng cụ', N'CCDC'), ('154', N'Chi phí sản xuất, kinh doanh dở dang', N'CP DDDK'),
    ('155', N'Thành phẩm', N'Thành phẩm'), ('156', N'Hàng hóa', N'Hàng hóa'),
    ('157', N'Hàng gửi đi bán', N'Hàng gửi bán'), ('158', N'Hàng hoá kho bảo thuế', N'Hàng bảo thuế'),
    ('211', N'Tài sản cố định hữu hình', N'TSCĐ HH'), ('212', N'Tài sản cố định thuê tài chính', N'TSCĐ thuê TC'),
    ('213', N'Tài sản cố định vô hình', N'TSCĐ VH'), ('214', N'Hao mòn tài sản cố định', N'Hao mòn TSCĐ'),
    ('217', N'Bất động sản đầu tư', N'BĐS đầu tư'),
    ('221', N'Đầu tư vào công ty con', N'Đầu tư CTy con'), ('222', N'Đầu tư vào công ty liên doanh, liên kết', N'Đầu tư LĐLK'),
    ('228', N'Đầu tư khác', N'Đầu tư khác'),
    ('241', N'Xây dựng cơ bản dở dang', N'XDCB DDDK'), ('242', N'Chi phí trả trước', N'CP trả trước'),
    ('331', N'Phải trả cho người bán', N'Công nợ NCC'), ('333', N'Thuế và các khoản phải nộp Nhà nước', N'Thuế phải nộp'),
    ('334', N'Phải trả người lao động', N'Lương phải trả'), ('335', N'Chi phí phải trả', N'CP phải trả'),
    ('336', N'Phải trả nội bộ', N'Phải trả NB'), ('338', N'Phải trả, phải nộp khác', N'Phải trả khác'),
    ('341', N'Vay và nợ thuê tài chính', N'Vay dài hạn'), ('343', N'Trái phiếu phát hành', N'Trái phiếu'),
    ('411', N'Vốn đầu tư của chủ sở hữu', N'Vốn CSH'), ('421', N'Lợi nhuận sau thuế chưa phân phối', N'LNST CPP'),
    ('511', N'Doanh thu bán hàng và cung cấp dịch vụ', N'Doanh thu'), ('521', N'Các khoản giảm trừ doanh thu', N'Giảm trừ DT'),
    ('611', N'Mua hàng', N'Mua hàng'), ('621', N'Chi phí nguyên vật liệu trực tiếp', N'CP NVL trực tiếp'),
    ('622', N'Chi phí nhân công trực tiếp', N'CP nhân công trực tiếp'), ('627', N'Chi phí sản xuất chung', N'CPSXC'),
    ('632', N'Giá vốn hàng bán', N'GVHB'),
    ('641', N'Chi phí bán hàng', N'CP bán hàng'), ('642', N'Chi phí quản lý doanh nghiệp', N'CP QLDN'),
    ('711', N'Thu nhập khác', N'Thu nhập khác'), ('811', N'Chi phí khác', N'CP khác'),
    ('911', N'Xác định kết quả kinh doanh', N'Xác định KQKD');
    
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 50 dòng vào TAIKHOANCAP1.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TAIKHOANCAP1: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 37. TAIKHOANCAP2 (70 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang thêm TAIKHOANCAP2 ';
    
    INSERT INTO TAIKHOANCAP2 (SoTKC2, SoTKC1, TenTKC2, GhiChuTKC2)
    VALUES
    -- TK 111: Tiền mặt
    ('1111', '111', N'Tiền Việt Nam', N'Tiền VNĐ'), ('1112', '111', N'Ngoại tệ', N'Tiền ngoại tệ'), ('1113', '111', N'Vàng tiền tệ', N'Vàng'),
    -- TK 112: Tiền gửi ngân hàng
    ('1121', '112', N'Tiền Việt Nam gửi ngân hàng', N'Tiền gửi VNĐ'), ('1122', '112', N'Ngoại tệ gửi ngân hàng', N'Tiền gửi ngoại tệ'),
    ('1123', '112', N'Vàng tiền tệ gửi ngân hàng', N'Vàng gửi NH'),
    -- TK 113: Tiền đang chuyển
    ('1131', '113', N'Tiền Việt Nam đang chuyển', N'Tiền chuyển VNĐ'), ('1132', '113', N'Ngoại tệ đang chuyển', N'Tiền chuyển ngoại tệ'),
    -- TK 121: Chứng khoán kinh doanh
    ('1211', '121', N'Cổ phiếu', N'Cổ phiếu KD'), ('1212', '121', N'Trái phiếu', N'Trái phiếu KD'),
    ('1218', '121', N'Chứng khoán và công cụ tài chính khác', N'CK khác'),
    -- TK 128: Đầu tư nắm giữ đến ngày đáo hạn
    ('1281', '128', N'Tiền gửi có kỳ hạn', N'Tiền gửi KH'), ('1282', '128', N'Trái phiếu', N'Trái phiếu đầu tư'),
    ('1283', '128', N'Cho vay', N'Cho vay DH'), ('1288', '128', N'Đầu tư khác nắm giữ đến ngày đáo hạn', N'Đầu tư khác'),
    -- TK 131: Phải thu khách hàng
    ('1311', '131', N'Phải thu khách hàng', N'Phải thu KH'),
    -- TK 133: Thuế GTGT được khấu trừ
    ('1331', '133', N'Thuế GTGT được khấu trừ của hàng hóa, dịch vụ', N'Thuế GTGT HH'),
    ('1332', '133', N'Thuế GTGT được khấu trừ của TSCĐ', N'Thuế GTGT TSCĐ'),
    -- TK 136: Phải thu nội bộ
    ('1361', '136', N'Vốn kinh doanh ở các đơn vị trực thuộc', N'Vốn ĐVTT'), ('1362', '136', N'Phải thu nội bộ về chênh lệch tỷ giá', N'PT NB tỷ giá'),
    ('1363', '136', N'Phải thu nội bộ về chi phí vay vốn hóa', N'PT NB vay'), ('1368', '136', N'Phải thu nội bộ khác', N'PT NB khác'),
    -- TK 138: Phải thu khác
    ('1381', '138', N'Tài sản thiếu chờ xử lý', N'TS thiếu'), ('1385', '138', N'Phải thu về cổ phần hoá', N'PT CPH'),
    ('1388', '138', N'Phải thu khác', N'PT khác'),
    -- TK 141: Tạm ứng
    ('1411', '141', N'Tạm ứng', N'Tạm ứng'),
    -- TK 151: Hàng mua đang đi đường
    ('1511', '151', N'Hàng mua đang đi đường', N'Hàng đi đường'),
    -- TK 152: Nguyên liệu, vật liệu
    ('1521', '152', N'Nguyên liệu, vật liệu', N'NVL'),
    -- TK 153: Công cụ, dụng cụ
    ('1531', '153', N'Công cụ, dụng cụ', N'CCDC'), ('1532', '153', N'Bao bì luân chuyển', N'Bao bì'),
    ('1533', '153', N'Đồ dùng cho thuê', N'Đồ cho thuê'), ('1534', '153', N'Thiết bị, phụ tùng thay thế', N'TB phụ tùng'),
    -- TK 154: Chi phí SXKD dở dang
    ('1541', '154', N'Chi phí sản xuất, kinh doanh dở dang', N'CP DDDK'),
    -- TK 155: Thành phẩm
    ('1551', '155', N'Thành phẩm nhập kho', N'TP nhập kho'), ('1557', '155', N'Thành phẩm bất động sản', N'TP BĐS'),
    -- TK 156: Hàng hóa
    ('1561', '156', N'Giá mua hàng hóa', N'Giá mua HH'), ('1562', '156', N'Chi phí thu mua hàng hóa', N'CP thu mua'),
    ('1567', '156', N'Hàng hóa bất động sản', N'HH BĐS'),
    -- TK 157: Hàng gửi đi bán
    ('1571', '157', N'Hàng gửi đi bán', N'Hàng gửi'),
    -- TK 158: Hàng hóa kho bảo thuế
    ('1581', '158', N'Hàng hoá kho bảo thuế', N'Kho bảo thuế'),
    -- TK 211: TSCĐ hữu hình
    ('2111', '211', N'Nhà cửa, vật kiến trúc', N'Nhà cửa'), ('2112', '211', N'Máy móc, thiết bị', N'Máy móc'),
    ('2113', '211', N'Phương tiện vận tải, truyền dẫn', N'PTVT'), ('2114', '211', N'Thiết bị, dụng cụ quản lý', N'TB quản lý'),
    ('2115', '211', N'Cây lâu năm, súc vật làm việc', N'Cây lâu năm'), ('2118', '211', N'TSCĐ khác', N'TSCĐ khác'),
    -- TK 212: TSCĐ thuê tài chính
    ('2121', '212', N'TSCĐ hữu hình thuê tài chính', N'TSCĐ HH thuê TC'), ('2122', '212', N'TSCĐ vô hình thuê tài chính', N'TSCĐ VH thuê TC'),
    -- TK 213: TSCĐ vô hình
    ('2131', '213', N'Quyền sử dụng đất', N'QSD đất'), ('2132', '213', N'Quyền phát hành', N'Quyền phát hành'),
    ('2133', '213', N'Bản quyền, bằng sáng chế', N'Bản quyền'), ('2134', '213', N'Nhãn hiệu, tên thương mại', N'Nhãn hiệu'),
    ('2135', '213', N'Chương trình phần mềm', N'Phần mềm'), ('2136', '213', N'Giấy phép và giấy phép nhượng quyền', N'Giấy phép'),
    ('2138', '213', N'TSCĐ vô hình khác', N'TSCĐ VH khác'),
    -- TK 214: Hao mòn TSCĐ
    ('2141', '214', N'Hao mòn TSCĐ hữu hình', N'HM TSCĐ HH'), ('2142', '214', N'Hao mòn TSCĐ thuê tài chính', N'HM TSCĐ thuê TC'),
    ('2143', '214', N'Hao mòn TSCĐ vô hình', N'HM TSCĐ VH'), ('2147', '214', N'Hao mòn bất động sản đầu tư', N'HM BĐS ĐT'),
    -- TK 217: Bất động sản đầu tư
    ('2171', '217', N'Bất động sản đầu tư', N'BĐS đầu tư'),
    -- TK 221: Đầu tư vào công ty con
    ('2211', '221', N'Đầu tư vào công ty con', N'ĐT CTy con'),
    -- TK 222: Đầu tư liên doanh, liên kết
    ('2221', '222', N'Đầu tư vào công ty liên doanh, liên kết', N'ĐT LĐLK'),
    -- TK 228: Đầu tư khác
    ('2281', '228', N'Đầu tư góp vốn', N'ĐT góp vốn'), ('2288', '228', N'Đầu tư khác', N'ĐT khác'),
    -- TK 241: XDCB dở dang
    ('2411', '241', N'Mua sắm TSCĐ', N'Mua sắm TSCĐ'), ('2412', '241', N'Xây dựng cơ bản', N'XD cơ bản'),
    ('2413', '241', N'Sửa chữa lớn TSCĐ', N'SCL TSCĐ'),
    -- TK 242: Chi phí trả trước
    ('2421', '242', N'Chi phí trả trước ngắn hạn', N'CP trả trước NH'),
    -- TK 331: Phải trả người bán
    ('3311', '331', N'Phải trả cho người bán', N'PT người bán'),
    -- TK 333: Thuế phải nộp
    ('3331', '333', N'Thuế GTGT phải nộp', N'Thuế GTGT'),
    -- TK 334: Phải trả người lao động
    ('3341', '334', N'Phải trả người lao động', N'Lương phải trả'),
    -- TK 338: Phải trả khác
    ('3381', '338', N'Phải trả, phải nộp khác', N'Phải trả khác'),
    -- TK 411: Vốn chủ sở hữu
    ('4111', '411', N'Vốn đầu tư của chủ sở hữu', N'Vốn CSH'),
    -- TK 421: Lợi nhuận
    ('4211', '421', N'Lợi nhuận sau thuế chưa phân phối', N'LNST CPP'),
    -- TK 511: Doanh thu
    ('5111', '511', N'Doanh thu bán hàng hóa', N'DT bán HH'),
    -- TK 521: Giảm trừ doanh thu
    ('5211', '521', N'Hàng bán bị trả lại', N'Hàng trả lại'),
    -- TK 611: Mua hàng
    ('6111', '611', N'Mua hàng hóa', N'Mua HH'),
    -- TK 632: Giá vốn hàng bán
    ('6321', '632', N'Giá vốn hàng bán', N'GVHB'),
    -- TK 641: Chi phí bán hàng
    ('6411', '641', N'Chi phí nhân viên bán hàng', N'CP nhân viên BH'),
    ('6412', '641', N'Chi phí NVL, bao bì', N'CP NVL, bao bì');
    
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 70 dòng vào TAIKHOANCAP2.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TAIKHOANCAP2: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 38. TAIKHOANCAP3 (85 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang thêm TAIKHOANCAP3';
    
    INSERT INTO TAIKHOANCAP3 (SoTKC3, SoTKC2, TenTKC3, GhiChuTKC3)
    VALUES
    -- Con của 1111: Tiền Việt Nam
    ('1111M', '1111', N'Tiền mặt Việt Nam', N'Tiền VNĐ tại quỹ'),
    -- Con của 1112: Ngoại tệ
    ('1112N', '1112', N'Ngoại tệ USD', N'Tiền USD tại quỹ'),
    -- Con của 1113: Vàng
    ('1113V', '1113', N'Vàng tiền tệ SJC', N'Vàng SJC'),
    -- Con của 1121: Tiền gửi VNĐ
    ('1121H', '1121', N'Tiền Việt Nam gửi Vietcombank', N'VCB VNĐ'),
    -- Con của 1122: Tiền gửi ngoại tệ
    ('1122H', '1122', N'Ngoại tệ gửi BIDV', N'BIDV USD'),
    -- Con của 1123: Vàng gửi NH
    ('1123H', '1123', N'Vàng gửi ngân hàng', N'Vàng gửi NH'),
    -- Con của 1131: Tiền chuyển VNĐ
    ('1131C', '1131', N'Tiền Việt Nam đang chuyển', N'Tiền chuyển VNĐ'),
    -- Con của 1132: Tiền chuyển ngoại tệ
    ('1132C', '1132', N'USD đang chuyển', N'USD chuyển'),
    -- Con của 1211: Cổ phiếu
    ('1211C', '1211', N'Cổ phiếu VNM', N'CP VNM'),
    -- Con của 1212: Trái phiếu KD
    ('1212T', '1212', N'Trái phiếu Chính phủ', N'TP Chính phủ'),
    -- Con của 1218: CK khác
    ('1218K', '1218', N'Chứng chỉ quỹ', N'CCQ'),
    -- Con của 1281: Tiền gửi KH
    ('1281T', '1281', N'Tiền gửi có kỳ hạn 12 tháng', N'Gửi KH 12T'),
    -- Con của 1282: Trái phiếu đầu tư
    ('1282T', '1282', N'Trái phiếu doanh nghiệp', N'TP DN'),
    -- Con của 1283: Cho vay
    ('1283V', '1283', N'Cho vay dài hạn', N'Cho vay DH'),
    -- Con của 1288: Đầu tư khác
    ('1288D', '1288', N'Đầu tư khác', N'ĐT khác'),
    -- Con của 1311: Phải thu KH
    ('1311K', '1311', N'Phải thu khách hàng trong nước', N'PT KH trong nước'),
    -- Con của 1331: Thuế GTGT HH
    ('1331T', '1331', N'Thuế GTGT được khấu trừ của hàng hóa', N'Thuế GTGT HH'),
    -- Con của 1332: Thuế GTGT TSCĐ
    ('1332T', '1332', N'Thuế GTGT được khấu trừ của TSCĐ', N'Thuế GTGT TSCĐ'),
    -- Con của 1361: Vốn ĐVTT
    ('1361V', '1361', N'Vốn kinh doanh chi nhánh', N'Vốn CN'),
    -- Con của 1362: PT NB tỷ giá
    ('1362C', '1362', N'Phải thu nội bộ chênh lệch tỷ giá', N'PT NB tỷ giá'),
    -- Con của 1363: PT NB vay
    ('1363P', '1363', N'Phải thu nội bộ chi phí vay vốn hóa', N'PT NB vay VH'),
    -- Con của 1368: PT NB khác
    ('1368K', '1368', N'Phải thu nội bộ khác', N'PT NB khác'),
    -- Con của 1381: TS thiếu
    ('1381H', '1381', N'Hàng hóa thiếu chờ xử lý', N'HH thiếu'),
    -- Con của 1385: PT CPH
    ('1385C', '1385', N'Phải thu về cổ phần hoá', N'PT CPH'),
    -- Con của 1388: PT khác
    ('1388K', '1388', N'Phải thu khác', N'PT khác'),
    -- Con của 1411: Tạm ứng
    ('1411T', '1411', N'Tạm ứng nhân viên', N'Tạm ứng NV'),
    -- Con của 1511: Hàng đi đường
    ('1511H', '1511', N'Hàng nhập khẩu đang về', N'Hàng NK'),
    -- Con của 1521: NVL
    ('1521N', '1521', N'Bột mì', N'Bột mì'),
    -- Con của 1531: CCDC
    ('1531C', '1531', N'Công cụ sản xuất', N'CC SX'),
    -- Con của 1532: Bao bì
    ('1532B', '1532', N'Bao bì carton', N'Bao bì'),
    -- Con của 1533: Đồ cho thuê
    ('1533D', '1533', N'Máy móc cho thuê', N'MM cho thuê'),
    -- Con của 1534: TB phụ tùng
    ('1534T', '1534', N'Phụ tùng máy móc', N'Phụ tùng MM'),
    -- Con của 1541: CP DDDK
    ('1541D', '1541', N'Chi phí sản xuất dở dang', N'CP SX DDDK'),
    -- Con của 1551: TP nhập kho
    ('1551T', '1551', N'Thành phẩm mì gói', N'TP mì gói'),
    -- Con của 1557: TP BĐS
    ('1557B', '1557', N'Căn hộ chưa bán', N'Căn hộ'),
    -- Con của 1561: Giá mua HH
    ('1561G', '1561', N'Giá mua hàng hóa mì', N'Giá mua mì'),
    -- Con của 1562: CP thu mua
    ('1562C', '1562', N'Chi phí vận chuyển', N'CP vận chuyển'),
    -- Con của 1567: HH BĐS
    ('1567B', '1567', N'Đất nền', N'Đất nền'),
    -- Con của 1571: Hàng gửi
    ('1571G', '1571', N'Hàng gửi đại lý', N'Hàng gửi ĐL'),
    -- Con của 1581: Kho bảo thuế
    ('1581K', '1581', N'Hàng NK chưa nộp thuế', N'Hàng kho BT'),
    -- Con của 2111: Nhà cửa
    ('2111N', '2111', N'Nhà xưởng sản xuất', N'Nhà xưởng'),
    -- Con của 2112: Máy móc
    ('2112M', '2112', N'Máy sản xuất mì', N'Máy SX mì'),
    -- Con của 2113: PTVT
    ('2113P', '2113', N'Xe tải', N'Xe tải'),
    -- Con của 2114: TB quản lý
    ('2114T', '2114', N'Máy tính văn phòng', N'Máy tính VP'),
    -- Con của 2115: Cây lâu năm
    ('2115C', '2115', N'Cây cao su', N'Cây cao su'),
    -- Con của 2118: TSCĐ khác
    ('2118K', '2118', N'TSCĐ khác', N'TSCĐ khác'),
    -- Con của 2121: TSCĐ HH thuê TC
    ('2121H', '2121', N'Máy móc thuê tài chính', N'MM thuê TC'),
    -- Con của 2122: TSCĐ VH thuê TC
    ('2122V', '2122', N'Phần mềm thuê tài chính', N'PM thuê TC'),
    -- Con của 2131: QSD đất
    ('2131D', '2131', N'Quyền sử dụng đất lâu dài', N'QSD đất LD'),
    -- Con của 2132: Quyền phát hành
    ('2132Q', '2132', N'Quyền phát hành sách', N'Quyền PH sách'),
    -- Con của 2133: Bản quyền
    ('2133B', '2133', N'Bằng sáng chế', N'Bằng SC'),
    -- Con của 2134: Nhãn hiệu
    ('2134N', '2134', N'Nhãn hiệu Hảo Hảo', N'NH Hảo Hảo'),
    -- Con của 2135: Phần mềm
    ('2135P', '2135', N'Phần mềm SAP', N'PM SAP'),
    -- Con của 2136: Giấy phép
    ('2136G', '2136', N'Giấy phép kinh doanh', N'GP KD'),
    -- Con của 2138: TSCĐ VH khác
    ('2138K', '2138', N'TSCĐ vô hình khác', N'TSCĐ VH khác'),
    -- Con của 2141: HM TSCĐ HH
    ('2141H', '2141', N'Hao mòn nhà xưởng', N'HM nhà xưởng'),
    -- Con của 2142: HM TSCĐ thuê TC
    ('2142T', '2142', N'Hao mòn máy thuê TC', N'HM máy thuê TC'),
    -- Con của 2143: HM TSCĐ VH
    ('2143V', '2143', N'Hao mòn phần mềm', N'HM phần mềm'),
    -- Con của 2147: HM BĐS ĐT
    ('2147B', '2147', N'Hao mòn nhà cho thuê', N'HM nhà thuê'),
    -- Con của 2171: BĐS đầu tư
    ('2171B', '2171', N'Nhà cho thuê', N'Nhà cho thuê'),
    -- Con của 2211: ĐT CTy con
    ('2211C', '2211', N'Đầu tư vào công ty con A', N'ĐT CTy con A'),
    -- Con của 2221: ĐT LĐLK
    ('2221L', '2221', N'Đầu tư liên doanh', N'ĐT LĐ'),
    -- Con của 2281: ĐT góp vốn
    ('2281G', '2281', N'Đầu tư góp vốn', N'ĐT góp vốn'),
    -- Con của 2288: ĐT khác
    ('2288K', '2288', N'Đầu tư khác', N'ĐT khác'),
    -- Con của 2411: Mua sắm TSCĐ
    ('2411M', '2411', N'Mua sắm máy móc', N'Mua sắm MM'),
    -- Con của 2412: XD cơ bản
    ('2412X', '2412', N'Xây dựng nhà xưởng', N'XD nhà xưởng'),
    -- Con của 2413: SCL TSCĐ
    ('2413S', '2413', N'Sửa chữa lớn TSCĐ', N'SCL TSCĐ'),
    -- Con của 2421: CP trả trước NH
    ('2421C', '2421', N'Chi phí trả trước ngắn hạn', N'CP trả trước NH'),
    -- Con của 3311: PT người bán
    ('3311P', '3311', N'Phải trả nhà cung cấp', N'PT NCC'),
    -- Con của 3331: Thuế GTGT
    ('33311', '3331', N'Thuế GTGT đầu ra', N'Thuế GTGT ĐR'),
    ('33312', '3331', N'Thuế GTGT hàng nhập khẩu', N'Thuế GTGT NK'),
    ('3332T', '3331', N'Thuế tiêu thụ đặc biệt', N'Thuế TTĐB'),
    ('3334T', '3331', N'Thuế thu nhập doanh nghiệp', N'Thuế TNDN'),
    ('3335T', '3331', N'Thuế thu nhập cá nhân', N'Thuế TNCN'),
    -- Con của 3341: Lương phải trả
    ('3341L', '3341', N'Phải trả lương công nhân viên', N'Lương PT'),
    -- Con của 3381: Phải trả khác
    ('3381T', '3381', N'Tài sản thừa chờ xử lý', N'TS thừa'),
    ('3382K', '3381', N'Kinh phí công đoàn', N'KP CĐ'),
    ('3383B', '3381', N'Bảo hiểm xã hội', N'BHXH'),
    -- Con của 4111: Vốn CSH
    ('4111V', '4111', N'Vốn góp của chủ sở hữu', N'Vốn CSH'),
    ('41111', '4111', N'Cổ phiếu phổ thông', N'CP phổ thông'),
    -- Con của 4211: LNST CPP
    ('4211L', '4211', N'Lợi nhuận sau thuế chưa phân phối', N'LNST CPP'),
    -- Con của 5111: DT bán HH
    ('5111B', '5111', N'Doanh thu bán hàng hóa mì', N'DT bán mì'),
    -- Con của 5211: Hàng trả lại
    ('5211G', '5211', N'Hàng bán bị trả lại', N'Hàng trả lại'),
    -- Con của 6111: Mua HH
    ('6111M', '6111', N'Mua nguyên liệu bột mì', N'Mua bột mì'),
    -- Con của 6321: GVHB
    ('6321H', '6321', N'Giá vốn hàng bán mì', N'GVHB mì'),
    -- Con của 6411: CP nhân viên BH
    ('6411C', '6411', N'Chi phí nhân viên bán hàng', N'CP nhân viên BH'),
    ('6412B', '6412', N'Chi phí bao bì', N'CP bao bì');
    
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 85 dòng vào TAIKHOANCAP3.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu TAIKHOANCAP3: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 39. SODUDAUKY (40 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu BƯỚC 4: SODUDAUKY (40 dòng) (Cập nhật năm 2025)...';
    INSERT INTO SODUDAUKY (SoTK, SoTKC3, TenTK, SDDKNo, SDDKCo, ThangNam)
    VALUES
    ('TK001', '1111M', N'Tiền mặt Việt Nam', 50000000.00, 0.00, '2025-01-01'),
    ('TK002', '1121H', N'Tiền gửi Vietcombank', 200000000.00, 0.00, '2025-01-01'),
    ('TK003', '1122H', N'Tiền gửi BIDV USD', 150000000.00, 0.00, '2025-01-01'),
    ('TK004', '1311K', N'Phải thu khách hàng', 80000000.00, 0.00, '2025-01-01'),
    ('TK005', '1331T', N'Thuế GTGT được khấu trừ', 15000000.00, 0.00, '2025-01-01'),
    ('TK006', '1521N', N'Bột mì', 120000000.00, 0.00, '2025-01-01'),
    ('TK007', '1561G', N'Giá mua hàng hóa', 250000000.00, 0.00, '2025-01-01'),
    ('TK008', '2111N', N'Nhà xưởng sản xuất', 5000000000.00, 0.00, '2025-01-01'),
    ('TK009', '2112M', N'Máy sản xuất mì', 3000000000.00, 0.00, '2025-01-01'),
    ('TK010', '2113P', N'Xe tải', 800000000.00, 0.00, '2025-01-01'),
    ('TK011', '2131D', N'Quyền sử dụng đất', 2000000000.00, 0.00, '2025-01-01'),
    ('TK012', '2141H', N'Hao mòn TSCĐ hữu hình', 0.00, 1200000000.00, '2025-01-01'),
    ('TK013', '2143V', N'Hao mòn TSCĐ vô hình', 0.00, 200000000.00, '2025-01-01'),
    ('TK014', '3311P', N'Phải trả nhà cung cấp', 0.00, 180000000.00, '2025-01-01'),
    ('TK015', '33311', N'Thuế GTGT đầu ra', 0.00, 25000000.00, '2025-01-01'),
    ('TK016', '3334T', N'Thuế TNDN', 0.00, 35000000.00, '2025-01-01'),
    ('TK017', '3341L', N'Phải trả lương', 0.00, 60000000.00, '2025-01-01'),
    ('TK018', '3383B', N'BHXH', 0.00, 15000000.00, '2025-01-01'),
    ('TK019', '4111V', N'Vốn góp CSH', 0.00, 8500000000.00, '2025-01-01'),
    ('TK020', '41111', N'Cổ phiếu phổ thông', 0.00, 8000000000.00, '2025-01-01'),
    ('TK021', '1111M', N'Tiền mặt Việt Nam', 55000000.00, 0.00, '2025-02-01'),
    ('TK022', '1121H', N'Tiền gửi Vietcombank', 220000000.00, 0.00, '2025-02-01'),
    ('TK023', '1311K', N'Phải thu khách hàng', 75000000.00, 0.00, '2025-02-01'),
    ('TK024', '1331T', N'Thuế GTGT được khấu trừ', 18000000.00, 0.00, '2025-02-01'),
    ('TK025', '1561G', N'Giá mua hàng hóa', 280000000.00, 0.00, '2025-02-01'),
    ('TK026', '2141H', N'Hao mòn TSCĐ hữu hình', 0.00, 1250000000.00, '2025-02-01'),
    ('TK027', '3311P', N'Phải trả nhà cung cấp', 0.00, 160000000.00, '2025-02-01'),
    ('TK028', '33311', N'Thuế GTGT đầu ra', 0.00, 22000000.00, '2025-02-01'),
    ('TK029', '3341L', N'Phải trả lương', 0.00, 58000000.00, '2025-02-01'),
    ('TK030', '1111M', N'Tiền mặt Việt Nam', 60000000.00, 0.00, '2025-03-01'),
    ('TK031', '1121H', N'Tiền gửi Vietcombank', 240000000.00, 0.00, '2025-03-01'),
    ('TK032', '1311K', N'Phải thu khách hàng', 70000000.00, 0.00, '2025-03-01'),
    ('TK033', '1331T', N'Thuế GTGT được khấu trừ', 20000000.00, 0.00, '2025-03-01'),
    ('TK034', '1561G', N'Giá mua hàng hóa', 300000000.00, 0.00, '2025-03-01'),
    ('TK035', '2141H', N'Hao mòn TSCĐ hữu hình', 0.00, 1300000000.00, '2025-03-01'),
    ('TK036', '3311P', N'Phải trả nhà cung cấp', 0.00, 150000000.00, '2025-03-01'),
    ('TK037', '33311', N'Thuế GTGT đầu ra', 0.00, 20000000.00, '2025-03-01'),
    ('TK038', '3341L', N'Phải trả lương', 0.00, 62000000.00, '2025-03-01'),
    ('TK039', '1112N', N'Ngoại tệ USD', 100000000.00, 0.00, '2025-01-01'),
    ('TK040', '2135P', N'Phần mềm SAP', 500000000.00, 0.00, '2025-01-01');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 40 dòng vào SODUDAUKY (Cập nhật năm 2025).';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu SODUDAUKY: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 31. DVTSP (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO DVTSP (MaDVTSP, MaSP, TenDVTSP)
    VALUES
    ('DVT001', 'SP001', N'Ly'),
    ('DVT002', 'SP002', N'Gói'),
    ('DVT003', 'SP003', N'Gói'),
    ('DVT004', 'SP004', N'Gói'),
    ('DVT005', 'SP005', N'Ly'),
    ('DVT006', 'SP006', N'Gói'),
    ('DVT007', 'SP007', N'Gói'),
    ('DVT008', 'SP008', N'Tô'),
    ('DVT009', 'SP009', N'Gói'),
    ('DVT010', 'SP010', N'Gói');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào DVTSP.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu DVTSP: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 31. DONVITINHQUYDOI (10 dòng)
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO DONVITINHQUYDOI (MaDVTQD, MaSP, MaDVTSP, TenQD, SLQD)
    VALUES
    ('QD001', 'SP001', 'DVT001', N'1 Thùng = 24 Ly', 24),
    ('QD002', 'SP002', 'DVT002', N'1 Thùng = 30 Gói', 30),
    ('QD003', 'SP003', 'DVT003', N'1 Thùng = 30 Gói', 30),
    ('QD004', 'SP004', 'DVT004', N'1 Thùng = 30 Gói', 30),
    ('QD005', 'SP005', 'DVT005', N'1 Thùng = 24 Ly', 24),
    ('QD006', 'SP006', 'DVT006', N'1 Thùng = 30 Gói', 30),
    ('QD007', 'SP007', 'DVT007', N'1 Thùng = 30 Gói', 30),
    ('QD008', 'SP008', 'DVT008', N'1 Thùng = 12 Tô', 12),
    ('QD009', 'SP009', 'DVT009', N'1 Thùng = 20 Gói', 20),
    ('QD010', 'SP010', 'DVT010', N'1 Thùng = 30 Gói', 30);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 10 dòng vào DONVITINHQUYDOI.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu DONVITINHQUYDOI: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 27. BUTTOAN (20 dòng) 
BEGIN TRY
    BEGIN TRAN;
    PRINT N'-- Đang chèn dữ liệu BƯỚC 5: BUTTOAN (20 dòng) (Đã đồng bộ hóa với HDB/PTT, Năm 2025)...';
    INSERT INTO BUTTOAN (SoCT, NgayHachToan, DienGiai, TKNo, TKCo, SoTienBT, SLBT, DonGiaBT)
    VALUES
    -- Bút toán 1: Thu tiền (TGNH) + Ghi nhận Doanh thu (HDB001: TT đủ 44.2tr)
    ('BT001', '2025-01-15', N'Ghi nhận DT bán hàng HDB001', '1311K', '5111B', 42000000, 9000, 4667.00), 
    ('BT002', '2025-01-15', N'Thu tiền thanh toán HDB001', '1121H', '1311K', 44200000, 1, 44200000.00), 
    -- Bút toán 2: Thu tiền (TGNH) + Ghi nhận Doanh thu (HDB002: TT đủ 27tr)
    ('BT003', '2025-01-17', N'Ghi nhận DT bán hàng HDB002', '1311K', '5111B', 25000000, 7000, 3571.00), 
    ('BT004', '2025-01-17', N'Thu tiền thanh toán HDB002', '1121H', '1311K', 27000000, 1, 27000000.00), 
    -- Bút toán 3: Ghi nhận công nợ (HDB006: TT cọc 15tr, Công nợ còn 60.1tr)
    ('BT005', '2025-02-18', N'Ghi nhận DT bán hàng HDB006', '1311K', '5111B', 71000000, 18000, 3944.00), 
    ('BT006', '2025-02-18', N'Thu tiền cọc HDB006', '1121H', '1311K', 15000000, 1, 15000000.00), 
    -- Bút toán 4: Thu tiền (TM) + Ghi nhận Doanh thu (HDB003: TT đủ 8.25tr)
    ('BT007', '2025-01-18', N'Ghi nhận DT bán hàng HDB003', '1311K', '5111B', 7500000, 1000, 7500.00), 
    ('BT008', '2025-01-18', N'Thu tiền thanh toán HDB003', '1111M', '1311K', 8250000, 1, 8250000.00), 
    -- Bút toán 5: Ghi nhận công nợ (HDB016: Công nợ 47.5tr, không cọc)
    ('BT009', '2025-06-05', N'Ghi nhận DT công nợ HDB016', '1311K', '5111B', 45000000, 6000, 7500.00), 
    ('BT010', '2025-06-05', N'Ghi nhận thuế GTGT đầu ra HDB016', '1311K', '33311', 4500000, 1, 4500000.00), 
    -- Bút toán 6: Ghi nhận công nợ (HDB017: Công nợ 34tr, cọc 5tr)
    ('BT011', '2025-06-15', N'Ghi nhận DT công nợ HDB017', '1311K', '5111B', 32000000, 4500, 7111.00), 
    ('BT012', '2025-06-15', N'Ghi nhận thuế GTGT đầu ra HDB017', '1311K', '33311', 3200000, 1, 3200000.00), 
    ('BT013', '2025-06-15', N'Thu tiền cọc HDB017', '1121H', '1311K', 5000000, 1, 5000000.00), 
    -- Bút toán 7: Ghi nhận công nợ (HDB019: Công nợ 82.3tr, cọc 15tr)
    ('BT014', '2025-06-25', N'Ghi nhận DT công nợ HDB019', '1311K', '5111B', 78000000, 10000, 7800.00), 
    ('BT015', '2025-06-25', N'Ghi nhận thuế GTGT đầu ra HDB019', '1311K', '33311', 7800000, 1, 7800000.00), 
    ('BT016', '2025-06-25', N'Thu tiền cọc HDB019', '1121H', '1311K', 15000000, 1, 15000000.00), 
    -- Bút toán 8: Ghi nhận Hàng bán bị trả lại 
    ('BT017', '2025-03-01', N'Hàng bán bị trả lại từ KH003', '5211G', '1111M', 1000000, 100, 10000.00), 
    -- Bút toán 9: Ghi nhận Chi phí bán hàng (Bao bì)
    ('BT018', '2025-01-31', N'Chi phí bao bì tháng 1', '6412B', '1532B', 5000000, 1, 5000000.00), 
    -- Bút toán 10: Ghi nhận Giá vốn hàng bán (Giả định giá vốn DDH001 là 35tr)
    ('BT019', '2025-01-15', N'Ghi nhận GVHB DDH001', '6321H', '1551T', 35000000, 9000, 3889.00),
    -- Bút toán 11: Ghi nhận Giá vốn hàng bán (Giả định giá vốn DDH002 là 20tr)
    ('BT020', '2025-01-17', N'Ghi nhận GVHB DDH002', '6321H', '1551T', 20000000, 7000, 2857.00);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào BUTTOAN.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu BUTTOAN: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 28. BAOCAO (20 dòng) - Cập nhật năm 2025
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO BAOCAO (MaBC, MaNV, NgayLapBC, LoaiBC, NoiDungBC, TongGiaTri)
    VALUES
    ('BC001', 'NV001', '2025-01-31', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 1/2025', 200000000.00),
    ('BC002', 'NV001', '2025-02-28', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 2/2025', 250000000.00),
    ('BC003', 'NV001', '2025-03-31', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 3/2025', 280000000.00),
    ('BC004', 'NV005', '2025-01-31', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 1', 150000000.00),
    ('BC005', 'NV005', '2025-02-28', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 2', 165000000.00),
    ('BC006', 'NV005', '2025-03-31', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 3', 170000000.00),
    ('BC007', 'NV009', '2025-01-31', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 1', 45000000.00),
    ('BC008', 'NV009', '2025-02-28', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 2', 38000000.00),
    ('BC009', 'NV009', '2025-03-31', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 3', 40000000.00),
    ('BC010', 'NV001', '2025-04-30', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 4/2025', 310000000.00),
    ('BC011', 'NV001', '2025-05-31', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 5/2025', 350000000.00),
    ('BC012', 'NV005', '2025-04-30', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 4', 175000000.00),
    ('BC013', 'NV005', '2025-05-31', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 5', 180000000.00),
    ('BC014', 'NV009', '2025-04-30', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 4', 35000000.00),
    ('BC015', 'NV009', '2025-05-31', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 5', 42000000.00),
    ('BC016', 'NV001', '2025-06-30', N'Báo Cáo Doanh Thu', N'Doanh thu tháng 6/2025', 320000000.00),
    ('BC017', 'NV005', '2025-06-30', N'Báo Cáo Tồn Kho', N'Tồn kho cuối tháng 6', 185000000.00),
    ('BC018', 'NV009', '2025-06-30', N'Báo Cáo Công Nợ', N'Công nợ khách hàng tháng 6', 48000000.00),
    ('BC019', 'NV001', '2025-06-30', N'Báo Cáo Tổng Hợp', N'Báo cáo quý 2/2025', 980000000.00),
    ('BC020', 'NV013', '2025-06-30', N'Báo Cáo Thanh Toán', N'Thanh toán quý 2/2025', 850000000.00);
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 20 dòng vào BAOCAO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu BAOCAO: ' + ERROR_MESSAGE();
END CATCH;
GO

-- 40. CONGNO 
BEGIN TRY
    BEGIN TRAN;
    INSERT INTO CONGNO (MaCN, MaKH, MaNCC, LoaiCongNo, NgayPhatSinh, HanThanhToan, SoTienNo, SoTienDaTra, TrangThai)
    VALUES
    ('CNPT01', 'KH008', NULL, N'Phải thu', '2025-02-18', '2025-03-18', 75100000, 15000000, N'Đã thanh toán một phần'), 
    ('CNPT02', 'KH013', NULL, N'Phải thu', '2025-03-25', '2025-04-25', 101700000, 20000000, N'Đã thanh toán một phần'), 
    ('CNPT03', 'KH018', NULL, N'Phải thu', '2025-05-15', '2025-06-15', 158000000, 30000000, N'Quá hạn'), 
    ('CNPT04', 'KH020', NULL, N'Phải thu', '2025-06-05', '2025-07-05', 47500000, 0, N'Chưa thanh toán'), 
    ('CNPT05', 'KH002', NULL, N'Phải thu', '2025-06-15', '2025-07-15', 34000000, 5000000, N'Chưa thanh toán'), 

    ('CNPR01', NULL, 'NCC002', N'Phải trả', '2025-01-10', '2025-02-10', 5000000, 5000000, N'Đã thanh toán đủ'), 
    ('CNPR02', NULL, 'NCC006', N'Phải trả', '2025-02-01', '2025-03-01', 8000000, 0, N'Quá hạn'), 
    ('CNPR03', NULL, 'NCC019', N'Phải trả', '2025-01-01', '2025-02-01', 10000000, 10000000, N'Đã thanh toán đủ');
    COMMIT TRAN;
    PRINT N'✓ Đã thêm 8 dòng vào CONGNO.';
END TRY
BEGIN CATCH
    ROLLBACK TRAN;
    PRINT N'✗ Lỗi khi chèn dữ liệu CONGNO: ' + ERROR_MESSAGE();
END CATCH;
GO

PRINT N'';
PRINT N'================================================';
PRINT N'  ✔ HOÀN THÀNH THÊM DỮ LIỆU CHO CÁC BẢNG';
PRINT N'================================================';
GO

