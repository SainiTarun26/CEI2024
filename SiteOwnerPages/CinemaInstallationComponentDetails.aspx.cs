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
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        if (Convert.ToString(Session["IntimationId"]) != null && Convert.ToString(Session["IntimationId"]) != "")
                        {
                            String IntimationId = Convert.ToString(Session["IntimationId"]);
                            getWorkIntimationData(IntimationId);
                        }
                        else
                        {
                            Response.Redirect("CinemaIntimationDetails.aspx", false);
                        }
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

        private void getWorkIntimationData(string IntimationId)
        {
            DataTable dt = new DataTable();
            dt = CEI.GetCinemaInstallationDetails(IntimationId);
            if (dt != null && dt.Rows.Count > 0)
            {
                LblGridView1.Visible = false;
                GridView1.DataSource = dt;
            }
            else
            {
                LblGridView1.Visible = true;
                LblGridView1.Text = "There is no pending Installations for Test Report";
                GridView1.DataSource = null;
            }

            GridView1.DataBind();
            dt.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                    Session["id"] = lblID.Text;
                    #region Navneet 20-may-2025 added only new condition
                    if (lblInspectionType.Text.Trim() == "New")
                    {
                        Response.Redirect("TestReport_Cinema_Video_Talkies.aspx", false);

                    }
                    else
                    {
                        Response.Redirect("/SiteOwnerPages/PeriodicTestReport_Cinema_Video_Talkies.aspx", false);
                    }
                    #endregion
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('An Error occured.');", true);
            }
        }
    }
}