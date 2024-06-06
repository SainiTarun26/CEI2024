using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Officers
{
    public partial class InProcessInspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        private static int lineNumber = 0;

        private static string ApprovedorReject, Reason, StaffId, Suggestions;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {                    
                    if (Session["StaffID"] != null && Session["StaffID"].ToString() != "")
                    {
                        lineNumber = 0;
                        GetData();
                        GetTestReportData();
                        btnPreview.Visible = false;
                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }



        protected void lnkRedirect_Click(object sender, EventArgs e)
        {

            LinkButton lnkRedirect = (LinkButton)sender;
            string testReportId = lnkRedirect.CommandArgument;
            Session["InspectionTestReportId"] = testReportId;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
            }
        }
        private void GetData()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InspectionData(ID);

                txtInspectionReportID.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["TypeOfApplicant"].ToString();
                txtWorkType.Text = ds.Tables[0].Rows[0]["TypeOfInstallation"].ToString();
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
                txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["OwnerName"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["SiteownerAddress"].ToString();
                txtSiteOwnerContact.Text = ds.Tables[0].Rows[0]["SiteownerContactNumber"].ToString();
                txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                txtContractorPhoneNo.Text = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();
                txtContractorEmail.Text = ds.Tables[0].Rows[0]["ContractorEmail"].ToString();
                txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();
                txtSupervisorEmail.Text = ds.Tables[0].Rows[0]["SupervisorEmail"].ToString();
                txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();
                string SiteInspectionDate = ds.Tables[0].Rows[0]["InspectionDate"].ToString();
                GridBindDocument();
               
                string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                
                if (Status == "Approved")
                {
                    InspectionDate.Visible = false;
                    txtSuggestion.Text = ds.Tables[0].Rows[0]["Suggestion"].ToString();
                    if (!string.IsNullOrEmpty(txtSuggestion.Text))
                    {
                        Suggestion.Visible = true;
                        txtSuggestion.ReadOnly = true;
                    }
                    ddlReview.SelectedIndex = ddlReview.Items.IndexOf(ddlReview.Items.FindByText(Status));
                    ddlReview.Attributes.Add("disabled", "true");
                    txtSuggestion.Attributes.Add("disabled", "true");                    
                    
                    if(!string.IsNullOrEmpty(SiteInspectionDate))
                    {
                        InspectionDate.Visible = true;
                        txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        txtInspectionDate.Attributes.Add("disabled", "true");
                    }                    
                    btnBack.Visible = true;
                    btnSubmit.Visible = false;
                }
                if (Status == "Rejected")
                {
                    InspectionDate.Visible = false;

                    if (!string.IsNullOrEmpty(SiteInspectionDate))
                    {
                        InspectionDate.Visible = true;
                        txtInspectionDate.Text = DateTime.Parse(SiteInspectionDate).ToString("yyyy-MM-dd");
                        txtInspectionDate.Attributes.Add("disabled", "true");
                    }                    
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
                if(Status =="Return")
                {
                    InspectionDate.Visible = false;
                    ApprovalRequired.Visible = false;
                    btnSubmit.Visible = false;

                   // Rejection.Visible = true;
                   //txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                   ddlReview.Attributes.Add("disabled", "true");
                   //txtRejected.Attributes.Add("disabled", "true");
                   //txtRejected.ReadOnly = true;

                }

            }
            catch (Exception ex)
            {
                //
            }
        }
        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //ID = Session["InspectionId"].ToString();

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["InProcessInspectionId"].ToString() != null && Session["InProcessInspectionId"].ToString() != "" && Session["StaffID"].ToString() != null)
                {
                    StaffId = Session["StaffID"].ToString();
                    ID = Session["InProcessInspectionId"].ToString();
                    if (ddlReview.SelectedValue != null && ddlReview.SelectedValue != "" && ddlReview.SelectedValue != "0")
                    {
                        ApprovedorReject = ddlReview.SelectedItem.ToString();
                        Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text.Trim();

                        if (Suggestion.Visible == true)
                        {
                            Suggestions = string.IsNullOrEmpty(txtSuggestion.Text) ? null : txtSuggestion.Text.Trim();
                        }

                        CEI.InspectionFinalAction(ID, StaffId, ApprovedorReject, Reason, Suggestions, txtInspectionDate.Text);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata('" + ApprovedorReject + "');", true);

                    }
                    else
                    {
                        ddlReview.Focus();
                        return;
                    }
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

                
        protected void ddlSuggestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lineNumber == 0)
            {
                lineNumber = 1;
            }
            else
            {
                lineNumber++;
            }
            string selectedItemText = ddlSuggestion.SelectedItem.Text;
            txtSuggestion.Text += lineNumber + ". " + selectedItemText + "\n";
            ddlSuggestion.Items.Remove(ddlSuggestion.SelectedItem);
            //lineNumber++;
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlReview.SelectedValue == "1")
                {
                    if (Session["InProcessInspectionId"].ToString() != null && Session["InProcessInspectionId"].ToString() != "")
                    {
                        ID = Session["InProcessInspectionId"].ToString();

                        //DataSet ds = new DataSet();
                        //ds = CEI.checkPreviewInspection(Convert.ToInt32(ID));
                        //if (ds.Tables[0].Rows.Count > 0)
                        //{
                        //    btnPreview.Visible = false;
                        //    Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                        //}
                        //else
                        //{
                            SqlCommand cmd = new SqlCommand("Sp_insertTempInspection");
                            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                            cmd.Connection = con;
                            if (con.State == ConnectionState.Closed)
                            {
                                con.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                                con.Open();
                            }
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@inspectionId", ID);
                            cmd.Parameters.AddWithValue("@suggestion", txtSuggestion.Text.Trim());
                            cmd.Parameters.AddWithValue("@ReasionRejection", txtRejected.Text == null ? null : txtRejected.Text);
                            DateTime initialIssueDate;
                            if (DateTime.TryParse(txtInspectionDate.Text, out initialIssueDate) && initialIssueDate != DateTime.MinValue)
                            {
                                cmd.Parameters.AddWithValue("@inspectionDate", initialIssueDate);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@inspectionDate", DBNull.Value);
                            }
                            int x = cmd.ExecuteNonQuery();
                            con.Close();
                            if (x > 0)
                            {


                            }
                            btnPreview.Visible = false;
                            Response.Redirect("/Print_Forms/PrintCertificate1.aspx", false);
                        }
                   // }
                }                            
            }
            catch (Exception ex)
            {

                //throw;
            }
           
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/InProcessRequest.aspx", false);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {           
            Rejection.Visible = false;
            Suggestion.Visible = false;
            ddlSuggestions.Visible = false;
            btnPreview.Visible = false;
            if (ddlReview.SelectedValue == "2")
            {                              
                Rejection.Visible = true;                                         
            }
            else if (ddlReview.SelectedValue == "1")
            {
                btnPreview.Visible = true;
                ddlSuggestions.Visible = true;
                Suggestion.Visible = true;                      
            }
        }

        protected void GridBindDocument()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
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
            {
                //throw;
            }
        }
       
        private void GetTestReportData()
        {
            try
            {
                ID = Session["InProcessInspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.GetTestReport(ID);
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
            catch(Exception ex) { }
        }
    }
}