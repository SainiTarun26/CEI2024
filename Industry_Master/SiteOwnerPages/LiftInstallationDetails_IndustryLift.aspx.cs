using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master.SiteOwnerPages
{
    public partial class LiftInstallationDetails_IndustryLift : System.Web.UI.Page
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
                        loginTypeLabel.Text = "Supervisor / Create New Test Report / Installation Details";
                    }

                    if (Session["SiteOwnerId_IndustryLift"] != null)
                    {
                        getWorkIntimationData();
                    }
                    else
                    {
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                        Response.Redirect("/Industry_Sessions_Clear.aspx", false);
                        return;
            }
        }

        private void getWorkIntimationData()
        {
            string Id = Session["id_IndustryLift"].ToString();

            DataTable ds = new DataTable();
            ds = CEI.GetInstllationsforSitOwner_IndustryLift(Id);
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
                Session["OTP_IndustryLift"] = "0";
                Session["ReturnedValue_IndustryLift"] = "Treys";
                if (Session["SiteOwnerId_IndustryLift"] != null || Request.Cookies["SiteOwnerId_IndustryLift"] != null)
                {
                    if (e.CommandName == "Select")
                    {
                        Control ctrl = e.CommandSource as Control;
                        GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                        Label lblhistory = (Label)row.FindControl("lblhistory");
                        Label lblStatus = (Label)row.FindControl("lblStatus");
                        Label lblReportType = (Label)row.FindControl("lblReportType");



                        Session["Approval_IndustryLift"] = lblStatus.Text.Trim();

                        if (Session["Approval_IndustryLift"].ToString() != null)
                        {
                            Session["Typs_IndustryLift"] = "";
                            Session["TypeOf_IndustryLift"] = "";
                            Session["Application_IndustryLift"] = "";
                            Session["ApplicationForTestReport_IndustryLift"] = "";
                            Session["Intimations_IndustryLift"] = "";
                            Session["NoOfInstallations_IndustryLift"] = "";
                            Session["NoOfInstallation_IndustryLift"] = "";
                            Session["TotalInstallation_IndustryLift"] = "";
                            Session["IHID_IndustryLift"] = "";
                            Session["IHIDs_IndustryLift"] = "";
                            Session["LineId_IndustryLift"] = "";
                            Session["ValueId_IndustryLift"] = "";
                            Session["SubStationID_IndustryLift"] = "";
                            Session["GeneratingSetId_IndustryLift"] = "";
                            Session["ApplicantType_IndustryLift"] = "";
                        }

                        if (lblhistory.Text.Trim() == "Generated" && lblStatus.Text.Trim() != "Reject")
                        {
                            string script = "alert(\"You already created a test report for this. It is now only visible under Test Report History.\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                        else if (lblReportType.Text == "Returned")
                        {

                            //if (Session["SiteOwnerId"].ToString().ToLower() == lblAssignedSupervisor.Text.ToString().ToLower())
                            //{
                            Label lblTyps = (Label)row.FindControl("lblTyps");
                            Session["Typs_IndustryLift"] = lblTyps.Text.Trim();
                            Session["TypeOf_IndustryLift"] = lblTyps.Text.Trim();                          ///////////////
                            Label lblApllication = (Label)row.FindControl("lblApllication");
                            Session["Application_IndustryLift"] = lblApllication.Text.Trim();
                            Session["ApplicationForTestReport_IndustryLift"] = lblApllication.Text.Trim(); /////////
                            Label lblIntimations = (Label)row.FindControl("lblIntimations");
                            Session["Intimations_IndustryLift"] = lblIntimations.Text.Trim();
                            Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                            Session["NoOfInstallation_IndustryLift"] = lblNoOfInstallations.Text.Trim();
                            Label lblTotalInstallation = (Label)row.FindControl("lblTotalInstallation");
                            Session["TotalInstallation_IndustryLift"] = lblTotalInstallation.Text.Trim();
                            //Session["TotalInstallation"] = lblTotalInstallation.Text.Trim();
                            Label lblID = (Label)row.FindControl("lblID");
                            Session["IHID_IndustryLift"] = lblID.Text.Trim();
                            Session["IHIDs_IndustryLift"] = lblID.Text.Trim();                           //////////////
                            Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                            Session["VoltageLevel_IndustryLift"] = lblVoltageLevel.Text.Trim();
                            //Label lblApplicantType = (Label)row.FindControl("ApplicantType");
                            //Session["ApplicantType"] = lblApplicantType.Text.Trim();
                            DataSet ds = new DataSet();
                            ds = CEI.GetData(lblTyps.Text.Trim(), lblIntimations.Text.Trim(), lblNoOfInstallations.Text.Trim());
                            if (lblTyps.Text.Trim() == "Lift")
                            {
                                //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                //{
                                //    Session["LineId"] = ds.Tables[0].Rows[0]["ID"].ToString();
                                //    Session["ValueId"] = "True";
                                //}
                                Response.Redirect("/Industry_Master/SiteOwnerPages/LiftDetails_IndustryLift.aspx", false);
                            }
                            else
                            {

                                Response.Redirect("/Industry_Master/SiteOwnerPages/EscalatorDetails_IndustryLift.aspx", false);
                            }
                            //}
                            //else
                            //{
                            //    string script = "alert(\"You are not Authorised to Edit.\");";
                            //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            //}
                        }
                        //If The TestReport Is Assigned To New Supervisor Then That One Should Not Be Able to Work On Other TestReports In That Intimation

                        else
                        {
                            Label lblTyps = (Label)row.FindControl("lblTyps");
                            Session["Typs_IndustryLift"] = lblTyps.Text.Trim();
                            Session["TypeOf_IndustryLift"] = lblTyps.Text.Trim();                          ///////////////
                            Label lblApllication = (Label)row.FindControl("lblApllication");
                            Session["Application_IndustryLift"] = lblApllication.Text.Trim();
                            Session["ApplicationForTestReport_IndustryLift"] = lblApllication.Text.Trim(); /////////
                            Label lblIntimations = (Label)row.FindControl("lblIntimations");
                            Session["Intimations_IndustryLift"] = lblIntimations.Text.Trim();
                            Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                            Session["NoOfInstallations_IndustryLift"] = lblNoOfInstallations.Text.Trim();
                            Session["NoOfInstallation_IndustryLift"] = lblNoOfInstallations.Text.Trim();
                            Label lblTotalInstallation = (Label)row.FindControl("lblTotalInstallation");
                            Session["TotalInstallation_IndustryLift"] = lblTotalInstallation.Text.Trim();
                            Label lblID = (Label)row.FindControl("lblID");
                            Session["IHID_IndustryLift"] = lblID.Text.Trim();
                            Session["IHIDs_IndustryLift"] = lblID.Text.Trim();                           //////////////
                            //Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                            //Session["VoltageLevel"] = lblVoltageLevel.Text.Trim();
                            //Label lblApplicant = (Label)row.FindControl("lblApplicant");
                            //Session["ApplicantType"] = lblApplicant.Text.Trim();
                            DataSet ds = new DataSet();
                            ds = CEI.GetData(lblTyps.Text.Trim(), lblIntimations.Text.Trim(), lblNoOfInstallations.Text.Trim());
                            if (lblTyps.Text.Trim() == "Lift")
                            {
                                //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                //{
                                //    Session["LineId"] = ds.Tables[0].Rows[0]["ID"].ToString();
                                //    Session["ValueId"] = "True";
                                //}
                                Response.Redirect("/Industry_Master/SiteOwnerPages/LiftDetails_IndustryLift.aspx", false);
                            }
                            else
                            {

                                Response.Redirect("/Industry_Master/SiteOwnerPages/EscalatorDetails_IndustryLift.aspx", false);
                            }

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
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblReportType = (Label)e.Row.FindControl("lblReportType");

                if (lblReportType != null && lblReportType.Text == "Returned")
                {
                    e.Row.CssClass = "ReturnedRowColor";
                }

            }
        }
    }
}