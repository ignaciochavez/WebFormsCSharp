using Business.Implementation;
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
                    Tuple<MessageVO, Business.Entity.Heroe> heroe = HeroeImpl.Select(id);
                    if (heroe.Item1 != null)
                    {
                        WithoutRecord();
                        messageVO = heroe.Item1;
                        SetpMessage("alert alert-secondary");
                    }
                    else if (heroe.Item2 != null)
                    {
                        Page.Title = "Actualizar";
                        hTitle.InnerText = "Actualizar";
                        Session["HeroeUpdate"] = heroe.Item2;
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