using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class SLDReturn : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != string.Empty)
                {

                }
                else
                {

                }
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string SiteOwnerId = Session["SiteOwnerId_Sld_Indus"].ToString();
                string SldId = Session["Sld_id"].ToString();
                int maxFileSize = 2 * 1024 * 1024;
                string filePathInfo = "";

                if (customFile.HasFile && customFile.PostedFile != null && customFile.PostedFile.ContentLength <= maxFileSize)
                {

                    string FilName = string.Empty;
                    FilName = Path.GetFileName(customFile.PostedFile.FileName);


                    if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/"));
                    }

                    //string ext = Path.GetExtension(customFile.FileName);
                    string ext = ".pdf";
                    string path = "/Attachment/" + SiteOwnerId + "/Sld Document/";
                    string fileName = "Sld Document" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                    string filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
                    customFile.SaveAs(filePathInfo2);
                    filePathInfo = path + fileName;


                }
                else
                {
                    throw new Exception("Please Upload Pdf Files 2 Mb Only");
                }
                CEI.UpdateSLD(SldId, filePathInfo, SiteOwnerId);
                string script = $"alert('SLD Document Re submitted successfully.'); window.location='SLD_Status.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
            }
            catch (Exception ex)
            { 
                string errorMessage = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
            }
        }
    }
}