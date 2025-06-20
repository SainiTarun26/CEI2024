using CEI_PRoject;
using CEIHaryana.Contractor;
using OfficeOpenXml.Drawing.Slicer.Style;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace CEIHaryana.UserPages
{
    public partial class ContractorApplicationForm : System.Web.UI.Page
    {
        //Page settd by neha 18-June-2025
        CEI CEI = new CEI();
        string LoginID = string.Empty;
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
                        PartnersModalDirectorData(ContractorId);
                        ContractorTeamBind(ContractorId);
                        //if (Session["PartnerDirector"] != null)
                        //{
                        //    PartnersModalDirectorData();
                        //}
                        //else {}
                    }
                    else
                    {
                        Response.Redirect("/LogOut.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
            }
        }
        private void ContractorInformation(string ContractorId)
        {
            try
            {
                DataTable ds = new DataTable();
                ds = CEI.ContractorBasicInformation(ContractorId);
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

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);
            }
            catch { }

        }
        protected void ddlPenalities_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPenalities.SelectedValue != "0")
                {
                    string selectedValue = ddlPenalities.SelectedValue;

                    if (!string.IsNullOrEmpty(txtPenalities.Text))
                    {
                        // If the TextBox is not empty, append a comma and space
                        txtPenalities.Text += ", ";
                    }

                    txtPenalities.Text += ddlPenalities.SelectedItem.ToString();

                    ListItem itemToRemove = ddlPenalities.Items.FindByValue(selectedValue);
                    if (itemToRemove != null)
                    {
                        ddlPenalities.Items.Remove(itemToRemove);
                    }

                    ddlPenalities.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or display an error message.
            }
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
        protected void DdlPartnerOrDirector_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the selected value is "YES"
            if (DdlPartnerOrDirector.SelectedValue == "1")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);
                ADDpartner.Visible = true;
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "hideModal", "$('#myModal').modal('hide');", true);
                ADDpartner.Visible = false;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                try
                {
                    if (HFContractor.Value != null && HFContractor.Value != "")
                    {
                        //String ConId = Convert.ToString(Session["ContractorID"]);
                        if (e.CommandName == "DeleteRecord")
                        {
                            int id = Convert.ToInt32(e.CommandArgument);
                            CEI.DeleteContractorPartner(id);
                            PartnersModalDirectorData(HFContractor.Value);
                        }
                    }
                }
                catch (Exception Ex)
                { }
            }
            catch { }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                if (HFContractor.Value != null && HFContractor.Value != "")
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
                    bool atLeastOneWiremanConnect = false;
                    foreach (GridViewRow row in GridView3.Rows)
                    {
                        string typeOfEmployee = row.Cells[1].Text.Trim();
                        if (typeOfEmployee == "Supervisor")
                        {
                            atLeastOneSupervisorConnect = true;
                        }
                        if (typeOfEmployee == "Wireman")
                        {
                            atLeastOneWiremanConnect = true;
                        }
                        if (atLeastOneSupervisorConnect && atLeastOneWiremanConnect)
                        {
                            break;
                        }
                    }

                    // If not both are present, show alert
                    if (!(atLeastOneSupervisorConnect && atLeastOneWiremanConnect))
                    {
                        //Response.Write("<script>alert('Please Add at least one Supervisor And Wireman.');</script>");
                        //return;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please Add at least one Supervisor And Wireman.');", true);
                    }

                    


                    if (DdlPartnerOrDirector.SelectedValue == "1" && ds.Rows.Count < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "PartnerDirectorAlert();", true);
                    }
                    else if (!atLeastOneSupervisorConnect || !atLeastOneWiremanConnect)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "ContractorTeamAlert();", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "CallValidateForm", "validateForm();", true);

                        string validationResult = Page.ClientScript.GetWebResourceUrl(this.GetType(), "window.validationResult");

                        bool isValidBoolean;
                        if (!bool.TryParse(validationResult, out isValidBoolean))
                        {
                           

                            //string Createdby = Session["ContractorID"].ToString();
                            string selectedValues = txtPenalities.Text.Trim();
                            CEI.ContractorApplicationData(txtBusinessAddress.Text, txtBusinessPin.Text, txtBusinessEmail.Text, txtBusinessPhoneNo.Text,
                                                          txtGstNumber.Text, ddlCompanyStyle.SelectedItem.ToString(), txtNameOfCompany.Text, ddlOffice.SelectedItem.ToString(),
                                                          DdlPartnerOrDirector.SelectedItem.ToString(), ddlAnnexureOrNot.SelectedItem.ToString(),
                                                          txtAgentName.Text, ddlUnitOrNot.SelectedItem.ToString(), ddlLicenseGranted.SelectedItem.ToString(), 
                                                          txtIssusuingName.Text, txtIssuedateOtherState.Text, txtLicenseExpiry.Text, txtWorkPermitUndertaken.Text,
                                                          ddlSameNameLicense.SelectedItem.ToString(), txtLicenseNo.Text, txtLicenseIssue.Text,
                                                          DropDownList2.SelectedItem.ToString(), txtPenalities.Text,
                                                          LoginID);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Application Submitted Successfully !!!')", true);
                            Response.Redirect("/UserPages/DocumentsForContractor.aspx", false);
                        }
                    }
                }
            }
            catch
            {
                Response.Redirect("/LogOut.aspx");
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
        protected void btnModalSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                if (HFContractor.Value != null && HFContractor.Value != "")
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
                }
                else
                {
                    DdlPenelity.Visible = false;
                    ShowPenelity.Visible = false;
                }

            }
            catch { }
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
                }

            }
            catch { }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["ContractorID"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("/Login.aspx");
        }

        ////protected void btnAddEmployeeDetails_Click(object sender, EventArgs e)
        ////{
        ////    try
        ////    {
        //// string CreatedBy = Session["ContractorID"].ToString();
        //// //bool isvaild = bool.Parse(hdnIsClientSideValid.Value);
        //// //if (isvaild){}               
        //// DataTable ds = new DataTable();
        //// ds = CEI.checkvacantSupervisor(txtLicense1.Text.Trim());
        //// if (ds.Rows.Count > 0)
        //// {
        ////     ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "CheckVacantSupervisor();", true);


        ////}
        //// //else {
        //// //    CEI.InsertContractorTeam(ddlEmployer1.SelectedItem.ToString(), txtLicense1.Text.Trim(), txtIssueDate1.Text.Trim(), txtValidity1.Text.Trim(),
        //// //                       txtQualification1.Text.Trim(), CreatedBy);
        //// //    ContractorTeamBind();
        //// //}
        ////     ddlEmployer1.SelectedValue = "0";
        ////     txtLicense1.Text = "";
        ////     txtIssueDate1.Text = ""; txtValidity1.Text = ""; txtQualification1.Text = "";

        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "alert('An Error occured');", true);
        ////    }
        ////}

        private void ContractorTeamBind(string LoginID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = CEI.GetContractorTeam(LoginID);

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


        protected void btnShowPartnerDiv_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);
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
                }
            }
            catch
            {

            }
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            string selectedSearchBy = ddlforsearch.SelectedValue;
            string employerType = ddlEmployer1.SelectedValue;
            string searchValue = txtSearchValue.Text.Trim();
            try
            {
                DataTable dt = CEI.SearchLicenseDetails(selectedSearchBy, searchValue, employerType);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('Please Select Type of Employee And Search Type to search.');", true);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message.Replace("'", "\\'");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('An Error occurred: {errorMsg}');", true);
            }
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "") */
            if (HFContractor.Value != null && HFContractor.Value != "")
            {
                string createdBy = HFContractor.Value;

                int currentCount = CEI.GetContractorTeamCount(createdBy); // You need to create this method
                if (currentCount >= 5)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LimitReached", "alert('Only 5 employees are allowed in a contractor team.');", true);
                    return;
                }


                GridViewRow row = GridView4.SelectedRow;
                string typeOfEmployee = ddlEmployer1.SelectedItem.Text;

                // Get controls
                Label lblName = (Label)row.FindControl("lblName");
                Label lblPhoneNo = (Label)row.FindControl("lblPhoneNo");
                Label lblLicenseNo = (Label)row.FindControl("lblLicenseNo");
                Label lblIssueDate = (Label)row.FindControl("lblIssueDate");
                Label lblValidityDate = (Label)row.FindControl("lblValidityDate");

                // Extract values
                string Name = lblName.Text.Trim();
                string licenseNo = lblLicenseNo.Text.Trim();


                DateTime issueDate, validityDate;
                if (lblIssueDate == null || !DateTime.TryParseExact(lblIssueDate.Text.Trim(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out issueDate))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('Invalid Issue Date');", true);
                    return;
                }
                if (lblValidityDate == null || !DateTime.TryParseExact(lblValidityDate.Text.Trim(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out validityDate))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('Invalid Validity Date');", true);
                    return;
                }

                // Pass all values to your insert method
                int RowAffected = CEI.InsertContractorTeam(Name, typeOfEmployee, licenseNo, issueDate, validityDate, createdBy);


                if (RowAffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Employee inserted successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Err", "alert('This employee is already associated with another contractor');", true);
                }
                ContractorTeamBind(createdBy);

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Employee inserted successfully');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", $"alert('An Error occurred');", true);
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

        protected void ddlCompanyStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (ddlCompanyStyle.SelectedValue == "1")
            {          
                Lbl1.Visible = true;
                Lbl2.Visible = false;
                Lbl3.Visible = false;
                Lbl4.Visible = false;
            }
            else if (ddlCompanyStyle.SelectedValue == "2")
            {               
                Lbl1.Visible = false;
                Lbl2.Visible = true;
                Lbl3.Visible = false;
                Lbl4.Visible = false;
            }
            else if (ddlCompanyStyle.SelectedValue == "3")
            {               
                Lbl1.Visible = false;
                Lbl2.Visible = false;
                Lbl3.Visible = true;
                Lbl4.Visible = false;
            }
            else if (ddlCompanyStyle.SelectedValue == "4")
            {             
                Lbl1.Visible = false;
                Lbl2.Visible = false;
                Lbl3.Visible = false;
                Lbl4.Visible = true;
            }
        }
    }

}