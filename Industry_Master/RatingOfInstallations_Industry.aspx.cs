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

namespace CEIHaryana.Industry_Master
{
    public partial class RatingOfInstallations_Industry : System.Web.UI.Page
    {
        CEI cei = new CEI();
        string REID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    var master = (MasterPage)Master;
                    var loginTypeLabel = (Label)master.FindControl("LoginType");
                    if (loginTypeLabel != null)
                    {
                        loginTypeLabel.Text = "SiteOwner / Create new test Report";
                    }
                    if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                    {

                        if (CheckInspectionStatus())
                        {
                            Response.Redirect("InspectionHistory_Industry.aspx", false);
                            return;
                        }
                        getWorkIntimationData();
                    }
                    else
                    {
                       
                    }
                }
            }
            catch(Exception ex)
            {
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }

        }
        private void getWorkIntimationData()
        {
            DataTable ds = new DataTable();
            string Id = Session["SiteOwnerId_Industry"].ToString();
            ds = cei.WorkIntimationDataforSiteOwner(Id);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["intimationid_Industry"] = lblID.Text;

                Label lblStartdateasinWI = (Label)row.FindControl("lblStartdateasinWI");
                Response.Redirect("/Industry_Master/TestReport_Industries.aspx");

            }
            else
            {
                getWorkIntimationData();

            }
        }

        private bool CheckInspectionStatus()
        {
            string panNumber = null;
            string Districtlocalpr = null;
            //added on 24 feb 2025 to filter district records against a panno

            if (Session["SiteOwnerId_Industry"] != null)
            {
                panNumber = Session["SiteOwnerId_Industry"].ToString();
            }
            if (Session["district_Temp"] != null)
            {
                Districtlocalpr = Session["district_Temp"].ToString();
            }

            string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckAlreadyApplied_PeriodicInspection_Industries", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PANNumber", panNumber);
                    cmd.Parameters.AddWithValue("@District", Districtlocalpr);
                    //added on 24 feb 2025 to filter district records against a panno

                    conn.Open();

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result == 1;
                }
            }
        }
    }
}