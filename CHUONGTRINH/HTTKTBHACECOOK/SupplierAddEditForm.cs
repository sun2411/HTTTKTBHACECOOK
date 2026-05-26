using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class SupplierAddEditForm : Form
    {
        private string MaNCC;
        private string CONNECTION_STRING;
        private bool IsEditMode => !string.IsNullOrEmpty(MaNCC);
        private bool IsReadOnlyMode = false;

        // Constructor 1: Thêm mới
        public SupplierAddEditForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            SetupFormForAddMode();
        }

        // Constructor 2: Chỉnh sửa
        public SupplierAddEditForm(string connectionString, string maNCC)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaNCC = maNCC;
            SetupFormForEditMode();
        }

        // Constructor 3: Xem (Read-only)
        public SupplierAddEditForm(string connectionString, string maNCC, bool isReadOnly)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaNCC = maNCC;
            this.IsReadOnlyMode = isReadOnly;
            SetupFormForViewMode();
        }

        private void SupplierAddEditForm_Load(object sender, EventArgs e)
        {
            SetupButtonHoverEffects();

            if (IsEditMode || IsReadOnlyMode)
            {
                LoadSupplierData(MaNCC);
            }
        }

        private void SetupButtonHoverEffects()
        {
            if (!IsReadOnlyMode)
            {
                btnSave.MouseEnter += (s, e) => btnSave.BackColor = IsEditMode ?
                    ColorTranslator.FromHtml("#FFCA2C") : ColorTranslator.FromHtml("#0B5ED7");
                btnSave.MouseLeave += (s, e) => btnSave.BackColor = IsEditMode ?
                    ColorTranslator.FromHtml("#FFC107") : ColorTranslator.FromHtml("#0D6EFD");
            }

            btnClose.MouseEnter += (s, e) => btnClose.BackColor = ColorTranslator.FromHtml("#5A6268");
            btnClose.MouseLeave += (s, e) => btnClose.BackColor = ColorTranslator.FromHtml("#6C757D");
        }

        // --- SETUP MODES ---

        private void SetupFormForAddMode()
        {
            lblTitle.Text = "➕  THÊM NHÀ CUNG CẤP MỚI";
            pnlHeader.BackColor = ColorTranslator.FromHtml("#0D6EFD"); // Blue

            // --- SỬA ĐỔI: TỰ ĐỘNG SINH MÃ ---
            txtMaNCC.Text = GenerateNewMaNCC();
            txtMaNCC.ReadOnly = true; // Khóa lại không cho sửa
            // -------------------------------

            btnSave.Text = "➕  Thêm mới";
            btnSave.BackColor = ColorTranslator.FromHtml("#0D6EFD");
        }

        private void SetupFormForEditMode()
        {
            lblTitle.Text = "✏️  CHỈNH SỬA NHÀ CUNG CẤP";
            pnlHeader.BackColor = ColorTranslator.FromHtml("#FFC107"); // Yellow
            txtMaNCC.ReadOnly = true;
            txtMaNCC.BackColor = ColorTranslator.FromHtml("#F8F9FA");
            btnSave.Text = "💾  Cập nhật";
            btnSave.BackColor = ColorTranslator.FromHtml("#FFC107");
            btnSave.ForeColor = ColorTranslator.FromHtml("#212529");
        }

        private void SetupFormForViewMode()
        {
            lblTitle.Text = "👁️  CHI TIẾT NHÀ CUNG CẤP";
            pnlHeader.BackColor = ColorTranslator.FromHtml("#198754"); // Green

            // Lock all fields
            txtMaNCC.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtEmail.ReadOnly = true;

            // Change background color
            Color readOnlyColor = ColorTranslator.FromHtml("#F8F9FA");
            txtMaNCC.BackColor = readOnlyColor;
            txtTenNCC.BackColor = readOnlyColor;
            txtDiaChi.BackColor = readOnlyColor;
            txtDienThoai.BackColor = readOnlyColor;
            txtEmail.BackColor = readOnlyColor;

            // Hide Save button
            btnSave.Visible = false;
            // Chỉnh sửa vị trí và text của nút Đóng
            btnClose.Text = "✔️  Đóng";
            btnClose.Location = new Point(366, 15);
            btnClose.Size = new Size(260, 50);
        }

        // --- HÀM SINH MÃ TỰ ĐỘNG (MỚI THÊM) ---
        private string GenerateNewMaNCC()
        {
            string newCode = "NCC001"; // Mặc định
            string query = "SELECT TOP 1 MaNCC FROM NHACUNGCAP ORDER BY LEN(MaNCC) DESC, MaNCC DESC";

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
                            string lastCode = result.ToString(); // Ví dụ: NCC020

                            // Cắt bỏ "NCC" (3 ký tự đầu) để lấy số
                            if (lastCode.Length > 3)
                            {
                                string numberPart = lastCode.Substring(3);
                                if (int.TryParse(numberPart, out int currentNumber))
                                {
                                    // Tăng 1 và format lại thành 3 chữ số (021)
                                    newCode = "NCC" + (currentNumber + 1).ToString("D3");
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
            return newCode;
        }

        // --- DATA OPERATIONS ---

        private void LoadSupplierData(string maNCC)
        {
            string query = @"
                SELECT MaNCC, TenNCC, DiaChiNCC, SDTNCC, EmailNCC 
                FROM NHACUNGCAP 
                WHERE MaNCC = @MaNCC";

            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaNCC", maNCC);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtMaNCC.Text = reader["MaNCC"].ToString().Trim();
                                txtTenNCC.Text = reader["TenNCC"].ToString().Trim();
                                txtDiaChi.Text = reader["DiaChiNCC"]?.ToString().Trim() ?? "";
                                txtDienThoai.Text = reader["SDTNCC"]?.ToString().Trim() ?? "";
                                txtEmail.Text = reader["EmailNCC"]?.ToString().Trim() ?? "";
                            }
                            else
                            {
                                ShowError("Lỗi dữ liệu", "Không tìm thấy nhà cung cấp này.");
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi tải dữ liệu", ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsReadOnlyMode) return;

            if (!ValidateInput()) return;

            if (IsEditMode)
            {
                ExecuteUpdateSupplier();
            }
            else
            {
                ExecuteInsertSupplier();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaNCC.Text))
            {
                ShowWarning("Thiếu thông tin", "Mã nhà cung cấp không được để trống.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                ShowWarning("Thiếu thông tin", "Tên nhà cung cấp không được để trống.");
                txtTenNCC.Focus();
                return false;
            }

            // Validate email format
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
            {
                ShowWarning("Email không hợp lệ", "Vui lòng nhập đúng định dạng email.\nVí dụ: example@email.com");
                txtEmail.Focus();
                return false;
            }

            // Validate phone format
            if (!string.IsNullOrWhiteSpace(txtDienThoai.Text) && !IsValidPhoneNumber(txtDienThoai.Text))
            {
                ShowWarning("Số điện thoại không hợp lệ", "Vui lòng nhập đúng định dạng số điện thoại.\nVí dụ: 0901234567");
                txtDienThoai.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phone)
        {
            string cleanPhone = phone.Replace(" ", "").Replace("-", "");
            return cleanPhone.Length >= 10 && cleanPhone.Length <= 11 &&
                   cleanPhone.All(char.IsDigit) && cleanPhone.StartsWith("0");
        }

        private void ExecuteInsertSupplier()
        {
            string insertQuery = @"
                INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChiNCC, SDTNCC, EmailNCC)
                VALUES (@MaNCC, @TenNCC, @DiaChiNCC, @SDTNCC, @EmailNCC)";

            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaNCC", txtMaNCC.Text.Trim());
                        command.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text.Trim());
                        command.Parameters.AddWithValue("@DiaChiNCC",
                            string.IsNullOrEmpty(txtDiaChi.Text) ? (object)DBNull.Value : txtDiaChi.Text.Trim());
                        command.Parameters.AddWithValue("@SDTNCC",
                            string.IsNullOrEmpty(txtDienThoai.Text) ? (object)DBNull.Value : txtDienThoai.Text.Trim());
                        command.Parameters.AddWithValue("@EmailNCC",
                            string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());

                        command.ExecuteNonQuery();

                        ShowSuccess($"✅ Thêm thành công nhà cung cấp:\n{txtTenNCC.Text} ({txtMaNCC.Text})");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Duplicate primary key
                {
                    ShowError("Mã trùng lặp",
                        $"Mã nhà cung cấp '{txtMaNCC.Text}' đã tồn tại.\nHệ thống sẽ thử lại mã khác.");
                    // Có thể gọi lại GenerateNewMaNCC() nếu muốn thử lại ngay
                }
                else
                {
                    ShowError("Lỗi SQL", ex.Message);
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi hệ thống", ex.Message);
            }
        }

        private void ExecuteUpdateSupplier()
        {
            string updateQuery = @"
                UPDATE NHACUNGCAP 
                SET TenNCC = @TenNCC, 
                    DiaChiNCC = @DiaChiNCC, 
                    SDTNCC = @SDTNCC, 
                    EmailNCC = @EmailNCC
                WHERE MaNCC = @MaNCC";

            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaNCC", this.MaNCC);
                        command.Parameters.AddWithValue("@TenNCC", txtTenNCC.Text.Trim());
                        command.Parameters.AddWithValue("@DiaChiNCC",
                            string.IsNullOrEmpty(txtDiaChi.Text) ? (object)DBNull.Value : txtDiaChi.Text.Trim());
                        command.Parameters.AddWithValue("@SDTNCC",
                            string.IsNullOrEmpty(txtDienThoai.Text) ? (object)DBNull.Value : txtDienThoai.Text.Trim());
                        command.Parameters.AddWithValue("@EmailNCC",
                            string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());

                        command.ExecuteNonQuery();

                        ShowSuccess($"✅ Cập nhật thành công nhà cung cấp:\n{txtTenNCC.Text} ({this.MaNCC})");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi cập nhật", ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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