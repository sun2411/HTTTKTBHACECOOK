using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class OrderAddEditForm : Form
    {
        private string MaDDH;
        private string CONNECTION_STRING;
        private bool IsEditMode => !string.IsNullOrEmpty(MaDDH);

        // Biến kiểm soát chế độ xem chi tiết (Read-only)
        private bool IsReadOnlyMode = false;

        // Biến lưu danh sách sản phẩm dùng chung cho cả 2 cột ComboBox (Cache)
        private DataTable dtProductList;

        // Cờ hiệu để tránh vòng lặp vô tận khi 2 cột ComboBox cập nhật lẫn nhau
        private bool isSystemUpdating = false;

        // Biến lưu tổng tiền gốc từ DB để tính ngược phụ phí khi sửa
        private decimal OrderGrandTotalFromDB = 0;

        // Constructor Thêm mới
        public OrderAddEditForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            SetupFormForAddMode();
        }

        // Constructor Chỉnh sửa
        public OrderAddEditForm(string connectionString, string maDDH)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaDDH = maDDH;
            SetupFormForEditMode();
        }

        private void OrderAddEditForm_Load(object sender, EventArgs e)
        {
            // 1. Tải danh sách sản phẩm vào bộ nhớ đệm
            LoadProductListCache();

            // 2. Load dữ liệu cho các ComboBox (Khách hàng, Trạng thái)
            LoadComboBoxes();

            // 3. Cấu hình Grid (Cả Mã và Tên đều xổ xuống)
            SetupOrderDetailsGrid();

            if (IsEditMode)
            {
                LoadOrderData(MaDDH);
                LoadOrderDetails(MaDDH);
            }
            else
            {
                // Tự động sinh mã đơn hàng mới nếu là thêm mới
                txtMaDDH.Text = GenerateNewMaDDH();
            }

            // Đăng ký các sự kiện tính toán và đồng bộ
            dgvOrderDetails.CellValueChanged += dgvOrderDetails_CellValueChanged;
            dgvOrderDetails.CurrentCellDirtyStateChanged += dgvOrderDetails_CurrentCellDirtyStateChanged;
            dgvOrderDetails.RowsRemoved += (s, ev) => CalculateTotalAmount();

            txtPhuPhi.TextChanged += txtPhuPhi_TextChanged;
            txtPhuPhi.Leave += txtPhuPhi_Leave;

            // Khắc phục lỗi hiển thị Designer (nếu có)
            this.pnlHeaderInfo.ResumeLayout(false);
        }

        // --- 1. LOAD DỮ LIỆU & CACHE ---

        private void LoadProductListCache()
        {
            // Lấy MaSP, TenSP, GiaBanSP để nạp vào ComboBox
            string query = "SELECT MaSP, TenSP, GiaBanSP FROM SANPHAM ORDER BY TenSP";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    dtProductList = new DataTable();
                    adapter.Fill(dtProductList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
                }
            }
        }

        private void LoadComboBoxes()
        {
            LoadDataToComboBox(cmbKhachHang, "SELECT MaKH, TenKH FROM KHACHHANG ORDER BY TenKH", "TenKH", "MaKH");

            DataTable dtTrangThai = new DataTable();
            dtTrangThai.Columns.Add("Ma", typeof(string));
            dtTrangThai.Columns.Add("Ten", typeof(string));
            dtTrangThai.Rows.Add("DANG_XL", "Đang xử lý");
            dtTrangThai.Rows.Add("DANG_GIAO", "Đang giao");
            dtTrangThai.Rows.Add("DA_GIAO", "Đã giao");
            dtTrangThai.Rows.Add("DA_HUY", "Đã hủy");

            cmbTrangThai.DataSource = dtTrangThai;
            cmbTrangThai.DisplayMember = "Ten";
            cmbTrangThai.ValueMember = "Ma";

            // Mặc định chọn "Đang xử lý" nếu thêm mới
            if (!IsEditMode) cmbTrangThai.SelectedValue = "DANG_XL";
        }

        private void LoadDataToComboBox(ComboBox cmb, string query, string displayMember, string valueMember)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmb.DataSource = dt;
                    cmb.DisplayMember = displayMember;
                    cmb.ValueMember = valueMember;
                }
                catch { }
            }
        }

        // --- 2. CẤU HÌNH GRID VỚI 2 COMBOBOX ---

        private void SetupOrderDetailsGrid()
        {
            dgvOrderDetails.Columns.Clear();
            dgvOrderDetails.AutoGenerateColumns = false;

            // Cột 1: Mã SP (ComboBox)
            DataGridViewComboBoxColumn colMaSP = new DataGridViewComboBoxColumn();
            colMaSP.Name = "MaSP";
            colMaSP.HeaderText = "Mã SP";
            colMaSP.DataPropertyName = "MaSP";
            colMaSP.DataSource = dtProductList;
            colMaSP.DisplayMember = "MaSP";     // Hiển thị Mã
            colMaSP.ValueMember = "MaSP";       // Giá trị là Mã
            colMaSP.Width = 100;
            colMaSP.AutoComplete = true;
            colMaSP.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colMaSP.ReadOnly = IsReadOnlyMode;
            dgvOrderDetails.Columns.Add(colMaSP);

            // Cột 2: Tên SP (ComboBox)
            DataGridViewComboBoxColumn colTenSP = new DataGridViewComboBoxColumn();
            colTenSP.Name = "TenSP";
            colTenSP.HeaderText = "Tên Sản phẩm";
            // Không gán DataPropertyName trực tiếp để xử lý đồng bộ thủ công an toàn hơn
            colTenSP.DataSource = dtProductList;
            colTenSP.DisplayMember = "TenSP";   // Hiển thị Tên
            colTenSP.ValueMember = "MaSP";      // Giá trị ngầm vẫn là Mã SP (để đồng bộ)
            colTenSP.Width = 250;
            colTenSP.AutoComplete = true;
            colTenSP.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colTenSP.ReadOnly = IsReadOnlyMode;
            dgvOrderDetails.Columns.Add(colTenSP);

            // Các cột khác
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn() { Name = "SoLuongDDH", HeaderText = "Số lượng", DataPropertyName = "SoLuongDDH", DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" } });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn() { Name = "DonGiaDDH", HeaderText = "Đơn giá", ReadOnly = true, DataPropertyName = "DonGiaDDH", DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" } });
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn() { Name = "ThanhTien", HeaderText = "Thành tiền", ReadOnly = true, DataPropertyName = "ThanhTien", DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" } });

            dgvOrderDetails.AllowUserToAddRows = !IsReadOnlyMode;
        }

        // --- 3. XỬ LÝ ĐỒNG BỘ 2 COMBOBOX VÀ TÍNH TIỀN ---

        private void dgvOrderDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvOrderDetails.IsCurrentCellDirty)
            {
                // Commit ngay lập tức để lấy giá trị mới nhất
                dgvOrderDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvOrderDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || isSystemUpdating) return;

            string colName = dgvOrderDetails.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = dgvOrderDetails.Rows[e.RowIndex];

            // LOGIC ĐỒNG BỘ 2 COMBOBOX (CHỌN MÃ -> TỰ NHẢY TÊN VÀ NGƯỢC LẠI)
            if (colName == "MaSP" || colName == "TenSP")
            {
                object selectedValue = row.Cells[colName].Value;

                if (selectedValue != null)
                {
                    string selectedMaSP = selectedValue.ToString();

                    isSystemUpdating = true; // Khóa sự kiện để tránh vòng lặp

                    try
                    {
                        // 1. Đồng bộ ô còn lại
                        if (colName == "MaSP") row.Cells["TenSP"].Value = selectedMaSP;
                        if (colName == "TenSP") row.Cells["MaSP"].Value = selectedMaSP;

                        // 2. Lấy đơn giá từ Cache
                        DataRow[] foundRows = dtProductList.Select($"MaSP = '{selectedMaSP}'");
                        if (foundRows.Length > 0)
                        {
                            row.Cells["DonGiaDDH"].Value = foundRows[0]["GiaBanSP"];
                        }

                        // 3. Mặc định số lượng là 1 nếu chưa có
                        if (row.Cells["SoLuongDDH"].Value == null || row.Cells["SoLuongDDH"].Value.ToString() == "" || row.Cells["SoLuongDDH"].Value.ToString() == "0")
                        {
                            row.Cells["SoLuongDDH"].Value = 1;
                        }
                    }
                    finally
                    {
                        isSystemUpdating = false; // Mở khóa
                    }

                    // 4. Tính thành tiền
                    CalculateRowAmount(row);
                }
            }

            // KHI THAY ĐỔI SỐ LƯỢNG
            if (colName == "SoLuongDDH")
            {
                CalculateRowAmount(row);
            }
        }

        private void CalculateRowAmount(DataGridViewRow row)
        {
            if (row.Cells["SoLuongDDH"].Value != null && row.Cells["DonGiaDDH"].Value != null)
            {
                if (decimal.TryParse(row.Cells["SoLuongDDH"].Value.ToString(), out decimal sl) &&
                    decimal.TryParse(row.Cells["DonGiaDDH"].Value.ToString(), out decimal dg))
                {
                    row.Cells["ThanhTien"].Value = sl * dg;
                }
                else
                {
                    row.Cells["ThanhTien"].Value = 0;
                }
                CalculateTotalAmount();
            }
        }

        // --- 4. CÁC HÀM HỖ TRỢ KHÁC ---

        private string GenerateNewMaDDH()
        {
            string newCode = "DDH001";
            string query = "SELECT TOP 1 MaDDH FROM DONDATHANG ORDER BY LEN(MaDDH) DESC, MaDDH DESC";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    object result = new SqlCommand(query, conn).ExecuteScalar();
                    if (result != null)
                    {
                        string lastCode = result.ToString();
                        if (lastCode.Length > 3)
                        {
                            string numPart = lastCode.Substring(3);
                            if (int.TryParse(numPart, out int num))
                            {
                                newCode = "DDH" + (num + 1).ToString("D3");
                            }
                        }
                    }
                }
                catch { }
            }
            return newCode;
        }

        private void CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["ThanhTien"].Value != null &&
                    decimal.TryParse(row.Cells["ThanhTien"].Value.ToString(), out decimal val))
                {
                    total += val;
                }
            }

            string cleanPhuPhi = txtPhuPhi.Text.Replace(".", "").Replace(",", "");
            if (decimal.TryParse(cleanPhuPhi, out decimal phuPhi))
            {
                total += phuPhi;
            }

            lblTongTriGia.Text = total.ToString("N0");
        }

        private void txtPhuPhi_TextChanged(object sender, EventArgs e) => CalculateTotalAmount();

        private void txtPhuPhi_Leave(object sender, EventArgs e)
        {
            string cleanText = txtPhuPhi.Text.Replace(".", "").Replace(",", "");
            if (decimal.TryParse(cleanText, out decimal value))
                txtPhuPhi.Text = value.ToString("N0");
            else
                txtPhuPhi.Text = "0";
        }

        private void LoadOrderData(string maDDH)
        {
            string query = "SELECT * FROM DONDATHANG WHERE MaDDH = @MaDDH";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaDDH", maDDH);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        cmbKhachHang.SelectedValue = reader["MaKH"].ToString();
                        dtpNgayDat.Value = Convert.ToDateTime(reader["NgayDatHang"]);
                        if (reader["NgayGiaoHang"] != DBNull.Value) dtpNgayGiao.Value = Convert.ToDateTime(reader["NgayGiaoHang"]);
                        cmbTrangThai.SelectedValue = ConvertStatusToCode(reader["TrangThaiDH"].ToString());
                        txtGhiChu.Text = reader["GhiChuDH"].ToString();
                        OrderGrandTotalFromDB = Convert.ToDecimal(reader["TriGiaDH"]);
                    }
                }
            }
        }

        private void LoadOrderDetails(string maDDH)
        {
            string query = "SELECT MaSP, SoLuongDDH, DonGiaDDH, (SoLuongDDH * DonGiaDDH) AS ThanhTien FROM CT_DH WHERE MaDDH = @MaDDH";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaDDH", maDDH);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Gán dữ liệu vào Grid
                dgvOrderDetails.DataSource = dt;

                // Đồng bộ cột TenSP (điền giá trị MaSP vào để nó tự map)
                foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                {
                    if (row.Cells["MaSP"].Value != null)
                    {
                        row.Cells["TenSP"].Value = row.Cells["MaSP"].Value;
                    }
                }

                CalculateTotalAmountAndSetExtraFee(dt);
            }
        }

        private void CalculateTotalAmountAndSetExtraFee(DataTable dtDetails)
        {
            decimal totalProduct = 0;
            foreach (DataRow row in dtDetails.Rows)
            {
                totalProduct += Convert.ToDecimal(row["ThanhTien"]);
            }
            decimal extraFee = OrderGrandTotalFromDB - totalProduct;
            txtPhuPhi.Text = extraFee.ToString("N0");
            lblTongTriGia.Text = OrderGrandTotalFromDB.ToString("N0");
        }

        private string ConvertStatusToCode(string statusName)
        {
            if (statusName.Contains("Đang xử lý")) return "DANG_XL";
            if (statusName.Contains("Đang giao")) return "DANG_GIAO";
            if (statusName.Contains("Đã hủy")) return "DA_HUY";
            if (statusName.Contains("Đã giao")) return "DA_GIAO";
            return "DANG_XL";
        }

        // --- 5. LOGIC LƯU DỮ LIỆU ---

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateOrder()) return;

            if (IsEditMode) ExecuteUpdateOrder();
            else ExecuteInsertOrder();
        }

        private bool ValidateOrder()
        {
            if (cmbKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng.", "Cảnh báo");
                return false;
            }

            bool hasDetails = false;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (!row.IsNewRow && row.Cells["MaSP"].Value != null)
                {
                    hasDetails = true;
                    break;
                }
            }

            if (!hasDetails)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một sản phẩm.", "Cảnh báo");
                return false;
            }
            return true;
        }

        private void ExecuteInsertOrder()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryDDH = @"
                        INSERT INTO DONDATHANG (MaDDH, MaKH, NgayDatHang, NgayGiaoHang, TrangThaiDH, GhiChuDH, TriGiaDH)
                        VALUES (@MaDDH, @MaKH, @NgayDat, @NgayGiao, @TrangThai, @GhiChu, @TriGia)";

                    decimal tongTriGia = decimal.Parse(lblTongTriGia.Text.Replace(".", "").Replace(",", ""));

                    using (SqlCommand cmd = new SqlCommand(queryDDH, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaDDH", txtMaDDH.Text);
                        cmd.Parameters.AddWithValue("@MaKH", cmbKhachHang.SelectedValue);
                        cmd.Parameters.AddWithValue("@NgayDat", dtpNgayDat.Value);
                        cmd.Parameters.AddWithValue("@NgayGiao", dtpNgayGiao.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", cmbTrangThai.Text); // Lưu Text hiển thị (Đang xử lý...) hoặc dùng Code tùy logic DB
                        cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                        cmd.Parameters.AddWithValue("@TriGia", tongTriGia);
                        cmd.ExecuteNonQuery();
                    }

                    string queryCT = "INSERT INTO CT_DH (MaDDH, MaSP, SoLuongDDH, DonGiaDDH) VALUES (@MaDDH, @MaSP, @SoLuong, @DonGia)";

                    foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                    {
                        if (row.IsNewRow || row.Cells["MaSP"].Value == null) continue;

                        using (SqlCommand cmd = new SqlCommand(queryCT, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaDDH", txtMaDDH.Text);
                            cmd.Parameters.AddWithValue("@MaSP", row.Cells["MaSP"].Value);
                            cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row.Cells["SoLuongDDH"].Value));
                            cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(row.Cells["DonGiaDDH"].Value));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Thêm đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.Message, "Lỗi");
                }
            }
        }

        private void ExecuteUpdateOrder()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    decimal tongTriGia = decimal.Parse(lblTongTriGia.Text.Replace(".", "").Replace(",", ""));

                    string queryUpdate = @"
                        UPDATE DONDATHANG SET 
                            MaKH = @MaKH, NgayDatHang = @NgayDat, NgayGiaoHang = @NgayGiao, 
                            TrangThaiDH = @TrangThai, GhiChuDH = @GhiChu, TriGiaDH = @TriGia
                        WHERE MaDDH = @MaDDH";

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@MaDDH", MaDDH);
                        cmd.Parameters.AddWithValue("@MaKH", cmbKhachHang.SelectedValue);
                        cmd.Parameters.AddWithValue("@NgayDat", dtpNgayDat.Value);
                        cmd.Parameters.AddWithValue("@NgayGiao", dtpNgayGiao.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", cmbTrangThai.Text); // Lưu text
                        cmd.Parameters.AddWithValue("@GhiChu", txtGhiChu.Text);
                        cmd.Parameters.AddWithValue("@TriGia", tongTriGia);
                        cmd.ExecuteNonQuery();
                    }

                    new SqlCommand($"DELETE FROM CT_DH WHERE MaDDH = '{MaDDH}'", conn, transaction).ExecuteNonQuery();

                    string queryCT = "INSERT INTO CT_DH (MaDDH, MaSP, SoLuongDDH, DonGiaDDH) VALUES (@MaDDH, @MaSP, @SoLuong, @DonGia)";
                    foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                    {
                        if (row.IsNewRow || row.Cells["MaSP"].Value == null) continue;

                        using (SqlCommand cmd = new SqlCommand(queryCT, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@MaDDH", MaDDH);
                            cmd.Parameters.AddWithValue("@MaSP", row.Cells["MaSP"].Value);
                            cmd.Parameters.AddWithValue("@SoLuong", Convert.ToInt32(row.Cells["SoLuongDDH"].Value));
                            cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(row.Cells["DonGiaDDH"].Value));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Cập nhật đơn hàng thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }

        // --- 6. SETUP MODES ---

        private void SetupFormForAddMode()
        {
            lblTitle.Text = "➕ LẬP ĐƠN ĐẶT HÀNG MỚI";
            txtMaDDH.ReadOnly = true;
            cmbTrangThai.Enabled = true; // --- ĐÃ SỬA: CHO PHÉP CHỌN ---
        }

        private void SetupFormForEditMode()
        {
            lblTitle.Text = $"✏️ CHỈNH SỬA ĐƠN HÀNG: {MaDDH}";
            txtMaDDH.Text = MaDDH;
            txtMaDDH.ReadOnly = true;
            cmbTrangThai.Enabled = true;
        }

        public void SetReadOnlyMode(bool isReadOnly)
        {
            if (isReadOnly && IsEditMode) lblTitle.Text = $"👁️ CHI TIẾT ĐƠN HÀNG: {MaDDH}";
            this.IsReadOnlyMode = isReadOnly;

            cmbKhachHang.Enabled = !isReadOnly;
            dtpNgayDat.Enabled = !isReadOnly;
            cmbTrangThai.Enabled = !isReadOnly;
            dtpNgayGiao.Enabled = !isReadOnly;
            txtGhiChu.ReadOnly = isReadOnly;
            txtPhuPhi.ReadOnly = isReadOnly;

            dgvOrderDetails.ReadOnly = isReadOnly;
            dgvOrderDetails.AllowUserToAddRows = !isReadOnly;

            btnSave.Visible = !isReadOnly;
            btnClose.Text = isReadOnly ? "Đóng" : "Hủy";
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}