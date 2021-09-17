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
    public partial class frmChucVu : Form
    {

        BLLDALChucVu daCV = new BLLDALChucVu();
        public frmChucVu()
        {
            InitializeComponent();
        }

        private void frmChucVu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }
        public void loadDataGridView()
        {
            dtgv_ChucVu.DataSource = daCV.loadChucVu();
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void dtgv_ChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_ChucVu.CurrentRow != null)
            {
                txtMaCV.Text = dtgv_ChucVu.CurrentRow.Cells[0].Value.ToString();
                txtTenCV.Text = dtgv_ChucVu.CurrentRow.Cells[1].Value.ToString();
                txtLuongCB.Text = dtgv_ChucVu.CurrentRow.Cells[2].Value.ToString();               
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int luong = int.Parse(txtLuongCB.Text.Trim());
            if (String.IsNullOrEmpty(txtMaCV.Text.Trim()) || String.IsNullOrEmpty(txtTenCV.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ, tên chức vụ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaCV.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã chức vụ không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenCV.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên chức vụ không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           
            if (!daCV.ktKhoaChinh(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ này đã tồn tại nên không thể thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daCV.themCV(txtMaCV.Text.Trim(), txtTenCV.Text.Trim(), luong))
            {
                loadDataGridView();
                MessageBox.Show("Thêm chức vụ mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm chức vụ mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int luong = int.Parse(txtLuongCB.Text.Trim());
            if (String.IsNullOrEmpty(txtTenCV.Text.Trim()) || String.IsNullOrEmpty(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ, tên chức vụ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenCV.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên chức vụ không được vượt quá 100 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daCV.ktKhoaChinh(txtMaCV.Text.Trim()))
            {
                MessageBox.Show("Mã chức vụ này không tồn tại nên không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daCV.suaCV(txtMaCV.Text.Trim(), txtTenCV.Text.Trim(), luong))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật chức vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật chức vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Gpb_ThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTenCV_Click(object sender, EventArgs e)
        {

        }

        private void dtgv_ChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
