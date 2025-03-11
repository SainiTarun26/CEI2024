using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Industry_Master.SiteOwnerPages
{
    public partial class InspectionHistory_New_IndustryLift : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId_IndustryLift"] != null && Session["SiteOwnerId_IndustryLift"].ToString() != "")
                    {
                        BindGrid();
                    }
                }
            }
            catch
            {
            }
        }

        public void BindGrid()
        {
            string LoginID = string.Empty;
            LoginID = Session["SiteOwnerId_IndustryLift"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SiteOwnerInspectionData_IndustryLift(LoginID);
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

            if (e.CommandName == "Select" || e.CommandName == "Print" || e.CommandName == "Print1")
            {
                Session["LineID"] = "";
                Session["SubStationID"] = "";
                Session["GeneratingSetId"] = "";
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label lblID = (Label)row.FindControl("lblID");
                Session["InspectionId_IndustryLift"] = lblID.Text;
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval_IndustryLift"] = lblApproval.Text.Trim();
                Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
                Label lblType = (Label)row.FindControl("lblType");
                Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                Label LblAssignTo = (Label)row.FindControl("LblAssignTo");
                //if (lblType.Text.Trim() == "Line")
                //{
                //    Session["LineID"] = lblTestRportId.Text.Trim();
                //}
                //else if (lblType.Text.Trim() == "Substation Transformer")
                //{
                //    Session["SubStationID"] = lblTestRportId.Text.Trim();
                //}
                //else if (lblType.Text.Trim() == "Generating Set")
                //{
                //    Session["GeneratingSetId"] = lblTestRportId.Text.Trim();
                //}
                if (e.CommandName == "Select")
                {
                    if (lblType.Text.Trim() == "Escalator" || lblType.Text.Trim() == "Lift" || lblType.Text.Trim() == "Lift/Escalator" || lblType.Text.Trim() == "MultiLift" || lblType.Text.Trim() == "MultiEscalator")
                    {
                        Response.Redirect("/Industry_Master/SiteOwnerPages/Inspection_Lift_New_IndustryLift.aspx", false);
                    }
                    //else
                    //{
                    //    Response.Redirect("/SiteOwnerPages/Inspection.aspx", false);
                    //}

                }
                else if (e.CommandName == "Print")
                {
                    if ((lblType.Text == "Lift" || lblType.Text == "Lift/Escalator" || lblType.Text == "Escalator") && LblInspectionType.Text == "Periodic")
                    {
                        Response.Redirect("/Industry_Master/SiteOwnerPages/Periodic_Lift_EscalatorInspectionRequestPrint_IndustryLift.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Industry_Master/SiteOwnerPages/InspectionRequestPrint_IndustryLift.aspx");
                    }

                }
                else if (e.CommandName == "Print1")
                {
                    if (LblInspectionType.Text == "New")
                    {
                         if (lblType.Text == "Multiple")
                        {
                            Response.Redirect("/Print_Forms/NewInspectionApprovalCertificate.aspx", false);
                        }

                                               
                     else if (lblType.Text != "Lift" && lblType.Text != "Escalator" && lblType.Text != "Lift/Escalator" && lblType.Text != "MultiLift" && lblType.Text != "MultiEscalator")
                        {
                            Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                        }
                        else if (lblType.Text == "Lift" || lblType.Text == "Escalator" || lblType.Text == "Lift/Escalator" || lblType.Text == "MultiLift" || lblType.Text == "MultiEscalator")
                        {

                            Response.Redirect("/Industry_Master/SiteOwnerPages/LiftApprovalData_IndustryLift.aspx", false);
                        }
                    }
                    else if (LblInspectionType.Text == "Periodic")
                    {
                        if (lblType.Text != "Lift" && lblType.Text != "Escalator" && lblType.Text != "Lift/Escalator" && lblType.Text != "MultiLift" && lblType.Text != "MultiEscalator")
                        {
                            Response.Redirect("/Print_Forms/PeriodicApprovalCertificate.aspx", false);
                        }
                        else if (lblType.Text == "Lift" || lblType.Text == "Escalator" || lblType.Text == "Lift/Escalator" || lblType.Text == "MultiLift" || lblType.Text == "MultiEscalator")
                        {

                            Response.Redirect("/Industry_Master/SiteOwnerPages/LiftApprovalData_Periodic_IndustryLift.aspx", false);
                        }

                    }
                }
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton linkButton = (LinkButton)e.Row.FindControl("lnkPrint");
                Label lblFinalExpectedApprovalDate = (Label)e.Row.FindControl("lblFinalExpectedApprovalDate");
                Label lblApproval = (Label)e.Row.FindControl("lblApproval");
                string applicationStatus = DataBinder.Eval(e.Row.DataItem, "ApplicationStatus").ToString();
                string AssignTo = DataBinder.Eval(e.Row.DataItem, "AssignTo").ToString();
                if (lblApproval.Text == "Submitted" || lblApproval.Text == "InProcess" || lblApproval.Text == "ReSubmit")
                {
                    lblFinalExpectedApprovalDate.Visible = true;
                }
                else
                {
                    lblFinalExpectedApprovalDate.Visible = false;
                }
                if (applicationStatus == "Approved")
                {
                    if (string.IsNullOrEmpty(AssignTo))
                    {
                        linkButton.Visible = false;
                    }
                    else
                    {
                        linkButton.Visible = true;
                    }

                }
                int reportTypeColumnIndex = 9;
                TableCell reportTypeCell = e.Row.Cells[reportTypeColumnIndex];

                if (reportTypeCell.Text == "Returned")
                {
                    e.Row.CssClass = "ReturnedRowColor";
                }
                //else
                //{

                //    linkButton.Visible = false;
                //}
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                BindGrid();
            }
            catch { }
        }
    }
}