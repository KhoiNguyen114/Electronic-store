using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALLoaiKhachHang
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALLoaiKhachHang()
        {

        }

        public IQueryable loadLoaiKhachHang()
        {
            IQueryable ds = from k in quanLy.LOAIKHACHHANGs select new { k.MALOAIKH, k.TENLOAI, k.GIAMGIA};
            return ds;
        }
        public bool ktKhoaChinh(string pMaLoaiKH)
        {
            LOAIKHACHHANG lkh = quanLy.LOAIKHACHHANGs.Where(t => t.MALOAIKH == pMaLoaiKH).SingleOrDefault();
            if (lkh == null)
            {
                return true;
            }
            return false;
        }
        public string traVeTenLoaiKH(string pMaLoaiKH)
        {
            try
            {
                string kq = "";
                LOAIKHACHHANG lkh = quanLy.LOAIKHACHHANGs.Where(t => t.MALOAIKH == pMaLoaiKH).SingleOrDefault();
                kq = lkh.TENLOAI;
                return kq;
            }
            catch
            {
                return null;
            }

        }
        public bool themLoaiKH(string pMaLoaiKH, string pTenLoai, int pGiamGia)
        {
            try
            {
                LOAIKHACHHANG lkh = new LOAIKHACHHANG();
                lkh.MALOAIKH = pMaLoaiKH;
                lkh.TENLOAI = pTenLoai;
                lkh.GIAMGIA = pGiamGia;
                quanLy.LOAIKHACHHANGs.InsertOnSubmit(lkh);
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suaLoaiKH(string pMaLoaiKH, string pTenLoai, int pGiamGia)
        {
            try
            {
                LOAIKHACHHANG lkh = quanLy.LOAIKHACHHANGs.Where(t => t.MALOAIKH == pMaLoaiKH).SingleOrDefault();
                if (lkh == null)
                {
                    return false;
                }
                lkh.MALOAIKH = pMaLoaiKH;
                lkh.TENLOAI = pTenLoai;
                lkh.GIAMGIA = pGiamGia;
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
