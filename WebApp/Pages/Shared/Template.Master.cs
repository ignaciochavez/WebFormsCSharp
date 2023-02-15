using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Pages.Shared
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    OnInit();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OnInit()
        {
            string absolutePath = HttpContext.Current.Request.Url.AbsolutePath;

            if (absolutePath.Contains("Index.aspx"))
                hlIndex.CssClass = "nav-link active";
            else if (absolutePath.Contains("About.aspx"))
                hlAbout.CssClass = "nav-link active";
            else if (absolutePath.Contains("Contact.aspx"))
                hlContact.CssClass = "nav-link active";

            lblAnio.Text = DateTime.Now.ToString("yyyy");
        }
    }
}