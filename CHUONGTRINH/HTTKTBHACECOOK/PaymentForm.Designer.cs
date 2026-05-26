namespace HTTKTBHACECOOK
{
    partial class PaymentForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.txtMaCN = new System.Windows.Forms.TextBox();
            this.lblConLai = new System.Windows.Forms.Label();
            this.txtConLai = new System.Windows.Forms.TextBox();
            this.lblSoTienTra = new System.Windows.Forms.Label();
            this.txtSoTienTra = new System.Windows.Forms.TextBox();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();

            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 193, 7); // Warning color (Yellow)
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(500, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THANH TOÁN CÔNG NỢ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlContent
            this.pnlContent.Controls.Add(this.txtGhiChu);
            this.pnlContent.Controls.Add(this.lblGhiChu);
            this.pnlContent.Controls.Add(this.dtpNgayTra);
            this.pnlContent.Controls.Add(this.lblNgayTra);
            this.pnlContent.Controls.Add(this.txtSoTienTra);
            this.pnlContent.Controls.Add(this.lblSoTienTra);
            this.pnlContent.Controls.Add(this.txtConLai);
            this.pnlContent.Controls.Add(this.lblConLai);
            this.pnlContent.Controls.Add(this.txtMaCN);
            this.pnlContent.Controls.Add(this.lblMaCN);
            this.pnlContent.Controls.Add(this.btnSave);
            this.pnlContent.Controls.Add(this.btnCancel);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(500, 350);
            this.pnlContent.TabIndex = 1;

            // Inputs
            int startY = 20;
            int gapY = 40;

            this.lblMaCN.Location = new System.Drawing.Point(30, startY);
            this.lblMaCN.Text = "Mã Công Nợ:";
            this.lblMaCN.AutoSize = true;
            this.txtMaCN.Location = new System.Drawing.Point(150, startY - 3);
            this.txtMaCN.Size = new System.Drawing.Size(300, 23);
            this.txtMaCN.ReadOnly = true;

            this.lblConLai.Location = new System.Drawing.Point(30, startY + gapY);
            this.lblConLai.Text = "Nợ Còn Lại:";
            this.lblConLai.AutoSize = true;
            this.txtConLai.Location = new System.Drawing.Point(150, startY + gapY - 3);
            this.txtConLai.Size = new System.Drawing.Size(300, 23);
            this.txtConLai.ReadOnly = true;
            this.txtConLai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblSoTienTra.Location = new System.Drawing.Point(30, startY + 2 * gapY);
            this.lblSoTienTra.Text = "Số Tiền Trả (*):";
            this.lblSoTienTra.AutoSize = true;
            this.txtSoTienTra.Location = new System.Drawing.Point(150, startY + 2 * gapY - 3);
            this.txtSoTienTra.Size = new System.Drawing.Size(300, 23);

            this.lblNgayTra.Location = new System.Drawing.Point(30, startY + 3 * gapY);
            this.lblNgayTra.Text = "Ngày Trả (*):";
            this.lblNgayTra.AutoSize = true;
            this.dtpNgayTra.Location = new System.Drawing.Point(150, startY + 3 * gapY - 3);
            this.dtpNgayTra.Size = new System.Drawing.Size(300, 23);
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblGhiChu.Location = new System.Drawing.Point(30, startY + 4 * gapY);
            this.lblGhiChu.Text = "Ghi Chú:";
            this.lblGhiChu.AutoSize = true;
            this.txtGhiChu.Location = new System.Drawing.Point(150, startY + 4 * gapY - 3);
            this.txtGhiChu.Size = new System.Drawing.Size(300, 50);
            this.txtGhiChu.Multiline = true;

            // Buttons
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(25, 135, 84); // Success green
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(150, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.Text = "Xác nhận";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(270, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "PaymentForm";
            this.Text = "Thanh toán";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.TextBox txtMaCN;
        private System.Windows.Forms.Label lblConLai;
        private System.Windows.Forms.TextBox txtConLai;
        private System.Windows.Forms.Label lblSoTienTra;
        private System.Windows.Forms.TextBox txtSoTienTra;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
    }
}