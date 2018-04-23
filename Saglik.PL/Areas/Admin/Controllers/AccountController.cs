using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Saglik.DAL.Context;
using Saglik.DAL.Identity;
using Saglik.PL.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Saglik.PL.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<AplicationRole> roleManager;
        public AccountController()
        {
            SaglikContext ent = new SaglikContext();
            UserStore<ApplicationUser> UserStore = new UserStore<ApplicationUser>(ent);
            userManager = new UserManager<ApplicationUser>(UserStore);
            RoleStore<AplicationRole> roleStore = new RoleStore<AplicationRole>(ent);
            roleManager = new RoleManager<AplicationRole>(roleStore);

        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                IdentityResult iResult = userManager.Create(user, model.Paswword);
                if (iResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "User");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUser", "Kullanıcı Eklemede Hata!");
                }
            }
            return View(model);
        }
        public ActionResult Login()
        {
         
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = userManager.Find(model.UserName, model.Paswword);
                if (user!=null)
                {
                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authManager.SignIn(authProps, identity);
                    return RedirectToAction("");

                }
            }
            return View();
        }
        [Authorize]
        public ActionResult LogOut()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index","Home");
        }
    }
}