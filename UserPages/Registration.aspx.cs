using CEI_PRoject;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class Registration : System.Web.UI.Page
    {

        //Page settd by neha 18-June-2025
        string REID = string.Empty;
        CEI CEI = new CEI();
        string ipaddress;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlLoadBindState();
                    ddlLoadBindState1();
                    //ddlBindDistrict();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx", false);
            }
        }
        //private void ddlBindDistrict()
        //{
        //    DataTable ds = new DataTable();
        //    ds = CEI.getDistrict();
        //    ddlDist.DataSource = ds;
        //    ddlDist.DataTextField = "HeadOffice";
        //    ddlDist.DataValueField = "Area";
        //    ddlDist.DataBind();
        //    ddlDist.Items.Insert(0, new ListItem("Select", "0"));
        //    ds.Clear();
        //}
        //private void ddlBindDivision()
        //{
        //    string District = ddlDist.SelectedItem.ToString();
        //    DataTable ds = new DataTable();
        //    ds = CEI.getDivisionDistrict(District);
        //    ddlDivision.DataSource = ds;
        //    ddlDivision.DataTextField = "Area";
        //    ddlDivision.DataValueField = "HeadOffice";
        //    ddlDivision.DataBind();
        //    ddlDivision.Items.Insert(0, new ListItem("Select", "0"));
        //    ds.Clear();
        //}
        #region GetIP
        protected void GetIP()
        {
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == txtConfirmPswrd.Text)
                {
                    string Category = string.Empty;
                    string name = txtName.Text;
                    string dob = txtDOB.Text;
                    string firstNamePart = name.Length >= 4 ? name.Substring(0, 4) : name;
                    string numericDOB = new string(dob.Where(char.IsDigit).ToArray());
                    string userId = $"{firstNamePart}{numericDOB}";

                    if (ddlcategory.SelectedValue == "1")
                    {
                        Category = "Wireman";
                    }
                    else if (ddlcategory.SelectedValue == "2")
                    {
                        Category = "Supervisor";
                    }
                    else
                    {
                        Category = "Contractor";
                    }
                    GetIP();
                    int Aadhar = CEI.CheckAadharOrPANExist(txtAadhaar.Text.Trim(), txtpancard.Text.Trim());
                    if (Aadhar > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "AadharAlert();", true);
                        return;
                    }
                    else
                    {
                        if (Convert.ToString(hdnrandomNumber.Value) == null || Convert.ToString(hdnrandomNumber.Value) == "")
                        {
                            GenerateUniquerandomNumber();
                        }
                        if (Convert.ToString(hdnrandomNumber.Value) != null && Convert.ToString(hdnrandomNumber.Value) != "")
                        {
                            string RandomUniqueNumber = hdnrandomNumber.Value;
                            GetIP();
                            CEI.InserNewUserData(ddlcategory.SelectedItem.ToString(), txtName.Text, txtDOB.Text, txtyears.Text, txtFatherNmae.Text,
                            ddlGender.SelectedItem.ToString(), txtAadhaar.Text.Trim(), txtpancard.Text.Trim(), txtPermanentAddress.Text, ddlDistrict.SelectedItem.ToString(),
                            ddlState.SelectedItem.ToString(), txtPinCode.Text, txtphone.Text,
                            txtEmailID.Text, Category, userId, userId, txtCommunicationAddress.Text, ddlState1.SelectedItem.ToString(), ddlDistrict1.SelectedItem.ToString(),
                            txtPin.Text, txtConfirmPswrd.Text, ipaddress, RandomUniqueNumber);

                            CEI.ToActivateAndVerifyEmail(txtEmailID.Text, RandomUniqueNumber);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Passwords do not match. Please enter the same passwords.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", $"alert('An error occurred:');", true);
                return;
            }
        }

        private void GenerateUniquerandomNumber()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1000000000, int.MaxValue);

            string currentDate = DateTime.Now.ToString("ddMMyyyyHHmmss");

            string combined = randomNumber.ToString() + currentDate;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // hex format
                }
                string uniqueAlphanumeric = sb.ToString().Substring(0, 30); // Get first 30 chars
                hdnrandomNumber.Value = uniqueAlphanumeric;
            }
        }

        private void ddlLoadBindState()
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
        private void ddlLoadBindDistrict(string state)
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
        private void ddlLoadBindState1()
        {
            DataSet dsState = new DataSet();
            dsState = CEI.GetddlDrawState();
            ddlState1.DataSource = dsState;
            ddlState1.DataTextField = "StateName";
            ddlState1.DataValueField = "StateID";
            ddlState1.DataBind();
            ddlState1.Items.Insert(0, new ListItem("Select", "0"));
            dsState.Clear();
        }
        private void ddlLoadBindDistrict1(string state)
        {
            DataSet dsDistrict = new DataSet();
            dsDistrict = CEI.GetddlDrawDistrict(state);
            ddlDistrict1.DataSource = dsDistrict;
            ddlDistrict1.DataTextField = "District";
            ddlDistrict1.DataValueField = "District";
            ddlDistrict1.DataBind();
            ddlDistrict1.Items.Insert(0, new ListItem("Select", "0"));
            dsDistrict.Clear();
        }
        protected void txtDOB_TextChanged(object sender, EventArgs e)
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
                        CalculatedDatey.Visible = false;
                    }
                    else if (ageDiff >= 65)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ShowAlert", "alert('You are not eligible to fill this form As you Age is 65 or more than 65 years.');", true);
                        txtDOB.Text = "";
                        CalculatedDatey.Visible = false;
                    }
                    else
                    {
                        if (DateTime.TryParseExact(txtDOB.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dobDate))
                        {
                            if (dobDate > currentDate)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid Date !!!')", true);
                                txtDOB.Text = "";
                                CalculatedDatey.Visible = false;
                            }
                            else
                            {
                                TimeSpan ageDifference = currentDate - selectedDOB;
                                int ageYear = (int)(ageDifference.TotalDays / 365.25);
                                int ageMonth = (int)((ageDifference.TotalDays % 365.25) / 30.44);
                                int ageDay = (int)(ageDifference.TotalDays % 30.44);

                                string ageString = $"{ageYear} Years - {ageMonth} Months - {ageDay} Days";

                                if (ageYear >= 64)
                                {

                                    DateTime sixtyFifthBirthday = selectedDOB.AddYears(65);
                                    int totalMonthsLeft = ((sixtyFifthBirthday.Year - currentDate.Year) * 12) + (sixtyFifthBirthday.Month - currentDate.Month);


                                    if (sixtyFifthBirthday.Day < currentDate.Day)
                                    {
                                        totalMonthsLeft--;
                                    }

                                    DateTime intermediateDate = currentDate.AddMonths(totalMonthsLeft);

                                    int remainingDays = (sixtyFifthBirthday - intermediateDate).Days;

                                    string timeLeft = $"{totalMonthsLeft} Months - {remainingDays} Days";
                                    string script = $"alert('You are eligible for this license only for the remaining {timeLeft}');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
                                }
                                txtyears.Text = ageString;
                                CalculatedDatey.Visible = true;
                            }
                        }
                    }
                }
            }
            else
            {
                CalculatedDatey.Visible = false;
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
            }
            ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
        }

        protected void ddlState1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLoadBindDistrict1(ddlState1.SelectedItem.ToString());
        }
        #region gurmeet 30-June-2025
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {

                if (txtCommunicationAddress.Text != "" && ddlDistrict1.SelectedValue != "" && ddlDistrict1.SelectedValue != "0" && txtPinCode.Text != ""
                    && ddlState1.SelectedValue != "" && ddlState1.SelectedValue != "0"
                    )
                {
                    txtPermanentAddress.Text = txtCommunicationAddress.Text;
                    ddlState.SelectedValue = ddlState1.SelectedValue;
                    //ddlDistrict.ClearSelection();
                    ddlLoadBindDistrict(ddlState1.SelectedItem.ToString());
                    ddlDistrict.SelectedValue = ddlDistrict1.SelectedValue;
                    //ddlDistrict.Items.Clear();
                    //ddlDistrict.Items.Add(new ListItem(ddlDistrict1.SelectedItem.Text, "1"));
                    txtPin.Text = txtPinCode.Text;

                    txtPermanentAddress.Attributes.Add("readonly", "false");
                    txtPin.Attributes.Add("readonly", "false");

                    ddlState.Attributes.Add("disabled", "disabled");
                    ////ddlDistrict.Attributes.Add("disabled", "disabled");
                    ddlDistrict.Enabled = false;

                    //txtCommunicationAddress.Attributes.Add("readonly", "true");
                    txtCommunicationAddress.ReadOnly = true;
                    //txtPinCode.Attributes.Add("readonly", "false");
                    txtPinCode.ReadOnly = true;
                    ddlState1.Attributes.Add("disabled", "disabled");
                    ////ddlDistrict1.Attributes.Add("disabled", "disabled");
                    ddlDistrict1.Enabled = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please Select Communication  Address First!!!')", true);
                    ddlDistrict.Focus();
                    CheckBox1.Checked = false;
                }
            }
            else
            {
                txtCommunicationAddress.ReadOnly = false;
                txtPermanentAddress.Text = "";
                ddlState.SelectedValue = "0";
                ddlDistrict.Items.Clear();
                ddlDistrict.Items.Add(new ListItem("Select", "0"));
                txtPin.Text = "";
                txtPermanentAddress.Attributes.Remove("readonly");
                ddlState.Attributes.Remove("disabled");
                txtPin.Attributes.Remove("readonly");
                ddlDistrict.Attributes.Remove("disabled");

                txtCommunicationAddress.Attributes.Remove("readonly");
                txtCommunicationAddress.ReadOnly = false;
                //txtPinCode.Attributes.Remove("disabled");
                ddlState1.Attributes.Remove("disabled");
                ddlDistrict1.Attributes.Remove("disabled");
                txtPinCode.ReadOnly = false;
                ddlDistrict.Enabled = true;
                ddlDistrict1.Enabled = true;

            }
        }
        #endregion
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserPages/Instructions.aspx", false);
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
            if (ddlcategory.SelectedValue == "3")
            {
                Pancardno.Visible = true;
                Aadhaarcard.Visible = false;
                WireSup.Visible = false;
                contractor.Visible = true;
            }
            else
            {
                contractor.Visible = false;
                WireSup.Visible = true;
                Aadhaarcard.Visible = true;
                Pancardno.Visible = false;
            }
        }

        private void Reset()
        {
            txtName.Text = "";
            txtFatherNmae.Text = "";
            txtAadhaar.Text = "";
            txtpancard.Text = "";
            ddlGender.SelectedValue = "0";
            txtDOB.Text = "";
            txtCommunicationAddress.Text = "";
            ddlState1.SelectedIndex = 0;
            ddlDistrict1.SelectedIndex = 0;
            txtPinCode.Text = "";
            txtphone.Text = "";
            txtPassword.Text = "";
            txtPermanentAddress.Text = "";
            ddlState.SelectedIndex = 0;
            txtPin.Text = "";
            txtEmailID.Text = "";
            txtConfirmPswrd.Text = "";
            txtyears.Text = "";
            CheckBox1.Checked = false;
            ddlDistrict.SelectedIndex = 0;

            CalculatedDatey.Visible = false;
            txtPermanentAddress.Text = "";
            ddlState.SelectedValue = "0";
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add(new ListItem("Select", "0"));
            txtPin.Text = "";
            txtPermanentAddress.Attributes.Remove("readonly");
            ddlState.Attributes.Remove("disabled");
            txtPin.Attributes.Remove("readonly");
            ddlDistrict.Attributes.Remove("disabled");
        }

        //protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddlBindDivision();
        //}
        #region neeraj 2-July-2025
        //protected void txtCommunicationAddress_TextChanged(object sender, EventArgs e)
        //{

        //    ddlState1.SelectedValue = "0";
        //    ddlDistrict1.SelectedValue = "0";
        //    txtPinCode.Text = "";          
        //    txtPinCode.Attributes.Remove("readonly");
        //    txtPermanentAddress.Text = "";
        //    ddlState.SelectedValue = "0";          
        //    ddlDistrict.SelectedValue = "0";
        //    txtPin.Text = "";
        //    txtPermanentAddress.Attributes.Remove("readonly");
        //    txtPin.Attributes.Remove("readonly");
        //    ddlState1.Attributes.Remove("disabled");
        //    ddlDistrict1.Attributes.Remove("disabled");
        //    ddlState.Attributes.Remove("disabled");
        //    ddlDistrict.Attributes.Remove("disabled");
        //    CheckBox1.Checked = false;

        //}
        #endregion
    }
}