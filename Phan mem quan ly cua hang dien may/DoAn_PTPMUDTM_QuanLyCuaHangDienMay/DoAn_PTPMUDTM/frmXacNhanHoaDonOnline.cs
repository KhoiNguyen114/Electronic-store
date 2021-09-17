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
    public partial class frmXacNhanHoaDonOnline : Form
    {
        BLLDALHoaDon daHD = new BLLDALHoaDon();
        BLLDALChiTietHoaDon daCTHD = new BLLDALChiTietHoaDon();
        BLLDALNhanVien daNV = new BLLDALNhanVien();

        public frmXacNhanHoaDonOnline()
        {
            InitializeComponent();
        }

        private void frmXacNhanHoaDonOnline_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void frmXacNhanHoaDonOnline_Load(object sender, EventArgs e)
        {
            dtgv_HoaDon.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            loadDataGridView();
        }
        
        public void loadDataGridView()
        {
            dtgv_HoaDon.DataSource = daHD.loadXemHoaDonOnline();            
        }

        private void dtgv_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_HoaDon.CurrentRow != null)
            {
                int maHD = int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString());
                dtgv_CTHD.DataSource = daCTHD.loadXemCTHoaDon(maHD);
            }
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            string maNV = daNV.traVeMaNhanVien(Program.tenDangNhap);
            if(dtgv_HoaDon.CurrentRow != null)
            {
                int maHD = int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString());
                if(daHD.capNhatNhanVien(maHD,maNV))
                {
                    loadDataGridView();
                    MessageBox.Show("Xác nhận giao hàng thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xác nhận giao hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                if (dtgv_HoaDon.CurrentRow != null)
                {
                    int maHD = int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString());
                    if(daHD.huyHoaDonOnline(maHD))
                    {
                        loadDataGridView();
                        MessageBox.Show("Hủy hóa đơn online thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Hủy hóa đơn online thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
    }
}
