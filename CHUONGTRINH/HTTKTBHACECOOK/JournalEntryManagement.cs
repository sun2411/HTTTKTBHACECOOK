using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HTTKTBHACECOOK
{
    public partial class JournalEntryManagementForm : Form
    {
        private string CONNECTION_STRING;
        private string searchPlaceholder = "Nhập mã bút toán, chứng từ hoặc diễn giải...";

        public JournalEntryManagementForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
        }

        private void JournalEntryManagementForm_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            SetupSearchPlaceholder();
            SetupDateRangePicker();
            LoadJournalEntryData();
        }

        // --- SETUP GIAO DIỆN ---
        private void SetupVisualStyling()
        {
            dgvJournalEntries.AutoGenerateColumns = false;
            SetupButtonHoverEffects();
            dgvJournalEntries.CellFormatting += DgvJournalEntries_CellFormatting;
        }

        private void DgvJournalEntries_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvJournalEntries.Columns[e.ColumnIndex].Name == "TrangThai" && e.Value != null)
            {
                string trangThai = e.Value.ToString();
                if (trangThai == "Ghi sổ")
                {
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#D1E7DD");
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#0F5132");
                }
                else
                {
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                    e.CellStyle.ForeColor = ColorTranslator.FromHtml("#664D03");
                }
            }
            if (dgvJournalEntries.Columns[e.ColumnIndex].Name == "SoTien" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = string.Format(new CultureInfo("vi-VN"), "{0:C0}", amount);
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            if (dgvJournalEntries.Columns[e.ColumnIndex].Name == "NgayGhiSo" && e.Value != null)
            {
                if (e.Value is DateTime d) e.Value = d.ToString("dd/MM/yyyy");
            }
        }

        private void SetupButtonHoverEffects()
        {
            btnAdd.MouseEnter += (s, e) => btnAdd.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnAdd.MouseLeave += (s, e) => btnAdd.BackColor = ColorTranslator.FromHtml("#0D6EFD");
            btnEdit.MouseEnter += (s, e) => btnEdit.BackColor = ColorTranslator.FromHtml("#FFCA2C");
            btnEdit.MouseLeave += (s, e) => btnEdit.BackColor = ColorTranslator.FromHtml("#FFC107");
            btnViewDetail.MouseEnter += (s, e) => btnViewDetail.BackColor = ColorTranslator.FromHtml("#1AA2BA");
            btnViewDetail.MouseLeave += (s, e) => btnViewDetail.BackColor = ColorTranslator.FromHtml("#17A2B8");
            btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = ColorTranslator.FromHtml("#BB2D3B");
            btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = ColorTranslator.FromHtml("#DC3545");
            btnExport.MouseEnter += (s, e) => btnExport.BackColor = ColorTranslator.FromHtml("#1E7E4E");
            btnExport.MouseLeave += (s, e) => btnExport.BackColor = ColorTranslator.FromHtml("#198754");
        }

        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            txtSearch.Enter += (s, e) => { if (txtSearch.Text == searchPlaceholder) { txtSearch.Text = ""; txtSearch.ForeColor = Color.Black; } };
            txtSearch.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = searchPlaceholder; txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD"); } };
        }

        private void SetupDateRangePicker()
        {
            dtpStartDate.Value = new DateTime(2025, 1, 1);
            dtpEndDate.Value = DateTime.Now;
        }

        // --- LOAD DỮ LIỆU ---
        private void LoadJournalEntryData(string keyword = "")
        {
            try
            {
                string query = @"
                    SELECT 
                        BT.SoCT AS MaBT,        
                        BT.NgayHachToan AS NgayGhiSo, 
                        BT.SoCT AS ChungTu,     
                        BT.TKNo, 
                        BT.TKCo, 
                        BT.SoTienBT AS SoTien,  
                        BT.DienGiai, 
                        ISNULL(BT.TrangThai, N'Ghi sổ') AS TrangThai,
                        ISNULL((SELECT TOP 1 HoTenNV FROM NHANVIEN WHERE MaPB = 'PB004'), N'Kế toán viên') AS NguoiGhiSo 
                    FROM BUTTOAN BT
                    WHERE (@Keyword = '' OR BT.SoCT LIKE @Search OR BT.DienGiai LIKE @Search)
                    AND BT.NgayHachToan BETWEEN @StartDate AND @EndDate
                    ORDER BY BT.NgayHachToan DESC";

                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                    adapter.SelectCommand.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1));
                    adapter.SelectCommand.Parameters.AddWithValue("@Keyword", keyword);
                    adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" + keyword + "%");
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvJournalEntries.DataSource = data;
                    CalculateStatistics(data);
                }
            }
            catch (Exception ex) { ShowError("Lỗi tải dữ liệu", ex.Message); }
        }

        private void CalculateStatistics(DataTable data)
        {
            int count = data.Rows.Count;
            decimal totalAmount = 0;
            if (data.Rows.Count > 0)
            {
                object sum = data.Compute("Sum(SoTien)", "");
                if (sum != DBNull.Value) totalAmount = Convert.ToDecimal(sum);
            }
            lblStatsCount.Text = $"{count} bút toán";
            lblTotalDebit.Text = string.Format(new CultureInfo("vi-VN"), "{0:C0}", totalAmount);
            lblTotalCredit.Text = string.Format(new CultureInfo("vi-VN"), "{0:C0}", totalAmount);
        }

        // --- SỰ KIỆN NÚT ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            JournalEntryDetailForm detailForm = new JournalEntryDetailForm(CONNECTION_STRING, null);
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                LoadJournalEntryData();
                ShowSuccess("Thêm bút toán mới thành công!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckSelection())
            {
                string maBT = dgvJournalEntries.SelectedRows[0].Cells["MaBT"].Value.ToString();
                // Mặc định isViewOnly = false (Cho phép sửa)
                JournalEntryDetailForm detailForm = new JournalEntryDetailForm(CONNECTION_STRING, maBT);
                if (detailForm.ShowDialog() == DialogResult.OK)
                {
                    LoadJournalEntryData();
                    ShowSuccess("Cập nhật thành công!");
                }
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (CheckSelection())
            {
                string maBT = dgvJournalEntries.SelectedRows[0].Cells["MaBT"].Value.ToString();
                // Truyền isViewOnly = true (Chỉ xem)
                JournalEntryDetailForm detailForm = new JournalEntryDetailForm(CONNECTION_STRING, maBT, true);
                detailForm.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckSelection())
            {
                string maBT = dgvJournalEntries.SelectedRows[0].Cells["MaBT"].Value.ToString();
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa bút toán {maBT}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                        {
                            conn.Open();
                            string query = "DELETE FROM BUTTOAN WHERE SoCT = @MaBT";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@MaBT", maBT);
                            cmd.ExecuteNonQuery();
                        }
                        LoadJournalEntryData();
                        ShowSuccess("Đã xóa bút toán thành công.");
                    }
                    catch (Exception ex) { ShowError("Lỗi xóa dữ liệu", ex.Message); }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvJournalEntries.Rows.Count == 0)
            {
                ShowWarning("Dữ liệu trống", "Không có dữ liệu để xuất file.");
                return;
            }
            try { ExportToExcel_Interop(); }
            catch (Exception ex) { ShowError("Lỗi xuất Excel", "Vui lòng đảm bảo máy tính đã cài đặt Microsoft Excel.\n" + ex.Message); }
        }

        private void ExportToExcel_Interop()
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            excelApp.WindowState = Excel.XlWindowState.xlMaximized;
            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            worksheet.Name = "SoNhatKyChung";

            int startRow = 6;
            // Header Công ty
            Excel.Range headRange = worksheet.Range["A1", "F1"];
            headRange.Merge();
            headRange.Value = "CÔNG TY CỔ PHẦN ACECOOK VIỆT NAM";
            headRange.Font.Bold = true;
            headRange.Font.Size = 14;
            headRange.Font.Color = ColorTranslator.ToOle(Color.Red);
            headRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            // Tiêu đề
            Excel.Range titleRange = worksheet.Range["A3", "I3"];
            titleRange.Merge();
            titleRange.Value = "SỔ NHẬT KÝ CHUNG";
            titleRange.Font.Bold = true;
            titleRange.Font.Size = 16;
            titleRange.Font.Color = ColorTranslator.ToOle(Color.Navy);
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Ngày tháng
            Excel.Range dateRange = worksheet.Range["A4", "I4"];
            dateRange.Merge();
            dateRange.Value = $"Từ ngày: {dtpStartDate.Value:dd/MM/yyyy} - Đến ngày: {dtpEndDate.Value:dd/MM/yyyy}";
            dateRange.Font.Italic = true;
            dateRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Header Cột
            for (int i = 0; i < dgvJournalEntries.Columns.Count; i++)
            {
                worksheet.Cells[5, i + 1] = dgvJournalEntries.Columns[i].HeaderText;
                Excel.Range cell = (Excel.Range)worksheet.Cells[5, i + 1];
                cell.Font.Bold = true;
                cell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                cell.RowHeight = 30;
            }

            // Dữ liệu
            for (int i = 0; i < dgvJournalEntries.Rows.Count; i++)
            {
                for (int j = 0; j < dgvJournalEntries.Columns.Count; j++)
                {
                    object cellValue = dgvJournalEntries.Rows[i].Cells[j].Value;
                    string colName = dgvJournalEntries.Columns[j].Name;
                    Excel.Range cell = (Excel.Range)worksheet.Cells[startRow + i, j + 1];

                    if (colName == "SoTien" && cellValue != null && decimal.TryParse(cellValue.ToString(), out decimal val))
                    {
                        cell.Value = val;
                        cell.NumberFormat = "#,##0";
                    }
                    else if (colName == "NgayGhiSo" && cellValue != null && DateTime.TryParse(cellValue.ToString(), out DateTime dateVal))
                    {
                        cell.Value = dateVal;
                        cell.NumberFormat = "dd/MM/yyyy";
                        cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    }
                    else
                    {
                        cell.Value = cellValue != null ? cellValue.ToString() : "";
                        cell.WrapText = true;
                    }
                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }

            // Footer
            int footerRow = startRow + dgvJournalEntries.Rows.Count + 2;
            Excel.Range signDateRange = worksheet.Range[$"G{footerRow}", $"I{footerRow}"];
            signDateRange.Merge();
            signDateRange.Value = $"..............., ngày ... tháng ... năm {DateTime.Now.Year}";
            signDateRange.Font.Italic = true;
            signDateRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range lblLapBieu = worksheet.Range[$"G{footerRow + 1}", $"I{footerRow + 1}"];
            lblLapBieu.Merge();
            lblLapBieu.Value = "NGƯỜI GHI SỔ";
            lblLapBieu.Font.Bold = true;
            lblLapBieu.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range lblKTT = worksheet.Range[$"B{footerRow + 1}", $"D{footerRow + 1}"];
            lblKTT.Merge();
            lblKTT.Value = "KẾ TOÁN TRƯỞNG";
            lblKTT.Font.Bold = true;
            lblKTT.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range signNote1 = worksheet.Range[$"G{footerRow + 2}", $"I{footerRow + 2}"];
            signNote1.Merge();
            signNote1.Value = "(Ký, ghi rõ họ tên)";
            signNote1.Font.Italic = true;
            signNote1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range signNote2 = worksheet.Range[$"B{footerRow + 2}", $"D{footerRow + 2}"];
            signNote2.Merge();
            signNote2.Value = "(Ký, ghi rõ họ tên)";
            signNote2.Font.Italic = true;
            signNote2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            worksheet.Columns.AutoFit();
            ((Excel.Range)worksheet.Columns["G"]).ColumnWidth = 40;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = (txtSearch.Text == searchPlaceholder) ? "" : txtSearch.Text.Trim();
            LoadJournalEntryData(keyword);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            dtpStartDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEndDate.Value = DateTime.Now;
            LoadJournalEntryData();
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        private bool CheckSelection()
        {
            if (dgvJournalEntries.SelectedRows.Count == 0)
            {
                ShowWarning("Chưa chọn", "Vui lòng chọn một bút toán để thao tác.");
                return false;
            }
            return true;
        }

        private void ShowSuccess(string msg) => MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void ShowError(string title, string msg) => MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarning(string title, string msg) => MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}