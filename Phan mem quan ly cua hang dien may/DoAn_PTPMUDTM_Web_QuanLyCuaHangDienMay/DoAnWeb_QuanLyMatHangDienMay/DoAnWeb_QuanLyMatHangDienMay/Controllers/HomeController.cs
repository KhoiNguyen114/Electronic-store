using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_QuanLyMatHangDienMay.Models;
using System.IO;

namespace DoAnWeb_QuanLyMatHangDienMay.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        DataClasses1DataContext data = new DataClasses1DataContext();

        public ActionResult Index() //Giao diện trang chủ
        {
            List<SANPHAM> dsSP = data.SANPHAMs.ToList();
            return View(dsSP);
        }        

        public ActionResult DSLoaiThietBi() //Partial View hiển thị loại thiết bị
        {
            List<LOAITHIETBI> dsSP = data.LOAITHIETBIs.ToList();
            return PartialView(dsSP);
        }

        public ActionResult DSNhaSanXuat()  //Partial View hiển thị nhà sản xuất
        {
            List<NHASANXUAT> dsSP = data.NHASANXUATs.ToList();
            return PartialView(dsSP);
        }

        public ActionResult HTSPTheoLTB(string id)  //Hiển thị danh sách sản phẩm theo loại thiết bị
        {
            List<SANPHAM> dsSP = data.SANPHAMs.Where(t => t.MATHIETBI == id).ToList();
            return View("Index",dsSP);
        }

        public ActionResult HTSPTheoNSX(string id)  //Hiển thị danh sách sản phẩm theo nhà sản xuất
        {
            List<SANPHAM> dsSP = data.SANPHAMs.Where(t => t.MANSX == id).ToList();
            return View("Index", dsSP);
        }

        public ActionResult TimKiem(FormCollection col)  //Hiển thị danh sách tìm kiếm
        {
            string ten = col["txtSearch"];
            List<SANPHAM> dsSP = data.SANPHAMs.Where(t => t.TENSP.Contains(ten)).ToList();
            return View("Index", dsSP);
        }

        public ActionResult HienThiTen()  //Hiển thị tên khách hàng
        {
            ViewBag.kh = Session["kh"];
            return PartialView();
        }

        public ActionResult Index1() //Giao diện trang chủ của quản lý
        {
            List<SANPHAM> dsSP = data.SANPHAMs.ToList();
            return View(dsSP);
        }

        public ActionResult ChiTiet(string id)  //Hiển thị chi tiết
        {
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(t => t.MASP == id);
            return View(sp);
        }

        public ActionResult HoTro()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult Add(SANPHAM sp)
        {
            int kq = 1;
            try
            {
                data.SANPHAMs.InsertOnSubmit(sp);
                data.SubmitChanges();
            }
            catch
            {
                kq = 0;
            }
            return Json(kq, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ThemSP()
        {
            return View();
        }

        public ActionResult TuVan()
        {
            List<LOAITHIETBI> ds = data.LOAITHIETBIs.ToList();
            ViewBag.TieuChi = docFileTieuChi();
            return View(ds);
        }


        // hiển thị các tiêu chí ở đây?
        // cái này thì nó trả về 1 list để test 1 cái đi
        // cách tieu chí tương ứng với các Raido đó hả?
        // gióng như này nè Hải
        // hiểu rổi, thay vì bên kia thì m nên dùng cái này trả về một partialView
        public ActionResult hienThiCacTieuChi(string pName)
        {
            List<DuLieu> dsDuLieu = docFile();
            List<DuLieu> dsCacDacDiem = getDuLieu(pName, dsDuLieu);
            List<string> dsDD1 = getDacDiem1(dsCacDacDiem, 1);
            return View(dsDD1);
        }

        public List<DuLieu> docFile()
        {
            StreamReader sr = new StreamReader(Server.MapPath("~/Content/TuLanh.txt"));
            string line;
            List<DuLieu> ds = new List<DuLieu>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] a = line.Split(',');
                DuLieu duLieu = new DuLieu();
                duLieu.TenThietBi = a[0];
                duLieu.DacDiem1 = a[1];
                duLieu.DacDiem2 = a[2];
                duLieu.DacDiem3 = a[3];
                duLieu.DacDiem4 = a[4];
                duLieu.MaSP = a[5];
                ds.Add(duLieu);
            }
            sr.Close();
            return ds;
        }

        public List<DuLieuTrain> docFileTrain()
        {
            StreamReader sr = new StreamReader("Output1.txt");
            string line;
            List<DuLieuTrain> ds = new List<DuLieuTrain>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] a = line.Split(',');
                DuLieuTrain dlt = new DuLieuTrain();
                dlt.DacDiem1 = a[0];
                dlt.DacDiem2 = a[1];
                dlt.DacDiem3 = a[2];
                dlt.DacDiem4 = a[3];
                dlt.XacSuat = double.Parse(a[4]);
                dlt.MaSP = a[5];
                ds.Add(dlt);
            }
            sr.Close();
            return ds;
        }


        public List<TieuChi> docFileTieuChi()
        {
            StreamReader sr = new StreamReader(Server.MapPath("~/Content/FileTieuChi.txt"));            
            string line;
            List<TieuChi> ds = new List<TieuChi>();
            while ((line = sr.ReadLine()) != null)
            {
                string[] a = line.Split(',');
                TieuChi tieuChi = new TieuChi();
                tieuChi.TenThietBi = a[0];
                tieuChi.TieuChi1 = a[1];
                tieuChi.TieuChi2 = a[2];
                tieuChi.TieuChi3 = a[3];
                tieuChi.TieuChi4 = a[4];
                ds.Add(tieuChi);
            }
            sr.Close();
            return ds;
        }

        public List<string> getDacDiem1(List<DuLieu> dsDuLieu, int pDD)
        {
            List<string> ds = new List<string>();
            for (int i = 0; i < dsDuLieu.Count; i++)
            {
                switch (pDD)
                {
                    case 1:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].DacDiem1.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].DacDiem1.Trim()))
                        {
                            ds.Add(dsDuLieu[i].DacDiem1.Trim());
                        }
                        break;
                    case 2:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].DacDiem2.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].DacDiem2.Trim()))
                        {
                            ds.Add(dsDuLieu[i].DacDiem2.Trim());
                        }
                        break;
                    case 3:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].DacDiem3.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].DacDiem3.Trim()))
                        {
                            ds.Add(dsDuLieu[i].DacDiem3.Trim());
                        }
                        break;
                    case 4:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].DacDiem4.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].DacDiem4.Trim()))
                        {
                            ds.Add(dsDuLieu[i].DacDiem4.Trim());
                        }
                        break;
                    case 5:
                        if (!ds.Any())
                        {
                            ds.Add(dsDuLieu[i].MaSP.Trim());
                        }
                        if (kiemTraListDacDiem1(ds, dsDuLieu[i].MaSP.Trim()))
                        {
                            ds.Add(dsDuLieu[i].MaSP.Trim());
                        }
                        break;
                }

            }

            return ds;
        }

        public bool kiemTraListDacDiem1(List<string> ds, string pTenDacDiem)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].Trim() == pTenDacDiem.Trim())
                {
                    return false;
                }
            }
            return true;
        }

        public List<DuLieu> getDuLieu(string pName, List<DuLieu> dsDuLieu)
        {
            List<DuLieu> ds = new List<DuLieu>();
            for (int i = 0; i < dsDuLieu.Count; i++)
            {
                if (dsDuLieu[i].TenThietBi == pName)
                {
                    ds.Add(dsDuLieu[i]);
                }
            }
            return ds;
        }
    }

    public class DuLieu
    {
        string tenThietBi, dacDiem1, dacDiem2, dacDiem3, dacDiem4, maSP;

        public string TenThietBi { get => tenThietBi; set => tenThietBi = value; }
        public string DacDiem1 { get => dacDiem1; set => dacDiem1 = value; }
        public string DacDiem2 { get => dacDiem2; set => dacDiem2 = value; }
        public string DacDiem3 { get => dacDiem3; set => dacDiem3 = value; }
        public string DacDiem4 { get => dacDiem4; set => dacDiem4 = value; }
        public string MaSP { get => maSP; set => maSP = value; }
    }

    public class TieuChi
    {
        string tenThietBi, tieuChi1, tieuChi2, tieuChi3, tieuChi4;

        public string TenThietBi { get => tenThietBi; set => tenThietBi = value; }
        public string TieuChi1 { get => tieuChi1; set => tieuChi1 = value; }
        public string TieuChi2 { get => tieuChi2; set => tieuChi2 = value; }
        public string TieuChi3 { get => tieuChi3; set => tieuChi3 = value; }
        public string TieuChi4 { get => tieuChi4; set => tieuChi4 = value; }
    }

    public class DuLieuTrain
    {
        string dacDiem1, dacDiem2, dacDiem3, dacDiem4, maSP;
        double xacSuat;

        public string DacDiem1 { get => dacDiem1; set => dacDiem1 = value; }
        public string DacDiem2 { get => dacDiem2; set => dacDiem2 = value; }
        public string DacDiem3 { get => dacDiem3; set => dacDiem3 = value; }
        public string DacDiem4 { get => dacDiem4; set => dacDiem4 = value; }
        public double XacSuat { get => xacSuat; set => xacSuat = value; }
        public string MaSP { get => maSP; set => maSP = value; }
    }
}
