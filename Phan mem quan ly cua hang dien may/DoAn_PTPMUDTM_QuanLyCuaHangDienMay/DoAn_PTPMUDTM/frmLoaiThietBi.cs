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
    public partial class frmLoaiThietBi : Form
    {
        BLLDALLoaiThietBi daLTB = new BLLDALLoaiThietBi();
        public frmLoaiThietBi()
        {
            InitializeComponent();
        }

        private void frmLoaiThietBi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void frmLoaiThietBi_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        public void loadDataGridView()
        {
            dtgv_LoaiThietBi.DataSource = daLTB.loadLoaiThietBi();
        }

        private void dtgv_LoaiThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgv_LoaiThietBi.CurrentRow != null)
            {
                txtMaLoai.Text = dtgv_LoaiThietBi.CurrentRow.Cells[0].Value.ToString();
                txtTenLoai.Text = dtgv_LoaiThietBi.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoai.Text.Trim()) || String.IsNullOrEmpty(txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại, tên loại thiết bị không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaLoai.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã loại thiết bị không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenLoai.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên loại thiết bị không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daLTB.ktKhoaChinh(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại thiết bị này đã tồn tại nên không thể thêm! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daLTB.themLoaiThietBi(txtMaLoai.Text.Trim(), txtTenLoai.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Thêm loại thiết bị mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm loại thiết bị mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại thiết bị không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daLTB.ktKhoaChinh(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại thiết bị này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult r;
            r = MessageBox.Show("Khi xóa đi loại thiết bị này thì những sản phẩm thuộc loại thiết bị này cũng bị xóa. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (daLTB.xoaLoaiThietBi(txtMaLoai.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa loại thiết bị thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa loại thiết bị thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaLoai.Text.Trim()) || String.IsNullOrEmpty(txtTenLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại, tên loại thiết bị không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenLoai.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên loại thiết bị không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daLTB.ktKhoaChinh(txtMaLoai.Text.Trim()))
            {
                MessageBox.Show("Mã loại thiết bị này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daLTB.suaLoaiThietBi(txtMaLoai.Text.Trim(), txtTenLoai.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật loại thiết bị thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật loại thiết bị thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMaLoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgv_LoaiThietBi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
