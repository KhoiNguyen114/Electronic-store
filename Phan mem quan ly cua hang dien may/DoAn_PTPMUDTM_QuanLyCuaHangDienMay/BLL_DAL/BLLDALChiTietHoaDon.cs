using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALChiTietHoaDon
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALChiTietHoaDon()
        {

        }

        public IQueryable loadXemCTHoaDon()
        {
            IQueryable ds = from k in quanLy.CHITIETHOADONs
                            join sp in quanLy.SANPHAMs on k.MASP equals sp.MASP
                            select new
                            {
                                k.MAHD,
                                sp.TENSP,
                                k.SOLUONG,
                                k.DONGIABAN,
                                k.THANHTIEN,
                            };
            return ds;
        }

        public IQueryable loadXemCTHoaDon(int pMaHD)
        {
            IQueryable ds = from k in quanLy.CHITIETHOADONs
                            join sp in quanLy.SANPHAMs on k.MASP equals sp.MASP
                            where k.MAHD == pMaHD
                            select new
                            {
                                k.MAHD,
                                sp.TENSP,
                                k.SOLUONG,
                                k.DONGIABAN,
                                k.THANHTIEN,
                            };
            return ds;
        }

        public bool ktKhoaChinh(int pMaHD, string pMaSP, List<ChiTietHoaDon> ds)
        {
            ChiTietHoaDon cthd = ds.Where(t => t.MaHD == pMaHD && t.MaSP == pMaSP).SingleOrDefault();
            if (cthd == null)
            {
                return true;
            }
            return false;
        }

        public bool ktKhoaChinh(int pMaHD, string pMaSP)
        {
            CHITIETHOADON cthd = quanLy.CHITIETHOADONs.Where(t => t.MAHD == pMaHD && t.MASP == pMaSP).SingleOrDefault();
            if(cthd == null)
            {
                return true;
            }    
            return false;
        }

        public bool themCTHD(int pMaHD, string pMaSP, int pSoLuong, double pDonGia, double pGiamGia, double pThanhTien, List<ChiTietHoaDon> ds)
        {
            try
            {
                ChiTietHoaDon cthd = new ChiTietHoaDon();
                cthd.MaHD = pMaHD;
                cthd.MaSP = pMaSP;
                cthd.SoLuong = pSoLuong;
                cthd.DonGia = pDonGia;
                if(pGiamGia == 0)
                {
                    cthd.GiamGia = null;
                }
                else
                { 
                    cthd.GiamGia = pGiamGia;
                }
                cthd.ThanhTien = pThanhTien;
                ds.Add(cthd);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaCTHD(int pMaHD, string pMaSP, int pSoLuong, double pDonGia, double pGiamGia, double pThanhTien, List<ChiTietHoaDon> ds)
        {
            try
            {
                ChiTietHoaDon cthd = ds.Where(t => t.MaHD == pMaHD && t.MaSP == pMaSP).SingleOrDefault();
                if (cthd == null)
                {
                    return false;
                }
                cthd.SoLuong = pSoLuong;
                cthd.DonGia = pDonGia; 
                if (pGiamGia == 0)
                {
                    cthd.GiamGia = null;
                }
                else
                {
                    cthd.GiamGia = pGiamGia;
                }
                cthd.ThanhTien = pThanhTien;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaCTHD(int pMaHD, string pMaSP, List<ChiTietHoaDon> ds)
        {
            try
            {
                ChiTietHoaDon cthd = ds.Where(t => t.MaHD == pMaHD && t.MaSP == pMaSP).SingleOrDefault();
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

    public class ChiTietHoaDon
    {
        int? maHD, soLuong;
        string maSP;
        double? donGia, giamGia, thanhTien;

        public int? MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int? SoLuong { get => soLuong; set => soLuong = value; }
        public double? DonGia { get => donGia; set => donGia = value; }
        public double? GiamGia { get => giamGia; set => giamGia = value; }
        public double? ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
