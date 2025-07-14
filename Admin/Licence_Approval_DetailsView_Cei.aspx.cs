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
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (!IsPostBack && Request.UrlReferrer != null)
                    {
                        string referrerUrl = Request.UrlReferrer.ToString();

                        if (!referrerUrl.Contains("New_Registration_Information.aspx") && !referrerUrl.Contains("New_Registration_Information_Contractor.aspx"))
                        {
                            Session["PreviousPageUrl2"] = referrerUrl;
                        }
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
            if (Session["PreviousPageUrl2"] != null)
            {
                Response.Redirect(Session["PreviousPageUrl2"].ToString(), false);
            }
        }

        //protected void lnkFile_Click(object sender, EventArgs e)
        //{
        //    //Only redirect Changed by navneet 26-June-2025
        //    Session["NewApplicationRegistrationNo"] = txtRegistrationId.Text.Trim();


        //    string category = txtRegistrationId.Text.Trim();
        //    string url = "";


        //        url = "/UserPages/New_Registration_Information.aspx";


        //    string script = $"window.open('{url}', '_blank');";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenDoc", script, true);

        //}

        //Added on 14 july 2025 because nv code was fixed for one page .2  and in another tab
        protected void lnkFile_Click(object sender, EventArgs e)
        {

            Session["NewApplicationRegistrationNo"] = "";
            Session["NewApplication_Contractor_RegNo"] = "";
            Session["Application_Id"] = txtApplicationId.Text.ToString();
            if (txtLicenceType.Text == "Wireman" || txtLicenceType.Text == "Supervisor")
            {
                Session["NewApplicationRegistrationNo"] = txtRegistrationId.Text.Trim();
                Response.Redirect("/UserPages/New_Registration_Information.aspx", false);

                //string script = "window.open('/UserPages/New_Registration_Information.aspx', '_blank');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenDoc", script, true);
            }
            else if (txtLicenceType.Text == "Contractor")
            {
                Session["NewApplication_Contractor_RegNo"] = txtRegistrationId.Text.Trim();

                //string script = "window.open('/UserPages/New_Registration_Information_Contractor.aspx', '_blank');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenDoc", script, true);
                Response.Redirect("/UserPages/New_Registration_Information_Contractor.aspx", false);

            }
        }

    }
}