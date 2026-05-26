# 🍜 Hệ Thống Thông Tin Kế Toán Quản Lý Bán Hàng – ACECOOK Việt Nam

> Đồ án học phần **Hệ Thống Thông Tin Kế Toán** – Trường Đại học Tài chính Marketing

---

## 📋 Giới Thiệu

Dự án xây dựng **Hệ thống Thông tin Kế toán Quản lý Bán hàng** cho Công ty Cổ phần ACECOOK Việt Nam – một trong những nhà sản xuất mì ăn liền hàng đầu Việt Nam (thành lập 15/12/1993, chuyển đổi thành Công ty Cổ phần ngày 18/1/2008). Hệ thống hỗ trợ toàn bộ quy trình kinh doanh từ quản lý khách hàng, đơn hàng, kho hàng, kế toán đến báo cáo thống kê.

---

## 🛠️ Công Nghệ Sử Dụng

| Thành phần | Công nghệ |
|---|---|
| Ngôn ngữ lập trình | C# (.NET) |
| Giao diện | Windows Forms (Desktop Application) |
| Hệ quản trị CSDL | Microsoft SQL Server |
| Công cụ phân tích | Enterprise Architect, Draw.io, PowerDesigner |
| IDE | Microsoft Visual Studio |

---

## ✨ Tính Năng Chính

### 👥 Kinh Doanh
- **Quản lý Khách hàng** – Thêm, xem, chỉnh sửa, xóa thông tin khách hàng; phân loại theo loại khách hàng; xem lịch sử mua hàng
- **Quản lý Đơn hàng** – Tạo đơn hàng mới, chỉnh sửa, theo dõi trạng thái đơn hàng, duyệt đơn hàng, lập lệnh bán hàng

### 📦 Kho Hàng
- **Quản lý Sản phẩm & Nguyên vật liệu** – Thêm, xem, cập nhật thông tin sản phẩm; quản lý nguyên vật liệu và định mức sản xuất
- **Quản lý Tồn kho** – Kiểm tra tồn kho real-time, nhập kho, xuất kho; báo cáo tồn kho theo thời điểm
- **Quản lý Nhà cung cấp** – Thêm, xem, cập nhật thông tin nhà cung cấp; ghi nhận dừng giao dịch

### 💰 Kế Toán
- **Quản lý Công nợ** – Theo dõi công nợ khách hàng và phải trả nhà cung cấp
- **Quản lý Hóa đơn** – Lập hóa đơn bán hàng, phiếu thanh toán nhà cung cấp, cập nhật trạng thái thanh toán
- **Bút toán Kế toán** – Ghi nhận bút toán, quản lý tài khoản kế toán đa cấp (cấp 1, 2, 3), số dư đầu kỳ

### 📊 Báo Cáo & Thống Kê
- Báo cáo doanh thu
- Báo cáo tồn kho
- Báo cáo đơn hàng
- Báo cáo công nợ khách hàng
- Báo cáo phải trả nhà cung cấp

### 🔐 Quản Trị Hệ Thống
- Đăng nhập / Đăng xuất bảo mật
- Quên mật khẩu / Đổi mật khẩu
- Quản lý người dùng
- Phân quyền theo vai trò (RBAC – Role-Based Access Control)

---

## 📸 Giao Diện Minh Họa

| Màn hình | Mô tả |
|---|---|
| Đăng nhập | Xác thực tài khoản người dùng |
| Quản lý Khách hàng | Danh sách và thao tác CRUD khách hàng |
| Quản lý Sản phẩm | Danh sách sản phẩm và nguyên vật liệu |
| Bút toán Kế toán | Ghi nhận và quản lý bút toán |
| Báo cáo Tồn kho | Thống kê tồn kho toàn hệ thống |

---

## 🗄️ Cơ Sở Dữ Liệu

Hệ thống sử dụng **Microsoft SQL Server** với các nhóm bảng chính:

- **Nhân sự & Phân quyền:** `NHANVIEN`, `PHONGBAN`, `CHUCVU`, `TAIKHOAN`, `VAITRO`, `QUYEN`, `LOAIQUYEN`
- **Kinh doanh:** `DONDATHANG`, `CT_DH`, `LENHBANHANG`, `HOADONBAN`, `KHACHHANG`, `LOAIKHACHHANG`
- **Kho hàng:** `SANPHAM`, `LOAISANPHAM`, `NGUYENLIEU`, `KHO`, `TONKHO`, `PHIEUNHAPKHO`, `CHITIET_PN`, `PHIEUXUAT`, `CT_PX`
- **Nhà cung cấp:** `NHACUNGCAP`, `CT_CC`, `PHIEUTHANHTOANNCC`
- **Kế toán:** `TAIKHOANCAP1`, `TAIKHOANCAP2`, `TAIKHOANCAP3`, `BUTTOAN`, `SODUDAUKY`, `PHIEUTHU`, `PHIEUCHI`
- **Khuyến mãi:** `CTKM`, `CT_KM`, `THETV`
- **Khác:** `BAOCAO`, `DVTSP`, `DONVITINHQUYDOI`, `NGANHANG`

---

## 📐 Phân Tích & Thiết Kế Hệ Thống

Dự án áp dụng đầy đủ quy trình phân tích và thiết kế hệ thống thông tin kế toán:

- **BFD** (Business Function Diagram) – Mô hình phân rã chức năng
- **DFD** (Data Flow Diagram) – Mô hình luồng dữ liệu
- **ERD** (Entity Relationship Diagram) – Mô hình quan hệ thực thể
- **Use Case Diagram** – Sơ đồ use case mức tổng thể và chi tiết
- **Lưu đồ chứng từ** – Mô tả quy trình xử lý chứng từ kế toán

---

## 🚀 Hướng Dẫn Cài Đặt

### Yêu Cầu Hệ Thống

- Windows 10/11
- .NET Framework (phiên bản tương thích với Visual Studio)
- Microsoft SQL Server 2019 trở lên
- Microsoft Visual Studio 2022

### Các Bước Cài Đặt

1. **Clone repository**
   ```bash
   git clone <repository-url>
   cd acecook-accounting-system
   ```

2. **Khôi phục CSDL**
   - Mở SQL Server Management Studio (SSMS)
   - Restore file backup CSDL (`.bak`) hoặc chạy script SQL trong thư mục `/Database`

3. **Cấu hình Connection String**
   - Mở file `App.config` hoặc `appsettings.json`
   - Cập nhật chuỗi kết nối theo thông tin SQL Server của bạn:
   ```xml
   <connectionStrings>
     <add name="AcecookDB"
          connectionString="Server=YOUR_SERVER;Database=AcecookDB;Integrated Security=True;"
          providerName="System.Data.SqlClient"/>
   </connectionStrings>
   ```

4. **Build & Run**
   - Mở file `.sln` bằng Visual Studio
   - Build solution (`Ctrl + Shift + B`)
   - Chạy ứng dụng (`F5`)

### Tài Khoản Mặc Định (Demo)

| Tài khoản | Mật khẩu | Vai trò |
|---|---|---|
| `ltthuha` | `ThuHa@456` | Kế toán trưởng |

> ⚠️ **Lưu ý:** Thay đổi mật khẩu mặc định sau khi cài đặt lần đầu.

---

## 📁 Cấu Trúc Dự Án

```
AcecookAccountingSystem/
├── Forms/                  # Các form giao diện (Windows Forms)
│   ├── Login/              # Đăng nhập
│   ├── Customer/           # Quản lý khách hàng
│   ├── Order/              # Quản lý đơn hàng
│   ├── Product/            # Quản lý sản phẩm
│   ├── Inventory/          # Quản lý kho
│   ├── Supplier/           # Quản lý nhà cung cấp
│   ├── Accounting/         # Kế toán (công nợ, hóa đơn, bút toán)
│   └── Report/             # Báo cáo thống kê
├── Models/                 # Các lớp thực thể (Entity classes)
├── DAL/                    # Data Access Layer
├── BLL/                    # Business Logic Layer
├── Database/               # Script SQL và backup CSDL
└── Resources/              # Tài nguyên (hình ảnh, icon)
```

---

## 📚 Tài Liệu Tham Khảo

- Báo cáo đồ án học phần Hệ thống Thông tin Kế toán
- Microsoft SQL Server Documentation
- C# Windows Forms Documentation – Microsoft Docs
- Giáo trình Hệ thống Thông tin Kế toán – Trường ĐH Tài chính Marketing

---

## 📄 Giấy Phép

Dự án được thực hiện phục vụ mục đích học thuật tại **Trường Đại học Tài chính Marketing**, Khoa Khoa học Dữ liệu.

© 2025 – Acecook Việt Nam. All rights reserved.
