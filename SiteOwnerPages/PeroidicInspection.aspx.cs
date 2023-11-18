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
    public partial class Peroidic_inspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        //string Type = string.Empty;
        //string Voltage = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindGrid();
                }
            }
            catch { }
        }

        public void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SiteOwnerPeroidicInspectionData(LoginID);
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
            Control ctrl = e.CommandSource as Control;
            GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
            Label lblId = (Label)row.FindControl("lblId");
            Session["InspectionId"] = lblId.Text;
            Label lblApproval = (Label)row.FindControl("lblApproval");
            Session["Approval"] = lblApproval.Text.Trim();
            Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
            Label lblType = (Label)row.FindControl("lblType");
            Session["PeriodicInspection"] = "true";
            if (lblType.Text.Trim() == "Line")
            {
                Session["LineID"] = lblTestRportId.Text.Trim();
            }
            else if (lblType.Text.Trim() == "Substation Transformer")
            {
                Session["SubStationID"] = lblTestRportId.Text.Trim();
            }
            else if (lblType.Text.Trim() == "Generating Station")
            {
                Session["GeneratingSetId"] = lblTestRportId.Text.Trim();
            }


            if (e.CommandName == "Select")
            {
                Response.Redirect("/SiteOwnerPages/Inspection.aspx", false);

            }
        }
    }
}