
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;
using PagedList;
using PagedList.Mvc;


namespace TechnoTool_WebApp.Controllers
{
    public class AdminKullaniciController : Controller
    {
        Context c = new Context();
        // GET: AdminKullanici
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kullanicis.Where(x=>x.durum==true).ToList().ToPagedList(sayfa,10);
            return View(degerler);
        }

        public ActionResult KullaniciSil(int id)
        {
            var degerler = c.Kullanicis.Find(id);
            degerler.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}