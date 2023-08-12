using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;
namespace TechnoTool_WebApp.Controllers
{

    public class KullaniciAnaSayfaController : Controller
    {

        
        Context c = new Context();
        // GET: KullaniciAnaSayfa
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Baslik()
        {
            return PartialView();
        }

        public PartialViewResult Urunler()
        {
            var degerler = c.Urunlers.ToList();
            return PartialView(degerler);
        }
    }
}