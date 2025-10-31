using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Admin
{
    public partial class IntimationHistoryForAdmin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        BindGrid();
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
                Console.WriteLine(ex.Message);
            }
        }

        private void BindGrid()
        {
            try
            {
                string LoginId = Session["AdminID"].ToString();
                DataTable ds = new DataTable();
                ds = CEI.InspectionHistoryForAdminData(LoginId);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Session["LineID"] = "";
                    Session["SubStationID"] = "";
                    Session["GeneratingSetId"] = "";

                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Session["InspectionId"] = lblID.Text;
                    Label lblApproval = (Label)row.FindControl("lblApproval");
                    Session["Approval"] = lblApproval.Text.Trim();
                    Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
                    string installationType = lblInstallationType.Text.Trim();
                    Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
                    string TestRportId = lblTestRportId.Text.Trim();
                    Label lblRequestStatus = (Label)row.FindControl("lblRequestStatus");
                    Label lblTypeOfInspection = (Label)row.FindControl("lblTypeOfInspection");
                    Label lblInstallationFor = (Label)row.FindControl("lblInstallationType");


                    if (installationType.Trim() == "Line")
                    {
                        Session["LineID"] = installationType;
                    }
                    else if (installationType.Trim() == "Substation Transformer")
                    {
                        Session["SubStationID"] = TestRportId;
                    }
                    else if (installationType.Trim() == "Generating Set")
                    {
                        Session["GeneratingSetId"] = TestRportId;
                    }
                    else if (installationType == "Multiple")
                    {
                        Session["PeriodicMultiple"] = installationType;
                    }
                    if (e.CommandName == "Select")
                    {
                        if (lblInstallationFor.Text == "Cinema_Videos Talkies")
                        {
                            if (lblTypeOfInspection.Text.Trim() == "New")
                            {
                                Response.Redirect("/Admin/Inspection_Cinema_Talkies_Admin.aspx", false);
                                return;
                            }
                            else if (lblTypeOfInspection.Text.Trim() == "Periodic")
                            {
                                Response.Redirect("/Admin/PeriodicInspection_Cinema_Talkies_Admin.aspx", false);
                                return;
                            }
                        }
                        else
                        {
                            if (lblRequestStatus != null && lblRequestStatus.Text == "ReSubmit" && lblTypeOfInspection.Text == "New")
                            {
                                Response.Redirect("/Admin/ReturnedIntimationForHistory.aspx", false);
                            }
                            else if (lblRequestStatus != null && lblRequestStatus.Text == "ReSubmit" && lblTypeOfInspection.Text == "Periodic")
                            {
                                Response.Redirect("/Admin/PeriodicReturnedIntimationForHistory.aspx", false);
                            }
                            else //if (lblRequestStatus != null && lblRequestStatus.Text == "New")
                            {
                                Response.Redirect("/Admin/IntimationForHistory.aspx", false);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No Record Found\");", true);
                    }
                }
                //Added by Aslam 12 sep 2025 to show popup 
                else if (e.CommandName == "ShowDetails")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lbllblApplicantFor = (Label)row.FindControl("lblApplicantFor");

                    if (lbllblApplicantFor.Text == "Power Utility")
                    {
                        LinkButton lnkbtnshowdetails = (LinkButton)row.FindControl("LnkResetButton");
                        string CreatedBy = e.CommandArgument.ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", "$('#ownerModal').modal('show');", true);
                        PowerUtility(CreatedBy);
                    }
                    else
                    {
                        LinkButton lnkbtnshowdetails = (LinkButton)row.FindControl("LnkResetButton");
                        string CreatedBy = e.CommandArgument.ToString();
                        ScriptManager.RegisterStartupScript(this, GetType(), "ModalScript", "$('#ownerModal').modal('show');", true);
                        NonPowerUtility(CreatedBy);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Powerutility condition aded by aslam 12-sep-2025
                Label lbllblApplicantFor = (Label)e.Row.FindControl("lblApplicantFor");

                if (lbllblApplicantFor != null && lbllblApplicantFor.Text == "Power Utility")
                {
                    e.Row.CssClass = "PowerUtilityRowColor";
                }
                //
            }
        }
        protected void NonPowerUtility(string CreatedBy)
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
        protected void PowerUtility(string CreatedBy)
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
                string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);
                string fileUrl = baseUrl + filePath;
                string script = $@"<script>window.open('{fileUrl}', '_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Siteowner has not uploaded the PAN card yet!');", true);
            }
        }
    }
}