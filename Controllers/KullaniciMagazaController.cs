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
    public class KullaniciMagazaController : Controller
    {

        Context c = new Context();
        Class1 cs1 = new Class1();

        // GET: KullaniciMagaza
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Urunlers.ToList().ToPagedList(sayfa, 9);
            return View(degerler);   
        }

        public ActionResult SonUruneGoreListe()
        {
            var urun = c.Urunlers.OrderByDescending(x => x.urunid).ToList();
            return View(urun);
        }

        public PartialViewResult Filter()
        {

            cs1.kategori = c.Kategorilers.ToList();
            cs1.urun = c.Urunlers.ToList();
            return PartialView(cs1);
        }

        public ActionResult KategoriyeGoreUrunListe(int id)
        {
            cs1.urun = c.Urunlers.Where(x => x.kategoriid == id).ToList();
            return View(cs1);
        }

    }
}