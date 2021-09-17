using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALNguoiDungNhomNguoiDung
    {
        QuanLyCuaHangDienMayDataContext quanly = new QuanLyCuaHangDienMayDataContext();
        public BLLDALNguoiDungNhomNguoiDung()
        {

        }
        public IQueryable loadQLNguoiDung()
        {

            IQueryable ng = from k in quanly.QL_NGUOIDUNGNHOMNGUOIDUNGs select new { k.TENDN, k.MANHOM, k.GHICHU };
            return ng;

        }

        public IQueryable loadMaNhom()
        {
            IQueryable ma = from m in quanly.NHOMNGUOIDUNGs select new { m.MANHOM, m.TENNHOM };
            return ma;

        }

        public IQueryable loadTenDN()
        {
            IQueryable ten = from t in quanly.NGUOIDUNGs select new { t.TENDN };
            return ten;
        }

        public string traVeTenNhom(string pMaNhom)
        {
            NHOMNGUOIDUNG ng = quanly.NHOMNGUOIDUNGs.Where(t => t.MANHOM == pMaNhom).SingleOrDefault();
            if (ng == null)
                return null;
            return ng.TENNHOM;
        }

        public bool themQLNguoiDung(string pTenDN, string pMaNhom, string pGhiChu)
        {
            try
            {
                QL_NGUOIDUNGNHOMNGUOIDUNG ngdung = new QL_NGUOIDUNGNHOMNGUOIDUNG();
                ngdung.TENDN = pTenDN;
                ngdung.MANHOM = pMaNhom;
                ngdung.GHICHU = pGhiChu;

                quanly.QL_NGUOIDUNGNHOMNGUOIDUNGs.InsertOnSubmit(ngdung);
                quanly.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool xoaQLNguoiDung(string pTenDN, string pMaNhom)
        {
            try
            {
                QL_NGUOIDUNGNHOMNGUOIDUNG nv = quanly.QL_NGUOIDUNGNHOMNGUOIDUNGs.Where(t => t.TENDN == pTenDN && t.MANHOM == pMaNhom).SingleOrDefault();
                if (nv == null)
                    return false;

                quanly.QL_NGUOIDUNGNHOMNGUOIDUNGs.DeleteOnSubmit(nv);
                quanly.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ktKhoaChinhQLNguoiDung(string pTenDN, string pMaNhom)
        {
            QL_NGUOIDUNGNHOMNGUOIDUNG ng = quanly.QL_NGUOIDUNGNHOMNGUOIDUNGs.Where(t => t.TENDN == pTenDN && t.MANHOM == pMaNhom).SingleOrDefault();
            if (ng == null)
                return true;
            return false;
        }

        public bool ktNguoiDungDaCoNhom(string pTenDN)
        {
            QL_NGUOIDUNGNHOMNGUOIDUNG ng = quanly.QL_NGUOIDUNGNHOMNGUOIDUNGs.Where(t => t.TENDN == pTenDN).SingleOrDefault();
            if (ng == null)
                return true;
            return false;
        }
    }
}
