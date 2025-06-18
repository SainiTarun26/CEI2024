using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Officers
{   
    public partial class Pending_Final_Recommendations : System.Web.UI.Page
    {
        //Page Created by aslam 18-June-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (!IsPostBack && Request.UrlReferrer != null)
                    {
                        ViewState["PreviousPageUrl"] = Request.UrlReferrer.ToString();
                    }

                    if (Convert.ToString(Session["StaffID"]) != null && Convert.ToString(Session["StaffID"]) != string.Empty && Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
                    {
                        hdn_Lic_ApplicationId.Value = Session["Application_Id"].ToString();
                        Session["Application_Id"] = null;

                        string var_Lic_ApplicationId = hdn_Lic_ApplicationId.Value;

                        if (!string.IsNullOrEmpty(var_Lic_ApplicationId))
                        {
                            GetHeaderDetailsWithId(var_Lic_ApplicationId);
                            BindApplicationLogDetails(var_Lic_ApplicationId);
                        }


                    }
                    else
                    {
                        Session["StaffID"] = null;
                        Response.Redirect("/OfficerLogout.aspx", false);
                    }

                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.ToString().Replace("'", "\\'"); 
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", $"alert('An unexpected error occurred: {errorMessage}');", true);
                return;

            }

        }

        private void GetHeaderDetailsWithId(string licApplicationId)
        {
            DataSet ds =  CEI.Licence_XenfinalRecommend_GetHeaderDetails(licApplicationId);
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
            if (Session["StaffID"].ToString() != null)
            {
                try
                {
                    string applicationId = txtApplicationId.Text.Trim();
                    string remarks = TextBox1.Text.Trim();
                    string actionTaken = ddlReview.SelectedValue;

                    if (string.IsNullOrEmpty(applicationId))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Application ID is required.');", true);
                        return;
                    }
                    if (actionTaken == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please select an action.');", true);
                        return;
                    }
                    if (string.IsNullOrEmpty(remarks))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Please enter remarks.');", true);
                        return;
                    }

                    int result = CEI.Insert_Licence_XenFinalRecommendation(applicationId, remarks, actionTaken, Session["StaffID"].ToString());

                    if (result == 1)
                    {
                        string actionText = ddlReview.SelectedItem.Text;
                        string message = $"Application {actionText} successfully.";
                        ScriptManager.RegisterStartupScript(this, GetType(), "successMessage", $"alert('{message}'); window.location='Pending_Final_Recommendations_List.aspx';", true);
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", "alert('Failed to save recommendation. Please try again later.');", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "exceptionMessage", "alert('" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
            else
            {
                Session["StaffID"] = null;
                Response.Redirect("/OfficerLogout.aspx");
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPageUrl"] != null)
            {
                Response.Redirect(ViewState["PreviousPageUrl"].ToString(), false);
            }
        }

    }
}