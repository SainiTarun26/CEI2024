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
    public partial class InProcessRequest : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string LoginId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                {
                    GridBind();
                }
                else
                {

                }
            }
        }
        public void GridBind()
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                LoginId = Convert.ToString(Session["AdminId"]);
                DataSet ds = new DataSet();
                ds = CEI.InProcessRequestInspectionForAdmin(LoginId);
                if (ds.Tables.Count > 0)
                {
                    DataTable ftrtbs = CEI.Grddtl(searchText, ds, "Dt");
                    if (ftrtbs.Rows.Count > 0)
                    {
                        GridView1.DataSource = ftrtbs;
                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        string script = "alert(\"No Record Found\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
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
            catch (Exception ex)
            {

                //throw;
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                string id = lblID.Text;
                Session["InspectionId"] = id;
                if (e.CommandName == "Select")
                {
                    Response.Redirect("/Admin/InspectionDetails.aspx", false);
                }
            }
        }       

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridBind();
            }
            catch { }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            GridBind();
        }
    }
}