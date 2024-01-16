using CEI_PRoject;
using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace CEIHaryana.UserPages
{
    public partial class ContractorApplicationForm : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //ddlLoadBindState();
                }
            }
            catch
            { }

        }

        //private void ddlLoadBindState()
        //{
        //    try
        //    {
        //        DataSet dsState = new DataSet();
        //        dsState = CEI.GetddlDrawState();
        //        ddlState.DataSource = dsState;
        //        ddlState.DataTextField = "StateName";
        //        ddlState.DataValueField = "StateID";
        //        ddlState.DataBind();
        //        ddlState.Items.Insert(0, new ListItem("Select", "0"));
        //        dsState.Clear();
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ddlLoadBindDistrict(ddlState.SelectedItem.ToString());
        //    }
        //    catch { }

        //}

        //private void ddlLoadBindDistrict(string state)
        //{
        //    try
        //    {
        //        DataSet dsDistrict = new DataSet();
        //        dsDistrict = CEI.GetddlDrawDistrict(state);
        //        ddlDistrict.DataSource = dsDistrict;
        //        ddlDistrict.DataTextField = "District";
        //        ddlDistrict.DataValueField = "District";
        //        ddlDistrict.DataBind();
        //        ddlDistrict.Items.Insert(0, new ListItem("Select", "0"));
        //        dsDistrict.Clear();
        //    }
        //    catch (Exception)
        //    {
        //        //msg.Text = ex.Message;
        //    }
        //}

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                string Createdby = Session["ContractorID"].ToString();
                string selectedValues = Request.Form["demo-multiple-select"];
                CEI.ContractorApplicationData(txtGstNumber.Text, ddlCompanyStyle.SelectedItem.ToString(), ddlOffice.SelectedItem.ToString(),
                    DdlPartnerOrDirector.SelectedItem.ToString(), selectedValues, ddlAnnexureOrNot.SelectedItem.ToString(),
                    txtAgentName.Text, ddlUnitOrNot.SelectedItem.ToString(), ddlLicenseGranted.SelectedItem.ToString(), txtIssusuingName.Text, txtDOB.Text,
                    txtLicenseExpiry.Text, ddlEmployer1.SelectedItem.ToString(), txtLicense1.Text, txtIssueDate1.Text, txtValidity1.Text,
                    txtQualification1.Text, ddlEmployer2.SelectedItem.ToString(), txtLicense2.Text, txtIssueDate2.Text, txtValidity2.Text,
                    txtQualification2.Text, Createdby);
                //CEI.ContractorPartners()

            }
            catch { }
        }
    }
}