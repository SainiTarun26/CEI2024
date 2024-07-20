using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.UserPages
{
    public partial class SiteOwnerRegistration : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ApplicantType, ApplicantCode, PanTanNumber, ElectricalInstallationFor, NameOfOwner, NameofAgency, Address,
            District, PinCode, PhoneNumber, Email;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlLoadBindDistrict("Haryana");
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

        protected void ddlApplicantType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblPanNumber.Visible = false;
            LblTanNumber.Visible = false;
            txtPANTan.Visible = false;
            if (ddlApplicantType.SelectedValue == "AT001")
            {
                LblPanNumber.Visible = true;
                txtPANTan.Visible = true;
                txtPANTan.Text = "";
            }
            //else if (ddlApplicantType.SelectedValue == "AT002")
            //{
            //    NameUtility.Visible = true;
            //    Wing.Visible = true;
            //    PowerUtility.Visible = true;
            //    //ElectricalInstallation.Visible= false;
            //    ddlPoweUtilityBind();
            //    //DivPoweUtilityWing.Visible = true;
            //    txtTanNumber.Text = "";
            //    txtPAN.Text = "";
            //}
            else if (ddlApplicantType.SelectedValue == "AT003")
            {
                LblTanNumber.Visible = true;
                txtPANTan.Visible = true;
                txtPANTan.Text = "";
            }
        }

        protected void ddlworktype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblNameofOwner.Visible = false;
            LblAgency.Visible = false;

            if (ddlworktype.SelectedValue == "1")
            {
                LblNameofOwner.Visible = true;
            }
            else if (ddlworktype.SelectedValue == "2")
            {
                LblAgency.Visible = true;
            }
            else
            {
                LblNameofOwner.Visible = true;
            }
        }

        protected void txtPANTan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Regex regex;
                string TANNumber = txtPANTan.Text.Trim();
                if (LblPanNumber.Visible == true)
                {
                    regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}");
                }
                else
                {
                    regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}");
                }

                if (!regex.IsMatch(TANNumber))
                {
                    if (LblPanNumber.Visible == true)
                    {
                        LblPanNumber.Visible = true;
                        LblTanNumber.Visible = false;
                    }
                    else
                    {
                        LblPanNumber.Visible = false;
                        LblTanNumber.Visible = true;
                    }
                    txtPANTan.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid Pan/Tan Number format. Please enter a valid TAN number.');", true);
                    txtPANTan.Text = "";
                    return;
                }
                DataSet ds = new DataSet();
                ds = CEI.GetDetailsByPanNumberId(TANNumber);
                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid Pan/Tan Number already exist');", true);
                    txtPANTan.Text = "";
                    return;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or provide a more detailed error message
                Page.ClientScript.RegisterStartupScript(GetType(), "error", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                PanTanNumber = txtPANTan.Text.Trim();
                DataTable dt = CEI.CheckSiteownerPan(PanTanNumber);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid Pan/Tan Number already exist');", true);
                    txtPANTan.Text = "";
                    txtPANTan.Focus();
                    return;
                }
                ApplicantType = ddlApplicantType.SelectedItem.ToString();
                ApplicantCode = ddlApplicantType.SelectedValue;
                ElectricalInstallationFor = ddlworktype.SelectedItem.ToString();
                if (LblNameofOwner.Visible == true)
                {
                    NameOfOwner = txtName.Text;
                }
                else if (LblAgency.Visible == true)
                {
                    NameofAgency = txtName.Text;
                }
                Address = txtAddress.Text.Trim();
                District = ddlDistrict.SelectedItem.ToString();
                PinCode = txtPin.Text;
                PhoneNumber = txtPhone.Text;
                Email = txtEmail.Text;
                CEI.InsertSiteOwnerRegistration(ApplicantType, ApplicantCode, PanTanNumber, ElectricalInstallationFor, NameOfOwner, NameofAgency
                    ,Address, District, PinCode, PhoneNumber, Email);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                //throw;
            }

        }
    }
}