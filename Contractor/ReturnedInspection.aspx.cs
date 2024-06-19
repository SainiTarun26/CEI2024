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
    public partial class ReturnedInspection : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ContractorId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
                {

                   
                    GetinspectionGridData();
                    GetGridData();
                    GetAssigenedGridData();
                }
            }
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

        public void GetAssigenedGridData()
        {
            try
            {
                if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
                {
                    ContractorId = Convert.ToString(Session["ContractorID"]);
                    ContractorId = Session["ContractorID"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.GetAssignedGridDataForContractor(ContractorId);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = ds;
                        GridView2.DataBind();                       
                    }
                    else
                    {
                       
                    }
                   // ds.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public void GetinspectionGridData()
        {
            if (Session["ContractorID"].ToString() != null && Session["ContractorID"].ToString() != "")
            {
                ContractorId = Convert.ToString(Session["ContractorID"]);                
                DataSet ds = new DataSet();
                ds = CEI.GetReturnInspectionForContractor(ContractorId);
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
                            Label lblTestReportId = (Label)row.FindControl("lblTestReportId");
                            int Count = Convert.ToInt32(TestReportCount.Text);

                            int inspectionId = Convert.ToInt32(row.Cells[1].Text);
                            //string TestReportId = row.Cells[2].Text;                           
                            string InstallationType = row.Cells[3].Text;

                            SqlCommand cmd = new SqlCommand("sp_InsertReturnInspectionAssignByContractor", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@InspectionId", inspectionId);
                            cmd.Parameters.AddWithValue("@IntimationId", lblIntimation.Text);
                            cmd.Parameters.AddWithValue("@InstallationType", InstallationType);
                            cmd.Parameters.AddWithValue("@Count", Count);
                            cmd.Parameters.AddWithValue("@TestReportId", lblTestReportId.Text);
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
                GetAssigenedGridData();
                ddlAssignSupervisor.SelectedValue = "-1";
                txtRemarksForSupervisor.Text = "";
                BtnSubmit.Enabled = true;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "ViewTestReport")
            {              
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblInstallationType = (Label)row.FindControl("LblInstallationType");
                string installationtype = lblInstallationType.Text;               
                string testReportId = e.CommandArgument.ToString();
                RedirectToRestReport(testReportId, installationtype);
                //if (installationtype == "Line")
                //{
                //    Session["LineID"] = testReportId;
                //    Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
                //}
                //else if (installationtype == "Substation Transformer")
                //{
                //    Session["SubStationID"] = testReportId;
                //    Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
                //}
                //else if (installationtype == "Generating Set")
                //{
                //    Session["GeneratingSetId"] = testReportId;
                //    Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
                //}
            }
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewTestReport")
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblInstallationType = (Label)row.FindControl("LblInstallationType");
                string installationtype = lblInstallationType.Text;
                string testReportId = e.CommandArgument.ToString();

                RedirectToRestReport(testReportId, installationtype);
                //if (installationtype == "Line")
                //{
                //    Session["LineID"] = testReportId;
                //    Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx','_blank');</script>");
                //}
                //else if (installationtype == "Substation Transformer")
                //{
                //    Session["SubStationID"] = testReportId;
                //    Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx','_blank');</script>");
                //}
                //else if (installationtype == "Generating Set")
                //{
                //    Session["GeneratingSetId"] = testReportId;
                //    Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx','_blank');</script>");
                //}
            }
        }

        private void RedirectToRestReport(string TestReportId,string Type)
        {
            Session["Approval"] = null;
            string Querystring = "?Return=returnd";
            if (Type == "Line")
            {
                Session["LineID"] = TestReportId;
                Response.Write("<script>window.open('/TestReportModal/LineTestReportModal.aspx"+Querystring +"','_blank');</script>");
            }
            else if (Type == "Substation Transformer")
            {
                Session["SubStationID"] = TestReportId;
                Response.Write("<script>window.open('/TestReportModal/SubstationTransformerTestReportModal.aspx" + Querystring + "','_blank');</script>");
            }
            else if (Type == "Generating Set")
            {
                Session["GeneratingSetId"] = TestReportId;
                Response.Write("<script>window.open('/TestReportModal/GeneratingSetTestReportModal.aspx" + Querystring + "','_blank');</script>");
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

        protected void lnkReadMore_Click(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;
            if (row != null)
            {
                Label lblOffRemarks = (Label)row.FindControl("lblOffRemarks");
                if (lblOffRemarks != null)
                {
                    lblModalOffRemarks.Text = lblOffRemarks.Text;
                }
                Label lblSORemarks = (Label)row.FindControl("lblSORemarks");
                if (lblSORemarks != null)
                {
                    lblModalSORemarks.Text = lblSORemarks.Text;
                }
                Label lblContRemarks = (Label)row.FindControl("lblContRemarks");
                if (lblContRemarks != null)
                {
                    lblModalContRemarks.Text = lblContRemarks.Text;
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#modal1').modal('show');", true);
        }

        protected void lnkReadMore_Click1(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)((Control)sender).NamingContainer;
            if (row != null)
            {

                ContractorRemarks.Visible = false;
                ContRemarks.Visible = false;
                Label lblOffRemarks = (Label)row.FindControl("LblRemarkForOfficer");
                if (lblOffRemarks != null)
                {
                    lblModalOffRemarks.Text = lblOffRemarks.Text;
                }
                Label lblSORemarks = (Label)row.FindControl("LblSiteOwnerInspectionRemark");
                if (lblSORemarks != null)
                {
                    lblModalSORemarks.Text = lblSORemarks.Text;
                }

            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#modal1').modal('show');", true);
        }
    }
}