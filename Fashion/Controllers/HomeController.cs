using Fashion.Common;
using Fashion.Models;
using MyDb.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var sanphamDao = new SanphamDao();
            //lấy ra những sản phẩm mới và hot
            ViewBag.listNewSanphams = sanphamDao.ListNewSanpham(4);
            ViewBag.listHotSanphams = sanphamDao.ListHotSanpham(4);
            return View();
        }
        [ChildActionOnly]  //dành cho 1 cái view ko gọi tới trang khác được
        public ActionResult Menuchung()   //hàm gọi menu
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }
        public ActionResult Menutren()   //hàm gọi menu ở trên
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }
        public PartialViewResult HeaderGiohang()   //hàm gọi menu giỏ hàng.
        {
            var giohang = Session[CommonParams.GiohangSession];
            var list = new List<GiohangItem>();
            if (giohang != null)
            {
                list = (List<GiohangItem>)giohang;
            }

            return PartialView(list);
        }
        public ActionResult Footer()   //hàm gọi footer
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
    }
}