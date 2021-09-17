using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace DoAn_PTPMUDTM
{
    public partial class frmDangNhap : Form
    {
        BLLDALNguoiDung daND = new BLLDALNguoiDung();
        BLLDALPhanQuyen daPQ = new BLLDALPhanQuyen();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text.Trim()) || string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Select();
                return;
            }

            int kq = daPQ.Check_Config();

            if (kq == 0)
            {
                processLogin();
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                processConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                processConfig();
            }

        }

        public void processConfig()
        {
            frmCauHinh frm = new frmCauHinh();
            frm.Show();

        }

        public void processLogin()
        {
            int result = daPQ.Check_user(txtTenDangNhap.Text, txtMatKhau.Text);

            if (result == 1)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (result == 2)
            {
                MessageBox.Show("Tài khoản bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.frmMain = new frmMain();
            this.Visible = false;
            Program.frmMain.TenDangNhap = txtTenDangNhap.Text.Trim();
            Program.tenDangNhap = txtTenDangNhap.Text.Trim();
            Program.frmMain.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
