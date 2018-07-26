using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PortalClientesCoprTranser.Models.model_DB;


namespace PortalClientesCoprTranser.Models.Viajes
{
    public class ViajesModel
    {
        //ConsultarViajes actuales
        public List<Viajes> _LoadList()
        {
            List<Viajes> _ListaViajesCurso = new List<Viajes>();
            PROC_CLEINTES_DB proc = new PROC_CLEINTES_DB();
            DataTable dt = new DataTable();
            dt = proc.VIAJ_CURSO();
            _ListaViajesCurso = (from DataRow dr in dt.Rows
                                 select new Viajes()
                                 {
                                     ORDEN = int.Parse(dr["ORDEN"].ToString()),
                                     PLANILLA = dr["PLANILLA"].ToString(),
                                     FECHA = dr["FECHA"].ToString(),
                                     VEHICULO = dr["VEHICULO"].ToString(),
                                     CIUORIGEN = dr["CIUORIGEN"].ToString(),
                                     CIUDESTINO = dr["CIUDESTINO"].ToString(),
                                     NOMB_CONDUCTOR = dr["NOMCONDUCTOR"].ToString(),
                                     APELL_CONDUCTOR = dr["APECONDUCTOR"].ToString(),
                                     NOMPRODUCT = dr["NOMPRODUCTO"].ToString()
                                 }).ToList();


            return _ListaViajesCurso;
        }
        //consulta de detalles del viaje
        public Viajes detViaje(string _OrcaNro)
        {
            DataTable dt = new DataTable();
            Viajes detViaje = new Viajes();
            PROC_CLEINTES_DB proc = new PROC_CLEINTES_DB();
            dt = proc.VIAJ_CURSO_DET(_OrcaNro);

            detViaje = (from DataRow dr in dt.Rows
                        select new Viajes()
                        {
                            DT = dr["DT"].ToString(),
                            TRAILER = dr["TRAILER"].ToString(),
                            CEDCONDUCTOR = int.Parse(dr["CEDCONDUCTOR"].ToString()),
                            TIEMPOCAR = dr["TIEMPOCAR"].ToString(),
                            TIEMPODES = dr["TIEMPODES"].ToString()
                        }).Single();
            return detViaje;
        }

        public List<Viajes> _LoadListHistorico(string _FecIni, string _FecFin)
        {
            List<Viajes> _ListaViajesCurso = new List<Viajes>();
            PROC_CLEINTES_DB proc = new PROC_CLEINTES_DB();
            DataTable dt = new DataTable();
            dt = proc.HISTO_VIAJES(_FecIni, _FecFin);
            _ListaViajesCurso = (from DataRow dr in dt.Rows
                                 select new Viajes()
                                 {
                                     ORDEN = int.Parse(dr["ORDEN"].ToString()),
                                     PLANILLA = dr["PLANILLA"].ToString(),
                                     FECHA = dr["FECHA"].ToString(),
                                     VEHICULO = dr["VEHICULO"].ToString(),
                                     CIUORIGEN = dr["CIUORIGEN"].ToString(),
                                     CIUDESTINO = dr["CIUDESTINO"].ToString(),
                                     NOMB_CONDUCTOR = dr["NOMCONDUCTOR"].ToString(),
                                     APELL_CONDUCTOR = dr["APECONDUCTOR"].ToString(),
                                     NOMPRODUCT = dr["NOMPRODUCTO"].ToString()
                                 }).ToList();


            return _ListaViajesCurso;
        }

    }
}