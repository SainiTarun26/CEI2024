using CEI_PRoject;
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

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SLDReturn : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Session["ClickCount"] = "0";

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

            int ClickCount = 0;
            ClickCount = Convert.ToInt32(Session["ClickCount"]);
            if (ClickCount < 1)
            {
                ClickCount = ClickCount + 1;
                Session["ClickCount"] = ClickCount;
                string SiteOwnerId = Session["SiteOwnerId"].ToString();
            string SldId = Session["Sld_id"].ToString();
            int maxFileSize = 2 * 1024 * 1024;
            string filePathInfo = "";
            string filePathInfo1 = "";

            //    if (customFile.HasFile && customFile.PostedFile != null && customFile.PostedFile.ContentLength <= maxFileSize && File.HasFile && File.PostedFile != null && File.PostedFile.ContentLength <= maxFileSize)
            //    {

            //            string FilName = string.Empty;
            //            FilName = Path.GetFileName(customFile.PostedFile.FileName);


            //            if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/")))
            //            {
            //                Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/"));
            //            }

            //            //string ext = Path.GetExtension(customFile.FileName);
            //            string ext = ".pdf";
            //            string path = "/Attachment/" + SiteOwnerId + "/Sld Document/";
            //            string fileName = "Sld Document" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
            //            string filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
            //            customFile.SaveAs(filePathInfo2);
            //            filePathInfo = path + fileName;
            //        // second file 
            //        string FilName1 = string.Empty;
            //        FilName1 = Path.GetFileName(File.PostedFile.FileName);

            //        if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/")))
            //        {
            //            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/"));
            //        }

            //        string ex = Path.GetExtension(File.FileName);
            //        string path1 = "/Attachment/" + SiteOwnerId + "/RequestLetter/";
            //        string fileName1 = "RequestLetter" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
            //        string filePathInfo3 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/" + fileName);
            //        //File.SaveAs(filePathInfo3);
            //        filePathInfo1 = path1 + fileName1;

            //    }
            //    else
            //    {
            //        throw new Exception("Please Upload Pdf Files 2 Mb Only");
            //    }

            //    CEI.UpdateSLD(SldId, filePathInfo, SiteOwnerId);
            //    string script = $"alert('SLD Document Re submitted successfully.'); window.location='SiteOwnerDashboard.aspx';";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
            //}
            //catch (Exception ex) 
            //{
            //    string errorMessage = ex.Message;
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
            //}
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
                        int x = CEI.UpdateSLD(SldId, filePathInfo, filePathInfo1, SiteOwnerId,transaction);
                        if (x == 2)
                        {
                            filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
                            filePathInfo3 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/" + fileName1);
                            customFile.SaveAs(filePathInfo2);
                            File.SaveAs(filePathInfo3);
                            string script = $"alert('SLD Document Re submitted successfully.'); window.location='SiteOwnerDashboard.aspx';";
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
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='SLD_Status.aspx'", true);
            }

        }
    }
}


    
