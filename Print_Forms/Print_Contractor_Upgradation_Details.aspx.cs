using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Print_Forms
{
    public partial class Print_Contractor_Upgradation_Details : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    Session["BackPreviousPage"] = Request.UrlReferrer.ToString();
                }
                if (!string.IsNullOrEmpty(Convert.ToString(Session["AdminId"])))
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["id"])))
                    {
                        int RowID = Convert.ToInt32(Session["id"]);
                        GetDataItem(RowID);
                    }
                    else
                    {
                        Response.Redirect("/Admin/Contractor_Supervisor_Upgradation_Details.aspx");
                    }
                }
                else if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["id"])))
                    {
                        int RowID = Convert.ToInt32(Session["id"]);
                        GetDataItem(RowID);
                    }
                    else
                    {
                        Response.Redirect("/Contractor/ConractorUpgradationHistory.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string previousPageUrl = Session["BackPreviousPage"] as string;
            if (!string.IsNullOrEmpty(previousPageUrl))
            {
                Response.Redirect(previousPageUrl, false);
                Session["BackPreviousPage"] = null;
            }
        }
    }
}