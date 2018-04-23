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
    public class BaseController : Controller
    {
        SaglikContext ent = new SaglikContext();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Repository<Kategori> repo = new Repository<Kategori>(ent);
            ViewBag.Kategoriler = repo.GetAll().ToList();
            base.OnActionExecuting(filterContext);
        }

    }
}