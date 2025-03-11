using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;
namespace CEIHaryana.Industry_Master.SiteOwnerPages
{
    public partial class ReturnInspections_IndustryLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindGrid();
                    Session["InspectionId_IndustryLift"] = "";
                }
            }
            catch
            { }
        }

        private void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId_IndustryLift"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SiteOwnerReturnedInspection_IndustryLift(LoginID);
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
                Session["TestReportIds_IndustryLift"] = "Test";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["InspectionId_IndustryLift"] = lblID.Text;
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval_IndustryLift"] = lblApproval.Text.Trim();
                Label lblType = (Label)row.FindControl("lblType");
                Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                Label lblTypeOfInspection = (Label)row.FindControl("lblTypeOfInspection");
                Label lblReturnBased = (Label)row.FindControl("lblReturnBased");
                Session["ReturnedValue_IndustryLift"] = lblReturnBased.Text.Trim();
                if (e.CommandName == "Select")
                {
                    Session["TypeOfInspection_IndustryLift"] = "";
                    Session["Verified_IndustryLift"] = "NotVerified";
                    Session["TypeOfInspection_IndustryLift"] = lblTypeOfInspection.Text.Trim();
                    if (lblType.Text.Trim() == "Lift" || lblType.Text.Trim() == "Escalator" || lblType.Text.Trim() == "Lift/Escalator" || lblType.Text.Trim() == "MultiLift" || lblType.Text.Trim() == "MultiEscalator")
                    {
                        Response.Redirect("/Industry_Master/SiteOwnerPages/ReturnLiftInspections_IndustryLift.aspx", false);
                    }
                    //else if (lblTypeOfInspection.Text.Trim() == "New")
                    //{

                    //    Response.Redirect("/Industry_Master/SiteOwnerPages/ReapplyReturnINspection_IndustryLift.aspx", false);
                    //}
                    //else if (lblTypeOfInspection.Text.Trim() == "Periodic")
                    //{
                    //    Response.Redirect("/Industry_Master/SiteOwnerPages/InspectionRenewalCart_IndustryLift.aspx", false);
                    //}

                }
            }
        }
    }
}