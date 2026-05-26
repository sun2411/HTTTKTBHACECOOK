namespace HTTKTBHACECOOK
{
    partial class DebtManagementForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlSearchBar = new System.Windows.Forms.Panel();
            this.cmbDebtType = new System.Windows.Forms.ComboBox();
            this.lblDebtTypeIcon = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.pnlTotalOverdue = new System.Windows.Forms.Panel();
            this.lblTotalOverdue = new System.Windows.Forms.Label();
            this.lblOverdueIcon = new System.Windows.Forms.Label();
            this.pnlTotalDebt = new System.Windows.Forms.Panel();
            this.lblTotalDebt = new System.Windows.Forms.Label();
            this.lblTotalDebtIcon = new System.Windows.Forms.Label();
            this.pnlStatsCount = new System.Windows.Forms.Panel();
            this.lblStatsCount = new System.Windows.Forms.Label();
            this.lblStatsIcon = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlDataGrid = new System.Windows.Forms.Panel();
            this.tabControlDebt = new System.Windows.Forms.TabControl();
            this.tabPageReceivable = new System.Windows.Forms.TabPage();
            this.dgvReceivable = new System.Windows.Forms.DataGridView();
            this.Receivable_MaCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable_MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable_TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable_NgayPhatSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable_SoTienNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable_SoTienDaTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable_ConLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable_HanThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivable_TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePayable = new System.Windows.Forms.TabPage();
            this.dgvPayable = new System.Windows.Forms.DataGridView();
            this.Payable_MaCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable_MaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable_TenNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable_NgayPhatSinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable_SoTienNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable_SoTienDaTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable_ConLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable_HanThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payable_TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlSearchBar.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlTotalOverdue.SuspendLayout();
            this.pnlTotalDebt.SuspendLayout();
            this.pnlStatsCount.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            this.tabControlDebt.SuspendLayout();
            this.tabPageReceivable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivable)).BeginInit();
            this.tabPagePayable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayable)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(25, 20, 25, 15);
            this.pnlHeader.Size = new System.Drawing.Size(1084, 70);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPageTitle.Location = new System.Drawing.Point(25, 20);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(600, 35);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "💳  QUẢN LÝ CÔNG NỢ";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearchBar
            // 
            this.pnlSearchBar.BackColor = System.Drawing.Color.White;
            this.pnlSearchBar.Controls.Add(this.cmbDebtType);
            this.pnlSearchBar.Controls.Add(this.lblDebtTypeIcon);
            this.pnlSearchBar.Controls.Add(this.btnRefresh);
            this.pnlSearchBar.Controls.Add(this.btnSearch);
            this.pnlSearchBar.Controls.Add(this.txtSearch);
            this.pnlSearchBar.Controls.Add(this.lblSearchIcon);
            this.pnlSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchBar.Location = new System.Drawing.Point(0, 70);
            this.pnlSearchBar.Name = "pnlSearchBar";
            this.pnlSearchBar.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlSearchBar.Size = new System.Drawing.Size(1084, 70);
            this.pnlSearchBar.TabIndex = 1;
            // 
            // cmbDebtType
            // 
            this.cmbDebtType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDebtType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDebtType.FormattingEnabled = true;
            this.cmbDebtType.Items.AddRange(new object[] {
            "Tất cả",
            "Chưa thanh toán",
            "Đã thanh toán một phần",
            "Đã thanh toán đủ",
            "Quá hạn"});
            this.cmbDebtType.Location = new System.Drawing.Point(800, 18);
            this.cmbDebtType.Name = "cmbDebtType";
            this.cmbDebtType.Size = new System.Drawing.Size(180, 25);
            this.cmbDebtType.TabIndex = 5;
            // 
            // lblDebtTypeIcon
            // 
            this.lblDebtTypeIcon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebtTypeIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDebtTypeIcon.Location = new System.Drawing.Point(760, 12);
            this.lblDebtTypeIcon.Name = "lblDebtTypeIcon";
            this.lblDebtTypeIcon.Size = new System.Drawing.Size(35, 35);
            this.lblDebtTypeIcon.TabIndex = 4;
            this.lblDebtTypeIcon.Text = "📋";
            this.lblDebtTypeIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(630, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄  Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(500, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍  Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.txtSearch.Location = new System.Drawing.Point(70, 18);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(420, 27);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSearchIcon.Location = new System.Drawing.Point(25, 12);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(40, 40);
            this.lblSearchIcon.TabIndex = 0;
            this.lblSearchIcon.Text = "🔍";
            this.lblSearchIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlActions.Controls.Add(this.pnlTotalOverdue);
            this.pnlActions.Controls.Add(this.pnlTotalDebt);
            this.pnlActions.Controls.Add(this.pnlStatsCount);
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.btnPayment);
            this.pnlActions.Controls.Add(this.btnViewDetail);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 140);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlActions.Size = new System.Drawing.Size(1084, 80);
            this.pnlActions.TabIndex = 2;
            // 
            // pnlTotalOverdue
            // 
            this.pnlTotalOverdue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.pnlTotalOverdue.Controls.Add(this.lblTotalOverdue);
            this.pnlTotalOverdue.Controls.Add(this.lblOverdueIcon);
            this.pnlTotalOverdue.Location = new System.Drawing.Point(840, 15);
            this.pnlTotalOverdue.Name = "pnlTotalOverdue";
            this.pnlTotalOverdue.Size = new System.Drawing.Size(210, 50);
            this.pnlTotalOverdue.TabIndex = 6;
            // 
            // lblTotalOverdue
            // 
            this.lblTotalOverdue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOverdue.ForeColor = System.Drawing.Color.White;
            this.lblTotalOverdue.Location = new System.Drawing.Point(50, 12);
            this.lblTotalOverdue.Name = "lblTotalOverdue";
            this.lblTotalOverdue.Size = new System.Drawing.Size(150, 26);
            this.lblTotalOverdue.TabIndex = 1;
            this.lblTotalOverdue.Text = "QH: 0 ₫";
            this.lblTotalOverdue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOverdueIcon
            // 
            this.lblOverdueIcon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverdueIcon.ForeColor = System.Drawing.Color.White;
            this.lblOverdueIcon.Location = new System.Drawing.Point(5, 8);
            this.lblOverdueIcon.Name = "lblOverdueIcon";
            this.lblOverdueIcon.Size = new System.Drawing.Size(40, 35);
            this.lblOverdueIcon.TabIndex = 0;
            this.lblOverdueIcon.Text = "⚠️";
            this.lblOverdueIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTotalDebt
            // 
            this.pnlTotalDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(126)))), ((int)(((byte)(20)))));
            this.pnlTotalDebt.Controls.Add(this.lblTotalDebt);
            this.pnlTotalDebt.Controls.Add(this.lblTotalDebtIcon);
            this.pnlTotalDebt.Location = new System.Drawing.Point(640, 15);
            this.pnlTotalDebt.Name = "pnlTotalDebt";
            this.pnlTotalDebt.Size = new System.Drawing.Size(190, 50);
            this.pnlTotalDebt.TabIndex = 5;
            // 
            // lblTotalDebt
            // 
            this.lblTotalDebt.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDebt.ForeColor = System.Drawing.Color.White;
            this.lblTotalDebt.Location = new System.Drawing.Point(50, 12);
            this.lblTotalDebt.Name = "lblTotalDebt";
            this.lblTotalDebt.Size = new System.Drawing.Size(130, 26);
            this.lblTotalDebt.TabIndex = 1;
            this.lblTotalDebt.Text = "0 ₫";
            this.lblTotalDebt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalDebtIcon
            // 
            this.lblTotalDebtIcon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDebtIcon.ForeColor = System.Drawing.Color.White;
            this.lblTotalDebtIcon.Location = new System.Drawing.Point(5, 8);
            this.lblTotalDebtIcon.Name = "lblTotalDebtIcon";
            this.lblTotalDebtIcon.Size = new System.Drawing.Size(40, 35);
            this.lblTotalDebtIcon.TabIndex = 0;
            this.lblTotalDebtIcon.Text = "💰";
            this.lblTotalDebtIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatsCount
            // 
            this.pnlStatsCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.pnlStatsCount.Controls.Add(this.lblStatsCount);
            this.pnlStatsCount.Controls.Add(this.lblStatsIcon);
            this.pnlStatsCount.Location = new System.Drawing.Point(460, 15);
            this.pnlStatsCount.Name = "pnlStatsCount";
            this.pnlStatsCount.Size = new System.Drawing.Size(170, 50);
            this.pnlStatsCount.TabIndex = 4;
            // 
            // lblStatsCount
            // 
            this.lblStatsCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsCount.ForeColor = System.Drawing.Color.White;
            this.lblStatsCount.Location = new System.Drawing.Point(55, 12);
            this.lblStatsCount.Name = "lblStatsCount";
            this.lblStatsCount.Size = new System.Drawing.Size(110, 26);
            this.lblStatsCount.TabIndex = 1;
            this.lblStatsCount.Text = "Tổng: 0";
            this.lblStatsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatsIcon
            // 
            this.lblStatsIcon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsIcon.ForeColor = System.Drawing.Color.White;
            this.lblStatsIcon.Location = new System.Drawing.Point(10, 8);
            this.lblStatsIcon.Name = "lblStatsIcon";
            this.lblStatsIcon.Size = new System.Drawing.Size(40, 35);
            this.lblStatsIcon.TabIndex = 0;
            this.lblStatsIcon.Text = "📊";
            this.lblStatsIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(315, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(135, 50);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "📊  Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayment.FlatAppearance.BorderSize = 0;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnPayment.Location = new System.Drawing.Point(25, 15);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(135, 50);
            this.btnPayment.TabIndex = 0;
            this.btnPayment.Text = "💵  Thanh toán";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnViewDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewDetail.FlatAppearance.BorderSize = 0;
            this.btnViewDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetail.ForeColor = System.Drawing.Color.White;
            this.btnViewDetail.Location = new System.Drawing.Point(170, 15);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(135, 50);
            this.btnViewDetail.TabIndex = 1;
            this.btnViewDetail.Text = "👁️  Chi tiết";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1130, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 50);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "➕  Ghi nợ";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.BackColor = System.Drawing.Color.White;
            this.pnlDataGrid.Controls.Add(this.tabControlDebt);
            this.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGrid.Location = new System.Drawing.Point(0, 220);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Padding = new System.Windows.Forms.Padding(25, 10, 25, 25);
            this.pnlDataGrid.Size = new System.Drawing.Size(1084, 468);
            this.pnlDataGrid.TabIndex = 3;
            // 
            // tabControlDebt
            // 
            this.tabControlDebt.Controls.Add(this.tabPageReceivable);
            this.tabControlDebt.Controls.Add(this.tabPagePayable);
            this.tabControlDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDebt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlDebt.ItemSize = new System.Drawing.Size(200, 40);
            this.tabControlDebt.Location = new System.Drawing.Point(25, 10);
            this.tabControlDebt.Name = "tabControlDebt";
            this.tabControlDebt.SelectedIndex = 0;
            this.tabControlDebt.Size = new System.Drawing.Size(1034, 433);
            this.tabControlDebt.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlDebt.TabIndex = 0;
            this.tabControlDebt.SelectedIndexChanged += new System.EventHandler(this.tabControlDebt_SelectedIndexChanged);
            // 
            // tabPageReceivable
            // 
            this.tabPageReceivable.BackColor = System.Drawing.Color.White;
            this.tabPageReceivable.Controls.Add(this.dgvReceivable);
            this.tabPageReceivable.Location = new System.Drawing.Point(4, 44);
            this.tabPageReceivable.Name = "tabPageReceivable";
            this.tabPageReceivable.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageReceivable.Size = new System.Drawing.Size(1026, 385);
            this.tabPageReceivable.TabIndex = 0;
            this.tabPageReceivable.Text = "📥  Công nợ phải thu";
            // 
            // dgvReceivable
            // 
            this.dgvReceivable.AllowUserToAddRows = false;
            this.dgvReceivable.AllowUserToDeleteRows = false;
            this.dgvReceivable.AllowUserToResizeRows = false;
            this.dgvReceivable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceivable.BackgroundColor = System.Drawing.Color.White;
            this.dgvReceivable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReceivable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceivable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceivable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceivable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Receivable_MaCN,
            this.Receivable_MaKH,
            this.Receivable_TenKH,
            this.Receivable_NgayPhatSinh,
            this.Receivable_SoTienNo,
            this.Receivable_SoTienDaTra,
            this.Receivable_ConLai,
            this.Receivable_HanThanhToan,
            this.Receivable_TrangThai});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceivable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceivable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceivable.EnableHeadersVisualStyles = false;
            this.dgvReceivable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvReceivable.Location = new System.Drawing.Point(10, 10);
            this.dgvReceivable.MultiSelect = false;
            this.dgvReceivable.Name = "dgvReceivable";
            this.dgvReceivable.ReadOnly = true;
            this.dgvReceivable.RowHeadersVisible = false;
            this.dgvReceivable.RowHeadersWidth = 51;
            this.dgvReceivable.RowTemplate.Height = 45;
            this.dgvReceivable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceivable.Size = new System.Drawing.Size(1006, 365);
            this.dgvReceivable.TabIndex = 0;
            // 
            // Receivable_MaCN
            // 
            this.Receivable_MaCN.DataPropertyName = "MaCN";
            this.Receivable_MaCN.FillWeight = 60F;
            this.Receivable_MaCN.HeaderText = "Mã CN";
            this.Receivable_MaCN.Name = "Receivable_MaCN";
            this.Receivable_MaCN.ReadOnly = true;
            // 
            // Receivable_MaKH
            // 
            this.Receivable_MaKH.DataPropertyName = "MaKH";
            this.Receivable_MaKH.FillWeight = 60F;
            this.Receivable_MaKH.HeaderText = "Mã KH";
            this.Receivable_MaKH.Name = "Receivable_MaKH";
            this.Receivable_MaKH.ReadOnly = true;
            // 
            // Receivable_TenKH
            // 
            this.Receivable_TenKH.DataPropertyName = "TenKH";
            this.Receivable_TenKH.FillWeight = 110F;
            this.Receivable_TenKH.HeaderText = "👤 Khách hàng";
            this.Receivable_TenKH.Name = "Receivable_TenKH";
            this.Receivable_TenKH.ReadOnly = true;
            // 
            // Receivable_NgayPhatSinh
            // 
            this.Receivable_NgayPhatSinh.DataPropertyName = "NgayPhatSinh";
            this.Receivable_NgayPhatSinh.FillWeight = 80F;
            this.Receivable_NgayPhatSinh.HeaderText = "📅 Ngày PS";
            this.Receivable_NgayPhatSinh.Name = "Receivable_NgayPhatSinh";
            this.Receivable_NgayPhatSinh.ReadOnly = true;
            // 
            // Receivable_SoTienNo
            // 
            this.Receivable_SoTienNo.DataPropertyName = "SoTienNo";
            this.Receivable_SoTienNo.FillWeight = 85F;
            this.Receivable_SoTienNo.HeaderText = "💰 Tiền nợ";
            this.Receivable_SoTienNo.Name = "Receivable_SoTienNo";
            this.Receivable_SoTienNo.ReadOnly = true;
            // 
            // Receivable_SoTienDaTra
            // 
            this.Receivable_SoTienDaTra.DataPropertyName = "SoTienDaTra";
            this.Receivable_SoTienDaTra.FillWeight = 85F;
            this.Receivable_SoTienDaTra.HeaderText = "💵 Đã trả";
            this.Receivable_SoTienDaTra.Name = "Receivable_SoTienDaTra";
            this.Receivable_SoTienDaTra.ReadOnly = true;
            // 
            // Receivable_ConLai
            // 
            this.Receivable_ConLai.DataPropertyName = "ConLai";
            this.Receivable_ConLai.FillWeight = 85F;
            this.Receivable_ConLai.HeaderText = "💳 Còn lại";
            this.Receivable_ConLai.Name = "Receivable_ConLai";
            this.Receivable_ConLai.ReadOnly = true;
            // 
            // Receivable_HanThanhToan
            // 
            this.Receivable_HanThanhToan.DataPropertyName = "HanThanhToan";
            this.Receivable_HanThanhToan.FillWeight = 80F;
            this.Receivable_HanThanhToan.HeaderText = "⏰ Hạn TT";
            this.Receivable_HanThanhToan.Name = "Receivable_HanThanhToan";
            this.Receivable_HanThanhToan.ReadOnly = true;
            // 
            // Receivable_TrangThai
            // 
            this.Receivable_TrangThai.DataPropertyName = "TrangThai";
            this.Receivable_TrangThai.FillWeight = 90F;
            this.Receivable_TrangThai.HeaderText = "📌 Trạng thái";
            this.Receivable_TrangThai.Name = "Receivable_TrangThai";
            this.Receivable_TrangThai.ReadOnly = true;
            // 
            // tabPagePayable
            // 
            this.tabPagePayable.BackColor = System.Drawing.Color.White;
            this.tabPagePayable.Controls.Add(this.dgvPayable);
            this.tabPagePayable.Location = new System.Drawing.Point(4, 44);
            this.tabPagePayable.Name = "tabPagePayable";
            this.tabPagePayable.Padding = new System.Windows.Forms.Padding(10);
            this.tabPagePayable.Size = new System.Drawing.Size(1026, 385);
            this.tabPagePayable.TabIndex = 1;
            this.tabPagePayable.Text = "📤  Công nợ phải trả";
            // 
            // dgvPayable
            // 
            this.dgvPayable.AllowUserToAddRows = false;
            this.dgvPayable.AllowUserToDeleteRows = false;
            this.dgvPayable.AllowUserToResizeRows = false;
            this.dgvPayable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayable.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPayable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Payable_MaCN,
            this.Payable_MaNCC,
            this.Payable_TenNCC,
            this.Payable_NgayPhatSinh,
            this.Payable_SoTienNo,
            this.Payable_SoTienDaTra,
            this.Payable_ConLai,
            this.Payable_HanThanhToan,
            this.Payable_TrangThai});
            this.dgvPayable.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPayable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayable.EnableHeadersVisualStyles = false;
            this.dgvPayable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvPayable.Location = new System.Drawing.Point(10, 10);
            this.dgvPayable.MultiSelect = false;
            this.dgvPayable.Name = "dgvPayable";
            this.dgvPayable.ReadOnly = true;
            this.dgvPayable.RowHeadersVisible = false;
            this.dgvPayable.RowHeadersWidth = 51;
            this.dgvPayable.RowTemplate.Height = 45;
            this.dgvPayable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayable.Size = new System.Drawing.Size(1006, 365);
            this.dgvPayable.TabIndex = 0;
            // 
            // Payable_MaCN
            // 
            this.Payable_MaCN.DataPropertyName = "MaCN";
            this.Payable_MaCN.FillWeight = 60F;
            this.Payable_MaCN.HeaderText = "Mã CN";
            this.Payable_MaCN.Name = "Payable_MaCN";
            this.Payable_MaCN.ReadOnly = true;
            // 
            // Payable_MaNCC
            // 
            this.Payable_MaNCC.DataPropertyName = "MaNCC";
            this.Payable_MaNCC.FillWeight = 60F;
            this.Payable_MaNCC.HeaderText = "Mã NCC";
            this.Payable_MaNCC.Name = "Payable_MaNCC";
            this.Payable_MaNCC.ReadOnly = true;
            // 
            // Payable_TenNCC
            // 
            this.Payable_TenNCC.DataPropertyName = "TenNCC";
            this.Payable_TenNCC.FillWeight = 110F;
            this.Payable_TenNCC.HeaderText = "🏭 Nhà cung cấp";
            this.Payable_TenNCC.Name = "Payable_TenNCC";
            this.Payable_TenNCC.ReadOnly = true;
            // 
            // Payable_NgayPhatSinh
            // 
            this.Payable_NgayPhatSinh.DataPropertyName = "NgayPhatSinh";
            this.Payable_NgayPhatSinh.FillWeight = 80F;
            this.Payable_NgayPhatSinh.HeaderText = "📅 Ngày PS";
            this.Payable_NgayPhatSinh.Name = "Payable_NgayPhatSinh";
            this.Payable_NgayPhatSinh.ReadOnly = true;
            // 
            // Payable_SoTienNo
            // 
            this.Payable_SoTienNo.DataPropertyName = "SoTienNo";
            this.Payable_SoTienNo.FillWeight = 85F;
            this.Payable_SoTienNo.HeaderText = "💰 Tiền nợ";
            this.Payable_SoTienNo.Name = "Payable_SoTienNo";
            this.Payable_SoTienNo.ReadOnly = true;
            // 
            // Payable_SoTienDaTra
            // 
            this.Payable_SoTienDaTra.DataPropertyName = "SoTienDaTra";
            this.Payable_SoTienDaTra.FillWeight = 85F;
            this.Payable_SoTienDaTra.HeaderText = "💵 Đã trả";
            this.Payable_SoTienDaTra.Name = "Payable_SoTienDaTra";
            this.Payable_SoTienDaTra.ReadOnly = true;
            // 
            // Payable_ConLai
            // 
            this.Payable_ConLai.DataPropertyName = "ConLai";
            this.Payable_ConLai.FillWeight = 85F;
            this.Payable_ConLai.HeaderText = "💳 Còn lại";
            this.Payable_ConLai.Name = "Payable_ConLai";
            this.Payable_ConLai.ReadOnly = true;
            // 
            // Payable_HanThanhToan
            // 
            this.Payable_HanThanhToan.DataPropertyName = "HanThanhToan";
            this.Payable_HanThanhToan.FillWeight = 80F;
            this.Payable_HanThanhToan.HeaderText = "⏰ Hạn TT";
            this.Payable_HanThanhToan.Name = "Payable_HanThanhToan";
            this.Payable_HanThanhToan.ReadOnly = true;
            // 
            // Payable_TrangThai
            // 
            this.Payable_TrangThai.DataPropertyName = "TrangThai";
            this.Payable_TrangThai.FillWeight = 90F;
            this.Payable_TrangThai.HeaderText = "📌 Trạng thái";
            this.Payable_TrangThai.Name = "Payable_TrangThai";
            this.Payable_TrangThai.ReadOnly = true;
            // 
            // DebtManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1084, 688);
            this.Controls.Add(this.pnlDataGrid);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlSearchBar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DebtManagementForm";
            this.Text = "Quản lý Công nợ";
            this.Load += new System.EventHandler(this.DebtManagementForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlSearchBar.ResumeLayout(false);
            this.pnlSearchBar.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlTotalOverdue.ResumeLayout(false);
            this.pnlTotalDebt.ResumeLayout(false);
            this.pnlStatsCount.ResumeLayout(false);
            this.pnlDataGrid.ResumeLayout(false);
            this.tabControlDebt.ResumeLayout(false);
            this.tabPageReceivable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceivable)).EndInit();
            this.tabPagePayable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlSearchBar;
        private System.Windows.Forms.ComboBox cmbDebtType;
        private System.Windows.Forms.Label lblDebtTypeIcon;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlTotalOverdue;
        private System.Windows.Forms.Label lblTotalOverdue;
        private System.Windows.Forms.Label lblOverdueIcon;
        private System.Windows.Forms.Panel pnlTotalDebt;
        private System.Windows.Forms.Label lblTotalDebt;
        private System.Windows.Forms.Label lblTotalDebtIcon;
        private System.Windows.Forms.Panel pnlStatsCount;
        private System.Windows.Forms.Label lblStatsCount;
        private System.Windows.Forms.Label lblStatsIcon;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.TabControl tabControlDebt;
        private System.Windows.Forms.TabPage tabPageReceivable;
        private System.Windows.Forms.DataGridView dgvReceivable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_MaCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_NgayPhatSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_SoTienNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_SoTienDaTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_ConLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_HanThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivable_TrangThai;
        private System.Windows.Forms.TabPage tabPagePayable;
        private System.Windows.Forms.DataGridView dgvPayable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_MaCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_MaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_TenNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_NgayPhatSinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_SoTienNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_SoTienDaTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_ConLai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_HanThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payable_TrangThai;
    }
}