using Company;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {

        MessageSweetalert message;
        protected void Page_Load(object sender, EventArgs e)
        {
            message = new MessageSweetalert(this);
            //deshabilitar el almacenamiento en caché
            this.DisableCache(this.Page);

            txtUser.Text = "Administrador";
            //txtPassword.Text = "1234";

            if (Page.IsPostBack)
                return;

            HttpContext.Current.Cache.Cast<System.Collections.DictionaryEntry>().ToList().ForEach(f => HttpContext.Current.Cache.Remove((string)f.Key));
        }

        public void DisableCache(Page page)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "forceCache", "try { clearCache(); } catch(ex) { }", true);
            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AppendHeader("Expires", "0");
        }

        private void Authenticate(string user, string contrasena)
        {
            if (txtUser.Text == "Administrador" && txtPassword.Text == "1234")
            {
                Response.Redirect("Pages/Home.aspx");
            }
            else
            {
                message.MsgError("No se encontró ningun usuario registrado con dicha información");
            }
        }

        protected void bntIngresar_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string contrasena = txtPassword.Text;

            if (user == "" && contrasena == "")
            {
                message.MsgError("Ingrese por favor el usuario y contraseña");
                return;
            }
            else if (user == "" && contrasena != "")
            {
                message.MsgError("Por favor digite su usuario");
                return;
            }
            else if (user != "" && contrasena == "")
            {
                message.MsgError("Por favor digitar la contraseña del usuario");
                return;
            }

            Authenticate(user, contrasena);
        }
    }
}
