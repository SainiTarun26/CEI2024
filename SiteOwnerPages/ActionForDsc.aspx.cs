using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class ActionForDsc : System.Web.UI.Page
    {
        //Created By Neeraj 30-May-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    hdnOwnerId.Value = "";
                    hdnDisId.Value = "";
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != string.Empty)
                    {
                        if (Session["Dis_Id"] != null && Convert.ToString(Session["Dis_Id"]) != string.Empty)
                        {
                            hdnOwnerId.Value = Session["SiteOwnerId"].ToString();
                            hdnDisId.Value = Session["Dis_Id"].ToString();
                            GetUtilityData(hdnDisId.Value);
                            GetData(hdnDisId.Value);
                            BindGrid(hdnDisId.Value);
                        }
                    }
                    else
                    {
                        Session["SiteOwnerId"] = "";
                        Response.Redirect("/SiteOwnerLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }

        }
        private void GetUtilityData(string DisId)
        {
            try
            {
                if (Convert.ToString(hdnOwnerId.Value) == Convert.ToString(Session["SiteOwnerId"]) && Convert.ToString(hdnDisId.Value) == Convert.ToString(Session["Dis_Id"]))
                {
                    DataTable dt = CEI.GetUtilityDetails(DisId);
                    txtUtility.Text = dt.Rows[0]["UtilityName"].ToString();
                    txtWing.Text = dt.Rows[0]["WingName"].ToString();
                    txtZone.Text = dt.Rows[0]["ZoneName"].ToString();
                    txtCircle.Text = dt.Rows[0]["CircleName"].ToString();
                    txtDivision.Text = dt.Rows[0]["DivisionName"].ToString();
                    txtSubDivision.Text = dt.Rows[0]["SubDivision"].ToString();
                }
                else
                {
                    Session["SiteOwnerId"] = "";
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        private void GetData(string DisId)
        {
            try
            {
                if (Convert.ToString(hdnOwnerId.Value) == Convert.ToString(Session["SiteOwnerId"]) && Convert.ToString(hdnDisId.Value) == Convert.ToString(Session["Dis_Id"]))
                {
                    DataTable dt = CEI.GetDSCDetails(DisId);
                    txtName.Text = dt.Rows[0]["Owner_FirmName"].ToString();
                    txtPanNo.Text = dt.Rows[0]["PanNo"].ToString();
                    txtAccNo.Text = dt.Rows[0]["AccountNo"].ToString();
                    TxtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                    txtCategory.Text = dt.Rows[0]["Category"].ToString();
                    if (txtCategory.Text != null && txtCategory.Text != string.Empty)
                    {
                        OtherCat.Visible = false;
                    }
                    else
                    {
                        OtherCat.Visible = true;
                        txtOtherCategory.Text = dt.Rows[0]["OtherCategory"].ToString();
                    }
                    txtSanctionLoad.Text = dt.Rows[0]["SanctionLoad"].ToString();
                 

                }
                else
                {
                    Session["SiteOwnerId"] = "";
                    Response.Redirect("/SiteOwnerLogout.aspx", false);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }
        public void BindGrid(string Id)
        {
            try
            {
                DataTable dt = CEI.GetDisconnectionDoc_CEI(Id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    grd_Documemnts.DataSource = dt;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                dt.Dispose();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;

            }

        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ////fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    //ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    string fileName = e.CommandArgument.ToString();
                    string folderPath = Server.MapPath(fileName);
                    string filePath = Path.Combine(folderPath);
                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(hdnOwnerId.Value) == Convert.ToString(Session["SiteOwnerId"]))
            {
                Response.Redirect("/SiteOwnerPages/DSCRequest.aspx", false);
            }
            else
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }
        }

        //Commented by navneet as per instructio of sunil and vinod sir of remoing sugestons
        //protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(ddlAction.SelectedValue == "Approved")
        //    {
        //        Suggestion.Visible = true;
        //    }
        //    else
        //    {
        //        Suggestion.Visible = false;
        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(hdnOwnerId.Value) == Convert.ToString(Session["SiteOwnerId"]) && Convert.ToString(hdnDisId.Value) == Convert.ToString(Session["Dis_Id"]))
            {
                if(ddlAction.SelectedValue != "Select")
                {
                    if (ddlAction.SelectedValue == "Approved")
                    {
                        if (txtSuggestion.Text == null && txtSuggestion.Text == string.Empty)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please share suggestion or note for Approval.')", true);
                            return;
                        }
                    }
                    if (txtRemarks.Text != null && txtRemarks.Text != string.Empty)
                    {
                        if (FileReport.HasFile)
                        {                      
                      
                            string[] allowedExtensions = { ".pdf" };
                            int maxFileSize = 1 * 1024 * 1024;
                            string filePathForm1 = "";
                            string filePathForm2 = "";
                            if (FileReport.PostedFile.ContentLength <= maxFileSize)
                            {
                                    string ext = Path.GetExtension(FileReport.FileName).ToLower();
                                    if (!allowedExtensions.Contains(ext))
                                    {
                                        throw new Exception("Only PDF files are allowed.");
                                    }

                                    string directoryPath = Server.MapPath("~/Attachment/DisconnectionNotice/" + hdnOwnerId.Value + "/" + hdnDisId.Value);
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }
                                    string fileName = "DisconnectionNotice" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                                    string fullPath = Path.Combine(directoryPath, fileName);
                                    filePathForm1 = "/Attachment/DisconnectionNotice/" + hdnOwnerId.Value + "/" + hdnDisId.Value + "/" + fileName;
                                    FileReport.SaveAs(fullPath);

                            }
                                else
                                {
                                    string alertScript = "alert('Please upload 1MB files.');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                    return;
                                }
                           
                            if (FileOther.HasFile)
                            {
                                if (FileOther.PostedFile.ContentLength <= maxFileSize)
                                {
                                    string ext = Path.GetExtension(FileOther.FileName).ToLower();
                                    if (!allowedExtensions.Contains(ext))
                                    {
                                        throw new Exception("Only PDF files are allowed.");
                                    }

                                    string directoryPath = Server.MapPath("~/Attachment/DisconnectionNotice/" + hdnOwnerId.Value + "/" + hdnDisId.Value);
                                    if (!Directory.Exists(directoryPath))
                                    {
                                        Directory.CreateDirectory(directoryPath);
                                    }
                                    string fileName = "DisconnectionNotice" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ext;
                                    string fullPath = Path.Combine(directoryPath, fileName);
                                    filePathForm2 = "/Attachment/DisconnectionNotice/" + hdnOwnerId.Value + "/" + hdnDisId.Value + "/" + fileName;
                                    FileOther.SaveAs(fullPath);

                                }
                                else
                                {
                                    string alertScript = "alert('Please upload 1MB files.');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                    return;
                                }
                            }


                            //final action 
                            int x = CEI.InsertApprovalDataForDisconnection(hdnDisId.Value, hdnOwnerId.Value,ddlAction.SelectedValue, txtRemarks.Text, txtSuggestion.Text, filePathForm1, filePathForm2);

                            if (x > 0)
                            {
                                if (ddlAction.SelectedValue == "Approved")
                                {
                                    string script = $"alert('Disconnection for supply has been approved Successfuly !.'); window.location='/SiteOwnerPages/DisconnectionStatus.aspx';";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                                }

                                else
                                {
                                    string script = $"alert('Disconnection for supply has been Rejected !!.'); window.location='/SiteOwnerPages/DisconnectionStatus.aspx';";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                                }
                            }
                            else
                            {
                                string alertScript = "alert('Please try again.');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                                return;

                            }
                        }
                        else
                        {
                            string alertScript = "alert('Please upload file for action taken.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                            return;
                        }

                    }
                 
                     else
                    {
                        string alertScript = "alert('Please share Remarks.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                        return;
                    }

                }
                else
                {
                    string alertScript = "alert('Please select the action to Process..');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                    return;
                   
                }
            }
            else
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("/SiteOwnerLogout.aspx", false);
            }
            }
    }
}