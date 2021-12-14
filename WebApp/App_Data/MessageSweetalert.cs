using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace WebApp
{
  public class MessageSweetalert
  {
    private Page Page { get; set; }
    public MessageSweetalert(Page page)
    {
      this.Page = page;
    }

    public enum TypeMessage
    {
      info,
      success,
      warning,
      error
    }

    public void MsgSuccess(string Message, string Title = "Alerta", string NumTimer = "100000", string CssClass = "", bool showConfButt = true)
    {
      Message = Message.Replace("'", "\\'").Replace("\r\n", "<br/>");
      StringBuilder sScript = new StringBuilder();
      Message = Message.Replace("'", "").Replace("\r\n", "<br />").Replace("\n", "<br />");
      Title = Title.Replace("'", "");
      sScript.Append("var msgNew = new sweetalertMSG2();");
      sScript.Append("msgNew.create.Success('" + Title.ToString() + "','" + Message.ToString() + "'," + NumTimer + ",'" + CssClass + "'," + showConfButt.ToString().ToLower() + ");");
      RegistrarMensaje(sScript);
    }

    public void MsgError(string Message, string Title = "Alerta", string NumTimer = "100000", string CssClass = "", bool showConfButt = true)
    {
      Message = Message.Replace("'", "\\'").Replace("\r\n", "<br/>");
      StringBuilder sScript = new StringBuilder();
      Message = Message.Replace("'", "").Replace("\r\n", "<br />").Replace("\n", "<br />");
      Title = Title.Replace("'", "");
      sScript.Append("var msgNew = new sweetalertMSG2();");
      sScript.Append("msgNew.create.Error('" + Title.ToString() + "','" + Message.ToString() + "'," + NumTimer + ",'" + CssClass + "'," + showConfButt.ToString().ToLower() + ");");
      RegistrarMensaje(sScript);
    }
    public void MsgInfo(string Message, string Title = "Alerta", string NumTimer = "100000", string CssClass = "", bool showConfButt = true)
    {
      Message = Message.Replace("'", "\\'").Replace("\r\n", "<br/>");
      StringBuilder sScript = new StringBuilder();
      Message = Message.Replace("'", "").Replace("\r\n", "<br />").Replace("\n", "<br />");
      Title = Title.Replace("'", "");
      sScript.Append("var msgNew = new sweetalertMSG2();");
      sScript.Append("msgNew.create.Info('" + Title.ToString() + "','" + Message.ToString() + "'," + NumTimer + ",'" + CssClass + "'," + showConfButt.ToString().ToLower() + ");");
      RegistrarMensaje(sScript);
    }

    public void MsgWarning(string Message, string Title = "Alerta", string NumTimer = "100000", string CssClass = "", bool showConfButt = true)
    {
      Message = Message.Replace("'", "\\'").Replace("\r\n", "<br/>");
      StringBuilder sScript = new StringBuilder();
      Message = Message.Replace("'", "").Replace("\r\n", "<br />").Replace("\n", "<br />");
      Title = Title.Replace("'", "");
      sScript.Append("var msgNew = new sweetalertMSG2();");
      sScript.Append("msgNew.create.Warning('" + Title.ToString() + "','" + Message.ToString() + "'," + NumTimer + ",'" + CssClass + "'," + showConfButt.ToString().ToLower() + ");");
      RegistrarMensaje(sScript);
    }

    public void MsgConfirm(string Message, string Title = "Alerta", string targetAceptar = "targetAceptar", string targetCancelar = "targetCancelar", string parameter = "", string TextButtonAceptar = "Aceptar", string TextButtonCancelar = "Cancelar", string CssClass = "", TypeMessage typsmsg = TypeMessage.info, bool showCancelButton = false)
    {
      string CancelVisible = "";
      if (showCancelButton)
        CancelVisible = "true";
      else
        CancelVisible = "false";

      Message = Message.Replace("'", "\\'").Replace("\r\n", "<br/>");
      StringBuilder sScript = new StringBuilder();
      Message = Message.Replace("'", "").Replace("\r\n", "<br />").Replace("\n", "<br />");
      Title = Title.Replace("'", "");
      sScript.Append("var msgNew = new sweetalertMSG2();");
      sScript.Append("msgNew.create.Confirm('" + Title + "','" + Message.ToString() + "','" + targetAceptar + "','" + targetCancelar + "','" + parameter + "','" + TextButtonAceptar + "','" + TextButtonCancelar + "','" + CssClass + "','" + typsmsg.ToString() + "' ," + showCancelButton.ToString().ToLower() + ");");
      RegistrarMensaje(sScript);
    }

    private void RegistrarMensaje(StringBuilder sScript)
    {
      ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sweetalert2", "setTimeout(function() { " + sScript.ToString() + " }, 1000);", true);
    }
  }
}
