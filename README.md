# Sales Management Database System (Acecook Vietnam Case Study)


> **Academic course project** — End-to-end design and implementation of a sales management database system for a real-world FMCG enterprise environment, covering business analysis, database design, advanced SQL Server features, and application development.

---

## Business Problem

Manual sales workflows at Acecook Vietnam create bottlenecks in order processing, inventory tracking, invoicing, payment management, and reporting. This project models a structured database solution to digitise and automate these processes across the entire sales pipeline — from order placement to revenue reporting.

---

## Functional Scope

| Module | Key Capabilities |
|---|---|
| Customer Management | Customer profiles, classification (retail/agency/supermarket), debt tracking, membership cards |
| Product Management | Product catalogue (Hảo Hảo, Đệ Nhất, Lẩu Thái…), pricing, promotions, unit conversion |
| Order Management | Order creation, status tracking (pending → approved → delivered → paid) |
| Warehouse Management | Multi-warehouse inventory, import/export slips, minimum stock alerts |
| Supplier Management | Supplier profiles, material supply contracts, payable debt tracking |
| Invoicing | Export slips linked to orders, VAT invoices with tax calculation |
| Payment & Receivables | Partial payment support, invoice status, accounts receivable/payable tracking |
| User & Access Control | RBAC (Role-Based Access Control), login audit log, account lockout |
| Reporting & Statistics | Revenue by product/customer/period, inventory reports, top-selling products |

---

## Tech Stack

| Layer | Technology |
|---|---|
| Database | SQL Server (SSMS, SQL Server 2021) |
| DB Design | PowerDesigner (CDM → LDM → PDM) |
| Application | C# (.NET Framework 4.8), WinForms |
| Query Language | T-SQL |

---

## Database Design

The database is designed across three levels following standard methodology:

- **Conceptual (CDM)** — Entity-Relationship Diagram with 20+ entities
- **Logical (LDM)** — Normalised relational model with primary/foreign keys
- **Physical (PDM)** — Final schema deployed on SQL Server with full constraints

**Core tables include:** NhanVien, TaiKhoan, KhachHang, SanPham, DonDatHang, PhieuXuat, HoaDon, PhieuThanhToan, TonKho, PhieuNhap, NhaCungCap, CTKM, VaiTro, and 10+ junction/detail tables.

**Integrity constraints implemented:**
- Domain constraints (e.g. TenThe ∈ {Vàng, Bạc, Kim cương, VIP})
- Inter-attribute constraints (e.g. HSD > NgaySX, DonGiaSP ≥ GiaNhapSP)
- Tuple constraints (e.g. TonKho ≥ 0, MatKhau length ≥ 6)
- Referential constraints (e.g. NhanVien → PhongBan, DonDatHang → KhachHang)

---

## SQL Server Features Implemented

### Synonym
Aliases created for core tables (SanPham, DonDatHang, TaiKhoan) to simplify queries and decouple object names from physical locations, supporting cross-database access.

### Index
- **Clustered Index** on primary keys (MaKH, MaSP, MaDDH)
- **Non-Clustered Index** on frequently filtered columns (SDTKH, MaLoaiKH, NgayDatHang)
- Applied to KhachHang, DonDatHang, PhieuNhap, PhieuXuat tables

### View
- `v_DanhSachKhachHang` — Customer contact list
- `v_BaoCaoDonHangChiTiet` — Detailed order report
- `v_TongHopNhapXuat` — Warehouse import/export summary
- `v_KhachHangSieuThi` — Filtered view: supermarket customers only
- `v_HieuQuaKinhDoanh` — Business performance by product category

### Function
- `fn_TinhTongTienDonHang` — Calculate total order value
- `fn_TimSanPhamTheoGia` — Filter products by price range
- `fn_BaoCaoTonKho` — Inventory report with stock status evaluation

### Stored Procedure
- `sp_ThemKhachHangMoi` — Add new customer
- `sp_TaoDonDatHang` — Create new order
- `sp_DuyetDonHang` — Approve order
- `sp_HuyDonHang` — Cancel order
- `sp_ThanhToanCongNo` — Process debt payment
- `sp_LichSuMuaHang` — Customer purchase history
- `sp_KiemTraHeThong` — System health check
- `sp_XuLyDonHang_Transaction` — Full order processing with ACID transaction

### Trigger
- DML: Check inventory on order creation; auto-update customer debt on invoicing; restore stock on order line deletion
- DDL: Audit log for schema changes (table structure modifications)
- LOGON: Limit concurrent logins; auto-log every login event

### User & Role (RBAC)
- Roles mapped from VaiTro table: Role_BanHang, Role_ThuKho, Role_KeToan, etc.
- Password encryption/decryption using SHA2 hashing
- GRANT permissions assigned per role with detailed access control

### Transaction & Isolation
- Explicit transactions (BEGIN TRAN / COMMIT / ROLLBACK) with TRY…CATCH
- READ COMMITTED isolation level tested against Dirty Read and Non-Repeatable Read scenarios
- UPDLOCK applied to prevent Lost Update in concurrent order processing

### Backup & Restore
- Full backup to `.bak` file using BACKUP DATABASE
- Restore via file attach (`.mdf` + `.ldf`) using SSMS Attach workflow

---

## WinForms Application

A desktop application (C# / WinForms) connects to the SQL Server database to demonstrate core business functions:

- **Login** — Credential authentication with role-based session loading
- **Customer Management** — Full CRUD for customer records and classification
- **Order Management** — Order lifecycle tracking from creation to payment
- **Revenue Report** — Summary, by-product, and chart tabs with date filtering
- **Access Control** — Dynamic menu visibility based on user role (RBAC)
- **Change Password** — Secure password update with old-password verification

---

## Key Outcomes

- Fully normalised relational database with 30+ tables deployed on SQL Server
- Complete business logic layer via Stored Procedures, Functions, Triggers, and Views
- RBAC security model with encrypted credentials and login auditing
- ACID-compliant transaction management with concurrency control
- Automated sales tracking, inventory management, and real-time reporting
- WinForms UI demonstrating end-to-end sales workflow

---


## Project Info

| | |
|---|---|
| Course | Hệ thống thông tin kế toán |
| Institution | University of Finance and Marketing (UFM), Ho Chi Minh City |
| Completed | December 2025 |
