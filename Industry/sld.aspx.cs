using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["SiteOwnerId"] != null)
                {
                    Session["SiteOwnerId"] = "JVCBN5647K";
                    BindGrid();
                    BindAdress();
                }
                else
                {

                }
            }

        }
        private void BindAdress()
        {
            try
            {
                string id = Session["SiteOwnerId"].ToString();
                DataSet dsAdress = new DataSet();
                dsAdress = CEI.GetOwnerAdress(id);
                string OwnerName = dsAdress.Tables[0].Rows[0]["OwnerName"].ToString();
                Session["OwnerName"] = OwnerName;
                ddlSiteOwnerAdress.DataSource = dsAdress;
                ddlSiteOwnerAdress.DataTextField = "FullAddress";
                ddlSiteOwnerAdress.DataValueField = "FullAddress";
                ddlSiteOwnerAdress.DataBind();
                ddlSiteOwnerAdress.Items.Insert(0, new ListItem("Select", "0"));
                dsAdress.Clear();
            }
            catch
            {

            }
        }

        public void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SldHistoryinIndustry(LoginID);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            string SiteOwnerId = Session["SiteOwnerId"].ToString();
            string SiteOwnerName = Session["OwnerName"].ToString();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            int maxFileSize = 2 * 1024 * 1024;
            string filePathInfo = "";

            if (customFile.HasFile && customFile.PostedFile != null && customFile.PostedFile.ContentLength <= maxFileSize)
            {
                try
                {
                    string FilName = string.Empty;
                    FilName = Path.GetFileName(customFile.PostedFile.FileName);


                    if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/"));
                    }

                    string ext = Path.GetExtension(customFile.FileName);
                    string path = "/Attachment/" + SiteOwnerId + "/Sld Document/";
                    string fileName = "Sld Document" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                    string filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
                    customFile.SaveAs(filePathInfo2);
                    filePathInfo = path + fileName;

                }
                catch (Exception ex)
                {
                    //throw new Exception("Please Upload Pdf Files 1 Mb Only");
                }
            }
            else
            {
                throw new Exception("Please Upload Pdf Files 2 Mb Only");
            }
            CEI.UploadSldDocument(SiteOwnerId, filePathInfo, SiteOwnerId, ddlSiteOwnerAdress.SelectedItem.ToString(), SiteOwnerName);
            BindGrid();
            string script = $"alert('SLD Document submitted successfully.');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            if (e.CommandName == "Select1")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();

                LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("lnkDocument");
                LinkButton linkButton1 = (LinkButton)e.Row.FindControl("lnkDocument1");

                if (status == "Rejected")
                {
                    lnkDocumemtPath.Visible = true;
                    linkButton1.Visible = false;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                if (status == "Returned")
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;

                }
                else
                {

                    lnkDocumemtPath.Visible = false;
                    linkButton1.Visible = true;
                }
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch { }
        }
    }
}