using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Saglik.PL.App_Start.Startup))]

namespace Saglik.PL.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Admin/Account/Login")
            });
        }
    }
}
