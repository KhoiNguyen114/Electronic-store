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
    public partial class frmThongKePhieuNhap : Form
    {
        BLLDALThongKe daTK = new BLLDALThongKe();

        public frmThongKePhieuNhap()
        {
            InitializeComponent();
        }

        private void frmThongKePhieuNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void frmThongKePhieuNhap_Load(object sender, EventArgs e)
        {
            dtgv_ThongKe.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

            lblNgay.Visible = false;
            lblThang.Visible = false;
            lblNam.Visible = false;
            cboNgay.Visible = false;
            cboThang.Visible = false;
            cboNam.Visible = false;

            cboNam.DataSource = daTK.loadDuLieu(2000, 2030);
            cboThang.DataSource = daTK.loadDuLieu(1, 12);
        }

        private void rdoNgay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNgay.Checked)
            {
                lblNgay.Visible = true;
                lblThang.Visible = true;
                lblNam.Visible = true;
                cboNgay.Visible = true;
                cboThang.Visible = true;
                cboNam.Visible = true;
                cboNgay.Enabled = false;
                cboThang.Enabled = false;
            }
            else
            {
                lblNgay.Visible = false;
                lblThang.Visible = false;
                lblNam.Visible = false;
                cboNgay.Visible = false;
                cboThang.Visible = false;
                cboNam.Visible = false;
            }
        }

        private void rdoThang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoThang.Checked)
            {
                lblThang.Visible = true;
                lblNam.Visible = true;
                cboThang.Visible = true;
                cboNam.Visible = true;
                cboThang.Enabled = false;
            }
            else
            {
                lblThang.Visible = false;
                lblNam.Visible = false;
                cboThang.Visible = false;
                cboNam.Visible = false;
            }
        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoNam.Checked)
            {
                lblNam.Visible = true;
                cboNam.Visible = true;
            }
            else
            {
                lblNam.Visible = false;
                cboNam.Visible = false;
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboThang.Enabled = true;
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboNgay.Enabled = true;
                int thang = int.Parse(cboThang.SelectedValue.ToString());
                int nam = int.Parse(cboNam.SelectedValue.ToString());
                switch (thang)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        cboNgay.DataSource = daTK.loadDuLieu(1, 31);
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        cboNgay.DataSource = daTK.loadDuLieu(1, 30);
                        break;
                    case 2:
                        cboNgay.DataSource = daTK.loadThang2(nam);
                        break;
                }
            }
            catch
            {

            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            int ngay, thang, nam;

            if (rdoNgay.Checked)
            {
                try
                {
                    ngay = int.Parse(cboNgay.SelectedValue.ToString());
                    thang = int.Parse(cboThang.SelectedValue.ToString());
                    nam = int.Parse(cboNam.SelectedValue.ToString());
                    bool kq = daTK.kiemTraNgayThangHopLe(ngay, thang, nam);
                    if (!kq)
                    {
                        MessageBox.Show("Ngày tháng năm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dtgv_ThongKe.DataSource = daTK.thongKePhieuNhap(ngay, thang, nam);
                    string a = String.Format("{0:0,00}", daTK.tongTienPhieuNhap(ngay, thang, nam));
                    lblTongTien.Text = a;
                }
                catch
                {
                    MessageBox.Show("VUi lòng chọn ngày, tháng, năm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (rdoThang.Checked)
            {
                try
                {
                    thang = int.Parse(cboThang.SelectedValue.ToString());
                    nam = int.Parse(cboNam.SelectedValue.ToString());
                    dtgv_ThongKe.DataSource = daTK.thongKePhieuNhap(thang, nam);
                    string a = String.Format("{0:0,00}", daTK.tongTienPhieuNhap(thang, nam));
                    lblTongTien.Text = a;
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn tháng, năm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                nam = int.Parse(cboNam.SelectedValue.ToString());
                dtgv_ThongKe.DataSource = daTK.thongKePhieuNhap(nam);
                string a = String.Format("{0:0,00}", daTK.tongTienPhieuNhap(nam));
                lblTongTien.Text = a;
            }
        }
    }
}
