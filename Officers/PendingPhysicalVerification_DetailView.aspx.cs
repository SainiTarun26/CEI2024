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
        CEI CEI = new CEI(); string Application_Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    txtDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        BindVenue();
                        Application_Id = Session["Application_Id"].ToString();
                        GetHeaderDetailsWithId(Application_Id);
                        BindApplicationLogDetails(Application_Id);
                        //Session["Application_Id"] = "";
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
        private void BindVenue()
        {
            DataTable dt = new DataTable();
            dt = CEI.GetVenueforOfficer();
            ddlvenue.DataSource = dt;
            ddlvenue.DataTextField = "Venue";
            ddlvenue.DataValueField = "Venue";
            ddlvenue.DataBind();
            ddlvenue.Items.Insert(0, new ListItem("Select", "0"));
            dt.Clear();
        }
        private void GetHeaderDetailsWithId(string licApplication_Id)
        {
            DataSet ds = CEI.Licence_XenfinalRecommend_GetHeaderDetails(licApplication_Id);
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

        private void BindApplicationLogDetails(string licApplication_Id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Get_Licence_ApplicationLogDetails(licApplication_Id);

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
                    CEI.UpdateXenVerificationstatus(txtApplicationId.Text, StaffID, ddlcorrection.SelectedItem.Text, RadioButtonList1.SelectedValue, txtRemarks.Text, txtCorrectionRemarks.Text, txtDate.Text, txtTime.Text, ddlvenue.SelectedValue, "Ready For Issue Letter");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                }
                else
                {

                    CEI.UpdateXenVerificationstatus(txtApplicationId.Text, StaffID, ddlcorrection.SelectedItem.Text, RadioButtonList1.SelectedValue.ToString(), txtRemarks.Text, txtCorrectionRemarks.Text,null,null,null, "Verified");
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
                AcceptedLabel.Visible= false;
                NeedCorrection.Visible= false;
                VerificationDate.Visible= false;
                Div1.Visible= false;
                Div2.Visible= false;
            }
            else
            {

                RejectionRemarks.Visible = false;
                AcceptedLabel.Visible = true;
                NeedCorrection.Visible = true;
                VerificationDate.Visible = true;
                Div1.Visible = true;
                Div2.Visible = true;
            }
        }
    }
}