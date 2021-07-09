using MyDb.Dao;
using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fashion.Areas.Admin.Controllers
{
    public class TinTucController : BaseController
    {
        // GET: Admin/TinTuc
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new TintucDao();
            var tintuc = dao.GetById(id);

            SetViewBag(tintuc.DanhmucId);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(TinTuc model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag(model.DanhmucId);
            return View();
        }
        [HttpPost]
        public ActionResult Create(TinTuc model)
        {  
            if(ModelState.IsValid)
            {

            }
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? chonId = null)
        {
            var dao = new DanhmucDao();
            ViewBag.DanhmucId = new SelectList(dao.ListAll(), "Id", "Name",chonId);

        }
    }
}