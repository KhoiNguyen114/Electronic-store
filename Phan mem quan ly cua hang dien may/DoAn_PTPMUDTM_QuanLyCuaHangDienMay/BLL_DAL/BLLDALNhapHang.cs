using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNhapHang
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALNhapHang()
        {

        }

        public IQueryable loadXemPhieuNhap()
        {
            IQueryable ds = from k in quanLy.PHIEUNHAPs
                            join nv in quanLy.NHANVIENs on k.MANV equals nv.MANV
                            join nsx in quanLy.NHASANXUATs on k.MANSX equals nsx.MANSX
                            select new
                            {
                                k.MAPN,
                                nv.TENNV,
                                nsx.TENNSX,
                                k.NGAYLAPPN,
                                k.TONGTIENPN,
                                k.TINHTRANG
                            };
            return ds;
        }

        public bool themPhieuNhap(string pMaNV, string pMaNSX)
        {
            try
            {
                PHIEUNHAP pn = new PHIEUNHAP();
                pn.MANV = pMaNV;
                pn.MANSX = pMaNSX;
                pn.NGAYLAPPN = DateTime.Now;
                pn.TINHTRANG = "Có hiệu lực";

                quanLy.PHIEUNHAPs.InsertOnSubmit(pn);
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int traVeMaPhieuNhap()
        {
            try
            {
                var ds = from k in quanLy.PHIEUNHAPs orderby k.MAPN descending select k;
                if (ds == null)
                    return -1;
                PHIEUNHAP pn = ds.First();
                return pn.MAPN;
            }
            catch
            {
                return -1;
            }
        }

        public bool huyPhieuNhap(int pMaPN)
        {
            try
            {
                PHIEUNHAP pn = quanLy.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
                if (pn == null)
                    return false;
                pn.TINHTRANG = "Hủy";
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xacNhanThanhToan(int pMaPN, List<ChiTietPhieuNhap> ds)
        {
            try
            {
                PHIEUNHAP pn = quanLy.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
                if (pn == null)
                {
                    return false;
                }
                NHASANXUAT nsx = quanLy.NHASANXUATs.Where(t => t.MANSX == pn.MANSX).SingleOrDefault();
                if (nsx == null)
                {
                    return false;
                }
                double? tongTien = ds.Sum(t => t.ThanhTien);
                pn.TONGTIENPN = tongTien;

                quanLy.SubmitChanges();
                for (int i = 0; i < ds.Count; i++)
                {
                    CHITIETPHIEUNHAP ctpn = new CHITIETPHIEUNHAP();
                    ctpn.MAPN = pn.MAPN;
                    ctpn.MASP = ds[i].MaSP;
                    ctpn.SOLUONG = ds[i].SoLuong;
                    ctpn.DONGIANHAP = ds[i].DonGia;
                    ctpn.THANHTIEN = ds[i].ThanhTien;

                    quanLy.CHITIETPHIEUNHAPs.InsertOnSubmit(ctpn);
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

        public void capNhatSauKhiThanhToan(int pMaPN)
        {
            List<CHITIETPHIEUNHAP> ds = quanLy.CHITIETPHIEUNHAPs.Where(t => t.MAPN == pMaPN).ToList();
            for (int i = 0; i < ds.Count; i++)
            {
                string ma = ds[i].MASP;
                SANPHAM sp = quanLy.SANPHAMs.Where(t => t.MASP == ma).SingleOrDefault();
                sp.SOLUONG += ds[i].SOLUONG;
                quanLy.SubmitChanges();
            }
        }
    }
}
