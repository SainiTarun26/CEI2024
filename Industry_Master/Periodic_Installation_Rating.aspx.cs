using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class Periodic_Installation_Rating : System.Web.UI.Page
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
                       
                        getWorkIntimationData();
                    }
                    else
                    {
                       
                    }
                }
            }
            catch (Exception ex)
            {
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }

        }
        private void getWorkIntimationData()
        {
            DataTable ds = new DataTable();
            string Id = Session["SiteOwnerId_Industry"].ToString();
            ds = cei.WorkIntimationDataforSiteOwner_Industries(Id);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                getWorkIntimationData();
            }
            else
            {
                getWorkIntimationData();
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            getWorkIntimationData();
        }
    }
}