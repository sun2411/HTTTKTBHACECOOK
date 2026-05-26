namespace HTTKTBHACECOOK
{
    partial class CustomerDetailForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle_MaKH = new System.Windows.Forms.Label();
            this.lblValue_MaKH = new System.Windows.Forms.Label();
            this.lblTitle_TenKH = new System.Windows.Forms.Label();
            this.lblValue_TenKH = new System.Windows.Forms.Label();
            this.lblTitle_SDT = new System.Windows.Forms.Label();
            this.lblValue_SDT = new System.Windows.Forms.Label();
            this.lblTitle_Email = new System.Windows.Forms.Label();
            this.lblValue_Email = new System.Windows.Forms.Label();
            this.lblTitle_DiaChi = new System.Windows.Forms.Label();
            this.lblValue_DiaChi = new System.Windows.Forms.Label();
            this.lblTitle_LoaiKH = new System.Windows.Forms.Label();
            this.lblValue_LoaiKH = new System.Windows.Forms.Label();
            this.lblTitle_MST = new System.Windows.Forms.Label();
            this.lblValue_MST = new System.Windows.Forms.Label();
            this.lblTitle_STK = new System.Windows.Forms.Label();
            this.lblValue_STK = new System.Windows.Forms.Label();
            this.lblTitle_CongNo = new System.Windows.Forms.Label();
            this.lblValue_CongNo = new System.Windows.Forms.Label();
            this.lblTitle_GhiChu = new System.Windows.Forms.Label();
            this.lblValue_GhiChu = new System.Windows.Forms.Label();
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
            this.pnlContent.Controls.Add(this.tlpDetails);
            this.pnlContent.Controls.Add(this.btnClose);
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(10, 10);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(680, 630);
            this.pnlContent.TabIndex = 0;
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
            this.lblTitle.Text = "CHI TIẾT KHÁCH HÀNG";
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
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tlpDetails
            // 
            this.tlpDetails.ColumnCount = 2;
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpDetails.Controls.Add(this.lblTitle_MaKH, 0, 0);
            this.tlpDetails.Controls.Add(this.lblValue_MaKH, 1, 0);
            this.tlpDetails.Controls.Add(this.lblTitle_TenKH, 0, 1);
            this.tlpDetails.Controls.Add(this.lblValue_TenKH, 1, 1);
            this.tlpDetails.Controls.Add(this.lblTitle_SDT, 0, 2);
            this.tlpDetails.Controls.Add(this.lblValue_SDT, 1, 2);
            this.tlpDetails.Controls.Add(this.lblTitle_Email, 0, 3);
            this.tlpDetails.Controls.Add(this.lblValue_Email, 1, 3);
            this.tlpDetails.Controls.Add(this.lblTitle_DiaChi, 0, 4);
            this.tlpDetails.Controls.Add(this.lblValue_DiaChi, 1, 4);
            this.tlpDetails.Controls.Add(this.lblTitle_LoaiKH, 0, 5);
            this.tlpDetails.Controls.Add(this.lblValue_LoaiKH, 1, 5);
            this.tlpDetails.Controls.Add(this.lblTitle_MST, 0, 6);
            this.tlpDetails.Controls.Add(this.lblValue_MST, 1, 6);
            this.tlpDetails.Controls.Add(this.lblTitle_STK, 0, 7);
            this.tlpDetails.Controls.Add(this.lblValue_STK, 1, 7);
            this.tlpDetails.Controls.Add(this.lblTitle_CongNo, 0, 8);
            this.tlpDetails.Controls.Add(this.lblValue_CongNo, 1, 8);
            this.tlpDetails.Controls.Add(this.lblTitle_GhiChu, 0, 9);
            this.tlpDetails.Controls.Add(this.lblValue_GhiChu, 1, 9);
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
            this.lblTitle_MaKH.Text = "Mã Khách hàng:";
            this.lblTitle_MaKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValue_MaKH
            // 
            this.lblValue_MaKH.AutoSize = true;
            this.lblValue_MaKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_MaKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_MaKH.Location = new System.Drawing.Point(195, 0);
            this.lblValue_MaKH.Name = "lblValue_MaKH";
            this.lblValue_MaKH.Size = new System.Drawing.Size(442, 35);
            this.lblValue_MaKH.TabIndex = 1;
            this.lblValue_MaKH.Text = "[MaKH]";
            this.lblValue_MaKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblTitle_TenKH.Text = "Tên Khách hàng:";
            this.lblTitle_TenKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValue_TenKH
            // 
            this.lblValue_TenKH.AutoSize = true;
            this.lblValue_TenKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_TenKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_TenKH.Location = new System.Drawing.Point(195, 35);
            this.lblValue_TenKH.Name = "lblValue_TenKH";
            this.lblValue_TenKH.Size = new System.Drawing.Size(442, 35);
            this.lblValue_TenKH.TabIndex = 3;
            this.lblValue_TenKH.Text = "[TenKH]";
            this.lblValue_TenKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblTitle_SDT.Text = "Số điện thoại:";
            this.lblTitle_SDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValue_SDT
            // 
            this.lblValue_SDT.AutoSize = true;
            this.lblValue_SDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_SDT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_SDT.Location = new System.Drawing.Point(195, 70);
            this.lblValue_SDT.Name = "lblValue_SDT";
            this.lblValue_SDT.Size = new System.Drawing.Size(442, 35);
            this.lblValue_SDT.TabIndex = 5;
            this.lblValue_SDT.Text = "[SDTKH]";
            this.lblValue_SDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblValue_Email
            // 
            this.lblValue_Email.AutoSize = true;
            this.lblValue_Email.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_Email.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_Email.Location = new System.Drawing.Point(195, 105);
            this.lblValue_Email.Name = "lblValue_Email";
            this.lblValue_Email.Size = new System.Drawing.Size(442, 35);
            this.lblValue_Email.TabIndex = 7;
            this.lblValue_Email.Text = "[EmailKH]";
            this.lblValue_Email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblValue_DiaChi
            // 
            this.lblValue_DiaChi.AutoSize = true;
            this.lblValue_DiaChi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_DiaChi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_DiaChi.Location = new System.Drawing.Point(195, 140);
            this.lblValue_DiaChi.Name = "lblValue_DiaChi";
            this.lblValue_DiaChi.Size = new System.Drawing.Size(442, 35);
            this.lblValue_DiaChi.TabIndex = 9;
            this.lblValue_DiaChi.Text = "[DiaChiKH]";
            this.lblValue_DiaChi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.lblTitle_LoaiKH.Text = "Loại Khách hàng:";
            this.lblTitle_LoaiKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValue_LoaiKH
            // 
            this.lblValue_LoaiKH.AutoSize = true;
            this.lblValue_LoaiKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_LoaiKH.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_LoaiKH.Location = new System.Drawing.Point(195, 175);
            this.lblValue_LoaiKH.Name = "lblValue_LoaiKH";
            this.lblValue_LoaiKH.Size = new System.Drawing.Size(442, 35);
            this.lblValue_LoaiKH.TabIndex = 11;
            this.lblValue_LoaiKH.Text = "[TenLoaiKH]";
            this.lblValue_LoaiKH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblValue_MST
            // 
            this.lblValue_MST.AutoSize = true;
            this.lblValue_MST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_MST.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_MST.Location = new System.Drawing.Point(195, 210);
            this.lblValue_MST.Name = "lblValue_MST";
            this.lblValue_MST.Size = new System.Drawing.Size(442, 35);
            this.lblValue_MST.TabIndex = 13;
            this.lblValue_MST.Text = "[MSTKH]";
            this.lblValue_MST.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblValue_STK
            // 
            this.lblValue_STK.AutoSize = true;
            this.lblValue_STK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_STK.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_STK.Location = new System.Drawing.Point(195, 245);
            this.lblValue_STK.Name = "lblValue_STK";
            this.lblValue_STK.Size = new System.Drawing.Size(442, 35);
            this.lblValue_STK.TabIndex = 15;
            this.lblValue_STK.Text = "[STKKH]";
            this.lblValue_STK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblValue_CongNo
            // 
            this.lblValue_CongNo.AutoSize = true;
            this.lblValue_CongNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_CongNo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_CongNo.Location = new System.Drawing.Point(195, 280);
            this.lblValue_CongNo.Name = "lblValue_CongNo";
            this.lblValue_CongNo.Size = new System.Drawing.Size(442, 35);
            this.lblValue_CongNo.TabIndex = 17;
            this.lblValue_CongNo.Text = "[CongNoKH]";
            this.lblValue_CongNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // lblValue_GhiChu
            // 
            this.lblValue_GhiChu.AutoSize = true;
            this.lblValue_GhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue_GhiChu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue_GhiChu.Location = new System.Drawing.Point(195, 315);
            this.lblValue_GhiChu.Name = "lblValue_GhiChu";
            this.lblValue_GhiChu.Size = new System.Drawing.Size(442, 165);
            this.lblValue_GhiChu.TabIndex = 19;
            this.lblValue_GhiChu.Text = "[GhiChuKH]";
            // 
            // CustomerDetailForm
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
            this.Name = "CustomerDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết Khách hàng";
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
        private System.Windows.Forms.Label lblValue_MaKH;
        private System.Windows.Forms.Label lblTitle_TenKH;
        private System.Windows.Forms.Label lblValue_TenKH;
        private System.Windows.Forms.Label lblTitle_SDT;
        private System.Windows.Forms.Label lblValue_SDT;
        private System.Windows.Forms.Label lblTitle_Email;
        private System.Windows.Forms.Label lblValue_Email;
        private System.Windows.Forms.Label lblTitle_DiaChi;
        private System.Windows.Forms.Label lblValue_DiaChi;
        private System.Windows.Forms.Label lblTitle_LoaiKH;
        private System.Windows.Forms.Label lblValue_LoaiKH;
        private System.Windows.Forms.Label lblTitle_MST;
        private System.Windows.Forms.Label lblValue_MST;
        private System.Windows.Forms.Label lblTitle_STK;
        private System.Windows.Forms.Label lblValue_STK;
        private System.Windows.Forms.Label lblTitle_CongNo;
        private System.Windows.Forms.Label lblValue_CongNo;
        private System.Windows.Forms.Label lblTitle_GhiChu;
        private System.Windows.Forms.Label lblValue_GhiChu;
    }
}