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

                //CEI.ContractorApplicationData(txtGstNumber.Text, ddlCompanyStyle.SelectedItem.ToString(), ddlRegisterdOffice.SelectedItem.ToString(),
                //    DdlPartnerOrDirector.SelectedItem.ToString(), ddlAuthorityType.SelectedItem.ToString(), txtFullName.Text, txtAddress.Text,
                //    ddlState.SelectedItem.ToString(), ddlDistrict.SelectedItem.ToString(), txtPin.Text, txtCompanyPenalities.Text, ddlLibraryAvailable.SelectedItem.ToString(),
                //    txtAgentName.Text, ddlFirmOrUnit.SelectedItem.ToString(), ddlLicenseGranted.SelectedItem.ToString(), txtIssuingAuthorityName.Text, txtDOB.Text,
                //    txtLicenseExpiryDate.Text, ddlTypofEmployee1.SelectedItem.ToString(), txtLicenseNumber1.Text, txtIssueDate1.Text, txtValidityDate1.Text,
                //    txtQualification1.Text, ddlTypofEmployee2.SelectedItem.ToString(), txtLicenseNumber2.Text, txtIssueDate2.Text, txtValidityDate2.Text,
                //    txtQualification2.Text, "Admin");
                //CEI.ContractorPartners()

            }
            catch { }
        }
    }
}