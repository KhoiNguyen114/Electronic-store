using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
   public class BLLDALKhachHang
    {
        QuanLyCuaHangDienMayDataContext quanly = new QuanLyCuaHangDienMayDataContext();
        public BLLDALKhachHang()
        {

        }
        public IQueryable loadKhachHang()
        {
            IQueryable ds = from kh in quanly.KHACHHANGs select new { kh.MAKH, kh.TENKH, kh.GIOITINH, kh.NGAYSINH, kh.SDT , kh.DIACHI, kh.TENDN, kh.MALOAIKH};
            return ds;
        }
        public string traVeTenKhachHang(int pMaKH)
        {
            try
            {
                KHACHHANG kh = quanly.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
                if (kh == null)
                    return null;
                return kh.TENKH;
            }
            catch
            {
                return null;
            }
        }

        public bool ktKhoaChinh(int pMaKH)
        {
            KHACHHANG kh = quanly.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
            if (kh == null)
                return true;
            return false;
        }

        public bool ktTenDN(string pTenDN)
        {
            KHACHHANG kh = quanly.KHACHHANGs.Where(t => t.TENDN == pTenDN).SingleOrDefault();
            if (kh == null)
                return true;
            return false;
        }

        public bool themKhachHang(string pTenKH, string pGioiTinh, DateTime pNgaySinh, string pSDT, string pDiaChi, string pTenDN, string pMatKhau, string pMaLoaiKH)
        {
            try
            {
                KHACHHANG kh = new KHACHHANG();
                kh.TENKH = pTenKH;
                kh.GIOITINH = pGioiTinh;
                kh.NGAYSINH = pNgaySinh;
                kh.SDT = pSDT;
                kh.DIACHI = pDiaChi;
                kh.TENDN = pTenDN;
                kh.MATKHAU = pMatKhau;
                kh.MALOAIKH = pMaLoaiKH;

                quanly.KHACHHANGs.InsertOnSubmit(kh);
                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaKhachHang(int pMaKH, string pTenKH, string pGioiTinh, DateTime pNgaySinh, string pSDT, string pDiaChi, string pMatKhau, string pMaLoaiKH)
        {
            try
            {
                KHACHHANG kh = quanly.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
                if (kh == null)
                    return false;
                kh.TENKH = pTenKH;
                kh.GIOITINH = pGioiTinh;
                kh.NGAYSINH = pNgaySinh;
                kh.SDT = pSDT;
                kh.DIACHI = pDiaChi;
                kh.MATKHAU = pMatKhau;
                kh.MALOAIKH = pMaLoaiKH;

                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoaKhachHang(int pMaKH)
        {
            try
            {
                KHACHHANG kh = quanly.KHACHHANGs.Where(t => t.MAKH == pMaKH).SingleOrDefault();
                if (kh == null)
                    return false;
                var hd = quanly.HOADONs.Where(t => t.MAKH == pMaKH).ToList();
                var bh = quanly.BAOHANHs.Where(t => t.MAKH == pMaKH).ToList();

                quanly.HOADONs.DeleteAllOnSubmit(hd);
                quanly.BAOHANHs.DeleteAllOnSubmit(bh);
                quanly.KHACHHANGs.DeleteOnSubmit(kh);
                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
