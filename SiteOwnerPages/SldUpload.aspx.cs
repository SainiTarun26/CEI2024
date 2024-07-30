using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;
using CEIHaryana.Contractor;
using System.IO;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SldUpload : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                if (Session["SiteOwnerId"] != null)
                {
                    BindGrid();
                }
                else
                {

                }
            }

        }
        public void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SldReturnHistory(LoginID);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                Documents.Visible = true;
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           string SiteOwnerId = Session["SiteOwnerId"].ToString();
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
            CEI.UploadSldDocument(SiteOwnerId, filePathInfo, SiteOwnerId);
            string script = $"alert('SLD Document submitted successfully.'); window.location='SiteOwnerDashboard.aspx';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();

               
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");

             
                if (status == "Returned")
                {
                    Documents.Visible = false;
                }
                if (status == "Rejected")
                {
                    Documents.Visible = false;
                }
               

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblId = (Label)row.FindControl("LblId");
                Label lblStatus = (Label)row.FindControl("lblStatus");
                if (lblStatus.Text.Trim().Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                {
                    // Show an alert if StatusType is Rejected
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cannot upload SLD document.');", true);
                }
                else
                {
                    Session["Sld_id"] = LblId.Text;
                    Response.Redirect("/SiteOwnerPages/SLDReturn.aspx", false);
                }
            }
            else
            {

            }
        }
    }
}