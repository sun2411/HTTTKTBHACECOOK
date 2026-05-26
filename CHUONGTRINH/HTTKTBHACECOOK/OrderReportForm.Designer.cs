namespace HTTKTBHACECOOK
{
    partial class OrderReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblRevenueValue = new System.Windows.Forms.Label();
            this.lblRevenueLabel = new System.Windows.Forms.Label();
            this.lblProcessingValue = new System.Windows.Forms.Label();
            this.lblProcessingLabel = new System.Windows.Forms.Label();
            this.lblCompletedValue = new System.Windows.Forms.Label();
            this.lblCompletedLabel = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.MaDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoMatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlStatusSummary = new System.Windows.Forms.Panel();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.dgvStatusSummary = new System.Windows.Forms.DataGridView();
            this.TrangThaiCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyLeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoanhThuCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCustomerSummary = new System.Windows.Forms.Panel();
            this.lblCustomerTitle = new System.Windows.Forms.Label();
            this.dgvCustomerSummary = new System.Windows.Forms.DataGridView();
            this.KhachHangCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDonHangCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaTriCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.pnlStatusSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusSummary)).BeginInit();
            this.pnlCustomerSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1400, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO ĐƠN HÀNG";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.btnExport);
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Controls.Add(this.dtpEndDate);
            this.pnlFilter.Controls.Add(this.dtpStartDate);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 60);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlFilter.Size = new System.Drawing.Size(1400, 70);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(720, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 40);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "📊 Xuất file";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(590, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(460, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "🔍 Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(300, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(140, 27);
            this.dtpEndDate.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(60, 20);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(140, 27);
            this.dtpStartDate.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTo.Location = new System.Drawing.Point(250, 23);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 20);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "đến";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFrom.Location = new System.Drawing.Point(20, 23);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(25, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ";
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.lblRevenueValue);
            this.pnlStats.Controls.Add(this.lblRevenueLabel);
            this.pnlStats.Controls.Add(this.lblProcessingValue);
            this.pnlStats.Controls.Add(this.lblProcessingLabel);
            this.pnlStats.Controls.Add(this.lblCompletedValue);
            this.pnlStats.Controls.Add(this.lblCompletedLabel);
            this.pnlStats.Controls.Add(this.lblTotalValue);
            this.pnlStats.Controls.Add(this.lblTotalLabel);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 130);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlStats.Size = new System.Drawing.Size(1400, 80);
            this.pnlStats.TabIndex = 2;
            // 
            // lblRevenueValue
            // 
            this.lblRevenueValue.AutoSize = true;
            this.lblRevenueValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRevenueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.lblRevenueValue.Location = new System.Drawing.Point(892, 38);
            this.lblRevenueValue.Name = "lblRevenueValue";
            this.lblRevenueValue.Size = new System.Drawing.Size(75, 21);
            this.lblRevenueValue.TabIndex = 7;
            this.lblRevenueValue.Text = "0 VND";
            // 
            // lblRevenueLabel
            // 
            this.lblRevenueLabel.AutoSize = true;
            this.lblRevenueLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRevenueLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblRevenueLabel.Location = new System.Drawing.Point(892, 15);
            this.lblRevenueLabel.Name = "lblRevenueLabel";
            this.lblRevenueLabel.Size = new System.Drawing.Size(126, 19);
            this.lblRevenueLabel.TabIndex = 6;
            this.lblRevenueLabel.Text = "Tổng doanh thu:";
            // 
            // lblProcessingValue
            // 
            this.lblProcessingValue.AutoSize = true;
            this.lblProcessingValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProcessingValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblProcessingValue.Location = new System.Drawing.Point(624, 38);
            this.lblProcessingValue.Name = "lblProcessingValue";
            this.lblProcessingValue.Size = new System.Drawing.Size(19, 21);
            this.lblProcessingValue.TabIndex = 5;
            this.lblProcessingValue.Text = "0";
            // 
            // lblProcessingLabel
            // 
            this.lblProcessingLabel.AutoSize = true;
            this.lblProcessingLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProcessingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblProcessingLabel.Location = new System.Drawing.Point(624, 15);
            this.lblProcessingLabel.Name = "lblProcessingLabel";
            this.lblProcessingLabel.Size = new System.Drawing.Size(94, 19);
            this.lblProcessingLabel.TabIndex = 4;
            this.lblProcessingLabel.Text = "Đang xử lý:";
            // 
            // lblCompletedValue
            // 
            this.lblCompletedValue.AutoSize = true;
            this.lblCompletedValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCompletedValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.lblCompletedValue.Location = new System.Drawing.Point(356, 38);
            this.lblCompletedValue.Name = "lblCompletedValue";
            this.lblCompletedValue.Size = new System.Drawing.Size(19, 21);
            this.lblCompletedValue.TabIndex = 3;
            this.lblCompletedValue.Text = "0";
            // 
            // lblCompletedLabel
            // 
            this.lblCompletedLabel.AutoSize = true;
            this.lblCompletedLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCompletedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblCompletedLabel.Location = new System.Drawing.Point(356, 15);
            this.lblCompletedLabel.Name = "lblCompletedLabel";
            this.lblCompletedLabel.Size = new System.Drawing.Size(85, 19);
            this.lblCompletedLabel.TabIndex = 2;
            this.lblCompletedLabel.Text = "Đã giao:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.lblTotalValue.Location = new System.Drawing.Point(88, 38);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(19, 21);
            this.lblTotalValue.TabIndex = 1;
            this.lblTotalValue.Text = "0";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblTotalLabel.Location = new System.Drawing.Point(88, 15);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(127, 19);
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "Tổng đơn hàng:";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.dgvOrders);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 210);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.pnlMain.Size = new System.Drawing.Size(1400, 350);
            this.pnlMain.TabIndex = 3;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.AllowUserToResizeRows = false;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDH,
            this.KhachHang,
            this.NgayDat,
            this.NgayGiao,
            this.TrangThai,
            this.TongTien,
            this.SoMatHang});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.EnableHeadersVisualStyles = false;
            this.dgvOrders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvOrders.Location = new System.Drawing.Point(20, 20);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowTemplate.Height = 40;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(1360, 320);
            this.dgvOrders.TabIndex = 0;
            // 
            // MaDH
            // 
            this.MaDH.DataPropertyName = "MaDH";
            this.MaDH.FillWeight = 80F;
            this.MaDH.HeaderText = "Mã đơn hàng";
            this.MaDH.Name = "MaDH";
            this.MaDH.ReadOnly = true;
            // 
            // KhachHang
            // 
            this.KhachHang.DataPropertyName = "KhachHang";
            this.KhachHang.FillWeight = 150F;
            this.KhachHang.HeaderText = "Khách hàng";
            this.KhachHang.Name = "KhachHang";
            this.KhachHang.ReadOnly = true;
            // 
            // NgayDat
            // 
            this.NgayDat.DataPropertyName = "NgayDat";
            this.NgayDat.FillWeight = 80F;
            this.NgayDat.HeaderText = "Ngày đặt";
            this.NgayDat.Name = "NgayDat";
            this.NgayDat.ReadOnly = true;
            // 
            // NgayGiao
            // 
            this.NgayGiao.DataPropertyName = "NgayGiao";
            this.NgayGiao.FillWeight = 80F;
            this.NgayGiao.HeaderText = "Ngày giao";
            this.NgayGiao.Name = "NgayGiao";
            this.NgayGiao.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.FillWeight = 90F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.FillWeight = 100F;
            this.TongTien.HeaderText = "Tổng tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.ReadOnly = true;
            // 
            // SoMatHang
            // 
            this.SoMatHang.DataPropertyName = "SoMatHang";
            this.SoMatHang.FillWeight = 70F;
            this.SoMatHang.HeaderText = "Số mặt hàng";
            this.SoMatHang.Name = "SoMatHang";
            this.SoMatHang.ReadOnly = true;
            // 
            // pnlStatusSummary
            // 
            this.pnlStatusSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlStatusSummary.Controls.Add(this.lblStatusTitle);
            this.pnlStatusSummary.Controls.Add(this.dgvStatusSummary);
            this.pnlStatusSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusSummary.Location = new System.Drawing.Point(0, 560);
            this.pnlStatusSummary.Name = "pnlStatusSummary";
            this.pnlStatusSummary.Padding = new System.Windows.Forms.Padding(20, 0, 20, 10);
            this.pnlStatusSummary.Size = new System.Drawing.Size(1400, 120);
            this.pnlStatusSummary.TabIndex = 4;
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.AutoSize = true;
            this.lblStatusTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblStatusTitle.Location = new System.Drawing.Point(20, 5);
            this.lblStatusTitle.Name = "lblStatusTitle";
            this.lblStatusTitle.Size = new System.Drawing.Size(85, 20);
            this.lblStatusTitle.TabIndex = 1;
            this.lblStatusTitle.Text = "Trạng thái";
            // 
            // dgvStatusSummary
            // 
            this.dgvStatusSummary.AllowUserToAddRows = false;
            this.dgvStatusSummary.AllowUserToDeleteRows = false;
            this.dgvStatusSummary.AllowUserToResizeRows = false;
            this.dgvStatusSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatusSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatusSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatusSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStatusSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatusSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvStatusSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatusSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrangThaiCol,
            this.SoLuongCol,
            this.TyLeCol,
            this.DoanhThuCol});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatusSummary.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStatusSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvStatusSummary.EnableHeadersVisualStyles = false;
            this.dgvStatusSummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvStatusSummary.Location = new System.Drawing.Point(20, 30);
            this.dgvStatusSummary.Name = "dgvStatusSummary";
            this.dgvStatusSummary.ReadOnly = true;
            this.dgvStatusSummary.RowHeadersVisible = false;
            this.dgvStatusSummary.RowTemplate.Height = 35;
            this.dgvStatusSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatusSummary.Size = new System.Drawing.Size(1360, 80);
            this.dgvStatusSummary.TabIndex = 0;
            // 
            // TrangThaiCol
            // 
            this.TrangThaiCol.DataPropertyName = "TrangThai";
            this.TrangThaiCol.HeaderText = "Trạng thái";
            this.TrangThaiCol.Name = "TrangThaiCol";
            this.TrangThaiCol.ReadOnly = true;
            // 
            // SoLuongCol
            // 
            this.SoLuongCol.DataPropertyName = "SoLuong";
            this.SoLuongCol.HeaderText = "Số lượng";
            this.SoLuongCol.Name = "SoLuongCol";
            this.SoLuongCol.ReadOnly = true;
            // 
            // TyLeCol
            // 
            this.TyLeCol.DataPropertyName = "TyLe";
            this.TyLeCol.HeaderText = "Tỷ lệ (%)";
            this.TyLeCol.Name = "TyLeCol";
            this.TyLeCol.ReadOnly = true;
            // 
            // DoanhThuCol
            // 
            this.DoanhThuCol.DataPropertyName = "DoanhThu";
            this.DoanhThuCol.HeaderText = "Doanh thu";
            this.DoanhThuCol.Name = "DoanhThuCol";
            this.DoanhThuCol.ReadOnly = true;
            // 
            // pnlCustomerSummary
            // 
            this.pnlCustomerSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlCustomerSummary.Controls.Add(this.lblCustomerTitle);
            this.pnlCustomerSummary.Controls.Add(this.dgvCustomerSummary);
            this.pnlCustomerSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCustomerSummary.Location = new System.Drawing.Point(0, 680);
            this.pnlCustomerSummary.Name = "pnlCustomerSummary";
            this.pnlCustomerSummary.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.pnlCustomerSummary.Size = new System.Drawing.Size(1400, 120);
            this.pnlCustomerSummary.TabIndex = 5;
            // 
            // lblCustomerTitle
            // 
            this.lblCustomerTitle.AutoSize = true;
            this.lblCustomerTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCustomerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCustomerTitle.Location = new System.Drawing.Point(20, 5);
            this.lblCustomerTitle.Name = "lblCustomerTitle";
            this.lblCustomerTitle.Size = new System.Drawing.Size(91, 20);
            this.lblCustomerTitle.TabIndex = 1;
            this.lblCustomerTitle.Text = "Khách hàng";
            // 
            // dgvCustomerSummary
            // 
            this.dgvCustomerSummary.AllowUserToAddRows = false;
            this.dgvCustomerSummary.AllowUserToDeleteRows = false;
            this.dgvCustomerSummary.AllowUserToResizeRows = false;
            this.dgvCustomerSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomerSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomerSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomerSummary.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCustomerSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KhachHangCol,
            this.SoDonHangCol,
            this.TongGiaTriCol});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerSummary.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCustomerSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCustomerSummary.EnableHeadersVisualStyles = false;
            this.dgvCustomerSummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvCustomerSummary.Location = new System.Drawing.Point(20, 30);
            this.dgvCustomerSummary.Name = "dgvCustomerSummary";
            this.dgvCustomerSummary.ReadOnly = true;
            this.dgvCustomerSummary.RowHeadersVisible = false;
            this.dgvCustomerSummary.RowTemplate.Height = 35;
            this.dgvCustomerSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerSummary.Size = new System.Drawing.Size(1360, 70);
            this.dgvCustomerSummary.TabIndex = 0;
            // 
            // KhachHangCol
            // 
            this.KhachHangCol.DataPropertyName = "KhachHang";
            this.KhachHangCol.HeaderText = "Khách hàng";
            this.KhachHangCol.Name = "KhachHangCol";
            this.KhachHangCol.ReadOnly = true;
            // 
            // SoDonHangCol
            // 
            this.SoDonHangCol.DataPropertyName = "SoDonHang";
            this.SoDonHangCol.HeaderText = "Số đơn hàng";
            this.SoDonHangCol.Name = "SoDonHangCol";
            this.SoDonHangCol.ReadOnly = true;
            // 
            // TongGiaTriCol
            // 
            this.TongGiaTriCol.DataPropertyName = "TongGiaTri";
            this.TongGiaTriCol.HeaderText = "Tổng giá trị";
            this.TongGiaTriCol.Name = "TongGiaTriCol";
            this.TongGiaTriCol.ReadOnly = true;
            // 
            // OrderReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlStatusSummary);
            this.Controls.Add(this.pnlCustomerSummary);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.Name = "OrderReportForm";
            this.Text = "Báo cáo Đơn hàng";
            this.Load += new System.EventHandler(this.OrderReportForm_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.pnlStatusSummary.ResumeLayout(false);
            this.pnlStatusSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatusSummary)).EndInit();
            this.pnlCustomerSummary.ResumeLayout(false);
            this.pnlCustomerSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Label lblRevenueLabel;
        private System.Windows.Forms.Label lblProcessingValue;
        private System.Windows.Forms.Label lblProcessingLabel;
        private System.Windows.Forms.Label lblCompletedValue;
        private System.Windows.Forms.Label lblCompletedLabel;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoMatHang;
        private System.Windows.Forms.Panel pnlStatusSummary;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.DataGridView dgvStatusSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyLeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoanhThuCol;
        private System.Windows.Forms.Panel pnlCustomerSummary;
        private System.Windows.Forms.Label lblCustomerTitle;
        private System.Windows.Forms.DataGridView dgvCustomerSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhachHangCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDonHangCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaTriCol;
    }
}