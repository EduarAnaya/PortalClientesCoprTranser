using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalClientesCoprTranser.Models.Viajes;


namespace PortalClientesCoprTranser.Controllers
{
    [Authorize]
    public class ViajesController : Controller
    {

        [OutputCache(Duration = 360, Location = System.Web.UI.OutputCacheLocation.Client, NoStore = false)]
        public ActionResult ViajesCurso()
        {
            ViajesModel vm = new ViajesModel();
            List<Viajes> _listaViajesCurso = new List<Viajes>();
            _listaViajesCurso = vm._LoadList();
            return View(_listaViajesCurso);
        }

        [HttpPost]
        public ActionResult detViajesCurso(string nroOrca)
        {
            try
            {
                ViajesModel vm = new ViajesModel();
                Viajes _DetViajeCurso = new Viajes();
                _DetViajeCurso = vm.detViaje(nroOrca);
                ViewBag.detViaje = _DetViajeCurso;
                return View();
            }
            catch (Exception Exc)
            {
                ModelState.AddModelError("Error", Exc);
                return View();
            }
        }

        public ActionResult HistViajes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HistViajesSearch(string _FecIni, string _FecFin)
        {
            try
            {
                ViajesModel vm = new ViajesModel();
                List<Viajes> _listaViajesCurso = new List<Viajes>();
                _listaViajesCurso = vm._LoadListHistorico(_FecIni, _FecFin);
                return View(_listaViajesCurso);
            }
            catch (Exception Exc)
            {
                ModelState.AddModelError("Error", Exc);
                return View();
            }

        }

        public ActionResult loadMapa(string _orca)
        {
            return View();
        }
    }
}
