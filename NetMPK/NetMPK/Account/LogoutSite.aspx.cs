using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.Account
{
    public partial class LogoutSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NetMPKGlobalVariables.unload();
            Response.Redirect("~/Default.aspx");
        }
    }
}