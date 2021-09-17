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
    public partial class frmKhachHang : Form
    {
        BLLDALKhachHang daKH = new BLLDALKhachHang();
        BLLDALLoaiKhachHang dalkh = new BLLDALLoaiKhachHang();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            loadDataGridView();

            dtgv_KhachHang.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            cboLoaiKH.DataSource = dalkh.loadLoaiKhachHang();
            cboLoaiKH.DisplayMember = "TENLOAI";
            cboLoaiKH.ValueMember = "MALOAIKH";

            dpk_NgaySinh.CustomFormat = "dd/MM/yyyy";
        }
        public void loadDataGridView()
        {
            dtgv_KhachHang.DataSource = daKH.loadKhachHang();
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

        private void dtgv_KhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_KhachHang.CurrentRow != null)
            {
                txtMaKH.Text = dtgv_KhachHang.CurrentRow.Cells[0].Value.ToString();
                txtTenKH.Text = dtgv_KhachHang.CurrentRow.Cells[1].Value.ToString();
                checkGioiTinh(gbGioiTinh, dtgv_KhachHang.CurrentRow.Cells[2].Value.ToString());
                dpk_NgaySinh.Text = dtgv_KhachHang.CurrentRow.Cells[3].Value.ToString();
                txtDienThoai.Text = dtgv_KhachHang.CurrentRow.Cells[4].Value.ToString();
                txtDiaChi.Text = dtgv_KhachHang.CurrentRow.Cells[5].Value.ToString();
                txtTenDN.Text = dtgv_KhachHang.CurrentRow.Cells[6].Value.ToString();
                cboLoaiKH.Text = dalkh.traVeTenLoaiKH(dtgv_KhachHang.CurrentRow.Cells[7].Value.ToString());
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text) || String.IsNullOrEmpty(txtTenKH.Text) || 
                String.IsNullOrEmpty(txtDienThoai.Text) || String.IsNullOrEmpty(txtDiaChi.Text) ||
                String.IsNullOrEmpty(txtTenDN.Text) || String.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Mã khách hàng, tên khách hàng, số điện thoại, địa chỉ, tên đăng nhập, mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDienThoai.Text.Length > 10 || txtMaKH.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại, mã khách hàng không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenKH.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên khách hàng không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim().Length > 500)
            {
                MessageBox.Show("Địa chỉ khách hàng không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtTenDN.Text.Trim().Length > 50)
            {
                MessageBox.Show("Tên đăng nhập khách hàng không được vượt quá 50 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMatKhau.Text.Trim().Length > 20)
            {
                MessageBox.Show("Mật khẩu khách hàng không được vượt quá 20 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ktCheckGioiTinh(gbGioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int kh = int.Parse(txtMaKH.Text.Trim());            
            DateTime ns = dpk_NgaySinh.Value;
            if (!daKH.ktTenDN(txtTenDN.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập là duy nhất không thể trùng! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daKH.themKhachHang(txtTenKH.Text.Trim(), traVeGioiTinh(gbGioiTinh), ns, txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), txtTenDN.Text.Trim(), txtMatKhau.Text.Trim(),cboLoaiKH.SelectedValue.ToString()))
            { 
                loadDataGridView();
                MessageBox.Show("Thêm khách hàng mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm khách hàng mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Mã khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int kh = int.Parse(txtMaKH.Text.Trim());
            if (daKH.ktKhoaChinh(kh))
            {
                MessageBox.Show("Mã khách hàng này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return;
            }
            DialogResult r;
            r = MessageBox.Show("Nếu bạn xóa khách hàng này thì toàn bộ hóa đơn mua hàng của khách hàng này sẽ bị xóa. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (daKH.xoaKhachHang(kh))
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
            if (String.IsNullOrEmpty(txtMaKH.Text) || String.IsNullOrEmpty(txtTenKH.Text) ||
                String.IsNullOrEmpty(txtDienThoai.Text) || String.IsNullOrEmpty(txtDiaChi.Text)
                || String.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Mã khách hàng, tên khách hàng, số điện thoại, địa chỉ, mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDienThoai.Text.Length > 10 || txtMaKH.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại, mã khách hàng không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMatKhau.Text.Trim().Length > 20)
            {
                MessageBox.Show("Mật khẩu khách hàng không được vượt quá 20 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ktCheckGioiTinh(gbGioiTinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim().Length > 500)
            {
                MessageBox.Show("Địa chỉ khách hàng không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int kh = int.Parse(txtMaKH.Text.Trim());
            if (daKH.ktKhoaChinh(kh))
            {
                MessageBox.Show("Mã khách hàng này chưa tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime ns = DateTime.Parse(dpk_NgaySinh.Text);
            if (daKH.suaKhachHang(kh, txtTenKH.Text.Trim(), traVeGioiTinh(gbGioiTinh), ns, txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), txtMatKhau.Text.Trim(),cboLoaiKH.SelectedValue.ToString()))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
