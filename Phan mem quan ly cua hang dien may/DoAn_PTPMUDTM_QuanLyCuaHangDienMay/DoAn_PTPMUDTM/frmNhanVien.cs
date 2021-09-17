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
    public partial class frmNhanVien : Form
    {
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALChucVu daCV = new BLLDALChucVu();
        BLLDALNguoiDung daND = new BLLDALNguoiDung();

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadDataGridView();

            dtgv_NhanVien.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

            cboChucVu.DataSource = daCV.loadChucVu();
            cboChucVu.DisplayMember = "TENCV";
            cboChucVu.ValueMember = "MACV";

            dpk_NgaySinh.CustomFormat = "dd/MM/yyyy";
            dpk_NgayVL.CustomFormat = "dd/MM/yyyy";
        }

        public void loadDataGridView()
        {
            dtgv_NhanVien.DataSource = daNV.loadNhanVien();
        }

        public void checkGioiTinh(GroupBox gb, string pGioiTinh)
        {
            for (int i = 0; i < gb.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gb.Controls[i];
                if (rb.Text == pGioiTinh)
                {
                    rb.Checked = true;
                }
            }
        }

        public bool ktCheckGioiTinh(GroupBox gb)
        {
            for (int i = 0; i < gb.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gb.Controls[i];
                if (rb.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public string traVeGioiTinh(GroupBox gb)
        {
            string kq = "";
            for (int i = 0; i < gb.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)gb.Controls[i];
                if (rb.Checked)
                {
                    kq = rb.Text;
                    return kq;
                }
            }
            return kq;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNV.Text) || String.IsNullOrEmpty(txtTenNV.Text) || String.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Mã nhân viên, tên nhân viên, số điện thoại nhân viên, tên đăng nhập và mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDienThoai.Text.Length > 10 || txtMaNV.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại, mã nhân viên không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenNV.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên nhân viên không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim().Length > 500)
            {
                MessageBox.Show("Địa chỉ nhân viên không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ktCheckGioiTinh(gbGioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daNV.ktKhoaChinh(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return;
            }
            DateTime ns = DateTime.Parse(dpk_NgaySinh.Text);
            DateTime nvl = DateTime.Parse(dpk_NgayVL.Text);
            if (daNV.themNhanVien(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), traVeGioiTinh(gbGioiTinh), ns, txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), cboChucVu.SelectedValue.ToString(), nvl))
            {
                loadDataGridView();
                MessageBox.Show("Thêm nhân viên mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm nhân viên mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNV.ktKhoaChinh(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return;
            }
            DialogResult r;
            r = MessageBox.Show("Nếu bạn xóa nhân viên này thì toàn bộ hóa đơn và phiếu nhập do nhân viên này thực hiện cũng sẽ bị xóa. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (!daND.kiemTraTrungTenTaiKhoan(txtMaNV.Text, Program.tenDangNhap))
                {
                    MessageBox.Show("Tài khoản của nhân viên này đang đăng nhập nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daNV.xoaNhanVien(txtMaNV.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNV.Text) || String.IsNullOrEmpty(txtTenNV.Text) || String.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Mã nhân viên, tên nhân viên, số điện thoại nhân viên, tên đăng nhập và mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDienThoai.Text.Length > 10 || txtMaNV.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại, mã nhân viên không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ktCheckGioiTinh(gbGioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim().Length > 500)
            {
                MessageBox.Show("Địa chỉ nhân viên không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNV.ktKhoaChinh(txtMaNV.Text.Trim()))
            {
                MessageBox.Show("Mã nhân viên này chưa tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime ns = DateTime.Parse(dpk_NgaySinh.Text);
            DateTime nvl = DateTime.Parse(dpk_NgayVL.Text);
            if (daNV.suaNhanVien(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), traVeGioiTinh(gbGioiTinh), ns, txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), cboChucVu.SelectedValue.ToString(), nvl))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_NhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_NhanVien.CurrentRow != null)
            {
                txtMaNV.Text = dtgv_NhanVien.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dtgv_NhanVien.CurrentRow.Cells[1].Value.ToString();
                checkGioiTinh(gbGioiTinh, dtgv_NhanVien.CurrentRow.Cells[2].Value.ToString());
                dpk_NgaySinh.Text = dtgv_NhanVien.CurrentRow.Cells[3].Value.ToString();
                txtDienThoai.Text = dtgv_NhanVien.CurrentRow.Cells[4].Value.ToString();
                txtDiaChi.Text = dtgv_NhanVien.CurrentRow.Cells[5].Value.ToString();
                cboChucVu.Text = daCV.traVeTenCV(dtgv_NhanVien.CurrentRow.Cells[6].Value.ToString());
                dpk_NgayVL.Text = dtgv_NhanVien.CurrentRow.Cells[7].Value.ToString();
            }
        }

        private void frmNhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void txtDienThoai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
