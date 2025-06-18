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
    public partial class Pending_Final_Recommendations_List : System.Web.UI.Page
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
                    if (Convert.ToString(Session["StaffID"]) != null || Convert.ToString(Session["StaffID"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/OfficerLogout.aspx");
            }
        }
        public void GridBind()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.Licence_Xen_Pending_FinalRecommendationList();

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
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblApplicationId = (Label)row.FindControl("lblApplicationId");
                Session["Application_Id"] = lblApplicationId.Text.ToString();
                Response.Redirect("Pending_Final_Recommendations.aspx", false);
                return;
            }
            else
            {

            }
        }
    }
}