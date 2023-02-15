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

namespace WebApp.Pages.Heroe
{
    public partial class FormHeroe : System.Web.UI.UserControl
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

                iImgBase64String.Style.Add("display", "none");
            }
            else if (HttpContext.Current.Request.Url.AbsolutePath.Contains("Update"))
            {
                HtmlGenericControl i = new HtmlGenericControl("i");
                i.Attributes.Add("class", "fa fa-refresh");
                i.InnerText = "Actualizar";
                lbSubmit.Controls.Add(i);

                iImgBase64String.Style.Add("display", "block");

                Business.Entity.Heroe heroe = (Business.Entity.Heroe)Session["HeroeUpdate"];
                if (heroe != null)
                {
                    hfId.Value = heroe.Id.ToString();
                    tbName.Text = heroe.Name;
                    tbHome.Text = heroe.Home;
                    tbAppearance.Text = heroe.Appearance.ToString("yyyy-MM-dd");
                    tbDescription.Text = heroe.Description;
                    iImgBase64String.ImageUrl = heroe.ImgBase64String;
                    tbImgBase64String.Text = heroe.ImgBase64String;
                }

                Session["HeroeUpdate"] = null;
            }
        }

        protected void lbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(hfId.Value.ToString()) < 0)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("parameterMustBeGreaterThanOrEqualToZero").Replace("{0}", "id"));

                if (string.IsNullOrWhiteSpace(tbName.Text))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Name"));
                else if (tbName.Text.Trim().Length > 45)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Name").Replace("{1}", "45"));

                if (string.IsNullOrWhiteSpace(tbHome.Text))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Home"));
                else if (tbHome.Text.Trim().Length > 35)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Home").Replace("{1}", "35"));

                DateTimeOffset appearance = new DateTimeOffset();
                bool isDate = DateTimeOffset.TryParseExact(tbAppearance.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out appearance);
                if (!isDate)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "Appearance"));
                else if (!Useful.ValidateDateTimeOffset(appearance))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParametersNoInitialized").Replace("{0}", "Appearance"));
                else if (appearance > DateTimeOffset.Now)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("dateTimeParameterGreaterThanTheCurrentDate").Replace("{0}", "Appearance"));

                if (string.IsNullOrWhiteSpace(tbDescription.Text))
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "Description"));
                else if (tbDescription.Text.Trim().Length > 450)
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("maximunParameterLengthCharacter").Replace("{0}", "Description").Replace("{1}", "450"));

                if (string.IsNullOrWhiteSpace(tbImgBase64String.Text))
                {
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("emptyParameters").Replace("{0}", "ImgBase64String"));
                }
                else if (!Useful.ValidateBase64String(Useful.ReplaceConventionImageFromBase64String(tbImgBase64String.Text)))
                {
                    messageVO.Messages.Add(contentHTML.GetInnerTextById("invalidFormatParameters").Replace("{0}", "ImgBase64String"));
                }
                else
                {

                    string[] arrayImgBase64String = tbImgBase64String.Text.Split(',');
                    if (!Useful.ValidateIsImageBase64String(arrayImgBase64String[0]))
                        messageVO.Messages.Add(contentHTML.GetInnerTextById("formatMustBe").Replace("{0}", "ImgBase64String").Replace("{1}", "bmp, emf, exif, gif, icon, jpeg, jpg, png, tiff o wmf"));

                }

                if (messageVO.Messages.Count() > 0)
                {
                    messageVO.SetIdTitle(0, contentHTML.GetInnerTextById("requeridTitle"));
                    Session["MessageVOFormHeroe"] = messageVO;
                }
                else
                {
                    if (HttpContext.Current.Request.Url.AbsolutePath.Contains("Insert"))
                    {
                        Tuple<MessageVO, Business.Entity.Heroe> tupleInsertMethod = HeroeImpl.Insert(new HeroeInsertDTO(tbName.Text.Trim(), tbHome.Text.Trim(), appearance, tbDescription.Text.Trim(), tbImgBase64String.Text.Trim()));
                        if (tupleInsertMethod.Item1 != null)
                            Session["MessageVOFormHeroe"] = tupleInsertMethod.Item1;
                        else if (tupleInsertMethod.Item2 != null)
                            Session["InsertFormHeroe"] = tupleInsertMethod.Item2;
                    }
                    else
                    {
                        Tuple<MessageVO, bool?> tupleUpdateMethod = HeroeImpl.Update(new Business.Entity.Heroe(Convert.ToInt32(hfId.Value), tbName.Text.Trim(), tbHome.Text.Trim(), appearance, tbDescription.Text.Trim(), tbImgBase64String.Text.Trim()));
                        if (tupleUpdateMethod.Item1 != null)
                            Session["MessageVOFormHeroe"] = tupleUpdateMethod.Item1;
                        else if (tupleUpdateMethod.Item2 != null)
                            Session["UpdateFormHeroe"] = tupleUpdateMethod.Item2;
                    }
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                Session["ExceptionFormHeroe"] = messageVO;
            }
            finally
            {
                Response.Redirect("~/Pages/Heroe/ConfirmFormHeroe.aspx", false);
            }
        }
    }
}