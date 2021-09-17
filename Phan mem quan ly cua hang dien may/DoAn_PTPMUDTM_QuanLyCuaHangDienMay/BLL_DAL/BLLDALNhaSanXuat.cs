using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNhaSanXuat
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALNhaSanXuat()
        {

        }

        public IQueryable loadNhaSanXuat()
        {
            IQueryable ds = from k in quanLy.NHASANXUATs select new { k.MANSX, k.TENNSX, k.DIACHI, k.SDT };
            return ds;
        }

        public bool ktKhoaChinh(string pMaNSX)
        {
            NHASANXUAT nsx = quanLy.NHASANXUATs.Where(t => t.MANSX == pMaNSX).SingleOrDefault();
            if (nsx == null)
            {
                return true;
            }
            return false;
        }

        public string traVeTenNSX(string pMaNSX)
        {
            try
            {
                string kq = "";
                NHASANXUAT nsx = quanLy.NHASANXUATs.Where(t => t.MANSX == pMaNSX).SingleOrDefault();
                if(nsx == null)
                {
                    return null;
                }
                kq = nsx.TENNSX;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public bool themNSX(string pMaNSX, string pTenNSX, string pDiaChi, string pSDT)
        {
            try
            {
                NHASANXUAT nsx = new NHASANXUAT();
                nsx.MANSX = pMaNSX;
                nsx.TENNSX = pTenNSX;
                nsx.DIACHI = pDiaChi;
                nsx.SDT = pSDT;

                quanLy.NHASANXUATs.InsertOnSubmit(nsx);
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaNSX(string pMaNSX, string pTenNSX, string pDiaChi, string pSDT)
        {
            try
            {
                NHASANXUAT nsx = quanLy.NHASANXUATs.Where(t => t.MANSX == pMaNSX).SingleOrDefault();
                if (nsx == null)
                {
                    return false;
                }
                nsx.TENNSX = pTenNSX;
                nsx.DIACHI = pDiaChi;
                nsx.SDT = pSDT;

                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaNSX(string pMaNSX)
        {
            try
            {
                NHASANXUAT nsx = quanLy.NHASANXUATs.Where(t => t.MANSX == pMaNSX).SingleOrDefault();
                if (nsx == null)
                {
                    return false;
                }
                var sp = quanLy.SANPHAMs.Where(t => t.MANSX == pMaNSX).ToList();
                var sp1 = quanLy.PHIEUNHAPs.Where(t => t.MANSX == pMaNSX).ToList();
                quanLy.SANPHAMs.DeleteAllOnSubmit(sp);
                quanLy.PHIEUNHAPs.DeleteAllOnSubmit(sp1);
                quanLy.NHASANXUATs.DeleteOnSubmit(nsx);
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
