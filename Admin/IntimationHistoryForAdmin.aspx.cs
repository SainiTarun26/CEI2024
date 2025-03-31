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
    public partial class IntimationHistoryForAdmin : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        BindGrid();
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BindGrid()
        {
            try
            {
                string LoginId = Session["AdminID"].ToString();
                DataTable ds = new DataTable();
                ds = CEI.InspectionHistoryForAdminData(LoginId);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                    Label lblApproval = (Label)row.FindControl("lblApproval");
                    Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
                    string installationType = lblInstallationType.Text.Trim();
                    Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
                    string TestRportId = lblTestRportId.Text.Trim();
                    Label lblRequestStatus = (Label)row.FindControl("lblRequestStatus");
                    Label lblTypeOfInspection = (Label)row.FindControl("lblTypeOfInspection");
                    Label lblInstallationFor = (Label)row.FindControl("lblInstallationFor");               
                    if (e.CommandName == "Select")
                    {
                      
                        if (lblInstallationFor.Text == "Lift" || lblInstallationFor.Text == "Escalator" || lblInstallationFor.Text == "Lift/Escalator" || lblInstallationFor.Text == "MultiLift" || lblInstallationFor.Text == "MultiEscalator")
                        {
                            Session["InspectionId"] = lblID.Text;
                            Response.Redirect("/Admin/IntimationHistoryForLift.aspx", false);
                        }
                        else if (lblRequestStatus != null && lblRequestStatus.Text == "ReSubmit" && lblTypeOfInspection.Text == "New")
                        {
                            Session["InspectionId"] = lblID.Text;
                            Response.Redirect("/Admin/ReturnedIntimationForHistory.aspx", false);
                        }
                        else if (lblRequestStatus != null && lblRequestStatus.Text == "ReSubmit" && lblTypeOfInspection.Text == "Periodic")
                        {
                            Session["InspectionId"] = lblID.Text;
                            Response.Redirect("/Admin/PeriodicReturnedIntimationForHistory.aspx", false);
                        }
                        else 
                        {
                            Session["InspectionId"] = lblID.Text;
                            Response.Redirect("/Admin/IntimationForHistory.aspx", false);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No Record Found\");", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}