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
    public partial class CreateTestReports : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null || Request.Cookies["SiteOwnerId"] != null)
                    {
                        getWorkIntimationData();
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
            string Id = Session["SiteOwnerId"].ToString();

            DataSet ds = new DataSet();
            ds = CEI.TestReportData(Id);
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
                    if (lblhistory.Text.Trim() == "Generated")
                    {
                        string script = "alert(\"You already created a test report for this. It is now only visible under Test Report History.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        Label lblTyps = (Label)row.FindControl("lblTyps");
                        Session["Typs"] = lblTyps.Text.Trim();
                        Label lblApllication = (Label)row.FindControl("lblApllication");
                        Session["Application"] = lblApllication.Text.Trim();
                        Label lblIntimations = (Label)row.FindControl("lblIntimations");
                        Session["Intimations"] = lblIntimations.Text.Trim();
                        Label lblNoOfInstallations = (Label)row.FindControl("lblNoOfInstallations");
                        Session["NoOfInstallations"] = lblNoOfInstallations.Text.Trim();
                        Label lblID = (Label)row.FindControl("lblID");
                        Session["IHID"] = lblID.Text.Trim();
                        Label lblVoltageLevel = (Label)row.FindControl("lblVoltageLevel");
                        Session["VoltageLevel"] = lblVoltageLevel.Text.Trim();
                        if (lblTyps.Text.Trim() == "Line")
                        {
                            Response.Redirect("/Supervisor/LineTestReport.aspx", false);
                        }
                        else if (lblTyps.Text.Trim() == "Substation Transformer")
                        {
                            Response.Redirect("/Supervisor/SubstationTestReport.aspx", false);
                        }
                        else if (lblTyps.Text.Trim() == "Generating Set")
                        {
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