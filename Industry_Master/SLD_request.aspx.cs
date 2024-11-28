using CEI_PRoject;
using CEIHaryana.Model.Industry;
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

namespace CEIHaryana.Industry_Master
{
    public partial class SLD_request : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        Industry_Api_Post_DataformatModel ApiPostformatresult = new Industry_Api_Post_DataformatModel();
        IndustryApiLogDetails logDetails = new IndustryApiLogDetails();
        int newSLD_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Session["SiteOwnerId_Sld_Indus"] = "BDJPB4957Q";
                //Session["district_Temp"] = "Ambala";
                //Session["Serviceid_Sld_Indus"] = "930e4959-d5a0-4624-9995-8c5e3e9cadce";
                //Session["projectid_Sld_Indus"] = "332b5554-b740-4948-9670-22ce40ecba6c";

                if (Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != null && Convert.ToString(Session["SiteOwnerId_Sld_Indus"]) != string.Empty && Convert.ToString(Session["district_Temp"]) != null && Convert.ToString(Session["district_Temp"]) != string.Empty)
                {
                    //Session["SiteOwnerId_Sld_Indus"] = "ABCDG1234G";
                    string District = Session["district_Temp"].ToString();
                    string ownerId = Session["SiteOwnerId_Sld_Indus"].ToString();

                    bool distExist = false;

                    DataSet ds1 = CEI.checkDistrict(ownerId, District);
                    if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
                    {
                        distExist = true;
                        string statusType = ds1.Tables[0].Rows[0]["Status_type"].ToString();
                        if (statusType == "Returned")
                        {
                            BindGrid();
                            //BindAdress();
                        }
                        else if (statusType == "Approved" || statusType == "Rejected")
                        {
                            BindAdress();
                        }
                        else
                        {
                            Response.Redirect("SLD_Status.aspx");
                        }

                       

                    }
                    else
                    {
                        //Response.Redirect("SLD_Status.aspx");

                        BindAdress();
                    }
                  //  BindAdress();
                }
                else
                {
                    Response.Redirect("SLD_Status.aspx");

                }
            }

        }
        private void BindAdress()
        {
            try
            {
                string id = Session["SiteOwnerId_Sld_Indus"].ToString();
                string district = Session["district_Temp"].ToString();
                DataSet dsAdress = new DataSet();
                dsAdress = CEI.GetOwnerAdressForIndustry(id, district);
                string OwnerName = dsAdress.Tables[0].Rows[0]["OwnerName"].ToString();
                Session["OwnerName"] = OwnerName;
                ddlSiteOwnerAddress.DataSource = dsAdress;
                ddlSiteOwnerAddress.DataTextField = "FullAddress";
                ddlSiteOwnerAddress.DataValueField = "District";
                ddlSiteOwnerAddress.DataBind();
                ddlSiteOwnerAddress.Items.Insert(0, new ListItem("Select", "0"));
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
            ds = CEI.SldReturnHistory(LoginID);
            if (ds.Rows.Count > 0)
            {
                Gridview1.DataSource = ds;
                Gridview1.DataBind();
            }

            else
            {
                Gridview1.DataSource = null;
                Gridview1.DataBind();
                //Documents.Visible = true;
                //btnSubmit.Visible = true;
                //string script = "alert(\"No Record Found\");";
                //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }



        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string status = DataBinder.Eval(e.Row.DataItem, "Status_type").ToString();


                Label lblStatus = (Label)e.Row.FindControl("lblStatus");

                BtnSubmit.Visible = true;
                if (status == "Returned")
                {
                    Document.Visible = false;
                    Document.Visible = false;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
                if (status == "Rejected")
                {
                    Document.Visible = false;
                    BtnSubmit.Visible = false;
                }



            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblId = (Label)row.FindControl("LblId");
                Label lblStatus = (Label)row.FindControl("lblStatus");
                if (lblStatus.Text.Trim().Equals("Rejected", StringComparison.OrdinalIgnoreCase))
                {
                    // Show an alert if StatusType is Rejected
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cannot upload SLD document.');", true);
                }
                else
                {
                    Session["Sld_id"] = LblId.Text;
                    Response.Redirect("/Industry_Master/SLDReturn.aspx", false);
                }
            }

        }

        protected void BtnSubmit_Click1(object sender, EventArgs e)
        {
            int checksuccessmessage = 0;
            string SiteOwnerId = Session["SiteOwnerId_Sld_Indus"].ToString();
            string SiteOwnerName = Session["OwnerName"].ToString();
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
            int maxFileSize = 2 * 1024 * 1024;
            string filePathInfo = "";
            string filePathInfo1 = "";

            

            if (CustomFile.HasFile && CustomFile.PostedFile != null && CustomFile.PostedFile.ContentLength <= maxFileSize && File.HasFile && File.PostedFile != null && File.PostedFile.ContentLength <= maxFileSize)
            {
               
                    try
                    {
                       

                        string FilName = string.Empty;

                        FilName = Path.GetFileName(CustomFile.PostedFile.FileName);

                        if (!Directory.Exists(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/"));
                        }

                        string ext = Path.GetExtension(CustomFile.FileName);
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

                         newSLD_ID = CEI.UploadSldDocument_Industries(SiteOwnerId, filePathInfo, filePathInfo1 ,SiteOwnerId, ddlSiteOwnerAddress.SelectedItem.ToString(), SiteOwnerName, "Industry", ddlSiteOwnerAddress.SelectedValue.Trim(), Session["Serviceid_Sld_Indus"].ToString());
                  
                   
                    // for making document folder

                        filePathInfo2 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/Sld Document/" + fileName);
                        filePathInfo3 = Server.MapPath("~/Attachment/" + SiteOwnerId + "/RequestLetter/" + fileName1);
                        CustomFile.SaveAs(filePathInfo2);
                        File.SaveAs(filePathInfo3);
                        string script = $"alert('SLD Document submitted successfully.'); window.location='SLD_Status.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                        
                    
                   

                }
                    catch (Exception ex)
                    {
                       string errorMessage = ex.Message.Replace("'", "\\'");
                        ScriptManager.RegisterStartupScript(this, GetType(), "erroralert", $"alert('{errorMessage}')", true);
                        return;
                    }
                    
                
            }
            else
            {
                throw new Exception("Please Upload Pdf Files 2 Mb Only");
            }

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
                string script = $"alert('SLD Document submitted successfully.'); window.location='SLD_Status.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
            }

        }
    }
}