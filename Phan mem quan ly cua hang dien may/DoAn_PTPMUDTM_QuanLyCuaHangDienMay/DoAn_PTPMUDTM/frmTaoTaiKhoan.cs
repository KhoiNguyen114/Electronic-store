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
    public partial class frmTaoTaiKhoan : Form
    {
        BLLDALNguoiDung daND = new BLLDALNguoiDung();
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaoTaiKhoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            loadDataGridView();

            cboMaNV.DataSource = daNV.loadNhanVien();
            cboMaNV.ValueMember = "MANV";
            cboMaNV.DisplayMember = "TENNV";
        }

        public void loadDataGridView()
        {
            dtgv_TaiKhoan.DataSource = daND.loadNguoiDung();
        }

        private void btnThemNVQL_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenDN.Text.Trim()) || String.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập, mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenDN.Text.Trim().Length > 20 || txtMatKhau.Text.Trim().Length > 20)
            {
                MessageBox.Show("Tên đăng nhập, mật khẩu không được vượt quá 20 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daND.ktKhoaChinh(txtTenDN.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập là duy nhất! Tên đăng nhập này đã tồn tại! Xin vui lòng chọn tên đăng nhập khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daND.ktTrungNhanVien(cboMaNV.SelectedValue.ToString()))
            {
                MessageBox.Show("Mỗi nhân viên chỉ được sở hữu 1 tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daND.themNguoiDung(txtTenDN.Text.Trim(), txtMatKhau.Text.Trim(), cboMaNV.SelectedValue.ToString()))
            {
                loadDataGridView();
                MessageBox.Show("Thêm tài khoản mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm tài khoản mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoaNVQL_Click(object sender, EventArgs e)
        {
            if (!daND.kiemTraTrungTenTaiKhoan(cboMaNV.SelectedValue.ToString(), Program.tenDangNhap))
            {
                MessageBox.Show("Tài khoản này đang đăng nhập nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daND.ktKhoaChinh(txtTenDN.Text.Trim()))
            {
                MessageBox.Show("Tài khoản của nhân viên này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daND.xoaNguoiDung(cboMaNV.SelectedValue.ToString()))
            {
                loadDataGridView();
                MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtgv_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_TaiKhoan.CurrentRow != null)
            {
                cboMaNV.Text = daNV.traVeTenNhanVien(dtgv_TaiKhoan.CurrentRow.Cells[0].Value.ToString());
                txtTenDN.Text = dtgv_TaiKhoan.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
