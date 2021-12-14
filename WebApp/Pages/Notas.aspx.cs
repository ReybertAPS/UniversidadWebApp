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
    public partial class Notas : System.Web.UI.Page
    {
        Method mt = new Method();
        MessageSweetalert msg;

        protected void Page_Load(object sender, EventArgs e)
        {
            msg = new MessageSweetalert(this);

            if (Page.IsPostBack)
                return;

            CargaDatos();

        }

        #region METODOS CARGA DATOS
        private void CargaDatos()
        {
            CargaDatosNotas();

            CargaDatosdEstudiantes();

            CargaDatosAsignaturas();

            CargaDatosPeriodos();
        }

        private void CargaDatosNotas()
        {
            DataTable Data = new DataTable();

            Data = mt.Event("NOTAS_ESTUDIANTES_VIEW");

            gvNotas.DataSource = Data;
            gvNotas.DataBind();
        }

        private void CargaDatosdEstudiantes()
        {
            DataTable Data = new DataTable();

            Data = mt.Event("ESTUDIANTES_VIEW");

            gvEstudiantes.DataSource = Data;
            gvEstudiantes.DataBind();

        }

        private void CargaDatosAsignaturas()
        {
            DataTable Data = new DataTable();

            Data = mt.Event("ASIGNATURAS");

            DataRow nRow = Data.NewRow();
            nRow["Nombre"] = "Seleccione...";
            nRow["Id"] = "0";
            Data.Rows.InsertAt(nRow, 0);
            ddlAsignatura.DataSource = Data;
            ddlAsignatura.DataTextField = "Nombre";
            ddlAsignatura.DataValueField = "Id";
            ddlAsignatura.DataBind();
            ddlAsignatura.SelectedValue = "0";
        }

        private void CargaDatosPeriodos()
        {
            DataTable Data = new DataTable();

            Data = mt.Event("PERIODOS");

            DataRow nRow = Data.NewRow();
            nRow["Nombre"] = "Seleccione...";
            nRow["Id"] = "0";
            Data.Rows.InsertAt(nRow, 0);
            ddlPeriodo.DataSource = Data;
            ddlPeriodo.DataTextField = "Nombre";
            ddlPeriodo.DataValueField = "Id";
            ddlPeriodo.DataBind();
            ddlPeriodo.SelectedValue = "0";
        }
        #endregion


        #region EVENTOS GRIDVIEW
        protected void gvEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnLimpiar_Click(null, null);

            GridViewRow row = gvEstudiantes.SelectedRow;

            row.ForeColor = System.Drawing.Color.White;
            row.BackColor = System.Drawing.Color.DarkBlue;
        }

        protected void gvNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow fila in gvEstudiantes.Rows)
            {
                fila.ForeColor = System.Drawing.Color.Black;
                fila.BackColor = System.Drawing.Color.White;
            }

            GridViewRow row = gvNotas.SelectedRow;

            row.ForeColor = System.Drawing.Color.White;
            row.BackColor = System.Drawing.Color.DarkBlue;

            string IdNota = row.Cells[1].Text;
            string Nota = row.Cells[2].Text;
            string fecha = row.Cells[3].Text;
            string IdEstudiante = row.Cells[4].Text;
            string IdAsignatura = row.Cells[6].Text;
            string IdPeriodo = row.Cells[8].Text;

            txtIdNota.Text = IdNota;
            txtNota.Text = Nota;
            txtFecha.Text = fecha;
            ddlAsignatura.SelectedValue = IdAsignatura;
            ddlPeriodo.SelectedValue = IdPeriodo;

            foreach (GridViewRow fila in gvEstudiantes.Rows)
            {
                if (fila.Cells[1].Text == IdEstudiante)
                {
                    gvEstudiantes.SelectedIndex = fila.RowIndex;
                    fila.ForeColor = System.Drawing.Color.White;
                    fila.BackColor = System.Drawing.Color.DarkBlue;
                }
            }
        }

        protected void gvEstudiantes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gvEstudiantes.SelectedRow;

            if (row != null)
            {
                row.ForeColor = System.Drawing.Color.Black;
                row.BackColor = System.Drawing.Color.White;
            }
        }
        #endregion

        #region METODOS BOTONES
        private void Guardar()
        {
            GridViewRow row = gvEstudiantes.SelectedRow;
            string IdEstudiante = row.Cells[1].Text;

            Dictionary<string, string> Dic = new Dictionary<string, string>();

            Dic.Add("Nota", txtNota.Text);
            Dic.Add("IdEstudiante", IdEstudiante);
            Dic.Add("IdAsignatura", ddlAsignatura.SelectedValue);
            Dic.Add("IdPeriodo", ddlPeriodo.SelectedValue);
            Dic.Add("Fecha", txtFecha.Text);

            var valida = Valida(Dic);

            if (valida.Contains("false"))
            {
                msg.MsgError(valida[0]);
                return;
            }

            mt.BeginTransaction();
            if (!mt.Event("NOTAS", Dic, Method.Metodo.INSERT))
            {
                msg.MsgError("Hubo un error al guardar");
                mt.DisposeTransaction();
            }
            else
            {
                msg.MsgSuccess("Se guardó correctamente");
                CargaDatosNotas();
                mt.CommitTransaction();
            }
        }

        private void Actualizar()
        {
            GridViewRow rowNota = gvNotas.SelectedRow;
            string IdNota = rowNota.Cells[1].Text;

            GridViewRow rowestudiante = gvEstudiantes.SelectedRow;
            string IdEstudiante = rowestudiante.Cells[1].Text;

            Dictionary<string, string> Dic = new Dictionary<string, string>();

            Dic.Add("Id", txtIdNota.Text);
            Dic.Add("Nota", txtNota.Text);
            Dic.Add("IdEstudiante", IdEstudiante);
            Dic.Add("IdAsignatura", ddlAsignatura.SelectedValue);
            Dic.Add("IdPeriodo", ddlPeriodo.SelectedValue);
            Dic.Add("Fecha", txtFecha.Text);

            var valida = Valida(Dic);

            if (valida.Contains("false"))
            {
                msg.MsgError(valida[0]);
                return;
            }

            mt.BeginTransaction();
            if (!mt.Event("NOTAS", Dic, Method.Metodo.UPDATE))
            {
                msg.MsgError("Hubo un error al actualizar");
                mt.DisposeTransaction();
            }
            else
            {
                msg.MsgSuccess("Se actualizó correctamente");
                CargaDatosNotas();
                mt.CommitTransaction();
            }
        }

        private void Eliminar()
        {
            Dictionary<string, string> Dic = new Dictionary<string, string>();

            Dic.Add("Id", txtIdNota.Text);

            mt.BeginTransaction();
            if (!mt.Event("NOTAS", Dic, Method.Metodo.DELETE))
            {
                msg.MsgError("Hubo un error al eliminar");
                mt.DisposeTransaction();
            }
            else
            {
                msg.MsgSuccess("Se eliminó correctamente");
                CargaDatosNotas();
                mt.CommitTransaction();
            }
        }

        #endregion

        #region BOTONES 
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIdNota.Text.Equals(String.Empty))
            {
                Guardar();
                btnLimpiar_Click(null, null);
            }
            else
            {
                Actualizar();
                btnLimpiar_Click(null, null);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!txtIdNota.Text.Equals(String.Empty))
            {
                Eliminar();
                btnLimpiar_Click(null, null);
            }
            else
            {
                msg.MsgError("No ha seleccionado una nota para eliminar");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiaGridViews();

            CargaDatosAsignaturas();
            CargaDatosPeriodos();

            LimpiaTextBox();
        }

        private void LimpiaGridViews()
        {
            GridViewRow gvEstudiantesRow = gvEstudiantes.SelectedRow;
            if (gvEstudiantesRow != null)
            {
                gvEstudiantesRow.BackColor = System.Drawing.Color.White;
                gvEstudiantesRow.ForeColor = System.Drawing.Color.Black;
            }

            GridViewRow gvNotasRow = gvNotas.SelectedRow;
            if (gvNotasRow != null)
            {
                gvNotasRow.BackColor = System.Drawing.Color.White;
                gvNotasRow.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void LimpiaTextBox()
        {
            txtFecha.Text = String.Empty;
            txtIdNota.Text = String.Empty;
            txtNota.Text = String.Empty;
        }
        #endregion


        #region VALIDACIONES
        private List<string> Valida(Dictionary<string, string> dic)
        {
            List<string> result = new List<string>();
            foreach (var item in dic)
            {
                if (!item.Key.Equals("IdAsignatura") && !item.Key.Equals("IdPeriodo"))
                {
                    if (item.Key.Equals("Fecha"))
                    {
                        if (!IsDate(item.Value))
                        {
                            result = new List<string> { "Debe diligenciar bien la fecha", "false" };
                        }
                    }

                    if (item.Value == "")
                        result = new List<string> { "Debe diligenciar todos los campos", "false" };
                }
                else
                {
                    if (item.Value == "0")
                    {
                        result = new List<string> { "Debe seleccionar un valor", "false" };
                    }
                }
            }
            return result;
        }

        public static Boolean IsDate(String fecha)
        {
            try
            {
                DateTime date = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}