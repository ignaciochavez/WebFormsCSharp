using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApp.Pages.Heroe
{
    public partial class Download : System.Web.UI.Page
    {
        private ContentHTML contentHTML = new ContentHTML();
        private MessageVO messageVO = new MessageVO();
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
                MessageVO messageVOSession = (MessageVO)Session["MessageVODownload"];
                if (messageVOSession != null)
                {
                    messageVO = messageVOSession;
                    SetpMessage("alert alert-secondary");
                }
                else
                {
                    MessageVO exceptionSession = (MessageVO)Session["ExceptionDownload"];
                    if (exceptionSession != null)
                    {
                        messageVO = exceptionSession;
                        SetpMessage("alert alert-danger");
                    }
                    else
                    {
                        messageVO.SetMessage(0, contentHTML.GetInnerTextById("noProcessCompletedtTitle"), contentHTML.GetInnerTextById("noProcessCompleted"));
                        SetpMessage("alert alert-primary");
                    }
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                SetpMessage("alert alert-danger");
            }
            finally
            {
                Session["MessageVODownload"] = null;
                Session["ExceptionDownload"] = null;
            }
        }

        private void SetpMessage(string pAlertCssClas)
        {
            pMessage.Visible = true;
            pAlert.CssClass = pAlertCssClas;
            hTitleAlert.InnerText = $"{messageVO.Id} - {messageVO.Title}";
            foreach (var item in messageVO.Messages)
            {
                HtmlGenericControl htmlGenericControl = new HtmlGenericControl("p");
                htmlGenericControl.InnerText = item;
                pAlert.Controls.Add(htmlGenericControl);
            }
        }
    }
}