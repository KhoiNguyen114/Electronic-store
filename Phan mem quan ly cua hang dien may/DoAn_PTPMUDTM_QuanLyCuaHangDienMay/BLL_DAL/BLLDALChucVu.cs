using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALChucVu
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALChucVu()
        {

        }

        public IQueryable loadChucVu()
        {
            IQueryable ds = from k in quanLy.CHUCVUs select new { k.MACV, k.TENCV, k.LUONGCB };
            return ds;
        }
        public bool ktKhoaChinh(string pMACV)
        {
            CHUCVU cv = quanLy.CHUCVUs.Where(t => t.MACV == pMACV).SingleOrDefault();
            if (cv == null)
            {
                return true;
            }
            return false;
        }
        public string traVeTenCV(string pMACV)
        {
            try
            {
                string kq = "";
                CHUCVU cv = quanLy.CHUCVUs.Where(t => t.MACV == pMACV).SingleOrDefault();
                kq = cv.TENCV;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public string traVeTenChucVuTinhLuong(string pMaNV)
        {
            try
            {
                string kq = "";
                NHANVIEN nv = quanLy.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return null;
                CHUCVU chucvu = quanLy.CHUCVUs.Where(t => t.MACV == nv.MACV).SingleOrDefault();
                kq = chucvu.TENCV;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public double? traVeLuongCB(string pMaNV)
        {
            try
            {
                NHANVIEN nv = quanLy.NHANVIENs.Where(t => t.MANV == pMaNV).SingleOrDefault();
                if (nv == null)
                    return -1;
                CHUCVU chucvu = quanLy.CHUCVUs.Where(t => t.MACV == nv.MACV).SingleOrDefault();
                return chucvu.LUONGCB;
            }
            catch
            {
                return -1;
            }
        }

        public bool themCV(string pMaCV, string pTenCV, int pLUONGCB)
        {
            try
            {
                CHUCVU cv = new CHUCVU();
                cv.MACV = pMaCV;
                cv.TENCV = pTenCV;
                cv.LUONGCB = pLUONGCB;
                quanLy.CHUCVUs.InsertOnSubmit(cv);
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool suaCV(string pMaCV, string pTenCV, int pLUONGCB)
        {
            try
            {
                CHUCVU cv = quanLy.CHUCVUs.Where(t => t.MACV == pMaCV).SingleOrDefault();
                if (cv == null)
                {
                    return false;
                }
                cv.MACV = pMaCV;
                cv.TENCV = pTenCV;
                cv.LUONGCB = pLUONGCB;
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
