using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Tool;
using Business.Implementation;
using System.Web.UI.HtmlControls;

namespace WebApp.Pages.Check
{
    public partial class SOAPCSharpCheck : System.Web.UI.Page
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
                MessageVO sOAPCSharpCheck = CheckImpl.Check();
                hTitle.InnerText = $"{sOAPCSharpCheck.Id} - {sOAPCSharpCheck.Title}";
                foreach (var item in sOAPCSharpCheck.Messages)
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