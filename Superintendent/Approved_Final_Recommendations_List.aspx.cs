using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Superintendent
{
    public partial class Approved_Final_Recommendations_List : System.Web.UI.Page
    {
        //Page Created by aslam 18-June-2025
        CEI CEI = new CEI();
        string LoginID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["SuperidentId"]) != null || Convert.ToString(Session["SuperidentId"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {
                        Response.Redirect("/OfficerLogout.aspx");
                        return;

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/OfficerLogout.aspx");
                return;
            }
        }
        public void GridBind()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Licence_Sup_Recommended_FinalRecommendationList();

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                }

                ds.Dispose();
            }
            catch (Exception ex)
            {
                string errorScript = "alert(\"An error occurred: " + ex.Message.Replace("'", "\\'") + "\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorMessage", errorScript, true);
            }


        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            if (e.CommandName == "Select")
            {
                Label lblApplicationId = (Label)row.FindControl("lblApplicationId");
                Session["Application_Id"] = lblApplicationId.Text.ToString();
                Response.Redirect("Sup_LicenceFinal_DetailView.aspx", false);
                return;
            }
            else if (e.CommandName == "Print")
            {

                Label lblApplicationId = (Label)row.FindControl("lblApplicationId");
                Session["Application_Id"] = lblApplicationId.Text.ToString();
                Label lblgetCategory = (Label)row.FindControl("lblgetCategory");
                Label lblLicenceType = (Label)row.FindControl("lblLicenceType");
                string category = lblgetCategory?.Text;
                if (!string.IsNullOrEmpty(lblLicenceType.Text) && lblLicenceType.Text == "New")
                {
                    switch (category)
                    {
                        case "Contractor":
                            Response.Redirect("/Print_Forms/Contractor_Licence_New_Certificate.aspx", false);
                            break;
                        case "Supervisor":
                            Response.Redirect("/Print_Forms/Certificate_of_Competency.aspx", false);
                            break;
                        case "Wireman":
                            Response.Redirect("/Print_Forms/Certificate_of_wireman_Permit.aspx", false);
                            break;
                    }
                }
                else if (!string.IsNullOrEmpty(lblLicenceType.Text) && lblLicenceType.Text == "Renewal")
                {
                    switch (category)
                    {
                        case "Contractor":
                            Response.Redirect("/Print_Forms/ContractorLicenceRenewal.aspx", false);
                            break;
                        case "Supervisor":

                            Response.Redirect("/Print_Forms/CertificateOfCompetencyRenewal.aspx", false);
                            break;
                        case "Wireman":
                            Response.Redirect("/Print_Forms/CertificateOfWiremanPermitRenewal.aspx", false);
                            break;
                    }
                }

            }
        }
    }
}