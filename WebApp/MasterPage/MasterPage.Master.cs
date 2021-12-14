using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.MasterPage
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
        }

        protected void Redirecciona_click(object sender, EventArgs e)
        {
            LinkButton lkButton = sender as LinkButton;
            string id = lkButton.ClientID.Replace("lk", "");
            Response.Redirect(id + ".aspx");
        }
    }
}
