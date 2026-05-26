using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace HTTKTBHACECOOK
{
    public partial class CustomerManagementForm : Form
    {
        private string CONNECTION_STRING;
        private string searchPlaceholder = "Nhập tên, mã hoặc số điện thoại khách hàng...";

        // Constructor nhận chuỗi kết nối từ Dashboard
        public CustomerManagementForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            SetupVisualStyling();
        }

        private void CustomerManagementForm_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
            SetupSearchPlaceholder();
        }

        private void SetupVisualStyling()
        {
            SetupButtonHoverEffects();
        }

        private void SetupButtonHoverEffects()
        {
            // Thêm hiệu ứng hover cho các nút (giữ nguyên mã)
            // Add button
            btnAdd.MouseEnter += (s, e) => btnAdd.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnAdd.MouseLeave += (s, e) => btnAdd.BackColor = ColorTranslator.FromHtml("#0D6EFD");

            // View Detail button
            btnViewDetail.MouseEnter += (s, e) => btnViewDetail.BackColor = ColorTranslator.FromHtml("#198754");
            btnViewDetail.MouseLeave += (s, e) => btnViewDetail.BackColor = ColorTranslator.FromHtml("#198754");

            // Edit button
            btnEdit.MouseEnter += (s, e) => btnEdit.BackColor = ColorTranslator.FromHtml("#FFCA2C");
            btnEdit.MouseLeave += (s, e) => btnEdit.BackColor = ColorTranslator.FromHtml("#FFC107");

            // Delete button
            btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = ColorTranslator.FromHtml("#BB2D3F");
            btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = ColorTranslator.FromHtml("#DC3545");

            // Search button
            btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#007BFF");

            // Refresh button
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = ColorTranslator.FromHtml("#5A6268");
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = ColorTranslator.FromHtml("#6C757D");
        }

        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
        }

        // Phương thức tải dữ liệu khách hàng
        private void LoadCustomerData(string searchQuery = "")
        {
            string query = @"
                SELECT 
                    KH.MaKH,
                    KH.TenKH,
                    KH.SDTKH,
                    KH.EmailKH,
                    KH.DiaChiKH,
                    KH.MaLoaiKH, 
                    LKH.TenLoaiKH, 
                    KH.MSTKH,
                    KH.STKKH
                FROM KHACHHANG KH
                INNER JOIN LOAIKHACHHANG LKH ON KH.MaLoaiKH = LKH.MaLoaiKH
                WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != searchPlaceholder)
            {
                query += $" AND (KH.MaKH LIKE N'%{searchQuery}%' OR KH.TenKH LIKE N'%{searchQuery}%' OR KH.SDTKH LIKE N'%{searchQuery}%') ";
            }

            query += " ORDER BY KH.MaKH ASC";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtCustomers = new DataTable();
                    adapter.Fill(dtCustomers);

                    dgvCustomers.DataSource = dtCustomers;
                    FormatDataGridView();
                    UpdateCustomerCount(dtCustomers.Rows.Count);
                }
                catch (SqlException ex)
                {
                    ShowError("Lỗi kết nối CSDL", ex.Message);
                }
                catch (Exception ex)
                {
                    ShowError("Lỗi hệ thống", ex.Message);
                }
            }
        }

        private void UpdateCustomerCount(int count)
        {
            lblTotalCustomers.Text = count.ToString();
        }

        private void FormatDataGridView()
        {
            // Ẩn cột MaLoaiKH
            if (dgvCustomers.Columns.Contains("MaLoaiKH"))
            {
                dgvCustomers.Columns["MaLoaiKH"].Visible = false;
            }

            // Đặt tiêu đề cột
            dgvCustomers.Columns["MaKH"].HeaderText = "Mã KH";
            dgvCustomers.Columns["TenKH"].HeaderText = "Tên Khách hàng";
            dgvCustomers.Columns["SDTKH"].HeaderText = "📞 Số điện thoại";
            dgvCustomers.Columns["EmailKH"].HeaderText = "📧 Email";
            dgvCustomers.Columns["DiaChiKH"].HeaderText = "📍 Địa chỉ";
            dgvCustomers.Columns["TenLoaiKH"].HeaderText = "🏷️ Loại KH";
            dgvCustomers.Columns["MSTKH"].HeaderText = "MST";
            dgvCustomers.Columns["STKKH"].HeaderText = "Số TK Ngân hàng";

            // Ẩn các cột không cần thiết
            if (dgvCustomers.Columns.Contains("MSTKH")) dgvCustomers.Columns["MSTKH"].Visible = false;
            if (dgvCustomers.Columns.Contains("STKKH")) dgvCustomers.Columns["STKKH"].Visible = false;

            // Đặt độ rộng cột
            dgvCustomers.Columns["MaKH"].Width = 100;
            dgvCustomers.Columns["TenKH"].Width = 250;
            dgvCustomers.Columns["SDTKH"].Width = 150;
            dgvCustomers.Columns["EmailKH"].Width = 200;
            dgvCustomers.Columns["TenLoaiKH"].Width = 150;

            // Căn giữa cho cột Mã KH
            dgvCustomers.Columns["MaKH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Thêm nút "Xem" nếu chưa có
            if (!dgvCustomers.Columns.Contains("btnView"))
            {
                DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
                btnView.HeaderText = "⚡ Thao tác";
                btnView.Text = "👁️ Xem";
                btnView.Name = "btnView";
                btnView.UseColumnTextForButtonValue = true;
                btnView.Width = 120;
                btnView.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#0D6EFD");
                btnView.DefaultCellStyle.ForeColor = Color.White;
                btnView.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#0B5ED7");
                btnView.DefaultCellStyle.SelectionForeColor = Color.White;
                dgvCustomers.Columns.Add(btnView);
            }
        }

        // --- XỬ LÝ SỰ KIỆN NÚT VÀ DGV ---

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
            string query = txtSearch.Text == searchPlaceholder ? "" : txtSearch.Text.Trim();
            LoadCustomerData(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            LoadCustomerData();
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        // KHỞI TẠO FORM THÊM MỚI (ADD)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở CustomerAddEditForm ở chế độ Thêm mới (MaKH = null)
                CustomerAddEditForm addForm = new CustomerAddEditForm(this.CONNECTION_STRING);
                addForm.StartPosition = FormStartPosition.CenterParent;

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCustomerData(); // Tải lại dữ liệu sau khi thêm mới
                    ShowSuccess("Thêm mới khách hàng thành công!");
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khởi tạo Form", ex.Message);
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            ShowSelectedRowDetails();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowSelectedRowDetails(isEdit: true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedCustomer();
        }

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCustomers.Columns.Contains("btnView") &&
                e.ColumnIndex == dgvCustomers.Columns["btnView"].Index)
            {
                ShowSelectedRowDetails();
            }
        }

        // HÀM QUAN TRỌNG: XEM CHI TIẾT VÀ GỌI CustomerDetailForm/CustomerAddEditForm
        private void ShowSelectedRowDetails(bool isEdit = false)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];
                string maKH = row.Cells["MaKH"].Value.ToString();

                if (isEdit)
                {
                    // KHỞI TẠO FORM CHỈNH SỬA (EDIT)
                    try
                    {
                        CustomerAddEditForm editForm = new CustomerAddEditForm(this.CONNECTION_STRING, maKH);
                        editForm.StartPosition = FormStartPosition.CenterParent;

                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadCustomerData(); // Tải lại dữ liệu sau khi cập nhật
                            ShowSuccess($"Cập nhật khách hàng {maKH} thành công!");
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowError("Lỗi khởi tạo Form", ex.Message);
                    }
                }
                else
                {
                    // KHỞI TẠO FORM XEM CHI TIẾT (DETAIL)
                    try
                    {
                        CustomerDetailForm detailForm = new CustomerDetailForm(maKH, this.CONNECTION_STRING);
                        detailForm.StartPosition = FormStartPosition.CenterParent;
                        detailForm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        ShowError("Lỗi hiển thị chi tiết", ex.Message);
                    }
                }
            }
            else
            {
                ShowWarning("Chưa chọn khách hàng", "Vui lòng chọn một khách hàng trong danh sách.");
            }
        }

        private void DeleteSelectedCustomer()
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];
                string maKH = row.Cells["MaKH"].Value.ToString();
                string tenKH = row.Cells["TenKH"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"⚠️ BẠN ĐANG THỰC HIỆN XÓA KHÁCH HÀNG ⚠️\n\n" +
                    $"Mã KH: {maKH}\nTên: {tenKH}\n\n" +
                    $"Thao tác này không thể hoàn tác!\nBạn có chắc chắn muốn xóa?",
                    "⚠️ XÁC NHẬN XÓA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                );

                if (result == DialogResult.Yes)
                {
                    ExecuteDelete(maKH, tenKH);
                }
            }
            else
            {
                ShowWarning("Chưa chọn khách hàng", "Vui lòng chọn một khách hàng trong danh sách để xóa.");
            }
        }

        private void ExecuteDelete(string maKH, string tenKH)
        {
            string deleteQuery = "DELETE FROM KHACHHANG WHERE MaKH = @MaKH";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", maKH);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ShowSuccess($"✅ Đã xóa thành công khách hàng '{tenKH}' ({maKH})!");
                            LoadCustomerData();
                        }
                        else
                        {
                            ShowWarning("Không tìm thấy", "Không tìm thấy khách hàng để xóa.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547)
                        {
                            ShowError(
                                "Không thể xóa khách hàng",
                                $"Khách hàng '{tenKH}' đang có dữ liệu liên quan trong hệ thống.\n\nVui lòng xóa các dữ liệu liên quan trước khi xóa khách hàng."
                            );
                        }
                        else
                        {
                            ShowError("Lỗi xóa dữ liệu", ex.Message);
                        }
                    }
                }
            }
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