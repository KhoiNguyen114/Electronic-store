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
    public partial class frmXemHoaDon : Form
    {
        BLLDALHoaDon daHD = new BLLDALHoaDon();
        BLLDALChiTietHoaDon daCTHD = new BLLDALChiTietHoaDon();
        BLLDALNhapHang daPN = new BLLDALNhapHang();
        BLLDALChiTietNhapHang daCTPN = new BLLDALChiTietNhapHang();
        BLLDALReportHoaDon daRPHD = new BLLDALReportHoaDon();
        BLLDALReportPhieuNhap daRPPN = new BLLDALReportPhieuNhap();

        public frmXemHoaDon()
        {
            InitializeComponent();
        }

        private void frmXemHoaDon_Load(object sender, EventArgs e)
        {
            dtgv_HoaDon.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgv_HoaDon.DataSource = daHD.loadXemHoaDon();
            dtgv_CTHD.DataSource = daCTHD.loadXemCTHoaDon();

            dtgv_PhieuNhap.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgv_PhieuNhap.DataSource = daPN.loadXemPhieuNhap();
            dtgv_CTPN.DataSource = daCTPN.loadXemCTNhapHang();
        }

        private void dtgv_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgv_HoaDon.CurrentRow != null)
            {
                int maHD = int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString());
                dtgv_CTHD.DataSource = daCTHD.loadXemCTHoaDon(maHD);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dtgv_HoaDon.CurrentRow != null)
            {
                int maHD = int.Parse(dtgv_HoaDon.CurrentRow.Cells[0].Value.ToString());
                ReportHoaDon rpt = new ReportHoaDon();
                rpt.lblNgayLap.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(daRPHD.traVeNgayLap(maHD).ToString()));
                rpt.lblTongTien.Text = string.Format("{0:0,0} VNĐ", daRPHD.traVeTongTien(maHD));
                rpt.lblThanhToan.Text = string.Format("{0:0,0} VNĐ", daRPHD.traVeThanhToan(maHD));
                rpt.DataSource = daRPHD.xuatHoaDon(maHD);
                rpt.ShowPreviewDialog();
            }
            
        }

        private void dtgv_PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgv_PhieuNhap.CurrentRow != null)
            {
                int maPN = int.Parse(dtgv_PhieuNhap.CurrentRow.Cells[0].Value.ToString());
                dtgv_CTPN.DataSource = daCTPN.loadXemCTNhapHang(maPN);
            }
        }

        private void btnInPhieuNhap_Click(object sender, EventArgs e)
        {
            if (dtgv_PhieuNhap.CurrentRow != null)
            {
                int maPN = int.Parse(dtgv_PhieuNhap.CurrentRow.Cells[0].Value.ToString());
                ReportPhieuNhap rpt = new ReportPhieuNhap();
                rpt.lblNgayLap.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(daRPPN.traVeNgayLap(maPN).ToString()));
                rpt.lblTongTien.Text = string.Format("{0:0,0} VNĐ", daRPPN.traVeTongTien(maPN));
                rpt.DataSource = daRPPN.xuatPhieuNhap(maPN);
                rpt.ShowPreviewDialog();
            }
        }

        private void frmXemHoaDon_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }
    }
}
