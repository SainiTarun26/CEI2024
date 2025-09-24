using CEI_PRoject;
using CEIHaryana.Contractor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Contractor_Registration_Details : System.Web.UI.Page
    {
        //Created by neha 18-Aug-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                    {
                        string ContractorId = Convert.ToString(Session["ContractorID"]);
                        GetUserDetails(ContractorId);
                        GetDetails(ContractorId);
                        PartnersModalDirectorData(ContractorId);
                        ContractorTeamBind(ContractorId);
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/LogOut.aspx", false);
            }
        }

        private void GetUserDetails(string UserName)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.Getdetailsofuser(UserName);

                txtcategory.Text = dt.Rows[0]["Category"].ToString();
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtuserid.Text = dt.Rows[0]["UserId"].ToString();
                txtFatherNmae.Text = dt.Rows[0]["FatherName"].ToString();
                txtDOB.Text = dt.Rows[0]["DOB"].ToString();
                txtyears.Text = dt.Rows[0]["CalculatedAge"].ToString();
                txtgender.Text = dt.Rows[0]["Gender"].ToString();
                txtPAN.Text = dt.Rows[0]["PanCardNo"].ToString();
                txtCommunicationAddress.Text = dt.Rows[0]["CommunicationAddress"].ToString();
                txtState1.Text = dt.Rows[0]["CommState"].ToString();
                txtDistrict1.Text = dt.Rows[0]["CommDistrict"].ToString();
                txtPinCode.Text = dt.Rows[0]["CommPin"].ToString();
                txtPermanentAddress.Text = dt.Rows[0]["PermanentAddress"].ToString();
                txtstate.Text = dt.Rows[0]["PermanentState"].ToString();
                txtdistrict.Text = dt.Rows[0]["PermanentDistrict"].ToString();
                txtPin.Text = dt.Rows[0]["PermanentPin"].ToString();
                txtphone.Text = dt.Rows[0]["PhoneNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtNationality.Text = dt.Rows[0]["Nationality"].ToString();
            }
            catch (Exception ex )
            {
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/AdminLogout.aspx");
        }

        private void GetDetails(string contractorId)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.GetContractorApplicationsInformation(contractorId);

                txtCompanyStyle.Text = ds.Rows[0]["StyleOfCompany"].ToString();
                if (txtCompanyStyle.Text == "Company(Limited)")
                {
                    DivAgentName.Visible = true;
                    txtAgentName.Text = ds.Rows[0]["AgentName"].ToString();
                }
                else
                {
                    DivAgentName.Visible = false;
                }
                txtNameOfCompany.Text = ds.Rows[0]["NameOfCompany"].ToString();
                txtBusinessAddress.Text = ds.Rows[0]["BusinessAddress"].ToString();
                txtBusinessState.Text = ds.Rows[0]["BusinessState"].ToString();
                txtBusinessDistrict.Text = ds.Rows[0]["BusinessDistrict"].ToString();
                txtOffice.Text = ds.Rows[0]["CompanyRegisterdOffice"].ToString();
                txtBusinessPin.Text = ds.Rows[0]["BusinessAddPinCode"].ToString();
                txtGstNumber.Text = ds.Rows[0]["GSTNumber"].ToString();
                txtBusinessEmail.Text = ds.Rows[0]["BusinessAddEmail"].ToString();
                txtBusinessPhoneNo.Text = ds.Rows[0]["BusinessAddPhoneNo"].ToString();
                txtNameOfCompany.Text = ds.Rows[0]["NameOfCompany"].ToString();


                txtauthorizedperson.Text = ds.Rows[0]["NameOfAuthorizedperson"].ToString();

                txtUnitOrNot.Text = ds.Rows[0]["ManufacturingFirmOrProductionUnit"].ToString();


                txtSameNameLicense.Text = ds.Rows[0]["ContractorLicencePreviouslyGrantedWithSameName"].ToString();

                if (txtSameNameLicense.Text == "YES")
                {
                    DivLicenseNo.Visible = true;
                    DivLicenseIssueDateifSameName.Visible = true;

                    txtLicenseNo.Text = ds.Rows[0]["LicenseNoIfYes"].ToString();
                    if (ds.Rows[0]["DateoFIssue"] != DBNull.Value)
                    {
                        DateTime DateoFIssue = Convert.ToDateTime(ds.Rows[0]["DateoFIssue"]);
                        txtLicenseIssue.Text = DateoFIssue.ToString("yyyy-MM-dd");
                    }
                }
                else
                {
                    DivLicenseNo.Visible = false;
                    DivLicenseIssueDateifSameName.Visible = false;

                    txtLicenseNo.Text = "";
                    txtLicenseIssue.Text = "";
                }

                txtLicenseGranted.Text = ds.Rows[0]["ContractorLicencePreviouslyGrantedFromOtherState"].ToString();

                if (txtLicenseGranted.Text == "YES")
                {
                    divIssueAuthority.Visible = true;
                    divLicenseIssueDate.Visible = true;
                    divLicenseExpiry.Visible = true;
                    divDetailsOfWorkPermit.Visible = true;
                    txtIssusuingName.Text = ds.Rows[0]["NameOfIssuingAuthority"].ToString();
                    if (ds.Rows[0]["IssuedateOtherState"] != DBNull.Value)
                    {
                        DateTime IssuedateOtherState = Convert.ToDateTime(ds.Rows[0]["IssuedateOtherState"]);
                        txtIssuedateOtherState.Text = IssuedateOtherState.ToString("yyyy-MM-dd");
                    }
                    if (ds.Rows[0]["DateOfLicenseExpiring"] != DBNull.Value)
                    {
                        DateTime expiryDate = Convert.ToDateTime(ds.Rows[0]["DateOfLicenseExpiring"]);
                        txtLicenseExpiry.Text = expiryDate.ToString("yyyy-MM-dd");
                    }

                    txtWorkPermitUndertaken.Text = ds.Rows[0]["DetailOfWorkPermit"].ToString();
                }
                else
                {
                    divIssueAuthority.Visible = false;
                    divLicenseIssueDate.Visible = false;
                    divLicenseExpiry.Visible = false;
                    divDetailsOfWorkPermit.Visible = false;
                    txtIssusuingName.Text = "";
                    txtIssuedateOtherState.Text = "";
                    txtLicenseExpiry.Text = "";
                    txtWorkPermitUndertaken.Text = "";
                }

                txtAnnexureOrNot.Text = ds.Rows[0]["LibraryAvailable"].ToString();

                txtCompanyAndFirmHavePunishment.Text = ds.Rows[0]["DoCompanyHavePenalties"].ToString();

                if (txtCompanyAndFirmHavePunishment.Text == "YES")
                {
                    DivPenelity.Visible = true;
                    txtPenalities.Text = ds.Rows[0]["Penalities"].ToString();
                }
                else
                {
                    txtPenalities.Text = "";
                    DivPenelity.Visible = false;
                }
                txtWorkUnderLicenceConditionsandregulation29.Text= ds.Rows[0]["WorkUnderLicenceConditionsandregulation29"].ToString();
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        private void ContractorTeamBind(string contractorId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetContractorTeam(contractorId);

                if (dt.Rows.Count > 0)
                {
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                }
                dt.Dispose();
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message.Replace("'", "\\'");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('An Error occurred: {errorMsg}');", true);
            }
        }

        private void PartnersModalDirectorData(string LoginID)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetPartnersDirectorDate(LoginID);
            if (dt != null && dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            dt.Dispose();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserPages/DocumentsForContractor.aspx", false);
        }
    }
}