using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class CustomerAddEditForm : Form
    {
        private string MaKH; // Null nếu là chế độ thêm mới
        private string CONNECTION_STRING;
        private bool IsEditMode => !string.IsNullOrEmpty(MaKH);

        // Constructor cho chế độ Thêm mới
        public CustomerAddEditForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            SetupFormForAddMode();
        }

        // Constructor cho chế độ Chỉnh sửa
        public CustomerAddEditForm(string connectionString, string maKH)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaKH = maKH;
            SetupFormForEditMode();
        }

        private void CustomerAddEditForm_Load(object sender, EventArgs e)
        {
            LoadLoaiKHComboBox();
            if (IsEditMode)
            {
                LoadCustomerData(MaKH);
            }
        }

        // --- CẤU HÌNH GIAO DIỆN ---

        private void SetupFormForAddMode()
        {
            lblTitle.Text = "➕ THÊM MỚI KHÁCH HÀNG";

            // 1. Tự động sinh mã mới và hiển thị
            txtMaKH.Text = GenerateNewMaKH();

            // 2. Khóa ô này lại để người dùng không sửa tay gây lỗi dữ liệu
            txtMaKH.ReadOnly = true;

            txtCongNo.Text = "0";
            txtCongNo.ReadOnly = true; // Công nợ mặc định là 0 khi thêm mới
        }

        private void SetupFormForEditMode()
        {
            lblTitle.Text = $"✏️ CHỈNH SỬA KHÁCH HÀNG: {MaKH}";
            txtMaKH.ReadOnly = true; // KHÔNG được chỉnh sửa Mã KH (Khóa chính)
            txtCongNo.ReadOnly = true; // Công nợ thường không sửa trực tiếp ở đây mà qua nghiệp vụ khác
        }

        // --- HÀM SINH MÃ TỰ ĐỘNG ---
        private string GenerateNewMaKH()
        {
            string newMaKH = "KH001"; // Giá trị mặc định nếu DB chưa có gì
            // Lấy mã KH lớn nhất hiện tại (Sắp xếp theo độ dài rồi đến giá trị để KH10 > KH9)
            string query = "SELECT TOP 1 MaKH FROM KHACHHANG ORDER BY LEN(MaKH) DESC, MaKH DESC";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string lastMaKH = result.ToString(); // Ví dụ: KH020

                            // Logic: Bỏ 2 ký tự đầu "KH", lấy phần số, cộng 1, rồi ghép lại
                            if (lastMaKH.Length > 2)
                            {
                                string numberPart = lastMaKH.Substring(2);
                                if (int.TryParse(numberPart, out int currentNumber))
                                {
                                    // Format "D3" nghĩa là số sẽ luôn có ít nhất 3 chữ số (021)
                                    newMaKH = "KH" + (currentNumber + 1).ToString("D3");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi sinh mã tự động: " + ex.Message);
                }
            }
            return newMaKH;
        }

        // --- CÁC HÀM TẢI DỮ LIỆU ---

        private void LoadLoaiKHComboBox()
        {
            string query = "SELECT MaLoaiKH, TenLoaiKH FROM LOAIKHACHHANG ORDER BY TenLoaiKH";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtLoaiKH = new DataTable();
                    adapter.Fill(dtLoaiKH);

                    cmbLoaiKH.DataSource = dtLoaiKH;
                    cmbLoaiKH.DisplayMember = "TenLoaiKH"; // Hiển thị Tên
                    cmbLoaiKH.ValueMember = "MaLoaiKH";   // Lưu Mã
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi tải danh mục Loại Khách hàng: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCustomerData(string maKH)
        {
            string query = @"
                SELECT KH.*, LKH.MaLoaiKH AS CurrentMaLoaiKH
                FROM KHACHHANG KH
                LEFT JOIN LOAIKHACHHANG LKH ON KH.MaLoaiKH = LKH.MaLoaiKH
                WHERE KH.MaKH = @MaKH";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@MaKH", maKH);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtMaKH.Text = reader["MaKH"].ToString();
                        txtTenKH.Text = reader["TenKH"].ToString();
                        txtSDT.Text = reader["SDTKH"].ToString();
                        txtEmail.Text = reader["EmailKH"] == DBNull.Value ? "" : reader["EmailKH"].ToString();
                        txtDiaChi.Text = reader["DiaChiKH"] == DBNull.Value ? "" : reader["DiaChiKH"].ToString();
                        txtMST.Text = reader["MSTKH"] == DBNull.Value ? "" : reader["MSTKH"].ToString();
                        txtSTK.Text = reader["STKKH"] == DBNull.Value ? "" : reader["STKKH"].ToString();

                        double congNo = reader["CongNoKH"] != DBNull.Value ? Convert.ToDouble(reader["CongNoKH"]) : 0;
                        txtCongNo.Text = string.Format("{0:N0}", congNo);

                        txtGhiChu.Text = reader["GhiChuKH"] == DBNull.Value ? "" : reader["GhiChuKH"].ToString();

                        // Chọn đúng Loại KH trong ComboBox
                        if (reader["CurrentMaLoaiKH"] != DBNull.Value)
                        {
                            cmbLoaiKH.SelectedValue = reader["CurrentMaLoaiKH"].ToString();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi tải dữ liệu KH: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- XỬ LÝ LƯU DỮ LIỆU ---

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            // Lấy mã loại KH từ combobox
            string selectedLoaiKH = cmbLoaiKH.SelectedValue != null ? cmbLoaiKH.SelectedValue.ToString() : null;

            if (selectedLoaiKH == null)
            {
                MessageBox.Show("Vui lòng chọn Loại khách hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsEditMode)
            {
                ExecuteUpdate(selectedLoaiKH);
            }
            else
            {
                ExecuteInsert(selectedLoaiKH);
            }
        }

        private bool ValidateInputs()
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) ||
                string.IsNullOrWhiteSpace(txtTenKH.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                cmbLoaiKH.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường bắt buộc (*).", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra định dạng số điện thoại (10 chữ số)
            if (txtSDT.Text.Length != 10 || !long.TryParse(txtSDT.Text, out _))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số và chỉ chứa ký tự số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra định dạng email (nếu có nhập)
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ExecuteInsert(string maLoaiKH)
        {
            // Câu lệnh INSERT: Sử dụng tham số @STK để khớp với code AddCommonParameters bên dưới
            string query = @"
                INSERT INTO KHACHHANG (MaKH, TenKH, SDTKH, EmailKH, DiaChiKH, MaLoaiKH, MSTKH, STKKH, CongNoKH, GhiChuKH)
                VALUES (@MaKH, @TenKH, @SDTKH, @EmailKH, @DiaChiKH, @MaLoaiKH, @MSTKH, @STK, 0, @GhiChu)";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                AddCommonParameters(command, maLoaiKH);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đóng Form và báo hiệu thành công
                }
                catch (SqlException ex)
                {
                    // Lỗi trùng Mã KH (Primary Key Violation)
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show($"Mã Khách hàng {txtMaKH.Text} đã tồn tại. Hệ thống sẽ tự động thử lại mã khác.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Tùy chọn: Có thể gọi lại GenerateNewMaKH() ở đây nếu muốn thử lại ngay
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExecuteUpdate(string maLoaiKH)
        {
            string query = @"
                UPDATE KHACHHANG SET 
                    TenKH = @TenKH,
                    SDTKH = @SDTKH,
                    EmailKH = @EmailKH,
                    DiaChiKH = @DiaChiKH,
                    MaLoaiKH = @MaLoaiKH,
                    MSTKH = @MSTKH,
                    STKKH = @STK,
                    GhiChuKH = @GhiChu
                WHERE MaKH = @MaKH";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                AddCommonParameters(command, maLoaiKH);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đóng Form và báo hiệu thành công
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddCommonParameters(SqlCommand command, string maLoaiKH)
        {
            command.Parameters.AddWithValue("@MaKH", txtMaKH.Text.Trim());
            command.Parameters.AddWithValue("@TenKH", txtTenKH.Text.Trim());
            command.Parameters.AddWithValue("@SDTKH", txtSDT.Text.Trim());

            // Xử lý giá trị có thể NULL
            command.Parameters.AddWithValue("@EmailKH", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
            command.Parameters.AddWithValue("@DiaChiKH", string.IsNullOrWhiteSpace(txtDiaChi.Text) ? (object)DBNull.Value : txtDiaChi.Text.Trim());

            command.Parameters.AddWithValue("@MaLoaiKH", maLoaiKH); // Đã kiểm tra null ở btnSave

            command.Parameters.AddWithValue("@MSTKH", string.IsNullOrWhiteSpace(txtMST.Text) ? (object)DBNull.Value : txtMST.Text.Trim());

            // Tham số @STK dùng cho cột STKKH
            command.Parameters.AddWithValue("@STK", string.IsNullOrWhiteSpace(txtSTK.Text) ? (object)DBNull.Value : txtSTK.Text.Trim());

            command.Parameters.AddWithValue("@GhiChu", string.IsNullOrWhiteSpace(txtGhiChu.Text) ? (object)DBNull.Value : txtGhiChu.Text.Trim());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}