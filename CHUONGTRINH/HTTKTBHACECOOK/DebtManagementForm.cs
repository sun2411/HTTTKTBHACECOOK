using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;            // Thêm thư viện IO để ghi file
using System.Text;          // Thêm thư viện Text để xử lý chuỗi
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class DebtManagementForm : Form
    {
        private string CONNECTION_STRING;
        private string searchPlaceholder = "Nhập mã công nợ, tên khách hàng hoặc nhà cung cấp...";

        public enum DebtType { Receivable, Payable }

        private DebtType CurrentDebtType =>
            tabControlDebt.SelectedTab == tabPageReceivable ? DebtType.Receivable : DebtType.Payable;

        public DebtManagementForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
        }

        private void DebtManagementForm_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            SetupSearchPlaceholder();
            SetupFilterComboBox();
            SetupTabControl();
            LoadDebtData(DebtType.Receivable);
        }

        // --- SETUP ---

        private void SetupVisualStyling()
        {
            dgvReceivable.AutoGenerateColumns = false;
            dgvPayable.AutoGenerateColumns = false;
            SetupButtonHoverEffects();
            dgvReceivable.CellFormatting += DgvDebt_CellFormatting;
            dgvPayable.CellFormatting += DgvDebt_CellFormatting;
        }

        private void DgvDebt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string statusColumnName = (dgv == dgvReceivable) ? "Receivable_TrangThai" : "Payable_TrangThai";

            if (dgv.Columns[e.ColumnIndex].Name == statusColumnName && e.Value != null)
            {
                string trangThai = e.Value.ToString();
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                if (trangThai.Contains("Quá hạn"))
                {
                    row.Cells[e.ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                    row.Cells[e.ColumnIndex].Style.ForeColor = ColorTranslator.FromHtml("#721C24");
                    row.Cells[e.ColumnIndex].Style.Font = new Font(dgv.Font, FontStyle.Bold);
                }
                else if (trangThai.Contains("một phần") || trangThai.Contains("Chưa"))
                {
                    row.Cells[e.ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                    row.Cells[e.ColumnIndex].Style.ForeColor = ColorTranslator.FromHtml("#856404");
                }
                else if (trangThai.Contains("đủ"))
                {
                    row.Cells[e.ColumnIndex].Style.BackColor = ColorTranslator.FromHtml("#D4EDDA");
                    row.Cells[e.ColumnIndex].Style.ForeColor = ColorTranslator.FromHtml("#155724");
                }
            }
        }

        private void SetupButtonHoverEffects()
        {
            // Payment - Yellow
            btnPayment.MouseEnter += (s, e) => btnPayment.BackColor = ColorTranslator.FromHtml("#FFCA2C");
            btnPayment.MouseLeave += (s, e) => btnPayment.BackColor = ColorTranslator.FromHtml("#FFC107");

            // View Detail - Cyan
            btnViewDetail.MouseEnter += (s, e) => btnViewDetail.BackColor = ColorTranslator.FromHtml("#1AA2BA");
            btnViewDetail.MouseLeave += (s, e) => btnViewDetail.BackColor = ColorTranslator.FromHtml("#17A2B8");

            // Export - Green
            btnExport.MouseEnter += (s, e) => btnExport.BackColor = ColorTranslator.FromHtml("#1E7E4E");
            btnExport.MouseLeave += (s, e) => btnExport.BackColor = ColorTranslator.FromHtml("#198754");

            // Search - Blue
            btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#007BFF");

            // Refresh - Grey
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = ColorTranslator.FromHtml("#5A6268");
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = ColorTranslator.FromHtml("#6C757D");
        }

        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");

            txtSearch.Enter += (sender, e) =>
            {
                if (txtSearch.Text == searchPlaceholder)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = ColorTranslator.FromHtml("#495057");
                }
            };

            txtSearch.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = searchPlaceholder;
                    txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
                }
            };

            txtSearch.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSearch_Click(sender, e);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void SetupFilterComboBox()
        {
            cmbDebtType.SelectedIndex = 0; // "Tất cả"
            cmbDebtType.SelectedIndexChanged += (sender, e) => LoadDebtData(CurrentDebtType);
        }

        private void SetupTabControl()
        {
            tabControlDebt.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlDebt.DrawItem += TabControl_DrawItem;
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);

            Color backColor, textColor;

            if (e.State == DrawItemState.Selected)
            {
                if (e.Index == 0) // Receivable - Green
                {
                    backColor = ColorTranslator.FromHtml("#198754");
                    textColor = Color.White;
                }
                else // Payable - Orange/Red
                {
                    backColor = ColorTranslator.FromHtml("#DC3545");
                    textColor = Color.White;
                }
            }
            else
            {
                backColor = ColorTranslator.FromHtml("#F8F9FA");
                textColor = ColorTranslator.FromHtml("#495057");
            }

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            TextRenderer.DrawText(
                e.Graphics,
                tabPage.Text,
                tabPage.Font,
                tabRect,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        // --- DATA OPERATIONS ---

        private void LoadDebtData(DebtType type, string keyword = "")
        {
            try
            {
                DataGridView dgv;
                string query;
                string statusFilter = GetStatusFilter();

                if (type == DebtType.Receivable)
                {
                    dgv = dgvReceivable;
                    query = @"
                        SELECT 
                            CN.MaCN,
                            CN.MaKH,
                            KH.TenKH,
                            CN.NgayPhatSinh AS NgayPhatSinh_Raw,
                            CN.SoTienNo AS SoTienNo_Raw,
                            CN.SoTienDaTra AS SoTienDaTra_Raw,
                            (CN.SoTienNo - CN.SoTienDaTra) AS ConLai_Raw,
                            CN.HanThanhToan AS HanThanhToan_Raw,
                            CN.TrangThai
                        FROM CONGNO CN
                        INNER JOIN KHACHHANG KH ON CN.MaKH = KH.MaKH
                        WHERE CN.LoaiCongNo = N'Phải thu'
                        AND (@Keyword = '' 
                            OR CN.MaCN LIKE @Keyword 
                            OR KH.TenKH LIKE @Keyword)
                        " + statusFilter + @"
                        ORDER BY CN.NgayPhatSinh DESC, CN.MaCN DESC";
                }
                else
                {
                    dgv = dgvPayable;
                    query = @"
                        SELECT 
                            CN.MaCN,
                            CN.MaNCC,
                            NCC.TenNCC,
                            CN.NgayPhatSinh AS NgayPhatSinh_Raw,
                            CN.SoTienNo AS SoTienNo_Raw,
                            CN.SoTienDaTra AS SoTienDaTra_Raw,
                            (CN.SoTienNo - CN.SoTienDaTra) AS ConLai_Raw,
                            CN.HanThanhToan AS HanThanhToan_Raw,
                            CN.TrangThai
                        FROM CONGNO CN
                        INNER JOIN NHACUNGCAP NCC ON CN.MaNCC = NCC.MaNCC
                        WHERE CN.LoaiCongNo = N'Phải trả'
                        AND (@Keyword = '' 
                            OR CN.MaCN LIKE @Keyword 
                            OR NCC.TenNCC LIKE @Keyword)
                        " + statusFilter + @"
                        ORDER BY CN.NgayPhatSinh DESC, CN.MaCN DESC";
                }

                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    FormatDataTable(dt);
                    dgv.DataSource = dt;
                    UpdateStats(type, dt);

                    dgv.Invalidate();
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi tải dữ liệu", ex.Message);
            }
        }

        private string GetStatusFilter()
        {
            string selectedStatus = cmbDebtType.SelectedItem?.ToString() ?? "Tất cả";

            switch (selectedStatus)
            {
                case "Chưa thanh toán":
                    return " AND CN.TrangThai = N'Chưa thanh toán'";
                case "Đã thanh toán một phần":
                    return " AND CN.TrangThai = N'Đã thanh toán một phần'";
                case "Đã thanh toán đủ":
                    return " AND CN.TrangThai = N'Đã thanh toán đủ'";
                case "Quá hạn":
                    return " AND CN.TrangThai = N'Quá hạn'";
                default:
                    return "";
            }
        }

        private void FormatDataTable(DataTable dt)
        {
            dt.Columns.Add("NgayPhatSinh", typeof(string));
            dt.Columns.Add("HanThanhToan", typeof(string));
            dt.Columns.Add("SoTienNo", typeof(string));
            dt.Columns.Add("SoTienDaTra", typeof(string));
            dt.Columns.Add("ConLai", typeof(string));

            if (dt.Columns.Contains("NgayPhatSinh_Raw")) dt.Columns["NgayPhatSinh_Raw"].ColumnName = "NgayPhatSinh_Original";
            if (dt.Columns.Contains("HanThanhToan_Raw")) dt.Columns["HanThanhToan_Raw"].ColumnName = "HanThanhToan_Original";
            if (dt.Columns.Contains("SoTienNo_Raw")) dt.Columns["SoTienNo_Raw"].ColumnName = "SoTienNo_Original";
            if (dt.Columns.Contains("SoTienDaTra_Raw")) dt.Columns["SoTienDaTra_Raw"].ColumnName = "SoTienDaTra_Original";
            if (dt.Columns.Contains("ConLai_Raw")) dt.Columns["ConLai_Raw"].ColumnName = "ConLai_Original";

            foreach (DataRow row in dt.Rows)
            {
                if (row["NgayPhatSinh_Original"] != DBNull.Value)
                {
                    DateTime date = Convert.ToDateTime(row["NgayPhatSinh_Original"]);
                    row["NgayPhatSinh"] = date.ToString("dd/MM/yyyy");
                }

                if (row["HanThanhToan_Original"] != DBNull.Value)
                {
                    DateTime date = Convert.ToDateTime(row["HanThanhToan_Original"]);
                    row["HanThanhToan"] = date.ToString("dd/MM/yyyy");
                }

                string[] moneyFieldsRaw = { "SoTienNo_Original", "SoTienDaTra_Original", "ConLai_Original" };
                string[] moneyFieldsFormatted = { "SoTienNo", "SoTienDaTra", "ConLai" };

                for (int i = 0; i < moneyFieldsRaw.Length; i++)
                {
                    if (row[moneyFieldsRaw[i]] != DBNull.Value)
                    {
                        decimal amount = Convert.ToDecimal(row[moneyFieldsRaw[i]]);
                        row[moneyFieldsFormatted[i]] = amount.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " ₫";
                    }
                }
            }

            if (dt.Columns.Contains("NgayPhatSinh_Original")) dt.Columns.Remove("NgayPhatSinh_Original");
            if (dt.Columns.Contains("HanThanhToan_Original")) dt.Columns.Remove("HanThanhToan_Original");
            if (dt.Columns.Contains("SoTienNo_Original")) dt.Columns.Remove("SoTienNo_Original");
            if (dt.Columns.Contains("SoTienDaTra_Original")) dt.Columns.Remove("SoTienDaTra_Original");
            if (dt.Columns.Contains("ConLai_Original")) dt.Columns.Remove("ConLai_Original");
        }

        private void UpdateStats(DebtType type, DataTable dt)
        {
            int count = dt.Rows.Count;
            string typeText = (type == DebtType.Receivable) ? "PT" : "PTr";
            lblStatsCount.Text = $"Tổng: {count} {typeText}";

            decimal totalDebt = 0;
            decimal totalOverdue = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["ConLai"] != DBNull.Value)
                {
                    string amountStr = row["ConLai"].ToString().Replace(" ₫", "").Trim();

                    if (decimal.TryParse(amountStr, NumberStyles.Number, CultureInfo.GetCultureInfo("vi-VN"), out decimal amount))
                    {
                        totalDebt += amount;
                        string trangThai = row["TrangThai"]?.ToString() ?? "";
                        if (trangThai.Contains("Quá hạn"))
                        {
                            totalOverdue += amount;
                        }
                    }
                }
            }

            lblTotalDebt.Text = totalDebt.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " ₫";
            lblTotalOverdue.Text = "QH: " + totalOverdue.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " ₫";
        }

        // --- EVENT HANDLERS ---

        private void tabControlDebt_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDebtData(CurrentDebtType);
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            cmbDebtType.SelectedIndex = 0;
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (CurrentDebtType == DebtType.Receivable) ? dgvReceivable : dgvPayable;
            string idColumn = (CurrentDebtType == DebtType.Receivable) ? "Receivable_MaCN" : "Payable_MaCN";
            string remainingCol = (CurrentDebtType == DebtType.Receivable) ? "Receivable_ConLai" : "Payable_ConLai";

            if (dgv.SelectedRows.Count == 0)
            {
                ShowWarning("Chưa chọn", "Vui lòng chọn một khoản công nợ để thanh toán.");
                return;
            }

            string statusCol = (CurrentDebtType == DebtType.Receivable) ? "Receivable_TrangThai" : "Payable_TrangThai";
            string status = dgv.SelectedRows[0].Cells[statusCol].Value?.ToString();

            if (status != null && status.Contains("đủ"))
            {
                ShowWarning("Đã hoàn thành", "Khoản nợ này đã được thanh toán đủ.");
                return;
            }

            string maCN = dgv.SelectedRows[0].Cells[idColumn].Value.ToString();
            string remaining = dgv.SelectedRows[0].Cells[remainingCol].Value.ToString();

            PaymentForm form = new PaymentForm(CONNECTION_STRING, maCN, remaining);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDebtData(CurrentDebtType);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (CurrentDebtType == DebtType.Receivable) ? dgvReceivable : dgvPayable;
            string idColumn = (CurrentDebtType == DebtType.Receivable) ? "Receivable_MaCN" : "Payable_MaCN";

            if (dgv.SelectedRows.Count == 0)
            {
                ShowWarning("Chưa chọn", "Vui lòng chọn một khoản công nợ để xem chi tiết.");
                return;
            }

            string maCN = dgv.SelectedRows[0].Cells[idColumn].Value.ToString();
            bool isReceivable = (CurrentDebtType == DebtType.Receivable);

            DebtDetailForm form = new DebtDetailForm(CONNECTION_STRING, maCN, isReceivable);
            form.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string typeText = (CurrentDebtType == DebtType.Receivable) ? "phải thu" : "phải trả";
            ShowInfo("Thông báo", $"Chức năng ghi nợ {typeText} sẽ được cập nhật trong phiên bản sau.");
        }

        // --- HÀM XUẤT EXCEL (ĐÃ SỬA LỖI) ---
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = (CurrentDebtType == DebtType.Receivable) ? dgvReceivable : dgvPayable;

                if (dgv.Rows.Count == 0)
                {
                    ShowWarning("Không có dữ liệu", "Danh sách trống, không thể xuất file.");
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = "CongNo_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Sử dụng StringBuilder để tạo nội dung CSV
                    StringBuilder sb = new StringBuilder();

                    // 1. Ghi tiêu đề cột
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible)
                        {
                            sb.Append(dgv.Columns[i].HeaderText);
                            sb.Append(i == dgv.Columns.Count - 1 ? "" : ",");
                        }
                    }
                    sb.AppendLine();

                    // 2. Ghi dữ liệu từng dòng
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (dgv.Columns[i].Visible)
                                {
                                    string cellValue = row.Cells[i].Value?.ToString() ?? "";

                                    // Xử lý các ký tự đặc biệt để không làm hỏng file CSV
                                    cellValue = cellValue.Replace(",", " ").Replace("\n", " ").Trim();

                                    sb.Append(cellValue);
                                    sb.Append(i == dgv.Columns.Count - 1 ? "" : ",");
                                }
                            }
                            sb.AppendLine();
                        }
                    }

                    // 3. Ghi file xuống ổ đĩa với encoding UTF8 (có BOM) để hiển thị tiếng Việt đúng
                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                    if (MessageBox.Show("Xuất file thành công!\nBạn có muốn mở file ngay không?", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi xuất file", "Không thể ghi file: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            cmbDebtType.SelectedIndex = 0;
            LoadDebtData(CurrentDebtType);
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = (txtSearch.Text == searchPlaceholder) ? "" : txtSearch.Text.Trim();
            LoadDebtData(CurrentDebtType, keyword);
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