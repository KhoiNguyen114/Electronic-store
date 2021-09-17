using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALReportPhieuNhap
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALReportPhieuNhap()
        {

        }

        public DataTable xuatPhieuNhap(int maPN)
        {
            var ds = (from k in quanLy.PHIEUNHAPs
                      join ctpn in quanLy.CHITIETPHIEUNHAPs on k.MAPN equals ctpn.MAPN
                      join sp in quanLy.SANPHAMs on ctpn.MASP equals sp.MASP
                      join nv in quanLy.NHANVIENs on k.MANV equals nv.MANV
                      join nsx in quanLy.NHASANXUATs on k.MANSX equals nsx.MANSX
                      where k.MAPN == maPN
                      select new
                      {
                          k.MAPN,
                          nsx.TENNSX,
                          sp.TENSP,
                          nv.TENNV,
                          k.NGAYLAPPN,
                          k.TONGTIENPN,                          
                          ctpn.SOLUONG,
                          ctpn.DONGIANHAP,
                          ctpn.THANHTIEN,
                      }).ToList();

            DataTable dt = new DataTable();
            dt = ToDataTable(ds);
            return dt;
        }

        public DateTime? traVeNgayLap(int pMaPN)
        {
            PHIEUNHAP hd = quanLy.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.NGAYLAPPN;
        }

        public double? traVeTongTien(int pMaPN)
        {
            PHIEUNHAP hd = quanLy.PHIEUNHAPs.Where(t => t.MAPN == pMaPN).SingleOrDefault();
            if (hd == null)
                return null;
            return hd.TONGTIENPN;
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
