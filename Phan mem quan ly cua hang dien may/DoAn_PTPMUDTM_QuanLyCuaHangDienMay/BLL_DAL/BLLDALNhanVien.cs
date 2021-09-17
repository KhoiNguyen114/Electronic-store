using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNhanVien
    {
        QuanLyCuaHangDienMayDataContext quanly = new QuanLyCuaHangDienMayDataContext();
        public BLLDALNhanVien()
        {

        }
        public IQueryable loadNhanVien()
        {
            IQueryable ds = from nv in quanly.NHANVIENs select new { nv.MANV, nv.TENNV, nv.GIOITINH, nv.NGAYSINH, nv.DIENTHOAI, nv.DIACHI, nv.MACV, nv.NGAYVL };
            return ds;
        }

        public string traVeTenNhanVien(string pMaNV)
        {
            try
            {
                NHANVIEN nv = quanly.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return null;
                return nv.TENNV;
            }
            catch
            {
                return null;
            }
        }

        public string traVeMaNhanVien(string pTenDN)
        {
            try
            {
                NGUOIDUNG ng = quanly.NGUOIDUNGs.Where(t => t.TENDN == pTenDN).SingleOrDefault();
                if (ng == null)
                    return null;
                NHANVIEN nv = quanly.NHANVIENs.Where(t => t.MANV == ng.MANV).SingleOrDefault();
                if (nv == null)
                    return null;
                return nv.MANV;
            }
            catch
            {
                return null;
            }
        }

        public string traVeNhanVienDiemDanh(string pTenDN)
        {
            try
            {
                NGUOIDUNG ng = quanly.NGUOIDUNGs.Where(t => t.TENDN == pTenDN).SingleOrDefault();
                if (ng == null)
                    return null;
                NHANVIEN nv = quanly.NHANVIENs.Where(t => t.MANV == ng.MANV).SingleOrDefault();
                if (nv == null)
                    return null;
                return nv.TENNV;
            }
            catch
            {
                return null;
            }
        }

        public bool ktKhoaChinh(string pMaNV)
        {
            NHANVIEN nv = quanly.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
            if (nv == null)
                return true;
            return false;
        }

        public bool themNhanVien(string pMaNV, string pTenNV, string pGioiTinh, DateTime pNgaySinh, string pDienThoai, string pDiaChi, string pMaCV, DateTime pNgayVL)
        {
            try
            {
                NHANVIEN nv = new NHANVIEN();
                nv.MANV = pMaNV;
                nv.TENNV = pTenNV;
                nv.GIOITINH = pGioiTinh;
                nv.NGAYSINH = pNgaySinh;
                nv.DIENTHOAI = pDienThoai;
                nv.DIACHI = pDiaChi;
                nv.MACV = pMaCV;
                nv.NGAYVL = pNgayVL;

                quanly.NHANVIENs.InsertOnSubmit(nv);
                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaNhanVien(string pMaNV, string pTenNV, string pGioiTinh, DateTime pNgaySinh, string pDienThoai, string pDiaChi, string pMaCV, DateTime pNgayVL)
        {
            try
            {
                NHANVIEN nv = quanly.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return false;
                nv.TENNV = pTenNV;
                nv.GIOITINH = pGioiTinh;
                nv.NGAYSINH = pNgaySinh;
                nv.DIENTHOAI = pDienThoai;
                nv.DIACHI = pDiaChi;
                nv.MACV = pMaCV;
                nv.NGAYVL = pNgayVL;

                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaNhanVien(string pMaNV)
        {
            try
            {
                NHANVIEN nv = quanly.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return false;

                var nguoiDung = quanly.NGUOIDUNGs.Where(t => t.MANV == pMaNV).ToList();
                var diemDanh = quanly.DIEMDANHs.Where(t => t.MANV == pMaNV).ToList();
                var phieuNhap = quanly.PHIEUNHAPs.Where(t => t.MANV == pMaNV).ToList();
                var hoaDon = quanly.HOADONs.Where(t => t.MANV == pMaNV).ToList();

                quanly.NGUOIDUNGs.DeleteAllOnSubmit(nguoiDung);
                quanly.DIEMDANHs.DeleteAllOnSubmit(diemDanh);
                quanly.PHIEUNHAPs.DeleteAllOnSubmit(phieuNhap);
                quanly.HOADONs.DeleteAllOnSubmit(hoaDon);
                quanly.NHANVIENs.DeleteOnSubmit(nv);
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
