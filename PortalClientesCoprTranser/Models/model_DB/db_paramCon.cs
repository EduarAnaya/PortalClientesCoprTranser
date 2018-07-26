using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientesCoprTranser.Models.model_DB
{
    public class db_paramCon
    {
        public string server { get; set; }
        public string databaseName { get; set; }
        public string userDb { get; set; }
        public string paswDb { get; set; }

        public db_paramCon()
        {
            this.server = "192.168.30.6";
            this.databaseName = "MILEBOG1";
            this.userDb = "web";
            this.paswDb = "web01";
        }
    }
}