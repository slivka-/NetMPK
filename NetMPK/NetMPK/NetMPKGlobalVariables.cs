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
        public string loggedInUserName { get; set; }
        public bool userVerified { get; set; }
        public bool admin { get; set; }

        private NetMPKGlobalVariables()
        {
            isUserLoggedIn = true;
            loggedInUserName = "slivka";
            userVerified = true;
            admin = false;
        }

        public static NetMPKGlobalVariables getInstance()
        {
            if (instance == null)
            {
                instance = new NetMPKGlobalVariables();
            }
            return instance;
        }

        public static void unload()
        {
            instance = null;
        }
    }
}