using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing; // Thư viện in ấn
using System.Globalization;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class InventoryReport : Form
    {
        private string CONNECTION_STRING;
        private string searchPlaceholder = "Nhập mã SP, tên sản phẩm...";

        // Biến phục vụ in ấn
        private int printRowIndex = 0;
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        // Biến lưu tổng cộng cho báo cáo
        private decimal sumDauKy_SL = 0, sumDauKy_TT = 0;
        private decimal sumNhap_SL = 0, sumNhap_TT = 0;
        private decimal sumXuat_SL = 0, sumXuat_TT = 0;
        private decimal sumCuoiKy_SL = 0, sumCuoiKy_TT = 0;

        public InventoryReport(string connectionString)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;

            // Cấu hình in ấn: Khổ ngang (Landscape)
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void InventoryReport_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            SetupSearchPlaceholder();
            SetupComboBox();
            LoadInventoryData();
        }

        // --- 1. SETUP GIAO DIỆN ---

        private void SetupVisualStyling()
        {
            dgvInventory.AutoGenerateColumns = false;
            SetupButtonHoverEffects();

            // Cấu hình GridView
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // --- [CẬP NHẬT MỚI] ĐỊNH DẠNG CỘT SỐ LIỆU ---
            // Định dạng hiển thị tiền tệ/số lượng (N0 = có dấu phân cách ngàn, không số thập phân)

            // 1. Cột Giá: Căn phải, định dạng 1,000
            if (dgvInventory.Columns["Gia"] != null)
            {
                dgvInventory.Columns["Gia"].DefaultCellStyle.Format = "N0";
                dgvInventory.Columns["Gia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 2. Cột Giá Trị (Thành tiền): Căn phải, định dạng 1,000,000
            if (dgvInventory.Columns["GiaTri"] != null)
            {
                dgvInventory.Columns["GiaTri"].DefaultCellStyle.Format = "N0";
                dgvInventory.Columns["GiaTri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // 3. Cột Tồn Kho: Căn giữa, định dạng số
            if (dgvInventory.Columns["TonKho"] != null)
            {
                dgvInventory.Columns["TonKho"].DefaultCellStyle.Format = "N0";
                dgvInventory.Columns["TonKho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            // ---------------------------------------------

            // Sự kiện vẽ viền màu
            pnlTongGiaTri.Paint += (s, e) => DrawBorderLeft(e.Graphics, pnlTongGiaTri, Color.FromArgb(25, 135, 84));
            pnlSanPham.Paint += (s, e) => DrawBorderLeft(e.Graphics, pnlSanPham, Color.FromArgb(23, 162, 184));
            pnlConHang.Paint += (s, e) => DrawBorderLeft(e.Graphics, pnlConHang, Color.FromArgb(255, 193, 7));
            pnlNhaCungCap.Paint += (s, e) => DrawBorderLeft(e.Graphics, pnlNhaCungCap, Color.FromArgb(220, 53, 69));
        }

        private void DrawBorderLeft(Graphics g, Panel panel, Color color)
        {
            using (Pen pen = new Pen(color, 4))
            {
                g.DrawLine(pen, 0, 0, 0, panel.Height);
            }
        }

        private void SetupButtonHoverEffects()
        {
            SetButtonHover(btnSearch, "#0B5ED7", "#0D6EFD");
            SetButtonHover(btnRefresh, "#5A6268", "#6C757D");
            SetButtonHover(btnPrint, "#1E7E4E", "#198754");
        }

        private void SetButtonHover(Button btn, string hoverHex, string normalHex)
        {
            btn.MouseEnter += (s, e) => btn.BackColor = ColorTranslator.FromHtml(hoverHex);
            btn.MouseLeave += (s, e) => btn.BackColor = ColorTranslator.FromHtml(normalHex);
        }

        private void SetupSearchPlaceholder()
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");

            txtSearch.Enter += (sender, e) => {
                if (txtSearch.Text == searchPlaceholder) { txtSearch.Text = ""; txtSearch.ForeColor = ColorTranslator.FromHtml("#495057"); }
            };
            txtSearch.Leave += (sender, e) => {
                if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = searchPlaceholder; txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD"); }
            };
            txtSearch.KeyDown += (sender, e) => {
                if (e.KeyCode == Keys.Enter) { btnSearch_Click(sender, e); e.Handled = true; e.SuppressKeyPress = true; }
            };
        }

        private void SetupComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    conn.Open();
                    string query = "SELECT TenLoaiSP FROM LOAISANPHAM ORDER BY TenLoaiSP";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    dt.Rows.Add("Tất cả");
                    da.Fill(dt);

                    cmbLoaiSanPham.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TenLoaiSP"] != DBNull.Value)
                            cmbLoaiSanPham.Items.Add(row["TenLoaiSP"].ToString());
                    }
                    cmbLoaiSanPham.SelectedIndex = 0;
                }
            }
            catch
            {
                cmbLoaiSanPham.Items.Add("Tất cả");
                cmbLoaiSanPham.SelectedIndex = 0;
            }
            cmbLoaiSanPham.SelectedIndexChanged += (sender, e) => LoadInventoryData();
        }

        // --- 2. XỬ LÝ DỮ LIỆU & SQL ---

        private void LoadInventoryData(string keyword = "")
        {
            try
            {
                string loaiFilter = cmbLoaiSanPham.SelectedItem?.ToString() ?? "Tất cả";

                string query = @"
                    SELECT 
                        SP.MaSP,
                        SP.TenSP AS TenSanPham,
                        LSP.TenLoaiSP AS Loai,
                        ISNULL(DVT.TenDVTSP, N'Thùng') AS DonViTinh,
                        SP.GiaBanSP AS Gia,
                        
                        -- Lấy dữ liệu tồn kho (Nếu không có record trong TONKHO thì trả về 0)
                        ISNULL(SUM(TK.SLTonDauKy), 0) AS DauKy_SL,
                        ISNULL(SUM(TK.TGNhapDauKy), 0) AS DauKy_TT,

                        ISNULL(SUM(TK.SLNhapTrongKy), 0) AS Nhap_SL,
                        ISNULL(SUM(TK.TGNhapTrongKy), 0) AS Nhap_TT,

                        ISNULL(SUM(TK.SLXuatTrongKy), 0) AS Xuat_SL,
                        ISNULL(SUM(TK.TGXuatTrongKy), 0) AS Xuat_TT,

                        ISNULL(SUM(TK.SLTonCuoiKy), 0) AS TonKho,
                        ISNULL(SUM(TK.TGNhapDauKy + TK.TGNhapTrongKy - TK.TGXuatTrongKy), 0) AS GiaTri,

                        STUFF((
                            SELECT ', ' + K.TenKho + ': ' + FORMAT(TK2.SLTonCuoiKy, 'N0')
                            FROM TONKHO TK2 
                            JOIN KHO K ON TK2.MaKho = K.MaKho
                            WHERE TK2.MaSP = SP.MaSP AND TK2.SLTonCuoiKy > 0
                            FOR XML PATH('')
                        ), 1, 2, '') AS ChiTietTheoKho

                    FROM SANPHAM SP
                    LEFT JOIN LOAISANPHAM LSP ON SP.MaLoaiSP = LSP.MaLoaiSP
                    LEFT JOIN DVTSP DVT ON SP.MaSP = DVT.MaSP
                    LEFT JOIN TONKHO TK ON SP.MaSP = TK.MaSP
                    WHERE (@Keyword = '' 
                        OR SP.MaSP LIKE '%' + @Keyword + '%'
                        OR SP.TenSP LIKE N'%' + @Keyword + '%') 
                    AND (@LoaiFilter = N'Tất cả' OR LSP.TenLoaiSP = @LoaiFilter)
                    GROUP BY SP.MaSP, SP.TenSP, LSP.TenLoaiSP, DVT.TenDVTSP, SP.GiaBanSP
                    ORDER BY SP.MaSP";

                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Keyword", (txtSearch.Text == searchPlaceholder) ? "" : txtSearch.Text.Trim());
                    adapter.SelectCommand.Parameters.AddWithValue("@LoaiFilter", loaiFilter);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvInventory.DataSource = dt;

                    UpdateStatistics(dt);
                    ApplyRowColors();
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi tải dữ liệu", ex.Message);
            }
        }

        private void ApplyRowColors()
        {
            dgvInventory.ClearSelection();

            foreach (DataGridViewRow row in dgvInventory.Rows)
            {
                if (row.Cells["TonKho"].Value != null)
                {
                    if (int.TryParse(row.Cells["TonKho"].Value.ToString(), out int tonKho))
                    {
                        // HẾT HÀNG: Nền Hồng Nhạt, Chữ Đỏ
                        if (tonKho <= 0)
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE6E6");
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            row.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                            row.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F5C6CB");
                            row.DefaultCellStyle.SelectionForeColor = Color.Red;

                            if (row.Cells["ChiTietTheoKho"].Value == null || row.Cells["ChiTietTheoKho"].Value.ToString() == "")
                            {
                                row.Cells["ChiTietTheoKho"].Value = "Hết hàng trên toàn hệ thống";
                            }
                        }
                        // SẮP HẾT: Nền Vàng nhạt
                        else if (tonKho < 100)
                        {
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
                            row.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#856404");
                            row.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FFE69C");
                            row.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#856404");
                        }
                    }
                }
            }
        }

        private void UpdateStatistics(DataTable dt)
        {
            decimal totalValue = 0;
            int totalProducts = dt.Rows.Count;
            int inStockCount = 0;
            int outOfStockCount = 0;

            sumDauKy_SL = 0; sumDauKy_TT = 0;
            sumNhap_SL = 0; sumNhap_TT = 0;
            sumXuat_SL = 0; sumXuat_TT = 0;
            sumCuoiKy_SL = 0; sumCuoiKy_TT = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["GiaTri"] != DBNull.Value) totalValue += Convert.ToDecimal(row["GiaTri"]);

                sumDauKy_SL += Convert.ToDecimal(row["DauKy_SL"] ?? 0);
                sumDauKy_TT += Convert.ToDecimal(row["DauKy_TT"] ?? 0);
                sumNhap_SL += Convert.ToDecimal(row["Nhap_SL"] ?? 0);
                sumNhap_TT += Convert.ToDecimal(row["Nhap_TT"] ?? 0);
                sumXuat_SL += Convert.ToDecimal(row["Xuat_SL"] ?? 0);
                sumXuat_TT += Convert.ToDecimal(row["Xuat_TT"] ?? 0);
                sumCuoiKy_SL += Convert.ToDecimal(row["TonKho"] ?? 0);
                sumCuoiKy_TT += Convert.ToDecimal(row["GiaTri"] ?? 0);

                if (row["TonKho"] != DBNull.Value)
                {
                    int tonKho = Convert.ToInt32(row["TonKho"]);
                    if (tonKho > 0) inStockCount++;
                    else outOfStockCount++;
                }
            }

            lblTongGiaTriValue.Text = totalValue.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            lblSanPhamValue.Text = totalProducts.ToString();
            lblConHangValue.Text = inStockCount.ToString();
            lblNhaCungCapValue.Text = outOfStockCount.ToString();
        }

        // --- 3. XỬ LÝ SỰ KIỆN NÚT ---

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInventoryData((txtSearch.Text == searchPlaceholder) ? "" : txtSearch.Text.Trim());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = searchPlaceholder;
            txtSearch.ForeColor = ColorTranslator.FromHtml("#ADB5BD");
            if (cmbLoaiSanPham.Items.Count > 0) cmbLoaiSanPham.SelectedIndex = 0;
            LoadInventoryData();
            ShowSuccess("Đã làm mới dữ liệu!");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvInventory.Rows.Count == 0)
            {
                ShowInfo("Thông báo", "Không có dữ liệu để in.");
                return;
            }

            printRowIndex = 0;
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Width = 1200;
            printPreviewDialog.Height = 800;
            printPreviewDialog.StartPosition = FormStartPosition.CenterScreen;
            printPreviewDialog.ShowDialog();
        }

        // --- 4. LOGIC IN ẤN: BÁO CÁO NHẬP - XUẤT - TỒN ---

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Font và Màu
            Font fontHeader = new Font("Times New Roman", 16, FontStyle.Bold);
            Font fontSubHeader = new Font("Times New Roman", 13, FontStyle.Bold);
            Font fontNormal = new Font("Times New Roman", 10, FontStyle.Regular);
            Font fontSmallBold = new Font("Times New Roman", 9, FontStyle.Bold);
            Font fontFooter = new Font("Times New Roman", 11, FontStyle.Bold);
            Font fontItalic = new Font("Times New Roman", 11, FontStyle.Italic);

            Brush brushText = Brushes.Black;
            Pen penLine = new Pen(Color.Black, 1);
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
            StringFormat leftFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };

            // Thông số trang in
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float pageWidth = e.PageBounds.Width; // Lấy chiều rộng TOÀN BỘ trang giấy
            float rowHeight = 25;

            // --- 1. HEADER BÁO CÁO (CĂN GIỮA TUYỆT ĐỐI) ---
            if (printRowIndex == 0)
            {
                RectangleF fullPageRect = new RectangleF(0, y, pageWidth, 30);

                // Tên công ty
                e.Graphics.DrawString("CÔNG TY CỔ PHẦN ACECOOK VIỆT NAM", fontSubHeader, Brushes.Red, fullPageRect, centerFormat);
                y += 35;

                // Tiêu đề báo cáo
                fullPageRect.Y = y;
                e.Graphics.DrawString("BÁO CÁO NHẬP - XUẤT - TỒN KHO HÀNG HÓA", fontHeader, Brushes.Navy, fullPageRect, centerFormat);
                y += 35;

                // Tháng/Năm
                fullPageRect.Y = y;
                e.Graphics.DrawString($"Tháng {DateTime.Now.Month}/{DateTime.Now.Year}", fontItalic, Brushes.Black, fullPageRect, centerFormat);
                y += 40;
            }

            // --- 2. CẤU TRÚC CỘT ---
            float[] colWidths = { 40, 200, 50, 70, 90, 70, 90, 70, 90, 70, 90 };
            float startX = x;
            float headerH = 50;

            // --- 3. VẼ HEADER BẢNG ---
            e.Graphics.DrawRectangle(penLine, x, y, colWidths[0], headerH);
            e.Graphics.DrawString("STT", fontSmallBold, brushText, new RectangleF(x, y, colWidths[0], headerH), centerFormat);
            x += colWidths[0];

            e.Graphics.DrawRectangle(penLine, x, y, colWidths[1], headerH);
            e.Graphics.DrawString("Tên Sản Phẩm", fontSmallBold, brushText, new RectangleF(x, y, colWidths[1], headerH), centerFormat);
            x += colWidths[1];

            e.Graphics.DrawRectangle(penLine, x, y, colWidths[2], headerH);
            e.Graphics.DrawString("ĐVT", fontSmallBold, brushText, new RectangleF(x, y, colWidths[2], headerH), centerFormat);
            x += colWidths[2];

            DrawGroupHeader(e.Graphics, "Tồn đầu kỳ", x, y, colWidths[3] + colWidths[4], fontSmallBold); x += colWidths[3] + colWidths[4];
            DrawGroupHeader(e.Graphics, "Nhập trong kỳ", x, y, colWidths[5] + colWidths[6], fontSmallBold); x += colWidths[5] + colWidths[6];
            DrawGroupHeader(e.Graphics, "Xuất trong kỳ", x, y, colWidths[7] + colWidths[8], fontSmallBold); x += colWidths[7] + colWidths[8];
            DrawGroupHeader(e.Graphics, "Tồn cuối kỳ", x, y, colWidths[9] + colWidths[10], fontSmallBold);

            y += 25;
            x = startX + colWidths[0] + colWidths[1] + colWidths[2];

            for (int i = 0; i < 4; i++)
            {
                e.Graphics.DrawRectangle(penLine, x, y, colWidths[3 + i * 2], 25);
                e.Graphics.DrawString("SL", fontSmallBold, brushText, new RectangleF(x, y, colWidths[3 + i * 2], 25), centerFormat);
                x += colWidths[3 + i * 2];

                e.Graphics.DrawRectangle(penLine, x, y, colWidths[4 + i * 2], 25);
                e.Graphics.DrawString("Thành tiền", fontSmallBold, brushText, new RectangleF(x, y, colWidths[4 + i * 2], 25), centerFormat);
                x += colWidths[4 + i * 2];
            }
            y += 25;

            // --- 4. VẼ DÒNG DỮ LIỆU ---
            while (printRowIndex < dgvInventory.Rows.Count)
            {
                if (y + rowHeight > e.MarginBounds.Bottom) { e.HasMorePages = true; return; }

                DataRowView rowView = (DataRowView)dgvInventory.Rows[printRowIndex].DataBoundItem;
                DataRow row = rowView.Row;
                x = startX;

                e.Graphics.DrawRectangle(penLine, x, y, colWidths[0], rowHeight);
                e.Graphics.DrawString((printRowIndex + 1).ToString(), fontNormal, brushText, new RectangleF(x, y, colWidths[0], rowHeight), centerFormat);
                x += colWidths[0];

                e.Graphics.DrawRectangle(penLine, x, y, colWidths[1], rowHeight);
                e.Graphics.DrawString(row["TenSanPham"].ToString(), fontNormal, brushText, new RectangleF(x + 2, y, colWidths[1] - 4, rowHeight), leftFormat);
                x += colWidths[1];

                e.Graphics.DrawRectangle(penLine, x, y, colWidths[2], rowHeight);
                e.Graphics.DrawString(row["DonViTinh"].ToString(), fontNormal, brushText, new RectangleF(x, y, colWidths[2], rowHeight), centerFormat);
                x += colWidths[2];

                DrawNumberCell(e.Graphics, row["DauKy_SL"], x, y, colWidths[3], rowHeight); x += colWidths[3];
                DrawNumberCell(e.Graphics, row["DauKy_TT"], x, y, colWidths[4], rowHeight); x += colWidths[4];
                DrawNumberCell(e.Graphics, row["Nhap_SL"], x, y, colWidths[5], rowHeight); x += colWidths[5];
                DrawNumberCell(e.Graphics, row["Nhap_TT"], x, y, colWidths[6], rowHeight); x += colWidths[6];
                DrawNumberCell(e.Graphics, row["Xuat_SL"], x, y, colWidths[7], rowHeight); x += colWidths[7];
                DrawNumberCell(e.Graphics, row["Xuat_TT"], x, y, colWidths[8], rowHeight); x += colWidths[8];
                DrawNumberCell(e.Graphics, row["TonKho"], x, y, colWidths[9], rowHeight); x += colWidths[9];
                DrawNumberCell(e.Graphics, row["GiaTri"], x, y, colWidths[10], rowHeight); x += colWidths[10];

                y += rowHeight;
                printRowIndex++;
            }

            // --- 5. TỔNG CỘNG ---
            x = startX;
            float totalWidthText = colWidths[0] + colWidths[1] + colWidths[2];
            Brush brushTotal = new SolidBrush(Color.FromArgb(200, 230, 255));

            e.Graphics.FillRectangle(brushTotal, x, y, totalWidthText, rowHeight);
            e.Graphics.DrawRectangle(penLine, x, y, totalWidthText, rowHeight);
            e.Graphics.DrawString("TỔNG CỘNG", new Font("Times New Roman", 10, FontStyle.Bold), brushText, new RectangleF(x, y, totalWidthText, rowHeight), centerFormat);
            x += totalWidthText;

            DrawTotalCell(e.Graphics, sumDauKy_SL, x, y, colWidths[3], rowHeight, brushTotal); x += colWidths[3];
            DrawTotalCell(e.Graphics, sumDauKy_TT, x, y, colWidths[4], rowHeight, brushTotal); x += colWidths[4];
            DrawTotalCell(e.Graphics, sumNhap_SL, x, y, colWidths[5], rowHeight, brushTotal); x += colWidths[5];
            DrawTotalCell(e.Graphics, sumNhap_TT, x, y, colWidths[6], rowHeight, brushTotal); x += colWidths[6];
            DrawTotalCell(e.Graphics, sumXuat_SL, x, y, colWidths[7], rowHeight, brushTotal); x += colWidths[7];
            DrawTotalCell(e.Graphics, sumXuat_TT, x, y, colWidths[8], rowHeight, brushTotal); x += colWidths[8];
            DrawTotalCell(e.Graphics, sumCuoiKy_SL, x, y, colWidths[9], rowHeight, brushTotal); x += colWidths[9];
            DrawTotalCell(e.Graphics, sumCuoiKy_TT, x, y, colWidths[10], rowHeight, brushTotal); x += colWidths[10];

            y += rowHeight + 40;

            // --- 6. FOOTER CHỮ KÝ ---

            float rightSectionX = e.MarginBounds.Right - 300;
            float leftSectionX = e.MarginBounds.Left + 50;

            // 1. Dòng Ngày tháng (ĐỂ TRỐNG)
            string dateStr = "..............., ngày ...... tháng ...... năm .........";

            RectangleF dateRect = new RectangleF(rightSectionX, y, 300, 25);
            e.Graphics.DrawString(dateStr, fontItalic, brushText, dateRect, centerFormat);
            y += 30;

            // 2. Chức danh
            e.Graphics.DrawString("KẾ TOÁN TRƯỞNG", fontFooter, brushText, new RectangleF(leftSectionX, y, 200, 25), centerFormat);
            e.Graphics.DrawString("NGƯỜI LẬP BIỂU", fontFooter, brushText, new RectangleF(rightSectionX, y, 300, 25), centerFormat);
            y += 25;

            // 3. Ghi chú ký tên
            e.Graphics.DrawString("(Ký, ghi rõ họ tên)", fontItalic, brushText, new RectangleF(leftSectionX, y, 200, 25), centerFormat);
            e.Graphics.DrawString("(Ký, ghi rõ họ tên)", fontItalic, brushText, new RectangleF(rightSectionX, y, 300, 25), centerFormat);

            e.HasMorePages = false;
        }

        // --- HELPER VẼ ---
        private void DrawGroupHeader(Graphics g, string text, float x, float y, float w, Font font)
        {
            g.FillRectangle(Brushes.LightGray, x, y, w, 25);
            g.DrawRectangle(Pens.Black, x, y, w, 25);
            g.DrawString(text, font, Brushes.Black, new RectangleF(x, y, w, 25), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        private void DrawNumberCell(Graphics g, object value, float x, float y, float w, float h)
        {
            decimal val = Convert.ToDecimal(value);
            g.DrawRectangle(Pens.Black, x, y, w, h);
            g.DrawString(val.ToString("N0"), new Font("Times New Roman", 10), Brushes.Black, new RectangleF(x, y, w - 5, h), new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
        }

        private void DrawTotalCell(Graphics g, decimal val, float x, float y, float w, float h, Brush bg)
        {
            g.FillRectangle(bg, x, y, w, h);
            g.DrawRectangle(Pens.Black, x, y, w, h);
            g.DrawString(val.ToString("N0"), new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, new RectangleF(x, y, w - 5, h), new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
        }

        // --- 5. HELPER METHODS ---

        private void ShowSuccess(string message) => MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void ShowError(string title, string message) => MessageBox.Show(message, "❌ " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void ShowInfo(string title, string message) => MessageBox.Show(message, "ℹ️ " + title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}