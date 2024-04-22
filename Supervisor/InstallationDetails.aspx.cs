using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEIHaryana;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CEI_PRoject;
using System.Runtime.ConstrainedExecution;

namespace CEIHaryana.Supervisor
{
    public partial class InstallationDetails : System.Web.UI.Page
    {

        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null)
                    {
                        getWorkIntimationData();
                    }
                    else
                    {
                        Response.Redirect("/Login.aspx");
                    }
                }
            }
            catch
            {
                Response.Redirect("/login.aspx");
            }
        }

        private void getWorkIntimationData()
        {
            string Id = Session["id"].ToString();

            DataTable ds = new DataTable();
            ds = CEI.GetInstllationsforSupervisor(Id);
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getWorkIntimationData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblhistory = (Label)row.FindControl("lblhistory");
                    Label lblStatus = (Label)row.FindControl("lblStatus");
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

                    if (lblhistory.Text.Trim() == "Generated" && lblStatus.Text.Trim() != "Reject")
                    {
                        string script = "alert(\"You already created a test report for this. It is now only visible under Test Report History.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
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
                        ds = CEI.GetData(lblTyps.Text.Trim(), lblIntimations.Text.Trim(), lblNoOfInstallations.Text.Trim());
                        if (lblTyps.Text.Trim() == "Line")
                        {
                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                Session["LineId"] = ds.Tables[0].Rows[0]["ID"].ToString();
                                Session["ValueId"] = "True";
                            }
                            Response.Redirect("/Supervisor/LineTestReport.aspx", false);
                        }
                        else if (lblTyps.Text.Trim() == "Substation Transformer")
                        {
                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                Session["SubStationID"] = ds.Tables[0].Rows[0]["ID"].ToString();
                                Session["ValueId"] = "True";
                            }
                            Response.Redirect("/Supervisor/SubstationTestReport.aspx", false);
                        }
                        else if (lblTyps.Text.Trim() == "Generating Set")
                        {
                            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["ID"].ToString();
                                Session["ValueId"] = "True";
                            }
                            Response.Redirect("/Supervisor/GeneratingSetTestReport.aspx", false);
                        }
                    }


                }
                else
                {

                }
            }
            catch (Exception)
            { }
        }
    }
}