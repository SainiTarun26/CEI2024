﻿using CEI_PRoject;
using CEIHaryana.SiteOwnerPages;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class LiftInspectionDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Type = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["StaffID"] != null && Session["StaffID"].ToString() != "" && Convert.ToString(Session["InspectionId"]) != null && Convert.ToString(Session["InspectionId"]) != string.Empty)
            {
                string inspectionId = Session["InspectionId"]?.ToString();

                if (!string.IsNullOrEmpty(inspectionId))
                {
                    GetData(inspectionId);
                }

            }
            else
            {
                Session["StaffID"] = "";
                Response.Redirect("/OfficerLogout.aspx", false);
            }
        }
        private void GetData(string inspectionId)
        {
            try
            {
                string ID = inspectionId;
                DataSet ds = new DataSet();
                ds = CEI.InspectionDataFor_Lift(ID);
                Type = ds.Tables[0].Rows[0]["IType"].ToString();
                lblInspectionType.Text = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                lblInstallation.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();

                if (Type == "New")
                {
                    txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();

                    txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    Session["InstallationType"] = txtWorkType.Text;

                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                    txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                    string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                    Session["InspectionType"] = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    string ReturnValu = ds.Tables[0].Rows[0]["ReturnedBasedOnDocumentValue"].ToString();
                    GridBindDocument(ID);
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    //txtAmount.Visible = false;
                    // Added by gurmeet on 23-07
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                    txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtOwnerDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtUserType.Text = ds.Tables[0].Rows[0]["UserType"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    if (txtAmount.Text == "0")
                    {
                        //TranscationDetails.Visible = false;   // comment by gurmeet on 23-07
                    }
                    else
                    {

                        TranscationDetails.Visible = true;

                    }

                    txtelectrical.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Firm/Company")
                    {
                        agency.Visible = true;
                        individual.Visible = false;
                        txtagency.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtagency.ReadOnly = true;

                        DivOtherDepartment.Visible = true;
                        DivPancard_TanNo.Visible = false;
                        txtTanNumber.Text = ds.Tables[0].Rows[0]["PanOrTan"].ToString();


                    }
                    else if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Individual Person")
                    {
                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtSiteOwnerName.ReadOnly = true;
                        DivPancard_TanNo.Visible = true;
                        DivOtherDepartment.Visible = false;
                        txtPAN.Text = ds.Tables[0].Rows[0]["PanOrTan"].ToString();
                    }

                    string Division = ds.Tables[0].Rows[0]["Division"].ToString();

                    DivViewTRinMultipleCaseNew.Visible = true;
                    GridToViewMultipleCaseNew(ID);
                    if (ReturnValu == "1")
                    {
                        grd_Documemnts.Columns[3].Visible = true;
                        //grd_Documemnts.Columns[4].Visible = true;

                    }
                    else if (ReturnValu == "3")
                    {

                        grd_Documemnts.Columns[3].Visible = true;
                        //grd_Documemnts.Columns[4].Visible = true;
                        Grid_MultipleInspectionTR.Columns[5].Visible = true;
                        Grid_MultipleInspectionTR.Columns[6].Visible = true;
                        Grid_MultipleInspectionTR.Columns[7].Visible = true;
                        Grid_MultipleInspectionTR.Columns[8].Visible = true;
                        Grid_MultipleInspectionTR.Columns[9].Visible = true;
                    }
                    else if (ReturnValu == "2")
                    {

                        grd_Documemnts.Columns[3].Visible = false;
                        //grd_Documemnts.Columns[4].Visible = false;

                    }
                    else
                    {
                        grd_Documemnts.Columns[3].Visible = true;
                        // grd_Documemnts.Columns[4].Visible = false;

                    }

                    txtAction.Text = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    Session["ApplicationStatus"] = txtAction.Text;

                    if (txtAction.Text == "Return")
                    {
                        GetTestReportData_Return(ID);
                    }
                    else
                    {
                        GetTestReportData(ID);
                    }



                }
                else if (Type == "Periodic")
                {
                    //grd_Documemnts.Columns[4].Visible = false;
                    txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    //InspectionType.Visible = false;
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
                    Session["InstallationType"] = txtWorkType.Text;
                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    // Added by gurmeet on 23-07
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                    txtContactNo.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                    txtOwnerDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtUserType.Text = ds.Tables[0].Rows[0]["UserType"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();

                    if (txtAmount.Text == "0")
                    {
                       // TranscationDetails.Visible = false;
                    }
                    else
                    {

                        TranscationDetails.Visible = true;

                    }

                    txtelectrical.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                    if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Firm/Company")
                    {
                        agency.Visible = true;
                        individual.Visible = false;
                        txtagency.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtagency.ReadOnly = true;

                        DivOtherDepartment.Visible = true;
                        DivPancard_TanNo.Visible = false;
                        txtTanNumber.Text = ds.Tables[0].Rows[0]["PanOrTan"].ToString();


                    }
                    else if (ds.Tables[0].Rows[0]["ContractorType"].ToString() == "Individual Person")
                    {
                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                        txtSiteOwnerName.ReadOnly = true;
                        DivPancard_TanNo.Visible = true;
                        DivOtherDepartment.Visible = false;
                        txtPAN.Text = ds.Tables[0].Rows[0]["PanOrTan"].ToString();
                    }

                    Session["InspectionType"] = ds.Tables[0].Rows[0]["Type_of_Inspection"].ToString();
                    string Division = ds.Tables[0].Rows[0]["Division"].ToString();

                    Address.Visible = true;
                    txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();

                    string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                    grd_Documemnts.Columns[1].Visible = true;

                    GridView1.Columns[5].Visible = false;
                    GridView1.Columns[3].Visible = false;

                    DivTestReports.Visible = true;
                    GridToViewTestReports(ID);

                    GridBindDocument(ID);

                    txtAction.Text = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                    Session["ApplicationStatus"] = txtAction.Text;
                    if (txtAction.Text == "Return")
                    {
                        GetTestReportDataIfPeriodic_Return(ID);
                    }
                    else
                    {
                        GetTestReportDataIfPeriodic(ID);
                    }


                }
            }
            catch (Exception ex)
            {
            }
        }
        private void GetTestReportDataIfPeriodic(string inspectionId)
        {
            try
            {
                string ID = inspectionId;
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataIfPeriodic_Lift(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
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
            catch (Exception ex) { }
        }

        private void GetTestReportDataIfPeriodic_Return(string inspectionId)
        {
            try
            {
                string ID = inspectionId;
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataIfPeriodicLift_Return(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
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
            catch (Exception ex) { }
        }
        private void GridToViewTestReports(string inspectionId)
        {
            try
            {
                string ID = inspectionId;
                //string ID = Session["InspectionId"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewCart_Lift_Escalator(ID);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = dsVC;
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {

            }
        }



        private void GetTestReportData_Return(string inspectionId)
        {
            try
            {
                string ID = inspectionId;
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportLift_Return(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
                {
                    //TestRportId = ds.Tables[0].Rows[0]["TestRportId"].ToString();
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
                //Session["TestRportId"] = TestRportId;

                ds.Dispose();
            }
            catch (Exception ex) { }
        }


        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //ID = Session["InspectionId"].ToString();
                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }

            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();
                Label lblSubmittedDate = (Label)e.Row.FindControl("lblSubmittedDate");
                Session["lblSubmittedDate"] = lblSubmittedDate.Text;
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
        protected void lnkRedirect1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Label LblRegistrationNo = (Label)row.FindControl("LblRegistrationNo");
                Label LblTestReportId = (Label)row.FindControl("lblTestReport");
                Session["RegistrationNo"] = LblRegistrationNo.Text;
                Session["TestReportID"] = LblTestReportId.Text;

                if (lblInstallationName != null)
                {
                    if (lblInstallationName.Text == "Lift")
                    {
                        Response.Redirect("/TestReportModal/LiftPeriodicTestReportModal.aspx", false);
                    }
                    else if (lblInstallationName.Text == "Escalator")
                    {
                        Response.Redirect("/TestReportModal/EscalatorPeriodicTestReportModal.aspx", false);
                    }
                }

            }
            catch (Exception ex) { }
        }

        private void GridToViewMultipleCaseNew(string inspectionId)
        {
            try
            {
                string ID = inspectionId;
                DataTable dsVC = CEI.InstallationComponentsforLift(ID);

                if (dsVC != null && dsVC.Rows.Count > 0)
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
            {
                // Log or handle the exception as needed
            }
        }

        protected void GridBindDocument(string inspectionId)
        {
            try
            {
                string ID = inspectionId;
                DataSet ds = new DataSet();
                ds = CEI.ViewReturnDocuments_Lift(ID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grd_Documemnts.DataSource = ds;
                    grd_Documemnts.DataBind();
                    statement.Visible = false;
                }
                else
                {
                    grd_Documemnts.DataSource = null;
                    grd_Documemnts.DataBind();
                    //string script = "alert(\"No Record Found\");";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    statement.Visible = true;
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {
                //throw;
            }
        }
        private void GetTestReportData(string inspectionId)
        {
            try
            {
                string ID = inspectionId;
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport_Lift(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
                {
                    //TestRportId = ds.Tables[0].Rows[0]["TestRportId"].ToString();
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
                //Session["TestRportId"] = TestRportId;

                ds.Dispose();
            }
            catch (Exception ex) { }
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
            {
                // Log or handle the exception as needed
            }
        }

        protected void Grid_MultipleInspectionTR_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["InspectionId"] == null || string.IsNullOrWhiteSpace(Session["InspectionId"].ToString()))
            {
                Response.Redirect("/OfficerLogout.aspx", false);
                return;
            }

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
                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");
                //DataSet ds = new DataSet();
                //ds = CEI.GetData(LblInstallationName.Text.Trim(), IntimationId, Count);
                //if (ds.Tables[0].Rows.Count > 0)
                //{

                if (LblInstallationName != null)
                {
                    if (LblInstallationName.Text == "Lift")
                    {
                        Session["LiftTestReportID"] = LblTestReportId.Text;
                        Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
                    }
                    else if (LblInstallationName.Text == "Escalator")
                    {
                        Session["EscalatorTestReportID"] = LblTestReportId.Text;
                        Response.Redirect("/TestReportModal/EscalatorTestReportModal.aspx", false);
                    }
                }

            }

            //else if (e.CommandName == "View")
            //{
            //    string fileName = "";
            //    // fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
            //    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
            //    //lblerror.Text = fileName;
            //    string script = $@"<script>window.open('{fileName}','_blank');</script>";
            //    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            //}
            //else if (e.CommandName == "ViewInvoice")
            //{
            //    string fileName = "";
            //    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
            //    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
            //    string script = $@"<script>window.open('{fileName}','_blank');</script>";
            //    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
            //}
            String ID = Session["InspectionId"].ToString();
            GetData(ID);


        }

        protected void lnkRedirectTR_Click1(object sender, EventArgs e)
        {

            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                Label LblTestReportId = (Label)row.FindControl("LblTestReportId");

                if (lblInstallationName != null)
                {
                    if (lblInstallationName.Text == "Lift")
                    {
                        Session["LiftTestReportID"] = LblTestReportId.Text;
                        Response.Redirect("/TestReportModal/LiftTestReportModal.aspx", false);
                    }
                    else if (lblInstallationName.Text == "Escalator")
                    {
                        Session["EscalatorTestReportID"] = LblTestReportId.Text;
                        Response.Redirect("/TestReportModal/EscalatorTestReportModal.aspx", false);
                    }
                }


            }
            catch (Exception ex) { }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/OfficerDashboard.aspx", false);

        }
    }
}