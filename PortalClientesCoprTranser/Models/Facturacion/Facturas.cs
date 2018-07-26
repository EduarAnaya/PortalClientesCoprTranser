using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientesCoprTranser.Models.Facturacion
{
    public partial class Facturas
    {
        public string FACTURA { get; set; }
        public int CODCLIENTE { get; set; }
        public string NOMCLIENTE { get; set; }
        public string FECEMITE { get; set; }
        public string FECVENCE { get; set; }
        public int VALOR_FACT { get; set; }
        public string ESTADO { get; set; }
    }
    //estado cartera
    public partial class Facturas
    {
        public Int64 VALOR { get; set; }
        public string ABONOS { get; set; }
        public string SALD_ACTUAL { get; set; }
        public string CORRIENTE { get; set; }
        public string MES1 { get; set; }
        public string MES2 { get; set; }
        public string MES3 { get; set; }
        public string MES4 { get; set; }
    }
    public class detCartera
    {
        public double TOTAL_CARTERA{ get; set; }
        public int TOTAL_FAC_CORRIENTE { get; set; }
        public double SUMA_VALOR_CORRIENTE { get; set; }
        public int TOTAL_FAC_MES1 { get; set; }
        public double SUMA_VALOR_MES1 { get; set; }
        public int TOTAL_FAC_MES2 { get; set; }
        public double SUMA_VALOR_MES2 { get; set; }
        public int TOTAL_FAC_MES3 { get; set; }
        public double SUMA_VALOR_MES3 { get; set; }
        public int TOTAL_FAC_MES4 { get; set; }
        public double SUMA_VALOR_MES4 { get; set; }
        public double MIN{ get; set; }
        public double MAX { get; set; }
    }
}