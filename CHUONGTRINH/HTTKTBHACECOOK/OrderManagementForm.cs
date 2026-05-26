using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace HTTKTBHACECOOK
{
    public partial class OrderManagementForm : Form
    {
        private string CONNECTION_STRING;
        private string searchPlaceholder = "Nhập mã đơn hàng, tên khách hàng...";

        public OrderManagementForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            SetupVisualStyling();
        }

        private void OrderManagementForm_Load(object sender, EventArgs e)
        {
            LoadOrderData();
            SetupSearchPlaceholder();
        }

        private void SetupVisualStyling()
        {
            SetupButtonHoverEffects();
        }

        private void SetupButtonHoverEffects()
        {
            // Thiết lập hiệu ứng hover cho các nút (giữ nguyên logic)
            btnAdd.MouseEnter += (s, e) => btnAdd.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnAdd.MouseLeave += (s, e) => btnAdd.BackColor = ColorTranslator.FromHtml("#0D6EFD");

            btnViewDetail.MouseEnter += (s, e) => btnViewDetail.BackColor = ColorTranslator.FromHtml("#198754");
            btnViewDetail.MouseLeave += (s, e) => btnViewDetail.BackColor = ColorTranslator.FromHtml("#198754");

            btnEdit.MouseEnter += (s, e) => btnEdit.BackColor = ColorTranslator.FromHtml("#FFCA2C");
            btnEdit.MouseLeave += (s, e) => btnEdit.BackColor = ColorTranslator.FromHtml("#FFC107");

            btnDelete.MouseEnter += (s, e) => btnDelete.BackColor = ColorTranslator.FromHtml("#BB2D3F");
            btnDelete.MouseLeave += (s, e) => btnDelete.BackColor = ColorTranslator.FromHtml("#DC3545");

            btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#0B5ED7");
            btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = ColorTranslator.FromHtml("#007BFF");

            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = ColorTranslator.FromHtml("#5A6268");
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = ColorTranslator.FromHtml("#6C757D");
        }


        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
        }

        // --- LOGIC LOAD DATA ---

        private void LoadOrderData(string searchQuery = "")
        {
            string query = @"
                SELECT 
                    DDH.MaDDH,
                    KH.TenKH, 
                    DDH.NgayDatHang,
                    DDH.TriGiaDH,
                    DDH.TrangThaiDH,
                    DDH.PhuongThucThanhToan
                FROM DONDATHANG DDH
                INNER JOIN KHACHHANG KH ON DDH.MaKH = KH.MaKH
                WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(searchQuery) && searchQuery != searchPlaceholder)
            {
                query += $" AND (DDH.MaDDH LIKE N'%{searchQuery}%' OR KH.TenKH LIKE N'%{searchQuery}%') ";
            }

            query += " ORDER BY DDH.NgayDatHang DESC";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtOrders = new DataTable();
                    adapter.Fill(dtOrders);

                    dgvOrders.DataSource = dtOrders;
                    FormatDataGridView();
                    UpdateOrderCount(dtOrders.Rows.Count);
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

        private void UpdateOrderCount(int count)
        {
            lblTotalOrders.Text = count.ToString();
        }

        private void FormatDataGridView()
        {
            // (Mã định dạng DataGridView giữ nguyên)
            // ... (Định dạng cột và thêm nút 'Xem' đã được thực hiện trong thiết kế trước đó) ...

            // Xử lý khi Data Grid View có thể chưa được load
            if (dgvOrders.Columns.Count == 0) return;

            // Đặt tiêu đề cột
            dgvOrders.Columns["MaDDH"].HeaderText = "Mã ĐH";
            dgvOrders.Columns["TenKH"].HeaderText = "Tên Khách hàng";
            dgvOrders.Columns["NgayDatHang"].HeaderText = "📅 Ngày Đặt";
            dgvOrders.Columns["TriGiaDH"].HeaderText = "💰 Trị giá ĐH";
            dgvOrders.Columns["TrangThaiDH"].HeaderText = "Trạng thái";
            dgvOrders.Columns["PhuongThucThanhToan"].HeaderText = "PTTT";

            // Định dạng tiền tệ
            dgvOrders.Columns["TriGiaDH"].DefaultCellStyle.Format = "N0";
            dgvOrders.Columns["TriGiaDH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Định dạng ngày
            dgvOrders.Columns["NgayDatHang"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Đặt độ rộng cột
            dgvOrders.Columns["MaDDH"].Width = 120;
            dgvOrders.Columns["NgayDatHang"].Width = 150;
            dgvOrders.Columns["TrangThaiDH"].Width = 120;
            dgvOrders.Columns["PhuongThucThanhToan"].Width = 100;

            // Thêm nút "Xem" nếu chưa có
            if (!dgvOrders.Columns.Contains("btnView"))
            {
                DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
                btnView.HeaderText = "⚡ Thao tác";
                btnView.Text = "👁️ Xem";
                btnView.Name = "btnView";
                btnView.UseColumnTextForButtonValue = true;
                btnView.Width = 100;
                dgvOrders.Columns.Add(btnView);
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
            LoadOrderData(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            LoadOrderData();
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        // 1. KÍCH HOẠT NÚT THÊM MỚI
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OrderAddEditForm addForm = new OrderAddEditForm(this.CONNECTION_STRING);
                addForm.StartPosition = FormStartPosition.CenterParent;

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOrderData();
                    ShowSuccess("Thêm mới Đơn hàng thành công!");
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khởi tạo Form Thêm mới", ex.Message);
            }
        }

        // 2. KÍCH HOẠT NÚT XEM CHI TIẾT
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            ShowSelectedRowDetails(); // Gọi ShowSelectedRowDetails với isEdit = false (mặc định)
        }

        // 3. KÍCH HOẠT NÚT CHỈNH SỬA
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowSelectedRowDetails(isEdit: true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedOrder();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvOrders.Columns.Contains("btnView") &&
                e.ColumnIndex == dgvOrders.Columns["btnView"].Index)
            {
                ShowSelectedRowDetails(); // Mở Form Xem chi tiết khi bấm nút Xem trong Grid
            }
        }

        // HÀM QUAN TRỌNG: MỞ FORM XEM/SỬA
        private void ShowSelectedRowDetails(bool isEdit = false)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvOrders.SelectedRows[0];
                string maDDH = row.Cells["MaDDH"].Value.ToString();

                try
                {
                    OrderAddEditForm orderForm = new OrderAddEditForm(this.CONNECTION_STRING, maDDH);
                    orderForm.StartPosition = FormStartPosition.CenterParent;

                    if (!isEdit)
                    {
                        // CHẾ ĐỘ XEM CHI TIẾT
                        orderForm.SetReadOnlyMode(true);
                        orderForm.ShowDialog();
                    }
                    else
                    {
                        // CHẾ ĐỘ CHỈNH SỬA
                        if (orderForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadOrderData();
                            ShowSuccess($"Cập nhật Đơn hàng {maDDH} thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ShowError("Lỗi khởi tạo Form", ex.Message);
                }
            }
            else
            {
                ShowWarning("Chưa chọn Đơn hàng", "Vui lòng chọn một đơn hàng trong danh sách.");
            }
        }

        private void DeleteSelectedOrder()
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvOrders.SelectedRows[0];
                string maDDH = row.Cells["MaDDH"].Value.ToString();
                string tenKH = row.Cells["TenKH"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"⚠️ XÓA ĐƠN HÀNG ⚠️\n\nMã ĐH: {maDDH}\nKhách hàng: {tenKH}\n\nBạn có chắc chắn muốn xóa?",
                    "⚠️ XÁC NHẬN XÓA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2
                );

                if (result == DialogResult.Yes)
                {
                    ExecuteDelete(maDDH);
                }
            }
            else
            {
                ShowWarning("Chưa chọn Đơn hàng", "Vui lòng chọn một đơn hàng để xóa.");
            }
        }

        private void ExecuteDelete(string maDDH)
        {
            // (Logic xóa đơn hàng bằng Transaction giữ nguyên)
            string deleteCTQuery = "DELETE FROM CT_DH WHERE MaDDH = @MaDDH";
            string deleteDDHQuery = "DELETE FROM DONDATHANG WHERE MaDDH = @MaDDH";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. Xóa chi tiết đơn hàng
                    using (SqlCommand command = new SqlCommand(deleteCTQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@MaDDH", maDDH);
                        command.ExecuteNonQuery();
                    }

                    // 2. Xóa đơn hàng chính
                    using (SqlCommand command = new SqlCommand(deleteDDHQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@MaDDH", maDDH);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            transaction.Commit();
                            ShowSuccess($"✅ Đã xóa thành công Đơn hàng: {maDDH}");
                            LoadOrderData();
                        }
                        else
                        {
                            transaction.Rollback();
                            ShowWarning("Không tìm thấy", "Không tìm thấy đơn hàng để xóa.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    ShowError("Lỗi xóa dữ liệu", ex.Message);
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