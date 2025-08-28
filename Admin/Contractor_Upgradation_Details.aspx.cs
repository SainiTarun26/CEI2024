using CEI_PRoject;
using CEIHaryana.Contractor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.AcroFields;

namespace CEIHaryana.Admin
{
    public partial class Contractor_Upgradation_Details : System.Web.UI.Page
    {
        //page created by neha
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session["AdminId"])))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["id"])))
                    {
                        int RowID = Convert.ToInt32(Session["id"]);
                        GetDataItem(RowID);
                    }
                }
            }
        }

        private void GetDataItem(int rowID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetUpgradationOfContractorRecordsDataAtAdmin(rowID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    HFUserID.Value = dt.Rows[0]["CreatedBy"].ToString();
                    HFApplicationId.Value = dt.Rows[0]["ApplicationId"].ToString();
                    txtContractName.Text = dt.Rows[0]["Name"].ToString();
                    txtFirmName.Text = dt.Rows[0]["FirmName"].ToString();
                    txtDateOfBirth.Text = dt.Rows[0]["DateOfBirth"].ToString();
                    txtCurrentAge.Text = dt.Rows[0]["CurrentAge"].ToString();
                    txtOldCertificateNo.Text = dt.Rows[0]["OldCertificate"].ToString();
                    txtNewCertificateNo.Text = dt.Rows[0]["NewCertificate"].ToString();
                    txtCurrentVoltageLevel.Text = dt.Rows[0]["CurrentLicenceVoltageLevel"].ToString().Trim();

                    if (txtCurrentVoltageLevel.Text == "650V")
                    {
                        BluePrint.Visible = false;
                    }
                    else
                    {
                        BluePrint.Visible = true;
                        txtblueprint.Text = dt.Rows[0]["BluePrintsAvailableinAbove650V"].ToString();
                       
                    }


                    txtVoltageLevel.Text = dt.Rows[0]["LicenceLevelAppliedFor"].ToString();

                    txtGstNumber.Text = dt.Rows[0]["GstNo"].ToString();
                    txtCompanyStyle.Text = dt.Rows[0]["StyleOfCompany"].ToString();
                    lblCompanyName.Text = dt.Rows[0]["StyleOfCompany"].ToString();

                    if (txtCompanyStyle.Text == "Company(Limited)")
                    {
                        DivAgentName.Visible = true;
                        txtAgentName.Text = dt.Rows[0]["NameOfAgentOrManager"].ToString();
                    }
                    else
                    {
                        DivAgentName.Visible = false;
                    }
                    txtNameOfCompany.Text = dt.Rows[0]["NameOfCompany"].ToString();
                    txtOffice.Text = dt.Rows[0]["RegisteredOfficeInHaryana"].ToString();
                    txtBusinessAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtbusinessState.Text = dt.Rows[0]["State"].ToString();
                    txtbusinessDistrict.Text = dt.Rows[0]["District"].ToString();
                    txtBusinessPin.Text = dt.Rows[0]["PinCode"].ToString();
                    txtBusinessEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtBusinessPhoneNo.Text = dt.Rows[0]["PhoneNo"].ToString();
                    txtauthorizedperson.Text = dt.Rows[0]["AuthorisedPersonSigningName"].ToString();
                    txtUnitOrNot.Text = dt.Rows[0]["ManufacturingOrProduction"].ToString();
                    txtSameNameLicense.Text = dt.Rows[0]["LicensePreviouslyGrantedWithSameName"].ToString();
                    if (txtSameNameLicense.Text == "YES")
                    {
                        DivLicenseNo.Visible = true;
                        DivLicenseIssueDateifSameName.Visible = true;

                        txtLicenseNo.Text = dt.Rows[0]["LicenseNo"].ToString();
                        txtLicenseIssue.Text = dt.Rows[0]["DateOfIssue"].ToString();
                    }
                    else
                    {
                        DivLicenseNo.Visible = false;
                        DivLicenseIssueDateifSameName.Visible = false;
                    }

                    txtLicenseGranted.Text = dt.Rows[0]["LicensePreviouslyGrantedWithSameNameOfOtherState"].ToString();

                    if (txtLicenseGranted.Text == "YES")
                    {
                        divIssueAuthority.Visible = true;
                        divLicenseIssueDate.Visible = true;
                        divLicenseExpiry.Visible = true;
                        divDetailsOfWorkPermit.Visible = true;
                        txtIssusuingName.Text = dt.Rows[0]["IssueAuthorityName"].ToString();
                        txtIssuedateOtherState.Text = dt.Rows[0]["AuthorityDateofIssue"].ToString();
                        txtLicenseExpiry.Text = dt.Rows[0]["AuthorityLicenceExpiry"].ToString();
                        txtWorkPermitUndertaken.Text = dt.Rows[0]["DetailOfworkPermit"].ToString();
                    }
                    else
                    {
                        divIssueAuthority.Visible = false;
                        divLicenseIssueDate.Visible = false;
                        divLicenseExpiry.Visible = false;
                        divDetailsOfWorkPermit.Visible = false;
                    }
                    String UserID = dt.Rows[0]["CreatedBy"].ToString();
                    txtPartnerOrDirector.Text = dt.Rows[0]["CompanyHavePartnerOrDirector"].ToString();

                    if (txtPartnerOrDirector.Text == "YES")
                    {
                        DivGridView2.Visible = true;
                        PartnersModalDirectorData(UserID);
                    }
                    else
                    {
                        DivGridView2.Visible = false;
                    }
                    txtWorkUnderLicenceConditionsandregulation29.Text = dt.Rows[0]["WorkUnderLicenceConditionsandregulation29"].ToString();
                    txtAnnexureOrNot.Text = dt.Rows[0]["ELibraryAvailable"].ToString();
                    txtDropDownList2.Text = dt.Rows[0]["HavePeneltyOrPunishment"].ToString();

                    if (txtDropDownList2.Text == "YES")
                    {
                        DdlPenelity.Visible = true;
                        txtPenalities.Text = dt.Rows[0]["PeneltyOrPunishment"].ToString();
                    }
                    else
                    {
                        DdlPenelity.Visible = false;
                        txtPenalities.Text = "";
                    }
                    txtGrNNo.Text = dt.Rows[0]["GRN_No"].ToString();
                    txtChallanDate.Text = dt.Rows[0]["ChallanDate"].ToString();
                    txtTotalAmount.Text = dt.Rows[0]["ChallanAmount"].ToString();
                    GetEmployeeGridData(UserID);
                    GridBindDocument(UserID);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GridBindDocument(string userID)
        {
            try
            {
                DataTable dt = CEI.GetUpgradationOfContractorDocumentsAtAdmin(userID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    grd_Documemnts.DataSource = dt;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                }
                dt.Dispose(); // optional, but OK
            }
            catch (Exception ex)
            {
                //throw;
            }
        }

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    //string fileNames = e.CommandArgument.ToString();
                    //string folderPath = Server.MapPath(fileNames);
                    string fileNames = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileNames}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void GetEmployeeGridData(string UserID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.WorkIntimationGridData(UserID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView4.DataSource = ds;
                    GridView4.DataBind();
                }
                else
                {
                    GridView4.DataSource = null;
                    GridView4.DataBind();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('An Error Occured');", true);
            }
        }

        private void PartnersModalDirectorData(string UserID)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetUpgradationContractorPartnersData(UserID);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            dt.Dispose();
        }

        protected void RdbtnAccptReturn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RdbtnAccptReturn.SelectedValue == "1") //No(Return)
            {
                DivReason.Visible = true;
            }
            else
            {
                DivReason.Visible = false;
            }
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            string ActionBy = Convert.ToString(Session["AdminId"]);

            string ContractorID = HFUserID.Value.Trim();
            string ApplicationID = HFApplicationId.Value.Trim();

            if (!string.IsNullOrEmpty(ActionBy) && !string.IsNullOrEmpty(ApplicationID))
            {
                if (!string.IsNullOrEmpty(RdbtnAccptReturn.SelectedValue))
                {
                    string rejectReason = string.Empty;

                    if (RdbtnAccptReturn.SelectedValue == "0") // Approved
                    {
                        CEI.ApproveRequestForContractorUpgradation(ApplicationID, ActionBy, ContractorID);

                        string script = "alert('Application Approved Successfully!'); window.location='/Admin/UpgradationRequestHistory.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect", script, true);
                    }
                    else if (RdbtnAccptReturn.SelectedValue == "1") // Rejected
                    {

                        rejectReason = txtRejectReason.Text.Trim();

                        if (string.IsNullOrWhiteSpace(rejectReason))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please enter a reason for rejection.');", true);
                            return;
                        }
                        CEI.RejectedRequestForContractorUpgradation(ApplicationID, rejectReason, ActionBy, ContractorID);

                        string script = "alert('Application Rejected Successfully!'); window.location='/Admin/UpgradationRequestHistory.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertAndRedirect", script, true);
                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}