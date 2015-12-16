using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetMPK.MainFunct
{
    public partial class StopLines : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            titleText.InnerText += Request.QueryString["stopname"];
        }
    }
}