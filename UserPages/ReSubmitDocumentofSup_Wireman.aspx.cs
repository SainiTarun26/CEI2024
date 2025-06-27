using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;
using CEIHaryana.Officers;
using CEIHaryana.SiteOwnerPages;
using Pipelines.Sockets.Unofficial.Arenas;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.UserPages
{
    public partial class ReSubmitDocumentofSup_Wireman : System.Web.UI.Page
    {
        //Created By Neeraj 27-June-2025
        CEI CEI = new CEI();
        string Category;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session["WiremanId"] = "Paru19651013";
                    if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                    {
                        hdnSupWiremanId.Value = Session["SupervisorID"].ToString();                     
                        hdnCategory.Value = "Supervisor";
                        bindData(hdnSupWiremanId.Value, hdnCategory.Value);
                    }
                    else if (Convert.ToString(Session["WiremanId"]) != null && Convert.ToString(Session["WiremanId"]) != "")
                    {
                        hdnSupWiremanId.Value = Session["WiremanId"].ToString();                      
                        hdnCategory.Value = "Wireman";
                        bindData(hdnSupWiremanId.Value, hdnCategory.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ////fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    //ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    string fileName = e.CommandArgument.ToString();
                    string folderPath = Server.MapPath(fileName);
                    string filePath = Path.Combine(folderPath);
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hdnSupWiremanId.Value != null && hdnSupWiremanId.Value != string.Empty)
                {
                    Category = hdnCategory.Value;
                    int successCount = 0;
                    int failCount = 0;
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");
                        Label lblDocumentName = (Label)row.FindControl("lblDocumentName");
                        Label LblDocumentID = (Label)row.FindControl("LblDocumentID");
                        Label lblTempId = (Label)row.FindControl("lblTempId");
                        Label lblFileName = (Label)row.FindControl("lblFileName");
                        if (fileUpload.HasFile)
                        {
                            if (LblDocumentID.Text == "31" || LblDocumentID.Text == "32")
                            {
                                if (!IsValidPhoto(fileUpload))
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "UploadError", "alert('Please upload a valid image file (.jpg, .jpeg, .png) (Max: 1MB)');", true);
                                    fileUpload.Focus();
                                    return;
                                }
                                                                               
                            }
                            else if(LblDocumentID.Text == "41")
                            {
                                if (!IsValidZipOrPdf(fileUpload))
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "UploadError", "alert('Please upload a valid .zip or .pdf file (Max: 5MB)');", true);
                                    fileUpload.Focus();
                                    return;
                                }                            
                            }
                            else
                            {                             
                                if (!ValidatePdfFile(fileUpload))
                                {
                                    ScriptManager.RegisterStartupScript(this, GetType(), "UploadError", "alert('Please upload pdf only (Max: 1MB)');", true);
                                    fileUpload.Focus();
                                    return;
                                }
                            }
                        
                            if (!Directory.Exists(Server.MapPath("/Attachment/" + lblTempId.Text + "/" + hdnSupWiremanId.Value)))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + lblTempId.Text + "/" + hdnSupWiremanId.Value));
                            }
                            string path = "";
                            path = "/Attachment/" + lblTempId.Text + "/" + hdnSupWiremanId.Value;  
                            string fileName1 = lblDocumentName.Text + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                            string filePathInfo = "";
                            filePathInfo = Server.MapPath(path + "/" + fileName1);
                            fileUpload.PostedFile.SaveAs(filePathInfo);
                            int x = CEI.ReSubmitDocumentForSupWireman(Convert.ToInt64(lblTempId.Text), hdnCategory.Value, Convert.ToInt32(LblDocumentID.Text), lblDocumentName.Text, lblFileName.Text, filePathInfo, hdnSupWiremanId.Value);
                            if (x > 0)
                            {
                                successCount++;
                            }
                            else
                            {
                                failCount++;
                            }


                        }
                       
                    }                   
                    if (successCount > 0 && failCount == 0)
                    {
                       string script = $"alert('Document Re-Submitted Successfully.');";
                       ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertRedirect", script, true);
                       return;
                    }
                  
                    else
                    {
                        string script = $"alert('Try Again.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "AlertRedirect", script, true);
                        return;
                    }

                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private bool IsValidPhoto(FileUpload fileUpload)
        {
            if (!fileUpload.HasFile) return false;

            string ext = Path.GetExtension(fileUpload.FileName).ToLower();
            if (ext != ".jpg" && ext != ".jpeg" && ext != ".png") return false;

            if (fileUpload.PostedFile.ContentLength > 1048576) return false; // 1MB

            return true;
        }
   

        private bool ValidatePdfFile(FileUpload fileUpload)
        {
            if (!fileUpload.HasFile) return false;

            string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
            if (fileExtension != ".pdf")
            {
                return false;
            }

            if (fileUpload.PostedFile.ContentLength > 1048576)
            {
                return false;
            }

            return true; 
        }
        private bool IsValidZipOrPdf(FileUpload fileUpload)
        {
            string[] allowedExtensions = { ".zip", ".pdf" };
            string extension = Path.GetExtension(fileUpload.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                return false;

            int maxFileSizeBytes = 5 * 1024 * 1024; // 5MB
            return fileUpload.PostedFile.ContentLength <= maxFileSizeBytes;
        }
        public void bindData(string Id, string Category)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentForWiremanSupervisior(Id, Category);
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

        }

    }
}