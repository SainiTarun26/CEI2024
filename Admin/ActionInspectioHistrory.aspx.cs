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
    public partial class XenInspectioHistrory : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null || Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        GridBind();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("/Login.aspx");
            }
        }
        public void GridBind()
        {
            string searchText = txtSearch.Text.Trim();
            string LoginID = string.Empty;
            LoginID = Session["AdminId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.InProcessRequest(LoginID);

            if (ds.Tables.Count > 0)
            {
                DataTable ftrtbs = CEI.Grddtl(searchText, ds, "id");
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblID = (Label)row.FindControl("lblID");
                    string id = lblID.Text;
                    Session["InProcessInspectionId"] = id;
                    if (e.CommandName == "Select")
                    {
                        Response.Redirect("/Admin/ActionInprocessInspection.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                //
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