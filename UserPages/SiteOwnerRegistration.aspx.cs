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
                if (LblPanNumber.Visible=true)
                {
                     regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}"); ;
                }
                else 
                {                
                     regex = new System.Text.RegularExpressions.Regex("[A-Za-z]{4}[0-9]{5}[A-Za-z]{1}");
                }

                if (!regex.IsMatch(TANNumber))
                {
                    txtPANTan.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Invalid TAN Number format. Please enter a valid TAN number.');", true);
                    txtPANTan.Text = "";
                    return;
                }
                DataSet ds = new DataSet();
                ds = CEI.GetDetailsByPanNumberId(TANNumber);
                if (ds.Tables[0].Rows.Count > 0)
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
    }
}