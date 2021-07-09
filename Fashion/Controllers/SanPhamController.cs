using MyDb.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult DanhmucSanpham()
        {
            var model = new DanhmucSanphamDao().ListAll();
            return PartialView(model);

        }
        public ActionResult Danhmuc(long dmId, int page= 1, int pageSize = 1)  //truyền ra view danhmuc, phân trang cho sản phẩm
        {
            var danhmuc = new DanhmucDao().ViewDetail(dmId);
            ViewBag.Danhmucs = danhmuc;
            int totalTong = 0;
            var model = new SanphamDao().ListByDanhmucId(dmId, ref totalTong, page, pageSize);

            ViewBag.Total = totalTong;
            ViewBag.Page = page;

            int maxPage = 5;  //số trang tối đa.
            int totalPage = 0; //tổng số trang mặt định 0;

            totalPage = (int)Math.Ceiling((double)(totalTong / pageSize));//làm tròn số trang.
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = maxPage;         // trang cuối cùng
            ViewBag.Next = page + 1;   //trang kế tiếp 
            ViewBag.Prev = page - 1;   // trang trước đó.
             
            return View(model);
        }
        public ActionResult Detail(long spid)   //hàm chi tiết sp , truyền ra view sản phẩm
        {
            var sanpham = new SanphamDao().ViewDetail(spid);
            ViewBag.Danhmucs = new DanhmucSanphamDao().ViewDetail(sanpham.DanhmucId.Value);
            ViewBag.Relatedsp = new SanphamDao().ListHotSanphams(spid);
            return View(sanpham);
        }
    }
}