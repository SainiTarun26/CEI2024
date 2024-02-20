using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class ContractorRenewal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["ContractorID"]) != null && Convert.ToString(Session["ContractorID"]) != "")
                {

                    GetContractorDetails();
                    GetGridData();
                }
            }
        }

        private void GetContractorDetails()
        {
            try
            {
                string id = Session["ContractorID"].ToString();

                DataSet ds = new DataSet();

                ds = CEI.GetContractorDataForRenewal(id);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    txtLicenceNo.Text = ds.Tables[0].Rows[0]["LicenceNo"].ToString();

                    ddlLoadBindState();
                    string issueDate = ds.Tables[0].Rows[0]["IntialIssueDate"].ToString();
                    txtIssueDate.Text = DateTime.Parse(issueDate).ToString("yyyy-MM-dd");

                    string ExpiryDate = ds.Tables[0].Rows[0]["ExpiryDate"].ToString();
                    txtExpiryDate.Text = DateTime.Parse(ExpiryDate).ToString("yyyy-MM-dd");

                    //if (!string.IsNullOrEmpty(txtExpiryDate.Text))
                    //{
                    //    DateTime selectedExpiryDate;
                    //    if (DateTime.TryParse(txtExpiryDate.Text, out selectedExpiryDate))
                    //    {
                    //        DateTime currentDate = DateTime.Now;
                    //        if (selectedExpiryDate < currentDate)
                    //        {
                    //            divBelated.Visible = true;
                    //            TimeSpan remainingDays = currentDate - selectedExpiryDate;
                    //            int ageYear = (int)(remainingDays.TotalDays / 365.25);
                    //            int ageMonth = (int)((remainingDays.TotalDays % 365.25) / 30.44);
                    //            int ageDay = (int)(remainingDays.TotalDays % 30.44);
                    //            string ageString = $"{ageYear} Years - {ageMonth} Months - {ageDay} Days";
                    //            txtBelatedDate.Text = ageString;
                    //        }
                    //        else {
                    //            divBelated.Visible = false;


                    if (!string.IsNullOrEmpty(txtExpiryDate.Text))
                    {
                        DateTime selectedExpiryDate;
                        if (DateTime.TryParse(txtExpiryDate.Text, out selectedExpiryDate))
                        {
                            DateTime currentDate = DateTime.Now;
                            if (selectedExpiryDate < currentDate)
                            {
                                divBelated.Visible = true;
                                txtBelatedDate.Text = CEI.CalculateRemainingDate(currentDate, selectedExpiryDate);
                            }
                        }
                    }

                    if (txtDOB.Text != "")
                    {
                        DateTime selectedDOB;
                        if (DateTime.TryParse(txtDOB.Text, out selectedDOB))
                        {
                            DateTime currentDate = DateTime.Now;
                            //int ageDiff = currentDate.Year - selectedDOB.Year;

                            //TimeSpan ageDifference = currentDate - selectedDOB;
                            //int ageYear = (int)(ageDifference.TotalDays / 365.25);
                            //int ageMonth = (int)((ageDifference.TotalDays % 365.25) / 30.44);
                            //int ageDay = (int)(ageDifference.TotalDays % 30.44);
                            //string ageString = $"{ageYear} Years - {ageMonth} Months - {ageDay} Days";
                            //txtAge.Text = ageString;
                            txtAge.Text = CEI.CalculateRemainingDate(currentDate, selectedDOB);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Invalid Date format. Please enter a valid date.');", true);
                            txtDOB.Text = "";

                            txtAge.Text = "";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please enter your date of birth.');", true);
                    }
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["BranchOffice"].ToString();
                    txtpincode.Text = ds.Tables[0].Rows[0]["BranchPinCode"].ToString();
                    string state = ds.Tables[0].Rows[0]["BranchState"].ToString();
                    state = "Haryana ";

                    DdlState.SelectedIndex = DdlState.Items.IndexOf(DdlState.Items.FindByText(state));
                    string District = ds.Tables[0].Rows[0]["BranchDistrictoffirm"].ToString();
                    DdlState.SelectedIndex = DdlState.Items.IndexOf(DdlState.Items.FindByText(state));
                    ddlLoadBindDistrict(state);
                    DdlDistrict.SelectedValue = District;
                }
            }
            catch { }
        }

        private void ddlLoadBindState()
        {
            try
            {
                DataSet dsState = new DataSet();
                dsState = CEI.GetddlDrawState();
                DdlState.DataSource = dsState;
                DdlState.DataTextField = "StateName";
                DdlState.DataValueField = "StateID";
                DdlState.DataBind();
                DdlState.Items.Insert(0, new ListItem("Select", "0"));
                dsState.Clear();
            }
            catch (Exception ex)
            { }
        }

        private void ddlLoadBindDistrict(string state)
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                DdlDistrict.DataSource = dsDistrict;
                DdlDistrict.DataTextField = "District";
                DdlDistrict.DataValueField = "District";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex)
            { }
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDOB.Text != "")
                {
                    DateTime selectedDOB;
                    if (DateTime.TryParse(txtDOB.Text, out selectedDOB))
                    {
                        DateTime currentDate = DateTime.Now;
                        int ageDiff = currentDate.Year - selectedDOB.Year;
                        if (ageDiff < 18)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You must be at least 18 years old.');", true);
                            txtDOB.Text = "";
                            txtAge.Text = "";
                        }
                        else if (ageDiff > 65)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You are not eligible to fill this form.');", true);
                            txtDOB.Text = "";
                            txtAge.Text = "";
                        }
                        else
                        {
                            // Calculate age
                            TimeSpan ageDifference = currentDate - selectedDOB;
                            int ageYear = (int)(ageDifference.TotalDays / 365.25);
                            int ageMonth = (int)((ageDifference.TotalDays % 365.25) / 30.44);
                            int ageDay = (int)(ageDifference.TotalDays % 30.44);
                            string ageString = $"{ageYear} Years - {ageMonth} Months - {ageDay} Days";
                            txtAge.Text = ageString;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Invalid Date format. Please enter a valid date.');", true);
                        txtDOB.Text = "";
                        txtAge.Text = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('Please enter your date of birth.');", true);
                }
            }
            catch { }
        }

        protected void DdlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlState.SelectedValue != null)
            {
                ddlLoadBindDistrict(DdlState.SelectedItem.ToString());
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList1.SelectedValue == "1")
                {
                    txtAddress.ReadOnly = true;
                    //DdlState.Enabled = false;
                    DdlState.Attributes.Add("disabled", "disabled");
                    DdlDistrict.Attributes.Add("disabled", "disabled");
                    txtpincode.ReadOnly = true;
                }
                else
                {
                    txtAddress.ReadOnly = false;
                    DdlState.Attributes.Remove("disabled");
                    DdlDistrict.Attributes.Remove("disabled");
                    txtpincode.ReadOnly = false;
                }
            }
            catch { }
        }

        protected void GetassigneddatatoContractor()
        {
            try
            {
                string ID = string.Empty;
                ID = Session["id"].ToString();
                DataTable ds = new DataTable();
                ds = CEI.GetStaffAssignedToContractor(ID);
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
            catch
            {
            }
        }

        public void GetGridData()
        {
            try
            {
                string LoginID = string.Empty;
                LoginID = Session["ContractorID"].ToString();
                hdnId.Value = LoginID;

                DataSet ds = new DataSet();

                ds = CEI.WorkIntimationGridData(LoginID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
            }
            catch { }
        }
    }
}