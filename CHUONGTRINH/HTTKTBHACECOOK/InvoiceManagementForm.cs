using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
// Import InvoiceAddForm để sử dụng Enum FormMode
using static HTTKTBHACECOOK.InvoiceAddForm;

namespace HTTKTBHACECOOK
{
    public partial class InvoiceManagementForm : Form
    {
        private string CONNECTION_STRING;
        private string searchPlaceholder = "Nhập mã hóa đơn, tên khách hàng hoặc nhân viên...";

        // Constructor
        public InvoiceManagementForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
        }

        private void InvoiceManagementForm_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            SetupSearchPlaceholder();
            SetupFilterComboBox();
            LoadInvoiceData();

            // Đăng ký sự kiện định dạng cell
            dgvInvoices.CellFormatting += dgvInvoices_CellFormatting;
        }

        // --- SETUP ---

        private void SetupVisualStyling()
        {
            dgvInvoices.AutoGenerateColumns = false;
            SetupButtonHoverEffects();
        }

        private void SetupButtonHoverEffects()
        {
            SetButtonHover(btnAdd, "#0B5ED7", "#0D6EFD");       // Thêm - Blue
            SetButtonHover(btnViewDetail, "#1AA2BA", "#17A2B8");// Xem - Cyan
            SetButtonHover(btnEdit, "#FFCA2C", "#FFC107");      // Sửa - Yellow
            SetButtonHover(btnDelete, "#BB2D3B", "#DC3545");    // Xóa - Red
            SetButtonHover(btnPrint, "#1E7E4E", "#198754");     // In - Green
            SetButtonHover(btnSearch, "#0B5ED7", "#007BFF");    // Tìm - Blue
            SetButtonHover(btnRefresh, "#5A6268", "#6C757D");   // Làm mới - Grey
        }

        private void SetButtonHover(Button btn, string hoverColor, string normalColor)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml(hoverColor);
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml(normalColor);
        }

        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");

            txtSearch.Enter += (sender, e) => {
                if (txtSearch.Text == searchPlaceholder) { txtSearch.Text = ""; txtSearch.ForeColor = ColorTranslator.FromHtml("#495057"); }
            };
            txtSearch.Leave += (sender, e) => {
                if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = searchPlaceholder; txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD"); }
            };
            txtSearch.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); e.Handled = true; e.SuppressKeyPress = true; }
            };
        }

        private void SetupFilterComboBox()
        {
            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Đã thanh toán", "Chưa thanh toán", "Đã hủy" });
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndexChanged += (s, e) => LoadInvoiceData(GetKeyword(), GetStatusFilter());
        }

        private string GetKeyword() => (txtSearch.Text == searchPlaceholder) ? "" : txtSearch.Text.Trim();

        private string GetStatusFilter()
        {
            switch (cmbFilterStatus.SelectedIndex)
            {
                case 1: return " AND DDH.TrangThaiDH = N'Đã giao'";
                case 2: return " AND (DDH.TrangThaiDH = N'Đang xử lý' OR DDH.TrangThaiDH = N'Đang giao')";
                case 3: return " AND DDH.TrangThaiDH = N'Đã hủy'";
                default: return "";
            }
        }

        // --- LOAD DỮ LIỆU ---

        private void LoadInvoiceData(string keyword = "", string statusFilter = "")
        {
            try
            {
                string query = @"
                    SELECT 
                        HD.SoHDB AS MaHD,
                        HD.NgayLapHDB AS NgayLapHD,
                        KH.TenKH,
                        NV.HoTenNV AS TenNV,
                        HD.TriGiaSauGiam AS TongTien,
                        DDH.TrangThaiDH AS TrangThai, 
                        DDH.PhuongThucThanhToan
                    FROM HOADONBAN HD
                    INNER JOIN DONDATHANG DDH ON HD.MaDDH = DDH.MaDDH
                    INNER JOIN KHACHHANG KH ON DDH.MaKH = KH.MaKH
                    INNER JOIN NHANVIEN NV ON DDH.MaNV = NV.MaNV
                    WHERE 
                        (@Keyword = '' 
                        OR HD.SoHDB LIKE @Keyword 
                        OR KH.TenKH LIKE @Keyword
                        OR NV.HoTenNV LIKE @Keyword)
                        " + statusFilter + @"
                    ORDER BY HD.NgayLapHDB DESC, HD.SoHDB DESC";

                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Keyword", $"%{keyword}%");
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvInvoices.DataSource = dt;

                    object sumObj = dt.Compute("Sum(TongTien)", "");
                    UpdateStats(dt.Rows.Count, (sumObj != DBNull.Value) ? Convert.ToDecimal(sumObj) : 0);
                }
            }
            catch (Exception ex) { ShowError("Lỗi tải dữ liệu", ex.Message); }
        }

        private void UpdateStats(int count, decimal totalAmount)
        {
            lblStatsCount.Text = $"{count} HD";
            lblTotalAmount.Text = $"{totalAmount:N0} VNĐ";
        }

        // --- XỬ LÝ SỰ KIỆN ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (InvoiceAddForm addForm = new InvoiceAddForm(CONNECTION_STRING))
            {
                if (addForm.ShowDialog() == DialogResult.OK) LoadInvoiceData();
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (CheckSelection())
            {
                string maHD = dgvInvoices.SelectedRows[0].Cells["MaHD"].Value.ToString();
                using (InvoiceAddForm viewForm = new InvoiceAddForm(CONNECTION_STRING, maHD, FormMode.View))
                {
                    viewForm.ShowDialog();
                }
            }
        }

        // --- NÚT SỬA (MỚI THÊM) ---
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckSelection())
            {
                string maHD = dgvInvoices.SelectedRows[0].Cells["MaHD"].Value.ToString();
                using (InvoiceAddForm editForm = new InvoiceAddForm(CONNECTION_STRING, maHD, FormMode.Edit))
                {
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadInvoiceData();
                        ShowSuccess("Cập nhật thành công!");
                    }
                }
            }
        }
        // ---------------------------

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckSelection())
            {
                string maHD = dgvInvoices.SelectedRows[0].Cells["MaHD"].Value.ToString();
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn {maHD}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteInvoice(maHD);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (CheckSelection()) btnViewDetail_Click(sender, e); // Mở form chi tiết để in
        }

        private void btnSearch_Click(object sender, EventArgs e) => LoadInvoiceData(GetKeyword(), GetStatusFilter());

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            cmbFilterStatus.SelectedIndex = 0;
            LoadInvoiceData();
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        private bool CheckSelection()
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                ShowWarning("Chưa chọn", "Vui lòng chọn một hóa đơn để thao tác.");
                return false;
            }
            return true;
        }

        // --- XÓA HÓA ĐƠN ---
        private void DeleteInvoice(string maHD)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Lấy MaDDH để xóa chi tiết
                    string getDDH = "SELECT MaDDH FROM HOADONBAN WHERE SoHDB = @MaHD";
                    string maDDH = new SqlCommand(getDDH, connection, transaction).ExecuteScalar()?.ToString();

                    // 1. Xóa Hóa đơn
                    new SqlCommand($"DELETE FROM HOADONBAN WHERE SoHDB = '{maHD}'", connection, transaction).ExecuteNonQuery();

                    // 2. Xóa Chi tiết Đơn hàng (nếu cần thiết, tùy logic nghiệp vụ)
                    // new SqlCommand($"DELETE FROM CT_DH WHERE MaDDH = '{maDDH}'", connection, transaction).ExecuteNonQuery();
                    // 3. Xóa Đơn hàng
                    // new SqlCommand($"DELETE FROM DONDATHANG WHERE MaDDH = '{maDDH}'", connection, transaction).ExecuteNonQuery();

                    transaction.Commit();
                    ShowSuccess($"Đã xóa hóa đơn {maHD}");
                    LoadInvoiceData();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ShowError("Lỗi xóa", ex.Message);
                }
            }
        }

        // --- ĐỊNH DẠNG ---

        private void dgvInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInvoices.Columns[e.ColumnIndex].Name == "TongTien" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal val)) e.Value = val.ToString("N0") + " VNĐ";
            }
            if (dgvInvoices.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Đã giao")
                {
                    e.Value = "Đã thanh toán";
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#155724");
                }
                else if (status == "Đang xử lý" || status == "Đang giao")
                {
                    e.Value = "Chưa thanh toán";
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                }
                else if (status == "Đã hủy")
                {
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#721C24");
                }
            }
        }

        // --- HELPERS ---
        private void ShowSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void ShowError(string title, string msg) => MessageBox.Show(msg, "❌ " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarning(string title, string msg) => MessageBox.Show(msg, "⚠️ " + title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}