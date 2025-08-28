using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;
using AjaxControlToolkit;

namespace CEIHaryana.SiteOwner_Verification
{
    public partial class Pan_Card_Verification : System.Web.UI.Page
    {
        string fileName, PanTanNumber; 
        CEI CEI = new CEI();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                    GetDataOfSiteOwner();
                }
                else
                {

                }

            }


        }
        protected void GetDataOfSiteOwner()
        {
            txtpan.Text = Session["SiteOwnerId"].ToString();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            DataTable dt = new DataTable();
            dt = CEI.GetSiteOwnerDetailsforverifying(txtpan.Text.Trim());
            txtApplicanttype.Text= dt.Rows[0]["ApplicantType"].ToString();
            txtInstallationFor.Text= dt.Rows[0]["ContractorType"].ToString();
            txtOwnerName.Text= dt.Rows[0]["OwnerName"].ToString();
            txtaddress.Text= dt.Rows[0]["Address"].ToString();
            txtcontact.Text= dt.Rows[0]["ContactNo"].ToString();
            txtemail.Text= dt.Rows[0]["Email"].ToString();
        }
        public string UploadPannumber()
        {
            string path = "";
            fileName = "CopyOfPanCard" + ".pdf";
            string filePathInfo2 = "";
            PanTanNumber = txtpan.Text.Trim();
            if (Path.GetExtension(FileUpload1.FileName).ToLower() == ".pdf")
            {

                if (FileUpload1.PostedFile.ContentLength <= 1048576)
                {
                    string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    if (!Directory.Exists(Server.MapPath("~/Attachment/" + "/SiteOwner/" + PanTanNumber + "/" + "CopyOfPanCard" + "/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/Attachment/" + "/SiteOwner/" + PanTanNumber + "/" + "CopyOfPanCard" + "/"));
                    }

                    string ext = FileUpload1.PostedFile.FileName.Split('.')[1];

                    path = "/Attachment/" + "/SiteOwner/" + PanTanNumber + "/" + "CopyOfPanCard" + "/";
                    //string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                    //string fileName = DocSaveName + "." + ext;


                    filePathInfo2 = Server.MapPath("~/Attachment/" + "/SiteOwner/" + PanTanNumber + "/" + "CopyOfPanCard" + "/" + fileName);

                    FileUpload1.PostedFile.SaveAs(filePathInfo2);

                }
                else
                {
                    fileName = "";
                    throw new Exception("Please Upload Pdf Files Less Than 1 Mb Only");
                }
            }
            else
            {
                fileName = "";
                throw new Exception("Please Upload Pdf Only");
            }
            path = path + fileName;
            return path;
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    fileName = UploadPannumber();
                    if (fileName != "" && fileName != null)
                    {
                        CEI.UpdatePendingsignatureOfOwner(txtpan.Text.Trim(), fileName);
                        Session["SiteOwnerId"] = txtpan.Text;
                        Session["logintype"] = "SiteOwner";
                        Response.Cookies["SiteOwnerId"].Value = txtpan.Text;
                        Response.Cookies["logintype"].Value = "SiteOwner";
                        Reset();
                        string script = "alert('Pan Number Updated Successfully'); window.location='/SiteOwnerPages/InspectionHistory.aspx';";                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please Upload file');", true);
                }

            } 
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
            }

        }
        protected void Reset()
        {
            txtpan.Text = "";
            //Session["SiteOwnerId"] = "";
            txtApplicanttype.Text = "";
            txtInstallationFor.Text = "";
            txtOwnerName.Text = "";
            txtaddress.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
        }
    }
}