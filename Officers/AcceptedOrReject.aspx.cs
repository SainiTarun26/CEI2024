using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class AcceptedOrReject : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                    {

                        GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/OfficerLogout.aspx");
            }

        }
        public void GridBind()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["StaffID"].ToString();
                string searchText = txtSearch.Text.Trim();
                DataSet ds = new DataSet();
                ds = CEI.AcceptOrReject(LoginID, searchText);
                if (ds != null && ds.Tables.Count > 0)
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

                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
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
                    string id = lblID.Text;
                    Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
                    string InstallationType = lblInstallationType.Text.Trim();
                    Label lblApplicationStatus = (Label)row.FindControl("lblApplicationStatus");
                    string ApplicationStatus = lblApplicationStatus.Text;
                    Label lblApproveDateLabel = row.FindControl("lblApproveDate") as Label;
                    // code changed by aslam 19M-May-2025
                    Label lblblUserType = row.FindControl("lblUserType") as Label;//
                    string ApproveDate = lblApproveDateLabel.Text;
                    //lblApproveCertificate added by neeraj on 20-may-2025
                    Label lblApproveCertificate = row.FindControl("lblApproveCertificate") as Label;
                    string ApproveCertificate = lblApproveCertificate.Text;
                    Session["InProcessInspectionId"] = id;
                    if (e.CommandName == "Select")
                    {

                        if (InstallationType == "Lift" || InstallationType == "Escalator" || InstallationType == "Lift/Escalator" || InstallationType == "MultiLift" || InstallationType == "MultiEscalator")
                        {
                            if (ApplicationStatus == "Returned")
                            {
                                Response.Redirect("/Officers/InProcess_Returned_Inspection_Lift_Escalator.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("/Officers/InProcessInspection_Lift_Escalator.aspx", false);
                            }
                        }
                        //elseif condition of cinema added by neeraj on 20-may-2025
                        else if (InstallationType == "Cinema_Videos Talkies")
                        {
                            Response.Redirect("/Officers/ActionForCinemaVideo_Talkies.aspx", false);
                        }//
                        else
                        {
                            Response.Redirect("/Officers/InProcessInspection.aspx", false);
                        }
                    }
                    else if (e.CommandName == "Print")
                    {
                        if (LblInspectionType.Text == "New")
                        {
                            Session["InProcessInspectionId"] = id; //if condion of cinema added by neeraj on 20-may-2025
                            if (InstallationType == "Cinema_Videos Talkies")
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
                            }
                            //
                            else if (InstallationType != "Lift" && InstallationType != "Escalator" && InstallationType != "Lift/Escalator" && InstallationType != "MultiLift" && InstallationType != "MultiEscalator" && InstallationType != "Cinema/Videos Talkis")
                            {
                                Session["InProcessInspectionId"] = id;
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
                            }

                            #region aslam code changed by aslam 19M-May-2025
                            else if (InstallationType == "Lift" || InstallationType == "Escalator" || InstallationType == "Lift/Escalator" || InstallationType == "MultiLift" || InstallationType == "MultiEscalator")
                            {
                                if (lblblUserType.Text != "Industry")
                                {
                                    Session["InProcessInspectionId"] = id;
                                    Session["InProcessInspectionId_IndustryLift"] = null;

                                }
                                else if (lblblUserType.Text == "Industry")
                                {
                                    Session["InProcessInspectionId_IndustryLift"] = id;
                                    Session["InProcessInspectionId"] = null;

                                }
                                Response.Redirect("/Officers/Lift_EscelatorApprovaldata.aspx", false);

                            }
                            #endregion
                        }
                        else if (LblInspectionType.Text == "Periodic")
                        {
                            Session["InProcessInspectionId"] = id;
                            #region added by  neeraj on 20-May-2025         
                            if (InstallationType == "Cinema_Videos Talkies")
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
                            }
                            #endregion
                            else if (InstallationType != "Lift" && InstallationType != "Escalator" && InstallationType != "Lift/Escalator" && InstallationType != "MultiLift" && InstallationType != "MultiEscalator")
                            {
                                Response.Redirect("/Print_Forms/PeriodicApprovalCertificate.aspx", false);
                            }
                            else if (InstallationType == "Lift" || InstallationType == "Escalator" || InstallationType == "Lift/Escalator" || InstallationType == "MultiLift" || InstallationType == "MultiEscalator")
                            {
                                Response.Redirect("/Officers/Lift_EscelatorApprovaldata.aspx", false);
                            }

                        }
                    }

                }
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
            }

            catch (Exception ex)
            {
                //alert by  neeraj on 20-May-2025         
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch (Exception ex)
            {
                //alert by  neeraj on 20-May-2025   
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Siteowner has not uploaded the PAN card yet!');", true);
            }
        }
        #endregion

        #region kalpana global search
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            GridBind();
        }
        #endregion
    }
}