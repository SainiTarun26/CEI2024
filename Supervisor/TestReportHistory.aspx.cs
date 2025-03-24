using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class TestReportHistory : System.Web.UI.Page
    {
        CEI cei = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var master = (MasterPage)Master;
                    var loginTypeLabel = (Label)master.FindControl("LoginType");
                    if (loginTypeLabel != null)
                    {
                        loginTypeLabel.Text = "Supervisor /  Test Report History";
                    }
                    GridViewBind();
                }
            }
            catch
            {
                Response.Redirect("/SupervisorLogout.aspx");
            }
        }
        public void GridViewBind()
        {
            string LoginId = string.Empty;
            LoginId = Session["SupervisorID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.GetSuppervisorTestReportHistory(LoginId);
            if (ds.Tables.Count > 0)
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
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblApproval = (Label)row.FindControl("lblApproval");
                    Session["Approval1"] = lblApproval.Text;

                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    string id = lblTestReportId.Text;

                    Session["Approval"] = lblApproval.Text;
                    Label lblVoltage = (Label)row.FindControl("lblVoltage");
                    Session["Voltagelevel"] = lblVoltage.Text;
                    Session["TestReportHistory"] = "True";
                    Label lblInstallationLine = (Label)row.FindControl("lblInstallationLine");
                    Session["NoOfInstallation"] = lblInstallationLine.Text;
                    Session["NoOfInstallations"] = lblInstallationLine.Text;
                    Label lblApplicationForTestReport = (Label)row.FindControl("lblApplicationForTestReport");
                    Session["ApplicationForTestReport"] = lblApplicationForTestReport.Text;
                    //Label lblIHID = (Label)row.FindControl("lblIHID");
                    //Session["IHIDs"] = lblIHID.Text;
                    Label lblIntimations = (Label)row.FindControl("lblIntimations");




                    if (e.CommandName == "Select")
                    {
                        Label lblTypeOf = (Label)row.FindControl("lblTypeOf");
                        Session["TypeOf"] = lblTypeOf.Text;
                        DataSet ds = cei.GetReportsHistory(lblTypeOf.Text.Trim(), lblIntimations.Text.Trim(), lblInstallationLine.Text, lblTestReportId.Text);
                        //string id = ds.Tables[0].Rows[0]["ID"].ToString(); gurmeet to resolve the testreportid
                        //string id = ds.Tables[0].Rows[0]["TestReportId"].ToString();


                        Session["ID"] = id.Trim();
                        if (lblTypeOf.Text.Trim() == "Line")
                        {
                            if (lblApproval.Text.Trim() == "Reject")
                            {
                                Session["LineID"] = id;
                                Response.Redirect("~/Supervisor/LineTestReport.aspx", false);
                            }
                            else
                            {
                                Session["LineID"] = id;
                                Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                            }
                        }
                        else if (lblTypeOf.Text.Trim() == "Substation Transformer")
                        {

                            if (lblApproval.Text.Trim() == "Reject")
                            {
                                Session["SubStationID"] = id;
                                Response.Redirect("~/Supervisor/SubstationTestReport.aspx", false);
                            }
                            else
                            {
                                Session["SubStationID"] = id;
                                Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                            }
                        }
                        else if (lblTypeOf.Text.Trim() == "Generating Set")
                        {

                            if (lblApproval.Text.Trim() == "Reject")
                            {
                                Session["GeneratingSetId"] = id;
                                Response.Redirect("/Supervisor/GeneratingSetTestReport.aspx", false);
                            }
                            else
                            {
                                Session["GeneratingSetId"] = id;
                                Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
                            }
                        }
                        else if (lblTypeOf.Text.Trim() == "Switching station")
                        {

                            //if (lblApproval.Text.Trim() == "Reject")
                            //{
                            //    Session["GeneratingSetId"] = id;
                            //    Response.Redirect("/Supervisor/GeneratingSetTestReport.aspx", false);
                            //}
                            //else
                            //{
                                Session["SwitchingSubstationId"] = id;
                                Response.Redirect("/TestReportModal/SwitchingSubstationTestReportModal.aspx", false);
                           // }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        //protected void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    string searhterm = txtSearch.Text.Trim();
        //    string LoginId = string.Empty;
        //    LoginId = Session["SupervisorID"].ToString();

        //    DataSet ds = new DataSet();
        //    ds = cei.SearchingOnLine(searhterm, LoginId);
        //    if (ds.Tables.Count > 0)
        //    {
        //        GridView1.DataSource = ds;
        //        GridView1.DataBind();
        //    }
        //    else
        //    {
        //        string script = "alert(\"No Record Match\");";
        //        ScriptManager.RegisterStartupScript(this, GetType(), "Server Script", script, true);
        //    }
        //}

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridViewBind();
            }
            catch (Exception ex)
            {
                //
            }
        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        int reportTypeColumnIndex = 8;
        //        TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

        //        if (reportTypeCell.Text == "Return")
        //        {
        //            reportTypeCell.CssClass = "blink";
        //        }
        //    }
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int reportTypeColumnIndex = 11;
                TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

                if (reportTypeCell.Text == "Return")
                {
                    e.Row.CssClass = "ReturnedRowColor";
                }

            }
        }

        protected void lnkReadMore_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;
            if (row != null)
            {
                Label lblOffRemarks = (Label)row.FindControl("lblOffRemarks");
                Label lblSORemarks = (Label)row.FindControl("lblSORemarks");
                Label lblContRemarks = (Label)row.FindControl("lblContRemarks");

                // Clear modal labels before updating
                lblModalOffRemarks.Text = string.Empty;
                lblModalSORemarks.Text = string.Empty;
                lblModalContRemarks.Text = string.Empty;

                OffRemarks.Visible = false;
                SORemarks.Visible = false;
                ContRemarks.Visible = false;


                //Label lblOffRemarks = (Label)row.FindControl("lblOffRemarks");
                if (lblOffRemarks != null && !string.IsNullOrEmpty(lblOffRemarks.Text))
                {
                    OffRemarks.Visible = true;
                    lblModalOffRemarks.Text = lblOffRemarks.Text;
                }
                //Label lblSORemarks = (Label)row.FindControl("lblSORemarks");
                if (lblSORemarks != null && !string.IsNullOrEmpty(lblSORemarks.Text))
                {
                    SORemarks.Visible = true;
                    lblModalSORemarks.Text = lblSORemarks.Text;
                }
                //Label lblContRemarks = (Label)row.FindControl("lblContRemarks");
                if (lblContRemarks != null && !string.IsNullOrEmpty(lblContRemarks.Text))
                {
                    ContRemarks.Visible = true;

                    lblModalContRemarks.Text = lblContRemarks.Text;
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#modal1').modal('show');", true);
        }
    }
}