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
    public partial class TestReport : System.Web.UI.Page
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

                    if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                    {
                        getWorkIntimationData();
                    }
                    else
                    {
                        Response.Redirect("/Login.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/login.aspx");
            }

        }
        private void getWorkIntimationData()
        {
            string Id = Session["intimationid"].ToString();

            DataTable ds = new DataTable();
            ds = CEI.InstallationDataforSiteOwner(Id);
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
                if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
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



                        Session["Approval"] = lblStatus.Text.Trim();

                        if (Session["Approval"].ToString() != null)
                        {
                            Session["Typs"] = "";
                            Session["TypeOf"] = "";
                            Session["Application"] = "";
                            Session["ApplicationForTestReport"] = "";
                            Session["Intimations"] = "";
                            Session["NoOfInstallations"] = "";
                            Session["NoOfInstallation"] = "";
                            Session["TotalInstallation"] = "";
                            Session["IHID"] = "";
                            Session["IHIDs"] = "";
                            Session["LineId"] = "";
                            Session["ValueId"] = "";
                            Session["SubStationID"] = "";
                            Session["GeneratingSetId"] = "";
                        }


                    
                            Label lblTyps = (Label)row.FindControl("lblTyps");
                            Session["Typs"] = lblTyps.Text.Trim();
                            Session["TypeOf"] = lblTyps.Text.Trim();                          ///////////////
                            Label lblApllication = (Label)row.FindControl("lblApllication");
                            Session["Application"] = lblApllication.Text.Trim();
                            Session["ApplicationForTestReport"] = lblApllication.Text.Trim(); /////////
                            Label lblIntimations = (Label)row.FindControl("lblIntimations");
                            Session["Intimations"] = lblIntimations.Text.Trim();
                            Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                            Session["NoOfInstallations"] = lblNoOfInstallations.Text.Trim();
                            Session["NoOfInstallation"] = lblNoOfInstallations.Text.Trim();
                            Label lblTotalInstallation = (Label)row.FindControl("lblTotalInstallation");
                            Session["TotalInstallation"] = lblNoOfInstallations.Text.Trim();
                            Label lblID = (Label)row.FindControl("lblID");
                            Session["IHID"] = lblID.Text.Trim();
                            Session["IHIDs"] = lblID.Text.Trim();                           //////////////
                            Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                            Session["VoltageLevel"] = lblVoltageLevel.Text.Trim();
                            DataSet ds = new DataSet();
                            //ds = CEI.GetData(lblTyps.Text.Trim(), lblIntimations.Text.Trim(), lblNoOfInstallations.Text.Trim());
                           
                            if (lblTyps.Text.Trim() == "Substation Transformer")
                            {
 
                                Response.Redirect("/SiteOwnerPages/SubstationTransformerPeriodic.aspx", false);
                            }
                            else if (lblTyps.Text.Trim() == "Generating Set")
                            {
                                Response.Redirect("/SiteOwnerPages/generatingsetPeriodic.aspx", false);
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