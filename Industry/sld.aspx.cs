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
                }
                else
                {

                }
            }

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
            catch
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
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
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
            int newSLD_ID = CEI.UploadSldDocument_Industry(SiteOwnerId, filePathInfo, SiteOwnerId, ddlSiteOwnerAdress.SelectedItem.ToString(), SiteOwnerName ,"Industry", Session["Serviceid_Sld_Indus"].ToString());
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


                    CEI.LogToIndustryApiSuccessDatabase(
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
                CEI.LogToIndustryApiErrorDatabase(
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
                CEI.LogToIndustryApiErrorDatabase(
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

                string errorMessage = CEI.IndustryApiReturnedErrorMessage(ex);

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
                if (checksuccessmessage == 1)
                {
                    string script = $"alert('SLD Document submitted successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                }
                //connection.Close();
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
    }
}