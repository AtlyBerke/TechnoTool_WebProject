using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;
namespace TechnoTool_WebApp.Controllers
{
    public class KullaniciIletisimController : Controller
    {

        Context c = new Context();
        // GET: KullaniciIletisim
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult MesajGonder(Mesajlar m)
        {
            //Kullanıcının  mailini login ile alıp Mesajlar->gondericiye kaydetmek
            var mail = (string)Session["Mail"];
            var deger = c.Kullanicis.Where(x => x.Mail == mail).FirstOrDefault();
            m.gonderici = deger.Mail;

            m.alici = "admin";
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GonderilenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var deger = c.Kullanicis.Where(x => x.Mail == mail).FirstOrDefault();
            var mesajlar = c.Mesajlars.Where(x => x.gonderici == deger.Mail).ToList();
            return View(mesajlar);
        }

        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var deger = c.Kullanicis.Where(x => x.Mail == mail).FirstOrDefault();
            var mesajlar = c.Mesajlars.Where(x => x.alici == deger.Mail).ToList();
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mesajdetay = c.Mesajlars.Find(id);
            return View("MesajDetay",mesajdetay);

        }
      
    }
}