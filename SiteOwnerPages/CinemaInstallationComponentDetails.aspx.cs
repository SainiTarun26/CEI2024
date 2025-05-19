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
    public partial class CinemaInstallationComponentDetails : System.Web.UI.Page
    {
        //Page created by neha 19-May-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            getWorkIntimationData();
        }

        private void getWorkIntimationData()
        {
            string Id = Session["id"].ToString();

            DataTable ds = new DataTable();
            ds = CEI.GetCinemaInstallationDetails(Id);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"All test reports of given installation is Generated.Please initiate with different intimation.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                {
                    if (e.CommandName == "Select")
                    {
                        Control ctrl = e.CommandSource as Control;
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                        Label lblID = (Label)row.FindControl("lblID");
                        Session["id"] = lblID.Text;

                        Response.Redirect("/SiteOwnerPages/PeriodicTestReport_Cinema_Video_Talkies.aspx", false);
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            catch (Exception)
            { }
        }
    }
}