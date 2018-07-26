using PortalClientesCoprTranser.Models.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalClientesCoprTranser.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Ayuda()
        {
            ViewBag.title = "Ayuda";
            return View();
        }
        public ActionResult CambioContraseña()
        {
            return View();
        }


    }
}
