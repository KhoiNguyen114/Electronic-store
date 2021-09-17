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
    public partial class frmDiemDanh : Form
    {
        BLLDALNhanVien daNV = new BLLDALNhanVien();
        BLLDALDiemDanh daDD = new BLLDALDiemDanh();
        public frmDiemDanh()
        {
            InitializeComponent();
        }

        private void frmDiemDanh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void btnDiemDanh_Click(object sender, EventArgs e)
        {
            DateTime ngayDD = DateTime.Now;
            //DateTime a = ngayDD.AddMonths(24);
            //int r1 = DateTime.Compare(a, ngayDD);
            //MessageBox.Show(r1 + "");
            string maNV = daNV.traVeMaNhanVien(Program.tenDangNhap);
            if (!daDD.ktKhoaChinh(maNV, ngayDD))
            {
                MessageBox.Show("Bạn đã điểm danh hôm nay rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (daDD.themDiemDanh(maNV, ngayDD))
            {
                MessageBox.Show("Điểm danh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("Điểm danh thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmDiemDanh_Load(object sender, EventArgs e)
        {
            dtpNgayDD.CustomFormat = "dd/MM/yyyy";
            txtTenNV.Text = daNV.traVeNhanVienDiemDanh(Program.tenDangNhap);
        }
    }
}
