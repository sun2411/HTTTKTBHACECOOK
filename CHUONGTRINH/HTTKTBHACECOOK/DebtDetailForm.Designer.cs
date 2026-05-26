namespace HTTKTBHACECOOK
{
    partial class DebtDetailForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.txtMaCN = new System.Windows.Forms.TextBox();
            this.lblDoiTuong = new System.Windows.Forms.Label();
            this.txtDoiTuong = new System.Windows.Forms.TextBox();
            this.lblSoTienNo = new System.Windows.Forms.Label();
            this.txtSoTienNo = new System.Windows.Forms.TextBox();
            this.lblDaTra = new System.Windows.Forms.Label();
            this.txtDaTra = new System.Windows.Forms.TextBox();
            this.lblConLai = new System.Windows.Forms.Label();
            this.txtConLai = new System.Windows.Forms.TextBox();
            this.lblNgayPS = new System.Windows.Forms.Label();
            this.txtNgayPS = new System.Windows.Forms.TextBox();
            this.lblHanTT = new System.Windows.Forms.Label();
            this.txtHanTT = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();

            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(23, 162, 184); // Info color
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(600, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHI TIẾT CÔNG NỢ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlContent
            this.pnlContent.Controls.Add(this.txtGhiChu);
            this.pnlContent.Controls.Add(this.lblGhiChu);
            this.pnlContent.Controls.Add(this.txtTrangThai);
            this.pnlContent.Controls.Add(this.lblTrangThai);
            this.pnlContent.Controls.Add(this.txtHanTT);
            this.pnlContent.Controls.Add(this.lblHanTT);
            this.pnlContent.Controls.Add(this.txtNgayPS);
            this.pnlContent.Controls.Add(this.lblNgayPS);
            this.pnlContent.Controls.Add(this.txtConLai);
            this.pnlContent.Controls.Add(this.lblConLai);
            this.pnlContent.Controls.Add(this.txtDaTra);
            this.pnlContent.Controls.Add(this.lblDaTra);
            this.pnlContent.Controls.Add(this.txtSoTienNo);
            this.pnlContent.Controls.Add(this.lblSoTienNo);
            this.pnlContent.Controls.Add(this.txtDoiTuong);
            this.pnlContent.Controls.Add(this.lblDoiTuong);
            this.pnlContent.Controls.Add(this.txtMaCN);
            this.pnlContent.Controls.Add(this.lblMaCN);
            this.pnlContent.Controls.Add(this.btnClose);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(600, 450);
            this.pnlContent.TabIndex = 1;

            // Helper to set label/textbox properties
            int startY = 20;
            int gapY = 40;

            // MaCN
            this.lblMaCN.Location = new System.Drawing.Point(50, startY);
            this.lblMaCN.Text = "Mã Công Nợ:";
            this.lblMaCN.AutoSize = true;
            this.txtMaCN.Location = new System.Drawing.Point(200, startY - 3);
            this.txtMaCN.Size = new System.Drawing.Size(350, 23);
            this.txtMaCN.ReadOnly = true;

            // DoiTuong
            this.lblDoiTuong.Location = new System.Drawing.Point(50, startY + gapY);
            this.lblDoiTuong.Text = "Đối Tượng:";
            this.lblDoiTuong.AutoSize = true;
            this.txtDoiTuong.Location = new System.Drawing.Point(200, startY + gapY - 3);
            this.txtDoiTuong.Size = new System.Drawing.Size(350, 23);
            this.txtDoiTuong.ReadOnly = true;

            // SoTienNo
            this.lblSoTienNo.Location = new System.Drawing.Point(50, startY + 2 * gapY);
            this.lblSoTienNo.Text = "Số Tiền Nợ:";
            this.lblSoTienNo.AutoSize = true;
            this.txtSoTienNo.Location = new System.Drawing.Point(200, startY + 2 * gapY - 3);
            this.txtSoTienNo.Size = new System.Drawing.Size(350, 23);
            this.txtSoTienNo.ReadOnly = true;

            // DaTra
            this.lblDaTra.Location = new System.Drawing.Point(50, startY + 3 * gapY);
            this.lblDaTra.Text = "Đã Trả:";
            this.lblDaTra.AutoSize = true;
            this.txtDaTra.Location = new System.Drawing.Point(200, startY + 3 * gapY - 3);
            this.txtDaTra.Size = new System.Drawing.Size(350, 23);
            this.txtDaTra.ReadOnly = true;

            // ConLai
            this.lblConLai.Location = new System.Drawing.Point(50, startY + 4 * gapY);
            this.lblConLai.Text = "Còn Lại:";
            this.lblConLai.AutoSize = true;
            this.txtConLai.Location = new System.Drawing.Point(200, startY + 4 * gapY - 3);
            this.txtConLai.Size = new System.Drawing.Size(350, 23);
            this.txtConLai.ReadOnly = true;
            this.txtConLai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // NgayPS
            this.lblNgayPS.Location = new System.Drawing.Point(50, startY + 5 * gapY);
            this.lblNgayPS.Text = "Ngày Phát Sinh:";
            this.lblNgayPS.AutoSize = true;
            this.txtNgayPS.Location = new System.Drawing.Point(200, startY + 5 * gapY - 3);
            this.txtNgayPS.Size = new System.Drawing.Size(350, 23);
            this.txtNgayPS.ReadOnly = true;

            // HanTT
            this.lblHanTT.Location = new System.Drawing.Point(50, startY + 6 * gapY);
            this.lblHanTT.Text = "Hạn Thanh Toán:";
            this.lblHanTT.AutoSize = true;
            this.txtHanTT.Location = new System.Drawing.Point(200, startY + 6 * gapY - 3);
            this.txtHanTT.Size = new System.Drawing.Size(350, 23);
            this.txtHanTT.ReadOnly = true;

            // TrangThai
            this.lblTrangThai.Location = new System.Drawing.Point(50, startY + 7 * gapY);
            this.lblTrangThai.Text = "Trạng Thái:";
            this.lblTrangThai.AutoSize = true;
            this.txtTrangThai.Location = new System.Drawing.Point(200, startY + 7 * gapY - 3);
            this.txtTrangThai.Size = new System.Drawing.Size(350, 23);
            this.txtTrangThai.ReadOnly = true;

            // GhiChu
            this.lblGhiChu.Location = new System.Drawing.Point(50, startY + 8 * gapY);
            this.lblGhiChu.Text = "Ghi Chú:";
            this.lblGhiChu.AutoSize = true;
            this.txtGhiChu.Location = new System.Drawing.Point(200, startY + 8 * gapY - 3);
            this.txtGhiChu.Size = new System.Drawing.Size(350, 60);
            this.txtGhiChu.ReadOnly = true;
            this.txtGhiChu.Multiline = true;

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(250, 400);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "DebtDetailForm";
            this.Text = "Chi tiết công nợ";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.TextBox txtMaCN;
        private System.Windows.Forms.Label lblDoiTuong;
        private System.Windows.Forms.TextBox txtDoiTuong;
        private System.Windows.Forms.Label lblSoTienNo;
        private System.Windows.Forms.TextBox txtSoTienNo;
        private System.Windows.Forms.Label lblDaTra;
        private System.Windows.Forms.TextBox txtDaTra;
        private System.Windows.Forms.Label lblConLai;
        private System.Windows.Forms.TextBox txtConLai;
        private System.Windows.Forms.Label lblNgayPS;
        private System.Windows.Forms.TextBox txtNgayPS;
        private System.Windows.Forms.Label lblHanTT;
        private System.Windows.Forms.TextBox txtHanTT;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
    }
}