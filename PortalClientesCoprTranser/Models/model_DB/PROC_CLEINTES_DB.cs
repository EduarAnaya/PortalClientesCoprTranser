using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PortalClientesCoprTranser.Models.model_DB
{
    public class PROC_CLEINTES_DB
    {
        #region VIAJES
        /** 
         * 
         */
        public DataTable VIAJ_CURSO()
        {
            #region BLOQUE CONTROLADO

            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT ORDEN,PLANILLA,TO_CHAR(FECHA, 'dd/mm/yyyy') FECHA,VEHICULO,CIUORIGEN,CIUDESTINO,NOMCONDUCTOR,APECONDUCTOR ,NOMPRODUCTO FROM VIAJESWEB WHERE TRUNC(fecha) = TRUNC(sysdate) AND CODCLIENTE ='286' AND TIPOCARGA = 'A'";
                OracleCommand _Comando = new OracleCommand(select);
                dt = db.ExecuteSelect(_Comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion
        }

        public DataTable VIAJ_CURSO_DET(string _OrcaNro)
        {
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT DT,TRAILER,CEDCONDUCTOR,TO_CHAR(TIEMPOCAR,'dd/mm/yyyy') TIEMPOCAR,TO_CHAR(TIEMPODES,'dd/mm/yyyy') TIEMPODES FROM VIAJESWEB WHERE ORDEN='" + _OrcaNro + "'";
                OracleCommand _Comando = new OracleCommand(select);
                dt = db.ExecuteSelect(_Comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
        }

        public DataTable HISTO_VIAJES(string _FechIni, string _FecFin)
        {
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT ORDEN,PLANILLA,TO_CHAR(FECHA, 'yyyy-mm-dd') FECHA,VEHICULO,CIUORIGEN,CIUDESTINO,NOMCONDUCTOR,APECONDUCTOR,NOMPRODUCTO FROM VIAJESWEB WHERE TRUNC(fecha) >=to_date('" + _FechIni + "','yyyy-mm-dd') AND TRUNC(fecha) <=to_date('" + _FecFin + "','yyyy-mm-dd') AND CODCLIENTE ='286'";
                OracleCommand _Comando = new OracleCommand(select);
                dt = db.ExecuteSelect(_Comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
        }

        /** 
         *
         */
        #endregion

        #region FACTURACION
        /*
         * 
         */
        public DataTable FACT_PENDIENTE()
        {

            #region BLOQUE CONTROLADO
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT FACTURA,CODCLIENTE,NOMCLIENTE,TO_CHAR(FECEMITE, 'dd/mm/yyyy') FECEMITE,TO_CHAR(FECVENCE, 'dd/mm/yyyy') FECVENCE,VALOR,ESTADO FROM FACTURASWEB WHERE CODCLIENTE='286'AND ESTADO<>'T'";
                OracleCommand comando = new OracleCommand(select);
                dt = db.ExecuteSelect(comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion

        }

        public DataTable FACT_VENCIDA()
        {

            #region BLOQUE CONTROLADO
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT FACTURA,
  CODCLIENTE,
  NOMCLIENTE,
  TO_CHAR(FECEMITE, 'dd/mm/yyyy') FECEMITE,
  TO_CHAR(FECVENCE, 'dd/mm/yyyy') FECVENCE,
  VALOR,
  ESTADO
FROM FACTURASWEB
WHERE CODCLIENTE='286'
AND ESTADO      = 'V'";
                OracleCommand comando = new OracleCommand(select);
                dt = db.ExecuteSelect(comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion

        }

        public DataTable FACT_EST_CARTERA()
        {

            #region BLOQUE CONTROLADO
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT FACTURA,
  CODCLIENTE,
  TO_CHAR(FECEMITE, 'yyyy-mm-dd') FECEMITE,
  TO_CHAR(FECVENCE, 'yyyy-mm-dd') FECVENCE,
  VALOR VALOR,
  ABONOS ABONOS,
  (VALOR - ABONOS) SALDOACTUAL,
  DECODE(TIEMPO, 'CORR',(VALOR  -ABONOS),0) CORRIENTE,
  DECODE(TIEMPO, '0-30',(VALOR  -ABONOS),0) MES1,
  DECODE(TIEMPO, '30-60',(VALOR -ABONOS),0) MES2,
  DECODE(TIEMPO, '60-90',(VALOR -ABONOS),0) MES3,
  DECODE(TIEMPO, '91',(VALOR    -ABONOS),0) MES4
FROM
  (SELECT FACTURASWEB.FACTURA,
    CODCLIENTE,
    FECEMITE,
    FECVENCE,
    NVL(SUM(ABONO),0) ABONOS,
    VALOR,
    CASE
      WHEN (TRUNC(FECVENCE) >= TRUNC(SYSDATE))
      THEN 'CORR'
      WHEN (TRUNC(FECVENCE)                   < TRUNC(SYSDATE))
      AND (TRUNC(SYSDATE) - TRUNC(FECVENCE)) <= 30
      THEN '0-30'
      WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 31
      AND (TRUNC(SYSDATE)  - TRUNC(FECVENCE)) <= 60
      THEN '30-60'
      WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 60
      AND (TRUNC(SYSDATE)  - TRUNC(FECVENCE)) <= 90
      THEN '60-90'
      WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 90
      THEN '91'
      ELSE 'ERROR'
    END TIEMPO
  FROM FACTURASWEB,
    PAGOSFACWEB
  WHERE CODCLIENTE       = '286'
  AND ESTADO            <> 'T'
  AND FACTURASWEB.FACTURA=PAGOSFACWEB.FACTURA(+)
  GROUP BY FACTURASWEB.FACTURA,
    CODCLIENTE,
    FECEMITE,
    FECVENCE,
    VALOR
  ORDER BY FECEMITE
  )";
                OracleCommand comando = new OracleCommand(select);
                dt = db.ExecuteSelect(comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion

        }

        public DataTable FACT_HISTORICO(string _FecIni, string _FecFin)
        {

            #region BLOQUE CONTROLADO
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT FACTURA,
  CODCLIENTE,
  NOMCLIENTE,
  TO_CHAR(FECEMITE, 'dd/mm/yyyy') FECEMITE,
  TO_CHAR(FECVENCE, 'dd/mm/yyyy') FECVENCE,
  VALOR,
  DECODE(ESTADO,'P','PENDIENTE','V','VENCIDA','T','PAGADA') ESTADO
  FROM FACTURASWEB
  WHERE CODCLIENTE='286'
  AND TRUNC(FECEMITE)>=to_date('" + _FecIni + "','yyyy-mm-dd') AND TRUNC(FECEMITE)<=to_date('" + _FecFin + "','yyyy-mm-dd')";
                OracleCommand comando = new OracleCommand(select);
                dt = db.ExecuteSelect(comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion

        }

        public DataTable FACT_ULT_AÑO()
        {
            #region BLOQUE CONTROLADO
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT NVL(TO_CHAR(FECEMITE,'MM-YYYY'),0) MES,
  NVL(SUM(VALOR),0)  VALOR
  FROM FACTURASWEB
  WHERE CODCLIENTE = '286'
  AND (FECEMITE BETWEEN ADD_MONTHS(TRUNC(SYSDATE,'MM'),-12)
  AND LAST_DAY(ADD_MONTHS(TRUNC(SYSDATE,'MM'),-1)))
  GROUP BY TO_CHAR(FECEMITE,'MM-YYYY'), TO_CHAR(FECEMITE,'YYYY')
  ORDER BY TO_CHAR(FECEMITE,'YYYY'), TO_CHAR(FECEMITE,'MM-YYYY')";
                OracleCommand comando = new OracleCommand(select);
                dt = db.ExecuteSelect(comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion
        }

        public DataTable REP_OPERACION()
        {
            #region BLOQUE CONTROLADO
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT NVL(SUM(VALOR),0) VALOR,
  NVL(SUM(ABONOS),0) ABONOS,
  NVL(SUM(VALOR                       -ABONOS),0) SALDOACTUAL,
  NVL(SUM(DECODE(TIEMPO, 'CORR',VALOR -ABONOS,NULL)),0) CORRIENTE,
  NVL(SUM(DECODE(TIEMPO, '0-30',VALOR -ABONOS,NULL)),0) MES1,
  NVL(SUM(DECODE(TIEMPO, '30-60',VALOR-ABONOS,NULL)),0) MES2,
  NVL(SUM(DECODE(TIEMPO, '60-90',VALOR-ABONOS,NULL)),0) MES3,
  TO_CHAR(NVL(SUM(DECODE(TIEMPO, '91',VALOR   -ABONOS,NULL)),0),999999999.99) MES4
FROM
  (SELECT FACTURASWEB.FACTURA,
    CODCLIENTE,
    FECEMITE,
    FECVENCE,
    NVL(SUM(ABONO),0) ABONOS,
    VALOR,
    CASE
      WHEN (TRUNC(FECVENCE) >= TRUNC(SYSDATE))
      THEN 'CORR'
      WHEN (TRUNC(FECVENCE)                   < TRUNC(SYSDATE))
      AND (TRUNC(SYSDATE) - TRUNC(FECVENCE)) <= 30
      THEN '0-30'
      WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 31
      AND (TRUNC(SYSDATE)  - TRUNC(FECVENCE)) <= 60
      THEN '30-60'
      WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 60
      AND (TRUNC(SYSDATE)  - TRUNC(FECVENCE)) <= 90
      THEN '60-90'
      WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 90
      THEN '91'
      ELSE 'ERROR'
    END TIEMPO
  FROM FACTURASWEB,
    PAGOSFACWEB
  WHERE CODCLIENTE       = '286'
  AND ESTADO            <> 'T'
  AND FACTURASWEB.FACTURA=PAGOSFACWEB.FACTURA(+)
  GROUP BY FACTURASWEB.FACTURA,
    CODCLIENTE,
    FECEMITE,
    FECVENCE,
    VALOR
  ORDER BY FECEMITE
  )";
                OracleCommand comando = new OracleCommand(select);
                dt = db.ExecuteSelect(comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion
        }

        public DataTable DET_CARTERA()
        {
            #region BLOQUE CONTROLADO
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT
    DECODE(TIEMPO, 'CORR',(VALOR -ABONOS),0) CORRIENTE,
    DECODE(TIEMPO, '0-30',(VALOR       -ABONOS),0)MES1,
    DECODE(TIEMPO, '30-60',(VALOR      -ABONOS),0)MES2,
    DECODE(TIEMPO, '60-90',(VALOR      -ABONOS),0)MES3,
    DECODE(TIEMPO, '91',(VALOR         -ABONOS),0)MES4
  FROM
    (SELECT FACTURASWEB.FACTURA,
      CODCLIENTE,
      FECEMITE,
      FECVENCE,
      NVL(SUM(ABONO),0) ABONOS,
      VALOR,
      CASE
        WHEN (TRUNC(FECVENCE) >= TRUNC(SYSDATE))
        THEN 'CORR'
        WHEN (TRUNC(FECVENCE)                   < TRUNC(SYSDATE))
        AND (TRUNC(SYSDATE) - TRUNC(FECVENCE)) <= 30
        THEN '0-30'
        WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 31
        AND (TRUNC(SYSDATE)  - TRUNC(FECVENCE)) <= 60
        THEN '30-60'
        WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 60
        AND (TRUNC(SYSDATE)  - TRUNC(FECVENCE)) <= 90
        THEN '60-90'
        WHEN (TRUNC(SYSDATE) - TRUNC(FECVENCE)) >= 90
        THEN '91'
        ELSE 'ERROR'
      END TIEMPO
    FROM FACTURASWEB,
      PAGOSFACWEB
    WHERE CODCLIENTE       = '286'
    AND ESTADO            <> 'T'
    AND FACTURASWEB.FACTURA=PAGOSFACWEB.FACTURA(+)
    GROUP BY FACTURASWEB.FACTURA,
      CODCLIENTE,
      FECEMITE,
      FECVENCE,
      VALOR
    ORDER BY FACTURA
    )";
                OracleCommand comando = new OracleCommand(select);
                dt = db.ExecuteSelect(comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion
        }
        public DataTable minMax()
        {
            #region BLOQUE CONTROLADO
            try
            {
                db_conexion db = new db_conexion();
                DataTable dt = new DataTable();
                string select = @"SELECT MIN(NVL(SUM(VALOR),0))MINIMO,
  MAX(NVL(SUM(VALOR),0))MAXIMO
FROM FACTURASWEB
WHERE CODCLIENTE = '286'
AND (FECEMITE BETWEEN ADD_MONTHS(TRUNC(SYSDATE,'MM'),-12) AND LAST_DAY(ADD_MONTHS(TRUNC(SYSDATE,'MM'),-1)))
GROUP BY TO_CHAR(FECEMITE,'MM-YYYY'),
  TO_CHAR(FECEMITE,'YYYY')
ORDER BY TO_CHAR(FECEMITE,'YYYY'),
  TO_CHAR(FECEMITE,'MM-YYYY')";
                OracleCommand comando = new OracleCommand(select);
                dt = db.ExecuteSelect(comando);
                return dt;
            }
            catch (Exception Exc)
            {
                throw Exc;
            }
            #endregion
        }

        /*
         * 
         */
        #endregion
    }
}
