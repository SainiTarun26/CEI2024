using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Periodic_Industry
{
    public partial class InspectionPeriodic : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id = string.Empty;
        DateTime inspectionCreatedDate;
        string voltage = string.Empty;
        string id = string.Empty;
        private static string IType = string.Empty;
        bool Edit = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LineID"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        id = Session["LineID"].ToString();

                    }
                    else if (Session["SubStationID"] != null && Convert.ToString(Session["SubStationID"]) != "")
                    {
                        id = Session["SubStationID"].ToString();
                    }
                    else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["GeneratingSetId"]) != "")
                    {
                        id = Session["GeneratingSetId"].ToString();
                    }

                    GetDetailsWithId();
                    GridBind();
                    //GetTestReportDataForIndustry();

                    if (IType == "New")
                    {
                        GetTestReportData();
                    }
                    else if (IType == "Periodic")
                    {
                        GetTestReportDataIfPeriodic();
                    }

                    //GetTestReportData();

                    Session["PreviousPage"] = "";
                    if (Convert.ToString(Session["Type"]) != null && Convert.ToString(Session["Type"]) != "")
                    {
                        if (Convert.ToString(Session["Type"]) == "Line" || Convert.ToString(Session["Type"]) == "Generating Set")
                        {
                            string voltage = txtVoltage.Text;
                            string voltagePart = voltage.Substring(0, voltage.Length - 2);
                            int.TryParse(voltagePart, out int voltageLevel);

                            if (voltageLevel <= 415)
                            {
                                if (DateTime.Now.Subtract(inspectionCreatedDate).TotalDays >= 1095)
                                {
                                    string script = "alert(\" Now You Can edit this inspection because your 3 years time period is complete for update\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                    btnSubmit.Visible = true;
                                    Edit = true;
                                    //RejectedColumn.Visible = true;
                                }
                                else
                                {
                                    string script = "alert(\"You Can't edit this inspection before 3 years\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                    btnSubmit.Visible = false;
                                }
                            }
                            else
                            {
                                if (DateTime.Now.Subtract(inspectionCreatedDate).TotalDays >= 365)
                                {
                                    string script = "alert(\"Now You Can edit this inspection because your annual time period is completed\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                    btnSubmit.Visible = true;
                                    Edit = true;
                                    //RejectedColumn.Visible = true;
                                }
                                else
                                {
                                    string script = "alert(\"You Can't edit this inspection before 1 year\");";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                    btnSubmit.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            if (DateTime.Now.Subtract(inspectionCreatedDate).TotalDays >= 365)
                            {
                                string script = "alert(\"Now You Can edit this inspection because your annual time period is completed\");";
                                ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                btnSubmit.Visible = true;
                                Edit = true;

                            }
                            else
                            {
                                string script = "alert(\"You Can't edit inspection before 1 year\");";
                                ScriptManager.RegisterStartupScript(this, GetType(), "abc", script, true);
                                btnSubmit.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        if (Session["LineID"] != null && Convert.ToString(Session["LineID"]) != "")
                        {
                            txtWorkType.Text = "Line";

                        }
                        else if (Session["SubStationID"] != null && Convert.ToString(Session["SubStationID"]) != "")
                        {

                            txtWorkType.Text = "Substation Transformer";

                        }
                        else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["GeneratingSetId"]) != "")
                        {
                            txtWorkType.Text = "Generating Set";

                        }
                    }

                    // Visibilty();
                }
            }
            catch (Exception ex)
            {
                //
            }


        }
        //private void GetTestReportDataForIndustry()
        //{
        //    string ID = Session["InspectionIdforNew"].ToString();
        //    DataSet ds = CEI.GetTestReportDataForIndustry(ID);

        //    List<string> testReportIds = new List<string>();
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        testReportIds.Add(row["TestReportId"].ToString());
        //    }
        //    Session["TestReportIds"] = testReportIds;
        //}
        private void GetTestReportDataIfPeriodic()
        {
            try
            {
                ID = Session["InspectionIdforNew"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataIfPeriodic(ID);
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
        public void GetDetailsWithId()
        {
            try
            {
                if (Session["InspectionIdforNew"] != null && !string.IsNullOrEmpty(Session["InspectionIdforNew"].ToString()))
                {
                    ID = Session["InspectionIdforNew"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.InspectionData(ID);

                    IType = ds.Tables[0].Rows[0]["IType"].ToString();

                    if (IType == "New")
                    {
                        txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        //txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        //txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                        Session["TestReport"] = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                        txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();

                        string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                        DateTime.TryParse(createdDate, out inspectionCreatedDate);
                        string InspectionType = ds.Tables[0].Rows[0]["IType"].ToString();
                        //if (InspectionType == "Periodic")
                        //{
                        //    voltagelevel.Visible = false;
                        //    Type.Visible = false;
                        //}
                        //else
                        //{
                        voltagelevel.Visible = true;
                        Type.Visible = true;
                        txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        txtInspectionType.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        //}
                        string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                        if (Status == "Rejected")
                        {
                            Rejection.Visible = true;
                            txtRejected.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                            ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                            //ApprovedReject.Visible = true;
                            //ApprovalRequired.Visible = false;
                            ddlReview.Attributes.Add("disabled", "true");
                            txtRejected.Attributes.Add("disabled", "true");
                            btnBack.Visible = true;
                            btnSubmit.Visible = false;
                        }
                        if (Status == "Return")
                        {
                            ApprovalRequired.Visible = false;
                            btnSubmit.Visible = false;

                            buttonSubmit.Visible = true;
                            Remarks.Visible = true;

                            //Rejection.Visible = true;
                            //txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                            //ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                            //ApprovedReject.Visible = true;
                            //ApprovalRequired.Visible = false;
                            ddlReview.Attributes.Add("disabled", "true");
                            //txtRejected.Attributes.Add("disabled", "true");
                        }
                        string Reason = ds.Tables[0].Rows[0]["ReasonType"].ToString();
                        if (Reason == "1")
                        {
                            buttonSubmit.Visible = false;
                            Remarks.Visible = false;

                        }
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RemarkForContractor"].ToString()))
                        {
                            // If not null or empty, disable the textbox
                            txtOwnerRemarks.Text = ds.Tables[0].Rows[0]["RemarkForContractor"].ToString();
                            txtOwnerRemarks.Enabled = false;
                            buttonSubmit.Enabled = false;
                        }
                    }
                    else if (IType == "Periodic")
                    {
                        txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        Session["TestReport"] = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                        txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();
                        Session["CartIdNew"] = ds.Tables[0].Rows[0]["CartId"].ToString();
                        string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                        DateTime.TryParse(createdDate, out inspectionCreatedDate);
                        string InspectionType = ds.Tables[0].Rows[0]["IType"].ToString();

                        
                        voltagelevel.Visible = false;
                        Type.Visible = false;
                        GridView2.Columns[3].Visible = false;
                        GridView2.Columns[5].Visible = false;

                        DivViewCart.Visible = true;
                        GridToViewCart();

                        string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                        if (Status == "Rejected")
                        {
                            Rejection.Visible = true;
                            txtRejected.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                            ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                            ddlReview.Attributes.Add("disabled", "true");
                            txtRejected.Attributes.Add("disabled", "true");
                            btnBack.Visible = true;
                            btnSubmit.Visible = false;
                        }
                        if (Status == "Return")
                        {
                            ApprovalRequired.Visible = false;
                            btnSubmit.Visible = false;

                            buttonSubmit.Visible = true;
                            Remarks.Visible = true;
                            ddlReview.Attributes.Add("disabled", "true");
                        }
                        string Reason = ds.Tables[0].Rows[0]["ReasonType"].ToString();
                        if (Reason == "1")
                        {
                            buttonSubmit.Visible = false;
                            Remarks.Visible = false;
                            btnReSubmit.Visible = true;

                        }
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RemarkForContractor"].ToString()))
                        {
                            txtOwnerRemarks.Text = ds.Tables[0].Rows[0]["RemarkForContractor"].ToString();
                            txtOwnerRemarks.Enabled = false;
                            buttonSubmit.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void GridToViewCart()
        {
            try
            {
                string ID = Session["InspectionIdforNew"].ToString();
                DataSet dsVC = CEI.GetDetailsToViewCart(ID);

                if (dsVC != null && dsVC.Tables.Count > 0 && dsVC.Tables[0].Rows.Count > 0)
                {
                    GridView3.DataSource = dsVC;
                    GridView3.DataBind();
                }
                else
                {
                    GridView3.DataSource = null;
                    GridView3.DataBind();
                    string script = "alert('No Record Found');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
            }
        }


        protected void GridBind()
        {
            try
            {
                ID = Session["InspectionIdforNew"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments(ID);
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
            catch (Exception ex)
            {
                //throw;
            }
        }

        private void GetTestReportData()
        {
            try
            {
                ID = Session["InspectionIdforNew"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport(ID);
                string TestRportId = string.Empty;
                if (ds != null && ds.Tables.Count > 0)
                {
                    //TestRportId = ds.Tables[0].Rows[0]["TestRportId"].ToString();
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
                //Session["TestRportId"] = TestRportId;
                ds.Dispose();
            }
            catch { }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    string ID = Session["InspectionIdforNew"].ToString();

                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();

                 
                    string script = $"window.open('{fileName}', '_blank');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenFileInNewTab", script, true);
                }
                
            }
            catch (Exception ex)
            {
                
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
                string testReportId = btn.CommandArgument;

                Session["InspectionTestReportId"] = btn.CommandArgument;

                string url = string.Empty;
                if (installationName == "Line")
                {
                    Session["LineID"] = testReportId;
                    url = "/TestReportModal/LineTestReportModal.aspx";
                }
                else if (installationName == "Substation Transformer")
                {
                    Session["SubStationID"] = testReportId;
                    url = "/TestReportModal/SubstationTransformerTestReportModal.aspx";
                }
                else if (installationName == "Generating Set")
                {
                    Session["GeneratingSetId"] = testReportId;
                    url = "/TestReportModal/GeneratingSetTestReportModal.aspx";
                }

                if (!string.IsNullOrEmpty(url))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "openWindow", $"window.open('{url}','_blank');", true);
                }
            }
            catch (Exception ex)
            {
                
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
            string testReportId = lnkRedirect.CommandArgument;
            //Session["InspectionTestReportId"] = testReportId;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Session["LineID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Session["SubStationID"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Session["GeneratingSetId"] = testReportId;
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            }
        }

        protected void btnReSubmit_Click(object sender, EventArgs e)
        {
           string id = Session["CartIdNew"].ToString();
            //string ID = Session["InspectionIdforNew"].ToString();
            Response.Redirect("/Periodic_Industry/InProcessRenewal_Industry.aspx", false);
        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
           
            ID = Session["InspectionIdforNew"].ToString();
            DataSet ds = new DataSet();
                if (IType == "Periodic")
                {
                    ds = CEI.sp_InsertRemarksForContractorINPeriodic_Industry(ID, txtOwnerRemarks.Text.Trim());
                }

             // txtOwnerRemarks.Text = ds.Tables[0].Rows[0]["RemarkForContractor"].ToString();
              ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata1();", true);
            
           
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Periodic_Industry/InspectionHistoryforIndustry.aspx", false);

        }
    }
}