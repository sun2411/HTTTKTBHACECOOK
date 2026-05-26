using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class ProductAddEditForm : Form
    {
        private string MaSP;
        private string CONNECTION_STRING;
        private bool IsEditMode => !string.IsNullOrEmpty(MaSP);
        private bool IsReadOnlyMode = false;

        // Biến lưu danh sách NVL để dùng cho ComboBox trong Grid
        private DataTable dtMaterialList;

        public ProductAddEditForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            SetupFormForAddMode();
        }

        public ProductAddEditForm(string connectionString, string maSP)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaSP = maSP;
            SetupFormForEditMode();
        }

        private void ProductAddEditForm_Load(object sender, EventArgs e)
        {
            // 1. Tải danh sách NVL trước để nạp vào Grid
            LoadMaterialListCache();

            LoadLoaiSPComboBox();
            SetupBOMGrid(); // Cấu hình Grid có ComboBox

            if (IsEditMode || IsReadOnlyMode)
            {
                LoadProductData(MaSP);
                LoadBOMData(MaSP);
            }
            else
            {
                // Tự động sinh mã SP mới
                txtMaSP.Text = GenerateNewMaSP();
            }
        }

        // --- 1. SINH MÃ TỰ ĐỘNG SPxxx ---
        private string GenerateNewMaSP()
        {
            string newCode = "SP001";
            string query = "SELECT TOP 1 MaSP FROM SANPHAM ORDER BY LEN(MaSP) DESC, MaSP DESC";

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
                                newCode = "SP" + (num + 1).ToString("D3");
                            }
                        }
                    }
                }
                catch { }
            }
            return newCode;
        }

        // --- 2. CẤU HÌNH GRID BOM (QUAN TRỌNG) ---
        private void LoadMaterialListCache()
        {
            string query = "SELECT MaNL, TenNL, DVTNL FROM NGUYENLIEU ORDER BY TenNL";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                dtMaterialList = new DataTable();
                adapter.Fill(dtMaterialList);
            }
        }

        private void SetupBOMGrid()
        {
            dgvBOM.Columns.Clear();
            dgvBOM.AutoGenerateColumns = false;

            // Cột 1: Chọn Nguyên liệu (ComboBox)
            DataGridViewComboBoxColumn colMaNL = new DataGridViewComboBoxColumn();
            colMaNL.Name = "MaNL";
            colMaNL.HeaderText = "Nguyên vật liệu";
            colMaNL.DataSource = dtMaterialList;
            colMaNL.DisplayMember = "TenNL"; // Hiển thị Tên
            colMaNL.ValueMember = "MaNL";    // Giá trị là Mã
            colMaNL.Width = 250;
            colMaNL.AutoComplete = true;
            colMaNL.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colMaNL.ReadOnly = IsReadOnlyMode;
            dgvBOM.Columns.Add(colMaNL);

            // Cột 2: Đơn vị tính (Tự động hiển thị, ReadOnly)
            dgvBOM.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "DVTNL",
                HeaderText = "ĐVT",
                ReadOnly = true,
                Width = 80
            });

            // Cột 3: Số lượng (Cho phép nhập)
            dgvBOM.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "SoLuongNL",
                HeaderText = "Số lượng",
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N2" }, // N2 cho phép lẻ
                ReadOnly = IsReadOnlyMode
            });

            dgvBOM.AllowUserToAddRows = !IsReadOnlyMode;

            // Đăng ký sự kiện để tự động điền ĐVT khi chọn NVL
            dgvBOM.CellValueChanged += dgvBOM_CellValueChanged;
            dgvBOM.CurrentCellDirtyStateChanged += dgvBOM_CurrentCellDirtyStateChanged;
        }

        // Xử lý sự kiện khi chọn Nguyên liệu -> Tự động điền ĐVT
        private void dgvBOM_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvBOM.IsCurrentCellDirty) dgvBOM.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvBOM_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvBOM.Columns[e.ColumnIndex].Name == "MaNL")
            {
                object val = dgvBOM.Rows[e.RowIndex].Cells["MaNL"].Value;
                if (val != null)
                {
                    string maNL = val.ToString();
                    DataRow[] found = dtMaterialList.Select($"MaNL = '{maNL}'");
                    if (found.Length > 0)
                    {
                        dgvBOM.Rows[e.RowIndex].Cells["DVTNL"].Value = found[0]["DVTNL"];
                    }
                }
            }
        }

        // --- LOAD DỮ LIỆU ---
        private void LoadLoaiSPComboBox()
        {
            string query = "SELECT MaLoaiSP, TenLoaiSP FROM LOAISANPHAM ORDER BY TenLoaiSP";
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtLoaiSP = new DataTable();
                    adapter.Fill(dtLoaiSP);
                    cmbLoaiSP.DataSource = dtLoaiSP;
                    cmbLoaiSP.DisplayMember = "TenLoaiSP";
                    cmbLoaiSP.ValueMember = "MaLoaiSP";
                }
                catch { }
            }
        }

        private void LoadProductData(string maSP)
        {
            string query = "SELECT * FROM SANPHAM WHERE MaSP = @MaSP";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtMaSP.Text = reader["MaSP"].ToString();
                        txtTenSP.Text = reader["TenSP"].ToString();
                        cmbLoaiSP.SelectedValue = reader["MaLoaiSP"].ToString();
                        txtGiaBan.Text = string.Format("{0:N0}", reader["GiaBanSP"]);
                        txtMoTa.Text = reader["MoTa"].ToString();
                        dtpNSX.Value = Convert.ToDateTime(reader["NSXSP"]);
                        dtpHSD.Value = Convert.ToDateTime(reader["HSDSP"]);
                        txtNhietDo.Text = reader["NhietDoBaoQuan"].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        private void LoadBOMData(string maSP)
        {
            // Load lại dữ liệu BOM cũ lên Grid
            string query = "SELECT MaNL, SoLuongNL FROM DINH_MUC WHERE MaSP = @MaSP";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaSP", maSP);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Điền dữ liệu vào Grid thủ công để khớp với ComboBox
                foreach (DataRow rowData in dt.Rows)
                {
                    int idx = dgvBOM.Rows.Add();
                    dgvBOM.Rows[idx].Cells["MaNL"].Value = rowData["MaNL"]; // Tự động hiển thị Tên NL
                    dgvBOM.Rows[idx].Cells["SoLuongNL"].Value = rowData["SoLuongNL"];

                    // Điền lại ĐVT
                    DataRow[] found = dtMaterialList.Select($"MaNL = '{rowData["MaNL"]}'");
                    if (found.Length > 0) dgvBOM.Rows[idx].Cells["DVTNL"].Value = found[0]["DVTNL"];
                }
            }
        }

        // --- LƯU DỮ LIỆU ---
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            if (IsEditMode) ExecuteUpdateProduct();
            else ExecuteInsertProduct();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text) || string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                cmbLoaiSP.SelectedValue == null || !decimal.TryParse(txtGiaBan.Text, out _))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo");
                return false;
            }
            if (dtpNSX.Value > dtpHSD.Value)
            {
                MessageBox.Show("Hạn sử dụng lỗi.", "Cảnh báo");
                return false;
            }
            return true;
        }

        private void ExecuteInsertProduct()
        {
            string query = @"INSERT INTO SANPHAM (MaSP, MaLoaiSP, TenSP, MoTa, GiaBanSP, NhietDoBaoQuan, NSXSP, HSDSP)
                             VALUES (@MaSP, @MaLoaiSP, @TenSP, @MoTa, @GiaBanSP, @NhietDoBQ, @NSXSP, @HSDSP)";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                    {
                        AddProductParams(cmd);
                        cmd.ExecuteNonQuery();
                    }

                    SaveBOMDetails(conn, trans); // Lưu BOM nếu có

                    trans.Commit();
                    MessageBox.Show("Thêm thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void ExecuteUpdateProduct()
        {
            string query = @"UPDATE SANPHAM SET MaLoaiSP=@MaLoaiSP, TenSP=@TenSP, MoTa=@MoTa, GiaBanSP=@GiaBanSP, 
                             NhietDoBaoQuan=@NhietDoBQ, NSXSP=@NSXSP, HSDSP=@HSDSP WHERE MaSP=@MaSP";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                    {
                        AddProductParams(cmd);
                        cmd.ExecuteNonQuery();
                    }

                    // Xóa BOM cũ
                    new SqlCommand($"DELETE FROM DINH_MUC WHERE MaSP = '{txtMaSP.Text}'", conn, trans).ExecuteNonQuery();
                    // Lưu BOM mới
                    SaveBOMDetails(conn, trans);

                    trans.Commit();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo");
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void AddProductParams(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text);
            cmd.Parameters.AddWithValue("@MaLoaiSP", cmbLoaiSP.SelectedValue);
            cmd.Parameters.AddWithValue("@TenSP", txtTenSP.Text);
            cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
            cmd.Parameters.AddWithValue("@GiaBanSP", decimal.Parse(txtGiaBan.Text));
            cmd.Parameters.AddWithValue("@NhietDoBQ", txtNhietDo.Text);
            cmd.Parameters.AddWithValue("@NSXSP", dtpNSX.Value);
            cmd.Parameters.AddWithValue("@HSDSP", dtpHSD.Value);
        }

        // Lưu BOM: Bỏ qua dòng trống, đây chính là tính năng "Tùy chọn"
        private void SaveBOMDetails(SqlConnection conn, SqlTransaction trans)
        {
            string query = "INSERT INTO DINH_MUC (MaNL, MaSP, SoLuongNL) VALUES (@MaNL, @MaSP, @SoLuong)";
            foreach (DataGridViewRow row in dgvBOM.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["MaNL"].Value == null || row.Cells["SoLuongNL"].Value == null) continue;

                using (SqlCommand cmd = new SqlCommand(query, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@MaNL", row.Cells["MaNL"].Value);
                    cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text);
                    cmd.Parameters.AddWithValue("@SoLuong", Convert.ToDecimal(row.Cells["SoLuongNL"].Value));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --- SETUP MODES ---
        private void SetupFormForAddMode()
        {
            lblTitle.Text = "➕ THÊM MỚI SẢN PHẨM";
            txtMaSP.ReadOnly = true; // Khóa lại vì tự sinh mã
            dgvBOM.AllowUserToAddRows = true;
            dgvBOM.ReadOnly = false;
        }

        private void SetupFormForEditMode()
        {
            lblTitle.Text = $"✏️ CHỈNH SỬA SẢN PHẨM: {MaSP}";
            txtMaSP.ReadOnly = true;
            dgvBOM.AllowUserToAddRows = true;
            dgvBOM.ReadOnly = false;
        }

        public void SetReadOnlyMode(bool isReadOnly)
        {
            this.IsReadOnlyMode = isReadOnly;
            if (isReadOnly) lblTitle.Text = $"👁️ CHI TIẾT SẢN PHẨM: {MaSP}";

            txtTenSP.ReadOnly = isReadOnly;
            cmbLoaiSP.Enabled = !isReadOnly;
            txtGiaBan.ReadOnly = isReadOnly;
            txtMoTa.ReadOnly = isReadOnly;
            dtpNSX.Enabled = !isReadOnly;
            dtpHSD.Enabled = !isReadOnly;
            txtNhietDo.ReadOnly = isReadOnly;

            dgvBOM.ReadOnly = isReadOnly;
            dgvBOM.AllowUserToAddRows = !isReadOnly;

            btnSave.Visible = !isReadOnly;
            btnClose.Text = isReadOnly ? "Đóng" : "Hủy";
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}