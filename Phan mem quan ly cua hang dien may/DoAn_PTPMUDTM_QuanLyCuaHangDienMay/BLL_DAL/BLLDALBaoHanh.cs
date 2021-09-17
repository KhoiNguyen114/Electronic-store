using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALBaoHanh
    {
        QuanLyCuaHangDienMayDataContext quanly = new QuanLyCuaHangDienMayDataContext();
        public BLLDALBaoHanh()
        {

        }

        public IQueryable loadBaoHanh()
        {
            IQueryable ds = from bh in quanly.BAOHANHs select new { bh.MABH, bh.MAHD, bh.MAKH, bh.MASP, bh.NGAYBH, bh.GHICHU, bh.TINHTRANG};
            return ds;
        }
        
        public bool ktKhoaChinh(int pMaBH)
        {
            BAOHANH bh = quanly.BAOHANHs.Where(t => t.MABH == pMaBH).SingleOrDefault();
            if (bh == null)
                return true;
            return false;
        }

        public bool ktDangBaoHanh(int pMaHD, string pMaSP, int pMaKH)
        {
            try
            {
                var ds = (from k in quanly.BAOHANHs
                          where k.MAHD == pMaHD && k.MASP == pMaSP && k.MAKH == pMaKH
                          select k).ToList();
                for(int i=0; i<ds.Count; i++)
                {
                    if(ds[i].TINHTRANG == "Đang bảo hành")
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool capNhatBaoHanh(int pMaBH)
        {
            try
            {
                BAOHANH bh = quanly.BAOHANHs.Where(t => t.MABH == pMaBH).SingleOrDefault();
                if(bh == null)
                {
                    return false;
                }
                bh.TINHTRANG = "Hoàn thành";
                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int kiemTraThoiGianBaoHanh(DateTime pNgayLap, int pThoiGianBH)
        {
            try
            {
                DateTime ngayHetHan = pNgayLap.AddMonths(pThoiGianBH);
                DateTime ngayHienTai = DateTime.Now;
                int kq = DateTime.Compare(ngayHetHan, ngayHienTai);
                return kq;
            }
            catch
            {
                return -2;
            }
        }

        public bool BaoHanh(int pMaHD, DateTime pNgayBH, int pMaKH, string pMaSP, string pGhiChu)
        {
            try
            {
                BAOHANH bh = new BAOHANH();
                bh.MAHD = pMaHD;
                bh.NGAYBH = pNgayBH;
                bh.MAKH = pMaKH;
                bh.MASP = pMaSP;
                bh.GHICHU = pGhiChu;
                bh.TINHTRANG = "Đang bảo hành";

                quanly.BAOHANHs.InsertOnSubmit(bh);
                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suaThongTinBH(int pMaBH, string pGhiChu)
        {
            try
            {
                BAOHANH bh = quanly.BAOHANHs.Where(t => t.MABH == pMaBH).SingleOrDefault();
                if (bh == null)
                    return false;
                bh.GHICHU = pGhiChu;
                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool xoaBaoHanh(int pMaBH)
        {
            try
            {
                BAOHANH bh = quanly.BAOHANHs.Where(t => t.MABH == pMaBH).SingleOrDefault();
                if (bh == null)
                    return false;
                quanly.BAOHANHs.DeleteOnSubmit(bh);
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
