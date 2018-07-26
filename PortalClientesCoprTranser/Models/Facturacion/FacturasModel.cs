using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalClientesCoprTranser.Models.model_DB;
using System.Data;

namespace PortalClientesCoprTranser.Models.Facturacion
{
    public class FacturasModel
    {
        public List<Facturas> ListFactPendientes()
        {
            try
            {
                List<Facturas> _ListFactPendientes = new List<Facturas>();
                PROC_CLEINTES_DB pros = new PROC_CLEINTES_DB();
                DataTable dt = new DataTable();
                dt = pros.FACT_PENDIENTE();
                _ListFactPendientes = (from DataRow dr in dt.Rows
                                       select new Facturas()
                                       {
                                           FACTURA = dr["FACTURA"].ToString(),
                                           NOMCLIENTE = dr["NOMCLIENTE"].ToString(),
                                           FECEMITE = dr["FECEMITE"].ToString(),
                                           FECVENCE = dr["FECVENCE"].ToString(),
                                           VALOR_FACT = int.Parse(dr["VALOR"].ToString())
                                       }).ToList();
                return _ListFactPendientes;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
        }

        public List<Facturas> ListFactPendientes(string _FecIni, string _FecFin)
        {
            try
            {
                List<Facturas> _ListFactPendientes = new List<Facturas>();
                PROC_CLEINTES_DB pros = new PROC_CLEINTES_DB();
                DataTable dt = new DataTable();
                dt = pros.FACT_HISTORICO(_FecIni, _FecFin);
                _ListFactPendientes = (from DataRow dr in dt.Rows
                                       select new Facturas()
                                       {
                                           FACTURA = dr["FACTURA"].ToString(),
                                           NOMCLIENTE = dr["NOMCLIENTE"].ToString(),
                                           FECEMITE = dr["FECEMITE"].ToString(),
                                           FECVENCE = dr["FECVENCE"].ToString(),
                                           VALOR_FACT = int.Parse(dr["VALOR"].ToString())
                                       }).ToList();
                return _ListFactPendientes;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }

        }


        public List<Facturas> ListFactVencidas()
        {
            try
            {
                List<Facturas> _ListFactVencidas = new List<Facturas>();
                PROC_CLEINTES_DB pros = new PROC_CLEINTES_DB();
                DataTable dt = new DataTable();
                dt = pros.FACT_VENCIDA();
                _ListFactVencidas = (from DataRow dr in dt.Rows
                                     select new Facturas()
                                     {
                                         FACTURA = dr["FACTURA"].ToString(),
                                         NOMCLIENTE = dr["NOMCLIENTE"].ToString(),
                                         FECEMITE = dr["FECEMITE"].ToString(),
                                         FECVENCE = dr["FECVENCE"].ToString(),
                                         VALOR_FACT = int.Parse(dr["VALOR"].ToString())
                                     }).ToList();
                return _ListFactVencidas;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
        }

        public List<Facturas> ListestCartera()
        {
            try
            {
                List<Facturas> _ListEstCartera = new List<Facturas>();
                PROC_CLEINTES_DB pros = new PROC_CLEINTES_DB();
                DataTable dt = new DataTable();
                dt = pros.FACT_EST_CARTERA();
                _ListEstCartera = (from DataRow dr in dt.Rows
                                   select new Facturas()
                                   {
                                       FACTURA = dr["FACTURA"].ToString(),
                                       CODCLIENTE = int.Parse(dr["CODCLIENTE"].ToString()),
                                       FECEMITE = dr["FECEMITE"].ToString(),
                                       FECVENCE = dr["FECVENCE"].ToString(),
                                       VALOR_FACT = int.Parse(dr["VALOR"].ToString()),
                                       ABONOS = dr["ABONOS"].ToString(),
                                       SALD_ACTUAL = dr["SALDOACTUAL"].ToString(),
                                       CORRIENTE = dr["CORRIENTE"].ToString(),
                                       MES1 = dr["MES1"].ToString(),
                                       MES2 = dr["MES2"].ToString(),
                                       MES3 = dr["MES3"].ToString(),
                                       MES4 = dr["MES4"].ToString()
                                   }).ToList();
                return _ListEstCartera;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
        }

        public List<Facturas> ListopeAño()
        {
            try
            {
                List<Facturas> _ListEstCartera = new List<Facturas>();
                PROC_CLEINTES_DB pros = new PROC_CLEINTES_DB();
                DataTable dt = new DataTable();
                dt = pros.FACT_ULT_AÑO();
                _ListEstCartera = (from DataRow dr in dt.Rows
                                   select new Facturas()
                                   {
                                       MES1 = dr["MES"].ToString(),
                                       VALOR = Int64.Parse(dr["VALOR"].ToString())
                                   }).ToList();
                return _ListEstCartera;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }

        }

        public List<Facturas> ListRepoOperacion()
        {
            try
            {
                List<Facturas> _ListEstCartera = new List<Facturas>();
                PROC_CLEINTES_DB pros = new PROC_CLEINTES_DB();
                DataTable dt = new DataTable();
                dt = pros.REP_OPERACION();
                _ListEstCartera = (from DataRow dr in dt.Rows
                                   select new Facturas()
                                   {
                                       VALOR = Int64.Parse(dr["VALOR"].ToString()),
                                       ABONOS = dr["ABONOS"].ToString(),
                                       SALD_ACTUAL = dr["SALDOACTUAL"].ToString(),
                                       CORRIENTE = dr["CORRIENTE"].ToString(),
                                       MES1 = dr["MES1"].ToString(),
                                       MES2 = dr["MES2"].ToString(),
                                       MES3 = dr["MES3"].ToString(),
                                       MES4 = dr["MES4"].ToString()
                                   }).ToList();
                return _ListEstCartera;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }

        }

        public detCartera detCartera()
        {
            try
            {
                detCartera ct = new detCartera();
                List<Facturas> detFacturas = new List<Facturas>();
                PROC_CLEINTES_DB pros = new PROC_CLEINTES_DB();
                DataTable dt = new DataTable();
                dt = pros.DET_CARTERA();
                detFacturas = (from DataRow dr in dt.Rows
                               select new Facturas()
                               {
                                   CORRIENTE = dr["CORRIENTE"].ToString(),
                                   MES1 = dr["MES1"].ToString(),
                                   MES2 = dr["MES2"].ToString(),
                                   MES3 = dr["MES3"].ToString(),
                                   MES4 = dr["MES4"].ToString()
                               }).ToList();

                int contCorr = 0;
                double totalSumaCorr = 0;
                int contMes1 = 0;
                double totalSumaMes1 = 0;
                int contMes2 = 0;
                double totalSumaMes2 = 0;
                int contMes3 = 0;
                double totalSumaMes3 = 0;
                int contMes4 = 0;
                double totalSumaMes4 = 0;

                foreach (Facturas s in detFacturas)
                {
                    if (double.Parse(s.CORRIENTE) != 0)
                    {
                        totalSumaCorr += double.Parse(s.CORRIENTE);
                        contCorr++;
                    }
                    if (double.Parse(s.MES1) != 0)
                    {
                        totalSumaMes1 += double.Parse(s.MES1);
                        contMes1++;
                    }
                    if (double.Parse(s.MES2) != 0)
                    {
                        totalSumaMes2 += double.Parse(s.MES2);
                        contMes2++;
                    }
                    if (double.Parse(s.MES3) != 0)
                    {
                        totalSumaMes3 += double.Parse(s.MES3);
                        contMes3++;
                    }
                    if (double.Parse(s.MES4) != 0)
                    {
                        totalSumaMes4 += double.Parse(s.MES4);
                        contMes4++;
                    }
                }
                ct.TOTAL_CARTERA = (totalSumaCorr + totalSumaMes1 + totalSumaMes2 + totalSumaMes3 + totalSumaMes4);
                ct.TOTAL_FAC_CORRIENTE = contCorr;
                ct.SUMA_VALOR_CORRIENTE = totalSumaCorr;
                ct.TOTAL_FAC_MES1 = contMes1;
                ct.SUMA_VALOR_MES1 = totalSumaMes1;
                ct.TOTAL_FAC_MES2 = contMes2;
                ct.SUMA_VALOR_MES2 = totalSumaMes2;
                ct.TOTAL_FAC_MES3 = contMes3;
                ct.SUMA_VALOR_MES3 = totalSumaMes3;
                ct.TOTAL_FAC_MES4 = contMes4;
                ct.SUMA_VALOR_MES4 = totalSumaMes4;

                return ct;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        public detCartera minMax()
        {
            try
            {
                detCartera ct = new detCartera();
                PROC_CLEINTES_DB pros = new PROC_CLEINTES_DB();
                DataTable dt = new DataTable();
                dt = pros.minMax();
                ct = (from DataRow dr in dt.Rows
                               select new detCartera()
                               {
                                   MIN = double.Parse(dr["MINIMO"].ToString()),
                                   MAX = double.Parse(dr["MAXIMO"].ToString())
                               }).Single();

                return ct;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }
    }
}


