using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;

namespace TechnoTool_WebApp.Controllers
{
    public class KatalogController : Controller
    {

        Context c = new Context();
        // GET: Katalog
        public ActionResult Index()
        {
            var degerler = c.Urunlers.ToList();
            return View(degerler);
        }
    }
}