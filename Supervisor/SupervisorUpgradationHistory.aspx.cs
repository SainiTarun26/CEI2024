using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class SupervisorUpgradationHistory : System.Web.UI.Page
    {
        //page created by Neha
        CEI CEI = new CEI();
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
                        loginTypeLabel.Text = "Supervisor / Upgradation Licence Application History";
                    }
                    if (Convert.ToString(Session["SupervisorID"]) != null && Convert.ToString(Session["SupervisorID"]) != "")
                    {
                        string Id = Session["SupervisorID"].ToString();
                        GridToBindData(Id);
                    }
                    else
                    {
                        Response.Redirect("/SupervisorLogout.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/SupervisorLogout.aspx");
            }
        }

        private void GridToBindData(string Id)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetDataOfUpgradationRequestForSupervisor(Id);
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
    }
}