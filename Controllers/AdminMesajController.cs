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
    
    public class AdminMesajController : Controller
    {
        Context c = new Context();

        //TÜM MESAJLAR
        public ActionResult Index(int sayfa=1)
        {
           
            var degerler = c.Mesajlars.OrderByDescending(x => x.mesajid).ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult MesajEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MesajEkle(Mesajlar m)
        {
            //String Sessionla kullanıcı adını kullanabilirdim ama adminden geldiğini bilmesini istedim.
            var username = (string)Session["username"];
            m.gonderici = username;
            m.Durum = true;
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MesajOkundu(int id)
        {
            var degerler = c.Mesajlars.Find(id);
            degerler.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GelenMesajlar()
        {
            var username = (string)Session["username"];
            var mesajlar = c.Mesajlars.Where(x => x.alici == username && x.Durum==true).OrderByDescending(y => y.mesajid).ToList();
            return View(mesajlar);
        }

        public ActionResult OkunanMesajlar()
        {
            var username = (string)Session["username"];
            var mesajlar = c.Mesajlars.Where(x => x.alici == username && x.Durum == false).OrderByDescending(y => y.mesajid).ToList();
            return View(mesajlar);
        }

        public ActionResult GonderilenMesajlar()
        {
            var username = (string)Session["username"];
            var mesajlar = c.Mesajlars.Where(x => x.gonderici == username).OrderByDescending(y => y.mesajid).ToList();
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mesajdetay = c.Mesajlars.Find(id);
            return View(mesajdetay);
        }

        public ActionResult GelenMesajDetay(int id)
        {
            var mesajdetay = c.Mesajlars.Where(x=>x.mesajid==id).ToList();
            return View(mesajdetay);
        }

     

    }
}