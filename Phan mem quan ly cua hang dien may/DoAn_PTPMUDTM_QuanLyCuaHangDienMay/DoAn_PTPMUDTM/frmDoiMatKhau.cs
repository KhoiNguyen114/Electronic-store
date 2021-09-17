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
    public partial class frmDoiMatKhau : Form
    {
        BLLDALNguoiDung daND = new BLLDALNguoiDung();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMatKhauCu.Text) || String.IsNullOrEmpty(txtMatKhauMoi.Text) || String.IsNullOrEmpty(txtNhapLaiMatKhau.Text))
            {
                MessageBox.Show("Mật khẩu cũ, mật khẩu mới, nhập lại mật khẩu mới không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daND.kiemTraMatKhauCu(txtTenDangNhap.Text.Trim(), txtMatKhauCu.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu cũ không đúng! Xin vui lòng kiểm tra lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMatKhauMoi.Text.Trim() != txtNhapLaiMatKhau.Text.Trim())
            {
                MessageBox.Show("Mật khẩu nhập lại không trùng khớp", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daND.doiMatKhau(txtTenDangNhap.Text, txtMatKhauMoi.Text))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = Program.tenDangNhap;
        }
    }
}
