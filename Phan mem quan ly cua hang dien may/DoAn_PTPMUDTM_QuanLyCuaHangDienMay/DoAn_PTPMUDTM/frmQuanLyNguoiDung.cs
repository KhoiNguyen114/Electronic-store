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
    public partial class frmQuanLyNguoiDung : Form
    {
        BLLDALNguoiDungNhomNguoiDung daNDNND = new BLLDALNguoiDungNhomNguoiDung();
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLyNguoiDung_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            loadDSNguoiDung();

            cbbTenDN.DataSource = daNDNND.loadTenDN();
            cbbTenDN.DisplayMember = "TenDN";
            cbbTenDN.ValueMember = "TenDN";

            cbbMaNhom.DataSource = daNDNND.loadMaNhom();
            cbbMaNhom.DisplayMember = "TENNHOM";
            cbbMaNhom.ValueMember = "MANHOM";
        }

        public void loadDSNguoiDung()
        {
            dtgvQLNgDung.DataSource = daNDNND.loadQLNguoiDung();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!daNDNND.ktNguoiDungDaCoNhom(cbbTenDN.SelectedValue.ToString()))
            {
                MessageBox.Show("Mỗi người dùng chỉ được thuộc về 1 nhóm người dùng! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!daNDNND.ktKhoaChinhQLNguoiDung(cbbTenDN.SelectedValue.ToString(),cbbMaNhom.SelectedValue.ToString()))
            {
                MessageBox.Show("Người dùng này đã được phân vào nhóm người dùng nên không thể thêm! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtGhiChu.Text.Trim().Length > 200)
            {
                MessageBox.Show("Độ dài của ghi chú không được vượt quá 200 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNDNND.themQLNguoiDung(cbbTenDN.SelectedValue.ToString(), cbbMaNhom.SelectedValue.ToString(), txtGhiChu.Text.Trim()))
            {
                loadDSNguoiDung();
                MessageBox.Show("Thêm người dùng mới vào nhóm người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm người dùng mới vào nhóm người dùng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (daNDNND.ktKhoaChinhQLNguoiDung(cbbTenDN.SelectedValue.ToString(), cbbMaNhom.SelectedValue.ToString()))
            {
                MessageBox.Show("Người dùng này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daNDNND.xoaQLNguoiDung(cbbTenDN.SelectedValue.ToString(), cbbMaNhom.SelectedValue.ToString()))
            {
                loadDSNguoiDung();
                MessageBox.Show("Xóa người dùng ra khỏi nhóm người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa người dùng ra khỏi nhóm người dùng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtgvQLNgDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvQLNgDung != null)
            {
                try
                {
                    cbbTenDN.Text = dtgvQLNgDung.CurrentRow.Cells[0].Value.ToString();
                    cbbMaNhom.Text = daNDNND.traVeTenNhom(dtgvQLNgDung.CurrentRow.Cells[1].Value.ToString());
                    txtGhiChu.Text = dtgvQLNgDung.CurrentRow.Cells[2].Value?.ToString();
                }
                catch
                {
                    txtGhiChu.Text = "";
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
