using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace HTTKTBHACECOOK
{
    public partial class SalesRevenueReportForm : Form
    {
        private string CONNECTION_STRING;
        private Chart chartRevenue;
        private Chart chartProduct;
        private Chart chartTrend;

        public SalesRevenueReportForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
        }

        private void SalesRevenueReportForm_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            SetupDateRange();
            SetupReportType();
            SetupTabControl();
            SetupCharts();

            cmbReportType.SelectedIndexChanged += (s, ev) => GenerateReport();
            GenerateReport();
        }

        // --- SETUP ---

        private void SetupVisualStyling()
        {
            var culture = CultureInfo.GetCultureInfo("vi-VN");

            dgvSummary.AutoGenerateColumns = false;
            FormatGridColumn(dgvSummary, "Summary_Revenue", "N0", culture);
            FormatGridColumn(dgvSummary, "Summary_Cost", "N0", culture);
            FormatGridColumn(dgvSummary, "Summary_Profit", "N0", culture);
            FormatGridColumn(dgvSummary, "Summary_Margin", "N1", culture);

            dgvByProduct.AutoGenerateColumns = false;
            FormatGridColumn(dgvByProduct, "Product_DoanhThu", "N0", culture);
            FormatGridColumn(dgvByProduct, "Product_TyLe", "N1", culture);

            dgvByCustomer.AutoGenerateColumns = false;
            FormatGridColumn(dgvByCustomer, "Customer_TongTien", "N0", culture);

            dgvByEmployee.AutoGenerateColumns = false;
            FormatGridColumn(dgvByEmployee, "Employee_DoanhThu", "N0", culture);
            FormatGridColumn(dgvByEmployee, "Employee_TyLe", "N1", culture);

            FixLabelDisplay(lblOrders, pnlOrders);
            FixLabelDisplay(lblRevenue, pnlRevenue);
            FixLabelDisplay(lblCost, pnlCost);
            FixLabelDisplay(lblProfit, pnlProfit);

            SetupButtonHoverEffects();
        }

        private void FixLabelDisplay(Label lbl, Panel parent)
        {
            lbl.AutoSize = false;
            lbl.Width = parent.Width - 80;
            lbl.Height = 40;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.BringToFront();
        }

        private void FormatGridColumn(DataGridView dgv, string colName, string format, IFormatProvider provider)
        {
            if (dgv.Columns[colName] != null)
            {
                dgv.Columns[colName].DefaultCellStyle.Format = format;
                dgv.Columns[colName].DefaultCellStyle.FormatProvider = provider;
                dgv.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void SetupButtonHoverEffects()
        {
            SetButtonHover(btnGenerate, "#0B5ED7", "#0D6EFD");
            SetButtonHover(btnRefresh, "#5A6268", "#6C757D");
            SetButtonHover(btnExport, "#1E7E4E", "#198754");
        }

        private void SetButtonHover(Button btn, string hoverColor, string normalColor)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml(hoverColor);
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml(normalColor);
        }

        private void SetupDateRange()
        {
            dtpStartDate.Value = new DateTime(2025, 1, 1);
            dtpEndDate.Value = DateTime.Now;
        }

        private void SetupReportType()
        {
            if (cmbReportType.Items.Count > 0)
                cmbReportType.SelectedIndex = 2;
        }

        private void SetupTabControl()
        {
            tabPageCharts.AutoScroll = true;
        }

        private void SetupCharts()
        {
            chartRevenue = CreateChart("RevenueArea", "RevenueLegend", "BIỂU ĐỒ DOANH THU THEO KỲ");
            chartRevenue.Height = 400;
            chartRevenue.Dock = DockStyle.Top;
            tabPageCharts.Controls.Add(chartRevenue);

            Panel pnlBottomCharts = new Panel();
            pnlBottomCharts.Height = 400;
            pnlBottomCharts.Dock = DockStyle.Top;
            tabPageCharts.Controls.Add(pnlBottomCharts);
            pnlBottomCharts.BringToFront();
            chartRevenue.SendToBack();

            chartProduct = CreateChart("ProductArea", "ProductLegend", "TOP SẢN PHẨM", SeriesChartType.Pie);
            chartProduct.Parent = pnlBottomCharts;
            chartProduct.Dock = DockStyle.Left;
            chartProduct.Width = tabPageCharts.Width / 2;
            chartProduct.ChartAreas[0].Area3DStyle.Enable3D = true;

            chartTrend = CreateChart("TrendArea", "TrendLegend", "XU HƯỚNG LỢI NHUẬN", SeriesChartType.Line);
            chartTrend.Parent = pnlBottomCharts;
            chartTrend.Dock = DockStyle.Fill;
        }

        private Chart CreateChart(string areaName, string legendName, string titleText, SeriesChartType type = SeriesChartType.Column)
        {
            Chart chart = new Chart();
            chart.BackColor = Color.White;

            ChartArea area = new ChartArea(areaName) { BackColor = Color.White };
            area.AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0E0E0");
            area.AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#E0E0E0");
            area.AxisY.LabelStyle.Format = "N0";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;
            chart.ChartAreas.Add(area);

            Legend legend = new Legend(legendName)
            {
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Docking = (type == SeriesChartType.Pie) ? Docking.Right : Docking.Top,
                Alignment = StringAlignment.Center
            };
            chart.Legends.Add(legend);

            Title title = new Title(titleText)
            {
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#495057")
            };
            chart.Titles.Add(title);

            return chart;
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);

            Color[] tabColors = {
                ColorTranslator.FromHtml("#0D6EFD"),
                ColorTranslator.FromHtml("#6F42C1"),
                ColorTranslator.FromHtml("#17A2B8"),
                ColorTranslator.FromHtml("#FD7E14"),
                ColorTranslator.FromHtml("#198754")
            };

            Color backColor = (e.State == DrawItemState.Selected) ? tabColors[e.Index % tabColors.Length] : ColorTranslator.FromHtml("#F8F9FA");
            Color textColor = (e.State == DrawItemState.Selected) ? Color.White : ColorTranslator.FromHtml("#495057");

            using (SolidBrush brush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(brush, tabRect);

            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabRect, textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // --- DATA OPERATIONS ---

        private void GenerateReport()
        {
            try
            {
                LoadSummaryReport();
                LoadProductReport();
                LoadCustomerReport();
                LoadEmployeeReport();
                UpdateOverallStats();
                UpdateCharts();
            }
            catch (Exception) { }
        }

        private void LoadSummaryReport()
        {
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "Theo tháng";
            string groupBy = GetGroupByClause(reportType);
            string periodFormat = GetPeriodFormat(reportType);

            string query = $@"
                SELECT 
                    {periodFormat} AS Period,
                    COUNT(DISTINCT HDB.SoHDB) AS Orders,
                    ISNULL(SUM(HDB.TriGiaSauGiam), 0) AS Revenue,
                    ISNULL(SUM(HDB.TriGiaSauGiam) * 0.7, 0) AS Cost,
                    ISNULL(SUM(HDB.TriGiaSauGiam) - (SUM(HDB.TriGiaSauGiam) * 0.7), 0) AS Profit
                FROM HOADONBAN HDB
                WHERE HDB.NgayLapHDB BETWEEN @StartDate AND @EndDate
                GROUP BY {groupBy}
                ORDER BY {groupBy}";

            LoadDataToGrid(query, dgvSummary, (dt) => {
                dt.Columns.Add("Margin", typeof(decimal));
                foreach (DataRow row in dt.Rows)
                {
                    decimal rev = Convert.ToDecimal(row["Revenue"]);
                    decimal profit = Convert.ToDecimal(row["Profit"]);
                    row["Margin"] = rev > 0 ? (profit / rev * 100) : 0;
                }
            });
        }

        private void LoadProductReport()
        {
            string query = @"
                SELECT 
                    SP.MaSP, SP.TenSP,
                    ISNULL(SUM(CT.SoLuongDDH), 0) AS SoLuong,
                    ISNULL(SUM(CT.SoLuongDDH * CT.DonGiaDDH), 0) AS DoanhThu
                FROM CT_DH CT
                JOIN DONDATHANG DDH ON CT.MaDDH = DDH.MaDDH
                JOIN HOADONBAN HDB ON DDH.MaDDH = HDB.MaDDH
                JOIN SANPHAM SP ON CT.MaSP = SP.MaSP
                WHERE HDB.NgayLapHDB BETWEEN @StartDate AND @EndDate
                GROUP BY SP.MaSP, SP.TenSP
                ORDER BY DoanhThu DESC";

            LoadDataToGrid(query, dgvByProduct, (dt) => CalculatePercentages(dt, "DoanhThu", "TyLe"));
        }

        private void LoadCustomerReport()
        {
            string query = @"
                SELECT 
                    KH.MaKH, KH.TenKH,
                    COUNT(DISTINCT HDB.SoHDB) AS SoDonHang,
                    ISNULL(SUM(HDB.TriGiaSauGiam), 0) AS TongTien,
                    LKH.TenLoaiKH AS LoaiKH
                FROM HOADONBAN HDB
                JOIN DONDATHANG DDH ON HDB.MaDDH = DDH.MaDDH
                JOIN KHACHHANG KH ON DDH.MaKH = KH.MaKH
                LEFT JOIN LOAIKHACHHANG LKH ON KH.MaLoaiKH = LKH.MaLoaiKH
                WHERE HDB.NgayLapHDB BETWEEN @StartDate AND @EndDate
                GROUP BY KH.MaKH, KH.TenKH, LKH.TenLoaiKH
                ORDER BY TongTien DESC";

            LoadDataToGrid(query, dgvByCustomer, null);
        }

        private void LoadEmployeeReport()
        {
            string query = @"
                SELECT 
                    NV.MaNV, NV.HoTenNV AS TenNV,
                    COUNT(DISTINCT HDB.SoHDB) AS SoDonHang,
                    ISNULL(SUM(HDB.TriGiaSauGiam), 0) AS DoanhThu
                FROM HOADONBAN HDB
                JOIN DONDATHANG DDH ON HDB.MaDDH = DDH.MaDDH
                JOIN NHANVIEN NV ON DDH.MaNV = NV.MaNV
                WHERE HDB.NgayLapHDB BETWEEN @StartDate AND @EndDate
                GROUP BY NV.MaNV, NV.HoTenNV
                ORDER BY DoanhThu DESC";

            LoadDataToGrid(query, dgvByEmployee, (dt) => CalculatePercentages(dt, "DoanhThu", "TyLe"));
        }

        private void LoadDataToGrid(string query, DataGridView dgv, Action<DataTable> processAction)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                adapter.SelectCommand.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                processAction?.Invoke(dt);
                dgv.DataSource = dt;
            }
        }

        private void CalculatePercentages(DataTable dt, string valCol, string pctCol)
        {
            dt.Columns.Add(pctCol, typeof(decimal));
            decimal total = 0;
            foreach (DataRow r in dt.Rows) total += Convert.ToDecimal(r[valCol]);
            foreach (DataRow r in dt.Rows)
                r[pctCol] = total > 0 ? (Convert.ToDecimal(r[valCol]) / total * 100) : 0;
        }

        private void UpdateOverallStats()
        {
            string query = @"
                SELECT 
                    COUNT(DISTINCT HDB.SoHDB),
                    ISNULL(SUM(HDB.TriGiaSauGiam), 0)
                FROM HOADONBAN HDB
                WHERE HDB.NgayLapHDB BETWEEN @StartDate AND @EndDate";

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
                            int orders = reader.GetInt32(0);
                            decimal revenue = reader.GetDecimal(1);
                            decimal cost = revenue * 0.7m;
                            decimal profit = revenue - cost;

                            lblOrders.Text = $"Đơn hàng: {orders:N0}";
                            lblRevenue.Text = $"Doanh thu: {revenue:N0} ₫";
                            lblCost.Text = $"Chi phí (Est): {cost:N0} ₫";
                            lblProfit.Text = $"Lãi: {profit:N0} ₫";
                        }
                    }
                }
            }
        }

        private void UpdateCharts()
        {
            UpdateRevenueChart();
            UpdateProductChart();
            UpdateTrendChart();
        }

        private void UpdateRevenueChart()
        {
            chartRevenue.Series.Clear();
            AddSeriesToChart(chartRevenue, "Doanh thu", "#0D6EFD", "Summary_Revenue");
            AddSeriesToChart(chartRevenue, "Chi phí", "#DC3545", "Summary_Cost");
            AddSeriesToChart(chartRevenue, "Lợi nhuận", "#198754", "Summary_Profit");
        }

        private void AddSeriesToChart(Chart chart, string name, string colorHex, string colName)
        {
            Series s = new Series(name) { ChartType = SeriesChartType.Column, Color = ColorTranslator.FromHtml(colorHex) };
            foreach (DataGridViewRow row in dgvSummary.Rows)
                if (row.Cells["Summary_Period"].Value != null && row.Cells[colName].Value != null)
                    s.Points.AddXY(row.Cells["Summary_Period"].Value.ToString(), Convert.ToDecimal(row.Cells[colName].Value));
            chart.Series.Add(s);
        }

        private void UpdateProductChart()
        {
            chartProduct.Series.Clear();
            Series s = new Series("SP") { ChartType = SeriesChartType.Pie, IsValueShownAsLabel = true, LabelFormat = "N0" };
            int count = 0;
            Color[] colors = { ColorTranslator.FromHtml("#0D6EFD"), ColorTranslator.FromHtml("#6F42C1"), ColorTranslator.FromHtml("#17A2B8"), ColorTranslator.FromHtml("#FD7E14"), ColorTranslator.FromHtml("#198754") };

            foreach (DataGridViewRow row in dgvByProduct.Rows)
            {
                if (count++ >= 5) break;
                if (row.Cells["Product_DoanhThu"].Value != null)
                {
                    int idx = s.Points.AddXY(row.Cells["Product_TenSP"].Value, Convert.ToDecimal(row.Cells["Product_DoanhThu"].Value));
                    s.Points[idx].Color = colors[count % colors.Length];
                }
            }
            chartProduct.Series.Add(s);
        }

        private void UpdateTrendChart()
        {
            chartTrend.Series.Clear();
            Series s = new Series("Lợi nhuận") { ChartType = SeriesChartType.Line, Color = ColorTranslator.FromHtml("#198754"), BorderWidth = 3, MarkerStyle = MarkerStyle.Circle, MarkerSize = 8 };
            foreach (DataGridViewRow row in dgvSummary.Rows)
                if (row.Cells["Summary_Period"].Value != null && row.Cells["Summary_Profit"].Value != null)
                    s.Points.AddXY(row.Cells["Summary_Period"].Value.ToString(), Convert.ToDecimal(row.Cells["Summary_Profit"].Value));
            chartTrend.Series.Add(s);
        }

        // --- HELPERS ---

        private string GetGroupByClause(string type)
        {
            switch (type)
            {
                case "Theo ngày": return "CONVERT(DATE, HDB.NgayLapHDB)";
                case "Theo tuần": return "DATEPART(YEAR, HDB.NgayLapHDB), DATEPART(WEEK, HDB.NgayLapHDB)";
                case "Theo quý": return "YEAR(HDB.NgayLapHDB), DATEPART(QUARTER, HDB.NgayLapHDB)";
                case "Theo năm": return "YEAR(HDB.NgayLapHDB)";
                default: return "YEAR(HDB.NgayLapHDB), MONTH(HDB.NgayLapHDB)";
            }
        }

        private string GetPeriodFormat(string type)
        {
            switch (type)
            {
                case "Theo ngày": return "CONVERT(VARCHAR, HDB.NgayLapHDB, 103)";
                case "Theo tuần": return "CONCAT(N'Tuần ', DATEPART(WEEK, HDB.NgayLapHDB), '/', YEAR(HDB.NgayLapHDB))";
                case "Theo quý": return "CONCAT(N'Quý ', DATEPART(QUARTER, HDB.NgayLapHDB), '/', YEAR(HDB.NgayLapHDB))";
                case "Theo năm": return "CAST(YEAR(HDB.NgayLapHDB) AS VARCHAR)";
                default: return "CONCAT(N'Tháng ', MONTH(HDB.NgayLapHDB), '/', YEAR(HDB.NgayLapHDB))";
            }
        }

        // --- XUẤT EXCEL (INTEROP) ---

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataGridView currentGrid = null;
            string sheetName = "BaoCao";

            if (tabControlReport.SelectedTab == tabPageSummary) { currentGrid = dgvSummary; sheetName = "TongHop"; }
            else if (tabControlReport.SelectedTab == tabPageByProduct) { currentGrid = dgvByProduct; sheetName = "SanPham"; }
            else if (tabControlReport.SelectedTab == tabPageByCustomer) { currentGrid = dgvByCustomer; sheetName = "KhachHang"; }
            else if (tabControlReport.SelectedTab == tabPageByEmployee) { currentGrid = dgvByEmployee; sheetName = "NhanVien"; }

            if (currentGrid != null && currentGrid.Rows.Count > 0)
            {
                try
                {
                    ExportToExcel_Interop(currentGrid, sheetName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất Excel: " + ex.Message + "\n(Cần cài đặt Microsoft Excel)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất hoặc đang ở tab Biểu đồ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportToExcel_Interop(DataGridView dgv, string sheetName)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.WindowState = Excel.XlWindowState.xlMaximized;

            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            worksheet.Name = sheetName;

            int startRow = 6;

            // HEADER
            Excel.Range headRange = worksheet.Range["A1", "F1"];
            headRange.Merge();
            headRange.Value = "CÔNG TY CỔ PHẦN ACECOOK VIỆT NAM";
            headRange.Font.Bold = true;
            headRange.Font.Size = 14;
            headRange.Font.Color = ColorTranslator.ToOle(Color.Red);
            headRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range titleRange = worksheet.Range["A2", "F2"];
            titleRange.Merge();
            titleRange.Value = "BÁO CÁO DOANH THU BÁN HÀNG";
            titleRange.Font.Bold = true;
            titleRange.Font.Size = 16;
            titleRange.Font.Color = ColorTranslator.ToOle(Color.Navy);
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range dateRange = worksheet.Range["A3", "F3"];
            dateRange.Merge();
            dateRange.Value = $"Từ ngày: {dtpStartDate.Value:dd/MM/yyyy} - Đến ngày: {dtpEndDate.Value:dd/MM/yyyy}";
            dateRange.Font.Italic = true;
            dateRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // COLUMN HEADERS
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                worksheet.Cells[5, i + 1] = dgv.Columns[i].HeaderText;
                Excel.Range cell = (Excel.Range)worksheet.Cells[5, i + 1];
                cell.Font.Bold = true;
                cell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            // DATA
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    object cellValue = dgv.Rows[i].Cells[j].Value;

                    // Format số nếu là cột tiền (tránh bị lỗi text)
                    if (cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal val))
                    {
                        worksheet.Cells[startRow + i, j + 1] = val; // Gán số thô
                        ((Excel.Range)worksheet.Cells[startRow + i, j + 1]).NumberFormat = "#,##0"; // Format Excel
                    }
                    else
                    {
                        worksheet.Cells[startRow + i, j + 1] = cellValue != null ? cellValue.ToString() : "";
                    }

                    Excel.Range cell = (Excel.Range)worksheet.Cells[startRow + i, j + 1];
                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }

            // FOOTER
            int footerRow = startRow + dgv.Rows.Count + 2;

            Excel.Range signDateRange = worksheet.Range[$"D{footerRow}", $"F{footerRow}"];
            signDateRange.Merge();
            signDateRange.Value = $"..............., ngày ... tháng ... năm {DateTime.Now.Year}";
            signDateRange.Font.Italic = true;
            signDateRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range signNameRange = worksheet.Range[$"D{footerRow + 1}", $"F{footerRow + 1}"];
            signNameRange.Merge();
            signNameRange.Value = "NGƯỜI LẬP BIỂU";
            signNameRange.Font.Bold = true;
            signNameRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range signPlaceRange = worksheet.Range[$"D{footerRow + 2}", $"F{footerRow + 2}"];
            signPlaceRange.Merge();
            signPlaceRange.Value = "(Ký, ghi rõ họ tên)";
            signPlaceRange.Font.Italic = true;
            signPlaceRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            worksheet.Columns.AutoFit();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Ngày không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GenerateReport();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpStartDate.Value = new DateTime(2025, 1, 1);
            dtpEndDate.Value = DateTime.Now;
            cmbReportType.SelectedIndex = 2;
            GenerateReport();
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        private void ShowSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void ShowError(string title, string msg) => MessageBox.Show(msg, "❌ " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}