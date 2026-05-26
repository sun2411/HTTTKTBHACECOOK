namespace HTTKTBHACECOOK
{
    partial class JournalEntryManagementForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlSearchBar = new System.Windows.Forms.Panel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateRange = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.pnlTotalCredit = new System.Windows.Forms.Panel();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.lblCreditIcon = new System.Windows.Forms.Label();
            this.pnlTotalDebit = new System.Windows.Forms.Panel();
            this.lblTotalDebit = new System.Windows.Forms.Label();
            this.lblDebitIcon = new System.Windows.Forms.Label();
            this.pnlStatsCount = new System.Windows.Forms.Panel();
            this.lblStatsCount = new System.Windows.Forms.Label();
            this.lblStatsIcon = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlDataGrid = new System.Windows.Forms.Panel();
            this.dgvJournalEntries = new System.Windows.Forms.DataGridView();
            this.MaBT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGhiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChungTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiKhoanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiKhoanCo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienGiai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiGhiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader.SuspendLayout();
            this.pnlSearchBar.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlTotalCredit.SuspendLayout();
            this.pnlTotalDebit.SuspendLayout();
            this.pnlStatsCount.SuspendLayout();
            this.pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournalEntries)).BeginInit();
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
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblPageTitle.Location = new System.Drawing.Point(25, 20);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(700, 35);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "📚  QUẢN LÝ BÚT TOÁN KẾ TOÁN";
            this.lblPageTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSearchBar
            // 
            this.pnlSearchBar.BackColor = System.Drawing.Color.White;
            this.pnlSearchBar.Controls.Add(this.dtpEndDate);
            this.pnlSearchBar.Controls.Add(this.lblToDate);
            this.pnlSearchBar.Controls.Add(this.dtpStartDate);
            this.pnlSearchBar.Controls.Add(this.lblDateRange);
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
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(905, 20);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 23);
            this.dtpEndDate.TabIndex = 7;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(875, 23);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(21, 15);
            this.lblToDate.TabIndex = 6;
            this.lblToDate.Text = "➜";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(745, 20);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 23);
            this.dtpStartDate.TabIndex = 5;
            // 
            // lblDateRange
            // 
            this.lblDateRange.AutoSize = true;
            this.lblDateRange.Location = new System.Drawing.Point(700, 23);
            this.lblDateRange.Name = "lblDateRange";
            this.lblDateRange.Size = new System.Drawing.Size(19, 15);
            this.lblDateRange.TabIndex = 4;
            this.lblDateRange.Text = "📅";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(570, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(460, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(70, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(380, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.Location = new System.Drawing.Point(30, 23);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(19, 15);
            this.lblSearchIcon.TabIndex = 0;
            this.lblSearchIcon.Text = "🔍";
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlActions.Controls.Add(this.pnlTotalCredit);
            this.pnlActions.Controls.Add(this.pnlTotalDebit);
            this.pnlActions.Controls.Add(this.pnlStatsCount);
            this.pnlActions.Controls.Add(this.btnExport);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.btnEdit);
            this.pnlActions.Controls.Add(this.btnViewDetail);
            this.pnlActions.Controls.Add(this.btnAdd);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActions.Location = new System.Drawing.Point(0, 140);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(25, 15, 25, 15);
            this.pnlActions.Size = new System.Drawing.Size(1084, 80);
            this.pnlActions.TabIndex = 2;
            // 
            // pnlTotalCredit
            // 
            this.pnlTotalCredit.BackColor = System.Drawing.Color.OrangeRed;
            this.pnlTotalCredit.Controls.Add(this.lblTotalCredit);
            this.pnlTotalCredit.Controls.Add(this.lblCreditIcon);
            this.pnlTotalCredit.Location = new System.Drawing.Point(930, 15);
            this.pnlTotalCredit.Name = "pnlTotalCredit";
            this.pnlTotalCredit.Size = new System.Drawing.Size(140, 50);
            this.pnlTotalCredit.TabIndex = 7;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.AutoSize = true;
            this.lblTotalCredit.ForeColor = System.Drawing.Color.White;
            this.lblTotalCredit.Location = new System.Drawing.Point(40, 15);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(25, 15);
            this.lblTotalCredit.TabIndex = 1;
            this.lblTotalCredit.Text = "0 đ";
            // 
            // lblCreditIcon
            // 
            this.lblCreditIcon.AutoSize = true;
            this.lblCreditIcon.ForeColor = System.Drawing.Color.White;
            this.lblCreditIcon.Location = new System.Drawing.Point(10, 15);
            this.lblCreditIcon.Name = "lblCreditIcon";
            this.lblCreditIcon.Size = new System.Drawing.Size(19, 15);
            this.lblCreditIcon.TabIndex = 0;
            this.lblCreditIcon.Text = "📤";
            // 
            // pnlTotalDebit
            // 
            this.pnlTotalDebit.BackColor = System.Drawing.Color.SeaGreen;
            this.pnlTotalDebit.Controls.Add(this.lblTotalDebit);
            this.pnlTotalDebit.Controls.Add(this.lblDebitIcon);
            this.pnlTotalDebit.Location = new System.Drawing.Point(780, 15);
            this.pnlTotalDebit.Name = "pnlTotalDebit";
            this.pnlTotalDebit.Size = new System.Drawing.Size(140, 50);
            this.pnlTotalDebit.TabIndex = 6;
            // 
            // lblTotalDebit
            // 
            this.lblTotalDebit.AutoSize = true;
            this.lblTotalDebit.ForeColor = System.Drawing.Color.White;
            this.lblTotalDebit.Location = new System.Drawing.Point(40, 15);
            this.lblTotalDebit.Name = "lblTotalDebit";
            this.lblTotalDebit.Size = new System.Drawing.Size(25, 15);
            this.lblTotalDebit.TabIndex = 1;
            this.lblTotalDebit.Text = "0 đ";
            // 
            // lblDebitIcon
            // 
            this.lblDebitIcon.AutoSize = true;
            this.lblDebitIcon.ForeColor = System.Drawing.Color.White;
            this.lblDebitIcon.Location = new System.Drawing.Point(10, 15);
            this.lblDebitIcon.Name = "lblDebitIcon";
            this.lblDebitIcon.Size = new System.Drawing.Size(19, 15);
            this.lblDebitIcon.TabIndex = 0;
            this.lblDebitIcon.Text = "📥";
            // 
            // pnlStatsCount
            // 
            this.pnlStatsCount.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlStatsCount.Controls.Add(this.lblStatsCount);
            this.pnlStatsCount.Controls.Add(this.lblStatsIcon);
            this.pnlStatsCount.Location = new System.Drawing.Point(630, 15);
            this.pnlStatsCount.Name = "pnlStatsCount";
            this.pnlStatsCount.Size = new System.Drawing.Size(140, 50);
            this.pnlStatsCount.TabIndex = 5;
            // 
            // lblStatsCount
            // 
            this.lblStatsCount.AutoSize = true;
            this.lblStatsCount.ForeColor = System.Drawing.Color.White;
            this.lblStatsCount.Location = new System.Drawing.Point(40, 15);
            this.lblStatsCount.Name = "lblStatsCount";
            this.lblStatsCount.Size = new System.Drawing.Size(63, 15);
            this.lblStatsCount.TabIndex = 1;
            this.lblStatsCount.Text = "0 bút toán";
            // 
            // lblStatsIcon
            // 
            this.lblStatsIcon.AutoSize = true;
            this.lblStatsIcon.ForeColor = System.Drawing.Color.White;
            this.lblStatsIcon.Location = new System.Drawing.Point(10, 15);
            this.lblStatsIcon.Name = "lblStatsIcon";
            this.lblStatsIcon.Size = new System.Drawing.Size(19, 15);
            this.lblStatsIcon.TabIndex = 0;
            this.lblStatsIcon.Text = "📊";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(505, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(110, 50);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "📊 Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(385, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 50);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(145, 15);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 50);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏️ Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btnViewDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnViewDetail.ForeColor = System.Drawing.Color.White;
            this.btnViewDetail.Location = new System.Drawing.Point(265, 15);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(110, 50);
            this.btnViewDetail.TabIndex = 2;
            this.btnViewDetail.Text = "👁️ Chi tiết";
            this.btnViewDetail.UseVisualStyleBackColor = false;
            this.btnViewDetail.Click += new System.EventHandler(this.btnViewDetail_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(25, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 50);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "➕ Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlDataGrid
            // 
            this.pnlDataGrid.Controls.Add(this.dgvJournalEntries);
            this.pnlDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDataGrid.Location = new System.Drawing.Point(0, 220);
            this.pnlDataGrid.Name = "pnlDataGrid";
            this.pnlDataGrid.Padding = new System.Windows.Forms.Padding(25, 10, 25, 25);
            this.pnlDataGrid.Size = new System.Drawing.Size(1084, 468);
            this.pnlDataGrid.TabIndex = 3;
            // 
            // dgvJournalEntries
            // 
            this.dgvJournalEntries.AllowUserToAddRows = false;
            this.dgvJournalEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJournalEntries.BackgroundColor = System.Drawing.Color.White;
            this.dgvJournalEntries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJournalEntries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJournalEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJournalEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaBT,
            this.NgayGhiSo,
            this.ChungTu,
            this.TaiKhoanNo,
            this.TaiKhoanCo,
            this.SoTien,
            this.DienGiai,
            this.NguoiGhiSo,
            this.TrangThai});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJournalEntries.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJournalEntries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvJournalEntries.EnableHeadersVisualStyles = false;
            this.dgvJournalEntries.Location = new System.Drawing.Point(25, 10);
            this.dgvJournalEntries.MultiSelect = false;
            this.dgvJournalEntries.Name = "dgvJournalEntries";
            this.dgvJournalEntries.ReadOnly = true;
            this.dgvJournalEntries.RowHeadersVisible = false;
            this.dgvJournalEntries.RowTemplate.Height = 40;
            this.dgvJournalEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvJournalEntries.Size = new System.Drawing.Size(1034, 433);
            this.dgvJournalEntries.TabIndex = 0;
            // 
            // MaBT
            // 
            this.MaBT.DataPropertyName = "MaBT";
            this.MaBT.FillWeight = 70F;
            this.MaBT.HeaderText = "Mã BT";
            this.MaBT.Name = "MaBT";
            this.MaBT.ReadOnly = true;
            // 
            // NgayGhiSo
            // 
            this.NgayGhiSo.DataPropertyName = "NgayGhiSo";
            this.NgayGhiSo.FillWeight = 80F;
            this.NgayGhiSo.HeaderText = "Ngày ghi sổ";
            this.NgayGhiSo.Name = "NgayGhiSo";
            this.NgayGhiSo.ReadOnly = true;
            // 
            // ChungTu
            // 
            this.ChungTu.DataPropertyName = "ChungTu";
            this.ChungTu.FillWeight = 70F;
            this.ChungTu.HeaderText = "Chứng từ";
            this.ChungTu.Name = "ChungTu";
            this.ChungTu.ReadOnly = true;
            // 
            // TaiKhoanNo
            // 
            this.TaiKhoanNo.DataPropertyName = "TKNo";
            this.TaiKhoanNo.FillWeight = 60F;
            this.TaiKhoanNo.HeaderText = "TK Nợ";
            this.TaiKhoanNo.Name = "TaiKhoanNo";
            this.TaiKhoanNo.ReadOnly = true;
            // 
            // TaiKhoanCo
            // 
            this.TaiKhoanCo.DataPropertyName = "TKCo";
            this.TaiKhoanCo.FillWeight = 60F;
            this.TaiKhoanCo.HeaderText = "TK Có";
            this.TaiKhoanCo.Name = "TaiKhoanCo";
            this.TaiKhoanCo.ReadOnly = true;
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            this.SoTien.HeaderText = "Số tiền";
            this.SoTien.Name = "SoTien";
            this.SoTien.ReadOnly = true;
            // 
            // DienGiai
            // 
            this.DienGiai.DataPropertyName = "DienGiai";
            this.DienGiai.FillWeight = 250F;
            this.DienGiai.HeaderText = "Diễn giải";
            this.DienGiai.Name = "DienGiai";
            this.DienGiai.ReadOnly = true;
            // 
            // NguoiGhiSo
            // 
            this.NguoiGhiSo.DataPropertyName = "NguoiGhiSo";
            this.NguoiGhiSo.FillWeight = 120F;
            this.NguoiGhiSo.HeaderText = "Người ghi sổ";
            this.NguoiGhiSo.Name = "NguoiGhiSo";
            this.NguoiGhiSo.ReadOnly = true;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.FillWeight = 80F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            // 
            // JournalEntryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1084, 688);
            this.Controls.Add(this.pnlDataGrid);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlSearchBar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JournalEntryManagementForm";
            this.Text = "Quản lý Bút toán";
            this.Load += new System.EventHandler(this.JournalEntryManagementForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlSearchBar.ResumeLayout(false);
            this.pnlSearchBar.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlTotalCredit.ResumeLayout(false);
            this.pnlTotalCredit.PerformLayout();
            this.pnlTotalDebit.ResumeLayout(false);
            this.pnlTotalDebit.PerformLayout();
            this.pnlStatsCount.ResumeLayout(false);
            this.pnlStatsCount.PerformLayout();
            this.pnlDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJournalEntries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel pnlSearchBar;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel pnlStatsCount;
        private System.Windows.Forms.Label lblStatsCount;
        private System.Windows.Forms.Label lblStatsIcon;
        private System.Windows.Forms.Panel pnlTotalDebit;
        private System.Windows.Forms.Label lblTotalDebit;
        private System.Windows.Forms.Label lblDebitIcon;
        private System.Windows.Forms.Panel pnlTotalCredit;
        private System.Windows.Forms.Label lblTotalCredit;
        private System.Windows.Forms.Label lblCreditIcon;
        private System.Windows.Forms.Panel pnlDataGrid;
        private System.Windows.Forms.DataGridView dgvJournalEntries;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGhiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChungTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoanCo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienGiai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiGhiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}