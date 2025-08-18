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
    public partial class Print_New_Registration_Information_Contractor : System.Web.UI.Page
    {
        //Page created by gurmeet 1-July-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["NewApplication_Contractor_RegNo"]) != null && Convert.ToString(Session["NewApplication_Contractor_RegNo"]) != "")
                    {
                        if (Request.UrlReferrer != null)
                        {
                            Session["BackPreviousPage"] = Request.UrlReferrer.ToString();
                        }
                        GetDetailsOfUser(Convert.ToString(Session["NewApplication_Contractor_RegNo"]));
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetDetailsOfUser(string RegistartionID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetNewLicenceApplicationData_contractor(RegistartionID);
                if (dt.Rows.Count > 0)
                {
                    string Userid = dt.Rows[0]["CreatedBy"].ToString();
                    ApplyingFor.Text = dt.Rows[0]["ApplicationFor"].ToString();
                    Name.Text = dt.Rows[0]["Name"].ToString();
                    FatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    gender.Text = dt.Rows[0]["Gender"].ToString();
                    Nationailty.Text = dt.Rows[0]["Nationality"].ToString();
                    Aadhar.Text = dt.Rows[0]["Aadhar"].ToString();
                    dob.Text = dt.Rows[0]["DOB"].ToString();
                    Age.Text = dt.Rows[0]["CalculatedAge"].ToString();
                    phone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    Email.Text = dt.Rows[0]["Email"].ToString();
                    CommunicationAddress.Text = dt.Rows[0]["CommunicationAddress"].ToString();
                    // permanentAddress.Text = dt.Rows[0][""].ToString();

                    GridBindDocument(Userid);

                    //txtphone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    //txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    //txtCommunicationAddress.Text = dt.Rows[0]["CommunicationAddress"].ToString();
                    //txtpermanentAddress.Text = dt.Rows[0][""].ToString();

                    lblGst.Text = dt.Rows[0]["GSTNumber"].ToString();
                    lblStylecompany.Text = dt.Rows[0]["StyleOfCompany"].ToString();
                    lblRegisteroffice.Text = dt.Rows[0]["CompanyRegisterdOffice"].ToString();
                    lblweathercompnypartner.Text = dt.Rows[0]["CompanyPartnerOrDirector"].ToString();
                    if (!string.IsNullOrEmpty(lblweathercompnypartner.Text))
                    {
                        Partner_Div.Visible = true;
                        GridBind_Partners(Userid);
                    }
                    GridBind_Team(Userid);
                    //GridBindDocument(Userid);


                    lblAnyPenality.Text = dt.Rows[0]["DoCompanyHavePenalties"].ToString();
                    if (lblAnyPenality.Text == "Yes")
                    {
                        ShowPenelity.Visible = true;
                        lblPenality.Text = dt.Rows[0]["Penalities"].ToString();
                    }
                    lblAgentName.Text = dt.Rows[0]["AgentName"].ToString();
                    lblManufacturing.Text = dt.Rows[0]["ManufacturingFirmOrProductionUnit"].ToString();
                    lblCOntractorLicencesamename_otherstate.Text = dt.Rows[0]["ContractorLicencePreviouslyGrantedFromOtherState"].ToString();
                    if (lblCOntractorLicencesamename_otherstate.Text == "YES")
                    {
                        divIssueAuthority.Visible = true;
                        divLicensePreviouslyGranted.Visible = true;
                        //divLicenseExpiry.Visible = true;
                    }
                    lblIssuingAuthority.Text = dt.Rows[0]["NameOfIssuingAuthority"].ToString();
                    lblDateOfIssue.Text = dt.Rows[0]["IssuedateOtherState"].ToString();
                    lblDateOfExpiry.Text = dt.Rows[0]["DateOfLicenseExpiring"].ToString();
                    lblLicencePrivouslySameName.Text = dt.Rows[0]["ContractorLicencePreviouslyGrantedWithSameName"].ToString();
                    if (lblLicencePrivouslySameName.Text == "YES")
                    {
                        divLicence.Visible = true;
                        //divDOIssue.Visible = true;
                        lblLicenceNo.Text = dt.Rows[0]["LicenseNoIfYes"].ToString();
                    }
                    lblLibraryAnnexure.Text = dt.Rows[0]["LibraryAvailable"].ToString();
                    //Added by neha
                    lblWorkUnderConditionsandgulation29.Text = dt.Rows[0]["WorkUnderLicenceConditionsandregulation29"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected void GridBindDocument(string Userid)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = CEI.ViewDocumentsNewApplications(Userid);
                if (ds.Tables.Count > 0 && ds != null)
                {
                    string photoUrl = "";
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string a = row["DocumentName"].ToString();
                        if (row["DocumentName"].ToString() == "Candidate Image")
                        {
                            photoUrl = row["DocumentPath"].ToString();
                            myimg.ImageUrl = photoUrl;
                        }
                        if (row["DocumentName"].ToString() == "Candidate Signature")
                        {
                            photoUrl = row["DocumentPath"].ToString();
                            imgsignature.ImageUrl = photoUrl;
                        }
                    }
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dataRowView = (DataRowView)e.Row.DataItem;
                string DocmentName = dataRowView["DocumentName"].ToString().ToLower();
                if (DocmentName == "candidate image" || DocmentName == "candidate signature")
                {
                    e.Row.Visible = false;
                }
            }
        }
        protected void GridBind_Partners(string Userid)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = CEI.GetContractorPartners(Userid);
                if (ds.Tables.Count > 0)
                {
                    grdview_Partners.DataSource = ds;
                    grdview_Partners.DataBind();
                }
                else
                {
                    grdview_Partners.DataBind();
                    grdview_Partners.DataSource = null;

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        protected void GridBind_Team(string Userid)
        {
            try
            {

                DataTable ds = new DataTable();
                ds = CEI.GetContractorTeam(Userid);
                if (ds.Rows.Count > 0)
                {
                    grdView_ContractorTeam.DataSource = ds;
                    grdView_ContractorTeam.DataBind();
                }
                else
                {
                    grdView_ContractorTeam.DataSource = null;
                    grdView_ContractorTeam.DataBind();

                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }
    }
}