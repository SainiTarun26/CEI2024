using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;
using Pipelines.Sockets.Unofficial.Arenas;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class ReapplyReturnINspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["InspectionId"] != null && !string.IsNullOrEmpty(Session["InspectionId"].ToString()))
                {
                    GetInspectionDetails();
                    GridToViewTRinMultipleCaseNew();
                    GridBindDocument();
                    GetInspectionData();
                }
            }
            catch (Exception ex)
            { }
        }
        private void GetInspectionDetails()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetInspectionReport(ID);

                txtInspectionId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                txtMaxVoltage.Text = ds.Tables[0].Rows[0]["MaxVoltage"].ToString();
                txtCapacity.Text = ds.Tables[0].Rows[0]["TotalCapacity"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();

                txttransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                txttransactionDate.Text = ds.Tables[0].Rows[0]["TransctionDate"].ToString();

            }
            catch (Exception ex)
            { }
        }
        private void GridToViewTRinMultipleCaseNew()
        {
            try
            {
                string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewTRinMultipleCaseNew(ID);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    Grid_MultipleInspectionTR.DataSource = dsVC;
                    Grid_MultipleInspectionTR.DataBind();
                }
                else
                {
                    Grid_MultipleInspectionTR.DataSource = null;
                    Grid_MultipleInspectionTR.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            { }
        }
        protected void GridBindDocument()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
                if (ds.Tables.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            { }
        }
        private void GetInspectionData()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetInspectionReport(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    string script = "alert(\"No Record Found\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch { }
        }
        protected void Grid_MultipleInspectionTR_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    Label LblInstallationName = (Label)e.Row.FindControl("LblInstallationName");
                    LinkButton linkButtonInvoice = (LinkButton)e.Row.FindControl("lnkInstallaionInvoice");
                    LinkButton LinkButtonReport = (LinkButton)e.Row.FindControl("lnkManufacturingReport");
                    FileUpload UploadInstallaionInvoice = (FileUpload)e.Row.FindControl("FileUploadInstallaionInvoice");
                    FileUpload UploadManufacturingReport = (FileUpload)e.Row.FindControl("FileUploadManufacturingReport");
                    if (LblInstallationName.Text.Trim() == "Line")
                    {
                        linkButtonInvoice.Visible = false;
                        LinkButtonReport.Visible = false;
                        UploadInstallaionInvoice.Visible = false;
                        UploadManufacturingReport.Visible = false;
                    }
                    else
                    {
                        linkButtonInvoice.Visible = true;
                        LinkButtonReport.Visible = true;
                        UploadInstallaionInvoice.Visible = true;
                        UploadManufacturingReport.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {}
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/ReturnInspections.aspx", false);
        }
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            {
                string fileName = "";
                try
                {
                    if (e.CommandName == "Select")
                    {
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                }
                catch (Exception ex)
                { }
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
                //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }
            else if (e.CommandName == "ViewInvoice")
            {
                string fileName = "";
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex) { }
        }
    }
}