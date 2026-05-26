using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class ProductManagementForm : Form
    {
        private readonly string CONNECTION_STRING;
        private string searchPlaceholderProduct = "Nhập mã hoặc tên sản phẩm...";
        private string searchPlaceholderMaterial = "Nhập mã hoặc tên nguyên vật liệu...";

        public ProductManagementForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            LoadProductData(); // Load tab Sản phẩm đầu tiên
            SetupSearchPlaceholder(true);
        }

        // --- CÁC HÀM VISUAL ---
        private void SetupVisualStyling()
        {
            SetupTabControl();
            txtSearch.Text = searchPlaceholderProduct;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");

            // Tắt style mặc định của Windows để áp dụng màu tùy chỉnh
            dgvProducts.EnableHeadersVisualStyles = false;
            dgvMaterials.EnableHeadersVisualStyles = false;
        }

        private void SetupTabControl()
        {
            tabControlProducts.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControlProducts.DrawItem += TabControlProducts_DrawItem;
        }

        private void TabControlProducts_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);

            // Màu nền tab đang chọn vs không chọn
            Color backColor = (e.State == DrawItemState.Selected) ?
                (e.Index == 0 ? ColorTranslator.FromHtml("#6F42C1") : ColorTranslator.FromHtml("#28A745"))
                : ColorTranslator.FromHtml("#F8F9FA");

            Color textColor = (e.State == DrawItemState.Selected) ? Color.White : ColorTranslator.FromHtml("#495057");

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, tabRect);
            }

            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, tabRect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // --- LOAD DATA & FORMAT ---

        private void LoadProductData(string searchQuery = "")
        {
            string query = @"
                SELECT SP.MaSP, SP.TenSP, LSP.TenLoaiSP, SP.GiaBanSP, SP.NhietDoBaoQuan, SP.NSXSP, SP.HSDSP
                FROM SANPHAM SP
                INNER JOIN LOAISANPHAM LSP ON SP.MaLoaiSP = LSP.MaLoaiSP
                WHERE (@SearchQuery = '' OR SP.MaSP LIKE @SearchQuery OR SP.TenSP LIKE @SearchQuery)
                ORDER BY SP.MaSP ASC";

            LoadDataToGrid(dgvProducts, query, searchQuery);
            UpdateStats("SP", dgvProducts.RowCount);
            FormatProductDataGridView(); // Định dạng và tô màu
        }

        private void LoadMaterialData(string searchQuery = "")
        {
            string query = @"
                SELECT MaNL, TenNL, DVTNL, SoLuongTon 
                FROM NGUYENLIEU
                WHERE (@SearchQuery = '' OR MaNL LIKE @SearchQuery OR TenNL LIKE @SearchQuery)
                ORDER BY MaNL ASC";

            LoadDataToGrid(dgvMaterials, query, searchQuery);
            UpdateStats("NL", dgvMaterials.RowCount);
            FormatMaterialDataGridView(); // Định dạng và tô màu
        }

        private void LoadDataToGrid(DataGridView dgv, string query, string searchQuery)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    string paramValue = string.IsNullOrWhiteSpace(searchQuery) ||
                                        searchQuery == searchPlaceholderProduct ||
                                        searchQuery == searchPlaceholderMaterial ? "" : $"%{searchQuery}%";
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchQuery", paramValue);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgv.DataSource = dt;
                }
                catch (Exception ex) { ShowError("Lỗi tải dữ liệu", ex.Message); }
            }
        }

        // --- ĐỊNH DẠNG CỘT & MÀU SẮC ---

        private void FormatProductDataGridView()
        {
            if (dgvProducts.Columns.Count == 0) return;

            // 1. Đặt tên cột tiếng Việt
            dgvProducts.Columns["MaSP"].HeaderText = "Mã SP";
            dgvProducts.Columns["TenSP"].HeaderText = "Tên Sản phẩm";
            dgvProducts.Columns["TenLoaiSP"].HeaderText = "Loại";
            dgvProducts.Columns["GiaBanSP"].HeaderText = "Giá bán";
            dgvProducts.Columns["NhietDoBaoQuan"].HeaderText = "Nhiệt độ BQ";
            dgvProducts.Columns["NSXSP"].HeaderText = "NSX";
            dgvProducts.Columns["HSDSP"].HeaderText = "HSD";

            // 2. Định dạng số và ngày
            dgvProducts.Columns["GiaBanSP"].DefaultCellStyle.Format = "N0";
            dgvProducts.Columns["GiaBanSP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProducts.Columns["NSXSP"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvProducts.Columns["HSDSP"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // 3. TÔ MÀU HEADER (Màu Tím)
            dgvProducts.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#6F42C1");
            dgvProducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProducts.EnableHeadersVisualStyles = false;
        }

        private void FormatMaterialDataGridView()
        {
            if (dgvMaterials.Columns.Count == 0) return;

            // 1. Đặt tên cột
            dgvMaterials.Columns["MaNL"].HeaderText = "Mã NVL";
            dgvMaterials.Columns["TenNL"].HeaderText = "Tên Nguyên vật liệu";
            dgvMaterials.Columns["DVTNL"].HeaderText = "ĐVT";

            if (dgvMaterials.Columns.Contains("SoLuongTon"))
            {
                dgvMaterials.Columns["SoLuongTon"].HeaderText = "Tồn kho";
                // SỬA QUAN TRỌNG: Dùng N0 để hiển thị số nguyên (vd: 5,000)
                dgvMaterials.Columns["SoLuongTon"].DefaultCellStyle.Format = "N0";
                dgvMaterials.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvMaterials.Columns["MaNL"].Width = 100;
            dgvMaterials.Columns["TenNL"].Width = 300;

            // 2. TÔ MÀU HEADER (Màu Xanh lá)
            dgvMaterials.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#28A745");
            dgvMaterials.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMaterials.EnableHeadersVisualStyles = false;
        }

        private void UpdateStats(string type, int count)
        {
            if (type == "SP")
            {
                lblStatsTitle.Text = "📦 Tổng số SP:";
                pnlStats.BackColor = ColorTranslator.FromHtml("#6F42C1");
            }
            else
            {
                lblStatsTitle.Text = "🌿 Tổng số NVL:";
                pnlStats.BackColor = ColorTranslator.FromHtml("#28A745");
            }
            lblTotalItems.Text = count.ToString();
        }

        // --- CÁC SỰ KIỆN TÌM KIẾM VÀ TAB ---

        private void SetupSearchPlaceholder(bool isProductTab)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) || txtSearch.Text == searchPlaceholderProduct || txtSearch.Text == searchPlaceholderMaterial)
            {
                txtSearch.Text = isProductTab ? searchPlaceholderProduct : searchPlaceholderMaterial;
                txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == searchPlaceholderProduct || txtSearch.Text == searchPlaceholderMaterial)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = ColorTranslator.FromHtml("#495057");
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                bool isProductTab = tabControlProducts.SelectedTab == tabPageProducts;
                SetupSearchPlaceholder(isProductTab);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();
            if (query == searchPlaceholderProduct || query == searchPlaceholderMaterial) query = "";

            if (tabControlProducts.SelectedTab == tabPageProducts) LoadProductData(query);
            else LoadMaterialData(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            bool isProductTab = tabControlProducts.SelectedTab == tabPageProducts;
            SetupSearchPlaceholder(isProductTab);

            if (isProductTab) LoadProductData();
            else LoadMaterialData();
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        private void tabControlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isProductTab = tabControlProducts.SelectedTab == tabPageProducts;
            SetupSearchPlaceholder(isProductTab);

            if (isProductTab)
            {
                LoadProductData();
                btnViewDetail.BackColor = ColorTranslator.FromHtml("#6F42C1");
            }
            else
            {
                LoadMaterialData();
                btnViewDetail.BackColor = ColorTranslator.FromHtml("#28A745");
            }
        }

        // --- XỬ LÝ NÚT CHỨC NĂNG (THÊM, XÓA, SỬA...) ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool isProductTab = tabControlProducts.SelectedTab == tabPageProducts;
            try
            {
                Form addForm;
                if (isProductTab) addForm = new ProductAddEditForm(CONNECTION_STRING);
                else addForm = new MaterialAddEditForm(CONNECTION_STRING);

                addForm.StartPosition = FormStartPosition.CenterParent;
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    if (isProductTab) LoadProductData(); else LoadMaterialData();
                    ShowSuccess($"Thêm mới {(isProductTab ? "Sản phẩm" : "Nguyên vật liệu")} thành công!");
                }
            }
            catch (Exception ex) { ShowError("Lỗi mở form", ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e) => ShowSelectedRowDetails(true);
        private void btnViewDetail_Click(object sender, EventArgs e) => ShowSelectedRowDetails(false);

        // SỰ KIỆN CLICK GRID (Để tránh lỗi CS1061)
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { if (e.RowIndex >= 0) ShowSelectedRowDetails(false); }

        private void dgvMaterials_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { if (e.RowIndex >= 0) ShowSelectedRowDetails(false); }

        private void ShowSelectedRowDetails(bool isEdit = false)
        {
            DataGridView dgv = tabControlProducts.SelectedTab == tabPageProducts ? dgvProducts : dgvMaterials;
            bool isProductTab = dgv == dgvProducts;

            if (dgv.SelectedRows.Count > 0)
            {
                string id = dgv.SelectedRows[0].Cells[0].Value.ToString();
                try
                {
                    if (isProductTab)
                    {
                        var form = new ProductAddEditForm(CONNECTION_STRING, id);
                        if (!isEdit) form.SetReadOnlyMode(true);
                        if (form.ShowDialog() == DialogResult.OK) LoadProductData();
                    }
                    else
                    {
                        var form = new MaterialAddEditForm(CONNECTION_STRING, id);
                        if (!isEdit) form.SetReadOnlyMode(true);
                        if (form.ShowDialog() == DialogResult.OK) LoadMaterialData();
                    }
                }
                catch (Exception ex) { ShowError("Lỗi mở form", ex.Message); }
            }
            else
            {
                ShowWarning("Chưa chọn", "Vui lòng chọn một dòng để thao tác.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tabControlProducts.SelectedTab == tabPageProducts ? dgvProducts : dgvMaterials;
            if (dgv.SelectedRows.Count == 0) { ShowWarning("Chưa chọn", "Vui lòng chọn dòng để xóa."); return; }

            string id = dgv.SelectedRows[0].Cells[0].Value.ToString();
            string name = dgv.SelectedRows[0].Cells[1].Value.ToString();
            bool isProduct = (dgv == dgvProducts);

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa {(isProduct ? "SP" : "NVL")}: {name}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ExecuteDelete(id, isProduct);
            }
        }

        private void ExecuteDelete(string id, bool isProduct)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string table = isProduct ? "SANPHAM" : "NGUYENLIEU";
                    string col = isProduct ? "MaSP" : "MaNL";

                    // Kiểm tra và xóa ràng buộc trong DINH_MUC
                    string bomCol = isProduct ? "MaSP" : "MaNL";
                    SqlCommand checkCmd = new SqlCommand($"SELECT COUNT(*) FROM DINH_MUC WHERE {bomCol} = @Id", conn, trans);
                    checkCmd.Parameters.AddWithValue("@Id", id);

                    if ((int)checkCmd.ExecuteScalar() > 0)
                    {
                        if (isProduct) // Xóa SP -> Xóa luôn BOM của nó
                            new SqlCommand($"DELETE FROM DINH_MUC WHERE MaSP = @Id", conn, trans).ExecuteNonQuery();
                        else // Xóa NVL -> Chặn nếu đang được dùng
                        {
                            trans.Rollback();
                            ShowWarning("Không thể xóa", "Nguyên liệu đang được sử dụng trong định mức sản phẩm.");
                            return;
                        }
                    }

                    // Xóa bản ghi chính
                    SqlCommand delCmd = new SqlCommand($"DELETE FROM {table} WHERE {col} = @Id", conn, trans);
                    delCmd.Parameters.AddWithValue("@Id", id);
                    delCmd.ExecuteNonQuery();

                    trans.Commit();
                    ShowSuccess("Xóa thành công!");
                    if (isProduct) LoadProductData(); else LoadMaterialData();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    ShowError("Lỗi xóa", ex.Message);
                }
            }
        }

        private void ShowSuccess(string msg) => MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void ShowError(string title, string msg) => MessageBox.Show(msg, "❌ " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowWarning(string title, string msg) => MessageBox.Show(msg, "⚠️ " + title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}