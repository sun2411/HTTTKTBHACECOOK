using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class CustomerDetailForm : Form
    {
        private string MaKH;
        private string CONNECTION_STRING;

        public CustomerDetailForm(string maKH, string connectionString)
        {
            InitializeComponent();
            this.MaKH = maKH;
            this.CONNECTION_STRING = connectionString;
            this.Text = "Chi tiết Khách hàng: " + maKH;

            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {
            // Truy vấn lấy TẤT CẢ thông tin chi tiết, bao gồm cả Công nợ và Ghi chú.
            string query = @"
                SELECT 
                    KH.MaKH,
                    KH.TenKH,
                    KH.SDTKH,
                    KH.EmailKH,
                    KH.DiaChiKH,
                    LKH.TenLoaiKH, 
                    KH.MSTKH,
                    KH.STKKH,
                    KH.CongNoKH, 
                    KH.GhiChuKH  
                FROM KHACHHANG KH
                INNER JOIN LOAIKHACHHANG LKH ON KH.MaLoaiKH = LKH.MaLoaiKH
                WHERE KH.MaKH = @MaKH";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaKH", MaKH);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Gán dữ liệu vào các Label giá trị (lblValue_...)
                                lblValue_MaKH.Text = reader["MaKH"].ToString();
                                lblValue_TenKH.Text = reader["TenKH"].ToString();
                                lblValue_SDT.Text = reader["SDTKH"].ToString();
                                lblValue_Email.Text = reader["EmailKH"].ToString();
                                lblValue_DiaChi.Text = reader["DiaChiKH"].ToString();
                                lblValue_LoaiKH.Text = reader["TenLoaiKH"].ToString();

                                // Xử lý các trường có thể là NULL (MST, STK, GhiChu)
                                lblValue_MST.Text = reader["MSTKH"] == DBNull.Value ? "N/A" : reader["MSTKH"].ToString();
                                lblValue_STK.Text = reader["STKKH"] == DBNull.Value ? "N/A" : reader["STKKH"].ToString();

                                // Định dạng tiền tệ cho Công nợ
                                double congNo = reader["CongNoKH"] != DBNull.Value ? Convert.ToDouble(reader["CongNoKH"]) : 0;
                                lblValue_CongNo.Text = string.Format("{0:N0} VNĐ", congNo);

                                lblValue_GhiChu.Text = reader["GhiChuKH"] == DBNull.Value ? "" : reader["GhiChuKH"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy dữ liệu khách hàng. Vui lòng kiểm tra lại MaKH.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Lỗi truy vấn CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}