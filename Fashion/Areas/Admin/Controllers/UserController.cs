using Fashion.Common;
using MyDb.Dao;
using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Fashion.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User


        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            // phân trang cho User
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user) // thêm mới 1 user
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var mahoaMD5 = Mahoa.MD5Hash(user.Password);  // mã hóa pass
                user.Password = mahoaMD5;

                long id = dao.Them(user);
                if (id > 0)
                {
                    SetAlert("Thêm User Thành Công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm User Không Thành Công");
                }
            }
            return View("Index");
        }
        [HttpPost]

        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var mahoaMD5 = Mahoa.MD5Hash(user.Password);
                    user.Password = mahoaMD5;
                }


                var kiemtra = dao.Update(user);
                if (kiemtra)
                {
                   SetAlert("Cập Nhật User Thành Công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật User Không Thành Công");
                }
            }
            return View("Index");
        }
        [HttpDelete]

        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)  // chọn 1 cái trạng thái kích hoạt cho User hoặc ko kích hoạt
        {
            var kiemtra = new UserDao().ChangeStatus(id);
            return Json(new
            {
               status = kiemtra
            });
        }
    }
}