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
    public partial class frmNhaSanXuat : Form
    {
        BLLDALNhaSanXuat daNSX = new BLLDALNhaSanXuat();
        public frmNhaSanXuat()
        {
            InitializeComponent();
        }

        private void frmNhaSanXuat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void frmNhaSanXuat_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        public void loadDataGridView()
        {
            dtgv_NhaSanXuat.DataSource = daNSX.loadNhaSanXuat();
        }

        private void dtgv_NhaSanXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgv_NhaSanXuat.CurrentRow != null)
            {
                txtMaNSX.Text = dtgv_NhaSanXuat.CurrentRow.Cells[0].Value.ToString();
                txtTenNSX.Text = dtgv_NhaSanXuat.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dtgv_NhaSanXuat.CurrentRow.Cells[2].Value.ToString();
                txtDienThoai.Text = dtgv_NhaSanXuat.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNSX.Text.Trim()) || String.IsNullOrEmpty(txtTenNSX.Text.Trim()) || String.IsNullOrEmpty(txtDiaChi.Text.Trim()) || String.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Mã, tên, địa chỉ, số điện thoại nhà sản xuất không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaNSX.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã nhà sản xuất không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenNSX.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên nhà sản xuất không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim().Length > 500)
            {
                MessageBox.Show("Địa chỉ nhà sản xuất không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDienThoai.Text.Trim().Length > 12)
            {
                MessageBox.Show("Số điện thoại nhà sản xuất không được vượt quá 12 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!daNSX.ktKhoaChinh(txtMaNSX.Text.Trim()))
            {
                MessageBox.Show("Mã nhà sản xuất này đã tồn tại nên không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(daNSX.themNSX(txtMaNSX.Text.Trim(),txtTenNSX.Text.Trim(),txtDiaChi.Text.Trim(),txtDienThoai.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Thêm nhà sản xuất mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm nhà sản xuất mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNSX.Text.Trim()))
            {
                MessageBox.Show("Mã nhà sản xuất không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNSX.ktKhoaChinh(txtMaNSX.Text.Trim()))
            {
                MessageBox.Show("Mã nhà sản xuất này không tồn tại nên không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult r = MessageBox.Show("Khi xóa 1 nhà sản xuất này thì toàn bộ sản phẩm thuộc nhà sản xuất này cũng bị xóa theo. Bạn có muốn tiếp tục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
            {
                if (daNSX.xoaNSX(txtMaNSX.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa nhà sản xuất thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa nhà sản xuất thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNSX.Text.Trim()) || String.IsNullOrEmpty(txtTenNSX.Text.Trim()) || String.IsNullOrEmpty(txtDiaChi.Text.Trim()) || String.IsNullOrEmpty(txtDienThoai.Text.Trim()))
            {
                MessageBox.Show("Mã, tên, địa chỉ, số điện thoại nhà sản xuất không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            if (txtTenNSX.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên nhà sản xuất không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiaChi.Text.Trim().Length > 500)
            {
                MessageBox.Show("Địa chỉ nhà sản xuất không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDienThoai.Text.Trim().Length > 12)
            {
                MessageBox.Show("Số điện thoại nhà sản xuất không được vượt quá 12 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNSX.ktKhoaChinh(txtMaNSX.Text.Trim()))
            {
                MessageBox.Show("Mã nhà sản xuất này không tồn tại nên không thể thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNSX.suaNSX(txtMaNSX.Text.Trim(), txtTenNSX.Text.Trim(), txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật nhà sản xuất thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật nhà sản xuất thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
