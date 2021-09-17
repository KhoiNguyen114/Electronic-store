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
    public partial class frmLoaiKhachHang : Form
    {
        BLLDALLoaiKhachHang dalkh = new BLLDALLoaiKhachHang();
        public frmLoaiKhachHang()
        {
            InitializeComponent();
        }

        private void frmLoaiKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }
        public void loadDataGridView()
        {
            dtgv_LoaiKH.DataSource = dalkh.loadLoaiKhachHang();
        }

        private void frmLoaiKhachHang_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void dtgv_LoaiKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_LoaiKH.CurrentRow != null)
            {
                txtMaLoaiKH.Text = dtgv_LoaiKH.CurrentRow.Cells[0].Value.ToString();
                txtTenLoaiKH.Text = dtgv_LoaiKH.CurrentRow.Cells[1].Value.ToString();
                txtGiamGia.Text = dtgv_LoaiKH.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int giamgia = int.Parse(txtGiamGia.Text.Trim());
            if (String.IsNullOrEmpty(txtMaLoaiKH.Text.Trim()) || String.IsNullOrEmpty(txtTenLoaiKH.Text.Trim()) || String.IsNullOrEmpty(txtGiamGia.Text.Trim()))
            {
                MessageBox.Show("Mã loại, tên loại khách hàng và giảm giá không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaLoaiKH.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã loại khách hàng không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenLoaiKH.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên loại khách hàng không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (giamgia < 0 || giamgia > 100)
            {
                MessageBox.Show("Giảm giá không được quá 100%!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!dalkh.ktKhoaChinh(txtMaLoaiKH.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng này đã tồn tại nên không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dalkh.themLoaiKH(txtMaLoaiKH.Text.Trim(), txtTenLoaiKH.Text.Trim(), giamgia))
            {
                loadDataGridView();
                MessageBox.Show("Thêm loại khách hàng mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm loại khách hàng mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int giamgia = int.Parse(txtGiamGia.Text.Trim());
            if (String.IsNullOrEmpty(txtMaLoaiKH.Text.Trim()) || String.IsNullOrEmpty(txtTenLoaiKH.Text.Trim()) || String.IsNullOrEmpty(txtGiamGia.Text.Trim()))
            {
                MessageBox.Show("Mã loại, tên loại khách hàng và giảm giá không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenLoaiKH.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên loại khách hàng không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (giamgia < 0 || giamgia > 100)
            {
                MessageBox.Show("Giảm giá không được quá 100%!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dalkh.ktKhoaChinh(txtMaLoaiKH.Text.Trim()))
            {
                MessageBox.Show("Mã loại khách hàng này không tồn tại nên không thể thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dalkh.suaLoaiKH(txtMaLoaiKH.Text.Trim(), txtTenLoaiKH.Text.Trim(), giamgia))
            { 
                loadDataGridView();
                MessageBox.Show("Cập nhật loại khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật loại khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
