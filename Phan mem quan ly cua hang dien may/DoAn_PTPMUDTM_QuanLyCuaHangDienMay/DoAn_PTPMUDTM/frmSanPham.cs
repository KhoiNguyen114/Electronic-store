using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;

namespace DoAn_PTPMUDTM
{
    public partial class frmSanPham : Form
    {
        BLLDALLoaiThietBi daLTB = new BLLDALLoaiThietBi();
        BLLDALNhaSanXuat daNSX = new BLLDALNhaSanXuat();
        BLLDALSanPham daSP = new BLLDALSanPham();
        BLLDALHoaDon daHD = new BLLDALHoaDon();

        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            loadDataGridView();

            cboLoaiThietBi.DataSource = daLTB.loadLoaiThietBi();
            cboLoaiThietBi.DisplayMember = "TENTHIETBI";
            cboLoaiThietBi.ValueMember = "MATHIETBI";

            cboNhaSanXuat.DataSource = daNSX.loadNhaSanXuat();
            cboNhaSanXuat.DisplayMember = "TENNSX";
            cboNhaSanXuat.ValueMember = "MANSX";
        }

        public void loadDataGridView()
        {
            dtgv_SanPham.DataSource = daSP.loadSanPham();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtMoTa.ResetText();
            txtSoLuong.ResetText();
            txtDonGiaBan.ResetText();
            txtGiamGia.ResetText();
            txtMaSP.Focus();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaSP.Text.Trim()) || String.IsNullOrEmpty(txtTenSP.Text.Trim())
                || String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()) || String.IsNullOrEmpty(txtSoLuong.Text.Trim())
                || String.IsNullOrEmpty(txtMoTa.Text.Trim()) || String.IsNullOrEmpty(txtThoiGianBH.Text.Trim()))
            {
                MessageBox.Show("Mã, tên, đơn giá bán, số lượng, mô tả, thời gian bảo hành sản phẩm không được để trống không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtMaSP.Text.Trim().Length > 10)
            {
                MessageBox.Show("Mã sản phẩm không được vượt quá 10 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenSP.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên sản phẩm không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!daSP.ktKhoaChinh(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại nên không thể thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double donGia = double.Parse(txtDonGiaBan.Text.Trim());
            int soLuong = int.Parse(txtSoLuong.Text.Trim());
            double giamGia;
            if (Double.TryParse(txtGiamGia.Text.Trim(), out giamGia))
            {
                giamGia = double.Parse(txtGiamGia.Text.Trim());
            }
            else
            {
                giamGia = 0;
            }
            int thoiGianBH = int.Parse(txtThoiGianBH.Text.Trim());
            if (soLuong < 0 || donGia < 0 || giamGia < 0)
            {
                MessageBox.Show("Số lượng sản phẩm, đơn giá bán, giảm giá chỉ có thể lớn hơn hoặc bằng 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(giamGia >= donGia)
            {
                MessageBox.Show("Giảm giá không thể lớn hơn hoặc bằng đơn giá bán! Xin vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(String.IsNullOrEmpty(txtAnh.Text.Trim()))
            {
                DialogResult r = MessageBox.Show("Ảnh hiện tại đang không chọn. Bạn có muốn sử dụng ảnh của hệ thống không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(r == DialogResult.Yes)
                {
                    string hinh = "logoDienMay.png";
                    if (daSP.themSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), soLuong, donGia, cboLoaiThietBi.SelectedValue.ToString(), cboNhaSanXuat.SelectedValue.ToString(), giamGia, txtMoTa.Text.Trim(), thoiGianBH, hinh))
                    {
                        loadDataGridView();
                        MessageBox.Show("Thêm sản phẩm mới thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm sản phẩm mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }                
            }
            else
            {
                string hinh = Path.GetFileName(txtAnh.Text.Trim());
                if (daSP.themSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), soLuong, donGia, cboLoaiThietBi.SelectedValue.ToString(), cboNhaSanXuat.SelectedValue.ToString(), giamGia, txtMoTa.Text.Trim(), thoiGianBH, hinh))
                {
                    loadDataGridView();
                    try
                    {
                        File.Copy(txtAnh.Text.Trim(), Path.Combine(Application.StartupPath, "\\Images\\HinhSP\\", hinh), true);
                    }
                    catch
                    {

                    }
                    MessageBox.Show("Thêm sản phẩm mới thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm không được để trống không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daSP.ktKhoaChinh(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm này không tồn tại nên không thể xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult r;
            r = MessageBox.Show("Khi bạn xóa sản phẩm này thì toàn bộ chi tiết hóa đơn, chi tiết phiếu nhập có mã sản phẩm này cũng sẽ bị xóa theo. Bạn có muốn tiếp tục không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (daSP.xoaSP(txtMaSP.Text.Trim()))
                {
                    loadDataGridView();
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaSP.Text.Trim()) || String.IsNullOrEmpty(txtTenSP.Text.Trim())
                || String.IsNullOrEmpty(txtDonGiaBan.Text.Trim()) || String.IsNullOrEmpty(txtSoLuong.Text.Trim())
                || String.IsNullOrEmpty(txtMoTa.Text.Trim()) || String.IsNullOrEmpty(txtThoiGianBH.Text.Trim()))
            {
                MessageBox.Show("Mã, tên, đơn giá bán, số lượng, mô tả, thời gian bảo hành sản phẩm không được để trống không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTenSP.Text.Trim().Length > 500)
            {
                MessageBox.Show("Tên sản phẩm không được vượt quá 500 kí tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daSP.ktKhoaChinh(txtMaSP.Text.Trim()))
            {
                MessageBox.Show("Mã sản phẩm này không tồn tại nên không thể cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double donGia = double.Parse(txtDonGiaBan.Text.Trim());
            int soLuong = int.Parse(txtSoLuong.Text.Trim());            
            int thoiGianBH = int.Parse(txtThoiGianBH.Text.Trim());
            double giamGia;
            if (Double.TryParse(txtGiamGia.Text.Trim(), out giamGia))
            {
                giamGia = double.Parse(txtGiamGia.Text.Trim());
            }
            else
            {
                giamGia = 0;
            }
            if (soLuong < 0 || donGia < 0 || giamGia < 0)
            {
                MessageBox.Show("Số lượng sản phẩm, đơn giá bán, giảm giá chỉ có thể lớn hơn hoặc bằng 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (giamGia >= donGia)
            {
                MessageBox.Show("Giảm giá không thể lớn hơn hoặc bằng đơn giá bán! Xin vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(txtAnh.Text.Trim()))
            {
                DialogResult r = MessageBox.Show("Ảnh hiện tại đang không chọn. Bạn có muốn sử dụng ảnh của hệ thống không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    string hinh = "logoDienMay.png";
                    if (daSP.suaSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), soLuong, donGia, cboLoaiThietBi.SelectedValue.ToString(), cboNhaSanXuat.SelectedValue.ToString(), giamGia, txtMoTa.Text.Trim(), thoiGianBH, hinh))
                    {
                        loadDataGridView();
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                string hinh = Path.GetFileName(txtAnh.Text);
                if (daSP.suaSP(txtMaSP.Text.Trim(), txtTenSP.Text.Trim(), soLuong, donGia, cboLoaiThietBi.SelectedValue.ToString(), cboNhaSanXuat.SelectedValue.ToString(), giamGia, txtMoTa.Text.Trim(), thoiGianBH, hinh))
                {
                    loadDataGridView();
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        File.Copy(txtAnh.Text.Trim(), Path.Combine(Application.StartupPath, "\\Images\\HinhSP\\", hinh), true);
                    }
                    catch
                    {

                    }     
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_SanPham.CurrentRow != null)
            {
                txtMaSP.Text = dtgv_SanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dtgv_SanPham.CurrentRow.Cells[1].Value.ToString();
                txtDonGiaBan.Text = dtgv_SanPham.CurrentRow.Cells[2].Value.ToString();
                txtMoTa.Text = dtgv_SanPham.CurrentRow.Cells[3].Value?.ToString();
                txtSoLuong.Text = dtgv_SanPham.CurrentRow.Cells[4].Value.ToString();
                txtGiamGia.Text = dtgv_SanPham.CurrentRow.Cells[6].Value?.ToString();
                cboNhaSanXuat.Text = daNSX.traVeTenNSX(dtgv_SanPham.CurrentRow.Cells[7].Value.ToString());
                cboLoaiThietBi.Text = daLTB.traVeTenLoaiThietBi(dtgv_SanPham.CurrentRow.Cells[8].Value.ToString());
                txtTinhTrang.Text = dtgv_SanPham.CurrentRow.Cells[9].Value.ToString();
                txtThoiGianBH.Text = dtgv_SanPham.CurrentRow.Cells[10].Value.ToString();
                txtAnh.Text = dtgv_SanPham.CurrentRow.Cells[5].Value.ToString();

                try
                {
                    pictureSP.Image = new Bitmap(Application.StartupPath + "\\Images\\HinhSP\\" + txtAnh.Text);
                    //Vị trí xuất phát của file thực thi debug (Application.StartupPath)
                    //Các image được để trong file Resources sau đó copy file Resource vào -> bin -> debug 
                }
                catch
                {
                    pictureSP.Image = new Bitmap(Application.StartupPath + "\\Images\\HinhSP\\logoDienMay.png");
                }               
               
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgv_SanPham.DataSource = daSP.loadDanhSachSanPhamTheoTimKiem(txtTimKiem.Text.Trim());
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FilterIndex = 1;
            openFileDialog1.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofd.FileName;

                try
                {
                    pictureSP.Image = daSP.LoadHinh(fileName);
                    txtAnh.Text = fileName;
                }
                catch
                {
                    MessageBox.Show("Ảnh này không tồn tại! Vui lòng kiểm tra lại đường dẫn hoặc loại file!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
