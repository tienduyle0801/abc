using MyDb.Dao;
using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Controllers
{
    public class LienheController : Controller
    {
        // GET: Lienhe
        public ActionResult Index()
        {
            var model = new LienheDao().GetLH();
            return View(model);
        }
        [HttpPost]
        public JsonResult Send(string name, string sdt, string diachi, string email, string tintuc)
        {
            var ph = new PhanHoi();
            ph.Name = name;
            ph.Email = email;
            ph.CreatedDate = DateTime.Now;
            ph.Sodt = sdt;
            ph.Content = tintuc;
            ph.DiaChi = diachi;

            var id = new LienheDao().ThemPH(ph);
            if (id > 0)
                return Json(new
                {
                    status = true
                });
            else
                return Json(new
                {
                    status = false
                });
        }
    }
}