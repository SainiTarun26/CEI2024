using CEI_PRoject;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.Admin
{
    public partial class InspectionDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id, StaffTo, AssignFrom;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Convert.ToString(Session["AdminId"]) != null && Convert.ToString(Session["AdminId"]) != string.Empty)
                    {
                        if (Convert.ToString(Session["InspectionId"]) != null && Convert.ToString(Session["InspectionId"]) != string.Empty)
                        {
                            ////if (Session["LineID"] != null && Convert.ToString(Session["LineID"]) != "")
                            ////{
                            ////    txtWorkType.Text = "Line";
                            ////    Id = Session["LineID"].ToString();
                            ////}
                            ////else if (Session["SubStationID"] != null && Convert.ToString(Session["LineID"]) != "")
                            ////{
                            ////    txtWorkType.Text = "Substation Transformer";
                            ////    Id = Session["SubStationID"].ToString();
                            ////}
                            ////else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["LineID"]) != "")
                            ////{
                            ////    txtWorkType.Text = "Generating Set";
                            ////    Id = Session["GeneratingSetId"].ToString();
                            ////}
                            string InspectionId = Convert.ToString(Session["InspectionId"]);
                            GetDetailsWithId(InspectionId);
                        }
                        else
                        {
                            Session["InspectionId"] = "";
                            Response.Redirect("/Admin/AdminMaster.aspx", false);
                        }
                    }
                    else
                    {
                        Session["AdminId"] = "";
                        Response.Redirect("/AdminLogout.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        private void BindDivisions(string District)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetDivisionData(District);
            ddlDivisions.DataSource = ds;
            ddlDivisions.DataTextField = "District";
            ddlDivisions.DataValueField = "District";
            ddlDivisions.DataBind();
            ddlDivisions.Items.Insert(0, new ListItem("Select", "0"));
            ds.Clear();
        }
        private void GetDetailsWithId(String ID)
        {
            try
            {
                //ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InspectionData(ID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lbltype.Text = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    if (lbltype.Text == "Periodic")
                    {
                        Grd_PeriodTestReport(ID);
                        GetTestReportDataIfPeriodic(ID);
                    }
                    else if (lbltype.Text == "New")
                    {
                        GetTestReportData(ID);
                        DivTRinMultipleCaseNew.Visible = true;

                        GetGridNewInspectionMultiple(ID);
                    }
                    txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    //start added by gurmeet 17 july-2025
                    string Premises = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                    if (!string.IsNullOrEmpty(Premises))
                    {
                        txtPremises.Text = Premises;
                    }
                    else
                    {
                        txtPremises.Text = "     -";
                    }
                    txtContactPersonContact.Text = ds.Tables[0].Rows[0]["SiteownerContactNumber"].ToString();
                    txtSiteAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                    txtSupervisorContact.Text = ds.Tables[0].Rows[0]["SupervisorPhoneNo"].ToString();
                    txtcontractorContact.Text = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();
                    //** end added by gurmeet 17 july-2025
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                    if (txtWorkType.Text == "Line")
                    {
                        Capacity.Visible = false;
                        LineVoltage.Visible = true;
                        txtLineVoltage.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    }
                    else
                    {
                        LineVoltage.Visible = false;
                        Capacity.Visible = true;
                        txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    }
                    txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                    txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                    txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    txtApplicationStatus.Text = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    if (txtApplicationStatus.Text == "Approved")
                    {
                        //TxtSuggestions.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Suggestion"].ToString()))
                        {
                            Suggestion.Visible = false;
                        }
                        else
                        {
                            TxtSuggestions.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
                            Suggestion.Visible = true;
                            Rejection.Visible = false;
                        }
                    }
                    else if (txtApplicationStatus.Text == "Rejected")
                    {
                        txtRejection.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                        Rejection.Visible = true;
                        Suggestion.Visible = false;
                    }
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["InspectionDate"].ToString()))
                    {
                        inspectionDate.Visible = false;
                    }
                    else
                    {
                        DateTime createdDate1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspectionDate"]);
                        txtInspectionDate.Text = createdDate1.ToString("dd/MM/yyyy");
                        inspectionDate.Visible = true;
                    }
                    GridBindDocument(ID);
                    BindDivisions(txtDistrict.Text.Trim());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "scriptMessage", "alert('Data Not found For this inspection');", true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        private void GetGridNewInspectionMultiple(string ID)
        {
            try
            {
                //string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew(ID);
                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    lblGridMultipleInspectionTR.Visible = false;
                    Grid_MultipleInspectionTR.DataSource = dsVC;
                    Grid_MultipleInspectionTR.DataBind();
                }
                else
                {
                    lblGridMultipleInspectionTR.Visible = true;
                    lblGridMultipleInspectionTR.Text = "NA";
                    Grid_MultipleInspectionTR.DataSource = null;
                    Grid_MultipleInspectionTR.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/AdminMaster.aspx", false);
        }
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ID = Session["InspectionId"].ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        private void BindDropDownToAssign(string Division)
        {
            try
            {
                DataSet dsAssign = new DataSet();
                dsAssign = CEI.DdlToStaffAssign(Division);
                ddlToAssign.DataSource = dsAssign;
                ddlToAssign.DataTextField = "Staff";
                ddlToAssign.DataValueField = "StaffUserId";
                ddlToAssign.DataBind();
                ddlToAssign.Items.Insert(0, new ListItem("Select", "0"));
                dsAssign.Clear();
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDivisions.SelectedValue != "" && ddlDivisions.SelectedValue != null)
            {
                BindDropDownToAssign(ddlDivisions.SelectedValue);
            }
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                if (status == "RETURN")
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[2].BackColor = System.Drawing.Color.Blue;
                e.Row.Cells[2].BackColor = ColorTranslator.FromHtml("#9292cc");
            }
        }
        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            LinkButton lnkRedirect = (LinkButton)sender;
            string AdminTestReportId = lnkRedirect.CommandArgument;
            Session["InspectionTestReportId"] = "";
            if (txtWorkType.Text.Trim() == "Line")
            {
                Session["LineID"] = AdminTestReportId;
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Session["SubStationID"] = AdminTestReportId;
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Session["GeneratingSetId"] = AdminTestReportId;
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            }
        }
        protected void GridView2_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {   string status = DataBinder.Eval(e.Row.DataItem, "ActionTaken").ToString();
                //commented Condition only by gurmeet 1May
                //string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                if (status == "RETURN")
                {
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[2].BackColor = System.Drawing.Color.Blue;
                e.Row.Cells[2].BackColor = ColorTranslator.FromHtml("#9292cc");
            }
        }
        protected void GridBindDocument(string ID)
        {
            try
            {
                //ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Lblgrd_Documemnts.Visible = false;
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    Lblgrd_Documemnts.Visible = true;
                    Lblgrd_Documemnts.Text = "Documents Not Uploaded by User.";
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    // string script = "alert(\"No Record Found for document\");";
                    // ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        private void GetTestReportData(string InspectionId)
        {
            try
            {
                DataSet ds = new DataSet();
                //commet by gurmeet 29 aprail
              //  ds = CEI.GetTestReport(InspectionId);
                ds = CEI.GetInspectionHistoryLogs(InspectionId);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //TestRportId = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    TestReport_Card.Visible = false;
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                //Session["TestRportId"] = TestRportId;
                ds.Dispose();
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        // add below code by gurmeet 8Nov2024 to visible testreport gridview in case of periodic/multiple
        private void Grd_PeriodTestReport(string InspectionId)
        {
            try
            {
                DataSet dsVC = CEI.GetDetailsToViewCart(InspectionId);
                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    PeriodTestReport_CardId.Visible = true;
                    Grd_PeriodicTestReport.DataSource = dsVC;
                    Grd_PeriodicTestReport.DataBind();
                }
                else
                {
                    Grd_PeriodicTestReport.DataSource = null;
                    Grd_PeriodicTestReport.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
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

                Session["InspectionTestReportId"] = btn.CommandArgument;
                if (installationName == "Line")
                {
                    Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                }
                else if (installationName == "Substation Transformer")
                {
                    Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                }
                else if (installationName == "Generating Set")
                {
                    Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        private void GetTestReportDataIfPeriodic(string InspectionId)
        {
            try
            {
                DataSet ds = new DataSet();
                //commented Condition only by gurmeet 1May
                //ds = CEI.GetTestReportDataIfPeriodic(InspectionId);
                ds = CEI.GetInspectionHistoryLogs(InspectionId);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    //commented by gurmeet 2-may-2025
                    //GridView2.Columns[3].Visible = false;
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    TestReport_Card.Visible = false;
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        protected void Grid_MultipleInspectionTR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   // Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
                    LinkButton linkButtonInvoice = (LinkButton)e.Row.FindControl("lnkInstallaionInvoice");
                    LinkButton LinkButtonReport = (LinkButton)e.Row.FindControl("lnkManufacturingReport");
                    //Only Condition Changed By Navneet 30-april-2025 
                    //if (LblInstallationName.Text.Trim() == "Line")
                    //{
                    if (LinkButtonReport.CommandArgument.ToString() == null || LinkButtonReport.CommandArgument.ToString() == "" || linkButtonInvoice.CommandArgument.ToString() == null)
                    {
                        Grid_MultipleInspectionTR.Columns[5].Visible = false;
                        Grid_MultipleInspectionTR.Columns[6].Visible = false;
                        linkButtonInvoice.Visible = false;
                        LinkButtonReport.Visible = false;
                    }
                    else
                    {
                        Grid_MultipleInspectionTR.Columns[5].Visible = true;
                        Grid_MultipleInspectionTR.Columns[6].Visible = true;
                        linkButtonInvoice.Visible = true;
                        LinkButtonReport.Visible = true;
                        // ViewState["AllRowsAreLine"] = false;
                    }
                }
            }
            catch
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
        protected void Grid_MultipleInspectionTR_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Count = string.Empty;
            string IntimationId = string.Empty;
            if (e.CommandName == "Select")
            {
                Control ctrl = e.CommandSource as Control;
                GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                Label LblInstallationName = (Label)row.FindControl("LblInstallationName");
                Label LblTestReportCount = (Label)row.FindControl("LblTestReportCount");
                //IntimationId = Session["id"].ToString();
                Count = LblTestReportCount.Text.Trim();
                Label LblIntimationId = (Label)row.FindControl("LblIntimationId");
                IntimationId = LblIntimationId.Text.Trim();
                DataSet ds = new DataSet();
                ds = CEI.GetData(LblInstallationName.Text.Trim(), IntimationId, Count);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        Session["LineID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                    }
                    else if (LblInstallationName.Text.Trim() == "Substation Transformer")
                    {
                        Session["SubStationID"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                    }
                    else if (LblInstallationName.Text.Trim() == "Generating Set")
                    {
                        Session["GeneratingSetId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                        Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
                    }
                }
            }
            else if (e.CommandName == "View")
            {
                string fileName = "";
                //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                //lblerror.Text = fileName;
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else if (e.CommandName == "ViewInvoice")
            {
                string fileName = "";
                //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
        }
        protected void lnkRedirectTRr_Click1(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Session["InspectionTestReportId"] = btn.CommandArgument;
                if (installationName == "Line")
                {
                    Response.Redirect("/TestReportModal/LineTestReportModal.aspx", false);
                }
                else if (installationName == "Substation Transformer")
                {
                    Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx", false);
                }
                else if (installationName == "Generating Set")
                {
                    Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session["AdminId"] = "";
                Response.Redirect("/AdminLogout.aspx", false);
            }
        }
    }
}
