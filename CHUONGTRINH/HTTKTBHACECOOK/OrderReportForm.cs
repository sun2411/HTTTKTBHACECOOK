using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HTTKTBHACECOOK
{
    public partial class OrderReportForm : Form
    {
        private string CONNECTION_STRING;

        // KHAI BÁO HẰNG SỐ VỚI TÊN BẢNG CHÍNH XÁC TỪ FILE SQL
        private const string ORDER_TABLE = "DONDATHANG";
        private const string ORDER_DETAIL_TABLE = "CT_DH";

        public OrderReportForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
        }

        private void OrderReportForm_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            SetupDateRange();
            SetupButtonHoverEffects();
            LoadReportData();
        }

        // --- SETUP ---

        private void SetupVisualStyling()
        {
            dgvOrders.AutoGenerateColumns = false;
            dgvStatusSummary.AutoGenerateColumns = false;
            dgvCustomerSummary.AutoGenerateColumns = false;

            dgvOrders.CellFormatting += DgvOrders_CellFormatting;
        }

        private void DgvOrders_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra cột TrangThai trong DataGridView
            if (dgvOrders.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string trangThai = e.Value.ToString();
                DataGridViewRow row = dgvOrders.Rows[e.RowIndex];

                switch (trangThai)
                {
                    case "Hoàn thành":
                        row.Cells["TrangThai"].Style.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                        row.Cells["TrangThai"].Style.ForeColor = ColorTranslator.FromHtml("#155724");
                        row.Cells["TrangThai"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        break;
                    case "Đang xử lý":
                        row.Cells["TrangThai"].Style.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                        row.Cells["TrangThai"].Style.ForeColor = ColorTranslator.FromHtml("#856404");
                        row.Cells["TrangThai"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        break;
                    case "Chờ giao":
                        row.Cells["TrangThai"].Style.BackColor = ColorTranslator.FromHtml("#D1ECF1");
                        row.Cells["TrangThai"].Style.ForeColor = ColorTranslator.FromHtml("#0C5460");
                        row.Cells["TrangThai"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        break;
                    case "Đã hủy":
                        row.Cells["TrangThai"].Style.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                        row.Cells["TrangThai"].Style.ForeColor = ColorTranslator.FromHtml("#721C24");
                        row.Cells["TrangThai"].Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                        break;
                }
            }
        }

        private void SetupDateRange()
        {
            // --- [CẬP NHẬT] ĐẶT MẶC ĐỊNH LÀ 01/01/2025 ---
            dtpStartDate.Value = new DateTime(2025, 1, 1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void SetupButtonHoverEffects()
        {
            btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#0D6EFD");

            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = ColorTranslator.FromHtml("#5A6268");
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = ColorTranslator.FromHtml("#6C757D");

            btnExport.MouseEnter += (s, e) => btnExport.BackColor = ColorTranslator.FromHtml("#1E7E4E");
            btnExport.MouseLeave += (s, e) => btnExport.BackColor = ColorTranslator.FromHtml("#198754");
        }

        // --- DATA OPERATIONS ---

        private void LoadReportData()
        {
            try
            {
                LoadOrdersData();
                LoadStatusSummary();
                LoadCustomerSummary();
                UpdateStatsPanel();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi tải dữ liệu", ex.Message);
            }
        }

        private void LoadOrdersData()
        {
            string query = $@"
                SELECT 
                    DH.MaDDH AS MaDH, 
                    KH.TenKH AS KhachHang,
                    DH.NgayDatHang AS NgayDat_Raw, 
                    DH.NgayGiaoHang AS NgayGiao_Raw, 
                    DH.TrangThaiDH AS TrangThai_Raw, 
                    DH.TriGiaDH AS TongTien_Raw, 
                    (SELECT COUNT(*) FROM {ORDER_DETAIL_TABLE} WHERE MaDDH = DH.MaDDH) AS SoMatHang
                FROM {ORDER_TABLE} DH
                INNER JOIN KHACHHANG KH ON DH.MaKH = KH.MaKH
                WHERE DH.NgayDatHang BETWEEN @StartDate AND @EndDate
                ORDER BY DH.NgayDatHang DESC, DH.MaDDH DESC";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                FormatOrdersData(dt);
                dgvOrders.DataSource = dt;
            }
        }

        private void LoadStatusSummary()
        {
            string query = $@"
                SELECT 
                    TrangThaiDH AS TrangThai_Raw,
                    COUNT(*) AS SoLuong,
                    SUM(TriGiaDH) AS DoanhThu_Raw
                FROM {ORDER_TABLE}
                WHERE NgayDatHang BETWEEN @StartDate AND @EndDate
                GROUP BY TrangThaiDH
                ORDER BY 
                    CASE TrangThaiDH
                        WHEN N'Đã giao' THEN 1 
                        WHEN N'Đang xử lý' THEN 2
                        WHEN N'Đang giao' THEN 3 
                        ELSE 4
                    END";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dt.Columns.Add("TrangThai", typeof(string));
                dt.Columns.Add("DoanhThu", typeof(string));

                CalculatePercentages(dt, "SoLuong", "TyLe_Raw");
                dt.Columns.Add("TyLe", typeof(string));

                FormatStatusSummaryData(dt);
                dgvStatusSummary.DataSource = dt;

                dt.Columns.Remove("TrangThai_Raw");
                dt.Columns.Remove("DoanhThu_Raw");
                dt.Columns.Remove("TyLe_Raw");

                ApplyRowColors();
            }
        }

        private void ApplyRowColors()
        {
            foreach (DataGridViewRow row in dgvStatusSummary.Rows)
            {
                if (row.Cells["TrangThaiCol"].Value != null)
                {
                    string status = row.Cells["TrangThaiCol"].Value.ToString();
                    switch (status)
                    {
                        case "Hoàn thành":
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                            row.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#C3E6CB");
                            break;
                        case "Đang xử lý":
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                            row.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFEAA7");
                            break;
                        case "Chờ xử lý":
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D1ECF1");
                            row.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#BEE5EB");
                            break;
                    }
                }
            }
        }

        private void LoadCustomerSummary()
        {
            string query = $@"
                SELECT TOP 10
                    KH.TenKH AS KhachHang,
                    COUNT(DISTINCT DH.MaDDH) AS SoDonHang,
                    SUM(DH.TriGiaDH) AS TongGiaTri_Raw 
                FROM {ORDER_TABLE} DH
                INNER JOIN KHACHHANG KH ON DH.MaKH = KH.MaKH
                WHERE DH.NgayDatHang BETWEEN @StartDate AND @EndDate
                GROUP BY KH.MaKH, KH.TenKH
                ORDER BY TongGiaTri_Raw DESC";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dt.Columns.Add("TongGiaTri", typeof(string));

                FormatCustomerSummaryData(dt);
                dgvCustomerSummary.DataSource = dt;

                dt.Columns.Remove("TongGiaTri_Raw");

                HighlightTopCustomers();
            }
        }

        private void HighlightTopCustomers()
        {
            for (int i = 0; i < Math.Min(3, dgvCustomerSummary.Rows.Count); i++)
            {
                Color[] topColors = new Color[] {
                    ColorTranslator.FromHtml("#CFE2FF"), // Top 1 - Light Blue
                    ColorTranslator.FromHtml("#E7F1FF"), // Top 2 - Lighter Blue
                    ColorTranslator.FromHtml("#F0F6FF")  // Top 3 - Lightest Blue
                };

                dgvCustomerSummary.Rows[i].DefaultCellStyle.BackColor = topColors[i];
                dgvCustomerSummary.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }
        }

        private void UpdateStatsPanel()
        {
            string query = $@"
                SELECT 
                    COUNT(*) AS TotalOrders,
                    SUM(CASE WHEN TrangThaiDH = N'Đã giao' THEN 1 ELSE 0 END) AS CompletedOrders,
                    SUM(CASE WHEN TrangThaiDH = N'Đang xử lý' THEN 1 ELSE 0 END) AS ProcessingOrders,
                    SUM(TriGiaDH) AS TotalRevenue
                FROM {ORDER_TABLE}
                WHERE NgayDatHang BETWEEN @StartDate AND @EndDate";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                    command.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int total = reader["TotalOrders"] != DBNull.Value ? Convert.ToInt32(reader["TotalOrders"]) : 0;
                            int completed = reader["CompletedOrders"] != DBNull.Value ? Convert.ToInt32(reader["CompletedOrders"]) : 0;
                            int processing = reader["ProcessingOrders"] != DBNull.Value ? Convert.ToInt32(reader["ProcessingOrders"]) : 0;
                            decimal revenue = reader["TotalRevenue"] != DBNull.Value ? Convert.ToDecimal(reader["TotalRevenue"]) : 0;

                            lblTotalValue.Text = total.ToString();
                            lblCompletedValue.Text = completed.ToString();
                            lblProcessingValue.Text = processing.ToString();
                            lblRevenueValue.Text = revenue.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VND";
                        }
                    }
                }
            }
        }

        // --- DATA FORMATTING ---

        private void FormatOrdersData(DataTable dt)
        {
            dt.Columns.Add("NgayDat", typeof(string));
            dt.Columns.Add("NgayGiao", typeof(string));
            dt.Columns.Add("TongTien", typeof(string));
            dt.Columns.Add("TrangThai", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                // Format dates
                if (row["NgayDat_Raw"] != DBNull.Value)
                {
                    DateTime ngayDat = Convert.ToDateTime(row["NgayDat_Raw"]);
                    row["NgayDat"] = ngayDat.ToString("dd/MM/yyyy");
                }
                if (row["NgayGiao_Raw"] != DBNull.Value)
                {
                    DateTime ngayGiao = Convert.ToDateTime(row["NgayGiao_Raw"]);
                    row["NgayGiao"] = ngayGiao.ToString("dd/MM/yyyy");
                }

                // Format currency
                if (row["TongTien_Raw"] != DBNull.Value)
                {
                    decimal amount = Convert.ToDecimal(row["TongTien_Raw"]);
                    row["TongTien"] = amount.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VND";
                }

                // Chuyển đổi trạng thái hiển thị
                if (row["TrangThai_Raw"] != DBNull.Value)
                {
                    string dbStatus = row["TrangThai_Raw"].ToString();
                    if (dbStatus == "Đã giao") row["TrangThai"] = "Hoàn thành";
                    else if (dbStatus == "Đang giao") row["TrangThai"] = "Chờ giao";
                    else row["TrangThai"] = dbStatus; // Giữ nguyên trạng thái nếu không khớp
                }
            }

            // Xóa các cột Raw ban đầu
            dt.Columns.Remove("NgayDat_Raw");
            dt.Columns.Remove("NgayGiao_Raw");
            dt.Columns.Remove("TongTien_Raw");
            dt.Columns.Remove("TrangThai_Raw");
        }

        private void FormatStatusSummaryData(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                // Format currency
                if (row["DoanhThu_Raw"] != DBNull.Value)
                {
                    decimal amount = Convert.ToDecimal(row["DoanhThu_Raw"]);
                    row["DoanhThu"] = amount.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VND";
                }

                // Format percentage
                if (row["TyLe_Raw"] != DBNull.Value)
                {
                    decimal percentage = Convert.ToDecimal(row["TyLe_Raw"]);
                    row["TyLe"] = percentage.ToString("F1") + "%";
                }

                // Chuyển đổi trạng thái
                if (row["TrangThai_Raw"] != DBNull.Value)
                {
                    string dbStatus = row["TrangThai_Raw"].ToString();
                    if (dbStatus == "Đã giao") row["TrangThai"] = "Hoàn thành";
                    else if (dbStatus == "Đang giao") row["TrangThai"] = "Chờ xử lý";
                    else row["TrangThai"] = dbStatus;
                }
            }
        }

        private void FormatCustomerSummaryData(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                // Format currency
                if (row["TongGiaTri_Raw"] != DBNull.Value)
                {
                    decimal amount = Convert.ToDecimal(row["TongGiaTri_Raw"]);
                    row["TongGiaTri"] = amount.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VND";
                }
            }
        }

        private void CalculatePercentages(DataTable dt, string amountColumn, string percentColumn)
        {
            dt.Columns.Add(percentColumn, typeof(decimal));

            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row[amountColumn] != DBNull.Value)
                {
                    total += Convert.ToDecimal(row[amountColumn]);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                if (row[amountColumn] != DBNull.Value && total > 0)
                {
                    decimal amount = Convert.ToDecimal(row[amountColumn]);
                    row[percentColumn] = (amount / total) * 100;
                }
                else
                {
                    row[percentColumn] = 0;
                }
            }
        }

        // --- CHỨC NĂNG EXPORT EXCEL ---

        private void ExportToExcel(DataGridView dgv, string sheetName)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                if (dgv.Rows.Count == 0)
                {
                    ShowWarning("Không có dữ liệu", "Không có dữ liệu trong lưới để xuất Excel.");
                    return;
                }

                excelApp = new Excel.Application();
                excelApp.Visible = false;
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = sheetName;

                // Headers
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }

                // Data
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Auto-fit columns
                worksheet.Columns.AutoFit();

                // Save file using SaveFileDialog
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"BaoCaoDonHang_{DateTime.Now:yyyyMMdd_HHmm}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook, Type.Missing,
                                    Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange,
                                    Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing,
                                    Type.Missing, Type.Missing, Type.Missing);
                    ShowSuccess($"Đã xuất file Excel thành công tại:\n{sfd.FileName}");
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi xuất Excel", ex.Message + "\n\nKiểm tra:\n1. Đã cài đặt Microsoft Excel.\n2. Đã thêm tham chiếu Microsoft.Office.Interop.Excel.");
            }
            finally
            {
                // Release objects
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
        }


        // --- EVENT HANDLERS ---

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                ShowWarning("Ngày không hợp lệ", "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return;
            }

            LoadReportData();
            ShowSuccess("Đã tải báo cáo!");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // --- [CẬP NHẬT] LÀM MỚI CŨNG VỀ 01/01/2025 ---
            dtpStartDate.Value = new DateTime(2025, 1, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadReportData();
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvOrders, "DanhSachDonHang");
        }

        // --- HELPER METHODS ---

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "✅ Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowError(string title, string message)
        {
            MessageBox.Show(message, "❌ " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarning(string title, string message)
        {
            MessageBox.Show(message, "⚠️ " + title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowInfo(string title, string message)
        {
            MessageBox.Show(message, "ℹ️ " + title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}