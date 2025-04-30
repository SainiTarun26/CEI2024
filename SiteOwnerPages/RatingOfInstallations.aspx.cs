using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
  
    public partial class RatingOfInstallations : System.Web.UI.Page
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
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        getWorkIntimationData();
                    }
                    else
                    {
                        Response.Redirect("/SiteOwnerLogout.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/SiteOwnerLogout.aspx");
            }

        }
        private void getWorkIntimationData()
        {
            DataTable ds = new DataTable();
            string Id = Session["SiteOwnerId"].ToString();
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
                string script = "alert(\"Yet no work intimation is Submitted/Pending.\");";
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
                Session["intimationid"] = lblID.Text;
              
                Label lblStartdateasinWI = (Label)row.FindControl("lblStartdateasinWI");
                Response.Redirect("/SiteOwnerPages/TestReport.aspx");

            }
            else
            {
                getWorkIntimationData();

            }
        }

        
    }
}