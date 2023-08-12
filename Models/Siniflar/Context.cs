using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TechnoTool_WebApp.Models.Siniflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<Kullanici> Kullanicis { get; set; }

    }
}