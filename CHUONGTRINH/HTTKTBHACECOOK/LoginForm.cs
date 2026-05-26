using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace HTTKTBHACECOOK
{
    public partial class LoginForm : Form
    {
        // 🚨 CHUỖI KẾT NỐI 
        private const string CONNECTION_STRING = "Data Source=DESKTOP-Q1UORLL\\DESKTOP;Initial Catalog=QLKTBHACECOOK;Persist Security Info=True;User ID=sa;Password=123";

        public LoginForm()
        {
            InitializeComponent();
            // Thiết lập bo tròn cho các panel
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            SetupVisualStyling();
            SetupPlaceholders();
            ApplyRoundedCorners();
        }

        private void SetupVisualStyling()
        {
            // Header: Xanh dương đậm (#0066CC)
            this.pnlHeader.BackColor = ColorTranslator.FromHtml("#0066CC");

            // Logo: Đỏ Acecook (#D40000)
            //this.picLogo.BackColor = ColorTranslator.FromHtml("#D40000");

            // Tiêu đề: Trắng (#FFFFFF)
            this.lblTitle.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            // Nút Đăng nhập: Xanh tươi (#0085FF, chữ trắng)
            this.btn_Login.BackColor = ColorTranslator.FromHtml("#0085FF");
            this.btn_Login.ForeColor = ColorTranslator.FromHtml("#FFFFFF");

            // Mật khẩu che
            this.txtPassword.PasswordChar = '•';

            // Background cho form chính
            this.pnlMain.BackColor = ColorTranslator.FromHtml("#F0F4F8");

            // Box đăng nhập trắng với shadow (giả lập bằng border)
            this.pnlLoginBox.BackColor = Color.White;
        }

        private void ApplyRoundedCorners()
        {
            // Bo tròn cho Login Box
            MakeRoundedPanel(pnlLoginBox, 15);

            // Bo tròn cho các input panel
            MakeRoundedPanel(pnlUsername, 8);
            MakeRoundedPanel(pnlPassword, 8);

            // Bo tròn cho nút đăng nhập
            MakeRoundedButton(btn_Login, 8);
        }

        private void MakeRoundedPanel(Panel panel, int radius)
        {
            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = GetRoundedRectPath(panel.ClientRectangle, radius))
                {
                    panel.Region = new Region(path);
                }
            };
        }

        private void MakeRoundedButton(Button button, int radius)
        {
            button.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = GetRoundedRectPath(button.ClientRectangle, radius))
                {
                    button.Region = new Region(path);
                }
            };
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        // --- Logic Placeholder ---

        private void SetupPlaceholders()
        {
            SetPlaceholder(txtUsername, "Nhập tên đăng nhập");
            SetPlaceholder(txtPassword, "Nhập mật khẩu");
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Tag = placeholderText;
            textBox.Text = placeholderText;
            textBox.ForeColor = ColorTranslator.FromHtml("#AAAAAA");
        }

        private void RemovePlaceholder(TextBox textBox)
        {
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
                textBox.ForeColor = ColorTranslator.FromHtml("#212121");
            }
        }

        // Xử lý sự kiện Enter và Leave cho txtUsername
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtUsername);
            pnlUsername.BackColor = ColorTranslator.FromHtml("#E8F0FE");
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                SetPlaceholder(txtUsername, txtUsername.Tag.ToString());
            }
            pnlUsername.BackColor = ColorTranslator.FromHtml("#F5F7FA");
        }

        // Xử lý sự kiện Enter và Leave cho txtPassword
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtPassword);
            pnlPassword.BackColor = ColorTranslator.FromHtml("#E8F0FE");
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                SetPlaceholder(txtPassword, txtPassword.Tag.ToString());
            }
            pnlPassword.BackColor = ColorTranslator.FromHtml("#F5F7FA");
        }

        // --- Hiệu ứng hover cho nút ---
        private void btn_Login_MouseEnter(object sender, EventArgs e)
        {
            btn_Login.BackColor = ColorTranslator.FromHtml("#006FE6");
        }

        private void btn_Login_MouseLeave(object sender, EventArgs e)
        {
            btn_Login.BackColor = ColorTranslator.FromHtml("#0085FF");
        }

        // --- Logic Xử lý sự kiện chính ---

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string placeholderUser = txtUsername.Tag.ToString();
            string placeholderPass = txtPassword.Tag.ToString();

            // Kiểm tra rỗng hoặc còn giữ giá trị placeholder
            if (string.IsNullOrWhiteSpace(username) || username == placeholderUser ||
                string.IsNullOrWhiteSpace(password) || password == placeholderPass)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SỬA ĐỔI: Hàm AuthenticateUser giờ đây trả về 3 giá trị (bool, MaVT, HoTenNV)
            (bool isAuthenticated, string maVaiTro, string hoTenNV) = AuthenticateUser(username, password);

            if (isAuthenticated)
            {
                // SỬA ĐỔI: HIỂN THỊ TÊN NHÂN VIÊN
                MessageBox.Show($"Đăng nhập thành công! Xin chào: {hoTenNV}.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // LOGIC CHUYỂN FORM ĐÃ ĐƯỢC CẬP NHẬT
                try
                {
                    // Khởi tạo DashboardForm, truyền dữ liệu người dùng
                    DashboardForm dashboard = new DashboardForm(maVaiTro, hoTenNV);

                    this.Hide(); // Ẩn LoginForm
                    dashboard.ShowDialog(); // Hiển thị Dashboard dưới dạng Modal

                    // Nếu DashboardForm bị đóng, đóng luôn LoginForm
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải DashboardForm. Lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng, hoặc tài khoản đang bị khóa.",
                    "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// SỬA ĐỔI: Hàm xác thực người dùng, trả về Mã Vai Trò (MaVT) VÀ Tên Nhân Viên (HoTenNV)
        /// </summary>
        private (bool isAuthenticated, string maVaiTro, string hoTenNV) AuthenticateUser(string username, string password)
        {
            // THÊM BẢNG NHANVIEN VÀ TRUY VẤN CỘT N.HoTenNV
            string query =
                "SELECT T.MaVT, T.TrangThaiTK, N.HoTenNV, N.MaNV " +
                "FROM TAIKHOAN T INNER JOIN NHANVIEN N ON T.MaNV = N.MaNV " +
                "WHERE T.TenDangNhap = @Username AND T.MatKhau = @Password";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string trangThai = reader["TrangThaiTK"].ToString().Trim();
                                string hoTenNV = reader["HoTenNV"].ToString().Trim(); // Lấy tên nhân viên
                                string maVaiTro = reader["MaVT"].ToString().Trim();

                                // Kiểm tra trạng thái tài khoản. Tài khoản phải ở trạng thái 'Hoạt động'
                                if (trangThai == "Hoạt động")
                                {
                                    // TRẢ VỀ CẢ TÊN NHÂN VIÊN VÀ MÃ VAI TRÒ
                                    return (true, maVaiTro, hoTenNV);
                                }
                                else
                                {
                                    // Tài khoản tồn tại nhưng bị khóa
                                    return (false, null, null);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Lỗi kết nối CSDL: {ex.Message}. Vui lòng kiểm tra lại chuỗi kết nối.",
                            "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi chung: {ex.Message}.", "Lỗi hệ thống",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Không tìm thấy tài khoản hoặc mật khẩu sai
            return (false, null, null);
        }
    }
}