using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDb.Entity;
using MyDb.Dao;
using Fashion.Areas.Admin.Models;
using Fashion.Common;

namespace Fashion.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var kiemtra = dao.Login(model.UserName, Mahoa.MD5Hash(model.Password));
                if (kiemtra == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserId = user.Id;


                    Session.Add(CommonParams.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (kiemtra == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (kiemtra == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (kiemtra == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
           
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View("Index");
        }

    }
}