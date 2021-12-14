using Company;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Pages
{
    public partial class Asignaturas : System.Web.UI.Page
    {
        Method mt = new Method();
        MessageSweetalert msg;

        protected void Page_Load(object sender, EventArgs e)
        {
            msg = new MessageSweetalert(this);
            CargaDatos();

            if (Page.IsPostBack)
                return;
        }

        private void CargaDatos()
        {
            DataTable data = mt.Event("ASIGNATURAS");

            gvAsignaturas.DataSource = data;
            gvAsignaturas.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();

            Dic.Add("Nombre", txtNombre.Text);

            var valida = Valida(Dic);

            if (valida.Contains("false"))
            {
                msg.MsgError(valida[0]);
                return;
            }

            mt.BeginTransaction();
            if (!mt.Event("ASIGNATURAS", Dic, Method.Metodo.INSERT))
            {
                msg.MsgError("Hubo un error al guardar");
                mt.DisposeTransaction();
            }
            else
            {
                msg.MsgSuccess("Se guardó correctamente");
                Limpar();
                CargaDatos();
                mt.CommitTransaction();
            }
        }

        private List<string> Valida(Dictionary<string, string> dic)
        {
            List<string> result = new List<string>();
            foreach (var item in dic)
            {
                if (item.Value == "")
                    result = new List<string> { "Debe diligenciar todos los campos", "false" };
            }
            return result;
        }

        protected void Limpar()
        {
            txtNombre.Text = String.Empty;
        }
    }
}