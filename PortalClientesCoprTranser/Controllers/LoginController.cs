using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalClientesCoprTranser.Models.administracion;
using System.Web.Security;


namespace PortalClientesCoprTranser.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            ViewBag.Title = "Autenticación";
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel avm, string ReturnUrl)
        {
            ViewBag.Title = "Autenticación";
            AccountModel am = new AccountModel();
            if (string.IsNullOrEmpty(avm.Account.EMAIL) || string.IsNullOrEmpty(avm.Account.CONTRASEÑA_ACTUAL) || am.Login(avm) == null)//Variables nullas o credenciales no validas
            {
                ModelState.AddModelError("ErrorLogin", "Usuario o contraseña son incorrectos.");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(avm.Account.EMAIL, true);
                if (ReturnUrl == null)
                {
                    return Redirect("/Clientes/");
                }
                else
                {
                    return Redirect(ReturnUrl);
                }
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Clientes/Login/Login");
        }

    }
}
