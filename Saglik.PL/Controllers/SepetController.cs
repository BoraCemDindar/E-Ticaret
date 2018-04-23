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
    public class SepetController : BaseController
    {
        SaglikContext ent = new SaglikContext();
        public ActionResult Index()
        {
            List<cSepet> sepet = cSepet.SepetAl();
            return View(sepet);
        }
        public ActionResult SepeteEkle(string ID, string Adet)
        {
            Repository<Urun> repo = new Repository<Urun>(ent);
            Urun u = repo.Sec(Convert.ToInt32(ID));
            cSepet siparis = new cSepet();
            siparis.urunid = u.ID;
            siparis.urunad = u.UrunAdi;
            siparis.adet = Convert.ToInt32(Adet);
            siparis.fiyat = u.UrunFiyat;
            siparis.tutar = siparis.adet * siparis.fiyat;
            List<cSepet> sepet = cSepet.SepetAl();
            siparis.SepeteEkle(sepet, siparis);
            return View("SepetYenile");
        }
        public ActionResult SepetYenile()
        {
            return View();
        }
        public ActionResult SepettenSil(int ID)
        {
            List<cSepet> sepet = cSepet.SepetAl();
            cSepet siparis = sepet.Where(s => s.urunid == ID).FirstOrDefault();
            siparis.SepettenSil(sepet, siparis);
            sepet = cSepet.SepetAl();
            return View("SepettenSil", sepet);
        }
    }
}