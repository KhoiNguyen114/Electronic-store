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
    public partial class frmBaoHanh : Form
    {
        BLLDALBaoHanh daBH = new BLLDALBaoHanh();
        BLLDALKhachHang daKH = new BLLDALKhachHang();
        BLLDALSanPham daSP = new BLLDALSanPham();
        BLLDALHoaDon daHD = new BLLDALHoaDon();
        BLLDALChiTietHoaDon daCTHD = new BLLDALChiTietHoaDon();

        public frmBaoHanh()
        {
            InitializeComponent();
        }

        private void frmBaoHanh_Load(object sender, EventArgs e)
        {
            loadDataGridView();
            dtgv_BaoHanh.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            cboHoaDon.Enabled = false;
            cboTenSP.Enabled = false;

            cboTenKH.DataSource = daKH.loadKhachHang();
            cboTenKH.DisplayMember = "TENKH";
            cboTenKH.ValueMember = "MAKH";

            dtpNgayBH.CustomFormat = "dd/MM/yyyy";
        }
        public void loadDataGridView()
        {
            dtgv_BaoHanh.DataSource = daBH.loadBaoHanh();
        }

        private void dtgv_BaoHanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_BaoHanh.CurrentRow != null)
            {
                txtMaBH.Text = dtgv_BaoHanh.CurrentRow.Cells[0].Value.ToString();
                cboHoaDon.Text = dtgv_BaoHanh.CurrentRow.Cells[1].Value.ToString();
                cboTenKH.Text = daKH.traVeTenKhachHang(int.Parse(dtgv_BaoHanh.CurrentRow.Cells[2].Value.ToString()));
                cboTenSP.Text = daSP.traVeTenSanPham(dtgv_BaoHanh.CurrentRow.Cells[3].Value.ToString());
                dtpNgayBH.Text = dtgv_BaoHanh.CurrentRow.Cells[4].Value.ToString();
                txtGhiChu.Text = dtgv_BaoHanh.CurrentRow.Cells[5].Value.ToString();
                txtTinhTrang.Text = dtgv_BaoHanh.CurrentRow.Cells[6].Value?.ToString();
            }
        }

        private void btnBaoHanh_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Ghi chú không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cboHoaDon.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maHD = int.Parse(cboHoaDon.SelectedValue.ToString());
            if (cboTenSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daCTHD.ktKhoaChinh(maHD, cboTenSP.SelectedValue.ToString()))
            {
                MessageBox.Show("Hóa đơn này không có sản phẩm đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime nbh = dtpNgayBH.Value;
            DateTime ngayLapHD = (DateTime)daHD.traVeNgayLapHD(maHD);
            int maKH = int.Parse(cboTenKH.SelectedValue.ToString());
            int thoiGianBH = (int)daSP.traVeThoiGianBH(cboTenSP.SelectedValue.ToString());
            if(daBH.kiemTraThoiGianBaoHanh(ngayLapHD,thoiGianBH) == -1)
            {
                MessageBox.Show("Sản phẩm này đã hết hạn nên không thể bảo hành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!daBH.ktDangBaoHanh(maHD, cboTenSP.SelectedValue.ToString(), maKH))
            {
                MessageBox.Show("Sản phẩm này đang được bảo hành rồi! Xin vui lòng thử lại hoặc nhấn Hoàn thành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daBH.BaoHanh(maHD, nbh, maKH, cboTenSP.SelectedValue.ToString(), txtGhiChu.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Sản phẩm nhận bảo hành thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sản phẩm không nhận bảo hành!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaBH.Text) || String.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Mã bảo hành, ghi chú không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            int bh = int.Parse(txtMaBH.Text.Trim());
            if (daBH.ktKhoaChinh(bh))
            {
                MessageBox.Show("Mã bảo hành này không tồn tại nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daBH.suaThongTinBH(bh, txtGhiChu.Text.Trim()))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật thông tin bảo hành thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin bảo hành thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaBH.Text))
            {
                MessageBox.Show("Mã bảo hành không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int bh = int.Parse(txtMaBH.Text.Trim());
            if (cboHoaDon.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maHD = int.Parse(cboHoaDon.SelectedValue.ToString());
            if (cboTenSP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daBH.ktKhoaChinh(bh))
            {
                MessageBox.Show("Mã bảo hành này không tồn tại nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaBH.Focus();
                return;
            }

            DialogResult r;
            r = MessageBox.Show("Bạn chỉ có thể xoá bảo hành sản phẩm khi và chỉ khi sản phẩm này hết thời hạn bảo hành. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                DateTime ngayLapHD = (DateTime)daHD.traVeNgayLapHD(maHD);
                int thoiGianBH = (int)daSP.traVeThoiGianBH(cboTenSP.SelectedValue.ToString());
                int maKH = int.Parse(cboTenKH.SelectedValue.ToString());
                if (!daBH.ktDangBaoHanh(maHD, cboTenSP.SelectedValue.ToString(), maKH))
                {
                    MessageBox.Show("Sản phẩm này đang được bảo hành nên không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daBH.kiemTraThoiGianBaoHanh(ngayLapHD, thoiGianBH) != -1)
                {
                    MessageBox.Show("Sản phẩm này còn thời hạn nên không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (daBH.xoaBaoHanh(bh))
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaoHanh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void cboTenKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboHoaDon.Enabled = true;
            int maKH;
            if(int.TryParse(cboTenKH.SelectedValue.ToString(), out maKH))
            {
                cboHoaDon.DataSource = daHD.loadHoaDonTheoKhachHang(maKH);
                cboHoaDon.DisplayMember = "MAHD";
                cboHoaDon.ValueMember = "MAHD";
            }            
        }

        private void cboHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboTenSP.Enabled = true;
            int maHD;
            if (int.TryParse(cboHoaDon.SelectedValue.ToString(), out maHD))
            {
                cboTenSP.DataSource = daSP.loadDanhSachSanPhamTheoHoaDon(maHD);
                cboTenSP.DisplayMember = "TENSP";
                cboTenSP.ValueMember = "MASP";
            }
            
        }

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtMaBH.Text.Trim()))
            {
                MessageBox.Show("Mã bảo hành không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maBH = int.Parse(txtMaBH.Text.Trim());
            if(daBH.capNhatBaoHanh(maBH))
            {
                loadDataGridView();
                MessageBox.Show("Thay đổi tình trạng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thay đổi tình trạng thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
