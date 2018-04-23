using Microsoft.AspNet.Identity.EntityFramework;
using Saglik.DAL.Identity;
using Saglik.DAL.Migrations;
using Saglik.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.DAL.Context
{
    public class SaglikContext : IdentityDbContext<ApplicationUser>
    {
        public SaglikContext() : base("SaglikContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SaglikContext, Configuration>("SaglikContext"));   
        }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<AltKategori> AltKategoriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Satis> Satislar { get; set; }
        public virtual DbSet<SatisDetay> SatisDetaylar { get; set; }
        public virtual DbSet<Musteri> Musteriler { get; set; }

    }
}
