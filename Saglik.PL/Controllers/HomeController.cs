using Saglik.DAL.Context;
using Saglik.DAL.Repositories;
using Saglik.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saglik.PL.Controllers
{
    public class HomeController : BaseController
    {
        SaglikContext ent = new SaglikContext();
        public ActionResult Index(int? katid, int?altkatid)
        {
            ViewBag.KatID = katid;
            ViewBag.AltKatID = altkatid;
            
            return View();
        }
        public ActionResult UrunlerBy(int? katid, int? altkatid)
        {
            Repository<Urun> repo = new Repository<Urun>(ent);
            List<Urun> liste = new List<Urun>();
            if(altkatid.HasValue)
                liste = repo.GetAll(u => u.AltKategoriID == altkatid).ToList();
            else
            {
                if (katid.HasValue)
                    liste = repo.GetAll(u => u.KategoriID == katid).ToList();
                else
                    liste = repo.GetAll().ToList();
            }

            return PartialView(liste);
        }
        public ActionResult UrunDetay(int id)
        {
            Repository<Urun> repo = new Repository<Urun>(ent);
            return View(repo.Sec(id));
        }
    }
}