using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class MaterialAddEditForm : Form
    {
        private string MaNL;
        private readonly string CONNECTION_STRING;
        private bool IsEditMode => !string.IsNullOrEmpty(MaNL);
        private bool IsReadOnlyMode = false;
        private bool readOnlyModeRequested = false;

        public MaterialAddEditForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            SetupFormForAddMode();
        }

        public MaterialAddEditForm(string connectionString, string maNL)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaNL = maNL;
            SetupFormForEditMode();
        }

        private void MaterialAddEditForm_Load(object sender, EventArgs e)
        {
            LoadDVTComboBox();

            // Format ô số lượng: Chỉ cho phép nhập số (0-9) và phím điều khiển (Backspace...)
            // Chặn dấu chấm (.) để đảm bảo nhập số nguyên
            txtSoLuong.KeyPress += (s, ev) =>
            {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };

            if (IsEditMode || IsReadOnlyMode)
            {
                LoadMaterialData(MaNL);
            }
            else
            {
                txtMaNL.Text = GenerateNewMaNL();
                txtSoLuong.Text = "0"; // Mặc định là 0
            }

            if (readOnlyModeRequested) ApplyReadOnlyMode(true);
        }

        private string GenerateNewMaNL()
        {
            string newCode = "NL001";
            string query = "SELECT TOP 1 MaNL FROM NGUYENLIEU ORDER BY LEN(MaNL) DESC, MaNL DESC";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    object result = new SqlCommand(query, conn).ExecuteScalar();
                    if (result != null)
                    {
                        string lastCode = result.ToString();
                        if (lastCode.Length > 2)
                        {
                            string numPart = lastCode.Substring(2);
                            if (int.TryParse(numPart, out int num))
                            {
                                newCode = "NL" + (num + 1).ToString("D3");
                            }
                        }
                    }
                }
                catch { }
            }
            return newCode;
        }

        private void SetupFormForAddMode()
        {
            lblTitle.Text = "➕ THÊM MỚI NGUYÊN VẬT LIỆU";
            txtMaNL.ReadOnly = true;
        }

        private void SetupFormForEditMode()
        {
            lblTitle.Text = $"✏️ CHỈNH SỬA NGUYÊN VẬT LIỆU: {MaNL}";
            txtMaNL.ReadOnly = true;
        }

        public void SetReadOnlyMode(bool isReadOnly)
        {
            this.readOnlyModeRequested = isReadOnly;
            this.IsReadOnlyMode = isReadOnly;
        }

        private void ApplyReadOnlyMode(bool isReadOnly)
        {
            if (isReadOnly) lblTitle.Text = $"👁️ CHI TIẾT NGUYÊN VẬT LIỆU: {MaNL}";
            txtMaNL.ReadOnly = true;
            txtTenNL.ReadOnly = isReadOnly;
            txtSoLuong.ReadOnly = isReadOnly; // Khóa ô số lượng
            cmbDVT.Enabled = !isReadOnly;
            btnSave.Visible = !isReadOnly;
            btnClose.Text = isReadOnly ? "Đóng" : "Hủy";
        }

        private void LoadDVTComboBox()
        {
            DataTable dtDVT = new DataTable();
            dtDVT.Columns.Add("DVT", typeof(string));
            dtDVT.Rows.Add("Lít");
            dtDVT.Rows.Add("Thùng");
            dtDVT.Rows.Add("Kg");
            dtDVT.Rows.Add("Gam");
            cmbDVT.DataSource = dtDVT;
            cmbDVT.DisplayMember = "DVT";
            cmbDVT.ValueMember = "DVT";
        }

        private void LoadMaterialData(string maNL)
        {
            // Lấy dữ liệu từ DB lên form sửa
            string query = "SELECT MaNL, TenNL, DVTNL, SoLuongTon FROM NGUYENLIEU WHERE MaNL = @MaNL";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaNL", maNL);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtMaNL.Text = reader["MaNL"].ToString();
                        txtTenNL.Text = reader["TenNL"].ToString();
                        cmbDVT.SelectedValue = reader["DVTNL"].ToString();

                        // SỬA QUAN TRỌNG: Định dạng N0 để bỏ số lẻ .00 (Ví dụ: 5,000)
                        if (reader["SoLuongTon"] != DBNull.Value)
                            txtSoLuong.Text = string.Format("{0:N0}", reader["SoLuongTon"]);
                        else
                            txtSoLuong.Text = "0";
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            string selectedDVT = cmbDVT.SelectedValue.ToString();

            if (IsEditMode) ExecuteUpdateMaterial(selectedDVT);
            else ExecuteInsertMaterial(selectedDVT);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaNL.Text) || string.IsNullOrWhiteSpace(txtTenNL.Text) || cmbDVT.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo");
                return false;
            }

            // Validate số lượng (chấp nhận định dạng có dấu phẩy phân cách hàng nghìn)
            if (!decimal.TryParse(txtSoLuong.Text, out _))
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Cảnh báo");
                return false;
            }

            return true;
        }

        private void ExecuteInsertMaterial(string dvt)
        {
            // Thêm mới bao gồm cả SoLuongTon
            string query = "INSERT INTO NGUYENLIEU (MaNL, TenNL, DVTNL, SoLuongTon) VALUES (@MaNL, @TenNL, @DVTNL, @SoLuong)";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                AddCommonParameters(cmd, dvt);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (SqlException ex) { MessageBox.Show("Lỗi SQL: " + ex.Message); }
            }
        }

        private void ExecuteUpdateMaterial(string dvt)
        {
            // Cập nhật bao gồm cả SoLuongTon
            string query = "UPDATE NGUYENLIEU SET TenNL = @TenNL, DVTNL = @DVTNL, SoLuongTon = @SoLuong WHERE MaNL = @MaNL";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                AddCommonParameters(cmd, dvt);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void AddCommonParameters(SqlCommand command, string dvt)
        {
            command.Parameters.AddWithValue("@MaNL", txtMaNL.Text.Trim());
            command.Parameters.AddWithValue("@TenNL", txtTenNL.Text.Trim());
            command.Parameters.AddWithValue("@DVTNL", dvt);

            // Parse số lượng (xử lý dấu phẩy phân cách hàng nghìn nếu có)
            decimal sl = 0;
            decimal.TryParse(txtSoLuong.Text.Replace(",", "").Replace(".", ""), out sl);
            command.Parameters.AddWithValue("@SoLuong", sl);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}