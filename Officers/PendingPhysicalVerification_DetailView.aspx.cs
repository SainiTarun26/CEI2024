using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class PendingPhysicalVerification_DetailView : System.Web.UI.Page
    {
        //Page created by navneet 18-June-2025
        CEI CEI = new CEI(); string ApplicationId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    txtDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        ApplicationId = Session["ApplicationId"].ToString();
                        GetHeaderDetailsWithId(ApplicationId);
                        BindApplicationLogDetails(ApplicationId);
                        //Session["ApplicationId"] = "";
                    }
                    else
                    {
                        Session["StaffID"] = "";
                        Response.Redirect("/OfficerLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }
        private void GetHeaderDetailsWithId(string licApplicationId)
        {
            DataSet ds = CEI.Licence_XenfinalRecommend_GetHeaderDetails(licApplicationId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
               txtLicenceType.Text = row["Categary"].ToString();
                txtApplicationId.Text = row["ApplicationId"].ToString();
                txtCommiteeId.Text = row["CommitteeId"].ToString();
                txtApplicantName.Text = row["Name"].ToString();
                txtRegistrationId.Text = row["RegistrationId"].ToString();
            }
        }

        private void BindApplicationLogDetails(string licApplicationId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Get_Licence_ApplicationLogDetails(licApplicationId);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    string script = "alert(\"No record found for this application.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", script, true);
                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
            string StaffID = Session["StaffID"].ToString();
                if (RadioButtonList1.SelectedValue== "Accept") {
                    CEI.UpdateXenVerificationstatus(txtApplicationId.Text, StaffID, ddlcorrection.SelectedItem.Text, RadioButtonList1.SelectedValue, txtRemarks.Text, txtCorrectionRemarks.Text, txtDate.Text, "Ready For Issue Letter");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                }
                else
                {

                    CEI.UpdateXenVerificationstatus(txtApplicationId.Text, StaffID, ddlcorrection.SelectedItem.Text, RadioButtonList1.SelectedItem.Text, txtRemarks.Text, txtCorrectionRemarks.Text, txtDate.Text, "Verified");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata2();", true);
                }
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }
        }

        protected void ddlcorrection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcorrection.SelectedValue=="1")
            {
                Correction.Visible= true;
            }
            else
            {

                Correction.Visible = false;
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.Trim()== "Reject")
            {
                RejectionRemarks.Visible= true;
            }
            else
            {

                RejectionRemarks.Visible = false;
            }
        }
    }
}