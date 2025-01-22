using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class TestReport_Industries : System.Web.UI.Page
    {
        CEI CEI = new CEI();
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
                        loginTypeLabel.Text = "SiteOwner / Create New Test Report / Installation Details";
                    }

                    if (Convert.ToString(Session["SiteOwnerId_Industry"]) != null && Convert.ToString(Session["SiteOwnerId_Industry"]) != "")
                    {
                        getWorkIntimationData();
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
            }

        }
        private void getWorkIntimationData()
        {
            string Id = Session["intimationid_Industry"].ToString();

            DataTable ds = new DataTable();
            ds = CEI.InstallationDataforSiteOwner_Industries(Id);
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
            try
            {
                if (Session["SiteOwnerId_Industry"] != null || Request.Cookies["SiteOwnerId_Industry"] != null)
                {
                    if (e.CommandName == "Select")
                    {
                        Control ctrl = e.CommandSource as Control;
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                        Label lblhistory = (Label)row.FindControl("lblhistory");
                        Label lblStatus = (Label)row.FindControl("lblStatus");
                        Label lblReportType = (Label)row.FindControl("lblReportType");
                        Label lblAssignedSupervisor = (Label)row.FindControl("lblAssignedSupervisor");
                        Label lblInitialSupervisor = (Label)row.FindControl("lblInitialSupervisor");



                        Session["Approval_Industry"] = lblStatus.Text.Trim();

                        if (Session["Approval_Industry"].ToString() != null)
                        {
                            Session["Typs_Industry"] = "";
                            Session["TypeOf_Industry"] = "";
                            Session["Application_Industry"] = "";
                            Session["ApplicationForTestReport_Industry"] = "";
                            Session["Intimations_Industry"] = "";
                            Session["NoOfInstallations_Industry"] = "";
                            Session["NoOfInstallation_Industry"] = "";
                            Session["TotalInstallation_Industry"] = "";
                            Session["IHID_Industry"] = "";
                            Session["IHIDs_Industry"] = "";
                            Session["LineId_Industry"] = "";
                            Session["ValueId_Industry"] = "";
                            Session["SubStationID_Industry"] = "";
                            Session["GeneratingSetId_Industry"] = "";
                        }



                        Label lblTyps = (Label)row.FindControl("lblTyps");
                        Session["Typs_Industry"] = lblTyps.Text.Trim();
                        Session["TypeOf_Industry"] = lblTyps.Text.Trim();                          ///////////////
                        Label lblApllication = (Label)row.FindControl("lblApllication");
                        Session["Application_Industry"] = lblApllication.Text.Trim();
                        Session["ApplicationForTestReport_Industry"] = lblApllication.Text.Trim(); /////////
                        Label lblIntimations = (Label)row.FindControl("lblIntimations");
                        Session["Intimations_Industry"] = lblIntimations.Text.Trim();
                        Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                        Session["NoOfInstallations_Industry"] = lblNoOfInstallations.Text.Trim();
                        Session["NoOfInstallation_Industry"] = lblNoOfInstallations.Text.Trim();
                        Label lblTotalInstallation = (Label)row.FindControl("lblTotalInstallation");
                        Session["TotalInstallation_Industry"] = lblTotalInstallation.Text.Trim();
                        Label lblID = (Label)row.FindControl("lblID");
                        Session["IHID_Industry"] = lblID.Text.Trim();
                        Session["IHIDs_Industry"] = lblID.Text.Trim();                           //////////////
                        Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                        Session["VoltageLevel_Industry"] = lblVoltageLevel.Text.Trim();
                        DataSet ds = new DataSet();
                        //ds = CEI.GetData(lblTyps.Text.Trim(), lblIntimations.Text.Trim(), lblNoOfInstallations.Text.Trim());

                        if (lblTyps.Text.Trim() == "Substation Transformer")
                        {

                            Response.Redirect("/Industry_Master/SubstationTransformerPeriodic_Industry.aspx", false);
                        }
                        else if (lblTyps.Text.Trim() == "Generating Set")
                        {
                            Response.Redirect("/Industry_Master/GeneratingsetPeriodic_Industry.aspx", false);
                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    //logout
                }
            }
            catch (Exception)
            { }
        }
    }
}