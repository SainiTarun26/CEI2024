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

namespace CEIHaryana.Admin
{
    public partial class SldApprovalRequest : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        Industry_Api_Post_DataformatModel ApiPostformatresult = new Industry_Api_Post_DataformatModel();
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    Page.Session["ClickCount"] = "0";
                    GridBind();
                   
                }
                else
                {
                    Session["AdminId"] = "";
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }

        }
        private void GridBind()
        {
            try
            {
                string LoginId = Session["AdminID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewSldDocumentsFoApproval(LoginId, txtSearch.Text);
                if (ds.Tables.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReview.SelectedValue == "2")
            {
                Rejection.Visible = true;
                Remarks.Visible = false;
                Document.Visible = false;
            }
            else if (ddlReview.SelectedValue == "1")
            {
                Remarks.Visible = true;
                Document.Visible = true;
                Rejection.Visible = false;

            }
            if (ddlReview.SelectedValue == "0")
            {
                Rejection.Visible = false;
                Remarks.Visible = false;
                Document.Visible = false;
            }

        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            if (e.CommandName == "Print")
            {
                string fileName = e.CommandArgument.ToString();
                string folderPath = Server.MapPath(fileName);
                string filePath = Path.Combine(folderPath);
                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string RequestLetter = DataBinder.Eval(e.Row.DataItem, "RequestLetter").ToString();
                LinkButton Lnkbtn = (LinkButton)e.Row.FindControl("Lnkbtn");
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                chkSelect.CheckedChanged += chkSelect_CheckedChanged1;
                chkSelect.Attributes.Add("onclick", "SelectCheckbox(this);");
                if (RequestLetter != null && RequestLetter != "")
                {
                    Lnkbtn.Visible = true;
                }
                else
                {
                    Lnkbtn.Visible = false;
                }
            }
        }
        protected void chkSelect_CheckedChanged1(object sender, EventArgs e)
        {
            CheckBox chkSelect = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkSelect.NamingContainer;

            Label lblSldId = (Label)row.FindControl("lblSldId");

            Label lblSiteOwnerId = (Label)row.FindControl("lblSiteOwnerId");




            foreach (GridViewRow rows in grd_Documemnts.Rows)
            {
                if (rows.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = rows.FindControl("chkSelect") as CheckBox;

                    if (chk != null && chk.ClientID != chkSelect.ClientID)
                    {
                        chk.Checked = false;
                    }

                }
            }


            if (chkSelect.Checked)
            {

                ApproveDocument.Visible = true;
                Session["lblSldId"] = lblSldId.Text;
                Session["lblSiteOwnerId"] = lblSiteOwnerId.Text;
            }
            else
            {


                ApproveDocument.Visible = false;
                TxtRejectionReason.Text = "";
                TxtRemarks.Text = "";
                ddlReview.SelectedValue = "0";

            }

        }
        protected void grd_Documemnts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grd_Documemnts.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch
            {

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlReview.SelectedItem) != "Select")
            {
                if(ddlReview.SelectedItem.ToString() == "Approved")
                {
                    if(TxtRemarks.Text == "" || TxtRemarks.Text == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please share remarks for Approval.')", true);
                        return;
                    }
                    if(Signature.HasFile == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please upload SLD document.')", true);
                        return;
                    }

                }
                if (ddlReview.SelectedItem.ToString() == "Rejected")
                {
                    if (TxtRejectionReason.Text == "" || TxtRejectionReason.Text == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please share rejection reason.')", true);
                        return;
                    }
                }
                int ClickCount = 0;
                ClickCount = Convert.ToInt32(Session["ClickCount"]);
                if (ClickCount < 1)
                {
                    

                    int checksuccessmessage = 0;
                    string SLDID = Session["lblSldId"].ToString().Trim();


                    string reqType = CEI.GetIndustry_RequestType_Sld(Convert.ToInt32(SLDID));
                    if (reqType == "Industry")
                    {
                        string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in");
                        // string serverStatus = CEI.CheckServerStatus("https://staging.investharyana.in/api/project-service-logs-external_UHBVN");
                        if (serverStatus != "Server is reachable.")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('HEPC Server Is Not Responding . Please Try After Some Time')", true);
                            return;
                        }
                    }

                    //string SiteOwnerId = Session["lblSiteOwnerId"].ToString().Trim();
                    string AdminId = Session["AdminID"].ToString();
                    int maxFileSize = 2 * 1024 * 1024;
                    string filePathInfo = "";
                    if (Document.Visible == true)
                    {
                        if (Signature.HasFile && Signature.PostedFile != null && Signature.PostedFile.ContentLength <= maxFileSize)
                        {
                            try
                            {
                                ClickCount = ClickCount + 1;
                                Session["ClickCount"] = ClickCount;
                                string FilName = string.Empty;
                                FilName = Path.GetFileName(Signature.PostedFile.FileName);


                                if (!Directory.Exists(Server.MapPath("~/Attachment/" + AdminId + "/SLD/")))
                                {
                                    Directory.CreateDirectory(Server.MapPath("~/Attachment/" + AdminId + "/SLD/"));
                                }

                                string ext = Path.GetExtension(Signature.FileName);
                                string path = "/Attachment/" + AdminId + "/SLD/";
                                string fileName = "SLD" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                                string filePathInfo2 = Server.MapPath("~/Attachment/" + AdminId + "/SLD/" + fileName);
                                Signature.SaveAs(filePathInfo2);
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
                    }
                    try
                    {
                        string actiontype = ddlReview.SelectedItem.Text.ToString() == "Approved" ? "Approved" : "Rejected";

                        List<Industry_Api_Post_DataformatModel> ApiPostformatResults = CEI.GetIndustry_OutgoingRequestFormat_Sld(Convert.ToInt32(SLDID), actiontype);
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
                    catch (Exception ex)
                    {

                        //Commented below to raise errors as per backend
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please fill All details carefully')", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                    }
                    finally
                    {

                        //connection.Close();
                    }


                    int x = CEI.SldApprovedByAdmin(SLDID, ddlReview.SelectedItem.ToString(), AdminId, filePathInfo, TxtRemarks.Text.Trim(), TxtRejectionReason.Text.Trim());

                    if (x > 0)
                    {
                        checksuccessmessage = 1;
                    }

                    if (checksuccessmessage == 1)
                    {
                        string script = $"alert('SLD Document submitted successfully.'); window.location='AdminMaster.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='AdminMaster.aspx'", true);
                }
            }
            else
            {
                ddlReview.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "Please Select Approval Type to Proceed.", true);
            }
        }
    }
}