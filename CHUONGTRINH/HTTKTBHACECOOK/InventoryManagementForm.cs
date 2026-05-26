using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class InventoryManagementForm : Form
    {
        private string CONNECTION_STRING;
        private string searchPlaceholder = "Tìm kiếm theo mã SP, tên SP, mã kho...";
        private DataTable _cachedInventory;
        private bool _isLoading = false;

        public InventoryManagementForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            SetupVisualStyling();
        }

        private async void InventoryManagementForm_Load(object sender, EventArgs e)
        {
            await LoadInventoryDataAsync();
            SetupSearchPlaceholder();
        }

        private void SetupVisualStyling()
        {
            // Hover effects cho buttons
            SetupButtonHover(btnImport, "#157347", "#198754");
            SetupButtonHover(btnExport, "#BB2D3F", "#DC3545");
            SetupButtonHover(btnRefresh, "#0B5ED7", "#0D6EFD");
        }

        private void SetupButtonHover(Button btn, string hoverColor, string normalColor)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml(hoverColor);
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml(normalColor);
        }

        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
        }

        /// <summary>
        /// ✅ LOAD DỮ LIỆU TỒN KHO
        /// Lấy từ bảng TONKHO để hiển thị số lượng tồn thực tế
        /// </summary>
        private async Task LoadInventoryDataAsync(string searchQuery = "")
        {
            if (_isLoading) return;

            try
            {
                _isLoading = true;
                this.Cursor = Cursors.WaitCursor;
                dgvInventory.Enabled = false;

                string query = BuildInventoryQuery(searchQuery);

                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    await connection.OpenAsync();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dtInventory = new DataTable();
                        await Task.Run(() => adapter.Fill(dtInventory));

                        _cachedInventory = dtInventory;

                        dgvInventory.DataSource = dtInventory;
                        FormatDataGridView();
                        UpdateStats(dtInventory);
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowError("Lỗi kết nối CSDL", ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Lỗi không xác định", ex.Message);
            }
            finally
            {
                _isLoading = false;
                this.Cursor = Cursors.Default;
                dgvInventory.Enabled = true;
            }
        }

        /// <summary>
        /// Tạo query để lấy dữ liệu tồn kho
        /// Lấy từ bảng TONKHO JOIN với SANPHAM và KHO
        /// </summary>
        private string BuildInventoryQuery(string searchQuery)
        {
            string query = @"
                SELECT 
                    T.MaKho,
                    K.TenKho,
                    T.MaSP,
                    S.TenSP,
                    ISNULL(T.SLTonCuoiKy, 0) AS SoLuongTon,
                    ISNULL(S.GiaBanSP, 0) AS DonGia,
                    ISNULL(T.SLTonCuoiKy, 0) * ISNULL(S.GiaBanSP, 0) AS TriGiaTon
                FROM TONKHO T
                LEFT JOIN SANPHAM S ON T.MaSP = S.MaSP
                LEFT JOIN KHO K ON T.MaKho = K.MaKho
                WHERE 1 = 1";

            // Chỉ hiển thị sản phẩm còn tồn kho (SL > 0)
            query += " AND ISNULL(T.SLTonCuoiKy, 0) > 0";

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != searchPlaceholder)
            {
                query += $@" AND (
                    T.MaSP LIKE N'%{EscapeSql(searchQuery)}%' OR 
                    S.TenSP LIKE N'%{EscapeSql(searchQuery)}%' OR 
                    T.MaKho LIKE N'%{EscapeSql(searchQuery)}%'
                )";
            }

            query += " ORDER BY K.TenKho ASC, S.TenSP ASC";
            return query;
        }

        private string EscapeSql(string input)
        {
            return input.Replace("'", "''");
        }

        private void UpdateStats(DataTable dt)
        {
            try
            {
                // Tính tổng số lượng tồn
                decimal totalStock = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["SoLuongTon"] != DBNull.Value)
                        totalStock += Convert.ToDecimal(row["SoLuongTon"]);
                }
                lblTotalStock.Text = totalStock.ToString("N0");

                // Tính tổng trị giá tồn
                decimal totalValue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TriGiaTon"] != DBNull.Value)
                        totalValue += Convert.ToDecimal(row["TriGiaTon"]);
                }
                // Nếu có label tổng trị giá thì hiển thị
                // lblTotalValue.Text = totalValue.ToString("N0") + " ₫";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating stats: {ex.Message}");
            }
        }

        private void FormatDataGridView()
        {
            var columns = new System.Collections.Generic.Dictionary<string, (string HeaderText, int Width, string Format, DataGridViewContentAlignment Alignment)>
            {
                { "MaKho", ("Mã Kho", 90, null, DataGridViewContentAlignment.MiddleCenter) },
                { "TenKho", ("Tên Kho", 200, null, DataGridViewContentAlignment.MiddleLeft) },
                { "MaSP", ("Mã SP", 100, null, DataGridViewContentAlignment.MiddleCenter) },
                { "TenSP", ("Tên Sản Phẩm", 300, null, DataGridViewContentAlignment.MiddleLeft) },
                { "SoLuongTon", ("SL Tồn", 120, "N0", DataGridViewContentAlignment.MiddleRight) },
                { "DonGia", ("Đơn Giá", 130, "N0", DataGridViewContentAlignment.MiddleRight) },
                { "TriGiaTon", ("Trị Giá (₫)", 150, "N0", DataGridViewContentAlignment.MiddleRight) }
            };

            foreach (var col in columns)
            {
                if (dgvInventory.Columns.Contains(col.Key))
                {
                    var column = dgvInventory.Columns[col.Key];
                    column.HeaderText = col.Value.HeaderText;
                    column.Width = col.Value.Width;
                    column.DefaultCellStyle.Alignment = col.Value.Alignment;

                    if (!string.IsNullOrEmpty(col.Value.Format))
                        column.DefaultCellStyle.Format = col.Value.Format;
                }
            }
        }

        private void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInventory.Columns[e.ColumnIndex].Name == "SoLuongTon" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal quantity))
                {
                    // Cảnh báo nếu sắp hết hàng
                    if (quantity <= 10 && quantity > 0)
                    {
                        e.CellStyle.ForeColor = Color.Orange;
                        e.CellStyle.Font = new Font(dgvInventory.Font, FontStyle.Bold);
                    }
                    else if (quantity <= 0)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(dgvInventory.Font, FontStyle.Bold);
                    }
                }
            }
        }

        #region EVENT HANDLERS

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == searchPlaceholder)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = ColorTranslator.FromHtml("#495057");
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = searchPlaceholder;
                txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            }
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await PerformSearchAsync();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async Task PerformSearchAsync()
        {
            string query = txtSearch.Text == searchPlaceholder ? "" : txtSearch.Text.Trim();
            await LoadInventoryDataAsync(query);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            await LoadInventoryDataAsync();
        }

        /// <summary>
        /// ✅ NÚT NHẬP KHO
        /// Mở form nhập kho với sản phẩm và kho đã chọn
        /// </summary>
        private async void btnImport_Click(object sender, EventArgs e)
        {
            string maSp = null;
            string maKho = null;

            // Lấy thông tin từ dòng được chọn
            if (dgvInventory.SelectedRows.Count > 0)
            {
                var selectedRow = dgvInventory.SelectedRows[0];

                if (dgvInventory.Columns.Contains("MaSP") && selectedRow.Cells["MaSP"].Value != null)
                {
                    maSp = selectedRow.Cells["MaSP"].Value.ToString();
                }

                if (dgvInventory.Columns.Contains("MaKho") && selectedRow.Cells["MaKho"].Value != null)
                {
                    maKho = selectedRow.Cells["MaKho"].Value.ToString();
                }
            }

            // Mở form NHẬP KHO (isImport = true)
            using (var frm = new InventoryTransactionForm(CONNECTION_STRING, true, maSp, maKho))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Reload dữ liệu sau khi nhập thành công
                    await LoadInventoryDataAsync();
                }
            }
        }

        /// <summary>
        /// ✅ NÚT XUẤT KHO
        /// Mở form xuất kho với sản phẩm và kho đã chọn
        /// </summary>
        private async void btnExport_Click(object sender, EventArgs e)
        {
            string maSp = null;
            string maKho = null;

            // Lấy thông tin từ dòng được chọn
            if (dgvInventory.SelectedRows.Count > 0)
            {
                var selectedRow = dgvInventory.SelectedRows[0];

                if (dgvInventory.Columns.Contains("MaSP") && selectedRow.Cells["MaSP"].Value != null)
                {
                    maSp = selectedRow.Cells["MaSP"].Value.ToString();
                }

                if (dgvInventory.Columns.Contains("MaKho") && selectedRow.Cells["MaKho"].Value != null)
                {
                    maKho = selectedRow.Cells["MaKho"].Value.ToString();
                }
            }

            // Kiểm tra đã chọn sản phẩm chưa
            if (string.IsNullOrEmpty(maSp) || string.IsNullOrEmpty(maKho))
            {
                ShowWarning("Vui lòng chọn một sản phẩm tồn kho để xuất!");
                return;
            }

            // Mở form XUẤT KHO (isImport = false)
            using (var frm = new InventoryTransactionForm(CONNECTION_STRING, false, maSp, maKho))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Reload dữ liệu sau khi xuất thành công
                    await LoadInventoryDataAsync();
                }
            }
        }

        #endregion

        #region HELPER METHODS

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "⚠️ Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string title, string message)
        {
            MessageBox.Show(message, "❌ " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}