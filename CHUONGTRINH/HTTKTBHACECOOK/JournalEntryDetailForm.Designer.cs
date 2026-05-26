namespace HTTKTBHACECOOK
{
    partial class JournalEntryDetailForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDienGiai = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTKCo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTKNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSoCT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayGhiSo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaBT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(584, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHI TIẾT BÚT TOÁN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.cboTrangThai);
            this.pnlContent.Controls.Add(this.label8);
            this.pnlContent.Controls.Add(this.txtDienGiai);
            this.pnlContent.Controls.Add(this.label7);
            this.pnlContent.Controls.Add(this.txtSoTien);
            this.pnlContent.Controls.Add(this.label6);
            this.pnlContent.Controls.Add(this.cboTKCo);
            this.pnlContent.Controls.Add(this.label5);
            this.pnlContent.Controls.Add(this.cboTKNo);
            this.pnlContent.Controls.Add(this.label4);
            this.pnlContent.Controls.Add(this.txtSoCT);
            this.pnlContent.Controls.Add(this.label3);
            this.pnlContent.Controls.Add(this.dtpNgayGhiSo);
            this.pnlContent.Controls.Add(this.label2);
            this.pnlContent.Controls.Add(this.txtMaBT);
            this.pnlContent.Controls.Add(this.label1);
            this.pnlContent.Location = new System.Drawing.Point(12, 63);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(560, 320);
            this.pnlContent.TabIndex = 1;
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Items.AddRange(new object[] {
            "Ghi sổ",
            "Chưa ghi sổ"});
            this.cboTrangThai.Location = new System.Drawing.Point(390, 23);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(150, 33);
            this.cboTrangThai.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(290, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "Trạng thái:";
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(120, 220);
            this.txtDienGiai.Multiline = true;
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(420, 80);
            this.txtDienGiai.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "Diễn giải:";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(120, 175);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(420, 31);
            this.txtSoTien.TabIndex = 6;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTien_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số tiền:";
            // 
            // cboTKCo
            // 
            this.cboTKCo.FormattingEnabled = true;
            this.cboTKCo.Location = new System.Drawing.Point(390, 125);
            this.cboTKCo.Name = "cboTKCo";
            this.cboTKCo.Size = new System.Drawing.Size(150, 33);
            this.cboTKCo.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tài khoản có:";
            // 
            // cboTKNo
            // 
            this.cboTKNo.FormattingEnabled = true;
            this.cboTKNo.Location = new System.Drawing.Point(120, 125);
            this.cboTKNo.Name = "cboTKNo";
            this.cboTKNo.Size = new System.Drawing.Size(150, 33);
            this.cboTKNo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tài khoản nợ:";
            // 
            // txtSoCT
            // 
            this.txtSoCT.Location = new System.Drawing.Point(390, 75);
            this.txtSoCT.Name = "txtSoCT";
            this.txtSoCT.Size = new System.Drawing.Size(150, 31);
            this.txtSoCT.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số chứng từ:";
            // 
            // dtpNgayGhiSo
            // 
            this.dtpNgayGhiSo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayGhiSo.Location = new System.Drawing.Point(120, 75);
            this.dtpNgayGhiSo.Name = "dtpNgayGhiSo";
            this.dtpNgayGhiSo.Size = new System.Drawing.Size(150, 31);
            this.dtpNgayGhiSo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày ghi sổ:";
            // 
            // txtMaBT
            // 
            this.txtMaBT.Location = new System.Drawing.Point(120, 23);
            this.txtMaBT.Name = "txtMaBT";
            this.txtMaBT.Size = new System.Drawing.Size(150, 31);
            this.txtMaBT.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã bút toán:";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(340, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "LƯU";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(462, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // JournalEntryDetailForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JournalEntryDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết bút toán";
            this.Load += new System.EventHandler(this.JournalEntryDetailForm_Load);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TextBox txtMaBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoCT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayGhiSo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTKCo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboTKNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDienGiai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}