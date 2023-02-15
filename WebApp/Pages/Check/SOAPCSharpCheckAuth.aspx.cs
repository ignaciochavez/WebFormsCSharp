using Business.Implementation;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApp.Pages.Check
{
    public partial class SOAPCSharpCheckAuth : System.Web.UI.Page
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
                MessageVO sOAPCSharpCheckAuth = CheckImpl.CheckAuth();
                hTitle.InnerText = $"{sOAPCSharpCheckAuth.Id} - {sOAPCSharpCheckAuth.Title}";
                foreach (var item in sOAPCSharpCheckAuth.Messages)
                {
                    HtmlGenericControl htmlGenericControl = new HtmlGenericControl("p");
                    htmlGenericControl.InnerText = item;
                    pAlert.Controls.Add(htmlGenericControl);

                    if (contentHTML.GetInnerTextById("correctCheckMessage") == item)
                        pAlert.CssClass = "alert alert-success";
                    else
                        pAlert.CssClass = "alert alert-secondary";
                }

            }
            catch (Exception ex)
            {
                pAlert.CssClass = "alert alert-danger";
                hTitle.InnerText = contentHTML.GetInnerTextById("exceptionTitle");
                HtmlGenericControl htmlGenericControl = new HtmlGenericControl("p");
                htmlGenericControl.InnerText = ex.GetOriginalException().Message;
                pAlert.Controls.Add(htmlGenericControl);
            }
        }
    }
}