using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALDiemDanh
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        public BLLDALDiemDanh()
        {

        }

        public bool ktKhoaChinh(string pMaNV, DateTime pNgayDD)
        {
            DIEMDANH dd = quanLy.DIEMDANHs.Where(t => t.MANV == pMaNV && t.NGAYDD == pNgayDD).SingleOrDefault();
            if (dd == null)
                return true;
            return false;
        }

        public int? tinhSoNgayLamViec(string pMaNV, int pThang, int pNam)
        {
            int? soNgay = quanLy.DIEMDANHs.Count(t => t.MANV == pMaNV && t.NGAYDD.Year == pNam && t.NGAYDD.Month == pThang);
            return soNgay;
        }

        public bool themDiemDanh(string pMaNV, DateTime pNgayDD)
        {
            try
            {
                DIEMDANH dd = new DIEMDANH();
                dd.MANV = pMaNV;
                dd.NGAYDD = pNgayDD;

                quanLy.DIEMDANHs.InsertOnSubmit(dd);
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
