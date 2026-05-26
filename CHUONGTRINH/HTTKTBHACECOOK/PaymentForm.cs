using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class PaymentForm : Form
    {
        private string CONNECTION_STRING;
        private string MaCN;
        private decimal ConLai;

        public PaymentForm(string connectionString, string maCN, string conLaiText)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaCN = maCN;

            // Parse remaining amount from text (remove '₫' and formatting)
            string cleanAmount = conLaiText.Replace(" ₫", "").Replace(".", "").Trim();
            if (decimal.TryParse(cleanAmount, out decimal val))
                this.ConLai = val;
            else
                this.ConLai = 0;

            txtMaCN.Text = MaCN;
            txtConLai.Text = conLaiText;
            txtSoTienTra.TextChanged += TxtSoTienTra_TextChanged;
        }

        private void TxtSoTienTra_TextChanged(object sender, EventArgs e)
        {
            // Format input as currency
            if (decimal.TryParse(txtSoTienTra.Text.Replace(",", "").Replace(".", ""), out decimal amount))
            {
                // Remove existing event handler to avoid recursion
                txtSoTienTra.TextChanged -= TxtSoTienTra_TextChanged;
                txtSoTienTra.Text = amount.ToString("N0");
                txtSoTienTra.SelectionStart = txtSoTienTra.Text.Length;
                txtSoTienTra.TextChanged += TxtSoTienTra_TextChanged;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSoTienTra.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal paymentAmount;
            if (!decimal.TryParse(txtSoTienTra.Text.Replace(".", ""), out paymentAmount) || paymentAmount <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (paymentAmount > ConLai)
            {
                MessageBox.Show("Số tiền trả không được lớn hơn số nợ còn lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();

                    // 1. Update CONGNO table
                    // We increase SoTienDaTra. Status update logic depends on if fully paid.
                    string query = @"
                        UPDATE CONGNO 
                        SET SoTienDaTra = SoTienDaTra + @PaymentAmount,
                            TrangThai = CASE 
                                WHEN (SoTienNo - (SoTienDaTra + @PaymentAmount)) <= 0 THEN N'Đã thanh toán đủ'
                                ELSE N'Đã thanh toán một phần'
                            END
                        WHERE MaCN = @MaCN";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                        cmd.Parameters.AddWithValue("@MaCN", MaCN);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy công nợ để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Note: Ideally, you should also insert into a 'LichSuThanhToan' table here if you had one.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}