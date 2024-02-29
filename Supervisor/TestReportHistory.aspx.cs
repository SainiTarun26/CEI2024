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
                    GridViewBind();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
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
                    Session["Approval"] = lblApproval.Text;
                    Label lblVoltage = (Label)row.FindControl("lblVoltage");
                    Session["Voltagelevel"] = lblVoltage.Text;
                    Session["TestReportHistory"] = "True";
                    Label lblInstallationLine = (Label)row.FindControl("lblInstallationLine");
                    Session["NoOfInstallation"] = lblInstallationLine.Text;
                    Label lblApplicationForTestReport = (Label)row.FindControl("lblApplicationForTestReport");
                    Session["ApplicationForTestReport"] = lblApplicationForTestReport.Text;
                    Label lblIHID = (Label)row.FindControl("lblIHID");
                    Session["IHIDs"] = lblIHID.Text;
                    Label lblIntimations = (Label)row.FindControl("lblIntimations");
                    
                    if (e.CommandName == "Select")
                    {
                       Label lblTypeOf = (Label)row.FindControl("lblTypeOf");
                        Session["TypeOf"] = lblTypeOf.Text;
                        DataSet ds = cei.GetReportsHistory(lblTypeOf.Text.Trim(), lblIntimations.Text.Trim(), lblInstallationLine.Text);
                        string id = ds.Tables[0].Rows[0]["ID"].ToString();
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

                    }
                }
            }
            catch { }
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
            catch
            {

            }
        }
    }
}