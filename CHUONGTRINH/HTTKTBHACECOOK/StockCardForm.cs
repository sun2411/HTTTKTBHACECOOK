using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class StockCardForm : Form
    {
        private string CONNECTION_STRING;
        private string MaSP;
        private string MaKho;
        private string TenSP;

        // Constructor nhận các thông tin cần thiết để truy vấn thẻ kho
        public StockCardForm(string connectionString, string maSP, string tenSP, string maKho, string tenKho)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaSP = maSP;
            this.MaKho = maKho;
            this.TenSP = tenSP;

            lblTitle.Text = $"THẺ KHO: {tenSP.ToUpper()}";
            lblSubTitle.Text = $"Kho: {tenKho} | Mã SP: {maSP}";

            LoadStockHistory();
        }

        private void LoadStockHistory()
        {
            // Sử dụng View V_LichSu_NhapXuatKho để lấy lịch sử giao dịch
            string query = @"
                SELECT 
                    LoaiPhieu, 
                    SoPhieu, 
                    NgayThucHien, 
                    SoLuong, 
                    DonGia, 
                    ThanhTien, 
                    GhiChu
                FROM V_LichSu_NhapXuatKho
                WHERE MaHang = @MaSP AND MaKho = @MaKho
                ORDER BY NgayThucHien DESC";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSP", MaSP);
                    command.Parameters.AddWithValue("@MaKho", MaKho);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvHistory.DataSource = dt;
                    FormatGrid();
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu không load được dữ liệu (ví dụ: View không tồn tại, kết nối lỗi)
                    MessageBox.Show("Lỗi tải lịch sử (Kiểm tra lại View SQL): " + ex.Message, "Lỗi Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormatGrid()
        {
            // ÁP DỤNG LẬP TRÌNH PHÒNG THỦ: Kiểm tra cột tồn tại trước khi định dạng
            if (dgvHistory.Columns.Count == 0) return;

            // LoaiPhieu
            if (dgvHistory.Columns.Contains("LoaiPhieu"))
            {
                var colLoaiPhieu = dgvHistory.Columns["LoaiPhieu"];
                if (colLoaiPhieu != null)
                {
                    colLoaiPhieu.HeaderText = "Loại";
                    colLoaiPhieu.Width = 80;
                }
            }

            // SoPhieu
            if (dgvHistory.Columns.Contains("SoPhieu"))
            {
                var colSoPhieu = dgvHistory.Columns["SoPhieu"];
                if (colSoPhieu != null)
                {
                    colSoPhieu.HeaderText = "Số Phiếu";
                }
            }

            // NgayThucHien
            if (dgvHistory.Columns.Contains("NgayThucHien"))
            {
                var colNgay = dgvHistory.Columns["NgayThucHien"];
                if (colNgay != null)
                {
                    colNgay.HeaderText = "Ngày";
                    colNgay.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }

            // SoLuong
            if (dgvHistory.Columns.Contains("SoLuong"))
            {
                var colSL = dgvHistory.Columns["SoLuong"];
                if (colSL != null)
                {
                    colSL.HeaderText = "Số Lượng";
                    colSL.DefaultCellStyle.Format = "N0";
                    colSL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            // ThanhTien
            if (dgvHistory.Columns.Contains("ThanhTien"))
            {
                var colTT = dgvHistory.Columns["ThanhTien"];
                if (colTT != null)
                {
                    colTT.HeaderText = "Thành Tiền";
                    colTT.DefaultCellStyle.Format = "N0";
                    colTT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }

            // GhiChu
            if (dgvHistory.Columns.Contains("GhiChu"))
            {
                var colGC = dgvHistory.Columns["GhiChu"];
                if (colGC != null)
                {
                    colGC.HeaderText = "Diễn giải";
                    colGC.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }

            // Ẩn cột DonGia (nếu có)
            if (dgvHistory.Columns.Contains("DonGia")) dgvHistory.Columns["DonGia"].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}