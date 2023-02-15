using Business.DTO;
using Business.Implementation;
using Business.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApp.Pages.Example
{
    public partial class List : System.Web.UI.Page
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
                string paramPageIndex = Request.QueryString["pageIndex"];
                int pageIndex = (!string.IsNullOrWhiteSpace(paramPageIndex)) ? Convert.ToInt32(paramPageIndex) : 1;
                if (pageIndex <= 0)
                {
                    hPageIndex.InnerText = "Pagina 0";
                    FillPagination(null, pageIndex, 0);
                    messageVO.SetMessage(0, contentHTML.GetInnerTextById("requeridTitle"), contentHTML.GetInnerTextById("parametersAtZero").Replace("{0}", "pageIndex"));
                    SetpMessage("alert alert-secondary");
                }
                else
                {
                    Tuple<MessageVO, List<Business.Entity.Example>> tupleListMethod = ExampleImpl.List(new ExampleListDTO(pageIndex, Useful.GetPageSizeMaximun()));
                    if (tupleListMethod.Item2 != null && tupleListMethod.Item2.Count() == 0)
                        hPageIndex.InnerText = "Pagina 0";
                    else
                        hPageIndex.InnerText = "Pagina " + pageIndex.ToString();
                                        
                    if (tupleListMethod.Item1 != null)
                    {
                        FillPagination(tupleListMethod.Item2, pageIndex, 0);
                        messageVO = tupleListMethod.Item1;
                        SetpMessage("alert alert-secondary");
                    }
                    else if(tupleListMethod.Item2 != null && tupleListMethod.Item2.Count() > 0)
                    {
                        Tuple<MessageVO, long?> tupleCountMethod = ExampleImpl.TotalRecords();

                        if (tupleCountMethod.Item1 != null)
                        {
                            FillPagination(tupleListMethod.Item2, pageIndex, 0);
                            messageVO = tupleCountMethod.Item1;
                            SetpMessage("alert alert-secondary");
                        }
                        else
                        {
                            FillGridView(tupleListMethod.Item2);
                            FillPagination(tupleListMethod.Item2, pageIndex, tupleCountMethod.Item2.Value);
                        }
                    }
                    else
                    {
                        FillPagination(tupleListMethod.Item2, pageIndex, 0);
                        messageVO.SetMessage(1, contentHTML.GetInnerTextById("notFoundTitle"), contentHTML.GetInnerTextById("recordsNotFound"));
                        SetpMessage("alert alert-info");
                    }
                }

            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                SetpMessage("alert alert-danger");
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

        private void FillGridView(List<Business.Entity.Example> examples)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[] 
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Rut", typeof(string)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("LastName", typeof(string)),
                new DataColumn("BirthDate", typeof(string)),
                new DataColumn("Active", typeof(string)),
                new DataColumn("Password", typeof(string))
            });
            foreach (var item in examples)
            {
                dataTable.Rows.Add(
                        item.Id,
                        item.Rut,
                        item.Name,
                        item.LastName,
                        item.BirthDate.ToString("yyyy-MM-dd"),
                        (item.Active) ? "VERDADERO" : "FALSO",
                        item.Password
                    );
            }

            gvExamples.DataSource = dataTable;
            gvExamples.DataBind();
        }

        private void FillPagination(List<Business.Entity.Example> examples, int pageIndex, long totalRecords)
        {
            int totalPages = 0;
            if (examples != null && examples.Count() > 0)
            {
                totalPages = (int)Math.Ceiling((double)totalRecords / Useful.GetPageSizeMaximun());
                if (pageIndex == 1)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", "page-item disabled");
                    HtmlGenericControl span = new HtmlGenericControl("span");
                    span.Attributes.Add("class", "page-link");
                    span.InnerText = "Anterior";
                    li.Controls.Add(span);
                    uPagination.Controls.Add(li);
                }
                else
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", "page-item");
                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("class", "page-link");
                    a.Attributes.Add("href", $"List.aspx?pageIndex={pageIndex - 1}");
                    a.InnerText = "Anterior";
                    li.Controls.Add(a);
                    uPagination.Controls.Add(li);
                }

                for (int i = 1; i < totalPages + 1; i++)
                {
                    if (pageIndex == i)
                    {
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes.Add("class", "page-item active");
                        li.Attributes.Add("aria-current", "page");
                        HtmlGenericControl span = new HtmlGenericControl("span");
                        span.Attributes.Add("class", "page-link");
                        span.InnerText = i.ToString();
                        li.Controls.Add(span);
                        uPagination.Controls.Add(li);
                    }
                    else
                    {
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes.Add("class", "page-item");
                        HtmlGenericControl a = new HtmlGenericControl("a");
                        a.Attributes.Add("class", "page-link");
                        a.Attributes.Add("href", $"List.aspx?pageIndex={i}");
                        a.InnerText = i.ToString();
                        li.Controls.Add(a);
                        uPagination.Controls.Add(li);
                    }
                }

                if (pageIndex == totalPages)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", "page-item disabled");
                    HtmlGenericControl span = new HtmlGenericControl("span");
                    span.Attributes.Add("class", "page-link");
                    span.InnerText = "Siguiente";
                    li.Controls.Add(span);
                    uPagination.Controls.Add(li);
                }
                else
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.Attributes.Add("class", "page-item");
                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("class", "page-link");
                    a.Attributes.Add("href", $"List.aspx?pageIndex={pageIndex + 1}");
                    a.InnerText = "Siguiente";
                    li.Controls.Add(a);
                    uPagination.Controls.Add(li);
                }
            }
            else
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes.Add("class", "page-item disabled");
                HtmlGenericControl span = new HtmlGenericControl("span");
                span.Attributes.Add("class", "page-link");
                span.InnerText = "Sin Resultados";
                li.Controls.Add(span);
                uPagination.Controls.Add(li);
            }
        }
        
        protected void lbDownloadExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Tuple<MessageVO, ExampleExcelDTO> tupleExcelMethod = ExampleImpl.Excel();
                if (tupleExcelMethod.Item1 != null)
                {                    
                    Session["MessageVODownload"] = tupleExcelMethod.Item1;
                    Response.Redirect("~/Pages/Example/Download.aspx", false);
                }
                else
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={tupleExcelMethod.Item2.FileName}");
                    Response.BinaryWrite(tupleExcelMethod.Item2.FileContent);
                    Response.Flush();
                }
            }
            catch (Exception ex)
            {
                
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                Session["ExceptionDownload"] = messageVO;
                Response.Redirect("~/Pages/Example/Download.aspx", false);
            }
        }

        protected void lbDownloadPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Tuple<MessageVO, ExamplePDFDTO> tuplePDFMethod = ExampleImpl.PDF();
                if (tuplePDFMethod.Item1 != null)
                {
                    Session["MessageVODownload"] = tuplePDFMethod.Item1;
                    Response.Redirect("~/Pages/Example/Download.aspx", false);
                }
                else
                {
                    Response.ContentType = "application/pdf";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={tuplePDFMethod.Item2.FileName}");
                    Response.BinaryWrite(tuplePDFMethod.Item2.FileContent);
                    Response.Flush();
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                Session["ExceptionDownload"] = messageVO;
                Response.Redirect("~/Pages/Example/Download.aspx", false);
            }
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Tuple<MessageVO, bool?> tupleDeleteMethod = ExampleImpl.Delete(Convert.ToInt32(hfId.Value));
                if (tupleDeleteMethod.Item1 != null)
                {
                    Session["MessageVODelete"] = tupleDeleteMethod.Item1;
                    Response.Redirect("~/Pages/Example/Delete.aspx", false);
                }
                else
                {
                    Session["Delete"] = tupleDeleteMethod.Item2.Value;
                    Response.Redirect("~/Pages/Example/Delete.aspx", false);
                }
            }
            catch (Exception ex)
            {
                messageVO.SetMessage(0, contentHTML.GetInnerTextById("exceptionTitle"), ex.GetOriginalException().Message);
                Session["ExceptionDelete"] = messageVO;
                Response.Redirect("~/Pages/Example/Delete.aspx", false);
            }
        }
    }
}