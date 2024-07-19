using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Admin
{
    public partial class MultiplePeriodicInspectionDetail : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string Id, StaffTo, AssignFrom;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["LineID"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        txtWorkType.Text = "Line";
                        Id = Session["LineID"].ToString();
                    }
                    else if (Session["SubStationID"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        txtWorkType.Text = "Substation Transformer";
                        Id = Session["SubStationID"].ToString();
                    }
                    else if (Session["GeneratingSetId"] != null && Convert.ToString(Session["LineID"]) != "")
                    {
                        txtWorkType.Text = "Generating Station";
                        Id = Session["GeneratingSetId"].ToString();
                    }
                    else if (Session["PeriodicMultiple"] != null && Convert.ToString(Session["PeriodicMultiple"]) != "")
                    {
                        txtWorkType.Text = "Multiple";
                        Id = Session["PeriodicMultiple"].ToString();
                    }

                    GetDetailsWithId();

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
            }
        }

        private void GetDetailsWithId()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.PeriodicInspectionDataForAdmin(ID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (txtWorkType.Text != "Multiple") 
                    { 
                    txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    //txtInspectionType.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                    txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                    txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();
                    if (txtWorkType.Text == "Line")
                    {
                        Capacity.Visible = false;
                        //LineVoltage.Visible = true;
                        //txtLineVoltage.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    }
                    else
                    {
                        //LineVoltage.Visible = false;
                        Capacity.Visible = true;
                        txtCapacity.Text = ds.Tables[0].Rows[0]["Capacity"].ToString();
                    }
                    txtVoltage.Text = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                    txtTestReportId.Text = ds.Tables[0].Rows[0]["TestRportId"].ToString();

                    txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                    //txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                    //txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();

                    txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                    txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                    txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    }
                    else
                    {
                        txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                        txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                        //txtInspectionType.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();                        
                        txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                        txtWorkType.Text = ds.Tables[0].Rows[0]["InstallationType"].ToString();                        
                        txtVoltage.Text = ds.Tables[0].Rows[0]["MaxVoltage"].ToString();
                        TestReport.Visible = false;
                        txtCapacity.Text = ds.Tables[0].Rows[0]["TotalCapacity"].ToString();
                        txtSiteOwnerName.Text = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                        //txtContractorName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                        //txtSupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();

                        txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                        txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                    }
                    GridBindDocument();
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

        protected void grd_Documemnts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    ID = Session["InspectionId"].ToString();

                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDivisions.SelectedValue != "" && ddlDivisions.SelectedValue != null)
            {
                BindDropDownToAssign(ddlDivisions.SelectedValue);
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
                //msg.Text = ex.Message;
            }
        }

        protected void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                ApprovalRequired.Visible = true;
                DivToAssign.Visible = true;
                btnUpdate.Visible = true;
                btnAction.Visible = false;

            }
            catch (Exception ex)
            {
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["InspectionId"] != null && Convert.ToString(Session["InspectionId"]) != "" && Session["AdminID"] != null)
                {
                    ID = Session["InspectionId"].ToString();
                    AssignFrom = Session["AdminID"].ToString();
                    if (ddlToAssign.SelectedValue != null && ddlToAssign.SelectedValue != "0")
                    {
                        StaffTo = ddlToAssign.SelectedValue;
                        CEI.UpdateInspectionDataOnAction(ID, StaffTo, AssignFrom);

                        ddlDivisions.SelectedIndex = 0;
                        ddlToAssign.SelectedIndex = 0;

                        string script = $"alert('Inspection sent to {StaffTo} successfully.'); window.location='IntimationHistoryForAdmin.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);
                    }
                    else
                    {
                        ddlToAssign.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", "alert('Select Staff before save');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/PeriodicInspectionHistoryForAdmin.aspx");
        }

        private void GridBindDocument()
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
                    string script = "alert(\"No Record Found for document\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                ds.Dispose();
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        private void BindDivisions(string District)
        {
            DataSet ds = new DataSet();
            ds = CEI.GetDivisionData(District);
            ddlDivisions.DataSource = ds;
            ddlDivisions.DataTextField = "HeadOffice";
            ddlDivisions.DataValueField = "HeadOffice";
            ddlDivisions.DataBind();
            ddlDivisions.Items.Insert(0, new ListItem("Select", "0"));
            ds.Clear();
        }
    }
}