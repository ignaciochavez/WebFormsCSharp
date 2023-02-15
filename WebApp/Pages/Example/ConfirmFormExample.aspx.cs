using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Tool;
using System.Web.UI.HtmlControls;

namespace WebApp.Pages.Example
{
    public partial class ConfirmFormExample : System.Web.UI.Page
    {
        private MessageVO messageVO = new MessageVO();
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
                MessageVO messageVOSession = (MessageVO)Session["MessageVOFormExample"];
                if (messageVOSession != null)
                {
                    messageVO = messageVOSession;
                    SetpMessage("alert alert-secondary");
                }
                else
                {
                    MessageVO exceptionSession = (MessageVO)Session["ExceptionFormExample"];
                    if (exceptionSession != null)
                    {
                        messageVO = exceptionSession;
                        SetpMessage("alert alert-danger");
                    }
                    else
                    {                        
                        Business.Entity.Example insertFormExample = (Business.Entity.Example)Session["InsertFormExample"];
                        bool? updateFormExample = (bool?)Session["UpdateFormExample"];
                        if (insertFormExample != null && insertFormExample.Id > 0)
                        {
                            messageVO.SetMessage(0, contentHTML.GetInnerTextById("completedProcessTitle"), contentHTML.GetInnerTextById("recordsInsertSuccessfully"));
                            SetpMessage("alert alert-success");
                        }
                        else if (insertFormExample != null && insertFormExample.Id <= 0)
                        {
                            messageVO.SetMessage(0, contentHTML.GetInnerTextById("processNotCompletedTitle"), contentHTML.GetInnerTextById("recordsNotInsertCorrectly"));
                            SetpMessage("alert alert-secondary");
                        }
                        else if (updateFormExample != null && updateFormExample.Value)
                        {
                            messageVO.SetMessage(0, contentHTML.GetInnerTextById("completedProcessTitle"), contentHTML.GetInnerTextById("recordsUpdateSuccessfully"));
                            SetpMessage("alert alert-success");
                        }
                        else if (updateFormExample != null && !updateFormExample.Value)
                        {
                            messageVO.SetMessage(0, contentHTML.GetInnerTextById("processNotCompletedTitle"), contentHTML.GetInnerTextById("recordsNotUpdateCorrectly"));
                            SetpMessage("alert alert-secondary");
                        }
                        else
                        {
                            messageVO.SetMessage(0, contentHTML.GetInnerTextById("noProcessCompletedtTitle"), contentHTML.GetInnerTextById("noProcessCompleted"));
                            SetpMessage("alert alert-primary");
                        }
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
                Session["MessageVOFormExample"] = null;
                Session["ExceptionFormExample"] = null;
                Session["InsertFormExample"] = null;
                Session["UpdateFormExample"] = null;
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