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
    public partial class PendingPhysicalVerification_Gridview : System.Web.UI.Page
    {
        //Page created by navneet 18-June-2025
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

                        GridBind(LoginID);
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
        public void GridBind(string LoginID)
        {

            DataTable ds = new DataTable();
            ds = CEI.GetPendingPhysicalVerification_Gridview(LoginID);
            if (ds.Rows.Count > 0 && ds != null)
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
                Label lblApplicationStatus = (Label)row.FindControl("lblApplicationStatus");
                Session["ApplicationId"] = e.CommandArgument.ToString();
                if (lblApplicationStatus.Text == "Ready For Issue Letter")
                {
                    Response.Redirect("PhysicalVerification_Letter_Request.aspx", false);
                }
                else
                {
                    Response.Redirect("PendingPhysicalVerification_DetailView.aspx", false);

                }
                
            }
            else
            {

            }
        }
    }
}