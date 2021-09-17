using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLL_DAL
{
    public class BLLDALSanPham
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALSanPham()
        {

        }

        public Image LoadHinh(string duongDan)
        {
            return Image.FromFile(duongDan);
        }

        public IQueryable loadSanPham()
        {
            quanLy.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, quanLy.SANPHAMs);
            IQueryable ds = from sp in quanLy.SANPHAMs select new { sp.MASP, sp.TENSP, sp.DONGIABAN, sp.MOTA, sp.SOLUONG, sp.HINH, sp.GIAMGIA, sp.MANSX, sp.MATHIETBI, sp.TINHTRANG, sp.THOIGIANBH };
            return ds;
        }

        public List<SANPHAM> loadSanPhamCombobox()
        {
            quanLy.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, quanLy.SANPHAMs);
            var ds = new List<SANPHAM>();
            ds = (from sp in quanLy.SANPHAMs select sp).ToList();
            return ds;
        }

        public IQueryable loadDanhSachSanPhamTheoTimKiem(string ptenSanPham)
        {
            IQueryable ds = from sp in quanLy.SANPHAMs where sp.TENSP.Contains(ptenSanPham) || sp.MASP.Contains(ptenSanPham) select new { sp.MASP, sp.TENSP, sp.DONGIABAN, sp.MOTA, sp.SOLUONG, sp.HINH, sp.GIAMGIA, sp.MANSX, sp.MATHIETBI, sp.TINHTRANG, sp.THOIGIANBH };
            return ds;
        }

        public IQueryable loadDanhSachSanPhamTheoHoaDon(int pMaHD)
        {
            IQueryable ds = from sp in quanLy.SANPHAMs 
                            join cthd in quanLy.CHITIETHOADONs on sp.MASP equals cthd.MASP
                            join hd in quanLy.HOADONs on cthd.MAHD equals hd.MAHD
                            where hd.MAHD == pMaHD
                            select new 
                            { 
                                sp.MASP, 
                                sp.TENSP, 
                                sp.DONGIABAN, 
                                sp.MOTA,
                                sp.SOLUONG, 
                                sp.GIAMGIA, 
                                sp.MANSX, 
                                sp.MATHIETBI, 
                                sp.TINHTRANG,
                                sp.THOIGIANBH 
                            };
            return ds;
        }

        public bool ktKhoaChinh(string MaSP)
        {
            SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == MaSP).SingleOrDefault();
            if (sp == null)
                return true;
            return false;
        }


        public string traVeTenSanPham(string pMaSP)
        {
            try
            {
                SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
                if (sp == null)
                    return null;
                return sp.TENSP;
            }
            catch
            {
                return null;
            }
        }

        public int? traVeSoLuong(string pMaSP)
        {
            try
            {
                SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
                if (sp == null)
                    return null;
                return sp.SOLUONG;
            }
            catch
            {
                return null;
            }
        }

        public double? traVeDonGiaBan(string pMaSP)
        {
            SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
            if (sp == null)
                return -1;
            return sp.DONGIABAN;
        }

        public double? traVeGiamGia(string pMaSP)
        {
            SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
            if (sp == null)
                return -1;
            return sp.GIAMGIA;
        }

        public int? traVeThoiGianBH(string pMaSP)
        {
            SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
            if (sp == null)
                return -1;
            return sp.THOIGIANBH;
        }

        /*public double? traVeDonGiaNhap(string pMaSP)
        {
            SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == pMaSP).SingleOrDefault();
            if (sp == null)
                return -1;
            return sp.DONGIANHAP;
        }*/

        public void capNhatTinhTrang()
        {
            quanLy.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, quanLy.SANPHAMs);
            List<SANPHAM> dssp = quanLy.SANPHAMs.ToList();
            foreach (SANPHAM sp in dssp)
            {
                if (sp.SOLUONG == 0)
                {
                    sp.TINHTRANG = "Hết hàng";
                    quanLy.SubmitChanges();
                }
                else
                {
                    sp.TINHTRANG = "Còn";
                    quanLy.SubmitChanges();
                }
            }
        }

        

        /*//Khi cập nhật thì trên list là 400, textbox là 495 thì sẽ tính ra hiệu số là 95
        public int? traVeHieuSoSPKhiCapNhat(string pMaSP, int pMaDat, int pSoLuong, List<DichVuDatPhong> ds)
        {
            int? soLuong = 0;
            int a = pSoLuong;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaSP == pMaSP && ds[i].MaDat == pMaDat)
                {
                    soLuong += ds[i].SoLuong;
                }
            }
            return a - soLuong;
        }*/

        public bool themSP(string maSP, string TenSP, int soluong, double giaban, string maThietBi, string maNSX, double giamGia, string moTa, int thoiGianBH, string hinh)
        {
            try
            {
                SANPHAM sp = new SANPHAM();
                sp.MASP = maSP;
                sp.TENSP = TenSP;
                sp.SOLUONG = soluong;
                sp.DONGIABAN = giaban;
                sp.MATHIETBI = maThietBi;
                sp.MANSX = maNSX;
                sp.HINH = hinh;
                if (giamGia == 0)
                {
                    sp.GIAMGIA = null;
                }
                else
                {
                    sp.GIAMGIA = giamGia;
                }
                sp.MOTA = moTa;
                sp.THOIGIANBH = thoiGianBH;

                if (soluong > 0)
                {
                    sp.TINHTRANG = "Còn";
                }
                else
                {
                    sp.TINHTRANG = "Hết hàng";
                }
                quanLy.SANPHAMs.InsertOnSubmit(sp);
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaSP(string MaSP, string TenSP, int soluong, double giaban, string maThietBi, string maNSX, double giamGia, string moTa, int thoiGianBH, string hinh)
        {
            try
            {
                SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == MaSP).SingleOrDefault();
                if (sp == null)
                    return false;

                sp.TENSP = TenSP;
                sp.SOLUONG = soluong;
                sp.DONGIABAN = giaban;
                sp.MATHIETBI = maThietBi;
                sp.MANSX = maNSX;
                sp.HINH = hinh;
                if (giamGia == 0)
                {
                    sp.GIAMGIA = null;
                }
                else
                {
                    sp.GIAMGIA = giamGia;
                }
                sp.MOTA = moTa;
                sp.THOIGIANBH = thoiGianBH;

                if (soluong > 0)
                {
                    sp.TINHTRANG = "Còn";
                }
                else
                {
                    sp.TINHTRANG = "Hết hàng";
                }

                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaSP(string MaSP)
        {
            try
            {
                SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == MaSP).SingleOrDefault();
                if (sp == null)
                    return false;

                var cthd = quanLy.CHITIETHOADONs.Where(t => t.MASP == MaSP).ToList();
                List<int> ds = new List<int>();
                for(int i=0; i<cthd.Count; i++)
                {
                    ds.Add(cthd[i].MAHD);
                }               

                var ctpn = quanLy.CHITIETPHIEUNHAPs.Where(t => t.MASP == MaSP).ToList();
                List<int> dsCTPN = new List<int>();
                for (int i = 0; i < ctpn.Count; i++)
                {
                    ds.Add(ctpn[i].MAPN);
                }              

                var bh = quanLy.BAOHANHs.Where(t => t.MASP == MaSP).ToList();
               
                quanLy.BAOHANHs.DeleteAllOnSubmit(bh);
                quanLy.CHITIETHOADONs.DeleteAllOnSubmit(cthd);
                quanLy.CHITIETPHIEUNHAPs.DeleteAllOnSubmit(ctpn);
                quanLy.SANPHAMs.DeleteOnSubmit(sp);
                quanLy.SubmitChanges();

                quanLy.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, quanLy.CHITIETHOADONs);
                quanLy.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, quanLy.CHITIETPHIEUNHAPs);

                for (int i = 0; i < ds.Count; i++)
                {
                    HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == ds[i]).SingleOrDefault();
                    KHACHHANG kh = quanLy.KHACHHANGs.Where(t => t.MAKH == hd.MAKH).SingleOrDefault();
                    LOAIKHACHHANG lkh = quanLy.LOAIKHACHHANGs.Where(t => t.MALOAIKH == kh.MALOAIKH).SingleOrDefault();
                    List<CHITIETHOADON> dscthd = quanLy.CHITIETHOADONs.Where(t => t.MAHD == hd.MAHD).ToList();
                    double? tongTien = dscthd.Sum(t => t.THANHTIEN);
                    double giamGia = (double)lkh.GIAMGIA / 100;
                    double? temp = tongTien * giamGia;
                    double? thanhToan = tongTien - temp;
                    hd.TONGTIENHD = tongTien;
                    hd.THANHTOAN = thanhToan;

                    quanLy.SubmitChanges();
                }

                for (int i = 0; i < dsCTPN.Count; i++)
                {
                    PHIEUNHAP pn = quanLy.PHIEUNHAPs.Where(t => t.MAPN == dsCTPN[i]).SingleOrDefault();
                    List<CHITIETPHIEUNHAP> dscthd = quanLy.CHITIETPHIEUNHAPs.Where(t => t.MAPN == pn.MAPN).ToList();
                    double? tongTien = dscthd.Sum(t => t.THANHTIEN);
                    pn.TONGTIENPN = tongTien;

                    quanLy.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
