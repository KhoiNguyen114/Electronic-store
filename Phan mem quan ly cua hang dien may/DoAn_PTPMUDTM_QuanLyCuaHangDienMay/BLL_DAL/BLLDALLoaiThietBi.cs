using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALLoaiThietBi
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALLoaiThietBi ()
        {

        }

        public List<LOAITHIETBI> loadLoaiThietBiList()
        {
            quanLy.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, quanLy.LOAITHIETBIs);
            List<LOAITHIETBI> ds = (from k in quanLy.LOAITHIETBIs select k).ToList();
            return ds;
        }

        public IQueryable loadLoaiThietBi()
        {
            IQueryable ds = from k in quanLy.LOAITHIETBIs select new { k.MATHIETBI, k.TENTHIETBI };
            return ds;
        }

        public bool ktKhoaChinh(string pMaThietBi)
        {
            LOAITHIETBI ltb = quanLy.LOAITHIETBIs.Where(t => t.MATHIETBI == pMaThietBi).SingleOrDefault();
            if(ltb == null)
            {
                return true;
            }
            return false;
        }

        public string traVeTenLoaiThietBi(string pMaThietBi)
        {
            try
            {
                string kq = "";
                LOAITHIETBI ltb = quanLy.LOAITHIETBIs.Where(t => t.MATHIETBI == pMaThietBi).SingleOrDefault();
                kq = ltb.TENTHIETBI;
                return kq;
            }
            catch
            {
                return null;
            }
        }

        public bool themLoaiThietBi(string pMaLoai, string pTenLoai)
        {
            try
            {
                LOAITHIETBI ltb = new LOAITHIETBI();
                ltb.MATHIETBI = pMaLoai;
                ltb.TENTHIETBI = pTenLoai;

                quanLy.LOAITHIETBIs.InsertOnSubmit(ltb);
                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool suaLoaiThietBi(string pMaLoai, string pTenLoai)
        {
            try
            {
                LOAITHIETBI ltb = quanLy.LOAITHIETBIs.Where(t => t.MATHIETBI == pMaLoai).SingleOrDefault();
                if(ltb == null)
                {
                    return false;
                }
                ltb.TENTHIETBI = pTenLoai;

                quanLy.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaLoaiThietBi(string pMaLoai)
        {
            try
            {
                LOAITHIETBI ltb = quanLy.LOAITHIETBIs.Where(t => t.MATHIETBI == pMaLoai).SingleOrDefault();
                if (ltb == null)
                {
                    return false;
                }
                var sp = quanLy.SANPHAMs.Where(t => t.MATHIETBI == pMaLoai).ToList();
                quanLy.SANPHAMs.DeleteAllOnSubmit(sp);
                quanLy.LOAITHIETBIs.DeleteOnSubmit(ltb);
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
