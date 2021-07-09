using Application;
using Fashion.Models;
using MyDb.Dao;
using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Fashion.Controllers
{
    public class GiohangController : Controller
    {
        private const string GiohangSession = "GIOHANG_SESSION";
        // GET: Giohang
        public ActionResult Index()
        {
            var giohang = Session[GiohangSession];
            var list = new List<GiohangItem>();
            if (giohang != null)
            {
                list = (List<GiohangItem>)giohang;
            }
            return View(list);
        }
        public JsonResult DeleteAll()    //xóa tất cả giỏ hàng
        {
            Session[GiohangSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)   //xóa 1 sản phẩm trong giỏ hàng
        {
            var sessionGIOHANG = (List<GiohangItem>)Session[GiohangSession];
            sessionGIOHANG.RemoveAll(x => x.SanPham.Id == id);
            Session[GiohangSession] = sessionGIOHANG;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string giohangModel)
        {
            var jsonGiohang = new JavaScriptSerializer().Deserialize<List<GiohangItem>>(giohangModel);
            var sessionGIOHANG = (List<GiohangItem>)Session[GiohangSession];

            foreach (var item in sessionGIOHANG)
            {
                var jsonItem = jsonGiohang.SingleOrDefault(x => x.SanPham.Id == item.SanPham.Id);
                if (jsonItem != null)
                {
                    item.Soluong = jsonItem.Soluong;
                }
            }
            Session[GiohangSession] = sessionGIOHANG;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult ThemItem(long sanphamId, int soluong)
        {
            var sanpham = new SanphamDao().ViewDetail(sanphamId);
            var giohang = Session[GiohangSession];
            if (giohang != null)    //nếu giỏ hàng khác null  tức là đã có trong giỏ hàng
            {
                var list = (List<GiohangItem>)giohang;
                if (list.Exists(x => x.SanPham.Id == sanphamId))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.Id == sanphamId)
                        {
                            item.Soluong += soluong;
                        }
                    }
                }
                else
                {
                    //tạo mới 1 đối tượng giỏ hàng
                    var item = new GiohangItem();
                    item.SanPham = sanpham;
                    item.Soluong = soluong;
                    list.Add(item);
                }
                //gán vào session
                Session[GiohangSession] = list;

            }
            else   //chưa có trong giỏ hàng
            {
                //tạo mới 1 đối tượng giỏ hàng
                var item = new GiohangItem();
                item.SanPham = sanpham;
                item.Soluong = soluong;
                var list = new List<GiohangItem>();
                list.Add(item);

                //gán vào session
                Session[GiohangSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Thanhtoan()   //hàm thanh toán
        {
            var giohang = Session[GiohangSession];
            var list = new List<GiohangItem>();
            if (giohang != null)
            {
                list = (List<GiohangItem>)giohang;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Thanhtoan(string nguoinhan, string sdt, string diachi, string email)   //hàm thanh toán
        {
            var dathang = new DatHang();
            dathang.CreatedDate = DateTime.Now;
            dathang.Shipdiachi = diachi;
            dathang.ShipMobile = sdt;
            dathang.ShipName = nguoinhan;
            dathang.ShipEmail = email;
            try
            {
                var id = new DathangDao().Them(dathang);
                var giohang = (List<GiohangItem>)Session[GiohangSession];
                var detailDao = new DathangDetailDao();
                decimal total = 0;
                foreach (var item in giohang)
                {
                    var dathangDetail = new DatHangDetail();
                    dathangDetail.SanphamId = item.SanPham.Id;
                    dathangDetail.DathangId = id;
                    dathangDetail.DonGia = item.SanPham.Gia;
                    dathangDetail.Soluong = item.Soluong;
                    detailDao.Them(dathangDetail);

                    total += (item.SanPham.Gia.GetValueOrDefault(0) * item.Soluong);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/chung/client/template/neworder.html"));

                content = content.Replace("{{CustomerName}}", nguoinhan);
                content = content.Replace("{{Phone}}", sdt);
                content = content.Replace("{{Email}}", email);
                content = content.Replace("{{Address}}", diachi);
                content = content.Replace("{{Total}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new Email().guiMail(email, "Đơn hàng mới từ Fashion Shop", content);
                new Email().guiMail(toEmail, "Đơn hàng mới từ Fashion Shop", content);
            }
            catch(Exception ex)
            {
                //hiển thị log
                return Redirect("/error-thanh-toan");
            }
            return Redirect("/thanh-cong");
        }
        public ActionResult Thanhcong()
        {
            return View();
        }
    }
}