using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoTool_WebApp.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int mesajid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 karakter kullanabilirsin !")]
        public string gonderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 karakter kullanabilirsin !")]
        public string alici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En Fazla 50 karakter kullanabilirsin !")]
        public string konu { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string icerik { get; set; }

        [Column(TypeName = "Date")]
        public DateTime tarih { get; set; }

        public bool Durum { get; set; }
    }
}