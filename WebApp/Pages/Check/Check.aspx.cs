using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Tool;

namespace WebApp.Pages.Check
{
    public partial class Check : System.Web.UI.Page
    {
        private ContentHTML contentHTML = new ContentHTML();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Beginning();
            }
        }

        private void Beginning()
        {
            try
            {                
                if (contentHTML.IsLoadDocumentHTML())
                    SetpMessage("alert alert-success", $"0 - {contentHTML.GetInnerTextById("checkTitle")}", contentHTML.GetInnerTextById("correctCheckMessage"));
                else
                    SetpMessage("alert alert-warning", "0 - Verificacion de API", "Servicio no responde correctamente, funcionalidad no se ha ejecutado segun lo esperado");
            }
            catch (Exception ex)
            {
                SetpMessage("alert alert-danger", contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
            }
        }

        private void SetpMessage(string pAlertCssClas, string title, string message)
        {
            pAlert.CssClass = pAlertCssClas;
            hTitle.InnerText = title;
            pMessage.InnerText = message;
        }
    }
}