using CEI_PRoject;
using Pipelines.Sockets.Unofficial.Arenas;
using System;
using System.Collections.Generic;
using System.Data;
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

                    GetDetailsWithId();

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/Login.aspx");
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
        private void GetDetailsWithId()
        {
            try
            {
                ID = Session["InspectionId"].ToString();
                DataSet ds = new DataSet();
                ds = CEI.InspectionData(ID);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtInspectionReportId.Text = ds.Tables[0].Rows[0]["Id"].ToString();
                    txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                    txtPremises.Text = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
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

       

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/AdminMaster.aspx");
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
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
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

        protected void ddlDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDivisions.SelectedValue != "" && ddlDivisions.SelectedValue != null)
            {
                BindDropDownToAssign(ddlDivisions.SelectedValue);
            }
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
    }
}
