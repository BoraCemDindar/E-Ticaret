using Saglik.DAL.Context;
using Saglik.DAL.Repositories;
using Saglik.Domain.Core;
using Saglik.PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saglik.PL.Controllers
{
    public class MusteriController : BaseController
    {
        SaglikContext ent = new SaglikContext();
        public ActionResult MusteriGiris()
        {
            return View();
        }
        [HttpPost]
        public string MusteriGiris(string Email, string Sifre)
        {
            Repository<Musteri> repo = new Repository<Musteri>(ent);
            Musteri musteri = repo.Get(m => m.Email == Email && m.Sifre == Sifre);
            if (musteri == null)
            {
                return "Hatalı email yada şifre girişi!";
            }
            Session["uye"] = musteri;
            return "Hoşgeldiniz...<script type='text/javascript'>setTimeout(function(){window.location='/Musteri/AdresOnay'}, 3000);</script>";
        }
        public ActionResult MusteriKayit()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MusteriKayit(Musteri model)
        {
            Repository<Musteri> repo = new Repository<Musteri>(ent);
            if (ModelState.IsValid) 
            {
                Musteri yeni = new Musteri();
                yeni.Ad = model.Ad;
                yeni.Soyad = model.Soyad;
                yeni.Email = model.Email;
                yeni.Sifre = model.Sifre;
                yeni.SifreTekrar = model.SifreTekrar;
                yeni.Tarih = DateTime.Now;
                yeni.TCKimlikNo = model.TCKimlikNo;
                yeni.Telefon = model.Telefon;
                yeni.Adres = model.Adres;
                yeni.Ilce = model.Ilce;
                yeni.Il = model.Il;
                yeni.Silindi = false;
                if (repo.Ekle(yeni))
                    return RedirectToAction("MusteriGiris");
            }
            return View();
        }
        public ActionResult AdresOnay()
        {
            if (Session["uye"] == null)
                return RedirectToAction("MusteriGiris");
            Musteri uye = (Musteri)Session["uye"];
            return View(uye);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdresOnay(Musteri model)
        {
            if (ModelState.IsValid)
            {
            }

            Repository<Satis> repoSatis = new Repository<Satis>(ent);
            Musteri uye = (Musteri)Session["uye"];
            Satis s = new Satis();
            s.Tarih = DateTime.Now;
            s.ToplamMiktar = Convert.ToInt32(Session["toplamadet"]);
            s.ToplamTutar = Convert.ToInt32(Session["toplamtutar"]);
            s.MusteriID = uye.ID;
            s.TeslimTarihi = DateTime.Now.AddDays(2);
            s.Durumu = (byte)cEnums.SatisDurumu.siparis;
            if (repoSatis.Ekle(s))
            {
                int SonSatisNo = s.ID; 
                Repository<SatisDetay> repoSatisDetay = new Repository<SatisDetay>(ent);
                List<cSepet> sepet = cSepet.SepetAl();
                SatisDetay sd;
                foreach (cSepet siparis in sepet)
                {
                    sd = new SatisDetay();
                    sd.SatisID = SonSatisNo;
                    sd.UrunID = siparis.urunid;
                    sd.Adet = siparis.adet;
                    sd.BirimFiyat = siparis.fiyat;
                    sd.Tutar = siparis.tutar;
                    repoSatisDetay.Ekle(sd);
                }
                Session.Remove("sepet"); 
                Session.Remove("toplamadet");
                Session.Remove("toplamtutar");
            }
            return RedirectToAction("OdemeOnay");
        }
        public ActionResult OdemeOnay()
        {
            return View();
        }
    }
}