using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;


namespace TechnoTool_WebApp.Controllers
{
    
    public class AdminAyarlarController : Controller
    {
        Context c = new Context();

        // GET: AdminAyarlar
        public ActionResult Index()
        {

            return View();
        }

        public PartialViewResult Setting()
        {
            //LOGİNE GÖRE KİŞİYİ GETİR
            var username = (string)Session["username"];
            var id = c.Admins.Where(x => x.username == username).Select(y => y.ID).FirstOrDefault();
            var admindeger = c.Admins.Find(id);
            return PartialView("Setting",admindeger);
        }

        [HttpGet]
        public ActionResult AddProfile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProfile(Admin adm)
        {
            if (adm != null)
            {
                c.Admins.Add(adm);
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AddProfile");
            }
        }
       
        public ActionResult UpdateProfile(Admin adm)
        {
            var degerler = c.Admins.Find(adm.ID);
            degerler.username = adm.username;
            degerler.password = adm.password;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}