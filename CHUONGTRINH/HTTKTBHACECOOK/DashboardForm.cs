using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HTTKTBHACECOOK
{
    public partial class DashboardForm : Form
    {
        // CHUỖI KẾT NỐI HỆ THỐNG
        private const string CONNECTION_STRING = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLKTBHACECOOK;Persist Security Info=True;User ID=sa;Password=123;Encrypt=False";

        private string CurrentMaVT;
        private string CurrentHoTenNV;
        private Timer clockTimer;

        // Constructor
        public DashboardForm(string maVaiTro, string hoTenNV)
        {
            InitializeComponent();
            this.CurrentMaVT = maVaiTro;
            this.CurrentHoTenNV = hoTenNV;

            this.Text = "Hệ thống thông tin kế toán quản lý bán hàng ACECOOK - " + hoTenNV;

            InitializeClock();
        }

        // Sự kiện Load Form
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            SetupUserInfo();
            SetupVisualStyling();
            // Thiết lập hover effects cho các nút menu
            SetupMenuHoverEffects();
            ApplyAccessControl(CurrentMaVT);

            // TẢI FORM MẶC ĐỊNH KHI KHỞI ĐỘNG: Quản lý Khách hàng
            HighlightActiveMenu(btn_QL_KhachHang);
            LoadChildForm(new CustomerManagementForm(CONNECTION_STRING));
        }

        // --- CÁC HÀM TIỆN ÍCH HỆ THỐNG ---

        private void InitializeClock()
        {
            clockTimer = new Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
            UpdateClock();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            DateTime now = DateTime.Now;
            string[] daysOfWeek = { "Chủ Nhật", "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy" };
            string dayName = daysOfWeek[(int)now.DayOfWeek];
            lblCurrentTime.Text = $"📅  {dayName}, {now:dd/MM/yyyy} - {now:HH:mm:ss}";
        }

        private void SetupUserInfo()
        {
            lblUsername.Text = CurrentHoTenNV;
            lblStatus.Text = "🟢  " + GetRoleName(CurrentMaVT);
            // Có thể thêm logic thiết lập màu sắc trạng thái cho lblStatus ở đây
        }

        private void SetupVisualStyling()
        {
            // Thiết lập font chữ, màu sắc, đổ bóng chung cho Dashboard
            // Đảm bảo lblHeaderKinhDoanh.Visible = true; nếu muốn hiển thị header nhóm Kinh Doanh
            lblHeaderKinhDoanh.Visible = true;
            lblHeaderKinhDoanh.Height = 36; // Thiết lập lại chiều cao vì Designer set là 0
        }

        private void SetupMenuHoverEffects()
        {
            // Thiết lập hiệu ứng hover cho tất cả các nút menu nếu cần
            // Ví dụ: btn_QL_KhachHang.MouseEnter += MenuButton_MouseEnter;
            //         btn_QL_KhachHang.MouseLeave += MenuButton_MouseLeave;
        }

        private string GetRoleName(string maVT)
        {
            switch (maVT)
            {
                case "VT001": return "Quản Trị Viên";
                case "VT002": return "Kế Toán Trưởng";
                case "VT006": return "Nhân Viên Kế Toán";
                case "VT007": return "Nhân Viên Bán Hàng";
                case "VT008": return "Nhân Viên Kho";
                case "VT010": return "Kế Toán Công Nợ";
                default: return "Nhân Viên";
            }
        }

        private void ApplyAccessControl(string maVT)
        {
            // Ẩn tất cả các nút menu
            HideAllMenuButtons();

            // Hiển thị các nút dựa trên mã vai trò (maVT)
            if (maVT == "VT001" || maVT == "VT002") // Admin & Kế Toán Trưởng: Full quyền
            {
                ShowSalesMenu(true);
                ShowWarehouseMenu(true);
                ShowAccountingMenu(true);
                ShowReportMenu(true);
            }
            else if (maVT == "VT007") // Nhân Viên Bán Hàng: Kinh doanh và báo cáo doanh thu
            {
                ShowSalesMenu(true);
                btn_BaoCao_DT.Visible = true;
            }
            else if (maVT == "VT008") // Nhân Viên Kho: Kho hàng và báo cáo tồn kho
            {
                ShowWarehouseMenu(true);
                btn_BaoCao_TK.Visible = true;
            }
            else if (maVT == "VT006") // Nhân Viên Kế Toán: Kế toán và báo cáo
            {
                ShowAccountingMenu(true);
                ShowReportMenu(true);
            }
            else if (maVT == "VT010") // Kế Toán Công Nợ: Công nợ, hóa đơn, bút toán
            {
                lblHeaderKeToan.Visible = true;
                btn_QL_CongNo.Visible = true;
                btn_QL_HoaDon.Visible = true;
                btn_QL_ButToan.Visible = true;

                lblHeaderBaoCao.Visible = true;
                btn_BaoCao_DT.Visible = true;
            }
        }

        private void HideAllMenuButtons()
        {
            // Ẩn tất cả các header và nút menu
            lblHeaderKinhDoanh.Visible = false;
            btn_QL_KhachHang.Visible = false;
            btn_QL_DonHang.Visible = false;
            btn_QL_SanPham.Visible = false;

            lblHeaderKho.Visible = false;
            btn_QL_TonKho.Visible = false;
            btn_QL_NCC.Visible = false; // NCC nằm dưới header Kho trong Designer

            lblHeaderKeToan.Visible = false;
            btn_QL_CongNo.Visible = false;
            btn_QL_HoaDon.Visible = false;
            btn_QL_ButToan.Visible = false;

            lblHeaderBaoCao.Visible = false;
            btn_BaoCao_DT.Visible = false;
            btn_BaoCao_TK.Visible = false;
            btn_BaoCao_DH.Visible = false;

            // Nút Đăng xuất luôn hiển thị
            btnSeparatorLogout.Visible = true;
            btn_Logout.Visible = true;
        }

        // Các hàm hiển thị menu nhóm
        private void ShowSalesMenu(bool isVisible)
        {
            lblHeaderKinhDoanh.Visible = isVisible;
            btn_QL_KhachHang.Visible = isVisible;
            btn_QL_DonHang.Visible = isVisible;
        }
        private void ShowWarehouseMenu(bool isVisible)
        {
            lblHeaderKho.Visible = isVisible;
            btn_QL_SanPham.Visible = isVisible;
            btn_QL_TonKho.Visible = isVisible;
            btn_QL_NCC.Visible = isVisible;
        }
        private void ShowAccountingMenu(bool isVisible)
        {
            lblHeaderKeToan.Visible = isVisible;
            btn_QL_NCC.Visible = isVisible; // NCC có thể dùng cho Kho và Kế toán
            btn_QL_CongNo.Visible = isVisible;
            btn_QL_HoaDon.Visible = isVisible;
            btn_QL_ButToan.Visible = isVisible;
        }
        private void ShowReportMenu(bool isVisible)
        {
            lblHeaderBaoCao.Visible = isVisible;
            btn_BaoCao_DT.Visible = isVisible;
            btn_BaoCao_TK.Visible = isVisible;
            btn_BaoCao_DH.Visible = isVisible; // Báo cáo Đơn hàng
        }


        // --- XỬ LÝ SỰ KIỆN MENU CLICK ---

        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            HighlightActiveMenu(clickedButton);

            // Cập nhật tiêu đề
            string menuText = clickedButton.Text.Trim();
            // Xử lý loại bỏ icon emoji (nếu có)
            if (menuText.Length > 2 && char.IsControl(menuText[0]) == false && menuText[0] >= 0x1F300)
            {
                menuText = menuText.Substring(2).Trim();
            }
            lblSystemTitle.Text = "Hệ thống quản lý - " + menuText;

            // LOGIC TẢI FORM CON
            Form childFormToLoad = null;

            if (clickedButton == btn_QL_KhachHang)
            {
                childFormToLoad = new CustomerManagementForm(CONNECTION_STRING);
            }
            else if (clickedButton == btn_QL_NCC) // SupplierForm
            {
                childFormToLoad = new SupplierForm(CONNECTION_STRING);
            }
            else if (clickedButton == btn_QL_DonHang)
            {
                childFormToLoad = new OrderManagementForm(CONNECTION_STRING);
            }
            else if (clickedButton == btn_QL_SanPham)
            {
                childFormToLoad = new ProductManagementForm(CONNECTION_STRING);
            }
            // KHO
            else if (clickedButton == btn_QL_TonKho) // InventoryManagementForm (Quản lý nhập/xuất kho)
            {
                // KHẮC PHỤC LỖI CS0121: Khai báo rõ ràng namespace
                childFormToLoad = new HTTKTBHACECOOK.InventoryManagementForm(CONNECTION_STRING);
            }
            // KẾ TOÁN
            else if (clickedButton == btn_QL_HoaDon) // InvoiceManagementForm (Quản lý hóa đơn/chứng từ)
            {
                // KHẮC PHỤC LỖI CS1729: Gọi constructor với 1 tham số string (Giả định constructor đã được thêm vào InvoiceManagementForm.cs)
                childFormToLoad = new InvoiceManagementForm(CONNECTION_STRING);
            }
            else if (clickedButton == btn_QL_ButToan) // JournalEntryManagementForm (Quản lý bút toán/sổ nhật ký)
            {
                childFormToLoad = new JournalEntryManagementForm(CONNECTION_STRING);
            }
            else if (clickedButton == btn_QL_CongNo) // DebtManagementForm
            {
                childFormToLoad = new DebtManagementForm(CONNECTION_STRING);
            }
            // BÁO CÁO
            else if (clickedButton == btn_BaoCao_DT) // SalesRevenueReportForm
            {
                childFormToLoad = new SalesRevenueReportForm(CONNECTION_STRING);
            }
            else if (clickedButton == btn_BaoCao_TK) // InventoryReport
            {
                childFormToLoad = new InventoryReport(CONNECTION_STRING);
            }
            else if (clickedButton == btn_BaoCao_DH) // Báo cáo Đơn hàng (Giả định hiển thị báo cáo chi tiết đơn hàng)
            {
                childFormToLoad = new OrderReportForm(CONNECTION_STRING); // Hoặc một form báo cáo riêng nếu có
            }

            // Tải Form
            if (childFormToLoad != null)
            {
                LoadChildForm(childFormToLoad);
            }
        }

        // HÀM LOAD FORM CON
        private void LoadChildForm(Form childForm)
        {
            if (pnlMainContent.Controls.Count > 0)
            {
                pnlMainContent.Controls.Clear();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(childForm);
            childForm.Show();
        }

        private void HighlightActiveMenu(Button activeButton)
        {
            // Đặt lại màu cho tất cả các nút menu về màu mặc định
            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Button button && button != btn_Logout)
                {
                    button.BackColor = Color.FromArgb(30, 39, 46); // Màu nền pnlSidebar
                    button.ForeColor = Color.FromArgb(189, 195, 199);
                }
            }

            // Đặt màu nổi bật cho nút đang hoạt động
            activeButton.BackColor = Color.FromArgb(0, 122, 204); // Màu xanh dương nổi bật
            activeButton.ForeColor = Color.White;
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            // Logic đăng xuất
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                // Giả định có LoginForm để quay lại
                LoginForm login = new LoginForm();
                login.Show();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            clockTimer?.Stop();
            base.OnFormClosing(e);
        }
    }
}