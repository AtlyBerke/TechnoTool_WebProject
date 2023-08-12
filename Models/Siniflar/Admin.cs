using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnoTool_WebApp.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(20,ErrorMessage ="En Fazla 20 karakter kullanabilirsin !")]
        public string username { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(20, ErrorMessage = "En Fazla 20 karakter kullanabilirsin !")]
        public string password { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2)]
        public string role { get; set; }
    }
}