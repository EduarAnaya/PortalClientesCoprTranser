using PortalClientesCoprTranser.Models.administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalClientesCoprTranser.Controllers
{
    [Authorize]
    public class administracionController : Controller
    {
        public ActionResult CambioContraseña()
        {
            Account Account = new Account();
            Account.USUARIO = "BAVARIA";
            Account.EMAIL = "bavaria@bavaria.com";
            AccountViewModel AccountData = new AccountViewModel();
            AccountData.Account = Account;
            return View(AccountData);
        }
        [HttpPost]
        public ActionResult CambioContraseña(AccountViewModel avm)
        {
            Account Account = new Account();
            Account.USUARIO = "BAVARIA";
            Account.EMAIL = "bavaria@bavaria.com";
            Account.CONTRASEÑA_ACTUAL = "bavaria";

            if (avm.Account.CONTRASEÑA_ACTUAL != Account.CONTRASEÑA_ACTUAL)
            {
                ModelState.AddModelError("_Contraseña", "La contraseña actual es inválida");
                return View(avm);
            }
            else
            {
                return View();
            }
        }

    }
}
