using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class UpgradationRequestHistory : System.Web.UI.Page
    {
        //page created by Neha
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    GetAllUpgradationRequestApprovedOrRejected();
                }
            }
        }

        private void GetAllUpgradationRequestApprovedOrRejected()
        {
            DataTable dt = new DataTable();
            string searchText = txtsearch.Text.Trim();
            dt = CEI.GetAllUpgradationRequestApprovedOrRejected(searchText);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"There is no application Applied for Licence Upgradation.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            dt.Dispose();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkButton = (LinkButton)e.Row.FindControl("LinkButton1");
                string applicationStatus = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus").ToString();
                if (applicationStatus == "Approved")
                {

                    linkButton.Visible = true;
                }
                else
                {

                    linkButton.Visible = false;
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                if (e.CommandName == "Print")
                {
                    Label lblID = (Label)row.FindControl("lblID");
                    Label lblType = (Label)row.FindControl("lblType");
                    Label lblApplicationID = (Label)row.FindControl("lblApplicationID");
                    Session["ApplicationId"] = lblApplicationID.Text;
                    if (lblType.Text == "Supervisor")
                    {
                        Response.Redirect("/Print_Forms/Certificate_Of_Competency_Upgradation.aspx",false);
                    }
                    else if (lblType.Text == "Contractor")
                    {
                        Response.Redirect("/Print_Forms/Contractor_Licence_Upgradation_Certificate.aspx",false);
                    }
                }        
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "aleert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GetAllUpgradationRequestApprovedOrRejected();
            }
            catch { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetAllUpgradationRequestApprovedOrRejected();

        }
    }
}