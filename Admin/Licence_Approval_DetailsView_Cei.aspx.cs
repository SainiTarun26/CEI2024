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

namespace CEIHaryana.Admin
{
    public partial class Licence_Approval_DetailsView_Cei : System.Web.UI.Page
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

                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty && Convert.ToString(Session["Application_Id"]) != null && Convert.ToString(Session["Application_Id"]) != string.Empty)
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
                        Session["AdminId"] = null;
                        Response.Redirect("/AdminLogout.aspx", false);
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
            DataSet ds = CEI.Licence_Cei_Approval_GetHeaderDetails(licApplicationId);
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPageUrl"] != null)
            {
                Response.Redirect(ViewState["PreviousPageUrl"].ToString(), false);
            }
        }

        protected void lnkFile_Click(object sender, EventArgs e)
        {
            Session["Application_Id"] = txtApplicationId.Text.Trim();

            
            string category = txtLicenceType.Text.Trim();
            string url = "";

            if (category.Equals("Wireman", StringComparison.OrdinalIgnoreCase))
            {
                url = "/Print_Forms/Certificate_of_wireman_Permit.aspx";
            }
            else if (category.Equals("Supervisor", StringComparison.OrdinalIgnoreCase))
            {
                url = "/Admin/Pending_Licence_Approval_Cei_List.aspx"; 
            }
            else if (category.Equals("Contractor", StringComparison.OrdinalIgnoreCase))
            {
                url = "/Print_Forms/Contractor_Licence_New_Certificate.aspx";
            }

            string script = $"window.open('{url}', '_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenDoc", script, true);

        }

    }
}