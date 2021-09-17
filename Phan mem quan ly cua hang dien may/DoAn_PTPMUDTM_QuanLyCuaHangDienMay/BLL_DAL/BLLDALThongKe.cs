using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class BLLDALThongKe
    {
        QuanLyCuaHangDienMayDataContext quanLy = new QuanLyCuaHangDienMayDataContext();
        
        public BLLDALThongKe()
        {

        }

        public IQueryable thongKeDoanhThu(int pNam)
        {
            IQueryable ts = from k in quanLy.HOADONs
                            where k.NGAYLAPHD.Value.Year == pNam
                            select new { k.MAHD, k.MANV, k.MAKH, k.NGAYLAPHD, k.TONGTIENHD, k.THANHTOAN };
            return ts;
        }

        public IQueryable thongKeDoanhThu(int pThang, int pNam)
        {
            IQueryable ts = from k in quanLy.HOADONs
                            where k.NGAYLAPHD.Value.Month == pThang && k.NGAYLAPHD.Value.Year == pNam
                            select new { k.MAHD, k.MANV, k.MAKH, k.NGAYLAPHD, k.TONGTIENHD, k.THANHTOAN };
            return ts;
        }

        public IQueryable thongKeDoanhThu(int pNgay, int pThang, int pNam)
        {
            IQueryable ts = from k in quanLy.HOADONs
                            where k.NGAYLAPHD.Value.Month == pThang && k.NGAYLAPHD.Value.Year == pNam && k.NGAYLAPHD.Value.Day == pNgay
                            select new { k.MAHD, k.MANV, k.MAKH, k.NGAYLAPHD, k.TONGTIENHD, k.THANHTOAN };
            return ts;
        }

        public double? tongTien(int pNam)
        {
            List<ThongKe> ts = (from k in quanLy.HOADONs
                                where k.NGAYLAPHD.Value.Year == pNam
                                select new ThongKe
                                {
                                    MaHD = k.MAHD,
                                    MaNV = k.MANV,
                                    MaKH = k.MAKH,
                                    NgayLap = k.NGAYLAPHD,
                                    TongTien = k.TONGTIENHD,
                                    ThanhToan = k.THANHTOAN,
                                }).ToList();
            var tong = ts.Sum(t => t.ThanhToan);
            return tong;
        }

        public double? tongTien(int pThang, int pNam)
        {
            List<ThongKe> ts = (from k in quanLy.HOADONs
                                where k.NGAYLAPHD.Value.Month == pThang && k.NGAYLAPHD.Value.Year == pNam
                                select new ThongKe
                                {
                                    MaHD = k.MAHD,
                                    MaNV = k.MANV,
                                    MaKH = k.MAKH,
                                    NgayLap = k.NGAYLAPHD,
                                    TongTien = k.TONGTIENHD,
                                    ThanhToan = k.THANHTOAN,
                                }).ToList();
            var tong = ts.Sum(t => t.ThanhToan);
            return tong;
        }

        public double? tongTien(int pNgay, int pThang, int pNam)
        {
            List<ThongKe> ts = (from k in quanLy.HOADONs
                                where k.NGAYLAPHD.Value.Month == pThang && k.NGAYLAPHD.Value.Year == pNam && k.NGAYLAPHD.Value.Day == pNgay
                                select new ThongKe
                                {
                                    MaHD = k.MAHD,
                                    MaNV = k.MANV,
                                    MaKH = k.MAKH,
                                    NgayLap = k.NGAYLAPHD,
                                    TongTien = k.TONGTIENHD,
                                    ThanhToan = k.THANHTOAN,
                                }).ToList();
            var tong = ts.Sum(t => t.ThanhToan);
            return tong;
        }

        public IQueryable thongKePhieuNhap(int pNam)
        {
            IQueryable ts = from k in quanLy.PHIEUNHAPs
                            where k.NGAYLAPPN.Value.Year == pNam
                            select new { k.MAPN, k.MANV, k.MANSX, k.NGAYLAPPN, k.TONGTIENPN };
            return ts;
        }

        public IQueryable thongKePhieuNhap(int pThang, int pNam)
        {
            IQueryable ts = from k in quanLy.PHIEUNHAPs
                            where k.NGAYLAPPN.Value.Month == pThang && k.NGAYLAPPN.Value.Year == pNam
                            select new { k.MAPN, k.MANV, k.MANSX, k.NGAYLAPPN, k.TONGTIENPN };
            return ts;
        }

        public IQueryable thongKePhieuNhap(int pNgay, int pThang, int pNam)
        {
            IQueryable ts = from k in quanLy.PHIEUNHAPs
                            where k.NGAYLAPPN.Value.Month == pThang && k.NGAYLAPPN.Value.Year == pNam && k.NGAYLAPPN.Value.Day == pNgay
                            select new { k.MAPN, k.MANV, k.MANSX, k.NGAYLAPPN, k.TONGTIENPN };
            return ts;
        }

        public double? tongTienPhieuNhap(int pNam)
        {
            List<ThongKePhieuNhap> ts = (from k in quanLy.PHIEUNHAPs
                                         where k.NGAYLAPPN.Value.Year == pNam
                                         select new ThongKePhieuNhap
                                         {
                                             MaPN = k.MANV,
                                             MaNV = k.MANV,
                                             MaNCC = k.MANSX,
                                             NgayLap = k.NGAYLAPPN,
                                             TongTien = k.TONGTIENPN,
                                         }).ToList();
            var tong = ts.Sum(t => t.TongTien);
            return tong;
        }

        public double? tongTienPhieuNhap(int pThang, int pNam)
        {
            List<ThongKePhieuNhap> ts = (from k in quanLy.PHIEUNHAPs
                                         where k.NGAYLAPPN.Value.Month == pThang && k.NGAYLAPPN.Value.Year == pNam
                                         select new ThongKePhieuNhap
                                         {
                                             MaPN = k.MANV,
                                             MaNV = k.MANV,
                                             MaNCC = k.MANSX,
                                             NgayLap = k.NGAYLAPPN,
                                             TongTien = k.TONGTIENPN,
                                         }).ToList();
            var tong = ts.Sum(t => t.TongTien);
            return tong;
        }

        public double? tongTienPhieuNhap(int pNgay, int pThang, int pNam)
        {
            List<ThongKePhieuNhap> ts = (from k in quanLy.PHIEUNHAPs
                                         where k.NGAYLAPPN.Value.Month == pThang && k.NGAYLAPPN.Value.Year == pNam && k.NGAYLAPPN.Value.Day == pNgay
                                         select new ThongKePhieuNhap
                                         {
                                             MaPN = k.MANV,
                                             MaNV = k.MANV,
                                             MaNCC = k.MANSX,
                                             NgayLap = k.NGAYLAPPN,
                                             TongTien = k.TONGTIENPN,
                                         }).ToList();
            var tong = ts.Sum(t => t.TongTien);
            return tong;
        }

        public List<int> loadDuLieu(int pBatDau, int pKetThuc)
        {
            List<int> ds = new List<int>();
            for (int i = pBatDau; i <= pKetThuc; i++)
            {
                ds.Add(i);
            }
            return ds;
        }

        public List<int> loadThang2(int pNam)
        {
            List<int> ds = new List<int>();
            int soNgay = 0;
            if (kiemTraNamNhuan(pNam))
            {
                soNgay = 29;
            }
            else
            {
                soNgay = 28;
            }
            ds = loadDuLieu(1, soNgay);
            return ds;
        }

        public bool kiemTraNamNhuan(int pNam)
        {
            if (pNam % 400 == 0 || (pNam % 4 == 0 && pNam % 100 != 0))
            {
                return true;
            }
            return false;
        }

        public bool kiemTraNgayThangHopLe(int pNgay, int pThang, int pNam)
        {
            if (pNgay == 31 && (pThang == 4 || pThang == 6 || pThang == 9 || pThang == 11))
                return false;
            if (kiemTraNamNhuan(pNam))
            {
                if (pThang == 2 && (pNgay == 30 || pNgay == 31))
                    return false;
            }
            else
            {
                if (pThang == 2 && (pNgay == 29 || pNgay == 30 || pNgay == 31))
                    return false;
            }
            return true;
        }
    }

    public class ThongKe
    {
        string maNV;
        int? maKH;
        int? maHD;        

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public int? MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public int? MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }
        DateTime? ngayLap;

        public DateTime? NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        double? tongTien, thanhToan;

        public double? ThanhToan
        {
            get { return thanhToan; }
            set { thanhToan = value; }
        }

        public double? TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }

    }

    public class ThongKePhieuNhap
    {
        string maPN, maNV, maNSX;

        public string MaNCC
        {
            get { return maNSX; }
            set { maNSX = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string MaPN
        {
            get { return maPN; }
            set { maPN = value; }
        }
        DateTime? ngayLap;

        public DateTime? NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        double? tongTien;

        public double? TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
    }
}
