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
    public partial class Intimation_Cinema_HistoryGridView : System.Web.UI.Page
    {  //Page created by navneet 19-May-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
                    {
                        getWorkIntimationData();
                    }
                }
            }
            catch
            {
                Response.Redirect("~/LogOut.aspx", false);
            }
        }
        private void getWorkIntimationData()
        {
            DataTable ds = new DataTable();
            string Id = Session["SiteOwnerId"].ToString();
            ds = CEI.GetCinemaIntimationHistory(Id);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"There is no pending work intimation found.\");";
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
                Session["IntimationId"] = lblID.Text;

                Response.Redirect("/SiteOwnerPages/Intimation_Cinema_History.aspx", false);
            }
            else
            {
                getWorkIntimationData();
            }
        }
    }
}