
namespace DoAn_PTPMUDTM
{
    partial class frmChucVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChucVu));
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaCV = new System.Windows.Forms.TextBox();
            this.txtLuongCB = new txtChiNhapSoThuc.txtChiNhapSoThuc();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.lblTenCV = new System.Windows.Forms.Label();
            this.lblLuongCB = new System.Windows.Forms.Label();
            this.lblMaCV = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgv_ChucVu = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChucVu)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1135, 78);
            this.label6.TabIndex = 24;
            this.label6.Text = "DANH SÁCH CHỨC VỤ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.44185F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.55814F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.Controls.Add(this.txtMaCV, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtLuongCB, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtTenCV, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblTenCV, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblLuongCB, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblMaCV, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnThem, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnCapNhat, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnThoat, 3, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1124, 175);
            this.tableLayoutPanel2.TabIndex = 29;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // txtMaCV
            // 
            this.txtMaCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaCV.Location = new System.Drawing.Point(198, 17);
            this.txtMaCV.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtMaCV.Multiline = true;
            this.txtMaCV.Name = "txtMaCV";
            this.txtMaCV.Size = new System.Drawing.Size(149, 48);
            this.txtMaCV.TabIndex = 1;
            // 
            // txtLuongCB
            // 
            this.txtLuongCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLuongCB.Location = new System.Drawing.Point(197, 72);
            this.txtLuongCB.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtLuongCB.Multiline = true;
            this.txtLuongCB.Name = "txtLuongCB";
            this.txtLuongCB.Size = new System.Drawing.Size(151, 51);
            this.txtLuongCB.TabIndex = 5;
            this.txtLuongCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTenCV
            // 
            this.txtTenCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenCV.Location = new System.Drawing.Point(198, 130);
            this.txtTenCV.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTenCV.Multiline = true;
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(149, 39);
            this.txtTenCV.TabIndex = 3;
            // 
            // lblTenCV
            // 
            this.lblTenCV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTenCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenCV.Location = new System.Drawing.Point(19, 70);
            this.lblTenCV.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenCV.Name = "lblTenCV";
            this.lblTenCV.Size = new System.Drawing.Size(169, 55);
            this.lblTenCV.TabIndex = 2;
            this.lblTenCV.Text = "Tên chức vụ";
            this.lblTenCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTenCV.Click += new System.EventHandler(this.lblTenCV_Click);
            // 
            // lblLuongCB
            // 
            this.lblLuongCB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLuongCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLuongCB.Location = new System.Drawing.Point(19, 125);
            this.lblLuongCB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLuongCB.Name = "lblLuongCB";
            this.lblLuongCB.Size = new System.Drawing.Size(169, 49);
            this.lblLuongCB.TabIndex = 4;
            this.lblLuongCB.Text = "Lương cơ bản";
            this.lblLuongCB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaCV
            // 
            this.lblMaCV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMaCV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaCV.Location = new System.Drawing.Point(19, 12);
            this.lblMaCV.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaCV.Name = "lblMaCV";
            this.lblMaCV.Size = new System.Drawing.Size(169, 58);
            this.lblMaCV.TabIndex = 0;
            this.lblMaCV.Text = "Mã chức vụ";
            this.lblMaCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(356, 14);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 49);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhat.Location = new System.Drawing.Point(356, 72);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(135, 48);
            this.btnCapNhat.TabIndex = 2;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(356, 127);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(135, 42);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LUONGCB";
            this.Column3.HeaderText = "Lương cơ bản";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TENCV";
            this.Column2.HeaderText = "Tên chức vụ";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MACV";
            this.Column1.HeaderText = "Mã chức vụ";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dtgv_ChucVu
            // 
            this.dtgv_ChucVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgv_ChucVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgv_ChucVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_ChucVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dtgv_ChucVu.Location = new System.Drawing.Point(0, 255);
            this.dtgv_ChucVu.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dtgv_ChucVu.Name = "dtgv_ChucVu";
            this.dtgv_ChucVu.ReadOnly = true;
            this.dtgv_ChucVu.RowHeadersWidth = 51;
            this.dtgv_ChucVu.RowTemplate.Height = 24;
            this.dtgv_ChucVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgv_ChucVu.Size = new System.Drawing.Size(1135, 360);
            this.dtgv_ChucVu.TabIndex = 0;
            this.dtgv_ChucVu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_ChucVu_CellClick);
            this.dtgv_ChucVu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_ChucVu_CellContentClick);
            // 
            // frmChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(1135, 615);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtgv_ChucVu);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmChucVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chức vụ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChucVu_FormClosed);
            this.Load += new System.EventHandler(this.frmChucVu_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_ChucVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private txtChiNhapSoThuc.txtChiNhapSoThuc txtLuongCB;
        private System.Windows.Forms.TextBox txtTenCV;
        private System.Windows.Forms.TextBox txtMaCV;
        private System.Windows.Forms.Label lblLuongCB;
        private System.Windows.Forms.Label lblTenCV;
        private System.Windows.Forms.Label lblMaCV;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dtgv_ChucVu;
    }
}