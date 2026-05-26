using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class SupplierForm : Form
    {
        private string CONNECTION_STRING;
        private string searchPlaceholder = "Nhập mã, tên nhà cung cấp hoặc số điện thoại...";

        public SupplierForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            LoadSupplierData();
            SetupSearchPlaceholder();
        }

        private void SetupVisualStyling()
        {
            // DataGridView styling
            dgvSuppliers.AutoGenerateColumns = false;
            dgvSuppliers.BackgroundColor = Color.White;
            dgvSuppliers.RowHeadersVisible = false;

            // Button hover effects
            SetupButtonHoverEffects();
        }

        private void SetupButtonHoverEffects()
        {
            // Add button - Blue
            btnAdd.MouseEnter += (s, e) => btnAdd.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnAdd.MouseLeave += (s, e) => btnAdd.BackColor = ColorTranslator.FromHtml("#0D6EFD");

            // View button - Green
            btnView.MouseEnter += (s, e) => btnView.BackColor = ColorTranslator.FromHtml("#1E7E4E");
            btnView.MouseLeave += (s, e) => btnView.BackColor = ColorTranslator.FromHtml("#198754");

            // Edit button - Yellow
            btnEdit.MouseEnter += (s, e) => btnEdit.BackColor = ColorTranslator.FromHtml("#FFCA2C");
            btnEdit.MouseLeave += (s, e) => btnEdit.BackColor = ColorTranslator.FromHtml("#FFC107");

            // Delete button - Red
            btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = ColorTranslator.FromHtml("#BB2D3B");
            btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = ColorTranslator.FromHtml("#DC3545");

            // Search button - Blue
            btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#007BFF");

            // Refresh button - Grey
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

        // --- DATA OPERATIONS ---

        private void LoadSupplierData(string keyword = "")
        {
            // ĐÃ CHỈNH SỬA: Thay thế tên cột để khớp với Database (DiaChiNCC, SDTNCC, EmailNCC) 
            // và sử dụng AS để giữ tên cột hiển thị trên DataGridView (DiaChi, DienThoai, Email).
            string query = @"
                SELECT 
                    MaNCC, 
                    TenNCC, 
                    DiaChiNCC AS DiaChi,        
                    SDTNCC AS DienThoai,        
                    EmailNCC AS Email           
                FROM NHACUNGCAP
                WHERE (@Keyword = '' 
                    OR MaNCC LIKE @Keyword 
                    OR TenNCC LIKE @Keyword 
                    OR SDTNCC LIKE @Keyword)    -- SỬ DỤNG SDTNCC CHO TÌM KIẾM
                ORDER BY MaNCC ASC";

            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Keyword", $"%{keyword}%");

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvSuppliers.DataSource = dt;
                    UpdateStats(dt.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi tải dữ liệu", ex.Message);
            }
        }

        private void UpdateStats(int count)
        {
            lblTotalSuppliers.Text = $"Tổng: {count} NCC";
        }

        // --- EVENT HANDLERS ---

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SupplierAddEditForm addForm = new SupplierAddEditForm(CONNECTION_STRING))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSupplierData();
                    ShowSuccess("Thêm mới nhà cung cấp thành công!");
                }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count == 0)
            {
                ShowWarning("Chưa chọn", "Vui lòng chọn một nhà cung cấp để xem chi tiết.");
                return;
            }

            string maNCC = dgvSuppliers.SelectedRows[0].Cells["MaNCC"].Value.ToString();
            using (SupplierAddEditForm viewForm = new SupplierAddEditForm(CONNECTION_STRING, maNCC, isReadOnly: true))
            {
                viewForm.ShowDialog();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count == 0)
            {
                ShowWarning("Chưa chọn", "Vui lòng chọn một nhà cung cấp để chỉnh sửa.");
                return;
            }

            string maNCC = dgvSuppliers.SelectedRows[0].Cells["MaNCC"].Value.ToString();
            using (SupplierAddEditForm editForm = new SupplierAddEditForm(CONNECTION_STRING, maNCC))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadSupplierData();
                    ShowSuccess("Cập nhật thông tin nhà cung cấp thành công!");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count == 0)
            {
                ShowWarning("Chưa chọn", "Vui lòng chọn một nhà cung cấp để xóa.");
                return;
            }

            string maNCC = dgvSuppliers.SelectedRows[0].Cells["MaNCC"].Value.ToString();
            string tenNCC = dgvSuppliers.SelectedRows[0].Cells["TenNCC"].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"⚠️ XÁC NHẬN XÓA NHÀ CUNG CẤP ⚠️\n\n" +
                $"━━━━━━━━━━━━━━━━━━━━━━━━\n" +
                $"Mã NCC: {maNCC}\n" +
                $"Tên: {tenNCC}\n" +
                $"━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
                $"Thao tác này không thể hoàn tác!\n" +
                $"Bạn có chắc chắn muốn xóa?",
                "⚠️ XÁC NHẬN XÓA",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.Yes)
            {
                DeleteSupplier(maNCC, tenNCC);
            }
        }

        private void DeleteSupplier(string maNCC, string tenNCC)
        {
            string deleteQuery = "DELETE FROM NHACUNGCAP WHERE MaNCC = @MaNCC";

            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaNCC", maNCC);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ShowSuccess($"✅ Đã xóa thành công nhà cung cấp '{tenNCC}' ({maNCC})!");
                            LoadSupplierData();
                        }
                        else
                        {
                            ShowWarning("Không tìm thấy", "Không tìm thấy nhà cung cấp để xóa.");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // FK constraint violation
                {
                    ShowError(
                        "Không thể xóa",
                        $"Nhà cung cấp '{tenNCC}' đang có dữ liệu liên quan:\n\n" +
                        "• Có phiếu nhập hàng\n" +
                        "• Có nguyên vật liệu đang cung cấp\n" +
                        "• Hoặc có dữ liệu liên kết khác\n\n" +
                        "Vui lòng xóa các dữ liệu liên quan trước."
                    );
                }
                else
                {
                    ShowError("Lỗi xóa dữ liệu", ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi hệ thống", ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = (txtSearch.Text == searchPlaceholder) ? "" : txtSearch.Text.Trim();
            LoadSupplierData(keyword);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            LoadSupplierData();
            ShowSuccess("Đã làm mới dữ liệu!");
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
    }
}