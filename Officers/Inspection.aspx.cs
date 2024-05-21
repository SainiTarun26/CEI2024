using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;

namespace CEIHaryana.Officers
{
    public partial class Inspection : System.Web.UI.Page
    {

        CEI CEI = new CEI();
        private static int count;
        private static string IntimationId, AcceptorReturn, Reason, StaffId;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetData();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }

        public void GetData()
        {
            try
            {
                ID = Session["InspectionId"].ToString();

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
                txtTransactionId.Text = ds.Tables[0].Rows[0]["TransactionId"].ToString();
                txtTranscationDate.Text = ds.Tables[0].Rows[0]["TransactionDate1"].ToString();


                count = Convert.ToInt32(ds.Tables[0].Rows[0]["TestReportCount"].ToString());           //Added     
                IntimationId = ds.Tables[0].Rows[0]["IntimationId"].ToString();

                GridBindDocument();
                string Status = ds.Tables[0].Rows[0]["ApplicationStatus"].ToString();

                if (Status.Trim() == "InProcess")
                {
                    RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("0"));
                    RadioButtonList2.Attributes.Add("disabled", "true");
                    RadioButtonList2.Enabled = false;
                    btnBack.Visible = true;
                    btnSubmit.Visible = false;
                }
                else if (Status.Trim() == "Return")
                {
                    RadioButtonList2.SelectedIndex = RadioButtonList2.Items.IndexOf(RadioButtonList2.Items.FindByValue("1"));
                    RadioButtonList2.Attributes.Add("disabled", "true");
                    RadioButtonList2.Enabled = false;
                    Rejection.Visible = true;
                    txtRejected.Text = ds.Tables[0].Rows[0]["ReturnRemarks"].ToString();
                    txtRejected.Attributes.Add("disabled", "true");

                    btnBack.Visible = true;
                    btnSubmit.Visible = false;
                }
                else if (Status.Trim() == "Approved" || Status.Trim() == "Rejected")
                {
                    RadioButtonList2.Enabled = false;
                    txtRejected.Attributes.Add("disabled", "true");
                    btnBack.Visible = true;
                    btnSubmit.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected void lnkRedirect_Click(object sender, EventArgs e)
        {
            Session["InspectionTestReportId"] = txtTestReportId.Text;
            if (txtWorkType.Text.Trim() == "Line")
            {
                Response.Redirect("/TestReportModal/LineTestReportModal.aspx");
            }
            else if (txtWorkType.Text.Trim() == "Substation Transformer")
            {
                Response.Redirect("/TestReportModal/SubstationTransformerTestReportModal.aspx");
            }
            else if (txtWorkType.Text.Trim() == "Generating Set")
            {
                Response.Redirect("/TestReportModal/GeneratingSetTestReportModal.aspx");
            }

        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Rejection.Visible = false;
                if (RadioButtonList2.SelectedValue == "0")
                {
                    Rejection.Visible = false;
                }
                else if (RadioButtonList2.SelectedValue == "1")
                {
                    Rejection.Visible = true;
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

        protected void ddlReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlReview.SelectedValue == "2")
            //{
            //    Rejection.Visible = true;
            //}
            //else
            //{
            //    Rejection.Visible = false;
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["InspectionId"].ToString() != null && Session["InspectionId"].ToString() != "" && Session["StaffID"].ToString() != null)
                {
                    StaffId = Session["StaffID"].ToString();
                    ID = Session["InspectionId"].ToString();

                    if (RadioButtonList2.SelectedValue != "" && RadioButtonList2.SelectedValue != null)
                    {
                        AcceptorReturn = RadioButtonList2.SelectedValue == "0" ? "Accepted" : "Return";
                        Reason = string.IsNullOrEmpty(txtRejected.Text) ? null : txtRejected.Text;

                        CEI.updateInspection(ID, StaffId, IntimationId, count, txtWorkType.Text.Trim(), AcceptorReturn, Reason, ddlReasonType.SelectedItem.Value);

                        if (AcceptorReturn == "Accepted")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        }
                        else
                        {
                            if (ddlReasonType.SelectedItem.Value == "0") //Based On Test Report Returned
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataSupervisorReturn();", true);
                            }
                            if (ddlReasonType.SelectedItem.Value == "1") //Based On Documents Returned 
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataReturn();", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorMessage", "alert('Please select the yes or no');", true);
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
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Officers/InstallationIntimationDetails.aspx", false);

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
            {

                //throw;
            }
        }
    }
}
