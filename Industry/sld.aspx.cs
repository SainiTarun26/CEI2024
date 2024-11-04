using AjaxControlToolkit;
using CEI_PRoject;
using CEIHaryana.Model.Industry;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;

namespace CEIHaryana.Industry
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        Industry_Api_Post_DataformatModel ApiPostformatresult = new Industry_Api_Post_DataformatModel();
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Session["SiteOwnerId_Sld_Indus"] != null)
                {
                    //Session["SiteOwnerId_Sld_Indus"] = "JVCBN5647K";
                    BindGrid();
                    BindAdress();
                    BindGridview2();
                }
                else
                {

                }
            }
        }
        public void BindGridview2()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId_Sld_Indus"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SldReturnHistory(LoginID);
            if (ds.Rows.Count > 0)
            {
                GridView2.DataSource = ds;
                GridView2.DataBind();
            }

            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
                SiteAddress.Visible = true;
                btnVerify.Visible = true;
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        private void BindAdress()
        {
            try
            {
                string id = Session["SiteOwnerId_Sld_Indus"].ToString();
                DataSet dsAdress = new DataSet();
                dsAdress = CEI.GetOwnerAdress(id);
                string OwnerName = dsAdress.Tables[0].Rows[0]["OwnerName"].ToString();
                Session["OwnerName"] = OwnerName;
                ddlSiteOwnerAdress.DataSource = dsAdress;
                ddlSiteOwnerAdress.DataTextField = "FullAddress";
                ddlSiteOwnerAdress.DataValueField = "FullAddress";
                ddlSiteOwnerAdress.DataBind();
                ddlSiteOwnerAdress.Items.Insert(0, new ListItem("Select", "0"));
                dsAdress.Clear();
            }
            catch (Exception ex)
            {

            }
        }

        public void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId_Sld_Indus"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SldHistoryinIndustry(LoginID);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                // string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            int checksuccessmessage = 0;
            string SiteOwnerId = Session["SiteOwnerId_Sld_Indus"].ToString();
            string SiteOwnerName = Session["OwnerName"].ToString();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            int maxFileSize = 2 * 1024 * 1024;
            string filePathInfo = "";


            string alreadyReq = CEI.GetIndustry_InsertSdlData_Check(SiteOwnerId);
            if (alreadyReq == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There Is Already Incomplete Active Running Service For You.')", true);
                return;
            }

            string serverStatus = CEI.CheckServerStatus("https://investharyana.in");
            // string serverStatus = CEI.CheckServerStatus("https://investharyana.in/api/project-service-logs-external_UHBVN");
            if (serverStatus != "Server is reachable.")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('HEPC Server Is Not Responding . Please Try After Some Time')", true);
                return;
            }

            if (customFile.HasFile && customFile.PostedFile != null && customFile.PostedFile.ContentLength <= maxFileSize)
            {
                try
                {
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
            int newSLD_ID = CEI.UploadSldDocument_Industry(SiteOwnerId, filePathInfo, SiteOwnerId, ddlSiteOwnerAdress.SelectedItem.ToString(), SiteOwnerName, "Industry", Session["Serviceid_Sld_Indus"].ToString());
            BindGrid();

            checksuccessmessage = 1;

            try
            {
                string actiontype = "Submit";

                Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat_Sld(newSLD_ID, actiontype, Session["projectid_Sld_Indus"].ToString(), Session["Serviceid_Sld_Indus"].ToString(), Session["SiteOwnerId_Sld_Indus"].ToString());

                if (ApiPostformatresult.PremisesType == "Industry")
                {
                    // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                    string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                    // string accessToken = "dfsfdsfsfsdf";

                    logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                  "https://investharyana.in/api/project-service-logs-external_UHBVN",
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
                string script = $"alert('SLD Document submitted successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            if (e.CommandName == "Select1")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();

                LinkButton lnkDocumemtPath = (LinkButton)e.Row.FindControl("lnkDocument");
                LinkButton linkButton1 = (LinkButton)e.Row.FindControl("lnkDocument1");

                if (status == "Rejected")
                {
                    lnkDocumemtPath.Visible = true;
                    linkButton1.Visible = false;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                if (status == "Returned")
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                    lnkDocumemtPath.Visible = false;
                    linkButton1.Visible = true;
                }
                else
                {

                    lnkDocumemtPath.Visible = false;
                    linkButton1.Visible = true;
                }
            }

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch { }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();


                Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                btnVerify.Visible = true;
                if (status == "Returned")
                {
                    SiteAddress.Visible = false;
                    btnVerify.Visible = false;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                if (status == "Rejected")
                {
                    SiteAddress.Visible = false;
                    btnVerify.Visible = false;
                }



            }

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblId = (Label)row.FindControl("LblId");
                Label lblStatus = (Label)row.FindControl("lblStatus");
                if (lblStatus.Text.Trim().Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cannot upload SLD document.');", true);
                }
                else
                {
                    Session["Sld_id_Indus"] = LblId.Text;
                    ReSubmit.Visible = true;
                    btnReSubmit.Visible = true;
                    //Response.Redirect("/SiteOwnerPages/SLDReturn.aspx", false);
                }
            }
        }

        protected void btnReSubmit_Click(object sender, EventArgs e)
        {
            int checksuccessmessage = 0;
            string SiteOwnerId = Session["SiteOwnerId_Sld_Indus"]?.ToString();
            string SldId = Session["Sld_id_Indus"]?.ToString();
            if (string.IsNullOrEmpty(SiteOwnerId) || string.IsNullOrEmpty(SldId))
            {
                throw new Exception("Session variables are missing.");
            }


            if (FileUpload1.HasFile)
            {
                int maxFileSize = 2 * 1024 * 1024; // 2 MB
                if (FileUpload1.PostedFile.ContentLength > maxFileSize)
                {
                    throw new Exception("File size exceeds the 2 MB limit.");
                }

                string ext = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower();
                if (ext != ".pdf")
                {
                    throw new Exception("Please upload only PDF files.");
                }

                string uploadDirectory = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/");
                if (!Directory.Exists(uploadDirectory))
                {
                    Directory.CreateDirectory(uploadDirectory);
                }

                string newFileName = "Sld_Document_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                string filePath = Path.Combine(uploadDirectory, newFileName);

                FileUpload1.SaveAs(filePath);

                string filePathInfo = "/Attachment/" + SiteOwnerId + "/Sld Document/" + newFileName;
                CEI.UpdateSLD_Industry(SldId, filePathInfo, SiteOwnerId, Session["Serviceid_Sld_Indus"].ToString());
                BindGrid();
                checksuccessmessage = 1;

                try
                {
                    string actiontype = "Submit";

                    Industry_Api_Post_DataformatModel ApiPostformatresult = CEI.GetIndustry_OutgoingRequestFormat_Sld(Convert.ToInt32(SldId), actiontype, Session["projectid_Sld_Indus"].ToString(), Session["Serviceid_Sld_Indus"].ToString(), Session["SiteOwnerId_Sld_Indus"].ToString());

                    if (ApiPostformatresult.PremisesType == "Industry")
                    {
                        // string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                        string accessToken = TokenManagerConst.GetAccessToken(ApiPostformatresult);
                        // string accessToken = "dfsfdsfsfsdf";

                        logDetails = CEI.Post_Industry_Inspection_StageWise_JsonData(
                                      "https://investharyana.in/api/project-service-logs-external_UHBVN",
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


            }
            else
            {
                throw new Exception("No file uploaded.");
            }


            if (checksuccessmessage == 1)
            {
                string script = "alert('SLD Document Re-submitted successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                GridView2.Visible = false;
                SiteAddress.Visible = true;
                btnVerify.Visible = true;
                ReSubmit.Visible = false;
                btnReSubmit.Visible = false;
                BindAdress();
            }

        }


        protected void Reset()
        {
            try
            {
                ddlSiteOwnerAdress.SelectedValue = "0";

            }
            catch (Exception ex)
            {
            }
        }
    }
}