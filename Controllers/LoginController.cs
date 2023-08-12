using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TechnoTool_WebApp.Models.Siniflar;
namespace TechnoTool_WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context c = new Context();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin adm1)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.username == adm1.username && x.password == adm1.password);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.username, false);
                Session["username"] = bilgiler.username.ToString();
                return RedirectToAction("Index", "AnaSayfa");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult KullaniciLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KullaniciLogin(Kullanici kullanici)
        {
            var bilgiler = c.Kullanicis.FirstOrDefault(x => x.Mail == kullanici.Mail && x.Sifre == kullanici.Sifre && x.durum==true);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("Index", "KullaniciAnaSayfa");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}