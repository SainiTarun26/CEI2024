using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Admin
{
    public partial class Contractor_Supervisor_Upgradation_Details : System.Web.UI.Page
    {
        //page created by neha
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    GetSubmittedUpgradationApplications(null);
                }
                else
                {
                    Response.Redirect("/Logout.aspx", false);
                }
            }
        }

        private void GetSubmittedUpgradationApplications(string Value)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetSubmittedUpgradationApplications(Value);
            if (dt.Rows.Count > 0)
            {
                GridView3.DataSource = dt;
                GridView3.DataBind();
            }
            else
            {
                GridView3.DataSource = null;
                GridView3.DataBind();
                string script = "alert(\"There is no application Applied for Licence Upgradation.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            dt.Dispose();
        }

       

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserType.SelectedItem.Text == "Supervisor")
            {
                
                GetSubmittedUpgradationApplications(ddlUserType.SelectedItem.Text);

            }
            else
            {
                GetSubmittedUpgradationApplications(ddlUserType.SelectedItem.Text);
            }
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Label lblType = (Label)row.FindControl("lblType");
                Session["id"] = lblID.Text;
                if(lblType.Text== "Supervisor")
                {
                    Response.Redirect("/Admin/Supervisor_Upgradation_Details.aspx", false);
                }
                else if (lblType.Text == "Contractor")
                {
                    Response.Redirect("/Admin/Contractor_Upgradation_Details.aspx", false);
                }
            }
            else if(e.CommandName == "Print")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Label lblType = (Label)row.FindControl("lblType");
                Session["id"] = lblID.Text;
                if (lblType.Text == "Supervisor")
                {
                    Response.Redirect("/Print_Forms/Print_Supervisor_Upgradation_Details.aspx", false);
                }
                else if (lblType.Text == "Contractor")
                {
                    Response.Redirect("/Print_Forms/Print_Contractor_Upgradation_Details.aspx", false);
                }
            }
            else
            {
                GetSubmittedUpgradationApplications(null);
            }
        }
    }
}