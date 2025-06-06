﻿using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class InspectionHistory : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
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
            LoginID = Session["SiteOwnerId"].ToString();
            DataTable ds = new DataTable();
            ds = CEI.SiteOwnerInspectionData(LoginID);
            if (ds.Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                string script = "alert(\"Yet no Inspection is submitted.\");";
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
                Session["InspectionId"] = lblID.Text;
                Label lblApproval = (Label)row.FindControl("lblApproval");
                Session["Approval"] = lblApproval.Text.Trim();
                Label lblTestRportId = (Label)row.FindControl("lblTestRportId");
                Label lblType = (Label)row.FindControl("lblType");
                Label LblInspectionType = (Label)row.FindControl("LblInspectionType");
                Label LblAssignTo = (Label)row.FindControl("LblAssignTo"); 
                Label lblApproveDateLabel = row.FindControl("lblApproveDate") as Label;
                string ApproveDate = lblApproveDateLabel.Text;
                //Added By neeraj 22-May-2025
                Label lblApproveCertificate = row.FindControl("lblApproveCertificate") as Label;
                string ApproveCertificate = lblApproveCertificate.Text;
                //
                if (lblType.Text.Trim() == "Line")
                {
                    Session["LineID"] = lblTestRportId.Text.Trim();
                }
                else if (lblType.Text.Trim() == "Substation Transformer")
                {
                    Session["SubStationID"] = lblTestRportId.Text.Trim();
                }
                else if (lblType.Text.Trim() == "Generating Set")
                {
                    Session["GeneratingSetId"] = lblTestRportId.Text.Trim();
                }
                if (e.CommandName == "Select")
                {
                    if (lblType.Text.Trim() == "Escalator" || lblType.Text.Trim() == "Lift" || lblType.Text.Trim() == "Lift/Escalator" || lblType.Text.Trim() == "MultiLift" || lblType.Text.Trim() == "MultiEscalator")
                    {
                        Response.Redirect("/SiteOwnerPages/Inspection_Lift.aspx", false);
                    }
                    //Added By neeraj 22-May-2025
                    else if (lblType.Text.Trim() == "Cinema_Videos Talkies")
                    {
                        Response.Redirect("/SiteOwnerPages/InspectionDetailsCinema.aspx", false);
                    }//
                    else
                    {
                        Response.Redirect("/SiteOwnerPages/Inspection.aspx", false);
                    }

                }
                else if (e.CommandName == "Print")
                {
                    if ((lblType.Text == "Lift" || lblType.Text == "Lift/Escalator" || lblType.Text == "Escalator") && LblInspectionType.Text == "Periodic")
                    {
                        Response.Redirect("/SiteOwnerPages/Periodic_Lift_EscalatorInspectionRequestPrint.aspx");
                    }
                    else
                    {
                        Response.Redirect("/SiteOwnerPages/InspectionRequestPrint.aspx");
                    }

                }
                else if (e.CommandName == "Print1")
                {


                    if (LblInspectionType.Text == "New")
                    {
                        //Added By neeraj 22-May-2025
                        if (lblType.Text == "Cinema_Videos Talkies")
                        {
                            string fileName = lblApproveCertificate.Text;
                            string folderPath = Server.MapPath(fileName);
                            string filePath = Path.Combine(folderPath);
                            if (System.IO.File.Exists(filePath))
                            {
                                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                            }
                            else
                            {
                                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
                            }
                        }
                        //
                       else  if (lblType.Text != "Lift" && lblType.Text != "Escalator" && lblType.Text != "Lift/Escalator" && lblType.Text != "MultiLift" && lblType.Text != "MultiEscalator")
                            {
                                if (ApproveDate != null && DateTime.TryParse(ApproveDate, out DateTime lblApproveDate))
                                {
                                    DateTime comparisonDate = DateTime.Parse("2024-11-16");

                                    if (lblApproveDate <= comparisonDate)
                                    {
                                        Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                                    }
                                    else
                                    {
                                        Response.Redirect("/Print_Forms/NewInspectionApprovalCertificate.aspx", false);
                                    }

                                }
                            }
                            else if (lblType.Text == "Lift" || lblType.Text == "Escalator" || lblType.Text == "Lift/Escalator" || lblType.Text == "MultiLift" || lblType.Text == "MultiEscalator")
                            {

                                Response.Redirect("/SiteOwnerPages/LiftApprovalData.aspx", false);
                            }
                    }
                    else if (LblInspectionType.Text == "Periodic")
                    {
                        //Added By neeraj 22-May-2025
                        if (lblType.Text == "Cinema_Videos Talkies")
                        {
                            string fileName = lblApproveCertificate.Text;
                            string folderPath = Server.MapPath(fileName);
                            string filePath = Path.Combine(folderPath);
                            if (System.IO.File.Exists(filePath))
                            {
                                string script = $@"<script>window.open('{ResolveUrl(fileName)}','_blank');</script>";
                                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                            }
                            else
                            {
                                string errorMessage = "An error occurred: " + "Loading failed Please try Again later";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "erroralert", "alert('" + errorMessage.Replace("'", "\\'") + "')", true);
                            }
                        }//
                        else  if (lblType.Text != "Lift" && lblType.Text != "Escalator" && lblType.Text != "Lift/Escalator" && lblType.Text != "MultiLift" && lblType.Text != "MultiEscalator")
                        {
                            Response.Redirect("/Print_Forms/PeriodicApprovalCertificate.aspx", false);
                        }
                        else if (lblType.Text == "Lift" || lblType.Text == "Escalator" || lblType.Text == "Lift/Escalator" || lblType.Text == "MultiLift" || lblType.Text == "MultiEscalator")
                        {

                            Response.Redirect("/SiteOwnerPages/LiftApprovalData.aspx", false);
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
