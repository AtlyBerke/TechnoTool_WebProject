using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnoTool_WebApp.Models.Siniflar;
using PagedList;
using PagedList.Mvc;


namespace TechnoTool_WebApp.Controllers
{
    public class UrunController : Controller
    {

        Context c = new Context();
        

        //ÜRÜN LİSTESİ
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Urunlers.Where(x => x.Durum == true).ToList().ToPagedList(sayfa,10);
            return View(degerler);
        }

        public ActionResult UrunDetay(int id)
        {
            var degerler = c.Urunlers.Where(x => x.urunid == id).ToList();
            return View(degerler);
        }

        //ÜRÜN EKLE
        [HttpGet]
        public ActionResult YeniUrun()
        {


            List<SelectListItem> deger1 = (from x in c.Kategorilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriad,
                                               Value = x.kategoriid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urunler u)
        {


            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[i].FileName);
                    string dosyauzantisi = Path.GetExtension(Request.Files[i].FileName);
                    string yol = "~/Image/" + dosyaadi + dosyauzantisi;
                    Request.Files[i].SaveAs(Server.MapPath(yol));

                    switch (i)
                    {
                        case 0:
                            u.gorsel1 = "/Image/" + dosyaadi + dosyauzantisi;
                            break;
                        case 1:
                            u.gorsel2 = "/Image/" + dosyaadi + dosyauzantisi;
                            break;
                        case 2:
                            u.gorsel3 = "/Image/" + dosyaadi + dosyauzantisi;
                            break;
                        default:
                            // İstenilen miktarda görsele yer açmak için gerektiğinde bu alanı genişletebilirsiniz.
                            break;
                    }
                }
            }


            u.Durum = true;
            c.Urunlers.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        //ÜRÜN SİL(PASİF HALE GETİR)
        public ActionResult UrunSil(int id)
        {
            var degerler = c.Urunlers.Find(id);
            degerler.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        //IDYE GÖRE DEĞERLERİ BİR SAYFADAN DİĞERİNE TAŞIMA
        public ActionResult IdyegoreDegerTasi(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategorilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriad,
                                               Value = x.kategoriid.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            var degerler = c.Urunlers.Find(id);
            return View("IdyegoreDegerTasi", degerler);
        }

        //GÜNCELLE
        public ActionResult Guncelle(Urunler u)
        {
            var degerler = c.Urunlers.Find(u.urunid);

            if (Request.Files.Count > 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[i].FileName);
                    string dosyauzantisi = Path.GetExtension(Request.Files[i].FileName);
                    string yol = "~/Image/" + dosyaadi + dosyauzantisi;
                    Request.Files[i].SaveAs(Server.MapPath(yol));

                    switch (i)
                    {
                        case 0:
                            u.gorsel1 = "/Image/" + dosyaadi + dosyauzantisi;
                            degerler.gorsel1 = u.gorsel1;
                            break;
                        case 1:
                            u.gorsel2 = "/Image/" + dosyaadi + dosyauzantisi;
                            degerler.gorsel2 = u.gorsel2;
                            break;
                        case 2:
                            u.gorsel3 = "/Image/" + dosyaadi + dosyauzantisi;
                            degerler.gorsel3 = u.gorsel3;
                            break;
                        default:
                            // İstenilen miktarda görsele yer açmak için gerektiğinde bu alanı genişletebilirsiniz.
                            break;
                    }
                }
            }
            degerler.urunad = u.urunad;
            degerler.kategoriid = u.kategoriid;
            degerler.marka = u.marka;
            degerler.stok = u.stok;
            degerler.alisfiyat = u.alisfiyat;
            degerler.satisfiyat = u.satisfiyat;
            degerler.Durum = true;
            degerler.UrunAciklama = u.UrunAciklama;
 
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}