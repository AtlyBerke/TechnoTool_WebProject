using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;

namespace TechnoTool_WebApp.Controllers
{
    public class UrunDetayController : Controller
    {

        Context c = new Context();

        // GET: UrunDetay
        public ActionResult Index(int id)
        {
            var degerler = c.Urunlers.Where(x => x.urunid == id).ToList();
            return View(degerler);
        }
    }
}