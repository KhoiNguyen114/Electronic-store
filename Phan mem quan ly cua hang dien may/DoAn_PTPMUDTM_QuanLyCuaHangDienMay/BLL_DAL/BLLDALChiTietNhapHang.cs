using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALChiTietNhapHang
    {

        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALChiTietNhapHang()
        {

        }

        public IQueryable loadXemCTNhapHang()
        {
            IQueryable ds = from k in quanLy.CHITIETPHIEUNHAPs
                            join sp in quanLy.SANPHAMs on k.MASP equals sp.MASP
                            select new
                            {
                                k.MAPN,
                                sp.TENSP,
                                k.SOLUONG,
                                k.DONGIANHAP,
                                k.THANHTIEN,
                            };
            return ds;
        }

        public IQueryable loadXemCTNhapHang(int pMaPN)
        {
            IQueryable ds = from k in quanLy.CHITIETPHIEUNHAPs
                            join sp in quanLy.SANPHAMs on k.MASP equals sp.MASP
                            where k.MAPN == pMaPN
                            select new
                            {
                                k.MAPN,
                                sp.TENSP,
                                k.SOLUONG,
                                k.DONGIANHAP,
                                k.THANHTIEN,
                            };
            return ds;
        }

        public bool ktKhoaChinh(int pMaHD, string pMaSP, List<ChiTietPhieuNhap> ds)
        {
            ChiTietPhieuNhap cthd = ds.Where(t => t.MaPN == pMaHD && t.MaSP == pMaSP).SingleOrDefault();
            if (cthd == null)
            {
                return true;
            }
            return false;
        }

        public bool themCTPN(int pMaPN, string pMaSP, int pSoLuong, double pDonGia, double pThanhTien, List<ChiTietPhieuNhap> ds)
        {
            try
            {
                ChiTietPhieuNhap cthd = new ChiTietPhieuNhap();
                cthd.MaPN = pMaPN;
                cthd.MaSP = pMaSP;
                cthd.SoLuong = pSoLuong;
                cthd.DonGia = pDonGia;
                cthd.ThanhTien = pThanhTien;
                ds.Add(cthd);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaCTPN(int pMaPN, string pMaSP, int pSoLuong, double pDonGia, double pThanhTien, List<ChiTietPhieuNhap> ds)
        {
            try
            {
                ChiTietPhieuNhap cthd = ds.Where(t => t.MaPN == pMaPN && t.MaSP == pMaSP).SingleOrDefault();
                if (cthd == null)
                {
                    return false;
                }
                cthd.SoLuong = pSoLuong;
                cthd.DonGia = pDonGia;
                cthd.ThanhTien = pThanhTien;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaCTPN(int pMaPN, string pMaSP, List<ChiTietPhieuNhap> ds)
        {
            try
            {
                ChiTietPhieuNhap cthd = ds.Where(t => t.MaPN == pMaPN && t.MaSP == pMaSP).SingleOrDefault();
                if (cthd == null)
                {
                    return false;
                }

                ds.Remove(cthd);
                return true;
            }
            catch
            {
                return false;
            }
        }



    }

    public class ChiTietPhieuNhap
    {
        int? maPN, soLuong;
        string maSP;
        double? donGia, thanhTien;

        public int? MaPN { get => maPN; set => maPN = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int? SoLuong { get => soLuong; set => soLuong = value; }
        public double? DonGia { get => donGia; set => donGia = value; }
        public double? ThanhTien { get => thanhTien; set => thanhTien = value; }

    }
}
