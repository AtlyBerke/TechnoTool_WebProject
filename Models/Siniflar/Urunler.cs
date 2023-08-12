using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoTool_WebApp.Models.Siniflar
{
    public class Urunler
    {
        [Key]
        public int urunid { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullanabilirsin !")]
        public string urunad { get; set; }

        public int kategoriid { get; set; }
        public virtual Kategoriler kategori { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter kullanabilirsin !")]
        public string marka { get; set; }
        public int stok { get; set; }
        public decimal alisfiyat { get; set; }
        public decimal satisfiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(250)]
        public string gorsel1 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string gorsel2 { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string gorsel3 { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter kullanabilirsin !")]
        public string UrunAciklama { get; set; }
                           
        [Column(TypeName = "Varchar")]
        [StringLength(500,ErrorMessage = "En fazla 500 karakter kullanabilirsin !")]
        public string UrunOzellikler { get; set; }

        public ICollection<Faturalar> Faturalars { get; set; }
    }
}