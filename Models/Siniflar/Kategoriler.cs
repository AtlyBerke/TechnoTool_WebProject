using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoTool_WebApp.Models.Siniflar
{
    public class Kategoriler
    {
        [Key]
        public int kategoriid { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Kategori Adını Girin")]
        public string kategoriad { get; set; }

        public ICollection<Urunler> Uruns { get; set; }
    }
}