namespace HTTKTBHACECOOK
{
    partial class InvoiceAddForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.colMaSP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.lblTongTienTitle = new System.Windows.Forms.Label();
            this.lblTongTienVal = new System.Windows.Forms.Label();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.cmbKhachHang = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblPTTT = new System.Windows.Forms.Label();
            this.cmbPhuongThucTT = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Controls.Add(this.pnlInfo);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.pnlButtons);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(984, 761);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvInvoiceDetails);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 240); // Đẩy xuống dưới pnlInfo
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrid.Size = new System.Drawing.Size(984, 441);
            this.pnlGrid.TabIndex = 2;
            // 
            // dgvInvoiceDetails
            // 
            this.dgvInvoiceDetails.AllowUserToResizeRows = false;
            this.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoiceDetails.ColumnHeadersHeight = 35;
            this.dgvInvoiceDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colTenSP,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceDetails.Location = new System.Drawing.Point(10, 10);
            this.dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            this.dgvInvoiceDetails.RowHeadersWidth = 30;
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(964, 421);
            this.dgvInvoiceDetails.TabIndex = 0;
            // 
            // colMaSP
            // 
            this.colMaSP.HeaderText = "Mã SP (Chọn)";
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMaSP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colTenSP
            // 
            this.colTenSP.HeaderText = "Tên Sản phẩm";
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.Width = 250;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.Name = "colSoLuong";
            // 
            // colDonGia
            // 
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlFooter.Controls.Add(this.lblGiamGia);
            this.pnlFooter.Controls.Add(this.txtGiamGia);
            this.pnlFooter.Controls.Add(this.lblTongTienTitle);
            this.pnlFooter.Controls.Add(this.lblTongTienVal);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 681);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(984, 80);
            this.pnlFooter.TabIndex = 3;
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGiamGia.Location = new System.Drawing.Point(20, 25);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(130, 23);
            this.lblGiamGia.TabIndex = 0;
            this.lblGiamGia.Text = "Giảm giá (VNĐ):";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGiamGia.Location = new System.Drawing.Point(160, 20);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(200, 32);
            this.txtGiamGia.TabIndex = 1;
            this.txtGiamGia.Text = "0";
            this.txtGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTongTienTitle
            // 
            this.lblTongTienTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienTitle.AutoSize = true;
            this.lblTongTienTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTienTitle.Location = new System.Drawing.Point(550, 20);
            this.lblTongTienTitle.Name = "lblTongTienTitle";
            this.lblTongTienTitle.Size = new System.Drawing.Size(166, 32);
            this.lblTongTienTitle.TabIndex = 2;
            this.lblTongTienTitle.Text = "TỔNG CỘNG:";
            // 
            // lblTongTienVal
            // 
            this.lblTongTienVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongTienVal.ForeColor = System.Drawing.Color.Red;
            this.lblTongTienVal.Location = new System.Drawing.Point(730, 15);
            this.lblTongTienVal.Name = "lblTongTienVal";
            this.lblTongTienVal.Size = new System.Drawing.Size(240, 40);
            this.lblTongTienVal.TabIndex = 3;
            this.lblTongTienVal.Text = "0 đ";
            this.lblTongTienVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblMaHD);
            this.pnlInfo.Controls.Add(this.txtMaHD);
            this.pnlInfo.Controls.Add(this.lblNgayLap);
            this.pnlInfo.Controls.Add(this.dtpNgayLap);
            this.pnlInfo.Controls.Add(this.lblKhachHang);
            this.pnlInfo.Controls.Add(this.cmbKhachHang);
            this.pnlInfo.Controls.Add(this.lblNhanVien);
            this.pnlInfo.Controls.Add(this.cmbNhanVien);
            this.pnlInfo.Controls.Add(this.lblPTTT);
            this.pnlInfo.Controls.Add(this.cmbPhuongThucTT);
            this.pnlInfo.Controls.Add(this.lblTrangThai);
            this.pnlInfo.Controls.Add(this.cmbTrangThai);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 60);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(984, 180); // Chiều cao cố định
            this.pnlInfo.TabIndex = 1;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMaHD.Location = new System.Drawing.Point(20, 20);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(111, 23);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã Hóa đơn:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMaHD.Location = new System.Drawing.Point(140, 15);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.ReadOnly = true;
            this.txtMaHD.Size = new System.Drawing.Size(300, 32);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNgayLap.Location = new System.Drawing.Point(500, 20);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(86, 23);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(620, 15);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(300, 32);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.Location = new System.Drawing.Point(20, 70);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(108, 23);
            this.lblKhachHang.TabIndex = 4;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // cmbKhachHang
            // 
            this.cmbKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhachHang.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbKhachHang.Location = new System.Drawing.Point(140, 65);
            this.cmbKhachHang.Name = "cmbKhachHang";
            this.cmbKhachHang.Size = new System.Drawing.Size(300, 33);
            this.cmbKhachHang.TabIndex = 5;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.Location = new System.Drawing.Point(20, 120);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(97, 23);
            this.lblNhanVien.TabIndex = 6;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbNhanVien.Location = new System.Drawing.Point(140, 115);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(300, 33);
            this.cmbNhanVien.TabIndex = 7;
            // 
            // lblPTTT
            // 
            this.lblPTTT.AutoSize = true;
            this.lblPTTT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPTTT.Location = new System.Drawing.Point(500, 70);
            this.lblPTTT.Name = "lblPTTT";
            this.lblPTTT.Size = new System.Drawing.Size(117, 23);
            this.lblPTTT.TabIndex = 8;
            this.lblPTTT.Text = "Thanh toán:";
            // 
            // cmbPhuongThucTT
            // 
            this.cmbPhuongThucTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhuongThucTT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbPhuongThucTT.Location = new System.Drawing.Point(620, 65);
            this.cmbPhuongThucTT.Name = "cmbPhuongThucTT";
            this.cmbPhuongThucTT.Size = new System.Drawing.Size(300, 33);
            this.cmbPhuongThucTT.TabIndex = 9;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.Location = new System.Drawing.Point(500, 120);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(97, 23);
            this.lblTrangThai.TabIndex = 10;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbTrangThai.Location = new System.Drawing.Point(620, 115);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(300, 33);
            this.cmbTrangThai.TabIndex = 11;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 60);
            this.pnlHeader.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(984, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TẠO HÓA ĐƠN MỚI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlButtons.Controls.Add(this.btnPrint);
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 701); // Xuống dưới cùng
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(984, 60);
            this.pnlButtons.TabIndex = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.Gray;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(660, 10);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "🖨 In";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(770, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(550, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // InvoiceAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.pnlFooter); // Footer nằm trên nút
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hóa đơn";
            this.Load += new System.EventHandler(this.InvoiceAddForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.DataGridViewComboBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label lblTongTienTitle;
        private System.Windows.Forms.Label lblTongTienVal;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cmbKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label lblPTTT;
        private System.Windows.Forms.ComboBox cmbPhuongThucTT;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}