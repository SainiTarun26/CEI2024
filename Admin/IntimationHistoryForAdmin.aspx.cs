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
                    if (Session["AdminID"] != null && Session["AdminID"].ToString() != "")
                    {
                        BindGrid();
                    }
                }
            }
            catch
            {
            }
        }

        private void BindGrid()
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                string LoginId = Session["AdminID"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InspectionHistoryForAdminDataSearch(LoginId);
                if (ds.Tables.Count > 0)
                {
                    DataTable ftrtbs = CEI.Grddtl(searchText, ds, "id1");
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
            catch { }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
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
                    Label lblInstallationType = (Label)row.FindControl("lblInstallationType");
                    string installationType = lblInstallationType.Text.Trim();
                    Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
                    string TestRportId = lblTestRportId.Text.Trim();
                    //if (installationType != "Multiple")
                    //{
                    if (installationType.Trim() == "Line")
                    {
                        Session["LineID"] = installationType;
                    }
                    else if (installationType.Trim() == "Substation Transformer")
                    {
                        Session["SubStationID"] = TestRportId;
                    }
                    else if (installationType.Trim() == "Generating Set")
                    {
                        Session["GeneratingSetId"] = TestRportId;
                    }
                    else if (installationType == "Multiple")
                    {
                        Session["PeriodicMultiple"] = installationType;
                    }
                    if (e.CommandName == "Select")
                    {
                        Response.Redirect("/Admin/IntimationForHistory.aspx", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No Record Found for this test report\");", true);
                    }
                    //}
                    //else
                    //{
                    //    Session["PeriodicMultiple"] = installationType;
                    //    if (e.CommandName == "Select")
                    //    {
                    //        Response.Redirect("/Admin/MultiplePeriodicInspectionDetail.aspx", false);
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No Record Found for this test report\");", true);
                    //    }
                    //}

                    //if (e.CommandName == "Select")
                    //{
                    //    Response.Redirect("/Admin/IntimationForHistory.aspx",false);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", "alert(\"No Record Found for this test report\");", true);
                    //}
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

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}