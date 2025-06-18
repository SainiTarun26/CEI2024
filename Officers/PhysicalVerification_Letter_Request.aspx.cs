using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class PhysicalVerification_Letter_Request : System.Web.UI.Page
    {
        //Page created by navneet 18-June-2025
        CEI CEI = new CEI(); string ApplicationId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  
                ApplicationId = Session["ApplicationId"].ToString();
                GetHeaderDetailsWithId(ApplicationId);
                BindApplicationLogDetails(ApplicationId);
               // Session["ApplicationId"] = "";
            }

        }
        private void GetHeaderDetailsWithId(string licApplicationId)
        {
            DataSet ds = CEI.Licence_XenfinalRecommend_GetHeaderDetails(licApplicationId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                txtLicenceType.Text = row["Categary"].ToString();
                txtApplicationId.Text = row["ApplicationId"].ToString();
                txtCommiteeId.Text = row["CommitteeId"].ToString();
                txtApplicantName.Text = row["Name"].ToString();
                txtRegistrationId.Text = row["RegistrationId"].ToString();
            }
        }
        private void BindApplicationLogDetails(string licApplicationId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Get_Licence_ApplicationLogDetails(licApplicationId);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    string script = "alert(\"No record found for this application.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }

        protected void lnkbtnDownload_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Print_Forms/VerificationLetter.aspx", false);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string StaffID = Session["StaffID"].ToString();
                if (Uploadfile.HasFile)
                {
                    if (Path.GetExtension(Uploadfile.FileName).ToLower() == ".pdf")
                    {

                        //if (Uploadfile.PostedFile.ContentLength <= 1048576)
                        //{
                            string FileName = Path.GetFileName(Uploadfile.PostedFile.FileName);

                            if (!Directory.Exists(Server.MapPath("~/Attachment/" + "XenVerifiedLetters" + "/" + ApplicationId + "/")))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + "XenVerifiedLetters" + "/" + ApplicationId + "/"));
                            }
                            string ext = Uploadfile.PostedFile.FileName.Split('.')[1];
                            string path = "";
                            path = "/Attachment/" + "XenVerifiedLetters" + "/" + ApplicationId + "/";
                            //string fileName = DocSaveName + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + "." + ext;
                            //string fileName = DocSaveName + "." + ext;
                            string fileName = ApplicationId + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";

                            string filePathInfo2 = "";

                            filePathInfo2 = Server.MapPath("~/Attachment/" + "XenVerifiedLetters" + "/" + ApplicationId + "/" + fileName);

                            Uploadfile.PostedFile.SaveAs(filePathInfo2);
                            CEI.AddXenVerifiedLetter(txtApplicationId.Text, StaffID, path + fileName); 
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata2();", true);
                        //}
                        //else
                        //{

                        //}
                    }
                    else
                    {

                        throw new Exception("Please Upload PDF Only");
                    }
                }
                else
                {
                    throw new Exception("Please Upload Document");
                }
            }
            catch (Exception ex)
            {

                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }
    }
}