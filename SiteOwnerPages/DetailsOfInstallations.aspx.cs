using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using CEI_PRoject;
using CEIHaryana.Contractor;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class DetailsOfInstallations : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static string Id, ApplicantType, ApplicantCode, Password, EInstallationType;
        string SiteOwnerID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    {
                        GetDetails();
                        BindDistrict();
                        ddlLoadBindPremises();
                        ddlLoadBindVoltage();
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void BindDistrict()
        {
            try
            {
                DataSet dsDistrict = new DataSet();
                dsDistrict = CEI.GetddlDistrict();
                ddlDistrict.DataSource = dsDistrict;
                ddlDistrict.DataTextField = "AreaCovered";
                ddlDistrict.DataValueField = "Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
                dsDistrict.Clear();
            }
            catch (Exception ex) { }
        }

        protected void ddlPremises_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPremises.SelectedValue == "11")
                {
                    OtherPremises.Visible = true;
                }
                else
                {
                    OtherPremises.Visible = false;
                }
            }
            catch (Exception ex) { }
        }

        private void ddlLoadBindPremises()
        {
            try
            {
                DataSet dsPremises = new DataSet();
                dsPremises = CEI.GetddlPremises();
                ddlPremises.DataSource = dsPremises;
                ddlPremises.DataTextField = "Premises";
                ddlPremises.DataValueField = "ID";
                ddlPremises.DataBind();
                ddlPremises.Items.Insert(0, new ListItem("Select", "0"));
                dsPremises.Clear();
            }
            catch (Exception ex) { }
        }

        protected void ddlVoltageLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                installationType2.Visible = true;
                if (ddlVoltageLevel.SelectedValue == "650V")
                {
                    installationType2.Visible = false;
                }
                else
                {
                    installationType2.Visible = true;
                }
            }
            catch (Exception ex) { }
        }

        private void ddlLoadBindVoltage()
        {
            try
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
            catch (Exception ex) { }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList2.SelectedValue == "1")
                {
                    divSanctionLoad.Visible = true;
                }
                else
                {
                    divSanctionLoad.Visible = false;
                }
            }
            catch (Exception ex) { }
        }

        private void GetDetails()
        {
            Id = Session["SiteOwnerId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.GetWorkIntimationDataAtSiteOwner(Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                ApplicantType = txtApplicantType.Text;
                ApplicantCode = ds.Tables[0].Rows[0]["ApplicantTypeCode"].ToString();
                txtPAN.Text = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                txtElecticalInstallation.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                EInstallationType = txtElecticalInstallation.Text;

                if (EInstallationType == "Individual Person")
                {
                    individual.Visible = true;
                }
                else if (EInstallationType == "Firm/Organization/Company/Department")
                {
                    agency.Visible = true;
                }

                txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                if (ApplicantType == "Private/Personal Installation")
                {
                    PowerUtility.Visible = false;
                    UserId.Visible = false;
                    string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                    DivPancard_TanNo.Visible = true;
                    txtPAN.Text = PanTanNumber;
                }
                else if (ApplicantType == "Other Department/Organization")
                {
                    string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                    DivOtherDepartment.Visible = true;
                    txtTanNumber.Text = PanTanNumber;
                    PowerUtility.Visible = false;
                    UserId.Visible = false;
                }
                else if (ApplicantType == "Power Utility")
                {
                    string PanTanNumber = ds.Tables[0].Rows[0]["PANNumber"].ToString();
                    txtUserId.Text = PanTanNumber;
                    UserId.Visible = true;
                    NameUtility.Visible = true;
                    Wing.Visible = true;
                    PowerUtility.Visible = true;
                }
                txtUtilityName.Text = ds.Tables[0].Rows[0]["PowerUtility"].ToString();
                txtWing.Text = ds.Tables[0].Rows[0]["PowerUtilityWing"].ToString();
                txtZone.Text = ds.Tables[0].Rows[0]["ZoneName"].ToString();
                txtCircle.Text = ds.Tables[0].Rows[0]["CircleName"].ToString();
                txtDivision.Text = ds.Tables[0].Rows[0]["DivisionName"].ToString();
                txtSubDivision.Text = ds.Tables[0].Rows[0]["SubDivisionName"].ToString();
                Password = ds.Tables[0].Rows[0]["SiteOwnerPassword"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string Pan_TanNumber = "";

                if (DivPancard_TanNo.Visible && !string.IsNullOrEmpty(txtPAN.Text.Trim()))
                {
                    Pan_TanNumber = txtPAN.Text.Trim();
                }
                else if (DivOtherDepartment.Visible && !string.IsNullOrEmpty(txtTanNumber.Text.Trim()))
                {
                    Pan_TanNumber = txtTanNumber.Text.Trim();
                }
                else if (PowerUtility.Visible)
                {
                    if (string.IsNullOrEmpty(txtUserId.Text.Trim()))
                    {
                        string email = txtEmail.Text.Trim();
                        if (email.Contains("@"))
                        {
                            Pan_TanNumber = email.Split('@')[0];
                        }
                    }
                    else
                    {
                        Pan_TanNumber = txtUserId.Text.Trim();
                    }
                }


                if (string.IsNullOrEmpty(Pan_TanNumber))
                {
                    throw new Exception("Pan/Tan Number cannot be empty.");
                }
                CEI.IntimationDataInsertionBySiteowner(
                       Id,
                       txtApplicantType.Text.Trim(), ApplicantCode, txtElecticalInstallation.Text.Trim(), txtUtilityName.Text.Trim(), txtWing.Text.Trim(),
                       txtZone.Text.Trim(), txtCircle.Text.Trim(), txtDivision.Text.Trim(), txtSubDivision.Text.Trim(), txtName.Text.Trim(), txtagency.Text.Trim(),
                       txtPhone.Text.Trim(), txtAddress.Text.Trim(), ddlDistrict.SelectedItem?.ToString(), txtPin.Text.Trim(), ddlPremises.SelectedItem?.ToString(),
                       txtOtherPremises.Text.Trim(), ddlVoltageLevel.SelectedItem?.ToString(), Pan_TanNumber,
                       txtinstallationType2.Text.Trim(), txtinstallationNo2.Text.Trim(), txtinstallationType3.Text.Trim(), txtinstallationNo3.Text.Trim(),

                       txtEmail.Text.Trim(), Id,
                       RadioButtonList2.SelectedValue.ToString(), "Periodic", txtCapacity.Text.Trim(), txtSanctionLoad.Text.Trim(), Password
                       );
            }
            catch (Exception ex) { }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RadioButtonList1.SelectedValue == "1")
                {
                    DivDetails.Visible = true;
                    btnReset.Visible = true;
                    btnSubmit.Visible = true;
                }
                else
                {
                    DivDetails.Visible = false;
                    btnReset.Visible = false;
                    btnSubmit.Visible = false;
                }
            }
            catch (Exception ex) { }
        }
    }
}