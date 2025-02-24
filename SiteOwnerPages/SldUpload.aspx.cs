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
                ddlSiteOwnerAdress.DataValueField = "Id";
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
                btnSubmit.Visible = true;
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           string SiteOwnerId = Session["SiteOwnerId"].ToString();
            string SiteOwnerName = Session["OwnerName"].ToString();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            int maxFileSize = 2 * 1024 * 1024;
            string filePathInfo = "";
            string filePathInfo1 = "";

            if (customFile.HasFile && customFile.PostedFile != null && customFile.PostedFile.ContentLength <= maxFileSize && File.HasFile && File.PostedFile != null && File.PostedFile.ContentLength <= maxFileSize)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        connection.Open();

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
                        //customFile.SaveAs(filePathInfo2);
                        filePathInfo = path + fileName;

                        //====================
                        string FilName1 = string.Empty;
                        FilName1 = Path.GetFileName(File.PostedFile.FileName);

                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/"));
                        }

                        string ex = Path.GetExtension(File.FileName);
                        string path1 = "/Attachment/" + SiteOwnerId + "/RequestLetter/";
                        string fileName1 = "RequestLetter" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                        string filePathInfo3 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/" + fileName1);
                        //File.SaveAs(filePathInfo3);
                        filePathInfo1 = path1 + fileName1;


                        transaction = connection.BeginTransaction();
                        int x = CEI.UploadSldDocument(SiteOwnerId, filePathInfo, filePathInfo1, SiteOwnerId, ddlSiteOwnerAdress.SelectedItem.ToString(), SiteOwnerName, "", transaction);
                        if (x == 2)
                        {
                            filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
                            filePathInfo3 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/" + fileName1);
                            customFile.SaveAs(filePathInfo2);
                            File.SaveAs(filePathInfo3);
                            string script = $"alert('SLD Document submitted successfully.'); window.location='SiteOwnerDashboard.aspx';";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }

                    }
                    catch (Exception ex)
                    {
                        transaction?.Rollback();
                        string errorMessage = ex.Message.Replace("'", "\\'");
                        ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                        return;
                    }
                    finally
                    {
                        transaction?.Dispose();
                        connection.Close();
                    }
                }
            }
            else
            {
                throw new Exception("Please Upload Pdf Files 2 Mb Only");
            }
             
        }
           
        

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();

               
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                btnSubmit.Visible = true;
                if (status == "Returned")
                {
                    Documents.Visible = false;
                    btnSubmit.Visible = false;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                if (status == "Rejected")
                {
                    Documents.Visible = false;
                    btnSubmit.Visible = false;
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
            //if(e.CommandName == "View")
            //{

            //    string fileName = e.CommandArgument.ToString();
            //    string folderPath = Server.MapPath(fileName);
            //    string filePath = Path.Combine(folderPath);
            //    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
            //    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

            //}
            
        }
    }
}