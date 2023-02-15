using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Tool;
using System.Web.UI.HtmlControls;
using Business.Implementation;

namespace WebApp.Pages.Example
{
    public partial class Update : System.Web.UI.Page
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
                string paramId = Request.QueryString["id"];
                int id = (!string.IsNullOrWhiteSpace(paramId)) ? Convert.ToInt32(paramId) : 0;
                if (id <= 0)
                {
                    WithoutRecord();
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "id"));
                    SetpMessage("alert alert-secondary");
                }
                else
                {
                    Tuple<MessageVO, Business.Entity.Example> example = ExampleImpl.Select(id);
                    if (example.Item1 != null)
                    {
                        WithoutRecord();
                        messageVO = example.Item1;
                        SetpMessage("alert alert-secondary");
                    }
                    else if (example.Item2 != null)
                    {
                        Page.Title = "Actualizar";
                        hTitle.InnerText = "Actualizar";
                        Session["ExampleUpdate"] = example.Item2;
                        pUpdate.Visible = true;
                    }
                    else
                    {
                        WithoutRecord();
                        messageVO.SetMessage(0, contentHTML.GetInnerTextById("notFoundTitle"), contentHTML.GetInnerTextById("recordsNotFound"));
                        SetpMessage("alert alert-info");
                    }
                }
            }
            catch (Exception ex)
            {
                WithoutRecord();
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                SetpMessage("alert alert-danger");
            }
            
        }

        private void WithoutRecord()
        {
            Page.Title = "Sin registro";
            hTitle.InnerText = "Sin registro";
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