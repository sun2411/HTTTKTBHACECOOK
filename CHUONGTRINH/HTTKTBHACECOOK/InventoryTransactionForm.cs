using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;

namespace HTTKTBHACECOOK
{
    public partial class InventoryTransactionForm : Form
    {
        private readonly string CONNECTION_STRING;
        private readonly bool IsImport; // true = NHẬP, false = XUẤT
        private DataTable dtSanPham;
        private DataTable dtKho;
        private bool _isProcessing = false;

        private string SelectedMaSP = "";
        private string SelectedMaKho = "";
        private decimal CurrentStock = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        /// <param name="isImport">true = NHẬP KHO, false = XUẤT KHO</param>
        /// <param name="maSp">Mã sản phẩm mặc định (optional)</param>
        /// <param name="maKho">Mã kho mặc định (optional)</param>
        public InventoryTransactionForm(string connectionString, bool isImport, string maSp = null, string maKho = null)
        {
            InitializeComponent();
            CONNECTION_STRING = connectionString;
            IsImport = isImport;

            // Gán giá trị mặc định nếu có
            if (!string.IsNullOrEmpty(maSp)) SelectedMaSP = maSp;
            if (!string.IsNullOrEmpty(maKho)) SelectedMaKho = maKho;
        }

        private async void InventoryTransactionForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnSave.Enabled = false;

                // 1. Load dữ liệu cho ComboBoxes
                await LoadComboBoxDataAsync();

                // 2. Bind dữ liệu vào ComboBoxes
                BindComboBoxes();

                // 3. Setup giao diện (màu sắc, text)
                SetupForm();

                // 4. Load thông tin tồn kho lần đầu
                await LoadStockDetailsAsync();

                // 5. Tính toán SL sau giao dịch
                UpdateSLAfter();
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khởi tạo", $"Không thể tải dữ liệu: {ex.Message}");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSave.Enabled = true;
            }
        }

        #region DATA LOADING

        /// <summary>
        /// Load dữ liệu Sản phẩm và Kho từ database
        /// </summary>
        private async Task LoadComboBoxDataAsync()
        {
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                await conn.OpenAsync();

                // Load Sản phẩm
                string spQuery = "SELECT MaSP, TenSP, ISNULL(GiaBanSP, 0) AS GiaBanSP FROM SANPHAM ORDER BY TenSP";
                dtSanPham = await LoadTableAsync(conn, spQuery);

                // Load Kho
                string khoQuery = "SELECT MaKho, TenKho FROM KHO ORDER BY TenKho";
                dtKho = await LoadTableAsync(conn, khoQuery);
            }
        }

        private async Task<DataTable> LoadTableAsync(SqlConnection conn, string query)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                await Task.Run(() => da.Fill(dt));
                return dt;
            }
        }

        /// <summary>
        /// Bind dữ liệu vào ComboBoxes
        /// </summary>
        private void BindComboBoxes()
        {
            // ComboBox Sản phẩm
            cmbMaSP.DataSource = dtSanPham;
            cmbMaSP.DisplayMember = "MaSP";
            cmbMaSP.ValueMember = "MaSP";

            // ComboBox Kho
            cmbMaKho.DataSource = dtKho;
            cmbMaKho.DisplayMember = "MaKho";
            cmbMaKho.ValueMember = "MaKho";

            // Chọn giá trị mặc định nếu có
            if (!string.IsNullOrEmpty(SelectedMaSP) && dtSanPham.Rows.Count > 0)
            {
                var row = dtSanPham.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaSP") == SelectedMaSP);
                if (row != null)
                {
                    cmbMaSP.SelectedValue = SelectedMaSP;
                }
            }

            if (!string.IsNullOrEmpty(SelectedMaKho) && dtKho.Rows.Count > 0)
            {
                var row = dtKho.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaKho") == SelectedMaKho);
                if (row != null)
                {
                    cmbMaKho.SelectedValue = SelectedMaKho;
                }
            }
        }

        /// <summary>
        /// Load thông tin tồn kho hiện tại và chi tiết SP/Kho
        /// </summary>
        private async Task LoadStockDetailsAsync()
        {
            // Kiểm tra đã chọn SP và Kho chưa
            if (cmbMaSP.SelectedValue == null || cmbMaKho.SelectedValue == null ||
                string.IsNullOrEmpty(cmbMaSP.SelectedValue.ToString()) ||
                string.IsNullOrEmpty(cmbMaKho.SelectedValue.ToString()))
            {
                CurrentStock = 0;
                txtSLCurent.Text = "0";
                txtTenSP.Text = "";
                txtTenKho.Text = "";
                numSLTrans.Value = 0;
                UpdateSLAfter();
                return;
            }

            SelectedMaSP = cmbMaSP.SelectedValue.ToString();
            SelectedMaKho = cmbMaKho.SelectedValue.ToString();

            // Lấy thông tin Sản phẩm
            DataRow spRow = dtSanPham.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaSP") == SelectedMaSP);
            txtTenSP.Text = spRow?["TenSP"]?.ToString() ?? "N/A";

            // Lấy thông tin Kho
            DataRow khoRow = dtKho.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaKho") == SelectedMaKho);
            txtTenKho.Text = khoRow?["TenKho"]?.ToString() ?? "N/A";

            // Lấy giá sản phẩm (dùng cho tính TriGia)
            decimal giaBan = spRow != null ? Convert.ToDecimal(spRow["GiaBanSP"]) : 0;
            numDonGia.Value = giaBan > 0 ? giaBan : 1000;

            // ✅ Lấy SỐ LƯỢNG TỒN HIỆN TẠI từ TONKHO
            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                await conn.OpenAsync();
                string stockQuery = @"
                    SELECT ISNULL(SLTonCuoiKy, 0) 
                    FROM TONKHO 
                    WHERE MaKho = @MaKho AND MaSP = @MaSP";

                using (SqlCommand cmd = new SqlCommand(stockQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKho", SelectedMaKho);
                    cmd.Parameters.AddWithValue("@MaSP", SelectedMaSP);

                    object result = await cmd.ExecuteScalarAsync();
                    CurrentStock = (result != null && result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
                    txtSLCurent.Text = CurrentStock.ToString("N0");
                }
            }

            UpdateSLAfter();
        }

        #endregion

        #region FORM SETUP

        /// <summary>
        /// Setup giao diện form (màu sắc, text, ẩn hiện controls)
        /// </summary>
        private void SetupForm()
        {
            // Thiết lập các trường ẩn
            dtpNgay.Value = DateTime.Now;
            txtSoPhieu.Text = GenerateTransactionID(IsImport ? "PN" : "PX");

            if (IsImport)
            {
                SetupImportMode();
            }
            else
            {
                SetupExportMode();
            }
        }

        /// <summary>
        /// Thiết lập cho chế độ NHẬP KHO (màu xanh lá)
        /// </summary>
        private void SetupImportMode()
        {
            this.Text = "Nhập kho";
            lblTitle.Text = "NHẬP KHO";
            lblTitle.ForeColor = ColorTranslator.FromHtml("#198754");

            lblSLTrans.Text = "SL nhập:";
            lblSLAfter.Text = "SL sau nhập:";

            btnSave.Text = "Nhập";
            btnSave.BackColor = ColorTranslator.FromHtml("#198754"); // Xanh lá
            btnClose.BackColor = ColorTranslator.FromHtml("#DC3545"); // Đỏ

            txtSLAfter.BackColor = ColorTranslator.FromHtml("#D4EDDA"); // Xanh nhạt
            txtSLAfter.ForeColor = ColorTranslator.FromHtml("#155724");

            txtNote.Text = "Nhập hàng từ bộ phân sản xuất";
        }

        /// <summary>
        /// Thiết lập cho chế độ XUẤT KHO (màu đỏ)
        /// </summary>
        private void SetupExportMode()
        {
            this.Text = "Xuất kho";
            lblTitle.Text = "XUẤT KHO";
            lblTitle.ForeColor = ColorTranslator.FromHtml("#DC3545");

            lblSLTrans.Text = "SL xuất:";
            lblSLAfter.Text = "SL sau xuất:";

            btnSave.Text = "Xuất";
            btnSave.BackColor = ColorTranslator.FromHtml("#DC3545"); // Đỏ
            btnClose.BackColor = ColorTranslator.FromHtml("#6C757D"); // Xám

            txtSLAfter.BackColor = ColorTranslator.FromHtml("#F8D7DA"); // Đỏ nhạt
            txtSLAfter.ForeColor = ColorTranslator.FromHtml("#721C24");

            txtNote.Text = "Xuất hàng bán cho khách hàng";
        }

        /// <summary>
        /// Tạo mã phiếu tự động
        /// </summary>
        private string GenerateTransactionID(string prefix)
        {
            return $"{prefix}{DateTime.Now:yyyyMMddHHmmss}";
        }

        #endregion

        #region EVENT HANDLERS

        private async void cmbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadStockDetailsAsync();
        }

        private async void cmbMaKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadStockDetailsAsync();
        }

        private void numSLTrans_ValueChanged(object sender, EventArgs e)
        {
            UpdateSLAfter();
        }

        #endregion

        #region CALCULATION

        /// <summary>
        /// ✅ CẬP NHẬT SỐ LƯỢNG SAU GIAO DỊCH
        /// NHẬP: SL hiện tại + SL nhập
        /// XUẤT: SL hiện tại - SL xuất
        /// </summary>
        private void UpdateSLAfter()
        {
            decimal slAfter = 0;

            if (IsImport)
            {
                // ✅ NHẬP KHO: TĂNG
                slAfter = CurrentStock + numSLTrans.Value;
                txtSLAfter.ForeColor = ColorTranslator.FromHtml("#155724");
                txtSLAfter.BackColor = ColorTranslator.FromHtml("#D4EDDA");
            }
            else
            {
                // ✅ XUẤT KHO: GIẢM
                slAfter = CurrentStock - numSLTrans.Value;

                // Cảnh báo nếu SL sau xuất < 0
                if (slAfter < 0)
                {
                    txtSLAfter.BackColor = Color.Red;
                    txtSLAfter.ForeColor = Color.White;
                }
                else
                {
                    txtSLAfter.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                    txtSLAfter.ForeColor = ColorTranslator.FromHtml("#721C24");
                }
            }

            txtSLAfter.Text = slAfter.ToString("N0");
        }

        #endregion

        #region SAVE TRANSACTION

        /// <summary>
        /// Nút LƯU (Nhập/Xuất)
        /// </summary>
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_isProcessing) return;

            if (!ValidateInput())
                return;

            try
            {
                _isProcessing = true;
                btnSave.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                bool success = IsImport
                    ? await ExecuteImportAsync()
                    : await ExecuteExportAsync();

                if (success)
                {
                    string action = IsImport ? "nhập" : "xuất";
                    decimal slAfter = IsImport ? CurrentStock + numSLTrans.Value : CurrentStock - numSLTrans.Value;

                    ShowSuccess(
                        $"✅ {(IsImport ? "Nhập" : "Xuất")} kho thành công",
                        $"Đã {action} {numSLTrans.Value:N0} sản phẩm!\n\n" +
                        $"📦 Sản phẩm: {txtTenSP.Text}\n" +
                        $"🏢 Kho: {txtTenKho.Text}\n" +
                        $"📊 SL trước: {CurrentStock:N0}\n" +
                        $"📊 SL sau: {slAfter:N0}"
                    );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi lưu phiếu", ex.Message);
            }
            finally
            {
                _isProcessing = false;
                btnSave.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Validate đầu vào
        /// </summary>
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(SelectedMaSP) || string.IsNullOrEmpty(SelectedMaKho))
            {
                ShowWarning("Vui lòng chọn Sản phẩm và Kho hàng!");
                return false;
            }

            if (numSLTrans.Value <= 0)
            {
                ShowWarning($"Số lượng {(IsImport ? "nhập" : "xuất")} phải lớn hơn 0!");
                numSLTrans.Focus();
                return false;
            }

            // ✅ KIỂM TRA KHI XUẤT: Phải đủ hàng
            if (!IsImport)
            {
                if (CurrentStock <= 0)
                {
                    ShowWarning("⚠️ Kho đã hết hàng!\nKhông thể thực hiện xuất kho.");
                    return false;
                }

                if (CurrentStock < numSLTrans.Value)
                {
                    ShowWarning(
                        $"⚠️ KHÔNG ĐỦ HÀNG ĐỂ XUẤT!\n\n" +
                        $"SL tồn hiện tại: {CurrentStock:N0}\n" +
                        $"SL muốn xuất: {numSLTrans.Value:N0}\n" +
                        $"Thiếu: {(numSLTrans.Value - CurrentStock):N0}"
                    );
                    numSLTrans.Focus();
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                ShowWarning("Vui lòng nhập Ghi chú/Lý do giao dịch!");
                txtNote.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// ✅ THỰC HIỆN NHẬP KHO (TĂNG tồn kho)
        /// </summary>
        private async Task<bool> ExecuteImportAsync()
        {
            decimal triGia = numDonGia.Value * numSLTrans.Value;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                await conn.OpenAsync();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // ✅ CẬP NHẬT TỒN KHO: TĂNG SL
                        await UpdateStockAsync(conn, trans, SelectedMaSP, (int)numSLTrans.Value, triGia, true);

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception($"Lỗi nhập kho: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// ✅ THỰC HIỆN XUẤT KHO (GIẢM tồn kho)
        /// </summary>
        private async Task<bool> ExecuteExportAsync()
        {
            decimal triGia = numDonGia.Value * numSLTrans.Value;

            using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                await conn.OpenAsync();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // ✅ CẬP NHẬT TỒN KHO: GIẢM SL
                        await UpdateStockAsync(conn, trans, SelectedMaSP, (int)numSLTrans.Value, triGia, false);

                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new Exception($"Lỗi xuất kho: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// ✅ CẬP NHẬT TỒN KHO TRONG DATABASE
        /// isIncrease = true  → NHẬP (SLTonCuoiKy = SLTonCuoiKy + SL)
        /// isIncrease = false → XUẤT (SLTonCuoiKy = SLTonCuoiKy - SL)
        /// </summary>
        private async Task UpdateStockAsync(SqlConnection conn, SqlTransaction trans, string maItem, int quantity, decimal value, bool isIncrease)
        {
            string maKho = SelectedMaKho;

            // Kiểm tra đã có record trong TONKHO chưa
            string checkQuery = "SELECT COUNT(*) FROM TONKHO WHERE MaKho = @MaKho AND MaSP = @MaSP";
            using (SqlCommand cmdCheck = new SqlCommand(checkQuery, conn, trans))
            {
                cmdCheck.Parameters.AddWithValue("@MaKho", maKho);
                cmdCheck.Parameters.AddWithValue("@MaSP", maItem);
                int count = (int)await cmdCheck.ExecuteScalarAsync();

                string updateQuery;

                if (count > 0)
                {
                    // ✅ ĐÃ TỒN TẠI → UPDATE
                    if (isIncrease)
                    {
                        // ✅ NHẬP KHO: TĂNG số lượng tồn
                        updateQuery = @"
                            UPDATE TONKHO 
                            SET SLTonCuoiKy = SLTonCuoiKy + @SL, 
                                SLNhapTrongKy = ISNULL(SLNhapTrongKy, 0) + @SL,
                                TGNhapTrongKy = ISNULL(TGNhapTrongKy, 0) + @TT, 
                                NgayCapNhatKho = @Ngay 
                            WHERE MaKho = @MaKho AND MaSP = @MaSP";
                    }
                    else
                    {
                        // ✅ XUẤT KHO: GIẢM số lượng tồn
                        updateQuery = @"
                            UPDATE TONKHO 
                            SET SLTonCuoiKy = SLTonCuoiKy - @SL, 
                                SLXuatTrongKy = ISNULL(SLXuatTrongKy, 0) + @SL,
                                TGXuatTrongKy = ISNULL(TGXuatTrongKy, 0) + @TT, 
                                NgayCapNhatKho = @Ngay 
                            WHERE MaKho = @MaKho AND MaSP = @MaSP";
                    }
                }
                else
                {
                    // ✅ CHƯA TỒN TẠI
                    if (isIncrease)
                    {
                        // NHẬP KHO: Tạo record mới
                        updateQuery = @"
                            INSERT INTO TONKHO (MaKho, MaSP, SLTonCuoiKy, TGNhapTrongKy, SLTonDauKy, SLNhapTrongKy, SLXuatTrongKy, TGXuatTrongKy, NgayCapNhatKho) 
                            VALUES (@MaKho, @MaSP, @SL, @TT, 0, @SL, 0, 0, @Ngay)";
                    }
                    else
                    {
                        // XUẤT KHO: Không cho phép
                        throw new InvalidOperationException("Sản phẩm chưa có tồn kho trong kho này! Không thể xuất.");
                    }
                }

                using (SqlCommand cmd = new SqlCommand(updateQuery, conn, trans))
                {
                    cmd.Parameters.AddWithValue("@MaKho", maKho);
                    cmd.Parameters.AddWithValue("@MaSP", maItem);
                    cmd.Parameters.AddWithValue("@SL", quantity);
                    cmd.Parameters.AddWithValue("@TT", value);
                    cmd.Parameters.AddWithValue("@Ngay", dtpNgay.Value.Date);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion

        #region BUTTON HANDLERS

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region HELPER METHODS

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "⚠️ Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string title, string message)
        {
            MessageBox.Show(message, "❌ " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}