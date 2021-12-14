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
    public partial class Estudiantes : System.Web.UI.Page
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
            DataTable data = mt.Event("ESTUDIANTES");
            
            gvEstudiantes.DataSource = data;
            gvEstudiantes.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();

            Dic.Add("PrimerNombre", txtPrimerNombre.Text);
            Dic.Add("SegundoNombre", txtSegundoNombre.Text);
            Dic.Add("PrimerApellido", txtPrimerApellido.Text);
            Dic.Add("SegundoApellido", txtSegundoApellido.Text);
            Dic.Add("Direccion", txtDireccion.Text);
            Dic.Add("FechaNacimiento", txtFechaNacimiento.Text);

            var valida = Valida(Dic);

            if (valida.Contains("false"))
            {
                msg.MsgError(valida[0]);
                return;
            }

            mt.BeginTransaction();
            if (!mt.Event("ESTUDIANTES", Dic, Method.Metodo.INSERT))
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
                if (!item.Key.Equals("SegundoNombre") && !item.Key.Equals("SegundoApellido"))
                {
                    if (item.Key.Equals("FechaNacimiento"))
                    {
                        if (!IsDate(item.Value))
                        {
                            result = new List<string> { "Debe diligenciar bien la fecha", "false" };
                        }
                    }

                    if (item.Value == "")
                        result = new List<string> { "Debe diligenciar todos los campos", "false" };
                }                
            }
            return result;
        }

        private static Boolean IsDate(String fecha)
        {
            try
            {
                DateTime date = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        protected void Limpar()
        {
            txtPrimerNombre.Text = String.Empty;
            txtSegundoNombre.Text = String.Empty;
            txtPrimerApellido.Text = String.Empty;
            txtSegundoApellido.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtFechaNacimiento.Text = String.Empty;
        }
    }
}
