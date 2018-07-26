using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;

namespace PortalClientesCoprTranser.Models.model_DB
{
    public class db_conexion
    {
        #region DEFINICION DE VARIABLES GLOBALES
        private string cadena = string.Empty;
        #endregion

        public db_conexion()
        {
            db_paramCon paramCon = new db_paramCon();
            cadena = @"User Id=" + paramCon.userDb + ";Password="
                + paramCon.paswDb + ";Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST="
                + paramCon.server + ")(PORT=1521))(CONNECT_DATA=(SID=" + paramCon.databaseName + ")));";

        }
        public DataTable ExecuteSelect(OracleCommand _Comando)
        {
            using (OracleConnection connection = new OracleConnection(cadena))
            {
                //OracleCommand command = new OracleCommand(queryString);
                DataTable dt = new DataTable();
                _Comando.Connection = connection;
                try
                {
                    connection.Open();
                    dt.Load(_Comando.ExecuteReader());
                    connection.Close();
                    return dt;
                }
                catch (OracleException oraEx)
                {
                    throw oraEx;
                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }
    }
}