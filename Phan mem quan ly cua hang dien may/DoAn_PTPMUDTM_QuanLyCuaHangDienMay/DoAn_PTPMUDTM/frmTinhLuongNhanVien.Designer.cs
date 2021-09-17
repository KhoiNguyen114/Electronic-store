
namespace DoAn_PTPMUDTM
{
    partial class frmTinhLuongNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTinhLuongNhanVien));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboThang = new System.Windows.Forms.ComboBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.txtLuongThucNhan = new txtChiNhapSoThuc.txtChiNhapSoThuc();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.txtLuongCB = new txtChiNhapSoThuc.txtChiNhapSoThuc();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.lblLuongCB = new System.Windows.Forms.Label();
            this.lblTenCV = new System.Windows.Forms.Label();
            this.txtSoNgayLam = new txtChiNhapSo.txtChiNhapSo();
            this.label1 = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 21);
            this.label5.TabIndex = 34;
            this.label5.Text = "Tháng";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 21);
            this.label4.TabIndex = 33;
            this.label4.Text = "Năm";
            // 
            // cboThang
            // 
            this.cboThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThang.FormattingEnabled = true;
            this.cboThang.Location = new System.Drawing.Point(170, 55);
            this.cboThang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(193, 24);
            this.cboThang.TabIndex = 32;
            this.cboThang.SelectedIndexChanged += new System.EventHandler(this.cboThang_SelectedIndexChanged);
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(170, 24);
            this.cboNam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(193, 24);
            this.cboNam.TabIndex = 31;
            this.cboNam.SelectedIndexChanged += new System.EventHandler(this.cboNam_SelectedIndexChanged);
            // 
            // txtLuongThucNhan
            // 
            this.txtLuongThucNhan.Enabled = false;
            this.txtLuongThucNhan.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongThucNhan.Location = new System.Drawing.Point(170, 219);
            this.txtLuongThucNhan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLuongThucNhan.Name = "txtLuongThucNhan";
            this.txtLuongThucNhan.Size = new System.Drawing.Size(193, 24);
            this.txtLuongThucNhan.TabIndex = 30;
            this.txtLuongThucNhan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "Lương thực nhận";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhLuong.Image = ((System.Drawing.Image)(resources.GetObject("btnTinhLuong.Image")));
            this.btnTinhLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhLuong.Location = new System.Drawing.Point(160, 264);
            this.btnTinhLuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(121, 34);
            this.btnTinhLuong.TabIndex = 28;
            this.btnTinhLuong.Text = "Tính lương";
            this.btnTinhLuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTinhLuong.UseVisualStyleBackColor = true;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // txtLuongCB
            // 
            this.txtLuongCB.Enabled = false;
            this.txtLuongCB.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuongCB.Location = new System.Drawing.Point(170, 186);
            this.txtLuongCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLuongCB.Name = "txtLuongCB";
            this.txtLuongCB.Size = new System.Drawing.Size(193, 24);
            this.txtLuongCB.TabIndex = 27;
            this.txtLuongCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTenCV
            // 
            this.txtTenCV.Enabled = false;
            this.txtTenCV.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenCV.Location = new System.Drawing.Point(170, 152);
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(193, 24);
            this.txtTenCV.TabIndex = 25;
            // 
            // lblLuongCB
            // 
            this.lblLuongCB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLuongCB.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuongCB.Location = new System.Drawing.Point(25, 187);
            this.lblLuongCB.Name = "lblLuongCB";
            this.lblLuongCB.Size = new System.Drawing.Size(102, 21);
            this.lblLuongCB.TabIndex = 26;
            this.lblLuongCB.Text = "Lương cơ bản";
            this.lblLuongCB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenCV
            // 
            this.lblTenCV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTenCV.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCV.Location = new System.Drawing.Point(26, 153);
            this.lblTenCV.Name = "lblTenCV";
            this.lblTenCV.Size = new System.Drawing.Size(101, 21);
            this.lblTenCV.TabIndex = 24;
            this.lblTenCV.Text = "Chức vụ";
            this.lblTenCV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoNgayLam
            // 
            this.txtSoNgayLam.Enabled = false;
            this.txtSoNgayLam.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoNgayLam.Location = new System.Drawing.Point(170, 119);
            this.txtSoNgayLam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSoNgayLam.Name = "txtSoNgayLam";
            this.txtSoNgayLam.Size = new System.Drawing.Size(193, 24);
            this.txtSoNgayLam.TabIndex = 23;
            this.txtSoNgayLam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "Số ngày làm";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(170, 87);
            this.cboNhanVien.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(193, 24);
            this.cboNhanVien.TabIndex = 21;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Nhân viên";
            // 
            // frmTinhLuongNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(388, 323);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboThang);
            this.Controls.Add(this.cboNam);
            this.Controls.Add(this.txtLuongThucNhan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.txtLuongCB);
            this.Controls.Add(this.txtTenCV);
            this.Controls.Add(this.lblLuongCB);
            this.Controls.Add(this.lblTenCV);
            this.Controls.Add(this.txtSoNgayLam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmTinhLuongNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tính lương nhân viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTinhLuongNhanVien_FormClosed);
            this.Load += new System.EventHandler(this.frmTinhLuongNhanVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboThang;
        private System.Windows.Forms.ComboBox cboNam;
        private txtChiNhapSoThuc.txtChiNhapSoThuc txtLuongThucNhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTinhLuong;
        private txtChiNhapSoThuc.txtChiNhapSoThuc txtLuongCB;
        private System.Windows.Forms.TextBox txtTenCV;
        private System.Windows.Forms.Label lblLuongCB;
        private System.Windows.Forms.Label lblTenCV;
        private txtChiNhapSo.txtChiNhapSo txtSoNgayLam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label2;
    }
}