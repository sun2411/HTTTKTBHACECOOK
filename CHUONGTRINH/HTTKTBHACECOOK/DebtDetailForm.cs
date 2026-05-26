using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace HTTKTBHACECOOK
{
    public partial class DebtDetailForm : Form
    {
        private string MaCN;
        private string CONNECTION_STRING;
        private bool IsReceivable;

        public DebtDetailForm(string connectionString, string maCN, bool isReceivable)
        {
            InitializeComponent();
            this.CONNECTION_STRING = connectionString;
            this.MaCN = maCN;
            this.IsReceivable = isReceivable;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    string query;

                    if (IsReceivable)
                    {
                        query = @"SELECT CN.*, KH.TenKH as DoiTuong 
                                  FROM CONGNO CN 
                                  LEFT JOIN KHACHHANG KH ON CN.MaKH = KH.MaKH 
                                  WHERE CN.MaCN = @MaCN";
                    }
                    else
                    {
                        query = @"SELECT CN.*, NCC.TenNCC as DoiTuong 
                                  FROM CONGNO CN 
                                  LEFT JOIN NHACUNGCAP NCC ON CN.MaNCC = NCC.MaNCC 
                                  WHERE CN.MaCN = @MaCN";
                    }

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaCN", MaCN);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtMaCN.Text = reader["MaCN"].ToString();
                        txtDoiTuong.Text = reader["DoiTuong"].ToString();

                        decimal soTienNo = Convert.ToDecimal(reader["SoTienNo"]);
                        decimal daTra = Convert.ToDecimal(reader["SoTienDaTra"]);
                        decimal conLai = soTienNo - daTra;

                        CultureInfo culture = CultureInfo.GetCultureInfo("vi-VN");
                        txtSoTienNo.Text = soTienNo.ToString("N0", culture) + " ₫";
                        txtDaTra.Text = daTra.ToString("N0", culture) + " ₫";
                        txtConLai.Text = conLai.ToString("N0", culture) + " ₫";

                        txtNgayPS.Text = Convert.ToDateTime(reader["NgayPhatSinh"]).ToString("dd/MM/yyyy");
                        txtHanTT.Text = Convert.ToDateTime(reader["HanThanhToan"]).ToString("dd/MM/yyyy");
                        txtTrangThai.Text = reader["TrangThai"].ToString();
                        txtGhiChu.Text = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}