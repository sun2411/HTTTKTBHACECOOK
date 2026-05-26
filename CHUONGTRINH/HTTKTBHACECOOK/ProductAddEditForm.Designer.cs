namespace HTTKTBHACECOOK
{
    partial class ProductAddEditForm
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
            this.pnlBOM = new System.Windows.Forms.Panel();
            this.dgvBOM = new System.Windows.Forms.DataGridView();
            this.lblBOMTitle = new System.Windows.Forms.Label();
            this.pnlProductInfo = new System.Windows.Forms.Panel();
            this.tlpProduct = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle_MaSP = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblTitle_TenSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblTitle_LoaiSP = new System.Windows.Forms.Label();
            this.cmbLoaiSP = new System.Windows.Forms.ComboBox();
            this.lblTitle_GiaBan = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.lblTitle_MoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblTitle_NSX = new System.Windows.Forms.Label();
            this.dtpNSX = new System.Windows.Forms.DateTimePicker();
            this.lblTitle_HSD = new System.Windows.Forms.Label();
            this.dtpHSD = new System.Windows.Forms.DateTimePicker();
            this.lblTitle_NhietDo = new System.Windows.Forms.Label();
            this.txtNhietDo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlBOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).BeginInit();
            this.pnlProductInfo.SuspendLayout();
            this.tlpProduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlBOM);
            this.pnlMain.Controls.Add(this.pnlProductInfo);
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
            // pnlBOM
            // 
            this.pnlBOM.Controls.Add(this.dgvBOM);
            this.pnlBOM.Controls.Add(this.lblBOMTitle);
            this.pnlBOM.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBOM.Location = new System.Drawing.Point(15, 360);
            this.pnlBOM.Name = "pnlBOM";
            this.pnlBOM.Size = new System.Drawing.Size(920, 335);
            this.pnlBOM.TabIndex = 4;
            // 
            // dgvBOM
            // 
            this.dgvBOM.AllowUserToAddRows = false;
            this.dgvBOM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBOM.BackgroundColor = System.Drawing.Color.White;
            this.dgvBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvBOM.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM.Location = new System.Drawing.Point(0, 30);
            this.dgvBOM.Name = "dgvBOM";
            this.dgvBOM.RowHeadersWidth = 51;
            this.dgvBOM.RowTemplate.Height = 30;
            this.dgvBOM.Size = new System.Drawing.Size(920, 305);
            this.dgvBOM.TabIndex = 1;
            // 
            // lblBOMTitle
            // 
            this.lblBOMTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBOMTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBOMTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.lblBOMTitle.Location = new System.Drawing.Point(0, 0);
            this.lblBOMTitle.Name = "lblBOMTitle";
            this.lblBOMTitle.Size = new System.Drawing.Size(920, 30);
            this.lblBOMTitle.TabIndex = 0;
            this.lblBOMTitle.Text = "ĐỊNH MỨC NGUYÊN VẬT LIỆU (BOM)";
            this.lblBOMTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlProductInfo
            // 
            this.pnlProductInfo.Controls.Add(this.tlpProduct);
            this.pnlProductInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProductInfo.Location = new System.Drawing.Point(15, 65);
            this.pnlProductInfo.Name = "pnlProductInfo";
            this.pnlProductInfo.Size = new System.Drawing.Size(920, 295);
            this.pnlProductInfo.TabIndex = 3;
            // 
            // tlpProduct
            // 
            this.tlpProduct.ColumnCount = 4;
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpProduct.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpProduct.Controls.Add(this.lblTitle_MaSP, 0, 0);
            this.tlpProduct.Controls.Add(this.txtMaSP, 1, 0);
            this.tlpProduct.Controls.Add(this.lblTitle_TenSP, 0, 1);
            this.tlpProduct.Controls.Add(this.txtTenSP, 1, 1);
            this.tlpProduct.Controls.Add(this.lblTitle_LoaiSP, 0, 2);
            this.tlpProduct.Controls.Add(this.cmbLoaiSP, 1, 2);
            this.tlpProduct.Controls.Add(this.lblTitle_GiaBan, 0, 3);
            this.tlpProduct.Controls.Add(this.txtGiaBan, 1, 3);
            this.tlpProduct.Controls.Add(this.lblTitle_MoTa, 0, 4);
            this.tlpProduct.Controls.Add(this.txtMoTa, 1, 4);
            this.tlpProduct.Controls.Add(this.lblTitle_NSX, 2, 0);
            this.tlpProduct.Controls.Add(this.dtpNSX, 3, 0);
            this.tlpProduct.Controls.Add(this.lblTitle_HSD, 2, 1);
            this.tlpProduct.Controls.Add(this.dtpHSD, 3, 1);
            this.tlpProduct.Controls.Add(this.lblTitle_NhietDo, 2, 2);
            this.tlpProduct.Controls.Add(this.txtNhietDo, 3, 2);
            this.tlpProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProduct.Location = new System.Drawing.Point(0, 0);
            this.tlpProduct.Name = "tlpProduct";
            this.tlpProduct.RowCount = 5;
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpProduct.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpProduct.Size = new System.Drawing.Size(920, 295);
            this.tlpProduct.TabIndex = 0;
            // 
            // lblTitle_MaSP
            // 
            this.lblTitle_MaSP.AutoSize = true;
            this.lblTitle_MaSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_MaSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_MaSP.Location = new System.Drawing.Point(3, 0);
            this.lblTitle_MaSP.Name = "lblTitle_MaSP";
            this.lblTitle_MaSP.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_MaSP.TabIndex = 0;
            this.lblTitle_MaSP.Text = "Mã Sản phẩm (*):";
            this.lblTitle_MaSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSP.Location = new System.Drawing.Point(141, 6);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(316, 27);
            this.txtMaSP.TabIndex = 1;
            // 
            // lblTitle_TenSP
            // 
            this.lblTitle_TenSP.AutoSize = true;
            this.lblTitle_TenSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_TenSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_TenSP.Location = new System.Drawing.Point(3, 40);
            this.lblTitle_TenSP.Name = "lblTitle_TenSP";
            this.lblTitle_TenSP.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_TenSP.TabIndex = 2;
            this.lblTitle_TenSP.Text = "Tên Sản phẩm (*):";
            this.lblTitle_TenSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSP.Location = new System.Drawing.Point(141, 46);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(316, 27);
            this.txtTenSP.TabIndex = 3;
            // 
            // lblTitle_LoaiSP
            // 
            this.lblTitle_LoaiSP.AutoSize = true;
            this.lblTitle_LoaiSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_LoaiSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_LoaiSP.Location = new System.Drawing.Point(3, 80);
            this.lblTitle_LoaiSP.Name = "lblTitle_LoaiSP";
            this.lblTitle_LoaiSP.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_LoaiSP.TabIndex = 4;
            this.lblTitle_LoaiSP.Text = "Loại Sản phẩm (*):";
            this.lblTitle_LoaiSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLoaiSP
            // 
            this.cmbLoaiSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLoaiSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiSP.FormattingEnabled = true;
            this.cmbLoaiSP.Location = new System.Drawing.Point(141, 87);
            this.cmbLoaiSP.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.cmbLoaiSP.Name = "cmbLoaiSP";
            this.cmbLoaiSP.Size = new System.Drawing.Size(316, 25);
            this.cmbLoaiSP.TabIndex = 5;
            // 
            // lblTitle_GiaBan
            // 
            this.lblTitle_GiaBan.AutoSize = true;
            this.lblTitle_GiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_GiaBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_GiaBan.Location = new System.Drawing.Point(3, 120);
            this.lblTitle_GiaBan.Name = "lblTitle_GiaBan";
            this.lblTitle_GiaBan.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_GiaBan.TabIndex = 6;
            this.lblTitle_GiaBan.Text = "Giá bán (*):";
            this.lblTitle_GiaBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGiaBan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBan.Location = new System.Drawing.Point(141, 126);
            this.txtGiaBan.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(316, 27);
            this.txtGiaBan.TabIndex = 7;
            // 
            // lblTitle_MoTa
            // 
            this.lblTitle_MoTa.AutoSize = true;
            this.lblTitle_MoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_MoTa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_MoTa.Location = new System.Drawing.Point(3, 160);
            this.lblTitle_MoTa.Name = "lblTitle_MoTa";
            this.lblTitle_MoTa.Size = new System.Drawing.Size(132, 135);
            this.lblTitle_MoTa.TabIndex = 8;
            this.lblTitle_MoTa.Text = "Mô tả:";
            this.lblTitle_MoTa.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // txtMoTa
            // 
            this.tlpProduct.SetColumnSpan(this.txtMoTa, 3);
            this.txtMoTa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMoTa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Location = new System.Drawing.Point(141, 166);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(776, 126);
            this.txtMoTa.TabIndex = 9;
            // 
            // lblTitle_NSX
            // 
            this.lblTitle_NSX.AutoSize = true;
            this.lblTitle_NSX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_NSX.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_NSX.Location = new System.Drawing.Point(463, 0);
            this.lblTitle_NSX.Name = "lblTitle_NSX";
            this.lblTitle_NSX.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_NSX.TabIndex = 10;
            this.lblTitle_NSX.Text = "Ngày Sản xuất (NSX):";
            this.lblTitle_NSX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNSX
            // 
            this.dtpNSX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNSX.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNSX.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNSX.Location = new System.Drawing.Point(601, 6);
            this.dtpNSX.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.dtpNSX.Name = "dtpNSX";
            this.dtpNSX.Size = new System.Drawing.Size(316, 27);
            this.dtpNSX.TabIndex = 11;
            // 
            // lblTitle_HSD
            // 
            this.lblTitle_HSD.AutoSize = true;
            this.lblTitle_HSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_HSD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_HSD.Location = new System.Drawing.Point(463, 40);
            this.lblTitle_HSD.Name = "lblTitle_HSD";
            this.lblTitle_HSD.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_HSD.TabIndex = 12;
            this.lblTitle_HSD.Text = "Hạn sử dụng (HSD):";
            this.lblTitle_HSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpHSD
            // 
            this.dtpHSD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpHSD.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHSD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHSD.Location = new System.Drawing.Point(601, 46);
            this.dtpHSD.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.dtpHSD.Name = "dtpHSD";
            this.dtpHSD.Size = new System.Drawing.Size(316, 27);
            this.dtpHSD.TabIndex = 13;
            // 
            // lblTitle_NhietDo
            // 
            this.lblTitle_NhietDo.AutoSize = true;
            this.lblTitle_NhietDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_NhietDo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_NhietDo.Location = new System.Drawing.Point(463, 80);
            this.lblTitle_NhietDo.Name = "lblTitle_NhietDo";
            this.lblTitle_NhietDo.Size = new System.Drawing.Size(132, 40);
            this.lblTitle_NhietDo.TabIndex = 14;
            this.lblTitle_NhietDo.Text = "Nhiệt độ BQ:";
            this.lblTitle_NhietDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNhietDo
            // 
            this.txtNhietDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNhietDo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhietDo.Location = new System.Drawing.Point(601, 86);
            this.txtNhietDo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtNhietDo.Name = "txtNhietDo";
            this.txtNhietDo.Size = new System.Drawing.Size(316, 27);
            this.txtNhietDo.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(795, 705); // ĐÃ SỬA: Location
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
            this.lblTitle.Location = new System.Drawing.Point(15, 15); // ĐÃ SỬA: Location
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(920, 50);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "THÊM MỚI SẢN PHẨM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(665, 705); // ĐÃ SỬA: Location
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Hủy";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProductAddEditForm
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
            this.Name = "ProductAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm/Sửa Sản phẩm";
            this.Load += new System.EventHandler(this.ProductAddEditForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlBOM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).EndInit();
            this.pnlProductInfo.ResumeLayout(false);
            this.tlpProduct.ResumeLayout(false);
            this.tlpProduct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlProductInfo;
        private System.Windows.Forms.TableLayoutPanel tlpProduct;
        private System.Windows.Forms.Label lblTitle_MaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblTitle_TenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblTitle_LoaiSP;
        private System.Windows.Forms.ComboBox cmbLoaiSP;
        private System.Windows.Forms.Label lblTitle_GiaBan;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label lblTitle_MoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblTitle_NSX;
        private System.Windows.Forms.DateTimePicker dtpNSX;
        private System.Windows.Forms.Label lblTitle_HSD;
        private System.Windows.Forms.DateTimePicker dtpHSD;
        private System.Windows.Forms.Label lblTitle_NhietDo;
        private System.Windows.Forms.TextBox txtNhietDo;
        private System.Windows.Forms.Panel pnlBOM;
        private System.Windows.Forms.DataGridView dgvBOM;
        private System.Windows.Forms.Label lblBOMTitle;
    }
}