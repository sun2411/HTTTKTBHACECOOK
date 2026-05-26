using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing; // Thư viện in ấn
using System.Linq;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class InvoiceAddForm : Form
    {
        public enum FormMode { Add, Edit, View }

        private string CONNECTION_STRING;
        private string InvoiceID;
        private FormMode CurrentMode;
        private bool IsReadOnlyMode => CurrentMode == FormMode.View;

        // Cache danh sách sản phẩm để dùng cho ComboBox trong Grid
        private DataTable dtProductList;

        // Biến lưu dữ liệu chi tiết để phục vụ in ấn
        private DataTable dtPrintDetails;

        // Constructor Thêm mới
        public InvoiceAddForm(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.CurrentMode = FormMode.Add;
            SetupForm();
        }

        // Constructor Xem/Sửa
        public InvoiceAddForm(string connectionString, string invoiceID, FormMode mode)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.InvoiceID = invoiceID;
            this.CurrentMode = mode;
            SetupForm();
        }

        private void InvoiceAddForm_Load(object sender, EventArgs e)
        {
            // 1. Tải danh sách sản phẩm vào bộ nhớ đệm trước
            LoadProductListCache();

            // 2. Load dữ liệu ComboBox (KH, NV, Trạng thái)
            LoadComboBoxData();

            // 3. Cấu hình Grid (Cột Mã SP là ComboBox)
            SetupGridColumns();

            if (CurrentMode == FormMode.Add)
            {
                txtMaHD.Text = GenerateNewInvoiceID(); // Tự sinh mã HDB
                dtpNgayLap.Value = DateTime.Now;

                // Mới vào chưa lưu thì chưa cho in
                btnPrint.Enabled = false;

                // Mặc định trạng thái
                if (cmbTrangThai.Items.Count > 0) cmbTrangThai.SelectedIndex = 1; // Chưa thanh toán
            }
            else
            {
                LoadInvoiceData(this.InvoiceID);
            }

            // Đăng ký sự kiện tính toán
            dgvInvoiceDetails.CellValueChanged += dgvInvoiceDetails_CellValueChanged;
            // Sự kiện này giúp ComboBox phản hồi ngay khi chọn xong
            dgvInvoiceDetails.CurrentCellDirtyStateChanged += dgvInvoiceDetails_CurrentCellDirtyStateChanged;

            // Tính lại tổng khi xóa dòng hoặc nhập giảm giá
            dgvInvoiceDetails.RowsRemoved += (s, ev) => CalculateTotal();
            txtGiamGia.TextChanged += (s, ev) => CalculateTotal();

            // Chỉ cho nhập số vào ô giảm giá
            txtGiamGia.KeyPress += (s, ev) => { if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar)) ev.Handled = true; };

            // Gán sự kiện nút
            btnSave.Click += btnSave_Click;
            btnClose.Click += (s, ev) => this.Close();
            btnPrint.Click += btnPrint_Click;
        }

        // --- 1. SETUP GIAO DIỆN & GRID ---

        private void SetupForm()
        {
            dgvInvoiceDetails.AutoGenerateColumns = false;
            txtMaHD.ReadOnly = true;

            switch (CurrentMode)
            {
                case FormMode.Add:
                    lblTitle.Text = "➕ TẠO HÓA ĐƠN MỚI";
                    pnlHeader.BackColor = ColorTranslator.FromHtml("#0D6EFD");
                    break;
                case FormMode.Edit:
                    lblTitle.Text = $"✏️ CHỈNH SỬA HÓA ĐƠN {InvoiceID}";
                    pnlHeader.BackColor = ColorTranslator.FromHtml("#FFC107");
                    SetReadOnly(false);
                    break;
                case FormMode.View:
                    lblTitle.Text = $"👁️ CHI TIẾT HÓA ĐƠN {InvoiceID}";
                    pnlHeader.BackColor = ColorTranslator.FromHtml("#198754");
                    SetReadOnly(true);
                    break;
            }
        }

        private void SetReadOnly(bool isReadOnly)
        {
            cmbKhachHang.Enabled = !isReadOnly;
            cmbNhanVien.Enabled = !isReadOnly;
            dtpNgayLap.Enabled = !isReadOnly;
            cmbPhuongThucTT.Enabled = !isReadOnly;
            cmbTrangThai.Enabled = !isReadOnly;
            txtGiamGia.ReadOnly = isReadOnly;

            dgvInvoiceDetails.ReadOnly = isReadOnly;
            dgvInvoiceDetails.AllowUserToAddRows = !isReadOnly;
            dgvInvoiceDetails.AllowUserToDeleteRows = !isReadOnly;

            btnSave.Visible = !isReadOnly;
            btnPrint.Visible = true; // Luôn hiện nút in
            btnPrint.Enabled = true;
        }

        private void LoadProductListCache()
        {
            string query = "SELECT MaSP, TenSP, GiaBanSP FROM SANPHAM ORDER BY TenSP";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                dtProductList = new DataTable();
                adapter.Fill(dtProductList);
            }
        }

        private void SetupGridColumns()
        {
            // Cột Mã SP: Hiển thị MÃ (không phải tên)
            colMaSP.DataSource = dtProductList.Copy();
            colMaSP.DisplayMember = "MaSP";  // ✅ Hiển thị MÃ SP
            colMaSP.ValueMember = "MaSP";

            // Cột Tên SP: Cũng là ComboBox để dễ chọn
            if (colTenSP is DataGridViewComboBoxColumn)
            {
                ((DataGridViewComboBoxColumn)colTenSP).DataSource = dtProductList.Copy();
                ((DataGridViewComboBoxColumn)colTenSP).DisplayMember = "TenSP";
                ((DataGridViewComboBoxColumn)colTenSP).ValueMember = "TenSP";
            }
        }

        private void LoadComboBoxData()
        {
            LoadDataToCombo("SELECT MaKH, TenKH FROM KHACHHANG ORDER BY TenKH", cmbKhachHang, "TenKH", "MaKH");
            LoadDataToCombo("SELECT MaNV, HoTenNV FROM NHANVIEN ORDER BY HoTenNV", cmbNhanVien, "HoTenNV", "MaNV");

            cmbPhuongThucTT.Items.Clear();
            cmbPhuongThucTT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Ví điện tử" });
            cmbPhuongThucTT.SelectedIndex = 0;

            // Thêm lựa chọn trạng thái
            cmbTrangThai.Items.Clear();
            cmbTrangThai.Items.Add("Đã thanh toán");
            cmbTrangThai.Items.Add("Chưa thanh toán");
            cmbTrangThai.SelectedIndex = 0;
        }

        private void LoadDataToCombo(string query, ComboBox cmb, string display, string value)
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmb.DataSource = dt;
                cmb.DisplayMember = display;
                cmb.ValueMember = value;
            }
        }

        // --- 2. XỬ LÝ SỰ KIỆN TRÊN GRID (TỰ ĐỘNG TÍNH TOÁN) ---

        private void dgvInvoiceDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInvoiceDetails.IsCurrentCellDirty)
            {
                dgvInvoiceDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvInvoiceDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvInvoiceDetails.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = dgvInvoiceDetails.Rows[e.RowIndex];

            // KHI CHỌN SẢN PHẨM (qua Mã SP hoặc Tên SP) -> Tự điền thông tin
            if (colName == "colMaSP" || colName == "colTenSP")
            {
                object val = row.Cells[colName].Value;
                if (val != null)
                {
                    string searchValue = val.ToString();
                    DataRow[] found = null;

                    if (colName == "colMaSP")
                    {
                        // Tìm theo Mã SP
                        found = dtProductList.Select($"MaSP = '{searchValue}'");
                    }
                    else if (colName == "colTenSP")
                    {
                        // Tìm theo Tên SP
                        found = dtProductList.Select($"TenSP = '{searchValue.Replace("'", "''")}'");
                    }

                    if (found != null && found.Length > 0)
                    {
                        // Điền đồng bộ cả Mã và Tên
                        row.Cells["colMaSP"].Value = found[0]["MaSP"];
                        row.Cells["colTenSP"].Value = found[0]["TenSP"];
                        row.Cells["colDonGia"].Value = Convert.ToDecimal(found[0]["GiaBanSP"]).ToString("N0");

                        // Mặc định SL = 1 nếu chưa nhập
                        if (row.Cells["colSoLuong"].Value == null || row.Cells["colSoLuong"].Value.ToString() == "")
                            row.Cells["colSoLuong"].Value = 1;
                    }
                }
            }

            // KHI ĐỔI SỐ LƯỢNG HOẶC GIÁ -> TÍNH THÀNH TIỀN
            if (colName == "colSoLuong" || colName == "colDonGia" || colName == "colMaSP" || colName == "colTenSP")
            {
                decimal sl = 0, gia = 0;
                if (row.Cells["colSoLuong"].Value != null)
                    decimal.TryParse(row.Cells["colSoLuong"].Value.ToString(), out sl);

                if (row.Cells["colDonGia"].Value != null)
                    decimal.TryParse(row.Cells["colDonGia"].Value.ToString().Replace(".", ""), out gia);

                row.Cells["colThanhTien"].Value = (sl * gia).ToString("N0");

                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvInvoiceDetails.Rows)
            {
                if (row.Cells["colThanhTien"].Value != null)
                {
                    string valStr = row.Cells["colThanhTien"].Value.ToString().Replace(".", "");
                    decimal val = 0;
                    if (decimal.TryParse(valStr, out val)) total += val;
                }
            }

            decimal giamGia = 0;
            decimal.TryParse(txtGiamGia.Text.Replace(",", "").Replace(".", ""), out giamGia);

            lblTongTienVal.Text = (total - giamGia).ToString("N0") + " đ";
        }

        // --- 3. LOAD DATA (KHI XEM/SỬA) ---

        private void LoadInvoiceData(string maHD)
        {
            string queryHeader = @"
                SELECT HDB.SoHDB, HDB.NgayLapHDB, HDB.GiamGiaHDB, 
                       DDH.MaKH, DDH.MaNV, DDH.PhuongThucThanhToan, DDH.TrangThaiDH
                FROM HOADONBAN HDB
                JOIN DONDATHANG DDH ON HDB.MaDDH = DDH.MaDDH
                WHERE HDB.SoHDB = @MaHD";

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                // 1. Load Header
                SqlCommand cmd = new SqlCommand(queryHeader, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtMaHD.Text = reader["SoHDB"].ToString();
                    dtpNgayLap.Value = Convert.ToDateTime(reader["NgayLapHDB"]);
                    cmbKhachHang.SelectedValue = reader["MaKH"].ToString();
                    cmbNhanVien.SelectedValue = reader["MaNV"].ToString();
                    cmbPhuongThucTT.Text = reader["PhuongThucThanhToan"].ToString();

                    // Map trạng thái
                    string statusDB = reader["TrangThaiDH"].ToString();
                    if (statusDB == "Đã giao") cmbTrangThai.Text = "Đã thanh toán";
                    else cmbTrangThai.Text = "Chưa thanh toán";

                    txtGiamGia.Text = Convert.ToDecimal(reader["GiamGiaHDB"]).ToString("N0");
                }
                reader.Close();

                // 2. Load Details
                string queryDet = @"
                    SELECT CT.MaSP, SP.TenSP, CT.SoLuongDDH, CT.DonGiaDDH
                    FROM HOADONBAN HDB
                    JOIN DONDATHANG DDH ON HDB.MaDDH = DDH.MaDDH
                    JOIN CT_DH CT ON DDH.MaDDH = CT.MaDDH
                    JOIN SANPHAM SP ON CT.MaSP = SP.MaSP
                    WHERE HDB.SoHDB = @MaHD";

                SqlDataAdapter da = new SqlDataAdapter(queryDet, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaHD", maHD);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInvoiceDetails.Rows.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    int idx = dgvInvoiceDetails.Rows.Add();

                    // Set Mã SP (ComboBox)
                    dgvInvoiceDetails.Rows[idx].Cells["colMaSP"].Value = row["MaSP"];

                    // Set các cột khác
                    dgvInvoiceDetails.Rows[idx].Cells["colTenSP"].Value = row["TenSP"];

                    decimal sl = Convert.ToDecimal(row["SoLuongDDH"]);
                    decimal dg = Convert.ToDecimal(row["DonGiaDDH"]);

                    dgvInvoiceDetails.Rows[idx].Cells["colSoLuong"].Value = sl;
                    dgvInvoiceDetails.Rows[idx].Cells["colDonGia"].Value = dg.ToString("N0");

                    // QUAN TRỌNG: Gán Thành tiền trực tiếp để hiển thị ngay
                    dgvInvoiceDetails.Rows[idx].Cells["colThanhTien"].Value = (sl * dg).ToString("N0");
                }

                CalculateTotal(); // Tính lại tổng sau khi load
            }
        }

        // --- 4. SINH MÃ TỰ ĐỘNG ---

        private string GenerateNewID(string table, string col, string prefix)
        {
            string newID = prefix + "001";
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    conn.Open();
                    object res = new SqlCommand($"SELECT TOP 1 {col} FROM {table} ORDER BY {col} DESC", conn).ExecuteScalar();
                    if (res != null && res.ToString().Length > 3)
                    {
                        int num = int.Parse(res.ToString().Substring(3)) + 1;
                        newID = prefix + num.ToString("D3");
                    }
                }
                catch { }
            }
            return newID;
        }

        private string GenerateNewInvoiceID() => GenerateNewID("HOADONBAN", "SoHDB", "HDB");

        private string GenerateNewOrderID() => GenerateNewID("DONDATHANG", "MaDDH", "DDH");

        // --- 5. LƯU & SỬA ---

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsReadOnlyMode) return;
            if (!ValidateInput()) return;

            if (CurrentMode == FormMode.Add) ExecuteInsert();
            else ExecuteUpdate();
        }

        private bool ValidateInput()
        {
            if (cmbKhachHang.SelectedValue == null || cmbNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng và Nhân viên.", "Thiếu thông tin");
                return false;
            }
            if (dgvInvoiceDetails.Rows.Count <= 1 && dgvInvoiceDetails.Rows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng nhập ít nhất một sản phẩm.", "Thiếu thông tin");
                return false;
            }
            return true;
        }

        private void ExecuteInsert()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string maDDH = GenerateNewOrderID();
                    string maHD = txtMaHD.Text;

                    decimal tongTien = decimal.Parse(lblTongTienVal.Text.Replace(" đ", "").Replace(".", "").Replace(",", ""));
                    decimal giamGia = 0; decimal.TryParse(txtGiamGia.Text.Replace(".", ""), out giamGia);
                    decimal truocThue = tongTien / 1.1m;

                    // Chuyển đổi trạng thái UI -> DB
                    string trangThaiDB = cmbTrangThai.Text == "Đã thanh toán" ? "Đã giao" : "Đang xử lý";

                    // 1. DONDATHANG
                    string sqlDDH = @"INSERT INTO DONDATHANG (MaDDH, MaKH, MaNV, NgayDatHang, NgayGiaoHang, TienCoc, TriGiaDH, TrangThaiDH, PhuongThucThanhToan, SoLanGiaoHang)
                                      VALUES (@MaDDH, @MaKH, @MaNV, @Ngay, @Ngay, 0, @TriGia, @TrangThai, @PTTT, 1)";
                    using (SqlCommand cmd = new SqlCommand(sqlDDH, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@MaDDH", maDDH);
                        cmd.Parameters.AddWithValue("@MaKH", cmbKhachHang.SelectedValue);
                        cmd.Parameters.AddWithValue("@MaNV", cmbNhanVien.SelectedValue);
                        cmd.Parameters.AddWithValue("@Ngay", dtpNgayLap.Value);
                        cmd.Parameters.AddWithValue("@TriGia", truocThue);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThaiDB);
                        cmd.Parameters.AddWithValue("@PTTT", cmbPhuongThucTT.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. HOADONBAN
                    string sqlHDB = @"INSERT INTO HOADONBAN (SoHDB, MaDDH, NgayLapHDB, TiencocHDB, TriGiaTruocthueHDB, TriGiaSauthueHDB, GiamGiaHDB, TriGiaSauGiam)
                                      VALUES (@SoHDB, @MaDDH, @Ngay, 0, @TruocThue, @SauThue, @GiamGia, @SauGiam)";
                    using (SqlCommand cmd = new SqlCommand(sqlHDB, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@SoHDB", maHD);
                        cmd.Parameters.AddWithValue("@MaDDH", maDDH);
                        cmd.Parameters.AddWithValue("@Ngay", dtpNgayLap.Value);
                        cmd.Parameters.AddWithValue("@TruocThue", truocThue);
                        cmd.Parameters.AddWithValue("@SauThue", tongTien + giamGia);
                        cmd.Parameters.AddWithValue("@GiamGia", giamGia);
                        cmd.Parameters.AddWithValue("@SauGiam", tongTien);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. CT_DH
                    SaveDetails(maDDH, conn, trans);

                    trans.Commit();
                    MessageBox.Show("Lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Enable in ấn sau khi lưu
                    btnPrint.Enabled = true;
                    this.CurrentMode = FormMode.Edit;
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExecuteUpdate()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Lấy MaDDH từ MaHD
                    string getDDH = "SELECT MaDDH FROM HOADONBAN WHERE SoHDB = @MaHD";
                    string maDDH = "";
                    using (SqlCommand cmdGet = new SqlCommand(getDDH, conn, trans))
                    {
                        cmdGet.Parameters.AddWithValue("@MaHD", InvoiceID);
                        maDDH = cmdGet.ExecuteScalar()?.ToString();
                    }

                    decimal tongTien = decimal.Parse(lblTongTienVal.Text.Replace(" đ", "").Replace(".", "").Replace(",", ""));
                    decimal giamGia = 0; decimal.TryParse(txtGiamGia.Text.Replace(".", ""), out giamGia);
                    decimal truocThue = tongTien / 1.1m;
                    string trangThaiDB = cmbTrangThai.Text == "Đã thanh toán" ? "Đã giao" : "Đang xử lý";

                    // 1. UPDATE DONDATHANG
                    string sqlDDH = @"UPDATE DONDATHANG SET 
                                      MaKH=@MaKH, MaNV=@MaNV, NgayDatHang=@Ngay, NgayGiaoHang=@Ngay, 
                                      TriGiaDH=@TriGia, TrangThaiDH=@TrangThai, PhuongThucThanhToan=@PTTT
                                      WHERE MaDDH=@MaDDH";
                    using (SqlCommand cmd = new SqlCommand(sqlDDH, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@MaDDH", maDDH);
                        cmd.Parameters.AddWithValue("@MaKH", cmbKhachHang.SelectedValue);
                        cmd.Parameters.AddWithValue("@MaNV", cmbNhanVien.SelectedValue);
                        cmd.Parameters.AddWithValue("@Ngay", dtpNgayLap.Value);
                        cmd.Parameters.AddWithValue("@TriGia", truocThue);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThaiDB);
                        cmd.Parameters.AddWithValue("@PTTT", cmbPhuongThucTT.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. UPDATE HOADONBAN
                    string sqlHDB = @"UPDATE HOADONBAN SET 
                                      NgayLapHDB=@Ngay, TriGiaTruocthueHDB=@TruocThue, 
                                      TriGiaSauthueHDB=@SauThue, GiamGiaHDB=@GiamGia, TriGiaSauGiam=@SauGiam
                                      WHERE SoHDB=@SoHDB";
                    using (SqlCommand cmd = new SqlCommand(sqlHDB, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@SoHDB", InvoiceID);
                        cmd.Parameters.AddWithValue("@Ngay", dtpNgayLap.Value);
                        cmd.Parameters.AddWithValue("@TruocThue", truocThue);
                        cmd.Parameters.AddWithValue("@SauThue", tongTien + giamGia);
                        cmd.Parameters.AddWithValue("@GiamGia", giamGia);
                        cmd.Parameters.AddWithValue("@SauGiam", tongTien);
                        cmd.ExecuteNonQuery();
                    }

                    // 3. UPDATE CHI TIẾT (XÓA CŨ -> THÊM MỚI)
                    string delCT = "DELETE FROM CT_DH WHERE MaDDH = @MaDDH";
                    using (SqlCommand cmdDel = new SqlCommand(delCT, conn, trans))
                    {
                        cmdDel.Parameters.AddWithValue("@MaDDH", maDDH);
                        cmdDel.ExecuteNonQuery();
                    }

                    SaveDetails(maDDH, conn, trans);

                    trans.Commit();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveDetails(string maDDH, SqlConnection conn, SqlTransaction trans)
        {
            string sqlCT = "INSERT INTO CT_DH (MaDDH, MaSP, SoLuongDDH, DonGiaDDH) VALUES (@MaDDH, @MaSP, @SL, @DG)";
            foreach (DataGridViewRow row in dgvInvoiceDetails.Rows)
            {
                if (row.IsNewRow || row.Cells["colMaSP"].Value == null) continue;

                using (SqlCommand cmd = new SqlCommand(sqlCT, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@MaDDH", maDDH);
                    cmd.Parameters.AddWithValue("@MaSP", row.Cells["colMaSP"].Value);
                    cmd.Parameters.AddWithValue("@SL", row.Cells["colSoLuong"].Value);
                    decimal dg = decimal.Parse(row.Cells["colDonGia"].Value.ToString().Replace(".", ""));
                    cmd.Parameters.AddWithValue("@DG", dg);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --- 6. IN HÓA ĐƠN (UPDATED: FORM MỚI CHUẨN ACECOOK) ---

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dtPrintDetails = new DataTable();
            dtPrintDetails.Columns.Add("TenSP");
            dtPrintDetails.Columns.Add("SoLuong");
            dtPrintDetails.Columns.Add("DonGia");
            dtPrintDetails.Columns.Add("ThanhTien");

            foreach (DataGridViewRow row in dgvInvoiceDetails.Rows)
            {
                if (!row.IsNewRow && row.Cells["colMaSP"].Value != null)
                {
                    dtPrintDetails.Rows.Add(
                        row.Cells["colMaSP"].FormattedValue,
                        row.Cells["colSoLuong"].Value,
                        row.Cells["colDonGia"].Value,
                        row.Cells["colThanhTien"].Value
                    );
                }
            }

            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += PrintDocument_PrintPage;

            // Cài đặt trang giấy mặc định là A4
            doc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            pd.Document = doc;

            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            // 1. CẤU HÌNH FONT VÀ MÀU SẮC
            Font fontTitle = new Font("Times New Roman", 20, FontStyle.Bold); // Tiêu đề lớn
            Font fontCompany = new Font("Times New Roman", 14, FontStyle.Bold); // Tên công ty
            Font fontHeaderTable = new Font("Times New Roman", 11, FontStyle.Bold); // Tiêu đề cột
            Font fontNormal = new Font("Times New Roman", 11, FontStyle.Regular); // Chữ thường
            Font fontBold = new Font("Times New Roman", 11, FontStyle.Bold); // Chữ đậm nhỏ
            Font fontItalic = new Font("Times New Roman", 10, FontStyle.Italic); // Chữ nghiêng

            Brush brushMain = Brushes.Black;
            Brush brushRed = Brushes.Red; // Dùng cho tiêu đề
            Pen pen = new Pen(Color.Black, 1); // Bút vẽ bảng

            // Cấu hình lề và kích thước
            int leftMargin = 40;
            int topMargin = 40;
            int pageWidth = e.PageBounds.Width;
            int y = topMargin;

            StringFormat centerAlign = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat rightAlign = new StringFormat { Alignment = StringAlignment.Far };
            StringFormat leftAlign = new StringFormat { Alignment = StringAlignment.Near };

            // --- 2. VẼ HEADER (THÔNG TIN CÔNG TY) ---
            g.DrawString("CÔNG TY CỔ PHẦN ACECOOK VIỆT NAM", fontCompany, brushRed, leftMargin, y);
            y += 25;
            g.DrawString("Địa chỉ: Lô II-3, Đường số 11, KCN Tân Bình, P. Tây Thạnh, Q. Tân Phú, TP.HCM", fontNormal, brushMain, leftMargin, y);
            y += 20;
            g.DrawString("Điện thoại: (028) 3815 4064", fontNormal, brushMain, leftMargin, y);
            y += 40;

            // --- 3. TIÊU ĐỀ HÓA ĐƠN ---
            g.DrawString("HÓA ĐƠN BÁN HÀNG", fontTitle, brushRed, pageWidth / 2, y, centerAlign);
            y += 35;

            DateTime ngayLap = dtpNgayLap.Value;
            g.DrawString($"Ngày {ngayLap.Day} tháng {ngayLap.Month} năm {ngayLap.Year}", fontItalic, brushMain, pageWidth / 2, y, centerAlign);

            g.DrawString($"Số: {txtMaHD.Text}", fontBold, brushRed, pageWidth - leftMargin, y - 35, rightAlign);
            y += 30;

            // --- 4. THÔNG TIN KHÁCH HÀNG ---
            int labelX = leftMargin;
            int contentX = leftMargin + 90;

            g.DrawString("Khách hàng:", fontBold, brushMain, labelX, y);
            g.DrawString(cmbKhachHang.Text, fontNormal, brushMain, contentX, y);
            y += 25;

            g.DrawString("Địa chỉ:", fontBold, brushMain, labelX, y);
            g.DrawString("................................................................................................................................", fontNormal, brushMain, contentX, y);
            y += 25;

            g.DrawString("Hình thức TT: ", fontBold, brushMain, labelX, y);
            g.DrawString(cmbPhuongThucTT.Text, fontNormal, brushMain, contentX, y);
            y += 35;

            // --- 5. VẼ BẢNG CHI TIẾT (GRID) ---
            int[] colWidths = { 40, 300, 80, 110, 150 }; // STT, Tên hàng, SL, Đơn giá, Thành tiền
            string[] colHeaders = { "STT", "TÊN HÀNG", "SL", "ĐƠN GIÁ", "THÀNH TIỀN" };
            int tableWidth = colWidths.Sum();
            int currentX = leftMargin;

            // A. Vẽ Header Bảng
            int headerHeight = 30;
            g.DrawRectangle(pen, leftMargin, y, tableWidth, headerHeight);

            for (int i = 0; i < colWidths.Length; i++)
            {
                RectangleF cellRect = new RectangleF(currentX, y, colWidths[i], headerHeight);
                g.DrawString(colHeaders[i], fontHeaderTable, brushMain, cellRect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                if (i < colWidths.Length - 1)
                    g.DrawLine(pen, currentX + colWidths[i], y, currentX + colWidths[i], y + headerHeight);

                currentX += colWidths[i];
            }
            y += headerHeight;

            // B. Vẽ Dữ liệu (Rows)
            int rowHeight = 25;
            int stt = 1;
            decimal totalQuantity = 0;
            decimal totalMoney = 0;

            foreach (DataRow row in dtPrintDetails.Rows)
            {
                currentX = leftMargin;

                string tenSP = row["TenSP"].ToString();
                decimal sl = Convert.ToDecimal(row["SoLuong"]);
                decimal dg = Convert.ToDecimal(row["DonGia"].ToString().Replace(",", "").Replace(".", ""));
                decimal tt = Convert.ToDecimal(row["ThanhTien"].ToString().Replace(",", "").Replace(".", ""));

                totalQuantity += sl;
                totalMoney += tt;

                g.DrawRectangle(pen, leftMargin, y, tableWidth, rowHeight);

                // 1. STT
                g.DrawString(stt.ToString(), fontNormal, brushMain, new RectangleF(currentX, y, colWidths[0], rowHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                g.DrawLine(pen, currentX + colWidths[0], y, currentX + colWidths[0], y + rowHeight);
                currentX += colWidths[0];

                // 2. Tên Hàng
                RectangleF rectTen = new RectangleF(currentX + 5, y, colWidths[1] - 10, rowHeight);
                g.DrawString(tenSP, fontNormal, brushMain, rectTen, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                g.DrawLine(pen, currentX + colWidths[1], y, currentX + colWidths[1], y + rowHeight);
                currentX += colWidths[1];

                // 3. SL
                g.DrawString(sl.ToString(), fontNormal, brushMain, new RectangleF(currentX, y, colWidths[2], rowHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                g.DrawLine(pen, currentX + colWidths[2], y, currentX + colWidths[2], y + rowHeight);
                currentX += colWidths[2];

                // 4. Đơn giá
                g.DrawString(dg.ToString("N0"), fontNormal, brushMain, new RectangleF(currentX, y, colWidths[3] - 5, rowHeight), new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                g.DrawLine(pen, currentX + colWidths[3], y, currentX + colWidths[3], y + rowHeight);
                currentX += colWidths[3];

                // 5. Thành tiền
                g.DrawString(tt.ToString("N0"), fontNormal, brushMain, new RectangleF(currentX, y, colWidths[4] - 5, rowHeight), new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });

                y += rowHeight;
                stt++;
            }

            // --- 6. VẼ DÒNG TỔNG CỘNG ---
            g.DrawRectangle(pen, leftMargin, y, tableWidth, rowHeight);

            // Text "Tổng cộng"
            int widthTotalTitle = colWidths[0] + colWidths[1];
            g.DrawString("TỔNG CỘNG", fontHeaderTable, brushRed, new RectangleF(leftMargin, y, widthTotalTitle, rowHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            g.DrawLine(pen, leftMargin + widthTotalTitle, y, leftMargin + widthTotalTitle, y + rowHeight);

            // Tổng số lượng
            currentX = leftMargin + widthTotalTitle;
            g.DrawString(totalQuantity.ToString("N0"), fontBold, brushRed, new RectangleF(currentX, y, colWidths[2], rowHeight), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            g.DrawLine(pen, currentX + colWidths[2], y, currentX + colWidths[2], y + rowHeight);

            // Ô trống (Đơn giá)
            currentX += colWidths[2];
            g.DrawLine(pen, currentX + colWidths[3], y, currentX + colWidths[3], y + rowHeight);

            // Tổng thành tiền
            currentX += colWidths[3];
            g.DrawString(totalMoney.ToString("N0") + " đ", fontBold, brushRed, new RectangleF(currentX, y, colWidths[4] - 5, rowHeight), new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });

            y += rowHeight + 10;

            // --- 7. FOOTER (CHỮ KÝ) ---
            y += 20;
            int colSignWidth = tableWidth / 2;

            // Người mua hàng
            g.DrawString("NGƯỜI MUA HÀNG", fontBold, brushMain, leftMargin + (colSignWidth / 2), y, centerAlign);

            // Người bán hàng
            g.DrawString("NGƯỜI BÁN HÀNG", fontBold, brushMain, leftMargin + colSignWidth + (colSignWidth / 2), y, centerAlign);

            y += 20;
            g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, brushMain, leftMargin + (colSignWidth / 2), y, centerAlign);
            g.DrawString("(Ký, ghi rõ họ tên)", fontItalic, brushMain, leftMargin + colSignWidth + (colSignWidth / 2), y, centerAlign);
        }
    }
}