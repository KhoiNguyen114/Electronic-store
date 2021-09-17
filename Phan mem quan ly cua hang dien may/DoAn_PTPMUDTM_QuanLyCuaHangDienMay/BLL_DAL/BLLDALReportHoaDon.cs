using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALReportHoaDon
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALReportHoaDon()
        {

        }

        public DataTable xuatHoaDon(int maHD)
        {
            var ds = (from k in quanLy.HOADONs
                      join cthd in quanLy.CHITIETHOADONs on k.MAHD equals cthd.MAHD
                      join sp in quanLy.SANPHAMs on cthd.MASP equals sp.MASP
                      join nv in quanLy.NHANVIENs on k.MANV equals nv.MANV
                      join kh in quanLy.KHACHHANGs on k.MAKH equals kh.MAKH
                      where k.MAHD == maHD
                      select new
                      {
                          k.MAHD,
                          k.NGAYLAPHD,
                          k.TONGTIENHD,
                          k.THANHTOAN,
                          sp.TENSP,
                          sp.THOIGIANBH,
                          cthd.SOLUONG,
                          cthd.DONGIABAN,
                          cthd.THANHTIEN,
                          kh.TENKH,
                          nv.TENNV,
                      }).ToList();

            DataTable dt = new DataTable();
            dt = ToDataTable(ds);
            return dt;
        }

        public DateTime? traVeNgayLap(int pMaHD)
        {
            HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.NGAYLAPHD;
        }

        public double? traVeTongTien(int pMaHD)
        {
            HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.TONGTIENHD;
        }
        public double? traVeThanhToan(int pMaHD)
        {
            HOADON hd = quanLy.HOADONs.Where(t => t.MAHD == pMaHD).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.THANHTOAN;
        }

        private DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dt.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {//inserting property values to datatable rows
                    values[i] = props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dt;
        }
        
    }
}
