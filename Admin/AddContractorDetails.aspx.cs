using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Messaging;
using System.Globalization;

namespace CEI_PRoject.Admin
{
    public partial class AddContractorDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        public string UserId;
        public string Qualification;
        string REID = string.Empty;
        string ipaddress;
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
                            BtnReset.Visible= false;
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
            SqlCommand cmd = new SqlCommand("sp_updateContractorData");
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", REID);
            cmd.Connection = con;
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adp.Fill(ds);
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
                if (txtPinCode.Text== txtPinCode1.Text && 
                    ddlDistrict.SelectedValue == ddlDistrict1.SelectedValue &&
                    txtRegisteredOffice.Text== txtBranchOffice.Text)
                {
                    CheckBox1.Checked = true;
                    txtBranchOffice.Attributes.Add("readonly", "false");
                    ddlDistrict1.Attributes.Add("disabled", "disabled");
                    txtPinCode1.Attributes.Add("readonly", "false");

                }
                else
                {
                    CheckBox1.Checked = false;
                }

            } 

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

                if (txtLicenceNew.Text != "")
                {
                    UserId = txtLicenceNew.Text;
                }
                else
                {
                    UserId = txtLicenceOld.Text;
                }

                REID = hdnId.Value;
               string Createdby = Convert.ToString(Session["AdminID"]);
                GetIP();
                CEI.InsertContractorData(REID, UserId,txtName.Text.ToUpper(), txtFatherName.Text.ToUpper(), txtFirmName.Text, txtGST.Text, txtRegisteredOffice.Text,
                ddlState.SelectedItem.ToString(),ddlDistrict.SelectedItem.ToString(), txtPinCode.Text, txtBranchOffice.Text, txtState1.Text,
               ddlDistrict1.SelectedItem.ToString(), txtPinCode1.Text, txtContactNo.Text, txtEmail.Text,
               txtDateofIntialissue.Text, txtDateofRenewal.Text, txtDateofExpiry.Text, ddlVoltageLevel.SelectedValue, txtVoltageLevelWithEffect.Text,
               txtLicenceOld.Text, txtLicenceNew.Text,Createdby, ipaddress);
              
                Reset();
                if (btnSubmit.Text == "Update")
                {
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Updated Successfully !!!')", true);
                    Session["ID"] = "";
                    Reset();
                    regexValidatorGST.Attributes.Add("style", "display: none;");
                    DataUpdated.Visible = true;

                }
                else
                {

                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Data Inserted Successfully !!!')", true);
                    Reset();
                    DataSaved.Visible = true;
                }
                //  Response.Redirect("AddContractorDetails.aspx");
                Reset();

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
                if (txtRegisteredOffice.Text != "" && txtPinCode.Text != "" &&
                    ddlDistrict.SelectedValue != "" && ddlDistrict.SelectedValue != "0")
                {
                    if (ddlState.SelectedValue == "11")
                    {

                        txtBranchOffice.Text = txtRegisteredOffice.Text;
                        ddlDistrict1.SelectedValue = ddlDistrict.SelectedValue;
                        txtPinCode1.Text = txtPinCode.Text;
                        txtBranchOffice.Attributes.Add("readonly", "false");
                        ddlDistrict1.Attributes.Add("disabled", "disabled");
                        txtPinCode1.Attributes.Add("readonly", "false");
                       
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

                txtBranchOffice.Attributes.Remove("readonly");
                ddlDistrict1.Attributes.Remove("disabled");
                txtPinCode1.Attributes.Remove("readonly");
                txtBranchOffice.Text = "";
                ddlDistrict1.SelectedValue = "0";
                txtPinCode1.Text = "";
            }
         }

       
    }
}
