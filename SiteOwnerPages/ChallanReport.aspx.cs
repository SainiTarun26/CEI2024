using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class ChallanReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string id = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null)
                    {
                     //  string Text = Session["SiteOwnerId"].ToString() + "-" + Session["Data1"].ToString() + "-" + Session["Data2"].ToString();
                     //   txtInspectionDetails.Text = Text;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            { }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {



                id = Session["PendingPaymentId"].ToString();
                string FileName = string.Empty;
                string filepath = string.Empty;
                string flpPhotourl = string.Empty;

                if (FileUpload1.HasFile && FileUpload1.PostedFile.ContentLength <= 500 * 1024) // Check if file exists and size is within limit (500 KB)
                {
                    string ext = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();

                    if (ext == ".pdf") // Check if the file extension is PDF
                    {
                        FileName = "ChallanReport" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ChallanReport/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ChallanReport/"));
                        }
                        string path = "/Attachment/" + id + "/ChallanReport/";
                        string filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ChallanReport/" + FileName);

                        FileUpload1.SaveAs(filePathInfo2);
                        flpPhotourl = path + FileName;
                    }
                    else
                    {
                        string alert = "alert('File Format Not Supported. Only PDF files are allowed.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                        return;
                    }
                }
                else
                {
                    string alert = "alert('File exceeds maximum size limit (500 KB) or no file uploaded.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "JScript", alert, true);
                    return;
                }




                //if (FileUpload1.PostedFile.FileName.Length > 0)
                //{

                //    FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                //    if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ChallanReport/")))
                //    {
                //        Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ChallanReport/"));
                //    }

                //    string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                //    string path = "";
                //    path = "/Attachment/" + id + "/ChallanReport/";
                //    string fileName = "ChallanReport" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                //    string filePathInfo2 = "";
                //    filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ChallanReport/" + fileName);
                //    FileUpload1.PostedFile.SaveAs(filePathInfo2);
                //    flpPhotourl = path + fileName;
                //}
                CEI.updateInspectionPending(id, txttransactionId.Text, txttransactionDate.Text, flpPhotourl);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
            }
            catch { }
        }
    }
}