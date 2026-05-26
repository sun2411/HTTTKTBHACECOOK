namespace HTTKTBHACECOOK
{
    partial class MaterialAddEditForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle_MaNL = new System.Windows.Forms.Label();
            this.txtMaNL = new System.Windows.Forms.TextBox();
            this.lblTitle_TenNL = new System.Windows.Forms.Label();
            this.txtTenNL = new System.Windows.Forms.TextBox();
            this.lblTitle_DVT = new System.Windows.Forms.Label();
            this.cmbDVT = new System.Windows.Forms.ComboBox();
            this.lblTitle_SoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.tlpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(650, 400);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.btnSave);
            this.pnlContent.Controls.Add(this.btnClose);
            this.pnlContent.Controls.Add(this.tlpDetails);
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(10, 10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(630, 380);
            this.pnlContent.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(380, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(500, 320);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Hủy";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tlpDetails
            // 
            this.tlpDetails.ColumnCount = 2;
            // --- CHỈNH SỬA QUAN TRỌNG: CỐ ĐỊNH CỘT 1 (150px) ---
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // ----------------------------------------------------
            this.tlpDetails.Controls.Add(this.lblTitle_MaNL, 0, 0);
            this.tlpDetails.Controls.Add(this.txtMaNL, 1, 0);
            this.tlpDetails.Controls.Add(this.lblTitle_TenNL, 0, 1);
            this.tlpDetails.Controls.Add(this.txtTenNL, 1, 1);
            this.tlpDetails.Controls.Add(this.lblTitle_DVT, 0, 2);
            this.tlpDetails.Controls.Add(this.cmbDVT, 1, 2);
            this.tlpDetails.Controls.Add(this.lblTitle_SoLuong, 0, 3);
            this.tlpDetails.Controls.Add(this.txtSoLuong, 1, 3);
            this.tlpDetails.Location = new System.Drawing.Point(20, 70);
            this.tlpDetails.Name = "tlpDetails";
            this.tlpDetails.RowCount = 4;
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpDetails.Size = new System.Drawing.Size(580, 210);
            this.tlpDetails.TabIndex = 1;
            // 
            // lblTitle_MaNL
            // 
            this.lblTitle_MaNL.AutoSize = true;
            this.lblTitle_MaNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_MaNL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_MaNL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle_MaNL.Location = new System.Drawing.Point(3, 0);
            this.lblTitle_MaNL.Name = "lblTitle_MaNL";
            this.lblTitle_MaNL.Size = new System.Drawing.Size(144, 50);
            this.lblTitle_MaNL.TabIndex = 0;
            this.lblTitle_MaNL.Text = "Mã NVL (*):";
            this.lblTitle_MaNL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaNL
            // 
            this.txtMaNL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaNL.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNL.Location = new System.Drawing.Point(153, 9);
            this.txtMaNL.Name = "txtMaNL";
            this.txtMaNL.Size = new System.Drawing.Size(424, 32);
            this.txtMaNL.TabIndex = 1;
            // 
            // lblTitle_TenNL
            // 
            this.lblTitle_TenNL.AutoSize = true;
            this.lblTitle_TenNL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_TenNL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_TenNL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle_TenNL.Location = new System.Drawing.Point(3, 50);
            this.lblTitle_TenNL.Name = "lblTitle_TenNL";
            this.lblTitle_TenNL.Size = new System.Drawing.Size(144, 50);
            this.lblTitle_TenNL.TabIndex = 2;
            this.lblTitle_TenNL.Text = "Tên NVL (*):";
            this.lblTitle_TenNL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenNL
            // 
            this.txtTenNL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenNL.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNL.Location = new System.Drawing.Point(153, 59);
            this.txtTenNL.Name = "txtTenNL";
            this.txtTenNL.Size = new System.Drawing.Size(424, 32);
            this.txtTenNL.TabIndex = 3;
            // 
            // lblTitle_DVT
            // 
            this.lblTitle_DVT.AutoSize = true;
            this.lblTitle_DVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_DVT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_DVT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle_DVT.Location = new System.Drawing.Point(3, 100);
            this.lblTitle_DVT.Name = "lblTitle_DVT";
            this.lblTitle_DVT.Size = new System.Drawing.Size(144, 50);
            this.lblTitle_DVT.TabIndex = 4;
            this.lblTitle_DVT.Text = "Đơn vị tính (*):";
            this.lblTitle_DVT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDVT
            // 
            this.cmbDVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDVT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDVT.FormattingEnabled = true;
            this.cmbDVT.Location = new System.Drawing.Point(153, 108);
            this.cmbDVT.Name = "cmbDVT";
            this.cmbDVT.Size = new System.Drawing.Size(424, 33);
            this.cmbDVT.TabIndex = 5;
            // 
            // lblTitle_SoLuong
            // 
            this.lblTitle_SoLuong.AutoSize = true;
            this.lblTitle_SoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_SoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_SoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTitle_SoLuong.Location = new System.Drawing.Point(3, 150);
            this.lblTitle_SoLuong.Name = "lblTitle_SoLuong";
            this.lblTitle_SoLuong.Size = new System.Drawing.Size(144, 60);
            this.lblTitle_SoLuong.TabIndex = 6;
            this.lblTitle_SoLuong.Text = "Số lượng tồn (*):";
            this.lblTitle_SoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(153, 164);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(424, 32);
            this.txtSoLuong.TabIndex = 7;
            this.txtSoLuong.Text = "0";
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(630, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÊM MỚI NGUYÊN VẬT LIỆU";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaterialAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nguyên Vật Liệu";
            this.Load += new System.EventHandler(this.MaterialAddEditForm_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.tlpDetails.ResumeLayout(false);
            this.tlpDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpDetails;
        private System.Windows.Forms.Label lblTitle_MaNL;
        private System.Windows.Forms.TextBox txtMaNL;
        private System.Windows.Forms.Label lblTitle_TenNL;
        private System.Windows.Forms.TextBox txtTenNL;
        private System.Windows.Forms.Label lblTitle_DVT;
        private System.Windows.Forms.ComboBox cmbDVT;
        private System.Windows.Forms.Label lblTitle_SoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
    }
}