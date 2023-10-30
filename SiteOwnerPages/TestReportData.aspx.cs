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
    public partial class TestReportData : System.Web.UI.Page
    {

        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridData();
            }
        }

        protected void GridData()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SiteOwnerLineData(LoginID);
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
                string id = lblID.Text;
                Session["LineID"] = id;
                Label lblIntimationId = (Label)row.FindControl("lblIntimationId");
                string IntimationId = lblIntimationId.Text;
                Session["IntimationId"] = IntimationId;
                Label lblInspectionType = (Label)row.FindControl("lblInspectionType");
                Session["InspectionType"] = lblInspectionType.Text;
                Label lblApplicantType = (Label)row.FindControl("lblApplicantType");
                Session["ApplicantType"] = lblApplicantType.Text; 
                Label lblVoltage = (Label)row.FindControl("lblVoltage");
                Session["Voltage"] = lblVoltage.Text;
                Label lblDistrict = (Label)row.FindControl("lblDistrict");
                Session["District"] = lblDistrict.Text;
                if (e.CommandName == "Select")

                {
                    Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);

                }
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridData();
        }
    }
}