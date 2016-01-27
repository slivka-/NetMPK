using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMPK
{
    public class NetMPKGlobalVariables
    {
        private static NetMPKGlobalVariables instance;

        public bool isUserLoggedIn { get; set; }

        private NetMPKGlobalVariables()
        {
            isUserLoggedIn = false;
        }

        public static NetMPKGlobalVariables getInstance()
        {
            if (instance == null)
            {
                instance = new NetMPKGlobalVariables();
            }
            return instance;
        }

    }
}