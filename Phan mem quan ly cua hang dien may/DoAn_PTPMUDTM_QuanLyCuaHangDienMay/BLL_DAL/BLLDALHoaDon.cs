using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALHoaDon
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALHoaDon ()
        {

        }

        public IQueryable loadHoaDonTheoKhachHang(int pMaKH)
        {
            IQueryable ds = from k in quanLy.HOADONs where k.MAKH == pMaKH select new { k.MAHD, k.MAKH, k.MANV, k.NGAYLAPHD };
            return ds;
        }

        public IQueryable loadXemHoaDon()
        {
            IQueryable ds = from k in quanLy.HOADONs
                            join nv in quanLy.NHANVIENs on k.MANV equals nv.MANV
                            join kh in quanLy.KHACHHANGs on k.MAKH equals kh.MAKH
                            select new
                            {
                                k.MAHD,
                                nv.TENNV,
                                kh.TENKH,
                                k.NGAYLAPHD,
                                k.TONGTIENHD,
                                k.THANHTOAN,
                                k.TINHTRANG
                            };
            return ds;
        }

        public IQueryable loadXemHoaDonOnline()
        {
            IQueryable ds = from k in quanLy.HOADONs
                            join kh in quanLy.KHACHHANGs on k.MAKH equals kh.MAKH
                            where k.TINHTRANG == "Chờ xác nhận"
                            select new
                            {
                                k.MAHD,
                                kh.TENKH,
                                k.NGAYLAPHD,
                                k.TONGTIENHD,
                                k.THANHTOAN,
                                k.TINHTRANG
                            };
            return ds;
        }

        public bool themHoaDon(string pMaNV, int pMaKH)
        {
            try
            {
                HOADON hd = new HOADON();
                hd.MANV = pMaNV;
                hd.MAKH = pMaKH;
                hd.NGAYLAPHD = DateTime.Now;
                hd.TINHTRANG = "Có hiệu lực";

                quanLy.HOADONs.InsertOnSubmit(hd);
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool capNhatNhanVien(int pMaHD, string pMaNV)
        {
            try
            {
                HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
                hd.MANV = pMaNV;
                hd.TINHTRANG = "Có hiệu lực";

                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int traVeMaHoaDon()
        {
            try
            {
                var ds = from k in quanLy.HOADONs orderby k.MAHD descending select k;
                if (ds == null)
                    return -1;
                HOADON hd = ds.First();
                return hd.MAHD;
            }
            catch
            {
                return -1;
            }
        }

        public DateTime? traVeNgayLapHD(int pMaHD)
        {
            try
            {
                HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
                if (hd == null)
                {
                    return null;
                }
                return hd.NGAYLAPHD;
            }
            catch
            {
                return null;
            }
        }

        public bool huyHoaDon(int pMaHD)
        {
            try
            {
                HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
                if (hd == null)
                    return false;
                hd.TINHTRANG = "Hủy";
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool huyHoaDonOnline(int pMaHD)
        {
            try
            {
                HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
                if (hd == null)
                    return false;
                hd.TINHTRANG = "Hủy";
                quanLy.SubmitChanges();
                List<CHITIETHOADON> ds = quanLy.CHITIETHOADONs.Where(t => t.MAHD == pMaHD).ToList();
                for (int i = 0; i < ds.Count; i++)
                {
                    string ma = ds[i].MASP;
                    SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == ma).SingleOrDefault();
                    sp.SOLUONG += ds[i].SOLUONG;
                    quanLy.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xacNhanThanhToan(int pMaHD, List<ChiTietHoaDon> ds)
        {
            try
            {
                HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
                if(hd == null)
                {
                    return false;
                }
                KHACHHANG kh = quanLy.KHACHHANGs.Where(t => t.MAKH == hd.MAKH).SingleOrDefault();
                if (kh == null)
                {
                    return false;
                }
                LOAIKHACHHANG lkh = quanLy.LOAIKHACHHANGs.Where(t => t.MALOAIKH == kh.MALOAIKH).SingleOrDefault();
                if (lkh == null)
                {
                    return false;
                }
                double giamGia = (double) lkh.GIAMGIA / 100;
                double? tongTien = ds.Sum(t => t.ThanhTien);
                double? temp = tongTien * giamGia;
                double? thanhToan = tongTien - temp;
                hd.TONGTIENHD = tongTien;
                hd.THANHTOAN = thanhToan;

                quanLy.SubmitChanges();
                for(int i=0; i<ds.Count; i++)
                {
                    CHITIETHOADON cthd = new CHITIETHOADON();
                    cthd.MAHD = hd.MAHD;
                    cthd.MASP = ds[i].MaSP;
                    cthd.SOLUONG = ds[i].SoLuong;
                    cthd.DONGIABAN = ds[i].DonGia;
                    cthd.THANHTIEN = ds[i].ThanhTien;

                    quanLy.CHITIETHOADONs.InsertOnSubmit(cthd);
                    quanLy.SubmitChanges();
                }
                ds.Clear();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void capNhatSauKhiThanhToan(int pMaHD)
        {
            List<CHITIETHOADON> ds = quanLy.CHITIETHOADONs.Where(t => t.MAHD == pMaHD).ToList();
            for(int i=0; i<ds.Count; i++)
            {
                string ma = ds[i].MASP;
                SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == ma).SingleOrDefault();
                sp.SOLUONG -= ds[i].SOLUONG;
                quanLy.SubmitChanges();
            }
        }
    }
}
