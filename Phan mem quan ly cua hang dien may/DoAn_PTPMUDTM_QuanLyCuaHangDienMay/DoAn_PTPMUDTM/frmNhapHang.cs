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
    public partial class frmNhapHang : Form
    {
        BLLDALSanPham daSP = new BLLDALSanPham();
        BLLDALNhaSanXuat daNSX = new BLLDALNhaSanXuat();
        BLLDALNhapHang daPN = new BLLDALNhapHang();
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALChiTietNhapHang daCTPN = new BLLDALChiTietNhapHang();
        BLLDALReportPhieuNhap daRPPN = new BLLDALReportPhieuNhap();
        List<ChiTietPhieuNhap> ds = new List<ChiTietPhieuNhap>();

        public frmNhapHang()
        {
            InitializeComponent();
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            cboNhaSanXuat.DataSource = daNSX.loadNhaSanXuat();
            cboNhaSanXuat.DisplayMember = "TENNSX";
            cboNhaSanXuat.ValueMember = "MANSX";

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
            dtgv_CTPN.DataSource = null;
            dtgv_CTPN.DataSource = ds;
            dtgv_CTPN.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgv_CTPN.Columns[1].HeaderText = "Mã sản phẩm";
            dtgv_CTPN.Columns[2].HeaderText = "Số lượng";
            dtgv_CTPN.Columns[3].HeaderText = "Đơn giá";
            dtgv_CTPN.Columns[4].HeaderText = "Thành tiền";
        }

        private void frmNhapHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string maNV = daNV.traVeMaNhanVien(Program.tenDangNhap);
            if (daPN.themPhieuNhap(maNV, cboNhaSanXuat.SelectedValue.ToString()))
            {
                txtMaPN.Text = daPN.traVeMaPhieuNhap() + "";
                btnThemSanPham.Enabled = true;
                btnHuy.Enabled = true;
                cboSanPham.Enabled = true;
                txtSoLuong.Enabled = true;
                cboNhaSanXuat.Enabled = false;
                btnTaoHoaDon.Enabled = false;
                MessageBox.Show("Tạo phiếu nhập mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tạo phiếu nhập mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Phiếu nhập này vẫn chưa thanh toán, bạn có chắc chắn muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                int maHD = int.Parse(txtMaPN.Text.Trim());
                if (ds.Any())
                {
                    MessageBox.Show("Phiếu nhập này đang có chi tiết hóa đơn! Xin vui lòng thanh toán hoặc xóa chi tiết phiếu nhập trước khi hủy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (daPN.huyPhieuNhap(maHD))
                {
                    btnCapNhat.Enabled = false;
                    btnXoa.Enabled = false;
                    btnThemSanPham.Enabled = false;
                    btnHuy.Enabled = false;
                    btnThanhToan.Enabled = false;
                    btnTaoHoaDon.Enabled = true;
                    txtMaPN.ResetText();
                    txtSoLuong.ResetText();
                    txtThanhTien.ResetText();
                    MessageBox.Show("Hủy phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hủy phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()) || String.IsNullOrEmpty(txtThanhTien.Text.Trim()))
            {
                MessageBox.Show("Số lượng, đơn giá bán, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong = int.Parse(txtSoLuong.Text);
            int? soLuongHienCo = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString());
            double donGiaBan = double.Parse(txtDonGiaNhap.Text);
            double thanhTien = double.Parse(txtThanhTien.Text);
            int maHD = int.Parse(txtMaPN.Text.Trim());
            if (!daCTPN.ktKhoaChinh(maHD, cboSanPham.SelectedValue.ToString(), ds))
            {
                MessageBox.Show("Đã có sản phẩm này trong danh sách nên không thể thêm! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soLuong < 0 || thanhTien < 0)
            {
                MessageBox.Show("Số lượng, thành tiền không được nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daCTPN.themCTPN(maHD, cboSanPham.SelectedValue.ToString(), soLuong, donGiaBan, thanhTien, ds))
            {
                loadDataGridView();
                btnThanhToan.Enabled = true;
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnThanhToan.Enabled = true;
                MessageBox.Show("Thêm chi tiết phiếu nhập mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm chi tiết phiếu nhập mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSoLuong.Text.Trim()) || String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()) || String.IsNullOrEmpty(txtThanhTien.Text.Trim()))
            {
                MessageBox.Show("Số lượng, đơn giá bán, thành tiền không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuong = int.Parse(txtSoLuong.Text);
            int? soLuongHienCo = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString());
            double donGiaBan = double.Parse(txtDonGiaNhap.Text);
            double thanhTien = double.Parse(txtThanhTien.Text);
            int maHD = int.Parse(txtMaPN.Text.Trim());
            if (daCTPN.ktKhoaChinh(maHD, cboSanPham.SelectedValue.ToString(), ds))
            {
                MessageBox.Show("Sản phẩm này không có trong danh sách nên không thể cập nhật! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soLuong < 0 || thanhTien < 0)
            {
                MessageBox.Show("Số lượng, thành tiền không được nhỏ hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daCTPN.suaCTPN(maHD, cboSanPham.SelectedValue.ToString(), soLuong, donGiaBan, thanhTien, ds))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật chi tiết phiếu nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật chi tiết phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int maHD = daPN.traVeMaPhieuNhap();
            if (daCTPN.ktKhoaChinh(maHD, cboSanPham.SelectedValue.ToString(), ds))
            {
                MessageBox.Show("Sản phẩm này không có trong danh sách nên không thể xóa! Xin vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (daCTPN.xoaCTPN(maHD, cboSanPham.SelectedValue.ToString(), ds))
            {
                loadDataGridView();
                MessageBox.Show("Cập nhật chi tiết hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ds.Count == 0)
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
            int maHD = daPN.traVeMaPhieuNhap();
            if (daPN.xacNhanThanhToan(maHD, ds))
            {
                daPN.capNhatSauKhiThanhToan(maHD);
                loadDataGridView();
                daSP.capNhatTinhTrang();
                btnCapNhat.Enabled = false;
                cboSanPham.Enabled = false;
                btnThemSanPham.Enabled = false;
                btnXoa.Enabled = false;
                btnThanhToan.Enabled = false;
                btnHuy.Enabled = false;
                btnTaoHoaDon.Enabled = true;
                cboNhaSanXuat.Enabled = true;
                txtSoLuong.Enabled = false;
                txtMaPN.ResetText();
                txtSoLuong.ResetText();
                MessageBox.Show("Thanh toán xong! Phiếu nhập đã được lưu lại!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ReportPhieuNhap rpt = new ReportPhieuNhap();
                rpt.lblNgayLap.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(daRPPN.traVeNgayLap(maHD).ToString()));
                rpt.lblTongTien.Text = string.Format("{0:0,0} VNĐ", daRPPN.traVeTongTien(maHD));
                rpt.DataSource = daRPPN.xuatPhieuNhap(maHD);
                rpt.ShowPreviewDialog();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtgv_CTPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_CTPN.CurrentRow != null)
            {
                txtMaPN.Text = dtgv_CTPN.CurrentRow.Cells[0].Value.ToString();
                cboSanPham.Text = daSP.traVeTenSanPham(dtgv_CTPN.CurrentRow.Cells[1].Value.ToString());
                txtSoLuong.Text = dtgv_CTPN.CurrentRow.Cells[2].Value.ToString();
                txtDonGiaNhap.Text = dtgv_CTPN.CurrentRow.Cells[3].Value.ToString();
                txtThanhTien.Text = dtgv_CTPN.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            double? donGiaNhap = daSP.traVeDonGiaBan(cboSanPham.SelectedValue.ToString());
            txtDonGiaNhap.Text = donGiaNhap + "";
            txtSoLuongHienCo.Text = daSP.traVeSoLuong(cboSanPham.SelectedValue.ToString()) + "";
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()) && !String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                double dgn = double.Parse(txtDonGiaNhap.Text.Trim());
                txtThanhTien.Text = sl * dgn + "";
            }
        }

        private void txtDonGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSoLuong.Text.Trim()) && !String.IsNullOrEmpty(txtDonGiaNhap.Text.Trim()))
            {
                int sl = int.Parse(txtSoLuong.Text.Trim());
                double dgn = double.Parse(txtDonGiaNhap.Text.Trim());
                txtThanhTien.Text = sl * dgn + "";
            }
        }

        private void frmNhapHang_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
