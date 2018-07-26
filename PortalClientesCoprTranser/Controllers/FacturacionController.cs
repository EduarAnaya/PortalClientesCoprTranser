using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalClientesCoprTranser.Models.Facturacion;

namespace PortalClientesCoprTranser.Controllers
{
    [Authorize]
    public class FacturacionController : Controller
    {
        public ActionResult Pendientes()
        {
            try
            {
                FacturasModel fm = new FacturasModel();
                return View(fm.ListFactPendientes());
            }
            catch (Exception Exc)
            {
                ModelState.AddModelError("Error", Exc);
                return View();
            }

        }

        public ActionResult Vencidas()
        {
            try
            {
                FacturasModel fm = new FacturasModel();
                return View(fm.ListFactVencidas());
            }
            catch (Exception Exc)
            {
                ModelState.AddModelError("Error", Exc);
                return View();
            }
        }

        public ActionResult Estcartera()
        {
            try
            {
                FacturasModel fm = new FacturasModel();
                return View(fm.ListestCartera());
            }
            catch (Exception Exc)
            {
                ModelState.AddModelError("Error", Exc);
                return View();
            }
        }

        public ActionResult Histfacturas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchHistfacturas(string _FecIni, string _FecFin)
        {
            try
            {
                FacturasModel fm = new FacturasModel();
                return View(fm.ListFactPendientes(_FecIni, _FecFin));
            }
            catch (Exception Exc)
            {
                ModelState.AddModelError("Error", Exc);
                return View();
            }
        }

        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Client, NoStore = false)]
        public JsonResult estCarteraChart()
        {
            try
            {
                FacturasModel fm = new FacturasModel();
                return Json(fm.ListRepoOperacion(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        [OutputCache(Duration = 86400, Location = System.Web.UI.OutputCacheLocation.Client, NoStore = false)]
        public JsonResult opeAñoChart()
        {
            try
            {
                FacturasModel fm = new FacturasModel();
                return Json(fm.ListopeAño(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult detcartera()
        {
            FacturasModel fm = new FacturasModel();
            ViewBag.detCartera = fm.detCartera();
            return View();
        }

        public ActionResult minMax()
        {
            FacturasModel fm= new FacturasModel();
            ViewBag.minMax = fm.minMax();
            return View();
        }
    }
}
