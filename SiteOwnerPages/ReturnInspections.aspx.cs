using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class ReturnInspections : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindGrid();
                    Session["InspectionId"] = "";
                }
            }
            catch
            { }
        }

        private void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SiteOwnerReturnedInspection(LoginID);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"There is no returned inspection exist for this user.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Session["TestReportIds"] = "Test";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["InspectionId"] = lblID.Text;
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                Label lblType = (Label)row.FindControl("lblType");
                Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                Label lblTypeOfInspection = (Label)row.FindControl("lblTypeOfInspection");
                Label lblReturnBased = (Label)row.FindControl("lblReturnBased");
                Session["ReturnedValue"] = lblReturnBased.Text.Trim();
                Label lblCartId = (Label)row.FindControl("lblCartId");   //Added
                Session["CartID"] = lblCartId.Text.Trim();
                if (e.CommandName == "Select")
                {
                    Session["TypeOfInspection"] = "";
                    Session["Verified"] = "NotVerified";
                    Session["TypeOfInspection"] = lblTypeOfInspection.Text.Trim();
                    if (lblType.Text.Trim() == "Lift" || lblType.Text.Trim() == "Escalator" || lblType.Text.Trim() == "Lift/Escalator" || lblType.Text.Trim() == "MultiLift" || lblType.Text.Trim() == "MultiEscalator")
                    {
                        Response.Redirect("/SiteOwnerPages/ReturnLiftInspections.aspx", false);
                    }
                    else if (lblTypeOfInspection.Text.Trim() == "New")
                    {

                        Response.Redirect("/SiteOwnerPages/ReapplyReturnINspection.aspx", false);
                    }
                    else if (lblTypeOfInspection.Text.Trim() == "Periodic")
                    {
                       // Response.Redirect("/SiteOwnerPages/InspectionRenewalCart.aspx", false);
                        Response.Redirect("/SiteOwnerPages/ProcessInspectionRenewalCart.aspx", false);
                    }

                }
            }
        }
    }
}