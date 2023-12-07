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
                }
            }
            catch { }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            id = Session["PendingPaymentId"].ToString();
            string FileName = string.Empty;
            string filepath = string.Empty;
            string flpPhotourl = string.Empty;
            if (FileUpload1.PostedFile.FileName.Length > 0)
            {
                FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (!Directory.Exists(Server.MapPath("~/Attachment/" + id + "/ChallanReport/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + id + "/ChallanReport/"));
                }

                string ext = FileUpload1.PostedFile.FileName.Split('.')[1];
                string path = "";
                path = "/Attachment/" + id + "/ChallanReport/";
                string fileName = "ChallanReport" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                string filePathInfo2 = "";
                filePathInfo2 = Server.MapPath("~/Attachment/" + id + "/ChallanReport/" + fileName);
                FileUpload1.PostedFile.SaveAs(filePathInfo2);
                flpPhotourl = path + fileName;
            }
            CEI.updateInspectionPending(id, txttransactionId.Text, txttransactionDate.Text, flpPhotourl);
        }
    }
}