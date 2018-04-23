namespace Saglik.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AltKategoriler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AltKategoriAdi = c.String(nullable: false, maxLength: 50),
                        KategoriID = c.Int(),
                        Aciklama = c.String(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriID)
                .Index(t => t.KategoriID);
            
            CreateTable(
                "dbo.Kategoriler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 50),
                        Aciklama = c.String(),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Musteriler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 30),
                        Soyad = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        Sifre = c.String(nullable: false, maxLength: 20),
                        Tarih = c.DateTime(nullable: false),
                        TCKimlikNo = c.String(maxLength: 11),
                        Telefon = c.String(maxLength: 30),
                        Adres = c.String(),
                        Ilce = c.String(maxLength: 30),
                        Il = c.String(maxLength: 30),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Satislar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        MusteriID = c.Int(nullable: false),
                        ToplamMiktar = c.Int(nullable: false),
                        ToplamTutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TeslimTarihi = c.DateTime(nullable: false),
                        Durumu = c.Byte(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Musteriler", t => t.MusteriID, cascadeDelete: true)
                .Index(t => t.MusteriID);
            
            CreateTable(
                "dbo.SatisDetaylar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SatisID = c.Int(nullable: false),
                        UrunID = c.Int(nullable: false),
                        Adet = c.Int(nullable: false),
                        BirimFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tutar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Satislar", t => t.SatisID, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.UrunID, cascadeDelete: true)
                .Index(t => t.SatisID)
                .Index(t => t.UrunID);
            
            CreateTable(
                "dbo.Urunler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UrunKodu = c.String(nullable: false, maxLength: 20),
                        UrunAdi = c.String(nullable: false, maxLength: 50),
                        KategoriID = c.Int(),
                        AltKategoriID = c.Int(nullable: false),
                        Miktar = c.Int(nullable: false),
                        UrunFiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UrunBilgisi = c.String(),
                        UrunResimYolu1 = c.String(maxLength: 100),
                        UrunResimYolu2 = c.String(maxLength: 100),
                        Indirim = c.Boolean(nullable: false),
                        IndirimOrani = c.Int(nullable: false),
                        Silindi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AltKategoriler", t => t.AltKategoriID, cascadeDelete: true)
                .ForeignKey("dbo.Kategoriler", t => t.KategoriID)
                .Index(t => t.KategoriID)
                .Index(t => t.AltKategoriID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SatisDetaylar", "UrunID", "dbo.Urunler");
            DropForeignKey("dbo.Urunler", "KategoriID", "dbo.Kategoriler");
            DropForeignKey("dbo.Urunler", "AltKategoriID", "dbo.AltKategoriler");
            DropForeignKey("dbo.SatisDetaylar", "SatisID", "dbo.Satislar");
            DropForeignKey("dbo.Satislar", "MusteriID", "dbo.Musteriler");
            DropForeignKey("dbo.AltKategoriler", "KategoriID", "dbo.Kategoriler");
            DropIndex("dbo.Urunler", new[] { "AltKategoriID" });
            DropIndex("dbo.Urunler", new[] { "KategoriID" });
            DropIndex("dbo.SatisDetaylar", new[] { "UrunID" });
            DropIndex("dbo.SatisDetaylar", new[] { "SatisID" });
            DropIndex("dbo.Satislar", new[] { "MusteriID" });
            DropIndex("dbo.AltKategoriler", new[] { "KategoriID" });
            DropTable("dbo.Urunler");
            DropTable("dbo.SatisDetaylar");
            DropTable("dbo.Satislar");
            DropTable("dbo.Musteriler");
            DropTable("dbo.Kategoriler");
            DropTable("dbo.AltKategoriler");
        }
    }
}
