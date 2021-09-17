using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_QuanLyMatHangDienMay.Models;

namespace DoAnWeb_QuanLyMatHangDienMay.Controllers
{
    public class DatHangController : Controller
    {
        //
        // GET: /DatHang/

        DataClasses1DataContext data = new DataClasses1DataContext();

        public ActionResult XemGioHang()
        {
            GioHang gio = (GioHang)Session["gh"];
            if (gio == null)
                gio = new GioHang();
            return View(gio);
        }

        public ActionResult ThemMatHang(string id)
        {
            GioHang gio = (GioHang)Session["gh"];
            if (gio == null)
                gio = new GioHang();
            bool kq = gio.themSP(id);
            Session["gh"] = gio;
            return RedirectToAction("Index","Home");
        }

        public ActionResult XoaMatHang(string id)
        {
            GioHang gio = (GioHang)Session["gh"];
            CartItem a = gio.dsSP.Find(t => t.maSP == id);
            if (a == null)
            {
                return RedirectToAction("XemGioHang", "DatHang");
            }
            gio.dsSP.Remove(a);
            return RedirectToAction("XemGioHang","DatHang");
        }

        [HttpGet]
        public ActionResult TaoDonDatHang() //Tạo đơn đặt hàng, nếu chưa đặt hàng sẽ đăng nhập
        {
            KHACHHANG kh = (KHACHHANG)Session["kh"];
            if (kh == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            ViewBag.k = kh;
            GioHang gio = (GioHang)Session["gh"];
            if (gio == null)
                gio = new GioHang();
            return View(gio);
        }

        [HttpPost]
        public ActionResult LuuDonDatHang(FormCollection col) //Lưu đơn đặt hàng vào csdl, Thông báo người dùng đặt hành thành công
        {
            KHACHHANG kh = (KHACHHANG)Session["kh"];
            GioHang gio = (GioHang)Session["gh"];
            HOADON hd = new HOADON();
            hd.NGAYLAPHD = DateTime.Now;
            hd.MAKH = kh.MAKH;
            hd.TINHTRANG = "Chờ xác nhận";
            hd.TONGTIENHD = gio.tongThanhTien();
            data.HOADONs.InsertOnSubmit(hd);
            data.SubmitChanges();

            foreach (CartItem item in gio.dsSP)
            {
                CHITIETHOADON cthd = new CHITIETHOADON();
                cthd.MAHD = hd.MAHD;
                cthd.MASP = item.maSP;
                cthd.SOLUONG = item.soLuong;
                cthd.DONGIABAN = item.donGia;
                cthd.THANHTIEN = item.thanhTien;
                data.CHITIETHOADONs.InsertOnSubmit(cthd);
                data.SubmitChanges();
            }
            capNhatSauKhiThanhToan(hd.MAHD);
            gio.dsSP.Clear();
            return View();
        }

        public void capNhatSauKhiThanhToan(int pMaHD)
        {
            List<CHITIETHOADON> ds = data.CHITIETHOADONs.Where(t => t.MAHD == pMaHD).ToList();
            for (int i = 0; i < ds.Count; i++)
            {
                string ma = ds[i].MASP;
                SANPHAM sp = data.SANPHAMs.Where(t => t.MASP == ma).SingleOrDefault();
                sp.SOLUONG -= ds[i].SOLUONG;
                data.SubmitChanges();
            }
        }
    }    
}
