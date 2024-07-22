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
                   
                }
                else
                {

                }
            }

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
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Copy of Work Order/"));
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

       

    }
}