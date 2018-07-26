using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientesCoprTranser.Models.Viajes
{
    public class Viajes
    {
        public int ORDEN { get; set; }
        public string PLANILLA { get; set; }
        public string DT { get; set; }
        public string FECHA { get; set; }
        public string VEHICULO { get; set; }
        public string TRAILER { get; set; }
        public int CEDCONDUCTOR { get; set; }
        public string CIUORIGEN { get; set; }
        public string CIUDESTINO { get; set; }
        public string TIEMPOCAR { get; set; }
        public string TIEMPODES { get; set; }
        public string NOMB_CONDUCTOR { get; set; }
        public string APELL_CONDUCTOR { get; set; }
        public string NOMPRODUCT { get; set; }
    }

    public class detPosViajes
    {
        public DateTime FECHA { get; set; }
        public string UBICACION { get; set; }
    }
}