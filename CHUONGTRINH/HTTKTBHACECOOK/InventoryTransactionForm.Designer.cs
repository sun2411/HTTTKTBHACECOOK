namespace HTTKTBHACECOOK
{
    partial class InventoryTransactionForm
    {
        private System.ComponentModel.IContainer components = null;

        // === VISIBLE CONTROLS ===
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.ComboBox cmbMaSP;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblMaKho;
        private System.Windows.Forms.ComboBox cmbMaKho;
        private System.Windows.Forms.Label lblTenKho;
        private System.Windows.Forms.TextBox txtTenKho;
        private System.Windows.Forms.Label lblSLCurent;
        private System.Windows.Forms.TextBox txtSLCurent;
        private System.Windows.Forms.Label lblSLTrans;
        private System.Windows.Forms.NumericUpDown numSLTrans;
        private System.Windows.Forms.Label lblSLAfter;
        private System.Windows.Forms.TextBox txtSLAfter;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;

        // === HIDDEN CONTROLS (dùng trong code) ===
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.TextBox txtSoPhieu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.cmbMaSP = new System.Windows.Forms.ComboBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblMaKho = new System.Windows.Forms.Label();
            this.cmbMaKho = new System.Windows.Forms.ComboBox();
            this.lblTenKho = new System.Windows.Forms.Label();
            this.txtTenKho = new System.Windows.Forms.TextBox();
            this.lblSLCurent = new System.Windows.Forms.Label();
            this.txtSLCurent = new System.Windows.Forms.TextBox();
            this.lblSLTrans = new System.Windows.Forms.Label();
            this.numSLTrans = new System.Windows.Forms.NumericUpDown();
            this.lblSLAfter = new System.Windows.Forms.Label();
            this.txtSLAfter = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            // Hidden controls
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.txtSoPhieu = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.numSLTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            this.SuspendLayout();

            // ============================================
            // FORM PROPERTIES
            // ============================================
            this.ClientSize = new System.Drawing.Size(500, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load += new System.EventHandler(this.InventoryTransactionForm_Load);

            // ============================================
            // LAYOUT CONSTANTS
            // ============================================
            int marginLeft = 30;
            int labelWidth = 110;
            int inputWidth = 330;
            int inputWidthHalf = 160;
            int currentY = 70;
            int gap = 40;

            // ============================================
            // TITLE
            // ============================================
            this.lblTitle.Text = "NHẬP KHO";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(25, 135, 84);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 60;

            // ============================================
            // ROW 1: Mã sản phẩm
            // ============================================
            currentY = 80;

            this.lblMaSP.Text = "Mã sản phẩm:";
            this.lblMaSP.Location = new System.Drawing.Point(marginLeft, currentY + 5);
            this.lblMaSP.Size = new System.Drawing.Size(labelWidth, 22);
            this.lblMaSP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);

            this.cmbMaSP.Location = new System.Drawing.Point(marginLeft + labelWidth + 10, currentY);
            this.cmbMaSP.Size = new System.Drawing.Size(inputWidth, 27);
            this.cmbMaSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaSP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMaSP.SelectedIndexChanged += new System.EventHandler(this.cmbMaSP_SelectedIndexChanged);

            // ============================================
            // ROW 2: Tên sản phẩm
            // ============================================
            currentY += gap;

            this.lblTenSP.Text = "Tên sản phẩm:";
            this.lblTenSP.Location = new System.Drawing.Point(marginLeft, currentY + 5);
            this.lblTenSP.Size = new System.Drawing.Size(labelWidth, 22);

            this.txtTenSP.Location = new System.Drawing.Point(marginLeft + labelWidth + 10, currentY);
            this.txtTenSP.Size = new System.Drawing.Size(inputWidth, 27);
            this.txtTenSP.ReadOnly = true;
            this.txtTenSP.BackColor = System.Drawing.SystemColors.Control;
            this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 10F);

            // ============================================
            // ROW 3: Mã kho | Tên kho
            // ============================================
            currentY += gap;

            this.lblMaKho.Text = "Mã kho:";
            this.lblMaKho.Location = new System.Drawing.Point(marginLeft, currentY + 5);
            this.lblMaKho.Size = new System.Drawing.Size(labelWidth, 22);

            this.cmbMaKho.Location = new System.Drawing.Point(marginLeft + labelWidth + 10, currentY);
            this.cmbMaKho.Size = new System.Drawing.Size(110, 27);
            this.cmbMaKho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaKho.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMaKho.SelectedIndexChanged += new System.EventHandler(this.cmbMaKho_SelectedIndexChanged);

            this.txtTenKho.Location = new System.Drawing.Point(marginLeft + labelWidth + 10 + 110 + 10, currentY);
            this.txtTenKho.Size = new System.Drawing.Size(210, 27);
            this.txtTenKho.ReadOnly = true;
            this.txtTenKho.BackColor = System.Drawing.SystemColors.Control;
            this.txtTenKho.Font = new System.Drawing.Font("Segoe UI", 10F);

            // ============================================
            // ROW 4: SL hiện tại
            // ============================================
            currentY += gap;

            this.lblSLCurent.Text = "SL hiện tại:";
            this.lblSLCurent.Location = new System.Drawing.Point(marginLeft, currentY + 5);
            this.lblSLCurent.Size = new System.Drawing.Size(labelWidth, 22);

            this.txtSLCurent.Location = new System.Drawing.Point(marginLeft + labelWidth + 10, currentY);
            this.txtSLCurent.Size = new System.Drawing.Size(inputWidth, 27);
            this.txtSLCurent.ReadOnly = true;
            this.txtSLCurent.BackColor = System.Drawing.SystemColors.Control;
            this.txtSLCurent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSLCurent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // ============================================
            // ROW 5: SL nhập/xuất
            // ============================================
            currentY += gap;

            this.lblSLTrans.Text = "SL nhập:";
            this.lblSLTrans.Location = new System.Drawing.Point(marginLeft, currentY + 5);
            this.lblSLTrans.Size = new System.Drawing.Size(labelWidth, 22);
            this.lblSLTrans.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.numSLTrans.Location = new System.Drawing.Point(marginLeft + labelWidth + 10, currentY);
            this.numSLTrans.Size = new System.Drawing.Size(130, 27);
            this.numSLTrans.Minimum = 0;
            this.numSLTrans.Maximum = 1000000;
            this.numSLTrans.Value = 0;
            this.numSLTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSLTrans.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.numSLTrans.ValueChanged += new System.EventHandler(this.numSLTrans_ValueChanged);

            // ============================================
            // ROW 6: SL sau nhập/xuất
            // ============================================
            currentY += gap;

            this.lblSLAfter.Text = "SL sau nhập:";
            this.lblSLAfter.Location = new System.Drawing.Point(marginLeft, currentY + 5);
            this.lblSLAfter.Size = new System.Drawing.Size(labelWidth, 22);

            this.txtSLAfter.Location = new System.Drawing.Point(marginLeft + labelWidth + 10, currentY);
            this.txtSLAfter.Size = new System.Drawing.Size(inputWidth, 27);
            this.txtSLAfter.ReadOnly = true;
            this.txtSLAfter.BackColor = System.Drawing.Color.LightGreen;
            this.txtSLAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSLAfter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // ============================================
            // ROW 7: Ghi chú
            // ============================================
            currentY += gap;

            this.lblNote.Text = "Ghi chú:";
            this.lblNote.Location = new System.Drawing.Point(marginLeft, currentY + 5);
            this.lblNote.Size = new System.Drawing.Size(labelWidth, 22);

            this.txtNote.Location = new System.Drawing.Point(marginLeft + labelWidth + 10, currentY);
            this.txtNote.Size = new System.Drawing.Size(inputWidth, 70);
            this.txtNote.Multiline = true;
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9.75F);

            // ============================================
            // BUTTONS
            // ============================================
            currentY = 430;

            // Nút NHẬP/XUẤT
            this.btnSave.Text = "Nhập";
            this.btnSave.Location = new System.Drawing.Point(250, currentY);
            this.btnSave.Size = new System.Drawing.Size(110, 45);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(25, 135, 84); // Xanh lá
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // Nút HỦY
            this.btnClose.Text = "Hủy";
            this.btnClose.Location = new System.Drawing.Point(370, currentY);
            this.btnClose.Size = new System.Drawing.Size(100, 45);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(220, 53, 69); // Đỏ
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // ============================================
            // HIDDEN CONTROLS
            // ============================================
            this.numDonGia.Visible = false;
            this.numDonGia.Maximum = 10000000;

            this.dtpNgay.Visible = false;
            this.dtpNgay.Value = System.DateTime.Now;

            this.txtSoPhieu.Visible = false;

            // ============================================
            // ADD CONTROLS TO FORM
            // ============================================
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMaSP);
            this.Controls.Add(this.cmbMaSP);
            this.Controls.Add(this.lblTenSP);
            this.Controls.Add(this.txtTenSP);
            this.Controls.Add(this.lblMaKho);
            this.Controls.Add(this.cmbMaKho);
            this.Controls.Add(this.txtTenKho);
            this.Controls.Add(this.lblSLCurent);
            this.Controls.Add(this.txtSLCurent);
            this.Controls.Add(this.lblSLTrans);
            this.Controls.Add(this.numSLTrans);
            this.Controls.Add(this.lblSLAfter);
            this.Controls.Add(this.txtSLAfter);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.numDonGia);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.txtSoPhieu);

            ((System.ComponentModel.ISupportInitialize)(this.numSLTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}