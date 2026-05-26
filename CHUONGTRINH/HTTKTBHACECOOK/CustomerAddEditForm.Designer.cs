namespace HTTKTBHACECOOK
{
    partial class CustomerAddEditForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle_MaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTitle_TenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblTitle_SDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblTitle_Email = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTitle_DiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblTitle_LoaiKH = new System.Windows.Forms.Label();
            this.cmbLoaiKH = new System.Windows.Forms.ComboBox();
            this.lblTitle_MST = new System.Windows.Forms.Label();
            this.txtMST = new System.Windows.Forms.TextBox();
            this.lblTitle_STK = new System.Windows.Forms.Label();
            this.txtSTK = new System.Windows.Forms.TextBox();
            this.lblTitle_CongNo = new System.Windows.Forms.Label();
            this.txtCongNo = new System.Windows.Forms.TextBox();
            this.lblTitle_GhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
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
            this.pnlMain.Size = new System.Drawing.Size(700, 650);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.btnSave);
            this.pnlContent.Controls.Add(this.tlpDetails);
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Controls.Add(this.btnClose);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(10, 10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(680, 630);
            this.pnlContent.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(400, 580);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(15, 10, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(678, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÊM MỚI KHÁCH HÀNG";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(539, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Hủy";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tlpDetails
            // 
            this.tlpDetails.ColumnCount = 2;
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpDetails.Controls.Add(this.lblTitle_MaKH, 0, 0);
            this.tlpDetails.Controls.Add(this.txtMaKH, 1, 0);
            this.tlpDetails.Controls.Add(this.lblTitle_TenKH, 0, 1);
            this.tlpDetails.Controls.Add(this.txtTenKH, 1, 1);
            this.tlpDetails.Controls.Add(this.lblTitle_SDT, 0, 2);
            this.tlpDetails.Controls.Add(this.txtSDT, 1, 2);
            this.tlpDetails.Controls.Add(this.lblTitle_Email, 0, 3);
            this.tlpDetails.Controls.Add(this.txtEmail, 1, 3);
            this.tlpDetails.Controls.Add(this.lblTitle_DiaChi, 0, 4);
            this.tlpDetails.Controls.Add(this.txtDiaChi, 1, 4);
            this.tlpDetails.Controls.Add(this.lblTitle_LoaiKH, 0, 5);
            this.tlpDetails.Controls.Add(this.cmbLoaiKH, 1, 5);
            this.tlpDetails.Controls.Add(this.lblTitle_MST, 0, 6);
            this.tlpDetails.Controls.Add(this.txtMST, 1, 6);
            this.tlpDetails.Controls.Add(this.lblTitle_STK, 0, 7);
            this.tlpDetails.Controls.Add(this.txtSTK, 1, 7);
            this.tlpDetails.Controls.Add(this.lblTitle_CongNo, 0, 8);
            this.tlpDetails.Controls.Add(this.txtCongNo, 1, 8);
            this.tlpDetails.Controls.Add(this.lblTitle_GhiChu, 0, 9);
            this.tlpDetails.Controls.Add(this.txtGhiChu, 1, 9);
            this.tlpDetails.Location = new System.Drawing.Point(20, 70);
            this.tlpDetails.Name = "tlpDetails";
            this.tlpDetails.RowCount = 10;
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpDetails.Size = new System.Drawing.Size(640, 480);
            this.tlpDetails.TabIndex = 2;
            // 
            // lblTitle_MaKH
            // 
            this.lblTitle_MaKH.AutoSize = true;
            this.lblTitle_MaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_MaKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_MaKH.Location = new System.Drawing.Point(3, 0);
            this.lblTitle_MaKH.Name = "lblTitle_MaKH";
            this.lblTitle_MaKH.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_MaKH.TabIndex = 0;
            this.lblTitle_MaKH.Text = "Mã Khách hàng: (*)";
            this.lblTitle_MaKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKH.Location = new System.Drawing.Point(195, 5);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(442, 27);
            this.txtMaKH.TabIndex = 1;
            // 
            // lblTitle_TenKH
            // 
            this.lblTitle_TenKH.AutoSize = true;
            this.lblTitle_TenKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_TenKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_TenKH.Location = new System.Drawing.Point(3, 35);
            this.lblTitle_TenKH.Name = "lblTitle_TenKH";
            this.lblTitle_TenKH.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_TenKH.TabIndex = 2;
            this.lblTitle_TenKH.Text = "Tên Khách hàng: (*)";
            this.lblTitle_TenKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(195, 40);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(442, 27);
            this.txtTenKH.TabIndex = 3;
            // 
            // lblTitle_SDT
            // 
            this.lblTitle_SDT.AutoSize = true;
            this.lblTitle_SDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_SDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_SDT.Location = new System.Drawing.Point(3, 70);
            this.lblTitle_SDT.Name = "lblTitle_SDT";
            this.lblTitle_SDT.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_SDT.TabIndex = 4;
            this.lblTitle_SDT.Text = "Số điện thoại: (*)";
            this.lblTitle_SDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSDT
            // 
            this.txtSDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(195, 75);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(442, 27);
            this.txtSDT.TabIndex = 5;
            // 
            // lblTitle_Email
            // 
            this.lblTitle_Email.AutoSize = true;
            this.lblTitle_Email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_Email.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_Email.Location = new System.Drawing.Point(3, 105);
            this.lblTitle_Email.Name = "lblTitle_Email";
            this.lblTitle_Email.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_Email.TabIndex = 6;
            this.lblTitle_Email.Text = "Email:";
            this.lblTitle_Email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(195, 110);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(442, 27);
            this.txtEmail.TabIndex = 7;
            // 
            // lblTitle_DiaChi
            // 
            this.lblTitle_DiaChi.AutoSize = true;
            this.lblTitle_DiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_DiaChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_DiaChi.Location = new System.Drawing.Point(3, 140);
            this.lblTitle_DiaChi.Name = "lblTitle_DiaChi";
            this.lblTitle_DiaChi.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_DiaChi.TabIndex = 8;
            this.lblTitle_DiaChi.Text = "Địa chỉ:";
            this.lblTitle_DiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDiaChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(195, 145);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(442, 27);
            this.txtDiaChi.TabIndex = 9;
            // 
            // lblTitle_LoaiKH
            // 
            this.lblTitle_LoaiKH.AutoSize = true;
            this.lblTitle_LoaiKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_LoaiKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_LoaiKH.Location = new System.Drawing.Point(3, 175);
            this.lblTitle_LoaiKH.Name = "lblTitle_LoaiKH";
            this.lblTitle_LoaiKH.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_LoaiKH.TabIndex = 10;
            this.lblTitle_LoaiKH.Text = "Loại Khách hàng: (*)";
            this.lblTitle_LoaiKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLoaiKH
            // 
            this.cmbLoaiKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLoaiKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoaiKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoaiKH.FormattingEnabled = true;
            this.cmbLoaiKH.Location = new System.Drawing.Point(195, 179);
            this.cmbLoaiKH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.cmbLoaiKH.Name = "cmbLoaiKH";
            this.cmbLoaiKH.Size = new System.Drawing.Size(442, 25);
            this.cmbLoaiKH.TabIndex = 11;
            // 
            // lblTitle_MST
            // 
            this.lblTitle_MST.AutoSize = true;
            this.lblTitle_MST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_MST.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_MST.Location = new System.Drawing.Point(3, 210);
            this.lblTitle_MST.Name = "lblTitle_MST";
            this.lblTitle_MST.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_MST.TabIndex = 12;
            this.lblTitle_MST.Text = "Mã số thuế (MST):";
            this.lblTitle_MST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMST
            // 
            this.txtMST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMST.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMST.Location = new System.Drawing.Point(195, 215);
            this.txtMST.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtMST.Name = "txtMST";
            this.txtMST.Size = new System.Drawing.Size(442, 27);
            this.txtMST.TabIndex = 13;
            // 
            // lblTitle_STK
            // 
            this.lblTitle_STK.AutoSize = true;
            this.lblTitle_STK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_STK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_STK.Location = new System.Drawing.Point(3, 245);
            this.lblTitle_STK.Name = "lblTitle_STK";
            this.lblTitle_STK.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_STK.TabIndex = 14;
            this.lblTitle_STK.Text = "Số tài khoản (STK):";
            this.lblTitle_STK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSTK
            // 
            this.txtSTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSTK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTK.Location = new System.Drawing.Point(195, 250);
            this.txtSTK.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtSTK.Name = "txtSTK";
            this.txtSTK.Size = new System.Drawing.Size(442, 27);
            this.txtSTK.TabIndex = 15;
            // 
            // lblTitle_CongNo
            // 
            this.lblTitle_CongNo.AutoSize = true;
            this.lblTitle_CongNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_CongNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_CongNo.Location = new System.Drawing.Point(3, 280);
            this.lblTitle_CongNo.Name = "lblTitle_CongNo";
            this.lblTitle_CongNo.Size = new System.Drawing.Size(186, 35);
            this.lblTitle_CongNo.TabIndex = 16;
            this.lblTitle_CongNo.Text = "Công nợ hiện tại:";
            this.lblTitle_CongNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCongNo
            // 
            this.txtCongNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCongNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCongNo.Location = new System.Drawing.Point(195, 285);
            this.txtCongNo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtCongNo.Name = "txtCongNo";
            this.txtCongNo.ReadOnly = true;
            this.txtCongNo.Size = new System.Drawing.Size(442, 27);
            this.txtCongNo.TabIndex = 17;
            this.txtCongNo.Text = "0";
            // 
            // lblTitle_GhiChu
            // 
            this.lblTitle_GhiChu.AutoSize = true;
            this.lblTitle_GhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle_GhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle_GhiChu.Location = new System.Drawing.Point(3, 315);
            this.lblTitle_GhiChu.Name = "lblTitle_GhiChu";
            this.lblTitle_GhiChu.Size = new System.Drawing.Size(186, 165);
            this.lblTitle_GhiChu.TabIndex = 18;
            this.lblTitle_GhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(195, 320);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(442, 160);
            this.txtGhiChu.TabIndex = 19;
            // 
            // CustomerAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 650);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm mới Khách hàng";
            this.Load += new System.EventHandler(this.CustomerAddEditForm_Load);
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
        private System.Windows.Forms.TableLayoutPanel tlpDetails;
        private System.Windows.Forms.Label lblTitle_MaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblTitle_TenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblTitle_SDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblTitle_Email;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTitle_DiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblTitle_LoaiKH;
        private System.Windows.Forms.ComboBox cmbLoaiKH;
        private System.Windows.Forms.Label lblTitle_MST;
        private System.Windows.Forms.TextBox txtMST;
        private System.Windows.Forms.Label lblTitle_STK;
        private System.Windows.Forms.TextBox txtSTK;
        private System.Windows.Forms.Label lblTitle_CongNo;
        private System.Windows.Forms.TextBox txtCongNo;
        private System.Windows.Forms.Label lblTitle_GhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnSave;
    }
}