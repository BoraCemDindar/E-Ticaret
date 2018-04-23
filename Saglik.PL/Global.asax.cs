using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Saglik.DAL.Context;
using Saglik.DAL.Identity;
using Saglik.PL.App_Start;
using Saglik.PL.App_Start.Blog.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Saglik.PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (SaglikContext ent = new SaglikContext())
            {
                ent.Database.CreateIfNotExists();
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Role Tanımlama Adımları
            SaglikContext db = new SaglikContext();
            RoleStore<AplicationRole> roleStore = new RoleStore<AplicationRole>(db);
            RoleManager<AplicationRole> roleManager = new RoleManager<AplicationRole>(roleStore);
            if (!roleManager.RoleExists("Admin"))
            {
                AplicationRole adminRole = new AplicationRole("Admin", "Sistem Yöneticisi");
                roleManager.Create(adminRole);
            }
            if (!roleManager.RoleExists("User"))
            {
                AplicationRole UserRole = new AplicationRole("User", "Sistem Kullanıcısı");
                roleManager.Create(UserRole);
            }

        }
    }
}
