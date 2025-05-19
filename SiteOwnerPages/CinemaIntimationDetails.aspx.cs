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
    public partial class CinemaIntimationDetails : System.Web.UI.Page
    {

        //Page created by neha 19-May-2025
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        String SiteOwnerId = Convert.ToString(Session["SiteOwnerId"]);
                        getWorkIntimationData(SiteOwnerId);
                    }
                    else
                    {
                        Response.Redirect("LogOut.aspx", false);
                    }
                }
            }
            catch
            {
                Session["SiteOwnerId"] = "";
                Response.Redirect("LogOut.aspx", false);
            }
        }

        private void getWorkIntimationData(string OwnerID)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetCinemaTalkiesWorkIntimationData(OwnerID);
            if (dt != null && dt.Rows.Count > 0)
            {
                LblGridView1.Visible = false;
                GridView1.DataSource = dt;
            }
            else
            {
                LblGridView1.Visible = true;
                LblGridView1.Text = "There is no pending work intimation found.";
                GridView1.DataSource = null;
            }

            GridView1.DataBind();
            dt.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["IntimationId"] = lblID.Text;

                Response.Redirect("/SiteOwnerPages/CinemaInstallationComponentDetails.aspx", false);
            }
        }
    }
}