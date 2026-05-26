namespace HTTKTBHACECOOK
{
    partial class OrderAddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlDetailGrid = new System.Windows.Forms.Panel();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblTongTriGia = new System.Windows.Forms.Label();
            this.lblTitle_TongTriGia = new System.Windows.Forms.Label();
            this.txtPhuPhi = new System.Windows.Forms.TextBox();
            this.lblTitle_PhuPhi = new System.Windows.Forms.Label();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.pnlHeaderInfo = new System.Windows.Forms.Panel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle_MaDDH = new System.Windows.Forms.Label();
            this.txtMaDDH = new System.Windows.Forms.TextBox();
            this.lblTitle_MaKH = new System.Windows.Forms.Label();
            this.cmbKhachHang = new System.Windows.Forms.ComboBox();
            this.lblTitle_NgayDat = new System.Windows.Forms.Label();
            this.dtpNgayDat = new System.Windows.Forms.DateTimePicker();
            this.lblTitle_TrangThai = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTitle_NgayGiao = new System.Windows.Forms.Label();
            this.dtpNgayGiao = new System.Windows.Forms.DateTimePicker();
            this.lblTitle_GhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlDetailGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.pnlHeaderInfo.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlDetailGrid);
            this.pnlMain.Controls.Add(this.pnlHeaderInfo);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(950, 750);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlDetailGrid
            // 
            this.pnlDetailGrid.Controls.Add(this.dgvOrderDetails);
            this.pnlDetailGrid.Controls.Add(this.pnlSummary);
            this.pnlDetailGrid.Controls.Add(this.lblDetailTitle);
            this.pnlDetailGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDetailGrid.Location = new System.Drawing.Point(15, 305);
            this.pnlDetailGrid.Name = "pnlDetailGrid";
            this.pnlDetailGrid.Size = new System.Drawing.Size(920, 390);
            this.pnlDetailGrid.TabIndex = 4;
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvOrderDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderDetails.Location = new System.Drawing.Point(0, 30);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.RowTemplate.Height = 30;
            this.dgvOrderDetails.Size = new System.Drawing.Size(920, 300);
            this.dgvOrderDetails.TabIndex = 1;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.lblTongTriGia);
            this.pnlSummary.Controls.Add(this.lblTitle_TongTriGia);
            this.pnlSummary.Controls.Add(this.txtPhuPhi);
            this.pnlSummary.Controls.Add(this.lblTitle_PhuPhi);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSummary.Location = new System.Drawing.Point(0, 330);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(920, 60);
            this.pnlSummary.TabIndex = 2;
            // 
            // lblTongTriGia
            // 
            this.lblTongTriGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTriGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTriGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongTriGia.Location = new System.Drawing.Point(740, 30);
            this.lblTongTriGia.Name = "lblTongTriGia";
            this.lblTongTriGia.Size = new System.Drawing.Size(180, 25);
            this.lblTongTriGia.TabIndex = 3;
            this.lblTongTriGia.Text = "0";
            this.lblTongTriGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle_TongTriGia
            // 
            this.lblTitle_TongTriGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle_TongTriGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_TongTriGia.Location = new System.Drawing.Point(600, 30);
            this.lblTitle_TongTriGia.Name = "lblTitle_TongTriGia";
            this.lblTitle_TongTriGia.Size = new System.Drawing.Size(134, 25);
            this.lblTitle_TongTriGia.TabIndex = 2;
            this.lblTitle_TongTriGia.Text = "TỔNG TRỊ GIÁ ĐH:";
            this.lblTitle_TongTriGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhuPhi
            // 
            this.txtPhuPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhuPhi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhuPhi.Location = new System.Drawing.Point(740, 2);
            this.txtPhuPhi.Name = "txtPhuPhi";
            this.txtPhuPhi.Size = new System.Drawing.Size(180, 27);
            this.txtPhuPhi.TabIndex = 1;
            this.txtPhuPhi.Text = "0";
            this.txtPhuPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTitle_PhuPhi
            // 
            this.lblTitle_PhuPhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle_PhuPhi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_PhuPhi.Location = new System.Drawing.Point(600, 5);
            this.lblTitle_PhuPhi.Name = "lblTitle_PhuPhi";
            this.lblTitle_PhuPhi.Size = new System.Drawing.Size(134, 25);
            this.lblTitle_PhuPhi.TabIndex = 0;
            this.lblTitle_PhuPhi.Text = "Phụ phí / Vận chuyển:";
            this.lblTitle_PhuPhi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(920, 30);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "CHI TIẾT SẢN PHẨM (Mặt hàng)";
            this.lblDetailTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlHeaderInfo
            // 
            this.pnlHeaderInfo.Controls.Add(this.tlpHeader);
            this.pnlHeaderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderInfo.Location = new System.Drawing.Point(15, 65);
            this.pnlHeaderInfo.Name = "pnlHeaderInfo";
            this.pnlHeaderInfo.Size = new System.Drawing.Size(920, 240);
            this.pnlHeaderInfo.TabIndex = 3;
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 4;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpHeader.Controls.Add(this.lblTitle_MaDDH, 0, 0);
            this.tlpHeader.Controls.Add(this.txtMaDDH, 1, 0);
            this.tlpHeader.Controls.Add(this.lblTitle_MaKH, 0, 1);
            this.tlpHeader.Controls.Add(this.cmbKhachHang, 1, 1);
            this.tlpHeader.Controls.Add(this.lblTitle_NgayDat, 2, 0);
            this.tlpHeader.Controls.Add(this.dtpNgayDat, 3, 0);
            this.tlpHeader.Controls.Add(this.lblTitle_TrangThai, 2, 1);
            this.tlpHeader.Controls.Add(this.cmbTrangThai, 3, 1);
            this.tlpHeader.Controls.Add(this.lblTitle_NgayGiao, 2, 2);
            this.tlpHeader.Controls.Add(this.dtpNgayGiao, 3, 2);
            this.tlpHeader.Controls.Add(this.lblTitle_GhiChu, 0, 3);
            this.tlpHeader.Controls.Add(this.txtGhiChu, 1, 3);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 4;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpHeader.Size = new System.Drawing.Size(920, 240);
            this.tlpHeader.TabIndex = 0;
            // 
            // lblTitle_MaDDH
            // 
            this.lblTitle_MaDDH.AutoSize = true;
            this.lblTitle_MaDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_MaDDH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_MaDDH.Location = new System.Drawing.Point(3, 0);
            this.lblTitle_MaDDH.Name = "lblTitle_MaDDH";
            this.lblTitle_MaDDH.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_MaDDH.TabIndex = 0;
            this.lblTitle_MaDDH.Text = "Mã Đơn hàng:";
            this.lblTitle_MaDDH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaDDH
            // 
            this.txtMaDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaDDH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDDH.Location = new System.Drawing.Point(141, 6);
            this.txtMaDDH.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtMaDDH.Name = "txtMaDDH";
            this.txtMaDDH.ReadOnly = true;
            this.txtMaDDH.Size = new System.Drawing.Size(316, 27);
            this.txtMaDDH.TabIndex = 1;
            // 
            // lblTitle_MaKH
            // 
            this.lblTitle_MaKH.AutoSize = true;
            this.lblTitle_MaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_MaKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_MaKH.Location = new System.Drawing.Point(3, 40);
            this.lblTitle_MaKH.Name = "lblTitle_MaKH";
            this.lblTitle_MaKH.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_MaKH.TabIndex = 2;
            this.lblTitle_MaKH.Text = "Khách hàng (*):";
            this.lblTitle_MaKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbKhachHang
            // 
            this.cmbKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKhachHang.FormattingEnabled = true;
            this.cmbKhachHang.Location = new System.Drawing.Point(141, 47);
            this.cmbKhachHang.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.cmbKhachHang.Name = "cmbKhachHang";
            this.cmbKhachHang.Size = new System.Drawing.Size(316, 25);
            this.cmbKhachHang.TabIndex = 3;
            // 
            // lblTitle_NgayDat
            // 
            this.lblTitle_NgayDat.AutoSize = true;
            this.lblTitle_NgayDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_NgayDat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_NgayDat.Location = new System.Drawing.Point(463, 0);
            this.lblTitle_NgayDat.Name = "lblTitle_NgayDat";
            this.lblTitle_NgayDat.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_NgayDat.TabIndex = 4;
            this.lblTitle_NgayDat.Text = "Ngày đặt (*):";
            this.lblTitle_NgayDat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayDat
            // 
            this.dtpNgayDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayDat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDat.Location = new System.Drawing.Point(601, 6);
            this.dtpNgayDat.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.dtpNgayDat.Name = "dtpNgayDat";
            this.dtpNgayDat.Size = new System.Drawing.Size(316, 27);
            this.dtpNgayDat.TabIndex = 5;
            // 
            // lblTitle_TrangThai
            // 
            this.lblTitle_TrangThai.AutoSize = true;
            this.lblTitle_TrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_TrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_TrangThai.Location = new System.Drawing.Point(463, 40);
            this.lblTitle_TrangThai.Name = "lblTitle_TrangThai";
            this.lblTitle_TrangThai.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_TrangThai.TabIndex = 6;
            this.lblTitle_TrangThai.Text = "Trạng thái (*):";
            this.lblTitle_TrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Location = new System.Drawing.Point(601, 47);
            this.cmbTrangThai.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(316, 25);
            this.cmbTrangThai.TabIndex = 7;
            // 
            // lblTitle_NgayGiao
            // 
            this.lblTitle_NgayGiao.AutoSize = true;
            this.lblTitle_NgayGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_NgayGiao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_NgayGiao.Location = new System.Drawing.Point(463, 80);
            this.lblTitle_NgayGiao.Name = "lblTitle_NgayGiao";
            this.lblTitle_NgayGiao.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_NgayGiao.TabIndex = 8;
            this.lblTitle_NgayGiao.Text = "Ngày giao:";
            this.lblTitle_NgayGiao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayGiao
            // 
            this.dtpNgayGiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayGiao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayGiao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayGiao.Location = new System.Drawing.Point(601, 86);
            this.dtpNgayGiao.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.dtpNgayGiao.Name = "dtpNgayGiao";
            this.dtpNgayGiao.Size = new System.Drawing.Size(316, 27);
            this.dtpNgayGiao.TabIndex = 9;
            // 
            // lblTitle_GhiChu
            // 
            this.lblTitle_GhiChu.AutoSize = true;
            this.lblTitle_GhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_GhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_GhiChu.Location = new System.Drawing.Point(3, 120);
            this.lblTitle_GhiChu.Name = "lblTitle_GhiChu";
            this.lblTitle_GhiChu.Size = new System.Drawing.Size(132, 120);
            this.lblTitle_GhiChu.TabIndex = 10;
            this.lblTitle_GhiChu.Text = "Ghi chú:";
            this.lblTitle_GhiChu.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // txtGhiChu
            // 
            this.tlpHeader.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(141, 126);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(776, 111);
            this.txtGhiChu.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(700, 705);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(920, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "LẬP ĐƠN ĐẶT HÀNG MỚI";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(830, 705);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // OrderAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 750);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lập đơn đặt hàng";
            this.Load += new System.EventHandler(this.OrderAddEditForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlDetailGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.pnlHeaderInfo.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlHeaderInfo;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Label lblTitle_MaDDH;
        private System.Windows.Forms.TextBox txtMaDDH;
        private System.Windows.Forms.Label lblTitle_MaKH;
        private System.Windows.Forms.ComboBox cmbKhachHang;
        private System.Windows.Forms.Label lblTitle_NgayDat;
        private System.Windows.Forms.DateTimePicker dtpNgayDat;
        private System.Windows.Forms.Label lblTitle_TrangThai;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Label lblTitle_NgayGiao;
        private System.Windows.Forms.DateTimePicker dtpNgayGiao;
        private System.Windows.Forms.Label lblTitle_GhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Panel pnlDetailGrid;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblTongTriGia;
        private System.Windows.Forms.Label lblTitle_TongTriGia;
        private System.Windows.Forms.TextBox txtPhuPhi;
        private System.Windows.Forms.Label lblTitle_PhuPhi;
    }
}