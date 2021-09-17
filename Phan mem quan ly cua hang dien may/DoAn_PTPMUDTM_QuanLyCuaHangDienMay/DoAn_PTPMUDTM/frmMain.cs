
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
    public partial class frmMain : Form
    {
        BLLDALPhanQuyen daPQ = new BLLDALPhanQuyen();
        BLLDALNhanVien daNV = new BLLDALNhanVien();

        string tenDangNhap;

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaoTaiKhoan frm = new frmTaoTaiKhoan();
            this.Visible = false;
            frm.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm  = new frmDoiMatKhau();
            this.Visible = false;
            frm.Show();
        }

        private void điểmDanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiemDanh frm = new frmDiemDanh();
            this.Visible = false;
            frm.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cấpQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
            this.Visible = false;
            frm.Show();
        }

        private void chứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChucVu frm = new frmChucVu();
            this.Visible = false;
            frm.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            this.Visible = false;
            frm.Show();
        }

        private void loạiNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiKhachHang frm = new frmLoaiKhachHang();
            this.Visible = false;
            frm.Show();

        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaSanXuat frm = new frmNhaSanXuat();
            this.Visible = false;
            frm.Show();
        }

        private void loạithiếtbịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiThietBi frm = new frmLoaiThietBi();
            this.Visible = false;
            frm.Show();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            this.Visible = false;
            frm.Show();
        }

        private void hoáĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKePhieuNhap frm = new frmThongKePhieuNhap();
            this.Visible = false;
            frm.Show();
        }

        private void theoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu frm = new frmThongKeDoanhThu();
            this.Visible = false;
            frm.Show();
        }

        private void lươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTinhLuongNhanVien frm = new frmTinhLuongNhanVien();
            this.Visible = false;
            frm.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.frmDangNhap.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<MaNhomNguoiDung> nhomND = daPQ.getMaNhomNguoiDung(TenDangNhap);
            foreach (MaNhomNguoiDung item in nhomND)
            {
                List<DanhSachManHinh> dsQuyen = daPQ.getMaManHinh(item.MaNhom);
                for (int i = 0; i < dsQuyen.Count; i++)
                {
                    FindMenuPhanQuyen(this.menuStrip1.Items, dsQuyen[i].MaManHinh, Convert.ToBoolean(dsQuyen[i].CoQuyen.ToString()));
                }

            }

            Program.frmMain.Text = "Xin chào " + daNV.traVeNhanVienDiemDanh(Program.tenDangNhap) + " !";
        }

        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItems, string PScreenName, bool pEnable)
        {

            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {
                    FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems, PScreenName, pEnable);
                    menu.Enabled = CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
                    menu.Visible = menu.Enabled;
                }
                else if (string.Equals(PScreenName, menu.Tag))
                {
                    menu.Enabled = pEnable;
                    menu.Visible = pEnable;
                }
            }
        }

        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem && menuItem.Enabled)
                {
                    return true;

                }
                else if (menuItem is ToolStripSeparator)
                {
                    continue;
                }
            }
            return false;
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            frmThongTin frm = new frmThongTin();
            this.Visible = false;
            frm.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            this.Visible = false;
            frm.Show();
        }

        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThanhToan frm = new frmThanhToan();
            this.Visible = false;
            frm.Show();
        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapHang frm = new frmNhapHang();
            this.Visible = false;
            frm.Show();
        }

        private void bảoHànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoHanh frm = new frmBaoHanh();
            this.Visible = false;
            frm.Show();
        }

        private void xemHóaĐơnphiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXemHoaDon frm = new frmXemHoaDon();
            this.Visible = false;
            frm.Show();
        }

        private void tưVấnKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuVanSanPham frm = new frmTuVanSanPham();
            this.Visible = false;
            frm.Show();
        }

        private void xácNhậnHóaĐơnOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXacNhanHoaDonOnline frm = new frmXacNhanHoaDonOnline();
            this.Visible = false;
            frm.Show();
        }
    }
}
