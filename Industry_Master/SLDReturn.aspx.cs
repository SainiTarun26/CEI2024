using CEI_PRoject;
using CEIHaryana.Model.Industry;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        Industry_Api_Post_DataformatModel ApiPostformatresult = new Industry_Api_Post_DataformatModel();
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != string.Empty)
                    {
                        Page.Session["ClickCount"] = "0";

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata_InvalidSession();", true);
                    }
                }
                catch (Exception ex)
                {

                    string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
                }
               
            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int ClickCount = 0;
            ClickCount = Convert.ToInt32(Session["ClickCount"]);
            if (ClickCount < 1)
            {
                ClickCount = ClickCount + 1;
                Session["ClickCount"] = ClickCount;
                int checksuccessmessage = 0;
                try
                {
                    string SiteOwnerId = Session["SiteOwnerId_Sld_Indus"].ToString();
                    string SldId = Session["Sld_id"].ToString();
                    int maxFileSize = 2 * 1024 * 1024;
                    string filePathInfo = "";
                    string filePathInfo1 = "";

                    //if (customFile.HasFile && customFile.PostedFile != null && customFile.PostedFile.ContentLength <= maxFileSize)
                    //{

                    //    string FilName = string.Empty;
                    //    FilName = Path.GetFileName(customFile.PostedFile.FileName);


                    //    if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/")))
                    //    {
                    //        Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/"));
                    //    }

                    //    //string ext = Path.GetExtension(customFile.FileName);
                    //    string ext = ".pdf";
                    //    string path = "/Attachment/" + SiteOwnerId + "/Sld Document/";
                    //    string fileName = "Sld Document" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                    //    string filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
                    //    customFile.SaveAs(filePathInfo2);
                    //    filePathInfo = path + fileName;


                    //}
                    //else
                    //{
                    //    throw new Exception("Please Upload Pdf Files 2 Mb Only");                }
                    ////CEI.UpdateSLD(SldId, filePathInfo, SiteOwnerId);
                    //string script = $"alert('SLD Document Re submitted successfully.'); window.location='SLD_Status.aspx';";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
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
                                int x = CEI.UpdateSLD_Industry(SldId, filePathInfo, filePathInfo1, SiteOwnerId, transaction);
                                if (x == 2)
                                {
                                    filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
                                    filePathInfo3 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/" + fileName1);
                                    customFile.SaveAs(filePathInfo2);
                                    File.SaveAs(filePathInfo3);
                                    //string script = $"alert('SLD Document Re submitted successfully.'); window.location='SLD_Status.aspx';";
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
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
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
                }



                checksuccessmessage = 1;

                try
                {
                    string actiontype = "ReSubmit";

                    List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat_Sld(Convert.ToInt32(Session["Sld_id"].ToString()), actiontype, Session["projectid_Sld_Indus"].ToString(), Session["Serviceid_Sld_Indus"].ToString(), Session["SiteOwnerId_Sld_Indus"].ToString());
                    foreach (var ApiPostformatresult in ApiPostformatResults)
                    {
                        if (ApiPostformatresult.PremisesType == "Industry")
                        {
                            // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                            string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                            // string accessToken = "dfsfdsfsfsdf";

                            logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                          "https://staging.investharyana.in/api/project-service-logs-external_UHBVN",
                                          new Industry_Inspection_StageWise_JsonDataFormat_Model
                                          {
                                              actionTaken = ApiPostformatresult.ActionTaken,
                                              commentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                              //commentDate = ApiPostformatresult.CommentDate,
                                              commentDate = ApiPostformatresult.CommentDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                                              comments = ApiPostformatresult.Comments,
                                              id = ApiPostformatresult.Id,
                                              projectid = ApiPostformatresult.ProjectId,
                                              serviceid = ApiPostformatresult.ServiceId
                                              //projectid = "245df444-1808-4ff6-8421-cf4a859efb4c",
                                              //serviceid = "e31ee2a6-3b99-4f42-b61d-38cd80be45b6"
                                          }, ApiPostformatresult, accessToken);

                            if (!string.IsNullOrEmpty(logDetails.ErrorMessage))
                            {
                                throw new Exception(logDetails.ErrorMessage);
                            }


                            CEI.LogToIndustryApiSuccessDatabase_Sld(
                            logDetails.Url,
                            logDetails.Method,
                            logDetails.RequestHeaders,
                            logDetails.ContentType,
                            logDetails.RequestBody,
                            logDetails.ResponseStatusCode,
                            logDetails.ResponseHeaders,
                            logDetails.ResponseBody,

                            new Industry_Api_Post_DataformatModel
                            {
                                InspectionId = ApiPostformatresult.InspectionId,
                                InspectionLogId = ApiPostformatresult.InspectionLogId,
                                IncomingJsonId = ApiPostformatresult.IncomingJsonId,
                                ActionTaken = ApiPostformatresult.ActionTaken,
                                CommentByUserLogin = ApiPostformatresult.CommentByUserLogin,
                                CommentDate = ApiPostformatresult.CommentDate,

                                Comments = ApiPostformatresult.Comments,
                                Id = ApiPostformatresult.Id,
                                ProjectId = ApiPostformatresult.ProjectId,
                                ServiceId = ApiPostformatresult.ServiceId,
                            }

                        );

                        }
                    }
                }
                catch (TokenManagerException ex)
                {
                    CEI.LogToIndustryApiErrorDatabase_Sld(
                        ex.RequestUrl,
                        ex.RequestMethod,
                        ex.RequestHeaders,
                        ex.RequestContentType,
                        ex.RequestBody,
                        ex.ResponseStatusCode,
                        ex.ResponseHeaders,
                        ex.ResponseBody,
                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ex.InspectionId,
                            InspectionLogId = ex.InspectionLogId,
                            IncomingJsonId = ex.IncomingJsonId,
                            ActionTaken = ex.ActionTaken,
                            CommentByUserLogin = ex.CommentByUserLogin,
                            CommentDate = ex.CommentDate,
                            Comments = ex.Comments,
                            Id = ex.Id,
                            ProjectId = ex.ProjectId,
                            ServiceId = ex.ServiceId,
                        }
                    );
                    // string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    //   ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }
                catch (IndustryApiException ex)
                {
                    CEI.LogToIndustryApiErrorDatabase_Sld(
                        ex.RequestUrl,
                        ex.RequestMethod,
                        ex.RequestHeaders,
                        ex.RequestContentType,
                        ex.RequestBody,
                        ex.ResponseStatusCode,
                        ex.ResponseHeaders,
                        ex.ResponseBody,
                        new Industry_Api_Post_DataformatModel
                        {
                            InspectionId = ex.InspectionId,
                            InspectionLogId = ex.InspectionLogId,
                            IncomingJsonId = ex.IncomingJsonId,
                            ActionTaken = ex.ActionTaken,
                            CommentByUserLogin = ex.CommentByUserLogin,
                            CommentDate = ex.CommentDate,

                            Comments = ex.Comments,
                            Id = ex.Id,
                            ProjectId = ex.ProjectId,
                            ServiceId = ex.ServiceId,
                        }
                    );

                    // string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.ResponseBody.ToString() + "')", true);
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('{errorMessage}')", true);
                }


                if (checksuccessmessage == 1)
                {
                    string script = $"alert('SLD Document Re submitted successfully.'); window.location='SLD_Status.aspx';";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='SLD_Status.aspx'", true);
            }
        }
    }
}