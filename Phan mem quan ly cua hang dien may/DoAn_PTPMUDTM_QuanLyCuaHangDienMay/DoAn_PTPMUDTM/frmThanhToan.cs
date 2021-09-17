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
using DevExpress.XtraReports.UI;
using DoAn_PTPMUDTM.Report;


namespace DoAn_PTPMUDTM
{
    public partial class frmThanhToan : Form
    {
        BLLDALSanPham daSP = new BLLDALSanPham();
        BLLDALKhachHang daKH = new BLLDALKhachHang();
        BLLDALHoaDon daHD = new BLLDALHoaDon();
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALChiTietHoaDon daCTHD = new BLLDALChiTietHoaDon();
        BLLDALReportHoaDon daRPHD = new BLLDALReportHoaDon();
        List<ChiTietHoaDon> ds = new List<ChiTietHoaDon>();
        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {

            cboKhachHang.DataSource = daKH.loadKhachHang();
            cboKhachHang.DisplayMember = "TENKH";
            cboKhachHang.ValueMember = "MAKH";

            cboSanPham.DataSource = daSP.loadSanPham();
            cboSanPham.ValueMember = "MASP";
            cboSanPham.DisplayMember = "TENSP";
            

            btnCapNhat.Enabled = false;
            btnThemSanPham.Enabled = false;
            btnXoa.Enabled = false;
            btnThanhToan.Enabled = false;
            btnHuy.Enabled = false;
            cboSanPham.Enabled = false;
            txtSoLuong.Enabled = false;
        }

        public void loadDataGridView()
        {
            dtgv_CTHD.DataSource = null;          
            dtgv_CTHD.DataSource = ds;
            dtgv_CTHD.Columns[0].HeaderText = "Mã hóa đơn";
            dtgv_CTHD.Columns[1].HeaderText = "Mã sản phẩm";
            dtgv_CTHD.Columns[2].HeaderText = "Số lượng";
            dtgv_CTHD.Columns[3].HeaderText = "Đơn giá";
            dtgv_CTHD.Columns[4].HeaderText = "Giảm giá";
            dtgv_CTHD.Columns[5].HeaderText = "Thành tiền";
        }

        private void frmThanhToan_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string maNV = daNV.traVeMaNhanVien(Program.tenDangNhap);
            int maKH = int.Parse(cboKhachHang.SelectedValue.ToString());
            if (daHD.themHoaDon(maNV, maKH))
            {
                txtMaHD.Text = daHD.traVeMaHoaDon() + "";
                btnThemSanPham.Enabled = true;
                btnHuy.Enabled = true; 
                cboSanPham.Enabled = true;
                txtSoLuong.Enabled = true;
                cboKhachHang.Enabled = false;
                btnTaoHoaDon.Enabled = false;
                MessageBox.Show("Tạo hóa đơn mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tạo hóa đơn mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Hóa đơn này vẫn chưa thanh toán, bạn có chắc chắn muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int maHD = int.Parse(txtMaHD.Text.Trim());
                if (ds.Any())
                {
                    MessageBox.Show("Hóa đơn này đang có chi tiết hóa đơn! Xin vui lòng thanh toán hoặc xóa chi tiết hóa đơn trước khi hủy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daHD.huyHoaDon(maHD))
                {
                    btnCapNhat.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThemSanPham.Enabled = false;
                    btnHuy.Enabled = false;
                    btnThanhToan.Enabled = false;
                    btnTaoHoaDon.Enabled = true;
                    txtMaHD.ResetText();
                    txtSoLuong.ResetText();
                    txtThanhTien.ResetText();
                    MessageBox.Show("Hủy hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hủy hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()) || String.IsNullOrEmpty(txtThanhTien.Text.Trim()))
            {
                MessageBox.Show("Số lượng, đơn giá bán, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong = int.Parse(txtSoLuong.Text);
            int? soLuongHienCo = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString());
            double donGiaBan = double.Parse(txtDonGiaBan.Text);
            double thanhTien = double.Parse(txtThanhTien.Text);
            double giamGia;            
            int maHD = int.Parse(txtMaHD.Text.Trim());
            if (Double.TryParse(txtGiamGia.Text.Trim(), out giamGia))
            {
                giamGia = double.Parse(txtGiamGia.Text.Trim());
            }
            else
            {
                giamGia = 0;
            }
            if (!daCTHD.ktKhoaChinh(maHD, cboSanPham.SelectedValue.ToString(), ds))
            {
                MessageBox.Show("Đã có sản phẩm này trong danh sách nên không thể thêm! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soLuong < 0 || thanhTien < 0)
            {
                MessageBox.Show("Số lượng, thành tiền không được nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soLuongHienCo == 0)
            {
                MessageBox.Show("Sản phẩm này đã hết hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (soLuong > soLuongHienCo)
                {
                    MessageBox.Show("Số lượng nhập vào đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daCTHD.themCTHD(maHD, cboSanPham.SelectedValue.ToString(), soLuong, donGiaBan, giamGia, thanhTien, ds))
                {
                    loadDataGridView();
                    btnThanhToan.Enabled = true;
                    btnCapNhat.Enabled = true;
                    btnXoa.Enabled = true;
                    btnThanhToan.Enabled = true;
                    MessageBox.Show("Thêm chi tiết hóa đơn mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()) || String.IsNullOrEmpty(txtThanhTien.Text.Trim()))
            {
                MessageBox.Show("Số lượng, đơn giá bán, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong = int.Parse(txtSoLuong.Text);
            int? soLuongHienCo = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString());
            double donGiaBan = double.Parse(txtDonGiaBan.Text);
            double thanhTien = double.Parse(txtThanhTien.Text);
            double giamGia;
            int maHD = int.Parse(txtMaHD.Text.Trim());
            if (Double.TryParse(txtGiamGia.Text.Trim(), out giamGia))
            {
                giamGia = double.Parse(txtGiamGia.Text.Trim());
            }
            else
            {
                giamGia = 0;
            }
            if (daCTHD.ktKhoaChinh(maHD, cboSanPham.SelectedValue.ToString(), ds))
            {
                MessageBox.Show("Sản phẩm này không có trong danh sách nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soLuong < 0 || thanhTien < 0)
            {
                MessageBox.Show("Số lượng, thành tiền không được nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (soLuongHienCo == 0)
            {
                MessageBox.Show("Sản phẩm này đã hết hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (soLuong > soLuongHienCo)
                {
                    MessageBox.Show("Số lượng nhập vào đang lớn hơn số lượng sản phẩm hiện có! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daCTHD.suaCTHD(maHD, cboSanPham.SelectedValue.ToString(), soLuong, donGiaBan, giamGia, thanhTien, ds))
                {
                    loadDataGridView();
                    MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật chi tiết hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {            
            int maHD = daHD.traVeMaHoaDon();
            if (daCTHD.ktKhoaChinh(maHD, cboSanPham.SelectedValue.ToString(), ds))
            {
                MessageBox.Show("Sản phẩm này không có trong danh sách nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daCTHD.xoaCTHD(maHD, cboSanPham.SelectedValue.ToString(), ds))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(ds.Count == 0)
                {
                    btnThanhToan.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Cập nhật chi tiết hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int maHD = daHD.traVeMaHoaDon();
            if (daHD.xacNhanThanhToan(maHD,ds))
            {
                daHD.capNhatSauKhiThanhToan(maHD);
                loadDataGridView();
                daSP.capNhatTinhTrang();
                btnCapNhat.Enabled = false;
                btnThemSanPham.Enabled = false;
                btnXoa.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuy.Enabled = false;
                btnTaoHoaDon.Enabled = true;
                cboKhachHang.Enabled = true;
                txtSoLuong.Enabled = false;
                cboSanPham.Enabled = false;
                txtMaHD.ResetText();
                txtSoLuong.ResetText();
                MessageBox.Show("Thanh toán xong! Hóa đơn đã được lưu lại!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReportHoaDon rpt = new ReportHoaDon();
                rpt.lblNgayLap.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(daRPHD.traVeNgayLap(maHD).ToString()));
                rpt.lblTongTien.Text = string.Format("{0:0,0} VNĐ", daRPHD.traVeTongTien(maHD));
                rpt.lblThanhToan.Text = string.Format("{0:0,0} VNĐ", daRPHD.traVeThanhToan(maHD));
                rpt.DataSource = daRPHD.xuatHoaDon(maHD);                
                rpt.ShowPreviewDialog();
                
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            double? donGiaBan = daSP.traVeDonGiaBan(cboSanPham.SelectedValue.ToString());
            double? giamGia = daSP.traVeGiamGia(cboSanPham.SelectedValue.ToString());
            txtDonGiaBan.Text = donGiaBan + "";
            txtGiamGia.Text = giamGia + "";
            txtSoLuongHienCo.Text = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString()) + "";
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                if (!String.IsNullOrEmpty(txtGiamGia.Text.Trim()))
                {
                    double gg = double.Parse(txtGiamGia.Text.Trim());
                    txtThanhTien.Text = sl * gg + "";
                }
                else
                {
                    double dgb = double.Parse(txtDonGiaBan.Text.Trim());
                    txtThanhTien.Text = sl * dgb + "";
                }
            }
        }

        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                if (!String.IsNullOrEmpty(txtGiamGia.Text.Trim()))
                {
                    double gg = double.Parse(txtGiamGia.Text.Trim());
                    txtThanhTien.Text = sl * gg + "";
                }
                else
                {
                    double dgb = double.Parse(txtDonGiaBan.Text.Trim());
                    txtThanhTien.Text = sl * dgb + "";
                }
            }
        }

        private void dtgv_CTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_CTHD.CurrentRow != null)
            {
                txtMaHD.Text = dtgv_CTHD.CurrentRow.Cells[0].Value.ToString();
                cboSanPham.Text = daSP.traVeTenSanPham(dtgv_CTHD.CurrentRow.Cells[1].Value.ToString());
                txtSoLuong.Text = dtgv_CTHD.CurrentRow.Cells[2].Value.ToString();
                txtDonGiaBan.Text = dtgv_CTHD.CurrentRow.Cells[3].Value.ToString();
                txtGiamGia.Text = dtgv_CTHD.CurrentRow.Cells[4].Value?.ToString();
                txtThanhTien.Text = dtgv_CTHD.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                if (!String.IsNullOrEmpty(txtGiamGia.Text.Trim()))
                {
                    double gg = double.Parse(txtGiamGia.Text.Trim());
                    txtThanhTien.Text = sl * gg + "";
                }
                else
                {
                    double dgb = double.Parse(txtDonGiaBan.Text.Trim());
                    txtThanhTien.Text = sl * dgb + "";
                }
            }
        }

        private void frmThanhToan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ds.Count > 0)
            {
                MessageBox.Show("Vẫn còn mặt hàng trong danh sách! Vui lòng thanh toán hoặc hủy hóa đơn trước khi thoát!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                Program.frmMain.Show();
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
