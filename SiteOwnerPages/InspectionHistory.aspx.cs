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
    public partial class InspectionHistory : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindGrid();
                }
            }
            catch {
            }
        }

        public void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SiteOwnerInspectionData(LoginID);
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
            Session["LineID"] = "";
            Session["SubStationID"] = "";
            Session["GeneratingSetId"] = ""; 
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            Label lblID = (Label)row.FindControl("lblID");
            Session["InspectionId"] = lblID.Text;
            Label lblApproval = (Label)row.FindControl("lblApproval");
            Session["Approval"] = lblApproval.Text.Trim();
            Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
            Label lblType = (Label)row.FindControl("lblType");
            if (lblType.Text.Trim() == "Line")
            {
                Session["LineID"] = lblTestRportId.Text.Trim();
            }
            else if (lblType.Text.Trim() == "Substation Transformer")
            {
                Session["SubStationID"] = lblTestRportId.Text.Trim();
            }
            else if (lblType.Text.Trim() == "Generating Set")
            {
                Session["GeneratingSetId"] = lblTestRportId.Text.Trim();
            }
            if (e.CommandName == "Select")
            {
                Response.Redirect("/SiteOwnerPages/Inspection.aspx");

            }
            else if (e.CommandName == "Print")
            {
                Response.Redirect("/SiteOwnerPages/InspectionRequestPrint.aspx");

            }
        }
    }
}