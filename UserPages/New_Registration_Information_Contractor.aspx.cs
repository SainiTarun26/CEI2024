using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iTextSharp.text.pdf.AcroFields;

namespace CEIHaryana.UserPages
{
    public partial class New_Registration_Information_Contractor : System.Web.UI.Page
    {
        //Page created By Gurmeet 26-June-2025
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
                    //GetDetailsOfUser("");
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
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Userid = dt.Rows[0]["CreatedBy"].ToString();

                    txtApplyingFor.Text = dt.Rows[0]["ApplicationFor"].ToString();
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                    txtgender.Text = dt.Rows[0]["Gender"].ToString();
                    txtNationailty.Text = dt.Rows[0]["Nationality"].ToString();
                    txtPan.Text = dt.Rows[0]["PanCardNo"].ToString();
                    txtdob.Text = dt.Rows[0]["DOB"].ToString();
                    txtAge.Text = dt.Rows[0]["CalculatedAge"].ToString();

                    txtphone.Text = dt.Rows[0]["PhoneNo"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txtPermanant.Text = dt.Rows[0]["permanantAdd"].ToString();
                    txtCommunicationAddress.Text = dt.Rows[0]["CommunicationAdd"].ToString();
                   
                    txtGstNumber.Text = dt.Rows[0]["GSTNumber"].ToString();
                    txtstyle.Text = dt.Rows[0]["StyleOfCompany"].ToString();
                    lblCompanyName.Text = dt.Rows[0]["StyleOfCompany"].ToString();
                    txtCompanyName.Text = dt.Rows[0]["NameOfCompany"].ToString();

                    
                        if (txtstyle.Text == "Company(Limited)")
                        {
                            DivAgentName.Visible = true;
                            txtAgentName.Text = dt.Rows[0]["AgentName"].ToString();
                    }
                        else
                        {
                            DivAgentName.Visible = false;
                        }
                 


                    txtRegisterOffice.Text = dt.Rows[0]["CompanyRegisterdOffice"].ToString();
                    txthave_Partner_director.Text = dt.Rows[0]["CompanyPartnerOrDirector"].ToString();
                    if (!string.IsNullOrEmpty(txthave_Partner_director.Text))
                    {
                        Partner_Div.Visible = true;
                        GridBind_Partners(Userid);
                    }
                    GridBind_Team(Userid);
                    GridBindDocument(Userid);


                    txtBusinessAdd.Text = dt.Rows[0]["BusinessAddress"].ToString();
                    txtBusinessState.Text = dt.Rows[0]["BusinessState"].ToString();
                    txtBusinessDistrict.Text = dt.Rows[0]["BusinessDistrict"].ToString(); 
                    txtBusinessPin.Text = dt.Rows[0]["BusinessAddPinCode"].ToString(); 
                    txtbusinessEmail.Text = dt.Rows[0]["BusinessAddEmail"].ToString();
                    txtBusinessPhone.Text = dt.Rows[0]["BusinessAddPhoneNo"].ToString();

                    //txtAgentName.Text = dt.Rows[0]["AgentName"].ToString();
                    txtManufacturingfirm.Text = dt.Rows[0]["ManufacturingFirmOrProductionUnit"].ToString();
                    txtContractorLicence_sameName_otherstate.Text = dt.Rows[0]["ContractorLicencePreviouslyGrantedFromOtherState"].ToString();
                    if (txtContractorLicence_sameName_otherstate.Text == "YES")
                    {
                        divIssusuingNameSNO.Visible = true;
                        divIssueDateSNO.Visible = true;
                        divLicenceExpirySNO.Visible = true;
                        divDetailOfWorkPermitSNO.Visible = true;
                        //divIssueAuthority.Visible = true;
                        //divLicensePreviouslyGranted.Visible = true;
                        //divLicenseExpiry.Visible = true;

                        txtIssusuingName.Text = dt.Rows[0]["NameOfIssuingAuthority"].ToString();
                        txtIssueDateSNO.Text = dt.Rows[0]["IssuedateOtherState"].ToString();
                        txtLicenseExpiry.Text = dt.Rows[0]["DateOfLicenseExpiring"].ToString();
                        txtDetailOfWorkPermit.Text = dt.Rows[0]["DetailOfWorkPermit"].ToString();
                    }
                    //txtIssusuingName.Text = dt.Rows[0]["NameOfIssuingAuthority"].ToString();
                    //txtDateOfIssue.Text = dt.Rows[0]["IssuedateOtherState"].ToString();
                    //txtLicenseExpiry.Text = dt.Rows[0]["DateOfLicenseExpiring"].ToString();
                    txtContractorLicence_sameName.Text = dt.Rows[0]["ContractorLicencePreviouslyGrantedWithSameName"].ToString();
                    if (txtContractorLicence_sameName.Text == "YES")
                    {
                        //divLicence.Visible = true;
                        ////divDOIssue.Visible = true;
                        //txtLicenseNo.Text = dt.Rows[0]["LicenseNoIfYes"].ToString();

                        divLicenceSM.Visible = true;
                        divDateOfIssueSM.Visible = true;

                        txtLicenceNo.Text = dt.Rows[0]["LicenseNoIfYes"].ToString();
                        txtDateOfIssue.Text = dt.Rows[0]["DateoFIssue"].ToString();
                    }


                    txtE_Library.Text = dt.Rows[0]["LibraryAvailable"].ToString();
                    txtAnyPenality.Text = dt.Rows[0]["DoCompanyHavePenalties"].ToString();
                    if (txtAnyPenality.Text == "YES")
                    {
                        ShowPenelity.Visible = true;
                        txtPenalities.Text = dt.Rows[0]["Penalities"].ToString();
                    }
                    //Added by neha
                    txtWorkUnderConditionsandgulation29.Text = dt.Rows[0]["WorkUnderLicenceConditionsandregulation29"].ToString();
                    txtauthorizedperson.Text = dt.Rows[0]["NameOfAuthorizedperson"].ToString();
                   
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
                    string photoUrl ="";                   
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string a = row["DocumentName"].ToString();
                        if (row["DocumentName"].ToString() =="Candidate Image")
                        {
                            photoUrl = row["DocumentPath"].ToString();
                            imgPhoto.ImageUrl = photoUrl;                           
                        }
                        if (row["DocumentName"].ToString() == "Candidate Signature")
                        {
                            photoUrl = row["DocumentPath"].ToString();
                            mySignature.ImageUrl = photoUrl;                            
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


        protected void GridBind_Partners(string Userid)
        {
            try
            {

                DataSet ds = new DataSet();
                ds = CEI.GetContractorPartners(Userid);
                if (ds.Tables.Count > 0 && ds != null)
                {
                    grdview_Partners.DataSource = ds;
                    grdview_Partners.DataBind();
                }
                else
                {
                    grdview_Partners.DataSource = null;
                    grdview_Partners.DataBind();

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
                if (ds.Rows.Count > 0 && ds != null)
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
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    //string fileNames = e.CommandArgument.ToString();
                    //string folderPath = Server.MapPath(fileNames);

                    string fileNames = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    // fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileNames}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void grd_Documemnts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType ==DataControlRowType.DataRow)
            {
                DataRowView dataRowView = (DataRowView)e.Row.DataItem;
                string DocmentName = dataRowView["DocumentName"].ToString().ToLower();
                if (DocmentName == "candidate image" || DocmentName == "candidate signature")
                {
                    e.Row.Visible = false;
                }
            }
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