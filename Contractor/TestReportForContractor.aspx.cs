using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class TestReportForContractor : System.Web.UI.Page
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

        private void GridViewBind()
        {
            string LoginId = string.Empty;
            LoginId = Session["ContractorID"].ToString();
            DataSet ds = new DataSet();
            ds = cei.TestReportContractorHistory(LoginId);
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
                    Label lblID = (Label)row.FindControl("lblID");
                    string id = lblID.Text;
                    Label lblTypeOf = (Label)row.FindControl("lblTypeOf");
                    if(lblTypeOf.Text.Trim() == "Line")
                    {

                        Session["LineID"] = id;
                    }
                    else if (lblTypeOf.Text.Trim() == "Substation")
                    {

                        Session["SubStationID"] = id;
                    }
                    else if (lblTypeOf.Text.Trim() == "Generating")
                    {

                        Session["GeneratingSetId"] = id;
                    }
                    Label lblApproval = (Label)row.FindControl("lblApproval");
                    Session["Approval1"] = lblApproval.Text;
                    Session["Approval"] = lblApproval.Text;
                    Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                    Session["TestReportId"] = lblTestReportId.Text;
                    Session["TestReportHistory"] = "True";
                    Label lblReasionRejection = (Label)row.FindControl("LblReasionforRejection");
                    Session["ReasionForRejection"] = lblReasionRejection.Text;
                    if (e.CommandName == "Select")
                    {
                        //if (lblApproval.Text.Trim() == "Reject")
                        //{
                        Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                        //}
                        //else
                        //{
                        //    Response.Redirect("/TestReportModal/LineTestReportModal.aspx");
                        //}

                    }
                }
            }
            catch { }
        }

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