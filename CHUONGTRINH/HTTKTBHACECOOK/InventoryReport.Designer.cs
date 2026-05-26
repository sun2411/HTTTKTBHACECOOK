namespace HTTKTBHACECOOK
{
    partial class InventoryReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlNhaCungCap = new System.Windows.Forms.Panel();
            this.lblNhaCungCapValue = new System.Windows.Forms.Label();
            this.lblNhaCungCapLabel = new System.Windows.Forms.Label();
            this.pnlConHang = new System.Windows.Forms.Panel();
            this.lblConHangValue = new System.Windows.Forms.Label();
            this.lblConHangLabel = new System.Windows.Forms.Label();
            this.pnlSanPham = new System.Windows.Forms.Panel();
            this.lblSanPhamValue = new System.Windows.Forms.Label();
            this.lblSanPhamLabel = new System.Windows.Forms.Label();
            this.pnlTongGiaTri = new System.Windows.Forms.Panel();
            this.lblTongGiaTriValue = new System.Windows.Forms.Label();
            this.lblTongGiaTriLabel = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.cmbLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            // Đã xóa btnExportPDF và btnExportExcel
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTietTheoKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlNhaCungCap.SuspendLayout();
            this.pnlConHang.SuspendLayout();
            this.pnlSanPham.SuspendLayout();
            this.pnlTongGiaTri.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlTop.Size = new System.Drawing.Size(1400, 70);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(281, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO TỒN KHO";
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.Controls.Add(this.pnlNhaCungCap);
            this.pnlStats.Controls.Add(this.pnlConHang);
            this.pnlStats.Controls.Add(this.pnlSanPham);
            this.pnlStats.Controls.Add(this.pnlTongGiaTri);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 70);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlStats.Size = new System.Drawing.Size(1400, 120);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlNhaCungCap
            // 
            this.pnlNhaCungCap.BackColor = System.Drawing.Color.White;
            this.pnlNhaCungCap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNhaCungCap.Controls.Add(this.lblNhaCungCapValue);
            this.pnlNhaCungCap.Controls.Add(this.lblNhaCungCapLabel);
            this.pnlNhaCungCap.Location = new System.Drawing.Point(1040, 15);
            this.pnlNhaCungCap.Name = "pnlNhaCungCap";
            this.pnlNhaCungCap.Size = new System.Drawing.Size(320, 90);
            this.pnlNhaCungCap.TabIndex = 3;
            // 
            // lblNhaCungCapValue
            // 
            this.lblNhaCungCapValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblNhaCungCapValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblNhaCungCapValue.Location = new System.Drawing.Point(10, 45);
            this.lblNhaCungCapValue.Name = "lblNhaCungCapValue";
            this.lblNhaCungCapValue.Size = new System.Drawing.Size(298, 35);
            this.lblNhaCungCapValue.TabIndex = 1;
            this.lblNhaCungCapValue.Text = "0";
            this.lblNhaCungCapValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNhaCungCapLabel
            // 
            this.lblNhaCungCapLabel.AutoSize = true;
            this.lblNhaCungCapLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhaCungCapLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblNhaCungCapLabel.Location = new System.Drawing.Point(10, 15);
            this.lblNhaCungCapLabel.Name = "lblNhaCungCapLabel";
            this.lblNhaCungCapLabel.Size = new System.Drawing.Size(68, 19);
            this.lblNhaCungCapLabel.TabIndex = 0;
            this.lblNhaCungCapLabel.Text = "Hết hàng";
            // 
            // pnlConHang
            // 
            this.pnlConHang.BackColor = System.Drawing.Color.White;
            this.pnlConHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConHang.Controls.Add(this.lblConHangValue);
            this.pnlConHang.Controls.Add(this.lblConHangLabel);
            this.pnlConHang.Location = new System.Drawing.Point(700, 15);
            this.pnlConHang.Name = "pnlConHang";
            this.pnlConHang.Size = new System.Drawing.Size(320, 90);
            this.pnlConHang.TabIndex = 2;
            // 
            // lblConHangValue
            // 
            this.lblConHangValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblConHangValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblConHangValue.Location = new System.Drawing.Point(10, 45);
            this.lblConHangValue.Name = "lblConHangValue";
            this.lblConHangValue.Size = new System.Drawing.Size(298, 35);
            this.lblConHangValue.TabIndex = 1;
            this.lblConHangValue.Text = "0";
            this.lblConHangValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConHangLabel
            // 
            this.lblConHangLabel.AutoSize = true;
            this.lblConHangLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblConHangLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblConHangLabel.Location = new System.Drawing.Point(10, 15);
            this.lblConHangLabel.Name = "lblConHangLabel";
            this.lblConHangLabel.Size = new System.Drawing.Size(69, 19);
            this.lblConHangLabel.TabIndex = 0;
            this.lblConHangLabel.Text = "Còn hàng";
            // 
            // pnlSanPham
            // 
            this.pnlSanPham.BackColor = System.Drawing.Color.White;
            this.pnlSanPham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSanPham.Controls.Add(this.lblSanPhamValue);
            this.pnlSanPham.Controls.Add(this.lblSanPhamLabel);
            this.pnlSanPham.Location = new System.Drawing.Point(360, 15);
            this.pnlSanPham.Name = "pnlSanPham";
            this.pnlSanPham.Size = new System.Drawing.Size(320, 90);
            this.pnlSanPham.TabIndex = 1;
            // 
            // lblSanPhamValue
            // 
            this.lblSanPhamValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSanPhamValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.lblSanPhamValue.Location = new System.Drawing.Point(10, 45);
            this.lblSanPhamValue.Name = "lblSanPhamValue";
            this.lblSanPhamValue.Size = new System.Drawing.Size(298, 35);
            this.lblSanPhamValue.TabIndex = 1;
            this.lblSanPhamValue.Text = "0";
            this.lblSanPhamValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSanPhamLabel
            // 
            this.lblSanPhamLabel.AutoSize = true;
            this.lblSanPhamLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSanPhamLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblSanPhamLabel.Location = new System.Drawing.Point(10, 15);
            this.lblSanPhamLabel.Name = "lblSanPhamLabel";
            this.lblSanPhamLabel.Size = new System.Drawing.Size(107, 19);
            this.lblSanPhamLabel.TabIndex = 0;
            this.lblSanPhamLabel.Text = "Tổng sản phẩm";
            // 
            // pnlTongGiaTri
            // 
            this.pnlTongGiaTri.BackColor = System.Drawing.Color.White;
            this.pnlTongGiaTri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongGiaTri.Controls.Add(this.lblTongGiaTriValue);
            this.pnlTongGiaTri.Controls.Add(this.lblTongGiaTriLabel);
            this.pnlTongGiaTri.Location = new System.Drawing.Point(20, 15);
            this.pnlTongGiaTri.Name = "pnlTongGiaTri";
            this.pnlTongGiaTri.Size = new System.Drawing.Size(320, 90);
            this.pnlTongGiaTri.TabIndex = 0;
            // 
            // lblTongGiaTriValue
            // 
            this.lblTongGiaTriValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaTriValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.lblTongGiaTriValue.Location = new System.Drawing.Point(10, 45);
            this.lblTongGiaTriValue.Name = "lblTongGiaTriValue";
            this.lblTongGiaTriValue.Size = new System.Drawing.Size(298, 35);
            this.lblTongGiaTriValue.TabIndex = 1;
            this.lblTongGiaTriValue.Text = "0 VNĐ";
            this.lblTongGiaTriValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTongGiaTriLabel
            // 
            this.lblTongGiaTriLabel.AutoSize = true;
            this.lblTongGiaTriLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTongGiaTriLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblTongGiaTriLabel.Location = new System.Drawing.Point(10, 15);
            this.lblTongGiaTriLabel.Name = "lblTongGiaTriLabel";
            this.lblTongGiaTriLabel.Size = new System.Drawing.Size(129, 19);
            this.lblTongGiaTriLabel.TabIndex = 0;
            this.lblTongGiaTriLabel.Text = "Tổng giá trị tồn kho";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.cmbLoaiSanPham);
            this.pnlFilter.Controls.Add(this.lblLoai);
            this.pnlFilter.Controls.Add(this.txtSearch);
            this.pnlFilter.Controls.Add(this.lblSearch);
            this.pnlFilter.Controls.Add(this.btnPrint);
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 190);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.pnlFilter.Size = new System.Drawing.Size(1400, 80);
            this.pnlFilter.TabIndex = 2;
            // 
            // cmbLoaiSanPham
            // 
            this.cmbLoaiSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLoaiSanPham.FormattingEnabled = true;
            this.cmbLoaiSanPham.Location = new System.Drawing.Point(420, 25);
            this.cmbLoaiSanPham.Name = "cmbLoaiSanPham";
            this.cmbLoaiSanPham.Size = new System.Drawing.Size(150, 25);
            this.cmbLoaiSanPham.TabIndex = 8;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblLoai.Location = new System.Drawing.Point(370, 28);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(38, 19);
            this.lblLoai.TabIndex = 7;
            this.lblLoai.Text = "Loại";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(90, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 25);
            this.txtSearch.TabIndex = 6;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSearch.Location = new System.Drawing.Point(20, 28);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(71, 19);
            this.lblSearch.TabIndex = 5;
            this.lblSearch.Text = "Tìm kiếm";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            // VỊ TRÍ MỚI: Dời lại gần nút Refresh (Vị trí cũ của btnExportExcel)
            this.btnPrint.Location = new System.Drawing.Point(840, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(160, 40);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "🖨️ In báo cáo";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(720, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 1;
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
            this.btnSearch.Location = new System.Drawing.Point(590, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 40);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.dgvInventory);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 270);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.pnlMain.Size = new System.Drawing.Size(1400, 530);
            this.pnlMain.TabIndex = 3;
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInventory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(202)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(202)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSanPham,
            this.Loai,
            this.Gia,
            this.TonKho,
            this.GiaTri,
            this.ChiTietTheoKho});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInventory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventory.EnableHeadersVisualStyles = false;
            this.dgvInventory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            this.dgvInventory.Location = new System.Drawing.Point(20, 20);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInventory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowTemplate.Height = 45;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(1360, 490);
            this.dgvInventory.TabIndex = 0;
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.FillWeight = 60F;
            this.MaSP.HeaderText = "Mã SP";
            this.MaSP.Name = "MaSP";
            this.MaSP.ReadOnly = true;
            // 
            // TenSanPham
            // 
            this.TenSanPham.DataPropertyName = "TenSanPham";
            this.TenSanPham.FillWeight = 140F;
            this.TenSanPham.HeaderText = "Tên Sản Phẩm";
            this.TenSanPham.Name = "TenSanPham";
            this.TenSanPham.ReadOnly = true;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.FillWeight = 70F;
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            this.Loai.ReadOnly = true;
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.FillWeight = 80F;
            this.Gia.HeaderText = "Giá";
            this.Gia.Name = "Gia";
            this.Gia.ReadOnly = true;
            // 
            // TonKho
            // 
            this.TonKho.DataPropertyName = "TonKho";
            this.TonKho.FillWeight = 70F;
            this.TonKho.HeaderText = "Tồn Kho";
            this.TonKho.Name = "TonKho";
            this.TonKho.ReadOnly = true;
            // 
            // GiaTri
            // 
            this.GiaTri.DataPropertyName = "GiaTri";
            this.GiaTri.FillWeight = 100F;
            this.GiaTri.HeaderText = "Giá Trị";
            this.GiaTri.Name = "GiaTri";
            this.GiaTri.ReadOnly = true;
            // 
            // ChiTietTheoKho
            // 
            this.ChiTietTheoKho.DataPropertyName = "ChiTietTheoKho";
            this.ChiTietTheoKho.FillWeight = 150F;
            this.ChiTietTheoKho.HeaderText = "Chi Tiết Theo Kho";
            this.ChiTietTheoKho.Name = "ChiTietTheoKho";
            this.ChiTietTheoKho.ReadOnly = true;
            // 
            // InventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlTop);
            this.Name = "InventoryReport";
            this.Text = "Báo cáo Tồn kho";
            this.Load += new System.EventHandler(this.InventoryReport_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlNhaCungCap.ResumeLayout(false);
            this.pnlNhaCungCap.PerformLayout();
            this.pnlConHang.ResumeLayout(false);
            this.pnlConHang.PerformLayout();
            this.pnlSanPham.ResumeLayout(false);
            this.pnlSanPham.PerformLayout();
            this.pnlTongGiaTri.ResumeLayout(false);
            this.pnlTongGiaTri.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel pnlNhaCungCap;
        private System.Windows.Forms.Label lblNhaCungCapValue;
        private System.Windows.Forms.Label lblNhaCungCapLabel;
        private System.Windows.Forms.Panel pnlConHang;
        private System.Windows.Forms.Label lblConHangValue;
        private System.Windows.Forms.Label lblConHangLabel;
        private System.Windows.Forms.Panel pnlSanPham;
        private System.Windows.Forms.Label lblSanPhamValue;
        private System.Windows.Forms.Label lblSanPhamLabel;
        private System.Windows.Forms.Panel pnlTongGiaTri;
        private System.Windows.Forms.Label lblTongGiaTriValue;
        private System.Windows.Forms.Label lblTongGiaTriLabel;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.ComboBox cmbLoaiSanPham;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn TonKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiTietTheoKho;
    }
}