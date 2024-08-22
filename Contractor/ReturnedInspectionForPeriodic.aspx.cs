using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Contractor
{
    public partial class ReturnedInspectionForPeriodic : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ContractorId = string.Empty;
        private static string inspectionId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
                {
                    GetinspectionGridData();
                    GetGridData();
                }
            }
        }

        private void GetinspectionGridData()
        {
            if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
            {
                ContractorId = Convert.ToString(Session["ContractorID"]);
                DataSet ds = new DataSet();
                ds = CEI.GetReturnInspectionForContractorIfPeriodic(ContractorId);

                if (ds.Tables[0].Rows.Count > 0 && ds != null)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    AssignSupervisor.Visible = false;
                    BtnSubmit.Visible = false;
                }
            }
        }

        protected void lnkReadMore_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;
                if (row != null)
                {

                    ContractorRemarks.Visible = false;
                    ContRemarks.Visible = false;
                    Label lblOffRemarks = (Label)row.FindControl("LblOfficerRemark");
                    if (lblOffRemarks != null)
                    {
                        lblModalOffRemarks.Text = lblOffRemarks.Text;
                    }
                    Label lblSORemarks = (Label)row.FindControl("LblRemarkForContractor");
                    if (lblSORemarks != null)
                    {
                        lblModalSORemarks.Text = lblSORemarks.Text;
                    }

                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#modal1').modal('show');", true);
            }
            catch (Exception ex) { }
        }

        protected void lnkViewTestReport_Click(object sender, EventArgs e)
        {
            DivViewTestReport.Visible = true;

            //string inspectionId = null;
            LinkButton lnkViewTestReport = sender as LinkButton;
            if (lnkViewTestReport != null)
            {
                GridViewRow row = (GridViewRow)lnkViewTestReport.NamingContainer;
                Label lblInspectionId = (Label)row.FindControl("LblInspectionId");

                if (lblInspectionId != null)
                {
                    inspectionId = lblInspectionId.Text;
                }
            }
            GridToViewTestReport();
        }

        private void GridToViewTestReport()
        {
            try
            {
                DataSet dsVC = CEI.GetDetailsToViewCart(inspectionId);

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

        protected void lnkViewTR_Click(object sender, EventArgs e)
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

        public void GetGridData()
        {
            try
            {
                if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
                {
                    ContractorId = Session["ContractorID"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.WorkIntimationGridData(ContractorId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlAssignSupervisor.DataSource = ds;
                        ddlAssignSupervisor.DataValueField = "LicenseNo";
                        ddlAssignSupervisor.DataTextField = "LicenseNoText";
                        ddlAssignSupervisor.DataBind();
                        ddlAssignSupervisor.Items.Insert(0, new ListItem("--Select--", "-1"));
                        // ds.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            BtnSubmit.Enabled = false;
            if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
            {
                string AssignSupervisor = ddlAssignSupervisor.SelectedValue;
                bool AtLeastOneCheked = false;
                ContractorId = Convert.ToString(Session["ContractorID"]);
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString))
                {
                    con.Open();
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        CheckBox chk = (CheckBox)row.FindControl("CheckBox1");
                        if (chk != null && chk.Checked)
                        {
                            AtLeastOneCheked = true;
                            Label lblIntimation = (Label)row.FindControl("lblIntimation");
                            Label TestReportCount = (Label)row.FindControl("lblTestReportCount");
                            //Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                            //int Count = Convert.ToInt32(TestReportCount.Text);

                            int inspectionId = Convert.ToInt32(row.Cells[1].Text);
                            string InstallationType = row.Cells[3].Text;

                            SqlCommand cmd = new SqlCommand("sp_InsertReturnInspectionAssignByContractorIfPeriodic", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@InspectionId", inspectionId);
                            cmd.Parameters.AddWithValue("@IntimationId", lblIntimation.Text);
                            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                            //cmd.Parameters.AddWithValue("@Count", Count);
                            //cmd.Parameters.AddWithValue("@TestReportId", lblTestReportId.Text);
                            cmd.Parameters.AddWithValue("@AssignedSupervisore", AssignSupervisor);
                            cmd.Parameters.AddWithValue("@RemarksForSupervisor", string.IsNullOrEmpty(txtRemarksForSupervisor.Text.Trim()) ? null : txtRemarksForSupervisor.Text.Trim());
                            cmd.Parameters.AddWithValue("@CreatedBy", ContractorId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (!AtLeastOneCheked)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Please Tick Atleast One Test Report Before Submit'); ", true);
                    }
                }
                GetinspectionGridData();
                //GetAssigenedGridData();
                ddlAssignSupervisor.SelectedValue = "-1";
                txtRemarksForSupervisor.Text = "";
                BtnSubmit.Enabled = true;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    CheckBox chkSelectAll = (CheckBox)e.Row.FindControl("chkSelectAll");
                    chkSelectAll.Attributes.Add("onclick", "SelectAllCheckboxes(this)");
                }
            }
            catch { }
        }
    }
}