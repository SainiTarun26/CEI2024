using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEI_PRoject.Admin
{
    public partial class AddContractorDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        public string UserId;
        public string Qualification;
        string REID = string.Empty;
        string ipaddress;
        string Createdby = string.Empty;
        public void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                if (!IsPostBack)
                {
                    if (Session["AdminID"] != null || Request.Cookies["AdminID"] != null)
                    {
                        ddlLoadBindVoltage();
                        ddlLoadBindState();
                        //ddlLoadBindDistrict();
                        ddlLoadBindDistrictddl();
                        if (Convert.ToString(Session["ID"]) == null || Convert.ToString(Session["ID"]) == "")
                        {

                        }
                        else
                        {
                            REID = Session["ID"].ToString();
                            hdnId.Value = REID;
                            btnSubmit.Text = "Update";
                            BtnReset.Visible = false;
                            update();
                            Session["ID"] = "";
                        }

                    }
                    else
                    {
                        Session["ID"] = "";
                        Session["AdminID"] = "";
                        Response.Redirect("/Login.aspx");
                    }
                }
            }
            catch (Exception)
            {

                Response.Redirect("/Login.aspx");
            }
        }

        private void ddlLoadBindVoltage()
        {

            DataSet dsVoltage = new DataSet();
            dsVoltage = CEI.GetddlVoltageLevel();
            ddlVoltageLevel.DataSource = dsVoltage;
            ddlVoltageLevel.DataTextField = "Voltagelevel";
            ddlVoltageLevel.DataValueField = "VoltageID";
            ddlVoltageLevel.DataBind();
            ddlVoltageLevel.Items.Insert(0, new ListItem("Select", "0"));
            dsVoltage.Clear();

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

        private void ddlLoadBindDistrictddl()
        {
            try
            {
                string state = "Haryana";
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDrawDistrict(state);
                ddlDistrict1.DataSource = dsDistrict;
                ddlDistrict1.DataTextField = "District";
                ddlDistrict1.DataValueField = "District";
                ddlDistrict1.DataBind();
                ddlDistrict1.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlLoadBindDistrict(ddlState.SelectedItem.ToString());

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
                //msg.Text = ex.Message;
            }
        }

        public void update()
        {
            REID = hdnId.Value;
            DataSet ds = new DataSet();
            ds = CEI.GetContractorData(REID);
            string dp_Id = ds.Tables[0].Rows[0]["Name"].ToString();
            string dp_Id1 = ds.Tables[0].Rows[0]["FatherName"].ToString();
            string dp_Id2 = ds.Tables[0].Rows[0]["FirmName"].ToString();
            string dp_Id3 = ds.Tables[0].Rows[0]["GSTNumber"].ToString();
            string dp_Id18 = ds.Tables[0].Rows[0]["RegisteredOffice"].ToString();
            string dp_Id19 = ds.Tables[0].Rows[0]["BranchOffice"].ToString();
            string dp_Id4 = ds.Tables[0].Rows[0]["State"].ToString();
            string dp_Id5 = ds.Tables[0].Rows[0]["Districtoffirm"].ToString();
            string dp_Id6 = ds.Tables[0].Rows[0]["PinCode"].ToString();
            string dp_Id7 = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            string dp_Id8 = ds.Tables[0].Rows[0]["Email"].ToString();
            string dp_Id9 = ds.Tables[0].Rows[0]["IntialIssueDate"].ToString();
            string dp_Id10 = ds.Tables[0].Rows[0]["RenewalDate"].ToString();
            string dp_Id11 = ds.Tables[0].Rows[0]["ExpiryDate"].ToString();
            string dp_Id12 = ds.Tables[0].Rows[0]["votagelevel"].ToString();
            string dp_Id13 = ds.Tables[0].Rows[0]["voltageWithEffect"].ToString();
            string dp_Id14 = ds.Tables[0].Rows[0]["LicenceOld"].ToString();
            string dp_Id15 = ds.Tables[0].Rows[0]["LicenceNew"].ToString();
            string dp_Id16 = ds.Tables[0].Rows[0]["BranchDistrictoffirm"].ToString();
            string dp_Id17 = ds.Tables[0].Rows[0]["BranchPinCode"].ToString();

            txtName.Text = dp_Id;
            txtFatherName.Text = dp_Id1;
            txtRegisteredOffice.Text = dp_Id18;
            txtBranchOffice.Text = dp_Id19;
            txtFirmName.Text = dp_Id2;
            txtGST.Text = dp_Id3;
            ddlLoadBindState();
            ddlLoadBindDistrictddl();
            ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByText(dp_Id4));
            ddlLoadBindDistrict(dp_Id4);
            ddlDistrict.SelectedValue = dp_Id5;
            ddlDistrict1.SelectedIndex = ddlDistrict1.Items.IndexOf(ddlDistrict1.Items.FindByValue(dp_Id16));
            txtPinCode.Text = dp_Id6;
            txtPinCode1.Text = dp_Id17;
            txtContactNo.Text = dp_Id7;
            txtEmail.Text = dp_Id8;
            txtDateofIntialissue.Text = DateTime.Parse(dp_Id9).ToString("yyyy-MM-dd");
            txtDateofRenewal.Text = DateTime.Parse(dp_Id10).ToString("yyyy-MM-dd");
            //txtDateofRenewal.Text = Convert.ToDateTime(dp_Id10).ToString("yyyy-MM-dd");
            txtDateofExpiry.Text = DateTime.Parse(dp_Id11).ToString("yyyy-MM-dd");
            ddlVoltageLevel.SelectedValue = dp_Id12;
            txtVoltageLevelWithEffect.Text = DateTime.Parse(dp_Id13).ToString("yyyy-MM-dd");
            txtLicenceOld.Text = dp_Id14;
            txtLicenceNew.Text = dp_Id15;
            if (ddlDistrict.SelectedValue == ddlDistrict1.SelectedValue &&
                txtRegisteredOffice.Text == txtBranchOffice.Text)
            {
                CheckBox1.Checked = true;
                txtBranchOffice.Text = txtRegisteredOffice.Text;
                ddlDistrict1.SelectedValue = ddlDistrict.SelectedValue;
                txtPinCode1.Text = txtPinCode.Text;
                txtBranchOffice.Enabled = false;
                txtBranchOffice.Style.Add("width", "inherit");
                txtBranchOffice.Style.Add("height", "30px");
                txtBranchOffice.Style.Add("border-radius", ".25rem");


                ddlDistrict1.Enabled = false;
                ddlDistrict1.Style.Add("width", "inherit");
                ddlDistrict1.Style.Add("height", "30px");
                ddlDistrict1.Style.Add("border-radius", ".25rem");

                txtPinCode1.Enabled = false;
                txtPinCode1.Style.Add("width", "inherit");
                txtPinCode1.Style.Add("height", "30px");
                txtPinCode1.Style.Add("border-radius", ".25rem");

                txtRegisteredOffice.Enabled = false;
                txtRegisteredOffice.Style.Add("width", "inherit");
                txtRegisteredOffice.Style.Add("height", "30px");
                txtRegisteredOffice.Style.Add("border-radius", ".25rem");

                ddlState.Enabled = false;
                ddlState.Style.Add("width", "inherit");
                ddlState.Style.Add("height", "30px");
                ddlState.Style.Add("border-radius", ".25rem");

                ddlDistrict.Enabled = false;
                ddlDistrict.Style.Add("width", "inherit");
                ddlDistrict.Style.Add("height", "30px");
                ddlDistrict.Style.Add("border-radius", ".25rem");

                txtPinCode.Enabled = false;
                txtPinCode.Style.Add("width", "inherit");
                txtPinCode.Style.Add("height", "30px");
                txtPinCode.Style.Add("border-radius", ".25rem");

            }
            else
            {
                CheckBox1.Checked = false;
            }
            ds.Clear();


        }
        #region GetIP
        protected void GetIP()
        {

            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion
        public void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Update")
                {
                    if (txtLicenceNew.Text != "" || txtLicenceNew.Text != "NA")
                    {
                        UserId = txtLicenceNew.Text;
                    }
                    else
                    {
                        UserId = txtLicenceOld.Text;
                    }
                    REID = hdnId.Value;
                    Createdby = Session["AdminID"].ToString();
                    if (Createdby == null || Createdby == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                    }
                    else
                    {
                        GetIP();
                        CEI.InsertContractorData(REID, UserId, txtName.Text.ToUpper(), txtFatherName.Text.ToUpper(), txtFirmName.Text, txtGST.Text, txtRegisteredOffice.Text,
                        ddlState.SelectedItem.ToString(), ddlDistrict.SelectedItem.ToString(), txtPinCode.Text, txtBranchOffice.Text, txtState1.Text,
                        ddlDistrict1.SelectedItem.ToString(), txtPinCode1.Text, txtContactNo.Text, txtEmail.Text,
                        txtDateofIntialissue.Text, txtDateofRenewal.Text, txtDateofExpiry.Text, ddlVoltageLevel.SelectedValue, txtVoltageLevelWithEffect.Text,
                        txtLicenceOld.Text, txtLicenceNew.Text, Createdby, ipaddress);
                        Session["ID"] = "";
                        Reset();
                        regexValidatorGST.Visible = false;
                        RequiredFieldValidator3.Visible = false;
                        DataUpdated.Visible = true;
                        //  Response.Redirect("AddContractorDetails.aspx");
                    }
                }
                else
                {
                    DataSet ds = new DataSet();
                    ds = CEI.checkGSTexist(txtGST.Text);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string alertScript = "alert('The  GST number is already in use. Please provide a different GST number.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);

                    }
                    else
                    {
                        if (txtLicenceNew.Text != "" || txtLicenceNew.Text != "NA")
                        {
                            UserId = txtLicenceNew.Text;
                        }
                        else
                        {
                            UserId = txtLicenceOld.Text;
                        }

                        DataSet ds1 = new DataSet();
                        ds1 = CEI.checkLicenceexist(txtLicenceNew.Text, txtLicenceOld.Text);
                        if (ds1.Tables[0].Rows.Count > 0 )
                        {
                            string alertScript = "alert('The  licence number is already in use. Please provide a different licence number.');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);


                        }
                        else
                        {
                            REID = hdnId.Value;
                            Createdby = Session["AdminID"].ToString();
                            if (Createdby == null || Createdby == "")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);
                            }
                            else
                            {
                                GetIP();
                                CEI.InsertContractorData(REID, UserId, txtName.Text.ToUpper(), txtFatherName.Text.ToUpper(), txtFirmName.Text, txtGST.Text, txtRegisteredOffice.Text,
                                ddlState.SelectedItem.ToString(), ddlDistrict.SelectedItem.ToString(), txtPinCode.Text, txtBranchOffice.Text, txtState1.Text,
                               ddlDistrict1.SelectedItem.ToString(), txtPinCode1.Text, txtContactNo.Text, txtEmail.Text, txtDateofIntialissue.Text,
                               txtDateofRenewal.Text, txtDateofExpiry.Text, ddlVoltageLevel.SelectedValue, txtVoltageLevelWithEffect.Text,
                               txtLicenceOld.Text, txtLicenceNew.Text, ipaddress, Createdby);
                                Reset();
                                //DataSaved.Visible = true;
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);

                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {

                if (Ex.Message.StartsWith("Violation of UNIQUE KEY constraint"))
                {
                    string alertScript = "alert('Error: License Number Incorrect\\n\\nThe provided license number is already in use. Please provide a different license number.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                }
                else if (Ex.Message.StartsWith("The INSERT statement conflicted"))
                {
                    string sanitizedErrorMessage = Ex.Message.Replace("'", "\\'");
                    string alertScript = "alert('Error: License Number Incorrect\\n\\nLicense number old and new are the same. Please provide a different license number.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", alertScript, true);
                }


            }

        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            txtName.Text = string.Empty;
            txtRegisteredOffice.Text = string.Empty;
            txtGST.Text = "";
            txtFatherName.Text = "";
            txtFirmName.Text = "";
            txtPinCode1.Text = "";
            CheckBox1.Checked = false;
            txtBranchOffice.Text = "";
            ddlState.SelectedIndex = 0;
            ddlDistrict.SelectedIndex = 0;
            ddlDistrict1.SelectedIndex = 0;
            txtPinCode.Text = "";
            txtContactNo.Text = "";
            txtEmail.Text = "";
            txtDateofIntialissue.Text = "";
            txtDateofRenewal.Text = "";
            txtDateofExpiry.Text = "";
            ddlVoltageLevel.SelectedIndex = 0;
            txtVoltageLevelWithEffect.Text = "";
            txtLicenceOld.Text = "";
            txtLicenceNew.Text = "";

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (CheckBox1.Checked == true)
            {
                if (txtRegisteredOffice.Text != "" && ddlDistrict.SelectedValue != "" && ddlDistrict.SelectedValue != "0")
                {
                    if (ddlState.SelectedValue == "11")
                    {

                        txtBranchOffice.Text = txtRegisteredOffice.Text;
                        ddlDistrict1.SelectedValue = ddlDistrict.SelectedValue;
                        txtPinCode1.Text = txtPinCode.Text;
                        txtBranchOffice.Enabled = false;
                        txtBranchOffice.Style.Add("width", "inherit");
                        txtBranchOffice.Style.Add("height", "30px");
                        txtBranchOffice.Style.Add("border-radius", ".25rem");


                        ddlDistrict1.Enabled = false;
                        ddlDistrict1.Style.Add("width", "inherit");
                        ddlDistrict1.Style.Add("height", "30px");
                        ddlDistrict1.Style.Add("border-radius", ".25rem");

                        txtPinCode1.Enabled = false;
                        txtPinCode1.Style.Add("width", "inherit");
                        txtPinCode1.Style.Add("height", "30px");
                        txtPinCode1.Style.Add("border-radius", ".25rem");

                        txtRegisteredOffice.Enabled = false;
                        txtRegisteredOffice.Style.Add("width", "inherit");
                        txtRegisteredOffice.Style.Add("height", "30px");
                        txtRegisteredOffice.Style.Add("border-radius", ".25rem");

                        ddlState.Enabled = false;
                        ddlState.Style.Add("width", "inherit");
                        ddlState.Style.Add("height", "30px");
                        ddlState.Style.Add("border-radius", ".25rem");

                        ddlDistrict.Enabled = false;
                        ddlDistrict.Style.Add("width", "inherit");
                        ddlDistrict.Style.Add("height", "30px")
                            ;
                        ddlDistrict.Style.Add("border-radius", ".25rem");

                        txtPinCode.Enabled = false;
                        txtPinCode.Style.Add("width", "inherit");
                        txtPinCode.Style.Add("height", "30px");
                        txtPinCode.Style.Add("border-radius", ".25rem");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Your Registered Office Address is not Haryana !!!')", true);
                        ddlState.Focus();
                        CheckBox1.Checked = false;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Please Select Registered Office Address First!!!')", true);
                    ddlDistrict.Focus();
                    CheckBox1.Checked = false;
                }

            }
            else
            {

                txtBranchOffice.Enabled = true;
                ddlDistrict1.Enabled = true;
                txtPinCode1.Enabled = true;
                txtRegisteredOffice.Enabled = true;
                ddlState.Enabled = true;
                ddlDistrict.Enabled = true;
                txtPinCode.Enabled = true;
                txtBranchOffice.Text = "";
                ddlDistrict1.SelectedValue = "0";
                txtPinCode1.Text = "";
                txtRegisteredOffice.Text = "";
                ddlState.SelectedValue = "0";
                ddlDistrict.SelectedValue = "0";
                txtPinCode.Text = "";
            }
        }


    }
}
