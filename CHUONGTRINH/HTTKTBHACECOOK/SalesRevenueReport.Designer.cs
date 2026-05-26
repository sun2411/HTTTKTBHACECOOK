namespace HTTKTBHACECOOK
{
    partial class SalesRevenueReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.lblReportType = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlProfit = new System.Windows.Forms.Panel();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblProfitIcon = new System.Windows.Forms.Label();
            this.pnlCost = new System.Windows.Forms.Panel();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblCostIcon = new System.Windows.Forms.Label();
            this.pnlRevenue = new System.Windows.Forms.Panel();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblRevenueIcon = new System.Windows.Forms.Label();
            this.pnlOrders = new System.Windows.Forms.Panel();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblOrdersIcon = new System.Windows.Forms.Label();
            this.pnlDataGrid = new System.Windows.Forms.Panel();
            this.tabControlReport = new System.Windows.Forms.TabControl();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.Summary_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary_Orders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary_Revenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary_Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary_Margin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageByProduct = new System.Windows.Forms.TabPage();
            this.dgvByProduct = new System.Windows.Forms.DataGridView();
            this.Product_MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_DoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_TyLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageByCustomer = new System.Windows.Forms.TabPage();
            this.dgvByCustomer = new System.Windows.Forms.DataGridView();
            this.Customer_MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_SoDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_LoaiKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageByEmployee = new System.Windows.Forms.TabPage();
            this.dgvByEmployee = new System.Windows.Forms.DataGridView();
            this.Employee_MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_SoDonHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_DoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee_TyLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageCharts = new System.Windows.Forms.TabPage();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlProfit.SuspendLayout();
            this.pnlCost.SuspendLayout();
            this.pnlRevenue.SuspendLayout();
            this.pnlOrders.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            this.tabControlReport.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.tabPageByProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByProduct)).BeginInit();
            this.tabPageByCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByCustomer)).BeginInit();
            this.tabPageByEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvByEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(38, 31, 38, 23);
            this.pnlHeader.Size = new System.Drawing.Size(1626, 108);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPageTitle.Location = new System.Drawing.Point(38, 31);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(1050, 54);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "📊  BÁO CÁO DOANH THU BÁN HÀNG";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.cmbReportType);
            this.pnlFilter.Controls.Add(this.lblReportType);
            this.pnlFilter.Controls.Add(this.dtpEndDate);
            this.pnlFilter.Controls.Add(this.lblToDate);
            this.pnlFilter.Controls.Add(this.dtpStartDate);
            this.pnlFilter.Controls.Add(this.lblDateRange);
            this.pnlFilter.Controls.Add(this.btnExport);
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.btnGenerate);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 108);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(38, 23, 38, 23);
            this.pnlFilter.Size = new System.Drawing.Size(1626, 108);
            this.pnlFilter.TabIndex = 1;
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Theo ngày",
            "Theo tuần",
            "Theo tháng",
            "Theo quý",
            "Theo năm"});
            this.cmbReportType.Location = new System.Drawing.Point(1371, 31);
            this.cmbReportType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(193, 36);
            this.cmbReportType.TabIndex = 8;
            // 
            // lblReportType
            // 
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblReportType.Location = new System.Drawing.Point(1284, 18);
            this.lblReportType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(60, 62);
            this.lblReportType.TabIndex = 7;
            this.lblReportType.Text = "📈";
            this.lblReportType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(352, 31);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(178, 33);
            this.dtpEndDate.TabIndex = 6;
            // 
            // lblToDate
            // 
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblToDate.Location = new System.Drawing.Point(300, 28);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(45, 43);
            this.lblToDate.TabIndex = 5;
            this.lblToDate.Text = "➜";
            this.lblToDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(112, 31);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(178, 33);
            this.dtpStartDate.TabIndex = 4;
            // 
            // lblDateRange
            // 
            this.lblDateRange.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDateRange.Location = new System.Drawing.Point(38, 18);
            this.lblDateRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(68, 62);
            this.lblDateRange.TabIndex = 3;
            this.lblDateRange.Text = "📅";
            this.lblDateRange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1064, 23);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(180, 62);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "📊  Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(847, 23);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 62);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "🔄  Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(548, 23);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(277, 62);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "🔍  Xem báo cáo";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlStats.Controls.Add(this.pnlProfit);
            this.pnlStats.Controls.Add(this.pnlCost);
            this.pnlStats.Controls.Add(this.pnlRevenue);
            this.pnlStats.Controls.Add(this.pnlOrders);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 216);
            this.pnlStats.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(38, 23, 38, 23);
            this.pnlStats.Size = new System.Drawing.Size(1626, 123);
            this.pnlStats.TabIndex = 2;
            // 
            // pnlProfit
            // 
            this.pnlProfit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.pnlProfit.Controls.Add(this.lblProfit);
            this.pnlProfit.Controls.Add(this.lblProfitIcon);
            this.pnlProfit.Location = new System.Drawing.Point(1230, 23);
            this.pnlProfit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlProfit.Name = "pnlProfit";
            this.pnlProfit.Size = new System.Drawing.Size(345, 77);
            this.pnlProfit.TabIndex = 3;
            // 
            // lblProfit
            // 
            this.lblProfit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfit.ForeColor = System.Drawing.Color.White;
            this.lblProfit.Location = new System.Drawing.Point(75, 15);
            this.lblProfit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(255, 46);
            this.lblProfit.TabIndex = 1;
            this.lblProfit.Text = "Lãi: 0 ₫";
            this.lblProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProfitIcon
            // 
            this.lblProfitIcon.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfitIcon.ForeColor = System.Drawing.Color.White;
            this.lblProfitIcon.Location = new System.Drawing.Point(8, 8);
            this.lblProfitIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProfitIcon.Name = "lblProfitIcon";
            this.lblProfitIcon.Size = new System.Drawing.Size(60, 62);
            this.lblProfitIcon.TabIndex = 0;
            this.lblProfitIcon.Text = "💎";
            this.lblProfitIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCost
            // 
            this.pnlCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(126)))), ((int)(((byte)(20)))));
            this.pnlCost.Controls.Add(this.lblCost);
            this.pnlCost.Controls.Add(this.lblCostIcon);
            this.pnlCost.Location = new System.Drawing.Point(840, 23);
            this.pnlCost.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlCost.Name = "pnlCost";
            this.pnlCost.Size = new System.Drawing.Size(375, 77);
            this.pnlCost.TabIndex = 2;
            // 
            // lblCost
            // 
            this.lblCost.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCost.ForeColor = System.Drawing.Color.White;
            this.lblCost.Location = new System.Drawing.Point(75, 15);
            this.lblCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(285, 46);
            this.lblCost.TabIndex = 1;
            this.lblCost.Text = "Chi phí: 0 ₫";
            this.lblCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCostIcon
            // 
            this.lblCostIcon.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostIcon.ForeColor = System.Drawing.Color.White;
            this.lblCostIcon.Location = new System.Drawing.Point(8, 8);
            this.lblCostIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCostIcon.Name = "lblCostIcon";
            this.lblCostIcon.Size = new System.Drawing.Size(60, 62);
            this.lblCostIcon.TabIndex = 0;
            this.lblCostIcon.Text = "💸";
            this.lblCostIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRevenue
            // 
            this.pnlRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.pnlRevenue.Controls.Add(this.lblRevenue);
            this.pnlRevenue.Controls.Add(this.lblRevenueIcon);
            this.pnlRevenue.Location = new System.Drawing.Point(450, 23);
            this.pnlRevenue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlRevenue.Name = "pnlRevenue";
            this.pnlRevenue.Size = new System.Drawing.Size(375, 77);
            this.pnlRevenue.TabIndex = 1;
            // 
            // lblRevenue
            // 
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.ForeColor = System.Drawing.Color.White;
            this.lblRevenue.Location = new System.Drawing.Point(75, 15);
            this.lblRevenue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(285, 46);
            this.lblRevenue.TabIndex = 1;
            this.lblRevenue.Text = "Doanh thu: 0 ₫";
            this.lblRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRevenueIcon
            // 
            this.lblRevenueIcon.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenueIcon.ForeColor = System.Drawing.Color.White;
            this.lblRevenueIcon.Location = new System.Drawing.Point(8, 8);
            this.lblRevenueIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRevenueIcon.Name = "lblRevenueIcon";
            this.lblRevenueIcon.Size = new System.Drawing.Size(60, 62);
            this.lblRevenueIcon.TabIndex = 0;
            this.lblRevenueIcon.Text = "💰";
            this.lblRevenueIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOrders
            // 
            this.pnlOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.pnlOrders.Controls.Add(this.lblOrders);
            this.pnlOrders.Controls.Add(this.lblOrdersIcon);
            this.pnlOrders.Location = new System.Drawing.Point(38, 23);
            this.pnlOrders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlOrders.Name = "pnlOrders";
            this.pnlOrders.Size = new System.Drawing.Size(398, 77);
            this.pnlOrders.TabIndex = 0;
            // 
            // lblOrders
            // 
            this.lblOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.ForeColor = System.Drawing.Color.White;
            this.lblOrders.Location = new System.Drawing.Point(75, 15);
            this.lblOrders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(308, 46);
            this.lblOrders.TabIndex = 1;
            this.lblOrders.Text = "Đơn hàng: 0";
            this.lblOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrdersIcon
            // 
            this.lblOrdersIcon.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdersIcon.ForeColor = System.Drawing.Color.White;
            this.lblOrdersIcon.Location = new System.Drawing.Point(8, 8);
            this.lblOrdersIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrdersIcon.Name = "lblOrdersIcon";
            this.lblOrdersIcon.Size = new System.Drawing.Size(60, 62);
            this.lblOrdersIcon.TabIndex = 0;
            this.lblOrdersIcon.Text = "🧾";
            this.lblOrdersIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.BackColor = System.Drawing.Color.White;
            this.pnlDataGrid.Controls.Add(this.tabControlReport);
            this.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGrid.Location = new System.Drawing.Point(0, 339);
            this.pnlDataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Padding = new System.Windows.Forms.Padding(38, 15, 38, 38);
            this.pnlDataGrid.Size = new System.Drawing.Size(1626, 719);
            this.pnlDataGrid.TabIndex = 3;
            // 
            // tabControlReport
            // 
            this.tabControlReport.Controls.Add(this.tabPageSummary);
            this.tabControlReport.Controls.Add(this.tabPageByProduct);
            this.tabControlReport.Controls.Add(this.tabPageByCustomer);
            this.tabControlReport.Controls.Add(this.tabPageByEmployee);
            this.tabControlReport.Controls.Add(this.tabPageCharts);
            this.tabControlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReport.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlReport.ItemSize = new System.Drawing.Size(180, 40);
            this.tabControlReport.Location = new System.Drawing.Point(38, 15);
            this.tabControlReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControlReport.Name = "tabControlReport";
            this.tabControlReport.SelectedIndex = 0;
            this.tabControlReport.Size = new System.Drawing.Size(1550, 666);
            this.tabControlReport.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlReport.TabIndex = 0;
            this.tabControlReport.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl_DrawItem);
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.BackColor = System.Drawing.Color.White;
            this.tabPageSummary.Controls.Add(this.dgvSummary);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 44);
            this.tabPageSummary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageSummary.Size = new System.Drawing.Size(1542, 618);
            this.tabPageSummary.TabIndex = 0;
            this.tabPageSummary.Text = "📊  Tổng hợp";
            // 
            // dgvSummary
            // 
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AllowUserToResizeRows = false;
            this.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSummary.BackgroundColor = System.Drawing.Color.White;
            this.dgvSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSummary.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Summary_Period,
            this.Summary_Orders,
            this.Summary_Revenue,
            this.Summary_Cost,
            this.Summary_Profit,
            this.Summary_Margin});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSummary.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSummary.EnableHeadersVisualStyles = false;
            this.dgvSummary.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvSummary.Location = new System.Drawing.Point(15, 15);
            this.dgvSummary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSummary.MultiSelect = false;
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.RowHeadersVisible = false;
            this.dgvSummary.RowHeadersWidth = 51;
            this.dgvSummary.RowTemplate.Height = 45;
            this.dgvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSummary.Size = new System.Drawing.Size(1512, 588);
            this.dgvSummary.TabIndex = 0;
            // 
            // Summary_Period
            // 
            this.Summary_Period.DataPropertyName = "Period";
            this.Summary_Period.FillWeight = 90F;
            this.Summary_Period.HeaderText = "📅 Kỳ";
            this.Summary_Period.MinimumWidth = 8;
            this.Summary_Period.Name = "Summary_Period";
            this.Summary_Period.ReadOnly = true;
            // 
            // Summary_Orders
            // 
            this.Summary_Orders.DataPropertyName = "Orders";
            this.Summary_Orders.FillWeight = 75F;
            this.Summary_Orders.HeaderText = "🧾 ĐH";
            this.Summary_Orders.MinimumWidth = 8;
            this.Summary_Orders.Name = "Summary_Orders";
            this.Summary_Orders.ReadOnly = true;
            // 
            // Summary_Revenue
            // 
            this.Summary_Revenue.DataPropertyName = "Revenue";
            this.Summary_Revenue.FillWeight = 95F;
            this.Summary_Revenue.HeaderText = "💰 Doanh thu";
            this.Summary_Revenue.MinimumWidth = 8;
            this.Summary_Revenue.Name = "Summary_Revenue";
            this.Summary_Revenue.ReadOnly = true;
            // 
            // Summary_Cost
            // 
            this.Summary_Cost.DataPropertyName = "Cost";
            this.Summary_Cost.FillWeight = 95F;
            this.Summary_Cost.HeaderText = "💸 Chi phí";
            this.Summary_Cost.MinimumWidth = 8;
            this.Summary_Cost.Name = "Summary_Cost";
            this.Summary_Cost.ReadOnly = true;
            // 
            // Summary_Profit
            // 
            this.Summary_Profit.DataPropertyName = "Profit";
            this.Summary_Profit.FillWeight = 95F;
            this.Summary_Profit.HeaderText = "💎 Lợi nhuận";
            this.Summary_Profit.MinimumWidth = 8;
            this.Summary_Profit.Name = "Summary_Profit";
            this.Summary_Profit.ReadOnly = true;
            // 
            // Summary_Margin
            // 
            this.Summary_Margin.DataPropertyName = "Margin";
            this.Summary_Margin.FillWeight = 70F;
            this.Summary_Margin.HeaderText = "📈 % LN";
            this.Summary_Margin.MinimumWidth = 8;
            this.Summary_Margin.Name = "Summary_Margin";
            this.Summary_Margin.ReadOnly = true;
            // 
            // tabPageByProduct
            // 
            this.tabPageByProduct.BackColor = System.Drawing.Color.White;
            this.tabPageByProduct.Controls.Add(this.dgvByProduct);
            this.tabPageByProduct.Location = new System.Drawing.Point(4, 44);
            this.tabPageByProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageByProduct.Name = "tabPageByProduct";
            this.tabPageByProduct.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageByProduct.Size = new System.Drawing.Size(1542, 618);
            this.tabPageByProduct.TabIndex = 1;
            this.tabPageByProduct.Text = "📦  Theo sản phẩm";
            // 
            // dgvByProduct
            // 
            this.dgvByProduct.AllowUserToAddRows = false;
            this.dgvByProduct.AllowUserToDeleteRows = false;
            this.dgvByProduct.AllowUserToResizeRows = false;
            this.dgvByProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvByProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvByProduct.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvByProduct.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvByProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvByProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvByProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_MaSP,
            this.Product_TenSP,
            this.Product_SoLuong,
            this.Product_DoanhThu,
            this.Product_TyLe});
            this.dgvByProduct.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvByProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvByProduct.EnableHeadersVisualStyles = false;
            this.dgvByProduct.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvByProduct.Location = new System.Drawing.Point(15, 15);
            this.dgvByProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvByProduct.MultiSelect = false;
            this.dgvByProduct.Name = "dgvByProduct";
            this.dgvByProduct.ReadOnly = true;
            this.dgvByProduct.RowHeadersVisible = false;
            this.dgvByProduct.RowHeadersWidth = 51;
            this.dgvByProduct.RowTemplate.Height = 45;
            this.dgvByProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvByProduct.Size = new System.Drawing.Size(1512, 588);
            this.dgvByProduct.TabIndex = 0;
            // 
            // Product_MaSP
            // 
            this.Product_MaSP.DataPropertyName = "MaSP";
            this.Product_MaSP.FillWeight = 70F;
            this.Product_MaSP.HeaderText = "Mã SP";
            this.Product_MaSP.MinimumWidth = 8;
            this.Product_MaSP.Name = "Product_MaSP";
            this.Product_MaSP.ReadOnly = true;
            // 
            // Product_TenSP
            // 
            this.Product_TenSP.DataPropertyName = "TenSP";
            this.Product_TenSP.FillWeight = 130F;
            this.Product_TenSP.HeaderText = "📦 Tên sản phẩm";
            this.Product_TenSP.MinimumWidth = 8;
            this.Product_TenSP.Name = "Product_TenSP";
            this.Product_TenSP.ReadOnly = true;
            // 
            // Product_SoLuong
            // 
            this.Product_SoLuong.DataPropertyName = "SoLuong";
            this.Product_SoLuong.FillWeight = 75F;
            this.Product_SoLuong.HeaderText = "📊 SL bán";
            this.Product_SoLuong.MinimumWidth = 8;
            this.Product_SoLuong.Name = "Product_SoLuong";
            this.Product_SoLuong.ReadOnly = true;
            // 
            // Product_DoanhThu
            // 
            this.Product_DoanhThu.DataPropertyName = "DoanhThu";
            this.Product_DoanhThu.FillWeight = 95F;
            this.Product_DoanhThu.HeaderText = "💰 Doanh thu";
            this.Product_DoanhThu.MinimumWidth = 8;
            this.Product_DoanhThu.Name = "Product_DoanhThu";
            this.Product_DoanhThu.ReadOnly = true;
            // 
            // Product_TyLe
            // 
            this.Product_TyLe.DataPropertyName = "TyLe";
            this.Product_TyLe.FillWeight = 70F;
            this.Product_TyLe.HeaderText = "📈 % DT";
            this.Product_TyLe.MinimumWidth = 8;
            this.Product_TyLe.Name = "Product_TyLe";
            this.Product_TyLe.ReadOnly = true;
            // 
            // tabPageByCustomer
            // 
            this.tabPageByCustomer.BackColor = System.Drawing.Color.White;
            this.tabPageByCustomer.Controls.Add(this.dgvByCustomer);
            this.tabPageByCustomer.Location = new System.Drawing.Point(4, 44);
            this.tabPageByCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageByCustomer.Name = "tabPageByCustomer";
            this.tabPageByCustomer.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageByCustomer.Size = new System.Drawing.Size(1542, 618);
            this.tabPageByCustomer.TabIndex = 2;
            this.tabPageByCustomer.Text = "👤  Theo khách hàng";
            // 
            // dgvByCustomer
            // 
            this.dgvByCustomer.AllowUserToAddRows = false;
            this.dgvByCustomer.AllowUserToDeleteRows = false;
            this.dgvByCustomer.AllowUserToResizeRows = false;
            this.dgvByCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvByCustomer.BackgroundColor = System.Drawing.Color.White;
            this.dgvByCustomer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvByCustomer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvByCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvByCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvByCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Customer_MaKH,
            this.Customer_TenKH,
            this.Customer_SoDonHang,
            this.Customer_TongTien,
            this.Customer_LoaiKH});
            this.dgvByCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvByCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvByCustomer.EnableHeadersVisualStyles = false;
            this.dgvByCustomer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvByCustomer.Location = new System.Drawing.Point(15, 15);
            this.dgvByCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvByCustomer.MultiSelect = false;
            this.dgvByCustomer.Name = "dgvByCustomer";
            this.dgvByCustomer.ReadOnly = true;
            this.dgvByCustomer.RowHeadersVisible = false;
            this.dgvByCustomer.RowHeadersWidth = 51;
            this.dgvByCustomer.RowTemplate.Height = 45;
            this.dgvByCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvByCustomer.Size = new System.Drawing.Size(1512, 588);
            this.dgvByCustomer.TabIndex = 0;
            // 
            // Customer_MaKH
            // 
            this.Customer_MaKH.DataPropertyName = "MaKH";
            this.Customer_MaKH.FillWeight = 70F;
            this.Customer_MaKH.HeaderText = "Mã KH";
            this.Customer_MaKH.MinimumWidth = 8;
            this.Customer_MaKH.Name = "Customer_MaKH";
            this.Customer_MaKH.ReadOnly = true;
            // 
            // Customer_TenKH
            // 
            this.Customer_TenKH.DataPropertyName = "TenKH";
            this.Customer_TenKH.FillWeight = 120F;
            this.Customer_TenKH.HeaderText = "👤 Tên khách hàng";
            this.Customer_TenKH.MinimumWidth = 8;
            this.Customer_TenKH.Name = "Customer_TenKH";
            this.Customer_TenKH.ReadOnly = true;
            // 
            // Customer_SoDonHang
            // 
            this.Customer_SoDonHang.DataPropertyName = "SoDonHang";
            this.Customer_SoDonHang.FillWeight = 80F;
            this.Customer_SoDonHang.HeaderText = "🧾 Số đơn";
            this.Customer_SoDonHang.MinimumWidth = 8;
            this.Customer_SoDonHang.Name = "Customer_SoDonHang";
            this.Customer_SoDonHang.ReadOnly = true;
            // 
            // Customer_TongTien
            // 
            this.Customer_TongTien.DataPropertyName = "TongTien";
            this.Customer_TongTien.HeaderText = "💰 Tổng tiền";
            this.Customer_TongTien.MinimumWidth = 8;
            this.Customer_TongTien.Name = "Customer_TongTien";
            this.Customer_TongTien.ReadOnly = true;
            // 
            // Customer_LoaiKH
            // 
            this.Customer_LoaiKH.DataPropertyName = "LoaiKH";
            this.Customer_LoaiKH.FillWeight = 90F;
            this.Customer_LoaiKH.HeaderText = "🏷️ Loại KH";
            this.Customer_LoaiKH.MinimumWidth = 8;
            this.Customer_LoaiKH.Name = "Customer_LoaiKH";
            this.Customer_LoaiKH.ReadOnly = true;
            // 
            // tabPageByEmployee
            // 
            this.tabPageByEmployee.BackColor = System.Drawing.Color.White;
            this.tabPageByEmployee.Controls.Add(this.dgvByEmployee);
            this.tabPageByEmployee.Location = new System.Drawing.Point(4, 44);
            this.tabPageByEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageByEmployee.Name = "tabPageByEmployee";
            this.tabPageByEmployee.Padding = new System.Windows.Forms.Padding(15);
            this.tabPageByEmployee.Size = new System.Drawing.Size(1542, 618);
            this.tabPageByEmployee.TabIndex = 3;
            this.tabPageByEmployee.Text = "👨‍💼  Theo nhân viên";
            // 
            // dgvByEmployee
            // 
            this.dgvByEmployee.AllowUserToAddRows = false;
            this.dgvByEmployee.AllowUserToDeleteRows = false;
            this.dgvByEmployee.AllowUserToResizeRows = false;
            this.dgvByEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvByEmployee.BackgroundColor = System.Drawing.Color.White;
            this.dgvByEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvByEmployee.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvByEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvByEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvByEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Employee_MaNV,
            this.Employee_TenNV,
            this.Employee_SoDonHang,
            this.Employee_DoanhThu,
            this.Employee_TyLe});
            this.dgvByEmployee.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvByEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvByEmployee.EnableHeadersVisualStyles = false;
            this.dgvByEmployee.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvByEmployee.Location = new System.Drawing.Point(15, 15);
            this.dgvByEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvByEmployee.MultiSelect = false;
            this.dgvByEmployee.Name = "dgvByEmployee";
            this.dgvByEmployee.ReadOnly = true;
            this.dgvByEmployee.RowHeadersVisible = false;
            this.dgvByEmployee.RowHeadersWidth = 51;
            this.dgvByEmployee.RowTemplate.Height = 45;
            this.dgvByEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvByEmployee.Size = new System.Drawing.Size(1512, 588);
            this.dgvByEmployee.TabIndex = 0;
            // 
            // Employee_MaNV
            // 
            this.Employee_MaNV.DataPropertyName = "MaNV";
            this.Employee_MaNV.FillWeight = 70F;
            this.Employee_MaNV.HeaderText = "Mã NV";
            this.Employee_MaNV.MinimumWidth = 8;
            this.Employee_MaNV.Name = "Employee_MaNV";
            this.Employee_MaNV.ReadOnly = true;
            // 
            // Employee_TenNV
            // 
            this.Employee_TenNV.DataPropertyName = "TenNV";
            this.Employee_TenNV.FillWeight = 120F;
            this.Employee_TenNV.HeaderText = "👨‍💼 Tên nhân viên";
            this.Employee_TenNV.MinimumWidth = 8;
            this.Employee_TenNV.Name = "Employee_TenNV";
            this.Employee_TenNV.ReadOnly = true;
            // 
            // Employee_SoDonHang
            // 
            this.Employee_SoDonHang.DataPropertyName = "SoDonHang";
            this.Employee_SoDonHang.FillWeight = 80F;
            this.Employee_SoDonHang.HeaderText = "🧾 Số đơn";
            this.Employee_SoDonHang.MinimumWidth = 8;
            this.Employee_SoDonHang.Name = "Employee_SoDonHang";
            this.Employee_SoDonHang.ReadOnly = true;
            // 
            // Employee_DoanhThu
            // 
            this.Employee_DoanhThu.DataPropertyName = "DoanhThu";
            this.Employee_DoanhThu.HeaderText = "💰 Doanh thu";
            this.Employee_DoanhThu.MinimumWidth = 8;
            this.Employee_DoanhThu.Name = "Employee_DoanhThu";
            this.Employee_DoanhThu.ReadOnly = true;
            // 
            // Employee_TyLe
            // 
            this.Employee_TyLe.DataPropertyName = "TyLe";
            this.Employee_TyLe.FillWeight = 70F;
            this.Employee_TyLe.HeaderText = "📈 % DT";
            this.Employee_TyLe.MinimumWidth = 8;
            this.Employee_TyLe.Name = "Employee_TyLe";
            this.Employee_TyLe.ReadOnly = true;
            // 
            // tabPageCharts
            // 
            this.tabPageCharts.BackColor = System.Drawing.Color.White;
            this.tabPageCharts.Location = new System.Drawing.Point(4, 44);
            this.tabPageCharts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageCharts.Name = "tabPageCharts";
            this.tabPageCharts.Padding = new System.Windows.Forms.Padding(30, 31, 30, 31);
            this.tabPageCharts.Size = new System.Drawing.Size(1542, 618);
            this.tabPageCharts.TabIndex = 4;
            this.tabPageCharts.Text = "📊  Biểu đồ";
            // 
            // SalesRevenueReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1626, 1058);
            this.Controls.Add(this.pnlDataGrid);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SalesRevenueReportForm";
            this.Text = "Báo cáo Doanh thu";
            this.Load += new System.EventHandler(this.SalesRevenueReportForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlStats.ResumeLayout(false);
            this.pnlProfit.ResumeLayout(false);
            this.pnlCost.ResumeLayout(false);
            this.pnlRevenue.ResumeLayout(false);
            this.pnlOrders.ResumeLayout(false);
            this.pnlDataGrid.ResumeLayout(false);
            this.tabControlReport.ResumeLayout(false);
            this.tabPageSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.tabPageByProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvByProduct)).EndInit();
            this.tabPageByCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvByCustomer)).EndInit();
            this.tabPageByEmployee.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvByEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlProfit;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblProfitIcon;
        private System.Windows.Forms.Panel pnlCost;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblCostIcon;
        private System.Windows.Forms.Panel pnlRevenue;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblRevenueIcon;
        private System.Windows.Forms.Panel pnlOrders;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblOrdersIcon;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.TabControl tabControlReport;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary_Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary_Orders;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary_Revenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary_Profit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary_Margin;
        private System.Windows.Forms.TabPage tabPageByProduct;
        private System.Windows.Forms.DataGridView dgvByProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_DoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_TyLe;
        private System.Windows.Forms.TabPage tabPageByCustomer;
        private System.Windows.Forms.DataGridView dgvByCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_SoDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_LoaiKH;
        private System.Windows.Forms.TabPage tabPageByEmployee;
        private System.Windows.Forms.DataGridView dgvByEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_SoDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_DoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee_TyLe;
        private System.Windows.Forms.TabPage tabPageCharts;
    }
}