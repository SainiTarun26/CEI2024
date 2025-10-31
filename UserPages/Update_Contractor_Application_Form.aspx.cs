using CEI_PRoject;
using CEIHaryana;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    //Page created by neha 4-July -2025
    public partial class Update_Contractor_Application_Form : System.Web.UI.Page
    {
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
                        HFContractor.Value = ContractorId;
                        int partnerCount = CEI.GetContractorPartnerCount(HFContractor.Value);
                        if (partnerCount > 0)
                        {
                            DdlPartnerOrDirector.SelectedValue = "1";
                            ADDpartner.Visible = true;
                            DdlPartnerOrDirector.Enabled = false;
                        }
                     


                            ContractorInformation(ContractorId);
                        ddlLoadBindState();
                        ddlBusinessStateBind();

                        GetDetails(ContractorId);
                        PartnersModalDirectorData(ContractorId);
                        ContractorTeamBind(ContractorId);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Error", "alert('An error Occurred');", true);
                        Response.Redirect("/UserPages/DocumentsForContractor.aspx", false);
                    }
                }
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        private void GetDetails(string contractorId)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.GetContractorApplicationsInformation(contractorId);
                if (ds.Rows.Count > 0)
                {
                    ListItem item = ddlCompanyStyle.Items.FindByText(ds.Rows[0]["StyleOfCompany"].ToString());
                    if (item != null)
                    {
                        ddlCompanyStyle.ClearSelection();
                        item.Selected = true;
                        if (item.Text == "Company(Limited)")
                        {
                            DivAgentName.Visible = true;
                            txtAgentName.Text = ds.Rows[0]["AgentName"].ToString();                           
                            Lbl1.Visible=false;
                            Lbl2.Visible=true;
                            Lbl3.Visible=false;
                            Lbl4.Visible=false;
                            lb5.Visible=false;
                        }
                        else if(item.Text == "Proprietary Concern")
                        {
                            Lbl1.Visible=true;
                            Lbl2.Visible=false;
                            Lbl3.Visible=false;
                            Lbl4.Visible=false;
                            lb5.Visible=false;
                            DivAgentName.Visible = false;
                        }
                        else if(item.Text == "Firm(Registered under the company's act.)")
                        {
                            Lbl1.Visible=false;
                            Lbl2.Visible=false;
                            Lbl3.Visible=true;
                            Lbl4.Visible=false;
                            lb5.Visible=false;
                            DivAgentName.Visible = false;
                        }
                        else if(item.Text =="Partnership Firm")
                        {
                            Lbl1.Visible=false;
                            Lbl2.Visible=false;
                            Lbl3.Visible=false;
                            Lbl4.Visible=true;
                            lb5.Visible=false;
                            DivAgentName.Visible = false;
                        }
                        else if(item.Text == "Registered Society")
                        {
                            Lbl1.Visible=false;
                            Lbl2.Visible=false;
                            Lbl3.Visible=false;
                            Lbl4.Visible=false;
                            lb5.Visible=true;
                            DivAgentName.Visible = false;
                        }
                    }
                    txtNameOfCompany.Text = ds.Rows[0]["NameOfCompany"].ToString();
                    txtBusinessAddress.Text = ds.Rows[0]["BusinessAddress"].ToString();
                    string t1 = ds.Rows[0]["BusinessState"].ToString();
                    string t2 = ds.Rows[0]["BusinessDistrict"].ToString();
                    //ddlBusinessState.SelectedItem.Text = t1;

                    ListItem itemst = ddlBusinessState.Items.FindByText(ds.Rows[0]["BusinessState"].ToString());
                    if (itemst != null)
                    {
                        ddlBusinessState.ClearSelection();
                        itemst.Selected = true;
                    }

                    ddlLoadBindBusinessDistrict(t1);

                    //ddlBusinessDistrict.SelectedItem.Text = t2;

                    ddlBusinessDistrict.ClearSelection();
                    ListItem li = ddlBusinessDistrict.Items.FindByText(t2);
                    if (li != null)
                    {
                        ddlBusinessDistrict.ClearSelection();
                        li.Selected = true;
                    }





                    ListItem itemOffice = ddlOffice.Items.FindByText(ds.Rows[0]["CompanyRegisterdOffice"].ToString());
                    if (itemOffice != null)
                    {
                        ddlOffice.ClearSelection();
                        itemOffice.Selected = true;
                    }
                    txtBusinessPin.Text = ds.Rows[0]["BusinessAddPinCode"].ToString();
                    txtGstNumber.Text = ds.Rows[0]["GSTNumber"].ToString();
                    txtBusinessEmail.Text = ds.Rows[0]["BusinessAddEmail"].ToString();
                    txtBusinessPhoneNo.Text = ds.Rows[0]["BusinessAddPhoneNo"].ToString();

                    txtauthorizedperson.Text = ds.Rows[0]["NameOfAuthorizedperson"].ToString();

                    txtNameOfCompany.Text = ds.Rows[0]["NameOfCompany"].ToString();


                    DdlPartnerOrDirector.SelectedItem.Text = ds.Rows[0]["CompanyPartnerOrDirector"].ToString();

                    ListItem itemUnitOrNot = ddlUnitOrNot.Items.FindByText(ds.Rows[0]["ManufacturingFirmOrProductionUnit"].ToString());
                    if (itemUnitOrNot != null)
                    {
                        ddlUnitOrNot.ClearSelection();
                        itemUnitOrNot.Selected = true;
                    }
                    ListItem itemSameNameLicense = ddlSameNameLicense.Items.FindByText(ds.Rows[0]["ContractorLicencePreviouslyGrantedWithSameName"].ToString());
                    if (itemSameNameLicense != null)
                    {
                        ddlSameNameLicense.ClearSelection();
                        itemSameNameLicense.Selected = true;

                        if (itemSameNameLicense.Text == "YES")
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
                    }
                    ListItem itemLicenseGrantedOtherState = ddlLicenseGranted.Items.FindByText(ds.Rows[0]["ContractorLicencePreviouslyGrantedFromOtherState"].ToString());
                    if (itemLicenseGrantedOtherState != null)
                    {
                        ddlLicenseGranted.ClearSelection();
                        itemLicenseGrantedOtherState.Selected = true;

                        if (itemLicenseGrantedOtherState.Text == "YES")
                        {
                            divIssueAuthority.Visible = true;
                            divLicenseIssueDate.Visible = true;
                            divLicenseExpiry.Visible = true;
                            divDetailsOfWorkPermit.Visible = true;
                            txtIssusuingName.Text = ds.Rows[0]["NameOfIssuingAuthority"].ToString();
                            //txtIssuedateOtherState.Text = ds.Rows[0]["IssuedateOtherState"].ToString();
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
                    }


                    ListItem itemLibraryAvailable = ddlAnnexureOrNot.Items.FindByText(ds.Rows[0]["LibraryAvailable"].ToString());
                    if (itemLibraryAvailable != null)
                    {
                        ddlAnnexureOrNot.ClearSelection();
                        itemLibraryAvailable.Selected = true;
                    }

                    ListItem itemDoCompanyHavePenalties = DropDownList2.Items.FindByText(ds.Rows[0]["DoCompanyHavePenalties"].ToString());
                    if (itemDoCompanyHavePenalties != null)
                    {
                        DropDownList2.ClearSelection();
                        itemDoCompanyHavePenalties.Selected = true;

                        if (itemDoCompanyHavePenalties.Text == "YES")
                        {
                            DdlPenelity.Visible = true;
                            ShowPenelity.Visible = true;
                            DivPenelity.Visible = true;
                            txtPenalities.Text = ds.Rows[0]["Penalities"].ToString();
                        }
                        else
                        {
                            DdlPenelity.Visible = false;
                            ShowPenelity.Visible = false;
                            txtPenalities.Text = "";
                            DivPenelity.Visible = false;
                        }
                    }

                    ListItem itemWorkUnderConditionsandgulation29 = DdlWorkUnderConditionsandgulation29.Items.FindByText(ds.Rows[0]["WorkUnderLicenceConditionsandregulation29"].ToString());
                    if (itemWorkUnderConditionsandgulation29 != null)
                    {
                        DdlWorkUnderConditionsandgulation29.ClearSelection();
                        itemWorkUnderConditionsandgulation29.Selected = true;
                    }
                }
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

        private void ddlBusinessStateBind()
        {
            try
            {
                DataSet dsBusinessState = new DataSet();
                dsBusinessState = CEI.GetddlDrawState();
                ddlBusinessState.DataSource = dsBusinessState;
                ddlBusinessState.DataTextField = "StateName";
                ddlBusinessState.DataValueField = "StateID";
                ddlBusinessState.DataBind();
                ddlBusinessState.Items.Insert(0, new ListItem("Select", "0"));
                dsBusinessState.Clear();
            }
            catch (Exception)
            {
            }
        }


        private void ddlLoadBindState()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                ddlState.DataSource = dsState;
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void ContractorInformation(string ContractorId)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.GetApplicantBasicInformation(ContractorId);
                txtContractorName.Text = ds.Rows[0]["Name"].ToString();
                txtFatherName.Text = ds.Rows[0]["FatherName"].ToString();
                txtBirthDate.Text = ds.Rows[0]["DOB"].ToString();
                txtAppliedFor.Text = ds.Rows[0]["ApplicationFor"].ToString();
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/AdminLogout.aspx");
        }

        protected void btnupdate1_Click(object sender, EventArgs e)
        {
            try
            {
                if (HFContractor.Value == Convert.ToString(Session["ContractorID"]))
                {
                    CEI.UpdateContractorOrganisationDetails(txtBusinessAddress.Text, ddlBusinessState.SelectedItem.ToString(), ddlBusinessDistrict.SelectedItem.ToString(), txtBusinessPin.Text, txtBusinessEmail.Text,
                                                  txtBusinessPhoneNo.Text, txtauthorizedperson.Text, txtGstNumber.Text, ddlCompanyStyle.SelectedItem.ToString(),
                                                  txtNameOfCompany.Text, ddlOffice.SelectedItem.ToString(), txtAgentName.Text,
                                                         HFContractor.Value);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma", "alert('Multiple logins detected. Please log out from all other sessions before submitting your application.');", true);
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void btnupdate2_Click(object sender, EventArgs e)
        {
            try
            {
                if (HFContractor.Value == Convert.ToString(Session["ContractorID"]))
                {
                    CEI.UpdateOtherConOrganisationDetails( ddlUnitOrNot.SelectedItem.ToString(), ddlLicenseGranted.SelectedItem.ToString(),
                                                          txtIssusuingName.Text, txtIssuedateOtherState.Text, txtLicenseExpiry.Text, txtWorkPermitUndertaken.Text,
                                                          ddlSameNameLicense.SelectedItem.ToString(), txtLicenseNo.Text, txtLicenseIssue.Text,
                                                          HFContractor.Value);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma", "alert('Multiple logins detected. Please log out from all other sessions before submitting your application.');", true);
                    Response.Redirect("/AdminLogout.aspx",false);
                }
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void btnupdate3_Click(object sender, EventArgs e)
        {
            try
            {
                if (HFContractor.Value == Convert.ToString(Session["ContractorID"]))
                {
                    CEI.UpdateConAnnextureAndPenality(ddlAnnexureOrNot.SelectedItem.ToString(), DropDownList2.SelectedItem.ToString(), txtPenalities.Text,
                                                          HFContractor.Value);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma", "alert('Multiple logins detected. Please log out from all other sessions before submitting your application.');", true);
                    Response.Redirect("/AdminLogout.aspx", false);
                }
            }
            catch 
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void btnModalSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                if (HFContractor.Value == Convert.ToString(Session["ContractorID"]))
                {
                    string Createdby = HFContractor.Value;
                    int partnerCount = CEI.GetContractorPartnerCount(Createdby);

                    if (partnerCount >= 5)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "limitAlert", "alert('Only 5 partners are allowed.');", true);
                        return;
                    }
                    CEI.ContractorPartners(ddlAuthority.SelectedItem.ToString(), txtName.Text.Trim(), txtAddress.Text.Trim(),
                        ddlState.SelectedItem.ToString(), ddlDistrict.SelectedItem.ToString(), txtPinCode.Text.Trim(), Createdby);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);

                    PartnersModalDirectorData(Createdby);
                    //Session["PartnerDirector"] = "Added";
                    ResetModal();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma", "alert('Multiple logins detected. Please log out from all other sessions before submitting your application.');", true);
                    Response.Redirect("/AdminLogout.aspx",false);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An Error occurred.');", true);
            }
        }

        private void ResetModal()
        {
            ddlAuthority.SelectedValue = "0";
            txtName.Text = "";
            txtAddress.Text = "";
            ddlState.SelectedValue = "0";
            ddlDistrict.SelectedValue = "0";
            txtPinCode.Text = "";
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DropDownList2.SelectedValue == "1") // "Yes" selected
                {
                    DdlPenelity.Visible = true;
                    ShowPenelity.Visible = true;
                    DivPenelity.Visible = true;
                }
                else
                {
                    DdlPenelity.Visible = false;
                    ShowPenelity.Visible = false;
                    DivPenelity.Visible = false;
                    txtPenalities.Text = "";
                }

            }
            catch { }
        }

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        try
        //        {
        //            if (HFContractor.Value != null && HFContractor.Value != "")
        //            {
        //                //String ConId = Convert.ToString(Session["ContractorID"]);
        //                if (e.CommandName == "DeleteRecord")
        //                {
        //                    int id = Convert.ToInt32(e.CommandArgument);
        //                    CEI.DeleteContractorPartner(id);
        //                    PartnersModalDirectorData(HFContractor.Value);
        //                }
        //            }
        //        }
        //        catch (Exception Ex)
        //        { }
        //    }
        //    catch { }
        //}

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                try
                {
                    if (HFContractor.Value == Convert.ToString(Session["ContractorID"]))
                    {
                        //String ConId = Convert.ToString(Session["ContractorID"]);
                        if (e.CommandName == "DeleteRecord")
                        {
                            int id = Convert.ToInt32(e.CommandArgument);
                            CEI.DeleteContractorPartner(id);
                            PartnersModalDirectorData(HFContractor.Value);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma", "alert('Multiple logins detected. Please log out from all other sessions before submitting your application.');", true);
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
                catch (Exception Ex)
                { }
            }
            catch { }
        }

        protected void btnShowPartnerDiv_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);
        }

        protected void DdlPartnerOrDirector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlPartnerOrDirector.SelectedValue == "1")
            {
                 ADDpartner.Visible = true;
            }
            else
            {
               ADDpartner.Visible = false;
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                if (HFContractor.Value != null && HFContractor.Value != "")
                {
                    String ConId = HFContractor.Value;
                    if (e.CommandName == "DeleteTeam")
                    {
                        int id = Convert.ToInt32(e.CommandArgument);
                        CEI.DeleteContractorTeam(id);
                        ContractorTeamBind(ConId);
                    }
                }
            }
            catch (Exception Ex)
            { }
        }
        //protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    /*if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "") */
        //    if (HFContractor.Value != null && HFContractor.Value != "")
        //    {
        //        string createdBy = HFContractor.Value;

        //        int currentCount = CEI.GetContractorTeamCount(createdBy); // You need to create this method
        //        if (currentCount >= 5)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "LimitReached", "alert('Only 5 employees are allowed in a contractor team.');", true);
        //            return;
        //        }


        //        GridViewRow row = GridView4.SelectedRow;
        //        string typeOfEmployee = ddlEmployer1.SelectedItem.Text;

        //        // Get controls
        //        Label lblName = (Label)row.FindControl("lblName");
        //        Label lblPhoneNo = (Label)row.FindControl("lblPhoneNo");
        //        Label lblLicenseNo = (Label)row.FindControl("lblLicenseNo");
        //        Label lblIssueDate = (Label)row.FindControl("lblIssueDate");
        //        Label lblValidityDate = (Label)row.FindControl("lblValidityDate");
        //        Label lblREID = (Label)row.FindControl("lblREID");

        //        // Extract values
        //        string Name = lblName.Text.Trim();
        //        string licenseNo = lblLicenseNo.Text.Trim();
        //        string REID = lblREID.Text.Trim();

        //        DateTime issueDate, validityDate;
        //        if (lblIssueDate == null || !DateTime.TryParseExact(lblIssueDate.Text.Trim(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out issueDate))
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('Invalid Issue Date');", true);
        //            return;
        //        }
        //        if (lblValidityDate == null || !DateTime.TryParseExact(lblValidityDate.Text.Trim(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out validityDate))
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('Invalid Validity Date');", true);
        //            return;
        //        }

        //        // Pass all values to your insert method
        //        int RowAffected = CEI.InsertContractorTeam(Name, typeOfEmployee, licenseNo, issueDate, validityDate, createdBy, REID);


        //        if (RowAffected > 0)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Employee inserted successfully');", true);
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('This employee is already associated with another contractor');", true);
        //        }
        //        ContractorTeamBind(createdBy);

        //        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Employee inserted successfully');", true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('An Error occurred');", true);
        //    }
        //}

        protected void searchbtn_Click(object sender, EventArgs e)
        {

            string selectedSearchBy = ddlforsearch.SelectedValue.Trim();
            string employerType = ddlEmployer1.SelectedValue.Trim();
            string searchValue = txtSearchValue.Text.Trim();
            if ((string.IsNullOrWhiteSpace(selectedSearchBy) || selectedSearchBy == "Select" || selectedSearchBy == "0")
    || (string.IsNullOrWhiteSpace(employerType) || employerType == "Select" || employerType == "0")
    || string.IsNullOrWhiteSpace(searchValue))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('Please enter the all Required values before Search.');", true);
            }
            else
            {
                try
                {
                    DataTable dt = CEI.SearchLicenseDetails(selectedSearchBy, employerType, searchValue);
                    if (dt.Rows.Count > 0)
                    {
                        GridView4.DataSource = dt;
                        GridView4.DataBind();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal1').modal('show');", true);
                    }
                    else
                    {
                        GridView4.DataSource = null;
                        GridView4.DataBind();
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('Licence of this user is Expired');", true);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('Please Select Type of Employee And Search Type to search.');", true);                       
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('There is no active employee to attached with you.');", true);
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message.Replace("'", "\\'");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('An Error occurred: {errorMsg}');", true);
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                 if (HFContractor.Value == Convert.ToString(Session["ContractorID"]))
                    {
                    String LoginID = HFContractor.Value;
                    //LoginID = Session["ContractorID"].ToString();
                    DataTable ds = new DataTable();
                    ds = CEI.GetPartnersDirectorDate(LoginID);
                    if (DdlPartnerOrDirector.SelectedValue == "1")
                    {
                        if (GridView2.Rows.Count == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Add at least one partner');", true);
                            return;
                        }
                    }

                    bool atLeastOneSupervisorConnect = false;

                    // Check supervisor
                    foreach (GridViewRow row in GridView3.Rows)
                    {
                        string typeOfEmployee = row.Cells[1].Text.Trim();
                        if (typeOfEmployee == "Supervisor")
                        {
                            atLeastOneSupervisorConnect = true;
                            break;
                        }
                    }

                    // Condition: Supervisor mandatory
                    if (!atLeastOneSupervisorConnect)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please add at least one Supervisor (mandatory).');", true);
                        return;
                    }
                    if (GridView3.Rows.Count < 2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('You must add at least 2 employees under you.');", true);
                        return;
                    }
                    

                    if (DdlPartnerOrDirector.SelectedValue == "1" && ds.Rows.Count < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "PartnerDirectorAlert();", true);
                    }
                    //else if (!atLeastOneSupervisorConnect || !atLeastOneWiremanConnect)
                    else if (!atLeastOneSupervisorConnect)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "ContractorTeamAlert();", true);
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Application Updated Successfully !!!')", true);
                        CEI.UpdateStatusAfterEdit(LoginID);
                        Response.Redirect("/UserPages/DocumentsForContractor.aspx", false);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExpOnlyDiploma", "alert('Multiple logins detected. Please log out from all other sessions before submitting your application.');", true);
                    Response.Redirect("/AdminLogout.aspx",false);
                }
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);
            }
            catch { }
        }

        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "District";
                ddlDistrict.DataValueField = "District";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void ddlCompanyStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCompanyStyle.SelectedValue == "1")
            {
                Lbl1.Visible = true;
                Lbl2.Visible = false;
                Lbl3.Visible = false;
                Lbl4.Visible = false;
                lb5.Visible=false;
                DivAgentName.Visible = false;
                txtAgentName.Text = "";
            }
            else if (ddlCompanyStyle.SelectedValue == "2")
            {
                Lbl1.Visible = false;
                Lbl2.Visible = true;
                Lbl3.Visible = false;
                Lbl4.Visible = false;
                lb5.Visible=false;
                DivAgentName.Visible = true;
            }
            else if (ddlCompanyStyle.SelectedValue == "3")
            {
                Lbl1.Visible = false;
                Lbl2.Visible = false;
                Lbl3.Visible = true;
                Lbl4.Visible = false;
                lb5.Visible=false;
                DivAgentName.Visible = false;
                txtAgentName.Text = "";
            }
            else if (ddlCompanyStyle.SelectedValue == "4")
            {
                Lbl1.Visible = false;
                Lbl2.Visible = false;
                Lbl3.Visible = false;
                Lbl4.Visible = true;
                lb5.Visible=false;
                DivAgentName.Visible = false;
                txtAgentName.Text = "";
            }
            else if (ddlCompanyStyle.SelectedValue == "5")
            {
                Lbl1.Visible = false;
                Lbl2.Visible = false;
                Lbl3.Visible = false;
                Lbl4.Visible = false;
                lb5.Visible=true;
                DivAgentName.Visible = false;
                txtAgentName.Text = "";
            }
        }

        protected void btnupdateWorkUnderConditionsandgulation29_Click(object sender, EventArgs e)
        {
            try
            {
                if (HFContractor.Value != null && HFContractor.Value != "")
                {
                    CEI.UpdatevalueofWorkUnderConditionsandgulation29(DdlWorkUnderConditionsandgulation29.SelectedItem.ToString(), HFContractor.Value);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Details Updated Successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('There is an issue in Updating!!!')", true);
                }
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }

        ////protected void ddlEmployer1_SelectedIndexChanged(object sender, EventArgs e)
        ////{
        ////    string employerType = ddlEmployer1.SelectedValue;
        ////    try
        ////    {
        ////        DataTable dt = CEI.SearchLicenseDetails(employerType);
        ////        if (dt.Rows.Count > 0)
        ////        {
        ////            GridView4.DataSource = dt;
        ////            GridView4.DataBind();
        ////            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#myModal1').modal('show');", true);
        ////        }
        ////        else
        ////        {
        ////            GridView4.DataSource = null;
        ////            GridView4.DataBind();
        ////            ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('There is no any employee active to attached with you.');", true);
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        string errorMsg = ex.Message.Replace("'", "\\'");
        ////        ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('An Error occurred: {errorMsg}');", true);
        ////    }
        ////}

        //protected void ddlBusinessState_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddlLoadBindBusinessDistrict(ddlBusinessState.SelectedItem.ToString());
        //}

        private void ddlLoadBindBusinessDistrict(string State)
        {
            DataSet dsDistrict = new DataSet();
            dsDistrict = CEI.GetddlDrawDistrict(State);
            ddlBusinessDistrict.DataSource = dsDistrict;
            ddlBusinessDistrict.DataTextField = "District";
            ddlBusinessDistrict.DataValueField = "District";
            ddlBusinessDistrict.DataBind();
            ddlBusinessDistrict.Items.Insert(0, new ListItem("Select", "0"));
            dsDistrict.Clear();
        }


        protected void GridView4_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (!string.IsNullOrEmpty(HFContractor.Value))
                {
                    string createdBy = HFContractor.Value;

                    //int currentCount = CEI.GetContractorTeamCount(createdBy);
                    //if (currentCount >= 2)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "LimitReached", "alert('Only 2 employees are allowed in a contractor team.');", true);
                    //    ddlEmployer1.ClearSelection();
                    //    return;
                    //}

                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    GridViewRow row = GridView4.Rows[rowIndex];
                    string typeOfEmployee = ddlEmployer1.SelectedItem.Text;

                    // Get controls
                    Label lblName = (Label)row.FindControl("lblName");
                    Label lblPhoneNo = (Label)row.FindControl("lblPhoneNo");
                    Label lblLicenseNo = (Label)row.FindControl("lblLicenseNo");
                    Label lblIssueDate = (Label)row.FindControl("lblIssueDate");
                    Label lblValidityDate = (Label)row.FindControl("lblValidityDate");
                    Label lblREID = (Label)row.FindControl("lblREID");

                    // Extract values
                    string Name = lblName.Text.Trim();
                    string licenseNo = lblLicenseNo.Text.Trim();
                    string REID = lblREID.Text.Trim();

                    DateTime issueDate, validityDate;
                    if (lblIssueDate == null ||
                        !DateTime.TryParseExact(lblIssueDate.Text.Trim(), "dd-MM-yyyy", null,
                            System.Globalization.DateTimeStyles.None, out issueDate))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('Invalid Issue Date');", true);
                        return;
                    }

                    if (lblValidityDate == null ||
                        !DateTime.TryParseExact(lblValidityDate.Text.Trim(), "dd-MM-yyyy", null,
                            System.Globalization.DateTimeStyles.None, out validityDate))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('Invalid Validity Date');", true);
                        return;
                    }

                    // Insert employee
                    int RowAffected = CEI.InsertContractorTeam(Name, typeOfEmployee, licenseNo,
                        issueDate, validityDate, createdBy, REID);

                    if (RowAffected > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Employee inserted successfully');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('This employee is already associated with another contractor');", true);
                    }

                    ContractorTeamBind(createdBy);
                    ddlEmployer1.ClearSelection();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('An error occurred');", true);
                }
            }
        }

        protected void ddlBusinessState_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ddlLoadBindBusinessDistrict(ddlBusinessState.SelectedItem.ToString());
        }

        protected void ddlSameNameLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSameNameLicense.SelectedValue == "1") // "Yes"
                {
                    DivLicenseNo.Visible = true;
                    DivLicenseIssueDateifSameName.Visible = true;
                }
                else
                {
                    DivLicenseNo.Visible = false;
                    DivLicenseIssueDateifSameName.Visible = false;

                    txtLicenseNo.Text = "";
                    txtLicenseIssue.Text = "";
                }
            }
            catch
            {

            }
        }

        protected void ddlLicenseGranted_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlLicenseGranted.SelectedValue == "1") // "Yes" selected
                {
                    divIssueAuthority.Visible = true;
                    divLicenseIssueDate.Visible = true;
                    divLicenseExpiry.Visible = true;
                    divDetailsOfWorkPermit.Visible = true;
                    //divLicensePreviouslyGranted.Visible = true;
                }
                else
                {
                    divIssueAuthority.Visible = false;
                    divLicenseIssueDate.Visible = false;
                    divLicenseExpiry.Visible = false;
                    divDetailsOfWorkPermit.Visible = false;
                    //divLicensePreviouslyGranted.Visible = false;
                    txtIssusuingName.Text = "";
                    txtIssuedateOtherState.Text = "";
                    txtLicenseExpiry.Text = "";
                    txtWorkPermitUndertaken.Text = "";
                }

            }
            catch { }
        }
    }
}

