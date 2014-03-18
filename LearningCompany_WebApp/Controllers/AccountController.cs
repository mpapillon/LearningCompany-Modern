using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LearningCompany.Entities;

namespace LearningCompany.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if(Membership.ValidateUser(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("_FORM", "Nom d'utilisateur ou mot de passe incorrect0");
                return View();
            }
        }

        //
        // GET: /Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // On supprime le cookie de connexion
            return RedirectToAction("Index", "Home");
        }
	}
}