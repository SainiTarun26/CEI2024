using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Industry_Master
{
    public partial class NewInspectionDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id = string.Empty;
        DateTime inspectionCreatedDate;
        string voltage = string.Empty;
        string id = string.Empty;
        string CartId = string.Empty;
        string ReturnedBased = string.Empty;
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
                    getWorkIntimationData();
                    if (IType == "New")
                    {
                        GetTestReportData();
                    }
                    //else if (IType == "Periodic")
                    //{
                    //    GetTestReportDataIfPeriodic();
                    //}

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
                string script = "alert('" + ex.Message.Replace("'", "\\'") + "'); window.location = 'https://staging.investharyana.in/#/';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", script, true);
               // Response.Redirect("/login.aspx");
            }

        }
        private void getWorkIntimationData()
        {
            string IntimationId = Session["IntimationId"].ToString();
            string InspectionId = Session["InspId"].ToString();
            DataSet ds = new DataSet();
            ds = CEI.SiteOwnerInstallationsHistory_Industry(IntimationId, InspectionId);
            if (ds.Tables.Count > 0)
            {
                GridView4.DataSource = ds;
                GridView4.DataBind();
            }
            else
            {
                GridView4.DataSource = null;
                GridView4.DataBind();
                string script = "alert(\"No Record Found\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }
        //private void GetTestReportDataIfPeriodic()
        //{
        //    try
        //    {
        //        ID = Session["InspId"].ToString();
        //        DataSet ds = new DataSet();
        //        ds = CEI.GetTestReportDataIfPeriodic(ID);
        //        string TestRportId = string.Empty;
        //        if (ds != null && ds.Tables.Count > 0)
        //        {
        //            GridView2.DataSource = ds;
        //            GridView2.DataBind();
        //        }
        //        else
        //        {
        //            GridView2.DataSource = null;
        //            GridView2.DataBind();
        //            string script = "alert(\"No Record Found\");";
        //            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        //        }
        //        ds.Dispose();
        //    }
        //    catch { }
        //}
        public void GetDetailsWithId()
        {
            try
            {
                if (Session["InspId"] != null && !string.IsNullOrEmpty(Session["InspId"].ToString()))
                {
                    ID = Session["InspId"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.InspectionDataForIndustry(ID);

                    IType = ds.Tables[0].Rows[0]["IType"].ToString();

                    if (IType == "New")
                    {
                        txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        Session["TestReport"] = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                        txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();

                        string createdDate = ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                        DateTime.TryParse(createdDate, out inspectionCreatedDate);
                        string InspectionType = ds.Tables[0].Rows[0]["IType"].ToString();

                        voltagelevel.Visible = true;
                        Type.Visible = true;
                        txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                        txtInspectionType.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();

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
                            buttonSubmit.Visible = false;
                        }
                    }
                    else if (IType == "Periodic")
                    {
                        txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                        Session["TestReport"] = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                        txtApplicationNo.Text = ds.Tables[0].Rows[0]["InspectionReportID"].ToString();

                        ReturnedBased = ds.Tables[0].Rows[0]["ReasonType"].ToString();

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

                            if (ReturnedBased == "1")
                            {
                                btnResubmit.Visible = true;
                            }
                            else
                            {
                                btnResubmit.Visible = false;
                            }
                        }
                        string Reason = ds.Tables[0].Rows[0]["ReasonType"].ToString();
                        if (Reason == "1")
                        {
                            buttonSubmit.Visible = false;
                            Remarks.Visible = false;

                        }
                        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RemarkForContractor"].ToString()))
                        {
                            txtOwnerRemarks.Text = ds.Tables[0].Rows[0]["RemarkForContractor"].ToString();
                            txtOwnerRemarks.Enabled = false;
                            buttonSubmit.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    Control ctrl = e.CommandSource as Control;
                    GridViewRow row = ctrl.Parent.NamingContainer as GridViewRow;
                    Label lblCategory = (Label)row.FindControl("lblCategory");
                    string testReportId = e.CommandArgument.ToString();
                    //ID = Session["InspectionId"].ToString();
                    if (lblCategory.Text.Trim() == "Line")
                    {
                        Session["LineID"] = testReportId;
                        Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
                    }
                    else if (lblCategory.Text.Trim() == "Substation Transformer")
                    {
                        Session["SubStationID"] = testReportId;
                        Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
                    }
                    else if (lblCategory.Text.Trim() == "Generating Set")
                    {
                        Session["GeneratingSetId"] = testReportId;
                        Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
                    };

                }
                else if (e.CommandName == "View")
                {
                    fileName = "";
                    //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    //lblerror.Text = fileName;
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                }
            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }
        private void GridToViewCart()
        {
            try
            {
                string ID = Session["InspId"].ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["SiteOwnerId_Sld_Indus"] != null)
            {
                string Assign = string.Empty;
                string To = string.Empty;
                string input = txtVoltage.Text;
                string id = Session["LineID"].ToString();
                //string IntimationId = Session["IntimationId"].ToString();
                string CreatedBy = Session["SiteOwnerId_Sld_Indus"].ToString();
                string FileName = string.Empty;
                string flpPhotourl = string.Empty;
                string flpPhotourl1 = string.Empty;
                string flpPhotourl2 = string.Empty;
                string flpPhotourl3 = string.Empty;
                string flpPhotourl4 = string.Empty;
                string flpPhotourl5 = string.Empty;
                string flpPhotourl6 = string.Empty;
                string flpPhotourl7 = string.Empty;
                string flpPhotourl8 = string.Empty;
                string flpPhotourl9 = string.Empty;
                string flpPhotourl10 = string.Empty;
                string flpPhotourl11 = string.Empty;
                string flpPhotourl12 = string.Empty;
                //To = Session["District"].ToString();
                if (txtWorkType.Text == "Line")
                {
                    if (input.EndsWith("kv", StringComparison.OrdinalIgnoreCase))
                    {
                        string voltagePart = input.Substring(0, input.Length - 2);
                        if (int.TryParse(voltagePart, out int voltageLevel))
                        {
                            if (voltageLevel >= 11 && voltageLevel <= 33)
                            {
                                Assign = "SDO";
                            }
                            else if (voltageLevel >= 33)

                            {
                                Assign = "Admin@123";
                            }
                            else if (voltageLevel <= 11)

                            {
                                Assign = "JE";
                            }

                        }
                    }

                    else if (input.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                    {
                        Assign = "JE";

                    }
                }
                else
                {
                    if (input.EndsWith("KVA", StringComparison.OrdinalIgnoreCase))
                    {
                        string voltagePart = input.Substring(0, input.Length - 3);
                        if (int.TryParse(voltagePart, out int voltageLevel))
                        {
                            if (voltageLevel >= 250 && voltageLevel <= 500)
                            {
                                Assign = "XEN";
                            }
                            else if (voltageLevel >= 500)

                            {
                                Assign = "Admin@123";
                            }
                            else if (voltageLevel <= 250)
                            {
                                Assign = "SDO";
                            }
                        }

                    }
                    else if (input.EndsWith("MVA", StringComparison.OrdinalIgnoreCase))
                    {
                        Assign = "Admin@123";

                    }

                }
                #region Upload documents
               
                #endregion

                ID = Session["InspId"].ToString();
                //CEI.UpdateInspectionData(ID, id, txtPremises.Text, txtApplicantType.Text, txtWorkType.Text, txtVoltage.Text, flpPhotourl, flpPhotourl,
                //  flpPhotourl2, flpPhotourl3, flpPhotourl4, flpPhotourl5, flpPhotourl6, flpPhotourl7, flpPhotourl8,
                //  flpPhotourl9, flpPhotourl10, flpPhotourl11, flpPhotourl12, Assign, CreatedBy);

            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }
        protected void GridBind()
        {
            try
            {
                ID = Session["InspId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.ViewDocuments_Industry(ID);
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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ID = Session["InspId"].ToString();
                    if (e.CommandName == "Select")
                    {
                        //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        //lblerror.Text = fileName;
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        } 
        
        private void GetTestReportData()
        {
            try
            {
                ID = Session["InspId"].ToString();
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

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            string TestReportId = Session["TestReport"].ToString();
            ID = Session["InspId"].ToString();
            DataSet ds = new DataSet();
            if (IType == "New")
            {
                ds = CEI.ContractorRemarks(ID, TestReportId, txtOwnerRemarks.Text.Trim());
            }
            else if (IType == "Periodic")
            {
                ds = CEI.ContractorRemarksInPeriodic(ID, txtOwnerRemarks.Text.Trim());
            }
            //txtOwnerRemarks.Text = ds.Tables[0].Rows[0]["RemarkForContractor"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata1();", true);

        }

        protected void lnkRedirect1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);

                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblInstallationName = (Label)row.FindControl("LblInstallationName");
                string installationName = lblInstallationName.Text.Trim();
                LinkButton lnkRedirect1 = (LinkButton)sender;
                string testReportId = lnkRedirect1.CommandArgument;

                Session["InspectionTestReportId"] = btn.CommandArgument;

                if (installationName == "Line")
                {
                    Session["LineID"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
                }
                else if (installationName == "Substation Transformer")
                {
                    Session["SubStationID"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");

                }
                else if (installationName == "Generating Set")
                {
                    Session["GeneratingSetId"] = testReportId;
                    Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
                }
            }
            catch (Exception ex) { }
        }

        protected void btnResubmit_Click(object sender, EventArgs e)
        {
        //    ID = Session["InspId"].ToString();
        //    DataSet ds = new DataSet();
        //    ds = CEI.GetDetailsToViewCart(ID);

        //    CartId = ds.Tables[0].Rows[0]["CartId"].ToString();
        //    Session["IDCart"] = CartId;
        //    Response.Redirect("/SiteOwnerPages/ProcessInspectionRenewalCart.aspx", false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["PeriodicInspection"] != null)
            {
                //Response.Redirect("/SiteOwnerPages/PeroidicInspection.aspx", false);
            }
            else
            {
                Response.Redirect("/Industry_Master/NewInstallationStatus.aspx", false);
            }
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                getWorkIntimationData();
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
                    ID = Session["InspId"].ToString();
                    if (e.CommandName == "Select")
                    {
                        //fileName = "https://ceiharyana.com" + e.CommandArgument.ToString();
                        fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                        //lblerror.Text = fileName;
                        string script = $@"<script>window.open('{fileName}','_blank');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }

        protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblCategory = e.Row.FindControl("lblCategory") as Label;
                LinkButton LnkInvoice = e.Row.FindControl("LnkInovoice") as LinkButton;
                LinkButton lnkReport = e.Row.FindControl("lnkReport") as LinkButton;
                if (lblCategory.Text == "Line")
                {
                    LnkInvoice.Visible = false;
                    lnkReport.Visible = false;

                }
                else
                {
                    LnkInvoice.Visible = true;
                    lnkReport.Visible = true;

                }
            }
        }
    }
}