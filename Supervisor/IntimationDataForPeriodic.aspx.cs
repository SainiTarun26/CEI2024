using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using static System.Net.Mime.MediaTypeNames;

namespace CEIHaryana.Supervisor
{
    public partial class IntimationDataForPeriodic : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static string inspectionId = string.Empty;
        private static string Intimation = string.Empty;
        private static string TestReportCount = string.Empty;
        private static string InstallationName = string.Empty;
        private static string Status = string.Empty;
        private static string AssignedSupervisor = string.Empty;
        private static string Id = string.Empty;
        private static string Voltage = string.Empty; 


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    var master = (MasterPage)Master;
                    var loginTypeLabel = (Label)master.FindControl("LoginType");
                    if (loginTypeLabel != null)
                    {
                        loginTypeLabel.Text = "Supervisor / Create Periodic test Report(Returned)";
                    }
                    if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null)
                    {
                        GetReturnedInspectionData();
                    }
                    else
                    {
                        Response.Redirect("/Login.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }

        private void GetReturnedInspectionData()
        {
            DataTable ds = new DataTable();
            string Id = Session["SupervisorID"].ToString();
            ds = CEI.GetReturnedPeriodicInspections(Id);
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

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            DivViewCart.Visible = true;
            LinkButton lnkViewTestReport = sender as LinkButton;
            if (lnkViewTestReport != null)
            {
                GridViewRow row = (GridViewRow)lnkViewTestReport.NamingContainer;
                Label lblInspectionId = (Label)row.FindControl("lblInspectionId");

                if (lblInspectionId != null)
                {
                    inspectionId = lblInspectionId.Text;
                }
            }
            GridToViewCart();
        }

        private void GridToViewCart()
        {
            try
            {
                DataSet dsVC = CEI.GetDetailsToViewCartforSupervisor(inspectionId);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    GridView3.DataSource = dsVC;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }

        protected void lnkRedirect1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                LinkButton lnkRedirect1 = (LinkButton)sender;
                string testReportId = lnkRedirect1.CommandArgument;

                Session["InspectionTestReportId"] = btn.CommandArgument;

                if (installationName == "Line")
                {
                    Session["LineID"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
                }
                else if (installationName == "Substation Transformer")
                {
                    Session["SubStationID"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
                }
                else if (installationName == "Generating Set")
                {
                    Session["GeneratingSetId"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
                }
                GridToViewCart();
            }
            catch (Exception ex) { }
        }

        protected void LnkToCreate_Click(object sender, EventArgs e)
        {
            LinkButton lnkViewTestReport = sender as LinkButton;
            if (lnkViewTestReport != null)
            {
                GridViewRow row = (GridViewRow)lnkViewTestReport.NamingContainer;
                Label lblId = (Label)row.FindControl("lblId");

                if (lblId != null)
                {
                    Id = lblId.Text;
                }
                Label IntimationId = (Label)row.FindControl("IntimationId");
                if (IntimationId != null)
                {
                    Intimation = IntimationId.Text;
                }
                Label lblTestReportCount = (Label)row.FindControl("lblTestReportCount");
                if (lblTestReportCount != null)
                {

                    TestReportCount = lblTestReportCount.Text;
                }
                Label lblInstallationName = (Label)row.FindControl("lblInstallationName");
                if (lblInstallationName != null)
                {

                    InstallationName = lblInstallationName.Text;
                }
                Label lblApplicationStatus = (Label)row.FindControl("lblApplicationStatus");
                if (lblApplicationStatus != null)
                {

                    Status = lblApplicationStatus.Text;
                }
                Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                if (lblVoltageLevel != null)
                {

                    Voltage = lblVoltageLevel.Text;
                    Session["VoltageLevel"] = Voltage;
                }

                //Label lblAssignedSupervisor = (Label)row.FindControl("lblAssignedSupervisor");
                //if (lblAssignedSupervisor != null)
                //{
                
                //    AssignedSupervisor = lblAssignedSupervisor.Text;
                //}

            }


            Session["Approval"] = Status.Trim();
            if (Status == "Return")
            {
                //if (Session["SupervisorID"].ToString().ToLower() == AssignedSupervisor.ToLower())
                //{
                    DataSet ds = new DataSet();
                    ds = CEI.GetData(InstallationName.Trim(), Intimation.Trim(), TestReportCount.Trim());

                    if (InstallationName.Trim() == "Line")
                    {
                        Response.Redirect("/Supervisor/LineTestReport.aspx", false);
                    }
                    else if (InstallationName.Trim() == "Substation Transformer")
                    {
                        Response.Redirect("/Supervisor/SubstationTestReport.aspx", false);
                    }
                    else if (InstallationName.Trim() == "Generating Set")
                    {
                        Response.Redirect("/Supervisor/GeneratingSetTestReport.aspx", false);
                    }
                //}
                //else
                //{
                //    string script = "alert(\"You are not Authorized to Edit.\");";
                //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                //}
            }
        }
    }
}