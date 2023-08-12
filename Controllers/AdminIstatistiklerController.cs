using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;
namespace TechnoTool_WebApp.Controllers
{

   

    public class AdminIstatistiklerController : Controller
    {

        Context c = new Context();
        // GET: AdminIstatistikler
        public ActionResult Index()
        {
            //KULLANICI SAYISI
            var kullanicisayisi = c.Kullanicis.Count();
            ViewBag.kullanicisayisi = kullanicisayisi;

            //TOPLAM STOK SAYISI
            var toplamstok = c.Urunlers.Sum(x=>x.stok);
            ViewBag.toplamstok = toplamstok;

            //TOPLAM ÜRÜN SAYISI
            var toplamurun = c.Urunlers.Count();
            ViewBag.toplamurun = toplamurun;

            //TOPLAM KATEGORİ SAYISI
            var toplamkategori = c.Kategorilers.Count();
            ViewBag.toplamkategori = toplamkategori;

            //MARKA SAYISI(TABLODA *BİR SÜTUNDAN* DEĞER ÇEKECEĞİMİZ ZAMAN DİKKAT ET)
            var markasayisi = (from x in c.Urunlers select x.marka).Distinct().Count().ToString();
            ViewBag.markasayisi = markasayisi;

            //STOKTAKİ LAPTOP SAYISI
            var laptopsayisi = c.Urunlers.Where(x => x.kategoriid == 1).Sum(x => x.stok);
            ViewBag.laptopsayisi = laptopsayisi;

            //STOKTAKİ MASAÜSTÜ BİLGİSAYAR SAYISI
            var masaustusayisi = c.Urunlers.Where(x => x.kategoriid == 2).Sum(x => x.stok);
            ViewBag.masaustusayisi = masaustusayisi;

            //STOKTAKİ ANAKART SAYISI
            var anakartsayisi = c.Urunlers.Where(x => x.kategoriid == 3).Sum(x => x.stok);
            ViewBag.anakartsayisi = anakartsayisi;

            //STOKTAKİ İŞLEMCİ SAYISI
            var islemcisayisi = c.Urunlers.Where(x => x.kategoriid == 4).Sum(x => x.stok);
            ViewBag.islemcisayisi = islemcisayisi;

            //STOKTAKİ MONİTÖR SAYISI
            var monitorsayisi = c.Urunlers.Where(x => x.kategoriid == 5).Sum(x => x.stok);
            ViewBag.monitorsayisi = monitorsayisi;

            //STOKTAKİ MOUSE SAYISI
            var mousesayisi = c.Urunlers.Where(x => x.kategoriid == 7).Sum(x => x.stok);
            ViewBag.mousesayisi = mousesayisi;

            //STOKTAKİ MOUSEPAD SAYISI
            var mousepadsayisi = c.Urunlers.Where(x => x.kategoriid == 8).Sum(x => x.stok);
            ViewBag.mousepadsayisi = mousepadsayisi;

            //STOKTAKİ KULAKLIK SAYISI
            var kulakliksayisi = c.Urunlers.Where(x => x.kategoriid == 11).Sum(x => x.stok);
            ViewBag.kulakliksayisi = kulakliksayisi;

            //MAX FİYATLI ÜRÜN
            var maxfiyaturun = (from x in c.Urunlers orderby x.satisfiyat descending select x.urunad).FirstOrDefault();
            var maxfiyat = (from x in c.Urunlers orderby x.satisfiyat descending select x.satisfiyat).FirstOrDefault();
            ViewBag.maxfiyaturun = maxfiyaturun;
            ViewBag.maxfiyat = maxfiyat;

            //MİN FİYAT
            var minfiyaturun = (from x in c.Urunlers orderby x.satisfiyat ascending select x.urunad).FirstOrDefault();
            var minfiyat = (from x in c.Urunlers orderby x.satisfiyat ascending select x.satisfiyat).FirstOrDefault();
            ViewBag.minfiyaturun = minfiyaturun;
            ViewBag.minfiyat = minfiyat;

            //**İSMİ EN FAZLA GEÇEN MARKA**
            var maxmarka = c.Urunlers.GroupBy(x => x.marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.maxmarka = maxmarka;

            return View();
        }
    }
}