﻿using CEI_PRoject;
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
    public partial class AcceptedOrRejectedRequest : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string LoginId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var master = (MasterPage)Master;
                    var loginTypeLabel = (Label)master.FindControl("LoginType");
                    if (loginTypeLabel != null)
                    {
                        loginTypeLabel.Text = "Admin / Dashboard / Approved / Rejected / Return Requests";
                    }

                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        GridBind();
                        BindDropDownForDivision();
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/AdminLogout.aspx");
            }
        }

        private void GridBind()
        {
            try
            {
                LoginId = Convert.ToString(Session["AdminId"]);
                string id = ddldivision.SelectedValue.ToString();
                string InstallationType = RadioButtonList1.SelectedValue.ToString();
                DataSet ds = new DataSet();
                //ds = CEI.AcceptedOrRejectedRequestInspectionForAdmin(LoginId, id);
                ds = CEI.AcceptRejectReturnedInspectionATAdmin(LoginId, id, InstallationType);
                if (ds.Tables.Count > 0)
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
            catch (Exception ex)
            {
                //throw;
            }
        }
        private void BindDropDownForDivision()
        {
            try
            {
                DataSet dsDivision = new DataSet();
                dsDivision = CEI.DdlForDivision();
                ddldivision.DataSource = dsDivision;
                ddldivision.DataTextField = "HeadOffice";
                ddldivision.DataValueField = "HeadOffice";
                ddldivision.DataBind();
                ddldivision.Items.Insert(0, new ListItem("Select", "0"));
                dsDivision.Clear();
            }
            catch (Exception ex)
            {
                //msg.Text = ex.Message;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                if (e.CommandName == "Select" || e.CommandName == "Print")
                {
                    Label lblID = (Label)row.FindControl("lblID");
                    Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                    Label lblApproval = (Label)row.FindControl("lblApproval");
                    Session["Approval"] = lblApproval.Text.Trim();
                    Label lblInstallationFor = (Label)row.FindControl("lblInstallationFor");
                    Label lblApproveDateLabel = row.FindControl("lblApproveDate") as Label;
                    string ApproveDate = lblApproveDateLabel.Text;
                    //Added By neeraj 22-May-2025
                    Label lblApproveCertificate = row.FindControl("lblApproveCertificate") as Label;
                    string ApproveCertificate = lblApproveCertificate.Text;
                    //
                    string id = lblID.Text;


                    Session["InspectionId"] = id;
                    if (e.CommandName == "Select")
                    {
                        //Added By neeraj 22-May-2025
                        if (lblInstallationFor.Text == "Cinema_Videos Talkies")
                        {
                            Session["InspectionId"] = id;
                            Response.Redirect("/Admin/CinemaInspectionDetails.aspx", false);
                        }
                        else if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                        {
                            Session["InspectionId"] = id;
                            Response.Redirect("/Admin/LiftInspectionDetails.aspx", false);
                        }
                        else
                        {
                            Session["InspectionId"] = id;
                            Response.Redirect("/Admin/InspectionDetails.aspx", false);
                        }
                    }
                    else if (e.CommandName == "Print")
                    {
                        if (LblInspectionType.Text == "New")
                        {
                            Session["InProcessInspectionId"] = id;
                            //Added By neeraj 22-May-2025
                            if (lblInstallationFor.Text == "Cinema_Videos Talkies")
                            {
                                string fileName = lblApproveCertificate.Text;
                                string folderPath = Server.MapPath(fileName);
                                string filePath = Path.Combine(folderPath);

                                if (System.IO.File.Exists(filePath))
                                {
                                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                                }
                                else
                                {
                                    string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
                                }
                            }//
                            else if (lblInstallationFor.Text != "Lift" && lblInstallationFor.Text != "Escalator" && lblInstallationFor.Text != "Lift/Escalator" && lblInstallationFor.Text != "MultiLift" && lblInstallationFor.Text != "MultiEscalator")
                            {
                                if (ApproveDate != null && DateTime.TryParse(ApproveDate, out DateTime lblApproveDate))
                                {
                                    DateTime comparisonDate = DateTime.Parse("2024-11-16");

                                    if (lblApproveDate <= comparisonDate)
                                    {
                                        Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                                    }
                                    else
                                    {
                                        Response.Redirect("/Print_Forms/NewInspectionApprovalCertificate.aspx", false);
                                    }

                                }
                                else
                                {
                                    Response.Redirect("/Print_Forms/NewInspectionApprovalCertificate.aspx", false);
                                }
                            }
                            else if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                            {
                                Session["InProcessInspectionId"] = id;
                                Response.Redirect("/Admin/LiftApprovalData.aspx", false);
                            }

                        }
                        else if (LblInspectionType.Text == "Periodic")
                        { //Added By neeraj 22-May-2025
                            Session["InProcessInspectionId"] = id;
                            //Session["InProcessInspectionId"] = id;
                            if (lblInstallationFor.Text == "Cinema_Videos Talkies")
                            {
                                string fileName = lblApproveCertificate.Text;
                                string folderPath = Server.MapPath(fileName);
                                string filePath = Path.Combine(folderPath);
                                if (System.IO.File.Exists(filePath))
                                {
                                    string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                                }
                                else
                                {
                                    string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
                                }
                            }//
                            else if (lblInstallationFor.Text != "Lift" && lblInstallationFor.Text != "Escalator" && lblInstallationFor.Text != "Lift/Escalator" && lblInstallationFor.Text != "MultiLift" && lblInstallationFor.Text != "MultiEscalator")
                            {
                                Response.Redirect("/Print_Forms/PeriodicApprovalCertificate.aspx", false);
                            }
                            else if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                            {
                                Response.Redirect("/Admin/LiftApprovalData.aspx", false);
                            }

                        }
                    }


                }
                //Added by kalpana 18-July-2025
                else if (e.CommandName == "ShowDetails")
                {
                    Label lbllblApplicantFor = (Label)row.FindControl("lblApplicantFor");

                    if (lbllblApplicantFor.Text == "Power Utility")
                    {
                        LinkButton lnkbtnshowdetails = (LinkButton)row.FindControl("LnkResetButton");
                        string CreatedBy = e.CommandArgument.ToString();

                        ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", "openModal();", true);
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#ownerModal').modal('show');", true);
                        binddataforPowerUtility(CreatedBy);
                    }
                    else
                    {
                        LinkButton lnkbtnshowdetails = (LinkButton)row.FindControl("LnkResetButton");
                        string CreatedBy = e.CommandArgument.ToString();

                        ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", "openModal();", true);
                        // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#ownerModal').modal('show');", true);
                        binddata(CreatedBy);

                    }

                }
                //
            }

            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "aleert", "alert('" + ex.Message + "');", true);
            }


        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkButton = (LinkButton)e.Row.FindControl("LinkButton1");
                string applicationStatus = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus").ToString();
                if (applicationStatus == "Approved")
                {

                    linkButton.Visible = true;
                }
                else
                {

                    linkButton.Visible = false;
                }
                //Powerutility condition aded by aslam 16-July-2025
                Label lbllblApplicantFor = (Label)e.Row.FindControl("lblApplicantFor");

                if (lbllblApplicantFor != null && lbllblApplicantFor.Text == "Power Utility")
                {
                    e.Row.CssClass = "PowerUtilityRowColor";
                }
                //
            }
        }

        protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddldivision.SelectedValue.ToString();
            GridBind();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string InstallationType = RadioButtonList1.SelectedValue.ToString();
            GridBind();
        }

        #region Kalpna siteownerpop up 18-July-2025

        protected void binddata(string CreatedBy)
        {

            DataTable dt = CEI.DetailsofSiteOwner(CreatedBy);


            if (dt != null && dt.Rows.Count > 0)
            {
                txttypeofapplicant.Text = dt.Rows[0]["ApplicantType"].ToString();
                txtPANTan.Text = dt.Rows[0]["UserID"].ToString();
                txtElectricalInstallation.Text = dt.Rows[0]["ContractorType"].ToString();
                txtName.Text = dt.Rows[0]["OwnerName"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtDistrict.Text = dt.Rows[0]["District"].ToString();
                txtPin.Text = dt.Rows[0]["Pincode"].ToString();
                txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                HdnPanFilePath.Value = dt.Rows[0]["CopyofPanNumber"].ToString();
            }
        }
        protected void binddataforPowerUtility(string CreatedBy)
        {

            DataTable dt = CEI.DetailsforPowerUtility(CreatedBy);


            if (dt != null && dt.Rows.Count > 0)
            {
                txttypeofapplicant.Text = dt.Rows[0]["ApplicantType"].ToString();
                txtPANTan.Text = dt.Rows[0]["PANNumber"].ToString();
                txtElectricalInstallation.Text = dt.Rows[0]["ContractorType"].ToString();
                txtName.Text = dt.Rows[0]["OwnerName"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtDistrict.Text = dt.Rows[0]["District"].ToString();
                txtPin.Text = dt.Rows[0]["Pincode"].ToString();
                txtPhone.Text = dt.Rows[0]["ContactNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                HdnPanFilePath.Value = dt.Rows[0]["CopyofPanNumber"].ToString();
            }
        }

        protected void LnkDocumemtPath_Click(object sender, EventArgs e)
        {
            string filePath = HdnPanFilePath.Value;
            if (!string.IsNullOrEmpty(filePath))
            {
                string fileUrl = "https://uat.ceiharyana.com" + filePath;
                string script = $@"<script>window.open('{fileUrl}', '_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('File not found!');", true);
            }
        }
        #endregion


    }
}
