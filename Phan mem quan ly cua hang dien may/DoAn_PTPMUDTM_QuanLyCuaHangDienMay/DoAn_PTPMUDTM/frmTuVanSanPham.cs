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
    public partial class frmTuVanSanPham : Form
    {
        BLLDALLoaiThietBi daLTB = new BLLDALLoaiThietBi();
        BLLDALThuatToan daTT = new BLLDALThuatToan();
        BLLDALSanPham daSP = new BLLDALSanPham();
        List<DuLieu> dsDuLieu = new List<DuLieu>();

        public frmTuVanSanPham()
        {
            InitializeComponent();
        }

        private void frmTuVanSanPham_Load(object sender, EventArgs e)
        {
            dsDuLieu = daTT.docFile();


            cboLoaiThietBi.DataSource = daLTB.loadLoaiThietBi();
            cboLoaiThietBi.DisplayMember = "TENTHIETBI";
            cboLoaiThietBi.ValueMember = "TENTHIETBI";

            
        }

        public string traVeTextCheckPanel(Panel pn)
        {
            string kq = "";
            for (int i = 0; i < pn.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)pn.Controls[i];
                if (rb.Checked)
                {
                    return rb.Text;
                }
            }
            return kq;
        }

        public bool ktCheckPanel(Panel pn)
        {
            for (int i = 0; i < pn.Controls.Count; i++)
            {
                RadioButton rb = (RadioButton)pn.Controls[i];
                if (rb.Checked)
                {
                    return true;
                }
            }
            return false;
        }

        public void loadControlDacDiem1(string pName ,Panel pn, int pDD)
        {
            pn.Controls.Clear();
            List<DuLieu> dsCacDacDiem = daTT.getDuLieu(pName, dsDuLieu);
            List<string> dsDD1 = daTT.getDacDiem1(pName, dsCacDacDiem, pDD);
            for(int i=0; i<dsDD1.Count; i++)
            {
                RadioButton rd = new RadioButton();
                rd.Size = new Size(200, 25);
                rd.Top = 20;
                rd.Left = 200 * i;
                rd.Padding = new Padding(20, 0, 0, 0);
                rd.Text = dsDD1[i];
                rd.Name = "rdo " + i;
                rd.CheckedChanged += Rd_CheckedChanged;
                pn.Controls.Add(rd);
            }
        }

        private void Rd_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void frmTuVanSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.frmMain.Show();
        }

        private void cboLoaiThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cboLoaiThietBi.SelectedValue.ToString();
            List<TieuChi> ds = daTT.docFileTieuChi();
            TieuChi a = ds.Where(t => t.TenThietBi == name).SingleOrDefault();
            if(a != null)
            {
                lblDD1.Text = a.TieuChi1;
                lblDD2.Text = a.TieuChi2;
                lblDD3.Text = a.TieuChi3;
                lblDD4.Text = a.TieuChi4;
            }

            loadControlDacDiem1(name, pnDD1, 1);
            loadControlDacDiem1(name, pnDD2, 2);
            loadControlDacDiem1(name, pnDD3, 3);
            loadControlDacDiem1(name, pnDD4, 4);
        }

        private void btnTuVan_Click(object sender, EventArgs e)
        {
            string name = cboLoaiThietBi.SelectedValue.ToString();
            if (!ktCheckPanel(pnDD1) || !ktCheckPanel(pnDD2) || !ktCheckPanel(pnDD3) || !ktCheckPanel(pnDD4))
            {
                MessageBox.Show("Vui lòng chọn đủ tất cả các điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dd1 = traVeTextCheckPanel(pnDD1);
            string dd2 = traVeTextCheckPanel(pnDD2);
            string dd3 = traVeTextCheckPanel(pnDD3);
            string dd4 = traVeTextCheckPanel(pnDD4);

            List<DuLieu> dsSanPhamTuVan = daTT.getDuLieu(name, dsDuLieu);
            List<string> dsDD1 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 1);
            List<string> dsDD2 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 2);
            List<string> dsDD3 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 3);
            List<string> dsDD4 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 4);
            List<string> dsDD5 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 5);
            List<string> dsPhanLop = daTT.getDacDiem1(name, dsSanPhamTuVan, 5);

            List<string> numDD1 = daTT.getDacDiem1(name, dsSanPhamTuVan, 1);
            List<string> numDD2 = daTT.getDacDiem1(name, dsSanPhamTuVan, 2);
            List<string> numDD3 = daTT.getDacDiem1(name, dsSanPhamTuVan, 3);
            List<string> numDD4 = daTT.getDacDiem1(name, dsSanPhamTuVan, 4);

            //daTT.thucThiBayesTuLam(dd1, dd2, dd3, dd4, dsDD1, dsDD2, 
            //    dsDD3, dsDD4, dsDD5, dsPhanLop, dsPhanLop.Count, dsSanPhamTuVan.Count);



            List<DuLieuTrain> dsTrain = daTT.docFileTrain();
            List<DuLieuTrain> dsLocTrain = new List<DuLieuTrain>();
            for (int i = 0; i < dsTrain.Count; i++)
            {
                if (dsTrain[i].DacDiem1.Trim() == dd1 && dsTrain[i].DacDiem2.Trim() == dd2 &&
                    dsTrain[i].DacDiem3.Trim() == dd3 && dsTrain[i].DacDiem4.Trim() == dd4)
                {
                    dsLocTrain.Add(dsTrain[i]);
                }
            }

            string kq = dsLocTrain[0].MaSP.Trim();
            double max = dsLocTrain[0].XacSuat;
            for (int i = 0; i < dsLocTrain.Count; i++)
            {
                if (max < dsLocTrain[i].XacSuat)
                {
                    max = dsLocTrain[i].XacSuat;
                    kq = dsLocTrain[i].MaSP.Trim();
                }
            }

            txtKetQua.Text = daSP.traVeTenSanPham(kq);
            lblDonGia.Text = string.Format("{0:0,0 VNĐ}", daSP.traVeDonGiaBan(kq));
            double? giamGia = daSP.traVeGiamGia(kq);
            if (giamGia == null)
            {
                lblGiamGia.Text = 0 + "";
            }
            else
            {
                lblGiamGia.Text = string.Format("{0:0,0 VNĐ}", giamGia);
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            List<LOAITHIETBI> ds = daLTB.loadLoaiThietBiList();
            for(int d = 0; d < ds.Count; d++)
            {
                string name = ds[d].TENTHIETBI;
                List<DuLieu> dsSanPhamTuVan = daTT.getDuLieu(name, dsDuLieu);
                List<string> dsDD1 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 1);
                List<string> dsDD2 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 2);
                List<string> dsDD3 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 3);
                List<string> dsDD4 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 4);
                List<string> dsDD5 = daTT.layToanBoDong1DD(name, dsSanPhamTuVan, 5);
                List<string> dsPhanLop = daTT.getDacDiem1(name, dsSanPhamTuVan, 5);
                List<string> dsVongLap1 = daTT.getDacDiem1(name, dsSanPhamTuVan, 1);
                List<string> dsVongLap2 = daTT.getDacDiem1(name, dsSanPhamTuVan, 2);
                List<string> dsVongLap3 = daTT.getDacDiem1(name, dsSanPhamTuVan, 3);
                List<string> dsVongLap4 = daTT.getDacDiem1(name, dsSanPhamTuVan, 4);
                for (int i = 0; i < dsVongLap1.Count; i++)
                {
                    for (int j = 0; j < dsVongLap2.Count; j++)
                    {
                        for (int k = 0; k < dsVongLap3.Count; k++)
                        {
                            for (int h = 0; h < dsVongLap4.Count; h++)
                            {
                                string dd1 = dsVongLap1[i];
                                string dd2 = dsVongLap2[j];
                                string dd3 = dsVongLap3[k];
                                string dd4 = dsVongLap4[h];
                                //RadioButton rb1 = (RadioButton)pnDD1.Controls[i];
                                //RadioButton rb2 = (RadioButton)pnDD2.Controls[j];
                                //RadioButton rb3 = (RadioButton)pnDD3.Controls[k];
                                //RadioButton rb4 = (RadioButton)pnDD4.Controls[h];
                                daTT.thucThiBayesTuLam(dd1, dd2, dd3, dd4, dsDD1, dsDD2,
                                    dsDD3, dsDD4, dsDD5, dsPhanLop, dsPhanLop.Count, dsSanPhamTuVan.Count);
                            }
                        }
                    }
                }
            }
            
        }
    }
}
