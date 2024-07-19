using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    }
}