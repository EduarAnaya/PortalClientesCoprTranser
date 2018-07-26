using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientesCoprTranser.Models.administracion
{
    public class AccountModel
    {
        public Account Login(AccountViewModel avm)
        {
            Account AccoutnDB = new Account();
            AccoutnDB.EMAIL = "bavaria@bavaria.com";
            AccoutnDB.CONTRASEÑA_ACTUAL = "bavaria";

            if (avm.Account.EMAIL == AccoutnDB.EMAIL && avm.Account.CONTRASEÑA_ACTUAL == AccoutnDB.CONTRASEÑA_ACTUAL)
            {
                return AccoutnDB;
            }
            else
            {
                return null;
            }

        }
    }
}