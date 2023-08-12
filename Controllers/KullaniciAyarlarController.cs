using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;


namespace TechnoTool_WebApp.Controllers
{
    public class KullaniciAyarlarController : Controller
    {
        Context c = new Context();

        // GET: KullaniciAyarlar
        public ActionResult Index()
        {

            return View();
        }



        public PartialViewResult Setting()
        {
     

            //logine göre kullanıcı verilerini taşı
            var mail = (string)Session["Mail"];
            var id = c.Kullanicis.Where(x => x.Mail == mail).Select(y => y.Kullanicid).FirstOrDefault();
            var kullanicideger = c.Kullanicis.Find(id);
            return PartialView("Setting", kullanicideger);
        }


        public ActionResult UpdateProfile(Kullanici k)
        {
            
            var degerler = c.Kullanicis.Find(k.Kullanicid);
            degerler.KullaniciAdi = k.KullaniciAdi;
            degerler.KullaniciSoyadi = k.KullaniciSoyadi;
            degerler.telefon = k.telefon;
            degerler.Mail = k.Mail;
            degerler.Sifre = k.Sifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

     
    }
}