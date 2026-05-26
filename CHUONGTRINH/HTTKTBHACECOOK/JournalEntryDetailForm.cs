using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class JournalEntryDetailForm : Form
    {
        private string _connectionString;
        private string _currentSoCT;
        private bool _isViewOnly;

        public JournalEntryDetailForm(string connectionString, string soCT = null, bool isViewOnly = false)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _currentSoCT = soCT;
            _isViewOnly = isViewOnly;
        }

        private void JournalEntryDetailForm_Load(object sender, EventArgs e)
        {
            LoadChartOfAccounts();

            if (string.IsNullOrEmpty(_currentSoCT))
            {
                SetupForAdd();
            }
            else
            {
                if (_isViewOnly) SetupForView();
                else SetupForEdit();

                LoadData();
            }
        }

        // --- SETUP GIAO DIỆN ---
        private void SetupForAdd()
        {
            lblTitle.Text = "THÊM MỚI BÚT TOÁN";
            lblTitle.BackColor = ColorTranslator.FromHtml("#0D6EFD");
            txtSoCT.Text = GenerateNewID();
            txtMaBT.Text = txtSoCT.Text;
            txtSoCT.ReadOnly = true;
            txtMaBT.ReadOnly = true;
            dtpNgayGhiSo.Value = DateTime.Now;
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
        }

        private void SetupForEdit()
        {
            lblTitle.Text = "CẬP NHẬT BÚT TOÁN";
            lblTitle.BackColor = ColorTranslator.FromHtml("#FFC107");
            lblTitle.ForeColor = Color.Black;
            txtSoCT.ReadOnly = true;
            txtMaBT.ReadOnly = true;
        }

        private void SetupForView()
        {
            lblTitle.Text = "CHI TIẾT BÚT TOÁN";
            lblTitle.BackColor = ColorTranslator.FromHtml("#17A2B8");
            lblTitle.ForeColor = Color.White;

            txtSoCT.ReadOnly = true;
            txtMaBT.ReadOnly = true;
            txtSoTien.ReadOnly = true;
            txtDienGiai.ReadOnly = true;
            dtpNgayGhiSo.Enabled = false;
            cboTKNo.Enabled = false;
            cboTKCo.Enabled = false;
            cboTrangThai.Enabled = false;

            btnSave.Visible = false;
            btnCancel.Text = "ĐÓNG";
            btnCancel.BackColor = ColorTranslator.FromHtml("#6C757D");
            btnCancel.Location = new Point((this.Width - btnCancel.Width) / 2, btnCancel.Location.Y);
        }

        // --- LOAD DATA ---
        private void LoadChartOfAccounts()
        {
            string query = @"
                SELECT SoTKC3 AS SoTK, TenTKC3 AS TenTK FROM TAIKHOANCAP3
                UNION
                SELECT SoTKC2 AS SoTK, TenTKC2 AS TenTK FROM TAIKHOANCAP2
                UNION
                SELECT SoTKC1 AS SoTK, TenTKC1 AS TenTK FROM TAIKHOANCAP1
                ORDER BY SoTK";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboTKNo.DataSource = dt;
                    cboTKNo.DisplayMember = "SoTK";
                    cboTKNo.ValueMember = "SoTK"; // Quan trọng: Giá trị thực là Số TK ngắn gọn
                    cboTKNo.SelectedIndex = -1;

                    DataTable dtCo = dt.Copy();
                    cboTKCo.DataSource = dtCo;
                    cboTKCo.DisplayMember = "SoTK";
                    cboTKCo.ValueMember = "SoTK";
                    cboTKCo.SelectedIndex = -1;

                    // Format hiển thị đẹp: "1111 - Tiền mặt"
                    cboTKNo.Format += (s, e) => { if (e.ListItem != null) e.Value = $"{((DataRowView)e.ListItem)["SoTK"]} - {((DataRowView)e.ListItem)["TenTK"]}"; };
                    cboTKCo.Format += (s, e) => { if (e.ListItem != null) e.Value = $"{((DataRowView)e.ListItem)["SoTK"]} - {((DataRowView)e.ListItem)["TenTK"]}"; };
                }
            }
            catch { }
        }

        private string GenerateNewID()
        {
            string newID = "BT001";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    object result = new SqlCommand("SELECT TOP 1 SoCT FROM BUTTOAN ORDER BY SoCT DESC", conn).ExecuteScalar();
                    if (result != null)
                    {
                        string lastID = result.ToString();
                        if (lastID.Length > 2 && int.TryParse(lastID.Substring(2), out int num))
                        {
                            newID = "BT" + (num + 1).ToString("D3");
                        }
                    }
                }
                catch { }
            }
            return newID;
        }

        private void LoadData()
        {
            string query = "SELECT * FROM BUTTOAN WHERE SoCT = @SoCT";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoCT", _currentSoCT);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    txtMaBT.Text = r["SoCT"].ToString();
                    txtSoCT.Text = r["SoCT"].ToString();
                    if (r["NgayHachToan"] != DBNull.Value) dtpNgayGhiSo.Value = Convert.ToDateTime(r["NgayHachToan"]);

                    // Gán giá trị vào ComboBox (nó sẽ tự khớp với ValueMember "SoTK")
                    cboTKNo.SelectedValue = r["TKNo"].ToString();
                    cboTKCo.SelectedValue = r["TKCo"].ToString();

                    txtSoTien.Text = Convert.ToDecimal(r["SoTienBT"]).ToString("N0");
                    txtDienGiai.Text = r["DienGiai"].ToString();
                    cboTrangThai.Text = r["TrangThai"].ToString();
                }
            }
        }

        // --- LƯU DỮ LIỆU (ĐÃ SỬA LỖI TRUNCATED) ---
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isViewOnly) return;

            if (string.IsNullOrEmpty(txtSoTien.Text)) { MessageBox.Show("Nhập số tiền!"); return; }
            if (cboTKNo.SelectedValue == null || cboTKCo.SelectedValue == null) { MessageBox.Show("Vui lòng chọn Tài khoản Nợ/Có!"); return; }

            decimal amount = 0;
            decimal.TryParse(txtSoTien.Text.Replace(".", "").Replace(",", ""), out amount);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = string.IsNullOrEmpty(_currentSoCT)
                    ? "INSERT INTO BUTTOAN (SoCT, NgayHachToan, TKNo, TKCo, SoTienBT, DienGiai, TrangThai) VALUES (@ID, @Ngay, @No, @Co, @Tien, @DG, @TT)"
                    : "UPDATE BUTTOAN SET NgayHachToan=@Ngay, TKNo=@No, TKCo=@Co, SoTienBT=@Tien, DienGiai=@DG, TrangThai=@TT WHERE SoCT=@ID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", txtSoCT.Text);
                    cmd.Parameters.AddWithValue("@Ngay", dtpNgayGhiSo.Value);

                    // SỬA LỖI Ở ĐÂY: Dùng SelectedValue thay vì Text
                    // SelectedValue chỉ chứa mã (VD: "1111") -> Vừa khít database CHAR(10)
                    cmd.Parameters.AddWithValue("@No", cboTKNo.SelectedValue);
                    cmd.Parameters.AddWithValue("@Co", cboTKCo.SelectedValue);

                    cmd.Parameters.AddWithValue("@Tien", amount);
                    cmd.Parameters.AddWithValue("@DG", txtDienGiai.Text);
                    cmd.Parameters.AddWithValue("@TT", cboTrangThai.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Lưu thành công!");
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
                }
            }
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}