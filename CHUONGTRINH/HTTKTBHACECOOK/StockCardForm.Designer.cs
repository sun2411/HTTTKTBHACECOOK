namespace HTTKTBHACECOOK
{
    partial class StockCardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlHeader;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();

            // PnlHeader
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubTitle);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Height = 40;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(13, 110, 253);

            // lblSubTitle
            this.lblSubTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSubTitle.Height = 30;
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblSubTitle.ForeColor = System.Drawing.Color.DimGray;

            // dgvHistory
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHistory.Height = 400;
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;

            // btnClose
            this.btnClose.Text = "Đóng";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.Location = new System.Drawing.Point(350, 500); // Canh giữa form 800px
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvHistory);
            this.Controls.Add(this.pnlHeader);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lịch sử giao dịch kho";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
        }
    }
}