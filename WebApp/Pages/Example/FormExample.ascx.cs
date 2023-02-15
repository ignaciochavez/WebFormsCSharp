using Business.DTO;
using Business.Implementation;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApp.Pages.Example
{
    public partial class FormExample : System.Web.UI.UserControl
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
            if (HttpContext.Current.Request.Url.AbsolutePath.Contains("Insert"))
            {
                Page.Title = "Insertar";

                HtmlGenericControl i = new HtmlGenericControl("i");
                i.Attributes.Add("class", "fa fa-check");
                i.InnerText = "Insertar";
                lbSubmit.Controls.Add(i);

                hfId.Value = "0";
            }
            else if (HttpContext.Current.Request.Url.AbsolutePath.Contains("Update"))
            {
                HtmlGenericControl i = new HtmlGenericControl("i");
                i.Attributes.Add("class", "fa fa-refresh");
                i.InnerText = "Actualizar";
                lbSubmit.Controls.Add(i);

                Business.Entity.Example example = (Business.Entity.Example)Session["ExampleUpdate"];
                if (example != null)
                {
                    hfId.Value = example.Id.ToString();
                    tbRut.Text = Useful.GetFormatRut(example.Rut);
                    tbName.Text = example.Name;
                    tbLastName.Text = example.LastName;
                    tbBirthDate.Text = example.BirthDate.ToString("yyyy-MM-dd");

                    if (example.Active)
                    {
                        rbNonActive.Checked = false;
                        rbYesActive.Checked = true;
                    }
                    else
                    {
                        rbYesActive.Checked = false;
                        rbNonActive.Checked = true;
                    }                    
                }

                Session["ExampleUpdate"] = null;
            }
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(hfId.Value) < 0)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parameterMustBeGreaterThanOrEqualToZero").Replace("{0}", "id"));

                if (string.IsNullOrWhiteSpace(tbRut.Text))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Rut"));
                else if (tbRut.Text.Trim().Length > 12)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Rut").Replace("{1}", "12"));
                else if (!Useful.ValidateRut(tbRut.Text))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "Rut"));

                if (string.IsNullOrWhiteSpace(tbName.Text))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Name"));
                else if (tbName.Text.Trim().Length > 45)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Name").Replace("{1}", "45"));

                if (string.IsNullOrWhiteSpace(tbLastName.Text))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "LastName"));
                else if (tbLastName.Text.Trim().Length > 45)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "LastName").Replace("{1}", "45"));

                DateTimeOffset birthDate = new DateTimeOffset();
                bool isDate = DateTimeOffset.TryParseExact(tbBirthDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
                if (!isDate)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "BirthDate"));
                else if (!Useful.ValidateDateTimeOffset(birthDate))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParametersNoInitialized").Replace("{0}", "BirthDate"));
                else if (birthDate > DateTimeOffset.Now)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParameterGreaterThanTheCurrentDate").Replace("{0}", "BirthDate"));

                if (!rbYesActive.Checked && !rbNonActive.Checked)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parameterNotSelected").Replace("{0}", "Active"));

                if (string.IsNullOrWhiteSpace(tbPassword.Text))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Password"));
                else if (tbPassword.Text.Trim().Length > 16)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Password").Replace("{1}", "16"));

                if (messageVO.Messages.Count() > 0)
                {
                    messageVO.SetIdTitle(0, contentHTML.GetInnerTextById("requeridTitle"));
                    Session["MessageVOFormExample"] = messageVO;
                }
                else
                {
                    if (HttpContext.Current.Request.Url.AbsolutePath.Contains("Insert"))
                    {
                        Tuple<MessageVO, Business.Entity.Example> tupleInsertMethod = ExampleImpl.Insert(new ExampleInsertDTO(tbRut.Text.Trim().Replace(".", ""), tbName.Text.Trim(), tbLastName.Text.Trim(), birthDate, ((rbYesActive.Checked) ? true : false), tbPassword.Text));
                        if (tupleInsertMethod.Item1 != null)
                            Session["MessageVOFormExample"] = tupleInsertMethod.Item1;
                        else if (tupleInsertMethod.Item2 != null)
                            Session["InsertFormExample"] = tupleInsertMethod.Item2;
                    }
                    else
                    {
                        Tuple<MessageVO, bool?> tupleUpdateMethod = ExampleImpl.Update(new Business.Entity.Example(Convert.ToInt32(hfId.Value), tbRut.Text.Trim().Replace(".", ""), tbName.Text.Trim(), tbLastName.Text.Trim(), birthDate, ((rbYesActive.Checked) ? true : false), tbPassword.Text));
                        if (tupleUpdateMethod.Item1 != null)
                            Session["MessageVOFormExample"] = tupleUpdateMethod.Item1;
                        else if (tupleUpdateMethod.Item2 != null)
                            Session["UpdateFormExample"] = tupleUpdateMethod.Item2;
                    }
                }
            }
            catch (Exception ex )
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                Session["ExceptionFormExample"] = messageVO;
            }
            finally
            {
                Response.Redirect("~/Pages/Example/ConfirmFormExample.aspx", false);
            }            
        }
    }
}