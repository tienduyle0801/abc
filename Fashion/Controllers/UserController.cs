using BotDetect.Web.Mvc;
using Facebook;
using Fashion.Common;
using Fashion.Models;
using MyDb.Dao;
using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Fashion.Controllers
{

    public class UserController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback"); //gọi tới fb để lấy về.
                return uriBuilder.Uri;
            }
        }
        // GET: User
        [HttpGet]
        public ActionResult DangKy()   //Đăng ký cho User
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()   //Đăng ký cho User
        {
            return View();
        }
        public ActionResult LoginFb()  // đăng nhập bằng Facebook
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {   //truyền vào 2 biến đã cofig ở web.config
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var user = new User();
                user.Email = email;
                user.UserName = email;
                user.Status = true;
                user.Name = firstname + " " + middlename + " " + lastname;
                user.CreatedDate = DateTime.Now;
                var ktThem = new UserDao().ThemForFb(user);
                if (ktThem > 0)
                {
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserId = user.Id;
                    Session.Add(CommonParams.USER_SESSION, userSession);
                }
            }
            return Redirect("/");
        }
        public ActionResult DangXuat()  //Đăng Xuất cho User
        {
            Session[CommonParams.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult DangNhap(DangnhapModel model)  //Đăng nhập cho User
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var kt = dao.Login(model.UserName, Mahoa.MD5Hash(model.Password));
                if (kt == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserId = user.Id;
                    Session.Add(CommonParams.USER_SESSION, userSession);
                    return Redirect("/");
                }
                else if (kt == 0)
                {
                    ModelState.AddModelError("", "Tài Khoản Không Tồn Tại.");
                }
                else if (kt == -1)
                {
                    ModelState.AddModelError("", "Tài Khoản Bị Khóa.");
                }
                else if (kt == -2)
                {
                    ModelState.AddModelError("", "Mật Khẩu Không Đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng Nhập Không Đúng.");
                }
            }
            return View(model);
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "dangkyCapcha", "Mã Xác Nhận Không Đúng!")]
        public ActionResult DangKy(DangkyModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.ktUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên Đăng Nhập Đã Tồn Tại");
                }
                else if (dao.ktEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email Đã Tồn Tại");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Name = model.Name;
                    user.Password = Mahoa.MD5Hash(model.Password);
                    user.Sdt = model.Sdt;
                    user.Email = model.Email;
                    user.DiaChi = model.Diachi;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    if (!string.IsNullOrEmpty(model.ProvinceId))
                    {
                        user.ProvinceId = int.Parse(model.ProvinceId);
                    }
                    if (!string.IsNullOrEmpty(model.DistrictId))
                    {
                        user.DistrictId = int.Parse(model.DistrictId);
                    }

                    var kt = dao.Them(user);
                    if (kt > 0)
                    {
                        ViewBag.thanhcong = "Đăng Ký Thành Công";
                        model = new DangkyModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng Ký Không Thành Công");
                    }
                }
            }
            return View(model);
        }
   }
}