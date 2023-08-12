using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoTool_WebApp.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int faturaid { get; set; }
  
        public int urunid { get; set; }
        public virtual Urunler urun { get; set; }
        public int adet { get; set; }
        public decimal fiyat { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string saat { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 karakter kullanabilirsin !")]
        public string teslimEden { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 karakter kullanabilirsin !")]
        public string teslimAlan { get; set; }

        public decimal toplam { get; set; }

    }
}