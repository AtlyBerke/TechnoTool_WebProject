using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using TechnoTool_WebApp.Models.Siniflar;

namespace TechnoTool_WebApp.Controllers
{

    public class KategoriController : Controller
    {

        Context c = new Context();
        //KATEGORİ LİSTESİ
        public ActionResult Index()
        {
            var degerler = c.Kategorilers.ToList();
            return View(degerler);

        }


        //YENİ KATEGORİ
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(Kategoriler k)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            c.Kategorilers.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        //KATEGORİ SİL
        public ActionResult KategoriSil(int id)
        {
            var degerler = c.Kategorilers.Find(id);
            c.Kategorilers.Remove(degerler);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        ////IDYE GÖRE DEĞERLERİ BİR SAYFADAN DİĞERİNE TAŞIMA
        public ActionResult KategoriGetir(int id)
        {
            var degerler = c.Kategorilers.Find(id);
            return View("KategoriGetir", degerler);
        }


        public ActionResult KategoriGuncelle(Kategoriler k)
        {
            var degerler = c.Kategorilers.Find(k.kategoriid);
            degerler.kategoriad = k.kategoriad;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}