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
    public partial class SingleLineDiagram : System.Web.UI.Page
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
                    GridBind();
                    Page.Session["ClickCount"] = "0";
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
                ds = CEI.ViewSldDocuments(LoginId, txtSearch.Text);
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

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReview.SelectedValue == "Returned")
            {
                Rejection.Visible = true;
               // Remarks.Visible = false;
            }
            else if (ddlReview.SelectedValue == "InProcess")
            {
                //Remarks.Visible = true;
                Rejection.Visible = false;

            }
            if (ddlReview.SelectedValue == "0")
            {
                Rejection.Visible = false;
               // Remarks.Visible = false;
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
                chkSelect.CheckedChanged += chkSelect_CheckedChanged;
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

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
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
               // TxtRemarks.Text = "";
                ddlReview.SelectedValue = "0";

            }



        }
     

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(ddlReview.SelectedValue) != "0")
            {
                if (ddlReview.SelectedItem.ToString() == "Returned")
                {
                    if (TxtRejectionReason.Text == "" || TxtRejectionReason.Text == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please share return reason.')", true);
                        return;
                    }
                }
                int ClickCount = 0;
                ClickCount = Convert.ToInt32(Session["ClickCount"]);
                if (ClickCount < 1)
                {
                    ClickCount = ClickCount + 1;
                    Session["ClickCount"] = ClickCount;

                    int checksuccessmessage = 0;
                    string SLDID = Session["lblSldId"].ToString().Trim();
                    string SiteOwnerId = Session["lblSiteOwnerId"].ToString().Trim();
                    string AdminId = Session["AdminID"].ToString();


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

                    CEI.SldRequestForAdmin(SLDID, ddlReview.SelectedValue.ToString(), AdminId, TxtRejectionReason.Text.Trim(), SiteOwnerId);
                    checksuccessmessage = 1;
                    try
                    {
                        string actiontype = ddlReview.SelectedItem.Text.ToString() == "Accepted" ? "InProgress" : "Return";
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
                        string errorMessage = CEI.IndustryTokenApiReturnedErrorMessage(ex);
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

                    if (checksuccessmessage == 1)
                    {
                        if (ddlReview.SelectedItem.Value == "InProcess")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        }
                        if (ddlReview.SelectedItem.Value == "Returned")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataReturn();", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('You double click on Button.'); window.location='AdminMaster.aspx'", true);
                }

                //string script = $"alert('SLD Document submitted successfully.'); window.location='AdminMaster.aspx';";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
            }
            else
            {
                ddlReview.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "Please Select Approval Type to Proceed.", true);
            }
        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Transfer_Sld_ToDifferentStaff_ByAdmin.aspx", false);
        }
    }
}